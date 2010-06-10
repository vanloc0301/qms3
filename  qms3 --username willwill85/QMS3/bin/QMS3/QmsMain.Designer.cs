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
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("发卡");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("编辑");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("查询");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("司机卡管理", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("发卡");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("编辑");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("查询");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("箱卡管理", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("车辆状态查询");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("垃圾楼状态查询");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("转运中心查询");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("转运中心操作");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("西城区数据分析");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("异常数据处理");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("用户管理");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("垃圾楼管理");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("班长管理");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("报表生成器");
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonlogin = new System.Windows.Forms.Button();
            this.buttonlogout = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBoxpassword = new System.Windows.Forms.MaskedTextBox();
            this.textboxusername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(890, 519);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(882, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(882, 481);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 519);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 519);
            this.panel3.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textboxusername);
            this.groupBox1.Controls.Add(this.maskedTextBoxpassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.buttonlogout);
            this.groupBox1.Controls.Add(this.buttonlogin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户登录";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(204, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1101, 10);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作台";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            treeNode19.Name = "节点1";
            treeNode19.Text = "发卡";
            treeNode20.Checked = true;
            treeNode20.Name = "节点4";
            treeNode20.Text = "编辑";
            treeNode21.Name = "节点5";
            treeNode21.Text = "查询";
            treeNode22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode22.Checked = true;
            treeNode22.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode22.Name = "节点0";
            treeNode22.Text = "司机卡管理";
            treeNode23.Name = "节点0";
            treeNode23.Text = "发卡";
            treeNode24.Name = "节点3";
            treeNode24.Text = "编辑";
            treeNode25.Name = "节点4";
            treeNode25.Text = "查询";
            treeNode26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode26.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode26.Name = "节点2";
            treeNode26.Text = "箱卡管理";
            treeNode27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode27.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode27.Name = "节点5";
            treeNode27.Text = "车辆状态查询";
            treeNode28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode28.Name = "节点6";
            treeNode28.Text = "垃圾楼状态查询";
            treeNode29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode29.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode29.Name = "节点8";
            treeNode29.Text = "转运中心查询";
            treeNode30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode30.Name = "节点7";
            treeNode30.Text = "转运中心操作";
            treeNode31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode31.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode31.Name = "节点9";
            treeNode31.Text = "西城区数据分析";
            treeNode32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode32.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode32.Name = "节点10";
            treeNode32.Text = "异常数据处理";
            treeNode33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode33.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode33.Name = "节点11";
            treeNode33.Text = "用户管理";
            treeNode34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode34.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode34.Name = "节点12";
            treeNode34.Text = "垃圾楼管理";
            treeNode35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode35.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode35.Name = "节点13";
            treeNode35.Text = "班长管理";
            treeNode36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            treeNode36.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            treeNode36.Name = "节点14";
            treeNode36.Text = "报表生成器";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36});
            this.treeView1.Size = new System.Drawing.Size(194, 336);
            this.treeView1.TabIndex = 2;
            // 
            // buttonlogin
            // 
            this.buttonlogin.Location = new System.Drawing.Point(23, 119);
            this.buttonlogin.Name = "buttonlogin";
            this.buttonlogin.Size = new System.Drawing.Size(54, 23);
            this.buttonlogin.TabIndex = 0;
            this.buttonlogin.Text = "登录";
            this.buttonlogin.UseVisualStyleBackColor = true;
            // 
            // buttonlogout
            // 
            this.buttonlogout.Location = new System.Drawing.Point(121, 119);
            this.buttonlogout.Name = "buttonlogout";
            this.buttonlogout.Size = new System.Drawing.Size(55, 23);
            this.buttonlogout.TabIndex = 1;
            this.buttonlogout.Text = "注销";
            this.buttonlogout.UseVisualStyleBackColor = true;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(23, 26);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(47, 12);
            this.username.TabIndex = 2;
            this.username.Text = "用户名:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密  码:";
            // 
            // maskedTextBoxpassword
            // 
            this.maskedTextBoxpassword.Location = new System.Drawing.Point(76, 54);
            this.maskedTextBoxpassword.Name = "maskedTextBoxpassword";
            this.maskedTextBoxpassword.Size = new System.Drawing.Size(100, 21);
            this.maskedTextBoxpassword.TabIndex = 4;
            // 
            // textboxusername
            // 
            this.textboxusername.Location = new System.Drawing.Point(76, 23);
            this.textboxusername.Name = "textboxusername";
            this.textboxusername.Size = new System.Drawing.Size(100, 21);
            this.textboxusername.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "权限:";
            // 
            // QmsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QmsMain";
            this.Text = "西城环卫数据采集系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Button buttonlogout;
        private System.Windows.Forms.Button buttonlogin;
        private System.Windows.Forms.TextBox textboxusername;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxpassword;
        private System.Windows.Forms.Label label3;
    }
}

