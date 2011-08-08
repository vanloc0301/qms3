#region 库文件声明

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

#endregion

namespace QMS3.OperateAndValidate
{
    class OperateAndValidate
    {
        QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();//声明BaseOperate类的一个对象，以调用其方法

        #region  绑定ComboBox控件
        /// <summary>
        /// 对ComboBox控件进行数据绑定
        /// </summary>
        /// <param name="PStrSQLStr">SQL语句</param>
        /// <param name="PStrTable">表名</param>
        /// <param name="PStrTBMember">数据表中字段名</param>
        /// <param name="cbox">ComboBox控件ID</param>
        public void cboxBind(string PStrSQLStr, string PStrTable, string PStrTBMember, ComboBox cbox)
        {
            DataSet myds = boperate.getds(PStrSQLStr, PStrTable);
            cbox.DataSource = myds.Tables[PStrTable];
            cbox.DisplayMember = PStrTBMember;
        }
        #endregion

        #region  验证输入字符串为数字
        /// <summary>
        /// 验证输入字符串为数字
        /// </summary>
        /// <param name="PStrNum">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateNum(string PStrNum)
        {
            return Regex.IsMatch(PStrNum, "^[0-9]*$");
        }
        #endregion

        #region  验证输入字符串为车牌号
        /// <summary>
        /// 验证输入字符串为车牌号
        /// </summary>
        /// <param name="PStrNum">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateTruckNo(string PStrNum)
        {
            //return Regex.IsMatch(PStrNum, "^([京]|[A-Z]){1,2}[A-Za-z0-9]{1,2}[0-9A-Za-z]{5}$");
            return Regex.IsMatch(PStrNum, "^[\u4e00-\u9fa5]{1}[A-Z]{1}[0-9A-Za-z]{5}$");
        }
        #endregion

        #region  验证输入字符串为卡号
        /// <summary>
        /// 验证输入字符串为卡号
        /// </summary>
        /// <param name="PStrNum">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateCNo(string PStrNum)
        {
            return Regex.IsMatch(PStrNum, "^[A-F0-9]*$");
        }
        #endregion

        #region  验证输入字符串为汉字
        /// <summary>
        /// 验证输入字符串为汉字
        /// </summary>
        /// <param name="PStrNum">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateStation(string PStrNum)
        {
            return Regex.IsMatch(PStrNum, "^[\u4e00-\u9fa5]*$");
        }
        #endregion

        #region  验证输入字符串为字母
        /// <summary>
        /// 验证输入字符串为字母
        /// </summary>
        /// <param name="PStrNum">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateIdent(string PStrNum)
        {
            return Regex.IsMatch(PStrNum, "^[1-9A-Za-z\u4e00-\u9fa5]*$");
        }
        #endregion
    }
}
