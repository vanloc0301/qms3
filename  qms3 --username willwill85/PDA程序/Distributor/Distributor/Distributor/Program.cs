using System;

using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
namespace Distributor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            if (SingleInstance.InitRunFlag())
            {
                Application.Run(new Form1());
                SingleInstance.DisposeRunFlag();
            }
            else
            {
                // MessageBox.Show("程序已经运行！");
                Application.Exit();
            } 
        }
        class SingleInstance
        {
            private static string runFlagFullname = null;


            public static bool InitRunFlag()
            {
                if (File.Exists(RunFlag))
                {
                    return false;
                }
                using (FileStream fs = new FileStream(RunFlag, FileMode.Create))
                {
                }
                return true;
            }

            public static void DisposeRunFlag()
            {
                if (File.Exists(RunFlag))
                {
                    File.Delete(RunFlag);
                }
            }

            public static string RunFlag
            {
                get
                {
                    if (runFlagFullname == null)
                    {
                        string assemblyFullName = "abc";
                        string path = "\\User_Storage\\";
                        runFlagFullname = Path.Combine(path, assemblyFullName);
                    }
                    return runFlagFullname;
                }
                set
                {
                    runFlagFullname = value;
                }
            }
        }

    }
}