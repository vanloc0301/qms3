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
using System.ComponentModel;

namespace StationManager
{
	/// <summary>
	/// PrintWindow.xaml 的交互逻辑
	/// </summary>
	public partial class PrintWindow : Window
	{
        public MainWindow.SetDialogFunc setDialog;
		
		//访问数据库对象
        BaseOperate operate = new BaseOperate();

        DataTable dataTable;
		public PrintWindow()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        private void Window_Closed(object sender, EventArgs e)
        {
            setDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet dsStart;
            DataSet dsEnd;
            //出发时刷卡信息
            string sqlStart = "Select [db_rfidtest].[rfidtest].[dbo.Goods].[StartTime] as PushTime,"+
                "[db_rfidtest].[rfidtest].[dbo.Goods].[TruckNo] as TruckNo,"+
                "[db_rfidtest].[rfidtest].[dbo.Station].[Name] as StationName,"+
                "[db_rfidtest].[rfidtest].[dbo.Goods].[Type] as Type1 "+
                "from [db_rfidtest].[rfidtest].[dbo.Goods] "+
                "inner join [db_rfidtest].[rfidtest].[dbo.Station] "+
                "on [db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = [db_rfidtest].[rfidtest].[dbo.Station].[StationID] "+
                "WHERE ([db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = 31) order by [db_rfidtest].[rfidtest].[dbo.Goods].[StartTime] desc";

            dsStart = operate.getds(sqlStart, "[db_rfidtest].[rfidtest].[dbo.Goods].[StartTime]");
            
            //到达时刷卡信息
            string sqlEnd = "Select [db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] as PushTime," +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[TruckNo] as TruckNo," +
                "[db_rfidtest].[rfidtest].[dbo.Station].[Name] as StationName," +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[Type] as Type1 " +
                "from [db_rfidtest].[rfidtest].[dbo.Goods] " +
                "inner join [db_rfidtest].[rfidtest].[dbo.Station] " +
                "on [db_rfidtest].[rfidtest].[dbo.Goods].[EndStationID] = [db_rfidtest].[rfidtest].[dbo.Station].[StationID] " +
                "WHERE ([db_rfidtest].[rfidtest].[dbo.Goods].[EndStationID] = 31)";
            dsEnd = operate.getds(sqlEnd, "[db_rfidtest].[rfidtest].[dbo.Goods].[StartTime] order by [db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] desc");
            //排序并加载到一张表中
            dataTable = new DataTable();
                
            //创建表结构
            dataTable.Columns.Add("no", Type.GetType("System.String"));
            dataTable.Columns.Add("PushTime", Type.GetType("System.String"));
            dataTable.Columns.Add("TruckNo", Type.GetType("System.String"));
            dataTable.Columns.Add("StationName", Type.GetType("System.String"));
            dataTable.Columns.Add("Type1", Type.GetType("System.Int32"));
            dsStart.Tables[0].Columns.Add("no", Type.GetType("System.String"));
            dsEnd.Tables[0].Columns.Add("no", Type.GetType("System.String"));
            //定义循环变量
            int no = 1;
            int ist = 0;
            int iet = 0;
            //循环添加并排序
            while (true)
            {
                DataRow temp;
                if (dsEnd.Tables[0].Rows.Count <= iet && dsStart.Tables[0].Rows.Count <= ist)
                    break;
                if (dsEnd.Tables[0].Rows.Count <= iet)
                    temp = dsStart.Tables[0].Rows[ist];
                else if (dsStart.Tables[0].Rows.Count <= ist)
                    temp = dsEnd.Tables[0].Rows[iet];
                else
                    temp = DateTime.Parse(dsEnd.Tables[0].Rows[iet]["PushTime"].ToString()) > DateTime.Parse(dsStart.Tables[0].Rows[ist]["PushTime"].ToString()) ?
                        dsEnd.Tables[0].Rows[iet] : dsStart.Tables[0].Rows[ist];
                temp["no"] = "" + no;
                DataRow row = dataTable.NewRow();
                row["no"] = temp["no"];
                row["PushTime"] = temp["PushTime"];
                row["TruckNo"] = temp["TruckNo"];
                row["StationName"] = temp["StationName"];
                row["Type1"] = temp["Type1"];
                dataTable.Rows.Add(row);
                no++;
                ist++;
                iet++;
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(dataTable);
            this.lvData.ItemsSource = view;
            
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

        private void btnDowm_Click(object sender, RoutedEventArgs e)
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
	}
}