namespace QMS3
{
    partial class QmsMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("发司机卡");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("司机信息编辑");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("司机信息查询");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("司机卡管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("发货箱卡");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("货箱信息编辑");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("货箱信息查询");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("货箱卡管理", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("车辆状态信息查询");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("垃圾楼状态信息查询");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("转运中心状态信息查询");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("转运中心结算");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("西城区状态信息查询");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("异常数据处理器");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("垃圾楼管理");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("班长管理");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("报表生成器");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.t1label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.maskpanel = new System.Windows.Forms.Panel();
            this.Leftpanel = new System.Windows.Forms.Panel();
            this.MenugroupBox = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.LogingroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.debugtextbox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.db_rfidtestDataSet = new QMS3.db_rfidtestDataSet();
            this.dbo_BoxTableAdapter = new QMS3.db_rfidtestDataSetTableAdapters.dbo_BoxTableAdapter();
            this.dbo_DriverTableAdapter = new QMS3.db_rfidtestDataSetTableAdapters.dbo_DriverTableAdapter();
            this.dbo_GoodsTableAdapter = new QMS3.db_rfidtestDataSetTableAdapters.dbo_GoodsTableAdapter();
            this.dbo_StationTableAdapter = new QMS3.db_rfidtestDataSetTableAdapters.dbo_StationTableAdapter();
            this.dbo_UserTableAdapter = new QMS3.db_rfidtestDataSetTableAdapters.dbo_UserTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.Leftpanel.SuspendLayout();
            this.MenugroupBox.SuspendLayout();
            this.LogingroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1090, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::QMS3.Properties.Resources.logo21;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1090, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage15);
            this.tabControl1.Controls.Add(this.tabPage16);
            this.tabControl1.Controls.Add(this.tabPage17);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(850, 519);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.t1label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(842, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // t1label1
            // 
            this.t1label1.AutoSize = true;
            this.t1label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.t1label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t1label1.Location = new System.Drawing.Point(3, 3);
            this.t1label1.Name = "t1label1";
            this.t1label1.Size = new System.Drawing.Size(554, 21);
            this.t1label1.TabIndex = 0;
            this.t1label1.Text = "欢迎使用西城区环卫局数据采集系统，请先登录，然后点击操作管理界面操作";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(842, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(842, 481);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(842, 481);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(842, 481);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(842, 481);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(842, 481);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(842, 481);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 34);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(842, 481);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 34);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(842, 481);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            this.tabPage11.Location = new System.Drawing.Point(4, 34);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(842, 481);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "tabPage11";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            this.tabPage12.Location = new System.Drawing.Point(4, 34);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(842, 481);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "tabPage12";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            this.tabPage13.Location = new System.Drawing.Point(4, 34);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(842, 481);
            this.tabPage13.TabIndex = 12;
            this.tabPage13.Text = "tabPage13";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            this.tabPage14.Location = new System.Drawing.Point(4, 34);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(842, 481);
            this.tabPage14.TabIndex = 13;
            this.tabPage14.Text = "tabPage14";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // tabPage15
            // 
            this.tabPage15.Location = new System.Drawing.Point(4, 34);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(842, 481);
            this.tabPage15.TabIndex = 14;
            this.tabPage15.Text = "tabPage15";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            this.tabPage16.Location = new System.Drawing.Point(4, 34);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(842, 481);
            this.tabPage16.TabIndex = 15;
            this.tabPage16.Text = "tabPage16";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // tabPage17
            // 
            this.tabPage17.Location = new System.Drawing.Point(4, 34);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(842, 481);
            this.tabPage17.TabIndex = 16;
            this.tabPage17.Text = "tabPage17";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.tabControl1);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(240, 140);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(850, 519);
            this.CenterPanel.TabIndex = 3;
            // 
            // maskpanel
            // 
            this.maskpanel.Location = new System.Drawing.Point(238, 140);
            this.maskpanel.Name = "maskpanel";
            this.maskpanel.Size = new System.Drawing.Size(1272, 12);
            this.maskpanel.TabIndex = 0;
            // 
            // Leftpanel
            // 
            this.Leftpanel.Controls.Add(this.MenugroupBox);
            this.Leftpanel.Controls.Add(this.LogingroupBox);
            this.Leftpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Leftpanel.Location = new System.Drawing.Point(0, 140);
            this.Leftpanel.Name = "Leftpanel";
            this.Leftpanel.Size = new System.Drawing.Size(240, 519);
            this.Leftpanel.TabIndex = 4;
            // 
            // MenugroupBox
            // 
            this.MenugroupBox.Controls.Add(this.treeView1);
            this.MenugroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenugroupBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenugroupBox.Location = new System.Drawing.Point(0, 195);
            this.MenugroupBox.Name = "MenugroupBox";
            this.MenugroupBox.Size = new System.Drawing.Size(240, 324);
            this.MenugroupBox.TabIndex = 1;
            this.MenugroupBox.TabStop = false;
            this.MenugroupBox.Text = "操作管理";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.treeView1.Location = new System.Drawing.Point(3, 22);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "发司机卡";
            treeNode2.Checked = true;
            treeNode2.Name = "节点4";
            treeNode2.Text = "司机信息编辑";
            treeNode3.Name = "节点5";
            treeNode3.Text = "司机信息查询";
            treeNode4.Name = "节点0";
            treeNode4.Text = "司机卡管理";
            treeNode5.Name = "节点0";
            treeNode5.Text = "发货箱卡";
            treeNode6.Name = "节点1";
            treeNode6.Text = "货箱信息编辑";
            treeNode7.Name = "节点2";
            treeNode7.Text = "货箱信息查询";
            treeNode8.Name = "节点2";
            treeNode8.Text = "货箱卡管理";
            treeNode9.Name = "节点3";
            treeNode9.Text = "车辆状态信息查询";
            treeNode10.Name = "节点4";
            treeNode10.Text = "垃圾楼状态信息查询";
            treeNode11.Name = "节点5";
            treeNode11.Text = "转运中心状态信息查询";
            treeNode12.Name = "节点6";
            treeNode12.Text = "转运中心结算";
            treeNode13.Name = "节点7";
            treeNode13.Text = "西城区状态信息查询";
            treeNode14.Name = "节点8";
            treeNode14.Text = "异常数据处理器";
            treeNode15.Name = "节点9";
            treeNode15.Text = "用户管理";
            treeNode16.Name = "节点10";
            treeNode16.Text = "垃圾楼管理";
            treeNode17.Name = "节点11";
            treeNode17.Text = "班长管理";
            treeNode18.Name = "节点12";
            treeNode18.Text = "报表生成器";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.treeView1.Size = new System.Drawing.Size(234, 299);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect_1);
            // 
            // LogingroupBox
            // 
            this.LogingroupBox.Controls.Add(this.label5);
            this.LogingroupBox.Controls.Add(this.linkLabel1);
            this.LogingroupBox.Controls.Add(this.label4);
            this.LogingroupBox.Controls.Add(this.button2);
            this.LogingroupBox.Controls.Add(this.button1);
            this.LogingroupBox.Controls.Add(this.label3);
            this.LogingroupBox.Controls.Add(this.label1);
            this.LogingroupBox.Controls.Add(this.maskedTextBox1);
            this.LogingroupBox.Controls.Add(this.textBox1);
            this.LogingroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogingroupBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogingroupBox.Location = new System.Drawing.Point(0, 0);
            this.LogingroupBox.Name = "LogingroupBox";
            this.LogingroupBox.Size = new System.Drawing.Size(240, 195);
            this.LogingroupBox.TabIndex = 0;
            this.LogingroupBox.TabStop = false;
            this.LogingroupBox.Text = "用户登录";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "0";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(119, 110);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(79, 20);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "什么是权限";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "权限：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "注销";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(32, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "密   码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(90, 69);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '*';
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBox1.TabIndex = 1;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // debugtextbox
            // 
            this.debugtextbox.Location = new System.Drawing.Point(32, 23);
            this.debugtextbox.Multiline = true;
            this.debugtextbox.Name = "debugtextbox";
            this.debugtextbox.Size = new System.Drawing.Size(285, 81);
            this.debugtextbox.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.db_rfidtestDataSet;
            this.bindingSource1.Position = 0;
            // 
            // db_rfidtestDataSet
            // 
            this.db_rfidtestDataSet.DataSetName = "db_rfidtestDataSet";
            this.db_rfidtestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbo_BoxTableAdapter
            // 
            this.dbo_BoxTableAdapter.ClearBeforeFill = true;
            // 
            // dbo_DriverTableAdapter
            // 
            this.dbo_DriverTableAdapter.ClearBeforeFill = true;
            // 
            // dbo_GoodsTableAdapter
            // 
            this.dbo_GoodsTableAdapter.ClearBeforeFill = true;
            // 
            // dbo_StationTableAdapter
            // 
            this.dbo_StationTableAdapter.ClearBeforeFill = true;
            // 
            // dbo_UserTableAdapter
            // 
            this.dbo_UserTableAdapter.ClearBeforeFill = true;
            // 
            // QmsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 681);
            this.Controls.Add(this.debugtextbox);
            this.Controls.Add(this.maskpanel);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.Leftpanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "QmsMain";
            this.Text = "西城区环卫局数据采集系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            this.Leftpanel.ResumeLayout(false);
            this.MenugroupBox.ResumeLayout(false);
            this.LogingroupBox.ResumeLayout(false);
            this.LogingroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Panel maskpanel;
        private System.Windows.Forms.Label t1label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel Leftpanel;
        private System.Windows.Forms.GroupBox MenugroupBox;
        private System.Windows.Forms.GroupBox LogingroupBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.TextBox debugtextbox;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private db_rfidtestDataSet db_rfidtestDataSet;
        private db_rfidtestDataSetTableAdapters.dbo_BoxTableAdapter dbo_BoxTableAdapter;
        private db_rfidtestDataSetTableAdapters.dbo_DriverTableAdapter dbo_DriverTableAdapter;
        private db_rfidtestDataSetTableAdapters.dbo_GoodsTableAdapter dbo_GoodsTableAdapter;
        private db_rfidtestDataSetTableAdapters.dbo_StationTableAdapter dbo_StationTableAdapter;
        private db_rfidtestDataSetTableAdapters.dbo_UserTableAdapter dbo_UserTableAdapter;
    }
}

