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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.taskPIC = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NetPIC = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.timer2 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboGoodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dboDriverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "其它";
            this.comboBox1.Items.Add("其它");
            this.comboBox1.Items.Add("厨余垃圾");
            this.comboBox1.Items.Add("餐厨垃圾");
            this.comboBox1.Items.Add("可回收垃圾");
            this.comboBox1.Location = new System.Drawing.Point(97, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 22);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.ValueMember = "其它";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tbStartSpotNum
            // 
            this.tbStartSpotNum.Location = new System.Drawing.Point(97, 20);
            this.tbStartSpotNum.Name = "tbStartSpotNum";
            this.tbStartSpotNum.ReadOnly = true;
            this.tbStartSpotNum.Size = new System.Drawing.Size(112, 21);
            this.tbStartSpotNum.TabIndex = 2;
            // 
            // lbStartSpotNum
            // 
            this.lbStartSpotNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbStartSpotNum.ForeColor = System.Drawing.Color.White;
            this.lbStartSpotNum.Location = new System.Drawing.Point(0, 24);
            this.lbStartSpotNum.Name = "lbStartSpotNum";
            this.lbStartSpotNum.Size = new System.Drawing.Size(88, 20);
            this.lbStartSpotNum.Text = "本站站号：";
            // 
            // labCarNum
            // 
            this.labCarNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labCarNum.ForeColor = System.Drawing.Color.White;
            this.labCarNum.Location = new System.Drawing.Point(0, 43);
            this.labCarNum.Name = "labCarNum";
            this.labCarNum.Size = new System.Drawing.Size(100, 20);
            this.labCarNum.Text = "卡车牌号：";
            // 
            // tbCarNum
            // 
            this.tbCarNum.Location = new System.Drawing.Point(97, 43);
            this.tbCarNum.Name = "tbCarNum";
            this.tbCarNum.Size = new System.Drawing.Size(112, 21);
            this.tbCarNum.TabIndex = 5;
            this.tbCarNum.TextChanged += new System.EventHandler(this.tbCarNum_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 7;
            this.button1.Text = "x";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbReadBoxCard
            // 
            this.pbReadBoxCard.BackColor = System.Drawing.Color.Transparent;
            this.pbReadBoxCard.Image = ((System.Drawing.Image)(resources.GetObject("pbReadBoxCard.Image")));
            this.pbReadBoxCard.Location = new System.Drawing.Point(121, 150);
            this.pbReadBoxCard.Name = "pbReadBoxCard";
            this.pbReadBoxCard.Size = new System.Drawing.Size(88, 99);
            this.pbReadBoxCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReadBoxCard.Click += new System.EventHandler(this.pbReadBoxCard_Click);
            this.pbReadBoxCard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbReadBoxCard_MouseDown);
            // 
            // pbReadCarCard
            // 
            this.pbReadCarCard.BackColor = System.Drawing.Color.SlateBlue;
            this.pbReadCarCard.Image = ((System.Drawing.Image)(resources.GetObject("pbReadCarCard.Image")));
            this.pbReadCarCard.Location = new System.Drawing.Point(24, 150);
            this.pbReadCarCard.Name = "pbReadCarCard";
            this.pbReadCarCard.Size = new System.Drawing.Size(80, 99);
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
            this.pictureBox1.Location = new System.Drawing.Point(75, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(75, 125);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bat
            // 
            this.bat.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.bat.ForeColor = System.Drawing.Color.White;
            this.bat.Location = new System.Drawing.Point(3, 3);
            this.bat.Name = "bat";
            this.bat.Size = new System.Drawing.Size(91, 20);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.Text = "箱的类型：";
            // 
            // taskPIC
            // 
            this.taskPIC.Location = new System.Drawing.Point(215, 7);
            this.taskPIC.Name = "taskPIC";
            this.taskPIC.Size = new System.Drawing.Size(8, 8);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(157, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.Text = "数据同步";
            // 
            // NetPIC
            // 
            this.NetPIC.Location = new System.Drawing.Point(132, 7);
            this.NetPIC.Name = "NetPIC";
            this.NetPIC.Size = new System.Drawing.Size(8, 8);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(100, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.Text = "网络";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 276);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SlateBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(46, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 26);
            this.textBox1.TabIndex = 5;
            this.textBox1.LostFocus += new System.EventHandler(this.textbox1_focus);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(46, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 24);
            this.label6.Text = "呼叫指挥中心";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(46, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 24);
            this.label5.Text = "呼叫指挥中心";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 53);
            this.label4.Text = "请用方向箭头选择呼叫目标";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(129, 176);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(75, 75);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.SlateBlue;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(25, 176);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(75, 75);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Chartreuse;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(3, 113);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(31, 31);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "目的地：";
            // 
            // comboBox2
            // 
            this.comboBox2.DisplayMember = "其它";
            this.comboBox2.Items.Add("大屯");
            this.comboBox2.Items.Add("马家楼");
            this.comboBox2.Location = new System.Drawing.Point(97, 91);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(112, 22);
            this.comboBox2.TabIndex = 29;
            this.comboBox2.ValueMember = "其它";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 200000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NetPIC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.taskPIC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
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
            this.Controls.Add(this.pictureBox7);
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
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox taskPIC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox NetPIC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Timer timer2;
    }
}

