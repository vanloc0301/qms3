using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriverManager.Classes;
using System.Threading;

namespace DriverManager
{
    public partial class MainWindow : Form
    {

        BaseOperate op = new BaseOperate();
        DataTable drivers;
        Thread tReadCard;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.cbType.SelectedIndex = 0;


        }

        #region 读卡线程

        private void readCard()
        {
            CfCardPC cfCardPC = new CfCardPC();
            
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String sql = "SELECT * FROM [dbo.Driver] ";
            if (this.cbType.SelectedIndex == 0 && txtWhere.Text.Length > 0)
                sql += "WHERE [DriverName] like '%" + txtWhere.Text + "%'";

            if(this.cbType.SelectedIndex == 1 && txtWhere.Text.Length > 0)
                sql += "WHERE [TruckNo] like '%" + txtWhere.Text + "%'";

            bgwSearch.RunWorkerAsync(sql);
            new DriverAddForm().ShowDialog();
            
        }

        private void bgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet ds = op.getds(e.Argument.ToString(),"[dbo.Driver]");
            if (ds.Tables.Count <= 0)
                return;
            drivers = ds.Tables[0];
        }

        private void bgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvDrivers.DataSource = drivers;
        }

        private void dgvDrivers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            e.Value = e.Value.ToString().Trim();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lblID.Text == "")
            {
                MessageBox.Show("请选择要保存的数据！");
                return;
            }

            string gender = this.rbMan.Checked ? "男" : "女";

            string sql = "UPDATE [dbo.Driver] SET [DriverName]='"+txtName.Text+"',[DriverAge]='"+txtAge.Text+"',[DriverGender]='"+gender+"',[TruckNo]='"+txtTruckNo.Text+"' WHERE [ID] = " + this.lblID.Text;
            op.getcom(sql);
            txtTruckNo.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            rbMan.Checked = true;
            lblID.Text = "";
            btnSearch_Click(null,null);

        }

        private void dgvDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex>= drivers.Rows.Count) 
                return;
            
            //复制数据到保存区域
            this.txtName.Text = drivers.Rows[e.RowIndex]["DriverName"].ToString();
            this.txtAge.Text = drivers.Rows[e.RowIndex]["DriverAge"].ToString();
            this.txtTruckNo.Text = drivers.Rows[e.RowIndex]["TruckNo"].ToString();
            this.lblID.Text = drivers.Rows[e.RowIndex]["ID"].ToString();

            if (drivers.Rows[e.RowIndex]["DriverGender"].ToString() == "男")
                this.rbMan.Checked = true;
            else
                this.rbWoMan.Checked = true;
        }
    }
}
