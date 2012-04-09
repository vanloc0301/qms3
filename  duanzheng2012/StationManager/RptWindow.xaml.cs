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

namespace StationManager
{
	/// <summary>
	/// RptWindow.xaml 的交互逻辑
	/// </summary>
	public partial class RptWindow : Window
	{

        public MainWindow.SetDialogFunc setDialog;
		public RptWindow()
		{
			this.InitializeComponent();
			
			// 在此点之下插入创建对象所需的代码。
		}

        private void Window_Closed(object sender, EventArgs e)
        {
            setDialog();
        }
	}
}