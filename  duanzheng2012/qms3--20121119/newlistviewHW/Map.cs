using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flash.External;
using System.IO;
using System.Threading;
using InfoView.Classes;
namespace newlistview
{
    public partial class Map : Form
    {
        public static string[] viewList = null;
        public static string[] pdaList = null;
        Thread thread;
        string scr;
        string width;
        string height;
        public Map()
        {
            InitializeComponent();
        }
        private bool appReady = false;
        private bool swfReady = false;
        //C# 封装的代理类，用于和swf方法交互
        private ExternalInterfaceProxy proxy;
        public ListItem[] mylistitem = new ListItem[56];
        private object proxy_ExternalInterfaceCall(object sender, ExternalInterfaceCallEventArgs e)
        {

            return null;
        }
        private void Initflash()
        {

           
            //swf文件路径，设置为map文件夹下面的map.swf
            string apppath = Application.StartupPath;
            string swfPath = apppath+"\\Map\\map.swf";
            this.IntrovertIMApp.LoadMovie(0, swfPath);

            // Create the proxy and register this app to receive notification when the proxy receives
            // a call from ActionScript
            
            proxy = new ExternalInterfaceProxy(IntrovertIMApp);
            proxy.ExternalInterfaceCall += new ExternalInterfaceCallEventHandler(proxy_ExternalInterfaceCall);
            
            appReady = true;
        }
        private void setallwhite()
        {
            for (int i = 0; i < mylistitem.Length; i++)
            {
                mylistitem[i].BackColor = System.Drawing.Color.White;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                const string filepath = "screen.ini";
                StreamReader objReader = new StreamReader(filepath);
                thread = new Thread(TimeOutSocket.ConnectTest);
                thread.Start();
                scr = objReader.ReadLine();
                width = objReader.ReadLine();
                height = objReader.ReadLine();
                try
                {
                    this.Location = Screen.AllScreens[int.Parse(scr)].WorkingArea.Location;
                }
                catch
                {

                }
                this.Size = new Size(int.Parse(width), int.Parse(height));
                objReader.Close();
            }
            catch
            {
                MessageBox.Show("Read config file failed!");
            }

            Initflash();
            for (int i = 0; i < mylistitem.Length; i++)
            {
                mylistitem[i] = new ListItem();
                mylistitem[i].BackColor = System.Drawing.Color.White;
                mylistitem[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //  mylistitem[i].Location = new System.Drawing.Point(3, 3);
                mylistitem[i].Name = "lt" + i.ToString();
                mylistitem[i].Size = new System.Drawing.Size(429, 212);
                mylistitem[i].TabIndex = i;
                //mylistitem[i].setid((i+31).ToString());
                //flowLayoutPanel1.Controls.Add(mylistitem[i]);
                mylistitem[i].GotFocus += new EventHandler(Form1_GotFocus);
                mylistitem[i].Click += new EventHandler(Map_Click);
            }
            for (int i = 0; i < mylistitem.Length; i++)
            {
                mylistitem[i].setid((i + 31).ToString());
                try
                {
                    proxy.Call("setFeatureVisible", new string[] { (i + 31).ToString(), "false" });
                }
                catch { }
            }

            //flowLayoutPanel1.Refresh();
          //  timer1.Enabled = true;
          //  timer1.Start();
        }

        void Map_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == false)
            {
                SetAllUnvisible();
                setallwhite();


                try
                {
                    proxy.Call("setCenter", ((ListItem)sender).StationID, "16");
                    proxy.Call("setFeatureVisible", new string[] { ((ListItem)sender).StationID, "true" });
                    string disp =
                        "站名： \t" + ((ListItem)sender).StationName + "\n"
                      + "日期： \t" + System.DateTime.Now.ToLongDateString() + "       \n"
                      + "===============================================\n"
                        + "今日清运量： \t" + ((ListItem)sender).StationNum + " 箱\t年总清运箱数： \t" + ((ListItem)sender).YearBox + "箱     \n"
                        + "今日总重量： \t" + ((ListItem)sender).StationWeight + " 吨\t年总清运重量： \t" +((ListItem)sender).YearWeight + "吨     \n\n"
                        + "===============================================\n"
                        + "今日值班员： \t" + ((ListItem)sender).Employee + "\n"

                        ;

                    proxy.Call("setText", new string[] { ((ListItem)sender).StationID, disp });

                }
                catch
                {
                    proxy.Call("viewEntire", new string[] { });
                }
            }

        }

        void Form1_GotFocus(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ((ListItem)sender).selected();
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int step = 0;
        int layer = 0;
        private void SetAllUnvisible()
        {
            for (int i = 0; i < mylistitem.Length; i++)
            {
                mylistitem[i].setid((i + 31).ToString());
                try
                {
                    proxy.Call("setFeatureVisible", new string[] { (i + 31).ToString(), "true" });
                    proxy.Call("setFeatureVisible", new string[] { (i + 31).ToString(), "false" });
                }
                catch { }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Interval = 3500;
            SetAllUnvisible();
            try
            {
                mylistitem[step].BackColor = Color.White;

                step++;
                if (step >= mylistitem.Length)
                {
                    step = 0;
                    layer++;
                    if (layer > 2)
                        layer = 0;
                    proxy.Call("switchMap", new string[] { layer.ToString() });
                }
            }
            catch { }
            try
            {
                //flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Value + 218;
            }
            catch { }
            try
            {
                //flowLayoutPanel1.Controls[step].Select();
            }
            catch { }
           // proxy.Call("viewEntire", new string[] { });
            try
            {
                proxy.Call("setCenter", mylistitem[step].StationID, "16");
                proxy.Call("setFeatureVisible", new string[] { mylistitem[step].StationID, "true" });
                string disp =
                        "站名： \t" + mylistitem[step].StationName + "\n"
                      + "日期： \t" + System.DateTime.Now.ToLongDateString() + "       \n"
                      + "===============================================\n"
                        + "今日清运量： \t" + mylistitem[step].StationNum + " 箱\t年总清箱数： \t" + mylistitem[step].YearBox + "箱     \n"
                        + "今日总重量： \t" + mylistitem[step].StationWeight + " 吨\t年总清运重量： \t" + mylistitem[step].YearWeight + "吨     \n\n"
                        + "===============================================\n"
                        + "今日值班员： \t" + mylistitem[step].Employee + "\n"

                        ;
                    
                proxy.Call("setText", new string[] { mylistitem[step].StationID, disp });

            }
            catch
            {
                proxy.Call("viewEntire", new string[] { });
            }
           // mylistitem[step].selected();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                //button1.Image = Properties.Resources.play;
                timer1.Enabled = false;
            }
            else
            {
                //button1.Image = Properties.Resources.pause;
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void IntrovertIMApp_Enter(object sender, EventArgs e)
        {

        }

        private void tmrSetLocation_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Location = Screen.AllScreens[int.Parse(scr)].WorkingArea.Location;
            }
            catch
            {

            }
            this.Size = new Size(int.Parse(width), int.Parse(height));
        }

        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
        }


    }
}
