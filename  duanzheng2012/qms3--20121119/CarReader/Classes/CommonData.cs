using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace CarReader.Classes
{
    public class CommonData
    {
        static public Label errorLabel = null;
        static public string stationID = "0";
        static public string stationName = "";
        public static DataTable stations;
        static public List<CarControl> datas = new List<CarControl>();
        static public BaseOperate op = new BaseOperate();
        static public List<CarData> updatingdatas = new List<CarData>();

        static public AxXDVIEWLib.AxXDView xdview;
        static public GroupBox groupCard;
        static public GroupBox groupWeight;
        static public int sec = 0;
        static public int min = 0;
    }
}
