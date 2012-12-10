using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InfoView;
using InfoView.Classes;
using newlistview;
using System.Diagnostics;

namespace InfoViewHW
{
    public partial class MainWindow : Form
    {
        Thread[] threads = new Thread[6];
        Thread tState;
        Process pro;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            this.Hide();

            pro = Process.Start("newlistview.exe");
            
            InfoView.Classes.BaseOperate.n = notifyIcon1;

            InfoViewYearMain infoMain = new InfoViewYearMain();
            //新添加的数据表
            threads[5] = new Thread(() => { Application.Run(new InfoViewDayData()); });
            threads[5].ApartmentState = ApartmentState.STA;

            //车辆信息线程
            threads[4] = new Thread(() => { Application.Run(new InfoViewCar()); });
            //月图标信息线程
            threads[3] = new Thread(() => { Application.Run(new InfoViewMonthMain()); });
            threads[3].ApartmentState = ApartmentState.STA;
            //时间分布图线程
            threads[2] = new Thread(() => { Application.Run(new InfoViewTimeMain()); });
            threads[2].ApartmentState = ApartmentState.STA;
            //年图标信息线程
            threads[1] = new Thread(() => { Application.Run(new InfoViewYearMain()); });
            threads[1].ApartmentState = ApartmentState.STA;


            ShowWindow();
        }
        private void ShowWindow()
        {

            for (int i =1; i < threads.Length; i++)
            {
                threads[i].Start();
                Thread.Sleep(2000);
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pro.Close();
            Application.Exit();
        }
    }
}
