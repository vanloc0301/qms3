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
    public partial class InfoViewMonthMain : Form
    {

        private ChartData chartdata = new ChartData();
        private int curMonth = 0;

        public InfoViewMonthMain()
        {
            InitializeComponent();
        }

        private void InfoViewMonthMain_Load(object sender, EventArgs e)
        {
            loadData();
        }


        private void loadData()
        {
            visifire vschart = new visifire();
            string str = System.AppDomain.CurrentDomain.BaseDirectory;
            Uri url = new Uri(str + "chart/Demo.htm");
            webBrowser.Url = url;

            chartdata.updateData(3, DateTime.Now, 0);

            vschart.reSize(webBrowser.Size.Width, webBrowser.Size.Height);
            vschart.settitle(DateTime.Now.ToString("yyyy年MM月") + "报表", "日期", "运输量(单位:箱)");
            string[] column = new string[31];
            double[] data = new double[31];
            double[] data2 = new double[31];
            int daysofm = Datetimecalc.daysofmonth(DateTime.Now);
            for (int i = 0; i < daysofm; i++)
            {
                column[i] = (i + 1).ToString();
                data[i] = chartdata.month[i];
            }
            vschart.s1 = DateTime.Now.ToString("yyyy年MM月");
            vschart.set3D(true);

            vschart.setData(column, data, daysofm);
            string type = "column";


            vschart.setType(type);
            webBrowser.Url = vschart.displayChart();


            //记录当前年月，用于判断是否更新
            curMonth = DateTime.Now.Month;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            //如果月份有变动则更新
            if (curMonth != DateTime.Now.Month)
                loadData();
        }


    }
}
