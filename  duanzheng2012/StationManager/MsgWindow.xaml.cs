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
using StationManager.Classes;
using System.Data;
using System.ComponentModel;

namespace StationManager
{
	/// <summary>
	/// MsgWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MsgWindow : Window
	{
        public MainWindow.SetDialogFunc setDialog;

        BaseOperate operate = new BaseOperate();

        DataSet ds;

        LoadWindow msgwin;

        //访问数据库时后台操作
        private BackgroundWorker backWork = new BackgroundWorker();
		public MsgWindow()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        private void Window_Closed(object sender, EventArgs e)
        {
            setDialog();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (lvData.SelectedIndex == -1)
            {
                lvData.SelectedIndex = 0;
                return;
            }

            if (lvData.SelectedIndex == 0)
                return;
            lvData.SelectedIndex--;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (lvData.SelectedIndex == -1)
            {
                lvData.SelectedIndex = 0;
                return;
            }

            if (lvData.SelectedIndex >= lvData.Items.Count)
                return;
            lvData.SelectedIndex++;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backWork.DoWork += updateData;
            backWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backWorkComplete);

            this.lblTitle.Content = BaseData.stationName.Replace(" ","") + "清洁站--消息与通知";

            //读取数据
            string sql = "SELECT * FROM [db_rfidtest].[rfidtest].[Message] WHERE [db_rfidtest].[rfidtest].[Message].[RevStation] = " + BaseData.stationID;

            ds = operate.getds(sql, "[db_rfidtest].[rfidtest].[Message]");
            if (ds.Tables.Count == 0)
            {
                msgwin = new LoadWindow();
                return;
            }

            //增加列
            ds.Tables[0].Columns.Add("SendTimeS", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MsgStateS", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("MsgLevelS", Type.GetType("System.String"));

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                //设置楼名为当前楼名


                //格式化时间
                item["SendTimeS"] = DateTime.Parse(item["SendTime"].ToString()).ToString("HH:mm");

                //格式化读取状态
                if (bool.Parse(item["MsgState"].ToString()))
                {
                    item["MsgStateS"] = "已读";
                }
                else
                {
                    item["MsgStateS"] = "未读";
                }

                //格式化级别

                if (item["MsgLevel"].ToString() == "1")
                {
                    item["MsgLevelS"] = "普通";
                }
                if (item["MsgLevel"].ToString() == "2")
                {
                    item["MsgLevelS"] = "重要";
                }
                if (item["MsgLevel"].ToString() == "3")
                {
                    item["MsgLevelS"] = "紧急";
                }
            }

            //显示到list中
            ICollectionView view = CollectionViewSource.GetDefaultView(ds.Tables[0]);
            this.lvData.ItemsSource = view;
        }

        //加载数据

        private void updateData(Object sender,DoWorkEventArgs e)
        {
            int id = int.Parse(e.Argument.ToString());

            string sql = "UPDATE [db_rfidtest].[rfidtest].[Message] SET [db_rfidtest].[rfidtest].[Message].[MsgState] = 1 WHERE [db_rfidtest].[rfidtest].[Message].[ID] = " + id;

            operate.getcom(sql);

           

            LoadWindow.closeWindow();

        }

        private void btnIsRead_Click(object sender, RoutedEventArgs e)
        {

            if (this.lvData.SelectedItem == null)
            {
                return;
            }

            if (bool.Parse(ds.Tables[0].Rows[this.lvData.SelectedIndex]["MsgState"].ToString()))
            {
                return;
            }

            int id = int.Parse(ds.Tables[0].Rows[this.lvData.SelectedIndex]["ID"].ToString());
            
            backWork.RunWorkerAsync(id);
        }


        private void backWorkComplete(object send, RunWorkerCompletedEventArgs e)
        {
            LoadWindow.closeWindow();
            ds.Tables[0].Rows[this.lvData.SelectedIndex]["MsgState"] = true;
            ds.Tables[0].Rows[this.lvData.SelectedIndex]["MsgStateS"] = "已读";
            ICollectionView view = CollectionViewSource.GetDefaultView(ds.Tables[0]);
            this.lvData.ItemsSource = view;
        }

        private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvData.SelectedIndex < 0)
                return;

            this.lblContent.Content = "消息内容:"+ds.Tables[0].Rows[lvData.SelectedIndex]["MsgContent"];
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}