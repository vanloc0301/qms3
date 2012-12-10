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
    public partial class InfoViewYearMain : Form
    {

        private ChartData chartdata = new ChartData();
        private int curYear = 0;

        public InfoViewYearMain()
        {
            InitializeComponent();
        }

        private void InfoViewYearMain_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            //设置自己的未知
            this.Location = new Point(480 * 2, 300 * 2);
            try
            {
                visifire vschart = new visifire();
                string str = System.AppDomain.CurrentDomain.BaseDirectory;
                Uri url = new Uri(str + "chart/Demo.htm");
                webBrowser.Url = url;

                chartdata.updateData(1, DateTime.Now, 0);
                chartdata.updateData(2, DateTime.Now, 0);
                vschart.reSize(webBrowser.Size.Width, webBrowser.Size.Height);
                vschart.settitle(DateTime.Now.AddYears(-1).ToString("yyyy") + "," + DateTime.Now.ToString("yyyy") + "年同比报表", "日期", "运输量(单位:吨)");
                string[] column = new string[12];
                double[] data = new double[12];
                double[] data2 = new double[12];
                for (int i = 0; i <= 11; i++)
                {
                    column[i] = (i + 1).ToString() + "月";
                    data[i] = chartdata.year[i];
                    data2[i] = chartdata.lastyear[i];
                }
                vschart.s1 = DateTime.Now.ToString("yyyy") + "年";
                vschart.s2 = DateTime.Now.AddMonths(-12).ToString("yyyy") + "年";
                vschart.set3D(true);

                vschart.setData(column, data, 12);
                vschart.setData2(data2);
                string type = "column";


                vschart.setType(type);
                webBrowser.Url = vschart.displayChart();
                curYear = DateTime.Now.Year;
            }
            catch { }


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void timeRefresh_Tick(object sender, EventArgs e)
        {
            if (curYear != DateTime.Now.Year)
                loadData();
        }

        private void tmrSetLocation_Tick(object sender, EventArgs e)
        {
        }
    }
}
