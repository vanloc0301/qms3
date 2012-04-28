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

namespace DTQMS3New
{
    public partial class MainWindow : Form
    {

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
            CommonData.errorLabel = lblError;
            //查询垃圾楼信息
            string sql = "SELECT * FROM [dbo.Station]";
            BaseOperate op = new BaseOperate();
            DataSet ds = op.getds(sql,"[dbo.Station]");
            if (ds.Tables.Count != 0)
                CommonData.stations = ds.Tables[0];

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
            Thread thread = new Thread(bgwUpdateUI_DoWork);
            thread.Start();
        }

        #region 读卡线程

        private void readCard()
        {
            if (!UHF.connect())
                return;

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
                    //添加到更新队列
                    CommonData.data.Add(card);
                    //更新UI界面
                    this.Invoke(fUpui, new Object[] { card });
                }
                UHF.PutDataIntoCard(3, 10, 1, UHF.MISSION_ING, card);
            }
        }

        #endregion

        #region 更新数据线程

        private void updateDB()
        {
            while (true)
            {
                while (true)
                {
                    //如果数据已经全部更新，则等待10秒
                    if (CommonData.data.Count <= CommonData.curUpdateIndex + 1)
                        Thread.Sleep(10000);
                    //否则退出循环
                    else
                        break;

                }

                //更新当前行数计数器
                CommonData.curUpdateIndex++;
                //获取要更新的数据
                Task card = CommonData.data[CommonData.curUpdateIndex];

                //更新数据
                string sql = "UPDATE [dbo.Goods]\r\nSET [EndTime]='"+card.EndTime+"',EndStationID="+CommonData.stationID+"\r" +
                "\nWHERE (StartTime = '"+card.StartTime+"')  AND (TruckNo='"+card.CarNum+"')";

                BaseOperate op = new BaseOperate();
                op.getcom(sql);
            }
        }

        #endregion

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CommonData.curUpdateIndex < CommonData.data.Count - 1)
            {
                MessageBox.Show("还有没更新完毕的数据，无法关闭");
                e.Cancel = true;
                return;
            }

            readCardThread.Abort();
            updateDBThread.Abort();
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
                sumWeight += int.Parse(row["Weight"].ToString());
            }

            this.dgvMsg.DataSource = ds.Tables[0];
            this.lblSum.Text = ds.Tables[0].Rows.Count + "次";
            this.lblSumWeight.Text = sumWeight + "吨";

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
    }
}
