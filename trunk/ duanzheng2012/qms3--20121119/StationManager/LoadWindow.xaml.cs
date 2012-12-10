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
    /// BaseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoadWindow : Window
    {
        private static LoadWindow curWindow;
        public LoadWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        public void showMsg(string title, string msg, bool btn)
        { 
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static void showWindow()
        {
            if (curWindow != null)
                curWindow.Close();
            curWindow.Show();
        }

        public static void closeWindow()
        {
            if (curWindow != null)
                curWindow.Close();
        }
    }
}
