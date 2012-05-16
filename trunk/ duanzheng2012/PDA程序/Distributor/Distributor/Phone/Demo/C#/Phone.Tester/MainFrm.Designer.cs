namespace SEUIC.Phone.Tester
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbPhoneNo = new System.Windows.Forms.TextBox();
            this.btnClearMessage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSMSContent = new System.Windows.Forms.TextBox();
            this.tbSMSID = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem_Phone = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_Call = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_SendDTMF = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_Answer = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_Hangup = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_SpeakerOn = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_SpeakerOff = new System.Windows.Forms.MenuItem();
            this.menuItem_PhoneBook_PhoneBook = new System.Windows.Forms.MenuItem();
            this.menuItem_Phone_CallLog = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem_SMS_Send = new System.Windows.Forms.MenuItem();
            this.menuItem_SMS_GetSMSByDBID = new System.Windows.Forms.MenuItem();
            this.menuItem_SMS_GetSMSByDeviceID = new System.Windows.Forms.MenuItem();
            this.menuItem_SMS_ViewAllSMS = new System.Windows.Forms.MenuItem();
            this.menuItem_SMS_GetSMSCenterNumber = new System.Windows.Forms.MenuItem();
            this.menuItem_SMS_SetSMSCenterNumber = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_SyncDial = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_AsyncDial = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_Hangup = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_GetState = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_GetEntryNames = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_GetDeviceInfos = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_RasPingTestEnable = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_RasPingTestDisable = new System.Windows.Forms.MenuItem();
            this.menuItem_Ras_SetDiagnoseDestAddress = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_ModuleEnable = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_Disable = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_ResetModule = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetSpeakerVolume = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_SetSpeakerVolume = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetMicVolume = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_SetMicVolume = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_ModuleAbnormalDetectEnable = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_AbnormalDetectDisable = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetEVDOMode = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetEVDOLocationInfo = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetModuleStatus = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetNetworkType = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetModuleInfo = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetRSSI = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetHDRRSSI = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetCellID = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetLAC = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetESN = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetIMSI = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_GetMEID = new System.Windows.Forms.MenuItem();
            this.menuItem_Module_SendATCMD = new System.Windows.Forms.MenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.tbATCMD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPingAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSMSCenterNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMicVolume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSpeakerVolume = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDTMFNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // tbMessage
            // 
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMessage.Location = new System.Drawing.Point(0, 0);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMessage.Size = new System.Drawing.Size(238, 194);
            this.tbMessage.TabIndex = 3;
            // 
            // tbPhoneNo
            // 
            this.tbPhoneNo.Location = new System.Drawing.Point(92, 267);
            this.tbPhoneNo.Name = "tbPhoneNo";
            this.tbPhoneNo.Size = new System.Drawing.Size(125, 23);
            this.tbPhoneNo.TabIndex = 7;
            // 
            // btnClearMessage
            // 
            this.btnClearMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClearMessage.Location = new System.Drawing.Point(0, 194);
            this.btnClearMessage.Name = "btnClearMessage";
            this.btnClearMessage.Size = new System.Drawing.Size(238, 20);
            this.btnClearMessage.TabIndex = 12;
            this.btnClearMessage.Text = "Clear";
            this.btnClearMessage.Click += new System.EventHandler(this.btnClearMessage_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.Text = "DescPhoneNo:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.Text = "IncomingPhoneNo:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 23);
            this.textBox1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "SMSContent:";
            // 
            // tbSMSContent
            // 
            this.tbSMSContent.AcceptsReturn = true;
            this.tbSMSContent.AcceptsTab = true;
            this.tbSMSContent.Location = new System.Drawing.Point(4, 334);
            this.tbSMSContent.Multiline = true;
            this.tbSMSContent.Name = "tbSMSContent";
            this.tbSMSContent.Size = new System.Drawing.Size(213, 101);
            this.tbSMSContent.TabIndex = 17;
            // 
            // tbSMSID
            // 
            this.tbSMSID.Location = new System.Drawing.Point(66, 437);
            this.tbSMSID.Name = "tbSMSID";
            this.tbSMSID.Size = new System.Drawing.Size(151, 23);
            this.tbSMSID.TabIndex = 32;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem_Phone);
            this.mainMenu1.MenuItems.Add(this.menuItem5);
            this.mainMenu1.MenuItems.Add(this.menuItem7);
            this.mainMenu1.MenuItems.Add(this.menuItem14);
            // 
            // menuItem_Phone
            // 
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_Call);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_SendDTMF);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_Answer);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_Hangup);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_SpeakerOn);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_SpeakerOff);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_PhoneBook_PhoneBook);
            this.menuItem_Phone.MenuItems.Add(this.menuItem_Phone_CallLog);
            this.menuItem_Phone.Text = "Phone";
            // 
            // menuItem_Phone_Call
            // 
            this.menuItem_Phone_Call.Text = "Call";
            this.menuItem_Phone_Call.Click += new System.EventHandler(this.menuItem_Phone_Call_Click);
            // 
            // menuItem_Phone_SendDTMF
            // 
            this.menuItem_Phone_SendDTMF.Text = "SendDTMF";
            this.menuItem_Phone_SendDTMF.Click += new System.EventHandler(this.menuItem_Phone_SendDTMF_Click);
            // 
            // menuItem_Phone_Answer
            // 
            this.menuItem_Phone_Answer.Text = "Answer";
            this.menuItem_Phone_Answer.Click += new System.EventHandler(this.menuItem_Phone_Answer_Click);
            // 
            // menuItem_Phone_Hangup
            // 
            this.menuItem_Phone_Hangup.Text = "Hangup";
            this.menuItem_Phone_Hangup.Click += new System.EventHandler(this.menuItem_Phone_Hangup_Click);
            // 
            // menuItem_Phone_SpeakerOn
            // 
            this.menuItem_Phone_SpeakerOn.Text = "SpeakerOn";
            this.menuItem_Phone_SpeakerOn.Click += new System.EventHandler(this.menuItem_Phone_SpeakerOn_Click);
            // 
            // menuItem_Phone_SpeakerOff
            // 
            this.menuItem_Phone_SpeakerOff.Text = "SpeakerOff";
            this.menuItem_Phone_SpeakerOff.Click += new System.EventHandler(this.menuItem_Phone_SpeakerOff_Click);
            // 
            // menuItem_PhoneBook_PhoneBook
            // 
            this.menuItem_PhoneBook_PhoneBook.Text = "PhoneBook";
            this.menuItem_PhoneBook_PhoneBook.Click += new System.EventHandler(this.menuItem_PhoneBook_ViewPhoneBook_Click);
            // 
            // menuItem_Phone_CallLog
            // 
            this.menuItem_Phone_CallLog.Text = "CallLog";
            this.menuItem_Phone_CallLog.Click += new System.EventHandler(this.menuItem_Phone_CallLog_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.MenuItems.Add(this.menuItem_SMS_Send);
            this.menuItem5.MenuItems.Add(this.menuItem_SMS_GetSMSByDBID);
            this.menuItem5.MenuItems.Add(this.menuItem_SMS_GetSMSByDeviceID);
            this.menuItem5.MenuItems.Add(this.menuItem_SMS_ViewAllSMS);
            this.menuItem5.MenuItems.Add(this.menuItem_SMS_GetSMSCenterNumber);
            this.menuItem5.MenuItems.Add(this.menuItem_SMS_SetSMSCenterNumber);
            this.menuItem5.Text = "SMS";
            // 
            // menuItem_SMS_Send
            // 
            this.menuItem_SMS_Send.Text = "SMSSend";
            this.menuItem_SMS_Send.Click += new System.EventHandler(this.menuItem_SMS_Send_Click);
            // 
            // menuItem_SMS_GetSMSByDBID
            // 
            this.menuItem_SMS_GetSMSByDBID.Text = "GetSMSByDBID";
            this.menuItem_SMS_GetSMSByDBID.Click += new System.EventHandler(this.menuItem_SMS_GetSMSByDBID_Click);
            // 
            // menuItem_SMS_GetSMSByDeviceID
            // 
            this.menuItem_SMS_GetSMSByDeviceID.Text = "GetSMSByDeviceID";
            this.menuItem_SMS_GetSMSByDeviceID.Click += new System.EventHandler(this.menuItem_SMS_GetSMSByDeviceID_Click);
            // 
            // menuItem_SMS_ViewAllSMS
            // 
            this.menuItem_SMS_ViewAllSMS.Text = "ViewAllSMS";
            this.menuItem_SMS_ViewAllSMS.Click += new System.EventHandler(this.menuItem_SMS_ViewAllSMS_Click);
            // 
            // menuItem_SMS_GetSMSCenterNumber
            // 
            this.menuItem_SMS_GetSMSCenterNumber.Text = "GetSMSCenterNumber";
            this.menuItem_SMS_GetSMSCenterNumber.Click += new System.EventHandler(this.menuItem_SMS_GetSMSCenterNumber_Click);
            // 
            // menuItem_SMS_SetSMSCenterNumber
            // 
            this.menuItem_SMS_SetSMSCenterNumber.Text = "SetSMSCenterNumber";
            this.menuItem_SMS_SetSMSCenterNumber.Click += new System.EventHandler(this.menuItem_SMS_SetSMSCenterNumber_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_SyncDial);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_AsyncDial);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_Hangup);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_GetState);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_GetEntryNames);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_GetDeviceInfos);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_RasPingTestEnable);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_RasPingTestDisable);
            this.menuItem7.MenuItems.Add(this.menuItem_Ras_SetDiagnoseDestAddress);
            this.menuItem7.Text = "Ras";
            // 
            // menuItem_Ras_SyncDial
            // 
            this.menuItem_Ras_SyncDial.Text = "SyncDial";
            this.menuItem_Ras_SyncDial.Click += new System.EventHandler(this.menuItem_Ras_SyncDial_Click);
            // 
            // menuItem_Ras_AsyncDial
            // 
            this.menuItem_Ras_AsyncDial.Text = "AsyncDial";
            this.menuItem_Ras_AsyncDial.Click += new System.EventHandler(this.menuItem_Ras_AsyncDial_Click);
            // 
            // menuItem_Ras_Hangup
            // 
            this.menuItem_Ras_Hangup.Text = "Hangup";
            this.menuItem_Ras_Hangup.Click += new System.EventHandler(this.menuItem_Ras_Hangup_Click);
            // 
            // menuItem_Ras_GetState
            // 
            this.menuItem_Ras_GetState.Text = "GetState";
            this.menuItem_Ras_GetState.Click += new System.EventHandler(this.menuItem_Ras_GetState_Click);
            // 
            // menuItem_Ras_GetEntryNames
            // 
            this.menuItem_Ras_GetEntryNames.Text = "GetEntryNames";
            this.menuItem_Ras_GetEntryNames.Click += new System.EventHandler(this.menuItem_Ras_GetEntryNames_Click);
            // 
            // menuItem_Ras_GetDeviceInfos
            // 
            this.menuItem_Ras_GetDeviceInfos.Text = "GetDeviceInfos";
            this.menuItem_Ras_GetDeviceInfos.Click += new System.EventHandler(this.menuItem_Ras_GetDeviceInfos_Click);
            // 
            // menuItem_Ras_RasPingTestEnable
            // 
            this.menuItem_Ras_RasPingTestEnable.Text = "RasPingTestEnable";
            this.menuItem_Ras_RasPingTestEnable.Click += new System.EventHandler(this.menuItem_Ras_RasPingTestEnable_Click);
            // 
            // menuItem_Ras_RasPingTestDisable
            // 
            this.menuItem_Ras_RasPingTestDisable.Text = "RasPingTestDisable";
            this.menuItem_Ras_RasPingTestDisable.Click += new System.EventHandler(this.menuItem_Ras_RasPingTestDisable_Click);
            // 
            // menuItem_Ras_SetDiagnoseDestAddress
            // 
            this.menuItem_Ras_SetDiagnoseDestAddress.Text = "SetDiagnoseDestAddress";
            this.menuItem_Ras_SetDiagnoseDestAddress.Click += new System.EventHandler(this.menuItem_Ras_SetDiagnoseDestAddress_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.MenuItems.Add(this.menuItem1);
            this.menuItem14.MenuItems.Add(this.menuItem2);
            this.menuItem14.MenuItems.Add(this.menuItem3);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetModuleStatus);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetNetworkType);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetModuleInfo);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetRSSI);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetHDRRSSI);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetCellID);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetLAC);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetESN);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetIMSI);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_GetMEID);
            this.menuItem14.MenuItems.Add(this.menuItem_Module_SendATCMD);
            this.menuItem14.MenuItems.Add(this.menuItem4);
            this.menuItem14.Text = "Module";
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem_Module_ModuleEnable);
            this.menuItem1.MenuItems.Add(this.menuItem_Module_Disable);
            this.menuItem1.MenuItems.Add(this.menuItem_Module_ResetModule);
            this.menuItem1.MenuItems.Add(this.menuItem_Module_GetSpeakerVolume);
            this.menuItem1.MenuItems.Add(this.menuItem_Module_SetSpeakerVolume);
            this.menuItem1.MenuItems.Add(this.menuItem_Module_GetMicVolume);
            this.menuItem1.MenuItems.Add(this.menuItem_Module_SetMicVolume);
            this.menuItem1.Text = "ModuleControl";
            // 
            // menuItem_Module_ModuleEnable
            // 
            this.menuItem_Module_ModuleEnable.Text = "ModuleEnable";
            this.menuItem_Module_ModuleEnable.Click += new System.EventHandler(this.menuItem_Module_ModuleEnable_Click);
            // 
            // menuItem_Module_Disable
            // 
            this.menuItem_Module_Disable.Text = "ModuleDisable";
            this.menuItem_Module_Disable.Click += new System.EventHandler(this.menuItem_Module_Disable_Click);
            // 
            // menuItem_Module_ResetModule
            // 
            this.menuItem_Module_ResetModule.Text = "ResetModule";
            this.menuItem_Module_ResetModule.Click += new System.EventHandler(this.menuItem_Module_ResetModule_Click);
            // 
            // menuItem_Module_GetSpeakerVolume
            // 
            this.menuItem_Module_GetSpeakerVolume.Text = "GetSpeakerVolume";
            this.menuItem_Module_GetSpeakerVolume.Click += new System.EventHandler(this.menuItem_Module_GetSpeakerVolume_Click);
            // 
            // menuItem_Module_SetSpeakerVolume
            // 
            this.menuItem_Module_SetSpeakerVolume.Text = "SetSpeakerVolume";
            this.menuItem_Module_SetSpeakerVolume.Click += new System.EventHandler(this.menuItem_Module_SetSpeakerVolume_Click);
            // 
            // menuItem_Module_GetMicVolume
            // 
            this.menuItem_Module_GetMicVolume.Text = "GetMicVolume";
            this.menuItem_Module_GetMicVolume.Click += new System.EventHandler(this.menuItem_Module_GetMicVolume_Click);
            // 
            // menuItem_Module_SetMicVolume
            // 
            this.menuItem_Module_SetMicVolume.Text = "SetMicVolume";
            this.menuItem_Module_SetMicVolume.Click += new System.EventHandler(this.menuItem_Module_SetMicVolume_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItem_Module_ModuleAbnormalDetectEnable);
            this.menuItem2.MenuItems.Add(this.menuItem_Module_AbnormalDetectDisable);
            this.menuItem2.Text = "RobustnessControl";
            // 
            // menuItem_Module_ModuleAbnormalDetectEnable
            // 
            this.menuItem_Module_ModuleAbnormalDetectEnable.Text = "AbnormalDetectEnable";
            this.menuItem_Module_ModuleAbnormalDetectEnable.Click += new System.EventHandler(this.menuItem_Module_ModuleAbnormalDetectEnable_Click);
            // 
            // menuItem_Module_AbnormalDetectDisable
            // 
            this.menuItem_Module_AbnormalDetectDisable.Text = "AbnormalDetectDisable";
            this.menuItem_Module_AbnormalDetectDisable.Click += new System.EventHandler(this.menuItem_Module_AbnormalDetectDisable_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MenuItems.Add(this.menuItem_Module_GetEVDOMode);
            this.menuItem3.MenuItems.Add(this.menuItem_Module_GetEVDOLocationInfo);
            this.menuItem3.Text = "EVDO";
            // 
            // menuItem_Module_GetEVDOMode
            // 
            this.menuItem_Module_GetEVDOMode.Text = "GetEVDOMode";
            this.menuItem_Module_GetEVDOMode.Click += new System.EventHandler(this.menuItem_Module_GetEVDOMode_Click);
            // 
            // menuItem_Module_GetEVDOLocationInfo
            // 
            this.menuItem_Module_GetEVDOLocationInfo.Text = "GetEVDOLocationInfo";
            this.menuItem_Module_GetEVDOLocationInfo.Click += new System.EventHandler(this.menuItem_Module_GetEVDOLocationInfo_Click);
            // 
            // menuItem_Module_GetModuleStatus
            // 
            this.menuItem_Module_GetModuleStatus.Text = "GetModuleStatus";
            this.menuItem_Module_GetModuleStatus.Click += new System.EventHandler(this.menuItem_Module_GetModuleStatus_Click);
            // 
            // menuItem_Module_GetNetworkType
            // 
            this.menuItem_Module_GetNetworkType.Text = "GetNetworkType";
            this.menuItem_Module_GetNetworkType.Click += new System.EventHandler(this.menuItem_Module_GetNetworkType_Click);
            // 
            // menuItem_Module_GetModuleInfo
            // 
            this.menuItem_Module_GetModuleInfo.Text = "GetModuleInfo";
            this.menuItem_Module_GetModuleInfo.Click += new System.EventHandler(this.menuItem_Module_GetModuleInfo_Click);
            // 
            // menuItem_Module_GetRSSI
            // 
            this.menuItem_Module_GetRSSI.Text = "GetRSSI";
            this.menuItem_Module_GetRSSI.Click += new System.EventHandler(this.menuItem_Module_GetRSSI_Click);
            // 
            // menuItem_Module_GetHDRRSSI
            // 
            this.menuItem_Module_GetHDRRSSI.Text = "GetHDRRSSI";
            this.menuItem_Module_GetHDRRSSI.Click += new System.EventHandler(this.menuItem_Module_GetHDRRSSI_Click);
            // 
            // menuItem_Module_GetCellID
            // 
            this.menuItem_Module_GetCellID.Text = "GetCellID";
            this.menuItem_Module_GetCellID.Click += new System.EventHandler(this.menuItem_Module_GetCellID_Click);
            // 
            // menuItem_Module_GetLAC
            // 
            this.menuItem_Module_GetLAC.Text = "GetLAC";
            this.menuItem_Module_GetLAC.Click += new System.EventHandler(this.menuItem_Module_GetLAC_Click);
            // 
            // menuItem_Module_GetESN
            // 
            this.menuItem_Module_GetESN.Text = "GetESN";
            this.menuItem_Module_GetESN.Click += new System.EventHandler(this.menuItem_Module_GetESN_Click);
            // 
            // menuItem_Module_GetIMSI
            // 
            this.menuItem_Module_GetIMSI.Text = "GetIMSI";
            this.menuItem_Module_GetIMSI.Click += new System.EventHandler(this.menuItem_Module_GetIMSI_Click);
            // 
            // menuItem_Module_GetMEID
            // 
            this.menuItem_Module_GetMEID.Text = "GetMEID";
            this.menuItem_Module_GetMEID.Click += new System.EventHandler(this.menuItem_Module_GetMEID_Click);
            // 
            // menuItem_Module_SendATCMD
            // 
            this.menuItem_Module_SendATCMD.Text = "SendATCMD";
            this.menuItem_Module_SendATCMD.Click += new System.EventHandler(this.menuItem_Module_SendATCMD_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "SMSID:";
            // 
            // tbATCMD
            // 
            this.tbATCMD.Location = new System.Drawing.Point(66, 461);
            this.tbATCMD.Name = "tbATCMD";
            this.tbATCMD.Size = new System.Drawing.Size(151, 23);
            this.tbATCMD.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "ATCMD:";
            // 
            // tbPingAddr
            // 
            this.tbPingAddr.Location = new System.Drawing.Point(66, 485);
            this.tbPingAddr.Name = "tbPingAddr";
            this.tbPingAddr.Size = new System.Drawing.Size(151, 23);
            this.tbPingAddr.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "PingAddr:";
            // 
            // tbSMSCenterNumber
            // 
            this.tbSMSCenterNumber.Location = new System.Drawing.Point(81, 510);
            this.tbSMSCenterNumber.Name = "tbSMSCenterNumber";
            this.tbSMSCenterNumber.Size = new System.Drawing.Size(136, 23);
            this.tbSMSCenterNumber.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 512);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "SMSCenter:";
            // 
            // tbMicVolume
            // 
            this.tbMicVolume.Location = new System.Drawing.Point(111, 561);
            this.tbMicVolume.Name = "tbMicVolume";
            this.tbMicVolume.Size = new System.Drawing.Size(106, 23);
            this.tbMicVolume.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 561);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.Text = "MicVolume:";
            // 
            // tbSpeakerVolume
            // 
            this.tbSpeakerVolume.Location = new System.Drawing.Point(111, 534);
            this.tbSpeakerVolume.Name = "tbSpeakerVolume";
            this.tbSpeakerVolume.Size = new System.Drawing.Size(106, 23);
            this.tbSpeakerVolume.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 536);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.Text = "SpeakerVolume:";
            // 
            // tbDTMFNo
            // 
            this.tbDTMFNo.Location = new System.Drawing.Point(92, 291);
            this.tbDTMFNo.Name = "tbDTMFNo";
            this.tbDTMFNo.Size = new System.Drawing.Size(125, 23);
            this.tbDTMFNo.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(0, 294);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 20);
            this.label10.Text = "DTMFNo:";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "IsSIMCardIn";
            this.menuItem4.Click += new System.EventHandler(this.menuItem_IsSIMCardIn_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 600);
            this.Controls.Add(this.tbDTMFNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbSpeakerVolume);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbMicVolume);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbSMSCenterNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPingAddr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbATCMD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSMSID);
            this.Controls.Add(this.tbSMSContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPhoneNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearMessage);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.label4);
            this.Menu = this.mainMenu1;
            this.Name = "MainFrm";
            this.Text = "RAS Dial";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFrm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbPhoneNo;
        private System.Windows.Forms.Button btnClearMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSMSContent;
        private System.Windows.Forms.TextBox tbSMSID;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem_Phone;
        private System.Windows.Forms.MenuItem menuItem_Phone_Call;
        private System.Windows.Forms.MenuItem menuItem_Phone_Answer;
        private System.Windows.Forms.MenuItem menuItem_Phone_Hangup;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem_SMS_Send;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem_Ras_SyncDial;
        private System.Windows.Forms.MenuItem menuItem_Ras_AsyncDial;
        private System.Windows.Forms.MenuItem menuItem_Ras_Hangup;
        private System.Windows.Forms.MenuItem menuItem_Ras_GetState;
        private System.Windows.Forms.MenuItem menuItem_Ras_GetEntryNames;
        private System.Windows.Forms.MenuItem menuItem_Ras_GetDeviceInfos;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem_Module_ModuleEnable;
        private System.Windows.Forms.MenuItem menuItem_Module_Disable;
        private System.Windows.Forms.MenuItem menuItem_Module_GetRSSI;
        private System.Windows.Forms.MenuItem menuItem_Module_GetHDRRSSI;
        private System.Windows.Forms.MenuItem menuItem_Module_GetCellID;
        private System.Windows.Forms.MenuItem menuItem_Module_GetLAC;
        private System.Windows.Forms.MenuItem menuItem_Module_GetESN;
        private System.Windows.Forms.MenuItem menuItem_Module_GetIMSI;
        private System.Windows.Forms.MenuItem menuItem_Module_GetMEID;
        private System.Windows.Forms.MenuItem menuItem_Module_GetModuleInfo;
        private System.Windows.Forms.MenuItem menuItem_Module_SendATCMD;
        private System.Windows.Forms.MenuItem menuItem_Module_GetModuleStatus;
        private System.Windows.Forms.MenuItem menuItem_Module_ResetModule;
        private System.Windows.Forms.MenuItem menuItem_SMS_GetSMSByDBID;
        private System.Windows.Forms.MenuItem menuItem_SMS_GetSMSByDeviceID;
        private System.Windows.Forms.MenuItem menuItem_Phone_SpeakerOn;
        private System.Windows.Forms.MenuItem menuItem_Phone_SpeakerOff;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbATCMD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem_Module_ModuleAbnormalDetectEnable;
        private System.Windows.Forms.MenuItem menuItem_Module_AbnormalDetectDisable;
        private System.Windows.Forms.TextBox tbPingAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuItem menuItem_Module_GetNetworkType;
        private System.Windows.Forms.MenuItem menuItem_Ras_RasPingTestEnable;
        private System.Windows.Forms.MenuItem menuItem_Ras_RasPingTestDisable;
        private System.Windows.Forms.MenuItem menuItem_Ras_SetDiagnoseDestAddress;
        private System.Windows.Forms.MenuItem menuItem_SMS_ViewAllSMS;
        private System.Windows.Forms.MenuItem menuItem_PhoneBook_PhoneBook;
        private System.Windows.Forms.MenuItem menuItem_Phone_CallLog;
        private System.Windows.Forms.MenuItem menuItem_SMS_GetSMSCenterNumber;
        private System.Windows.Forms.MenuItem menuItem_SMS_SetSMSCenterNumber;
        private System.Windows.Forms.TextBox tbSMSCenterNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMicVolume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSpeakerVolume;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuItem menuItem_Module_GetSpeakerVolume;
        private System.Windows.Forms.MenuItem menuItem_Module_SetSpeakerVolume;
        private System.Windows.Forms.MenuItem menuItem_Module_GetMicVolume;
        private System.Windows.Forms.MenuItem menuItem_Module_SetMicVolume;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem_Module_GetEVDOMode;
        private System.Windows.Forms.MenuItem menuItem_Module_GetEVDOLocationInfo;
        private System.Windows.Forms.MenuItem menuItem_Phone_SendDTMF;
        private System.Windows.Forms.TextBox tbDTMFNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuItem menuItem4;
    }
}

