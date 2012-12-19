using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarReader.Classes;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Data.OleDb;

namespace CarReader
{
    public partial class CarControl : UserControl
    {
        public CarData data;
        private bool isDown = false;                                            //标志是否已超出下行的时间限制(1分钟)
        private System.Timers.Timer tmrDown;
        private System.Timers.Timer tmrTimeOut;
        private System.Timers.Timer tmrDownOut;
        private int state = 0;
        private bool bIsDowned = false;
        public CarControl()
        {
            InitializeComponent();
            CarControl_Load(null, null);
        }
        

        //反序列化文件
        public void LoadDataByFile(FileStream fs)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(CarData));
            data = (CarData)formatter.Deserialize(fs);
        }
        //序列化文件
        public void  SaveFile(string sql1)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Windows\\System32\\data\\data.mdb;");
                cn.Open();
                string sql = "Insert into [data](boxid,truckNo,starttime,startstationid,type,endstationid,endtime,weight,picPath,allWeight,downWeight,downTime,upList,downList) Values('" + data.boxid + "','" + data.truckNo + "','" + data.startTime + "'," +
                    data.stationID + "," + data.type + "," + CommonData.stationID + ",'" + data.endTime + "'," +
                    (data.allWeight - data.carWeight) + ",'" + data.picPath + "'," + data.allWeight + "," + data.carWeight + ",'" +
                    data.downTime + "','" + data.uplist + "','" + data.downlist + "')";
                OleDbCommand cmd = new OleDbCommand(sql, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            { }
        }


        //判断是否为该卡 如果为该卡则执行操作返回true，否则返回false
        public bool isMyCar(CarData car)
        {
            //如果为该卡
            if (data == null)
                Thread.Sleep(1);
            if (car.truckNo == data.truckNo && car.startTime == data.startTime)
            {
                if (bIsDowned)
                    return true;
                //下行
                if (isDown)
                {
                    bIsDowned = true;
                    new Thread(CarDown).Start();
                    
                }
                //上行
                else
                {
                    //isDown = true;
                    tmrDown.Stop();
                    tmrDown.Start();
                    tmrTimeOut.Stop();
                    tmrTimeOut.Start();
                    
                }
                return true;
            }
            return false;
        }

        public void CarControl_Load(object sender, EventArgs e)
        {
            tmrDown = new System.Timers.Timer(1000 * 10 * 3);
            tmrTimeOut = new System.Timers.Timer(1000 * 60 * 60);
            tmrDown.Elapsed += tmrDown_Tick;
            tmrTimeOut.Elapsed += tmrTimeOut_Tick;
            tmrDownOut = new System.Timers.Timer(4000*60);
            tmrDownOut.Elapsed += tmrDownOut_Tick;
            tmrDown.Start();
            //tmrDownOut.Stop();
            tmrTimeOut.Start();
        }
        
        //根据控件名获取控件
        private Control GetControlByName(Control pc, string cName)
        {
            foreach (Control item in pc.Controls)
            {
                if (item.Name == cName)
                {
                    return item;
                }
            }
            return null;
        }


        //超出下行限制操作
        private void tmrDown_Tick(object sender, EventArgs e)
        {
            tmrDown.Stop();
            isDown =  true;
        }

        //超时操作
        private void tmrTimeOut_Tick(object sender, EventArgs e)
        {
            state += 3;
            this.SaveData();
        }

        //拍照方法 n
        private string GetPic()
        {
            CommonData.xdview.ChannelCapture(0);
            string path = CommonData.xdview.CaptureChannel(0);
            string npath = "c:/xdnvs/pic/" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".JPG";
            if (path == null || path.Length <= 0)
                return null;
            Bitmap bm = new Bitmap(path);
            bm.Save(npath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return npath;
        }

        private delegate void DelUpdateUI(int i);

        //刷到上行卡时的操作
        public void CarUp(object car)
        {
            try     
            {
                //获取站名
                ((CarData)car).stationName = CommonData.stations.GetValueByKey("StationID", (((CarData)car).stationID), "Name").ToString();
                //保存信息
                data = (CarData)car;
                //延迟三秒
                GetStableWeight.tag = 1;
                Thread.Sleep(5*1000);
                
                int s = 0;
                //称重
                lock (GetStableWeightUp.myarray)
                {
		    data.allWeight = GetStableWeightUp.getstable(ref s);
                    foreach (double item in GetStableWeightUp.myarray)
                    {
                        data.uplist += item + ",";
                    }
                }
                GetStableWeight.tag = 0;
                state = s * 100;
                //拍照
                data.picPath = GetPic(); 
                //
                DelUpdateUI d = new DelUpdateUI(UpdateUI);
                this.Invoke(d,1);
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream("error.log", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(ex.Message);
                sw.Close();
                fs.Close();
            }
        }
        //刷到下行卡时的操作
        public void CarDown()
        {
            int s = 0;
            data.downTime = DateTime.Now.ToString("yy-MM-dd,HH:mm");
            //延迟3秒
            GetStableWeight.tag = 1;
            Thread.Sleep(3000);
            
            //读取重量
	    lock (GetStableWeight.myarray)
            {
            	data.carWeight = GetStableWeight.getstable(ref s);
            
                foreach (double item in GetStableWeight.myarray)
                {
                    data.downlist += item + ",";
                }
            }
            GetStableWeight.tag = 0;
            if (s != 0)
                state += s%10;
            //更新界面
            DelUpdateUI d = new DelUpdateUI(UpdateUI);
            this.Invoke(d,0);
            //保存数据
            SaveData();
        }


        //更新界面
        public void UpdateUI(int n)
        {
            ((Label)GetControlByName(CommonData.groupCard, "lblStartTime")).Text = data.startTime;
            ((Label)GetControlByName(CommonData.groupCard, "lblStartStation")).Text = data.stationName;
            ((Label)GetControlByName(CommonData.groupCard, "lblTruck")).Text = data.truckNo;
            //((Label)GetControlByName(CommonData.groupCard, "lblType")).Text = data.type.ToString();
            switch (data.type)
            { 
                case 0:
                    ((Label)GetControlByName(CommonData.groupCard, "lblType")).Text = "其他";
                    break;
                case 1:
                    ((Label)GetControlByName(CommonData.groupCard, "lblType")).Text = "厨余垃圾";
                    break;
                case 2:
                    ((Label)GetControlByName(CommonData.groupCard, "lblType")).Text = "餐厨垃圾";
                    break;
                case 3:
                    ((Label)GetControlByName(CommonData.groupCard, "lblType")).Text = "可回收垃圾";
                    break;
                case -1:
                    ((Label)GetControlByName(CommonData.groupCard, "lblType")).Text = "类型错误";
                    break;
            }
            ((Label)GetControlByName(CommonData.groupCard, "lblEndTime")).Text = data.endTime;
            ((Label)GetControlByName(CommonData.groupCard, "label9")).Text = data.allWeight.ToString();
            ((Label)GetControlByName(CommonData.groupCard, "label13")).Text = data.carWeight.ToString();
            ((Label)GetControlByName(CommonData.groupCard, "label11")).Text = (data.allWeight - data.carWeight).ToString();
            if (n == 1)
            {
                ((Label)GetControlByName(CommonData.groupCard, "label13")).Text = "NA";
                ((Label)GetControlByName(CommonData.groupCard, "label11")).Text = "NA";
            }
        }

        //保存文件
        public void SaveData()
        {
            string sql = "EXEC center_updatedata '"+data.boxid+"','"
                +data.truckNo+"','"+data.parseData(1)+"',"
                +data.stationID+","+data.type+","+CommonData.stationID+",'"+data.parseData(0)
                +"',"+(data.allWeight-data.carWeight)+",'"
                +data.picPath+"',@status="+this.state+",@allWeight="
                +this.data.allWeight+",@downWeight="+this.data.carWeight.ToString("##.##")+",@downTime='"
                +data.downTime+"',@uplist='"+data.uplist+"',@downlist='"+data.downlist+"'";
            BaseOperate op = new BaseOperate();
            if (op.getcom(sql) == false)
            {
                this.SaveFile(sql);

            }
            if (tmrDownOut == null)
            {
                CommonData.datas.Remove(this);
                this.Dispose();
                return;
            }
            tmrDownOut.Start();
        }
        private void tmrDownOut_Tick(object sender, EventArgs e)
        {
            tmrDownOut.Stop();
            CommonData.datas.Remove(this);
            this.Dispose();
        }
    }
}
