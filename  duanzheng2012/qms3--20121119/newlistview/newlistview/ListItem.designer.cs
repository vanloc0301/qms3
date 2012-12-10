namespace newlistview
{
    partial class ListItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListItem));
            this.t1 = new System.Windows.Forms.Label();
            this.Lid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LstationName = new System.Windows.Forms.Label();
            this.Lweight = new System.Windows.Forms.Label();
            this.Lnum = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Lnet = new System.Windows.Forms.Label();
            this.Lcam = new System.Windows.Forms.Label();
            this.Lpda = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateState = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // t1
            // 
            this.t1.AutoSize = true;
            this.t1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.t1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.t1.Location = new System.Drawing.Point(19, 6);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(31, 21);
            this.t1.TabIndex = 0;
            this.t1.Text = "ID:";
            // 
            // Lid
            // 
            this.Lid.AutoSize = true;
            this.Lid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lid.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Lid.Location = new System.Drawing.Point(56, 6);
            this.Lid.Name = "Lid";
            this.Lid.Size = new System.Drawing.Size(70, 21);
            this.Lid.TabIndex = 1;
            this.Lid.Text = "加载中...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(156, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "清洁站名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(155, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "今日运输总重量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(154, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "今日运输总箱数：";
            // 
            // LstationName
            // 
            this.LstationName.AutoSize = true;
            this.LstationName.Font = new System.Drawing.Font("隶书", 35.75F);
            this.LstationName.ForeColor = System.Drawing.Color.ForestGreen;
            this.LstationName.Location = new System.Drawing.Point(172, 30);
            this.LstationName.Name = "LstationName";
            this.LstationName.Size = new System.Drawing.Size(236, 48);
            this.LstationName.TabIndex = 5;
            this.LstationName.Text = "加载中...";
            // 
            // Lweight
            // 
            this.Lweight.AutoSize = true;
            this.Lweight.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.Lweight.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lweight.Location = new System.Drawing.Point(332, 81);
            this.Lweight.Name = "Lweight";
            this.Lweight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lweight.Size = new System.Drawing.Size(24, 27);
            this.Lweight.TabIndex = 6;
            this.Lweight.Text = "0";
            // 
            // Lnum
            // 
            this.Lnum.AutoSize = true;
            this.Lnum.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.Lnum.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Lnum.Location = new System.Drawing.Point(332, 111);
            this.Lnum.Name = "Lnum";
            this.Lnum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lnum.Size = new System.Drawing.Size(24, 27);
            this.Lnum.TabIndex = 7;
            this.Lnum.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(373, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 27);
            this.label8.TabIndex = 8;
            this.label8.Text = "吨";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(373, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 27);
            this.label9.TabIndex = 9;
            this.label9.Text = "箱";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(151, 152);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(277, 152);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // Lnet
            // 
            this.Lnet.AutoSize = true;
            this.Lnet.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lnet.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lnet.Location = new System.Drawing.Point(83, 161);
            this.Lnet.Name = "Lnet";
            this.Lnet.Size = new System.Drawing.Size(62, 31);
            this.Lnet.TabIndex = 14;
            this.Lnet.Text = "正常";
            // 
            // Lcam
            // 
            this.Lcam.AutoSize = true;
            this.Lcam.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lcam.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lcam.Location = new System.Drawing.Point(209, 161);
            this.Lcam.Name = "Lcam";
            this.Lcam.Size = new System.Drawing.Size(62, 31);
            this.Lcam.TabIndex = 15;
            this.Lcam.Text = "正常";
            // 
            // Lpda
            // 
            this.Lpda.AutoSize = true;
            this.Lpda.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lpda.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lpda.Location = new System.Drawing.Point(331, 161);
            this.Lpda.Name = "Lpda";
            this.Lpda.Size = new System.Drawing.Size(62, 31);
            this.Lpda.TabIndex = 16;
            this.Lpda.Text = "正常";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 100000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrUpdateState
            // 
            this.tmrUpdateState.Enabled = true;
            this.tmrUpdateState.Interval = 1000;
            this.tmrUpdateState.Tick += new System.EventHandler(this.tmrUpdateState_Tick);
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Lpda);
            this.Controls.Add(this.Lcam);
            this.Controls.Add(this.Lnet);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Lnum);
            this.Controls.Add(this.Lweight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Lid);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.LstationName);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(422, 212);
            this.Load += new System.EventHandler(this.ListItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label Lid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LstationName;
        private System.Windows.Forms.Label Lweight;
        private System.Windows.Forms.Label Lnum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label Lnet;
        private System.Windows.Forms.Label Lcam;
        private System.Windows.Forms.Label Lpda;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmrUpdateState;
    }
}
