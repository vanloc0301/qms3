namespace SEUIC.Phone.Tester
{
    partial class PhoneBookFrm
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
            this.lvPhoneBook = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colDBID = new System.Windows.Forms.ColumnHeader();
            this.colNo = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colUnit = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPhoneBook
            // 
            this.lvPhoneBook.Columns.Add(this.colID);
            this.lvPhoneBook.Columns.Add(this.colDBID);
            this.lvPhoneBook.Columns.Add(this.colNo);
            this.lvPhoneBook.Columns.Add(this.colName);
            this.lvPhoneBook.Columns.Add(this.colUnit);
            this.lvPhoneBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvPhoneBook.Location = new System.Drawing.Point(0, 0);
            this.lvPhoneBook.Name = "lvPhoneBook";
            this.lvPhoneBook.Size = new System.Drawing.Size(238, 159);
            this.lvPhoneBook.TabIndex = 0;
            this.lvPhoneBook.View = System.Windows.Forms.View.Details;
            this.lvPhoneBook.SelectedIndexChanged += new System.EventHandler(this.lvPhoneBook_SelectedIndexChanged);
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
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colUnit
            // 
            this.colUnit.Text = "Unit";
            this.colUnit.Width = 100;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "No";
            // 
            // tbNo
            // 
            this.tbNo.Location = new System.Drawing.Point(65, 164);
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(158, 23);
            this.tbNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(65, 190);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(158, 23);
            this.tbName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Unit";
            // 
            // tbUnit
            // 
            this.tbUnit.Location = new System.Drawing.Point(65, 216);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.Size = new System.Drawing.Size(158, 23);
            this.tbUnit.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(14, 245);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(54, 20);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(74, 245);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(48, 20);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 20);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(178, 245);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 20);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // PhoneBookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvPhoneBook);
            this.Name = "PhoneBookFrm";
            this.Text = "PhoneBookFrm";
            this.Load += new System.EventHandler(this.PhoneBookFrm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PhoneBookFrm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPhoneBook;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDBID;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
    }
}