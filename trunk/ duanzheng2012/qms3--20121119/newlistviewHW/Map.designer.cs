namespace newlistview
{
    partial class Map
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.IntrovertIMApp = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.tmrSetLocation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IntrovertIMApp)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // IntrovertIMApp
            // 
            this.IntrovertIMApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IntrovertIMApp.Enabled = true;
            this.IntrovertIMApp.Location = new System.Drawing.Point(0, 0);
            this.IntrovertIMApp.Name = "IntrovertIMApp";
            this.IntrovertIMApp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("IntrovertIMApp.OcxState")));
            this.IntrovertIMApp.Size = new System.Drawing.Size(1380, 760);
            this.IntrovertIMApp.TabIndex = 2;
            this.IntrovertIMApp.Enter += new System.EventHandler(this.IntrovertIMApp_Enter);
            // 
            // tmrSetLocation
            // 
            this.tmrSetLocation.Tick += new System.EventHandler(this.tmrSetLocation_Tick);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 760);
            this.Controls.Add(this.IntrovertIMApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Map";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Map_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IntrovertIMApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private AxShockwaveFlashObjects.AxShockwaveFlash IntrovertIMApp;
        private System.Windows.Forms.Timer tmrSetLocation;


    }
}

