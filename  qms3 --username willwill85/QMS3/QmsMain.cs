﻿using System;
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
            treeView1.Nodes.Clear();
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
            treeView1.Nodes.Clear();
            tabControl1.SelectTab(0);
            UNtextBox.Text = "";
            UNtextBox.Enabled = true;
            PSmaskedTextBox.Text = "";
            PSmaskedTextBox.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (UNtextBox.Text.Length != 0)
                button1.Enabled = true;
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            treeView1.SelectedNode.Nodes.ToString();
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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        #region 权限treenode生成函数 权限为 1 2 3 4 5
        public void treeviewload(int Userright)
        {

          
            System.Windows.Forms.TreeNode treeNode207 = new System.Windows.Forms.TreeNode("车辆状态信息查询");
            System.Windows.Forms.TreeNode treeNode208 = new System.Windows.Forms.TreeNode("垃圾楼状态信息查询");
            System.Windows.Forms.TreeNode treeNode209 = new System.Windows.Forms.TreeNode("转运中心状态信息查询");
            System.Windows.Forms.TreeNode treeNode210 = new System.Windows.Forms.TreeNode("转运中心结算");
            System.Windows.Forms.TreeNode treeNode211 = new System.Windows.Forms.TreeNode("西城区状态信息查询");
            System.Windows.Forms.TreeNode treeNode212 = new System.Windows.Forms.TreeNode("异常数据处理器");
            System.Windows.Forms.TreeNode treeNode213 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode214 = new System.Windows.Forms.TreeNode("垃圾楼管理");
            System.Windows.Forms.TreeNode treeNode215 = new System.Windows.Forms.TreeNode("班长管理");
            System.Windows.Forms.TreeNode treeNode216 = new System.Windows.Forms.TreeNode("报表生成器");
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.treeView1.Location = new System.Drawing.Point(3, 22);
            this.treeView1.Name = "treeView1";
           
            treeNode207.Name = "节点3";
            treeNode207.Text = "车辆状态信息查询";
            treeNode208.Name = "节点4";
            treeNode208.Text = "垃圾楼状态信息查询";
            treeNode209.Name = "节点5";
            treeNode209.Text = "转运中心状态信息查询";
            treeNode210.Name = "节点6";
            treeNode210.Text = "转运中心结算";
            treeNode211.Name = "节点7";
            treeNode211.Text = "西城区状态信息查询";
            treeNode212.Name = "节点8";
            treeNode212.Text = "异常数据处理器";
            treeNode213.Name = "节点9";
            treeNode213.Text = "用户管理";
            treeNode214.Name = "节点10";
            treeNode214.Text = "垃圾楼管理";
            treeNode215.Name = "节点11";
            treeNode215.Text = "班长管理";
            treeNode216.Name = "节点12";
            treeNode216.Text = "报表生成器";

            switch (Userright)
            {


                case 1:
                    {

                        System.Windows.Forms.TreeNode treeNode199 = new System.Windows.Forms.TreeNode("发司机卡");
                        System.Windows.Forms.TreeNode treeNode200 = new System.Windows.Forms.TreeNode("司机信息编辑");
                        System.Windows.Forms.TreeNode treeNode201 = new System.Windows.Forms.TreeNode("司机信息查询");
                        System.Windows.Forms.TreeNode treeNode202 = new System.Windows.Forms.TreeNode("司机卡管理", new System.Windows.Forms.TreeNode[] {treeNode201 });

                        System.Windows.Forms.TreeNode treeNode203 = new System.Windows.Forms.TreeNode("发货箱卡");
                        System.Windows.Forms.TreeNode treeNode204 = new System.Windows.Forms.TreeNode("货箱信息编辑");
                        System.Windows.Forms.TreeNode treeNode205 = new System.Windows.Forms.TreeNode("货箱信息查询");
                        System.Windows.Forms.TreeNode treeNode206 = new System.Windows.Forms.TreeNode("货箱卡管理", new System.Windows.Forms.TreeNode[] {treeNode205 });
                        treeNode199.Name = "节点1";
                        treeNode199.Text = "发司机卡";
                        treeNode200.Checked = true;
                        treeNode200.Name = "节点4";
                        treeNode200.Text = "司机信息编辑";
                        treeNode201.Name = "节点5";
                        treeNode201.Text = "司机信息查询";
                        treeNode202.Name = "节点0";
                        treeNode202.Text = "司机卡管理";
                        treeNode203.Name = "节点0";
                        treeNode203.Text = "发货箱卡";
                        treeNode204.Name = "节点1";
                        treeNode204.Text = "货箱信息编辑";
                        treeNode205.Name = "节点2";
                        treeNode205.Text = "货箱信息查询";
                        treeNode206.Name = "节点2";
                        treeNode206.Text = "货箱卡管理";
                        this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                            treeNode202,
                                                                            treeNode206,
                                                                            treeNode207,
                                                                            treeNode208,
                                                                            treeNode209,
                                                                            treeNode210,
                                                                            treeNode211,
                                                                            treeNode212,
                                                                          //  treeNode213,
                                                                          //  treeNode214,
                                                                          //  treeNode215,
                                                                            treeNode216});
                        break;
                    }
                case 2:
                    {
                        this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                          //  treeNode202,
                                                                          //  treeNode206,
                                                                          //  treeNode207,
                                                                            treeNode208,
                                                                          //  treeNode209,
                                                                         //   treeNode210,
                                                                         //   treeNode211,
                                                                        //    treeNode212,
                                                                       //     treeNode213,
                                                                        //    treeNode214,
                                                                        //    treeNode215,
                                                                         //   treeNode216
                                                                                           });
                        break;
                    }
                case 3:
                    {
                        this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                         //   treeNode202,
                                                                        //    treeNode206,
                                                                        //    treeNode207,
                                                                         //   treeNode208,
                                                                            treeNode209,
                                                                            treeNode210,
                                                                         //   treeNode211,
                                                                         //   treeNode212,
                                                                       //     treeNode213,
                                                                        //    treeNode214,
                                                                        //    treeNode215,
                                                                       //     treeNode216
                                                                                        });
                        break;
                    }
                case 4:
                    {
                        System.Windows.Forms.TreeNode treeNode199 = new System.Windows.Forms.TreeNode("发司机卡");
                        System.Windows.Forms.TreeNode treeNode200 = new System.Windows.Forms.TreeNode("司机信息编辑");
                        System.Windows.Forms.TreeNode treeNode201 = new System.Windows.Forms.TreeNode("司机信息查询");
                        System.Windows.Forms.TreeNode treeNode202 = new System.Windows.Forms.TreeNode("司机卡管理", new System.Windows.Forms.TreeNode[] { treeNode201 });

                        System.Windows.Forms.TreeNode treeNode203 = new System.Windows.Forms.TreeNode("发货箱卡");
                        System.Windows.Forms.TreeNode treeNode204 = new System.Windows.Forms.TreeNode("货箱信息编辑");
                        System.Windows.Forms.TreeNode treeNode205 = new System.Windows.Forms.TreeNode("货箱信息查询");
                        System.Windows.Forms.TreeNode treeNode206 = new System.Windows.Forms.TreeNode("货箱卡管理", new System.Windows.Forms.TreeNode[] { treeNode205 });
                        treeNode199.Name = "节点1";
                        treeNode199.Text = "发司机卡";
                        treeNode200.Checked = true;
                        treeNode200.Name = "节点4";
                        treeNode200.Text = "司机信息编辑";
                        treeNode201.Name = "节点5";
                        treeNode201.Text = "司机信息查询";
                        treeNode202.Name = "节点0";
                        treeNode202.Text = "司机卡管理";
                        treeNode203.Name = "节点0";
                        treeNode203.Text = "发货箱卡";
                        treeNode204.Name = "节点1";
                        treeNode204.Text = "货箱信息编辑";
                        treeNode205.Name = "节点2";
                        treeNode205.Text = "货箱信息查询";
                        treeNode206.Name = "节点2";
                        treeNode206.Text = "货箱卡管理";
                        this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                            treeNode202,
                                                                            treeNode206,
                                                                            treeNode207,
                                                                            treeNode208,
                                                                        //    treeNode209,
                                                                            treeNode210,
                                                                            treeNode211,
                                                                        //    treeNode212,
                                                                        //    treeNode213,
                                                                         //   treeNode214,
                                                                        //    treeNode215,
                                                                            treeNode216});
                        break;
                    }
                case 5:
                    {
                        System.Windows.Forms.TreeNode treeNode199 = new System.Windows.Forms.TreeNode("发司机卡");
                        System.Windows.Forms.TreeNode treeNode200 = new System.Windows.Forms.TreeNode("司机信息编辑");
                        System.Windows.Forms.TreeNode treeNode201 = new System.Windows.Forms.TreeNode("司机信息查询");
                        System.Windows.Forms.TreeNode treeNode202 = new System.Windows.Forms.TreeNode("司机卡管理", new System.Windows.Forms.TreeNode[] { treeNode199, treeNode200, treeNode201 });

                        System.Windows.Forms.TreeNode treeNode203 = new System.Windows.Forms.TreeNode("发货箱卡");
                        System.Windows.Forms.TreeNode treeNode204 = new System.Windows.Forms.TreeNode("货箱信息编辑");
                        System.Windows.Forms.TreeNode treeNode205 = new System.Windows.Forms.TreeNode("货箱信息查询");
                        System.Windows.Forms.TreeNode treeNode206 = new System.Windows.Forms.TreeNode("货箱卡管理", new System.Windows.Forms.TreeNode[] { treeNode203, treeNode204, treeNode205 });
                        treeNode199.Name = "节点1";
                        treeNode199.Text = "发司机卡";
                        treeNode200.Checked = true;
                        treeNode200.Name = "节点4";
                        treeNode200.Text = "司机信息编辑";
                        treeNode201.Name = "节点5";
                        treeNode201.Text = "司机信息查询";
                        treeNode202.Name = "节点0";
                        treeNode202.Text = "司机卡管理";
                        treeNode203.Name = "节点0";
                        treeNode203.Text = "发货箱卡";
                        treeNode204.Name = "节点1";
                        treeNode204.Text = "货箱信息编辑";
                        treeNode205.Name = "节点2";
                        treeNode205.Text = "货箱信息查询";
                        treeNode206.Name = "节点2";
                        treeNode206.Text = "货箱卡管理";
                        this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                            treeNode202,
                                                                            treeNode206,
                                                                            treeNode207,
                                                                            treeNode208,
                                                                       //     treeNode209,
                                                                            treeNode210,
                                                                            treeNode211,
                                                                       //     treeNode212,
                                                                            treeNode213,
                                                                            treeNode214,
                                                                            treeNode215,
                                                                            treeNode216});
                        break;
                    }
                case 6:
                    {
                     //just for test
                        System.Windows.Forms.TreeNode treeNode199 = new System.Windows.Forms.TreeNode("发司机卡");
                        System.Windows.Forms.TreeNode treeNode200 = new System.Windows.Forms.TreeNode("司机信息编辑");
                        System.Windows.Forms.TreeNode treeNode201 = new System.Windows.Forms.TreeNode("司机信息查询");
                        System.Windows.Forms.TreeNode treeNode202 = new System.Windows.Forms.TreeNode("司机卡管理", new System.Windows.Forms.TreeNode[] { treeNode199, treeNode200, treeNode201 });

                        System.Windows.Forms.TreeNode treeNode203 = new System.Windows.Forms.TreeNode("发货箱卡");
                        System.Windows.Forms.TreeNode treeNode204 = new System.Windows.Forms.TreeNode("货箱信息编辑");
                        System.Windows.Forms.TreeNode treeNode205 = new System.Windows.Forms.TreeNode("货箱信息查询");
                        System.Windows.Forms.TreeNode treeNode206 = new System.Windows.Forms.TreeNode("货箱卡管理", new System.Windows.Forms.TreeNode[] { treeNode203, treeNode204, treeNode205 });
                        treeNode199.Name = "节点1";
                        treeNode199.Text = "发司机卡";
                        treeNode200.Checked = true;
                        treeNode200.Name = "节点4";
                        treeNode200.Text = "司机信息编辑";
                        treeNode201.Name = "节点5";
                        treeNode201.Text = "司机信息查询";
                        treeNode202.Name = "节点0";
                        treeNode202.Text = "司机卡管理";
                        treeNode203.Name = "节点0";
                        treeNode203.Text = "发货箱卡";
                        treeNode204.Name = "节点1";
                        treeNode204.Text = "货箱信息编辑";
                        treeNode205.Name = "节点2";
                        treeNode205.Text = "货箱信息查询";
                        treeNode206.Name = "节点2";
                        treeNode206.Text = "货箱卡管理";
                        this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                            treeNode202,
                                                                            treeNode206,
                                                                            treeNode207,
                                                                            treeNode208,
                                                                            treeNode209,
                                                                            treeNode210,
                                                                            treeNode211,
                                                                            treeNode212,
                                                                            treeNode213,
                                                                            treeNode214,
                                                                            treeNode215,
                                                                            treeNode216});
                        // 
                        break;
                    }

            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
           // label5.Text = textBox1.Text;
            string k="0";
            try
            {
                k = this.dbo_UserTableAdapter.ValidateUser(UNtextBox.Text, MD5.MDString(PSmaskedTextBox.Text)).ToString();
                button1.Enabled = false;
                button2.Enabled = true;
                UNtextBox.Enabled = false;
                PSmaskedTextBox.Enabled = false;
            }
            catch (Exception s)
            {
                MessageBox.Show("输入的用户名密码有误或网络超时");
                UNtextBox.Text = "";
                PSmaskedTextBox.Text = "";
            }
            label5.Text = k;
            treeView1.Nodes.Clear();
            debugtextbox.Text = MD5.MDString(PSmaskedTextBox.Text);
            treeviewload(int.Parse(label5.Text));
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //debugtextbox.Text= treeView1.SelectedNode.Nodes.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}