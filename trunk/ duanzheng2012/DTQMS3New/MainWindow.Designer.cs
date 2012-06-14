namespace DTQMS3New
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panelTtile = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.lblSumWeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupCard = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblStartStation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.dgvMsg = new System.Windows.Forms.DataGridView();
            this.StartStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TruckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bgwUpdateUI = new System.ComponentModel.BackgroundWorker();
            this.xDview = new AxXDVIEWLib.AxXDView();
            this.panelTtile.SuspendLayout();
            this.groupCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDview)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTtile
            // 
            this.panelTtile.BackColor = System.Drawing.Color.Transparent;
            this.panelTtile.Controls.Add(this.lblError);
            this.panelTtile.Controls.Add(this.lblSumWeight);
            this.panelTtile.Controls.Add(this.label3);
            this.panelTtile.Controls.Add(this.lblSum);
            this.panelTtile.Controls.Add(this.label2);
            this.panelTtile.Controls.Add(this.lblStation);
            this.panelTtile.Controls.Add(this.label1);
            this.panelTtile.Location = new System.Drawing.Point(0, 0);
            this.panelTtile.Name = "panelTtile";
            this.panelTtile.Size = new System.Drawing.Size(1024, 65);
            this.panelTtile.TabIndex = 0;
            this.panelTtile.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTtile_Paint);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(769, 20);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 28);
            this.lblError.TabIndex = 6;
            // 
            // lblSumWeight
            // 
            this.lblSumWeight.AutoSize = true;
            this.lblSumWeight.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSumWeight.ForeColor = System.Drawing.Color.Orange;
            this.lblSumWeight.Location = new System.Drawing.Point(682, 20);
            this.lblSumWeight.Name = "lblSumWeight";
            this.lblSumWeight.Size = new System.Drawing.Size(45, 28);
            this.lblSumWeight.TabIndex = 5;
            this.lblSumWeight.Text = "0吨";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(498, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "今日运输总重量：";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSum.ForeColor = System.Drawing.Color.Orange;
            this.lblSum.Location = new System.Drawing.Point(408, 20);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(45, 28);
            this.lblSum.TabIndex = 3;
            this.lblSum.Text = "0次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(224, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "今日运输总车次：";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStation.ForeColor = System.Drawing.Color.Orange;
            this.lblStation.Location = new System.Drawing.Point(144, 20);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(33, 28);
            this.lblStation.TabIndex = 1;
            this.lblStation.Text = "无";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "转运中心：";
            // 
            // groupCard
            // 
            this.groupCard.BackColor = System.Drawing.Color.Transparent;
            this.groupCard.Controls.Add(this.lblType);
            this.groupCard.Controls.Add(this.lblTruck);
            this.groupCard.Controls.Add(this.lblEndTime);
            this.groupCard.Controls.Add(this.lblStartTime);
            this.groupCard.Controls.Add(this.lblStartStation);
            this.groupCard.Controls.Add(this.label8);
            this.groupCard.Controls.Add(this.label7);
            this.groupCard.Controls.Add(this.label6);
            this.groupCard.Controls.Add(this.label5);
            this.groupCard.Controls.Add(this.label4);
            this.groupCard.ForeColor = System.Drawing.Color.White;
            this.groupCard.Location = new System.Drawing.Point(0, 67);
            this.groupCard.Name = "groupCard";
            this.groupCard.Size = new System.Drawing.Size(1024, 344);
            this.groupCard.TabIndex = 1;
            this.groupCard.TabStop = false;
            this.groupCard.Text = "刷卡信息";
            this.groupCard.Enter += new System.EventHandler(this.groupCard_Enter);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(762, 266);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 38);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "无";
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTruck.ForeColor = System.Drawing.Color.White;
            this.lblTruck.Location = new System.Drawing.Point(188, 266);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(46, 38);
            this.lblTruck.TabIndex = 8;
            this.lblTruck.Text = "无";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime.ForeColor = System.Drawing.Color.White;
            this.lblEndTime.Location = new System.Drawing.Point(762, 54);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(46, 38);
            this.lblEndTime.TabIndex = 7;
            this.lblEndTime.Text = "无";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime.ForeColor = System.Drawing.Color.White;
            this.lblStartTime.Location = new System.Drawing.Point(217, 54);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(46, 38);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "无";
            // 
            // lblStartStation
            // 
            this.lblStartStation.AutoSize = true;
            this.lblStartStation.Font = new System.Drawing.Font("微软雅黑", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartStation.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblStartStation.Location = new System.Drawing.Point(323, 108);
            this.lblStartStation.Name = "lblStartStation";
            this.lblStartStation.Size = new System.Drawing.Size(148, 124);
            this.lblStartStation.TabIndex = 5;
            this.lblStartStation.Text = "无";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(176, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 38);
            this.label8.TabIndex = 4;
            this.label8.Text = "始发站：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(598, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 38);
            this.label7.TabIndex = 3;
            this.label7.Text = "垃圾类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(53, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 38);
            this.label6.TabIndex = 2;
            this.label6.Text = "车牌号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(598, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 38);
            this.label5.TabIndex = 1;
            this.label5.Text = "到达时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(53, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "起始时间：";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(3, 417);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScrollBarsEnabled = false;
            this.webBrowser.Size = new System.Drawing.Size(466, 366);
            this.webBrowser.TabIndex = 2;
            // 
            // dgvMsg
            // 
            this.dgvMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartStation,
            this.StartTime,
            this.EndTime,
            this.TruckNo,
            this.ID,
            this.Type});
            this.dgvMsg.Location = new System.Drawing.Point(487, 417);
            this.dgvMsg.Name = "dgvMsg";
            this.dgvMsg.RowTemplate.Height = 23;
            this.dgvMsg.Size = new System.Drawing.Size(534, 203);
            this.dgvMsg.TabIndex = 3;
            // 
            // StartStation
            // 
            this.StartStation.DataPropertyName = "StartStationName";
            this.StartStation.HeaderText = "起始站";
            this.StartStation.Name = "StartStation";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "起始时间";
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "结束时间";
            this.EndTime.Name = "EndTime";
            // 
            // TruckNo
            // 
            this.TruckNo.DataPropertyName = "TruckNo";
            this.TruckNo.HeaderText = "车牌号";
            this.TruckNo.Name = "TruckNo";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "id";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "垃圾类型";
            this.Type.Name = "Type";
            // 
            // xDview
            // 
            this.xDview.Enabled = true;
            this.xDview.Location = new System.Drawing.Point(487, 626);
            this.xDview.Name = "xDview";
            this.xDview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("xDview.OcxState")));
            this.xDview.Size = new System.Drawing.Size(534, 148);
            this.xDview.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 786);
            this.Controls.Add(this.xDview);
            this.Controls.Add(this.dgvMsg);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.groupCard);
            this.Controls.Add(this.panelTtile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.panelTtile.ResumeLayout(false);
            this.panelTtile.PerformLayout();
            this.groupCard.ResumeLayout(false);
            this.groupCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTtile;
        private System.Windows.Forms.GroupBox groupCard;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSumWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblStartStation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvMsg;
        private System.ComponentModel.BackgroundWorker bgwUpdateUI;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TruckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private AxXDVIEWLib.AxXDView xDview;
    }
}