using System;
namespace SEUIC.Phone.Tester
{
    partial class MainFrm
    {
        private delegate void RefreshMessageHandle(string sMsgContent);

        private delegate void RefreshMessageNoTimeHandle(string sSMSContent, bool isShowTime);

        private void RefreshMessage(string sMsgContent)
        {
            ShowMessage(sMsgContent.ToString());
        }

        private void RefreshMessageNoTime(string sMsgContent, bool isShowTime)
        {
            ShowMessage(sMsgContent.ToString(),isShowTime);
        }

        private delegate void RefreshSMSContentHandle(string sSMSContent);


        private void RefreshSMSContent(string sSMSContent)
        {
            tbSMSContent.Text = sSMSContent;
        }

        private void ShowMessage(string sMsg)
        {
            ShowMessage(sMsg, true);
        }

        private void ShowMessage(string sMsg, bool isShowTime)
        {
            tbMessage.Text = (isShowTime ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " \r\n" : "") + sMsg + "\r\n" + tbMessage.Text;
        }
    }
}
