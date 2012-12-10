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
            //设置自己的未知
            this.Location = new Point(480 * 2, 300);
            //加载站信息
            timer1.Start();
            timer1_Tick(null,null);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sql = "SELECT [dbo.Goods].TruckNo,[dbo.Goods].StartTime,s1.Name as StartStation,[dbo.Goods].EndTime,[dbo.Goods].Weight,s2.Name as EndStation FROM [dbo.Goods] INNER JOIN [dbo.Station] as s1 ON [dbo.Goods].StartStationID = s1.StationID INNER JOIN [dbo.Station] as s2 ON [dbo.Goods].EndStationID = s2.StationID WHERE [dbo.Goods].StartTime > '" + DateTime.Now.ToString("yy-MM-dd,00:00") + "' AND StartTime<'" + DateTime.Now.AddDays(1).ToString("yy-MM-dd 00:00") + "' ORDER BY StartTime DESC" ;

            DataSet ds = operate.getds(sql, "[dbo.Goods]");
            if (ds.Tables.Count <= 0)
                return;
            try
            {
                this.dataGridView1.DataSource = ds.Tables[0];
                this.dataGridView1.Refresh();
            }
            catch { }
        }

        private void tmrSetLocation_Tick(object sender, EventArgs e)
        {     
        }
    }
}