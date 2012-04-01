namespace InfoView
{
    partial class InfoViewCarMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoViewCarMain));
            this.lblCarNo1 = new System.Windows.Forms.Label();
            this.lblStartTime1 = new System.Windows.Forms.Label();
            this.lblCarNo2 = new System.Windows.Forms.Label();
            this.lblStartTime2 = new System.Windows.Forms.Label();
            this.lblEndTime2 = new System.Windows.Forms.Label();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblEStation2 = new System.Windows.Forms.Label();
            this.lblSStation2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEndTime1 = new System.Windows.Forms.Label();
            this.lblEStation1 = new System.Windows.Forms.Label();
            this.lblSStation1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCarNo1
            // 
            this.lblCarNo1.AutoSize = true;
            this.lblCarNo1.BackColor = System.Drawing.Color.Transparent;
            this.lblCarNo1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCarNo1.ForeColor = System.Drawing.Color.Red;
            this.lblCarNo1.Location = new System.Drawing.Point(273, 108);
            this.lblCarNo1.Name = "lblCarNo1";
            this.lblCarNo1.Size = new System.Drawing.Size(166, 62);
            this.lblCarNo1.TabIndex = 6;
            this.lblCarNo1.Text = "label1";
            // 
            // lblStartTime1
            // 
            this.lblStartTime1.AutoSize = true;
            this.lblStartTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime1.ForeColor = System.Drawing.Color.Red;
            this.lblStartTime1.Location = new System.Drawing.Point(273, 474);
            this.lblStartTime1.Name = "lblStartTime1";
            this.lblStartTime1.Size = new System.Drawing.Size(166, 62);
            this.lblStartTime1.TabIndex = 6;
            this.lblStartTime1.Text = "label1";
            // 
            // lblCarNo2
            // 
            this.lblCarNo2.AutoSize = true;
            this.lblCarNo2.BackColor = System.Drawing.Color.Transparent;
            this.lblCarNo2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCarNo2.ForeColor = System.Drawing.Color.Green;
            this.lblCarNo2.Location = new System.Drawing.Point(273, 108);
            this.lblCarNo2.Name = "lblCarNo2";
            this.lblCarNo2.Size = new System.Drawing.Size(166, 62);
            this.lblCarNo2.TabIndex = 6;
            this.lblCarNo2.Text = "label1";
            // 
            // lblStartTime2
            // 
            this.lblStartTime2.AutoSize = true;
            this.lblStartTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblStartTime2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime2.ForeColor = System.Drawing.Color.Green;
            this.lblStartTime2.Location = new System.Drawing.Point(273, 474);
            this.lblStartTime2.Name = "lblStartTime2";
            this.lblStartTime2.Size = new System.Drawing.Size(166, 62);
            this.lblStartTime2.TabIndex = 6;
            this.lblStartTime2.Text = "label1";
            // 
            // lblEndTime2
            // 
            this.lblEndTime2.AutoSize = true;
            this.lblEndTime2.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime2.ForeColor = System.Drawing.Color.Green;
            this.lblEndTime2.Location = new System.Drawing.Point(273, 596);
            this.lblEndTime2.Name = "lblEndTime2";
            this.lblEndTime2.Size = new System.Drawing.Size(166, 62);
            this.lblEndTime2.TabIndex = 6;
            this.lblEndTime2.Text = "label1";
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 10000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(108, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1705, 815);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lblEndTime2);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.lblStartTime2);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.lblCarNo2);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.lblEStation2);
            this.panel4.Controls.Add(this.lblSStation2);
            this.panel4.Location = new System.Drawing.Point(965, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(615, 688);
            this.panel4.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(3, 596);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 62);
            this.label8.TabIndex = 7;
            this.label8.Text = "到达时间：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(51, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 62);
            this.label9.TabIndex = 7;
            this.label9.Text = "结束站：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(51, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(219, 62);
            this.label10.TabIndex = 7;
            this.label10.Text = "起始站：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 474);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(267, 62);
            this.label11.TabIndex = 7;
            this.label11.Text = "出发时间：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(51, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(219, 62);
            this.label12.TabIndex = 7;
            this.label12.Text = "车牌号：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(150, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(315, 62);
            this.label13.TabIndex = 7;
            this.label13.Text = "最近出发车辆";
            // 
            // lblEStation2
            // 
            this.lblEStation2.AutoSize = true;
            this.lblEStation2.BackColor = System.Drawing.Color.Transparent;
            this.lblEStation2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEStation2.ForeColor = System.Drawing.Color.Green;
            this.lblEStation2.Location = new System.Drawing.Point(273, 352);
            this.lblEStation2.Name = "lblEStation2";
            this.lblEStation2.Size = new System.Drawing.Size(166, 62);
            this.lblEStation2.TabIndex = 6;
            this.lblEStation2.Text = "label1";
            // 
            // lblSStation2
            // 
            this.lblSStation2.AutoSize = true;
            this.lblSStation2.BackColor = System.Drawing.Color.Transparent;
            this.lblSStation2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSStation2.ForeColor = System.Drawing.Color.Green;
            this.lblSStation2.Location = new System.Drawing.Point(273, 230);
            this.lblSStation2.Name = "lblSStation2";
            this.lblSStation2.Size = new System.Drawing.Size(166, 62);
            this.lblSStation2.TabIndex = 6;
            this.lblSStation2.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblStartTime1);
            this.panel3.Controls.Add(this.lblEndTime1);
            this.panel3.Controls.Add(this.lblEStation1);
            this.panel3.Controls.Add(this.lblSStation1);
            this.panel3.Controls.Add(this.lblCarNo1);
            this.panel3.Location = new System.Drawing.Point(113, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 688);
            this.panel3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 596);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 62);
            this.label5.TabIndex = 7;
            this.label5.Text = "到达时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(51, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 62);
            this.label7.TabIndex = 7;
            this.label7.Text = "结束站：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(51, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 62);
            this.label6.TabIndex = 7;
            this.label6.Text = "起始站：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 62);
            this.label4.TabIndex = 7;
            this.label4.Text = "出发时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(51, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 62);
            this.label3.TabIndex = 7;
            this.label3.Text = "车牌号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(150, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 62);
            this.label2.TabIndex = 7;
            this.label2.Text = "最近出发车辆";
            // 
            // lblEndTime1
            // 
            this.lblEndTime1.AutoSize = true;
            this.lblEndTime1.BackColor = System.Drawing.Color.Transparent;
            this.lblEndTime1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime1.ForeColor = System.Drawing.Color.Red;
            this.lblEndTime1.Location = new System.Drawing.Point(273, 596);
            this.lblEndTime1.Name = "lblEndTime1";
            this.lblEndTime1.Size = new System.Drawing.Size(123, 62);
            this.lblEndTime1.TabIndex = 6;
            this.lblEndTime1.Text = "未到";
            // 
            // lblEStation1
            // 
            this.lblEStation1.AutoSize = true;
            this.lblEStation1.BackColor = System.Drawing.Color.Transparent;
            this.lblEStation1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEStation1.ForeColor = System.Drawing.Color.Red;
            this.lblEStation1.Location = new System.Drawing.Point(273, 352);
            this.lblEStation1.Name = "lblEStation1";
            this.lblEStation1.Size = new System.Drawing.Size(123, 62);
            this.lblEStation1.TabIndex = 6;
            this.lblEStation1.Text = "未到";
            // 
            // lblSStation1
            // 
            this.lblSStation1.AutoSize = true;
            this.lblSStation1.BackColor = System.Drawing.Color.Transparent;
            this.lblSStation1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSStation1.ForeColor = System.Drawing.Color.Red;
            this.lblSStation1.Location = new System.Drawing.Point(273, 230);
            this.lblSStation1.Name = "lblSStation1";
            this.lblSStation1.Size = new System.Drawing.Size(166, 62);
            this.lblSStation1.TabIndex = 6;
            this.lblSStation1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(108, 953);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1705, 54);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(872, 843);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 62);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // InfoViewCarMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoViewCarMain";
            this.Text = "InfoViewCarMain";
            this.Load += new System.EventHandler(this.InfoViewCarMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoViewCarMain_Paint);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCarNo1;
        private System.Windows.Forms.Label lblStartTime1;
        private System.Windows.Forms.Label lblCarNo2;
        private System.Windows.Forms.Label lblStartTime2;
        private System.Windows.Forms.Label lblEndTime2;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEndTime1;
        private System.Windows.Forms.Label lblEStation1;
        private System.Windows.Forms.Label lblSStation1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblEStation2;
        private System.Windows.Forms.Label lblSStation2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}