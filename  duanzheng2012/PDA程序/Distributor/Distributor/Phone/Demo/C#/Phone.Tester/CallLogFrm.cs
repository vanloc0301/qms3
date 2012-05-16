using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SEUIC.Phone.Tester
{
    public partial class CallLogFrm : Form
    {
        public CallLogFrm()
        {
            InitializeComponent();
        }

        Phone.Call mCall = null;

        CallLog.CallLogCollection mCallLogCollection = new CallLog.CallLogCollection();

        private void CallLogFrm_Load(object sender, EventArgs e)
        {
            mCall = new Phone.Call();

            mCall.OnBusyEventWithCallerID += new Call.CallerNotifyHandle(mCall_OnBusyEventWithCallerID);
            mCall.OnHangUpEventWithCallerID += new Call.CallerNotifyHandle(mCall_OnHangUpEventWithCallerID);
            mCall.OnMissingEventWithCallerID += new Call.CallerNotifyHandle(mCall_OnMissingEventWithCallerID);
            mCall.OnDialingEventWithCallerID += new Call.CallerNotifyHandle(mCall_OnDialingEventWithCallerID);

        }

        void mCall_OnDialingEventWithCallerID(CallerID callerID)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { callerID });
        }

        void mCall_OnMissingEventWithCallerID(CallerID callerID)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { callerID });
        }

        void mCall_OnHangUpEventWithCallerID(CallerID callerID)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { callerID });
        }

        void mCall_OnBusyEventWithCallerID(CallerID callerID)
        {
            this.Invoke(new RefreshListViewHandle(RefreshListView), new object[] { callerID });
        }


        public void ShowCallLogList(CallLog.CallLogCollection callLogCollection)
        {
            lvCallLog.Items.Clear();

            for (int i = 0; i < callLogCollection.Count; i++)
            {
                lvCallLog.Items.Add(new ListViewItem(new string[]{i.ToString(),
                    callLogCollection[i].DBID.ToString(),
                    callLogCollection[i].Number.ToString(),
                    callLogCollection[i].Name.ToString(),
                    callLogCollection[i].StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    callLogCollection[i].EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    callLogCollection[i].CallType.ToString(),
                    callLogCollection[i].OutGoing.ToString(),
                    callLogCollection[i].Connected.ToString(),
                    callLogCollection[i].Ended.ToString(),
                    callLogCollection[i].Roaming.ToString(),
                    callLogCollection[i].CallIDType.ToString(),
                    callLogCollection[i].NameType.ToString(),
                    callLogCollection[i].Note.ToString(),
                    callLogCollection[i].Readed.ToString()}));

            }

            lvCallLog.Refresh();
        }


        private delegate void RefreshListViewHandle(CallerID callerID);

        private void RefreshListView(CallerID callerID)
        {
            mCallLogCollection.Refresh();
            ShowCallLogList(mCallLogCollection);

        }



        private void CallLogFrm_Closing(object sender, CancelEventArgs e)
        {
            mCall.OnBusyEventWithCallerID -= new Call.CallerNotifyHandle(mCall_OnBusyEventWithCallerID);
            mCall.OnHangUpEventWithCallerID -= new Call.CallerNotifyHandle(mCall_OnHangUpEventWithCallerID);
            mCall.OnMissingEventWithCallerID -= new Call.CallerNotifyHandle(mCall_OnMissingEventWithCallerID);
            mCall.OnDialingEventWithCallerID -= new Call.CallerNotifyHandle(mCall_OnDialingEventWithCallerID);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mCallLogCollection.Refresh();
            ShowCallLogList(mCallLogCollection);

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvCallLog.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvCallLog.SelectedIndices;

                if (indexes.Count == 1)
                {
                    mCallLogCollection.RemoveAt(indexes[0]);

                    ShowCallLogList(mCallLogCollection);

                }

            }
        }

        private void btnMissedAsReaded_Click(object sender, EventArgs e)
        {
            if (lvCallLog.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = lvCallLog.SelectedIndices;

                if (indexes.Count == 1)
                {
                    bool bRet=CallLog.CallLog.MarkMessageAsReaded(mCallLogCollection[indexes[0]].DBID);

                    ShowCallLogList(mCallLogCollection);

                }

            }
            
        }
    }
}