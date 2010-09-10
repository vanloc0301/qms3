using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QMS3.Classes
{
    class ChartData
    {
        
        public double[] year;
        public double[] lastyear;

        public double[] month;
        public double[] lastmonth;
        public double[] lastyearmonth;

        public double[] stationyear;
        public double[] stationlastyear;

        public double[] stationmonth;
        public double[] stationlastmonth;
        public double[] stationlastyearmonth;

        public int[] stationdaybox;

        private int[] PercentOfThread;


        public ChartData()
        {
            for (int i = 0; i <= 11; i++)
            {
                this.year[i] = 0;
                this.lastyear[i] = 0;
                this.stationyear[i] = 0;
                this.stationlastyear[i] = 0;
            }
            for (int i = 0; i <= 31; i++)
            {
                this.month[i] = 0;
                this.lastmonth[i] = 0;
                this.lastyearmonth[i] = 0;
                this.stationmonth[i] = 0;
                this.stationlastmonth[i] = 0;
                this.stationlastyearmonth[i] = 0;
            }
            for (int i = 0; i <= 4; i++)
            {
                this.PercentOfThread[i] = 100;
            }
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
                        if (this.PercentOfThread[Case-1] < 100)
                            return 1;
                        break;
                    }
                case 2://月
                    {
                        if (this.PercentOfThread[Case - 1] < 100)
                            return 1;
                        break;
                    }
                case 3://站年
                    {
                        if (this.PercentOfThread[Case - 1] < 100)
                            return 1;
                        break;
                    }
                case 4://站月
                    {
                        if (this.PercentOfThread[Case - 1] < 100)
                            return 1;
                        break;
                    }
                case 5://站状态
                    {
                        if (this.PercentOfThread[Case - 1] < 100)
                            return 1;
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
