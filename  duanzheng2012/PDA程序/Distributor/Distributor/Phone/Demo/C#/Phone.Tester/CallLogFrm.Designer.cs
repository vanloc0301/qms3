namespace SEUIC.Phone.Tester
{
    partial class CallLogFrm
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
            this.lvCallLog = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colDBID = new System.Windows.Forms.ColumnHeader();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colStartTime = new System.Windows.Forms.ColumnHeader();
            this.colEndTime = new System.Windows.Forms.ColumnHeader();
            this.colCallType = new System.Windows.Forms.ColumnHeader();
            this.colOutGoing = new System.Windows.Forms.ColumnHeader();
            this.colConnected = new System.Windows.Forms.ColumnHeader();
            this.colEnded = new System.Windows.Forms.ColumnHeader();
            this.colRoaming = new System.Windows.Forms.ColumnHeader();
            this.colCallIDType = new System.Windows.Forms.ColumnHeader();
            this.colNameType = new System.Windows.Forms.ColumnHeader();
            this.colNote = new System.Windows.Forms.ColumnHeader();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.colReaded = new System.Windows.Forms.ColumnHeader();
            this.btnMissedAsReaded = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCallLog
            // 
            this.lvCallLog.Columns.Add(this.colID);
            this.lvCallLog.Columns.Add(this.colDBID);
            this.lvCallLog.Columns.Add(this.colNumber);
            this.lvCallLog.Columns.Add(this.colName);
            this.lvCallLog.Columns.Add(this.colStartTime);
            this.lvCallLog.Columns.Add(this.colEndTime);
            this.lvCallLog.Columns.Add(this.colCallType);
            this.lvCallLog.Columns.Add(this.colOutGoing);
            this.lvCallLog.Columns.Add(this.colConnected);
            this.lvCallLog.Columns.Add(this.colEnded);
            this.lvCallLog.Columns.Add(this.colRoaming);
            this.lvCallLog.Columns.Add(this.colCallIDType);
            this.lvCallLog.Columns.Add(this.colNameType);
            this.lvCallLog.Columns.Add(this.colNote);
            this.lvCallLog.Columns.Add(this.colReaded);
            this.lvCallLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvCallLog.Location = new System.Drawing.Point(0, 0);
            this.lvCallLog.Name = "lvCallLog";
            this.lvCallLog.Size = new System.Drawing.Size(238, 239);
            this.lvCallLog.TabIndex = 0;
            this.lvCallLog.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 30;
            // 
            // colDBID
            // 
            this.colDBID.Text = "DBID";
            this.colDBID.Width = 30;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colStartTime
            // 
            this.colStartTime.Text = "StartTime";
            this.colStartTime.Width = 100;
            // 
            // colEndTime
            // 
            this.colEndTime.Text = "EndTime";
            this.colEndTime.Width = 100;
            // 
            // colCallType
            // 
            this.colCallType.Text = "CallType";
            this.colCallType.Width = 100;
            // 
            // colOutGoing
            // 
            this.colOutGoing.Text = "OutGoing";
            this.colOutGoing.Width = 30;
            // 
            // colConnected
            // 
            this.colConnected.Text = "Connetcted";
            this.colConnected.Width = 30;
            // 
            // colEnded
            // 
            this.colEnded.Text = "Ended";
            this.colEnded.Width = 30;
            // 
            // colRoaming
            // 
            this.colRoaming.Text = "Roaming";
            this.colRoaming.Width = 30;
            // 
            // colCallIDType
            // 
            this.colCallIDType.Text = "CallIDType";
            this.colCallIDType.Width = 60;
            // 
            // colNameType
            // 
            this.colNameType.Text = "NameType";
            this.colNameType.Width = 100;
            // 
            // colNote
            // 
            this.colNote.Text = "Note";
            this.colNote.Width = 100;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 246);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 20);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(63, 246);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(54, 20);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // colReaded
            // 
            this.colReaded.Text = "Readed";
            this.colReaded.Width = 60;
            // 
            // btnMissedAsReaded
            // 
            this.btnMissedAsReaded.Location = new System.Drawing.Point(123, 245);
            this.btnMissedAsReaded.Name = "btnMissedAsReaded";
            this.btnMissedAsReaded.Size = new System.Drawing.Size(99, 20);
            this.btnMissedAsReaded.TabIndex = 2;
            this.btnMissedAsReaded.Text = "MissedAsReaded";
            this.btnMissedAsReaded.Click += new System.EventHandler(this.btnMissedAsReaded_Click);
            // 
            // CallLogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.btnMissedAsReaded);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lvCallLog);
            this.Name = "CallLogFrm";
            this.Text = "CallLogFrm";
            this.Load += new System.EventHandler(this.CallLogFrm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CallLogFrm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCallLog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDBID;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colEndTime;
        private System.Windows.Forms.ColumnHeader colCallType;
        private System.Windows.Forms.ColumnHeader colOutGoing;
        private System.Windows.Forms.ColumnHeader colConnected;
        private System.Windows.Forms.ColumnHeader colEnded;
        private System.Windows.Forms.ColumnHeader colRoaming;
        private System.Windows.Forms.ColumnHeader colCallIDType;
        private System.Windows.Forms.ColumnHeader colNameType;
        private System.Windows.Forms.ColumnHeader colNote;
        private System.Windows.Forms.ColumnHeader colReaded;
        private System.Windows.Forms.Button btnMissedAsReaded;
    }
}