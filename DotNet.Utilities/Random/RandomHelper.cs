/// <summary>
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// 使用Random類生成偽隨機數
    /// </summary>
    public class RandomHelper
    {
        #region 生成一個指定範圍的隨機整數
        /// <summary>
        /// 生成一個指定範圍的隨機整數，該隨機數範圍包括最小值，但不包括最大值
        /// </summary>
        /// <param name="minNum">最小值</param>
        /// <param name="maxNum">最大值</param>
        public static int GetRandomInt(int minNum, int maxNum)
        {
            var random = new Random();
            return random.Next(minNum, maxNum);
        }
        #endregion

        #region 生成一個0.0到1.0的隨機小數
        /// <summary>
        /// 生成一個0.0到1.0的隨機小數
        /// </summary>
        public static double GetRandomDouble()
        {
            var random = new Random();
            return random.NextDouble();
        }
        #endregion

        #region 對一個數組進行隨機排序
        /// <summary>
        /// 對一個數組進行隨機排序
        /// </summary>
        /// <typeparam name="T">數組的類型</typeparam>
        /// <param name="arr">需要隨機排序的數組</param>
        public static void GetRandomArray<T>(T[] arr)
        {
            //對數組進行隨機排序的算法:隨機選擇兩個位置，將兩個位置上的值交換

            //交換的次數,這裡使用數組的長度作為交換次數
            int count = arr.Length;

            //開始交換
            for (int i = 0; i < count; i++)
            {
                //生成兩個隨機數位置
                int randomNum1 = GetRandomInt(0, arr.Length);
                int randomNum2 = GetRandomInt(0, arr.Length);

                //定義臨時變量
                T temp;

                //交換兩個隨機數位置的值
                temp = arr[randomNum1];
                arr[randomNum1] = arr[randomNum2];
                arr[randomNum2] = temp;
            }
        }


        // 一：隨機生成不重複數字字符串 
        private static int rep = 0;
        public static string GenerateCheckCodeNum(int codeCount)
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }
            return str;
        }

        //方法二：隨機生成字符串（數字和字母混和）
        public static string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        #endregion

        #region 從字符串裡隨機得到，規定個數的字符串.
        /// <summary>
        /// 從字符串裡隨機得到，規定個數的字符串.
        /// </summary>
        /// <param name="allChar">字符規範，如果等於null時，默認值為："1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z"</param>
        /// <param name="codeCount">需要生成的隨機數個數</param>
        /// <returns></returns>
        public static string GetRandomCode(string allChar, int codeCount)
        {
            if (string.IsNullOrEmpty(allChar))
            {
                allChar = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            }
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            var rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(allCharArray.Length - 1);

                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }

                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        #endregion


        #region 隨機數操作函數
        /// <summary>取得隨機數(數字),用yyMMddhhmmss + (xxx),共15位數字</summary>
        /// <returns></returns>
        public static string GetDateRnd()
        {
            DateTime dtTmp = DateTime.Now;
            return dtTmp.ToString("yyMMddhhmmss") + GetRndNum(3);
        }

        /// <summary> 取得隨機數(字母+數字),用yyMMddhhmmss + (xxx),共15位字母或數字,</summary>
        /// <returns></returns>
        public static string GetRndKey()
        {
            DateTime dtTmp = DateTime.Now;
            return dtTmp.ToString("yyMMddhhmmss") + GetRndNum(3, true);
        }

        /// <summary> 取得n位隨機整數,:45546</summary>
        /// <param name="n">隨機數長度</param>
        /// <param name="isStr">true=隨機字母和整數，false=隨機整數</param>
        /// <returns></returns>
        public static string GetRndNum(int n, bool isStr = false)
        {
            string cChar = "0123456789";
            if (isStr)
            {
                cChar = "abcdefghijklmnopqrstuvwxyz0123456789";
            }

            int cLen = cChar.Length;
            string sRet = "";
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < n; i++)
            {
                sRet += cChar[rnd.Next(0, cLen)].ToString();
            }
            return sRet;
        }

        /// <summary>取得區間中的隨機數,例如:getRndNext(14,17),將返回14,15,16</summary>
        /// <param name="min">隨機數的最小值</param> 
        /// <param name="max">隨機數的最大值(結果小於該值)</param> 
        /// <returns></returns>
        public static int GetRndNext(int min, int max)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            int t = 0;
            if (min > max)
            {
                t = min;
                min = max;
                max = t;
            }

            t = max - min;
            return rnd.Next(t) + min;
        }

        /// <summary>取得區間中的隨機數,例如:getRndNext(14,17),將返回14,15,16</summary>
        /// <param name="min">隨機數的最小值</param> 
        /// <param name="max">隨機數的最大值(結果小於該值)</param> 
        /// <returns></returns>
        public static decimal GetRndNextDecimal(decimal min, decimal max)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            decimal t = 0;
            if (min > max)
            {
                t = min;
                min = max;
                max = t;
            }

            t = max - min;
            return (decimal)rnd.NextDouble() * t + min;
        }
        #endregion
    }
}
