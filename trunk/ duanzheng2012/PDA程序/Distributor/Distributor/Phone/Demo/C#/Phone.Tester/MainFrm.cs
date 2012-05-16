﻿using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SEUIC;
using SEUIC.Phone;

namespace SEUIC.Phone.Tester
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private string ENTRYNAME = "Dial-up";

        string sMsg = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            bool b =Initialize.Init();
#if DEBUG
            Initialize.OnDebugInfoEvent += new Initialize.DebugIndoHandle(Initialize_OnDebugInfoEvent);
#endif
            mRas = RAS.Ras.GetInstance();
            mRas.OnConnectedEvent += new SEUIC.Phone.RAS.Ras.NotifyEvent(mRas_OnConnectedEvent);
            mRas.OnDisconnectedEvent += new SEUIC.Phone.RAS.Ras.NotifyEvent(mRas_OnDisconnectedEvent);
            mRas.OnStateChangedEvent += new SEUIC.Phone.RAS.Ras.StateChangeNotifyEvent(mRas_OnStateChangedEvent);
           
            mSms = SMS.Sms.GetInstance();
            mSms.OnSMSReceivedEvent += new SEUIC.Phone.SMS.Sms.SMSReceivedNotifyEvent(mSms_OnSMSReceivedEvent);
            mSms.OnSMSSendSuccessEvent += new SEUIC.Phone.SMS.Sms.SMSSendNotifyEvent(mSms_OnSMSSendSuccessEvent);
            mSms.OnSMSSendFailEvent += new SEUIC.Phone.SMS.Sms.SMSSendNotifyEvent(mSms_OnSMSSendFailEvent);


            mPhone = Call.GetInstance();
            mPhone.OnStatusChangeEvent += new Call.NotifyHandle(mPhone_OnStatusChangeEvent);

            mPhone.OnActiveEvent += new Call.NotifyEvent(mPhone_OnActiveEvent);
            mPhone.OnActiveEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnActiveEventWithCallerID);
            mPhone.OnAlertingEvent += new Call.NotifyEvent(mPhone_OnAlertingEvent);
            mPhone.OnAlertingEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnAlertingEventWithCallerID);
            mPhone.OnBusyEvent += new Call.NotifyEvent(mPhone_OnBusyEvent);
            mPhone.OnBusyEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnBusyEventWithCallerID);
            mPhone.OnDialingEvent += new Call.NotifyEvent(mPhone_OnDialingEvent);
            mPhone.OnDialingEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnDialingEventWithCallerID);
            mPhone.OnHangUpEvent += new Call.NotifyEvent(mPhone_OnHangUpEvent);
            mPhone.OnHangUpEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnHangUpEventWithCallerID);
            mPhone.OnIncomingEvent += new Call.NotifyEvent(mPhone_OnIncomingEvent);
            mPhone.OnIncomingEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnIncomingEventWithCallerID);
            mPhone.OnMissingEvent += new Call.NotifyEvent(mPhone_OnMissingEvent);
            mPhone.OnMissingEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnMissingEventWithCallerID);
            mPhone.OnNoAnswerEvent += new Call.NotifyEvent(mPhone_OnNoAnswerEvent);
            mPhone.OnNoAnswerEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnNoAnswerEventWithCallerID);
            mPhone.OnNoDialToneEvent += new Call.NotifyEvent(mPhone_OnNoDialToneEvent);
            mPhone.OnNoDialToneEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnNoDialToneEventWithCallerID);
            mPhone.OnOnHoldEvent += new Call.NotifyEvent(mPhone_OnOnHoldEvent);
            mPhone.OnOnHoldEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnOnHoldEventWithCallerID);
            mPhone.OnWaitingEvent += new Call.NotifyEvent(mPhone_OnWaitingEvent);
            mPhone.OnWaitingEventWithCallerID += new Call.CallerNotifyHandle(mPhone_OnWaitingEventWithCallerID);
        }

        void Initialize_OnDebugInfoEvent(string sInfo)
        {
            sMsg = "DEBUG:" + sInfo;

            this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

        }



        private void MainFrm_Closing(object sender, CancelEventArgs e)
        {
            Initialize.UnInit();

        }

        private void btnClearMessage_Click(object sender, EventArgs e)
        {
            tbMessage.Text = string.Empty;
        }

        private void menuItem_SMS_ViewAllSMS_Click(object sender, EventArgs e)
        {
            SMSFrm smsfrm = new SMSFrm();

            smsfrm.Show();
        }

        private void menuItem_PhoneBook_ViewPhoneBook_Click(object sender, EventArgs e)
        {
            PhoneBookFrm pbFrm = new PhoneBookFrm();

            pbFrm.Show();
        }

        private void menuItem_Phone_CallLog_Click(object sender, EventArgs e)
        {
            CallLogFrm calllogFrm = new CallLogFrm();

            calllogFrm.Show();
        }

        private void menuItem_IsSIMCardIn_Click(object sender, EventArgs e)
        {
            if (Module.Module.IsSIMCardIn())
                MessageBox.Show("SIM卡存在");
            else
                MessageBox.Show("SIM卡不存在");
        }



                
    }
}