using System;
namespace SEUIC.Phone.Tester
{
    partial class MainFrm
    {
        private Call mPhone;

        void mPhone_OnStatusChangeEvent(PhoneStatus phoneStatus)
        {
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { phoneStatus.ToString() });
        }

        void mPhone_OnWaitingEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnWaitingEventWithCallerID:\r\n"
                +callerID.CallDirection.ToString()+"\r\n"
                +callerID.CallerIDType.ToString()+"\r\n" 
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnWaitingEvent()
        {
            sMsg = "OnWaitingEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnOnHoldEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnOnHoldEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnOnHoldEvent()
        {
            sMsg = "OnOnHoldEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnNoDialToneEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnNoDialToneEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnNoDialToneEvent()
        {
            sMsg = "OnNoDialToneEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnNoAnswerEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnNoAnswerEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnNoAnswerEvent()
        {
            sMsg = "OnNoAnswerEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnMissingEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnMissingEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnMissingEvent()
        {
            sMsg = "OnMissingEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnIncomingEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnIncomingEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnIncomingEvent()
        {
            sMsg = "OnIncomingEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnHangUpEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnHangUpEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnHangUpEvent()
        {
            sMsg = "OnHangUpEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnDialingEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnDialingEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnDialingEvent()
        {
            sMsg = "OnDialingEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnBusyEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnBusyEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnBusyEvent()
        {
            sMsg = "OnBusyEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnAlertingEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnAlertingEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnAlertingEvent()
        {
            sMsg = "OnAlertingEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnActiveEventWithCallerID(CallerID callerID)
        {
            sMsg = "OnActiveEventWithCallerID:\r\n"
                + callerID.CallDirection.ToString() + "\r\n"
                + callerID.CallerIDType.ToString() + "\r\n"
                + callerID.CallerNumer;
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mPhone_OnActiveEvent()
        {
            sMsg = "OnActiveEvent:";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }


        private void menuItem_Phone_Call_Click(object sender, EventArgs e)
        {
            try
            {
                Call.MakeCall(tbPhoneNo.Text.ToString().Trim());

            }
            catch (System.Exception ex)
            {

            }

        }

        private void menuItem_Phone_Answer_Click(object sender, EventArgs e)
        {
            try
            {
                Call.Answer();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Phone_Hangup_Click(object sender, EventArgs e)
        {
            try
            {
                Call.HangUp();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Phone_SpeakerOn_Click(object sender, EventArgs e)
        {
            try
            {
                Call.Speaker(true);
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Phone_SpeakerOff_Click(object sender, EventArgs e)
        {
            try
            {
                Call.Speaker(false);
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Phone_SendDTMF_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbDTMFNo.Text))
                {
                    bool b=Call.SendDTMF(tbDTMFNo.Text.Trim());
                    sMsg = "SendDTMF:"+tbDTMFNo.Text+" "+b.ToString();
                    this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });

                }
            }
            catch (System.Exception ex)
            {
            	
            }

        }
    }
}
