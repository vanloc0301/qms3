using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriverManager.Classes;

namespace DriverManager
{
    public partial class DriverAddForm : Form
    {
        public CfCardPC cardPC;
        BaseOperate operate = new BaseOperate();
        private string cardID;
        public DriverAddForm()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DriverAddForm_Load(object sender, EventArgs e)
        {
            bgwLoadData.RunWorkerAsync();
        }

        #region 读卡部分
        
       
        private void bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            if (cardPC == null)
                return;
            cardID = "";
            int status = cardPC.GetCardID(0, ref cardID);

            if (status != 0)
            {
                MessageBox.Show("请不要拿开卡片！","提示");
                this.Close();
                return;
            }

            string sql = "SELECT * FROM [dbo.Driver] WHERE DriverCardID = '"+cardID+"'";

            DataSet ds = operate.getds(sql,"[dbo.Driver]");

            e.Result = ds;
        }

        private void bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                MessageBox.Show("加载司机信息失败！");
                this.Close();
                return;
            }

            DataSet ds = e.Result as DataSet;
            if(ds.Tables.Count <= 0)
            {
                MessageBox.Show("加载司机信息失败！");
                this.Close();
                return;
            }


            //如果数据库中没有记录
            if (ds.Tables[0].Rows.Count <= 0)
            {
                label1.Text = "新加卡信息";
                txtCardID.Text = cardID;
                txtTruckNo.Text = "京A";
            }
            else
            {
                try
                {
                    label1.Text = "编辑卡信息";
                    txtCardID.Text = ds.Tables[0].Rows[0]["DriverCardID"].ToString();
                    txtName.Text = ds.Tables[0].Rows[0]["DriverName"].ToString();
                    txtAge.Text = ds.Tables[0].Rows[0]["DriverAge"].ToString();
                    txtTruckNo.Text = ds.Tables[0].Rows[0]["TruckNo"].ToString();
                    if (ds.Tables[0].Rows[0]["DriverGender"].ToString().Trim() == "女")
                        rbWoMan.Checked = true;
                    else
                        rbMan.Checked = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            bgwUpdateData.RunWorkerAsync();
        }

        

        #region 写卡部分
        private void bgwUpdateData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                btnOK.Enabled = false;
                txtAge.Enabled = false;
                txtName.Enabled = false;
                txtTruckNo.Enabled = false;
                btnCancle.Enabled = false;
                //验证数据是否完整
                if (txtTruckNo.Text.Length <= 0 || txtName.Text.Length <= 0)
                {
                    MessageBox.Show("信息不完整，无法保存！", "提示");
                    return;
                }

                //验证卡是否存在
                string nc = "";
                int status = cardPC.GetCardID(-1, ref nc);
                if (nc != cardID)
                {
                    MessageBox.Show("两次读卡不一致，请不要换卡！", "提示");
                    return;
                }

                if (status != 0)
                {
                    MessageBox.Show("检测不到卡，请将卡片放置读写器上！", "提示");
                    return;
                }

                //写卡类型
                status = cardPC.WriteCardClass("0");
                if (status != 0)
                {
                    MessageBox.Show("写卡类型失败！", "提示");
                }

                //写车牌号
                status = cardPC.WriteTruckNo(txtTruckNo.Text);
                if (status != 0)
                {
                    MessageBox.Show("写车牌号失败！", "提示");
                    return;
                }

                //写数据库
                string sql = "";
                //添加新卡
                if (label1.Text == "新加卡信息")
                {
                    sql = "INSERT INTO [dbo.Driver] VALUES('" + txtCardID.Text + "','";
                    sql += txtTruckNo.Text + "','";
                    sql += txtName.Text + "','";
                    sql += (rbMan.Checked ? "男" : "女") + "','";
                    sql += txtAge.Text + "')";
                }
                //更新司机信息
                else
                {
                    sql = "UPDATE [dbo.Driver] SET ";
                    sql += "TruckNo='" + txtTruckNo.Text + "',";
                    sql += "DriverName='" + txtName.Text + "',";
                    sql += "DriverGender='" + (rbMan.Checked ? "男" : "女") + "',";
                    sql += "DriverAge='" + txtAge.Text + "'";
                    sql += "WHERE DriverCardID='" + txtCardID.Text + "'";
                }

                operate.getcom(sql);
                btnOK.Enabled = true;
                txtAge.Enabled = true;
                txtName.Enabled = true;
                txtTruckNo.Enabled = true;
                btnCancle.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnOK.Enabled = true;
            txtAge.Enabled = true;
            txtName.Enabled = true;
            txtTruckNo.Enabled = true;
            btnCancle.Enabled = true;
        }
        #endregion

        private void bgwUpdateData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
