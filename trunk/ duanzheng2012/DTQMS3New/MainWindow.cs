using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTQMS3New.Classes;
using System.Threading;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace DTQMS3New
{
    public partial class MainWindow : Form
    {
        //文件被打开标识
        object bRead = new object();

        //读卡线程
        private Thread readCardThread;

        //更新数据线程
        private Thread updateDBThread;

        //更新界面数据委托
        delegate void updateUI(Task card);


        updateUI fUpui;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Process.Start("转运中心.exe");
            this.dgvMsg.AutoGenerateColumns = false;
            CommonData.errorLabel = lblError;

            //登录摄像头
            StreamReader sr = new StreamReader("xdview.cfg");
            xDview.URL = sr.ReadLine();
            xDview.Port = int.Parse(sr.ReadLine());
            xDview.UserName = sr.ReadLine();
            xDview.UserPswd = sr.ReadLine();
            xDview.ChannelNum = "0";
            int r = xDview.LoginNVS();
            xDview.StartView();


           

            //读取配置文件
            //查询垃圾楼信息
            string sql = "SELECT * FROM [dbo.Station]";
            BaseOperate op = new BaseOperate();
            DataSet ds = op.getds(sql,"[dbo.Station]");
            if (ds.Tables.Count != 0)
                CommonData.stations = ds.Tables[0];
            bgwUpdateUI_DoWork();
            //创建读卡线程
            readCardThread = new Thread(this.readCard);

            readCardThread.Start();

            //创建更新数据线程
            updateDBThread = new Thread(this.updateDB);

            updateDBThread.Start();

            //设置UI代理
            fUpui = updateUIFunc;

            this.lblStation.Text = CommonData.stationName;
           
        }

        private void updateUIFunc(Task card)
        {
            //更新Label
            this.lblType.Text = card.Type.ToString();
            this.lblTruck.Text = card.CarNum;
            this.lblStartTime.Text = card.StartTime;
            this.lblStartStation.Text = CommonData.stations.GetValueByKey("StationID",card.StartSpot,"Name").ToString();
            this.lblEndTime.Text = card.EndTime;
            this.label9.Text = card.weight.ToString();
            if (card.cardStatus != 0)
                this.label11.Text = (card.weight - card.nweight).ToString();
            else
                this.label11.Text = "未知";
            bgwUpdateUI_DoWork();
        }

        #region 读卡线程

        private void readCard()
        {
            if (!UHF.connect())
                return;
            CommPort cmp = new CommPort();
            try
            {
                cmp.loadData();
                cmp.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开称重器端口有误！");
                return;
            }
            

            while (true)
            {
                Task card = new Task();
                UHF.requestID(ref card);
                try
                {
                    if (card.BOXID.Substring(0, 3) != "300")
                        continue;
                }
                catch
                {
                    continue;
                }

                if (!card.status)
                    continue;
                UHF.requestData(ref card);
                if (card.status)
                {
                    //设置到站时间
                    card.EndTime = DateTime.Now.ToString("yy-MM-dd,HH:mm");
                    //循环5次读取重量
                    for (int i = 0; i < 5; i++)
                    {
                        byte[] data = cmp.Read(8).Reverse<byte>().ToArray();
                        string str = "";
                        for (int j = 0; j < 8; i++)
                            str += data[j].ToString();
                        if (card.cardStatus == 0)
                        {
                            if (card.weight > int.Parse(str))
                                card.weight = int.Parse(str);
                        }
                        else
                        {
                            if (card.nweight > int.Parse(str))
                                card.nweight = int.Parse(str);
                        }
                    }

                    //如果为下行，则从数据库中读取重量
                    if (card.cardStatus == 1)
                    {
                        BaseOperate op = new BaseOperate();
                        string sql = "SELECT Weight FROM [dbo.Goods] WHERE " + "\r\nWHERE (StartTime = '" + card.StartTime + "')  AND (TruckNo='" + card.CarNum + "')";
                        card.weight = int.Parse(op.getds(sql,"[dbo.Goods]").Tables[0].Rows[0][0].ToString());
                    }
                    ////抓拍车牌号
                    xDview.ChannelCapture(0);
                    //将图片保存
                    card.picPath = xDview.CaptureChannel(0);
                    //将信息保存到data.xml中
                    CommonData.data.Add(card);
                    

                    //更新UI界面
                    this.Invoke(fUpui, new Object[] { card });
                }
            }
        }

        #endregion

        #region 更新数据线程

        private void updateDB()
        {
            while (true)
            {
                      XmlDocument xdoc = new XmlDocument();
                      if (CommonData.data.Count > CommonData.curUpdateIndex)
                      {
                          xdoc.Load("data.xml");
                          //添加数据
                          for (; CommonData.curUpdateIndex < CommonData.data.Count; CommonData.curUpdateIndex++)
                          {
                              Task item = CommonData.data[CommonData.curUpdateIndex];
                              XmlElement newNode = xdoc.CreateElement("Data");
                              newNode.SetAttribute("TruckNo", item.CarNum);
                              newNode.SetAttribute("StartTime", item.StartTime);
                              newNode.SetAttribute("EndTime", item.EndTime);
                              newNode.SetAttribute("StartStationID", item.StartSpot.ToString());
                              newNode.SetAttribute("Weight",item.weight.ToString());
                              newNode.SetAttribute("picPath",item.picPath);
                              newNode.SetAttribute("cardStatus",item.cardStatus.ToString());
                              newNode.SetAttribute("nweight", item.nweight.ToString());
                              xdoc.SelectSingleNode("Datas").AppendChild(newNode);
                          }
                          xdoc.Save("data.xml");
                      }
                        xdoc.Load("data.xml");
                        if (xdoc.SelectSingleNode("Datas").ChildNodes.Count <= 0)
                            continue;
                        
                        Task card = new Task();
                        XmlNode xRoot = xdoc.SelectSingleNode("Datas").ChildNodes[0];
                        card.StartSpot = int.Parse(xRoot.Attributes["StartStationID"].Value);
                        card.StartTime = xRoot.Attributes["StartTime"].Value;
                        card.EndTime = xRoot.Attributes["EndTime"].Value;
                        card.CarNum = xRoot.Attributes["TruckNo"].Value;
                        card.cardStatus = int.Parse(xRoot.Attributes["cardStatus"].Value);
                        card.weight = int.Parse(xRoot.Attributes["Weight"].Value);
                        card.nweight = int.Parse(xRoot.Attributes["nweight"].Value);
                        card.picPath = xRoot.Attributes["picPath"].Value;

                        string sql;
                        if (card.cardStatus == 0)
                        {
                            //更新数据
                            sql = "UPDATE [dbo.Goods]\r\nSET [EndTime]='" + card.EndTime + "',weight="+card.weight+",EndStationID=" + CommonData.stationID + ",picPath='" + card.picPath + "'\r" +
                            "\nWHERE (StartTime = '" + card.StartTime + "')  AND (TruckNo='" + card.CarNum + "')";
                        }
                        else
                        {
                            sql = "UPDATE [dbo.Goods]\r\nSET Weight=" +(card.weight-card.nweight)+
                            "\r\nWHERE (StartTime = '" + card.StartTime + "')  AND (TruckNo='" + card.CarNum + "')";
                        }
                        BaseOperate op = new BaseOperate();
                        if (op.getcom(sql))
                        {
                            this.lblError.Text = "";
                            //删除节点 
                            if (xdoc.SelectSingleNode("Datas") != null && xdoc.SelectSingleNode("Datas").ChildNodes.Count > 0)
                            {
                                xdoc.SelectSingleNode("Datas").RemoveChild(xRoot);
                                xdoc.Save("data.xml");
                            }
                        }
                        else
                        {
                            this.lblError.Text = "网络异常！";
                        }

            }
        }

        #endregion

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                readCardThread.Abort();
                updateDBThread.Abort();
            }
            catch
            { 
                
            }
        }

        private void groupCard_Enter(object sender, EventArgs e)
        {

        }

        private void panelTtile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bgwUpdateUI_DoWork()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            string sql = "SELECT * FROM [dbo.Goods] WHERE EndStationID="+CommonData.stationID+" AND EndTime >= '"+DateTime.Now.ToString("yy-MM-dd,00:00")+"'";
            double sumWeight = 0;
            BaseOperate op = new BaseOperate();
            DataSet ds = op.getds(sql, "[dbo.Goods]");
            if (ds.Tables.Count <= 0)
                return;
            ds.Tables[0].Columns.Add("StartStationName");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["StartStationName"] = CommonData.stations.GetValueByKey("StationID", row["StartStationID"], "Name");
                try
                {
                    sumWeight += int.Parse(row["Weight"].ToString());
                }
                catch { }
            }

            this.dgvMsg.DataSource = ds.Tables[0];
            this.lblSum.Text = ds.Tables[0].Rows.Count + "次";
            this.lblSumWeight.Text = sumWeight + "";

            ChartData chartdata = new ChartData();
            visifire vschart = new visifire();

            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Uri url = new Uri(str + "chart/Demo.htm");
            webBrowser.Url = url;

            chartdata.updateData(5, DateTime.Now, 0).ToString();
            vschart.reSize(webBrowser.Width, webBrowser.Height);
            vschart.settitle("当日转运中心报表", "时间", "运输量");
            string[] column = new string[16];
            double[] data = new double[16];
            for (int i = 0; i <= 15; i++)
            {
                column[i] = (i + 5).ToString() + ":00";
                data[i] = chartdata.stationdaybox[i];
            }

            vschart.set3D(true);
            vschart.setData(column, data, 16);
            string type = "pie";

            vschart.setType(type);
            webBrowser.Url = vschart.displayChart();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
