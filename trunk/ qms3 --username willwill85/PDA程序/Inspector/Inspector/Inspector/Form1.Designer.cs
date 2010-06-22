namespace Inspector
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
            this.lbCarNum = new System.Windows.Forms.Label();
            this.tbCarNum = new System.Windows.Forms.TextBox();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.tbStartSpotNum = new System.Windows.Forms.TextBox();
            this.lbStartSpotNum = new System.Windows.Forms.Label();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.transpoartSystemDataSet = new Inspector.TranspoartSystemDataSet();
            this.boxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxTableAdapter = new Inspector.TranspoartSystemDataSetTableAdapters.BoxTableAdapter();
            this.driverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.driverTableAdapter = new Inspector.TranspoartSystemDataSetTableAdapters.DriverTableAdapter();
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.goodsTableAdapter = new Inspector.TranspoartSystemDataSetTableAdapters.GoodsTableAdapter();
            this.pbInspect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "x";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbCarNum
            // 
            this.lbCarNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbCarNum.ForeColor = System.Drawing.Color.White;
            this.lbCarNum.Location = new System.Drawing.Point(12, 19);
            this.lbCarNum.Name = "lbCarNum";
            this.lbCarNum.Size = new System.Drawing.Size(100, 20);
            this.lbCarNum.Text = "车牌号：";
            // 
            // tbCarNum
            // 
            this.tbCarNum.Location = new System.Drawing.Point(103, 18);
            this.tbCarNum.Name = "tbCarNum";
            this.tbCarNum.ReadOnly = true;
            this.tbCarNum.Size = new System.Drawing.Size(115, 21);
            this.tbCarNum.TabIndex = 4;
            // 
            // tbStartTime
            // 
            this.tbStartTime.Location = new System.Drawing.Point(103, 85);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(115, 21);
            this.tbStartTime.TabIndex = 11;
            // 
            // lbStartTime
            // 
            this.lbStartTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbStartTime.ForeColor = System.Drawing.Color.White;
            this.lbStartTime.Location = new System.Drawing.Point(12, 86);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(100, 20);
            this.lbStartTime.Text = "发货时间：";
            // 
            // tbStartSpotNum
            // 
            this.tbStartSpotNum.Location = new System.Drawing.Point(103, 51);
            this.tbStartSpotNum.Name = "tbStartSpotNum";
            this.tbStartSpotNum.ReadOnly = true;
            this.tbStartSpotNum.Size = new System.Drawing.Size(115, 21);
            this.tbStartSpotNum.TabIndex = 10;
            // 
            // lbStartSpotNum
            // 
            this.lbStartSpotNum.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbStartSpotNum.ForeColor = System.Drawing.Color.White;
            this.lbStartSpotNum.Location = new System.Drawing.Point(12, 52);
            this.lbStartSpotNum.Name = "lbStartSpotNum";
            this.lbStartSpotNum.Size = new System.Drawing.Size(100, 20);
            this.lbStartSpotNum.Text = "始发站号：";
            // 
            // tbEndTime
            // 
            this.tbEndTime.Location = new System.Drawing.Point(103, 121);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(115, 21);
            this.tbEndTime.TabIndex = 17;
            // 
            // lbEndTime
            // 
            this.lbEndTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbEndTime.ForeColor = System.Drawing.Color.White;
            this.lbEndTime.Location = new System.Drawing.Point(12, 122);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(100, 20);
            this.lbEndTime.Text = "收货时间：";
            // 
            // transpoartSystemDataSet
            // 
            this.transpoartSystemDataSet.DataSetName = "TranspoartSystemDataSet";
            this.transpoartSystemDataSet.Prefix = "";
            this.transpoartSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // boxBindingSource
            // 
            this.boxBindingSource.DataMember = "Box";
            this.boxBindingSource.DataSource = this.transpoartSystemDataSet;
            // 
            // boxTableAdapter
            // 
            this.boxTableAdapter.ClearBeforeFill = true;
            // 
            // driverBindingSource
            // 
            this.driverBindingSource.DataMember = "Driver";
            this.driverBindingSource.DataSource = this.transpoartSystemDataSet;
            // 
            // driverTableAdapter
            // 
            this.driverTableAdapter.ClearBeforeFill = true;
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataMember = "Goods";
            this.goodsBindingSource.DataSource = this.transpoartSystemDataSet;
            // 
            // goodsTableAdapter
            // 
            this.goodsTableAdapter.ClearBeforeFill = true;
            // 
            // pbInspect
            // 
            this.pbInspect.BackColor = System.Drawing.Color.Transparent;
            this.pbInspect.Image = ((System.Drawing.Image)(resources.GetObject("pbInspect.Image")));
            this.pbInspect.Location = new System.Drawing.Point(63, 157);
            this.pbInspect.Name = "pbInspect";
            this.pbInspect.Size = new System.Drawing.Size(88, 110);
            this.pbInspect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInspect.Click += new System.EventHandler(this.pbInspect_Click);
            this.pbInspect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbInspect_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.tbEndTime);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.tbStartTime);
            this.Controls.Add(this.lbStartTime);
            this.Controls.Add(this.tbStartSpotNum);
            this.Controls.Add(this.lbStartSpotNum);
            this.Controls.Add(this.tbCarNum);
            this.Controls.Add(this.lbCarNum);
            this.Controls.Add(this.pbInspect);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "检查终端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transpoartSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pbInspect;
        private System.Windows.Forms.Label lbCarNum;
        private System.Windows.Forms.TextBox tbCarNum;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.TextBox tbStartSpotNum;
        private System.Windows.Forms.Label lbStartSpotNum;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.Label lbEndTime;
        private TranspoartSystemDataSet transpoartSystemDataSet;
        private System.Windows.Forms.BindingSource boxBindingSource;
        private Inspector.TranspoartSystemDataSetTableAdapters.BoxTableAdapter boxTableAdapter;
        private System.Windows.Forms.BindingSource driverBindingSource;
        private Inspector.TranspoartSystemDataSetTableAdapters.DriverTableAdapter driverTableAdapter;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private Inspector.TranspoartSystemDataSetTableAdapters.GoodsTableAdapter goodsTableAdapter;
    }
}

