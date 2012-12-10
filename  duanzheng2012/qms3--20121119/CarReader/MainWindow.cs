using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarReader.Classes;
using System.IO;
using Org.LLRP.LTK.LLRPV1;
using Org.LLRP.LTK.LLRPV1.DataType;
using System.Xml.Serialization;
using System.Threading;
using System.Data.OleDb;
using System.Diagnostics;

namespace CarReader
{
    public partial class MainWindow : Form
    {
        private CarData ndata;
        public delegate void DelUpWindow();
        public delegate void AddChildDel(CarControl car);
        public delegate void UpWindowLabelDel(Label l,string s);
        LLRPClient reader = new LLRPClient();
        MSG_ERROR_MESSAGE msg_err;
        Thread thread;
        Thread checkCar;
        Thread whileCar;
        BaseOperate operate = new BaseOperate();
        Queue<CarData> carQueue = new Queue<CarData>();
        
        ulong old_time = 0;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            try
            {
                //Thread.CurrentThread.IsBackground = true;
                CommonData.errorLabel = this.lblError;
                String sql = "Select * from [dbo.Station]";
                DataSet ds = operate.getds(sql, "[dbo.Station]");
                if (ds == null || ds.Tables.Count <= 0)

                    CommonData.stations = new DataTable();
                else
                    CommonData.stations = ds.Tables[0];
                //读取转运中心配置文件
                StreamReader sr = new StreamReader("station.cfg");
                CommonData.stationName = sr.ReadLine();
                CommonData.stationID = sr.ReadLine();
                sr.Close();

                //设置摄像头
                sr = new StreamReader("xdview.cfg");
                xdview.URL = sr.ReadLine();
                xdview.Port = short.Parse(sr.ReadLine());
                xdview.UserName = sr.ReadLine();
                xdview.UserPswd = sr.ReadLine();
                sr.Close();

                xdview.ChannelNum = "0";

                xdview.LoginNVS();
                xdview.StartView();
                dgvMsg.AutoGenerateColumns = false;
                updateWindow();
                this.lblStation.Text = CommonData.stationName;

                Process.Start(@"c:\app\NetCheckerWin.exe");
                //读取读卡器配置文件
                sr = new StreamReader("reader.cfg");
                string ip = sr.ReadLine();
                //打开读卡器
                ENUM_ConnectionAttemptStatusType status;
                if (reader.Open(ip, 5000, out status) == false || status != ENUM_ConnectionAttemptStatusType.Success)
                {
                   // System.Environment.Exit(0);
                    Application.Exit();
                }

                

                STOP_ROSPEC(123);

                Delete_RoSpec();
                DELETE_ACCESSSPEC();
                ADD_ACCESSSPEC_READ_M4();
                // ADD_ACCESSSPEC_WRITE_M4();
                //  ADD_ACCESSSPEC_WRITE2();
                ENABLE_ACCESSSPEC();
                Add_RoSpec(123);
                Enable_RoSpec(123);
                Start_RoSpec(123);

                reader.OnRoAccessReportReceived += new delegateRoAccessReport(reader_OnRoAccessReportReceived);
                
                

                
                //timer1.Start();
                

                //启动更新线程
                thread = new Thread(UpdateData);
                thread.Start();
                whileCar = new Thread(WhileCar);
                whileCar.Start();
                //保存对象
                CommonData.xdview = this.xdview;
                CommonData.groupCard = this.groupCard;
                CommonData.groupWeight = this.groupBox1;

                //设置称重机
                comm2.Open();
                comm1.Open();
                //读取配置文件
                sr = new StreamReader("timeout.txt");
                CommonData.sec = int.Parse(sr.ReadLine());
                CommonData.min = int.Parse(sr.ReadLine());
                sr.Close();
            }
            catch(Exception ex)
            {
                try
                {
                    try
                    {
                        comm1.Close();
                    }
                    catch { }
                    try
                    {
                        comm2.Close();
                    }
                    catch { }
                   // FileStream fs = new FileStream("error.log", FileMode.OpenOrCreate);
                   // StreamWriter sw = new StreamWriter(fs);
                   // sw.WriteLine(ex.Message);
                   //// System.Environment.Exit(0);
                   // sw.Close();
                   // fs.Close();
                    //MessageBox.Show(ex.Message);
                    whileCar.Abort();
                    thread.Abort();
                    Application.Exit();
                }
                catch { }

            }
            //timer2.Start();
            
        }

        private void addChild(CarControl l)
        {
            groupList.Controls.Add(l);
        }

        private void WhileCar()
        {
            while (true)
            {
                try
                {
                    if (carQueue.Count <= 0)
                    {
                        continue;
                    }
                    CarData data;
                    lock (carQueue)
                    {
                        data = carQueue.Dequeue();
                    }
                    bool dataStatus = CommonData.datas.GetDataStatus(data);
                    if (!dataStatus)
                    {
                        //添加新卡
                        CarControl car = new CarControl();
                        CommonData.datas.Add(car);
                        AddChildDel de = new AddChildDel(addChild);
                        this.Invoke(de, new object[] { car });
                        Thread t = new Thread(car.CarUp);
                        t.Start(data);
                        DelUpWindow d = new DelUpWindow(updateWindow);
                        this.Invoke(d);
                    }
                }
                catch { }
                
            }
        }

        private void reader_OnRoAccessReportReceived(MSG_RO_ACCESS_REPORT msg)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            //读取卡内容
            CarData data = GetObjectByMsg(msg);
            if (data == null)
                return;
            lock (carQueue)
            {
                carQueue.Enqueue(data);
            }
        }

        //更新窗口
        private void updateWindow()
        {
            try
            {
                //Control.CheckForIllegalCrossThreadCalls = false;
                //string sql = "SELECT * FROM [dbo.Goods] WHERE EndStationID=" + CommonData.stationID + " AND EndTime >= '" + DateTime.Now.ToString("yy-MM-dd,00:00") + "'";
                //double sumWeight = 0;
                //BaseOperate op = new BaseOperate();
                //DataSet ds = op.getds(sql, "[dbo.Goods]");
                //if (ds.Tables.Count <= 0)
                //    return;
                //ds.Tables[0].Columns.Add("StartStationName");
                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                //    row["StartStationName"] = CommonData.stations.GetValueByKey("StationID", row["StartStationID"], "Name");
                //    try
                //    {
                //        sumWeight += double.Parse(row["Weight"].ToString());
                //    }
                //    catch (Exception e) { }
                //}

                //this.dgvMsg.DataSource = ds.Tables[0];
                //this.lblSum.Text = ds.Tables[0].Rows.Count + "次";
                //this.lblSumWeight.Text = sumWeight + "";

                //ChartData chartdata = new ChartData();
                //visifire vschart = new visifire();

                //string str = System.AppDomain.CurrentDomain.BaseDirectory;
                //Uri url = new Uri(str + "chart/Demo.htm");
                //webBrowser.Url = url;

                //chartdata.updateData(5, DateTime.Now, 0).ToString();
                //vschart.reSize(webBrowser.Width, webBrowser.Height);
                //vschart.settitle("当日转运中心报表", "时间", "运输量");
                //string[] column = new string[16];
                //double[] data1 = new double[16];
                //for (int i = 0; i <= 15; i++)
                //{
                //    column[i] = (i + 5).ToString() + ":00";
                //    data1[i] = chartdata.stationdaybox[i];
                //}

                //vschart.set3D(true);
                //vschart.setData(column, data1, 16);
                //string type = "pie";

                //vschart.setType(type);
                //webBrowser.Url = vschart.displayChart();
                bgwUpdate.RunWorkerAsync();
            }
            catch { }
        }

        //遍历文件夹，更新数据
        private void UpdateData()
        {
            while (true)
            {
                Thread.Sleep(1000*60*60);
                try
                {
                    OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\Windows\\System32\\data\\data.mdb;");
                    cn.Open();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [data]", cn);
                    da.Fill(dt);
                    string sqls = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        CarData data = new CarData();
                        data.boxid = row["boxid"].ToString();
                        data.truckNo = row["truckNo"].ToString();
                        data.startTime = row["startTime"].ToString();
                        data.stationID = int.Parse(row["startstationid"].ToString());
                        data.type = int.Parse(row["type"].ToString());
                        data.endTime = row["endTime"].ToString();
                        data.allWeight = double.Parse(row["allWeight"].ToString());
                        data.carWeight = double.Parse(row["downWeight"].ToString());
                        data.downTime = row["downTime"].ToString();
                        data.uplist = row["upList"].ToString();
                        data.downTime = row["downList"].ToString();
                        string sql = "EXEC center_updatedata '" + data.boxid + "','"
                + data.truckNo + "','" + data.parseData(1) + "',"
                + data.stationID + "," + data.type + "," + CommonData.stationID + ",'" + data.parseData(0)
                + "'," + (data.allWeight - data.carWeight) + ",'"
                + data.picPath + "',@status=" + 0 + ",@allWeight="
                + data.allWeight + ",@downWeight=" + data.carWeight + ",@downTime='"
                + data.downTime + "',@uplist='" + data.uplist + "',@downlist='" + data.downlist + "'";
                        BaseOperate op = new BaseOperate();
                        if (!op.getcom(sql))
                            continue;
                        sql = "DELETE FROM [data] WHERE ID = " + int.Parse(row["id"].ToString());
                        OleDbCommand cmd = new OleDbCommand(sql, cn);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    
                }
            }
            
        }

        #region 读卡相关
        private void STOP_ROSPEC(uint id)
        {
            MSG_STOP_ROSPEC msg = new MSG_STOP_ROSPEC();
            msg.ROSpecID = id;

            MSG_STOP_ROSPEC_RESPONSE rsp = reader.STOP_ROSPEC(msg, out msg_err, 2121);
        }

        private void Delete_RoSpec()
        {
                MSG_DELETE_ROSPEC msg = new MSG_DELETE_ROSPEC();
                msg.ROSpecID = 123;

                MSG_DELETE_ROSPEC_RESPONSE rsp = reader.DELETE_ROSPEC(msg, out msg_err, 12000);
        }

        private void DELETE_ACCESSSPEC()
        {
                MSG_DELETE_ACCESSSPEC msg = new MSG_DELETE_ACCESSSPEC();
                msg.AccessSpecID = 0;

                MSG_DELETE_ACCESSSPEC_RESPONSE rsp = reader.DELETE_ACCESSSPEC(msg, out msg_err, 2121);
        }

        private void ADD_ACCESSSPEC_READ_M4()
        {
                MSG_ADD_ACCESSSPEC msg = new MSG_ADD_ACCESSSPEC();
                msg.AccessSpec = new PARAM_AccessSpec();
                msg.AccessSpec.AccessSpecID = 1001;


                //>>> This allows Tag Access to be done from any antenna >>>>>>>>>>>>>>>>>>>>>
                msg.AccessSpec.AntennaID = 0;
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                msg.AccessSpec.ProtocolID = ENUM_AirProtocols.EPCGlobalClass1Gen2;
                msg.AccessSpec.CurrentState = ENUM_AccessSpecState.Disabled;
                msg.AccessSpec.ROSpecID = 123;
                msg.AccessSpec.AccessSpecStopTrigger = new PARAM_AccessSpecStopTrigger();
                msg.AccessSpec.AccessSpecStopTrigger.AccessSpecStopTrigger = ENUM_AccessSpecStopTriggerType.Null;
                msg.AccessSpec.AccessSpecStopTrigger.OperationCountValue = 3;
                msg.AccessSpec.AccessCommand = new PARAM_AccessCommand();
                msg.AccessSpec.AccessCommand.AirProtocolTagSpec = new UNION_AirProtocolTagSpec();

                PARAM_C1G2TagSpec tagSpec = new PARAM_C1G2TagSpec();
                tagSpec.C1G2TargetTag = new PARAM_C1G2TargetTag[1];
                tagSpec.C1G2TargetTag[0] = new PARAM_C1G2TargetTag();
                tagSpec.C1G2TargetTag[0].Match = true; //>change to "true" if you want to the following parameters take effect.
                tagSpec.C1G2TargetTag[0].MB = new TwoBits(1);
                tagSpec.C1G2TargetTag[0].Pointer = 0x20;
                tagSpec.C1G2TargetTag[0].TagData = LLRPBitArray.FromString("6666");
                //                tagSpec.C1G2TargetTag[0].TagMask = LLRPBitArray.FromBinString("0000000000000000");
                tagSpec.C1G2TargetTag[0].TagMask = LLRPBitArray.FromBinString("0000000000000000");
                msg.AccessSpec.AccessCommand.AirProtocolTagSpec.Add(tagSpec);
                //>define access spec
                msg.AccessSpec.AccessCommand.AccessCommandOpSpec = new UNION_AccessCommandOpSpec();
                //			<!-- Read the Serialized number from Monza/ID -->
                PARAM_C1G2Read rd3 = new PARAM_C1G2Read();
                rd3.OpSpecID = 1;
                rd3.AccessPassword = 0;
                rd3.MB = new TwoBits(Convert.ToUInt16("3"));
                rd3.WordPointer = Convert.ToUInt16("0");
                rd3.WordCount = Convert.ToUInt16("11");

                

                /*
                 * EPC = 111122223333444455556666
                 * MB=new TwoBits(1)
                 * WordCount=1
                 * WordPointer=7 yeilds 6666
                 * WordPointer=6 yeilds 5555
                 * WordPointer=5 yeilds 4444
                 * WordPointer=4 yeilds 3333
                 * WordPointer=3 yeilds 2222
                 * WordPointer=2 yeilds 1111
                 */
                //by will//
                PARAM_C1G2Write wr = new PARAM_C1G2Write();

                wr.MB = new TwoBits(Convert.ToUInt16("3"));
                wr.OpSpecID = 111;
                wr.WordPointer = Convert.ToUInt16("10");
                wr.AccessPassword = uint.Parse("000000", System.Globalization.NumberStyles.HexNumber);
                wr.WriteData = UInt16Array.FromHexString("4500");

                //



                msg.AccessSpec.AccessCommand.AccessCommandOpSpec.Add(rd3);
                msg.AccessSpec.AccessCommand.AccessCommandOpSpec.Add(wr);

                msg.AccessSpec.AccessReportSpec = new PARAM_AccessReportSpec();

                msg.AccessSpec.AccessReportSpec.AccessReportTrigger = ENUM_AccessReportTriggerType.Whenever_ROReport_Is_Generated;

                MSG_ADD_ACCESSSPEC_RESPONSE rsp = reader.ADD_ACCESSSPEC(msg, out msg_err, 12000);
        }

        private void ENABLE_ACCESSSPEC()
        {
                MSG_ENABLE_ACCESSSPEC msg = new MSG_ENABLE_ACCESSSPEC();
                msg.AccessSpecID = 1001;

                MSG_ENABLE_ACCESSSPEC_RESPONSE rsp = reader.ENABLE_ACCESSSPEC(msg, out msg_err, 2121);
        }
        private void Add_RoSpec(uint id)
        {
            MSG_ADD_ROSPEC msg = new MSG_ADD_ROSPEC();
            msg.ROSpec = new PARAM_ROSpec();
            msg.ROSpec.CurrentState = ENUM_ROSpecState.Disabled;
            msg.ROSpec.Priority = 0x00;
            msg.ROSpec.ROSpecID = id;

            msg.ROSpec.ROBoundarySpec = new PARAM_ROBoundarySpec();
            msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger = new PARAM_ROSpecStartTrigger();
            msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger.ROSpecStartTriggerType = ENUM_ROSpecStartTriggerType.Immediate;

            //>//>/If you want to use GPI as start trigger

            //>msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger.GPITriggerValue = new PARAM_GPITriggerValue();
            //>msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger.GPITriggerValue.GPIPortNum = 1;
            //>msg.ROSpec.ROBoundarySpec.ROSpecStartTrigger.GPITriggerValue.GPIEvent = true;

            msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger = new PARAM_ROSpecStopTrigger();
            msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.ROSpecStopTriggerType = ENUM_ROSpecStopTriggerType.Null;

            //                msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.DurationTriggerValue = 10000;        //>ten second           
            if (isNumeric("1000", System.Globalization.NumberStyles.Integer))
            {
                msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.DurationTriggerValue = Convert.ToUInt16("1000");        //>ten second           
            }
            else
            {
                MessageBox.Show("Read Duration must be a numeric integer");
                return;
            }


            //--> change this value

            //>//>/If you want to use GPI as stop trigger

            //>msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.ROSpecStopTriggerType = ENUM_ROSpecStopTriggerType.GPI_With_Timeout;
            //>msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.GPITriggerValue = new PARAM_GPITriggerValue();
            //>msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.GPITriggerValue.GPIEvent = false;
            //>msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.GPITriggerValue.GPIPortNum = 1;
            //>msg.ROSpec.ROBoundarySpec.ROSpecStopTrigger.GPITriggerValue.Timeout = 2000;


            //>//>/Enable the following code will replace the parameters set by Set_Reader_Config

            //>msg.ROSpec.ROReportSpec = new PARAM_ROReportSpec();
            //>msg.ROSpec.ROReportSpec.ROReportTrigger = ENUM_ROReportTriggerType.Upon_N_Tags_Or_End_Of_ROSpec;
            //>msg.ROSpec.ROReportSpec.N = 1; //>0 for reporting ro_access_report at once
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector = new PARAM_TagReportContentSelector();
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableAccessSpecID = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableAntennaID = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableChannelIndex = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableFirstSeenTimestamp = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableInventoryParameterSpecID = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableLastSeenTimestamp = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnablePeakRSSI = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableROSpecID = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableSpecIndex = false;
            //>msg.ROSpec.ROReportSpec.TagReportContentSelector.EnableTagSeenCount = false;

            msg.ROSpec.SpecParameter = new UNION_SpecParameter();
            PARAM_AISpec aiSpec = new PARAM_AISpec();

            aiSpec.AntennaIDs = new UInt16Array();

            
            aiSpec.AntennaIDs.Add(0);
            //aiSpec.AntennaIDs.Add(2);



            aiSpec.AISpecStopTrigger = new PARAM_AISpecStopTrigger();
            aiSpec.AISpecStopTrigger.AISpecStopTriggerType = ENUM_AISpecStopTriggerType.Null;

            //>//>/GPI triggered AISpec
            //>aiSpec.AISpecStopTrigger.GPITriggerValue = new PARAM_GPITriggerValue();
            //>aiSpec.AISpecStopTrigger.GPITriggerValue.GPIEvent = false;
            //>aiSpec.AISpecStopTrigger.GPITriggerValue.GPIPortNum = 1;
            //>aiSpec.AISpecStopTrigger.GPITriggerValue.Timeout = 0;
            aiSpec.InventoryParameterSpec = new PARAM_InventoryParameterSpec[1];
            aiSpec.InventoryParameterSpec[0] = new PARAM_InventoryParameterSpec();
            aiSpec.InventoryParameterSpec[0].InventoryParameterSpecID = 1234;
            aiSpec.InventoryParameterSpec[0].ProtocolID = ENUM_AirProtocols.EPCGlobalClass1Gen2;
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>added this to prevent the out of index error when using antennas other than 1
            aiSpec.InventoryParameterSpec[0].AntennaConfiguration = new PARAM_AntennaConfiguration[aiSpec.AntennaIDs.Count];
            for (int x = 0; x < aiSpec.AntennaIDs.Count; x++)
            {
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x] = new PARAM_AntennaConfiguration();
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].AntennaID = aiSpec.AntennaIDs[x];
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFReceiver = new PARAM_RFReceiver();
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter = new PARAM_RFTransmitter();
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFReceiver.ReceiverSensitivity = (ushort)(1); ;
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter.ChannelIndex = 1;
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter.HopTableID = 1;
                aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter.TransmitPower = (ushort)(81); ;
                //aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].AirProtocolInventoryCommandSettings[0] = new PARAM_C1G2InventoryCommand();
                //aiSpec.InventoryParameterSpec[0].AntennaConfiguration[0].AirProtocolInventoryCommandSettings[0];
                //aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFReceiver = new PARAM_RFReceiver();

                //aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter = new PARAM_RFTransmitter();
                //aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter.ChannelIndex = 1;
                //aiSpec.InventoryParameterSpec[0].AntennaConfiguration[x].RFTransmitter.HopTableID = 1;

            }
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            msg.ROSpec.SpecParameter.Add(aiSpec);

            MSG_ADD_ROSPEC_RESPONSE rsp = reader.ADD_ROSPEC(msg, out msg_err, 2121);

        }

        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }
        private void Enable_RoSpec(uint id)
        {
            MSG_ENABLE_ROSPEC msg = new MSG_ENABLE_ROSPEC();
            msg.ROSpecID = id;
            MSG_ENABLE_ROSPEC_RESPONSE rsp = reader.ENABLE_ROSPEC(msg, out msg_err, 12000);

        }

        private void Start_RoSpec(uint id)
        {
            MSG_START_ROSPEC msg = new MSG_START_ROSPEC();
            msg.ROSpecID = id;
            MSG_START_ROSPEC_RESPONSE rsp = reader.START_ROSPEC(msg, out msg_err, 12000);

        }


        private CarData GetObjectByMsg(MSG_RO_ACCESS_REPORT msg)
        {
            if (msg.TagReportData == null || msg.TagReportData.Length < 1) return null ;

            ulong ms = msg.TagReportData[0].FirstSeenTimestampUTC.Microseconds - old_time;
            old_time = msg.TagReportData[0].FirstSeenTimestampUTC.Microseconds;


            if (ms <= 0) ms = 1; //>normalize to 1

            //  lbltagspermin.Text = (60000000 / ms).ToString() + "Tags/Min";




            try
            {
                try
                {
                    //textBox2.Text = msg.ToString();
                    string a = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.ToHexWordString();
                    uint a1 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[0];
                    uint a2 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[1];
                    uint a3 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[2];
                    uint a4 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[3];
                    uint a5 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[4];
                    uint a6 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[5];
                    uint a7 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[6];
                    uint a8 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[7];
                    uint a9 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[8];
                    uint a10 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[9];
                    uint a11 = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.data[10];

                    string epc;
                    if (msg.TagReportData[0].EPCParameter[0].GetType() == typeof(PARAM_EPC_96))
                    {
                        epc = ((PARAM_EPC_96)(msg.TagReportData[0].EPCParameter[0])).EPC.ToHexString();
                        //MessageBox.Show("96");
                    }
                    else
                    {
                        epc = ((PARAM_EPCData)(msg.TagReportData[0].EPCParameter[0])).EPC.ToHexString();
                        //MessageBox.Show("EPC");
                    }
                    if (a1.ToString() == "12288" || a1.ToString()== "12544"  || a1.ToString()== "12800" || a1.ToString() == "13056")
                    ;
                    else
                        return null;

                        //uint x = a1 / 256;
                        //char type = (char)x;
                    char type = (char)(a1 >> 8);
                    //车牌号
                    char car1 = (char)(a3 / 256);
                    char car2 = (char)(a3 % 256);

                    char car3 = (char)(a4 / 256);
                    char car4 = (char)(a4 % 256);

                    char car5 = (char)(a5 / 256);
                    char car6 = (char)(a5 % 256);

                    string car = "京" + car1.ToString() + car2.ToString() + car3.ToString() + car4.ToString() + car5.ToString() + car6.ToString();
                    CarData data = new CarData();
                    data.truckNo = car;
                    //时间
                    string time = ((PARAM_C1G2ReadOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).ReadData.ToHexString();
                    //time=time.Substring(35, 12);
                    string time2 = time.Substring(30, 12);
                    string year = "20" + time2.Substring(0, 2);
                    string month = time2.Substring(2, 2);
                    string day = time2.Substring(5, 2);
                    string hour = time2.Substring(7, 2);
                    string min = time2.Substring(10, 2);

                    time = year + "-" + month + "-" + day + "," + hour + ":" + min;
                    //出发站点
                    data.startTime = time;
                    char station1 = (char)(a10 / 256);
                    char station2 = (char)(a10 % 256);
                    string station = station1.ToString() + station2.ToString();
                    data.stationID = int.Parse(station);
                    data.endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    data.boxid = epc;
                    //  listBox2.Items.Add(msg.ToString());
                    try
                    {
                        data.type = int.Parse(type.ToString());
                    }
                    catch { data.type = -1; }
                    return data;
                }
                catch (Exception e)
                {
                }
            }
            catch (Exception ex)
            {
                // textBox2.Text = ((PARAM_C1G2WriteOpSpecResult)(msg.TagReportData[0].AccessCommandOpSpecResult[0])).OpSpecID.ToString();
            }
            return null;
        }
        #endregion


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               // System.Environment.Exit(0);
                whileCar.Abort();
                thread.Abort();
                Application.Exit();
            }
            catch { }
        }

        private void groupCard_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }


        string w = "";
        public double convert(string input)
        {
            if (input.Length != 8)
            {
                return 0;
            }
            else
            {
                string reverse = "";
                for (int i = 0; i <= 7; i++)
                {
                    reverse += input[7 - i];
                }
                try
                {
                    double x = double.Parse(reverse);
                    return x;
                }
                catch { return 0; }
                
            }
        }
        private void comm1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            byte[] bs = new byte[9];
            comm1.Read(bs, 0, 9);
            string temp=comm1.ReadExisting();
            string xx = "";
            foreach (byte b in bs)
            {
                char a=(char)b;
                xx += a.ToString();
                if (a == '=')
                {
                    lblComm2.Text = convert(w).ToString();
                    GetStableWeight.insert(convert(w));
                    w = "";
                }
                else
                    w += a.ToString();
            }
            //lblComm1.Text = w;
        }

        public void LabelUpdate(Label l, string s)
        {
            l.Text = s;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] bs = new byte[9];
            bs[0] = (byte)'=';
            bs[1] = (byte)'2';
            bs[2] = (byte)'3';
            bs[3] = (byte)'4';
            bs[4] = (byte)'5';
            bs[5] = (byte)'6';
            bs[6] = (byte)'7';
            bs[7] = (byte)'0';
            bs[8] = (byte)'0';
            comm1.Write(bs, 0, 9);
        }
        string w2 = "";
        private void comm2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            byte[] bs = new byte[9];
            comm2.Read(bs, 0, 9);
            UpWindowLabelDel d = new UpWindowLabelDel(LabelUpdate);
            string xx = "";
            foreach (byte b in bs)
            {
                char a = (char)b;
                if (a == '=')
                {
                    lblComm1.Text = convert2(w2).ToString();
                    GetStableWeightUp.insert(convert2(w2));
                    w2 = "";
                }
                else
                    w2 += a.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer2.Enabled = false;
            this.Refresh();
            //this.Paint();
            
            this.Show();
        }

        public double convert2(string input)
        {
            if (input.Length != 8)
            {
                return 0;
            }
            else
            {
                string reverse = "";
                for (int i = 0; i <= 7; i++)
                {
                    reverse += input[7 - i];
                }
                try
                {
                    double x = double.Parse(reverse);
                    return x;
                }
                catch { return 0; }
            }
        }
        public void GetWeight1(object data)
        {
            Thread.Sleep(3000);
            try
            {
                ((CarData)data).allWeight = double.Parse(lblComm1.Text);
            }
            catch { }
        }
        public void GetWeight2(object data)
        {
            Thread.Sleep(3000);
            try
            {
                ((CarData)data).carWeight = double.Parse(lblComm2.Text);
                //MessageBox.Show(lblComm2.Text);
                label13.Text = lblComm2.Text;
            }
            catch { }
        }

        visifire vschart;
        private void bgwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                string sql = "SELECT * FROM [dbo.Goods] WHERE EndStationID=" + CommonData.stationID + " AND EndTime >= '" + DateTime.Now.ToString("yy-MM-dd,00:00") + "'";
                double sumWeight = 0;
                BaseOperate op = new BaseOperate();
                DataSet ds = op.getds(sql, "[dbo.Goods]");
                if (ds.Tables.Count <= 0)
                    return;

                

                ChartData chartdata = new ChartData();
                vschart = new visifire();

                

                chartdata.updateData(5, DateTime.Now, 0).ToString();
                vschart.reSize(webBrowser.Width, webBrowser.Height);
                vschart.settitle("当日转运中心报表", "时间", "运输量");
                string[] column = new string[16];
                double[] data1 = new double[16];
                for (int i = 0; i <= 15; i++)
                {
                    column[i] = (i + 5).ToString() + ":00";
                    data1[i] = chartdata.stationdaybox[i];
                }

                vschart.set3D(true);
                vschart.setData(column, data1, 16);
                string type = "pie";

                vschart.setType(type);
                e.Result = ds;
                if (CommonData.stations.Rows.Count > 0)
                    return;
                sql = "Select * from [dbo.Station]";
                DataSet ds1 = operate.getds(sql, "[dbo.Station]");
                if (ds1 == null || ds1.Tables.Count <= 0)
                    CommonData.stations = new DataTable();
                else
                    CommonData.stations = ds1.Tables[0]; 
            }
            catch { }
        }

        private void bgwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataSet ds = (DataSet)e.Result;
                double sumWeight = 0;
                ds.Tables[0].Columns.Add("StartStationName");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["StartStationName"] = CommonData.stations.GetValueByKey("StationID", row["StartStationID"], "Name");
                    try
                    {
                        sumWeight += double.Parse(row["Weight"].ToString());
                    }
                    catch (Exception ex) { }
                }
                
                this.dgvMsg.DataSource = ds.Tables[0];
                this.lblSum.Text = ds.Tables[0].Rows.Count + "次";
                this.lblSumWeight.Text = sumWeight + "";
                string str = System.AppDomain.CurrentDomain.BaseDirectory;
                Uri url = new Uri(str + "chart/Demo.htm");
                webBrowser.Url = url;

                webBrowser.Url = vschart.displayChart();
            }
            catch { }
        }

    }


}
