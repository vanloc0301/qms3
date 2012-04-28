using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DTQMS3New.Classes
{
    public class CommonData
    {
        public static int stationID = 1;                    //本站ID
        public static string stationName = "大屯";          //本站名称
        public static int sumTime = 0;                      //车次计数
        public static double sumWeight = 0;                 //运输总吨量
        public static int curUpdateIndex = -1;              //当前正在更新的数据下标
        public static List<Task> data = new List<Task>();   //所有刷卡数据集合
        public static DataTable stations;
        public static Label errorLabel;

        public static void resetData()
        {
            sumTime = 0;
            sumWeight = 0;
            curUpdateIndex = -1;
            data.Clear();
        }

        public static DataTable toDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TruckNo",Type.GetType("System.String"));
            dataTable.Columns.Add("StartTime",Type.GetType("System.String"));
            dataTable.Columns.Add("EndTime",Type.GetType("System.String"));
            dataTable.Columns.Add("StartStation",Type.GetType("System.String"));
            dataTable.Columns.Add("Type", Type.GetType("System.Int32"));

            for (int i = data.Count - 1; i <= 0;i++ )
            {
                Task item = data[i];
                DataRow row = dataTable.NewRow();
                row["TruckNo"] = item.CarNum;
                row["StartTime"] = item.StartTime;
                row["EndTime"] = item.EndTime;
                row["StartStation"] = stations.GetValueByKey("StationID", item.StartSpot, "Name");
                row["Type"] = item.Type;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
