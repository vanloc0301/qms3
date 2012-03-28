using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfoView
{
    public partial class InfoViewTimeMain : Form
    {

        private InfoView.Classes.ChartData chartdata = new InfoView.Classes.ChartData();

        public InfoViewTimeMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoView.Classes.visifire vschart = new InfoView.Classes.visifire();
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Uri url = new Uri(str + "chart/Demo.htm");
            webBrowser.Url = url;

            chartdata.updateData(5,DateTime.Now, 0).ToString();
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

            Random rd = new Random();
            vschart.setData(column, data, 16);
            string type = "pie";

            vschart.setType(type);
            webBrowser.Url = vschart.displayChart();
        }

        private void InfoViewTimeMain_Resize(object sender, EventArgs e)
        {
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            this.Form1_Load(null,null);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
