using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inspector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myCfCard = new Distributor.CfCard.CfCard();
            clearMemProperties();
        }

        protected void clearMemProperties()
        {
            sBoxCardId = "";
            sCarNum = "";
//            sBoxNum = "";
            sStartSpotNum = "";
            nStartSpotNum = -1;
            sStartTime = "";
            sEndTime = "";
        }

        protected void clearPropShow()
        {
            tbCarNum.Text = "";
//            tbBoxNum.Text = "";
            tbStartSpotNum.Text = "";
            tbStartTime.Text = "";
            tbEndTime.Text = "";
        }

        protected void propShow()
        {
            tbCarNum.Text = sCarNum;
//            tbBoxNum.Text = sBoxNum;
            tbStartSpotNum.Text = sStartSpotNum;
            tbStartTime.Text = sStartTime;
            tbEndTime.Text = sEndTime;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (TranspoartSystemDataSetUtil.DesignerUtil.IsRunTime())
            {
                // TODO: 删除此行代码以移除“transpoartSystemDataSet.Goods”的默认 AutoFill。
//                this.goodsTableAdapter.Fill(this.transpoartSystemDataSet.Goods);
            }
            if (TranspoartSystemDataSetUtil.DesignerUtil.IsRunTime())
            {
                // TODO: 删除此行代码以移除“transpoartSystemDataSet.Driver”的默认 AutoFill。
//                this.driverTableAdapter.Fill(this.transpoartSystemDataSet.Driver);
            }
            if (TranspoartSystemDataSetUtil.DesignerUtil.IsRunTime())
            {
                // TODO: 删除此行代码以移除“transpoartSystemDataSet.Box”的默认 AutoFill。
//                this.boxTableAdapter.Fill(this.transpoartSystemDataSet.Box);
            }
            clearPropShow();
            myCfCard.connect();
        }

        private void pbInspect_Click(object sender, EventArgs e)
        {
            this.pbInspect.Image = Properties.Resources.btReadUp;
            this.Refresh();
            clearMemProperties();
            clearPropShow();

            string sInfoR = "";

            if (myCfCard.request(ref sBoxCardId) != 0)
            {
                return;
            }
            else
                sBoxCardId = myCfCard.carid();
            //读取卡类型
            if (myCfCard.Auth(5, 0) != 0)
                return;
            if (myCfCard.ReadString(0, 1, ref sInfoR) != 0)
            {
                MessageBox.Show("读取卡类型错误！");
                return;
            }
            //if (sInfoR != BOX_CARD)
            //{
            //    MessageBox.Show("此卡不是货箱卡！");
            //    return;
            //}

            //读取车牌号
            if (myCfCard.Auth(3, 2) != 0)
            {
                return;
            }
            if (myCfCard.ReadString(1, 9, ref sCarNum) != 0)
            {
                MessageBox.Show("读取车牌号错误！");
                return;
            }

            /*if (myCfCard.Auth(3, 1) != 0)
            {
                return;
            }
            if (myCfCard.ReadString(3, 1, ref sBoxNum) != 0)
            {
                MessageBox.Show("读取货箱号错误！");
                return;
            }*/

            sInfoR = "";

            if (myCfCard.ReadString(13, 1, ref sInfoR) != 0)
            {
                MessageBox.Show("无法读取任务状态！");
                return;
            }
            if (myCfCard.ReadString2(6, 5, ref sStartTime) != 0)
            {
                MessageBox.Show("读取发货时间错误！");
                return;
            }
            sStartTime = myCfCard.decodetime(sStartTime);

            if (myCfCard.ReadString(9, 2, ref sStartSpotNum) != 0)
            {
                MessageBox.Show("读取始发站号错误！");
                return;
            }
  /*          if (sStartSpotNum.Length <= 2)
            {
                MessageBox.Show("读取始发站号错误！您的货箱可能尚未经过发货！");
                return;
            }
            if (sStartSpotNum.Substring(0, 2) != S_START_SPOT_PREFIX)
            {
                MessageBox.Show("无效的始发站号！");
                return;
            }*/
            //try
            //{
            //    nStartSpotNum = int.Parse(sStartSpotNum);
            //}
            //catch (System.Exception eStartSpotNum)
            //{
            //    MessageBox.Show("卡中的始发站号有误！");
            //    return;
            //}

            if (sInfoR == MISSION_ING)
            {
                sEndTime = MISSION_ING_CH;
            }
            else
            {
                if (myCfCard.ReadString2(10, 5, ref sEndTime) != 0)
                {
                    MessageBox.Show("读取收货时间错误！");
                    return;
                }
                sEndTime = myCfCard.decodetime(sEndTime);
                if (sEndTime.CompareTo(sStartTime) < 0)
                {
                    MessageBox.Show("错误！出发时间晚于到达时间！");
                  //  return;
                }
            }
            if (network)
            {
                try
                {
                    if (sEndTime == MISSION_ING_CH)
                    {
                        if ((((int)(this.boxTableAdapter.ScalarQueryByInspector(sBoxCardId))) != 1) ||
                             (((int)(this.driverTableAdapter.ScalarQueryByInspector(sCarNum))) != 1) ||
                             (((int)(this.goodsTableAdapter.ScalarQueryByInspectorMissoinIng(sBoxCardId, sCarNum,
                             sStartTime, nStartSpotNum))) != 1)
                        )
                        {
                            MessageBox.Show("您的信息核对有误！");
                            return;
                        }
                    }
                    else
                    {
                        if ((((int)(this.boxTableAdapter.ScalarQueryByInspector(sBoxCardId))) != 1) ||
                            (((int)(this.driverTableAdapter.ScalarQueryByInspector(sCarNum))) != 1) ||
                            (((int)(this.goodsTableAdapter.ScalarQueryByInspector(sBoxCardId, sCarNum,
                                 sStartTime, sEndTime, nStartSpotNum))) != 1)
                            )
                        {
                            MessageBox.Show("您的信息核对有误！");
                            return;
                        }
                    }
                }
                catch (System.Exception e0)
                {
                    if (MessageBox.Show("数据库连接失败！终止本次检查？" + e0.Message, "提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        return;

                    }
                }
            }
            propShow();
        }

        private void pbInspect_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbInspect.Image = Properties.Resources.btReadDown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private const string CAR_CARD = "C";
        private const string BOX_CARD = "B";
        private const string MISSION_ING = "S";
        private const string MISSION_FINISH = "E";
        private const string MISSION_ING_CH = "未完成";
        private const string S_START_SPOT_PREFIX = "S#";
        private const bool network = false;

        private Distributor.CfCard.CfCard myCfCard;
        private string sBoxCardId;
        private string sCarNum;
//        private string sBoxNum;
        private string sStartSpotNum;
        private int nStartSpotNum;
        private string sStartTime;
        private string sEndTime;
    }
}