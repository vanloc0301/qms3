using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CarReader.Classes
{
    [Serializable]
    public class CarData
    {
        

        public string truckNo = "";
        public string startTime = "";
        public int stationID = 0;
        public string stationName = "";
        public double carWeight = 0;
        public double allWeight = 0;
        public string endTime = "";
        public string picPath = "";
        public int isUsed = 0;
        public int type = 0;
        public string boxid = "";
        public string downTime = "";
        public string uplist = "";
        public string downlist = "";

        public void Save()
        {
            string sql = "Update [dbo.Goods] Set EndTime = '"+DateTime.Parse(this.endTime).ToString("yy-MM-dd,HH:mm")+"',Weight="+(this.allWeight-this.carWeight)+",EndStationID="+CommonData.stationID+",picPath='"+this.picPath+"' Where TruckNo = '"+truckNo+"' and StartTime = '"+DateTime.Parse(startTime).ToString("yy-MM-dd,HH:mm")+"' and endtime is null";
            if (DateTime.Parse(startTime) >= DateTime.Parse(endTime))
            {
                sql = "Update [dbo.Goods] Set EndTime = '" + DateTime.Parse(this.endTime).ToString("yy-MM-dd,HH:mm") + "',Weight=" + (this.allWeight - this.carWeight) + ",EndStationID=" + CommonData.stationID + ",picPath='" + this.picPath + "',State=3 Where TruckNo = '" + truckNo + "' and StartTime = '" + DateTime.Parse(startTime).ToString("yy-MM-dd,HH:mm") + "' and endtime is null";
            }
            FileStream fs = new FileStream("sql.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //MessageBox.Show(sql);
            CommonData.op.getcom(sql);
        }

        public string parseData(int n)
        {
            if (n == 1)
                return DateTime.Parse(this.startTime).ToString("yy-MM-dd,HH:mm");
            else
                return DateTime.Parse(this.endTime).ToString("yy-MM-dd,HH:mm");
        }
    }
}

