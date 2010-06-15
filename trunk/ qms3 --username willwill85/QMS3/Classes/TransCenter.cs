using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.IO;

using System.Net;
using System.Windows.Forms;
namespace QMS3
{
    class TransCenter
    {
        public static int m_hScanner;
        static bool bConnectedDevice;/*是否连接上设备*/
        static string sKey;     //密钥
        //用于锁定数据卡的标签
        public static byte[] TagBuffer = new byte[16];
        private const string MISSION_ING = "S";
        private const string MISSION_FINISH = "E";
        public static string Cardid = "";
        public static string sStartTime = "";

        public static string sEndTime = "";
        public static string TruckNo = "";
        public static int startstationid = 0;
        static char[] hexDigits = { 
            '0','1','2','3','4','5','6','7',
            '8','9','A','B','C','D','E','F'};
        #region 站名
        public static string[] StationName = { //55个
                                       "六部口",
                                        "新华社",
                                        "二龙路",
                                        "织女桥",
                                        "成方街",
                                        "四道口",
                                        "儿童医院",
                                        "一区",
                                        "二区",
                                        "真武庙",
                                        "全总",
                                        "西便门",
                                        "22号楼",
                                        "小马厂",
                                        "二炮",
                                        "扣钟庙",
                                        "电车一厂",
                                        "万明寺",
                                        "保险公司",
                                        "西斜街",
                                        "西四北头条",
                                        "安平巷",
                                        "官园",
                                        "中华路",
                                        "北草场",
                                        "德宝",
                                        "南关",
                                        "党校",
                                        "车公庄",
                                        "物资",
                                        "军报",
                                        "新华社东",
                                        "人大",
                                        "305医院",
                                        "508厂",
                                        "建工学院",
                                        "国防部",
                                        "西单",
                                        "皇城根",
                                        "护国寺",
                                        "西海",
                                        "陟山门",
                                        "恭俭",
                                        "前海西街",
                                        "后海",
                                        "184中",
                                        "大石桥",
                                        "六铺炕",
                                        "五路通",
                                        "新明",
                                        "马甸南村",
                                        "双 旗 杆",
                                        "一号地",
                                        "裕民东里",
                                        "四清公司"
                                   };
        #endregion
        const int OK = 0;

        public static bool connect()
        {
            char[] ipaddr = "192.168.0.88".ToCharArray();
            char[] ipaddr2 = "192.168.0.100".ToCharArray();
            // string[] ipaddr={"","","",""};
            String st = "";
            try
            {
                StreamReader din = File.OpenText("ip.ini");
                String str;

                while ((str = din.ReadLine()) != null)
                    st += str;
                ipaddr = st.ToCharArray();
                //  MessageBox.Show(st);

            }
            catch
            {
                MessageBox.Show("ip.ini配置文件丢失！\n请联系技术人员解决。");
                return false;
            }

            IPHostEntry myHost = new IPHostEntry();
            try
            {
                myHost = Dns.GetHostByName(Dns.GetHostName());
                //显示本地主机的IP地址表
                // for(int i=0; i<myHost.AddressList.Length;i++)
                // {
                // MessageBox.Show("本地主机IP地址->"+myHost.AddressList[i].ToString()+"\r");
                //  }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            ipaddr2 = myHost.AddressList[0].ToString().ToCharArray();
            if (Net_ConnectScanner(ref m_hScanner, ipaddr, 1969, ipaddr2, 5000) != 0)
            {
                MessageBox.Show("读卡器连接失败！\n请检查网络是否可用。\n" + "远程IP：" + st + "\n本地IP：" + myHost.AddressList[0].ToString());
                return false;
            }
            return true;
        }
        public static bool readinfo(ref string info, string weight, ref string st, ref int ss)
        {
            string sInfoR = "";
            if (ReadString(13, 1, ref sInfoR) != 0)
            {
                MessageBox.Show("无法读取任务状态！");
                info = "无法读取任务状态！";
                return false;
            }
            
            try
            {
                sInfoR = sInfoR.Remove(1);
            }
            catch
            {
                sInfoR = "A";
            }
            if (sInfoR == MISSION_FINISH)
            {
                MessageBox.Show("任务已完成！不能重复操作！");
                info = "任务已完成！不能重复操作！";
                return false;
            }
            else if (sInfoR != MISSION_ING)
            {
                MessageBox.Show("任务状态字出错！");
                info = "任务状态字出错！";
            }

            //读取车牌号
            string sCarNum = "";
            if (ReadString(1, 8, ref sCarNum) != 0)
            {
                MessageBox.Show("读取车牌号错误！");
                info = "读取车牌号错误！";
                return false;
            }
            sCarNum = sCarNum.Remove(6);
            TruckNo = sCarNum;
            //string sStartTime = "";
            if (ReadStringHex(6, 5, ref sStartTime) != 0)
            {
                MessageBox.Show("读取发货时间错误！");
                info = "读取发货时间错误！";
                return false;
            }
            //sStartTime = myCfCard.HexToStr(sStartTime);
            
            sStartTime = decodetime(sStartTime);
            //MessageBox.Show(sStartTime);
            //if (sEndTime.CompareTo(sStartTime) < 0)
            //{
            //    MessageBox.Show("错误！出发时间晚于到达时间！");
            //    return false;
            //}
            string sStartSpotNum = "";
            if (ReadString(9, 1, ref sStartSpotNum) != 0)
            {
                MessageBox.Show("读取始发站号错误！");
                info = "读取始发站号错误！";
                //return false;
            }
            startstationid = int.Parse(sStartSpotNum);
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
            int nStartSpotNum = 0;
            try
            {
                nStartSpotNum = int.Parse(sStartSpotNum);
            }
            catch
            {
                MessageBox.Show("卡中的始发站号有误！");
                info = "卡中的始发站号有误！";
                return false;
            }
            sEndTime = System.DateTime.Now.ToString("yy-MM-dd,HH:mm");
            string sEndTime2 = System.DateTime.Now.ToString("yyMMddHHmm");
            sEndTime2 = sEndTime2.Substring(0, 10);
            if (PutDataIntoCardHex(3, 10, 4, sEndTime2) != 0)
            {
                MessageBox.Show("写卡失败！");
                info = "写卡失败！";
                return false;
            }
            if (PutDataIntoCard(3, 13, 1, MISSION_FINISH) != 0)
            {
                MessageBox.Show("写卡失败！");
                info = "写卡失败！";
                return false;
            }

            //this.GoodsTableAdaper.UpdateQueryByTime(2, double.Parse(textBox1.Text), sStartTime, nStartSpotNum);
            st = sStartTime;
            ss = nStartSpotNum;

            info = "车号：" + sCarNum + ";      " + "发车时间：" + sStartTime + ";      " + "到达时间：" + sEndTime + ";      " + "重量：" + weight + ";      " + "始发站：" + StationName[nStartSpotNum - 31] + ".";


            //listBox1.Items.Add("始发站：" + StationName[nStartSpotNum - 30] + ";      " + "发车时间：" + sStartTime + ";      " + "车号：" + sCarNum + ".");
            //MessageBox.Show(sInfoR);
            //MessageBox.Show(sCarNum);
            //MessageBox.Show(sStartTime);
            //MessageBox.Show(sStartSpotNum);
            return true;

        }

        #region 有关读卡.

        #region 寻卡, 并获得卡片Tag ID
        /// <summary>
        /// 寻找并锁定卡片，同时获得卡片Tag ID
        /// </summary>
        /// <param name="CardID">CardID:[OUT]所读卡片的Tag ID</param>
        /// <returns>
        /// 0：成功返回
        /// -1：未连接读卡器
        /// </returns>
        public static int Request(ref string CardID, ref int count)
        {


            int m_antenna_sel = 1;
            int status = -1;


            int nCounter = 0, ID_len = 0, ID_len_temp = 0;
            string str = "", strtemp = "";

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];
            byte[] AccessPassWord = new byte[4];

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
                    if (status == OK)
                        break;
                    m_antenna_sel = m_antenna_sel * 2;

                    Sleep(20);
                }
                if (status != OK)
                {
                    //MessageBox.Show("读卡器天线出现问题，请重试！\n若仍然有问题，请联系生产厂家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                //MessageBox.Show("天线成功！");

                //读取G2卡ID
                Array.Clear(TagBuffer, 0, TagBuffer.Length);

                status = Net_EPC1G2_ReadLabelID(m_hScanner, 1, 0, 0, mask, IDBuffer, ref nCounter);

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
                //取ID Buffer中第一个ID，若有多个ID，则只保留第一个，忽略其余
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
                count = nCounter;
                //MessageBox.Show(CardID);
                /*************************************
                  ************************************/
                //返回卡ID，取EPC数据块的前6位字符
                if (CardID.Length > 6)
                    CardID = CardID.Substring(0, 6);
                //************************************/

                break;//*/
            }

            return 0;
        }
        public int Request(ref string CardID)
        {


            int m_antenna_sel = 1;
            int status = -1;


            int nCounter = 0, ID_len = 0, ID_len_temp = 0;
            string str = "", strtemp = "";

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];
            byte[] AccessPassWord = new byte[4];

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
                    if (status == OK)
                        break;
                    m_antenna_sel = m_antenna_sel * 2;

                    Sleep(20);
                }
                if (status != OK)
                {
                    //MessageBox.Show("读卡器天线出现问题，请重试！\n若仍然有问题，请联系生产厂家！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                //MessageBox.Show("天线成功！");

                //读取G2卡ID
                Array.Clear(TagBuffer, 0, TagBuffer.Length);

                status = Net_EPC1G2_ReadLabelID(m_hScanner, 1, 0, 0, mask, IDBuffer, ref nCounter);

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
                //取ID Buffer中第一个ID，若有多个ID，则只保留第一个，忽略其余
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
                //返回卡ID，取EPC数据块的前6位字符
                if (CardID.Length > 6)
                    CardID = CardID.Substring(0, 6);
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
                    default:
                        MessageBox.Show("出现了位置问题！\n错误代码：" + status.ToString(), "出问题啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return -1;
            }

            return 0;
        }
        #endregion
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
        public static int PutDataIntoCard(int block, int n_ptr, int n_len, string PutString)
        {


            int m_antenna_sel = 1;
            int status = -1;

            //string str = "", strtemp = "";
            string str = "";

            byte EPC_BYTE = 0x00;

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];
            mask = System.Text.Encoding.Default.GetBytes(PutString);

            byte[] AccessPassword = new byte[4];

            string str_temp = "00000000";           // 读取密码
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
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
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
                    status = Net_EPC1G2_WriteWordBlock(m_hScanner, EPC_BYTE, IDTemp, 3, ptr, len, mask, AccessPassword);
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
        public static int PutDataIntoCardHex(int block, int n_ptr, int n_len, string PutString)
        {


            int m_antenna_sel = 1;
            int status = -1;

            //string str = "", strtemp = "";
            string str = "";

            byte EPC_BYTE = 0x00;

            byte[] DB = new byte[128];
            byte[] IDBuffer = new byte[7680];
            byte[] mask = new byte[96];
            //mask = System.Text.Encoding.Default.GetBytes(PutString);
            mask = ToDigitsBytes(PutString);

            byte[] AccessPassword = new byte[4];

            string str_temp = "00000000";           // 读取密码
            for (int i = 0; i < 4; i++)
            {
                AccessPassword[i] = Convert.ToByte(str_temp[i * 2] + str_temp[i * 2 + 1]);
            }

            EPC_BYTE = Convert.ToByte("6");            //目前认为ID是6位
            byte ptr = Convert.ToByte(n_ptr);          //准备读的首地址是n_ptr
            byte len = Convert.ToByte(n_len);          //准备读的长度是n_len

            for (int n = 0; n < 150; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
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

                    Sleep(50);
                    status = Net_EPC1G2_WriteWordBlock(m_hScanner, EPC_BYTE, IDTemp, 3, ptr, len, mask, AccessPassword);
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
        //public int write(string input, int ptr,int len)
        //{

        //}
        //public int write2(string intput, int ptr,int len)
        //{

        //}
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
        /// </returns>

        public int GetCardID(int CardClass, ref string CardID)
        {
            int status;
            int CardClassCoincidence;
            string Pc_str_CardID = "";

            status = Request(ref Pc_str_CardID);

            if (-1 == status)
            {
                //MessageBox.Show("请注意！尚未连接到读卡器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
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

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
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


                status = Net_EPC1G2_ReadWordBlock(m_hScanner, EPC_BYTE, IDTemp, Convert.ToByte(3), ptr, len, DB, AccessPassword);
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

        public static int ReadString(int ptr, int len, ref string TruckNo)
        {
            string Pc_str_TruckNo = "";


            int m_antenna_sel = 1;
            int status = -1;

            byte EPC_BYTE = 0x00;
            // byte ptr = 0x00;        //读取起始地址
            //byte len = 0x00;        //读取的长度

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
            // ptr = Convert.ToByte("1");          //准备读的首地址是0
            //  len = Convert.ToByte("5");          //准备读的长度是5

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
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


                status = Net_EPC1G2_ReadWordBlock(m_hScanner, EPC_BYTE, IDTemp, Convert.ToByte(3), Convert.ToByte(ptr), Convert.ToByte(len), DB, AccessPassword);
                if (status == OK)
                    break;

                Sleep(20);
            }

            Pc_str_TruckNo = System.Text.Encoding.Default.GetString(DB, 0, len * 2);     //准备读的长度是5

            //MessageBox.Show(Pc_str_TruckNo, "司机编号", MessageBoxButtons.OK, MessageBoxIcon.Information);  //测试用

            TruckNo = Pc_str_TruckNo.Trim();

            return 0;
        }//*/
        public static int ReadStringHex(int ptr, int len, ref string TruckNo)
        {
            string Pc_str_TruckNo = "";


            int m_antenna_sel = 1;
            int status = -1;

            byte EPC_BYTE = 0x00;
            // byte ptr = 0x00;        //读取起始地址
            //byte len = 0x00;        //读取的长度

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
            // ptr = Convert.ToByte("1");          //准备读的首地址是0
            //  len = Convert.ToByte("5");          //准备读的长度是5

            for (int n = 0; n < 50; n++)
            {
                //设置天线
                for (int i = 0; i < 4; i++)
                {
                    status = Net_SetAntenna(m_hScanner, m_antenna_sel);
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


                status = Net_EPC1G2_ReadWordBlock(m_hScanner, EPC_BYTE, IDTemp, Convert.ToByte(3), Convert.ToByte(ptr), Convert.ToByte(len), DB, AccessPassword);
                if (status == OK)
                    break;

                Sleep(20);
            }

            Pc_str_TruckNo = ToHexString(DB);     //准备读的长度是5

            //MessageBox.Show(Pc_str_TruckNo, "司机编号", MessageBoxButtons.OK, MessageBoxIcon.Information);  //测试用

            TruckNo = Pc_str_TruckNo.Trim();

            return 0;
        }//*/
        #endregion

        #endregion

        #region 公共函数

        public static string decodetime(string ortime)
        {
            string newtime = "";
            newtime = ortime.Substring(0, 2) + "-" + ortime.Substring(2, 2) + "-" + ortime.Substring(4, 2) + "," + ortime.Substring(6, 2) + ":" + ortime.Substring(8, 2);
            return newtime;
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
        public bool setSecKey(string key)
        {
            if (key.Length == 12)
            {
                sKey = key;
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
        public string DoubletoString(double a)//把小于10的数字转化为 a.bc-》abc 的字符串格式 a.b->ab0 a->a00
        {
            string b = "";
            if (a.ToString().Length > 4)
            {
                MessageBox.Show("a");
                b = a.ToString().Substring(0, 4);
            }
            if (a.ToString().Length == 4)
            {
                MessageBox.Show("b");
                b = a.ToString();
            }
            if (a.ToString().Length < 4 && a.ToString().Length > 1)
            {
                MessageBox.Show("c");
                b = a.ToString();
                for (int i = 1; i <= 4 - a.ToString().Length; i++)
                    b += "0";
            }
            if (a.ToString().Length == 1)
            {
                MessageBox.Show("d");
                b = a.ToString() + ".00";
            }
            b = b.Replace(".", "");
            return b;

        }
        #endregion


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

        #endregion

        #region 网络API

        [DllImport("NETUHF.dll")]
        //连接读写器
        public static extern int Net_ConnectScanner(ref int hSocket, char[] nTargetAddress, uint nTargetPort, char[] nHostAddress, uint nHostPort);
        [DllImport("NETUHF.dll")]
        //断开连接
        public static extern int Net_DisconnectScanner(int hSocket);

        //==============================设备控制命令==============================
        //设置波特率
        [DllImport("NETUHF.dll")]
        public static extern int Net_SetBaudRate(int hSocket, int nBaudRate);
        [DllImport("NETUHF.dll")]
        //读取版本号
        //        public static extern int Net_GetReaderVersion(int hSocket, WORD *wHardVer, WORD  *wSoftVer);

        //设定输出功率
        public static extern int Net_SetOutputPower(int hSocket, int nPower);
        [DllImport("NETUHF.dll")]
        //设定工作频率
        public static extern int Net_SetFrequency(int hSocket, int Min_Frequency, int Max_Frequency);
        [DllImport("NETUHF.dll")]
        //读取写器工作参数
        public static extern int Net_ReadParam(int hSocket, ref Parameter pParam);
        [DllImport("NETUHF.dll")]
        //设置调制度
        public static extern int Net_SetModDepth(int hSocket, int ModDepth);
        [DllImport("NETUHF.dll")]
        //获得调制度
        public static extern int Net_GetModDepth(int hSocket, ref int ModDepth);
        [DllImport("NETUHF.dll")]
        //设置读写器工作参数
        public static extern int Net_WriteParam(int hSocket, ref Parameter pParam);
        [DllImport("NETUHF.dll")]
        //选择天线
        public static extern int Net_SetAntenna(int hSocket, int Antenna);
        [DllImport("NETUHF.dll")]
        //设置读写器出厂参数
        public static extern int Net_WriteFactoryParameter(int hSocket, ref Parameter pParam);
        [DllImport("NETUHF.dll")]
        //读取读写器出厂参数
        public static extern int Net_ReadFactoryParameter(int hSocket);
        [DllImport("NETUHF.dll")]
        //复位读写器
        public static extern int Net_Reboot(int hSocket);

        //设置时间
        //public static extern int Net_SetReaderTime(int hSocket, ReaderDate time);

        //获得时间
        //public static extern int Net_GetReaderTime(int hSocket, ReaderDate *time);

        //==============================网络命令==============================
        //设置读写器IP地址
        [DllImport("NETUHF.dll")]
        public static extern int Net_SetReaderNetwork(int hSocket, byte[] IP_Address, int Port, byte[] Mask, byte[] Gateway);
        [DllImport("NETUHF.dll")]
        //获得读写器IP地址
        public static extern int Net_GetReaderNetwork(int hSocket, byte[] IP_Address, ref int Port, byte[] Mask, byte[] Gateway);
        [DllImport("NETUHF.dll")]
        //设置读写器MAC地址
        public static extern int Net_SetReaderMAC(int hSocket, byte[] MAC);
        [DllImport("NETUHF.dll")]
        //获得读写器MAC地址
        public static extern int Net_GetReaderMAC(int hSocket, byte[] MAC);
        //==============================IO命令==============================
        [DllImport("NETUHF.dll")]
        //设置读写器继电器状态
        public static extern int Net_SetRelay(int hSocket, int relay);
        [DllImport("NETUHF.dll")]
        //获得读写器继电器状态
        public static extern int Net_GetRelay(int hSocket, ref int relay);

        //==============================EPC C1G2数据读写命令==============================
        [DllImport("NETUHF.dll")]
        //读取EPC1G2标签ID号
        public static extern int Net_EPC1G2_ReadLabelID(int hSocket, byte mem, int ptr, byte len, byte[] mask, byte[] IDBuffer, ref int nCounter);
        [DllImport("NETUHF.dll")]
        //读一块数据
        public static extern int Net_EPC1G2_ReadWordBlock(int hSocket, byte EPC_WORD, byte[] IDBuffer, byte mem, byte ptr, byte len, byte[] Data, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //写一块数据
        public static extern int Net_EPC1G2_WriteWordBlock(int hSocket, byte EPC_WORD, byte[] IDBuffer, byte mem, byte ptr, byte len, byte[] Data, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //设置读写保护状态
        public static extern int Net_EPC1G2_SetLock(int hSocket, byte EPC_WORD, byte[] IDBuffer, byte mem, byte Lock, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //擦除标签数据
        public static extern int Net_EPC1G2_EraseBlock(int hSocket, byte EPC_WORD, byte[] IDBuffer, byte mem, byte ptr, byte len);
        [DllImport("NETUHF.dll")]
        //写EPC
        public static extern int Net_EPC1G2_WriteEPC(int hSocket, byte len, byte[] Data, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //块锁命令
        public static extern int Net_EPC1G2_BlockLock(int hSocket, byte EPC_WORD, byte[] IDBuffer, byte ptr, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //EAS状态操作命令
        public static extern int Net_EPC1G2_ChangeEas(int hSocket, byte EPC_WORD, byte[] IDBuffer, byte State, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //EAS报警命令
        public static extern int Net_EPC1G2_EasAlarm(int hSocket);
        [DllImport("NETUHF.dll")]
        //读保护设置
        public static extern int Net_EPC1G2_ReadProtect(int hSocket, byte[] AccessPassword, byte EPC_WORD, byte[] IDBuffer);
        [DllImport("NETUHF.dll")]
        //复位读保护设置
        public static extern int Net_EPC1G2_RStreadProtect(int hSocket, byte[] AccessPassword);
        [DllImport("NETUHF.dll")]
        //侦测标签
        public static extern int Net_EPC1G2_DetectTag(int hSocket);


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

        [DllImport("kernel32.dll")]
        public static extern void Sleep(int dwMilliseconds);

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





    }
}
