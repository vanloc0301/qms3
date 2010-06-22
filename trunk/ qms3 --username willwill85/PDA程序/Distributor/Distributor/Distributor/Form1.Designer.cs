namespace Distributor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tbStartSpotNum = new System.Windows.Forms.TextBox();
            this.lbStartSpotNum = new System.Windows.Forms.Label();
            this.labCarNum = new System.Windows.Forms.Label();
            this.tbCarNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pbReadBoxCard = new System.Windows.Forms.PictureBox();
            this.pbReadCarCard = new System.Windows.Forms.PictureBox();
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_rfidtestDataSet = new Distributor.db_rfidtestDataSet();
            this.dboGoodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dboDriverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transpoartSystemDataSet = new Distributor.TranspoartSystemDataSet();
            this.driverTableAdapter = new Distributor.TranspoartSystemDataSetTableAdapters.DriverTableAdapter();
            this.boxTableAdapter = new Distributor.TranspoartSystemDataSetTableAdapters.BoxTableAdapter();
            this.goodsTableAdapter = new Distributor.TranspoartSystemDataSetTableAdapters.GoodsTableAdapter();
            this.driverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbo_BoxTableAdapter1 = new Distributor.db_rfidtestDataSetTableAdapters.dbo_BoxTableAdapter();
            this.dbo_DriverTableAdapter1 = new Distributor.db_rfidtestDataSetTableAdapters.dbo_DriverTableAdapter();
            this.dbo_GoodsTableAdapter1 = new Distributor.db_rfidtestDataSetTableAdapters.dbo_GoodsTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.bat = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LBStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboGoodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboDriverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStartSpotNum
            // 
            this.tbStartSpotNum.Location = new System.Drawing.Point(97, 23);
            this.tbStartSpotNum.Name = "tbStartSpotNum";
            this.tbStartSpotNum.ReadOnly = true;
            this.tbStartSpotNum.Size = new System.Drawing.Size(112, 21);
            this.tbStartSpotNum.TabIndex = 2;
            // 
            // lbStartSpotNum
            // 
            this.lbStartSpotNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbStartSpotNum.ForeColor = System.Drawing.Color.White;
            this.lbStartSpotNum.Location = new System.Drawing.Point(3, 24);
            this.lbStartSpotNum.Name = "lbStartSpotNum";
            this.lbStartSpotNum.Size = new System.Drawing.Size(88, 20);
            this.lbStartSpotNum.Text = "本站站号：";
            // 
            // labCarNum
            // 
            this.labCarNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labCarNum.ForeColor = System.Drawing.Color.White;
            this.labCarNum.Location = new System.Drawing.Point(4, 58);
            this.labCarNum.Name = "labCarNum";
            this.labCarNum.Size = new System.Drawing.Size(100, 20);
            this.labCarNum.Text = "车牌号：";
            // 
            // tbCarNum
            // 
            this.tbCarNum.Location = new System.Drawing.Point(97, 58);
            this.tbCarNum.Name = "tbCarNum";
            this.tbCarNum.Size = new System.Drawing.Size(112, 21);
            this.tbCarNum.TabIndex = 5;
            this.tbCarNum.TextChanged += new System.EventHandler(this.tbCarNum_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "x";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbReadBoxCard
            // 
            this.pbReadBoxCard.BackColor = System.Drawing.Color.Transparent;
            this.pbReadBoxCard.Image = ((System.Drawing.Image)(resources.GetObject("pbReadBoxCard.Image")));
            this.pbReadBoxCard.Location = new System.Drawing.Point(121, 139);
            this.pbReadBoxCard.Name = "pbReadBoxCard";
            this.pbReadBoxCard.Size = new System.Drawing.Size(88, 110);
            this.pbReadBoxCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReadBoxCard.Click += new System.EventHandler(this.pbReadBoxCard_Click);
            this.pbReadBoxCard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbReadBoxCard_MouseDown);
            // 
            // pbReadCarCard
            // 
            this.pbReadCarCard.BackColor = System.Drawing.Color.SlateBlue;
            this.pbReadCarCard.Enabled = false;
            this.pbReadCarCard.Image = ((System.Drawing.Image)(resources.GetObject("pbReadCarCard.Image")));
            this.pbReadCarCard.Location = new System.Drawing.Point(16, 139);
            this.pbReadCarCard.Name = "pbReadCarCard";
            this.pbReadCarCard.Size = new System.Drawing.Size(88, 110);
            this.pbReadCarCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReadCarCard.Click += new System.EventHandler(this.pbReadCarCard_Click);
            this.pbReadCarCard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbReadCarCard_MouseDown);
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataSource = this.db_rfidtestDataSet;
            this.goodsBindingSource.Position = 0;
            // 
            // db_rfidtestDataSet
            // 
            this.db_rfidtestDataSet.DataSetName = "db_rfidtestDataSet";
            this.db_rfidtestDataSet.Prefix = "";
            this.db_rfidtestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dboGoodsBindingSource
            // 
            this.dboGoodsBindingSource.DataMember = "dbo.Goods";
            this.dboGoodsBindingSource.DataSource = this.goodsBindingSource;
            // 
            // dboBoxBindingSource
            // 
            this.dboBoxBindingSource.DataMember = "dbo.Box";
            this.dboBoxBindingSource.DataSource = this.goodsBindingSource;
            // 
            // dboDriverBindingSource
            // 
            this.dboDriverBindingSource.DataMember = "dbo.Driver";
            this.dboDriverBindingSource.DataSource = this.goodsBindingSource;
            // 
            // transpoartSystemDataSet
            // 
            this.transpoartSystemDataSet.DataSetName = "TranspoartSystemDataSet";
            this.transpoartSystemDataSet.Prefix = "";
            this.transpoartSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // driverTableAdapter
            // 
            this.driverTableAdapter.ClearBeforeFill = true;
            // 
            // boxTableAdapter
            // 
            this.boxTableAdapter.ClearBeforeFill = true;
            // 
            // goodsTableAdapter
            // 
            this.goodsTableAdapter.ClearBeforeFill = true;
            // 
            // driverBindingSource
            // 
            this.driverBindingSource.DataMember = "dbo.Driver";
            this.driverBindingSource.DataSource = this.db_rfidtestDataSet;
            // 
            // boxBindingSource
            // 
            this.boxBindingSource.DataMember = "dbo.Box";
            this.boxBindingSource.DataSource = this.db_rfidtestDataSet;
            // 
            // dbo_BoxTableAdapter1
            // 
            this.dbo_BoxTableAdapter1.ClearBeforeFill = true;
            // 
            // dbo_DriverTableAdapter1
            // 
            this.dbo_DriverTableAdapter1.ClearBeforeFill = true;
            // 
            // dbo_GoodsTableAdapter1
            // 
            this.dbo_GoodsTableAdapter1.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(81, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(66, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 108);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bat
            // 
            this.bat.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bat.ForeColor = System.Drawing.Color.White;
            this.bat.Location = new System.Drawing.Point(3, 91);
            this.bat.Name = "bat";
            this.bat.Size = new System.Drawing.Size(100, 20);
            this.bat.Text = "电量：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 270);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(237, 10);
            this.progressBar1.Visible = false;
            // 
            // LBStatus
            // 
            this.LBStatus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.LBStatus.ForeColor = System.Drawing.Color.White;
            this.LBStatus.Location = new System.Drawing.Point(0, 252);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(171, 15);
            this.LBStatus.Text = "状态";
            this.LBStatus.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LBStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbCarNum);
            this.Controls.Add(this.labCarNum);
            this.Controls.Add(this.lbStartSpotNum);
            this.Controls.Add(this.tbStartSpotNum);
            this.Controls.Add(this.pbReadBoxCard);
            this.Controls.Add(this.pbReadCarCard);
            this.Controls.Add(this.bat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "西城区环境卫生服务中心垃圾楼终端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboGoodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboBoxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboDriverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbReadCarCard;
        private System.Windows.Forms.PictureBox pbReadBoxCard;
        private System.Windows.Forms.TextBox tbStartSpotNum;
        private System.Windows.Forms.Label lbStartSpotNum;
        private System.Windows.Forms.Label labCarNum;
        private System.Windows.Forms.TextBox tbCarNum;
        private System.Windows.Forms.Button button1;
        private TranspoartSystemDataSet transpoartSystemDataSet;
        private System.Windows.Forms.BindingSource driverBindingSource;
        private Distributor.TranspoartSystemDataSetTableAdapters.DriverTableAdapter driverTableAdapter;
        private System.Windows.Forms.BindingSource boxBindingSource;
        private Distributor.TranspoartSystemDataSetTableAdapters.BoxTableAdapter boxTableAdapter;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private Distributor.TranspoartSystemDataSetTableAdapters.GoodsTableAdapter goodsTableAdapter;
        private db_rfidtestDataSet db_rfidtestDataSet;
        private Distributor.db_rfidtestDataSetTableAdapters.dbo_BoxTableAdapter dbo_BoxTableAdapter1;
        private Distributor.db_rfidtestDataSetTableAdapters.dbo_DriverTableAdapter dbo_DriverTableAdapter1;
        private Distributor.db_rfidtestDataSetTableAdapters.dbo_GoodsTableAdapter dbo_GoodsTableAdapter1;
        private System.Windows.Forms.BindingSource dboGoodsBindingSource;
        private System.Windows.Forms.BindingSource dboBoxBindingSource;
        private System.Windows.Forms.BindingSource dboDriverBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label bat;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LBStatus;
    }
}

