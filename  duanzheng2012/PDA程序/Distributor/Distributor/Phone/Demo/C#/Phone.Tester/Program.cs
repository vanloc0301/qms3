using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace SEUIC.Phone.Tester
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
//             LocalStorage lds = new LocalStorage();
//             lds.Run();
            Application.Run(new MainFrm());
        }
    }
}