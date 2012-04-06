using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSManager
{
    public partial class CsmMain : Form
    {
        public CsmMain()
        {
            InitializeComponent();
        }

        
        #region 登录系统

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //隐藏当前groupbox
            this.loginBox.Visible = false;
            //显示登录信息groupbox
            this.loginUserBox.Visible = true;

            //填充登录信息groupbox内容
            this.lblUser.Text = this.txtUser.Text;
            this.lblStation.Text = this.cbStation.Text;
            this.lblRight.Text = "0";


            //加载功能模块
            //loadFunction();

            //开启功能列表
            this.tvFunction.Enabled = true;
        }

        #endregion

        private void btnLoginout_Click(object sender, EventArgs e)
        {
            this.loginBox.Visible = true;

            this.loginUserBox.Visible = false;

            this.tvFunction.Enabled = false;
        }

        private void CsmMain_Load(object sender, EventArgs e)
        {
            this.MainTab.ItemSize = new Size(1,1);

            this.MainTab.SelectTab(6);

            this.MainTab.Region = new Region(new RectangleF(this.tpDayRpt.Left, this.tpDayRpt.Top, this.tpDayRpt.Width, this.tpDayRpt.Height));
        }

        private void tvFunction_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvFunction.SelectedNode == null)
                return;

            switch (this.tvFunction.SelectedNode.Text)
            {
                case "清洁站日清运进行情况":
                    this.MainTab.SelectTab(0);
                    break;
                case "按垃圾分类类型查询":
                    this.MainTab.SelectTab(2);
                    break;
                case "高分辨率遥感影像地图":
                    this.MainTab.SelectTab(1);
                    break;
                case "清洁站日报表":
                    this.MainTab.SelectTab(3);
                    break;
                case "清洁站月报表":
                    this.MainTab.SelectTab(4);
                    break;
                case "清洁站年报表":
                    this.MainTab.SelectTab(5);
                    break;
            }
        }




    }
}
