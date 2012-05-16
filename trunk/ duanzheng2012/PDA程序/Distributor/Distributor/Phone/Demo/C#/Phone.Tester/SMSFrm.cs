using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SEUIC.Phone.Tester
{
    public partial class SMSFrm : Form
    {
        public SMSFrm()
        {
            InitializeComponent();
        }

        SEUIC.Phone.SMS.Sms mSMS = null;

        SMS.MessageCollection mSMSCollection = new SMS.MessageCollection();

        private void SMSFrm_Load(object sender, EventArgs e)
        {
            mSMS = SMS.Sms.GetInstance();
    
            mSMS.OnSMSReceivedEvent+=new SEUIC.Phone.SMS.Sms.SMSReceivedNotifyEvent(mSMS_OnSMSReceivedEvent);
            mSMS.OnSMSSendFailEvent += new SEUIC.Phone.SMS.Sms.SMSSendNotifyEvent(mSMS_OnSMSSendFailEvent);
            mSMS.OnSMSSendSuccessEvent += new SEUIC.Phone.SMS.Sms.SMSSendNotifyEvent(mSMS_OnSMSSendSuccessEvent);

            mSMSCollection.Refresh();
            ShowSMSList(mSMSCollection);
        }


        private void SMSFrm_Closing(object sender, CancelEventArgs e)
        {
            mSMS.OnSMSReceivedEvent -= new SEUIC.Phone.SMS.Sms.SMSReceivedNotifyEvent(mSMS_OnSMSReceivedEvent);
            mSMS.OnSMSSendFailEvent -= new SEUIC.Phone.SMS.Sms.SMSSendNotifyEvent(mSMS_OnSMSSendFailEvent);
            mSMS.OnSMSSendSuccessEvent -= new SEUIC.Phone.SMS.Sms.SMSSendNotifyEvent(mSMS_OnSMSSendSuccessEvent);
        }


        public void ShowSMSList(SMS.MessageCollection smsCollection)
        {
            lvSMS.Items.Clear();

            for (int i=0;i<smsCollection.Count;i++)
            {
                lvSMS.Items.Add(new ListViewItem(new string[]{i.ToString(),
                    smsCollection[i].DBID.ToString(),
                    smsCollection[i].MessageStatus.ToString(),
                    smsCollection[i].Address.ToString(),
                    smsCollection[i].ReceiveTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    smsCollection[i].MessageText}));
            }

            lvSMS.Refresh();
        }


        private delegate void RefreshListViewHandle(int dbIndex);

        private void RefreshListView(int dbIndex)
        {
            if (dbIndex!=-1)
            {
                mSMSCollection.Refresh();
                ShowSMSList(mSMSCollection);
            }
        }


        void mSMS_OnSMSSendSuccessEvent(int dbIndex)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { dbIndex });
        }

        void mSMS_OnSMSSendFailEvent(int dbIndex)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { dbIndex });
        }

        void  mSMS_OnSMSReceivedEvent(int dbIndex)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { dbIndex });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mSMSCollection.Refresh();
            ShowSMSList(mSMSCollection);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvSMS.SelectedIndices.Count>0)
            {
                ListView.SelectedIndexCollection indexes = lvSMS.SelectedIndices;

                if (indexes.Count == 1)
                {
                    mSMSCollection.RemoveAt(indexes[0]);
                    
                    ShowSMSList(mSMSCollection);

                }

            }
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SMS.SMSMessage smsMsg = new SMS.SMSMessage();
            smsMsg.MessageText = tbSMSContent.Text.ToString().Trim();
            smsMsg.MessageStatus = SMS.MessageStatus.Draft;

            mSMSCollection.Add(smsMsg);

            ShowSMSList(mSMSCollection);
        }

        private void lvSMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSMS.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvSMS.SelectedIndices;

                if (indexes.Count == 1)
                {
                    tbSMSContent.Text = mSMSCollection[indexes[0]].Address + "\r\n" +
                                        mSMSCollection[indexes[0]].ReceiveTime.ToString("yyyy-MM-dd HH:mm-ss") + "\r\n" +
                                        mSMSCollection[indexes[0]].MessageText;

                }

            }
        }

    }
}