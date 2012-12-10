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
using InfoView.Classes;
using newlistview;
using System.IO;

namespace InfoView
{

    
    public partial class MainWindow : Form
    {
     
        static public int[] locations = new int[5];
        Thread[] threads = new Thread[8];
        Thread tState;
        public MainWindow()
        {
            InitializeComponent();
            //读取配置文件
            tState = new Thread(TimeOutSocket.ConnectTest);
            try
            {
                StreamReader sr = new StreamReader("Config.cfg");
                for (int i = 0; i < 5; i++)
                {
                    sr.ReadLine();
                    locations[i] = int.Parse(sr.ReadLine());
                }
            }
            catch {
                MessageBox.Show("读取配置文件失败!");
                this.Close();
                return;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Hide();

            InfoViewYearMain infoMain = new InfoViewYearMain();

            tState.Start();

            //新添加的数据表
            threads[7] = new Thread(() => { Application.Run(new InfoViewDayData()); });
            threads[7].ApartmentState = ApartmentState.STA;

            //车辆信息线程
            threads[6] = new Thread(() => { Application.Run(new InfoViewCarMain()); });
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

            threads[0] = new Thread(() => { Application.Run(new Map()); });
            threads[0].ApartmentState = ApartmentState.STA;



            InfoView.Classes.BaseOperate.n = notifyIcon1;

            
        }
        private void ShowWindow()
        {

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
                Thread.Sleep(2000);
            }
            
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            tState.Abort();
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
