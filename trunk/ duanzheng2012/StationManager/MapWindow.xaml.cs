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
using System.Windows.Resources;
using StationManager.BaseClass;
using System.Data;
using System.Windows.Threading;

namespace StationManager
{
	/// <summary>
	/// MapWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MapWindow : Window
	{

        public MainWindow.SetDialogFunc setDialog;

		public MapWindow()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lblTitle.Content = BaseData.stationName+"清洁站--卫星影像";
            lblStation.Content = BaseData.stationName + "清洁站";
            lblAddress.Content = BaseData.stationAddress;

            String imgName = BaseData.stationName.Trim().Replace(" ","")+"楼.jpg";
            BitmapImage imgS = new BitmapImage();
            StreamResourceInfo info = Application.GetRemoteStream(new Uri("Maps/" + imgName,UriKind.Relative));
            imgS.BeginInit();
            imgS.StreamSource = info.Stream;
            imgS.EndInit();
            this.imgMap.Source = imgS;
            getCarNum(null, null);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += getCarNum;
            timer.Interval = new TimeSpan(0,1,0);
            timer.Start();

        }

        public void getCarNum(object sender,EventArgs e)
        {
            string sql = "SELECT count(*) FROM [dbo.Goods] WHERE ([db_rfidtest].[rfidtest].[dbo.Goods].[StartTime]>'" + DateTime.Now.ToString("yy-MM-dd") + "' and [db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = " +
                BaseData.stationID + ")";
            BaseOperate op = new BaseOperate();
            DataSet set = op.getds(sql,"[dbo.Goods]");
            if (set.Tables.Count <= 0)
                return;
            lblCarNum.Content = set.Tables[0].Rows[0][0];
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            setDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}