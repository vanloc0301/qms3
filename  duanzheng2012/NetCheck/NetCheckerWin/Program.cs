using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetCheckerWin
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
            if(Properties.Settings.Default.Station)
            Application.Run(new Form1());
            else
            Application.Run(new Form2());
        }
    }
}
