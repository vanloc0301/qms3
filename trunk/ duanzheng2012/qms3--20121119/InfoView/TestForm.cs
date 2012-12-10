using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfoView.Classes;
using System.Net.Sockets;

namespace InfoView
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient tc = new TcpClient();
            tc.SendTimeout = 2000;
            tc.Connect(textBox1.Text, 5000);
            if (tc.Connected)
                MessageBox.Show("连接成功！");
            else
                MessageBox.Show("连接失败！");
            tc.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TcpClient tc = new TcpClient();
            tc.SendTimeout = 2000;
            tc.Connect(textBox1.Text, 3389);
            if (tc.Connected)
                MessageBox.Show("连接成功！");
            else
                MessageBox.Show("连接失败！");
            tc.Close();
        }
    }
}
