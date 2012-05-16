using SEUIC.Phone.Module;
using System;
namespace SEUIC.Phone.Tester
{
    partial class MainFrm
    {
        private void menuItem_Module_ModuleEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (Module.Module.ModuleEnable())
                {
                    sMsg = "Module ModuleEnable Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module ModuleEnable Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_Disable_Click(object sender, EventArgs e)
        {
            try
            {
                if (Module.Module.ModuleDisable())
                {
                    sMsg = "Module ModuleDisable Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module ModuleDisable Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetRSSI_Click(object sender, EventArgs e)
        {
            try
            {
                int iRSSI = Module.Module.GetRSSI();
                sMsg = "RSSI:" + iRSSI.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetHDRRSSI_Click(object sender, EventArgs e)
        {
            try
            {
                int iRSSI = Module.Module.GetHDRRSSI();
                sMsg = "HDR^RSSI:" + iRSSI.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetCellID_Click(object sender, EventArgs e)
        {
            try
            {
                string sCellID = Module.Module.GetCellID();
                sMsg = "CellID:" + sCellID;
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetLAC_Click(object sender, EventArgs e)
        {
            try
            {
                string sLAC = Module.Module.GetLAC();
                sMsg = "LAC:" + sLAC;
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetESN_Click(object sender, EventArgs e)
        {
            try
            {
                string sESN = Module.Module.GetESN();
                sMsg = "ESN:" + sESN;
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetIMSI_Click(object sender, EventArgs e)
        {
            try
            {
                string sIMSI = Module.Module.GetIMSI();
                sMsg = "IMSI:" + sIMSI;
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetMEID_Click(object sender, EventArgs e)
        {
            try
            {
                string sMEID = Module.Module.GetMEID();
                sMsg = "MEID:" + sMEID;
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetModuleInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string sModuleInfo = Module.Module.GetModuleInfo();
                sMsg = "ModuleInfo:" + sModuleInfo;
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_SendATCMD_Click(object sender, EventArgs e)
        {
            try
            {
//                 string sATCMD = tbATCMD.Text.ToString().Trim();
//                 string sATCMDResponse = Module.Module.SendATCommand(sATCMD);
                sMsg = "Not Support.";
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetModuleStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Module.ModuleStatus moduleStatus = Module.Module.GetModuleStatus();
                sMsg = "ModuleStatus:" + moduleStatus.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_ResetModule_Click(object sender, EventArgs e)
        {
            try
            {
                if (Module.Module.ResetModule())
                {
                    sMsg = "Module ResetModule Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module ResetModule Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_ModuleAbnormalDetectEnable_Click(object sender, EventArgs e)
        {
            try
            {
                if (Module.Module.ModuleAbnormalDetectEnable())
                {
                    sMsg = "Module ModuleAbnormalDetectEnable Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module ModuleAbnormalDetectEnable Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_AbnormalDetectDisable_Click(object sender, EventArgs e)
        {
            try
            {
                if (Module.Module.ModuleAbnormalDetectDisable())
                {
                    sMsg = "Module ModuleAbnormalDetectDisable Success";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
                else
                {
                    sMsg = "Module ModuleAbnormalDetectDisable Fail";
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetNetworkType_Click(object sender, EventArgs e)
        {
            try
            {
                Module.NetworkType networkType= Module.Module.GetNetworkType();
                sMsg = "NetworkType:" + networkType.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });
            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetSpeakerVolume_Click(object sender, EventArgs e)
        {
            try
            {
                int iVolume = Module.Module.GetSpeakerVolume();
                sMsg = "SpeakerVolume:" + iVolume.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                tbSpeakerVolume.Text = iVolume.ToString();

            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void menuItem_Module_SetSpeakerVolume_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbSpeakerVolume.Text))
                {
                    int iVolume = int.Parse(tbSpeakerVolume.Text.Trim());
                    bool bRet = Module.Module.SetSpeakerVolume(iVolume);

                    sMsg = "SetSpeakerVolume:" + bRet.ToString();
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }

            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetMicVolume_Click(object sender, EventArgs e)
        {
            try
            {
                int iVolume = Module.Module.GetMicVolume();
                sMsg = "SpeakerVolume:" + iVolume.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                tbMicVolume.Text = iVolume.ToString();

            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_SetMicVolume_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbMicVolume.Text))
                {
                    int iVolume = int.Parse(tbMicVolume.Text.Trim());
                    bool bRet = Module.Module.SetMicVolume(iVolume);

                    sMsg = "SetSpeakerVolume:" + bRet.ToString();
                    this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

                }

            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetEVDOMode_Click(object sender, EventArgs e)
        {
            try
            {
                EVDOMode mode = Module.EVDO.GetNetWorkMode();

                sMsg = "GetNetWorkMode:" + mode.ToString();
                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

            }
            catch (System.Exception ex)
            {

            }
        }

        private void menuItem_Module_GetEVDOLocationInfo_Click(object sender, EventArgs e)
        {
            try
            {
                EVDOLocationInfo lacInfo = Module.EVDO.GetEVDOLocationInfo();

                sMsg = "GetEVDOLocationInfo: lat:" 
                    + lacInfo.dwBaseLatitude.ToString()+"long:"+lacInfo.dwBaseLongitude.ToString()
                    + " lat(degress):" + ((double)lacInfo.dwBaseLatitude/14400).ToString() + "long(degress)::" + ((double)lacInfo.dwBaseLongitude/14400).ToString();

                this.Invoke(new RefreshMessageHandle(RefreshMessage), new object[] { sMsg });

            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
