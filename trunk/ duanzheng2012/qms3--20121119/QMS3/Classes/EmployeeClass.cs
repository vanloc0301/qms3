using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QMS3.Classes
{
    public class EmployeeClass
    {
        private string employee;

        public string Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        private int stationID;

        public int StationID
        {
            get { return stationID; }
            set { stationID = value; }
        }
    }
}
