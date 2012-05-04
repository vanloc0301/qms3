using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StationManager.Classes;
using System.Windows.Media.Animation;
using System.Xml;
using StationManager.BaseClass;
using System.Data;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;

namespace StationManager
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
    
	public partial class MainWindow : Window
	{

        BaseOperate operate = new BaseOperate();
        DataRow newGoods;
        DataRow newMsg;
        BackgroundWorker backWork = new BackgroundWorker();
        //窗口关闭时取消灰色背景的委托
        public delegate void SetDialogFunc();

		public MainWindow()
		{
			this.InitializeComponent();

			// 在此点下面插入创建对象所需的代码。
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BaseOperate.label = this.lblMessage;
            //读取站信息
            XmlDocument xdoc = new XmlDocument();
            string stationID = "";
            try
            {
                xdoc.Load("station.cfg");
                XmlNodeList xNode = xdoc.SelectSingleNode("station").ChildNodes;
                stationID = xNode[0].InnerText;
                BaseData.stationAddress = xNode[1].InnerText;
            }
            catch(Exception ex)
            {
                MessageBox.Show("配置文件出错，程序将退出！");
                this.Close();
                return;
            }

            //从数据库中读取清洁站信息

            string sql = "Select * from [dbo.Station] WHERE StationID = " + stationID;
            DataSet ds =  operate.getds(sql, "[dbo.Station]");

            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("读取清洁站信息失败！");
                this.Close();
                return;
            }

            BaseData.stationID = int.Parse(stationID);
            BaseData.stationName = ds.Tables[0].Rows[0]["Name"].ToString();

            setDialog();
            this.lblTitle.Content = BaseData.stationName + "清洁站清运监管信息系统";
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.loginSys = new LoginWindow.LoginSysFunc(loginSys);
            loginWindow.ShowDialog();

            backWork.DoWork += loadData;
            backWork.RunWorkerCompleted += loadDataComplete;
            backWork.RunWorkerAsync();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0,1,0);
            timer.Start();
            Process.Start("垃圾楼.exe");

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!backWork.IsBusy)
                backWork.RunWorkerAsync();
        }

        public void loadDataComplete(object sender, EventArgs e)
        {
            if (newGoods == null)
                return;
            this.lblMessage.Content = "最新刷卡车辆：" + newGoods["TruckNo"].ToString().Trim() + " 刷卡时间：" + newGoods["StartTime"].ToString().Trim();

            if (newMsg == null)
                return;
            this.lblMessage.Content += "    最新消息发送人：" + newMsg["SendPeople"].ToString().Trim() + " 发送时间：" + newMsg["SendTime"].ToString().Trim();
        }

        public void loadData(object sender,EventArgs e)
        {
            string sql = "SELECT TOP 1 * FROM [dbo.Goods] WHERE StartStationID = " + BaseData.stationID + " ORDER BY StartTime desc";
            DataSet ds = operate.getds(sql, "[dbo.Goods]");
            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                return;
            newGoods = ds.Tables[0].Rows[0];
            sql = "SELECT TOP 1 * FROM [Message] WHERE RevStation = "+BaseData.stationID + " ORDER BY SendTime desc";
            ds = operate.getds(sql, "Message]");
            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
                return;
            newMsg = ds.Tables[0].Rows[0];
        }

        //登录成功时调用的方法
        private void loginSys(String user, String pwd)
        {
            this.lblUser.Content += user;
            this.lblRight.Content += pwd;

            setDialog();
        }

        //显示或取消灰色背景
        private void setDialog()
        {
            if (this.dialogBg.Visibility == Visibility.Hidden)
                this.dialogBg.Visibility = Visibility.Visible;
            else
                this.dialogBg.Visibility = Visibility.Hidden;
        }


        //查看卫星影像
        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            MapWindow mapWindow = new MapWindow();
            this.setDialog();
            mapWindow.setDialog = new SetDialogFunc(setDialog);
            mapWindow.ShowDialog();
        }

        private void btnRpt_Click(object sender, RoutedEventArgs e)
        {
            RptWindow window = new RptWindow();
            this.setDialog();
            window.setDialog = new SetDialogFunc(setDialog);
            window.ShowDialog();
        }

        private void btnClk_Click(object sender, RoutedEventArgs e)
        {
            ClkWidnow window = new ClkWidnow();
            this.setDialog();
            window.setDialog = new SetDialogFunc(setDialog);
            window.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MsgWindow window = new MsgWindow();
            this.setDialog();
            window.setDialog = new SetDialogFunc(setDialog);
            window.ShowDialog();
        }

        private void btnPrt_Click(object sender, RoutedEventArgs e)
        {
            PrintWindow window = new PrintWindow();
            this.setDialog();
            window.setDialog = new SetDialogFunc(setDialog);
            window.ShowDialog();
        }

        private void btnExt_Click(object sender, RoutedEventArgs e)
        {
            this.lblUser.Content = "用户名：";
            this.lblRight.Content = "权  限：";

            setDialog();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.loginSys = new LoginWindow.LoginSysFunc(loginSys);
            loginWindow.ShowDialog();
        }
	}
}