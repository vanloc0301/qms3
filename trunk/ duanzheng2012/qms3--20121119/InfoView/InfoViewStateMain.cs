using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfoView.Classes;
using System.IO;
using System.Net.Sockets;
using System.Net;
using newlistview;
using System.Threading;

namespace InfoView
{
    public partial class InfoViewStateMain : Form
    {
        int stateCount = 0;
        public DataTable stations;
        public InfoViewStateMain()
        {
            InitializeComponent();
        }

        private void InfoViewStateMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = Screen.AllScreens[MainWindow.locations[3]].WorkingArea.Location;
                this.Size = Screen.AllScreens[MainWindow.locations[3]].WorkingArea.Size;

            }
            catch { }
            try
            {
                string sql = "Select name from [dbo.Station] where stationid > 29";
                InfoView.Classes.BaseOperate op = new InfoView.Classes.BaseOperate();
                stations = op.getds(sql, "[dbo.Station]").Tables[0];
            }
            catch { }
            tmrState_Tick(null, null);

            //
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tmrState_Tick(object sender, EventArgs e)
        {
            if (TimeOutSocket.count == stateCount)
                return;
            stateCount = TimeOutSocket.count;
            int station = 0;
            int stationWeb = 0;                         //垃圾楼网络异常数量
            int stationView = 0;                        //垃圾楼摄像头异常数量
            int center = 0;                              //转运中心总数
            int centerWeb = 0;                           //转运中心网络异常数量
            int centerView = 0;                          //转运中心摄像头异常数量
            int pda = 0;                                 //pda正常台数

            //垃圾楼状态
            for (int i = 0; i < TimeOutSocket.stationList.Count; i++)
            {
                station++;
                if (TimeOutSocket.stationList[i].view)
                    stationView++;
                if (TimeOutSocket.stationList[i].web)
                    stationWeb++;
                if (TimeOutSocket.stationList[i].pda)
                    pda++;
            }
            //转运中心状态
            for (int i = 0; i < TimeOutSocket.centerList.Count; i++)
            {
                center++;
                if (TimeOutSocket.centerList[i].view)
                    centerView++;
                if (TimeOutSocket.centerList[i].web)
                    centerWeb++;
            }

            stationNum.Text = station + "座";
            stationOK.Text = stationWeb + "座";
            this.stationError.Text = (station - stationWeb) + "座";

            sViewNum.Text = station + "台";
            sViewOK.Text = stationView + "台";
            sViewError.Text = (station - stationView) + "台";

            centerNum.Text = center + "座";
            centerOK.Text = centerWeb + "座";
            centerError.Text = (center - centerWeb) + "座";

            cViewNum.Text = center + "台";
            cViewOK.Text = centerView + "台";
            cViewError.Text = (center - centerView) + "台";
            pdaNum.Text = station + "台";
            pdaOK.Text = pda + "台";
            pdaError.Text = (station - pda) + "台";
        }

        private void tmrSetLocation_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Location = Screen.AllScreens[MainWindow.locations[3]].WorkingArea.Location;
                this.Size = Screen.AllScreens[MainWindow.locations[3]].WorkingArea.Size;

            }
            catch { }
        }
    }
}