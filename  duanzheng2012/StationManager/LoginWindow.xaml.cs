using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StationManager.BaseClass;
using System.Data;
using System.Windows.Media.Animation;
using StationManager.Classes;

namespace StationManager
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public delegate void LoginSysFunc(String user, String pwd);
        public LoginSysFunc loginSys;

        //数据库访问类
        private BaseOperate operate = new BaseOperate();

        //用户列表
        private DataSet ds;

        public LoginWindow()
        {
            this.InitializeComponent();

            // 在此点之下插入创建对象所需的代码。
            String sql = "Select * from [db_rfidtest].[rfidtest].[dbo.User]";

            ds = operate.getds(sql, "[db_rfidtest].[rfidtest].[dbo.User]");

            if (ds.Tables.Count <= 0)
            {
                MessageBox.Show("无法加载数据，请检测网络状况！");
                return;
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                this.cbUser.Items.Add(ds.Tables[0].Rows[i]["UserName"]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = this.cbUser.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("请选择您的用户名！");
                return;
            }
            if (ds.Tables[0].Rows[i]["UsePwd"].ToString() != MD5.MDString(this.txtPwd.Password))
            {
                MessageBox.Show("对不起，您输入的密码错误，请重新输入！");
                return;
            }

            string right = ds.Tables[0].Rows[i]["UserRight"].ToString();

            loginSys(this.cbUser.Text, right);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.txtPwd.Password.Length <= 0)
                return;
            this.txtPwd.Password = this.txtPwd.Password.Substring(0, this.txtPwd.Password.Length-1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.txtPwd.Password = "";
        }

        private void ButtonNum_Click(object sender, RoutedEventArgs e)
        {
            string num = ((Button)sender).Name.Substring(3,1);

            this.txtPwd.Password += num;
        }

    }
}