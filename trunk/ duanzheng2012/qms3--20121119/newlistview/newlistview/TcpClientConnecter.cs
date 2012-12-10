using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using newlistview;

namespace InfoView.Classes
{
    public class TimeOutSocket
    {
        public static int count = 0;
        public static List<StationState> stationList = new List<StationState>();
        public static List<StationState> centerList = new List<StationState>();
        private static bool IsConnectionSuccessful = false;
        private static Exception socketexception;
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public static void ConnectTest()
        {
            //初始化全部清运站
            try
            {
                string sql = "Select name from [dbo.Station] where stationid > 29";
                BaseOperate op = new BaseOperate();
                DataTable stations = op.getds(sql, "[dbo.Station]").Tables[0];
                for (int i = 0; i < stations.Rows.Count; i++)
                {
                    StationState ss = new StationState();
                    ss.name = stations.Rows[i][0].ToString().Replace(" ", "");
                    stationList.Add(ss);
                }
            }
            catch { }
            while (true)
            {
                //清运站
                WebClient wc = new WebClient();
                StreamReader sr = new StreamReader("stationList.ini", Encoding.Default);
                try
                {
                    wc.DownloadFile("http://180.186.12.183/log/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                }
                catch { }
                while (sr.Peek() >= 0)
                {
                    string[] l = sr.ReadLine().Split(' ');
                    StationState stationState = null;
                    foreach (StationState item in stationList)
                    {
                        if (item.name == l[1].Replace(" ", ""))
                        {
                            stationState = item;
                            stationState.url = l[0];

                            break;
                        }
                    }
                    if (stationState == null)
                    {
                        stationState = new StationState();
                        stationState.url = l[0];
                        stationList.Add(stationState);
                    }
                    stationState.view = false;
                    stationState.pda = false;
                    stationState.web = false;
                    for (int i = 0; i < 3; i++)
                    {
                        //Thread.Sleep(100);
                        if (TryConnect(stationState.url, 5000, 5000))
                        {
                            stationState.view = true;
                            break;
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        //Thread.Sleep(100);
                        if (TryConnect(stationState.url, 3389, 5000))
                        {
                            stationState.web = true;
                            break;
                        }
                    }
                    //读取PDA状态

                    
                }
                try
                {
                    StreamReader srPda = new StreamReader(DateTime.Now.ToString("yyyy-MM-dd") + ".txt", Encoding.Default);
                    string allPda = srPda.ReadToEnd();
                    srPda.Close();
                    foreach (StationState sItem in stationList)
                    {
                        if (allPda.Contains(sItem.name))
                            sItem.pda = true;
                    }
                }
                catch (Exception ex) { }
                //转运中心
                sr.Close();
                sr = new StreamReader("centerList.ini", Encoding.Default);
                while (sr.Peek() >= 0)
                {
                    string[] l = sr.ReadLine().Split(' ');
                    StationState stationState = null;
                    foreach (StationState item in centerList)
                    {
                        if (item.name == l[1])
                        {
                            stationState = item;
                            stationState.url = l[0];
                            break;
                        }
                    }
                    if (stationState == null)
                    {
                        stationState = new StationState();
                        stationState.url = l[0];
                        stationState.name = l[1];
                        centerList.Add(stationState);
                    }
                    stationState.view = false;
                    stationState.pda = false;
                    stationState.web = false;
                    //Thread.Sleep(100);
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(100);
                        if (TryConnect(stationState.url, 5000, 5000))
                        {
                            stationState.view = true;

                            break;
                        }
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        //Thread.Sleep(100);
                        if (TryConnect(stationState.url, 3389, 5000))
                        {
                            stationState.web = true;
                            break;
                        }
                    }
                }
                count++;
                sr.Close();
                Thread.Sleep(1800000);
            }
        }
        static Thread thread;
        public static bool TryConnect(string ip, int port, int timeoutMiliSecond)
        {

            thread = new Thread(connect);
            TcpStruct tcp = new TcpStruct();
            tcp.tcp = new TcpClient();
            tcp.port = port;
            tcp.ip = ip;
            thread.Start(tcp);
            thread.Join(2000);
            return tcp.success;
        }
        private static void connect(object tcpStruct)
        {
            TcpStruct tcp = (TcpStruct)tcpStruct;
            tcp.success = false;
            try
            {
                tcp.tcp.Connect(tcp.ip, tcp.port);
                if (tcp.tcp.Connected)
                    tcp.success = true;
                else
                    tcp.success = false;
            }
            catch { tcp.success = false; }
        }
        private class TcpStruct
        {
            public int port;
            public bool success;
            public string ip;
            public TcpClient tcp;
        }
        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                IsConnectionSuccessful = false;
                TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

                if (tcpclient.Client != null)
                {
                    tcpclient.EndConnect(asyncresult);
                    IsConnectionSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                IsConnectionSuccessful = false;
                socketexception = ex;
            }
            finally
            {
                thread.Abort();  
            }
        }
    }

}
