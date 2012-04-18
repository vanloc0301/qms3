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
        }

        private void updateUIFunc(Task card)
        {
            //更新Label
            CommonData.sumTime++;
            this.lblSum.Text = CommonData.sumTime.ToString();
            this.lblType.Text = card.Type.ToString();
            this.lblTruck.Text = card.CarNum;
            this.lblStartTime.Text = card.StartTime;
            this.lblStartStation.Text = CommonData.stations.GetValueByKey("StationID",card.StartSpot,"Name").ToString();
            this.lblEndTime.Text = card.EndTime;

            //更新时间分布图
            visifire vschart = new visifire();
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Uri url = new Uri(str + "chart/Demo.htm");
            webBrowser.Url = url;


            vschart.reSize(webBrowser.Width, webBrowser.Height);
            vschart.settitle("当日转运中心报表", "时间", "运输量");
            string[] column = new string[16];
            double[] data = new double[16];
            for (int i = 0; i <= 15; i++)
            {
                column[i] = (i + 5).ToString() + ":00";
            }

            foreach (var item in CommonData.data)
            {
                data[int.Parse(DateTime.Parse(item.EndTime).ToString("HH"))-5] ++;
            }

            vschart.set3D(true);

            Random rd = new Random();
            vschart.setData(column, data, 16);
            string type = "pie";

            vschart.setType(type);
            webBrowser.Url = vschart.displayChart();

            //更新最新数据
            this.dgvMsg.DataSource = CommonData.toDataTable();
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
                    this.Invoke(fUpui,new Object[]{card});
                }
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
                string sql = "UPDATE [dbo.Goods]\r\nSET [EndTime]='"+card.EndTime+"'\r" +
                "\nWHERE (StartTime = @StartTime)  AND (TruckNo=@TruckNo)";

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
    }
}
