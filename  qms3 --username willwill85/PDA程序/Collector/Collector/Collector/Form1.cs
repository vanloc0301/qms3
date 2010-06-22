using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Distributor.CfCard;

namespace Collector
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
            nStartSpotNum = -1;
            sBoxCardId = "";
            sCarNum = "";
//            sBoxNum = "";
            sStartSpotNum = "";
            sStartTime = "";
            sEndTime = "";
//            cMissionState = "E";
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

        private bool checkCardData()
        {
            string sInfoR = "";

            if (myCfCard.request(ref sBoxCardId) != 0)
            {
                return false;
            }
            else
                sBoxCardId = myCfCard.carid();
            //读取卡类型
           
            if (myCfCard.ReadString(0, 1, ref sInfoR) != 0)
            {
                MessageBox.Show("读取卡类型错误！");
                return false;
            }
            //MessageBox.Show(myCfCard.StrToHex(sInfoR));
            //MessageBox.Show(myCfCard.StrToHex(BOX_CARD));


            //if (sInfoR != myCfCard.HexToStr(BOX_CARD))
            //{
            //    MessageBox.Show("此卡不是货箱卡！");
            //   // return false;
            //}

            sInfoR = "";

            if (myCfCard.ReadString(13,1, ref sInfoR) != 0)
            {
                MessageBox.Show("无法读取任务状态！");
                return false;
            }

            if (sInfoR!= MISSION_ING)
            {
                MessageBox.Show("任务已完成");
                return false;
            }

            //读取车牌号
            if (myCfCard.ReadString(1, 9, ref sCarNum) != 0)
            {
                MessageBox.Show("读取车牌号错误！");
                return false;
            }

            /*if (myCfCard.Auth(3, 1) != 0)
            {
                return false;
            }
            if (myCfCard.ReadString(3, 1, ref sBoxNum) != 0)
            {
                MessageBox.Show("读取货箱号错误！");
                return false;
            }*/

           if (myCfCard.ReadString2(6, 5, ref sStartTime) != 0)
            {
                MessageBox.Show("读取发货时间错误！");
                return false;
            }
            //sStartTime = myCfCard.HexToStr(sStartTime);
            
            sStartTime = myCfCard.decodetime(sStartTime);
            //MessageBox.Show(sStartTime);
            if (sEndTime.CompareTo(sStartTime) < 0)
            {
                MessageBox.Show("错误！出发时间晚于到达时间！");
                return false;
            }
            if (myCfCard.ReadString(9,2, ref sStartSpotNum) != 0)
            {
                MessageBox.Show("读取始发站号错误！");
                return false;
            }
         //   MessageBox.Show(sStartSpotNum);
            /* if (sStartSpotNum.Length <= 2)
            {
                MessageBox.Show("读取始发站号错误！您的货箱可能尚未经过发货！");
                return false;
            }
               if (sStartSpotNum.Substring(0, 2) != S_START_SPOT_PREFIX)
                {
                    MessageBox.Show("无效的始发站号！");
                    return false;
                }*/
                try
                {
                    nStartSpotNum = int.Parse(sStartSpotNum);
                }
                catch (System.Exception eStartSpotNum)
                {
                    MessageBox.Show("卡中的始发站号有误！");
                    return false;
                }

            propShow();
            return true;
        }

        private void pbCollect_Click(object sender, EventArgs e)
        {
            pbCollect.Enabled = false;
            if (weightnum.Text == "")
            {
                MessageBox.Show("请填写重量");
                return;
            }
            int boxTableRst = -1, driverTableRst = -1, goodsTableRst = -1;
            this.pbCollect.Image = Properties.Resources.btWriteUp;
            this.Refresh();
            clearMemProperties();
            clearPropShow();

            string sInfoW = "";

            sEndTime = System.DateTime.Now.ToString("yy-MM-dd,HH:mm");
            //for UHF 重新调整短格式
            sEndTime2 = System.DateTime.Now.ToString("yyMMddHHmm");
            if (!checkCardData())
            {
               // MessageBox.Show("非法操作或任务已完成，不能写入！");
                return;
            }
            pictureBox1.Visible = true;
            pictureBox1.Refresh();
            

            //写入结束时间信息

            if (myCfCard.Write2(sEndTime2,10) != 0)
            {
                MessageBox.Show("写卡失败！");
                clearPropShow();
                return;
            }

           // //标记任务未完成标志.
           // if (myCfCard.Write(sStartSpotNum, 9) == 0)
           // {
           ////     MessageBox.Show("写卡成功！");
           // }
           // else
           // {
           //     MessageBox.Show("写卡失败！");
           //     clearPropShow();
           // }
            sInfoW = MISSION_FINISH;
//            cMissionState = MISSION_FINISH;
            if (myCfCard.Write(sInfoW,13) == 0)
            {
               // MessageBox.Show("写卡成功！");
                pictureBox1.Visible = false;
                networkupdate(goodsTableRst);
                weightnum.Text = "";
            }
            else
            {
                MessageBox.Show("写卡失败！");
                clearPropShow();
            }
            pbCollect.Enabled = true;
        }
        public void networkupdate(int goodsTableRst)
        {
            pictureBox2.Visible = true;
            pictureBox2.Refresh();
            if (network)
            {
                try
                {
                    if (
                        // ((boxTableRst = (int)(this.boxTableAdapter.ScalarQueryBySendInfo(sBoxCardId))) != 1) ||
                        // ((driverTableRst = (int)(this.driverTableAdapter.ScalarQueryBySendInfo(sCarNum))) != 1) ||
                        // ((goodsTableRst = (int)(this.goodsTableAdapter.ScalarQueryBySendInfo(sBoxCardId,sCarNum, sStartTime, nStartSpotNum))) != 1)
                        //是不是有这么一个箱   ((boxTableRst=(int)(this.dbo_BoxTableAdapter1.ScalarQueryBySendInfo(sBoxCardId))) !=1) ||
                        // 是不是有这么一个车   ((driverTableRst=(int)(this.dbo_DriverTableAdapter1.ScalarQueryBySendInfo(sCarNum)))!=1) ||
                        ((goodsTableRst = (int)(this.dbo_GoodsTableAdapter1.ScalarQueryBySendInfo(sBoxCardId, sCarNum, sStartTime, nStartSpotNum))) != 1)
                        )
                    {
                        //MessageBox.Show(sBoxCardId + "=" + sCarNum + "=" + sStartTime + "=" + nStartSpotNum);
                        if (goodsTableRst == 0)
                        {
                            //if (MessageBox.Show("发货站网络连接可能出错，导致数据库中无此次运送数据，终止本次操作？", "提示",
                            //MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                            //MessageBoxDefaultButton.Button1) == DialogResult.OK)
                            //{
                            //    clearPropShow();
                            //    return;
                            //}
                            //else
                            //{
                            //    this.dbo_GoodsTableAdapter1.InsertQueryForAll(sBoxCardId, sCarNum, sStartTime, sEndTime, nStartSpotNum, double.Parse(weightnum.Text)); 
                            //}
                            MessageBox.Show("发货站的网络可能出现问题，本次操作可以写入，但是请修复发货站网络连接");
                        }
                        else
                        {
                            MessageBox.Show("您的信息验证有误,同一条记录出现多次！本次操作失败！");
                            clearPropShow();
                            return;
                        }
                    }
                }
                catch (System.Exception e0)
                {
                    MessageBox.Show("数据库连接失败！不能进行操作！" + e0.Message);
                    clearPropShow();
                    return;
                }

                try
                {

                    if (goodsTableRst == 1)
                    {
                        //this.goodsTableAdapter.UpdateQueryEndTime(sEndTime, sBoxCardId, sCarNum,sStartTime, nStartSpotNum);
                        this.dbo_GoodsTableAdapter1.UpdateQueryEndTime(sEndTime, double.Parse(weightnum.Text), sBoxCardId, sCarNum, sStartTime, nStartSpotNum);
                    }
                    else
                    {
                        //this.goodsTableAdapter.InsertQueryForAll(sBoxCardId, sCarNum, sStartTime,sEndTime, nStartSpotNum);
                        this.dbo_GoodsTableAdapter1.InsertQueryForAll(sBoxCardId, sCarNum, sStartTime, sEndTime, nStartSpotNum, double.Parse(weightnum.Text), -1);
                    }
                }
                catch (System.Exception e1)
                {
                    //      MessageBox.Show("您的信息更新有误！插入操作失败！");
                    clearPropShow();
                    return;
                }
            }
            pictureBox2.Visible = false;
        }
        private void pbCollect_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbCollect.Image = Properties.Resources.btWriteDown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private const string CAR_CARD = "43";
        private const string BOX_CARD = "42";
        private const string MISSION_ING = "S";
        private const string MISSION_FINISH = "E";
        private const string MISSION_ING_CH = "未完成";
        private const string S_START_SPOT_PREFIX = "S#";
        private const bool network = true;
        private Distributor.CfCard.CfCard myCfCard;
        private string sBoxCardId;
        private string sCarNum;
//        private string sBoxNum;
        private string sStartSpotNum;
        private int nStartSpotNum;
        private string sStartTime;
        private string sEndTime;
        private string sEndTime2;
//        private string cMissionState;
    }
}