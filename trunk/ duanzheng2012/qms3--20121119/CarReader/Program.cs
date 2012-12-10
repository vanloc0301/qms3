using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text;

namespace CarReader
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new MainWindow());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            FileStream fs = new FileStream("Exception/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".log", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine(e.Exception.Message + "\n" + e.Exception.StackTrace);
            sw.Close();
            fs.Close();

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            FileStream fs = new FileStream("Exception/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".log", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine(((Exception)e.ExceptionObject).Message + "\n" + ((Exception)e.ExceptionObject).StackTrace);
            sw.Close();
            fs.Close();
        }
    }
}
