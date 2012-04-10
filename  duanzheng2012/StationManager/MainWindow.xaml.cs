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

namespace StationManager
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{

        //窗口关闭时取消灰色背景的委托
        public delegate void SetDialogFunc();

		public MainWindow()
		{
			this.InitializeComponent();

			// 在此点下面插入创建对象所需的代码。
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setDialog();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.loginSys = new LoginWindow.LoginSysFunc(loginSys);
            loginWindow.ShowDialog();
            
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