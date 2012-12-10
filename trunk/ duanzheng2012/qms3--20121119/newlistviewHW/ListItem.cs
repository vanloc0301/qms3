using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using InfoView.Classes;

namespace newlistview
{
    public partial class ListItem : UserControl
    {
        int stateCount = 0;
        public string StationID = "";
        public string StationName = "";
        public string StationWeight = "0";
        public string StationNum = "0";
        public string YearWeight = "0";
        public string YearBox = "0";

        public bool NetStatus = true;
        public bool CameraStatus = true;
        public bool PDAStatus = true;
        public string Employee = "";
        BaseOperate operate = new BaseOperate();

        public ListItem()
        {
            InitializeComponent();
        }

        public void setid(string id)
        {
            StationID = id;
            //Random rd = new Random(System.DateTime.Now.Millisecond);
            //timer1.Interval = rd.Next(100, 3000);
            timer1.Interval = (int.Parse(StationID)-30)*1000;
            //用随机数触发第一次查询，防止将来站多了突发数据量太大，导致数据库无法访问
            timer1.Enabled = true;
            timer1.Start();
        }
        private void ListItem_Load(object sender, EventArgs e)
        {

        }
        public void selected()
        {
            this.BackColor = Color.LightBlue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 300000;//5分钟更新一次
            updatedata();
        }
        private void updatedata()
        {
            //需要填写查询过程
            try
            {
                DateTime dpDate = System.DateTime.Now;
                bool b = true;
                string sql = @"select count(*) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE '" + dpDate.ToString("yy-MM-dd") + "'+'%' AND EndTime is not null AND StartStationID = " + StationID;
                DataSet ds = operate.getds(sql, "[rfidtest].[dbo.Goods]",ref b);

                if (!b)
                {
                    LstationName.Text = "网络不畅";
                    return;
                }
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    LstationName.Text = "网络不畅";

                    return;
                }
                if (StationID == "56")
                    this.StationID = "56";
                StationNum = ds.Tables[0].Rows[0][0].ToString();
                StationWeight = "0";
                sql = @"select s.name,e.employee from [rfidtest].[dbo.Station] as s left join [dbo.employee] as e on s.stationid = e.stationid and s.EmployeeNum = e.num WHERE s.StationID = " + StationID;
                ds = operate.getds(sql, "[rfidtest].[dbo.Station]");
                StationName = ds.Tables[0].Rows[0]["name"].ToString().Trim().Replace(" ", "");
                try
                {
                    Employee = ds.Tables[0].Rows[0]["employee"].ToString();
                }
                catch {
                    Employee = "无"; }
                sql = @"select sum(Weight) from [rfidtest].[dbo.Goods] WHERE StartStationID = " + StationID + " and EndTime LIKE '" + dpDate.ToString("yy-MM-dd") + "%'";
                ds = operate.getds(sql, "[rfidtest].[dbo.Goods]");
                StationWeight = ds.Tables[0].Rows[0][0].ToString().Trim();
                try
                {
                    double.Parse(StationWeight);
                }
                catch { StationWeight = "0"; }
                sql = @"select sum(Weight),count(weight) from [rfidtest].[dbo.Goods] WHERE StartStationID = " + StationID + " and EndTime like '" + dpDate.ToString("yy-") + "%' group by startstationid";
                
                ds = operate.getds(sql, "[rfidtest].[dbo.Goods]");
                try
                {
                    YearWeight = ds.Tables[0].Rows[0][0].ToString().Trim();
                    YearBox = ds.Tables[0].Rows[0][1].ToString().Trim();
                }
                catch { YearBox = "0"; YearWeight = "0"; }
                showdata();
            }
            catch(Exception ex) {
                this.Dispose();
                
            };


        }
        private void showdata()
        {
            Lid.Text = StationID;
            LstationName.Text = StationName;
            Lweight.Text = StationWeight;
            Lnum.Text = StationNum;
            if (NetStatus)
            {
                Lnet.Text = "正常";
                Lnet.ForeColor = Color.ForestGreen;
            }
            else
            {
                Lnet.Text = "异常";
                Lnet.ForeColor = Color.Red;
            }
            if (CameraStatus)
            {
                Lcam.Text = "正常";
                Lcam.ForeColor = Color.ForestGreen;
            }
            else
            {
                Lcam.Text = "异常";
                Lcam.ForeColor = Color.Red;
            }
            if (PDAStatus)
            {
                Lpda.Text = "正常";
                Lpda.ForeColor = Color.ForestGreen;
            }
            else
            {
                Lpda.Text = "异常";
                Lpda.ForeColor = Color.Red;
            }
        }

        private void tmrUpdateState_Tick(object sender, EventArgs e)
        {
            try
            {
                if (stateCount == TimeOutSocket.count)
                    return;
                stateCount = TimeOutSocket.count;
                foreach (StationState item in TimeOutSocket.stationList)
                {
                    if (item.name == StationName)
                    {
                        PDAStatus = false;
                        CameraStatus = false;
                        NetStatus = false;
                        if (item.pda)
                            PDAStatus = true;
                        if (item.view)
                            CameraStatus = true;
                        if (item.web)
                            NetStatus = true;
                    }
                }
                showdata();
            }
            catch { }
        }
    }
}
