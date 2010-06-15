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


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Office.Interop;
using Microsoft.Office.Core;
using System.Threading;

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
        SqlDataAdapter crform_sqlda;
        DataTable result_tb;
        DataTable dt_goods;
        bool flag_mon;
        bool flag_day;
        bool flag_exl;
        bool flag_everyday;
        bool flag_everydayexl;
        string fName;
        //***

        public QmsMain()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            MainTab.ItemSize = new Size(1, 1);
            treeView1.Nodes.Clear();
        }

        //***********************所有功能TAB请修改下面的tree view操作*********************

        #region treeview 操作
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
                    #region 转运中心查询
                    progressBar2.Visible = true;
                    progressBar1.Visible = true;

                    if(!showDayreport.IsBusy)
                        showDayreport.RunWorkerAsync();
                    if (!showDayImagereport.IsBusy)
                        showDayImagereport.RunWorkerAsync();
                    dateTimePicker1.Value = System.DateTime.Now;  
                    MainTab.SelectTab(9);
                    #endregion
                }
                break;
                case "TreeNode: 转运中心结算":
                {
                    #region 转运中心结算
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
                    #endregion
                }
                case "TreeNode: 西城区状态信息查询":    MainTab.SelectTab(11);
                break;
                case "TreeNode: 异常数据处理器":
                {
                    #region 异常处理
                    string systime = System.DateTime.Now.ToString("yy-MM-dd");//  //"10-06-11";
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
                    MainTab.SelectTab(12);
                    break;
                    #endregion
                }
                case "TreeNode: 用户管理":
                {
                    #region 用户管理
                    string systime = System.DateTime.Now.ToString("yy-MM-dd");//  //"10-06-11";
                    // System.DateTime.Now.ToString("yy-MM-dd");

                    string strSQL = "SELECT UserID AS '用户ID', UserName AS '用户名', UserRight AS '用户权限' FROM [dbo.User]";
                    string strTable = " [db_rfidtest].[rfidtest].[dbo.user]";

                    try
                    {
                        ds = boperate.getds(strSQL, strTable);
                    }
                    catch
                    {
                        MessageBox.Show("网络连接失败！请稍后重试");
                        //showDayreport.CancelAsync();
                    }
                    dataGridView4.DataSource = ds.Tables[0];

                    MainTab.SelectTab(13);
                    break;
                    #endregion
                }
                case "TreeNode: 垃圾楼管理":
                {
                    string systime = System.DateTime.Now.ToString("yy-MM-dd");//  //"10-06-11";
                    // System.DateTime.Now.ToString("yy-MM-dd");

                    string strSQL = "SELECT StationID AS '站号', Name AS '站名', Class AS '所属班号' FROM [dbo.Station]";
                    string strTable = " [db_rfidtest].[rfidtest].[dbo.Station]";

                    try
                    {
                        ds = boperate.getds(strSQL, strTable);
                    }
                    catch
                    {
                        MessageBox.Show("网络连接失败！请稍后重试");
                        //showDayreport.CancelAsync();
                    }
                    dataGridView5.DataSource = ds.Tables[0];

                    strSQL = "SELECT  Name AS '姓名', Class AS '对应班号' FROM [dbo.Class]";
                    strTable = " [db_rfidtest].[rfidtest].[dbo.Class]";

                    try
                    {
                        ds = boperate.getds(strSQL, strTable);
                    }
                    catch
                    {
                        MessageBox.Show("网络连接失败！请稍后重试");
                        //showDayreport.CancelAsync();
                    }

                    dataGridView6.DataSource = ds.Tables[0];

                    MainTab.SelectTab(14);
                    break;
                }
                case "TreeNode: 班长管理":
                {

                    string strSQL = "SELECT ID AS '用户ID', Name AS '姓名', Class AS '班号' FROM [dbo.Class]";
                    string strTable = " [db_rfidtest].[rfidtest].[dbo.Class]";

                    try
                    {
                        ds = boperate.getds(strSQL, strTable);
                    }
                    catch
                    {
                        MessageBox.Show("网络连接失败！请稍后重试");
                        //showDayreport.CancelAsync();
                    }

                    dataGridView7.DataSource = ds.Tables[0];
                    MainTab.SelectTab(15);
                    break;
                }
                case "TreeNode: 日垃圾清运完成情况":
                {
                    sqlcon = boperate.getcon();
                    crform_ds = new DataSet();
                    dt_goods = crform_ds.Tables.Add("Goods_Table");
                    //用来存储最终的结果
                    result_tb = crform_ds.Tables.Add("Result");

                    #region  建立存储结果的datatable Result
                    //向新建的存储最终的结果的DataTable加入列名
                    DataColumn col = result_tb.Columns.Add("StaName", Type.GetType("System.String"));
                    col.AllowDBNull = false;
                    col.MaxLength = 20;
                    col = result_tb.Columns.Add("SumBox", Type.GetType("System.Int32"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_2", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_3", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_4", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_5", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_6", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_7", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_8", Type.GetType("System.Decimal"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_9", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_10", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_11", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_12", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_13", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_14", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("Weight_15", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("SumWeight", Type.GetType("System.Double"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("SumBoxTail", Type.GetType("System.Int32"));
                    col.AllowDBNull = true;
                    col = result_tb.Columns.Add("DateID", Type.GetType("System.String"));
                    col.AllowDBNull = true;
                    #endregion


                    flag_everyday = false;
                    flag_everydayexl = false;
                    toolStripButtonDayCompExl.Enabled = false;
                    groupBoxReport2.Enabled = false;
                    MainTab.SelectTab(16);
                }
                break;
                case "TreeNode: 每月清运垃圾明细表":
                {
                        sqlcon = boperate.getcon();
                        crform_ds = new DataSet();
                        dt_goods = crform_ds.Tables.Add("Goods_Table");
                        //用来存储最终的结果
                        result_tb = crform_ds.Tables.Add("Result");

                        #region  建立存储结果的datatable Result
                        //向新建的存储最终的结果的DataTable加入列名
                        DataColumn col = result_tb.Columns.Add("StaName", Type.GetType("System.String"));
                        col.AllowDBNull = false;
                        col.MaxLength = 20;
                        col = result_tb.Columns.Add("SumBox", Type.GetType("System.Int32"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_2", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_3", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_4", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_5", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_6", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_7", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_8", Type.GetType("System.Decimal"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_9", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_10", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_11", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_12", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_13", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_14", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_15", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("SumWeight", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("SumBoxTail", Type.GetType("System.Int32"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("DateID", Type.GetType("System.String"));
                        col.AllowDBNull = true;
                        #endregion

                        flag_mon = false;
                        flag_day = false;
                        flag_exl = false;
                        toolStripButtonMonExl.Enabled = false;
                        groupBoxReport.Enabled = false;
                        MainTab.SelectTab(17);                    
                 }
                    
                    break;
                case "TreeNode: 年度清运垃圾明细表":
                    {
                        sqlcon = boperate.getcon();
                        crform_ds = new DataSet();
                        comboBoxMon3.Enabled = false;
                        comboBoxDay3.Enabled = false;
                        dt_goods = crform_ds.Tables.Add("Goods_Table");
                        //用来存储最终的结果
                        result_tb = crform_ds.Tables.Add("Result");
                        toolStripButtonYearExl.Enabled = false;
                        groupBoxReport3.Enabled = false;
                        fName = "";

                        #region  建立存储结果的datatable Result
                        //向新建的存储最终的结果的DataTable加入列名
                        DataColumn col = result_tb.Columns.Add("StaName", Type.GetType("System.String"));
                        col.AllowDBNull = false;
                        col.MaxLength = 20;
                        col = result_tb.Columns.Add("SumBox", Type.GetType("System.Int32"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_2", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_3", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_4", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_5", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_6", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_7", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_8", Type.GetType("System.Decimal"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_9", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_10", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_11", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_12", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_13", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_14", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("Weight_15", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("SumWeight", Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("SumBoxTail", Type.GetType("System.Int32"));
                        col.AllowDBNull = true;
                        col = result_tb.Columns.Add("DateID", Type.GetType("System.String"));
                        col.AllowDBNull = true;
                        #endregion

 
                        MainTab.SelectTab(18);
                    }
                    break;


            }
        }
        #endregion

        //*******************added by wanchao*********************************************

        #region 月表
        private void comboBoxDay1_DropDown(object sender, EventArgs e)//生成每个月对应的天数
        {
            if (comboBoxYear1.Text.Trim() == "" || comboBoxMon1.Text.Trim() == "")
            {
                MessageBox.Show("请先选择年月，再选择日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                comboBoxDay1.Items.Clear();
                if (comboBoxMon1.Text.Trim() == "1" || comboBoxMon1.Text.Trim() == "3" || comboBoxMon1.Text.Trim() == "5" || comboBoxMon1.Text.Trim() == "7" || comboBoxMon1.Text.Trim() == "8" || comboBoxMon1.Text.Trim() == "10" || comboBoxMon1.Text.Trim() == "12")
                {


                    comboBoxDay1.Items.Add("1");
                    comboBoxDay1.Items.Add("2");
                    comboBoxDay1.Items.Add("3");
                    comboBoxDay1.Items.Add("4");
                    comboBoxDay1.Items.Add("5");
                    comboBoxDay1.Items.Add("6");
                    comboBoxDay1.Items.Add("7");
                    comboBoxDay1.Items.Add("8");
                    comboBoxDay1.Items.Add("9");
                    comboBoxDay1.Items.Add("10");
                    comboBoxDay1.Items.Add("11");
                    comboBoxDay1.Items.Add("12");
                    comboBoxDay1.Items.Add("13");
                    comboBoxDay1.Items.Add("14");
                    comboBoxDay1.Items.Add("15");
                    comboBoxDay1.Items.Add("16");
                    comboBoxDay1.Items.Add("17");
                    comboBoxDay1.Items.Add("18");
                    comboBoxDay1.Items.Add("19");
                    comboBoxDay1.Items.Add("20");
                    comboBoxDay1.Items.Add("21");
                    comboBoxDay1.Items.Add("22");
                    comboBoxDay1.Items.Add("23");
                    comboBoxDay1.Items.Add("24");
                    comboBoxDay1.Items.Add("25");
                    comboBoxDay1.Items.Add("26");
                    comboBoxDay1.Items.Add("27");
                    comboBoxDay1.Items.Add("28");
                    comboBoxDay1.Items.Add("29");
                    comboBoxDay1.Items.Add("30");
                    comboBoxDay1.Items.Add("31");
                }
                else if (comboBoxMon1.Text.Trim() == "4" || comboBoxMon1.Text.Trim() == "6" || comboBoxMon1.Text.Trim() == "9" || comboBoxMon1.Text.Trim() == "11")
                {
                    comboBoxDay1.Items.Add("1");
                    comboBoxDay1.Items.Add("2");
                    comboBoxDay1.Items.Add("3");
                    comboBoxDay1.Items.Add("4");
                    comboBoxDay1.Items.Add("5");
                    comboBoxDay1.Items.Add("6");
                    comboBoxDay1.Items.Add("7");
                    comboBoxDay1.Items.Add("8");
                    comboBoxDay1.Items.Add("9");
                    comboBoxDay1.Items.Add("10");
                    comboBoxDay1.Items.Add("11");
                    comboBoxDay1.Items.Add("12");
                    comboBoxDay1.Items.Add("13");
                    comboBoxDay1.Items.Add("14");
                    comboBoxDay1.Items.Add("15");
                    comboBoxDay1.Items.Add("16");
                    comboBoxDay1.Items.Add("17");
                    comboBoxDay1.Items.Add("18");
                    comboBoxDay1.Items.Add("19");
                    comboBoxDay1.Items.Add("20");
                    comboBoxDay1.Items.Add("21");
                    comboBoxDay1.Items.Add("22");
                    comboBoxDay1.Items.Add("23");
                    comboBoxDay1.Items.Add("24");
                    comboBoxDay1.Items.Add("25");
                    comboBoxDay1.Items.Add("26");
                    comboBoxDay1.Items.Add("27");
                    comboBoxDay1.Items.Add("28");
                    comboBoxDay1.Items.Add("29");
                    comboBoxDay1.Items.Add("30");
                }
                else
                {
                    string year_str = comboBoxYear1.Text.Trim();
                    int year_int = Convert.ToInt32(year_str);
                    if (year_int % 4 == 0 || (year_int % 100 == 0 && year_int % 400 == 0))
                    {
                        comboBoxDay1.Items.Add("1");
                        comboBoxDay1.Items.Add("2");
                        comboBoxDay1.Items.Add("3");
                        comboBoxDay1.Items.Add("4");
                        comboBoxDay1.Items.Add("5");
                        comboBoxDay1.Items.Add("6");
                        comboBoxDay1.Items.Add("7");
                        comboBoxDay1.Items.Add("8");
                        comboBoxDay1.Items.Add("9");
                        comboBoxDay1.Items.Add("10");
                        comboBoxDay1.Items.Add("11");
                        comboBoxDay1.Items.Add("12");
                        comboBoxDay1.Items.Add("13");
                        comboBoxDay1.Items.Add("14");
                        comboBoxDay1.Items.Add("15");
                        comboBoxDay1.Items.Add("16");
                        comboBoxDay1.Items.Add("17");
                        comboBoxDay1.Items.Add("18");
                        comboBoxDay1.Items.Add("19");
                        comboBoxDay1.Items.Add("20");
                        comboBoxDay1.Items.Add("21");
                        comboBoxDay1.Items.Add("22");
                        comboBoxDay1.Items.Add("23");
                        comboBoxDay1.Items.Add("24");
                        comboBoxDay1.Items.Add("25");
                        comboBoxDay1.Items.Add("26");
                        comboBoxDay1.Items.Add("27");
                        comboBoxDay1.Items.Add("28");
                        comboBoxDay1.Items.Add("29");
                    }
                    else
                    {
                        comboBoxDay1.Items.Add("1");
                        comboBoxDay1.Items.Add("2");
                        comboBoxDay1.Items.Add("3");
                        comboBoxDay1.Items.Add("4");
                        comboBoxDay1.Items.Add("5");
                        comboBoxDay1.Items.Add("6");
                        comboBoxDay1.Items.Add("7");
                        comboBoxDay1.Items.Add("8");
                        comboBoxDay1.Items.Add("9");
                        comboBoxDay1.Items.Add("10");
                        comboBoxDay1.Items.Add("11");
                        comboBoxDay1.Items.Add("12");
                        comboBoxDay1.Items.Add("13");
                        comboBoxDay1.Items.Add("14");
                        comboBoxDay1.Items.Add("15");
                        comboBoxDay1.Items.Add("16");
                        comboBoxDay1.Items.Add("17");
                        comboBoxDay1.Items.Add("18");
                        comboBoxDay1.Items.Add("19");
                        comboBoxDay1.Items.Add("20");
                        comboBoxDay1.Items.Add("21");
                        comboBoxDay1.Items.Add("22");
                        comboBoxDay1.Items.Add("23");
                        comboBoxDay1.Items.Add("24");
                        comboBoxDay1.Items.Add("25");
                        comboBoxDay1.Items.Add("26");
                        comboBoxDay1.Items.Add("27");
                        comboBoxDay1.Items.Add("28");
                    }
                }
            }

        }
        private void comboBoxMon1_SelectedIndexChanged(object sender, EventArgs e)//换月，天数要变换
        {
            comboBoxDay1.Items.Clear();
        }

        private void toolStripButtonMonRpt_Click(object sender, EventArgs e)
        {
            crystalReportViewerMon.ReportSource = null;
            #region  建立用于测试的MyDate表，并且如果查询条件合适，开启子线程

            if (comboBoxYear1.Text.Trim() == "" || comboBoxMon1.Text.Trim() == "")
            {
                MessageBox.Show("请选择年月", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Enabled = true;
            }
            else
            {


                string yr_str = comboBoxYear1.Text.Trim();
                string yr_nian = yr_str + "年";
                int yr_int = Convert.ToInt32(yr_str);
                string mon_str = comboBoxMon1.Text.Trim();
                string mon_yue = mon_str + "月";
                int mon_int = Convert.ToInt32(mon_str);
                if (mon_int < 10)
                    mon_str = "0" + mon_str;
                string totalDate = yr_str.Substring(2, 2) + "-" + mon_str + "-";
                //groupBox1.Enabled = true;
                //查询时间

                if (mon_int == 1 || mon_int == 3 || mon_int == 5 || mon_int == 7 || mon_int == 8 || mon_int == 10 || mon_int == 12)
                {
                    #region  建立用于测试的MyDate表，数据库中没有，以后可加入
                    DataTable mydate_tb = crform_ds.Tables.Add("MyDate");
                    DataColumn col_mydate = mydate_tb.Columns.Add("Year", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("Month", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("Day", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("DateID", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = false;
                    col_mydate = mydate_tb.Columns.Add("TotalBox", Type.GetType("System.Int32"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("TotalWeight", Type.GetType("System.Double"));
                    col_mydate.AllowDBNull = true;
                    DataRow new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "1日";
                    new_row_mydate["DateID"] = totalDate + "01";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "2日";
                    new_row_mydate["DateID"] = totalDate + "02";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "3日";
                    new_row_mydate["DateID"] = totalDate + "03";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "4日";
                    new_row_mydate["DateID"] = totalDate + "04";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "5日";
                    new_row_mydate["DateID"] = totalDate + "05";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "6日";
                    new_row_mydate["DateID"] = totalDate + "06";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "7日";
                    new_row_mydate["DateID"] = totalDate + "07";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "8日";
                    new_row_mydate["DateID"] = totalDate + "08";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "9日";
                    new_row_mydate["DateID"] = totalDate + "09";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "10日";
                    new_row_mydate["DateID"] = totalDate + "10";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "11日";
                    new_row_mydate["DateID"] = totalDate + "11";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "12日";
                    new_row_mydate["DateID"] = totalDate + "12";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "13日";
                    new_row_mydate["DateID"] = totalDate + "13";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "14日";
                    new_row_mydate["DateID"] = totalDate + "14";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "15日";
                    new_row_mydate["DateID"] = totalDate + "15";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "16日";
                    new_row_mydate["DateID"] = totalDate + "16";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "17日";
                    new_row_mydate["DateID"] = totalDate + "17";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "18日";
                    new_row_mydate["DateID"] = totalDate + "18";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "19日";
                    new_row_mydate["DateID"] = totalDate + "19";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "20日";
                    new_row_mydate["DateID"] = totalDate + "20";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "21日";
                    new_row_mydate["DateID"] = totalDate + "21";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "22日";
                    new_row_mydate["DateID"] = totalDate + "22";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "23日";
                    new_row_mydate["DateID"] = totalDate + "23";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "24日";
                    new_row_mydate["DateID"] = totalDate + "24";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "25日";
                    new_row_mydate["DateID"] = totalDate + "25";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "26日";
                    new_row_mydate["DateID"] = totalDate + "26";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "27日";
                    new_row_mydate["DateID"] = totalDate + "27";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "28日";
                    new_row_mydate["DateID"] = totalDate + "28";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "29日";
                    new_row_mydate["DateID"] = totalDate + "29";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "30日";
                    new_row_mydate["DateID"] = totalDate + "30";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "31日";
                    new_row_mydate["DateID"] = totalDate + "31";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);

                    #endregion
                }
                else if (mon_int == 4 || mon_int == 6 || mon_int == 9 || mon_int == 11)
                {
                    #region  建立用于测试的MyDate表，数据库中没有，以后可加入
                    DataTable mydate_tb = crform_ds.Tables.Add("MyDate");
                    DataColumn col_mydate = mydate_tb.Columns.Add("Year", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("Month", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("Day", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("DateID", Type.GetType("System.String"));
                    col_mydate.AllowDBNull = false;
                    col_mydate = mydate_tb.Columns.Add("TotalBox", Type.GetType("System.Int32"));
                    col_mydate.AllowDBNull = true;
                    col_mydate = mydate_tb.Columns.Add("TotalWeight", Type.GetType("System.Double"));
                    col_mydate.AllowDBNull = true;
                    DataRow new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "1日";
                    new_row_mydate["DateID"] = totalDate + "01";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "2日";
                    new_row_mydate["DateID"] = totalDate + "02";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "3日";
                    new_row_mydate["DateID"] = totalDate + "03";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "4日";
                    new_row_mydate["DateID"] = totalDate + "04";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "5日";
                    new_row_mydate["DateID"] = totalDate + "05";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "6日";
                    new_row_mydate["DateID"] = totalDate + "06";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "7日";
                    new_row_mydate["DateID"] = totalDate + "07";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "8日";
                    new_row_mydate["DateID"] = totalDate + "08";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "9日";
                    new_row_mydate["DateID"] = totalDate + "09";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "10日";
                    new_row_mydate["DateID"] = totalDate + "10";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "11日";
                    new_row_mydate["DateID"] = totalDate + "11";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "12日";
                    new_row_mydate["DateID"] = totalDate + "12";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "13日";
                    new_row_mydate["DateID"] = totalDate + "13";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "14日";
                    new_row_mydate["DateID"] = totalDate + "14";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "15日";
                    new_row_mydate["DateID"] = totalDate + "15";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "16日";
                    new_row_mydate["DateID"] = totalDate + "16";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "17日";
                    new_row_mydate["DateID"] = totalDate + "17";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "18日";
                    new_row_mydate["DateID"] = totalDate + "18";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "19日";
                    new_row_mydate["DateID"] = totalDate + "19";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "20日";
                    new_row_mydate["DateID"] = totalDate + "20";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "21日";
                    new_row_mydate["DateID"] = totalDate + "21";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "22日";
                    new_row_mydate["DateID"] = totalDate + "22";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "23日";
                    new_row_mydate["DateID"] = totalDate + "23";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "24日";
                    new_row_mydate["DateID"] = totalDate + "24";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "25日";
                    new_row_mydate["DateID"] = totalDate + "25";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "26日";
                    new_row_mydate["DateID"] = totalDate + "26";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "27日";
                    new_row_mydate["DateID"] = totalDate + "27";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "28日";
                    new_row_mydate["DateID"] = totalDate + "28";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "29日";
                    new_row_mydate["DateID"] = totalDate + "29";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                    new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                    new_row_mydate["Year"] = yr_nian;
                    new_row_mydate["Month"] = mon_yue;
                    new_row_mydate["Day"] = "30日";
                    new_row_mydate["DateID"] = totalDate + "30";
                    crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);

                    #endregion
                }
                else
                {
                    if (yr_int % 4 == 0)
                    {
                        #region  建立用于测试的MyDate表，数据库中没有，以后可加入
                        DataTable mydate_tb = crform_ds.Tables.Add("MyDate");
                        DataColumn col_mydate = mydate_tb.Columns.Add("Year", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("Month", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("Day", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("DateID", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = false;
                        col_mydate = mydate_tb.Columns.Add("TotalBox", Type.GetType("System.Int32"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("TotalWeight", Type.GetType("System.Double"));
                        col_mydate.AllowDBNull = true;
                        DataRow new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "1日";
                        new_row_mydate["DateID"] = totalDate + "01";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "2日";
                        new_row_mydate["DateID"] = totalDate + "02";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "3日";
                        new_row_mydate["DateID"] = totalDate + "03";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "4日";
                        new_row_mydate["DateID"] = totalDate + "04";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "5日";
                        new_row_mydate["DateID"] = totalDate + "05";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "6日";
                        new_row_mydate["DateID"] = totalDate + "06";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "7日";
                        new_row_mydate["DateID"] = totalDate + "07";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "8日";
                        new_row_mydate["DateID"] = totalDate + "08";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "9日";
                        new_row_mydate["DateID"] = totalDate + "09";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "10日";
                        new_row_mydate["DateID"] = totalDate + "10";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "11日";
                        new_row_mydate["DateID"] = totalDate + "11";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "12日";
                        new_row_mydate["DateID"] = totalDate + "12";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "13日";
                        new_row_mydate["DateID"] = totalDate + "13";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "14日";
                        new_row_mydate["DateID"] = totalDate + "14";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "15日";
                        new_row_mydate["DateID"] = totalDate + "15";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "16日";
                        new_row_mydate["DateID"] = totalDate + "16";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "17日";
                        new_row_mydate["DateID"] = totalDate + "17";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "18日";
                        new_row_mydate["DateID"] = totalDate + "18";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "19日";
                        new_row_mydate["DateID"] = totalDate + "19";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "20日";
                        new_row_mydate["DateID"] = totalDate + "20";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "21日";
                        new_row_mydate["DateID"] = totalDate + "21";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "22日";
                        new_row_mydate["DateID"] = totalDate + "22";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "23日";
                        new_row_mydate["DateID"] = totalDate + "23";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "24日";
                        new_row_mydate["DateID"] = totalDate + "24";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "25日";
                        new_row_mydate["DateID"] = totalDate + "25";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "26日";
                        new_row_mydate["DateID"] = totalDate + "26";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "27日";
                        new_row_mydate["DateID"] = totalDate + "27";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "28日";
                        new_row_mydate["DateID"] = totalDate + "28";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "29日";
                        new_row_mydate["DateID"] = totalDate + "29";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);

                        #endregion
                    }

                    else
                    {
                        #region  建立用于测试的MyDate表，数据库中没有，以后可加入
                        DataTable mydate_tb = crform_ds.Tables.Add("MyDate");
                        DataColumn col_mydate = mydate_tb.Columns.Add("Year", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("Month", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("Day", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("DateID", Type.GetType("System.String"));
                        col_mydate.AllowDBNull = false;
                        col_mydate = mydate_tb.Columns.Add("TotalBox", Type.GetType("System.Int32"));
                        col_mydate.AllowDBNull = true;
                        col_mydate = mydate_tb.Columns.Add("TotalWeight", Type.GetType("System.Double"));
                        col_mydate.AllowDBNull = true;
                        DataRow new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "1日";
                        new_row_mydate["DateID"] = totalDate + "01";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "2日";
                        new_row_mydate["DateID"] = totalDate + "02";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "3日";
                        new_row_mydate["DateID"] = totalDate + "03";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "4日";
                        new_row_mydate["DateID"] = totalDate + "04";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "5日";
                        new_row_mydate["DateID"] = totalDate + "05";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "6日";
                        new_row_mydate["DateID"] = totalDate + "06";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "7日";
                        new_row_mydate["DateID"] = totalDate + "07";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "8日";
                        new_row_mydate["DateID"] = totalDate + "08";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "9日";
                        new_row_mydate["DateID"] = totalDate + "09";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "10日";
                        new_row_mydate["DateID"] = totalDate + "10";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "11日";
                        new_row_mydate["DateID"] = totalDate + "11";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "12日";
                        new_row_mydate["DateID"] = totalDate + "12";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "13日";
                        new_row_mydate["DateID"] = totalDate + "13";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "14日";
                        new_row_mydate["DateID"] = totalDate + "14";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "15日";
                        new_row_mydate["DateID"] = totalDate + "15";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "16日";
                        new_row_mydate["DateID"] = totalDate + "16";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "17日";
                        new_row_mydate["DateID"] = totalDate + "17";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "18日";
                        new_row_mydate["DateID"] = totalDate + "18";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "19日";
                        new_row_mydate["DateID"] = totalDate + "19";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "20日";
                        new_row_mydate["DateID"] = totalDate + "20";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "21日";
                        new_row_mydate["DateID"] = totalDate + "21";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "22日";
                        new_row_mydate["DateID"] = totalDate + "22";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "23日";
                        new_row_mydate["DateID"] = totalDate + "23";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "24日";
                        new_row_mydate["DateID"] = totalDate + "24";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "25日";
                        new_row_mydate["DateID"] = totalDate + "25";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "26日";
                        new_row_mydate["DateID"] = totalDate + "26";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "27日";
                        new_row_mydate["DateID"] = totalDate + "27";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);
                        new_row_mydate = crform_ds.Tables["MyDate"].NewRow();
                        new_row_mydate["Year"] = yr_nian;
                        new_row_mydate["Month"] = mon_yue;
                        new_row_mydate["Day"] = "28日";
                        new_row_mydate["DateID"] = totalDate + "28";
                        crform_ds.Tables["MyDate"].Rows.Add(new_row_mydate);

                        #endregion
                    }
                }

                flag_mon = false;
                timerMon1.Start();
                System.Threading.Thread myThread = new System.Threading.Thread(new System.Threading.ThreadStart(CheckConfig));
                myThread.Start();

            }
            # endregion
        }
        private void CheckConfig()//生成月表子线程
        {
            this.Enabled = false;
            //this.Update();
            //this.Refresh();
            // this.loadFiles();
            //label5.Text = "正在处理...";
            //progressBar1.Visible = true;
            //progressBar1.Value = 0;
            //new System.Threading.Thread(new System.Threading.ThreadStart(StartDownload)).Start();
            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程
            //fThread.Start();

            progressBarMon.Visible = true;
            progressBarMon.Value = 0;
            progressBarMon.Update();
            labelProgMon.Text = "";
            labelProgMon.Update();
            //this.Enabled = false;
            //Form1 waitingform = new Form1();
            //waitingform.ShowDialog(this);




            crform_ds.Tables["Result"].Clear();


            string yr_str = comboBoxYear1.Text.Trim();
            int yr_int = Convert.ToInt32(yr_str);
            string mon_str = comboBoxMon1.Text.Trim();
            int mon_int = Convert.ToInt32(mon_str);
            if (mon_int < 10)
                mon_str = "0" + mon_str;
            groupBoxReport.Enabled = true;
            //查询时间
            int cur_month_days;
            if (mon_int == 1 || mon_int == 3 || mon_int == 5 || mon_int == 7 || mon_int == 8 || mon_int == 10 || mon_int == 12)
            {

                cur_month_days = 31;
            }
            else if (mon_int == 4 || mon_int == 6 || mon_int == 9 || mon_int == 11)
            {

                cur_month_days = 30;
            }
            else
            {
                if (yr_int % 4 == 0)
                {

                    cur_month_days = 29;
                }

                else
                {

                    cur_month_days = 28;
                }
            }
            //ts1 = Process.GetCurrentProcess().TotalProcessorTime;//测试cpu时间
            //string month_first_day = new DateTime(yr_int, mon_int, 1, 0, 0, 0).ToString().Substring(2, 8);////要查询的月的第一天，10-01-01，这里月份用1月，以后用 System.DateTime.Now.Month，下一行同样
            //DateTime next_month_first_day = new DateTime(yr_int, mon_int + 1, 1, 0, 0, 0);
            //next_month_first_day = next_month_first_day.AddDays(-1);//得到要查询月最后一天
            //int second_pos = next_month_first_day.ToString().LastIndexOf("/");
            //int cur_month_days = int.Parse(next_month_first_day.ToString().Substring(second_pos + 1, 2));//当前月的天数
            string cur_month_days_str = cur_month_days.ToString();

            //MessageBox.Show(cur_month_days_str, "day", MessageBoxButtons.OK, MessageBoxIcon.None);
            string day_str = "";

            ////string sql_startTime = System.DateTime.Now.Year.ToString().Substring(2, 2) + "-01-" + str_cur_day + ",12:00";


            string sql_startTime = yr_str.Substring(2, 2) + "-" + mon_str + "-";
            ////string sql_goods = "select * from [rfidtest].[dbo.Goods] where StartStationID=" + staID.ToString() + " and StartTime = \'" + sql_startTime + "\'";
            //string sql_goods = "select * from [rfidtest].[dbo.Goods] where StartTime LIKE \'" + sql_startTime + "%\'";

            for (int cur_day = 1; cur_day <= cur_month_days; cur_day++)//2替换cur_month_days。按站分组，每次生成新表的一行
            {

                labelProgMon.Text = "完成  " + progressBarMon.Value.ToString() + "%";
                labelProgMon.Update();
                progressBarMon.Value = Convert.ToInt32(cur_day * 3.15);
                progressBarMon.Update();
                //System.Threading.Thread.Sleep(1);
                //this.Update();
                //this.Refresh();

                int first_line = (cur_day - 1) * 56;//当天在Result表中第一行
                string str_cur_day = cur_day.ToString();
                if (cur_day < 10)
                {
                    day_str = "0" + str_cur_day;
                    str_cur_day = sql_startTime + day_str;
                }
                else
                {
                    day_str = str_cur_day;
                    str_cur_day = sql_startTime + day_str;
                }
                string sql_goods = @"if not exists(select name from sysobjects where name='res' and type='u')
  create table res(staname  varchar(100),sumbox int,weight2 float,weight3 float,weight4 float,weight5 float,weight6 float,weight7 float,weight8 float,weight9 float,weight10 float,weight11 float,weight12 float,weight13 float,weight14 float,weight15 float,sumweight float,sumboxtail float,dateid varchar(100));
else
  begin
  drop table res;
  create table res(staname  varchar(100),sumbox int,weight2 float,weight3 float,weight4 float,weight5 float,weight6 float,weight7 float,weight8 float,weight9 float,weight10 float,weight11 float,weight12 float,weight13 float,weight14 float,weight15 float,sumweight float,sumboxtail float,dateid varchar(100));
  end

declare @tmpweight float;/*每行获取的weight*/
declare @ttlweight float;
declare @col varchar(100);/*weight2-15的列名*/
declare @sqls varchar(1000);
declare @i int;

declare @cur_date varchar(10);
set @cur_date=CONVERT(varchar(10),getDate(),120);/*当前日期*/
declare @q_date varchar(10);
set @q_date='" + yr_str.Substring(2, 2) + "-" + mon_str + "-" + day_str + @"'" + @"

declare @day_str varchar(20);
set @day_str=@q_date+'%';

declare @staid int;
set @staid=31;
while @staid<=85
begin
    declare @stationname varchar(100);
	set @stationname=(select Name from [rfidtest].[dbo.Station] WHERE StationID=@staid);
	declare @date varchar(30);
	set @date=substring(@day_str,1,8);
	declare @boxnum int;
	set @boxnum=(select count(*) from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str GROUP BY StartStationID);
    if @boxnum<>0
	insert into res(staname,sumbox,sumboxtail,dateid) values(@stationname,@boxnum,@boxnum,@date);
    else
    insert into res(staname,sumbox,sumboxtail,dateid) values(@stationname,0,0,@date);
 
    select ID=identity(int,   1,   1), Weight into #t  from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str; 
	/*select   *   from   #t*/
	set @ttlweight=0;
	set @i=1;
	while @i<=@boxnum
	begin
		set @col='weight'+cast(@i+1 as varchar)
		set @tmpweight=(select Weight from #t where ID=@i);
        if @tmpweight is null
        set @tmpweight=0 
		set @ttlweight=@ttlweight+@tmpweight;
		set @sqls='update res set '+@col+'='+cast(@tmpweight as varchar)+' WHERE staname='''+@stationname+''' AND dateid='''+substring(@day_str,1,8)+'''';
		exec(@sqls) 
		set @i=@i+1;
	end
    set @sqls='update res set sumweight='+cast(@ttlweight as varchar)+' WHERE staname='''+@stationname+''' AND dateid='''+substring(@day_str,1,8)+'''';
    exec(@sqls)
    drop table #t;	
    set @staid=@staid+1;
end

select * from res;
drop table res;";
                //MessageBox.Show(sql_goods, "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                ////string sql_starion = "select * from [rfidtest].[dbo.Station] where StationID=" + staID.ToString();
                //string sql_starion = "select * from [rfidtest].[dbo.Station]";


                //SqlCommand cmd = new SqlCommand(sql_goods, sqlcon);
                //sqlcon.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //sqlcon.Close();

                //msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
                //MessageBox.Show(msecs.ToString(), "reader", MessageBoxButtons.OK, MessageBoxIcon.None);

                //ts1 = Process.GetCurrentProcess().TotalProcessorTime;//测试cpu时间

                //两个表连接，并加入到DataSet
                //sqlcon.ConnectionTimeout = 0;


                crform_sqlda = new SqlDataAdapter(sql_goods, sqlcon);

                crform_sqlda.SelectCommand.CommandTimeout = 100000000;
                try
                {
                    crform_sqlda.Fill(crform_ds, "Goods_Table");//得到要查询的月的所有的运输信息，包括所有站。
                }
                catch
                {
                    MessageBox.Show("不能生成报表！\n单日箱数超过15箱，请检查数据真实性！");
                    this.Enabled = true;
                    progressBarMon.Visible = false;
                    labelProgMon.Text = "";
                    labelProgMon.Update();
                    groupBoxReport.Enabled = false;
                    groupBoxSelect.Enabled = true;
                    dt_goods.Clear();
                    crform_ds.Tables.Remove("MyDate");
                    return;
                }



                //crform_ds.
                //crform_sqlda = new SqlDataAdapter(sql_starion, sqlcon);
                //crform_sqlda.Fill(crform_ds, "Station_Table");//得到所有站信息

                //msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
                //MessageBox.Show(msecs.ToString(), "fill", MessageBoxButtons.OK, MessageBoxIcon.None);

                //ts1 = Process.GetCurrentProcess().TotalProcessorTime;//测试cpu时间


                DataRow new_row = crform_ds.Tables["Result"].NewRow();
                //DataTable dt_goods = crform_ds.Tables["Goods_Table"];
                foreach (DataRow row in dt_goods.Rows)
                {
                    if (row["DateID"].ToString() == str_cur_day)
                    {
                        //new_row["StaName"] = row["staname"].ToString();
                        //new_row["DateID"] = row["dateid"].ToString().Substring(0, 8);
                        new_row = row;
                        crform_ds.Tables["Result"].Rows.Add(new_row.ItemArray);
                    }
                }
                DataTable tb_result = crform_ds.Tables["Result"];
                DataRow total_row = tb_result.NewRow();
                total_row["StaName"] = "合计";

                int total_box = 0;
                for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                    total_box += Convert.ToInt32(tb_result.Rows[line_tb_result][1].ToString());
                total_row["SumBox"] = total_box;

                //DataTableSQL查询后得到DateSet中的第一个表Goods_Table，处理每天的箱数和重量
                for (int col_num = 2; col_num <= 16; col_num++)
                {
                    double total_col_weight = 0;
                    for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                    {
                        string weight_str = tb_result.Rows[line_tb_result][col_num].ToString();
                        if (weight_str != "")
                            total_col_weight += Convert.ToDouble(weight_str);

                    }
                    ///////////if (total_col_weight != 0)//0不显示
                    total_row[col_num] = total_col_weight;

                }
                total_row["SumBoxTail"] = total_box;
                total_row["DateID"] = crform_ds.Tables["Result"].Rows[crform_ds.Tables["Result"].Rows.Count - 1]["DateID"].ToString();
                DataRow mdRow = crform_ds.Tables["MyDate"].Rows[cur_day - 1];
                mdRow["TotalBox"] = total_box;
                mdRow["TotalWeight"] = total_row["SumWeight"];
                crform_ds.Tables["Result"].Rows.Add(total_row);



            }
            //msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
            //MessageBox.Show(msecs.ToString(), "process", MessageBoxButtons.OK, MessageBoxIcon.None);

           flag_mon = true;


        }
        private void timerMon1_Tick_1(object sender, EventArgs e)
        {
            if (flag_mon == true)
            {
                timerMon1.Stop();
                //MessageBox.Show("请选择年月日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                dataGridViewMon.DataSource = crform_ds.Tables["Result"];
                dataGridViewMon.Visible = false;
                //报表对象，绑定报表文件

                //string crPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                //     Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
                string crPath = "CrystalReport3.rpt";
                //crDocument.Refresh();
                ReportDocument crDocument = new ReportDocument();
                crDocument.Load(crPath);
                //绑定数据集，注意，一个报表用一个数据集。
                crDocument.SetDataSource(crform_ds);

                //在Viewer中呈现
                crystalReportViewerMon.ReportSource = crDocument;
                // MessageBox.Show("请选择年", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                dt_goods.Clear();
                toolStripButtonMonExl.Enabled = true;
                progressBarMon.Value = progressBarMon.Maximum;
                progressBarMon.Update();
                labelProgMon.Text = "已完成";
                labelProgMon.Update();
                //MessageBox.Show("请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Enabled = true;
                flag_mon = false;
                crform_ds.Tables.Remove("MyDate");


            }

        }

        private void toolStripButtonDayRpt_Click(object sender, EventArgs e)
        {
            crystalReportViewerMon.ReportSource = null;
            //label5.Text = "正在处理...";
            //progressBar1.Visible = true;
            //progressBar1.Value = 0;

            //Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程

            flag_day = false;
            timerMon2.Start();
            System.Threading.Thread myThread = new System.Threading.Thread(new System.Threading.ThreadStart(DayReport));
            myThread.Start();
        }
        private void DayReport()//生成日表子线程
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            if (comboBoxYear1.Text.Trim() == "" || comboBoxMon1.Text.Trim() == "" || comboBoxDay1.Text.Trim() == "")
            {
                MessageBox.Show("请选择年月日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                //Form1 waitingform = new Form1();
                //waitingform.ShowDialog(this);

                //new System.Threading.Thread(new System.Threading.ThreadStart(StartDownload)).Start();
                this.Enabled = false;
                progressBarMon.Visible = true;
                progressBarMon.Value = 0;
                progressBarMon.Update();
                labelProgMon.Text = "";
                labelProgMon.Update();

                progressBarMon.Value = 15;
                progressBarMon.Update();
                labelProgMon.Text = "处理中...";
                labelProgMon.Update();

                crform_ds.Tables["Result"].Clear();
                groupBoxReport.Enabled = true;
                string yr_str = comboBoxYear1.Text.Trim();
                int yr_int = Convert.ToInt32(yr_str);
                string mon_str = comboBoxMon1.Text.Trim();
                int mon_int = Convert.ToInt32(mon_str);
                if (mon_int < 10)
                    mon_str = "0" + mon_str;
                string day_str = comboBoxDay1.Text.Trim();
                int day_int = Convert.ToInt32(day_str);
                if (day_int < 10)
                    day_str = "0" + day_str;
                //查询时间
                //ts1 = Process.GetCurrentProcess().TotalProcessorTime;//测试cpu时间
                string month_first_day = new DateTime(yr_int, mon_int, 1, 0, 0, 0).ToString().Substring(2, 8);////要查询的月的第一天，10-01-01，这里月份用1月，以后用 System.DateTime.Now.Month，下一行同样
                DateTime next_month_first_day = new DateTime(yr_int, mon_int + 1, 1, 0, 0, 0);
                next_month_first_day = next_month_first_day.AddDays(-1);//得到要查询月最后一天
                int second_pos = next_month_first_day.ToString().LastIndexOf("/");
                int cur_month_days = int.Parse(next_month_first_day.ToString().Substring(second_pos + 1, 2));//当前月的天数
                string cur_month_days_str = cur_month_days.ToString();

                ////string sql_startTime = System.DateTime.Now.Year.ToString().Substring(2, 2) + "-01-" + str_cur_day + ",12:00";


                string sql_startTime = yr_str.Substring(2, 2) + "-" + mon_str + "-";
                ////string sql_goods = "select * from [rfidtest].[dbo.Goods] where StartStationID=" + staID.ToString() + " and StartTime = \'" + sql_startTime + "\'";
                //string sql_goods = "select * from [rfidtest].[dbo.Goods] where StartTime LIKE \'" + sql_startTime + "%\'";
                string sql_goods = @"if not exists(select name from sysobjects where name='res' and type='u')
  create table res(staname  varchar(100),sumbox int,weight2 float,weight3 float,weight4 float,weight5 float,weight6 float,weight7 float,weight8 float,weight9 float,weight10 float,weight11 float,weight12 float,weight13 float,weight14 float,weight15 float,sumweight float,sumboxtail float,dateid varchar(100));
else
  begin
  drop table res;
  create table res(staname  varchar(100),sumbox int,weight2 float,weight3 float,weight4 float,weight5 float,weight6 float,weight7 float,weight8 float,weight9 float,weight10 float,weight11 float,weight12 float,weight13 float,weight14 float,weight15 float,sumweight float,sumboxtail float,dateid varchar(100));
  end

                    declare @tmpweight float;/*每行获取的weight*/
                    declare @ttlweight float;
                    declare @col varchar(100);/*weight2-15的列名*/
                    declare @sqls varchar(1000);
                    declare @i int;

                    declare @cur_date varchar(10);
                    set @cur_date=CONVERT(varchar(10),getDate(),120);/*当前日期*/
                    declare @q_date varchar(10);
                    set @q_date='" + yr_str.Substring(2, 2) + "-" + mon_str + "-" + day_str + @"'" + @"

                    declare @day_str varchar(20);
                    set @day_str=@q_date+'%';

                    declare @staid int;
                    set @staid=31;
                    while @staid<=85
                    begin
                        declare @stationname varchar(100);
	                    set @stationname=(select Name from [rfidtest].[dbo.Station] WHERE StationID=@staid);
	                    declare @date varchar(30);
	                    set @date=substring(@day_str,1,8);
	                    declare @boxnum int;
	                    set @boxnum=(select count(*) from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str GROUP BY StartStationID);
                        if @boxnum<>0
	                    insert into res(staname,sumbox,sumboxtail,dateid) values(@stationname,@boxnum,@boxnum,@date);
                        else
                        insert into res(staname,sumbox,sumboxtail,dateid) values(@stationname,0,0,@date);
                     
                        select ID=identity(int,   1,   1), Weight into #t  from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str; 
	                    /*select   *   from   #t*/
	                    set @ttlweight=0;
	                    set @i=1;
	                    while @i<=@boxnum
	                    begin
		                    set @col='weight'+cast(@i+1 as varchar)
		                    set @tmpweight=(select Weight from #t where ID=@i);
                            if @tmpweight is null
                            set @tmpweight=0 
		                    set @ttlweight=@ttlweight+@tmpweight;
		                    set @sqls='update res set '+@col+'='+cast(@tmpweight as varchar)+' WHERE staname='''+@stationname+''' AND dateid='''+substring(@day_str,1,8)+'''';
		                    exec(@sqls) 
		                    set @i=@i+1;
	                    end
                        set @sqls='update res set sumweight='+cast(@ttlweight as varchar)+' WHERE staname='''+@stationname+''' AND dateid='''+substring(@day_str,1,8)+'''';
                        exec(@sqls)
                        drop table #t;	
                        set @staid=@staid+1;
                    end

                    select * from res;
                    drop table res;";
                //MessageBox.Show(sql_goods, "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                ////string sql_starion = "select * from [rfidtest].[dbo.Station] where StationID=" + staID.ToString();
                //string sql_starion = "select * from [rfidtest].[dbo.Station]";


                //SqlCommand cmd = new SqlCommand(sql_goods, sqlcon);
                //sqlcon.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //sqlcon.Close();

                //msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
                //MessageBox.Show(msecs.ToString(), "reader", MessageBoxButtons.OK, MessageBoxIcon.None);

                //ts1 = Process.GetCurrentProcess().TotalProcessorTime;//测试cpu时间

                //两个表连接，并加入到DataSet

                //sqlcon.ConnectionTimeout = 0;
                crform_sqlda = new SqlDataAdapter(sql_goods, sqlcon);
                crform_sqlda.SelectCommand.CommandTimeout = 100000000;
                try
                {
                    crform_sqlda.Fill(crform_ds, "Goods_table");//得到要查询的月的所有的运输信息，包括所有站。
                }
                catch
                {
                    MessageBox.Show("不能生成报表！\n单日箱数超过15箱，请检查数据真实性！");
                    this.Enabled = true;
                    progressBarMon.Visible = false;
                    labelProgMon.Text = "";
                    labelProgMon.Update();
                    groupBoxReport.Enabled = false;
                    groupBoxSelect.Enabled = true;
                    dt_goods.Clear();
                    return;

                }
                progressBarMon.Value = 70;
                progressBarMon.Update();
                labelProgMon.Text = "处理中...";
                labelProgMon.Update();
                this.Update();

                //crform_sqlda = new SqlDataAdapter(sql_starion, sqlcon);
                //crform_sqlda.Fill(crform_ds, "Station_Table");//得到所有站信息

                //msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
                //MessageBox.Show(msecs.ToString(), "fill", MessageBoxButtons.OK, MessageBoxIcon.None);

                //ts1 = Process.GetCurrentProcess().TotalProcessorTime;//测试cpu时间

                int first_line = 0;//当天在Result表中第一行
                string str_cur_day = day_int.ToString();
                if (day_int < 10)
                    str_cur_day = sql_startTime + "0" + str_cur_day;
                else
                    str_cur_day = sql_startTime + str_cur_day;
                DataRow new_row = crform_ds.Tables["Result"].NewRow();
                //DataTable dt_goods = crform_ds.Tables["Goods_Table"];
                foreach (DataRow row in dt_goods.Rows)
                {
                    if (row["DateID"].ToString() == str_cur_day)
                    {
                        //new_row["StaName"] = row["staname"].ToString();
                        //new_row["DateID"] = row["dateid"].ToString().Substring(0, 8);
                        new_row = row;
                        crform_ds.Tables["Result"].Rows.Add(new_row.ItemArray);
                    }
                }
                DataTable tb_result = crform_ds.Tables["Result"];
                DataRow total_row = tb_result.NewRow();
                total_row["StaName"] = "合计";

                int total_box = 0;
                for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                    total_box += Convert.ToInt32(tb_result.Rows[line_tb_result][1].ToString());
                total_row["SumBox"] = total_box;


                //DataTableSQL查询后得到DateSet中的第一个表Goods_Table，处理每天的箱数和重量
                for (int col_num = 2; col_num <= 16; col_num++)
                {
                    double total_col_weight = 0;
                    for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                    {
                        string weight_str = tb_result.Rows[line_tb_result][col_num].ToString();
                        if (weight_str != "")
                            total_col_weight += Convert.ToDouble(weight_str);

                    }
                    /////////if (total_col_weight != 0)//0不显示
                    total_row[col_num] = total_col_weight;

                }
                total_row["SumBoxTail"] = total_box;
                total_row["DateID"] = crform_ds.Tables["Result"].Rows[crform_ds.Tables["Result"].Rows.Count - 1]["DateID"].ToString();
                crform_ds.Tables["Result"].Rows.Add(total_row);
                //msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
                //MessageBox.Show(msecs.ToString(), "process", MessageBoxButtons.OK, MessageBoxIcon.None);

                
                flag_day = true;
            }
        }
        private void timerMon2_Tick(object sender, EventArgs e)
        {

            if (flag_day == true)
            {
                timerMon2.Stop();
                //MessageBox.Show("请选择年月日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                dataGridViewMon.DataSource = crform_ds.Tables["Result"];

                dataGridViewMon.Visible = false;
                //报表对象，绑定报表文件

                //string crPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                //     Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
                string crPath = "CrystalReport2.rpt";
                //crDocument.Refresh();
                ReportDocument crDocument = new ReportDocument();
                crDocument.Load(crPath);
                //绑定数据集，注意，一个报表用一个数据集。
                crDocument.SetDataSource(crform_ds);

                //在Viewer中呈现
                crystalReportViewerMon.ReportSource = crDocument;
                // MessageBox.Show("请选择年", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                dt_goods.Clear();
                toolStripButtonMonExl.Enabled = true;
                progressBarMon.Value = progressBarMon.Maximum;
                progressBarMon.Update();
                labelProgMon.Text = "已完成";
                labelProgMon.Update();
                //MessageBox.Show("请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Enabled = true;
                flag_day = false;


            }
        }

        private void toolStripButtonMonExl_Click(object sender, EventArgs e)
        {
            try
            {

                this.Enabled = false;
                progressBarMon.Visible = true;
                progressBarMon.Value = 0;
                progressBarMon.Update();
                labelProgMon.Text = "";
                labelProgMon.Update();
                flag_exl = false;
                timerMon3.Start();
                System.Threading.Thread myThread = new System.Threading.Thread(new System.Threading.ThreadStart(GenExcel));
                myThread.Start();



            }
            catch
            {
                MessageBox.Show("导出错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void GenExcel()//导出EXCEL子线程
        {
            //MessageBox.Show("11", "process", MessageBoxButtons.OK, MessageBoxIcon.None);
            flag_exl = true;

        }
        private void timerMon3_Tick(object sender, EventArgs e)
        {
            if (flag_exl == true)
            {
                timerMon3.Stop();
                ExportExcel(dataGridViewMon);
                this.Enabled = true;
                flag_exl = false;


            }
        }
        private void ExportExcel(DataGridView dgv)
        {
            try
            {
                //MessageBox.Show("22", "process", MessageBoxButtons.OK, MessageBoxIcon.None);
                if (dgv.Rows.Count >= 1)
                {
                    labelProgMon.Text = "开始导出";
                    labelProgMon.Update();
                    //MessageBox.Show("33", "process", MessageBoxButtons.OK, MessageBoxIcon.None);
                    string yr_str = comboBoxYear1.Text.Trim();
                    string mon_str = comboBoxMon1.Text.Trim();
                    string day_str = comboBoxDay1.Text.Trim();
                    string fName = "";
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = "d:";
                    saveFileDialog.Filter = "EXCEL文件|*.xlsx";
                    saveFileDialog.FilterIndex = 2;
                    if (day_str == "")
                    {
                        saveFileDialog.FileName = yr_str + "年" + mon_str + "月清运垃圾明细表";
                    }
                    else
                    {
                        saveFileDialog.FileName = yr_str + "年" + mon_str + "月" + day_str + "日清运垃圾明细表";
                    }
                    saveFileDialog.RestoreDirectory = true;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fName = saveFileDialog.FileName;
                        //MessageBox.Show("44", "process", MessageBoxButtons.OK, MessageBoxIcon.None);
                        progressBarMon.Value = 12;
                        progressBarMon.Update();


                        this.Refresh();
                        //建立Excel对象 
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbooks wbs = excel.Workbooks;// new Microsoft.Office.Interop.Excel.Workbooks();
                        Microsoft.Office.Interop.Excel.Workbook wb = wbs.Add(true);// new Microsoft.Office.Interop.Excel.Workbook   
                        Microsoft.Office.Interop.Excel.Worksheet ws;
                        //MessageBox.Show("355", "process", MessageBoxButtons.OK, MessageBoxIcon.None);
                        int num_sheet = dgv.Rows.Count / 55;
                        labelProgMon.Text = "完成  " + progressBarMon.Value.ToString() + "%";
                        labelProgMon.Update();
                        //MessageBox.Show(num_sheet.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                        for (int cur_sheet = 1; cur_sheet <= num_sheet; cur_sheet++)
                        {
                            if (num_sheet != 1)
                            {
                                progressBarMon.Value = Convert.ToInt32(12 + cur_sheet * 87 / num_sheet);
                                progressBarMon.Update();
                                //label5.Text = "完成  " + progressBar1.Value.ToString() + "%";
                                //label5.Update();
                            }
                            else
                            {
                                progressBarMon.Value = 50;
                                progressBarMon.Update();
                                //label5.Text = "完成  " + progressBar1.Value.ToString() + "%";
                                //label5.Update();
                            }
                            if (cur_sheet == 1)
                                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets["Sheet1"];
                            else
                                ws = wb.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing) as Microsoft.Office.Interop.Excel.Worksheet;
                            ws.Name = cur_sheet.ToString();
                            //生成字段名称 
                            excel.Cells[1, 1] = "      日期\n名称";
                            excel.Cells[1, 2] = "1";
                            excel.Cells[1, 3] = "2";
                            excel.Cells[1, 4] = "3";
                            excel.Cells[1, 5] = "4";
                            excel.Cells[1, 6] = "5";
                            excel.Cells[1, 7] = "6";
                            excel.Cells[1, 8] = "7";
                            excel.Cells[1, 9] = "8";
                            excel.Cells[1, 10] = "9";
                            excel.Cells[1, 11] = "10";
                            excel.Cells[1, 12] = "11";
                            excel.Cells[1, 13] = "12";
                            excel.Cells[1, 14] = "13";
                            excel.Cells[1, 15] = "14";
                            excel.Cells[1, 16] = "15";
                            excel.Cells[1, 17] = "合计";
                            excel.Cells[1, 18] = "";
                            excel.Cells[2, 1] = "";
                            excel.Cells[2, 2] = "箱数";
                            excel.Cells[2, 3] = "吨数";
                            excel.Cells[2, 4] = "吨数";
                            excel.Cells[2, 5] = "吨数";
                            excel.Cells[2, 6] = "吨数";
                            excel.Cells[2, 7] = "吨数";
                            excel.Cells[2, 8] = "吨数";
                            excel.Cells[2, 9] = "吨数";
                            excel.Cells[2, 10] = "吨数";
                            excel.Cells[2, 11] = "吨数";
                            excel.Cells[2, 12] = "吨数";
                            excel.Cells[2, 13] = "吨数";
                            excel.Cells[2, 14] = "吨数";
                            excel.Cells[2, 15] = "吨数";
                            excel.Cells[2, 16] = "吨数";
                            excel.Cells[2, 17] = "吨数";
                            excel.Cells[2, 18] = "总箱数";
                            Microsoft.Office.Interop.Excel.Range merge_range = excel.get_Range(excel.Cells[1, 17], excel.Cells[1, 18]);
                            merge_range.Merge(Type.Missing);
                            Microsoft.Office.Interop.Excel.Range merge_range2 = excel.get_Range(excel.Cells[1, 1], excel.Cells[2, 1]);
                            merge_range2.Merge(Type.Missing);

                            //填充数据 
                            for (int i = (cur_sheet - 1) * 56 + 1; i < (cur_sheet - 1) * 56 + 57; i++)
                            {
                                for (int j = 0; j < dgv.ColumnCount - 1; j++)
                                {
                                    if (dgv[j, i - 1].Value != null)
                                    {
                                        excel.Cells[i - (cur_sheet - 1) * 56 + 2, j + 1] = dgv[j, i - 1].Value;
                                    }
                                    else
                                        excel.Cells[i - (cur_sheet - 1) * 56 + 2, j + 1] = "";
                                }
                            }

                            Microsoft.Office.Interop.Excel.Range all_range = excel.get_Range(excel.Cells[1, 1], excel.Cells[58, 18]);//现有的
                            all_range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            Microsoft.Office.Interop.Excel.Range c11_range = excel.get_Range(excel.Cells[1, 1], excel.Cells[1, 1]);
                            c11_range.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                            all_range.EntireColumn.AutoFit();     //自动调整列宽
                            all_range.EntireRow.AutoFit();
                            all_range.Borders.LineStyle = 1;
                            labelProgMon.Text = "完成  " + progressBarMon.Value.ToString() + "%";
                            labelProgMon.Update();
                        }//end for每个sheet                   

                        progressBarMon.Value = progressBarMon.Maximum;
                        progressBarMon.Update();


                        wb.Saved = true;
                        wb.SaveCopyAs(fName); //保存
                        excel.Quit(); //关闭进程
                        labelProgMon.Text = "已完成";
                        labelProgMon.Update();
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                        //label5.Text = "完成";
                        toolStripButtonMonExl.Enabled = false;


                    }
                    else
                    {
                        progressBarMon.Visible = false;
                        progressBarMon.Update();
                        labelProgMon.Text = "";
                        labelProgMon.Update();
                        MessageBox.Show("未导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
            }
            catch (Exception ex)
            {
                progressBarMon.Visible = false;
                progressBarMon.Update();
                labelProgMon.Text = "";
                labelProgMon.Update();
                MessageBox.Show(ex.Message.ToString());
            }


            //*/
        }
        #endregion

        #region 日表
        //TAB17
        private void comboBoxDay2_DropDown(object sender, EventArgs e)
        {
            if (comboBoxYear2.Text.Trim() == "" || comboBoxMon2.Text.Trim() == "")
            {
                MessageBox.Show("请先选择年月，再选择日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                comboBoxDay2.Items.Clear();
                if (comboBoxMon2.Text.Trim() == "1" || comboBoxMon2.Text.Trim() == "3" || comboBoxMon2.Text.Trim() == "5" || comboBoxMon2.Text.Trim() == "7" || comboBoxMon2.Text.Trim() == "8" || comboBoxMon2.Text.Trim() == "10" || comboBoxMon2.Text.Trim() == "12")
                {


                    comboBoxDay2.Items.Add("1");
                    comboBoxDay2.Items.Add("2");
                    comboBoxDay2.Items.Add("3");
                    comboBoxDay2.Items.Add("4");
                    comboBoxDay2.Items.Add("5");
                    comboBoxDay2.Items.Add("6");
                    comboBoxDay2.Items.Add("7");
                    comboBoxDay2.Items.Add("8");
                    comboBoxDay2.Items.Add("9");
                    comboBoxDay2.Items.Add("10");
                    comboBoxDay2.Items.Add("11");
                    comboBoxDay2.Items.Add("12");
                    comboBoxDay2.Items.Add("13");
                    comboBoxDay2.Items.Add("14");
                    comboBoxDay2.Items.Add("15");
                    comboBoxDay2.Items.Add("16");
                    comboBoxDay2.Items.Add("17");
                    comboBoxDay2.Items.Add("18");
                    comboBoxDay2.Items.Add("19");
                    comboBoxDay2.Items.Add("20");
                    comboBoxDay2.Items.Add("21");
                    comboBoxDay2.Items.Add("22");
                    comboBoxDay2.Items.Add("23");
                    comboBoxDay2.Items.Add("24");
                    comboBoxDay2.Items.Add("25");
                    comboBoxDay2.Items.Add("26");
                    comboBoxDay2.Items.Add("27");
                    comboBoxDay2.Items.Add("28");
                    comboBoxDay2.Items.Add("29");
                    comboBoxDay2.Items.Add("30");
                    comboBoxDay2.Items.Add("31");
                }
                else if (comboBoxMon2.Text.Trim() == "4" || comboBoxMon2.Text.Trim() == "6" || comboBoxMon2.Text.Trim() == "9" || comboBoxMon2.Text.Trim() == "11")
                {
                    comboBoxDay2.Items.Add("1");
                    comboBoxDay2.Items.Add("2");
                    comboBoxDay2.Items.Add("3");
                    comboBoxDay2.Items.Add("4");
                    comboBoxDay2.Items.Add("5");
                    comboBoxDay2.Items.Add("6");
                    comboBoxDay2.Items.Add("7");
                    comboBoxDay2.Items.Add("8");
                    comboBoxDay2.Items.Add("9");
                    comboBoxDay2.Items.Add("10");
                    comboBoxDay2.Items.Add("11");
                    comboBoxDay2.Items.Add("12");
                    comboBoxDay2.Items.Add("13");
                    comboBoxDay2.Items.Add("14");
                    comboBoxDay2.Items.Add("15");
                    comboBoxDay2.Items.Add("16");
                    comboBoxDay2.Items.Add("17");
                    comboBoxDay2.Items.Add("18");
                    comboBoxDay2.Items.Add("19");
                    comboBoxDay2.Items.Add("20");
                    comboBoxDay2.Items.Add("21");
                    comboBoxDay2.Items.Add("22");
                    comboBoxDay2.Items.Add("23");
                    comboBoxDay2.Items.Add("24");
                    comboBoxDay2.Items.Add("25");
                    comboBoxDay2.Items.Add("26");
                    comboBoxDay2.Items.Add("27");
                    comboBoxDay2.Items.Add("28");
                    comboBoxDay2.Items.Add("29");
                    comboBoxDay2.Items.Add("30");
                }
                else
                {
                    string year_str = comboBoxYear2.Text.Trim();
                    int year_int = Convert.ToInt32(year_str);
                    if (year_int % 4 == 0 || (year_int % 100 == 0 && year_int % 400 == 0))
                    {
                        comboBoxDay2.Items.Add("1");
                        comboBoxDay2.Items.Add("2");
                        comboBoxDay2.Items.Add("3");
                        comboBoxDay2.Items.Add("4");
                        comboBoxDay2.Items.Add("5");
                        comboBoxDay2.Items.Add("6");
                        comboBoxDay2.Items.Add("7");
                        comboBoxDay2.Items.Add("8");
                        comboBoxDay2.Items.Add("9");
                        comboBoxDay2.Items.Add("10");
                        comboBoxDay2.Items.Add("11");
                        comboBoxDay2.Items.Add("12");
                        comboBoxDay2.Items.Add("13");
                        comboBoxDay2.Items.Add("14");
                        comboBoxDay2.Items.Add("15");
                        comboBoxDay2.Items.Add("16");
                        comboBoxDay2.Items.Add("17");
                        comboBoxDay2.Items.Add("18");
                        comboBoxDay2.Items.Add("19");
                        comboBoxDay2.Items.Add("20");
                        comboBoxDay2.Items.Add("21");
                        comboBoxDay2.Items.Add("22");
                        comboBoxDay2.Items.Add("23");
                        comboBoxDay2.Items.Add("24");
                        comboBoxDay2.Items.Add("25");
                        comboBoxDay2.Items.Add("26");
                        comboBoxDay2.Items.Add("27");
                        comboBoxDay2.Items.Add("28");
                        comboBoxDay2.Items.Add("29");
                    }
                    else
                    {
                        comboBoxDay2.Items.Add("1");
                        comboBoxDay2.Items.Add("2");
                        comboBoxDay2.Items.Add("3");
                        comboBoxDay2.Items.Add("4");
                        comboBoxDay2.Items.Add("5");
                        comboBoxDay2.Items.Add("6");
                        comboBoxDay2.Items.Add("7");
                        comboBoxDay2.Items.Add("8");
                        comboBoxDay2.Items.Add("9");
                        comboBoxDay2.Items.Add("10");
                        comboBoxDay2.Items.Add("11");
                        comboBoxDay2.Items.Add("12");
                        comboBoxDay2.Items.Add("13");
                        comboBoxDay2.Items.Add("14");
                        comboBoxDay2.Items.Add("15");
                        comboBoxDay2.Items.Add("16");
                        comboBoxDay2.Items.Add("17");
                        comboBoxDay2.Items.Add("18");
                        comboBoxDay2.Items.Add("19");
                        comboBoxDay2.Items.Add("20");
                        comboBoxDay2.Items.Add("21");
                        comboBoxDay2.Items.Add("22");
                        comboBoxDay2.Items.Add("23");
                        comboBoxDay2.Items.Add("24");
                        comboBoxDay2.Items.Add("25");
                        comboBoxDay2.Items.Add("26");
                        comboBoxDay2.Items.Add("27");
                        comboBoxDay2.Items.Add("28");
                    }
                }
            }

        }
        private void comboBoxMon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDay2.Items.Clear();
        }

        private void toolStripButtonDayComp_Click(object sender, EventArgs e)
        {
            crystalReportViewerDay.ReportSource = null;
            flag_everyday = false;
            timerMon4.Start();
            System.Threading.Thread myThread = new System.Threading.Thread(new System.Threading.ThreadStart(DayComp));
            myThread.Start();
        }
        private void DayComp()//生成每日完成情况报表子线程
        {
            if (comboBoxYear2.Text.Trim() == "" || comboBoxMon2.Text.Trim() == "" || comboBoxDay2.Text.Trim() == "")
            {
                MessageBox.Show("请选择年月日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                //Form1 waitingform = new Form1();
                //waitingform.ShowDialog(this);

                //new System.Threading.Thread(new System.Threading.ThreadStart(StartDownload)).Start();
                this.Enabled = false;
                progressBarDay.Visible = true;
                progressBarDay.Value = 0;
                progressBarDay.Update();
                labelProgDay.Text = "";
                labelProgDay.Update();

                progressBarDay.Value = 15;
                progressBarDay.Update();
                labelProgDay.Text = "处理中...";
                labelProgDay.Update();

                crform_ds.Tables["Result"].Clear();
                groupBoxReport2.Enabled = true;
                string yr_str = comboBoxYear2.Text.Trim();
                int yr_int = Convert.ToInt32(yr_str);
                string mon_str = comboBoxMon2.Text.Trim();
                int mon_int = Convert.ToInt32(mon_str);
                if (mon_int < 10)
                    mon_str = "0" + mon_str;
                string day_str = comboBoxDay2.Text.Trim();
                int day_int = Convert.ToInt32(day_str);
                if (day_int < 10)
                    day_str = "0" + day_str;

                string month_first_day = new DateTime(yr_int, mon_int, 1, 0, 0, 0).ToString().Substring(2, 8);////要查询的月的第一天，10-01-01，这里月份用1月，以后用 System.DateTime.Now.Month，下一行同样
                DateTime next_month_first_day = new DateTime(yr_int, mon_int + 1, 1, 0, 0, 0);
                next_month_first_day = next_month_first_day.AddDays(-1);//得到要查询月最后一天
                int second_pos = next_month_first_day.ToString().LastIndexOf("/");
                int cur_month_days = int.Parse(next_month_first_day.ToString().Substring(second_pos + 1, 2));//当前月的天数
                string cur_month_days_str = cur_month_days.ToString();

                string sql_startTime = yr_str.Substring(2, 2) + "-" + mon_str + "-";
                string sql_goods = @"if not exists(select name from sysobjects where name='res' and type='u')
  create table res(staname  varchar(100),sumbox int,weight2 float,weight3 float,weight4 float,weight5 float,weight6 float,weight7 float,weight8 float,weight9 float,weight10 float,weight11 float,weight12 float,weight13 float,weight14 float,weight15 float,sumweight float,sumboxtail float,dateid varchar(100));
else
  begin
  drop table res;
  create table res(staname  varchar(100),sumbox int,weight2 float,weight3 float,weight4 float,weight5 float,weight6 float,weight7 float,weight8 float,weight9 float,weight10 float,weight11 float,weight12 float,weight13 float,weight14 float,weight15 float,sumweight float,sumboxtail float,dateid varchar(100));
  end

                    declare @tmpweight float;/*每行获取的weight*/
                    declare @ttlweight float;
                    declare @col varchar(100);/*weight2-15的列名*/
                    declare @sqls varchar(1000);
                    declare @i int;

                    declare @cur_date varchar(10);
                    set @cur_date=CONVERT(varchar(10),getDate(),120);/*当前日期*/
                    declare @q_date varchar(10);
                    set @q_date='" + yr_str.Substring(2, 2) + "-" + mon_str + "-" + day_str + @"'" + @"

                    declare @day_str varchar(20);
                    set @day_str=@q_date+'%';

                    declare @staid int;
                    set @staid=31;
                    while @staid<=85
                    begin
                        declare @stationname varchar(100);
	                    set @stationname=(select Name from [rfidtest].[dbo.Station] WHERE StationID=@staid);
	                    declare @date varchar(30);
	                    set @date=substring(@day_str,1,8);
	                    declare @boxnum int;
	                    set @boxnum=(select count(*) from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str GROUP BY StartStationID);
                        if @boxnum<>0
	                    insert into res(staname,sumbox,sumboxtail,dateid) values(@stationname,@boxnum,@boxnum,@date);
                        else
                        insert into res(staname,sumbox,sumboxtail,dateid) values(@stationname,0,0,@date);
                     
                        select ID=identity(int,   1,   1), Weight into #t  from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str; 
	                    /*select   *   from   #t*/
	                    set @ttlweight=0;
	                    set @i=1;
	                    while @i<=@boxnum
	                    begin
		                    set @col='weight'+cast(@i+1 as varchar)
		                    set @tmpweight=(select Weight from #t where ID=@i);
                            if @tmpweight is null
                            set @tmpweight=0 
		                    set @ttlweight=@ttlweight+@tmpweight;
		                    set @sqls='update res set '+@col+'='+cast(@tmpweight as varchar)+' WHERE staname='''+@stationname+''' AND dateid='''+substring(@day_str,1,8)+'''';
		                    exec(@sqls) 
		                    set @i=@i+1;
	                    end
                        set @sqls='update res set sumweight='+cast(@ttlweight as varchar)+' WHERE staname='''+@stationname+''' AND dateid='''+substring(@day_str,1,8)+'''';
                        exec(@sqls)
                        drop table #t;	
                        set @staid=@staid+1;
                    end

                    select * from res;
                    drop table res;";

                crform_sqlda = new SqlDataAdapter(sql_goods, sqlcon);
                crform_sqlda.SelectCommand.CommandTimeout = 100000000;
                try
                {
                    crform_sqlda.Fill(crform_ds, "Goods_table");//得到要查询的月的所有的运输信息，包括所有站。
                }
                catch
                {
                    MessageBox.Show("不能生成报表！\n单日箱数超过15箱，请检查数据真实性！");
                    this.Enabled = true;
                    progressBarDay.Visible = false;
                    labelProgDay.Text = "";
                    labelProgDay.Update();
                    groupBoxReport2.Enabled = false;
                    groupBoxSelect2.Enabled = true;
                    dt_goods.Clear();
                    return;

                }
                progressBarDay.Value = 60;
                progressBarDay.Update();
                labelProgDay.Text = "处理中...";
                labelProgDay.Update();
                this.Update();


                int first_line = 0;//当天在Result表中第一行
                string str_cur_day = day_int.ToString();
                if (day_int < 10)
                    str_cur_day = sql_startTime + "0" + str_cur_day;
                else
                    str_cur_day = sql_startTime + str_cur_day;
                DataRow new_row = crform_ds.Tables["Result"].NewRow();
                //DataTable dt_goods = crform_ds.Tables["Goods_Table"];
                foreach (DataRow row in dt_goods.Rows)
                {
                    if (row["DateID"].ToString() == str_cur_day)
                    {
                        //new_row["StaName"] = row["staname"].ToString();
                        //new_row["DateID"] = row["dateid"].ToString().Substring(0, 8);
                        new_row = row;
                        crform_ds.Tables["Result"].Rows.Add(new_row.ItemArray);
                    }
                }
                DataTable tb_result = crform_ds.Tables["Result"];
                DataRow total_row = tb_result.NewRow();
                total_row["StaName"] = "合计";

                int total_box = 0;
                for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                    total_box += Convert.ToInt32(tb_result.Rows[line_tb_result][1].ToString());
                total_row["SumBox"] = total_box;


                //DataTableSQL查询后得到DateSet中的第一个表Goods_Table，处理每天的箱数和重量
                for (int col_num = 2; col_num <= 16; col_num++)
                {
                    double total_col_weight = 0;
                    for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                    {
                        string weight_str = tb_result.Rows[line_tb_result][col_num].ToString();
                        if (weight_str != "")
                            total_col_weight += Convert.ToDouble(weight_str);

                    }
                    /////////if (total_col_weight != 0)//0不显示
                    total_row[col_num] = total_col_weight;

                }
                total_row["SumBoxTail"] = total_box;
                total_row["DateID"] = crform_ds.Tables["Result"].Rows[crform_ds.Tables["Result"].Rows.Count - 1]["DateID"].ToString();
                crform_ds.Tables["Result"].Rows.Add(total_row);


                //讲结果按队分为三个表


                int team_num = 3;//获得班的个数
                DataTable[] team = new DataTable[team_num + 1];
                //dgdv = new DataGridView[team_num];
                for (int i = 0; i <= team_num; i++)
                {
                    string table_name = "Result_t" + i.ToString();
                    string col1_name = "StaName" + i.ToString();
                    string col2_name = "SumBox" + i.ToString();
                    string col3_name = "SumWeight" + i.ToString();
                    string col4_name = "AveWeight" + i.ToString();
                    int sum_box = 0;
                    double sum_weight = 0;
                    if (crform_ds.Tables.Contains(table_name))//判断一下是否已经有了这个表
                    {
                        crform_ds.Tables[table_name].Clear();
                        team[i] = crform_ds.Tables[table_name];
                    }
                    else
                    {
                        team[i] = crform_ds.Tables.Add(table_name);
                        DataColumn col = team[i].Columns.Add(col1_name, Type.GetType("System.String"));
                        col.AllowDBNull = false;
                        col.MaxLength = 20;
                        col = team[i].Columns.Add(col2_name, Type.GetType("System.Int32"));
                        col.AllowDBNull = true;
                        col = team[i].Columns.Add(col3_name, Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                        col = team[i].Columns.Add(col4_name, Type.GetType("System.Double"));
                        col.AllowDBNull = true;
                    }

                    if (i == 0)//result_t0表作为汇总表，只建表
                        continue;

                    string sql_team = "select * from [rfidtest].[dbo.Station] where Class=" + i.ToString();
                    crform_sqlda = new SqlDataAdapter(sql_team, sqlcon);
                    crform_sqlda.Fill(crform_ds, "Temp_Result");


                    foreach (DataRow row in crform_ds.Tables["Temp_Result"].Rows)
                    {
                        DataRow team_row = team[i].NewRow();
                        team_row[col1_name] = row["Name"];
                        //MessageBox.Show(row["Name"].ToString());
                        foreach (DataRow res_row in crform_ds.Tables["Result"].Rows)
                        {
                            if (res_row["StaName"].ToString() == team_row[col1_name].ToString())
                            {
                                //MessageBox.Show(team_row["StaName"].ToString());
                                team_row[col2_name] = res_row["SumBox"];
                                sum_box += Convert.ToInt32(team_row[col2_name].ToString());
                                team_row[col3_name] = res_row["SumWeight"];
                                sum_weight += Convert.ToDouble(team_row[col3_name].ToString());
                                if (Convert.ToInt32(team_row[col2_name].ToString()) == 0)
                                    team_row[col4_name] = Convert.ToDouble("0");
                                else
                                    team_row[col4_name] = Convert.ToDouble(string.Format("{0:f2}", (Convert.ToDouble(team_row[col3_name].ToString()) / Convert.ToDouble(team_row[col2_name].ToString()))));
                                break;
                            }
                        }
                        team[i].Rows.Add(team_row);
                        team[0].Rows.Add(team_row.ItemArray);
                    }
                    DataRow team_total_row = team[i].NewRow();
                    team_total_row[col1_name] = "实际数";
                    team_total_row[col2_name] = sum_box;
                    team_total_row[col3_name] = sum_weight;
                    if (sum_box != 0)
                        team_total_row[col4_name] = Convert.ToDouble(string.Format("{0:f2}", sum_weight / sum_box));
                    else
                        team_total_row[col4_name] = 0;
                    team[i].Rows.Add(team_total_row);
                    team[0].Rows.Add(team_total_row.ItemArray);

                    DataRow team_plan_row = team[i].NewRow();
                    team_plan_row[col1_name] = "核算数";
                    team_plan_row[col2_name] = sum_box;
                    team_plan_row[col3_name] = sum_weight;
                    if (sum_box != 0)
                        team_plan_row[col4_name] = Convert.ToDouble(string.Format("{0:f2}", sum_weight / sum_box));
                    else
                        team_plan_row[col4_name] = 0;
                    team[i].Rows.Add(team_plan_row);
                    team[0].Rows.Add(team_plan_row.ItemArray);

                    DataRow team_diff_row = team[i].NewRow();
                    team_diff_row[col1_name] = "差额";
                    team_diff_row[col2_name] = 0;
                    team_diff_row[col3_name] = 0;
                    team_diff_row[col4_name] = 0;
                    team[i].Rows.Add(team_diff_row);
                    team[0].Rows.Add(team_diff_row.ItemArray);

                    //dgdv[i - 1] = new DataGridView();
                    //BindingSource myBindingSource = new BindingSource();
                    //myBindingSource.DataSource = crform_ds.Tables[table_name];
                    //DataGridView ss = new DataGridView();
                    //dgdv[i - 1].AutoGenerateColumns = false;
                    //dgdv[i-1]
                    //this.groupBox1.Controls.Add(dgdv[i - 1]);
                    //ss.DataSource = crform_ds.Tables[table_name];
                    //dgdv[i - 1].DataSource = myBindingSource; //crform_ds.Tables[table_name];
                    //dgdv[i-1].DataMember="Result";


                    //MessageBox.Show(ss.Rows.Count.ToString());
                    //MessageBox.Show(dgdv[i - 1].RowCount.ToString());

                    crform_ds.Tables["Temp_Result"].Clear();
                }//每次循环处理一班，一个datatable
                //foreach (DataRow row in crform_ds.Tables["Result_t2"].Rows)
                //{

                //    MessageBox.Show(row["StaName"].ToString());
                //}
                flag_everyday = true;
            }

        }
        private void timerMon4_Tick(object sender, EventArgs e)
        {
            if (flag_everyday == true)
            {
                timerMon4.Stop();
                //MessageBox.Show("请选择年月日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                dataGridViewMon.DataSource = crform_ds.Tables["Result"];
                dataGridViewMon.Visible = false;
                //报表对象，绑定报表文件

                //string crPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                //     Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
                string crPath = "CrystalReport1.rpt";
                //crDocument.Refresh();
                ReportDocument crDocument = new ReportDocument();
                crDocument.Load(crPath);
                //绑定数据集，注意，一个报表用一个数据集。
                crDocument.SetDataSource(crform_ds);

                //在Viewer中呈现
                crystalReportViewerDay.ReportSource = crDocument;
                // MessageBox.Show("请选择年", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                dt_goods.Clear();
                toolStripButtonDayCompExl.Enabled = true;
                progressBarDay.Value = progressBarDay.Maximum;
                progressBarDay.Update();
                labelProgDay.Text = "已完成";
                labelProgDay.Update();
                //MessageBox.Show("请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Enabled = true;
                flag_everyday = false;


            }
        }

        private void toolStripButtonDayCompExl_Click(object sender, EventArgs e)
        {
            flag_everydayexl = false;
            timerMon5.Start();
            //MessageBox.Show("FUCK!");
            System.Threading.Thread myThread = new System.Threading.Thread(new System.Threading.ThreadStart(GenDayCompExcel));
            myThread.Start();
        }
        private void GenDayCompExcel()//导出每日完成情况EXCEL子线程
        {
            flag_everydayexl = true;
        }
        private void timerMon5_Tick(object sender, EventArgs e)
        {
            if (flag_everydayexl == true)
            {
                timerMon5.Stop();
                dataGridViewMon.DataSource = crform_ds.Tables["Result_t0"];

                //MessageBox.Show(dataGridView1[0, 0].Value.ToString());
                //MessageBox.Show(dataGridView1[0, 1].Value.ToString());
                //MessageBox.Show(dataGridView1[1, 0].Value.ToString());
                //MessageBox.Show(dataGridView1[1, 1].Value.ToString());
                //ExportExcel(dataGridView1);
                try
                {

                    if (dataGridViewMon.Rows.Count >= 1)
                    {
                        this.Enabled = false;
                        //MessageBox.Show("FUCK@@");
                        progressBarDay.Visible = true;
                        progressBarDay.Value = 0;
                        progressBarDay.Update();
                        labelProgDay.Text = "开始导出";
                        labelProgDay.Update();
                        string yr_str = comboBoxYear2.Text.Trim();
                        string mon_str = comboBoxMon2.Text.Trim();
                        string day_str = comboBoxDay2.Text.Trim();
                        string fName = "";
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.InitialDirectory = "d:";
                        saveFileDialog.Filter = "EXCEL文件|*.xlsx";
                        saveFileDialog.FilterIndex = 2;
                        saveFileDialog.FileName = mon_str + "月" + day_str + "日完成情况";

                        saveFileDialog.RestoreDirectory = true;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            fName = saveFileDialog.FileName;

                            progressBarDay.Value = 12;
                            progressBarDay.Update();

                            this.Refresh();
                            //建立Excel对象 
                            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel.Workbooks wbs = excel.Workbooks;//一个xls文档 new Microsoft.Office.Interop.Excel.Workbooks();
                            Microsoft.Office.Interop.Excel.Workbook wb = wbs.Add(true);// new Microsoft.Office.Interop.Excel.Workbook   
                            Microsoft.Office.Interop.Excel.Worksheet ws;//excel中的一个sheet
                            ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets["Sheet1"];

                            //int num_sheet = dgv.Rows.Count / 55;
                            //label5.Text = "完成  " + progressBar1.Value.ToString() + "%";
                            //label5.Update();

                            //for (int cur_sheet = 1; cur_sheet <= num_sheet; cur_sheet++)
                            //{
                            //    if (num_sheet != 1)
                            //    {
                            //        progressBar1.Value = Convert.ToInt32(12 + cur_sheet * 87 / num_sheet);
                            //        progressBar1.Update();
                            //label5.Text = "完成  " + progressBar1.Value.ToString() + "%";
                            //label5.Update();
                            //    }
                            //    else
                            //    {
                            //        progressBar1.Value = 50;
                            //        progressBar1.Update();
                            //label5.Text = "完成  " + progressBar1.Value.ToString() + "%";
                            //label5.Update();
                            //    }
                            //    if (cur_sheet == 1)
                            //        ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets["Sheet1"];
                            //    else
                            //        ws = wb.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing) as Microsoft.Office.Interop.Excel.Worksheet;
                            //    ws.Name = cur_sheet.ToString();
                            excel.Cells[2, 1] = "一班：王玉宝";
                            excel.Cells[2, 6] = "二班：蔡震";
                            excel.Cells[2, 11] = "三班：韩培元";
                            excel.Cells[2, 13] = "日期：" + mon_str + "月" + day_str + "日";
                            Microsoft.Office.Interop.Excel.Range merge_range = excel.get_Range(excel.Cells[2, 13], excel.Cells[2, 14]);
                            merge_range.Merge(Type.Missing);
                            Microsoft.Office.Interop.Excel.Range bold_range = excel.get_Range(excel.Cells[2, 1], excel.Cells[2, 15]);
                            bold_range.Font.Bold = true;

                            //生成字段名称 
                            excel.Cells[3, 1] = "楼名";
                            excel.Cells[3, 2] = "日产箱数";
                            excel.Cells[3, 3] = "实际吨数";
                            excel.Cells[3, 4] = "平均吨数";

                            excel.Cells[3, 6] = "楼名";
                            excel.Cells[3, 7] = "日产箱数";
                            excel.Cells[3, 8] = "实际吨数";
                            excel.Cells[3, 9] = "平均吨数";

                            excel.Cells[3, 11] = "楼名";
                            excel.Cells[3, 12] = "日产箱数";
                            excel.Cells[3, 13] = "实际吨数";
                            excel.Cells[3, 14] = "平均吨数";

                            //填充数据 
                            for (int x = 0; x < 15; x++)
                            {
                                for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                                {
                                    if (dataGridViewMon[y, x].Value != null)
                                    {
                                        //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                        excel.Cells[x + 4, y + 1] = dataGridViewMon[y, x].Value;
                                    }
                                    else
                                        excel.Cells[x + 4, y + 1] = "";
                                }
                            }
                            for (int x = 18; x < 40; x++)
                            {
                                for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                                {
                                    if (dataGridViewMon[y, x].Value != null)
                                    {
                                        //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                        excel.Cells[x - 18 + 4, y + 1 + 5] = dataGridViewMon[y, x].Value;
                                    }
                                    else
                                        excel.Cells[x - 18 + 4, y + 1 + 5] = "";
                                }
                            }
                            for (int x = 43; x < 59; x++)
                            {
                                for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                                {
                                    if (dataGridViewMon[y, x].Value != null)
                                    {
                                        //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                        excel.Cells[x - 43 + 4, y + 1 + 10] = dataGridViewMon[y, x].Value;
                                    }
                                    else
                                        excel.Cells[x - 43 + 4, y + 1 + 10] = "";
                                }
                            }

                            for (int x = 15; x < 18; x++)
                            {
                                for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                                {
                                    if (dataGridViewMon[y, x].Value != null)
                                    {
                                        //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                        excel.Cells[x + 13, y + 1] = dataGridViewMon[y, x].Value;
                                    }
                                    else
                                        excel.Cells[x + 13, y + 1] = "";
                                }
                            }
                            for (int x = 40; x < 43; x++)
                            {
                                for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                                {
                                    if (dataGridViewMon[y, x].Value != null)
                                    {
                                        //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                        excel.Cells[x - 12, y + 1 + 5] = dataGridViewMon[y, x].Value;
                                    }
                                    else
                                        excel.Cells[x - 12, y + 1 + 5] = "";
                                }
                            }
                            for (int x = 59; x < 62; x++)
                            {
                                for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                                {
                                    if (dataGridViewMon[y, x].Value != null)
                                    {
                                        //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                        excel.Cells[x - 31, y + 1 + 10] = dataGridViewMon[y, x].Value;
                                    }
                                    else
                                        excel.Cells[x - 31, y + 1 + 10] = "";
                                }
                            }

                            Microsoft.Office.Interop.Excel.Range all_range = excel.get_Range(excel.Cells[3, 1], excel.Cells[30, 14]);//现有的
                            //all_range.NumberFormatLocal = "0.00_";
                            all_range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            all_range.EntireColumn.AutoFit();     //自动调整列宽
                            all_range.EntireRow.AutoFit();

                            Microsoft.Office.Interop.Excel.Range t1_range = excel.get_Range(excel.Cells[3, 1], excel.Cells[30, 4]);
                            t1_range.Borders.LineStyle = 1;
                            Microsoft.Office.Interop.Excel.Range t2_range = excel.get_Range(excel.Cells[3, 6], excel.Cells[30, 9]);
                            t2_range.Borders.LineStyle = 1;
                            Microsoft.Office.Interop.Excel.Range t3_range = excel.get_Range(excel.Cells[3, 11], excel.Cells[30, 14]);
                            t3_range.Borders.LineStyle = 1;


                            labelProgDay.Text = "完成  " + progressBarDay.Value.ToString() + "%";
                            labelProgDay.Update();
                            //}//end for每个datagridview,也就是每个table_team
                            //}//end for每个sheet                   

                            progressBarDay.Value = progressBarDay.Maximum;
                            progressBarDay.Update();


                            wb.Saved = true;
                            wb.SaveCopyAs(fName); //保存
                            excel.Quit(); //关闭进程
                            labelProgDay.Text = "已完成";
                            labelProgDay.Update();
                            MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                            //label5.Text = "完成";
                            toolStripButtonDayCompExl.Enabled = false;
                            this.Enabled = true;


                        }
                        else
                        {
                            progressBarDay.Visible = false;
                            progressBarDay.Update();
                            labelProgDay.Text = "";
                            labelProgDay.Update();
                            MessageBox.Show("未导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    progressBarDay.Visible = false;
                    progressBarDay.Update();
                    labelProgDay.Text = "";
                    labelProgDay.Update();
                    this.Enabled = true;
                }
                this.Enabled = true;
                flag_everydayexl = false;
            }
        }
#endregion

        #region 年表
        private void comboBoxDay3_DropDown_1(object sender, EventArgs e)
        {
            if (comboBoxYear3.Text.Trim() == "" || comboBoxMon3.Text.Trim() == "")
            {
                MessageBox.Show("请先选择年月，再选择日", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                comboBoxDay3.Items.Clear();
                if (comboBoxMon3.Text.Trim() == "1" || comboBoxMon3.Text.Trim() == "3" || comboBoxMon3.Text.Trim() == "5" || comboBoxMon3.Text.Trim() == "7" || comboBoxMon3.Text.Trim() == "8" || comboBoxMon3.Text.Trim() == "10" || comboBoxMon3.Text.Trim() == "12")
                {


                    comboBoxDay3.Items.Add("1");
                    comboBoxDay3.Items.Add("2");
                    comboBoxDay3.Items.Add("3");
                    comboBoxDay3.Items.Add("4");
                    comboBoxDay3.Items.Add("5");
                    comboBoxDay3.Items.Add("6");
                    comboBoxDay3.Items.Add("7");
                    comboBoxDay3.Items.Add("8");
                    comboBoxDay3.Items.Add("9");
                    comboBoxDay3.Items.Add("10");
                    comboBoxDay3.Items.Add("11");
                    comboBoxDay3.Items.Add("12");
                    comboBoxDay3.Items.Add("13");
                    comboBoxDay3.Items.Add("14");
                    comboBoxDay3.Items.Add("15");
                    comboBoxDay3.Items.Add("16");
                    comboBoxDay3.Items.Add("17");
                    comboBoxDay3.Items.Add("18");
                    comboBoxDay3.Items.Add("19");
                    comboBoxDay3.Items.Add("20");
                    comboBoxDay3.Items.Add("21");
                    comboBoxDay3.Items.Add("22");
                    comboBoxDay3.Items.Add("23");
                    comboBoxDay3.Items.Add("24");
                    comboBoxDay3.Items.Add("25");
                    comboBoxDay3.Items.Add("26");
                    comboBoxDay3.Items.Add("27");
                    comboBoxDay3.Items.Add("28");
                    comboBoxDay3.Items.Add("29");
                    comboBoxDay3.Items.Add("30");
                    comboBoxDay3.Items.Add("31");
                }
                else if (comboBoxMon3.Text.Trim() == "4" || comboBoxMon3.Text.Trim() == "6" || comboBoxMon3.Text.Trim() == "9" || comboBoxMon3.Text.Trim() == "11")
                {
                    comboBoxDay3.Items.Add("1");
                    comboBoxDay3.Items.Add("2");
                    comboBoxDay3.Items.Add("3");
                    comboBoxDay3.Items.Add("4");
                    comboBoxDay3.Items.Add("5");
                    comboBoxDay3.Items.Add("6");
                    comboBoxDay3.Items.Add("7");
                    comboBoxDay3.Items.Add("8");
                    comboBoxDay3.Items.Add("9");
                    comboBoxDay3.Items.Add("10");
                    comboBoxDay3.Items.Add("11");
                    comboBoxDay3.Items.Add("12");
                    comboBoxDay3.Items.Add("13");
                    comboBoxDay3.Items.Add("14");
                    comboBoxDay3.Items.Add("15");
                    comboBoxDay3.Items.Add("16");
                    comboBoxDay3.Items.Add("17");
                    comboBoxDay3.Items.Add("18");
                    comboBoxDay3.Items.Add("19");
                    comboBoxDay3.Items.Add("20");
                    comboBoxDay3.Items.Add("21");
                    comboBoxDay3.Items.Add("22");
                    comboBoxDay3.Items.Add("23");
                    comboBoxDay3.Items.Add("24");
                    comboBoxDay3.Items.Add("25");
                    comboBoxDay3.Items.Add("26");
                    comboBoxDay3.Items.Add("27");
                    comboBoxDay3.Items.Add("28");
                    comboBoxDay3.Items.Add("29");
                    comboBoxDay3.Items.Add("30");
                }
                else
                {
                    string year_str = comboBoxYear3.Text.Trim();
                    int year_int = Convert.ToInt32(year_str);
                    if (year_int % 4 == 0 || (year_int % 100 == 0 && year_int % 400 == 0))
                    {
                        comboBoxDay3.Items.Add("1");
                        comboBoxDay3.Items.Add("2");
                        comboBoxDay3.Items.Add("3");
                        comboBoxDay3.Items.Add("4");
                        comboBoxDay3.Items.Add("5");
                        comboBoxDay3.Items.Add("6");
                        comboBoxDay3.Items.Add("7");
                        comboBoxDay3.Items.Add("8");
                        comboBoxDay3.Items.Add("9");
                        comboBoxDay3.Items.Add("10");
                        comboBoxDay3.Items.Add("11");
                        comboBoxDay3.Items.Add("12");
                        comboBoxDay3.Items.Add("13");
                        comboBoxDay3.Items.Add("14");
                        comboBoxDay3.Items.Add("15");
                        comboBoxDay3.Items.Add("16");
                        comboBoxDay3.Items.Add("17");
                        comboBoxDay3.Items.Add("18");
                        comboBoxDay3.Items.Add("19");
                        comboBoxDay3.Items.Add("20");
                        comboBoxDay3.Items.Add("21");
                        comboBoxDay3.Items.Add("22");
                        comboBoxDay3.Items.Add("23");
                        comboBoxDay3.Items.Add("24");
                        comboBoxDay3.Items.Add("25");
                        comboBoxDay3.Items.Add("26");
                        comboBoxDay3.Items.Add("27");
                        comboBoxDay3.Items.Add("28");
                        comboBoxDay3.Items.Add("29");
                    }
                    else
                    {
                        comboBoxDay3.Items.Add("1");
                        comboBoxDay3.Items.Add("2");
                        comboBoxDay3.Items.Add("3");
                        comboBoxDay3.Items.Add("4");
                        comboBoxDay3.Items.Add("5");
                        comboBoxDay3.Items.Add("6");
                        comboBoxDay3.Items.Add("7");
                        comboBoxDay3.Items.Add("8");
                        comboBoxDay3.Items.Add("9");
                        comboBoxDay3.Items.Add("10");
                        comboBoxDay3.Items.Add("11");
                        comboBoxDay3.Items.Add("12");
                        comboBoxDay3.Items.Add("13");
                        comboBoxDay3.Items.Add("14");
                        comboBoxDay3.Items.Add("15");
                        comboBoxDay3.Items.Add("16");
                        comboBoxDay3.Items.Add("17");
                        comboBoxDay3.Items.Add("18");
                        comboBoxDay3.Items.Add("19");
                        comboBoxDay3.Items.Add("20");
                        comboBoxDay3.Items.Add("21");
                        comboBoxDay3.Items.Add("22");
                        comboBoxDay3.Items.Add("23");
                        comboBoxDay3.Items.Add("24");
                        comboBoxDay3.Items.Add("25");
                        comboBoxDay3.Items.Add("26");
                        comboBoxDay3.Items.Add("27");
                        comboBoxDay3.Items.Add("28");
                    }
                }
            }

        }
        private void comboBoxMon3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBoxDay3.Items.Clear();
        }
        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            crystalReportViewerYear.ReportSource = null;
            if (comboBoxYear3.Text != "")
            {
                if (crform_ds.Tables.Contains("YearOutput"))//判断一下是否已经有了这个表
                {
                    crform_ds.Tables["YearOutput"].Clear();
                }
                backgroundWorkerYearOp.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("请选择要查看表的年份", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void backgroundWorkerYearOp_DoWork(object sender, DoWorkEventArgs e)
        {
        
            this.Enabled = false;

            progressBarYear.Visible = true;
            progressBarYear.Value = 0;
            progressBarYear.Update();
            labelProgYear.Text = "";
            labelProgYear.Update();
            //MessageBox.Show("aa", "day", MessageBoxButtons.OK, MessageBoxIcon.None);
            crform_ds.Tables["Result"].Clear();
            //MessageBox.Show("aa", "day", MessageBoxButtons.OK, MessageBoxIcon.None);
            string yr_str = comboBoxYear3.Text; //"2010";// comboBoxYear3.Text.Trim();
            //int yr_int = Convert.ToInt32(yr_str);
            //string mon_str = comboBoxMon3.Text.Trim();
            //int mon_int = Convert.ToInt32(mon_str);
            //if (mon_int < 10)
            //    mon_str = "0" + mon_str;
            groupBoxReport3.Enabled = true;
           
    
            string sql_startTime = yr_str.Substring(2, 2) + "-";
            //MessageBox.Show("aa", "day", MessageBoxButtons.OK, MessageBoxIcon.None);
            for (int cur_mon = 1; cur_mon <= 12; cur_mon++)//2替换cur_month_days。按站分组，每次生成新表的一行
            {
                //MessageBox.Show(cur_mon.ToString(), "day", MessageBoxButtons.OK, MessageBoxIcon.None);
                labelProgYear.Text = "完成  " + progressBarYear.Value.ToString() + "%";
                labelProgYear.Update();
                progressBarYear.Value = Convert.ToInt32(cur_mon * 8.15);
                progressBarYear.Update();
                //System.Threading.Thread.Sleep(1);
                //this.Update();
                //this.Refresh();

                //int first_line = (cur_day - 1) * 56;//当天在Result表中第一行
                string str_cur_mon = cur_mon.ToString();
                if (cur_mon < 10)
                {
                    //str_cur_mon = sql_startTime + day_str;
                    str_cur_mon = "0" + str_cur_mon;
                }

                string sql_goods = @"if not exists(select name from sysobjects where name='resYear' and type='u')
  create table resYear(monname  varchar(100),summonbox int,summonweight float,datemonid varchar(30));
else
  begin
  drop table resYear;
  create table resYear(monname  varchar(100),summonbox int,summonweight float,datemonid varchar(30));
  end

declare @monweight float;
declare @monbox int;
declare @yrweight float;
declare @yrbox int;
declare @datemon varchar(30);
declare @i int;

declare @q_date varchar(10);
set @q_date='" + yr_str.Substring(2, 2) + @"-'

declare @mons int;/*月份*/ 
set @mons=1;
declare @mon_str varchar(20);
set @monweight=0;
set @monbox=0;
set @yrweight=0;
set @yrbox=0;

set @mons=" + cur_mon.ToString() + @"

    set @monweight=0;
    set @monbox=0;
    set @datemon=cast(@mons as varchar)+'月';
    if @mons<10
        set @mon_str=@q_date+'0'+cast(@mons as varchar)+'-';
    if @mons>=10
        set @mon_str=@q_date+cast(@mons as varchar)+'-';

    declare @days int;/*当前月份的天数*/ 
    set @days=1;
    declare @day_str varchar(20);

    while @days<=31
    begin
        if @days<10
            set @day_str=@mon_str+'0'+cast(@days as varchar)+'%';
        if @days>=10
            set @day_str=@mon_str+cast(@days as varchar)+'%';

        declare @staid int;
        set @staid=31;
        while @staid<=85
        begin
            declare @stationname varchar(100);
	        set @stationname=(select Name from [rfidtest].[dbo.Station] WHERE StationID=@staid);
	        declare @date varchar(30);
	        set @date=substring(@day_str,1,8);
	        declare @boxnum int;
	        set @boxnum=(select count(*) from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str GROUP BY StartStationID);
            declare @tweight float;
	        set @tweight=(select sum(Weight) from [rfidtest].[dbo.Goods] WHERE StartStationID=@staid AND StartTime LIKE @day_str GROUP BY StartStationID);
            if @tweight is null
                set @tweight=0;
            if @boxnum is null
                set @boxnum=0;
            set @monbox=@monbox+@boxnum
            set @monweight=@monweight+@tweight
            set @staid=@staid+1;
        end
        set @days=@days+1;
    end
    if @monbox<>0
	    insert into resYear(monname,summonbox,summonweight,datemonid) values(@datemon,@monbox,@monweight,' ');
    else
        insert into resYear(monname,summonbox,summonweight,datemonid) values(@datemon,0,0,' ');

select * from resYear;
drop table resYear;";



                crform_sqlda = new SqlDataAdapter(sql_goods, sqlcon);

                crform_sqlda.SelectCommand.CommandTimeout = 100000000;


                try
                {
                    crform_sqlda.Fill(crform_ds, "YearOutput");//得到要查询的月的所有的运输信息，包括所有站。
                }
                catch (Exception x)
                {
                    MessageBox.Show("不能生成报表,请查找错误");
                    this.Enabled = true;
                    progressBarYear.Visible = false;
                    labelProgYear.Text = "";
                    labelProgYear.Update();
                    groupBoxReport3.Enabled = false;
                    groupBoxSelect3.Enabled = true;
                    dt_goods.Clear();
                    //crform_ds.Tables["YearOutput"].Clear();

                    return;
                }

                //DataRow new_row = crform_ds.Tables["Result"].NewRow();
                
                //foreach (DataRow row in dt_goods.Rows)
                //{
                //    if (row["DateID"].ToString() == str_cur_day)
                //    {
                //        //new_row["StaName"] = row["staname"].ToString();
                //        //new_row["DateID"] = row["dateid"].ToString().Substring(0, 8);
                //        new_row = row;
                //        crform_ds.Tables["Result"].Rows.Add(new_row.ItemArray);
                //    }
                //}
                //DataTable tb_result = crform_ds.Tables["Result"];
                //DataRow total_row = tb_result.NewRow();
                //total_row["StaName"] = "合计";

                //int total_box = 0;
                //for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                //    total_box += Convert.ToInt32(tb_result.Rows[line_tb_result][1].ToString());
                //total_row["SumBox"] = total_box;

                ////DataTableSQL查询后得到DateSet中的第一个表Goods_Table，处理每天的箱数和重量
                //for (int col_num = 2; col_num <= 16; col_num++)
                //{
                //    double total_col_weight = 0;
                //    for (int line_tb_result = first_line; line_tb_result <= first_line + 54; line_tb_result++)//当天的所有记录在Result表中的行数范围，不包括合计
                //    {
                //        string weight_str = tb_result.Rows[line_tb_result][col_num].ToString();
                //        if (weight_str != "")
                //            total_col_weight += Convert.ToDouble(weight_str);

                //    }
                //    ///////////if (total_col_weight != 0)//0不显示
                //    total_row[col_num] = total_col_weight;

                //}
                //total_row["SumBoxTail"] = total_box;
                //total_row["DateID"] = crform_ds.Tables["Result"].Rows[crform_ds.Tables["Result"].Rows.Count - 1]["DateID"].ToString();
                //DataRow mdRow = crform_ds.Tables["MyDate"].Rows[cur_day - 1];
                //mdRow["TotalBox"] = total_box;
                //mdRow["TotalWeight"] = total_row["SumWeight"];
                //crform_ds.Tables["Result"].Rows.Add(total_row);

                //crform_ds.Tables["YearOutput"].Clear();


            }//end for
            double yrWeight = 0;
            int yrBox = 0;
            DataTable aa = crform_ds.Tables["YearOutput"];
            foreach (DataRow row in aa.Rows)
            {
                //MessageBox.Show(row["MonName"].ToString());
                yrBox += Convert.ToInt32(row["SumMonBox"].ToString());
                yrWeight+=Convert.ToDouble(row["SumMonWeight"].ToString());
                //new_row["StaName"] = row["staname"].ToString();
                //new_row["DateID"] = row["dateid"].ToString().Substring(0, 8);
            }
            DataRow new_row = crform_ds.Tables["YearOutput"].NewRow();
            new_row["MonName"] = "总计";
            new_row["SumMonBox"]=yrBox;
            new_row["SumMonWeight"]=yrWeight;
            crform_ds.Tables["YearOutput"].Rows.Add(new_row);

            //flag_mon = true;
        }
        private void backgroundWorkerYearOp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridViewMon.DataSource = crform_ds.Tables["YearOutPut"];
            dataGridViewMon.Visible = false;
            //报表对象，绑定报表文件

            //string crPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
            //     Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            string crPath = "CrystalReport4.rpt";
            //crDocument.Refresh();
            ReportDocument crDocument = new ReportDocument();
            crDocument.Load(crPath);
            //绑定数据集，注意，一个报表用一个数据集。
            crDocument.SetDataSource(crform_ds);

            //在Viewer中呈现
            crystalReportViewerYear.ReportSource = crDocument;
            // MessageBox.Show("请选择年", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            dt_goods.Clear();
            toolStripButtonYearExl.Enabled = true;
            progressBarYear.Value = progressBarYear.Maximum;
            progressBarYear.Update();
            labelProgYear.Text = "已完成";
            labelProgYear.Update();
            //MessageBox.Show("请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Enabled = true;
        }
        private void toolStripButtonYearExl_Click(object sender, EventArgs e)
        {
            if (dataGridViewMon.Rows.Count >= 1)
            {
                this.Enabled = false;
                progressBarYear.Visible = true;
                progressBarYear.Value = 0;
                progressBarYear.Update();
                labelProgYear.Text = "开始导出";
                labelProgYear.Update();
                string yr_str = comboBoxYear3.Text;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "d:";
                saveFileDialog.Filter = "EXCEL文件|*.xlsx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.FileName = yr_str + "年垃圾产量总计表";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fName = saveFileDialog.FileName;
                    this.Refresh();
                    
                    backgroundWorkerYearExl.RunWorkerAsync();
                }
                else
                {
                    progressBarYear.Visible = false;
                    progressBarYear.Update();
                    labelProgYear.Text = "";
                    labelProgYear.Update();
                    MessageBox.Show("未导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Enabled = true;
                }
            
            }
           
        }
        private void backgroundWorkerYearExl_DoWork(object sender, DoWorkEventArgs e)
        {
            
            try
            {
                       

                        progressBarYear.Value = 12;
                        progressBarYear.Update();
                        labelProgYear.Text = "完成 " + progressBarYear.Value.ToString() + "%";
                        labelProgYear.Update();
                        
                        //建立Excel对象 
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbooks wbs = excel.Workbooks;//一个xls文档 new Microsoft.Office.Interop.Excel.Workbooks();
                        Microsoft.Office.Interop.Excel.Workbook wb = wbs.Add(true);// new Microsoft.Office.Interop.Excel.Workbook   
                        Microsoft.Office.Interop.Excel.Worksheet ws;//excel中的一个sheet
                        ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets["Sheet1"];

                      
                        
                        Microsoft.Office.Interop.Excel.Range merge_range = excel.get_Range(excel.Cells[1, 1], excel.Cells[2, 11]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 1], excel.Cells[4, 1]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 2], excel.Cells[4, 2]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 3], excel.Cells[4, 3]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 10], excel.Cells[4, 10]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 11], excel.Cells[4, 11]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 4], excel.Cells[3, 6]);
                        merge_range.Merge(Type.Missing);
                        merge_range = excel.get_Range(excel.Cells[3, 7], excel.Cells[3, 9]);
                        merge_range.Merge(Type.Missing);

                        excel.Cells[1, 1] = comboBoxYear3.Text +"年垃圾产量总计表";
                        Microsoft.Office.Interop.Excel.Range bold_range = excel.get_Range(excel.Cells[1, 1], excel.Cells[2,11]);
                        bold_range.Font.Size = 20;
                        bold_range.Font.Bold = true;
                        bold_range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        bold_range.EntireColumn.AutoFit();     //自动调整列宽
                        bold_range.EntireRow.AutoFit();
                        excel.Cells[3, 1] = "日期";
                        excel.Cells[3, 2] = "月产箱数";
                        excel.Cells[3, 3] = "实际吨数";
                        excel.Cells[3, 4] = "自运箱数";
                        excel.Cells[3, 5] = "实际吨数";
                        excel.Cells[3, 10] = "合计箱数";
                        excel.Cells[3, 11] = "合计吨数";

                        excel.Cells[4, 4] = "西清";
                        excel.Cells[4, 5] = "十队";
                        excel.Cells[4, 6] = "合计";
                        excel.Cells[4, 7] = "西清";
                        excel.Cells[4, 8] = "十队";
                        excel.Cells[4, 9] = "合计";

                        //填充数据 
                        for (int x = 0; x < dataGridViewMon.RowCount; x++)
                        {
                            for (int y = 0; y < dataGridViewMon.ColumnCount; y++)
                            {
                                if (dataGridViewMon[y, x].Value != null)
                                {
                                    //MessageBox.Show(dataGridView1[y, x].Value.ToString());
                                    excel.Cells[x + 5, y + 1] = dataGridViewMon[y, x].Value;
                                }
                                else
                                    excel.Cells[x + 5, y + 1] = "";
                            }
                        }


                        Microsoft.Office.Interop.Excel.Range all_range = excel.get_Range(excel.Cells[3, 1], excel.Cells[17, 11]);//现有的                    
                        all_range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        all_range.EntireColumn.AutoFit();     //自动调整列宽
                        all_range.EntireRow.AutoFit();
                        all_range.Borders.LineStyle = 1;
                        all_range.Font.Size = 12;



                        labelProgYear.Text = "完成  " + progressBarYear.Value.ToString() + "%";
                        labelProgYear.Update();
                

                        progressBarYear.Value = progressBarYear.Maximum;
                        progressBarYear.Update();


                        wb.Saved = true;
                        wb.SaveCopyAs(fName); //保存
                        excel.Quit(); //关闭进程
                        labelProgYear.Text = "已完成";
                        labelProgYear.Update();
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                        //label5.Text = "完成";
                        toolStripButton6.Enabled = false;
                        this.Enabled = true;


                    
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                progressBarDay.Visible = false;
                progressBarDay.Update();
                labelProgDay.Text = "";
                labelProgDay.Update();
                this.Enabled = true;
            }
            this.Enabled = true;

        }
        private void backgroundWorkerYearExl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion

        //*******************************************************************************

        #region 本区域代码 by 林秀峰

        #region 以下内容与读写卡有关，林秀峰
        /*************New by 林秀峰*****************/
        QMS3.OperateAndValidate.OperateAndValidate opAndvalidate = new QMS3.OperateAndValidate.OperateAndValidate();
        QMS3.CfCardPC.CfCardPC cardrelated = new QMS3.CfCardPC.CfCardPC();
        /******************************/
        /*********************************************以下内容与读写卡有关，林秀峰***************************************/
        private int CardClass = -1, DataState = -1;
        // CardClass: 记录选择卡的类型: 0为司机卡, 1为货箱卡. 其它值无效.
        // DateState: 记录数据库中是否有该卡: 2为数据库中含有该卡,但需要修改;
        //                                    1为数据库中含有该卡,无需添加以及修改; 
        //                                    0为添加新卡. 其它值无效.
        string CardID = "";
        #endregion

        #region 司机发卡中读卡按钮
        /// <summary>
        /// 司机发卡中读卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            bool bStatus = cardrelated.Connect();

            if (!bStatus)
            {
                MessageBox.Show("读卡失败");

                return;
            }
            string strStatus = "";
            int intStatus = cardrelated.Request(ref strStatus);

            ReadDriverCard();
        }
        #endregion

        #region 读司机卡
        /// <summary>
        /// 读司机卡
        /// </summary>
        public void ReadDriverCard()
        {
            #region 读卡
            CardID = "";
            int status = 0;
            bool bStatus;

            status = cardrelated.GetCardID(0, ref CardID); //0为司机卡

            if (status != 0)
            //读卡不成功
            {
                /*
                if (status != 3 && status != 5)
                    MessageBox.Show("读卡不成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                */
                //ResetAll();
                bStatus = cardrelated.Disconnect();
                return;
            }

            bStatus = cardrelated.Disconnect();

            //*****************************************************************
            //MessageBox.Show(CardID);
            #endregion

            #region 读数据库
            try
            {
                ///*
                SqlDataReader sqlread = boperate.getread("EXEC ReadDriverCard'"
                                        + CardID + "'");
                //*/

                /*
                SqlDataReader sqlread = boperate.getread("EXEC ReadDriverCard'"
                                        + "12345678" + "'");
                //*/
                if (sqlread.Read())
                {
                    if (MessageBox.Show("您扫描的卡号在数据库中已有记录，是否更改？", "提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            txtDCNo.Text = sqlread["DriverCardID"].ToString();
                            txtTruckNo.Text = sqlread["TruckNo"].ToString();
                            txtTruckNo.ReadOnly = false;
                        }
                        catch
                        {
                            MessageBox.Show("数据库配置有误，请确认数据库已配置完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            ResetDCardSent_All();

                            return;
                        }

                        DataState = 2;
                        btnResetDCardAll.Enabled = btnSendDCard.Enabled = btnResetDCard.Enabled = true;
                        btnReadDCard.Enabled = false;
                    }
                    else
                    {
                        ResetDCardSent_All();

                        //调试用
                        txtDCNo.Text = "";
                        txtDCNo.Enabled = txtTruckNo.Enabled = false;
                        btnReadDCard.Enabled = true;
                        btnSendDCard.Enabled = false;
                    }
                }
                else if (MessageBox.Show("您扫描的卡号没有在数据库中查到，是否添加新卡？", "提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //MessageBox.Show("您选择添加新卡", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataState = 0;

                    txtDCNo.Text = CardID;

                    txtTruckNo.Text = "";
                    txtTruckNo.ReadOnly = false;

                    string TruckNo_T = "";

                    int nStatus = cardrelated.ReadTruckNo(ref TruckNo_T);

                    //验证司机车牌，如果不是指定格式，则取空字符

                    try
                    {
                        TruckNo_T = TruckNo_T.Substring(0, 7);
                    }
                    catch
                    {
                        TruckNo_T = "";
                    }
                    //*/
                    bool b_t_Status = false;//opAndvalidate.validateTruckNo(TruckNo_T);
                    //MessageBox.Show(TruckNo_T.Length.ToString());
                    //MessageBox.Show(nStatus.ToString());

                    btnResetDCardAll.Enabled = btnSendDCard.Enabled = true;
                    btnReadDCard.Enabled = false;

                    if (nStatus == 0 && b_t_Status == true)
                    {
                        txtTruckNo.Text = TruckNo_T;
                    }
                    else
                    {
                        txtTruckNo.Text = "京A";
                    }

                }
                else
                {
                    ResetDCardSent_All();

                    //调试用
                    txtDCNo.Text = "";
                    txtDCNo.Enabled = txtTruckNo.Enabled = false;

                    btnReadDCard.Enabled = true;
                    btnSendDCard.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show("数据库连接或者配置有误，请检查连接！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetDCardSent_All();

                //调试用
                txtDCNo.Text = "";
                txtDCNo.Enabled = txtTruckNo.Enabled = false;

                return;
            }
            #endregion
        }
        #endregion

        #region 写司机卡
        /// <summary>
        /// 写司机卡
        /// </summary>
        public void WriteDriverCard()
        {
            #region 验证数据的正确性 (目前未严格验证)
            //验证数据的正确性
            bool validity = true;// opAndvalidate.validateTruckNo(txtTruckNo.Text.Trim());

            //仅测试用
            if ("" == txtTruckNo.Text.Trim())
            //|| "" == txtDriverName.Text.Trim()) 
            {
                validity = false;
            }

            if (!validity)
            {
                MessageBox.Show("您输入的数据有误，请检查后重新提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region 写卡
            /* ***********************************************************************************
             *                                                                                   *
             *                                 有关写卡                                          *
             *                                                                                   *
             * ***********************************************************************************/

            //调用写卡函数，此处调试用，显示对话框
            //if (DialogResult.Yes == MessageBox.Show("是否发放司机卡？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            DialogResult DiaResult = MessageBox.Show("是否发放司机卡？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (DialogResult.Yes == DiaResult)
            {
                int status;

                //写卡之前先确认卡片是否存在
                string t_CardID = "";
                status = cardrelated.GetCardID(-1, ref t_CardID); //-1为不验证卡类型
                if (t_CardID != CardID)
                {
                    //MessageBox.Show("当前卡片与刚读取的卡片编号不一致", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = 3;
                }

                if (status != 0)
                {
                    //if (status != 3 )
                    //MessageBox.Show("读卡不成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ResetDCardSent_All();

                    cardrelated.Disconnect();
                    return;
                }

                //写卡类型
                //status = cardrelated_old.WriteCardClass("CARCARD");
                status = cardrelated.WriteCardClass("C");
                if (status != 0)
                {
                    MessageBox.Show("出错啦！写入卡类型不成功！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetDCardSent_All();

                    return;
                }
                //MessageBox.Show("写入卡类型成功");//*/

                //写车牌号
                status = cardrelated.WriteTruckNo(txtTruckNo.Text.Trim());
                if (status != 0)
                {
                    MessageBox.Show("出错啦！写入司机牌号不成功！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetDCardSent_All();

                    return;
                }
            }
            else if (DialogResult.No == DiaResult)
            {
                ResetDCardSent_All();
                return;
            }
            else
            {
                return;
            }
            #endregion

            #region 写数据库
            //写数据库
            if (DataState == 0)
            {
                try
                {
                    //boperate.getcom("INSERT INTO [TranspoartSystem].[dbo].[Driver] ([DriverCardID] ,[TruckNo]) VALUES ('" + txtDCNo.Text + "','" + txtTruckNo.Text + "')");
                    boperate.getcom("EXEC InsertIntoDriverCard '" + txtDCNo.Text.Trim() + "','" + txtTruckNo.Text.Trim() + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show("数据库连接或者配置有误，发卡写入数据库失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ResetDCardSent_All();

                    //调试用
                    txtDCNo.Text = "";
                    txtDCNo.Enabled = txtTruckNo.Enabled = false;

                    return;
                }
            }
            else if (DataState == 2)
            {
                try
                {
                    /*
                    boperate.getcom("UPDATE [TranspoartSystem].[dbo].[Driver] SET [TruckNo] = '" + txtTruckNo.Text + "'"
                                    + "WHERE [DriverCardID] = '" + txtDCNo.Text + "'");
                    //*/
                    boperate.getcom("Exec UpdateDriverCard'" + txtDCNo.Text.Trim() + "'"
                                    + ", '" + txtTruckNo.Text.Trim() + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    MessageBox.Show("数据库连接或者配置有误，发卡写入数据库失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ResetDCardSent_All();

                    //调试用
                    txtDCNo.Text = "";
                    txtDCNo.Enabled = txtTruckNo.Enabled = false;

                    return;
                }
            }
            #endregion

            MessageBox.Show("发卡成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #region 清空

            ResetDCardSent_All();

            //调试用
            txtDCNo.Text = "";
            txtDCNo.Enabled = txtTruckNo.Enabled = false;
            #endregion
        }
        #endregion

        #region 读货箱卡
        /// <summary>
        /// 读货箱卡
        /// </summary>
        public void ReadBoxCard()
        {
        }
        #endregion

        #region 写货箱卡
        /// <summary>
        /// 写货箱卡
        /// </summary>
        public void WriteBoxCard()
        {
        }
        #endregion

        #region 司机发卡中重置按钮
        private void btnResetDCard_Click(object sender, EventArgs e)
        {
            ResetDCardSent_All();
        }
        #endregion

        #region 重置司机发卡Tab
        public void ResetDCardSent_All()
        {
            btnReadDCard.Enabled = true;
            btnSendDCard.Enabled = false;

            txtDriverNo.Text = txtDriverName.Text //= txtDriverGender.Text
                = txtDriverAge.Text = txtDriverStation.Text = txtTruckNo.Text
                = txtDCNo.Text = "";

            cardrelated.Disconnect();

            btnReadDCard.Enabled = true;
            btnSendDCard.Enabled = btnResetDCard.Enabled = false;
        }
        #endregion

        #region 重置司机发卡Tab中司机信息
        private void btnResetDCard_Click_1(object sender, EventArgs e)
        {
            btnReadDCard.Enabled = true;
            btnSendDCard.Enabled = false;

            txtTruckNo.Text = txtDCNo.Text = "";

            cardrelated.Disconnect();

            btnReadDCard.Enabled = true;
            btnSendDCard.Enabled = btnResetDCard.Enabled = false;
        }
        #endregion

        #region 司机发卡中写卡按钮
        private void btnSendDCard_Click(object sender, EventArgs e)
        {
            bool bStatus = cardrelated.Connect();

            if (!bStatus)
                return;

            WriteDriverCard();

            cardrelated.Disconnect();
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {

        }
        #endregion

        //*************************add by will*******************************************
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


            System.Windows.Forms.TreeNode treeNode236 = new System.Windows.Forms.TreeNode("报表生成器", new System.Windows.Forms.TreeNode[] { treeNode216, treeNode217, treeNode218 });
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

        #region login

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
            if (conneted)
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
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                this.AcceptButton = button3;
            else
                this.AcceptButton = button1;
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
        #endregion

        #region 结算
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
                debugtextbox.Text += "\n读到卡数" + Ccount.ToString() + "\n";
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
            string Starttime = "";
            int StartStation = 0;
            if (TransCenter.readinfo(ref info, textBox1.Text, ref Starttime, ref StartStation))
            {
                //this.myadapter.UpdateCommand = new SqlCommand(" UPDATE [dbo.Goods] SET [State] = @State, [Weight] = @Weight WHERE (BoxCardID = @BoxCardID) AND (TruckNo = @TruckNo) AND (StartTime = @StartTime) AND (StartStationID = @StartStationID)");
                int count=0;
                //MessageBox.Show("OK");
                try 
                {
                    count=int.Parse(this.dbo_GoodsTableAdapter.ScalarQueryNumofGoods(Starttime," "+TransCenter.TruckNo).ToString());
                    debugtextbox.Text += "========== " + count.ToString() + "==========";
                    if(count<1)
                    {
                        MessageBox.Show("远程垃圾站"+TransCenter.StationName[TransCenter.startstationid]+"网络可能出错,本条记录会添加到数据库中,但请检查垃圾站的网络是否正常！");
                        this.dbo_GoodsTableAdapter.InsertQuerya(TransCenter.ToHexString(TransCenter.TagBuffer).Substring(2, 6), " "+TransCenter.TruckNo, Starttime, TransCenter.sEndTime,-1, double.Parse(textBox1.Text), TransCenter.startstationid);
                        listBox1.Items.Add(info);
                    }

                }
                catch
                {
                    MessageBox.Show("数据库同步失败！");
                    listBox1.Items.Add(info + "   " + "数据库同步失败！");
                }
                try
                {
                    if (count == 1)
                    {
                        this.dbo_GoodsTableAdapter.UpdateGoodsByTime(1, double.Parse(textBox1.Text), TransCenter.sEndTime, Starttime, StartStation, TransCenter.TruckNo);
                        listBox1.Items.Add(info);
                    }
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
        #endregion

        #region 异常处理

        private void goodupdatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dbo_GoodsTableAdapter.UpdateGoodsByEndTime(2, double.Parse(textBox13.Text), textBox14.Text,textBox16.Text);
                textBox17.Text = "";
                textBox16.Text = "";
                textBox15.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                string systime = System.DateTime.Now.ToString("yy-MM-dd"); //"10-06-11";
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
            catch
            {
                MessageBox.Show("数据库操作超时！");
            }
        }

        private void goodsdelbutton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dbo_GoodsTableAdapter.DeleteByEndTime(textBox14.Text,textBox16.Text);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                string systime = System.DateTime.Now.ToString("yy-MM-dd"); //;
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
            catch
            {
                MessageBox.Show("数据库操作超时，请稍后再试！");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox17.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            
           
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox17.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox16.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox15.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox14.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox13.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch
            { }

        }
        #endregion

        #region 编辑用户
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UserID.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                TBuserName.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                TBright.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
                TBpassword.Text = "";
            }
            catch { }

        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UserID.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                TBuserName.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                TBright.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
                TBpassword.Text = "";
            }
            catch
            { }

        }

        private void TBright_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(TBright.Text) < 0 || int.Parse(TBright.Text) > 5)
                    TBright.Text = "0";
            }
            catch
            {
                TBright.Text = "0";
            }
            
        }

        private void BnAddUser_Click(object sender, EventArgs e)
        {
            if (TBuserName.Text.Length == 0)
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if(TBright.Text.Length==0)
            {
                MessageBox.Show("权限不能为空！");
                return;
            }
            if (TBpassword.Text.Length == 0)
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            try
            {
                this.dbo_UserTableAdapter.InsertUser(TBuserName.Text, MD5.MDString(TBpassword.Text), TBright.Text);
            }
            catch
            {
                MessageBox.Show("连接数据库失败！请确保网络可用！");
                return;
            }
            string systime = System.DateTime.Now.ToString("yy-MM-dd");//  //"10-06-11";
            // System.DateTime.Now.ToString("yy-MM-dd");

            string strSQL = "SELECT UserID AS '用户ID', UserName AS '用户名', UserRight AS '用户权限' FROM [dbo.User]";
            string strTable = " [db_rfidtest].[rfidtest].[dbo.user]";

            try
            {
                ds = boperate.getds(strSQL, strTable);
            }
            catch
            {
                MessageBox.Show("网络连接失败！请稍后重试");
                //showDayreport.CancelAsync();
            }
            dataGridView4.DataSource = ds.Tables[0];

        }

        private void bnUpateUser_Click(object sender, EventArgs e)
        {
            if (TBuserName.Text.Length == 0)
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (TBright.Text.Length == 0)
            {
                MessageBox.Show("权限不能为空！");
                return;
            }
            try
            {
                this.dbo_UserTableAdapter.UpdateInfo(TBuserName.Text, TBright.Text, int.Parse(UserID.Text));
            }
            catch
            {
                MessageBox.Show("连接数据库失败！请确保网络可用！");
                return;
            }
            string systime = System.DateTime.Now.ToString("yy-MM-dd");//  //"10-06-11";
            // System.DateTime.Now.ToString("yy-MM-dd");

            string strSQL = "SELECT UserID AS '用户ID', UserName AS '用户名', UserRight AS '用户权限' FROM [dbo.User]";
            string strTable = " [db_rfidtest].[rfidtest].[dbo.user]";

            try
            {
                ds = boperate.getds(strSQL, strTable);
            }
            catch
            {
                MessageBox.Show("网络连接失败！请稍后重试");
                //showDayreport.CancelAsync();
            }
            dataGridView4.DataSource = ds.Tables[0];

        }

        private void BnUpdatePW_Click(object sender, EventArgs e)
        {
            if (UserID.Text.Length == 0)
            {
                MessageBox.Show("请选择要重置的用户！");
                return;
            }
            try
            {
                this.dbo_UserTableAdapter.UpdatePWD(MD5.MDString("123456"), int.Parse(UserID.Text));
            }
            catch
            {
                MessageBox.Show("连接数据库失败！请确保网络可用！");
            }
            MessageBox.Show("重置密码成功，重置后的密码为123456！");
        }


        private void bnDelUser_Click_1(object sender, EventArgs e)
        {
            if (UserID.Text.Length == 0)
            {
                MessageBox.Show("请选择要删除的用户！");
                return;
            }
            try
            {
                this.dbo_UserTableAdapter.DeleteByID(int.Parse(UserID.Text));
            }
            catch
            {
                MessageBox.Show("连接数据库失败！请确保网络可用！");
                return;
            }
            string systime = System.DateTime.Now.ToString("yy-MM-dd");//  //"10-06-11";
            // System.DateTime.Now.ToString("yy-MM-dd");

            string strSQL = "SELECT UserID AS '用户ID', UserName AS '用户名', UserRight AS '用户权限' FROM [dbo.User]";
            string strTable = " [db_rfidtest].[rfidtest].[dbo.user]";

            try
            {
                ds = boperate.getds(strSQL, strTable);
            }
            catch
            {
                MessageBox.Show("网络连接失败！请稍后重试");
                //showDayreport.CancelAsync();
            }
            dataGridView4.DataSource = ds.Tables[0];
        }
        #endregion

        #region 转运中心数据查询


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            string systime = dateTimePicker1.Value.ToString("yy-MM-dd");

            showDayreport.ReportProgress(30);
            string strSQL = "SELECT DISTINCT  [db_rfidtest].[rfidtest].[dbo.Station].[Name] AS '起始站点' , " +
                " [db_rfidtest].[rfidtest].[dbo.Goods].[BoxCardID] AS '货箱卡号' ,  " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[TruckNo] AS '货车牌号' ,  " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[StartTime] AS '开始时间' ,  " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[EndTime] AS '结束时间' ,  [db_rfidtest].[rfidtest].[dbo.Goods].[Weight] AS '重量(单位:吨)'" +
                " FROM  [db_rfidtest].[rfidtest].[dbo.Goods] INNER JOIN  [db_rfidtest].[rfidtest].[dbo.Station] ON   " +
                "[db_rfidtest].[rfidtest].[dbo.Goods].[StartStationID] = [db_rfidtest].[rfidtest].[dbo.Station].[StationID] " +
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
            debugtextbox.Text += e.ProgressPercentage.ToString() + ".";

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
            Dayreport = "http://chart.apis.google.com/chart?cht=ls" +
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
                    string p1, p2;
                    if (i < 10)
                        p1 = dateTimePicker1.Value.ToString("yy-MM-dd") + ",0" + i.ToString();
                    else
                        p1 = dateTimePicker1.Value.ToString("yy-MM-dd") + "," + i.ToString();
                    if ((i + 1) < 10)
                        p2 = dateTimePicker1.Value.ToString("yy-MM-dd") + ",0" + (i + 1).ToString();
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
            debugtextbox.Text += "    " + Dayreport;
            progressBar1.Visible = false;
            pictureBox2.ImageLocation = Dayreport;
            pictureBox2.Load();
        }

        void showDayImagereport_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            debugtextbox.Text += e.ProgressPercentage.ToString() + ".";

        }
        #endregion


        







    }
}
