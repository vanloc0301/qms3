using System;

using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.InteropServices;
namespace Distributor
{
    public class Updater
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        static extern byte MapVirtualKey(byte wCode, int wMap);
        private static XmlDocument readXML()//初始化任务列表，或者读取列表
        {
            string Path = "Task.xml";
            XmlDocument task = new XmlDocument();
            try
            {
                task.Load(Path);
                return task;
            }
            catch
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlNode xmlnode = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                // xmlnode.InnerText += "encoding=\"GB2312\"";
                xmldoc.AppendChild(xmlnode);
                XmlElement xmlelem = xmldoc.CreateElement("", "Tasks", "");
                XmlText xmltext = xmldoc.CreateTextNode("");
                xmlelem.AppendChild(xmltext);
                xmldoc.AppendChild(xmlelem);
                xmldoc.Save("Task.xml");
                return xmldoc;
            }
        }
        public static bool isBusy()//判断是否还有任务
        {
            XmlDocument task = readXML();
            XmlNode root = task.SelectSingleNode("Tasks");

            return root.HasChildNodes;

        }
        public static void insertTask(String sBoxCardNum, string sCarNum, string sStartTime, int N_START_SPOT, int type,int dest)//添加任务
        {
            XmlDocument task = readXML();
            XmlNode root = task.SelectSingleNode("Tasks");

            XmlElement xe1 = task.CreateElement("Good");

            XmlElement xBoxCardNum = task.CreateElement("sBoxCardNum");
            xBoxCardNum.InnerText = sBoxCardNum;
            XmlElement xCarNum = task.CreateElement("sCarNum");
            xCarNum.InnerText = sCarNum;
            XmlElement xStartTime = task.CreateElement("sStartTime");
            xStartTime.InnerText = sStartTime;
            XmlElement xStartSpot = task.CreateElement("N_START_SPOT");
            xStartSpot.InnerText = N_START_SPOT.ToString();
            XmlElement xType = task.CreateElement("type");
            xType.InnerText = type.ToString();
            XmlElement xDest = task.CreateElement("sDestination");
            xDest.InnerText = dest.ToString();
            xe1.AppendChild(xBoxCardNum);
            xe1.AppendChild(xCarNum);
            xe1.AppendChild(xStartTime);
            xe1.AppendChild(xStartSpot);
            xe1.AppendChild(xType);

            root.AppendChild(xe1);

            task.Save("Task.xml");

        }
        private static void insertDB(String sBoxCardNum, string sCarNum, string sStartTime, int N_START_SPOT, int type)//添加任务
        {
            string mssqlstring = "EXEC pda_InsertGoods '" +
                        sBoxCardNum + "','" +
                        sCarNum + "','" +
                        sStartTime + "'," +
                //cbxDriverGender.Text + "','" +
                        N_START_SPOT.ToString();

            BaseOperate.getcom(mssqlstring);
            
        }
        public static void doWork()//计划任务
        {
            if (!isBusy())
                return;

            XmlDocument task = readXML();
            XmlNode root = task.SelectSingleNode("Tasks");
            XmlNode xe1 = root.FirstChild;
            XmlNodeList list = xe1.ChildNodes;

            try
            {
                insertDB(
                    list.Item(0).InnerText,
                    list.Item(1).InnerText,
                    list.Item(2).InnerText,
                    int.Parse(list.Item(3).InnerText),
                    int.Parse(list.Item(4).InnerText)
                    );

                root.RemoveChild(xe1);
                task.Save("Task.xml");
            }
            catch { }
            //  return list.Item(0).InnerText + " " + list.Item(1).InnerText;

        }

    }
}
