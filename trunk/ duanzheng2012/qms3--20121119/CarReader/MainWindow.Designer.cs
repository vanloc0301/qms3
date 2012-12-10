namespace CarReader
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblError = new System.Windows.Forms.Label();
            this.lblSumWeight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupCard = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.TruckNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comm1 = new System.IO.Ports.SerialPort(this.components);
            this.comm2 = new System.IO.Ports.SerialPort(this.components);
            this.lblComm1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblComm2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupList = new System.Windows.Forms.GroupBox();
            this.xdview = new AxXDVIEWLib.AxXDView();
            this.bgwUpdate = new System.ComponentModel.BackgroundWorker();
            this.groupCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xdview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(853, 18);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 28);
            this.lblError.TabIndex = 13;
            // 
            // lblSumWeight
            // 
            this.lblSumWeight.AutoSize = true;
            this.lblSumWeight.BackColor = System.Drawing.Color.Transparent;
            this.lblSumWeight.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSumWeight.ForeColor = System.Drawing.Color.Orange;
            this.lblSumWeight.Location = new System.Drawing.Point(731, 18);
            this.lblSumWeight.Name = "lblSumWeight";
            this.lblSumWeight.Size = new System.Drawing.Size(45, 28);
            this.lblSumWeight.TabIndex = 12;
            this.lblSumWeight.Text = "0吨";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(545, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "今日运输总重量：";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSum.ForeColor = System.Drawing.Color.Orange;
            this.lblSum.Location = new System.Drawing.Point(459, 18);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(45, 28);
            this.lblSum.TabIndex = 10;
            this.lblSum.Text = "0次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(275, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "今日运输总车次：";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.BackColor = System.Drawing.Color.Transparent;
            this.lblStation.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStation.ForeColor = System.Drawing.Color.Orange;
            this.lblStation.Location = new System.Drawing.Point(133, 18);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(33, 28);
            this.lblStation.TabIndex = 8;
            this.lblStation.Text = "无";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "转运中心：";
            // 
            // groupCard
            // 
            this.groupCard.BackColor = System.Drawing.Color.Transparent;
            this.groupCard.Controls.Add(this.label13);
            this.groupCard.Controls.Add(this.label14);
            this.groupCard.Controls.Add(this.label11);
            this.groupCard.Controls.Add(this.label12);
            this.groupCard.Controls.Add(this.label9);
            this.groupCard.Controls.Add(this.label10);
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
            this.groupCard.Location = new System.Drawing.Point(0, 62);
            this.groupCard.Name = "groupCard";
            this.groupCard.Size = new System.Drawing.Size(1014, 344);
            this.groupCard.TabIndex = 14;
            this.groupCard.TabStop = false;
            this.groupCard.Text = "刷卡信息";
            this.groupCard.Enter += new System.EventHandler(this.groupCard_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(890, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 38);
            this.label13.TabIndex = 15;
            this.label13.Text = "未知";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(736, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 38);
            this.label14.TabIndex = 14;
            this.label14.Text = "车辆皮重：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(890, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 38);
            this.label11.TabIndex = 13;
            this.label11.Text = "未知";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(736, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 38);
            this.label12.TabIndex = 12;
            this.label12.Text = "垃圾净重：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(890, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 38);
            this.label9.TabIndex = 11;
            this.label9.Text = "无";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(736, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 38);
            this.label10.TabIndex = 10;
            this.label10.Text = "车辆总重：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(543, 285);
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
            this.lblTruck.Location = new System.Drawing.Point(168, 285);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(46, 38);
            this.lblTruck.TabIndex = 8;
            this.lblTruck.Text = "无";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndTime.ForeColor = System.Drawing.Color.White;
            this.lblEndTime.Location = new System.Drawing.Point(527, 40);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(38, 31);
            this.lblEndTime.TabIndex = 7;
            this.lblEndTime.Text = "无";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartTime.ForeColor = System.Drawing.Color.White;
            this.lblStartTime.Location = new System.Drawing.Point(169, 40);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(38, 31);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "无";
            // 
            // lblStartStation
            // 
            this.lblStartStation.AutoSize = true;
            this.lblStartStation.Font = new System.Drawing.Font("微软雅黑", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartStation.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblStartStation.Location = new System.Drawing.Point(294, 108);
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
            this.label8.Location = new System.Drawing.Point(147, 162);
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
            this.label7.Location = new System.Drawing.Point(379, 285);
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
            this.label6.Location = new System.Drawing.Point(33, 285);
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
            this.label5.Location = new System.Drawing.Point(379, 33);
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
            this.label4.Location = new System.Drawing.Point(24, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 38);
            this.label4.TabIndex = 0;
            this.label4.Text = "出发时间：";
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(3, 412);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScrollBarsEnabled = false;
            this.webBrowser.Size = new System.Drawing.Size(478, 344);
            this.webBrowser.TabIndex = 15;
            // 
            // dgvMsg
            // 
            this.dgvMsg.AllowUserToAddRows = false;
            this.dgvMsg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMsg.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMsg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMsg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TruckNo,
            this.Weight,
            this.StartStationName,
            this.StartTime,
            this.EndTime});
            this.dgvMsg.Location = new System.Drawing.Point(492, 412);
            this.dgvMsg.Name = "dgvMsg";
            this.dgvMsg.RowHeadersVisible = false;
            this.dgvMsg.RowTemplate.Height = 23;
            this.dgvMsg.Size = new System.Drawing.Size(513, 128);
            this.dgvMsg.TabIndex = 16;
            // 
            // TruckNo
            // 
            this.TruckNo.DataPropertyName = "TruckNo";
            this.TruckNo.HeaderText = "车牌号";
            this.TruckNo.Name = "TruckNo";
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            this.Weight.HeaderText = "重量";
            this.Weight.Name = "Weight";
            // 
            // StartStationName
            // 
            this.StartStationName.DataPropertyName = "StartStationName";
            this.StartStationName.HeaderText = "起始站";
            this.StartStationName.Name = "StartStationName";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "发车时间";
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "到站时间";
            this.EndTime.Name = "EndTime";
            // 
            // comm1
            // 
            this.comm1.BaudRate = 4800;
            this.comm1.PortName = "COM8";
            this.comm1.ReceivedBytesThreshold = 9;
            this.comm1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comm1_DataReceived);
            // 
            // comm2
            // 
            this.comm2.BaudRate = 4800;
            this.comm2.PortName = "COM3";
            this.comm2.ReceivedBytesThreshold = 9;
            this.comm2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comm2_DataReceived);
            // 
            // lblComm1
            // 
            this.lblComm1.AutoSize = true;
            this.lblComm1.BackColor = System.Drawing.Color.Transparent;
            this.lblComm1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblComm1.ForeColor = System.Drawing.Color.White;
            this.lblComm1.Location = new System.Drawing.Point(109, 37);
            this.lblComm1.Name = "lblComm1";
            this.lblComm1.Size = new System.Drawing.Size(75, 38);
            this.lblComm1.TabIndex = 18;
            this.lblComm1.Text = "1.03";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(6, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 38);
            this.label16.TabIndex = 17;
            this.label16.Text = "上行：";
            // 
            // lblComm2
            // 
            this.lblComm2.AutoSize = true;
            this.lblComm2.BackColor = System.Drawing.Color.Transparent;
            this.lblComm2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblComm2.ForeColor = System.Drawing.Color.White;
            this.lblComm2.Location = new System.Drawing.Point(109, 109);
            this.lblComm2.Name = "lblComm2";
            this.lblComm2.Size = new System.Drawing.Size(75, 38);
            this.lblComm2.TabIndex = 20;
            this.lblComm2.Text = "1.06";
            this.lblComm2.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(6, 109);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 38);
            this.label18.TabIndex = 19;
            this.label18.Text = "下行：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblComm1);
            this.groupBox1.Controls.Add(this.lblComm2);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(743, 541);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 158);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "称重";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupList
            // 
            this.groupList.Location = new System.Drawing.Point(840, 25);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(58, 31);
            this.groupList.TabIndex = 16;
            this.groupList.TabStop = false;
            this.groupList.Text = "groupBox2";
            this.groupList.Visible = false;
            // 
            // xdview
            // 
            this.xdview.Enabled = true;
            this.xdview.Location = new System.Drawing.Point(492, 602);
            this.xdview.Name = "xdview";
            this.xdview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("xdview.OcxState")));
            this.xdview.Size = new System.Drawing.Size(241, 159);
            this.xdview.TabIndex = 16;
            // 
            // bgwUpdate
            // 
            this.bgwUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdate_DoWork);
            this.bgwUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdate_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 750);
            this.Controls.Add(this.groupList);
            this.Controls.Add(this.dgvMsg);
            this.Controls.Add(this.xdview);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupCard);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblSumWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.groupCard.ResumeLayout(false);
            this.groupCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMsg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xdview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblSumWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupCard;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblStartStation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.DataGridView dgvMsg;
        private System.IO.Ports.SerialPort comm1;
        private System.IO.Ports.SerialPort comm2;
        private System.Windows.Forms.Label lblComm1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblComm2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupList;
        private AxXDVIEWLib.AxXDView xdview;
        private System.Windows.Forms.DataGridViewTextBoxColumn TruckNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.ComponentModel.BackgroundWorker bgwUpdate;
    }
}

