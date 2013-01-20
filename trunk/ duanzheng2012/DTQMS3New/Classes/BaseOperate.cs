﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace DTQMS3New.Classes
{
    class BaseOperate
    {
        #region  建立数据库连接 getcon()
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        /// 

        public SqlConnection getcon()
        {
            //SQL Server服务器登录方式：Windows登录方式，本地登录
            //  string MStrSQLCon = "Data Source=localhost;User Id=;Password=;packet size=4096;Database=TranspoartSystem;Integrated Security=True";
            string MStrSQLCon = "Data Source=db113.72dns.net;User Id=rfidtest;Password=123456;packet size=4096;Database=db_rfidtest";
            //SQL Server服务器登录方式：SQL Server登录方式，远程登录，IP地址在Data Source中修改，用户名在User Id中修改，密码在Password中修改
            //  string MStrSQLCon = "Data Source=192.168.0.104;User Id=myt;Password=xiaoyuemian;packet size=4096;Database=TransportSystem;Integrated Security=True";

            SqlConnection myCon = new SqlConnection(MStrSQLCon);
            return myCon;
        }
        #endregion

        #region  执行SqlCommand命令 getcom调用了getcon
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public bool getcom(string MStrSQLStr)
        {
            try
            {
                SqlConnection sqlcon = this.getcon();
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(MStrSQLStr, sqlcon);
                int r = sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
                if (r > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region  创建DataSet对象（调用getcon）
        /// <summary>
        /// 创建一个DataSet对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <param name="M_str_table">表名</param>
        /// <returns>返回DataSet对象</returns>
        public DataSet getds(string MStrSQLStr, string MStrTable)
        {
            SqlConnection sqlcon = this.getcon();
            SqlDataAdapter sqlda = new SqlDataAdapter(MStrSQLStr, sqlcon);
            DataSet myds = new DataSet();
            Control.CheckForIllegalCrossThreadCalls = false;

            try
            {
                sqlda.Fill(myds, MStrTable);
                CommonData.errorLabel.Text = "";
                
            }
            catch(Exception e)
            {
                CommonData.errorLabel.Text = "网络异常！";
                MessageBox.Show(e.Message);
            }
            return myds;
        }
        #endregion

        #region  创建SqlDataReader对象
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public SqlDataReader getread(string MStrSQLStr)
        {
            SqlConnection sqlcon = this.getcon();
            SqlCommand sqlcom = new SqlCommand(MStrSQLStr, sqlcon);
            sqlcon.Open();
            SqlDataReader sqlread = sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlread;
        }
        #endregion
    }
}