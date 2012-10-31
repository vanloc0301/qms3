using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Distributor
{
    public partial class Form2 : Form
    {
        [DllImport("Coredll.dll")]
        private extern static bool PlaySound(string strFile, IntPtr hMod, int flag);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }
        public void setmsg(string msg, int logo,string sound)
        {
            timer1.Enabled = true;
            this.Visible = true;
            this.TopMost = true;
           // this.Show();
            label1.Text = msg;
            if (logo == 1)
                pictureBox1.Image = Properties.Resources.suc;
            if (logo == 2)
                pictureBox1.Image = Properties.Resources.failed;
            if (logo == 3)
                pictureBox1.Image = Properties.Resources.info;
            this.Refresh();
            PlaySound(sound, IntPtr.Zero, 0x0002);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            timer1.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}