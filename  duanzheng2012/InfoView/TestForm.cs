using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfoView.Classes;

namespace InfoView
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            String sqlStart = @"SELECT * FROM [db_rfidtest].[rfidtest].[dbo.goods] WHERE
                                    [db_rfidtest].[rfidtest].[dbo.goods].[ENDTIME] ='' ORDER BY STARTTIME DESC";
            BaseOperate operate = new BaseOperate();
            DataSet ds2 = null;
            try
            {
                ds2 = operate.getds(sqlStart, "[db_rfidtest].[rfidtest].[dbo.goods]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



            foreach (DataRow row in ds2.Tables[0].Rows)
            {
                DataGridViewRow dgr = new DataGridViewRow();
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    dgr.Cells.Add(c.CellTemplate.Clone() as DataGridViewCell);
                }
                dgr.Cells[0].Value = row["StartTime"].ToString();
                dgr.Cells[1].Value = row["EndTime"].ToString();
                dgr.Cells[2].Value = row["TruckNo"].ToString();
                dgr.Cells[3].Value = row["Weight"].ToString();

                dataGridView1.Rows.Add(dgr);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "insert into [db_rfidtest].[rfidtest].[dbo.goods] VALUES('1','1','" +
                DateTime.Now.ToString("yy-MM-dd,HH:mm") + "','"+
                DateTime.Now.ToString("yy-MM-dd,HH:mm") + "',0,'0',31,31,1)";
            BaseOperate op = new BaseOperate();
            op.getcom(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "insert into [db_rfidtest].[rfidtest].[dbo.goods] VALUES('1','1','" +
                DateTime.Now.ToString("yy-MM-dd,HH:mm") + "',null,0,'0',31,1,1)";
            BaseOperate op = new BaseOperate();
            op.getcom(sql);
        }
    }
}
