using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace NetCheckerWin
{
    class Tenda
    {
        static string sUser = "admin";
        static string sPwd="admin";
        static string sDomain = "";
        static System.Threading.Thread th = new System.Threading.Thread(dowork);
        public static void dowork()
        {
            NetworkCredential Cr;
            Cr = new NetworkCredential(sUser, sPwd, sDomain);
            WebClient wc = new WebClient();
            wc.Credentials = Cr;
            try
            {
                wc.DownloadString("http://192.168.0.1/goform/SysToolReboot");
            }
            catch { }

        }
        public static void reboot()
        {
            if (!th.IsAlive)
            {
                th = new System.Threading.Thread(dowork);
                th.Start();
            }
        }

    }
}
