using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QMS3
{
    public partial class QmsMain : Form
    {
        public QmsMain()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void panelDriverC1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.ItemSize = new Size(1, 1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "\n\t\t权限1: 二队队长\t\t\n" +
                "\n\t\t权限2: 垃圾楼楼长\t\t\n" +
                "\n\t\t权限3: 转运中心\t\t\n" +
                "\n\t\t权限4: 监管员\t\t\n" +
                "\n\t\t权限5: 系统管理员\t\t\n",
                "  权限说明书");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                button1.Enabled = true;
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.ToString())
            {
                case "TreeNode: 发司机卡":              tabControl1.SelectTab(1);
                break;
                case "TreeNode: 司机信息编辑":          tabControl1.SelectTab(2);
                break;
                case "TreeNode: 司机信息查询":          tabControl1.SelectTab(3);
                break;
                case "TreeNode: 发货箱卡":              tabControl1.SelectTab(4);
                break;
                case "TreeNode: 货箱信息编辑":          tabControl1.SelectTab(5);
                break;
                case "TreeNode: 货箱信息查询":          tabControl1.SelectTab(6);
                break;
                case "TreeNode: 车辆状态信息查询":      tabControl1.SelectTab(7);
                break;
                case "TreeNode: 垃圾楼状态信息查询":    tabControl1.SelectTab(8);
                break;
                case "TreeNode: 转运中心状态信息查询":  tabControl1.SelectTab(9);
                break;
                case "TreeNode: 转运中心结算":          tabControl1.SelectTab(10);
                break;
                case "TreeNode: 西城区状态信息查询":    tabControl1.SelectTab(11);
                break;
                case "TreeNode: 异常数据处理器":        tabControl1.SelectTab(12);
                break;
                case "TreeNode: 用户管理":              tabControl1.SelectTab(13);
                break;
                case "TreeNode: 垃圾楼管理":            tabControl1.SelectTab(14);
                break;
                case "TreeNode: 班长管理":              tabControl1.SelectTab(15);
                break;
                case "TreeNode: 报表生成器":            tabControl1.SelectTab(16);
                break;


            }
        }
    }
}
