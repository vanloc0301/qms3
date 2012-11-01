using System;

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
namespace Distributor.CfCard
{
  //  public class CfCard
  //  {

  //      ////////////////////////Library Import Start////////////////////////

  //      // 联接uhf设备，并确保通讯正常
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuOpenAndConnect(ref int hCom, char cPort, int flagCrc);

  //      // 关闭RMU 的功放并关闭通信端口
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuCloseAndDisconnect(int hCom, int flagCrc);

  //      // 读取RMU 功放状态
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuGetPaStatus(int hCom, StringBuilder uStatus, int flagCrc);

  //      // 读取RMU 的功率设置
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuGetPower(int hCom, StringBuilder Power, int flagCrc);

  //      // 设置RMU 的功率。
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuSetPower(int hCom, int uOption, int uPower, int flagCrc);

  //      // 打开RMU 的功放
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuOpenPower(int hCom, int flagCrc);

  //      // 关闭RMU 的功放
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuClosePower(int hCom, int flagCrc);

  //      // 启动RMU 的识别循环
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuInventory(int hCom, int flagAnti, int initQ, int flagCrc);

  //      // 读取RMU 返回的标签UII
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuGetReceived(int hCom, StringBuilder databuffer);

  //      // 停止RMU 的识别循环
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuStopGet(int hCom, int flagCrc);

  //      // 数读取标签数据
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuReadData(int hCom, StringBuilder Passwordbuffer, int uBank, StringBuilder Ptr, int uCnt, StringBuilder DIS_UII, StringBuilder DIS_ReadData, StringBuilder uErrorCode, int flagCrc);
  //      // RmuReadData (HANDLE hCom, UCHAR* uAccessPwd, UCHAR uBank, UCHAR* uPtr, UCHAR uCnt,
  //      //     LPWSTR DIS_UII, LPWSTR DIS_ReadData, UCHAR* uErrorCode, UCHAR flagCrc);

  //      // 写入标签数据
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuWriteData(int hCom, StringBuilder Passwordbuffer, int uBank, StringBuilder Ptr, int uCnt, StringBuilder DIS_UII, StringBuilder DIS_WriteData, StringBuilder uErrorCode, int flagCrc);
  //      //int WINAPI RmuWriteData (HANDLE hCom, UCHAR* uAccessPwd, UCHAR uBank,
  //      //UCHAR* uPtr, UCHAR uCnt, UCHAR* uUii, UCHAR* uWriteData, UCHAR* uErrorCode,
  //      //UCHAR flagCrc);

  ////      [DllImport("kernel32.dll")]
  ////      public static extern void Sleep(int dwMilliseconds);


  //      // 擦除标签数据
  //      [DllImport("UHF_API.dll")]
  //      public static extern void RmuEraseData(int hCom, StringBuilder AccessPwd, int uBank, StringBuilder Ptr, int uCnt, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);

  //      // 锁定标签的指定数据段
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuLockMem(int hCom, StringBuilder AccessPwd, StringBuilder LockData, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);

  //      // 销毁指定标签
  //      [DllImport("UHF_API.dll")]
  //      public static extern int RmuKillTag(int hCom, StringBuilder KillPwd, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);

  //      // 以下两个函数是用于对我公司机器键盘上的一对黄色键，和一对侧按键是否被按下的状
  //      //态读取，两对按键分别对应与BUTTON1 和BUTTON2。当返回0时表示按键被按下
  //      [DllImport("UHF_API.dll")]
  //      public static extern int OnReadButton1();

  //      [DllImport("UHF_API.dll")]
  //      public static extern int OnReadButton2();

  //      [DllImport("coredll.dll")]
  //      public static extern bool MessageBeep(int uType);

  //      ////////////////////////Library Import End////////////////////////
  //      int hReader = 0;
  //      bool threadflag = true;
  //      int flagCrc = 0;        //crc校验使能位
  //      int flagAnti = 0;       //防碰撞标使能志位 1使能
  //      int AntiQ = 0;          //碰撞次数，当flagAnti时有效 
  //      StringBuilder DIS_UII;
  //      // Thread ChekButtonThread;
  //      ////////////////////Member Function Definition/////////////////////
  //      //返回id一部分
  //      public string carid()
  //      {
  //          return DIS_UII.ToString().Substring(4,DIS_UII.Length-4);

  //      }

  //      //连接函数
  //      public bool connect()
  //      {
  //          char comnum;
  //          comnum = Convert.ToChar(0x9);
  //          //  Thread.Sleep(100);
  //          if (RmuOpenAndConnect(ref hReader, comnum, flagCrc) == 1)
  //          {
  //              //        MessageBox.Show( hReader.ToString());
  //              //      InitializeComponent();
  //              //
  //              //       ChekButtonThread = new Thread(new ThreadStart(ListButtonThread));
  //              //      ChekButtonThread.IsBackground = true;
  //              //      ChekButtonThread.Start();

  //              //   MessageBox.Show("Connected!");
  //              if (RmuSetPower(hReader, 1, 21, 0) == 1)
  //              {
  //                  //    MessageBox.Show(power.ToString());
  //              }
  //              else
  //              {
  //                  MessageBox.Show("set power failed");
  //              }
  //          }
  //          else
  //          {
  //              MessageBox.Show("Not found Reader connect to the COM! ");
  //              // EventArgs e ;
  //              // Form1_Closed();
  //             // this.Close();
  //              return false;
  //          }
  //          return true;
  //      }
  //      //读取UII
  //      public int GetReceivedUII()
  //      {
  //          StringBuilder databuffer;
  //          databuffer = new StringBuilder();
  //          databuffer.Capacity = 256;
  //          int count = 10;
  //          int i = 0;
  //          bool sign = true;
  //          while (i <= count && sign)
  //          {

  //              if (RmuGetReceived(hReader, databuffer) == 1)
  //              {
  //                  DIS_UII = new StringBuilder();
  //                  DIS_UII.Capacity = 256;
  //                  DIS_UII.Append(databuffer.ToString().Replace("\n\r", ""));
  //                  MessageBeep(0);
  //                  sign = false;
  //              }
  //              else
  //              {
  //                  i++;
  //                  Thread.Sleep(20);
  //                 // Sleep(20);
  //              }
  //          }
  //          if (sign == true)
  //              return 1;
  //          else
  //              return 0;
  //      }
  //      //连接卡
  //      public int request(ref string sCardNum)
  //      {
  //          int count = 20;
  //          if (RmuInventory(hReader, flagAnti, AntiQ, flagCrc) == 1)
  //          {
  //              if (GetReceivedUII() == 1)
  //              {
  //                  //MessageBox.Show("没有检测到卡片！请重试！");
  //                  return 1;
  //              }
  //              while (RmuStopGet(hReader, flagCrc) == 0 && count > 0)
  //              {
  //                  //     MessageBox.Show("stop get UID faild! ");
  //                 Thread.Sleep(20);
  //                  count--;
  //              }
  //          }
  //          else
  //          {
  //             // MessageBox.Show("没有检测到卡片！");
  //              return 1;

  //          }
  //          if (count == 0)
  //          {
  //            //  MessageBox.Show("没有检测到卡片！");
  //              return 1;
  //          }
  //          return 0;
  //      }
  //      //没用的函数
  //      public int Auth(int sec, int block)
  //      {
  //          return 0;
  //      }
  //      //写一个word
  //      public int Writeword(string temp, int sptr)
  //      {
  //          int Bank = 3;
  //          int Cnt = 1;
  //          StringBuilder DIS_WriteData;
  //          DIS_WriteData = new StringBuilder();
  //          DIS_WriteData.Capacity = 10;
  //          DIS_WriteData.Append(temp);

  //          StringBuilder DIS_WriteDataFirst;
  //          DIS_WriteDataFirst = new StringBuilder();
  //          DIS_WriteDataFirst.Capacity = 10;
  //          DIS_WriteDataFirst.Append(DIS_WriteData);

  //          StringBuilder DIS_WriteDataSecond;
  //          DIS_WriteDataSecond = new StringBuilder();
  //          DIS_WriteDataSecond.Capacity = 10;
  //          if (DIS_WriteData.Length >= 4)
  //          {
  //              DIS_WriteDataSecond.Append(DIS_WriteData.Remove(0, 4));
  //          }
  //          else
  //              DIS_WriteData.Append("0000");

  //          StringBuilder PassWord;
  //          PassWord = new StringBuilder();
  //          PassWord.Capacity = 4;
  //          PassWord.Append("0000");

  //          StringBuilder Ptr;
  //          Ptr = new StringBuilder();
  //          Ptr.Capacity = 2;
  //          string ssptr = "";
  //          //地址译码 有点山寨...
  //          if (sptr < 10)
  //              ssptr = "0" + sptr.ToString();
  //          else
  //          {
  //              if (sptr == 10)
  //                  ssptr = "0A";
  //              if (sptr == 11)
  //                  ssptr = "0B";
  //              if (sptr == 12)
  //                  ssptr = "0C";
  //              if (sptr == 13)
  //                  ssptr = "0D";
  //              if (sptr == 14)
  //                  ssptr = "0E";
  //              if (sptr == 15)
  //                  ssptr = "0F";
  //              if (sptr == 16)
  //                  ssptr = "10";

  //          }
  //          Ptr.Append(ssptr);

  //          StringBuilder uErrorCode;
  //          uErrorCode = new StringBuilder();
  //          uErrorCode.Capacity = 2;

  //          if (DIS_WriteData.Length == 0)
  //              MessageBox.Show("写入不能为空！");
  //          else
  //          {
  //              bool sign = true;
  //              bool sign2 = true;
  //              {
  //                  if (RmuWriteData(hReader, PassWord, Bank, Ptr, Cnt, DIS_UII, DIS_WriteDataFirst, uErrorCode, flagCrc) == 1)
  //                  {
  //                      Ptr.Remove(0, Ptr.Length);
  //                      sptr = sptr + 1;
  //                      sign = false;
  //                      if (sptr < 10)
  //                          ssptr = "0" + sptr.ToString();
  //                      else
  //                      {
  //                          if (sptr == 10)
  //                              ssptr = "0A";
  //                          if (sptr == 11)
  //                              ssptr = "0B";
  //                          if (sptr == 12)
  //                              ssptr = "0C";
  //                          if (sptr == 13)
  //                              ssptr = "0D";
  //                          if (sptr == 14)
  //                              ssptr = "0E";
  //                          if (sptr == 15)
  //                              ssptr = "0F";
  //                          if (sptr == 16)
  //                              ssptr = "10";

  //                      }

  //                      Ptr.Append(ssptr);
  //                      {
  //                          if (RmuWriteData(hReader, PassWord, Bank, Ptr, Cnt, DIS_UII, DIS_WriteDataSecond, uErrorCode, flagCrc) == 1)
  //                              sign2 = false;

  //                          else
  //                              return 1;
  //                      }
  //                  }
  //                  else
  //                  {
  //                      return 1;
  //                  }
  //              }
  //              if (sign != false || sign2 != false)
  //                  return 1;
  //          }
  //          return 0;
  //      }
  //      //写一个字符串
  //      public int Write(String temp, int ptr)
  //      {
  //          string temp2 = "";
  //          int i = 0;
  //          temp2 = StrToHex(temp);
  //          int yu;
  //          yu = temp2.Length % 8;
  //          int kk;
  //          for (kk = 1; kk <= (8 - yu); kk++)
  //              temp2 += "0";
  //          while (i <= (temp2.Length - 1))
  //          {
  //              int j = 0;
  //              bool suc = true;
  //              while (j <= 30 && suc)
  //              {
  //                  if (Writeword(temp2.Substring(i, 8), ptr) == 0)
  //                      suc = false;
  //                  else
  //                      j++;
  //              }
  //              if (suc)
  //              {
  //                 // MessageBox.Show("写入失败请重试！");
  //                  return 1;
  //              }
  //              i += 8;
  //              ptr += 2;
  //          }

  //          return 0;
  //      }
  //      //写字符串（不编码）
  //      public int Write2(String temp, int ptr)
  //      {
  //          string temp2 = "";
  //          int i = 0;
  //          temp2 = temp;
  //          //补0
  //          int yu;
  //          yu = temp2.Length % 8;
  //          int kk;
  //          for (kk = 1; kk <= (8 - yu); kk++)
  //              temp2 += "0";
  //          while (i <= (temp2.Length - 1))
  //          {
  //              int j = 0;
  //              bool suc = true;
  //              while (j <= 30 && suc)
  //              {
  //                  if (Writeword(temp2.Substring(i, 8), ptr) == 0)
  //                      suc = false;
  //                  else
  //                      j++;
  //              }
  //              if (suc)
  //              {
  //                //  MessageBox.Show("写入失败请重试！");
  //                  return 1;
  //              }
  //              i += 8;
  //              ptr += 2;
  //          }
  //          return 0;
  //      }
  //      //读一个字符串
  //      public string Readword(int sptr, int Cnt)
  //      {
  //          int Bank = 3;

  //          string x = "";

  //          StringBuilder DIS_ReadData;
  //          DIS_ReadData = new StringBuilder();
  //          DIS_ReadData.Capacity = 256;

  //          StringBuilder PassWord;
  //          PassWord = new StringBuilder();
  //          PassWord.Capacity = 4;
  //          PassWord.Append("0000");


  //          StringBuilder Ptr;
  //          Ptr = new StringBuilder();
  //          Ptr.Capacity = 2;
  //          string ssptr = "";
  //          if (sptr < 10)
  //              ssptr = "0" + sptr.ToString();
  //          else
  //          {
  //              if (sptr == 10)
  //                  ssptr = "0A";
  //              if (sptr == 11)
  //                  ssptr = "0B";
  //              if (sptr == 12)
  //                  ssptr = "0C";
  //              if (sptr == 13)
  //                  ssptr = "0D";
  //              if (sptr == 14)
  //                  ssptr = "0E";
  //              if (sptr == 15)
  //                  ssptr = "0F";
  //              if (sptr == 16)
  //                  ssptr = "10";

  //          }
  //          Ptr.Append(ssptr);
  //          StringBuilder uErrorCode;
  //          uErrorCode = new StringBuilder();
  //          uErrorCode.Capacity = 2;

  //          int i = 0;
  //          bool sign = true;
  //          while (i <= 50 && sign)
  //          {
  //              if (RmuReadData(hReader, PassWord, Bank, Ptr, Cnt, DIS_UII, DIS_ReadData, uErrorCode, flagCrc) == 1)
  //              {
  //                  x = DIS_ReadData.ToString();
  //                  sign = false;
  //              }
  //              else
  //              {
  //                  i++;
  //              }
  //          }
  //          if (sign)
  //          {
  //           //   MessageBox.Show("读出数据失败！");
  //          }
  //          return x;
  //      }
  //      public void disconnect()
  //      {
  //          char comnum;
  //          comnum = Convert.ToChar(0x9);
  //          //  Thread.Sleep(100);
  //         RmuCloseAndDisconnect( hReader,  flagCrc);

  //      }
  //      //read套壳 编码
  //      public int ReadString(int ptr, int cnt, ref string x)
  //      {

  //          x = Readword(ptr, cnt);
  //          MessageBeep(0);
  //          x = HexToStr(x);
  //          return 0;
  //      }
  //      //read套壳 不编码
  //      public int ReadString2(int ptr, int cnt, ref string x)
  //      {
  //          x = Readword(ptr, cnt);
  //          MessageBeep(0);
  //          return 0;
  //      }
  //      //字符串到16进制转换
  //      public string StrToHex(string str)
  //      {
  //          string strTemp = "";

  //          if (str == "")
  //              return "";
  //          byte[] bTemp = System.Text.Encoding.Default.GetBytes(str);

  //          for (int i = 0; i < bTemp.Length; i++)
  //          {
  //              strTemp += bTemp[i].ToString("X");
  //          }

  //          return strTemp;
  //      }
  //      //16进制到字符串转换
  //      public string HexToStr(string source)
  //      {
  //          byte[] oribyte = new byte[source.Length / 2];
  //          for (int i = 0; i < source.Length; i += 2)
  //          {
  //              string str = Convert.ToInt32(source.Substring(i, 2), 16).ToString();
  //              oribyte[i / 2] = Convert.ToByte(source.Substring(i, 2), 16);
  //          }
  //          try
  //          {
  //              return System.Text.Encoding.Default.GetString(oribyte, 0, source.Length / 2);
  //          }
  //          catch
  //          {
  //              //MessageBox.Show(source + "=" + );
  //              return "err";
  //          }
  //      }
  //      //对时间字符串解码
  //      public string decodetime(string ortime)
  //      {
  //          string newtime = "";
  //          newtime = ortime.Substring(0, 2) + "-" + ortime.Substring(2, 2) + "-" + ortime.Substring(4, 2) + "," + ortime.Substring(6, 2) + ":" + ortime.Substring(8, 2);
  //          return newtime;
  //      }
  //      //////////////////Member Function Definition End///////////////////
  //  }
    public class CfCard
    {
        // Fields
        private static int AntiQ = 0;
        private static StringBuilder DIS_UII;
        private static int flagAnti = 0;
        private static int flagCrc = 0;
        private static int hReader = 0;
        private static byte[] myid;
        public static Read myread;
        private static bool threadflag = true;

        // Methods
        public int Auth(int sec, int block)
        {
            return 0;
        }

        public string carid()
        {
            return DIS_UII.ToString().Substring(4, DIS_UII.Length - 4);
        }

        public bool connect()
        {
            char[] cPort = new char[0x10];
            cPort = "COM5:".ToCharArray();
            try
            {
                if (RmuOpenAndConnect(ref hReader, cPort, flagCrc) == 1)
                {
                    if (RmuSetPower(hReader, 1, 0x15, 0) != 1)
                    {
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
            }
            return true;
        }

        public string decodetime(string ortime)
        {
            return (ortime.Substring(0, 2) + "-" + ortime.Substring(2, 2) + "-" + ortime.Substring(4, 2) + "," + ortime.Substring(6, 2) + ":" + ortime.Substring(8, 2));
        }

        public void disconnect()
        {
            Convert.ToChar(9);
            RmuCloseAndDisconnect(ref hReader, flagCrc);
        }

        private void GetSingleRecivedUII()
        {
            StringBuilder builder = new StringBuilder
            {
                Capacity = 0x100
            };
            byte dataLen = 0;
            byte[] buffer = new byte[0x100];
            string str = "";
            if (RmuGetReceived(hReader, ref dataLen, ref buffer[0]) == 1)
            {
                myid = buffer;
                for (int i = 0; i < dataLen; i++)
                {
                    str = str + buffer[i].ToString("x2");
                }
                DIS_UII = new StringBuilder();
                DIS_UII.Capacity = 0x100;
                DIS_UII.Append(str);
                MessageBeep(0);
            }
        }

        public string HexToStr(string source)
        {
            byte[] bytes = new byte[source.Length / 2];
            for (int i = 0; i < source.Length; i += 2)
            {
                Convert.ToInt32(source.Substring(i, 2), 0x10).ToString();
                bytes[i / 2] = Convert.ToByte(source.Substring(i, 2), 0x10);
            }
            try
            {
                return Encoding.Default.GetString(bytes, 0, source.Length / 2);
            }
            catch
            {
                return "err";
            }
        }

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);
        public static bool newwrite(int ptr, byte[] data)
        {
            int uBank = 3;
            int uCnt = 1;
            byte[] myid = new byte[0x100];
            myid = Distributor.CfCard.CfCard.myid;
            StringBuilder passwordbuffer = new StringBuilder
            {
                Capacity = 4
            };
            passwordbuffer.Append("");
            new StringBuilder { Capacity = 2 }.Append("");
            StringBuilder uErrorCode = new StringBuilder
            {
                Capacity = 2
            };
            char ch = Convert.ToChar(ptr);
            byte[] buffer2 = new byte[0x40];
            byte[] buffer3 = new byte[8];
            if (data.Length == 1)
            {
                data = new byte[] { data[0], 0 };
            }
            buffer2 = data;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            for (num3 = 0; num3 < (buffer2.Length / 2); num3++)
            {
                ch = (char)(num3 + ptr);
                buffer3[0] = buffer2[2 * num3];
                buffer3[1] = buffer2[(2 * num3) + 1];
                for (int i = 0; i < 5; i++)
                {
                    num4 = RmuWriteData(hReader, passwordbuffer, uBank, ref ch, uCnt, myid, buffer3, uErrorCode, flagCrc);
                    if (num4 == 1)
                    {
                        break;
                    }
                }
                if (num4 != 1)
                {
                    return false;
                }
                num5 += 2;
            }
            return true;
        }

        [DllImport("UHF_API.dll")]
        public static extern int OnReadButton1();
        [DllImport("UHF_API.dll")]
        public static extern int OnReadButton2();
        public static bool read()
        {
            byte[] bytes = new byte[0x20];
            myread = new Read();
            byte[] myid = new byte[0x100];
            DIS_UII.ToString();
            myid = Distributor.CfCard.CfCard.myid;
            StringBuilder builder = new StringBuilder
            {
                Capacity = 0x100
            };
            StringBuilder passwordbuffer = new StringBuilder
            {
                Capacity = 4
            };
            passwordbuffer.Append("");
            new StringBuilder { Capacity = 2 }.Append("");
            StringBuilder uErrorCode = new StringBuilder
            {
                Capacity = 2
            };
            byte[] buffer3 = new byte[0x100];
            bool flag = false;
            char ptr = '\0';
            for (int i = 0; i < 3; i++)
            {
                if (RmuReadData(hReader, passwordbuffer, 3, ref ptr, 12, myid, ref buffer3[0], uErrorCode, flagCrc) == 1)
                {
                    MessageBeep(0);
                    flag = true;
                    for (int j = 0; j < 0x18; j++)
                    {
                        bytes[j] = buffer3[j];
                    }
                    break;
                }
            }
            if (!flag)
            {
                return false;
            }
            if (!flag)
            {
                return false;
            }
            myread.CarNum = Encoding.Default.GetString(bytes, 4, 6);
            myread.Cardtype = ((char)bytes[0]).ToString();
            myread.Status = ((char)bytes[20]).ToString();
            myread.date = bytes[12].ToString("x2") + bytes[13].ToString("x2") + bytes[14].ToString("x2");
            return true;
        }

        public int ReadString(int ptr, int cnt, ref string x)
        {
            MessageBeep(0);
            x = this.HexToStr(x);
            return 0;
        }

        public int ReadString2(int ptr, int cnt, ref string x)
        {
            MessageBeep(0);
            return 0;
        }

        public int request(ref string sCardNum)
        {
            int num = 20;
            if (RmuInventory(hReader, flagAnti, AntiQ, flagCrc) != 1)
            {
                return 1;
            }
            this.GetSingleRecivedUII();
            while (RmuStopGet(hReader, flagCrc) == 0)
            {
            }
            if (num == 0)
            {
                return 1;
            }
            return 0;
        }

        [DllImport("UHF_API.dll")]
        public static extern int RmuCloseAndDisconnect(ref int hCom, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuClosePower(int hCom, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern void RmuEraseData(int hCom, StringBuilder AccessPwd, int uBank, StringBuilder Ptr, int uCnt, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuGetPaStatus(int hCom, StringBuilder uStatus, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuGetPower(int hCom, StringBuilder Power, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuGetReceived(int hCom, ref byte dataLen, ref byte databuffer);
        [DllImport("UHF_API.dll")]
        public static extern int RmuInventory(int hCom, int flagAnti, int initQ, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuKillTag(int hCom, StringBuilder KillPwd, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuLockMem(int hCom, StringBuilder AccessPwd, StringBuilder LockData, StringBuilder DIS_UII, StringBuilder ErrorCode, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuOpenAndConnect(ref int hCom, char[] cPort, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuOpenPower(int hCom, int flagCrc);
        [DllImport("UHF_API.dll", SetLastError = true)]
        public static extern int RmuReadData(int hCom, StringBuilder Passwordbuffer, int uBank, ref char Ptr, int uCnt, byte[] DIS_UII, ref byte DIS_ReadData, StringBuilder uErrorCode, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuSetPower(int hCom, int uOption, int uPower, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuStopGet(int hCom, int flagCrc);
        [DllImport("UHF_API.dll")]
        public static extern int RmuWriteData(int hCom, StringBuilder Passwordbuffer, int uBank, ref char Ptr, int uCnt, byte[] DIS_UII, byte[] DIS_WriteData, StringBuilder uErrorCode, int flagCrc);
        public string StrToHex(string str)
        {
            string str2 = "";
            if (str == "")
            {
                return "";
            }
            byte[] bytes = Encoding.Default.GetBytes(str);
            for (int i = 0; i < bytes.Length; i++)
            {
                str2 = str2 + bytes[i].ToString("X");
            }
            return str2;
        }

        // Nested Types
        public class Read
        {
            // Fields
            public string Cardtype = "";
            public string CarNum = "";
            public string date = "";
            public string Status = "";
        }
    }


}
