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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections;

namespace StationManager
{
	/// <summary>
	/// WpfTimeLine.xaml 的交互逻辑
	/// </summary>
	public partial class WpfTimeLine : UserControl
	{
        //时间轴宽度
        private double lineWidth;
        public double LineWidth
        {
            set
            {
                cvsLine.Width = value;
                cvsText.Width = value;
            }
            get
            {
                return cvsLine.Width;
            }
        }

        //时间轴高度
        private double lineHeight;
        public double LineHeight
        {
            set
            {
                cvsLine.Height = value;
            }
            get
            {
                return cvsLine.Height;
            }
        }

        //文本域高度
        public double TextHeight
        {
            set
            {
                cvsText.Height = value;
            }
            get
            {
                return cvsText.Height;
            }
        }

        //字体大小
        private double textSize = 10;
        public double TextSize
        {
            set
            {
                textSize = value;
            }
            get
            {
                return textSize;
            }
        }

        //时间轴开始时间
        private int startTime;
        public int StartTime {
            get {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        //时间轴结束时间
        private int endTime;
        public int EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }
        //文本颜色
        private Color foreColor = Colors.White;
        public Color ForeColor
        {
            set
            {
                foreColor = value;
            }
            get
            {
                return foreColor;
            }
        }
        private DataTable data;
        private ArrayList elps = new ArrayList();
        //加载数据
        public void LoadData(DataTable dataArgs,string fieldName)
        {
            this.data = dataArgs;

            //清空所有圆
            for(int i=0;i<elps.Count;i++)
            {
                this.cvsLine.Children.Remove(elps[i] as Ellipse);
                
            }
            elps.Clear();
            foreach (DataRow row in data.Rows)
            {
                int hours = int.Parse(row[fieldName].ToString().Substring(9, 2))-startTime;
                int min = int.Parse(row[fieldName].ToString().Substring(12, 2)) + 60 * hours;

                double left = min*((this.cvsLine.Width / (double)(endTime - startTime)) / (double)60);
                double r = this.cvsLine.Height / 5;
                //double r = 10;
                Ellipse e = new Ellipse();
                e.Width = r;
                e.Height = r;
                e.SetValue(Canvas.TopProperty,(cvsLine.Height/2)-(r/2));
                e.SetValue(Canvas.LeftProperty,left);
                e.Fill = new SolidColorBrush(Colors.Red);
                cvsLine.Children.Add(e);
            }
        }

        public WpfTimeLine()
		{
			this.InitializeComponent();
		}

        public void initTime()
        {
            double minLen = (this.cvsLine.Width / (double)(endTime - startTime))/(double)60;    //每分钟的长度

            for (int i = startTime; i < endTime; i++)
            {
                //画出刻度
                Rectangle line = new Rectangle();
                line.Fill = new SolidColorBrush(Colors.White);
                line.Width = 1;
                line.Stroke = new SolidColorBrush(Colors.White);
                line.Height = (double)(cvsLine.Height / 4);

                line.SetValue(Canvas.LeftProperty, (double)((i - startTime) * 60 * minLen));
                line.SetValue(Canvas.TopProperty, (double)(cvsLine.Height-(cvsLine.Height / 4)));
                cvsLine.Children.Add(line);
                

                //显示时间标签
                Label lbl = new Label();
                lbl.Content = i.ToString("00")+":00";
                lbl.FontSize = textSize;
                lbl.Foreground = new SolidColorBrush(foreColor) ;
                cvsText.Children.Add(lbl);
                lbl.SetValue(Canvas.LeftProperty,(double)((i-startTime)*60*minLen));
                lbl.SetValue(Canvas.TopProperty,(double)(cvsText.Height/10));
                
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            initTime();
        }


	}
}