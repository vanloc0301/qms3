using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CarReader.Classes
{
    public class LogWriter
    {
        static string logPath = "C:\\Log\\";

        public static void WriteLog(string log)
        {
            File.AppendAllText(logPath +"StationManagerEx"+ DateTime.Now.ToString("yyyyMMdd") + ".txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss\t") + log+"\r\n");
        }
    }
}
