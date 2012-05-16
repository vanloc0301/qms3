namespace SEUIC.Phone.Tester
{
    partial class SMSFrm
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
            this.lvSMS = new System.Windows.Forms.ListView();
            this.colIndex = new System.Windows.Forms.ColumnHeader();
            this.colDBID = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colNo = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colMsg = new System.Windows.Forms.ColumnHeader();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.tbSMSContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvSMS
            // 
            this.lvSMS.Columns.Add(this.colIndex);
            this.lvSMS.Columns.Add(this.colDBID);
            this.lvSMS.Columns.Add(this.colStatus);
            this.lvSMS.Columns.Add(this.colNo);
            this.lvSMS.Columns.Add(this.colTime);
            this.lvSMS.Columns.Add(this.colMsg);
            this.lvSMS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvSMS.Location = new System.Drawing.Point(0, 0);
            this.lvSMS.Name = "lvSMS";
            this.lvSMS.Size = new System.Drawing.Size(238, 178);
            this.lvSMS.TabIndex = 0;
            this.lvSMS.View = System.Windows.Forms.View.Details;
            this.lvSMS.SelectedIndexChanged += new System.EventHandler(this.lvSMS_SelectedIndexChanged);
            // 
            // colIndex
            // 
            this.colIndex.Text = "Index";
            this.colIndex.Width = 30;
            // 
            // colDBID
            // 
            this.colDBID.Text = "DBID";
            this.colDBID.Width = 30;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 120;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 120;
            // 
            // colMsg
            // 
            this.colMsg.Text = "Message";
            this.colMsg.Width = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 246);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 20);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(77, 246);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(72, 20);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(152, 246);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(82, 20);
            this.btnSaveDraft.TabIndex = 3;
            this.btnSaveDraft.Text = "SaveAsDraft";
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // tbSMSContent
            // 
            this.tbSMSContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSMSContent.Location = new System.Drawing.Point(0, 178);
            this.tbSMSContent.Multiline = true;
            this.tbSMSContent.Name = "tbSMSContent";
            this.tbSMSContent.Size = new System.Drawing.Size(238, 62);
            this.tbSMSContent.TabIndex = 4;
            // 
            // SMSFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.tbSMSContent);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lvSMS);
            this.Name = "SMSFrm";
            this.Text = "SMSFrm";
            this.Load += new System.EventHandler(this.SMSFrm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SMSFrm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSMS;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colMsg;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.ColumnHeader colDBID;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.TextBox tbSMSContent;
    }
}