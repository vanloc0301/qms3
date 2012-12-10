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
    public partial class Form1 : Form
    {
        private int i;
        public Form1(int i1)
        {
            this.i = i1;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = i.ToString();
        }
    }
}
