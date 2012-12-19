using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarReader.Classes
{
    public static class GetStableWeight
    {
        public static System.Collections.ArrayList myarray = new System.Collections.ArrayList();
        const int length = 30;
        const int stablegate = 6;//稳定指数
        static int zeroCount = 0;
        public static int tag = 0;
        class elementcounter
        {
            public double value = 0;
            public double b1 = 0;
            public double b2 = 0;
            public int num = 0;
        }
        //每次串口读到数字 都要insert

        public static void insert(double thisweight)
        {

            lock (myarray)
            {
                if (thisweight == 0)
                    zeroCount++;
                else
                    zeroCount = 0;
                if (zeroCount >= 5 && tag == 0)
                    myarray.Clear();
                if (myarray.Count > length)
                {
                    myarray.Add(thisweight);
                    myarray.RemoveAt(0);
                }
                else
                {
                    myarray.Add(thisweight);
                }
            }

        }
        // state 为标志位
        // state =0 表示正常拿到稳定值
        // state =1 表示拿到了最大值，但不稳定
        // state =2 表示队列为空，
        // state =3 队列里都是无意义小数
        // state =4 未知
        public static double getstable(ref int state)
        {

            if (myarray.Count <= 0)
            {
                state = 2;
                return 0;
            }

            System.Collections.ArrayList mystatement = new System.Collections.ArrayList();

            foreach (double x in myarray)
            {
                bool getit = false;
                if (x <= 3)//过滤掉没用的小数
                    continue;
                foreach (elementcounter e in mystatement)//统计出现的次数
                {
                    if (e.value == x)
                    {
                        e.num++;
                        getit = true;
                        break;
                    }
                }
                if (getit == false)
                {
                    elementcounter ee = new elementcounter();
                    ee.value = x;
                    ee.num = 1;
                    mystatement.Add(ee);
                }
            }
            if (mystatement.Count == 0)
            {
                state = 3;
                return 0;

            }

            int position = 0;
            int max = ((elementcounter)(mystatement[0])).num;
            int maxposition = 0;
            foreach (elementcounter e in mystatement)// 统计出现最多的数字
            {
                if (e.num >= max)
                {
                    max = e.num;
                    maxposition = position;
                }
                position++;
            }
            if (max >= stablegate)//获得稳定值
            {
                state = 0;
                return ((elementcounter)(mystatement[maxposition])).value;

            }
            else// 获得队列里的最大值
            {
                double maxv = 0;
                foreach (double x in myarray)
                {
                    if (x > maxv)
                        maxv = x;
                }
                state = 1;
                return maxv;
            }

        }


    }
    public static class GetStableWeightUp
    {
        public static System.Collections.ArrayList myarray = new System.Collections.ArrayList();
        const int length = 30;
        const int stablegate = 6;//稳定指数
        static int zeroCount = 0;
        public static int tag = 0;
        class elementcounter
        {
            public double value = 0;
            public int num = 0;
        }
        //每次串口读到数字 都要insert
        public static void insert(double thisweight)
        {
            lock (myarray)
            {
                if (thisweight == 0)
                    zeroCount++;
                else
                    zeroCount = 0;
                if (zeroCount >= 5 && tag == 0)
                    myarray.Clear();
                if (myarray.Count > length)
                {
                    myarray.Add(thisweight);
                    myarray.RemoveAt(0);
                }
                else
                {
                    myarray.Add(thisweight);
                }
            }


        }
        // state 为标志位
        // state =0 表示正常拿到稳定值
        // state =1 表示拿到了最大值，但不稳定
        // state =2 表示队列为空，
        // state =3 队列里都是无意义小数
        // state =4 未知
        public static double getstable(ref int state)
        {

            if (myarray.Count <= 0)
            {
                state = 2;
                return 0;
            }

            System.Collections.ArrayList mystatement = new System.Collections.ArrayList();

            foreach (double x in myarray)
            {
                bool getit = false;
                if (x <= 4)//过滤掉没用的小数
                    continue;
                foreach (elementcounter e in mystatement)//统计出现的次数
                {
                    if (e.value == x)
                    {
                        e.num++;
                        getit = true;
                        break;
                    }
                }
                if (getit == false)
                {
                    elementcounter ee = new elementcounter();
                    ee.value = x;
                    ee.num = 1;
                    mystatement.Add(ee);
                }
            }
            if (mystatement.Count == 0)
            {
                state = 3;
                return 0;

            }

            int position = 0;
            int max = ((elementcounter)(mystatement[0])).num;
            int maxposition = 0;
            foreach (elementcounter e in mystatement)// 统计出现最多的数字
            {
                if (e.num >= max)
                {
                    max = e.num;
                    maxposition = position;
                }
                position++;
            }
            if (max >= stablegate)//获得稳定值
            {
                state = 0;
                return ((elementcounter)(mystatement[maxposition])).value;

            }
            else// 获得队列里的最大值
            {
                double maxv = 0;
                foreach (double x in myarray)
                {
                    if (x > maxv)
                        maxv = x;
                }
                state = 1;
                return maxv;
            }


        }

    }
}
