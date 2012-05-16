using System;
namespace SEUIC.Phone.Tester
{
    partial class MainFrm
    {
        private SMS.Sms mSms;

        void mSms_OnSMSReceivedEvent(int dbIndex)
        {
            sMsg = "SMS Reiceived,DBID:"+dbIndex.ToString();
            this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

            SMS.SMSMessage smsMsg = SMS.Sms.GetInstance().ReadMessage(dbIndex);
            string sContent = "PhoneNo:" + smsMsg.Address + "\r\n" + "Time:" + smsMsg.ReceiveTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + smsMsg.MessageText;

            this.Invoke(new RefreshSMSContentHandle(RefreshSMSContent), new object[] { sContent });
        }


        private void menuItem_SMS_Send_Click(object sender, EventArgs e)
        {
            try
            {
                string sDescAddress = tbPhoneNo.Text.ToString().Trim();
                string sSMSContent = tbSMSContent.Text.ToString().Trim();

                if (SMS.Sms.GetInstance().SMSSend(sDescAddress, sSMSContent))
                {
                    sMsg = "SMS Send Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "SMS Send Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }


            }
            catch (System.Exception ex)
            {

            }

        }

        private void menuItem_SMS_GetSMSByDBID_Click(object sender, EventArgs e)
        {
            try
            {
                int iDBID = int.Parse(tbSMSID.Text.ToString().Trim());

                SMS.SMSMessage msg = SMS.Sms.GetInstance().ReadMessage(iDBID);

                string sContent = "PhoneNo:" + msg.Address + "\r\n" + "Time:" + msg.ReceiveTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + msg.MessageText;

                this.Invoke(new RefreshSMSContentHandle(RefreshSMSContent), new object[] { sContent });
            }
            catch (System.Exception ex)
            {

            }

        }

        private void menuItem_SMS_GetSMSByDeviceID_Click(object sender, EventArgs e)
        {
            try
            {
                int iDeviceID = int.Parse(tbSMSID.Text.ToString().Trim());

                if (SMS.Sms.GetInstance().ReadMessageDrivers(iDeviceID))
                {
                    sMsg = "SMS ReadMessageDrivers Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "SMS ReadMessageDrivers Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }

            }
            catch (System.Exception ex)
            {

            }

        }

        void mSms_OnSMSSendFailEvent(int dbIndex)
        {
            sMsg = "SMS Send Fail";
            this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

        }

        void mSms_OnSMSSendSuccessEvent(int dbIndex)
        {
            sMsg = "SMS Send Success";
            this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
        }

        private void menuItem_SMS_GetSMSCenterNumber_Click(object sender, EventArgs e)
        {
            string sSMSCenter = mSms.GetSMSCenterNumber();
            sMsg = "SMSCenter:" + sSMSCenter;

            this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

            tbSMSCenterNumber.Text = sSMSCenter;
        }

        private void menuItem_SMS_SetSMSCenterNumber_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSMSCenterNumber.Text))
            {
                string sSMSCenter = tbSMSCenterNumber.Text.Trim();

                bool bRet = mSms.SetSMSCenterNumber(sSMSCenter);

                sMsg = "SetSMSCenterNumber:" + bRet.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

            }
        }
    }
}
