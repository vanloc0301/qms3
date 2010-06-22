namespace Collector
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
            this.button1 = new System.Windows.Forms.Button();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.tbStartSpotNum = new System.Windows.Forms.TextBox();
            this.lbStartSpotNum = new System.Windows.Forms.Label();
            this.tbCarNum = new System.Windows.Forms.TextBox();
            this.lbCarNum = new System.Windows.Forms.Label();
            this.pbCollect = new System.Windows.Forms.PictureBox();
            this.weightlabel = new System.Windows.Forms.Label();
            this.weightnum = new System.Windows.Forms.TextBox();
            this.transpoartSystemDataSet = new Collector.TranspoartSystemDataSet();
            this.boxTableAdapter = new Collector.TranspoartSystemDataSetTableAdapters.BoxTableAdapter();
            this.driverTableAdapter = new Collector.TranspoartSystemDataSetTableAdapters.DriverTableAdapter();
            this.goodsTableAdapter = new Collector.TranspoartSystemDataSetTableAdapters.GoodsTableAdapter();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.boxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.db_rfidtestDataSet = new Collector.db_rfidtestDataSet();
            this.driverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbo_BoxTableAdapter1 = new Collector.db_rfidtestDataSetTableAdapters.dbo_BoxTableAdapter();
            this.dbo_DriverTableAdapter1 = new Collector.db_rfidtestDataSetTableAdapters.dbo_DriverTableAdapter();
            this.dbo_GoodsTableAdapter1 = new Collector.db_rfidtestDataSetTableAdapters.dbo_GoodsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "x";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbEndTime
            // 
            this.tbEndTime.Location = new System.Drawing.Point(99, 115);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(110, 21);
            this.tbEndTime.TabIndex = 29;
            // 
            // lbEndTime
            // 
            this.lbEndTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbEndTime.ForeColor = System.Drawing.Color.White;
            this.lbEndTime.Location = new System.Drawing.Point(3, 115);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(90, 20);
            this.lbEndTime.Text = "收货时间：";
            // 
            // tbStartTime
            // 
            this.tbStartTime.Location = new System.Drawing.Point(99, 82);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(110, 21);
            this.tbStartTime.TabIndex = 27;
            // 
            // lbStartTime
            // 
            this.lbStartTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbStartTime.ForeColor = System.Drawing.Color.White;
            this.lbStartTime.Location = new System.Drawing.Point(3, 82);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(90, 20);
            this.lbStartTime.Text = "发货时间：";
            // 
            // tbStartSpotNum
            // 
            this.tbStartSpotNum.Location = new System.Drawing.Point(99, 49);
            this.tbStartSpotNum.Name = "tbStartSpotNum";
            this.tbStartSpotNum.ReadOnly = true;
            this.tbStartSpotNum.Size = new System.Drawing.Size(110, 21);
            this.tbStartSpotNum.TabIndex = 26;
            // 
            // lbStartSpotNum
            // 
            this.lbStartSpotNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbStartSpotNum.ForeColor = System.Drawing.Color.White;
            this.lbStartSpotNum.Location = new System.Drawing.Point(3, 49);
            this.lbStartSpotNum.Name = "lbStartSpotNum";
            this.lbStartSpotNum.Size = new System.Drawing.Size(90, 20);
            this.lbStartSpotNum.Text = "始发站号：";
            // 
            // tbCarNum
            // 
            this.tbCarNum.Location = new System.Drawing.Point(99, 16);
            this.tbCarNum.Name = "tbCarNum";
            this.tbCarNum.ReadOnly = true;
            this.tbCarNum.Size = new System.Drawing.Size(110, 21);
            this.tbCarNum.TabIndex = 24;
            // 
            // lbCarNum
            // 
            this.lbCarNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbCarNum.ForeColor = System.Drawing.Color.White;
            this.lbCarNum.Location = new System.Drawing.Point(3, 16);
            this.lbCarNum.Name = "lbCarNum";
            this.lbCarNum.Size = new System.Drawing.Size(90, 20);
            this.lbCarNum.Text = "车牌号：";
            // 
            // pbCollect
            // 
            this.pbCollect.BackColor = System.Drawing.Color.Transparent;
            this.pbCollect.Image = ((System.Drawing.Image)(resources.GetObject("pbCollect.Image")));
            this.pbCollect.Location = new System.Drawing.Point(67, 175);
            this.pbCollect.Name = "pbCollect";
            this.pbCollect.Size = new System.Drawing.Size(88, 110);
            this.pbCollect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCollect.Click += new System.EventHandler(this.pbCollect_Click);
            this.pbCollect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCollect_MouseDown);
            // 
            // weightlabel
            // 
            this.weightlabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.weightlabel.ForeColor = System.Drawing.Color.White;
            this.weightlabel.Location = new System.Drawing.Point(3, 149);
            this.weightlabel.Name = "weightlabel";
            this.weightlabel.Size = new System.Drawing.Size(90, 20);
            this.weightlabel.Text = "重量：";
            // 
            // weightnum
            // 
            this.weightnum.Location = new System.Drawing.Point(99, 148);
            this.weightnum.Name = "weightnum";
            this.weightnum.Size = new System.Drawing.Size(110, 21);
            this.weightnum.TabIndex = 37;
            // 
            // transpoartSystemDataSet
            // 
            this.transpoartSystemDataSet.DataSetName = "TranspoartSystemDataSet";
            this.transpoartSystemDataSet.Prefix = "";
            this.transpoartSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // boxTableAdapter
            // 
            this.boxTableAdapter.ClearBeforeFill = true;
            // 
            // driverTableAdapter
            // 
            this.driverTableAdapter.ClearBeforeFill = true;
            // 
            // goodsTableAdapter
            // 
            this.goodsTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(68, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 108);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Visible = false;
            // 
            // boxBindingSource
            // 
            this.boxBindingSource.DataSource = this.db_rfidtestDataSet;
            this.boxBindingSource.Position = 0;
            // 
            // db_rfidtestDataSet
            // 
            this.db_rfidtestDataSet.DataSetName = "db_rfidtestDataSet";
            this.db_rfidtestDataSet.Prefix = "";
            this.db_rfidtestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // driverBindingSource
            // 
            this.driverBindingSource.DataSource = this.db_rfidtestDataSet;
            this.driverBindingSource.Position = 0;
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataSource = this.db_rfidtestDataSet;
            this.goodsBindingSource.Position = 0;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.weightnum);
            this.Controls.Add(this.weightlabel);
            this.Controls.Add(this.tbEndTime);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.tbStartTime);
            this.Controls.Add(this.lbStartTime);
            this.Controls.Add(this.tbStartSpotNum);
            this.Controls.Add(this.lbStartSpotNum);
            this.Controls.Add(this.tbCarNum);
            this.Controls.Add(this.lbCarNum);
            this.Controls.Add(this.pbCollect);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "收货终端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.db_rfidtestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbCollect;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.TextBox tbStartSpotNum;
        private System.Windows.Forms.Label lbStartSpotNum;
        private System.Windows.Forms.TextBox tbCarNum;
        private System.Windows.Forms.Label lbCarNum;
        private TranspoartSystemDataSet transpoartSystemDataSet;
        private System.Windows.Forms.BindingSource boxBindingSource;
        private Collector.TranspoartSystemDataSetTableAdapters.BoxTableAdapter boxTableAdapter;
        private System.Windows.Forms.BindingSource driverBindingSource;
        private Collector.TranspoartSystemDataSetTableAdapters.DriverTableAdapter driverTableAdapter;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private Collector.TranspoartSystemDataSetTableAdapters.GoodsTableAdapter goodsTableAdapter;
        private System.Windows.Forms.Label weightlabel;
        private System.Windows.Forms.TextBox weightnum;
        private db_rfidtestDataSet db_rfidtestDataSet;
        private Collector.db_rfidtestDataSetTableAdapters.dbo_BoxTableAdapter dbo_BoxTableAdapter1;
        private Collector.db_rfidtestDataSetTableAdapters.dbo_DriverTableAdapter dbo_DriverTableAdapter1;
        private Collector.db_rfidtestDataSetTableAdapters.dbo_GoodsTableAdapter dbo_GoodsTableAdapter1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

