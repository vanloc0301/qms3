using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace InfoView
{
    public partial class MainWindow : Form
    {

        Thread[] threads = new Thread[6];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Hide();

            InfoViewYearMain infoMain = new InfoViewYearMain();


            //车辆信息线程
            threads[0] = new Thread(() => { Application.Run(new InfoViewCarMain()); });
            //月图标信息线程
            threads[1] = new Thread(() => { Application.Run(new InfoViewMonthMain()); });
            threads[1].ApartmentState = ApartmentState.STA;
            //设备状态信息线程
            threads[2] = new Thread(() => { Application.Run(new InfoViewStateMain()); });
            //全区统计信息线程
            threads[3] = new Thread(() => { Application.Run(new InfoViewSumMain()); });
            //时间分布图线程
            threads[4] = new Thread(() => { Application.Run(new InfoViewTimeMain()); });
            threads[4].ApartmentState = ApartmentState.STA;
            //年图标信息线程
            threads[5] = new Thread(() => { Application.Run(new InfoViewYearMain()); });
            threads[5].ApartmentState = ApartmentState.STA;

            
        }
        private void ShowWindow()
        {

            for (int i = 0; i < 6; i++)
            {
                threads[i].Start();
                Thread.Sleep(3000);
            }
            
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            this.Hide();
            this.Visible = false;
            ShowWindow();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
