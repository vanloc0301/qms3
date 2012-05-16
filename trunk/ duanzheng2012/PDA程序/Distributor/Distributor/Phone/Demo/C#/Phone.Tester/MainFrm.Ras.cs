using System;
namespace SEUIC.Phone.Tester
{
    partial class MainFrm
    {
        private RAS.Ras mRas;

        void mRas_OnStateChangedEvent(SEUIC.Phone.RAS.RASConnState rasConnState)
        {
            sMsg = rasConnState.ToString();
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }

        void mRas_OnDisconnectedEvent()
        {
            sMsg = "OnDisconnectedEvent DisConnected.";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });

        }

        void mRas_OnConnectedEvent()
        {
            sMsg = "OnConnectedEvent Connected.";
            this.Invoke(new RefreshMessageHandle(ShowMessage), new object[] { sMsg });
        }


        private void menuItem_Ras_SyncDial_Click(object sender, EventArgs e)
        {
            try
            {
                sMsg = "Start Sync Dial...";

                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                mRas.RasDialMode = RAS.RasDialMode.Sync;
                if (mRas.DialUp("", "", "*99***1#"))
                {
                    sMsg = "Sync Dial Success.";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }
                else
                {
                    sMsg = "Sync Dial Fail.";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }
            }
            catch (System.Exception ex)
            {

            }

        }

        private void menuItem_Ras_AsyncDial_Click(object sender, EventArgs e)
        {
            try
            {
                sMsg = "Start Async Dial...";
                mRas.RasDialMode = RAS.RasDialMode.Async;
                if (mRas.DialUp("", "", "*99***1#"))
                {
                    sMsg = "Async Dial Success.";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }
                else
                {
                    sMsg = "Async Dial Fail.";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_Hangup_Click(object sender, EventArgs e)
        {
            try
            {
                sMsg = "RAS Hangup...";
                if (mRas.HangUp())
                {
                    sMsg = "HangUp Success.";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }
                else
                {
                    sMsg = "HangUp Fail.";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_GetState_Click(object sender, EventArgs e)
        {
            try
            {
                RAS.RASConnState rasConnState = mRas.GetStatus();

                sMsg = rasConnState.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_GetEntryNames_Click(object sender, EventArgs e)
        {
            try
            {
                string[] entryNames = RAS.Ras.GetRasEntryNames();

                sMsg = "Get EntryNames...";
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                foreach (var item in entryNames)
                {
                    this.Invoke(new RefreshMessageNoTimeHandle(RefreshMessageNoTime), new object[] { item, false });
                }
                sMsg = "Get EntryNames END.";
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_GetDeviceInfos_Click(object sender, EventArgs e)
        {
            try
            {
                RAS.DeviceInfo[] devInfos = RAS.Ras.GetDeviceInfos();

                sMsg = "Get DeviceInfos...";

                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                foreach (var item in devInfos)
                {
                    this.Invoke(new RefreshMessageNoTimeHandle(RefreshMessageNoTime), new object[] { item.DeviceName + " - " + item.DeviceType, false });
                }
                sMsg = "Get DeviceInfos END.";
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_RasPingTestEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (RAS.Ras.RASPingTestEnable())
                {
                    sMsg = "Module RASPingTestEnable Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module RASPingTestEnable Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_RasPingTestDisable_Click(object sender, EventArgs e)
        {
            try
            {
                if (RAS.Ras.RASPingTestDisable())
                {
                    sMsg = "Module RASPingTestDisable Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module RASPingTestDisable Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Ras_SetDiagnoseDestAddress_Click(object sender, EventArgs e)
        {
            try
            {
                string sPingAddr = tbPingAddr.Text.ToString().Trim();

                if (RAS.Ras.SetDiagnoseDestAddress(sPingAddr))
                {
                    sMsg = "Module SetPingTestAddress Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module SetPingTestAddress Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

    }
}
