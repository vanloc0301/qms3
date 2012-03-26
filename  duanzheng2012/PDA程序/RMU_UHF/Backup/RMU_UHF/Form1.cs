using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;


namespace RMU_UHF
{
    public partial class Form1 : Form
    {
       
        // 联接uhf设备，并确保通讯正常
        [DllImport("UHF_API.dll")]
        public static extern int RmuOpenAndConnect(ref int hCom, char cPort, int flagCrc);

        // 关闭RMU 的功放并关闭通信端口
        [DllImport("UHF_API.dll")]
        public static extern int RmuCloseAndDisconnect(int hCom, int flagCrc);

        // 读取RMU 功放状态
        [DllImport("UHF_API.dll")]
        public static extern int RmuGetPaStatus(int hCom, StringBuilder uStatus, int flagCrc);

        // 读取RMU 的功率设置
        [DllImport("UHF_API.dll")]
        public static extern int RmuGetPower(int hCom, StringBuilder Power, int flagCrc);

        // 设置RMU 的功率。
        [DllImport("UHF_API.dll")]
        public static extern int RmuSetPower(int hCom, int uOption, int uPower, int flagCrc);

        // 打开RMU 的功放
        [DllImport("UHF_API.dll")]
        public static extern int RmuOpenPower(int hCom, int flagCrc);

        // 关闭RMU 的功放
        [DllImport("UHF_API.dll")]
        public static extern int RmuClosePower(int hCom, int flagCrc);

        // 启动RMU 的识别循环
        [DllImport("UHF_API.dll")]
        public static extern int RmuInventory(int hCom, int flagAnti, int initQ, int flagCrc);

        // 读取RMU 返回的标签UII
        [DllImport("UHF_API.dll")]
        public static extern int RmuGetReceived(int hCom, StringBuilder databuffer);

        // 停止RMU 的识别循环
        [DllImport("UHF_API.dll")]
        public static extern int RmuStopGet(int hCom, int flagCrc);

        // 数读取标签数据
        [DllImport("UHF_API.dll")]
        public static extern int RmuReadData(int hCom,StringBuilder Passwordbuffer,int uBank,StringBuilder Ptr,int uCnt,StringBuilder DIS_UII,StringBuilder DIS_ReadData,StringBuilder uErrorCode,int flagCrc);
       // RmuReadData (HANDLE hCom, UCHAR* uAccessPwd, UCHAR uBank, UCHAR* uPtr, UCHAR uCnt,
       //     LPWSTR DIS_UII, LPWSTR DIS_ReadData, UCHAR* uErrorCode, UCHAR flagCrc);

        // 写入标签数据
        [DllImport("UHF_API.dll")]
        public static extern int RmuWriteData(int hCom, StringBuilder Passwordbuffer, int uBank, StringBuilder Ptr, int uCnt, StringBuilder DIS_UII, StringBuilder DIS_WriteData, StringBuilder uErrorCode, int flagCrc);
        //int WINAPI RmuWriteData (HANDLE hCom, UCHAR* uAccessPwd, UCHAR uBank,
        //UCHAR* uPtr, UCHAR uCnt, UCHAR* uUii, UCHAR* uWriteData, UCHAR* uErrorCode,
        //UCHAR flagCrc);

        // 擦除标签数据
        [DllImport("UHF_API.dll")]
        public static extern void RmuEraseData(int hCom, StringBuilder AccessPwd, int uBank, StringBuilder Ptr, int uCnt, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);

        // 锁定标签的指定数据段
        [DllImport("UHF_API.dll")]
        public static extern int RmuLockMem(int hCom, StringBuilder AccessPwd, StringBuilder LockData, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);

        // 销毁指定标签
        [DllImport("UHF_API.dll")]
        public static extern int RmuKillTag(int hCom, StringBuilder KillPwd, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);

        // 以下两个函数是用于对我公司机器键盘上的一对黄色键，和一对侧按键是否被按下的状
        //态读取，两对按键分别对应与BUTTON1 和BUTTON2。当返回0时表示按键被按下
        [DllImport("UHF_API.dll")]
        public static extern int OnReadButton1();

        [DllImport("UHF_API.dll")]
        public static extern int OnReadButton2();

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);



        public delegate void SendStrCallback(string text);
                
        /// <summary>
        /// 发送扫描到TextBox控件
        /// </summary>
        /// <param name="text"></param>
        private void SendStr(string text)
        {
            if (this.listBox1.InvokeRequired)
            {
                //MessageBox.Show("invokerequired!!!");
                SendStrCallback d = new SendStrCallback(SendStr);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //MessageBox.Show("out!!");
                this.listBox1.Items.Add(text);
            }
        }

        int hReader = 0;
        bool threadflag=true;
        int flagCrc = 0;        //crc校验使能位
        int flagAnti = 0;       //防碰撞标使能志位 1使能
        int AntiQ = 0;          //碰撞次数，当flagAnti时有效 
        Thread ChekButtonThread;

        public Form1()
        {
            char comnum;
             comnum = Convert.ToChar(0x9);
             Thread.Sleep(100);
                if (RmuOpenAndConnect(ref hReader, comnum, flagCrc) == 1)
                {
            //        MessageBox.Show( hReader.ToString());
                    InitializeComponent();
                    //
                    ChekButtonThread = new Thread(new ThreadStart(ListButtonThread));
                    ChekButtonThread.IsBackground = true;
                    ChekButtonThread.Start();
                    

                }
                else
                {
                    MessageBox.Show("Not found Reader connect to the COM! ");
                   // EventArgs e ;
                   // Form1_Closed();
                    //this.Close();
                }
  /*           */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**/
            if (RmuInventory(hReader, flagAnti, AntiQ, flagCrc) == 1)
            {
                MessageBox.Show("start read! ");
                
            }
               
            else
                MessageBox.Show("start read faild! ");
        }

             
        public void ListButtonThread()
        {
            while (threadflag)
            {
                Thread.Sleep(200);
                //MessageBox.Show("thread test! ");

                if ((OnReadButton1() == 0) || (OnReadButton2() == 0))
                {
                    //MessageBox.Show("push!");
                    /* */
                    if (RmuInventory(hReader, flagAnti, AntiQ, flagCrc) == 1)
                    {
                        //MessageBox.Show("1");
                        GetReceivedUII();
                        //MessageBox.Show("2");
                        while (RmuStopGet(hReader, flagCrc) == 0)
                        {
                            // MessageBox.Show("stop get UID faild! ");
                        }
                        //MessageBox.Show("stop get uid ok!");
                    }
                }
                //else
                //    MessageBox.Show("no push!");
                  
            }
        }

        public void GetReceivedUII()
        {
            StringBuilder databuffer;
            
            databuffer = new StringBuilder();
            databuffer.Capacity = 256;

            if (RmuGetReceived(hReader, databuffer) == 1)
            {

                //MessageBox.Show("getreceive ok");
                //listBox1.Text = databuffer.ToString().Replace("\n\r", "");
                //listBox1.Items.Add(databuffer);
                SendStr(databuffer.ToString().Replace("\n\r", ""));
                MessageBeep(0);
                //listBox1.Items.Add(databuffer.ToString().Replace("\n\r", ""));
            }

            else
            {} //MessageBox.Show("get  faild! ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
          /*
            if (RmuStopGet(hReader, 0) == 1)
            { 
            }
            else
                MessageBox.Show("stop get UID faild! ");
           */
         
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (RmuInventory(hReader, flagAnti, AntiQ, flagCrc) == 1)
            {
                GetReceivedUII();
                while (RmuStopGet(hReader, flagCrc) == 0)
                {
                   // MessageBox.Show("stop get UID faild! ");
                }
                //MessageBox.Show("stop get uid ok!");
            }
            else
                MessageBox.Show("Inventory faild");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //listBox2.Items.Add((string)listBox1.SelectedItem);
            int Bank = 1;
            int Cnt = 1;
            
            StringBuilder DIS_UII;
            DIS_UII = new StringBuilder();
            DIS_UII.Capacity = 256;
            DIS_UII.Append((string)listBox1.SelectedItem);

            StringBuilder DIS_ReadData;
            DIS_ReadData = new StringBuilder();
            DIS_ReadData.Capacity = 256;

            StringBuilder PassWord;
            PassWord = new StringBuilder();
            PassWord.Capacity = 4;
            PassWord.Append("0000"); 

            StringBuilder Ptr;
            Ptr = new StringBuilder();
            Ptr.Capacity = 2;
            Ptr.Append("00"); 

            StringBuilder uErrorCode;
            uErrorCode = new StringBuilder();
            uErrorCode.Capacity = 2;


            if (RmuReadData(hReader, PassWord, Bank, Ptr, Cnt, DIS_UII, DIS_ReadData, uErrorCode, flagCrc)==1)
            {
                //MessageBox.Show("read ok!");
                listBox2.Items.Add(DIS_ReadData);
            }
            else
                MessageBox.Show("read failed,please try again!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //listBox2.Items.Add((string)listBox1.SelectedItem);
            int Bank = 1;
            int Cnt = 1;

            StringBuilder DIS_UII;
            DIS_UII = new StringBuilder();
            DIS_UII.Capacity = 256;
            DIS_UII.Append((string)listBox1.SelectedItem);
            

            StringBuilder DIS_WriteData;
            DIS_WriteData = new StringBuilder();
            DIS_WriteData.Capacity = 10;
            DIS_WriteData.Append((string)textBox2.Text);

            StringBuilder DIS_WriteDataFirst;
            DIS_WriteDataFirst = new StringBuilder();
            DIS_WriteDataFirst.Capacity = 10;
            DIS_WriteDataFirst.Append(DIS_WriteData);
            
            StringBuilder DIS_WriteDataSecond;
            DIS_WriteDataSecond = new StringBuilder();
            DIS_WriteDataSecond.Capacity = 10;
            if (DIS_WriteData.Length >= 4)
            {
                DIS_WriteDataSecond.Append(DIS_WriteData.Remove(0, 4));
            }
            else
                DIS_WriteData.Append("0000");

            StringBuilder PassWord;
            PassWord = new StringBuilder();
            PassWord.Capacity = 4;
            PassWord.Append("0000");

            StringBuilder Ptr;
            Ptr = new StringBuilder();
            Ptr.Capacity = 2;
            Ptr.Append("01");

            StringBuilder uErrorCode;
            uErrorCode = new StringBuilder();
            uErrorCode.Capacity = 2;

           // listBox1.Items.Add((string)textBox2.Text);
           // listBox1.Items.Add(DIS_UII);

           /**/
            //listBox1.Items.Add(DIS_WriteDataFirst);
            //listBox1.Items.Add(DIS_WriteDataSecond);
            DIS_WriteData.Remove(0, DIS_WriteData.Length);
            DIS_WriteData.Append((string)textBox2.Text);
            if (DIS_WriteData.Length == 0)
                MessageBox.Show("写入不能为空！");
            else
            {
                if (RmuWriteData(hReader, PassWord, Bank, Ptr, Cnt, DIS_UII, DIS_WriteDataFirst, uErrorCode, flagCrc) == 1)
                {
                    Ptr.Remove(0,Ptr.Length);
                    Ptr.Append("02");
                    //listBox1.Items.Add(Ptr);
                    if (RmuWriteData(hReader, PassWord, Bank, Ptr, Cnt, DIS_UII, DIS_WriteDataSecond, uErrorCode, flagCrc) == 1)
                        MessageBox.Show("Write Ok!");
                    else
                        MessageBox.Show("Write failed,please try again");
                }
                else
                    MessageBox.Show("Write failed,please try again!");
            }

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            
        }


 

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            threadflag = false;
            ChekButtonThread.Abort();

            RmuCloseAndDisconnect(hReader, flagCrc);
            //Application.Exit();
        }
        /*
         */
        
    }
}