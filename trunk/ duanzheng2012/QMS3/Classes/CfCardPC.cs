#region 库文件声明

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


#endregion

namespace QMS3.CfCardPC
{
    class CfCardPC
    {
        #region 预定义函数

        public CfCardPC()
        {
            sKey = "00000000";              //默认定义密钥为"00000000" 
            nComPort = 1;                   //默认定义使用的COM端口为COM1
            bConnectedDevice = false;       //默认尚未连接上读卡器
            RS485Address = 0;
        }

        public CfCardPC(string Key)
        {
            sKey = Key;                     //定义密钥为Key  
            nComPort = 1;                   //默认定义使用的COM端口为COM1
            bConnectedDevice = false;       //默认尚未连接上读卡器
            RS485Address = 0;
        }

        public CfCardPC(string Key, int Port)
        {
            sKey = Key;                     //定义密钥为Key  
            nComPort = Port;                //定义使用的COM端口为Port
            //若定义COM端口为0，则为从COM1至COM32自适应
            bConnectedDevice = false;       //默认尚未连接上读卡器
            RS485Address = 0;
        }

        public static byte GetHexBitsValue(byte ch)
        {
            byte sz = 0;
            if (ch <= '9' && ch >= '0')
                sz = (byte)(ch - 0x30);
            if (ch <= 'F' && ch >= 'A')
                sz = (byte)(ch - 0x37);
            if (ch <= 'f' && ch >= 'a')
                sz = (byte)(ch - 0x57);

            return sz;
        }

        public string getSecKey() { return sKey; }
        public int getComPort() { return nComPort; }
        public bool setSecKey(string key)
        {
            if (key.Length == 12)
            {
                sKey = key;
                return true;
            }
            return false;
        }

        public bool setComPort(int port)
        {
            if (port > 0 && port < 20 || port == 0)
            {
                nComPort = port;
                return true;
            }
            return false;
        }

        public static string ToHexString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length * 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }

            return new string(chars);
        }

        public static byte[] ToDigitsBytes(string theHex)
        {
            byte[] bytes = new byte[theHex.Length / 2 + (((theHex.Length % 2) > 0) ? 1 : 0)];
            for (int i = 0; i < bytes.Length; i++)
            {
                char lowbits = theHex[i * 2];
                char highbits;

                if ((i * 2 + 1) < theHex.Length)
                    highbits = theHex[i * 2 + 1];
                else
                    highbits = '0';

                int a = (int)GetHexBitsValue((byte)lowbits);
                int b = (int)GetHexBitsValue((byte)highbits);
                bytes[i] = (byte)((a << 4) + b);
            }

            return bytes;
        }

        #endregion

        //////////////////////////Library Import//////////////////////////
        #region Library Import

        [DllImport("kernel32.dll")]
        static extern void Sleep(int dwMilliseconds);

        #region Parameter


        [StructLayout(LayoutKind.Sequential)]
        public struct Parameter
        {
            public byte BaudRate;
            public byte Power;
            public byte Min_Frequence;
            public byte Antenna;
            public byte WorkMode;
            public byte ReadInterval;
            public byte OutMode;
            public byte TriggerMode;
            public byte IDPosition;
            public byte IfTestValidity;
            public byte OutInterface;
            public byte NumofCard;
            public byte Power2;
            public byte TagType;
            public byte WiegandWidth;
            public byte WiegandInterval;
            public byte ID_Start;
            public byte Max_Frequence;
            public byte ReadDuration;
            public byte StandardTime;
            public byte EnableBuzzer;
            public byte ReaderAddress;
            public byte Reserve23;
            public byte Reserve24;
            public byte Reserve25;
            public byte Reserve26;
            public byte Reserve27;
            public byte Reserve28;
            public byte Reserve29;
            public byte Reserve30;
            public byte TX_Mode;
            public byte Modulation;
        }

        [DllImport("Reader2600DLL.dll")]
        public static extern int ConnectScanner(ref int hScanner, string PortNum, int nBaudRate, int Address);
        //[DllImport("Reader2600DLL.dll")]
        //public static extern int DisconnectScanner(ref int hScanner);
        [DllImport("Reader2600DLL.dll")]
        public static extern int GetReaderVersion(int hScanner, ref int hardver, ref int Softver, int Address);
        [DllImport("Reader2600DLL.dll")]
        public static extern int SetAntenna(int hScanner, int m_antenna_sel, int Address);
        //设置读写器继电器状态
        //apiReturn _stdcall SetRelay(HANDLE hScanner, int Relay);
        [DllImport("Reader2600DLL.dll")]
        public static extern int SetRelay(int hScanner, int Relay, int Address);

        //设定输出功率
        //apiReturn _stdcall SetOutputPower(int hScanner, int nPower1);
        [DllImport("Reader2600DLL.dll")]
        public static extern int SetOutputPower(int hScanner, int nPower1, int Address);

        //读取写器工作参数
        //apiReturn _stdcall ReadParam(HANDLE hScanner, Reader2200Param * pParam);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ReadParam(int hScanner, ref Parameter pParam, int Address);

        //设置读写器工作参数
        //apiReturn _stdcall WriteParam(HANDLE hScanner, Reader2200Param * pParam);
        [DllImport("Reader2600DLL.dll")]
        public static extern int WriteParam(int hScanner, ref Parameter pParam, int Address);


        //复位读写器
        //apiReturn _stdcall Reboot(HANDLE hScanner);
        [DllImport("Reader2600DLL.dll")]
        public static extern int Reboot(int hScanner, int Address);


        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_ReadLabelID(int hScanner, int mem, int ptr, int len, byte[] mask, byte[] IDBuffer, ref int nCounter, int Address);
        //读一块数据
        //apiReturn _stdcall EPC1G2_ReadWordBlock(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE mem, BYTE ptr, BYTE len, BYTE *Data, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_ReadWordBlock(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte mem, byte ptr, byte len, byte[] Data, byte[] AccessPassword, int Address);

        //写一块数据
        //apiReturn _stdcall EPC1G2_WriteWordBlock(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE mem, BYTE ptr, BYTE len, BYTE *Data, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_WriteWordBlock(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte mem, byte ptr, byte len, byte[] Data, byte[] AccessPassword, int Address);
        //设置读写保护状态
        //apiReturn _stdcall EPC1G2_SetLock(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE mem, BYTE Lock, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_SetLock(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte mem, byte Lock, byte[] AccessPassword, int Address);
        //擦除标签数据
        //apiReturn _stdcall EPC1G2_EraseBlock(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE mem, BYTE ptr, BYTE len);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_EraseBlock(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte mem, byte ptr, byte len, int Address);
        //永久休眠标签
        //apiReturn _stdcall EPC1G2_KillTag(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE *KillPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_KillTag(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte[] KillPassword, int Address);
        //写EPC
        //apiReturn _stdcall EPC1G2_WriteEPC(HANDLE hScanner, BYTE len, BYTE *Data, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_WriteEPC(int hScanner, byte len, byte[] Data, byte[] AccessPassword, int Address);
        //块锁命令
        //apiReturn _stdcall EPC1G2_BlockLock(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE ptr, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_BlockLock(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte ptr, byte[] AccessPassword, int Address);
        //EAS状态操作命令
        //apiReturn _stdcall EPC1G2_ChangeEas(HANDLE hScanner, BYTE EPC_WORD, BYTE *IDBuffer, BYTE State, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_ChangeEas(int hScanner, byte EPC_WORD, byte[] IDBuffer, byte State, byte[] AccessPassword, int Address);
        //EAS报警命令
        //apiReturn _stdcall EPC1G2_EasAlarm(HANDLE hScanner);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_EasAlarm(int hScanner, int Address);
        //读保护设置
        //apiReturn _stdcall EPC1G2_ReadProtect(HANDLE hScanner,BYTE *AccessPassword, BYTE EPC_WORD, BYTE *IDBuffer);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_ReadProtect(int hScanner, byte[] AccessPassword, byte EPC_WORD, byte[] IDBuffer, int Address);
        //复位读保护设置
        //apiReturn _stdcall EPC1G2_RStreadProtect(HANDLE hScanner, BYTE *AccessPassword);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_RStreadProtect(int hScanner, byte[] AccessPassword, int Address);
        //侦测标签
        //apiReturn _stdcall EPC1G2_DetectTag(HANDLE hScanner);
        [DllImport("Reader2600DLL.dll")]
        public static extern int EPC1G2_DetectTag(int hScanner, int Address);
        #endregion

        #region ISO6B
        //==============================ISO-6B数据读写命令==============================
        //检测标签存在
        //apiReturn _stdcall ISO6B_LabelPresent(HANDLE hScanner, int *nCounter);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_LabelPresent(int hScanner, ref int nCounter, int Address);

        //读取ISO6B标签ID号
        //apiReturn _stdcall ISO6B_ReadLabelID(HANDLE hScanner, BYTE *IDBuffer, int *nCounter);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_ReadLabelID(int hScanner, byte[,] IDBuffer, ref int nCounter, int Address);

        //列出选定标签
        //apiReturn _stdcall ISO6B_ListSelectedID(HANDLE hScanner, int Cmd, int ptr, BYTE Mask, BYTE *Data, BYTE *IDBuffer, int *nCounter);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_ListSelectedID(int hScanner, int Cmd, int ptr, byte Mask, byte[] Data, byte[,] IDBuffer, ref int nCounter, int Address);
        //读一块数据
        //apiReturn _stdcall ISO6B_ReadByteBlock(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr, BYTE len,BYTE *Data);

        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_ReadByteBlock(int hScanner, byte[] IDBuffer, byte ptr, byte len, byte[] Data, int Address);
        //写一块数据
        //apiReturn _stdcall ISO6B_WriteByteBlock(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr, BYTE len, BYTE *Data);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_WriteByteBlock(int hScanner, byte[] IDBuffer, byte ptr, byte len, byte[] Data, int Address);

        //置写保护状态
        //apiReturn _stdcall ISO6B_WriteProtect(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_WriteProtect(int hScanner, byte[] IDBuffer, byte ptr, int Address);

        //读写保护状态
        //apiReturn _stdcall ISO6B_ReadWriteProtect(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr, BYTE *Protected);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_ReadWriteProtect(int hScanner, byte[] IDBuffer, byte ptr, ref byte Protected, int Address);

        //全部清除
        //apiReturn _stdcall ISO6B_ClearMemory(HANDLE hScanner, BYTE CardType, BYTE *IDBuffer);
        [DllImport("Reader2600DLL.dll")]
        public static extern int ISO6B_ClearMemory(int hScanner, byte cardType, byte[] IDBuffer, int Address);

        internal static int ISO6B_WriteByteBlock(int m_hScanner, byte p, byte p_3, byte[] mask)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region TK900
        //读取TK900标签ID号
        //apiReturn _stdcall TK900_ReadLabelID(HANDLE hScanner, BYTE *IDBuffer, int *nCounter);
        [DllImport("Reader2600DLL.dll")]
        public static extern int TK900_ReadLabelID(int hScanner, byte[,] IDBuffer, ref int nCounter, int Address);

        //读一块数据
        //apiReturn _stdcall TK900_ReadPageBlock(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr, BYTE len,BYTE *Data);
        [DllImport("Reader2600DLL.dll")]
        public static extern int TK900_ReadPageBlock(int hScanner, byte[] IDBuffer, byte ptr, byte len, byte[,] Data, int Address);

        //写一块数据
        //apiReturn _stdcall TK900_WritePageBlock(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr, BYTE *Data);

        [DllImport("Reader2600DLL.dll")]
        public static extern int TK900_WritePageBlock(int hScanner, byte[] IDBuffer, byte ptr, byte[] Data, int Address);
        //置写保护状态
        //apiReturn _stdcall TK900_SetProtect(HANDLE hScanner, BYTE *IDBuffer, BYTE ptr, BYTE len);

        [DllImport("Reader2600DLL.dll")]
        public static extern int TK900_SetProtect(int hScanner, byte[] IDBuffer, byte ptr, byte len, int Address);
        //读写保护状态
        //apiReturn _stdcall TK900_GetProtect(HANDLE hScanner, BYTE *IDBuffer ,BYTE *state);
        [DllImport("Reader2600DLL.dll")]
        public static extern int TK900_GetProtect(int hScanner, byte[] IDBuffer, byte[] State, int Address);
        #endregion

        #region systemAPI
        public delegate void TimerProc(IntPtr hWnder, uint nMsg, int nIDEvent, int dwTime);
        [DllImport("user32.dll")]
        public static extern int SetTimer(int hwnd, int nIDEvent, int uElapse, TimerProc CB);
        [DllImport("user32.dll")]
        public static extern int KillTimer(int hwnd, int nIDEvent);

        [DllImport("kernel32.dll")]
        public static extern bool GetCommState(
         int hFile,
         ref DCB lpDCB
       );

        [DllImport("kernel32.dll")]
        public static extern bool SetCommState(
         int hFile,  // 通信设备句柄 
         ref DCB lpDCB    // 设备控制块 
       );

        [DllImport("kernel32.dll")]
        public static extern bool PurgeComm(
        int hFile,  // 通信设备句柄 
        uint dwFlags
        );


        //        [DllImport("kernel32.dll")]
        //        public static extern bool Beep(int frequency, int duration);

        [DllImport("user32.dll")]
        public static extern bool MessageBeep(int beepType);


        [StructLayout(LayoutKind.Sequential)]
        public struct DCB
        {
            //taken from c struct in platform sdk  
            public int DCBlength;           // sizeof(DCB)  
            public int BaudRate;            // 指定当前波特率 current baud rate 
            // these are the c struct bit fields, bit twiddle flag to set 
            public int fBinary;          // 指定是否允许二进制模式,在windows95中必须主TRUE binary mode, no EOF check  
            public int fParity;          // 指定是否允许奇偶校验 enable parity checking  
            public int fOutxCtsFlow;      // 指定CTS是否用于检测发送控制，当为TRUE是CTS为OFF，发送将被挂起。 CTS output flow control  
            public int fOutxDsrFlow;      // 指定CTS是否用于检测发送控制 DSR output flow control  
            public int fDtrControl;       // DTR_CONTROL_DISABLE值将DTR置为OFF, DTR_CONTROL_ENABLE值将DTR置为ON, DTR_CONTROL_HANDSHAKE允许DTR"握手" DTR flow control type  
            public int fDsrSensitivity;   // 当该值为TRUE时DSR为OFF时接收的字节被忽略 DSR sensitivity  
            public int fTXContinueOnXoff; // 指定当接收缓冲区已满,并且驱动程序已经发送出XoffChar字符时发送是否停止。TRUE时，在接收缓冲区接收到缓冲区已满的字节XoffLim且驱动程序已经发送出XoffChar字符中止接收字节之后，发送继续进行。　FALSE时，在接收缓冲区接收到代表缓冲区已空的字节XonChar且驱动程序已经发送出恢复发送的XonChar之后，发送继续进行。XOFF continues Tx  
            public int fOutX;          // TRUE时，接收到XoffChar之后便停止发送接收到XonChar之后将重新开始 XON/XOFF out flow control  
            public int fInX;           // TRUE时，接收缓冲区接收到代表缓冲区满的XoffLim之后，XoffChar发送出去接收缓冲区接收到代表缓冲区空的XonLim之后，XonChar发送出去 XON/XOFF in flow control  
            public int fErrorChar;     // 该值为TRUE且fParity为TRUE时，用ErrorChar 成员指定的字符代替奇偶校验错误的接收字符 enable error replacement  
            public int fNull;          // eTRUE时，接收时去掉空（0值）字节 enable null stripping  
            public int fRtsControl;     // RTS flow control 
            /*RTS_CONTROL_DISABLE时,RTS置为OFF 
             RTS_CONTROL_ENABLE时, RTS置为ON 
           RTS_CONTROL_HANDSHAKE时, 
           当接收缓冲区小于半满时RTS为ON 
              当接收缓冲区超过四分之三满时RTS为OFF 
           RTS_CONTROL_TOGGLE时, 
           当接收缓冲区仍有剩余字节时RTS为ON ,否则缺省为OFF*/
            public int fAbortOnError;   // TRUE时,有错误发生时中止读和写操作 abort on error  
            public int fDummy2;        // 未使用 reserved  

            public uint flags;
            public ushort wReserved;          // 未使用,必须为0 not currently used  
            public ushort XonLim;             // 指定在XON字符发送这前接收缓冲区中可允许的最小字节数 transmit XON threshold  
            public ushort XoffLim;            // 指定在XOFF字符发送这前接收缓冲区中可允许的最小字节数 transmit XOFF threshold  
            public byte ByteSize;           // 指定端口当前使用的数据位   number of bits/byte, 4-8  
            public byte Parity;             // 指定端口当前使用的奇偶校验方法,可能为:EVENPARITY,MARKPARITY,NOPARITY,ODDPARITY  0-4=no,odd,even,mark,space  
            public byte StopBits;           // 指定端口当前使用的停止位数,可能为:ONESTOPBIT,ONE5STOPBITS,TWOSTOPBITS  0,1,2 = 1, 1.5, 2  
            public char XonChar;            // 指定用于发送和接收字符XON的值 Tx and Rx XON character  
            public char XoffChar;           // 指定用于发送和接收字符XOFF值 Tx and Rx XOFF character  
            public char ErrorChar;          // 本字符用来代替接收到的奇偶校验发生错误时的值 error replacement character  
            public char EofChar;            // 当没有使用二进制模式时,本字符可用来指示数据的结束 end of input character  
            public char EvtChar;            // 当接收到此字符时,会产生一个事件 received event character  
            public ushort wReserved1;         // 未使用 reserved; do not use  
        }

        #endregion

        #endregion
        ////////////////////////Library Import End////////////////////////

        //////////////////Member Function Definition///////////////////////
        #region Member Function Definition

        #region 连接读卡器
        /// <summary>
        /// 连接读卡器
        /// </summary>
        /// <returns>成功打开端口返回true，如果已经打开或者未能打开，均返回false</returns>
        /// <remarks>调用此函数时，如果请注意！尚未连接到读卡器，则连接读卡器；否则返回false</remarks>
        public bool Connect()
        {
            if (!bConnectedDevice)
            {
                int status = 0;

                int nBaudRate = 19200;

                if (nComPort == 0)
                {
                    for (int n = 1; n < 20; n++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            status = ConnectScanner(ref m_hScanner, "COM" + n.ToString(), nBaudRate, 0);
                            if (status == OK)
                            {
                                break;
                            }
                        }
                        if (status == OK)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        status = ConnectScanner(ref m_hScanner, "COM" + "3", nBaudRate, 0);
                        if (status == OK)
                        {
                            break;
                        }
                    }
                }

                if (status == OK)
                {
                    bConnectedDevice = true;
                    //MessageBox.Show("读卡器连接成功！");
                }
                else
                {
                    string strError = "出问题啦！请确认读卡器连接无误并且没有被其它软件占用！";
                    byte nError = (byte)status;
                    bConnectedDevice = false;
                    MessageBox.Show(strError, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("错误代码：" + nError.ToString(), "错误代码", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Parameter Param = new Parameter();
                for (int i = 0; i < 5; i++)
                {
                    status = ReadParam(m_hScanner, ref Param, RS485Address);
                    if (status == OK)
                        break;
                }
                if (status != OK)
                {
                    MessageBox.Show("出问题啦！读取读卡器参数有错误！\n错误代码：" + status.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                RS485Address = Convert.ToInt16(Param.ReaderAddress.ToString());

                return true;
            }
            else
            {
                //return false;
                return true;    //读卡器已经打开
            }
        }
        #endregion

        #region 断开读卡器
        /// <summary>
        /// 断开读卡器
        /// </summary>
        /// <returns>成功断开端口返回true，如果已经断开或者未能断开，均返回false</returns>
        public bool Disconnect()
        {
            if (bConnectedDevice)
            {
                int status = 0;

                //status = DisconnectScanner (ref m_hScanner);
                if (status == OK)
                {
                    //bConnectedDevice = false;
                    //MessageBox.Show("读卡器断开成功！");
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 有关读卡.

        #region 寻卡, 并获得卡片Tag ID
        /// <summary>
        /// 寻找并锁定卡片，同时获得卡片Tag ID
        /// </summary>
        /// <param name="CardID">CardID:[OUT]所读卡片的Tag ID</param>
        /// <returns>
        /// 0：成功返回
        /// -1：未连接读卡器
        /// -2：存在多余卡片
        /// </returns>

        public int Request(ref string CardID)
        {
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }


            int m_antenna_sel = 0x01;
            int status = -1;


            int nCounter = 0, ID_len = 0, ID_len_temp = 0;
            string str = "", strtemp = "";

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];
            ;
            byte[] AccessPassWord = new byte[4];

            for (int n = 0; n < 100; n++)
            {
                //设置天线
                for (int i = 0; i < 2; i++)
                {
                    status = SetAntenna(m_hScanner, m_antenna_sel, RS485Address);
                    if (status == OK)
                        break;
                    m_antenna_sel = m_antenna_sel * 2;
                    Sleep(20);
                }
                if (status != OK)
                {
                    MessageBox.Show("读卡器天线出现问题，请重试！\n若仍然有问题，请联系生产厂家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                //MessageBox.Show("天线成功！");

                //读取G2卡ID
                Array.Clear(TagBuffer, 0, TagBuffer.Length);

                status = EPC1G2_ReadLabelID(m_hScanner, 1, 0, 0, mask, IDBuffer, ref nCounter, 0);

                if (status != OK)
                {
                    Sleep(20);
                    continue;
                }
                // 如果ID Buffer中的ID比设定的长度(目前是6)大，则说明读取错误？放弃本次读取，再读一次
                if (IDBuffer[ID_len] > 6)
                {
                    nCounter = 0;
                    Sleep(20);
                    continue;
                }//

                //转换ID Buffer到 String
                //取ID Buffer中第一个ID，若有多个ID，则提示错误！
                if (nCounter > 1)
                {
                    status = 11;
                    break;
                }
                ID_len_temp = IDBuffer[ID_len] * 2 + 1;
                for (int j = 0; j < ID_len_temp; j++)
                {
                    TagBuffer[j] = IDBuffer[ID_len + j];
                }
                ID_len += ID_len_temp;

                str = "";
                strtemp = "";
                ID_len = TagBuffer[0] * 2;
                for (int j = 0; j < ID_len; j++)
                {
                    strtemp = TagBuffer[j + 1].ToString("X2");
                    str += strtemp;
                }

                CardID = str;

                //MessageBox.Show(CardID);
                /*************************************
                  ************************************/
                //返回卡ID，取EPC数据块的第16起共8位字符
                if (CardID.Length > 23)
                    CardID = CardID.Substring(16, 8);
                //************************************/

                break;//*/
            }

            if (status != OK)
            {
                switch (status)
                {
                    case 1:
                        MessageBox.Show("出问题啦！读卡器天线连接失败！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("未检测到有效的数据卡！请扫描卡片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 3:
                        MessageBox.Show("出问题啦！检测到非法的数据卡！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        MessageBox.Show("出问题啦！读写功率不够！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 5:
                        MessageBox.Show("出问题啦！数据卡ID区读写保护！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 6:
                        MessageBox.Show("出问题啦！校验和错误！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 7:
                        MessageBox.Show("出问题啦！参数错误！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 8:
                        MessageBox.Show("出问题啦！数据区不存在！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 9:
                        MessageBox.Show("出问题啦！数据卡的密码不正确！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 11:
                        MessageBox.Show("读卡器有效区域内检测到多余的卡片。"
                            + "\n请确保有且仅有一张卡片在扫描区域中再操作！", "出问题啦！",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -2;
                    default:
                        MessageBox.Show("出现了未知问题！\n错误代码：" + status.ToString(), "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return -1;
            }

            return 0;
        }
        #endregion

        #region 获取取卡片的编号
        /// <summary>
        /// 获取卡片的编号
        /// </summary>
        /// <param name="CardClass">CardClass: [IN]记录选择卡的类型: 0为司机卡, 1为货箱卡, -1为不验证卡类型. 其它值无效</param>
        /// <param name="CardID">CardID: [OUT]返回卡片的序列号</param>
        /// <returns>
        /// 0：成功运行
        /// -1：连接读卡器错误
        /// 2：读取卡片错误
        /// 3：卡片类型不一致
        /// 4：卡片密钥验证错误
        /// 5：多余一张卡片
        /// </returns>

        public int GetCardID(int CardClass, ref string CardID)
        {
            int status;
            int CardClassCoincidence;
            string Pc_str_CardID = "";

            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            status = Request(ref Pc_str_CardID);

            if (-1 == status)
            {
                //MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            else if (-2 == status)
            {
                return 5;
            }

            //MessageBox.Show(Pc_str_CardID.Trim(), "读出卡片编号", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (CardClass == 0 || CardClass == 1)       //需要验证卡类型
            {
                CardClassCoincidence = GetCardClass(CardClass, Pc_str_CardID.Trim());

                //MessageBox.Show(CardID, "读出卡片编号2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //MessageBox.Show(CardClassCoincidence.ToString(), "类型一致性提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CardClassCoincidence == 1)
                {
                    if (DialogResult.No == MessageBox.Show("您扫描的卡片与选择类型不一致，是否重新初始化该卡为所选类型？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return 3;
                }
                else if (CardClassCoincidence == 3)
                {
                    MessageBox.Show("您扫描的卡片数据类型存储错误，需要重新初始化。",
                                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            CardID = Pc_str_CardID.Trim();

            return 0;
        }
        //*/
        #endregion

        #region 获取卡片类型
        /// <summary>
        /// 获取卡片类型
        /// </summary>
        /// <param name="CardClass">CardClass: [IN]记录选择卡的类型: 0为司机卡, 1为货箱卡. 其它值无效</param>
        /// <param name="CardID">CardID: [IN]记录卡片的序列号</param>
        /// <returns>
        /// 0：卡片类型一致
        /// 1：卡片类型不一致
        /// 2：卡片为新卡
        /// -1：连接读卡器错误
        /// </returns>
        public int GetCardClass(int CardClass, string CardID)
        {
            string Pc_str_CardClass = "";

            //从User区首地址0长度1Word处获取卡片类型
            //“C”代表“CARCARD”，即司机卡
            //“B”代表“BOXCARD”，即货箱卡
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int m_antenna_sel = 1;
            int status = -1;

            byte EPC_BYTE = 0x00;
            byte ptr = 0x00;        //读取起始地址
            byte len = 0x00;        //读取的长度

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];

            byte[] AccessPassword = new byte[4];

            string str_temp = "00000000";
            for (int i = 0; i < 4; i++)
            {
                AccessPassword[i] = Convert.ToByte(str_temp[i * 2] + str_temp[i * 2 + 1]);
            }

            EPC_BYTE = Convert.ToByte("6");    //目前认为ID是6位
            ptr = Convert.ToByte("0");          //准备读的首地址是0
            len = Convert.ToByte("1");          //准备读的长度是1

            for (int n = 0; n < 100; n++)
            {
                //设置天线
                for (int i = 0; i < 2; i++)
                {
                    status = SetAntenna(m_hScanner, m_antenna_sel, RS485Address);
                    if (status == OK)
                        break;
                    m_antenna_sel = m_antenna_sel * 2;
                    Sleep(20);
                }
                if (status != OK)
                {
                    MessageBox.Show("读卡器天线出现问题，请重试！\n若仍然有问题，请联系生产厂家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                //MessageBox.Show("天线成功！");

                //读取卡片类型
                byte[] IDTemp = new byte[12];               //目前认为ID是6位

                for (int i = 0; i < TagBuffer[0] * 2; i++)
                {
                    IDTemp[i] = TagBuffer[i + 1];
                }


                status = EPC1G2_ReadWordBlock(m_hScanner, EPC_BYTE, IDTemp, Convert.ToByte(3), ptr, len, DB, AccessPassword, 0);
                if (status == OK)
                    break;
            }

            Pc_str_CardClass = System.Text.Encoding.UTF8.GetString(DB, 0, 1 * 2);     //准备读的长度是1

            try
            {
                Pc_str_CardClass = Pc_str_CardClass.Substring(0, 1);
            }
            catch
            {
                Pc_str_CardClass = "\0";
            }

            //MessageBox.Show("已经读取的卡片类型：" + Pc_str_CardClass);   //测试用
            //MessageBox.Show("准备读取的卡片类型：" + CardClass.ToString ());   //测试用

            if ((CardClass == 0 && Pc_str_CardClass == "C") ||
                (CardClass == 1 && Pc_str_CardClass == "B"))
                return 0;
            else if ((CardClass == 1 && Pc_str_CardClass == "C") ||
                     (CardClass == 0 && Pc_str_CardClass == "B"))
                return 1;
            else
                return 2;
        }
        //*/ 
        #endregion

        #region 读取司机车牌号码
        /// <summary>
        /// 读取司机车牌号码
        /// </summary>
        /// <param name="TruckNo">TruckNo:[OUT] 获取司机卡中的司机车牌号码</param>
        /// <returns>
        /// 0：成功运行
        /// -1：连接读卡器错误
        /// 2：读取卡片错误
        /// 3：卡片类型错误
        /// 4：卡片密钥验证错误
        /// </returns>

        public int ReadTruckNo(ref string TruckNo)
        {
            string Pc_str_TruckNo = "";

            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int m_antenna_sel = 1;
            int status = -1;

            byte EPC_BYTE = 0x00;
            byte ptr = 0x00;        //读取起始地址
            byte len = 0x00;        //读取的长度

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];

            byte[] AccessPassword = new byte[4];

            string str_temp = "00000000";
            for (int i = 0; i < 4; i++)
            {
                AccessPassword[i] = Convert.ToByte(str_temp[i * 2] + str_temp[i * 2 + 1]);
            }

            EPC_BYTE = Convert.ToByte("6");    //目前认为ID是6位
            ptr = Convert.ToByte("1");          //准备读的首地址是0
            len = Convert.ToByte("5");          //准备读的长度是5

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = SetAntenna(m_hScanner, m_antenna_sel, RS485Address);
                    if (status == OK)
                        break;
                    m_antenna_sel = m_antenna_sel * 2;
                    Sleep(20);
                }
                if (status != OK)
                {
                    MessageBox.Show("读卡器天线出现问题，请重试！\n若仍然有问题，请联系生产厂家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                //MessageBox.Show("天线成功！");

                //读取司机车牌号码，即读取卡片指定区域
                //目前读取User区的 
                byte[] IDTemp = new byte[12];               //目前认为ID是6位

                for (int i = 0; i < TagBuffer[0] * 2; i++)
                {
                    IDTemp[i] = TagBuffer[i + 1];
                }


                status = EPC1G2_ReadWordBlock(m_hScanner, EPC_BYTE, IDTemp, Convert.ToByte(3), ptr, len, DB, AccessPassword, 0);
                if (status == OK)
                    break;

                Sleep(20);
            }

            Pc_str_TruckNo = System.Text.Encoding.UTF8.GetString(DB, 0, 5 * 2);     //准备读的长度是5

            //MessageBox.Show(Pc_str_TruckNo, "司机编号", MessageBoxButtons.OK, MessageBoxIcon.Information);  //测试用

            TruckNo = Pc_str_TruckNo.Trim();

            return 0;
        }//*/
        #endregion

        #endregion


        #region 有关写卡

        #region 向G2卡写入字串
        /// <summary>
        /// 向G2卡U写入字串
        /// </summary>
        /// <param name="block">block:[IN] 待写入的数据区，1为EPC区，3为USER区，其它值不接收</param>
        /// <param name="n_ptr">ptr:[IN] 准备写入数据区的相对首地址</param>
        /// <param name="n_len">len:[IN] 准备写入的数据长度，单位WORD</param>
        /// <param name="PutString">PutString:[IN] 准备写入数据的字串</param>
        /// <returns>
        /// 0：成功运行
        /// -1：连接读卡器错误
        /// 2：读取卡片错误
        /// 3：卡片类型错误
        /// 4：卡片密钥验证错误
        /// 5：卡片写入失败
        /// 6：数据与长度不符合
        /// 7：写入数据区错误
        /// </returns>
        private int PutDataIntoCard(int block, int n_ptr, int n_len, string PutString)
        {
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int m_antenna_sel = 1;
            int status = -1;

            //string str = "", strtemp = "";
            string str = "";

            byte EPC_BYTE = 0x00;

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];
            mask = System.Text.Encoding.UTF8.GetBytes(PutString);

            byte[] AccessPassword = new byte[4];

            string str_temp = "00000000";           //  
            for (int i = 0; i < 4; i++)
            {
                AccessPassword[i] = Convert.ToByte(str_temp[i * 2] + str_temp[i * 2 + 1]);
            }

            EPC_BYTE = Convert.ToByte("6");            //目前认为ID是6位
            byte ptr = Convert.ToByte(n_ptr);          //准备读的首地址是n_ptr
            byte len = Convert.ToByte(n_len);          //准备读的长度是n_len

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = SetAntenna(m_hScanner, m_antenna_sel, RS485Address);
                    if (status == OK)
                        break;
                    m_antenna_sel = m_antenna_sel * 2;
                    Sleep(20);
                }
                if (status != OK)
                {
                    MessageBox.Show("读卡器天线出现问题，请重试！\n若仍然有问题，请联系生产厂家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                //MessageBox.Show("天线成功！");

                //写入卡片指定区域
                if (block == 3)
                {
                    //目前写入User区的 
                    byte[] IDTemp = new byte[12];               //目前认为ID是6位

                    for (int i = 0; i < TagBuffer[0] * 2; i++)
                    {
                        IDTemp[i] = TagBuffer[i + 1];
                    }

                    str = PutString;

                    Sleep(20);
                    status = EPC1G2_WriteWordBlock(m_hScanner, EPC_BYTE, IDTemp, 3, ptr, len, mask, AccessPassword, 0);
                }
                else if (block == 1)
                {
                }
                else
                    return 7;
                if (status == OK)
                    break;

                Sleep(10);
            }
            if (status != OK)
            {
                switch (status)
                {
                    case 1:
                        MessageBox.Show("出问题啦！读卡器天线连接失败！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        MessageBox.Show("未检测到有效的数据卡！请扫描卡片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 3:
                        MessageBox.Show("出问题啦！检测到非法的数据卡！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        MessageBox.Show("出问题啦！读写功率不够！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 5:
                        MessageBox.Show("出问题啦！数据卡ID区读写保护！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 6:
                        MessageBox.Show("出问题啦！校验和错误！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 7:
                        MessageBox.Show("出问题啦！参数错误！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 8:
                        MessageBox.Show("出问题啦！数据区不存在！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 9:
                        MessageBox.Show("出问题啦！数据卡的密码不正确！", "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("出现了位置问题！\n错误代码：" + status.ToString(), "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return 5;
            }
            return 0;
        }

        #endregion

        #region 写入司机车牌号码
        /// <summary>
        /// 写入司机车牌号码
        /// </summary>
        /// <param name="TruckNo">TruckNo:[IN] 卡中的司机车牌号码</param>
        /// <returns>
        /// 0：成功运行
        /// -1：连接读卡器错误
        /// 2：读取卡片错误
        /// 3：卡片类型错误
        /// 4：卡片密钥验证错误
        /// 5：卡片写入失败
        /// </returns>

        public int WriteTruckNo(string TruckNo)
        {
            string Pc_str_TruckNo = TruckNo.Trim() + "\0";

            Sleep(10);
            int status = PutDataIntoCard(3, 1, 5, Pc_str_TruckNo);

            if (status != OK)
            {
                return 5;
            }

            return 0;
        }
        //*/
        #endregion

        #region 写入卡片类型
        /// <summary>
        /// 写入卡片类型
        /// </summary>
        /// <param name="CardClass">CardClass: [IN] 待写入的卡片类型</param>
        /// <returns>
        /// 0：成功运行
        /// -1：连接读卡器错误
        /// 2：读取卡片错误
        /// 3：卡片类型错误
        /// 4：卡片密钥验证错误
        /// 5：卡片写入失败
        /// </returns>

        public int WriteCardClass(string CardClass)
        {
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            //将卡类型写入User区首地址为0字长为1个字的区域
            int status = PutDataIntoCard(3, 0, 1, CardClass);

            if (status != 0)
            {
                //MessageBox.Show("初始化卡片类型时，写卡失败！", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 5;
            }
            return 0;
        }
        //*/
        #endregion

        #region 初始化任务状态
        /// <summary>
        /// 初始化任务状态
        /// </summary>
        /// <returns></returns>

        public int InitTaskStatus()
        {
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            string Pc_str_TaskStatus = "\0";

            //将任务状态写入User区首地址为17字长为1个字的区域
            Sleep(10);
            int status = PutDataIntoCard(3, 17, 1, Pc_str_TaskStatus);

            if (status != 0)
            {
                //MessageBox.Show("初始化任务状态时，写卡失败！", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 5;
            }
            return 0;
        }
        //*/
        #endregion

        #region 初始化发货地点
        /// <summary>
        /// 初始化发货地点
        /// </summary>
        /// <returns></returns>

        public int InitSStation()
        {
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            string Pc_str_SStation = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0";

            //初始化发货地点
            //将任务状态写入User区首地址为18字长为6个字的区域
            Sleep(10);
            int status = PutDataIntoCard(3, 18, 6, Pc_str_SStation);
            /*
            int status = PutDataIntoCard(3, 6, 8, Pc_str_SStation);
            status = PutDataIntoCard(3, 14, 8, Pc_str_SStation);
            status = PutDataIntoCard(3, 18, 6, Pc_str_SStation);//*/

            if (status != 0)
            {
                //MessageBox.Show("初始化发货地点时，写卡失败！", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 5;
            }

            return 0;
        }
        //*/
        #endregion

        #region 初始化收发货时间
        /// <summary>
        /// 初始化收发货时间
        /// </summary>
        /// <returns></returns>

        public int InitSETime()
        {
            if (!bConnectedDevice)
            {
                MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            string Pc_str_SETime = "yyMMddHHmm";
            //初始化发货时间
            //将发货时间写入User区首地址为6字长为5个字的区域
            Sleep(10);
            int status = PutDataIntoCard(3, 6, 5, Pc_str_SETime);

            if (status != 0)
            {
                MessageBox.Show("初始化发货时间时，写卡失败！", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 5;
            }

            //初始化收货时间
            //将收货时间写入User区首地址为11字长为5个字的区域
            Sleep(10);
            status = PutDataIntoCard(3, 11, 5, Pc_str_SETime);

            if (status != 0)
            {
                MessageBox.Show("初始化收货时间时，写卡失败！", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 5;
            }

            return 0;
        }
        //*/
        #endregion

        #endregion



        #endregion
        //////////////////Member Function Definition End///////////////////

        ///////////////////////Member Variables/////////////////////////
        #region Member Variables

        string sKey;     //密钥
        int nComPort = 3;    //串口
        bool bConnectedDevice;/*是否连接上设备*/

        int m_hScanner;
        int RS485Address;

        //用于锁定数据卡的标签
        byte[] TagBuffer = new byte[16];

        static char[] hexDigits = { 
            '0','1','2','3','4','5','6','7',
            '8','9','A','B','C','D','E','F'};
        const int OK = 0;

        #endregion
        /////////////////////Member Variables End///////////////////////
    }
}