using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Runtime.InteropServices;
using System.Diagnostics;


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Office.Interop;
using Microsoft.Office.Core;
using System.Threading;

namespace QMS3.Classes
{
    class ChartData
    {
        public DateTime yeardatetime;
        public double[] year;
        public double[] lastyear;

        public double[] month;
        public double[] lastmonth;
        public double[] lastyearmonth;

        public int stationID;
        public DateTime monthdatetime;
        public double[] stationyear;
        public double[] stationlastyear;

        public double[] stationmonth;
        public double[] stationlastmonth;
        public double[] stationlastyearmonth;

        public int[] stationdaybox;

        private int[] PercentOfThread;


        public ChartData()
        {
            this.year = new double[12];
            this.lastyear = new double[12];
            this.stationyear = new double[12]; ;
            this.stationlastyear = new double[12]; 
           
            for (int i = 0; i <= 11; i++)
            {
                this.year[i] = 0;
                this.lastyear[i] = 0;
                this.stationyear[i] = 0;
                this.stationlastyear[i] = 0;
            }
            this.month = new double[31];
            this.lastmonth = new double[31]; ;
            this.lastyearmonth = new double[31];
            this.stationmonth = new double[31];
            this.stationlastmonth = new double[31];
            this.stationlastyearmonth = new double[31]; 
            for (int i = 0; i <= 30; i++)
            {
                this.month[i] = 0;
                this.lastmonth[i] = 0;
                this.lastyearmonth[i] = 0;
                this.stationmonth[i] = 0;
                this.stationlastmonth[i] = 0;
                this.stationlastyearmonth[i] = 0;
            }

            this.PercentOfThread = new int[5];

            for (int i = 0; i <= 4; i++)
            {
                this.PercentOfThread[i] = 100;
            }
            this.stationdaybox = new int[16];
            for (int i = 0; i <= 15; i++)
            {
                this.stationdaybox[i] =0;
            }
        }
        public int Get_Percent(int Task)
        {
            return this.PercentOfThread[Task];
        }
        public int updateData(int Case,DateTime dt,int stationID)
        { 
            string SQL;
            switch (Case)
            {
                case 1://年
                    {
                        {
                            DataSet ds;
                            string sttime = dt.ToString("yy");
                            string strSQL = "DECLARE	@return_value int EXEC	@return_value = [rfidtest].[GetCenterYearCount] @year = N'" + sttime + "',@station = 0";
                            string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
                        
                            try
                            {
                                QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();
                                ds = boperate.getds(strSQL, strTable);
                            }
                            catch
                            {
                                MessageBox.Show("网络连接失败！请稍后重试（错误 10273）");
                                return 1;
                            }
                            try
                            {

                                for (int i = 0; i <= 11; i++)
                                {
                                    this.year[i] = int.Parse(ds.Tables[0].Rows[i]["sumbox"].ToString());
                                }

                            }
                            catch (Exception xx)
                            {
                                MessageBox.Show("网络连接失败！请稍后重试（错误1027）" + xx.ToString());
                                return 1;
                            }

                            return 0;
                        }
                        break;
                    }
                case 2://去年
                    {
                        {
                            DataSet ds;

                            string sttime = dt.AddMonths(-12).ToString("yy");
                            string strSQL = "DECLARE	@return_value int EXEC	@return_value = [rfidtest].[GetCenterYearCount] @year = N'" + sttime + "',@station = 0";
                            string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
                           // MessageBox.Show(strSQL);
                            try
                            {
                                QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();
                                ds = boperate.getds(strSQL, strTable);
                            }
                            catch
                            {
                                MessageBox.Show("网络连接失败！请稍后重试（错误 10273）");
                                return 1;
                            }
                            try
                            {

                                for (int i = 0; i <= 11; i++)
                                {
                                    this.lastyear[i] = int.Parse(ds.Tables[0].Rows[i]["sumbox"].ToString());
                                }

                            }
                            catch (Exception xx)
                            {
                                MessageBox.Show("网络连接失败！请稍后重试（错误1027）" + xx.ToString());
                                return 1;
                            }

                            return 0;
                        }
                        break;
                    }
                case 3://月
                    {
                        DataSet ds;
                        string sttime = dt.ToString("yy-MM");
                        string strSQL = "DECLARE	@return_value int EXEC	@return_value = [rfidtest].[GetCenterMonthCount] @Month = N'" + sttime + "',@numofday="+QMS3.Classes.Datetimecalc.daysofmonth(dt).ToString()+",@station = 0";
                        string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
                        // MessageBox.Show(strSQL);
                        try
                        {
                            QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();
                            ds = boperate.getds(strSQL, strTable);
                        }
                        catch
                        {
                            MessageBox.Show("网络连接失败！请稍后重试（错误 10273）");
                            return 1;
                        }
                        try
                        {

                            for (int i = 0; i <QMS3.Classes.Datetimecalc.daysofmonth(dt); i++)
                            {
                                this.month[i] = int.Parse(ds.Tables[0].Rows[i]["sumbox"].ToString());
                            }

                        }
                        catch (Exception xx)
                        {
                            MessageBox.Show("网络连接失败！请稍后重试（错误10271）" + xx.ToString());
                            return 1;
                        }

                        return 0;
                        break;
                    }
                case 4://上月
                    {
                        DataSet ds;
                        string sttime = dt.AddMonths(-1).ToString("yy-MM");
                        string strSQL = "DECLARE	@return_value int EXEC	@return_value = [rfidtest].[GetCenterMonthCount] @Month = N'" + sttime + "',@numofday=" + QMS3.Classes.Datetimecalc.daysofmonth(dt).ToString() + ",@station = 0";
                        string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
                        // MessageBox.Show(strSQL);
                        try
                        {
                            QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();
                            ds = boperate.getds(strSQL, strTable);
                        }
                        catch
                        {
                            MessageBox.Show("网络连接失败！请稍后重试（错误 10273）");
                            return 1;
                        }
                        try
                        {

                            for (int i = 0; i < QMS3.Classes.Datetimecalc.daysofmonth(dt); i++)
                            {
                                this.lastmonth[i] = int.Parse(ds.Tables[0].Rows[i]["sumbox"].ToString());
                            }

                        }
                        catch (Exception xx)
                        {
                            MessageBox.Show("网络连接失败！请稍后重试（错误10271）" + xx.ToString());
                            return 1;
                        }

                        return 0;
                        break; ;
                    }
                case 6://上12月
                    {
                        DataSet ds;
                        string sttime = dt.AddMonths(-12).ToString("yy-MM");
                        string strSQL = "DECLARE	@return_value int EXEC	@return_value = [rfidtest].[GetCenterMonthCount] @Month = N'" + sttime + "',@numofday=" + QMS3.Classes.Datetimecalc.daysofmonth(dt).ToString() + ",@station = 0";
                        string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
                        // MessageBox.Show(strSQL);
                        try
                        {
                            QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();
                            ds = boperate.getds(strSQL, strTable);
                        }
                        catch
                        {
                            MessageBox.Show("网络连接失败！请稍后重试（错误 10273）");
                            return 1;
                        }
                        try
                        {

                            for (int i = 0; i < QMS3.Classes.Datetimecalc.daysofmonth(dt); i++)
                            {
                                this.lastmonth[i] = int.Parse(ds.Tables[0].Rows[i]["sumbox"].ToString());
                            }

                        }
                        catch (Exception xx)
                        {
                            MessageBox.Show("网络连接失败！请稍后重试（错误10271）" + xx.ToString());
                            return 1;
                        }

                        return 0;
                        break;
                    }
                case 5://站状态
                    {
                       
                        {
                            DataSet ds;
                            string sttime = dt.ToString("yy-MM-dd");
                            string strSQL = "DECLARE	@return_value int EXEC	@return_value = [rfidtest].[GetStationDetailbyDay] @day = N'" + sttime + "'";
                            string strTable = " [db_rfidtest].[rfidtest].[dbo.goods]";
                           // MessageBox.Show(strSQL);
                            try
                            {
                                QMS3.BaseClass.BaseOperate boperate = new QMS3.BaseClass.BaseOperate();
                                ds = boperate.getds(strSQL, strTable);
                            }
                            catch
                            {
                                MessageBox.Show("网络连接失败！请稍后重试（错误 10273）");
                                return 1;
                            }
                            try
                            {

                                for (int i = 0; i <= 15; i++)
                                {
                                    this.stationdaybox[i] = int.Parse(ds.Tables[0].Rows[i]["sumbox"].ToString() );
                                }

                            }
                            catch (Exception xx)
                            {
                                MessageBox.Show("网络连接失败！请稍后重试（错误1027）" + xx.ToString());
                                return 1;
                            }

                            return 0;
                        }
                        break;
                    }
                default:
                    {
                        return 2;
                        break;
                    }
                  
            }
            return 0;
        }
        

    }
}
