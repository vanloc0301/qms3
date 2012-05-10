using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NetCheck;
namespace NetCheckerWin
{
    public partial class Trans : Form
    {
        const string filepath = "NetConfig_Center.ini";
        public Trans()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.ControlBox = false;
            this.Size = new Size(380, 38);
            this.MaximumSize = new Size(380, 38);
            this.MinimumSize = new Size(380, 38);
        }
        protected override CreateParams CreateParams
        {
            get
            { int WS_EX_TOOLWINDOW = 0x80; CreateParams CP = base.CreateParams; CP.ExStyle = CP.ExStyle | WS_EX_TOOLWINDOW; return CP; }
        } 
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
            this.ShowInTaskbar = false;
            this.SetVisibleCore(true);
            this.Visible = false;
            this.TopMost = true;
            Point p = new Point();
            p.X = SystemInformation.VirtualScreen.Width -380;
            p.Y = 0;
            this.Location = p;
            timer1.Start();

        }
        public void dowork()
        {
            StreamReader objReader = new StreamReader(filepath);

            string ip = objReader.ReadLine();
            string CameraIP = objReader.ReadLine();
            string Weight = objReader.ReadLine();
            string Reader = objReader.ReadLine();
            objReader.Close();
            // NetCheck.StatusChecker.checkit();
            if (NetCheck.StatusChecker.CheckInternet())
            {
                pictureBox1.Image = Properties.Resources.status;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.status_busy;
            }

            if (NetCheck.StatusChecker.CheckConnection(CameraIP))
            {
                pictureBox2.Image = Properties.Resources.status;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.status_busy;
            }

            if (NetCheck.StatusChecker.CheckConnection(Weight))
            {
                pictureBox3.Image = Properties.Resources.status;
            }
            else
            {
                pictureBox3.Image = Properties.Resources.status_busy;
            }
            if (NetCheck.StatusChecker.CheckConnection(Reader))
            {
                pictureBox4.Image = Properties.Resources.status;
            }
            else
            {
                pictureBox4.Image = Properties.Resources.status_busy;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
  
            if (timer1.Interval != 300000)
                timer1.Interval = 300000;
            System.Threading.Thread th = new System.Threading.Thread(dowork);
            th.Start();
        }

        int X;
        int Y;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - Y
                - SystemInformation.FrameBorderSize.Height;
                this.Left = Control.MousePosition.X - X
                - SystemInformation.FrameBorderSize.Width;
            }
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;

            }
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - Y
                - SystemInformation.FrameBorderSize.Height;
                //  - SystemInformation.CaptionHeight;
                this.Left = Control.MousePosition.X - X
                - SystemInformation.FrameBorderSize.Width - ((Control)sender).Location.X;
            }
        }





    }
}
