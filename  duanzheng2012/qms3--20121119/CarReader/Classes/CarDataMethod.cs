using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarReader.Classes;
using CarReader;

namespace System.Collections.Generic
{
    public static class CarDataMethod
    {
        //返回值0表示该车第一次刷卡，1表示该车为下行，2表示该卡重复刷
        public static bool GetDataStatus(this List<CarControl> datas, CarData data)
        {
            for (int i=0;i<CommonData.datas.Count;i++)
            {
                CarControl item = CommonData.datas[i];
                if (item.isMyCar(data))
                    return true;
            }
            return false;
        }
    }
}
