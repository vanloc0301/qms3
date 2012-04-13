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
using StationManager.Classes;
using StationManager.BaseClass;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Microsoft.Windows.Controls;
using System.Drawing;

namespace StationManager
{
	/// <summary>
	/// RptWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RptWindow : Window
	{

        public MainWindow.SetDialogFunc setDialog;

        BaseOperate operate = new BaseOperate();
		public RptWindow()
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
            this.lblTitle.Content = BaseData.stationName + "垃圾站--本站报表";

            dpDate.CalendarFont = new Font("微软雅黑", 13);
            dpDate.Font = new Font("微软雅黑",15);
            dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dpDate.CustomFormat = "yyyy-MM-dd";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbRptType.SelectedIndex == 0)
                getYearRpt();
            else if (cbRptType.SelectedIndex == 1)
                getMonRpt();
            else if (cbRptType.SelectedIndex == 2)
                getDayRpt();
        }

        private void getDayRpt()
        {
            if (dpDate.Value == null)
            {
                MessageBox.Show("请选择日期");
                return;
            }
            string sql = @"SELECT [rfidtest].[dbo.Goods].[StartTime],[rfidtest].[dbo.Goods].[EndTime],[rfidtest].[dbo.Goods].[TruckNo],[rfidtest].[dbo.Goods].[Weight], 
                [rfidtest].[dbo.Station].[Name] as StartStation FROM [db_rfidtest].[rfidtest].[dbo.Goods] INNER JOIN [db_rfidtest].[rfidtest].[dbo.Station]
                ON [db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = [db_rfidtest].[rfidtest].[dbo.Station].[StationID]
                WHERE [db_rfidtest].[rfidtest].[dbo.Goods].[StartTime]>'"+
                this.dpDate.Value.ToString("yy-MM-dd")+"' and [db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = " + BaseData.stationID;


            DataSet ds = operate.getds(sql,"[rfidtest].[dbo.Goods]");

            if (ds.Tables.Count <= 0)
            {
                MessageBox.Show("无法加载数据，请检测网络状况！");
                return;
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(ds.Tables[0]);
            this.lvDayRpy.ItemsSource = view;
        }

        private void getYearRpt()
        {
            if (dpDate.Value == null)
            {
                MessageBox.Show("请选择日期");
                return;
            }
            string yr_str = dpDate.Value.ToString("yyyy");

            string q_sql = @"if not exists(select name from sysobjects where name='resYear' and type='u')
            create table resYear(monname  varchar(100),summonbox int,summonweight float,avgmonweight float);
            else
            begin
            drop table resYear;
            create table resYear(monname  varchar(100),summonbox int,summonweight float,avgmonweight varchar(30));
            end

            declare @q_date varchar(10);
            set @q_date='" + yr_str.Substring(2, 2) + @"-'

            declare @mons int;/*月份*/ 
            set @mons=1
            WHILE @mons<=12
            BEGIN
            declare @datemon varchar(30);
            declare @argWeight float;
            set @datemon=cast(@mons as varchar)+'月';

            declare @mon_str varchar(20);
            if @mons<10
                set @mon_str=@q_date+'0'+cast(@mons as varchar);
            if @mons>=10
                set @mon_str=@q_date+cast(@mons as varchar);
       
            declare @monweight float;
            declare @monbox int;
            set @monbox=(select count(*) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE @mon_str+'%' AND EndTime is not null AND StartStationID = " + BaseData.stationID + @");
            if @monbox is null
                set @monbox=0;
            set @monweight=(select sum(Weight) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE @mon_str+'%' AND EndTime is not null AND StartStationID = " + BaseData.stationID + @");
            if @monweight is null
                set @monweight=0;
            set @argWeight=(select avg(Weight) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE @mon_str+'%' AND EndTime is not null AND StartStationID = " + BaseData.stationID + @");
            if @argWeight is null
                set @argWeight=0;
   
            if @monbox<>0
	            insert into resYear(monname,summonbox,summonweight,avgmonweight) values(@datemon,@monbox,@monweight,@argWeight);
            else
                insert into resYear(monname,summonbox,summonweight,avgmonweight) values(@datemon,0,0,@argWeight);

            set @mons = @mons + 1
            END
            select * from resYear;
            drop table resYear;";

            DataSet ds = operate.getdsrpt(q_sql, "resYear");

            if (ds.Tables.Count < 0)
            {
                MessageBox.Show("无法加载数据，请检测网络状况！");
                return;
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(ds.Tables[0]);
            this.lvYearRpt.ItemsSource = view;
        }

        //生成月报表
        private void getMonRpt()
        {
            if (dpDate.Value == null)
            {
                MessageBox.Show("请选择日期");
                return;
            }
            string yr_str = dpDate.Value.ToString("yyyy");
            string cur_mon = dpDate.Value.ToString("MM");

            string q2_sql = @"if not exists(select name from sysobjects where name='resMon' and type='u')
            create table resMon(dayname  varchar(100),summonbox int,summonweight float,avgmonweight varchar(30));
            else
                begin
                drop table resMon;
                create table resMon(dayname  varchar(100),summonbox int,summonweight float,avgmonweight float);
                end

            declare @q_date varchar(10);
            set @q_date='" + yr_str.Substring(2, 2) + @"-';
            declare @mons int;/*月份*/ 
            set @mons=" + cur_mon.ToString() + @";
            declare @days int;
            set @days=1;

            declare @sumweight float;
            declare @sumbox int;
            set @sumweight=0;
            set @sumbox=0;

            while @days<=31
            begin

                declare @dateday varchar(16);
                declare @avgweight float;
                set @dateday=cast(@days as varchar);

                declare @mon_str varchar(20);
                if @mons<10
                    set @mon_str=@q_date+'0'+cast(@mons as varchar);
                if @mons>=10
                    set @mon_str=@q_date+cast(@mons as varchar);

                declare @day_str varchar(20);
                if @days<10
                    set @day_str=@mon_str+'-0'+cast(@days as varchar);
                if @days>=10
                    set @day_str=@mon_str+'-'+cast(@days as varchar);
       
                print @day_str

                declare @monweight float;
                declare @monbox int;
                set @monbox=(select count(*) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE @day_str+'%' AND EndTime is not null AND StartStationID = " + BaseData.stationID + @");
                if @monbox is null
                    set @monbox=0;
                set @monweight=(select sum(Weight) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE @day_str+'%' AND EndTime is not null AND StartStationID = " + BaseData.stationID + @");
                if @monweight is null
                    set @monweight=0;
                set @avgweight=(select avg(Weight) from [rfidtest].[dbo.Goods] WHERE StartTime LIKE @day_str+'%' AND EndTime is not null AND StartStationID = " + BaseData.stationID + @");
                if @avgweight is null
                    set @avgweight=0;
  
                set @sumweight=@sumweight+@monweight;
                set @sumbox=@sumbox+@monbox;
 
                if @monbox<>0
	                    insert into resMon(dayname,summonbox,summonweight,avgmonweight) values(@dateday,@monbox,@monweight,@avgweight);
                else
                        insert into resMon(dayname,summonbox,summonweight,avgmonweight) values(@dateday,0,0,@avgweight);

                set @days=@days+1;
                end

                if @sumbox<>0
	                insert into resMon(dayname,summonbox,summonweight,avgmonweight) values('总计',@sumbox,@sumweight,0);
                else
                    insert into resMon(dayname,summonbox,summonweight,avgmonweight) values('总计',0,0,0);

                select * from resMon;
                drop table resMon;";

            DataSet ds = operate.getdsrpt(q2_sql, "resMon");

            if (ds.Tables.Count <=0 )
            {
                MessageBox.Show("无法加载数据，请检测网络状况！");
                return;
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(ds.Tables[0]);
            this.lvMonRpt.ItemsSource = view;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //年报表
            if (lvMonRpt == null || lvYearRpt == null)
                return;
            if (cbRptType.SelectedIndex == 0)
            {
                this.lvMonRpt.Visibility = Visibility.Hidden;
                this.lvYearRpt.Visibility = Visibility.Visible;
                this.lvDayRpy.Visibility = Visibility.Hidden;
            }
            //月报表
            else if (cbRptType.SelectedIndex == 1)
            {
                this.lvMonRpt.Visibility = Visibility.Visible;
                this.lvYearRpt.Visibility = Visibility.Hidden;
                this.lvDayRpy.Visibility = Visibility.Hidden;
            }
            //日报表
            else if (cbRptType.SelectedIndex == 2)
            {
                this.lvMonRpt.Visibility = Visibility.Hidden;
                this.lvYearRpt.Visibility = Visibility.Hidden;
                this.lvDayRpy.Visibility = Visibility.Visible;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}