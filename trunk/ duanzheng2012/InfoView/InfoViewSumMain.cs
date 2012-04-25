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
    public partial class InfoViewSumMain : Form
    {
        public InfoViewSumMain()
        {
            InitializeComponent();
        }

        private void InfoViewSumMain_Load(object sender, EventArgs e)
        {
            int station = 46;
            int car;
            double size = 31.66;
            int people = 1243000;
            double sum = 0;
            double argSize;
            double argPeople;
            ChartData chartdata = new ChartData();
            BaseOperate op = new BaseOperate();
            chartdata.updateData(2,DateTime.Now,0);

            foreach (double item in chartdata.lastyear)
            {
                sum += item;
            }

            argSize = sum / size;
            argPeople = sum / people;

            String sql = @"SELECT COUNT(*) FROM [db_rfidtest].[rfidtest].[dbo.Driver]";
            DataSet ds = op.getds(sql, "[db_rfidtest].[rfidtest].[dbo.Driver]");
            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                return;
            car = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            sql = @"SELECT COUNT(*) FROM [db_rfidtest].[rfidtest].[dbo.Station]";
            ds = op.getds(sql, "[db_rfidtest].[rfidtest].[dbo.Station]");
            if (ds.Tables.Count <= 0)
                return;
            station = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            lblStation.Text = "" + station+"个";
            lblCar.Text = "" + car + "辆";
            lblSize.Text = "" + size +"平方公里";
            lblPeople.Text = "" + people + "人";
            lblSum.Text = "" + sum + "吨垃圾";
            lblArgSize.Text = "" + argSize.ToString("f2") + "吨垃圾";
            lblArgPeople.Text = "" + argPeople.ToString("f2") + "吨垃圾";

            this.Location = Screen.AllScreens[0].WorkingArea.Location;
        }

    }
}
