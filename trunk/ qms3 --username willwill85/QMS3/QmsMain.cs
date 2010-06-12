using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Runtime.InteropServices;
using System.Diagnostics; 

namespace QMS3
{
    public partial class QmsMain : Form
    {   
        /****三个自定义类对象的初始化****/
        QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();//建一个BaseOperate类的对象boperate
       // QMS3.BaseClass.OperateAndValidate opAndvalidate = new QMS.BaseClass.OperateAndValidate();
       // QMS3.CfCardPC.CfCardPC cardrelated = new QMS.CfCardPC.CfCardPC();
        /******************************/
        bool ifcon = false;
        DataSet ds;
        string Dayreport;
        string right;
        bool conneted = false;

        //***added by wangchao
        SqlConnection sqlcon;
        DataSet crform_ds;
        DataTable result_tb;
        DataTable dt_goods;
        //***

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
            MainTab.ItemSize = new Size(1, 1);
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
            MainTab.SelectTab(0);
            UNtextBox.Text = "";
            UNtextBox.Enabled = true;
            PSmaskedTextBox.Text = "";
            PSmaskedTextBox.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            conneted = false;
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
                case "TreeNode: 发司机卡":              MainTab.SelectTab(1);
                break;
                case "TreeNode: 司机信息编辑":          MainTab.SelectTab(2);
                break;
                case "TreeNode: 司机信息查询":          MainTab.SelectTab(3);
                break;
                case "TreeNode: 发货箱卡":              MainTab.SelectTab(4);
                break;
                case "TreeNode: 货箱信息编辑":          MainTab.SelectTab(5);
                break;
                case "TreeNode: 货箱信息查询":          MainTab.SelectTab(6);
                break;
                case "TreeNode: 车辆状态信息查询":      MainTab.SelectTab(7);
                break;
                case "TreeNode: 垃圾楼状态信息查询":    MainTab.SelectTab(8);
                break;
                case "TreeNode: 转运中心状态信息查询":
                {
                    progressBar2.Visible = true;
                    progressBar1.Visible = true;

                    if(!showDayreport.IsBusy)
                        showDayreport.RunWorkerAsync();
                    if (!showDayImagereport.IsBusy)
                        showDayImagereport.RunWorkerAsync();
                    dateTimePicker1.Value = System.DateTime.Now;  
                    MainTab.SelectTab(9);
                }
                break;
                case "TreeNode: 转运中心结算":
                {
                    MainTab.SelectTab(10);
                    if (!ifcon)
                    {
                        if (TransCenter.connect())
                        {
                            ifcon = true;
                        }
                        else
                        {
                            MainTab.SelectTab(0);
                        }
                    }
                    break;
                }
                case "TreeNode: 西城区状态信息查询":    MainTab.SelectTab(11);
                break;
                case "TreeNode: 异常数据处理器":        MainTab.SelectTab(12);
                break;
                case "TreeNode: 用户管理":              MainTab.SelectTab(13);
                break;
                case "TreeNode: 垃圾楼管理":            MainTab.SelectTab(14);
                break;
                case "TreeNode: 班长管理":              MainTab.SelectTab(15);
                break;
                case "TreeNode: 日垃圾清运完成情况":    MainTab.SelectTab(16);
                    break;
                case "TreeNode: 每月清运垃圾明细表":
                    {
                        sqlcon = boperate.getcon();
                        crform_ds = new DataSet();
                        dt_goods = crform_ds.Tables.Add("Goods_Table");
                        //用来存储最终的结果
                        result_tb = crform_ds.Tables.Add("Result");
                        toolStripButtonMonExl.Enabled = false;
                        groupBoxReport.Enabled = false;
                        MainTab.SelectTab(17);                    
                    }
                    
                    break;
                case "TreeNode: 年度清运垃圾明细表":    MainTab.SelectTab(18);
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

            System.Windows.Forms.TreeNode treeNode216 = new System.Windows.Forms.TreeNode("日垃圾清运完成情况");
            System.Windows.Forms.TreeNode treeNode217 = new System.Windows.Forms.TreeNode("每月清运垃圾明细表");
            System.Windows.Forms.TreeNode treeNode218 = new System.Windows.Forms.TreeNode("年度清运垃圾明细表");


            System.Windows.Forms.TreeNode treeNode236 = new System.Windows.Forms.TreeNode("报表生成器", new System.Windows.Forms.TreeNode[] {treeNode216,treeNode217,treeNode218 });
            //this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.treeView1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
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
            treeNode216.Text = "日垃圾清运完成情况";
            treeNode217.Name = "节点13";
            treeNode217.Text = "每月清运垃圾明细表";
            treeNode218.Name = "节点14";
            treeNode218.Text = "年度清运垃圾明细表";




            treeNode236.Name = "节点36";
            treeNode236.Text = "报表生成器";

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
                                                                            treeNode236});
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
                                                                         //   treeNode236
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
                                                                       //     treeNode236
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
                                                                            treeNode236});
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
                                                                            treeNode236});
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
                                                                            treeNode236});
                        // 
                        break;
                    }

            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
           // label5.Text = textBox1.Text;
            if (!login.IsBusy)
            {
                login.RunWorkerAsync();
                LogingroupBox.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
            else
                MessageBox.Show("正在登陆中情耐心等待！");
            //try
            //{
                
            //    button1.Enabled = false;
            //    button2.Enabled = true;
            //    UNtextBox.Enabled = false;
            //    PSmaskedTextBox.Enabled = false;
            //}
            //catch 
            //{
            //    MessageBox.Show("输入的用户名密码有误或网络超时");
            //    UNtextBox.Text = "";
            //    PSmaskedTextBox.Text = "";
            //}
            //label5.Text = k;
            //treeView1.Nodes.Clear();
            //treeviewload(int.Parse(label5.Text));
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //debugtextbox.Text= treeView1.SelectedNode.Nodes.ToString();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                this.AcceptButton = button3;
            else
                this.AcceptButton = button1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x;
            try
            {
                x = Convert.ToDouble(textBox1.Text.Trim());
                //直接转换，如果是数字无异常，如果不是数字会抛异常
                if (x > 10 || x < 0)
                {
                    MessageBox.Show("输入数值过大！");
                    textBox1.Text = "";
                    return;
                }

            }
            catch 
            {
                MessageBox.Show("输入数值非法！");
                textBox1.Text = "";
                return;
            }
            //  if (!CheckState())
            //    return;
            // WritetoCard(textBox1.Text);
            // WritetoDatabase(textBox1.Text);
            string ID = "";
            int Ccount = 0;
            //sEndTime = System.DateTime.Now.ToString("yy-MM-dd,HH:mm");
            if (TransCenter.Request(ref ID, ref Ccount) == 0)
            {
                debugtextbox.Text += "\n读到卡数"+ Ccount.ToString()+"\n";
                if (Ccount == 1)
                    listBox1.Items.Add("操作卡号：" + TransCenter.ToHexString(TransCenter.TagBuffer).Substring(2, 6));
                else
                {
                    MessageBox.Show("区域内检查到" + Ccount.ToString() + "张卡片！\n请确保1张卡片在扫描区域中再操作！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("没有读到卡片！");
                return;
            }
            string info = "";
            string Starttime="";
            int StartStation = 0;
            if (TransCenter.readinfo(ref info,textBox1.Text,ref Starttime,ref StartStation))
            {
                //this.myadapter.UpdateCommand = new SqlCommand(" UPDATE [dbo.Goods] SET [State] = @State, [Weight] = @Weight WHERE (BoxCardID = @BoxCardID) AND (TruckNo = @TruckNo) AND (StartTime = @StartTime) AND (StartStationID = @StartStationID)");

                //MessageBox.Show("OK");
                try
                {
                    this.dbo_GoodsTableAdapter.UpdateGoodsByTime(1, double.Parse(textBox1.Text),TransCenter.sEndTime, Starttime, StartStation);   
                    listBox1.Items.Add(info);
                }
                catch
                {
                    MessageBox.Show("数据库同步失败！");
                    listBox1.Items.Add(info + "   " + "数据库同步失败！");
                }
            }
            else
            {
                MessageBox.Show("操作失败！");
                listBox1.Items.Add(info);
                return;
            }
            MessageBox.Show("操作成功！");
            textBox1.Text = "";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            
            string systime = dateTimePicker1.Value.ToString("yy-MM-dd");
            
            showDayreport.ReportProgress(30);
            string strSQL = "SELECT DISTINCT  [db_rfidtest].[rfidtest].[dbo.Station].[Name] AS '起始站点' , "+
                " [db_rfidtest].[rfidtest].[dbo.Goods].[BoxCardID] AS '货箱卡号' ,  "+
                "[db_rfidtest].[rfidtest].[dbo.Goods].[TruckNo] AS '货车牌号' ,  "+
                "[db_rfidtest].[rfidtest].[dbo.Goods].[StartTime] AS '开始时间' ,  "+
                "[db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] AS '结束时间' ,  [db_rfidtest].[rfidtest].[dbo.Goods].[Weight] AS '重量(单位:吨)'"+
                " FROM  [db_rfidtest].[rfidtest].[dbo.Goods] INNER JOIN  [db_rfidtest].[rfidtest].[dbo.Station] ON   "+
                "[db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = [db_rfidtest].[rfidtest].[dbo.Station].[StationID] "+
                "WHERE  [db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] > '" + systime + ",00:00' AND [db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] < '" + systime + ",23:59'";
            string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
            showDayreport.ReportProgress(80);
            try
            {
                ds = boperate.getds(strSQL, strTable);
            }
            catch
            {
                MessageBox.Show("网络连接失败！请稍后重试");
                //showDayreport.CancelAsync();
            }
            ////DataSet中的SQL查询结果放入DataGridView中
            ////dataGridView1.DataSource = db_rfidtestDataSet._dbo_Goods;
            showDayreport.ReportProgress(99);
            
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ds.Tables[0];
                progressBar2.Visible = false;
            }
            catch
            {
            }

        }
       
        void backgroundWorker1_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
            debugtextbox.Text += e.ProgressPercentage.ToString()+".";

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //showDayreport.RunWorkerAsync();
            progressBar2.Visible = true;
            progressBar1.Visible = true;
            if (!showDayreport.IsBusy)
                showDayreport.RunWorkerAsync();
            if (!showDayImagereport.IsBusy)
                showDayImagereport.RunWorkerAsync();
        }

        private void showDayImagereport_DoWork(object sender, DoWorkEventArgs e)
        {
            //pictureBox2.ImageLocation 
             Dayreport= "http://chart.apis.google.com/chart?cht=ls" +
                                "&chs=836x250" +
                              //  "&chd=t:1,0,3,9,5,8,14,8,9,6,11,12,4,6,4,2" +
                                "&chds=0,15" +
                                "&chxt=x,y&chxl=0:|5:00|6:00|7:00|8:00|9:00|10:00|11:00|12:00|13:00|14:00|15:00|16:00|17:00|18:00|19:00|20:00|1:|0|5|10|15&chf=bg,s,EFEFEF" +
                                "&chtt=转运中心当天时间分布情况&chco=4d89f9&chts=0000FF,20" +
                                "&chg=5,20";
             string chd = "&chd=t:";
             int pc = 0;
             try
             {
                 for (int i = 5; i <= 20; i++)
                 {
                     string p1,p2;
                     if(i<10)
                          p1 = dateTimePicker1.Value.ToString("yy-MM-dd")+",0"+i.ToString();
                     else
                          p1= dateTimePicker1.Value.ToString("yy-MM-dd")+","+i.ToString();
                     if((i+1)<10)
                          p2 = dateTimePicker1.Value.ToString("yy-MM-dd")+",0"+(i+1).ToString();
                     else
                         p2 = dateTimePicker1.Value.ToString("yy-MM-dd") + "," + (i + 1).ToString();

                   
                         chd += this.dbo_GoodsTableAdapter.NumBetweenTime(p1, p2) + ",";
                    

                     pc += 6;
                     showDayImagereport.ReportProgress(pc);
                     
                  }
             }
             catch
             {
                    MessageBox.Show("网络连接失败！请稍后重试");
                  //showDayImagereport.CancelAsync();
             }
             Dayreport += chd;
             Dayreport = Dayreport.Substring(0, Dayreport.Length - 1);
            //pictureBox2.Load(); 
        }
        void showDayImagereport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            debugtextbox.Text +="    "+ Dayreport;
            progressBar1.Visible = false;
            pictureBox2.ImageLocation = Dayreport;
            pictureBox2.Load();
        }

        void showDayImagereport_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            debugtextbox.Text += e.ProgressPercentage.ToString() + ".";

        }

        private void login_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                right = this.dbo_UserTableAdapter.ValidateUser(UNtextBox.Text, MD5.MDString(PSmaskedTextBox.Text)).ToString();
                conneted = true;
            }
            catch
            {
                right = "0";
                conneted = false;
            }

        }
        void login_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(conneted)
            {

                button1.Enabled = false;
                button2.Enabled = true;
                UNtextBox.Enabled = false;
                PSmaskedTextBox.Enabled = false;
            }
            else
            {
                MessageBox.Show("输入的用户名密码有误或网络超时");
                UNtextBox.Text = "";
                PSmaskedTextBox.Text = "";
            }
            label5.Text = right;
            treeView1.Nodes.Clear();
            treeviewload(int.Parse(label5.Text));
            LogingroupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.MultiSelect=false;

            debugtextbox.Text = dataGridView2.SelectedRows.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string systime = "10-06-11";
           // System.DateTime.Now.ToString("yy-MM-dd");
            
            string strSQL = "SELECT DISTINCT  [db_rfidtest].[rfidtest].[dbo.Station].[Name] AS '起始站点' , " +
                " [db_rfidtest].[rfidtest].[dbo.Goods].[BoxCardID] AS '货箱卡号' ,  " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[TruckNo] AS '货车牌号' ,  " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[StartTime] AS '开始时间' ,  " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] AS '结束时间' ,  [db_rfidtest].[rfidtest].[dbo.Goods].[Weight] AS '重量(单位:吨)'" +
                " FROM  [db_rfidtest].[rfidtest].[dbo.Goods] INNER JOIN  [db_rfidtest].[rfidtest].[dbo.Station] ON   " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = [db_rfidtest].[rfidtest].[dbo.Station].[StationID] " +
                "WHERE  [db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] > '" + systime + ",00:00' AND [db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] < '" + systime + ",23:59'";
            string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
            
            try
            {
                ds = boperate.getds(strSQL, strTable);
            }
            catch
            {
                MessageBox.Show("网络连接失败！请稍后重试");
                //showDayreport.CancelAsync();
            }
            dataGridView2.DataSource = ds.Tables[0];
        }




    }
}
