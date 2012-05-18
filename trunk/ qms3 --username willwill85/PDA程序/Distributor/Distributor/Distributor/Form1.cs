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
using SEUIC.Phone;
using SEUIC.Phone.Module;
using SEUIC.Phone.RAS;
using System.Threading;
using Microsoft.WindowsCE.Forms;
using System.Diagnostics;
using System.Net;
namespace Distributor
{

    public partial class Form1 : Form
    {

        /// <summary>
        ///  
        /// </summary>
        #region 全局变量
        public const int WM_RESUME = 0x4010;
        public static string S_START_SPOT_NUM = "69";//00-99数字必须为2位;
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
        private phone currentphone;
        Thread mytask;
        Form2 f2;
        ProcMessageWindow MsgWin;

        //拨号
        private string entryname = "Dail-up";
        private static Call call;
        bool bConnected = false;
        static Ras ras;
        public Thread ringthd;

        //信号level 定义RSSI
        const int s1 = 10;
        const int s2 = 25;
        const int s3 = 50;
        const int s4 = 75;
        const int s5 = 100;

        #endregion
        /// <summary>
        ///  
        /// </summary>
        #region 引用的dll
        private SYSTEM_POWER_STATUS_EX2 status = new SYSTEM_POWER_STATUS_EX2();
        private SYSTEM_POWER_STATUS_EX status2 = new SYSTEM_POWER_STATUS_EX();
        [DllImport("coredll")]
        private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, int fUpdate);
        [DllImport("coredll")]
        public static extern void SystemIdleTimerReset();
        [DllImport("coredll.dll")]
        public static extern uint GetSystemPowerStatusEx2(ref SYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2, int dwLen, int fUpdate);
        [DllImport("D300SysUI.dll")]
        public static extern bool D300SysUI_SetSystemPowerStateSuspend();

        [DllImport("D300SysUI.dll")]
        public static extern void D300SysUI_SetResumeRegister(IntPtr hResumeWnd, int msgID);
        [DllImport("coredll.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        [DllImport("Coredll.dll")]
        private extern static bool PlaySound(string strFile, IntPtr hMod, int flag);

        #endregion
        /// <summary>
        ///  
        /// </summary>
        #region 电源管理
        private void timer2_Tick(object sender, EventArgs e)
        {
            D300SysUI_SetSystemPowerStateSuspend();
        }

        internal class ProcMessageWindow : MessageWindow
        {
            public ProcMessageWindow()
            {

            }

            protected override void WndProc(ref Message msg)
            {
                switch (msg.Msg)
                {
                    case WM_RESUME:
                        {
                            Thread th1 = new Thread(checkmyself);
                            th1.Start();
                        }
                        break;
                }
                //  base.WndProc(ref msg);
            }

        }

        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
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
        #endregion
        /// <summary>
        ///  
        /// </summary>
        #region 读卡 写卡
        //读司机卡
        private void pbReadCarCard_Click(object sender, EventArgs e)
        {
            pbReadCarCard.Enabled = false;
            pbReadBoxCard.Enabled = false;
            useractive();
            if (!myCfCard.connect())
            {
                if (!myCfCard.connect())
                {
                    f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                    // PlaySound("\\User_Storage\\sound\\nocard.wav", IntPtr.Zero, 0x0002);
                    string xx = tbCarNum.Text;
                    clearMemProperties();
                    clearPropShow();
                    tbCarNum.Text = xx;
                    return;
                }
            }

            this.pbReadCarCard.Image = Properties.Resources.btReadUp;
            this.Refresh();


            string sInfoR = "";

            if (myCfCard.request(ref sCarCardNum) != 0)
            {
                clearMemProperties();
                clearPropShow();
                return;
            }
            else
                try
                {
                    sCarCardNum = myCfCard.carid();
                }
                catch
                {
                    f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                    // PlaySound("\\User_Storage\\sound\\nocard.wav", IntPtr.Zero, 0x0002);
                    string xx = tbCarNum.Text;
                    clearMemProperties();
                    clearPropShow();
                    tbCarNum.Text = xx;
                    return;
                }


            //读取卡类型
            //     if (myCfCard.ReadString(0, 1, ref sInfoR) != 0)
            if (!CfCard.CfCard.read())
            {
                f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                clearMemProperties();
                clearPropShow();
                return;
            }
            //  MessageBox.Show(myCfCard.StrToHex(sInfoR));
            sInfoR = CfCard.CfCard.myread.Cardtype;
            if (sInfoR != "B")
            {
                //MessageBox.Show("此卡不是司机卡！");
                f2.setmsg("此卡不是司机卡", 3, "\\User_Storage\\sound\\driver.wav");
                //  PlaySound("\\User_Storage\\sound\\driver.wav", IntPtr.Zero, 0x0002);

                clearMemProperties();
                clearPropShow();
                return;
            }

            //读取车牌号
            string Truckno = "京" + CfCard.CfCard.myread.CarNum;
            //if (myCfCard.ReadString(1,9, ref Truckno) != 0)
            {
                // MessageBox.Show("读取车牌号错误！");
                // f2.setmsg("读卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
                //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                //  
                //  clearMemProperties();
                // //  clearPropShow();
                // return;
            }
            sCarNum = Truckno;
            //   tbCarNum.Text = sCarNum;


            SendStr(sCarNum);
            clearMemProperties();
            clearPropShow();
            tbCarNum.Text = Truckno;


        }
        private void SendStr(string text)
        {
            if (this.tbCarNum.InvokeRequired)
            {
                SendStrCallback d = new SendStrCallback(SendStr);
                this.Invoke(d, new object[] { text });
            }
            else
            {

                tbCarNum.Text = sCarNum;
            }
        }
        //读箱卡
        private void pbReadBoxCard_Click(object sender, EventArgs e)
        {
            useractive();
            pbReadCarCard.Enabled = false;
            if (!myCfCard.connect())
            {
                if (!myCfCard.connect())
                {
                    f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                    // PlaySound("\\User_Storage\\sound\\nocard.wav", IntPtr.Zero, 0x0002);
                    string xx = tbCarNum.Text;
                    clearMemProperties();
                    clearPropShow();
                    tbCarNum.Text = xx;
                    return;
                }
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
            //   pictureBox1.Refresh();
            string sInfoR = "";
            string sInfoW = "";
            sStartTime = System.DateTime.Now.ToString("yy-MM-dd,HH:mm");
            sStartTime2 = System.DateTime.Now.ToString("yyMMddHHmm");
            System.DateTime dt2 = System.DateTime.Now;
            sCarNum = tbCarNum.Text;
            if (sCarNum == "")
                sCarNum = "京";
            if (sCarNum == "京BYD")
            {
                myCfCard.disconnect();
                clearMemProperties();
                clearPropShow();
                mytask.Abort();
                Program.SingleInstance.DisposeRunFlag();
                Initialize.UnInit();
                Application.Exit();
                Process.GetCurrentProcess().Kill();
                return;
            }
            int Percent;
            Percent = GetSystemPowerStatusEx(status2,/*System.Runtime.InteropServices.Marshal.SizeOf(status),*/ 1);
            if (status2.BatteryLifePercent < 35)
            {
                f2.setmsg("电量不足，请充电", 3, "\\User_Storage\\sound\\nobat.wav");

                clearMemProperties();
                clearPropShow();

                return;
            }
            if (sCarNum.ToString().Length != 7)
            {
                f2.setmsg("请先读司机卡", 3, "\\User_Storage\\sound\\dfirst.wav");
                clearMemProperties();
                clearPropShow();

                return;
            }
            if (sCarNum == "京")
            {
                f2.setmsg("请先读司机卡", 3, "\\User_Storage\\sound\\dfirst.wav");
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
                f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                // PlaySound("\\User_Storage\\sound\\nocard.wav", IntPtr.Zero, 0x0002);
                string xx = tbCarNum.Text;
                clearMemProperties();
                clearPropShow();
                tbCarNum.Text = xx;
                return;
            }

            else
            {
                try
                {
                    sBoxCardNum = myCfCard.carid();
                }
                catch
                {
                    f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                    // PlaySound("\\User_Storage\\sound\\nocard.wav", IntPtr.Zero, 0x0002);
                    string xx = tbCarNum.Text;
                    clearMemProperties();
                    clearPropShow();
                    tbCarNum.Text = xx;
                    return;
                }

            }

            if (!CfCard.CfCard.read())
            {
                f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
                string xx = tbCarNum.Text;
                clearMemProperties();
                clearPropShow();
                tbCarNum.Text = xx;
                return;
            }
            //  MessageBox.Show(myCfCard.StrToHex(sInfoR));
            sInfoR = CfCard.CfCard.myread.Cardtype;

            if (sInfoR == "B")
            {
                f2.setmsg("不是货箱卡", 3, "\\User_Storage\\sound\\box.wav");
                //   PlaySound("\\User_Storage\\sound\\box.wav", IntPtr.Zero, 0x0002); ;
                string xx = tbCarNum.Text;
                clearMemProperties();
                clearPropShow();
                tbCarNum.Text = xx;
                return;
            }


            sInfoR = "";
            /* 其它
             厨余垃圾
             餐厨垃圾
             可回收垃圾*/


            progressBar1.Value = 15;
            progressBar1.Refresh();
            LBStatus.Text = "读取状态字中...";
            LBStatus.Refresh();
            sInfoR = CfCard.CfCard.myread.Status;
            //   MessageBox.Show(sInfoR);

            if (sInfoR == "S")
            {
                // MessageBox.Show("任务未完成，不能写入");
                DateTime nt=System.DateTime.Now;
                byte[] tempn=new byte[3];
               tempn[0] = Convert.ToByte((nt.Year - 2000).ToString(),16);

               tempn[1] = Convert.ToByte(nt.Month.ToString(), 16);


               tempn[2] = Convert.ToByte(nt.Day.ToString(), 16);
               string nowt = tempn[0].ToString("X2") + tempn[1].ToString("X2") + tempn[2].ToString("X2");
                //  MessageBox.Show(nowt);
                #region 88用于测试
               if (S_START_SPOT_NUM!="88")
                {
                       if (CfCard.CfCard.myread.date == nowt)
                       {
                           f2.setmsg("此卡已经发送", 1, "\\User_Storage\\sound\\done.wav");
                           //  PlaySound("\\User_Storage\\sound\\done.wav", IntPtr.Zero, 0x0002);

                           clearMemProperties();
                           clearPropShow();
                           return;
                       }
                }
                #endregion
            }

            //写入运输车号
            LBStatus.Text = "写入垃圾类型...";
            LBStatus.Refresh();
            progressBar1.Value = 21;
            progressBar1.Refresh();
            switch (comboBox1.Text)
            {
                case "其它":
                    {
                        sInfoR = "0";
                        break;
                    }
                case "厨余垃圾":
                    {
                        sInfoR = "1";
                        break;
                    }
                case "餐厨垃圾":
                    {
                        sInfoR = "2";
                        break;
                    }

                case "可回收垃圾":
                    {
                        sInfoR = "3";
                        break;
                    }
                default:
                    sInfoR = "0";
                    break;
            }
            string strtype = sInfoR;
            string endstation = "1";
            if (comboBox1.Text == "马家楼")
                endstation = "2";


            // if (myCfCard.Write(sInfoR, 0) != 0)


            if (!CfCard.CfCard.newwrite(0, System.Text.Encoding.Default.GetBytes(sInfoR)))
            {
                // MessageBox.Show("写卡失败！");
                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
                // PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);

                clearMemProperties();
                clearPropShow();
                return;
            }
            LBStatus.Text = "写入车牌号中...";
            LBStatus.Refresh();
            progressBar1.Value = 25;
            progressBar1.Refresh();
            //if (myCfCard.Write(sCarNum, 1) != 0)
            if (!CfCard.CfCard.newwrite(1, System.Text.Encoding.Default.GetBytes(sCarNum)))
            {
                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
                // PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);

                clearMemProperties();
                clearPropShow();
                return;
            }

            //写入起始时间信息
            LBStatus.Text = "写入发货时间中...";
            LBStatus.Refresh();
            progressBar1.Value = 65;
            progressBar1.Refresh();
            // if (myCfCard.Write2(sStartTime2,6) != 0)
            byte[] temp = new byte[6];
            temp[0] = Convert.ToByte((dt2.Year - 2000).ToString(),16);

            temp[1] = Convert.ToByte(dt2.Month.ToString(), 16);


            temp[2] = Convert.ToByte(dt2.Day.ToString(), 16);

            temp[3] = Convert.ToByte(dt2.Hour.ToString(), 16);

            temp[4] =Convert.ToByte(dt2.Minute.ToString(), 16);

 
            temp[5] = 0x00;


            if (!CfCard.CfCard.newwrite(6, temp))
            {
                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
                //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);

                clearMemProperties();
                clearPropShow();
                return;
            }
            LBStatus.Text = "写入出发地点中...";
            LBStatus.Refresh();
            progressBar1.Value = 85;
            progressBar1.Refresh();
            sStartSpotNum = S_START_SPOT_NUM;
            // if (myCfCard.Write(S_START_SPOT_NUM,9) != 0)
            if (!CfCard.CfCard.newwrite(9, System.Text.Encoding.Default.GetBytes(sStartSpotNum)))
            {
                //  MessageBox.Show("出发地点写入失败！");
                //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
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
            //if (myCfCard.Write(sInfoW, 10) == 0)
            if (CfCard.CfCard.newwrite(10, System.Text.Encoding.Default.GetBytes(sInfoW)))
            {
                //MessageBox.Show("写卡成功！");

                // !@!#!#!#!#
                //    PlaySound("\\User_Storage\\sound\\suc.wav", IntPtr.Zero, 0x0002);
                f2.setmsg("写卡成功", 1, "\\User_Storage\\sound\\suc.wav");
                Updater.insertTask(sBoxCardNum, sCarNum, sStartTime, N_START_SPOT_NUM,int.Parse(strtype),endstation);
            }
            else
            {
                //      PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
                try
                {
                    //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
                    //  if(network)
                    //    this.dbo_GoodsTableAdapter1.DeleteQueryByIdTime(sBoxCardNum);
                }
                catch (System.Exception)
                {
                    
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


            //  this.pictureBox1.Visible = false;
            //   this.pictureBox2.Visible = true;
            //   pictureBox2.Refresh();
            // networkupdate();
            //    pictureBox2.Visible = false;
            this.pbReadBoxCard.Enabled = true;
            clearPropShow();
            clearMemProperties();
            myCfCard.disconnect();
        }

        #endregion
        /// <summary>
        ///  
        /// </summary>
        #region 初始化和配置
        //获得始发站号
        public static string stationID()
        {
            StreamReader objReader = new StreamReader("\\User_Storage\\station.ini");
            string sLine = "";
            sLine = objReader.ReadLine();
            objReader.Close();
            return sLine;
        }
        //获得电话号码
        public string phonenum()
        {
            StreamReader objReader = new StreamReader("\\User_Storage\\phone.ini");
            string sLine = "";
            sLine = objReader.ReadLine();
            objReader.Close();
            return sLine;
        }

        //加载
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MsgWin = new ProcMessageWindow();
            D300SysUI_SetResumeRegister(MsgWin.Hwnd, WM_RESUME);
            //   D300SysUI_SetResumeRegister(mycallback, WM_RESUME);
            panel1.Visible = false;
            Initialize.Init();
            ras = Ras.GetInstance();
            call = Call.GetInstance();
            comboBox1.SelectedIndex = 0;
            S_START_SPOT_NUM = stationID();
            N_START_SPOT_NUM = int.Parse(S_START_SPOT_NUM);
            f2 = new Form2();
            f2.Show();
            f2.Visible = false;
            call.OnActiveEvent += new Call.NotifyEvent(OnCallAnwserEvent);
            call.OnIncomingEvent += new Call.NotifyEvent(OnCallInEvent);
            call.OnHangUpEvent += new Call.NotifyEvent(OnCallHangupEvent);
            call.OnDialingEvent += new Call.NotifyEvent(OnCallDialingEvent);
            call.OnMissingEvent += new Call.NotifyEvent(call_OnMissingEvent);
            ras.OnConnectedEvent += new Ras.NotifyEvent(OnConnectedEvent);
            ras.OnDisconnectedEvent += new Ras.NotifyEvent(OnDisconnectedEvent);

            if (checknet())
                NetPIC.BackColor = Color.Green;
            else
                NetPIC.BackColor = Color.Red;

            //      pictureBox1.Visible = false;
            //      pictureBox2.Visible = false;
            SEUIC.Phone.Initialize.Init();
            backgroundwork();
            clearPropShow();
        }

        public Form1()
        {
            InitializeComponent();
            myCfCard = new Distributor.CfCard.CfCard();
            clearMemProperties();
        }


        #endregion
        /// <summary>
        ///  
        /// </summary>
        #region 电话 和 网络


        private void OnDisconnectedEvent()
        {
            //   NetPIC.BackColor = Color.Red;
        }
        private void OnConnectedEvent()
        {
            try
            {
                //  NetPIC.BackColor = Color.Green;
            }
            catch
            {

            }

        }
        public delegate void connectinvoke();
        //来电时收到该事件
        private void OnCallInEvent()
        {
            this.Invoke(new RefreshMessageHandle(callin), new object[] { " " });

        }
        private void callin(string str)
        {
            //this.Invoke(new RefreshMessageHandle(hangup), new object[] { });
            label4.Text = "指挥中心来电,请接听";

            //.Visible = true;
            panel1.Visible = true;
            ringthd = new Thread(ring);
            ringthd.Start();
            useractive();
        }
        private delegate void RefreshMessageHandle(string sMsgContent);
        //挂断时收到该事件
        private void OnCallHangupEvent()
        {
            this.Invoke(new RefreshMessageHandle(hangup), new object[] { " " });
        }
        private void hangup(string str)
        {
            if (label4.Text == "指挥中心来电,请接听")
                ringthd.Abort();
            //ShowMessage("Phone hangup");
            label4.Text = "呼叫指挥中心";
            panel1.Visible = false;
            useractive();
        }
        void call_OnMissingEvent()
        {
            //throw new NotImplementedException();
            this.Invoke(new RefreshMessageHandle(hangup), new object[] { " " });
        }
        //应答时收到该事件
        private void OnCallAnwserEvent()
        {
            //  timer2.Enabled = false;
            //ShowMessage("Phone accept");
        }
        //拨打电话收到该事件
        private void OnCallDialingEvent()
        {
            //   timer2.Enabled = false;
            //ShowMessage("Is dialing");
        }

        //接通键
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            useractive();
            timer2.Enabled = false;
            pictureBox5.Image = Properties.Resources.phoneupDonw;
            this.Refresh();
            pictureBox5.Refresh();
            if (label4.Text == "请用方向箭头选择呼叫目标")
            {
                string strphnum;
                if (currentphone.privatephone)
                    strphnum = textBox1.Text;
                else
                    strphnum = label6.Text;
                label4.Text = "呼叫中请等待";
                SEUIC.Phone.Call.MakeCall(strphnum);
                //   MessageBox.Show(strphnum);
                OnCallDialingEvent();
            }
            if (label4.Text == "指挥中心来电,请接听")
            {
                SEUIC.Phone.Call.Answer();
                ringthd.Abort();
                this.OnCallAnwserEvent();
            }
            pictureBox5.Image = Properties.Resources.phoneupUp;
            this.Refresh();
            pictureBox5.Refresh();
        }
        //挂断键
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            useractive();
            pictureBox6.Image = Properties.Resources.phonedownDown;
            this.Refresh();
            pictureBox5.Refresh();
            SEUIC.Phone.Call.HangUp();
            this.OnCallHangupEvent();
            pictureBox6.Image = Properties.Resources.phonedownUp;
            this.Refresh();
            pictureBox5.Refresh();
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
        }
        //掉出电话界面
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            useractive();
            panel1.Visible = !panel1.Visible;
            label4.Text = "请用方向箭头选择呼叫目标";
            phonelist.getxml();
            currentphone = phonelist.nextphone();
            currentphone = phonelist.lastphone();
            textBox1.Text = "";
            textBox1.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            label5.Text = currentphone.name;
            if (!currentphone.privatephone)
            {
                label6.Text = currentphone.phonenum;
                label6.Visible = true;
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
                textBox1.Focus();
                label6.Visible = false;
            }
        }


        //显示信号强度
        public void setSignal(int rssi)
        {
            if (rssi <= s1)
            {

                signalpic.Image = Properties.Resources.nm_signal_00;
                signalpic.Refresh();
                signalpic.Show();
                return;
            }
            if (rssi <= s2)
            {
                signalpic.Image = Properties.Resources.nm_signal_25;
                signalpic.Refresh();
                signalpic.Show();
                return;
            }
            if (rssi <= s3)
            {
                signalpic.Image = Properties.Resources.nm_signal_50;
                signalpic.Refresh();
                signalpic.Show();
                return;
            }
            if (rssi <= s4)
            {
                signalpic.Image = Properties.Resources.nm_signal_75;
                signalpic.Refresh();
                signalpic.Show();
                return;
            }
            if (rssi <= s5)
            {
                signalpic.Image = Properties.Resources.nm_signal_100;
                signalpic.Refresh();
                signalpic.Show();
                return;
            }

        }


        public void Net_status(bool netstatus)
        {
            if (netstatus)
                taskPIC.BackColor = Color.Green;
            else
                taskPIC.BackColor = Color.Red;
        }
        //唤醒后检查网络 并更新使用log
        public static void checkmyself()
        {
            int iloop = 10;
            int iRssi = 0;
            ras.HangUp();
            Thread.Sleep(10000);

            iRssi = Module.GetRSSI();
            if (iRssi <= 0)
            {
                SEUIC.Phone.Module.Module.ResetModule();
                Thread.Sleep(3000);
                for (int i = 0; i < iloop; i++)
                {
                    iRssi = Module.GetRSSI();
                    if (iRssi > 0)
                        break;
                    Thread.Sleep(2000);
                }
            }
            dialup();
            System.Threading.Thread.Sleep(10000);
            try
            {
                HttpWebRequest myreq = (HttpWebRequest)WebRequest.Create("http://180.186.12.183/log/add.php?no=" + S_START_SPOT_NUM);
                HttpWebResponse myrep = (HttpWebResponse)myreq.GetResponse();
            }
            catch { }

        }
        #endregion 
        /// <summary>
        ///  
        /// </summary>    
        #region 其他
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
            useractive();
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                if (panel1.Visible == true)
                {
                    currentphone = phonelist.lastphone();
                    label5.Text = currentphone.name;
                    if (!currentphone.privatephone)
                    {
                        label6.Text = currentphone.phonenum;
                        label6.Visible = true;
                        textBox1.Visible = false;
                    }
                    else
                    {
                        textBox1.Visible = true;
                        textBox1.Focus();
                        label6.Visible = false;
                    }
                }

            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                if (panel1.Visible == true)
                {
                    currentphone = phonelist.nextphone();
                    label5.Text = currentphone.name;
                    if (!currentphone.privatephone)
                    {
                        label6.Text = currentphone.phonenum;
                        label6.Visible = true;
                        textBox1.Visible = false;
                    }
                    else
                    {
                        textBox1.Visible = true;
                        textBox1.Focus();
                        label6.Visible = false;
                    }
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                if (panel1.Visible == true)
                {
                    currentphone = phonelist.lastphone();
                    label5.Text = currentphone.name;
                    if (!currentphone.privatephone)
                    {
                        label6.Text = currentphone.phonenum;
                        label6.Visible = true;
                        textBox1.Visible = false;
                    }
                    else
                    {
                        textBox1.Visible = true;
                        textBox1.Focus();
                        label6.Visible = false;
                    }
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                if (panel1.Visible == true)
                {
                    currentphone = phonelist.nextphone();
                    label5.Text = currentphone.name;
                    if (!currentphone.privatephone)
                    {
                        label6.Text = currentphone.phonenum;
                        label6.Visible = true;
                        textBox1.Visible = false;
                    }
                    else
                    {
                        textBox1.Visible = true;
                        textBox1.Focus();
                        label6.Visible = false;
                    }
                }
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }



        }
        private void textbox1_focus(object sender, EventArgs e)
        {
            if (panel1.Visible)
                textBox1.Focus();
        }
        private void tbCarNum_TextChanged(object sender, EventArgs e)
        {
            useractive();
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

        //cdma2000网络拨号
        public static void dialup()
        {
            Initialize.Init();
            // SEUIC.Phone.Initialize.UnInit();
            //  Thread.Sleep(100);
            //    SEUIC.Phone.Initialize.Init();
            ras = Ras.GetInstance();
            int iloop = 10;
            int iRssi = 0;
            iRssi = Module.GetRSSI();
            if (iRssi <= 0)
            {
                SEUIC.Phone.Module.Module.ResetModule();
                Thread.Sleep(3000);
                for (int i = 0; i < iloop; i++)
                {
                    iRssi = Module.GetRSSI();
                    if (iRssi > 0)
                        break;
                    Thread.Sleep(2000);
                }
            }
            ras.RasDialMode = SEUIC.Phone.RAS.RasDialMode.Sync;//同步拨号,SEUIC.Phone.RAS.RasDialMode.Async 为异步拨号
            try
            {
                ras.DialUp("card", "card", "#777");
            }
            catch
            {

            }

        }


        public delegate void SendStrCallback(string text);
        //电话响铃
        public static void ring()
        {
            while (true)
            {
                PlaySound("\\User_Storage\\ring.wav", IntPtr.Zero, 0x0002);
                System.Threading.Thread.Sleep(1000);
            }
        }

        //检查网络状况
        public bool checknet()
        {
            RASConnState netstate = RASConnState.RASCS_Disconnected;
            netstate = ras.GetStatus();

            if (netstate == RASConnState.RASCS_Connected)
            {

                Ras.SetDiagnoseDestAddress("74.82.63.102");
                if (Ras.RASPingTestEnable())
                    return true;

            }
            return false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            myCfCard.disconnect();
            useractive();
            // SEUIC.Phone.Initialize.UnInit();//必须要调用。
        }

        protected void clearPropShow()
        {
            tbStartSpotNum.Text = S_START_SPOT_NUM;
            tbCarNum.Focus();
            tbCarNum.Text = "京";
            tbCarNum.Select(1, 0);
            LBStatus.Visible = false;
            progressBar1.Visible = false;
            //    pictureBox1.Visible = false;
            //   pictureBox2.Visible = false;
            pbReadBoxCard.Enabled = true;
            pbReadCarCard.Enabled = true;
            useractive();
            //  pictureBox1.Visible = false;
        }
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            //   SEUIC.Phone.Initialize.UnInit();
        }
        #endregion
        /// <summary>
        ///  
        /// </summary>
        #region 任务与线程


        public delegate void NetInvoke(bool netstatus);
        public delegate void TaskInvoke(bool taskstatus);
        //更新电量和网络状况
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
            {
                bat.Text = "电量不足！" + status2.BatteryLifePercent.ToString() + "%";
                bat.ForeColor = Color.Red;
            }
            else
            {
                bat.Text = "电量：" + status2.BatteryLifePercent.ToString() + "%";
                bat.ForeColor = Color.Green;
            }
            int sig = Module.GetHDRRSSI();
            //label2.Text = sig.ToString();
            setSignal(sig);
            if (ras.GetStatus() == RASConnState.RASCS_Connected)
                NetPIC.BackColor = Color.Green;
            else
                NetPIC.BackColor = Color.Red;
        }
        //重置睡眠定时器
        public void useractive()
        {
            timer2.Enabled = false;
            timer2.Interval = 200000;
            timer2.Enabled = true;
        }

        public void backgroundwork()
        {
            mytask = new Thread(NettaskTH);
            mytask.Start();
        }

        //更新xml的工作
        public void NettaskTH()
        {
            NetInvoke updatetask = new NetInvoke(Net_status);
            // TaskInvoke statusreport = new StatusInvoke(updateUIprocess);
            bool isin = false;
            while (true)
            {

                if (Updater.isBusy() && !isin)
                {
                    this.BeginInvoke(updatetask, new Object[] { false });
                    {
                        isin = true;
                        if (!checknet())
                        {
                            dialup();
                            System.Threading.Thread.Sleep(1000);
                        }
                        Updater.doWork();
                        isin = false;
                    }

                }
                else
                    this.BeginInvoke(updatetask, new Object[] { true });
                System.Threading.Thread.Sleep(20000);


            }
        }

        #endregion

    }



}