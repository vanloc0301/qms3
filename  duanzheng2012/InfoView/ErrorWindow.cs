using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InfoView
{
    public partial class ErrorWindow : Form
    {

        static private ErrorWindow instant;

        static public void ShowWindow()
        {
            if (instant == null)
                instant = new ErrorWindow();
            instant.Show();
        }

        private ErrorWindow()
        {
            InitializeComponent();
        }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            int sWidth = 0;
            int sHeight = 0;
            foreach (Screen s in Screen.AllScreens)
            {
                sWidth = s.WorkingArea.Width;
                sHeight = s.WorkingArea.Height;
            }

            Point p = new Point();
            p.X = sWidth - this.Size.Width;
            p.Y = sHeight - this.Size.Height;
            this.Location = p;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
