using System;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// 時間類
    /// 1、SecondToMinute(int Second) 把秒轉換成分鐘
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// 返回每月的第一天和最後一天
        /// </summary>
        /// <param name="month"></param>
        /// <param name="firstDay"></param>
        /// <param name="lastDay"></param>
        public static void ReturnDateFormat(int month, out string firstDay, out string lastDay)
        {
            int year = DateTime.Now.Year + month / 12;
            if (month != 12)
            {
                month = month % 12;
            }
            switch (month)
            {
                case 1:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 2:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    if (DateTime.IsLeapYear(DateTime.Now.Year))
                        lastDay = DateTime.Now.ToString(year + "-0" + month + "-29");
                    else
                        lastDay = DateTime.Now.ToString(year + "-0" + month + "-28");
                    break;
                case 3:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString("yyyy-0" + month + "-31");
                    break;
                case 4:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-30");
                    break;
                case 5:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 6:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-30");
                    break;
                case 7:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 8:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-31");
                    break;
                case 9:
                    firstDay = DateTime.Now.ToString(year + "-0" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-0" + month + "-30");
                    break;
                case 10:
                    firstDay = DateTime.Now.ToString(year + "-" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-" + month + "-31");
                    break;
                case 11:
                    firstDay = DateTime.Now.ToString(year + "-" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-" + month + "-30");
                    break;
                default:
                    firstDay = DateTime.Now.ToString(year + "-" + month + "-01");
                    lastDay = DateTime.Now.ToString(year + "-" + month + "-31");
                    break;
            }
        }
        /// <summary>
        /// 將時間格式化成 年月日 的形式,如果時間為null，返回當前系統時間
        /// </summary>
        /// <param name="dt">年月日分隔符</param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public string GetFormatDate(DateTime dt, char Separator)
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("yyyy{0}MM{1}dd", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        /// <summary>
        /// 將時間格式化成 時分秒 的形式,如果時間為null，返回當前系統時間
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public string GetFormatTime(DateTime dt, char Separator) {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("hh{0}mm{1}ss", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        /// <summary>
        /// 把秒轉換成分鐘
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        #region 返回某年某月最後一天

        /// <summary>
        /// 返回某個日期的當月最後一天
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <returns>日</returns>
        public static DateTime GetMonthLastDate(DateTime dateTime)
        {
            DateTime lastDay = new DateTime(dateTime.Year, dateTime.Month, new System.Globalization.GregorianCalendar().GetDaysInMonth(dateTime.Year, dateTime.Month));
            return lastDay;
        }
        #endregion

        #region 返回某年某月最後一天
        /// <summary>
        /// 返回某年某月最後一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 返回時間差
        public static string DateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(dateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(dateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = dateTime2 - dateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = dateTime1.Month.ToString() + "月" + dateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小時前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分鐘前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }

        /// <summary>時間比較函數，返回兩個日期相差幾秒、幾分鐘、幾小時或幾天</summary>
        /// <param name="sInterval"> y = 年, m =月, d = 日, w = 周, q = 季, h = 時, n = 分鐘, s = 秒 </param>
        /// <param name="StartDate">日期</param>
        /// <param name="EndDate">日期</param>
        /// <returns></returns>
        public static long DateDiff(string sInterval, DateTime StartDate, DateTime EndDate)
        {
            long lngRet = 0;
            TimeSpan TS = new TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (sInterval)
            {
                case "s": lngRet = (long)TS.TotalSeconds; break;
                case "n": lngRet = (long)TS.TotalMinutes; break;
                case "h": lngRet = (long)TS.TotalHours; break;
                case "d": lngRet = (long)TS.Days; break;
                case "w": lngRet = (long)(TS.Days / 7); break;
                case "m": lngRet = (long)(TS.Days / 30); break;
                case "q": lngRet = (long)((TS.Days / 30) / 3); break;
                case "y": lngRet = (long)(TS.Days / 365); break;
            }
            return (lngRet);
        }
        #endregion

        #region 獲得兩個日期的間隔
        /// <summary>
        /// 獲得兩個日期的間隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期間隔TimeSpan。</returns>
        public static TimeSpan DateDiff2(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }

        #endregion

        #region 格式化日期時間
        /// <summary>
        /// 格式化日期時間
        /// </summary>
        /// <param name="dateTime1">日期時間</param>
        /// <param name="dateMode">顯示模式</param>
        /// <returns>0-9種模式的日期</returns>
        public static string FormatDate(DateTime dateTime1, string dateMode)
        {
            switch (dateMode)
            {
                case "0":
                    return dateTime1.ToString("yyyy-MM-dd");
                case "1":
                    return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dateTime1.ToString("yyyy/MM/dd");
                case "3":
                    return dateTime1.ToString("yyyy年MM月dd日");
                case "4":
                    return dateTime1.ToString("MM-dd");
                case "5":
                    return dateTime1.ToString("MM/dd");
                case "6":
                    return dateTime1.ToString("MM月dd日");
                case "7":
                    return dateTime1.ToString("yyyy-MM");
                case "8":
                    return dateTime1.ToString("yyyy/MM");
                case "9":
                    return dateTime1.ToString("yyyy年MM月");
                default:
                    return dateTime1.ToString();
            }
        }
        #endregion

        #region 得到隨機日期
        /// <summary>
        /// 得到隨機日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">結束日期</param>
        /// <returns>間隔日期之間的 隨機日期</returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();

            System.TimeSpan ts = new System.TimeSpan(time1.Ticks - time2.Ticks);

            // 獲取兩個時間相隔的秒數
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue + 1;

            int i = random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }
        #endregion

        #region 把字符串轉成日期型
        /// <summary> 把字符串轉成日期型 </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static DateTime CDate(string str)
        {
            if (!IsDateTime(str))
            {
                return GetMinDate();
            }
            return DateTime.Parse(str);
        }

        /// <summary> 把字符串轉成日期型 </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static DateTime CDate(object str)
        {
            if (str == null)
            {
                return GetMinDate();
            }
            return CDate(str.ToString());
        }
        #endregion

        #region 判斷時間
        /// <summary>返回 Boolean 值指明某表達式是否可以轉換為時間。</summary>
        /// <param name="timeval">時間字符串</param>
        /// <returns></returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        /// <summary>返回 Boolean 值指明某表達式是否可以轉換為日期。</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(string str)
        {
            bool bRet = false;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            try
            {
                DateTime dt = DateTime.Parse(str);
                bRet = true;
            }
            catch
            {
                bRet = false;
            }
            return bRet;
        }

        /// <summary>返回 Boolean 值指明某表達式是否可以轉換為日期。</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(object str)
        {
            if (str != null)
            {
                return IsDateTime(str.ToString());
            }
            return false;
        }
        #endregion

        #region 系統默認最少時間
        /// <summary>系統默認最少時間</summary>
        /// <returns></returns>
        public static DateTime GetMinDate()
        {
            return new DateTime(1900, 1, 1);
        }
        #endregion

        /// <summary>
        /// Millis the time stamp.
        /// </summary>
        /// <param name="theDate">The date.</param>
        /// <returns></returns>
        public static long MilliTimeStamp(DateTime theDate)
        {
            DateTime d = theDate.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d.Ticks - GetMinDate().Ticks);
            return (long)ts.TotalMilliseconds;
        }
        /// <summary>
        /// Gets the time zone.
        /// </summary>
        /// <returns></returns>
        public static int GetTimeZone()
        {
            DateTime now = DateTime.Now;
            var utcnow = now.ToUniversalTime();

            var sp = now - utcnow;

            return sp.Hours;
        }
    }
}
