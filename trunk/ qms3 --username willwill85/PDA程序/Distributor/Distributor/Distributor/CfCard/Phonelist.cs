using System;

using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace Distributor
{
    class phone
    {
        public int id;
        public string name;
        public string phonenum;
        public bool privatephone;

    }
    class phonelist
    {
        public static phone[] myphone;
        public static int index=0;
        public static int count=0;
        public static void getxml()
        {
            string path = "\\User_Storage\\phone.xml";
            count = 0;
            index = 0;
            XmlDocument phonexml = new XmlDocument();
            //  try
            {
                phonexml.Load(path);

                XmlNode xmlroot = phonexml.SelectSingleNode("root");
                myphone = new phone[20];
                foreach (XmlNode phonenode in xmlroot.ChildNodes)
                {
                    myphone[count] = new phone();
                    string id = phonenode.ChildNodes[0].InnerText;
                    myphone[count].id = int.Parse(id);
                    myphone[count].name = phonenode.ChildNodes[1].InnerText;
                    myphone[count].phonenum = phonenode.ChildNodes[2].InnerText;
                    myphone[count].privatephone = bool.Parse(phonenode.ChildNodes[3].InnerText);
                    count++;
                }
            }
            //  catch
            {
                //  MessageBox.Show("phone.xml错误，请检查软件配置");
            }
            
        }
        public static phone nextphone()
        {
            index++;
            if (index >= count)
                index = 0;
            return myphone[index];
        }
        public static phone lastphone()
        {
            index--;
            if (index < 0)
                index = count - 1;
            return myphone[index];
        }
        
    }
}
