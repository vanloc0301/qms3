using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InfoView.Classes;

namespace InfoViewHW
{
    public partial class InfoViewCar : Form
    {
        private DataSet stations;
        int id1 = 0;
        int id2 = 0;
        public InfoViewCar()
        {
            InitializeComponent();
        }

        private void InfoViewCar_Load(object sender, EventArgs e)
        {

            //设置自己的未知
            this.Location = new Point(480 * 2, 0);

            //查询所有站
            BaseOperate op = new BaseOperate();

            String sql = @"SELECT StationID,Name FROM [db_rfidtest].[rfidtest].[dbo.Station]";
            stations = op.getds(sql, "[db_rfidtest].[rfidtest].[dbo.Station]");

            loadData();
        }

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

            if (ds1.Tables.Count <= 0 || ds1.Tables[0].Rows.Count <= 0)
                return;
            if (ds2.Tables.Count <= 0 || ds2.Tables[0].Rows.Count <= 0)
                return;

            //判断上次查询到的数据是否和本次一样
            if (id2 != int.Parse(ds1.Tables[0].Rows[0]["ID"].ToString()))
            {
                try
                {
                    //如果不一样则更改当前数据
                    id1 = int.Parse(ds1.Tables[0].Rows[0]["ID"].ToString().Trim());
                    TruckNo1.Text = ds1.Tables[0].Rows[0]["TruckNo"].ToString().Trim();
                    StartTime1.Text = DateTime.Parse(ds1.Tables[0].Rows[0]["StartTime"].ToString()).ToString("HH:mm");
                    StartStation1.Text = getNameById(ds1.Tables[0].Rows[0]["StartStationID"].ToString());
                    EndStation1.Text = getNameById(ds1.Tables[0].Rows[0]["EndStationID"].ToString());
                    if (EndStation1.Text.Trim() == "大屯")
                        EndStation1.Text = "马家楼";
                    else
                        EndStation1.Text = "大屯";
                }
                catch { }
            }

            if (id1 != int.Parse(ds2.Tables[0].Rows[0]["ID"].ToString()))
            {
                try
                {
                    //如果不一样则更改当前数据
                    id2 = int.Parse(ds2.Tables[0].Rows[0]["ID"].ToString());
                    TruckNo2.Text = ds2.Tables[0].Rows[0]["TruckNo"].ToString().Trim();
                    StartTime2.Text = DateTime.Parse(ds2.Tables[0].Rows[0]["StartTime"].ToString()).ToString("HH:mm");
                    EndTime2.Text = DateTime.Parse(ds2.Tables[0].Rows[0]["EndTime"].ToString()).ToString("HH:mm");
                    StartStation2.Text = getNameById(ds2.Tables[0].Rows[0]["StartStationID"].ToString());
                    EndStation2.Text = getNameById(ds2.Tables[0].Rows[0]["EndStationID"].ToString());
                    Weight2.Text = ds2.Tables[0].Rows[0]["Weight"].ToString();
                }
                catch
                { }
            }

        }
        #region 根据StationID获取Name
        private String getNameById(String id)
        {
            for (int i = 0; i < stations.Tables[0].Rows.Count; i++)
            {
                if (stations.Tables[0].Rows[i]["StationID"].ToString() == id)
                    return stations.Tables[0].Rows[i]["Name"].ToString();
            }

            return "";
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
