using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfoView.Classes;
using System.Data.SqlClient;
using System.Threading;

namespace InfoView
{
    public partial class InfoViewCarMain : Form
    {

        private int id1 = 0;
        private int id2 = 0;

        private int curStation;
        private DataSet stations;
        private DataSet cars;

        public InfoViewCarMain()
        {
            InitializeComponent();
        }

        #region 根据StationID获取Name
        private String getNameById(String id)
        {
            for (int i = 0; i < stations.Tables[0].Rows.Count;i++ )
            {
                if (stations.Tables[0].Rows[i]["StationID"].ToString() == id)
                    return stations.Tables[0].Rows[i]["Name"].ToString();
            }

            return "";
        }
        #endregion


        private void InfoViewCarMain_Load(object sender, EventArgs e)
        {

            //查询所有站
            BaseOperate op = new BaseOperate();

            String sql = @"SELECT StationID,Name FROM [db_rfidtest].[rfidtest].[dbo.Station]";
            stations = op.getds(sql, "[db_rfidtest].[rfidtest].[dbo.Station]");
            curStation = 0;

            loadData();
            loadStationCar();
            try
            {
                this.Location = Screen.AllScreens[0].WorkingArea.Location;
            }
            catch
            { }
           
        }

        #region 加载当前站车辆信息
        private void loadStationCar()
        {
            if (stations == null || stations.Tables.Count <= 0)
                return;
            String sql = @"SELECT * FROM [db_rfidtest].[rfidtest].[dbo.goods] WHERE StartStationID = "
                                +stations.Tables[0].Rows[curStation]["StationID"].ToString() +
                                " AND (StartTime > '" + DateTime.Now.ToString("yy-MM-dd")+"')";

            BaseOperate op = new BaseOperate();
            cars = op.getds(sql, "[db_rfidtest].[rfidtest].[dbo.goods]");
            panel2.Invalidate();
            label1.Text = stations.Tables[0].Rows[curStation]["Name"].ToString();
            curStation++;
            if (curStation >= stations.Tables[0].Rows.Count)
                curStation = 0;

        }
        #endregion


        private void loadData()
        {
            //第一次查询，查询出最近的一条已到车辆   
            String sqlStart = @"SELECT TOP 1 * FROM [db_rfidtest].[rfidtest].[dbo.goods] WHERE 
                                    [db_rfidtest].[rfidtest].[dbo.goods].[ENDTIME] is not null ORDER BY ENDTIME DESC";
            BaseOperate operate = new BaseOperate();
            DataSet ds2 = null;
            try
            {
                ds2 = operate.getds(sqlStart, "[db_rfidtest].[rfidtest].[dbo.goods]");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            //第二次查询，查询出最后一次未到车辆
            sqlStart = @"SELECT TOP 1 * FROM [db_rfidtest].[rfidtest].[dbo.goods] WHERE 
                              [db_rfidtest].[rfidtest].[dbo.goods].[ENDTIME] is null ORDER BY STARTTIME DESC";
            DataSet ds1 = null;
            try
            {
                ds1 = operate.getds(sqlStart, "[db_rfidtest].[rfidtest].[dbo.goods]");
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return;
            }

            if (ds1.Tables.Count <= 0 || ds1.Tables[0].Rows.Count<=0)
                return;
            if (ds2.Tables.Count <= 0 || ds2.Tables[0].Rows.Count <= 0)
                return;

            //判断上次查询到的数据是否和本次一样
            if (id1 != int.Parse(ds1.Tables[0].Rows[0]["ID"].ToString()))
            {
                //如果不一样则更改当前数据
                id1 = int.Parse(ds1.Tables[0].Rows[0]["ID"].ToString());
                lblCarNo1.Text = ds1.Tables[0].Rows[0]["TruckNo"].ToString();
                lblStartTime1.Text = DateTime.Parse(ds1.Tables[0].Rows[0]["StartTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                lblSStation1.Text = getNameById(ds1.Tables[0].Rows[0]["StartStationID"].ToString());
                lblEStation1.Text = getNameById(ds1.Tables[0].Rows[0]["EndStationID"].ToString());
                Thread t = new Thread(new ParameterizedThreadStart(changeData));
                t.Start("1");
            }

            if (id2 != int.Parse(ds2.Tables[0].Rows[0]["ID"].ToString()))
            {
                //如果不一样则更改当前数据
                id2 = int.Parse(ds2.Tables[0].Rows[0]["ID"].ToString());
                lblCarNo2.Text = ds2.Tables[0].Rows[0]["TruckNo"].ToString();
                lblStartTime2.Text = DateTime.Parse(ds2.Tables[0].Rows[0]["StartTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                lblEndTime2.Text = DateTime.Parse(ds2.Tables[0].Rows[0]["EndTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                lblSStation2.Text = getNameById(ds2.Tables[0].Rows[0]["StartStationID"].ToString());
                lblEStation2.Text = getNameById(ds2.Tables[0].Rows[0]["EndStationID"].ToString());
                Thread t = new Thread(new ParameterizedThreadStart(changeData));
                t.Start("2");
            }

        }

        private void loadPic(DataSet ds1, DataSet ds2)
        {
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            loadData();
            loadStationCar();
        }

        private void InfoViewCarMain_Paint(object sender, PaintEventArgs e)
        {
            int sTime = 5;                          //时间轴起始时间
            int eTime = 20;                         //时间轴结束时间
            int width = 1;                          //每一分钟之间的间隔
            int r = 10;                              //圆的半径
            Font font = new Font("微软雅黑",8);     //时间字体
          
            //画出时间轴
            Graphics g = panel2.CreateGraphics();
            Pen p = new Pen(Color.Black,5);
            Brush b = new SolidBrush(Color.Red);
            g.DrawLine(p, 10, 10, (eTime-sTime)*width*90+10+5, 10);
            for (int i = sTime; i <= eTime; i++)
            {
                g.DrawString(i.ToString("d2")+":"+"00",font,b,(i-sTime)*width*90,20);
                g.DrawLine(p, (i - sTime) * width*90 + 12, 10, (i - sTime) * width*90+12, 5);
            }

            if (cars == null)
                return;
            if (cars.Tables.Count <= 0)
                return;
            for (int i = 0; i < cars.Tables[0].Rows.Count; i++)
            {
                String startTime = cars.Tables[0].Rows[i]["StartTime"].ToString();
                int hours = int.Parse(startTime.Substring(9, 2))-sTime;
                int min = int.Parse(startTime.Substring(12, 2)) + 60 * hours;
                int x = min*width;
                Brush bRect = new SolidBrush(Color.Green);

                if(cars.Tables[0].Rows[i]["EndTime"].ToString().Length==0)
                    g.FillEllipse(b, x - r, 5, 10, 10);
                else
                    g.FillRectangle(bRect, x - r, 5, 10, 10);
            }
        }



        #region 未到车辆变色线程
        private void changeData(Object type)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            if (type.ToString() == "1")
            {
                lblCarNo1.Visible = false;
                lblEndTime1.Visible = false;
                lblEStation1.Visible = false;
                lblSStation1.Visible = false;
                lblStartTime1.Visible = false;


                Thread.Sleep(3000);


                lblCarNo1.Visible = true;
                lblEndTime1.Visible = true;
                lblEStation1.Visible = true;
                lblSStation1.Visible = true;
                lblStartTime1.Visible = true;
            }

            if (type.ToString() == "2")
            {
                lblCarNo2.Visible = false;
                lblEndTime2.Visible = false;
                lblEStation2.Visible = false;
                lblSStation2.Visible = false;
                lblStartTime2.Visible = false;

                Thread.Sleep(3000);

                lblCarNo2.Visible = true;
                lblEndTime2.Visible = true;
                lblEStation2.Visible = true;
                lblSStation2.Visible = true;
                lblStartTime2.Visible = true;
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            InfoViewCarMain_Paint(sender,e);
        }

    }
}
