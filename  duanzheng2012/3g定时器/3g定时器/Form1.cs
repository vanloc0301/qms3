using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using Telnet;
using Microsoft.Win32;

namespace _3g定时器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; 
            this.ShowInTaskbar = false; 
        } 
        protected override CreateParams CreateParams 
        { get 
            { int WS_EX_TOOLWINDOW = 0x80; CreateParams CP=base.CreateParams; CP.ExStyle= CP.ExStyle|WS_EX_TOOLWINDOW; return CP; }
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            SetRouter("offline");
        }
        public void SetRouter(string cmd)
        {
            Terminal tn = new Terminal("192.168.1.1", 23, 10, 80, 40); // hostname, port, timeout [s], width, height
            string Text="";
            tn.Connect(); // physical connection
            do
            {
                string f = tn.WaitForString("Login");
                if (f == null)
                    break; // this little clumsy line is better to watch in the debugger
                Text += tn.VirtualScreen.Hardcopy().TrimEnd();
                tn.SendResponse("admin", true);	// send username
                f = tn.WaitForString("Password");
                if (f == null)
                    break;
                Text += tn.VirtualScreen.Hardcopy().TrimEnd();
                tn.SendResponse("admin", true);	// send password 
                f = tn.WaitForString("#");
                if (f == null)
                    break;

                if (cmd == "online")
                {
                    tn.SendResponse("nvram set wan_way 1", true);	// send Shell command
                    if (tn.WaitForChangedScreen())
                        Text = tn.VirtualScreen.Hardcopy().TrimEnd();
                }
                if (cmd == "offline")
                {
                    tn.SendResponse("nvram set wan_way 0", true);	// send Shell command
                    if (tn.WaitForChangedScreen())
                        Text = tn.VirtualScreen.Hardcopy().TrimEnd();
                }
                tn.SendResponse("nvram commit", true);	// send Shell command

                if (tn.WaitForChangedScreen())
                    Text = tn.VirtualScreen.Hardcopy().TrimEnd();

                System.Threading.Thread.Sleep(2000);
                tn.SendResponse("nvram reboot", true);	// send Shell command

                if (tn.WaitForChangedScreen())
                    Text = tn.VirtualScreen.Hardcopy().TrimEnd();

            } while (false);
            tn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetRouter("online");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            this.ShowInTaskbar = false;
            this.SetVisibleCore(true);
            this.Visible = false;
            XmlDocument configfile = new XmlDocument();
            configfile.Load("config.xml");
            XmlNode config = configfile.SelectSingleNode("Configs");
            XmlNodeList singletask = config.ChildNodes;
            foreach (XmlNode configTime in singletask)
            {
                XmlElement XE = (XmlElement)configTime;
                XmlNode starth = XE.SelectSingleNode("StartH");
                XmlNode endh = XE.SelectSingleNode("EndH");
                XmlNode startm = XE.SelectSingleNode("StartM");
                XmlNode endm = XE.SelectSingleNode("EndM");
                XmlNode shell = XE.SelectSingleNode("Shell");
                if (shell.InnerText == "false")
                {
                   
                    //[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon]
                    //"Shell"="explorer.exe"
                    RegistryKey hklm = Registry.LocalMachine;
                    RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                    RegistryKey micro = software.OpenSubKey("Microsoft", true);
                    RegistryKey winnt = micro.OpenSubKey("Windows NT", true);
                    RegistryKey cv = winnt.OpenSubKey("CurrentVersion", true);
                    RegistryKey winlogon = cv.OpenSubKey("Winlogon", true);
                    winlogon.SetValue("Shell", "");

                    kill("explorer");
                }
                else
                {
                    RegistryKey hklm = Registry.LocalMachine;
                    RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                    RegistryKey micro = software.OpenSubKey("Microsoft", true);
                    RegistryKey winnt = micro.OpenSubKey("Windows NT", true);
                    RegistryKey cv = winnt.OpenSubKey("CurrentVersion", true);
                    RegistryKey winlogon = cv.OpenSubKey("Winlogon", true);
                    winlogon.SetValue("Shell", "explorer.exe");
                    bool live = false;
                    try
                    {
                        System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
                        foreach (System.Diagnostics.Process myProcess in myProcesses)
                        {
                            //listBox1.Items.Add(myProcess.ProcessName.ToLower());
                            if (myProcess.ProcessName.ToLower() == "explorer")
                                live = true;
                        }
                    }
                    catch (Exception ee)
                    { }
                    if (!live)
                    {
                        System.Diagnostics.Process.Start("explorer.exe");
                    }

                }
                label4.Text = starth.InnerText + "时" + startm.InnerText + "分";
                label3.Text = endh.InnerText + "时" + endm.InnerText + "分";
                int starttime = int.Parse(starth.InnerText) * 60 + int.Parse(startm.InnerText);
                int endtime = int.Parse(endh.InnerText) * 60 + int.Parse(endm.InnerText);
                string  curentH = DateTime.Now.ToString("HH");
                string curentM = DateTime.Now.ToString("mm");
                int curentime = int.Parse(curentH) * 60 + int.Parse(curentM);
                if (curentime < endtime && curentime >= starttime)
                {
                    //MessageBox.Show("online "+curentime.ToString()+" "+starttime.ToString()+" "+endtime.ToString());
                    SetRouter("online");
                }
                else
                {
                   // MessageBox.Show("offline");
                    SetRouter("offline");
                }
            }
            this.Visible = true;
     
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void kill(string name)
        {
            try
            {
                System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process myProcess in myProcesses)
                {
                    //listBox1.Items.Add(myProcess.ProcessName.ToLower());
                    if (name == myProcess.ProcessName)
                        myProcess.Kill();
                }
            }
            catch (Exception ee)
            {  }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = "现在时间：" + DateTime.Now.ToString("HH时mm分ss秒");
            if (DateTime.Now.ToString("HH时mm分ss秒") == (label4.Text + "00秒"))
            {
                //MessageBox.Show("online");
                SetRouter("online");
            }
            if (DateTime.Now.ToString("HH时mm分ss秒") == (label3.Text + "00秒"))
            {
                //MessageBox.Show("offline");
                SetRouter("offline");
            }
        }
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        static extern byte MapVirtualKey(byte wCode, int wMap);

        private void button3_Click(object sender, EventArgs e)
        {
            keybd_event(18, MapVirtualKey(18, 0), 0, 0); //按下CTRL鍵。　　　
            keybd_event(9, MapVirtualKey(9, 0), 0, 0); //按下CTRL鍵。　
            keybd_event(9, MapVirtualKey(9, 0), 2, 0); //按下CTRL鍵。　
            //keybd_event(70, MapVirtualKey(70, 0), 0, 0);//鍵下f鍵。　　　
            //keybd_event(70, MapVirtualKey(70, 0), 0x2, 0);//放開f鍵。　　0x35　
         //   System.Threading.Thread.Sleep(300);//开起程序后等待
            keybd_event(9, MapVirtualKey(9, 0), 0, 0); //按下CTRL鍵。　
            keybd_event(9, MapVirtualKey(9, 0), 2, 0); //按下CTRL鍵。　
            keybd_event(18, MapVirtualKey(18, 0), 0x2, 0);//放開CTRL鍵。 

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
