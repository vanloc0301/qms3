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

    private bool bConnected;
    private bool bdoconnect;
    private const string BOX_CARD = "42";

    private static Call call = Call.GetInstance();
    private const string CAR_CARD = "43";
    private string cMissionState;

    private phone currentphone;

    private string entryname = "Dail-up";
    private Form2 f2;
    private const string MISSION_FINISH = "E";
    private const string MISSION_ING = "S";
    private ProcMessageWindow MsgWin;
    private Distributor.CfCard.CfCard myCfCard;
    private Thread mytask;
    public int N_START_SPOT_NUM = 0x45;

    private const bool network = true;

    private static Ras ras = Ras.GetInstance();
    public Thread ringthd;
    public static string S_START_SPOT_NUM = "69";
    private string sBoxCardNum;
    private string sBoxNum;
    private string sCarCardNum;
    private string sCarNum;
    private int SND_FILENAME = 2;
    private string sStartSpotNum;
    private string sStartTime;
    private string sStartTime2;
    private SYSTEM_POWER_STATUS_EX2 status = new SYSTEM_POWER_STATUS_EX2();
    private SYSTEM_POWER_STATUS_EX status2 = new SYSTEM_POWER_STATUS_EX();


    public const int WM_RESUME = 0x4010;
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
    // Methods
    public Form1()
    {
        this.InitializeComponent();
        this.myCfCard = new Distributor.CfCard.CfCard();
        this.clearMemProperties();
    }

    public void backgroundwork()
    {
        this.mytask = new Thread(new ThreadStart(this.NettaskTH));
        this.mytask.Start();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    public static void checkmyself()
    {
        int num = 10;
        ras.HangUp();
        Thread.Sleep(0x2710);
        if (SEUIC.Phone.Module.Module.GetRSSI() <= 0)
        {
            Initialize.ModuleReset();
            Thread.Sleep(0xbb8);
            for (int i = 0; i < num; i++)
            {
                if (SEUIC.Phone.Module.Module.GetRSSI() > 0)
                {
                    break;
                }
                Thread.Sleep(0x7d0);
            }
        }
        dialup();
        Thread.Sleep(0x2710);
        try
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://180.186.12.183/log/add.php?no=" + S_START_SPOT_NUM);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        }
        catch
        {
        }
    }

    public bool checknet()
    {
        return (ras.GetStatus() == RASConnState.RASCS_Connected);
    }

    protected void clearMemProperties()
    {
        this.sCarNum = "京";
        this.sBoxNum = "";
        this.sStartTime = "";
        this.sStartSpotNum = "";
        this.cMissionState = "E";
        this.sCarCardNum = "";
        this.sBoxCardNum = "";
        this.myCfCard.disconnect();
        this.useractive();
    }

    protected void clearPropShow()
    {
        this.tbStartSpotNum.Text = S_START_SPOT_NUM;
        this.tbCarNum.Focus();
        this.tbCarNum.Text = "京";
        this.tbCarNum.Select(1, 0);
        this.LBStatus.Visible = false;
        this.progressBar1.Visible = false;
        this.pbReadBoxCard.Enabled = true;
        this.useractive();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    [DllImport("D300SysUI.dll")]
    public static extern void D300SysUI_SetResumeRegister(IntPtr hResumeWnd, int msgID);
    [DllImport("D300SysUI.dll")]
    public static extern bool D300SysUI_SetSystemPowerStateSuspend();
    public static void dialup()
    {
        int num = 10;
        if (SEUIC.Phone.Module.Module.GetRSSI() <= 0)
        {
            Initialize.ModuleReset();
            Thread.Sleep(0xbb8);
            for (int i = 0; i < num; i++)
            {
                if (SEUIC.Phone.Module.Module.GetRSSI() > 0)
                {
                    break;
                }
                Thread.Sleep(0x7d0);
            }
        }
        ras.RasDialMode = RasDialMode.Sync;
        ras.DialUp("card", "card", "#777");
    }



    private void Form1_Closing(object sender, CancelEventArgs e)
    {
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        this.useractive();
        if ((e.KeyCode == Keys.Up) && this.panel1.Visible)
        {
            this.currentphone = phonelist.lastphone();
            this.label5.Text = this.currentphone.name;
            if (!this.currentphone.privatephone)
            {
                this.label6.Text = this.currentphone.phonenum;
                this.label6.Visible = true;
                this.textBox1.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
                this.textBox1.Focus();
                this.label6.Visible = false;
            }
        }
        if ((e.KeyCode == Keys.Down) && this.panel1.Visible)
        {
            this.currentphone = phonelist.nextphone();
            this.label5.Text = this.currentphone.name;
            if (!this.currentphone.privatephone)
            {
                this.label6.Text = this.currentphone.phonenum;
                this.label6.Visible = true;
                this.textBox1.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
                this.textBox1.Focus();
                this.label6.Visible = false;
            }
        }
        if ((e.KeyCode == Keys.Left) && this.panel1.Visible)
        {
            this.currentphone = phonelist.lastphone();
            this.label5.Text = this.currentphone.name;
            if (!this.currentphone.privatephone)
            {
                this.label6.Text = this.currentphone.phonenum;
                this.label6.Visible = true;
                this.textBox1.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
                this.textBox1.Focus();
                this.label6.Visible = false;
            }
        }
        if ((e.KeyCode == Keys.Right) && this.panel1.Visible)
        {
            this.currentphone = phonelist.nextphone();
            this.label5.Text = this.currentphone.name;
            if (!this.currentphone.privatephone)
            {
                this.label6.Text = this.currentphone.phonenum;
                this.label6.Visible = true;
                this.textBox1.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
                this.textBox1.Focus();
                this.label6.Visible = false;
            }
        }
        Keys keyCode = e.KeyCode;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        this.MsgWin = new ProcMessageWindow();
        D300SysUI_SetResumeRegister(this.MsgWin.Hwnd, 0x4010);
        this.panel1.Visible = false;
        this.comboBox1.SelectedIndex = 0;
        S_START_SPOT_NUM = stationID();
        this.N_START_SPOT_NUM = int.Parse(S_START_SPOT_NUM);
        this.f2 = new Form2();
        this.f2.Show();
        this.f2.Visible = false;
        call.OnActiveEvent += new Call.NotifyEvent(this.OnCallAnwserEvent);
        call.OnIncomingEvent += new Call.NotifyEvent(this.OnCallInEvent);
        call.OnHangupEvent += new Call.NotifyEvent(this.OnCallHangupEvent);
        call.OnDialingEvent += new Call.NotifyEvent(this.OnCallDialingEvent);
        ras.OnConnectedEvent += new Ras.NotifyEvent(this.OnConnectedEvent);
        ras.OnDisconnectedEvent += new Ras.NotifyEvent(this.OnDisconnectedEvent);
        if (this.checknet())
        {
            this.NetPIC.BackColor = Color.Green;
        }
        else
        {
            this.NetPIC.BackColor = Color.Red;
        }
        Initialize.Init();
        this.backgroundwork();
        this.clearPropShow();
    }

    [DllImport("coredll.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
    [DllImport("coredll")]
    private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, int fUpdate);
    [DllImport("coredll.dll")]
    public static extern uint GetSystemPowerStatusEx2(ref SYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2, int dwLen, int fUpdate);


    public void Net_status(bool netstatus)
    {
        if (netstatus)
        {
            this.taskPIC.BackColor = Color.Green;
        }
        else
        {
            this.taskPIC.BackColor = Color.Red;
        }
    }

    public void NettaskTH()
    {
        NetInvoke method = new NetInvoke(this.Net_status);
        bool flag = false;
        while (true)
        {
            if (Updater.isBusy() && !flag)
            {
                base.BeginInvoke(method, new object[] { false });
                flag = true;
                if (!this.checknet())
                {
                    dialup();
                    Thread.Sleep(0x3e8);
                }
                Updater.doWork();
                flag = false;
            }
            else
            {
                base.BeginInvoke(method, new object[] { true });
            }
            Thread.Sleep(0x4e20);
        }
    }

    private void OnCallAnwserEvent()
    {
        this.timer2.Enabled = false;
    }

    private void OnCallDialingEvent()
    {
        this.timer2.Enabled = false;
    }

    private void OnCallHangupEvent()
    {
        if (this.label4.Text == "指挥中心来电,请接听")
        {
            this.ringthd.Abort();
        }
        this.label4.Text = "呼叫指挥中心";
        this.panel1.Visible = false;
        this.useractive();
    }

    private void OnCallInEvent()
    {
        this.label4.Text = "指挥中心来电,请接听";
        this.panel1.Visible = true;
        this.ringthd = new Thread(new ThreadStart(Form1.ring));
        this.ringthd.Start();
    }

    private void OnConnectedEvent()
    {
        try
        {
            this.NetPIC.BackColor = Color.Green;
        }
        catch
        {
        }
    }

    private void OnDisconnectedEvent()
    {
        this.NetPIC.BackColor = Color.Red;
    }

    private void pbReadBoxCard_Click(object sender, EventArgs e)
    {
        this.useractive();

        this.pbReadBoxCard.Image = Properties.Resources.btWriteUp;
        this.Refresh();
        this.pbReadBoxCard.Enabled = false;
        this.progressBar1.Value = 0;
        this.progressBar1.Visible = true;
        this.progressBar1.Refresh();
        this.LBStatus.Visible = true;
        this.LBStatus.Text = "数据处理中";
        this.LBStatus.Refresh();
        string s = "";
        string str3 = "";
        this.sStartTime = DateTime.Now.ToString("yy-MM-dd,HH:mm");
        this.sStartTime2 = DateTime.Now.ToString("yyMMddHHmm");
        DateTime now = DateTime.Now;
        this.sCarNum = this.tbCarNum.Text;
        if (this.sCarNum == "")
        {
            this.sCarNum = "京";
        }
        if (this.sCarNum == "京BYD")
        {
            this.myCfCard.disconnect();
            this.clearMemProperties();
            this.clearPropShow();
            this.mytask.Abort();
            Application.Exit();
            return;
        }
        GetSystemPowerStatusEx(this.status2, 1);
        if (this.status2.BatteryLifePercent < 25)
        {
            this.f2.setmsg("电量不足，请充电", 3, @"\User_Storage\sound\nobat.wav");
            this.clearMemProperties();
            this.clearPropShow();
            return;
        }
        if (!this.myCfCard.connect())
        {
            this.f2.setmsg("连接读卡器失败", 3, @"\User_Storage\sound\nocard.wav");
            string str = this.tbCarNum.Text;
            this.clearMemProperties();
            this.clearPropShow();
            this.tbCarNum.Text = str;
            return;
        }

        if (this.sCarNum.ToString().Length != 7)
        {
            this.f2.setmsg("请先读司机卡", 3, @"\User_Storage\sound\dfirst.wav");
            this.clearMemProperties();
            this.clearPropShow();
            return;
        }
        if (this.sCarNum == "京")
        {
            this.f2.setmsg("请先读司机卡", 3, @"\User_Storage\sound\dfirst.wav");
            this.clearMemProperties();
            this.clearPropShow();
            return;
        }
        this.progressBar1.Value = 10;
        this.progressBar1.Refresh();
        this.LBStatus.Text = "寻找卡片中...";
        this.LBStatus.Refresh();
        if (this.myCfCard.request(ref this.sBoxCardNum) != 0)
        {
            this.f2.setmsg("没有检测到卡片", 3, @"\User_Storage\sound\nocard.wav");
            string str4 = this.tbCarNum.Text;
            this.clearMemProperties();
            this.clearPropShow();
            this.tbCarNum.Text = str4;
            return;
        }
        try
        {
            this.sBoxCardNum = this.myCfCard.carid();
        }
        catch
        {
            this.f2.setmsg("没有检测到卡片", 3, @"\User_Storage\sound\nocard.wav");
            string str5 = this.tbCarNum.Text;
            this.clearMemProperties();
            this.clearPropShow();
            this.tbCarNum.Text = str5;
            return;
        }
        if (Distributor.CfCard.CfCard.read())
        {
            if (Distributor.CfCard.CfCard.myread.Cardtype == "B")
            {
                this.f2.setmsg("不是货箱卡", 3, @"\User_Storage\sound\box.wav");
                string str7 = this.tbCarNum.Text;
                this.clearMemProperties();
                this.clearPropShow();
                this.tbCarNum.Text = str7;
                return;
            }
            s = "";
            this.progressBar1.Value = 15;
            this.progressBar1.Refresh();
            this.LBStatus.Text = "读取状态字中...";
            this.LBStatus.Refresh();
            if (Distributor.CfCard.CfCard.myread.Status == "S")
            {
                DateTime time2 = DateTime.Now;
                byte[] buffer = new byte[] { Convert.ToByte((time2.Year - 0x7d0).ToString(), 0x10), Convert.ToByte(time2.Month.ToString(), 0x10), Convert.ToByte(time2.Day.ToString(), 0x10) };
                string str8 = buffer[0].ToString("X2") + buffer[1].ToString("X2") + buffer[2].ToString("X2");
                if (Distributor.CfCard.CfCard.myread.date == str8)
                {
                    this.f2.setmsg("此卡已经发送", 1, @"\User_Storage\sound\done.wav");
                    this.clearMemProperties();
                    this.clearPropShow();
                    return;
                }
            }
            this.LBStatus.Text = "写入垃圾类型...";
            this.LBStatus.Refresh();
            this.progressBar1.Value = 0x15;
            this.progressBar1.Refresh();
            string str9 = this.comboBox1.Text;
            if (str9 == null)
            {
                goto Label_0555;
            }
            if (!(str9 == "其它"))
            {
                if (str9 == "厨余垃圾")
                {
                    s = "1";
                    goto Label_055B;
                }
                if (str9 == "餐厨垃圾")
                {
                    s = "2";
                    goto Label_055B;
                }
                if (str9 == "可回收垃圾")
                {
                    s = "3";
                    goto Label_055B;
                }
                goto Label_0555;
            }
            s = "0";
            goto Label_055B;
        }
        this.f2.setmsg("没有检测到卡片", 3, @"\User_Storage\sound\nocard.wav");
        string text = this.tbCarNum.Text;
        this.clearMemProperties();
        this.clearPropShow();
        this.tbCarNum.Text = text;
        return;
    Label_0555:
        s = "0";
    Label_055B:
        if (!Distributor.CfCard.CfCard.newwrite(0, Encoding.Default.GetBytes(s)))
        {
            this.f2.setmsg("写卡失败,请重试", 2, @"\User_Storage\sound\failed.wav");
            this.clearMemProperties();
            this.clearPropShow();
        }
        else
        {
            this.LBStatus.Text = "写入类型中...";
            this.LBStatus.Refresh();
            this.progressBar1.Value = 0x19;
            this.progressBar1.Refresh();

            string sInfoR = "";
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
            if (!CfCard.CfCard.newwrite(0, System.Text.Encoding.Default.GetBytes(sInfoR)))
            {
                // MessageBox.Show("写卡失败！");
                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
                // PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);

                clearMemProperties();
                clearPropShow();
                return;
            }
            this.LBStatus.Text = "写入车牌号中...";
            this.LBStatus.Refresh();
            this.progressBar1.Value = 0x19;
            this.progressBar1.Refresh();

            if (!Distributor.CfCard.CfCard.newwrite(1, Encoding.Default.GetBytes(this.sCarNum)))
            {
                this.f2.setmsg("写卡失败,请重试", 2, @"\User_Storage\sound\failed.wav");
                this.clearMemProperties();
                this.clearPropShow();
            }
            else
            {
                this.LBStatus.Text = "写入发货时间中...";
                this.LBStatus.Refresh();
                this.progressBar1.Value = 0x41;
                this.progressBar1.Refresh();
                byte[] data = new byte[] { Convert.ToByte((now.Year - 0x7d0).ToString(), 0x10), Convert.ToByte(now.Month.ToString(), 0x10), Convert.ToByte(now.Day.ToString(), 0x10), Convert.ToByte(now.Hour.ToString(), 0x10), Convert.ToByte(now.Minute.ToString(), 0x10), 0 };
                if (!Distributor.CfCard.CfCard.newwrite(6, data))
                {
                    this.f2.setmsg("写卡失败,请重试", 2, @"\User_Storage\sound\failed.wav");
                    this.clearMemProperties();
                    this.clearPropShow();
                }
                else
                {
                    this.LBStatus.Text = "写入出发地点中...";
                    this.LBStatus.Refresh();
                    this.progressBar1.Value = 0x55;
                    this.progressBar1.Refresh();
                    this.sStartSpotNum = S_START_SPOT_NUM;
                    if (!Distributor.CfCard.CfCard.newwrite(9, Encoding.Default.GetBytes(this.sStartSpotNum)))
                    {
                        this.f2.setmsg("写卡失败,请重试", 2, @"\User_Storage\sound\failed.wav");
                        this.clearMemProperties();
                        this.clearPropShow();
                    }
                    else
                    {
                        str3 = "S".ToString();
                        this.cMissionState = "S";
                        this.LBStatus.Text = "写入完成标志位中...";
                        this.LBStatus.Refresh();
                        this.progressBar1.Value = 0x5f;
                        this.progressBar1.Refresh();
                        if (Distributor.CfCard.CfCard.newwrite(10, Encoding.Default.GetBytes(str3)))
                        {
                            this.f2.setmsg("写卡成功", 1, @"\User_Storage\sound\suc.wav");
                            string endstation = "1";
                            if (comboBox2.Text == "马家楼")
                                endstation = "2";

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
                            strtype = sInfoR;
                              Updater.insertTask(this.sBoxCardNum, this.sCarNum, this.sStartTime, this.N_START_SPOT_NUM,int.Parse(strtype),endstation);
                        }
                        else
                        {
                            this.f2.setmsg("写卡失败,请重试", 2, @"\User_Storage\sound\failed.wav");
                            this.clearMemProperties();
                            this.clearPropShow();
                            return;
                        }
                        this.LBStatus.Text = "写卡成功";
                        this.LBStatus.Refresh();
                        this.progressBar1.Value = 100;
                        this.progressBar1.Refresh();
                        this.pbReadBoxCard.Enabled = true;
                        this.clearPropShow();
                        this.clearMemProperties();
                        this.myCfCard.disconnect();
                    }
                }
            }
        }
    }

    private void pbReadBoxCard_MouseDown(object sender, MouseEventArgs e)
    {
        this.pbReadBoxCard.Image =Properties.Resources.btWriteDown;
    }

    private void pbReadCarCard_Click(object sender, EventArgs e)
    {
        this.useractive();
        this.pbReadCarCard.Image = Properties.Resources.btReadUp;
        this.Refresh();
        if (!this.myCfCard.connect())
        {
            this.f2.setmsg("连接读卡器失败", 3, @"\User_Storage\sound\nocard.wav");
            string text = this.tbCarNum.Text;
            this.clearMemProperties();
            this.clearPropShow();
            this.tbCarNum.Text = text;
        }
        else
        {

            if (this.myCfCard.request(ref this.sCarCardNum) != 0)
            {
                this.clearMemProperties();
                this.clearPropShow();
            }
            else
            {
                try
                {
                    this.sCarCardNum = this.myCfCard.carid();
                }
                catch
                {
                    this.f2.setmsg("没有检测到卡片", 3, @"\User_Storage\sound\nocard.wav");
                    string str3 = this.tbCarNum.Text;
                    this.clearMemProperties();
                    this.clearPropShow();
                    this.tbCarNum.Text = str3;
                    return;
                }
                if (Distributor.CfCard.CfCard.read())
                {
                    if (Distributor.CfCard.CfCard.myread.Cardtype != "B")
                    {
                        this.f2.setmsg("此卡不是司机卡", 3, @"\User_Storage\sound\driver.wav");
                        this.clearMemProperties();
                        this.clearPropShow();
                    }
                    else
                    {
                        string str4 = "京" + Distributor.CfCard.CfCard.myread.CarNum;
                        this.sCarNum = str4;
                        this.SendStr(this.sCarNum);
                        this.clearMemProperties();
                        this.clearPropShow();
                        this.tbCarNum.Text = str4;
                    }
                }
                else
                {
                    this.f2.setmsg("没有检测到卡片", 3, @"\User_Storage\sound\nocard.wav");
                    this.clearMemProperties();
                    this.clearPropShow();
                }
            }
        }
    }

    private void pbReadCarCard_MouseDown(object sender, MouseEventArgs e)
    {
        this.pbReadCarCard.Image = Properties.Resources.btReadDown;
    }

    public string phonenum()
    {
        StreamReader reader = new StreamReader(@"\User_Storage\phone.ini");
        string str = "";
        str = reader.ReadLine();
        reader.Close();
        return str;
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
        this.useractive();
        this.timer2.Enabled = false;
        this.pictureBox5.Image = Properties.Resources.phoneupDonw;
        this.Refresh();
        this.pictureBox5.Refresh();
        if (this.label4.Text == "请用方向箭头选择呼叫目标")
        {
            string text;
            if (this.currentphone.privatephone)
            {
                text = this.textBox1.Text;
            }
            else
            {
                text = this.label6.Text;
            }
            this.label4.Text = "呼叫中请等待";
            Call.MakeCall(text);
            this.OnCallDialingEvent();
        }
        if (this.label4.Text == "指挥中心来电,请接听")
        {
            Call.Answer();
            this.ringthd.Abort();
            this.OnCallAnwserEvent();
        }
        this.pictureBox5.Image = Properties.Resources.phoneupUp;
        this.Refresh();
        this.pictureBox5.Refresh();
    }

    private void pictureBox6_Click(object sender, EventArgs e)
    {
        this.useractive();
        this.pictureBox6.Image = Properties.Resources.phonedownDown;
        this.Refresh();
        this.pictureBox5.Refresh();
        Call.HangUp();
        this.OnCallHangupEvent();
        this.pictureBox6.Image = Properties.Resources.phonedownUp;
        this.Refresh();
        this.pictureBox5.Refresh();
        this.label5.Visible = false;
        this.label6.Visible = false;
        this.textBox1.Visible = false;
    }

    private void pictureBox7_Click(object sender, EventArgs e)
    {
        this.useractive();
        this.panel1.Visible = !this.panel1.Visible;
        this.label4.Text = "请用方向箭头选择呼叫目标";
        phonelist.getxml();
        this.currentphone = phonelist.nextphone();
        this.currentphone = phonelist.lastphone();
        this.textBox1.Text = "";
        this.textBox1.Visible = true;
        this.label6.Visible = true;
        this.label5.Visible = true;
        this.label5.Text = this.currentphone.name;
        if (!this.currentphone.privatephone)
        {
            this.label6.Text = this.currentphone.phonenum;
            this.label6.Visible = true;
            this.textBox1.Visible = false;
        }
        else
        {
            this.textBox1.Visible = true;
            this.textBox1.Focus();
            this.label6.Visible = false;
        }
    }

    [DllImport("Coredll.dll")]
    private static extern bool PlaySound(string strFile, IntPtr hMod, int flag);
    public static void ring()
    {
        while (true)
        {
            PlaySound(@"\User_Storage\ring.wav", IntPtr.Zero, 2);
            Thread.Sleep(0x3e8);
        }
    }

    private void SendStr(string text)
    {
        if (this.tbCarNum.InvokeRequired)
        {
            SendStrCallback method = new SendStrCallback(this.SendStr);
            base.Invoke(method, new object[] { text });
        }
        else
        {
            this.tbCarNum.Text = this.sCarNum;
        }
    }

    public static string stationID()
    {
        StreamReader reader = new StreamReader(@"\User_Storage\station.ini");
        string str = "";
        str = reader.ReadLine();
        reader.Close();
        return str;
    }

    [DllImport("coredll")]
    public static extern void SystemIdleTimerReset();
    private void tbCarNum_TextChanged(object sender, EventArgs e)
    {
        this.useractive();
        this.tbCarNum.Text = this.tbCarNum.Text.ToUpper();
        this.tbCarNum.Select(this.tbCarNum.Text.Length, 0);
        if (this.tbCarNum.Text.Length > 7)
        {
            this.tbCarNum.Text = this.tbCarNum.Text.Substring(0, 7);
            this.tbCarNum.Select(this.tbCarNum.Text.Length, 0);
        }
        if (this.tbCarNum.Text.Length < 1)
        {
            this.tbCarNum.Text = "京";
            this.tbCarNum.Select(1, 0);
        }
        if (this.tbCarNum.Text.Substring(0, 1) != "京")
        {
            this.tbCarNum.Text = "京";
            this.tbCarNum.Select(1, 0);
        }
    }

    private void textbox1_focus(object sender, EventArgs e)
    {
        if (this.panel1.Visible)
        {
            this.textBox1.Focus();
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        GetSystemPowerStatusEx(this.status2, 1);
        if (this.status2.BatteryLifePercent < 50)
        {
            this.bat.Text = "电量不足！" + this.status2.BatteryLifePercent.ToString() + "%";
            this.bat.ForeColor = Color.Red;
        }
        else
        {
            this.bat.Text = "电量：" + this.status2.BatteryLifePercent.ToString() + "%";
            this.bat.ForeColor = Color.Green;
        }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {

    }

    public void useractive()
    {
        this.timer2.Enabled = false;
        this.timer2.Interval = 0x30d40;
        this.timer2.Enabled = true;
    }

    // Nested Types
    public delegate void connectinvoke();

    [StructLayout(LayoutKind.Sequential)]
    internal struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }

    public delegate void NetInvoke(bool netstatus);

    internal class ProcMessageWindow : MessageWindow
    {
        // Methods
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x4010)
            {
                new Thread(new ThreadStart(Form1.checkmyself)).Start();
            }
        }
    }

    public delegate void SendStrCallback(string text);

    public delegate void TaskInvoke(bool taskstatus);

    private void timer2_Tick_1(object sender, EventArgs e)
    {
        D300SysUI_SetSystemPowerStateSuspend();
    }

}

 

 

//    public partial class Form1 : Form
//    {
        
//        private SYSTEM_POWER_STATUS_EX2 status = new SYSTEM_POWER_STATUS_EX2();
//        private SYSTEM_POWER_STATUS_EX status2 = new SYSTEM_POWER_STATUS_EX();
//        [DllImport("coredll")]
//        private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, int fUpdate);
//        [DllImport("coredll")]
//        public static extern void SystemIdleTimerReset();
//        [DllImport("coredll.dll")]
//        public static extern uint GetSystemPowerStatusEx2(ref SYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2,int dwLen, int fUpdate);
//        public Form1()
//        {
//            InitializeComponent();
//            myCfCard = new Distributor.CfCard.CfCard();
//            clearMemProperties();
//        }
//        Form2 f2;
//        public void dialup()
//        {
//            SEUIC.Phone.Initialize.UnInit();
//            Thread.Sleep(100);
//            SEUIC.Phone.Initialize.Init();
//            ras = Ras.GetInstance();
//            ras.RasDialMode = SEUIC.Phone.RAS.RasDialMode.Sync;//同步拨号,SEUIC.Phone.RAS.RasDialMode.Async 为异步拨号
//            ras.DialUp("card", "card", "#777");
//        }

//        public static void checkmyself()
//        {
//            int num = 10;
//            ras.HangUp();
//            Thread.Sleep(0x2710);
//            if (SEUIC.Phone.Module.Module.GetRSSI() <= 0)
//            {
//                Initialize.ModuleReset();
//                Thread.Sleep(0xbb8);
//                for (int i = 0; i < num; i++)
//                {
//                    if (SEUIC.Phone.Module.Module.GetRSSI() > 0)
//                    {
//                        break;
//                    }
//                    Thread.Sleep(0x7d0);
//                }
//            }
//            dialup();
//            Thread.Sleep(0x2710);
//            try
//            {
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://180.186.12.183/log/add.php?no=" + S_START_SPOT_NUM);
//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            }
//            catch
//            {
//            }
//        }

 

//        public Thread ringthd;// = new Thread(ring);
      
//        public static void ring()
//        {
//            while (true)
//            {
//                PlaySound("\\User_Storage\\ring.wav", IntPtr.Zero, 0x0002);
//                System.Threading.Thread.Sleep(1000);
//            }
//        }
        
//        public bool checknet()
//        {
//            Ras myras = Ras.GetInstance();
//            RASConnState netstate = RASConnState.RASCS_Disconnected;
//            netstate = myras.GetStatus();
//            if (netstate == RASConnState.RASCS_Connected)
//                return true;
//            return false;
//        }

//        protected void clearMemProperties()
//        {
//            sCarNum = "京";
//            sBoxNum = "";
//            sStartTime = "";
//            sStartSpotNum = "";
//            cMissionState = "E";
//            sCarCardNum = "";
//            sBoxCardNum = "";
//            myCfCard.disconnect();
//           // SEUIC.Phone.Initialize.UnInit();//必须要调用。
//        }

//        protected void clearPropShow()
//        {
//            tbStartSpotNum.Text = S_START_SPOT_NUM;
//            tbCarNum.Focus();
//            tbCarNum.Text = "京";
//            tbCarNum.Select(1, 0);
//            LBStatus.Visible = false;
//            progressBar1.Visible = false;
//            pictureBox1.Visible = false;
//            pictureBox2.Visible = false;
//            pbReadBoxCard.Enabled = true;
//            pictureBox1.Visible = false;
//        }
//        //读司机卡
//        private void pbReadCarCard_Click(object sender, EventArgs e)
//        {
//            if (!myCfCard.connect())
//            {
//                MessageBox.Show("连接读卡器失败！");
//                this.Close();
//            }

//            this.pbReadCarCard.Image = Properties.Resources.btReadUp;
//            this.Refresh();


//            string sInfoR = "";

//            if (myCfCard.request(ref sCarCardNum) != 0)
//            {
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            else
//                sCarCardNum = myCfCard.carid();
            

//            //读取卡类型
//            if (myCfCard.ReadString(0, 1, ref sInfoR) != 0)
//            {
//                MessageBox.Show("读取卡类型错误！");
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//          //  MessageBox.Show(myCfCard.StrToHex(sInfoR));
            
//            if (sInfoR != "B")
//            {
//                //MessageBox.Show("此卡不是司机卡！");
//                f2.setmsg("此卡不是司机卡", 3, "\\User_Storage\\sound\\driver.wav");
//              //  PlaySound("\\User_Storage\\sound\\driver.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }

//            //读取车牌号
//            string Truckno = "";
//            if (myCfCard.ReadString(1,9, ref Truckno) != 0)
//            {
//               // MessageBox.Show("读取车牌号错误！");
//                f2.setmsg("读卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//              //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            clearMemProperties();
//            clearPropShow();
//            sCarNum = Truckno;
//            tbCarNum.Text = sCarNum;

            
            
//        }
//        //读箱卡
//        private void pbReadBoxCard_Click(object sender, EventArgs e)
//        {

//            if (!myCfCard.connect())
//            {
//                MessageBox.Show("连接读卡器失败！");
//                this.Close();
//            }
//            this.pbReadBoxCard.Image = Properties.Resources.btWriteUp;
//            this.Refresh();
//            this.pbReadBoxCard.Enabled = false;
//            progressBar1.Value = 0;
//            progressBar1.Visible = true;
//            progressBar1.Refresh();
//            LBStatus.Visible = true;
//            LBStatus.Text = "数据处理中";
//            LBStatus.Refresh();
//            pictureBox1.Refresh();
//            string sInfoR = "";
//            string sInfoW = "";
//            sStartTime = System.DateTime.Now.ToString("yy-MM-dd,HH:mm");
//            sStartTime2 = System.DateTime.Now.ToString("yyMMddHHmm");
//            sCarNum = tbCarNum.Text;
//            if (sCarNum == "")
//                sCarNum = "京";
//          //  MessageBox.Show(sCarNum);
//            if (sCarNum == "京BYD")
//            {
//                myCfCard.disconnect();
//                clearMemProperties();
//                clearPropShow();
//                mytask.Abort();
                
//                //this.Close();
//                Application.Exit();
//                return;
//            }
//            int Percent;
//            Percent = GetSystemPowerStatusEx(status2,/*System.Runtime.InteropServices.Marshal.SizeOf(status),*/ 1);
//            if (status2.BatteryLifePercent < 40)
//            {
//               // MessageBox.Show("电池电量不足 不能读卡！");
//                f2.setmsg("电量不足，请充电", 3, "\\User_Storage\\sound\\nobat.wav");
//             //   PlaySound("\\User_Storage\\sound\\nobat.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();

//                return;
//            }
//            if (sCarNum.ToString().Length != 7)
//            {
//               // MessageBox.Show("车牌号输入有误");
//                f2.setmsg("请先读司机卡", 3, "\\User_Storage\\sound\\dfirst.wav");
//              //  PlaySound("\\User_Storage\\sound\\dfirst.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();

//                return;
//            }
//            if (sCarNum == "京")
//            {
//                //MessageBox.Show("请先读取司机卡");
//               // MessageBox.Show("请先输入车牌号");
//                f2.setmsg("请先读司机卡", 3, "\\User_Storage\\sound\\dfirst.wav");
//              //  PlaySound("\\User_Storage\\sound\\dfirst.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            progressBar1.Value = 10;
//            progressBar1.Refresh();
//            LBStatus.Text = "寻找卡片中...";
//            LBStatus.Refresh();
//            if (myCfCard.request(ref sBoxCardNum) != 0)
//            {
//                f2.setmsg("没有检测到卡片", 3, "\\User_Storage\\sound\\nocard.wav");
//               // PlaySound("\\User_Storage\\sound\\nocard.wav", IntPtr.Zero, 0x0002);
               
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            else
//            {
//                sBoxCardNum = myCfCard.carid();
       
//            }
//            myCfCard.ReadString(0, 1, ref sInfoR);
            
//            if (sInfoR =="B")
//            {
//                f2.setmsg("不是货箱卡", 3, "\\User_Storage\\sound\\box.wav");
//             //   PlaySound("\\User_Storage\\sound\\box.wav", IntPtr.Zero, 0x0002); ;
               
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }

//            /*if(myCfCard.Auth(3, 1) != 0)
//            {
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            if (myCfCard.ReadString(3, 1, ref sBoxNum) != 0)
//            {
//                MessageBox.Show("无法读取货箱号！");
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }*/

//            sInfoR = "";
//           /* 其它
//            厨余垃圾
//            餐厨垃圾
//            可回收垃圾*/


//            progressBar1.Value = 15;
//            progressBar1.Refresh();
//            LBStatus.Text = "读取状态字中...";
//            LBStatus.Refresh();
//            if (myCfCard.ReadString(10, 1, ref sInfoR) != 0)
//            {
//               // MessageBox.Show("无法读取任务状态！");
//                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//              //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//               return;
//            }
//         //   MessageBox.Show(sInfoR);
//            if (sInfoR == "S")
//            {
//               // MessageBox.Show("任务未完成，不能写入");
//                f2.setmsg("任务未完成，不能写入", 3, "\\User_Storage\\sound\\done.wav");
//             //   PlaySound("\\User_Storage\\sound\\done.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//              return;
//            }
//            pictureBox1.Visible = true; ;
//            pictureBox1.Refresh();
//            //写入运输车号
//            LBStatus.Text = "写入垃圾类型...";
//            LBStatus.Refresh();
//            progressBar1.Value = 21;
//            progressBar1.Refresh();
//            switch (comboBox1.Text)
//            {
//                case "其它":
//                    {
//                        sInfoR = "0";
//                        break;
//                    }
//                case "厨余垃圾":
//                    {
//                        sInfoR = "1";
//                        break;
//                    }
//                case "餐厨垃圾":
//                    {
//                        sInfoR = "2";
//                        break;
//                    }

//                case "可回收垃圾":
//                    {
//                        sInfoR = "3";
//                        break;
//                    }
//                default:
//                    sInfoR = "0";
//                    break;
//            }
//            string strtype = sInfoR;
//            string endstation = "1";
//            if (comboBox2.Text == "马家楼")
//                endstation = "2";

//            if (myCfCard.Write(sInfoR, 0) != 0)
//            {
//               // MessageBox.Show("写卡失败！");
//                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//               // PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            LBStatus.Text = "写入车牌号中...";
//            LBStatus.Refresh();
//            progressBar1.Value = 25;
//            progressBar1.Refresh();
//            if (myCfCard.Write(sCarNum, 1) != 0)
//            {
//                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//               // PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }

//            //写入起始时间信息
//            LBStatus.Text = "写入发货时间中...";
//            LBStatus.Refresh();
//            progressBar1.Value = 65;
//            progressBar1.Refresh();
//            if (myCfCard.Write2(sStartTime2,6) != 0)
//            {
//                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//              //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
                
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }
//            //if (myCfCard.Write2("0000000000",9 ) != 0)//清空上次结束时间
//            //{
//            //    MessageBox.Show("写卡失败！");
//            //    try
//            //    {
//            //        //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
//            //        //if(network)
//            //          //  this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
//            //    }
//            //    catch (System.Exception e4)
//            //    {
//            //        MessageBox.Show("清除缓存数据失败！");
//            //    }
//            //    clearMemProperties();
//            //    clearPropShow();
//            //    return;
//            //}

//            //写入出发地点
//            /*if (tbStartSpotNum.Text == "" || (iStartSpotNum = int.Parse(tbStartSpotNum.Text)) < 0)
//            {
//                MessageBox.Show("出发地点号输入非法！");
//                return;
//            }*/
//            LBStatus.Text = "写入出发地点中...";
//            LBStatus.Refresh();
//            progressBar1.Value = 85;
//            progressBar1.Refresh();
//            sStartSpotNum = S_START_SPOT_NUM;
//            if (myCfCard.Write(S_START_SPOT_NUM,9) != 0)
//            {
//              //  MessageBox.Show("出发地点写入失败！");
//              //  PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
//                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//                clearMemProperties();
//                clearPropShow();
//                return;
//            }

//            //标记任务未完成标志.
//            sInfoW = MISSION_ING.ToString();
//            cMissionState = MISSION_ING;
//            LBStatus.Text = "写入完成标志位中...";
//            LBStatus.Refresh();
//            progressBar1.Value = 95;
//            progressBar1.Refresh();
//            if (myCfCard.Write(sInfoW, 10) == 0)
//            {
//                //MessageBox.Show("写卡成功！");

//               // !@!#!#!#!#
//            //    PlaySound("\\User_Storage\\sound\\suc.wav", IntPtr.Zero, 0x0002);
//                f2.setmsg("写卡成功", 1, "\\User_Storage\\sound\\suc.wav");
//               // Updater.insertTask(sBoxCardNum, sCarNum, sStartTime, N_START_SPOT_NUM,0);
//                Updater.insertTask(sBoxCardNum, sCarNum, sStartTime, N_START_SPOT_NUM, int.Parse(strtype), endstation);
//            } 
//            else
//            {
//          //      PlaySound("\\User_Storage\\sound\\failed.wav", IntPtr.Zero, 0x0002);
//                f2.setmsg("写卡失败,请重试", 2, "\\User_Storage\\sound\\failed.wav");
//                try
//                {
//                    //this.goodsTableAdapter.DeleteQueryByIdTime(sBoxCardNum);
//                  //  if(network)
//                    //    this.dbo_GoodsTableAdapter1.DeleteQueryByIdTime(sBoxCardNum);
//                }
//                catch (System.Exception )
//                {
//                    MessageBox.Show("清除缓存数据失败！");
//                }
//                clearMemProperties();
//                clearPropShow();
//                return;
//           }
//            LBStatus.Text = "写卡成功";
//            LBStatus.Refresh();
//            progressBar1.Value = 100;
//            progressBar1.Refresh();

///*            tbCarNum.Text = "";
//            sCarNum = "";
//            iStartSpotNum = -1;*/


//            this.pictureBox1.Visible = false;
//            this.pictureBox2.Visible = true;
//            pictureBox2.Refresh();
//           // networkupdate();
//            pictureBox2.Visible = false;
//            this.pbReadBoxCard.Enabled = true;
//            clearPropShow();
//            clearMemProperties();
//            myCfCard.disconnect();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            panel1.Visible = false;
//            comboBox1.SelectedIndex = 0;
//            S_START_SPOT_NUM = stationID();
//            N_START_SPOT_NUM = int.Parse(S_START_SPOT_NUM);
//            f2 = new Form2();
//            f2.Show();
//            f2.Visible = false;
//            call.OnActiveEvent += new Call.NotifyEvent(OnCallAnwserEvent);
//            call.OnIncomingEvent += new Call.NotifyEvent(OnCallInEvent);
//            call.OnHangupEvent += new Call.NotifyEvent(OnCallHangupEvent);
//            call.OnDialingEvent += new Call.NotifyEvent(OnCallDialingEvent);
//            ras.OnConnectedEvent += new Ras.NotifyEvent(OnConnectedEvent);
//            ras.OnDisconnectedEvent += new Ras.NotifyEvent(OnDisconnectedEvent);

//            if (checknet())
//                NetPIC.BackColor = Color.Green;
//            else
//                NetPIC.BackColor = Color.Red;

//            pictureBox1.Visible = false;
//            pictureBox2.Visible = false;
//            SEUIC.Phone.Initialize.Init();
//            backgroundwork();
//            clearPropShow();
//        }
//        //获得始发站号
//        public string stationID()
//        {
//            StreamReader objReader = new StreamReader("\\User_Storage\\station.ini");
//            string sLine = "";
//            sLine = objReader.ReadLine();
//            objReader.Close();
//            return sLine;
//        }
//        //获得电话号码
//        public string phonenum()
//        {
//            StreamReader objReader = new StreamReader("\\User_Storage\\phone.ini");
//            string sLine = "";
//            sLine = objReader.ReadLine();
//            objReader.Close();
//            return sLine;
//        }


//        #region 全局变量
//        public string S_START_SPOT_NUM = "69";//00-99数字必须为2位;
//        public int N_START_SPOT_NUM = 69;
//        private const string CAR_CARD = "43";
//        private const string BOX_CARD = "42";
//        private const string MISSION_ING = "S";
//        private const string MISSION_FINISH = "E";
//        private const bool network = true;
//        private Distributor.CfCard.CfCard myCfCard;
//        private string sCarNum;
//        private string sBoxNum;
//        private string sStartTime;
//        private string sStartTime2;
//        private string sStartSpotNum;
//        private string cMissionState;
//        private string sCarCardNum;
//        private string sBoxCardNum;
//        private phone currentphone;
//        //拨号
//        #endregion

//        private string entryname = "Dail-up";
//        Ras ras = Ras.GetInstance();
//        bool bConnected = false;
//        public delegate void connectinvoke();

//        private bool bdoconnect = false;

//        private Call call = Call.GetInstance();

//        int iSMSIndexDelete = 0;

//        int SND_FILENAME = 0x0002;
//        [DllImport("Coredll.dll")]
//        private extern static bool PlaySound(string strFile, IntPtr hMod, int flag);


        
//        private void OnDisconnectedEvent()
//        {
//            NetPIC.BackColor = Color.Red;
//        }
//        private void OnConnectedEvent()
//        {
//            NetPIC.BackColor = Color.Green;
//        }

//        //来电时收到该事件
//        private void OnCallInEvent()
//        {
//            label4.Text = "指挥中心来电,请接听";
            
//            //.Visible = true;
//            panel1.Visible = true;
//            ringthd = new Thread(ring);
//            ringthd.Start();

//        }

//        //挂断时收到该事件
//        private void OnCallHangupEvent()
//        {
//            if (label4.Text == "指挥中心来电,请接听")
//                ringthd.Abort();
//            //ShowMessage("Phone hangup");
//            label4.Text = "呼叫指挥中心";
//            panel1.Visible = false;


//        }
//        //应答时收到该事件
//        private void OnCallAnwserEvent()
//        {
//            //ShowMessage("Phone accept");
//        }
//        //拨打电话收到该事件
//        private void OnCallDialingEvent()
//        {
//            //ShowMessage("Is dialing");
//        }
           
//        private void button1_Click(object sender, EventArgs e)
//        {
//            Application.Exit();
//        }

//        private void pbReadCarCard_MouseDown(object sender, MouseEventArgs e)
//        {
//            this.pbReadCarCard.Image = Properties.Resources.btReadDown;
//        }

//        private void pbReadBoxCard_MouseDown(object sender, MouseEventArgs e)
//        {
//            this.pbReadBoxCard.Image = Properties.Resources.btWriteDown;
//        }
        
//        private void Form1_KeyDown(object sender, KeyEventArgs e)
//        {
//            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
//            {
//                if (panel1.Visible == true)
//                {
//                    currentphone = phonelist.lastphone();
//                    label5.Text = currentphone.name;
//                    if (!currentphone.privatephone)
//                    {
//                        label6.Text = currentphone.phonenum;
//                        label6.Visible = true;
//                        textBox1.Visible = false;
//                    }
//                    else
//                    {
//                        textBox1.Visible = true;
//                        textBox1.Focus();
//                        label6.Visible = false;
//                    }
//                }
                    
//            }
//            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
//            {
//                if (panel1.Visible == true)
//                {
//                    currentphone = phonelist.nextphone();
//                    label5.Text = currentphone.name;
//                    if (!currentphone.privatephone)
//                    {
//                        label6.Text = currentphone.phonenum;
//                        label6.Visible = true;
//                        textBox1.Visible = false;
//                    }
//                    else
//                    {
//                        textBox1.Visible = true;
//                        textBox1.Focus();
//                        label6.Visible = false;
//                    }
//                }
//            }
//            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
//            {
//                if (panel1.Visible == true)
//                {
//                    currentphone = phonelist.lastphone();
//                    label5.Text = currentphone.name;
//                    if (!currentphone.privatephone)
//                    {
//                        label6.Text = currentphone.phonenum;
//                        label6.Visible = true;
//                        textBox1.Visible = false;
//                    }
//                    else
//                    {
//                        textBox1.Visible = true;
//                        textBox1.Focus();
//                        label6.Visible = false;
//                    }
//                }
//            }
//            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
//            {
//                if (panel1.Visible == true)
//                {
//                    currentphone = phonelist.nextphone();
//                    label5.Text = currentphone.name;
//                    if (!currentphone.privatephone)
//                    {
//                        label6.Text = currentphone.phonenum;
//                        label6.Visible = true;
//                        textBox1.Visible = false;
//                    }
//                    else
//                    {
//                        textBox1.Visible = true;
//                        textBox1.Focus();
//                        label6.Visible = false;
//                    }
//                }
//            }
//            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
//            {
//                // Enter
//            }

            

//        }
//        private void textbox1_focus(object sender, EventArgs e)
//        {
//            if(panel1.Visible)
//                textBox1.Focus();
//        }
//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            int Percent;
//            Percent = GetSystemPowerStatusEx(status2,/*System.Runtime.InteropServices.Marshal.SizeOf(status),*/ 1);
//            //uint Percent2;
//            //Percent2 = GetSystemPowerStatusEx2(ref status, System.Runtime.InteropServices.Marshal.SizeOf(status), 1);
//            //MessageBox.Show(Percent.ToString() + "+" + status2.BatteryLifePercent.ToString() + "+" + 
//            //    status2.BatteryLifeTime.ToString()+"=" + Percent2.ToString() + "+" +
//            //    status.BackupBatteryLifePercent.ToString() + "+" + status.BackupBatteryLifeTime.ToString());
//            if (status2.BatteryLifePercent < 50)
//            {
//                bat.Text = "电量不足！请尽快充电！";
//                bat.ForeColor = Color.Red;
//            }
//            else
//            {
//                bat.Text = "电量：" + status2.BatteryLifePercent.ToString() + "%";
//                bat.ForeColor = Color.Green;
//            }
            
//        }

//        private void tbCarNum_TextChanged(object sender, EventArgs e)
//        {
//            tbCarNum.Text = tbCarNum.Text.ToUpper();
//            tbCarNum.Select(tbCarNum.Text.Length, 0);
//            if (tbCarNum.Text.Length > 7)
//            {
//                tbCarNum.Text = tbCarNum.Text.Substring(0, 7);
//                tbCarNum.Select(tbCarNum.Text.Length, 0);
//            }
//            if (tbCarNum.Text.Length < 1)
//            {
//                tbCarNum.Text = "京";
//                tbCarNum.Select(1, 0);
//            }

//            if (tbCarNum.Text.Substring(0, 1) != "京")
//            {
//                tbCarNum.Text = "京";
//                tbCarNum.Select(1, 0);
//            }
            
//        }

//        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
//        {
            
//        }

//        Thread mytask;

//        public void backgroundwork()
//        {
//            mytask = new Thread(NettaskTH);
//            mytask.Start();
//        }

//        public void NettaskTH() 
//        {
//            NetInvoke updatetask = new NetInvoke(Net_status);
//           // TaskInvoke statusreport = new StatusInvoke(updateUIprocess);
//            while (true)
//            {
               

//                if (Updater.isBusy())
//                {
//                    this.BeginInvoke(updatetask, new Object[] {false });
//                    {
//                        if (!checknet())
//                        {
//                            dialup();
//                            //System.Threading.Thread.Sleep(10000);
//                        }
//                        Updater.doWork();
//                    }
       
//                }
//                else
//                    this.BeginInvoke(updatetask, new Object[] { true });
//                System.Threading.Thread.Sleep(10000);

//            }
//        }

//        public delegate void NetInvoke(bool netstatus);
//        public delegate void TaskInvoke(bool taskstatus);

//        public void Net_status(bool netstatus)
//        {
//            if (netstatus)
//                taskPIC.BackColor = Color.Green;
//            else
//                taskPIC.BackColor = Color.Red;
//        }

//        private void pictureBox5_Click(object sender, EventArgs e)
//        {
//            pictureBox5.Image = Properties.Resources.phoneupDonw;
//            this.Refresh();
//            pictureBox5.Refresh();
//            if (label4.Text == "请用方向箭头选择呼叫目标")
//            {
//                string strphnum;
//                if (currentphone.privatephone)
//                    strphnum = textBox1.Text;
//                else
//                    strphnum = label6.Text;
//                label4.Text = "呼叫中请等待";
//                SEUIC.Phone.Call.MakeCall(strphnum);
//             //   MessageBox.Show(strphnum);
//                OnCallDialingEvent();
//            }
//            if (label4.Text == "指挥中心来电,请接听")
//            {
//                SEUIC.Phone.Call.Answer();
//                ringthd.Abort();
//                this.OnCallAnwserEvent();
//            }
//            pictureBox5.Image=Properties.Resources.phoneupUp;
//            this.Refresh();
//            pictureBox5.Refresh();
//        }

//        private void pictureBox6_Click(object sender, EventArgs e)
//        {
//            pictureBox6.Image = Properties.Resources.phonedownDown;
//            this.Refresh();
//            pictureBox5.Refresh();
//            SEUIC.Phone.Call.HangUp();
//            this.OnCallHangupEvent();
//            pictureBox6.Image = Properties.Resources.phonedownUp;
//            this.Refresh();
//            pictureBox5.Refresh();
//            label5.Visible = false;
//            label6.Visible = false;
//            textBox1.Visible = false;
//        }

//        private void pictureBox7_Click(object sender, EventArgs e)
//        {
//            panel1.Visible = !panel1.Visible;
//            label4.Text = "请用方向箭头选择呼叫目标";
//            phonelist.getxml();
//            currentphone = phonelist.nextphone();
//            currentphone = phonelist.lastphone();
//            textBox1.Text = "";
//            textBox1.Visible = true;
//            label6.Visible = true;
//            label5.Visible = true;
//            label5.Text = currentphone.name;
//            if (!currentphone.privatephone)
//            {
//                label6.Text = currentphone.phonenum;
//                label6.Visible = true;
//                textBox1.Visible = false;
//            }
//            else
//            {
//                textBox1.Visible = true;
//                textBox1.Focus();
//                label6.Visible = false;
//            }
//        }
//   }
//    public struct SYSTEM_POWER_STATUS_EX2
//    {  //c# Windows CE读取电池电量的实现
//        public byte ACLineStatus;
//        public byte BatteryFlag;
//        public byte BatteryLifePercent;
//        public byte Reserved1;
//        public uint BatteryLifeTime;
//        public uint BatteryFullLifeTime;
//        public byte Reserved2;
//        public byte BackupBatteryFlag;
//        public byte BackupBatteryLifePercent;
//        public byte Reserved3;
//        public uint BackupBatteryLifeTime;
//        public uint BackupBatteryFullLifeTime;
//        public uint BatteryVoltage;
//        public uint BatteryCurrent;
//        public uint BatteryAverageCurrent;
//        public uint BatteryAverageInterval;
//        public uint BatterymAHourConsumed;
//        public uint BatteryTemperature;
//        public uint BackupBatteryVoltage;
//        public byte BatteryChemistry;
//    }
//    public class SYSTEM_POWER_STATUS_EX
//    {
//        public byte ACLineStatus = 0;
//        public byte BatteryFlag = 0;
//        public byte BatteryLifePercent = 0;
//        public byte Reserved1 = 0;
//        public uint BatteryLifeTime = 0;
//        public uint BatteryFullLifeTime = 0;
//        public byte Reserved2 = 0;
//        public byte BackupBatteryFlag = 0;
//        public byte BackupBatteryLifePercent = 0;
//        public byte Reserved3 = 0;
//        public uint BackupBatteryLifeTime = 0;
//        public uint BackupBatteryFullLifeTime = 0;
//    }
}