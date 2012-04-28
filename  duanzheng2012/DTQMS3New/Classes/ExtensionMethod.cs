using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data
{
    public static class ExtensionMethod
    {
        public static object GetValueByKey(this DataTable table,string key,object value,string valueKey)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row[key].ToString() == value.ToString())
                    return row[valueKey];
            }
            return null;
        }
    }
}
