using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QMS3.Classes
{
    class Datetimecalc
    {
        static public int daysofmonth(DateTime dt)
        {
            DateTime date = dt;
            int tday = dt.Day;
            tday--;
            tday = tday * -1;
            date=date.AddDays(tday);
            int i;
            for (i = 28; i <= 30; i++)
            {
                DateTime tempdate = date;  
                if (tempdate.AddDays(i).Month > date.Month)
                    return i;
            }
            return i;
        }
    }
}
