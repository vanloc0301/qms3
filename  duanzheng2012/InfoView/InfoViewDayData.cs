using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfoView.Classes;

namespace InfoView
{
    public partial class InfoViewDayData : Form
    {

        BaseOperate operate = new BaseOperate();
        

        public InfoViewDayData()
        {
            InitializeComponent();
        }

        private void InfoViewDayData_Load(object sender, EventArgs e)
        {

            //初始化位置
            Point p = new Point();
            p.Y = Screen.AllScreens[0].WorkingArea.Height / 2;
            p.X = Screen.AllScreens[0].WorkingArea.Width / 2;
            this.Location = p;


            //加载站信息
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sql = "SELECT [dbo.Goods].StartTime,[dbo.Goods].EndTime,[dbo.Goods].TruckNo,s1.Name as StartStation,-mm-dds2.Name as EndStation"+
                "FROM [dbo.Goods] INNER JOIN [dbo.Station] s1 ON s1.StationID = [dbo.Goods].StartStationID INNER JOIN [dbo.Station] s2 ON s2.StationID = [dbo.Goods].EndStationID"+
                "WHERE [dbo.Goods].StartTime >'"+DateTime.Now.ToString("yy-MM-dd,00:00")+"'";

            DataSet ds = operate.getds(sql, "[dbo.Goods]");
            if (ds.Tables.Count <= 0)
                return;
            this.dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.Refresh();
        }
    }
}