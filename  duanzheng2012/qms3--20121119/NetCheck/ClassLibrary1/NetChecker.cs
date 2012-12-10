using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
namespace NetCheck
{
    public class StatusChecker
    {
        const string filepath = "NetConfig.ini";
        #region nouse
        // static string CameraIP ="";
        //static string PDAName = "";
        //public static bool Internet=false;
        //public static bool Camera = false;
        //public static bool PDA = false;
        //public static void checkit()
        //{
        //    try
        //    {
        //        StreamReader objReader = new StreamReader(filepath);
        //        string ip = objReader.ReadLine();
        //        CameraIP = objReader.ReadLine();
        //        PDAName = objReader.ReadLine();
        //        objReader.Close();
        //        Thread td = new Thread(dowork);
        //        td.Start();
        //    }
        //    catch
        //    {
        //        Internet=false;
        //        Camera = false;
        //        PDA = false;
        //    }
        //}
        //public static void dowork()
        //{
        //    CheckInternet();
        //    CheckConnection(CameraIP);
        //    CheckPDA(PDAName);
        //}
        #endregion
        public static bool CheckInternet()
        {
            try
            {
                StreamReader objReader = new StreamReader(filepath);
                string ip = objReader.ReadLine();
                objReader.Close();

                Ping pingSender = new Ping();
                bool b = false;
                for (int i = 0; i < 5; i++)
                {
                    PingReply reply = pingSender.Send("www.baidu.com");
                    if (reply.Status == IPStatus.Success)
                    {
                        // Internet = true;
                        return true;


                    }
                    else
                    {
                        if (reply.Status == IPStatus.Success)
                        {
                            // Internet = true;
                            return true;


                        }
                        else
                        {
                            //   Internet = false;
                            b = false;
                        }
                        //   Internet = false;
                        //   return false;
                    }
                }
                return false;
            }
            catch
            {
                //  Internet = false;
                return false;
            }
        }

        public static bool CheckConnection(string ip)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip);
                if (reply.Status == IPStatus.Success)
                {
                  //  Camera = true;
                    return true;
                }
                else
                {
                  //  Camera = false;
                    return false;
                }
            }
            catch 
            {
              //  Camera = false;
                return false;
            }
        }

        public static bool CheckPDA(string station)
        {
            try
            {
                WebClient wc = new WebClient();
                string url = "http://180.186.12.183/log/" + System.DateTime.Now.Year+"-";
                if (System.DateTime.Now.Month < 10)
                    url += "0";
                url += System.DateTime.Now.Month+"-";

                if (System.DateTime.Now.Day < 10)
                    url += "0";
                url += System.DateTime.Now.Day+".txt";


                string dump = wc.DownloadString(url);
                if (dump.Contains(station))
                {
                  //  PDA = true;
                    return true;
                }
                else
                {
                 //   PDA = false;
                    return false;
                }
            }
            catch 
            {
               // PDA = false;
                return false;
            }
        }
    }
}
