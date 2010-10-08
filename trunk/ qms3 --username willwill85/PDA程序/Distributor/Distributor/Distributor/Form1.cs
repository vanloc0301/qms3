using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Distributor.CfCard;
using System.Runtime.InteropServices;
using System.IO;

namespace Distributor
{
    public partial class Form1 : Form
    {
        private SYSTEM_POWER_STATUS_EX2 status = new SYSTEM_POWER_STATUS_EX2();
        private SYSTEM_POWER_STATUS_EX status2 = new SYSTEM_POWER_STATUS_EX();
        [DllImport("coredll")]
        private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, int fUpdate);
        [DllImport("coredll")]
        public static extern void SystemIdleTimerReset();
        [DllImport("coredll.dll")]
        public static extern uint GetSystemPowerStatusEx2(ref SYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2,int dwLen, int fUpdate);
        public Form1()
        {
            InitializeComponent();
            myCfCard = new Distributor.CfCard.CfCard();
            clearMemProperties();
        }
        protected void clearMemProperties()
        {
            sCarNum = "京";
            sBoxNum = "";
            sStartTime = "";
            sStartSpotNum = "";
            cMissionState = "E";
            sCarCardNum = "";
            sBoxCardNum = "";
        }

        protected void clearPropShow()
        {
            tbStartSpotNum.Text = S_START_SPOT_NUM;
            tbCarNum.Focus();
            tbCarNum.Text = "京";
            tbCarNum.Select(1, 0);
            LBStatus.Visible = false;
            progressBar1.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pbReadBoxCard.Enabled = true;
            pictureBox1.Visible = false;
        }

        private void pbReadCarCard_Click(object sender, EventArgs e)
        {
            this.pbReadCarCard.Image = Properties.Resources.btReadUp;
            this.Refresh();
            clearMemProperties();
            clearPropShow();
            
            string sInfoR = "";

            if (myCfCard.request(ref sCarCardNum) != 0)
            {
                clearMemProperties();
                clearPropShow();
                return;
            }
            else
                sCarCardNum = myCfCard.carid();
            

            //读取卡类型
            if (myCfCard.ReadString(0, 1, ref sInfoR) != 0)
            {
                MessageBox.Show("读取卡类型错误！");
                clearMemProperties();
                clearPropShow();
                return;
            }
          //  MessageBox.Show(myCfCard.StrToHex(sInfoR));
            
            if (sInfoR != myCfCard.HexToStr(CAR_CARD))
            {
                MessageBox.Show("此卡不是司机卡！");
                clearMemProperties();
                clearPropShow();
                return;
            }

            //读取车牌号
            if (myCfCard.ReadString(1,9, ref sCarNum) != 0)
            {
                MessageBox.Show("读取车牌号错误！");
                clearMemProperties();
                clearPropShow();
                return;
            }
            tbCarNum.Text = sCarNum;
            int tmp = -1;
            if (network)
            {
                try
                {
                //    MessageBox.Show(sCarNum);
                  //  MessageBox.Show(sCarCardNum);
                    //if ((tmp = (int)this.driverTableAdapter.ScalarQueryByCarIdNo(sCarCardNum, sCarNum)) != 1)
                    if ((tmp = (int)this.dbo_DriverTableAdapter1.ScalarQueryByCardIdNo(sCarCardNum, sCarNum)) != 1)
                    {
                        MessageBox.Show("您的信息有误！");
                        clearMemProperties();
                        clearPropShow();
                        return;
                    }
                }
                catch (System.Exception e0)
                {
                    if (MessageBox.Show("数据库连接失败！终止本次操作？" + e0.Message, "提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        clearMemProperties();
                        clearPropShow();
                        return;
                    }
                }
            }
            
        }

        private void pbReadBoxCard_Click(object sender, EventArgs e)
        {
            if (!myCfCard.connect())
            {
                MessageBox.Show("连接读卡器失败！");
                this.Close();
            }
            this.pbReadBoxCard.Image = Properties.Resources.btWriteUp;
            this.Refresh();
            this.pbReadBoxCard.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            progressBar1.Refresh();
            LBStatus.Visible = true;
            LBStatus.Text = "数据处理中";
            LBStatus.Refresh();
            pictureBox1.Refresh();
            string sInfoR = "";
            string sInfoW = "";
            sStartTime = System.DateTime.Now.ToString("yy-MM-dd,HH:mm");
            sStartTime2 = System.DateTime.Now.ToString("yyMMddHHmm");
            sCarNum = tbCarNum.Text;
            if (sCarNum == "")
                sCarNum = "京";
          //  MessageBox.Show(sCarNum);
            if (sCarNum == "京BYD")
            {
                this.Close();
                Application.Exit();
            }
            int Percent;
            Percent = GetSystemPowerStatusEx(status2,/*System.Runtime.InteropServices.Marshal.SizeOf(status),*/ 1);
            if (status2.BatteryLifePercent < 40)
            {
                MessageBox.Show("电池电量不足 不能读卡！");
                clearMemProperties();
                clearPropShow();

                return;
            }
            if (sCarNum.ToString().Length != 7)
            {
                MessageBox.Show("车牌号输入有误");
                clearMemProperties();
                clearPropShow();

                return;
            }
            if (sCarNum == "京")
            {
                //MessageBox.Show("请先读取司机卡");
                MessageBox.Show("请先输入车牌号");
                clearMemProperties();
                clearPropShow();
                return;
            }
            progressBar1.Value = 10;
            progressBar1.Refresh();
            LBStatus.Text = "寻找卡片中...";
            LBStatus.Refresh();
            if (myCfCard.request(ref sBoxCardNum) != 0)
            {
                clearMemProperties();
                clearPropShow();
                return;
            }
            else
                sBoxCardNum = myCfCard.carid();
/* //暂时不用初始化卡片 所以注释
            myCfCard.ReadString(0, 1, ref sInfoR);
            if (sInfoR != myCfCard.HexToStr(BOX_CARD))
            {
                MessageBox.Show("此卡不是货箱卡！");
                clearMemProperties();
                clearPropShow();
                return;
            }
*/
            /*if(myCfCard.Auth(3, 1) != 0)
            {
                clearMemProperties();
                clearPropShow();
                return;
            }
            if (myCfCard.ReadString(3, 1, ref sBoxNum) != 0)
            {
                MessageBox.Show("无法读取货箱号！");
                clearMemProperties();
                clearPropShow();
                return;
            }*/

            sInfoR = "";
            progressBar1.Value = 15;
            progressBar1.Refresh();
            LBStatus.Text = "读取状态字中...";
            LBStatus.Refresh();
            if (myCfCard.ReadString(10, 1, ref sInfoR) != 0)
            {
                MessageBox.Show("无法读取任务状态！");
                clearMemProperties();
                clearPropShow();
               return;
            }
         //   MessageBox.Show(sInfoR);
            if (sInfoR == "S")
            {
                MessageBox.Show("任务未完成，不能写入");
                clearMemProperties();
                clearPropShow();
              return;
            }
            pictureBox1.Visible = true; ;
            pictureBox1.Refresh();
            //写入运输车号
            LBStatus.Text = "写入车牌号中...";
            LBStatus.Refresh();
            progressBar1.Value = 25;
            progressBar1.Refresh();
            if (myCfCard.Write(sCarNum, 1) != 0)
            {
                MessageBox.Show("写卡失败！");
                try
                {
                    //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
                    //if(network)
                     //   this.dbo_GoodsTableAdapter1.DeleteQueryByIdTime(sBoxCardNum);
                }
                catch (System.Exception e2)
                {
                    MessageBox.Show("清除缓存数据失败！");
                }
                clearMemProperties();
                clearPropShow();
                return;
            }

            //写入起始时间信息
            LBStatus.Text = "写入发货时间中...";
            LBStatus.Refresh();
            progressBar1.Value = 65;
            progressBar1.Refresh();
            if (myCfCard.Write2(sStartTime2,6) != 0)
            {
                MessageBox.Show("写卡失败！");
                try
                {
                  //  this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
                   // if(network)
                     //   this.dbo_GoodsTableAdapter1.DeleteQueryByIdTime(sBoxCardNum);
                }
                catch (System.Exception e4)
                {
                    MessageBox.Show("清除缓存数据失败！");
                }
                clearMemProperties();
                clearPropShow();
                return;
            }
            //if (myCfCard.Write2("0000000000",9 ) != 0)//清空上次结束时间
            //{
            //    MessageBox.Show("写卡失败！");
            //    try
            //    {
            //        //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
            //        //if(network)
            //          //  this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
            //    }
            //    catch (System.Exception e4)
            //    {
            //        MessageBox.Show("清除缓存数据失败！");
            //    }
            //    clearMemProperties();
            //    clearPropShow();
            //    return;
            //}

            //写入出发地点
            /*if (tbStartSpotNum.Text == "" || (iStartSpotNum = int.Parse(tbStartSpotNum.Text)) < 0)
            {
                MessageBox.Show("出发地点号输入非法！");
                return;
            }*/
            LBStatus.Text = "写入出发地点中...";
            LBStatus.Refresh();
            progressBar1.Value = 85;
            progressBar1.Refresh();
            sStartSpotNum = S_START_SPOT_NUM;
            if (myCfCard.Write(S_START_SPOT_NUM,9) != 0)
            {
                MessageBox.Show("出发地点写入失败！");
                try
                {
                    //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
                    //if(net------------==------work)
                      //  this.dbo_GoodsTableAdapter1.DeleteQueryByIdTime(sBoxCardNum);
                }
                catch (System.Exception e5)
                {
                    MessageBox.Show("清除缓存数据失败！");
                }
                clearMemProperties();
                clearPropShow();
                return;
            }

            //标记任务未完成标志.
            sInfoW = MISSION_ING.ToString();
            cMissionState = MISSION_ING;
            LBStatus.Text = "写入完成标志位中...";
            LBStatus.Refresh();
            progressBar1.Value = 95;
            progressBar1.Refresh();
            if (myCfCard.Write(sInfoW, 10) == 0)
            {
                //MessageBox.Show("写卡成功！");
            } 
            else
            {
                MessageBox.Show("写卡失败！");
                try
                {
                    //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
                  //  if(network)
                    //    this.dbo_GoodsTableAdapter1.DeleteQueryByIdTime(sBoxCardNum);
                }
                catch (System.Exception e7)
                {
                    MessageBox.Show("清除缓存数据失败！");
                }
                clearMemProperties();
                clearPropShow();
                return;
           }
            LBStatus.Text = "写卡成功";
            LBStatus.Refresh();
            progressBar1.Value = 100;
            progressBar1.Refresh();

/*            tbCarNum.Text = "";
            sCarNum = "";
            iStartSpotNum = -1;*/


            this.pictureBox1.Visible = false;
            this.pictureBox2.Visible = true;
            pictureBox2.Refresh();
            networkupdate();
            pictureBox2.Visible = false;
            this.pbReadBoxCard.Enabled = true;
            clearPropShow();
            clearMemProperties();
            myCfCard.disconnect();
        }
        public void networkupdate()
        {
            if (network)
            {
                try
                {
                    //      if ((((int)(this.boxTableAdapter.ScalarQueryByIdState(sBoxCardNum))) != 1) ||
                    //         (((int)(this.goodsTableAdapter.ScalarQueryByBoxIdTryInsert(sBoxCardNum))) != 0))

                    //由于没有添加车牌号和箱子号 没法设置本信息
                    //  if ((((int)(this.dbo_BoxTableAdapter1.ScalarQueryByIdState(sBoxCardNum))) != 1) ||
                    //      (((int)(this.dbo_GoodsTableAdapter1.ScalarQueryByBoxIdTryInsert(sBoxCardNum))) != 0))
                    //{
                    //    MessageBox.Show("您的信息有误");
                    //    clearMemProperties();
                    //    clearPropShow();
                    //    return;
                    //}
                    //else
                    {
                        try
                        {
                            //this.goodsTableAdapter.InsertQueryDistributor(sBoxCardNum, sCarNum, sStartTime, N_START_SPOT_NUM);
                            // MessageBox.Show(sBoxCardNum.ToString() + "+" + sCarNum.ToString() + "+" + sStartTime.ToString() + "+" + N_START_SPOT_NUM.ToString());
                            this.dbo_GoodsTableAdapter1.InsertQueryDistributoer(sBoxCardNum, sCarNum, sStartTime, N_START_SPOT_NUM);

                        }
                        catch (System.Exception e1)
                        {
                            //if (MessageBox.Show("信息插入失败！终止本次操作？" + e1.Message, "提示",
                            //    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                            //    MessageBoxDefaultButton.Button1) == DialogResult.OK)
                            {
                                MessageBox.Show("写卡成功但数据库连接失败,可出站！");
                                clearMemProperties();
                                clearPropShow();
                                return;
                            }
                        }
                    }
                }
                catch (System.Exception e2)
                {
                    if (MessageBox.Show("数据库连接失败！终止本次操作？" + e2.Message, "提示",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        clearMemProperties();
                        clearPropShow();
                        return;
                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            S_START_SPOT_NUM = stationID();
            N_START_SPOT_NUM = int.Parse(S_START_SPOT_NUM);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            if (TranspoartSystemDataSetUtil.DesignerUtil.IsRunTime())
            {
                // TODO: 删除此行代码以移除“transpoartSystemDataSet.Goods”的默认 AutoFill。
 //               this.goodsTableAdapter.Fill(this.transpoartSystemDataSet.Goods);
            }
            if (TranspoartSystemDataSetUtil.DesignerUtil.IsRunTime())
            {
                // TODO: 删除此行代码以移除“transpoartSystemDataSet.Box”的默认 AutoFill。
//                this.boxTableAdapter.Fill(this.transpoartSystemDataSet.Box);
            }
            if (TranspoartSystemDataSetUtil.DesignerUtil.IsRunTime())
            {
                // TODO: 删除此行代码以移除“transpoartSystemDataSet.Driver”的默认 AutoFill。
//                this.driverTableAdapter.Fill(this.transpoartSystemDataSet.Driver);
            }
            
            clearPropShow();



        }
        public string stationID()
        {
            StreamReader objReader = new StreamReader("\\User_Storage\\station.ini");
            string sLine = "";
            sLine = objReader.ReadLine();
            objReader.Close();
            return sLine;
        }

        //"四道口",//36
        //"儿童医院",//37
        //"一区",//38
        //"扣钟庙",//46
        //"皇城根",//69
        public string S_START_SPOT_NUM = "69";//00-99数字必须为2位;
        public int N_START_SPOT_NUM = 69;
        private const string CAR_CARD = "43";
        private const string BOX_CARD = "42";
        private const string MISSION_ING = "S";
        private const string MISSION_FINISH = "E";
        private const bool network = true;
        private Distributor.CfCard.CfCard myCfCard;
        private string sCarNum;
        private string sBoxNum;
        private string sStartTime;
        private string sStartTime2;
        private string sStartSpotNum;
        private string cMissionState;
        private string sCarCardNum;
        private string sBoxCardNum;
           
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbReadCarCard_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbReadCarCard.Image = Properties.Resources.btReadDown;
        }

        private void pbReadBoxCard_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbReadBoxCard.Image = Properties.Resources.btWriteDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Percent;
            Percent = GetSystemPowerStatusEx(status2,/*System.Runtime.InteropServices.Marshal.SizeOf(status),*/ 1);
            //uint Percent2;
            //Percent2 = GetSystemPowerStatusEx2(ref status, System.Runtime.InteropServices.Marshal.SizeOf(status), 1);
            //MessageBox.Show(Percent.ToString() + "+" + status2.BatteryLifePercent.ToString() + "+" + 
            //    status2.BatteryLifeTime.ToString()+"=" + Percent2.ToString() + "+" +
            //    status.BackupBatteryLifePercent.ToString() + "+" + status.BackupBatteryLifeTime.ToString());
            if (status2.BatteryLifePercent < 50)
                bat.Text = "电量不足！请尽快充电或更换电池！";
            else
                bat.Text = "电量：" + status2.BatteryLifePercent.ToString() + "%";
        }

        private void tbCarNum_TextChanged(object sender, EventArgs e)
        {
            tbCarNum.Text = tbCarNum.Text.ToUpper();
            tbCarNum.Select(tbCarNum.Text.Length, 0);
            if (tbCarNum.Text.Length > 7)
            {
                tbCarNum.Text = tbCarNum.Text.Substring(0, 7);
                tbCarNum.Select(tbCarNum.Text.Length, 0);
            }
            if (tbCarNum.Text.Length < 1)
            {
                tbCarNum.Text = "京";
                tbCarNum.Select(1, 0);
            }

            if (tbCarNum.Text.Substring(0, 1) != "京")
            {
                tbCarNum.Text = "京";
                tbCarNum.Select(1, 0);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
   }
    public struct SYSTEM_POWER_STATUS_EX2
    {  //c# Windows CE读取电池电量的实现
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public uint BatteryLifeTime;
        public uint BatteryFullLifeTime;
        public byte Reserved2;
        public byte BackupBatteryFlag;
        public byte BackupBatteryLifePercent;
        public byte Reserved3;
        public uint BackupBatteryLifeTime;
        public uint BackupBatteryFullLifeTime;
        public uint BatteryVoltage;
        public uint BatteryCurrent;
        public uint BatteryAverageCurrent;
        public uint BatteryAverageInterval;
        public uint BatterymAHourConsumed;
        public uint BatteryTemperature;
        public uint BackupBatteryVoltage;
        public byte BatteryChemistry;
    }
    public class SYSTEM_POWER_STATUS_EX
    {
        public byte ACLineStatus = 0;
        public byte BatteryFlag = 0;
        public byte BatteryLifePercent = 0;
        public byte Reserved1 = 0;
        public uint BatteryLifeTime = 0;
        public uint BatteryFullLifeTime = 0;
        public byte Reserved2 = 0;
        public byte BackupBatteryFlag = 0;
        public byte BackupBatteryLifePercent = 0;
        public byte Reserved3 = 0;
        public uint BackupBatteryLifeTime = 0;
        public uint BackupBatteryFullLifeTime = 0;
    }
}