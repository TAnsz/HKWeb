/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// 農曆屬性
    /// </summary>
    public class CNDate
    {
        /// <summary>
        /// 農曆年(整型)
        /// </summary>
        public int cnIntYear = 0;
        /// <summary>
        /// 農曆月份(整型)
        /// </summary>
        public int cnIntMonth = 0;
        /// <summary>
        /// 農曆天(整型)
        /// </summary>
        public int cnIntDay = 0;
        /// <summary>
        /// 農曆年(支幹)
        /// </summary>
        public string cnStrYear = "";
        /// <summary>
        /// 農曆月份(字符)
        /// </summary>
        public string cnStrMonth = "";
        /// <summary>
        /// 農曆天(字符)
        /// </summary>
        public string cnStrDay = "";
        /// <summary>
        /// 農曆屬象
        /// </summary>
        public string cnAnm = "";
        /// <summary>
        /// 二十四節氣
        /// </summary>
        public string cnSolarTerm = "";
        /// <summary>
        /// 陰曆節日
        /// </summary>
        public string cnFtvl = "";
        /// <summary>
        /// 陽曆節日
        /// </summary>
        public string cnFtvs = "";
    }

    /// <summary>
    /// 公歷轉農曆
    /// </summary>
    public class ChinaDate
    {
        #region 私有方法
        private static long[] lunarInfo = new long[] { 0x04bd8, 0x04ae0, 0x0a570, 0x054d5, 0x0d260, 0x0d950, 0x16554,
															   0x056a0, 0x09ad0, 0x055d2, 0x04ae0, 0x0a5b6, 0x0a4d0, 0x0d250, 0x1d255, 0x0b540, 0x0d6a0, 0x0ada2, 0x095b0,
															   0x14977, 0x04970, 0x0a4b0, 0x0b4b5, 0x06a50, 0x06d40, 0x1ab54, 0x02b60, 0x09570, 0x052f2, 0x04970, 0x06566,
															   0x0d4a0, 0x0ea50, 0x06e95, 0x05ad0, 0x02b60, 0x186e3, 0x092e0, 0x1c8d7, 0x0c950, 0x0d4a0, 0x1d8a6, 0x0b550,
															   0x056a0, 0x1a5b4, 0x025d0, 0x092d0, 0x0d2b2, 0x0a950, 0x0b557, 0x06ca0, 0x0b550, 0x15355, 0x04da0, 0x0a5d0,
															   0x14573, 0x052d0, 0x0a9a8, 0x0e950, 0x06aa0, 0x0aea6, 0x0ab50, 0x04b60, 0x0aae4, 0x0a570, 0x05260, 0x0f263,
															   0x0d950, 0x05b57, 0x056a0, 0x096d0, 0x04dd5, 0x04ad0, 0x0a4d0, 0x0d4d4, 0x0d250, 0x0d558, 0x0b540, 0x0b5a0,
															   0x195a6, 0x095b0, 0x049b0, 0x0a974, 0x0a4b0, 0x0b27a, 0x06a50, 0x06d40, 0x0af46, 0x0ab60, 0x09570, 0x04af5,
															   0x04970, 0x064b0, 0x074a3, 0x0ea50, 0x06b58, 0x055c0, 0x0ab60, 0x096d5, 0x092e0, 0x0c960, 0x0d954, 0x0d4a0,
															   0x0da50, 0x07552, 0x056a0, 0x0abb7, 0x025d0, 0x092d0, 0x0cab5, 0x0a950, 0x0b4a0, 0x0baa4, 0x0ad50, 0x055d9,
															   0x04ba0, 0x0a5b0, 0x15176, 0x052b0, 0x0a930, 0x07954, 0x06aa0, 0x0ad50, 0x05b52, 0x04b60, 0x0a6e6, 0x0a4e0,
															   0x0d260, 0x0ea65, 0x0d530, 0x05aa0, 0x076a3, 0x096d0, 0x04bd7, 0x04ad0, 0x0a4d0, 0x1d0b6, 0x0d250, 0x0d520,
															   0x0dd45, 0x0b5a0, 0x056d0, 0x055b2, 0x049b0, 0x0a577, 0x0a4b0, 0x0aa50, 0x1b255, 0x06d20, 0x0ada0 };

        private static int[] year20 = new int[] { 1, 4, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1 };
        private static int[] year19 = new int[] { 0, 3, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0 };
        private static int[] year2000 = new int[] { 0, 3, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1 };
        private static String[] nStr1 = new String[] { "", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };
        private static String[] Gan = new String[] { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        private static String[] Zhi = new String[] { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        private static String[] Animals = new String[] { "鼠", "牛", "虎", "兔", "龍", "蛇", "馬", "羊", "猴", "雞", "狗", "豬" };
        private static String[] solarTerm = new String[] { "小寒", "大寒", "立春", "雨水", "驚蟄", "春分", "清明", "谷雨", "立夏", "小滿", "芒種", "夏至", "小暑", "大暑", "立秋", "處暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };
        private static int[] sTermInfo = { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        private static String[] lFtv = new String[] { "0101農曆春節", "0202 龍抬頭節", "0115 元宵節", "0505 端午節", "0707 七夕情人節", "0815 中秋節", "0909 重陽節", "1208 臘八節", "1114 李君先生生日", "1224 小年", "0100除夕" };
        private static String[] sFtv = new String[] { "0101 新年元旦",
														 "0202 世界濕地日",
														 "0207 國際聲援南非日",
														 "0210 國際氣象節",
														 "0214 情人節",
														 "0301 國際海豹日",
														 "0303 全國愛耳日",
														 "0308 國際婦女節",
														 "0312 植樹節 孫中山逝世紀念日",
														 "0314 國際警察日",
														 "0315 國際消費者權益日",
														 "0317 中國國醫節 國際航海日",
														 "0321 世界森林日 消除種族歧視國際日",
														 "0321 世界兒歌日",
														 "0322 世界水日",
														 "0323 世界氣象日",
														 "0324 世界防治結核病日",
														 "0325 全國中小學生安全教育日",
														 "0330 巴勒斯坦國土日",
														 "0401 愚人節 全國愛國衛生運動月(四月) 稅收宣傳月(四月)",
														 "0407 世界衛生日",
														 "0422 世界地球日",
														 "0423 世界圖書和版權日",
														 "0424 亞非新聞工作者日",
														 "0501 國際勞動節",
														 "0504 中國五四青年節",
														 "0505 碘缺乏病防治日",
														 "0508 世界紅十字日",
														 "0512 國際護士節",
														 "0515 國際家庭日",
														 "0517 世界電信日",
														 "0518 國際博物館日",
														 "0520 全國學生營養日",
														 "0523 國際牛奶日",
														 "0531 世界無煙日",
														 "0601 國際兒童節",
														 "0605 世界環境日",
														 "0606 全國愛眼日",
														 "0617 防治荒漠化和乾旱日",
														 "0623 國際奧林匹剋日",
														 "0625 全國土地日",
														 "0626 國際反毒品日",
														 "0701 中國共產黨建黨日 世界建築日",
														 "0702 國際體育記者日",
														 "0707 中國人民抗日戰爭紀念日",
														 "0711 世界人口日",
														 "0730 非洲婦女日",
														 "0801 中國建軍節",
														 "0808 中國男子節(爸爸節)",
														 "0815 日本正式宣佈無條件投降日",
														 "0908 國際掃盲日 國際新聞工作者日",
														 "0910 教師節",
														 "0914 世界清潔地球日",
														 "0916 國際臭氧層保護日",
														 "0918 九·一八事變紀念日",
														 "0920 全國愛牙日",
														 "0927 世界旅遊日",
														 "1001 國慶節 世界音樂日 國際老人節",
														 "1001 國際音樂日",
														 "1002 國際和平與民主自由鬥爭日",
														 "1004 世界動物日",
														 "1008 全國高血壓日",
														 "1008 世界視覺日",
														 "1009 世界郵政日 萬國郵聯日",
														 "1010 辛亥革命紀念日 世界精神衛生日",
														 "1013 世界保健日 國際教師節",
														 "1014 世界標準日",
														 "1015 國際盲人節(白手杖節)",
														 "1016 世界糧食日",
														 "1017 世界消除貧困日",
														 "1022 世界傳統醫藥日",
														 "1024 聯合國日 世界發展信息日",
														 "1031 世界勤儉日",
														 "1107 十月社會主義革命紀念日",
														 "1108 中國記者日",
														 "1109 全國消防安全宣傳教育日",
														 "1110 世界青年節",
														 "1111 國際科學與和平周(本日所屬的一周)",
														 "1112 孫中山誕辰紀念日",
														 "1114 世界糖尿病日",
														 "1117 國際大學生節 世界學生節",
														 "1121 世界問候日 世界電視日",
														 "1129 國際聲援巴勒斯坦人民國際日",
														 "1201 世界艾滋病日",
														 "1203 世界殘疾人日",
														 "1205 國際經濟和社會發展志願人員日",
														 "1208 國際兒童電視日",
														 "1209 世界足球日",
														 "1210 世界人權日",
														 "1212 西安事變紀念日",
														 "1213 南京大屠殺(1937年)紀念日！緊記血淚史！",
														 "1221 國際籃球日",
														 "1224 平安夜",
														 "1225 聖誕節",
														 "1226 毛主席誕辰",
														 "1229 國際生物多樣性日" };


        /// <summary>
        /// 傳回農曆y年的總天數
        /// </summary>
        private static int lYearDays(int y)
        {
            int i, sum = 348;
            for (i = 0x8000; i > 0x8; i >>= 1)
            {
                if ((lunarInfo[y - 1900] & i) != 0)
                    sum += 1;
            }
            return (sum + leapDays(y));
        }

        /// <summary>
        /// 傳回農曆y年閏月的天數
        /// </summary>
        private static int leapDays(int y)
        {
            if (leapMonth(y) != 0)
            {
                if ((lunarInfo[y - 1900] & 0x10000) != 0)
                    return 30;
                else
                    return 29;
            }
            else
                return 0;
        }

        /// <summary>
        /// 傳回農曆y年閏哪個月 1-12 , 沒閏傳回 0
        /// </summary>
        private static int leapMonth(int y)
        {
            return (int)(lunarInfo[y - 1900] & 0xf);
        }

        /// <summary>
        /// 傳回農曆y年m月的總天數
        /// </summary>
        private static int monthDays(int y, int m)
        {
            if ((lunarInfo[y - 1900] & (0x10000 >> m)) == 0)
                return 29;
            else
                return 30;
        }

        /// <summary>
        /// 傳回農曆y年的生肖
        /// </summary>
        private static String AnimalsYear(int y)
        {
            return Animals[(y - 4) % 12];
        }

        /// <summary>
        /// 傳入月日的offset 傳回干支,0=甲子
        /// </summary>
        private static String cyclicalm(int num)
        {
            return (Gan[num % 10] + Zhi[num % 12]);
        }

        /// <summary>
        /// 傳入offset 傳回干支, 0=甲子
        /// </summary>
        private static String cyclical(int y)
        {
            int num = y - 1900 + 36;
            return (cyclicalm(num));
        }

        /// <summary>
        /// 傳出農曆.year0 .month1 .day2 .yearCyl3 .monCyl4 .dayCyl5 .isLeap6
        /// </summary>
        private long[] Lunar(int y, int m)
        {
            long[] nongDate = new long[7];
            int i = 0, temp = 0, leap = 0;
            DateTime baseDate = new DateTime(1900 + 1900, 2, 31);
            DateTime objDate = new DateTime(y + 1900, m + 1, 1);
            TimeSpan ts = objDate - baseDate;
            long offset = (long)ts.TotalDays;
            if (y < 2000)
                offset += year19[m - 1];
            if (y > 2000)
                offset += year20[m - 1];
            if (y == 2000)
                offset += year2000[m - 1];
            nongDate[5] = offset + 40;
            nongDate[4] = 14;

            for (i = 1900; i < 2050 && offset > 0; i++)
            {
                temp = lYearDays(i);
                offset -= temp;
                nongDate[4] += 12;
            }
            if (offset < 0)
            {
                offset += temp;
                i--;
                nongDate[4] -= 12;
            }
            nongDate[0] = i;
            nongDate[3] = i - 1864;
            leap = leapMonth(i); // 閏哪個月
            nongDate[6] = 0;

            for (i = 1; i < 13 && offset > 0; i++)
            {
                // 閏月
                if (leap > 0 && i == (leap + 1) && nongDate[6] == 0)
                {
                    --i;
                    nongDate[6] = 1;
                    temp = leapDays((int)nongDate[0]);
                }
                else
                {
                    temp = monthDays((int)nongDate[0], i);
                }

                // 解除閏月
                if (nongDate[6] == 1 && i == (leap + 1))
                    nongDate[6] = 0;
                offset -= temp;
                if (nongDate[6] == 0)
                    nongDate[4]++;
            }

            if (offset == 0 && leap > 0 && i == leap + 1)
            {
                if (nongDate[6] == 1)
                {
                    nongDate[6] = 0;
                }
                else
                {
                    nongDate[6] = 1;
                    --i;
                    --nongDate[4];
                }
            }
            if (offset < 0)
            {
                offset += temp;
                --i;
                --nongDate[4];
            }
            nongDate[1] = i;
            nongDate[2] = offset + 1;
            return nongDate;
        }

        /// <summary>
        /// 傳出y年m月d日對應的農曆.year0 .month1 .day2 .yearCyl3 .monCyl4 .dayCyl5 .isLeap6
        /// </summary>
        private static long[] calElement(int y, int m, int d)
        {
            long[] nongDate = new long[7];
            int i = 0, temp = 0, leap = 0;

            DateTime baseDate = new DateTime(1900, 1, 31);

            DateTime objDate = new DateTime(y, m, d);
            TimeSpan ts = objDate - baseDate;

            long offset = (long)ts.TotalDays;

            nongDate[5] = offset + 40;
            nongDate[4] = 14;

            for (i = 1900; i < 2050 && offset > 0; i++)
            {
                temp = lYearDays(i);
                offset -= temp;
                nongDate[4] += 12;
            }
            if (offset < 0)
            {
                offset += temp;
                i--;
                nongDate[4] -= 12;
            }
            nongDate[0] = i;
            nongDate[3] = i - 1864;
            leap = leapMonth(i); // 閏哪個月
            nongDate[6] = 0;

            for (i = 1; i < 13 && offset > 0; i++)
            {
                // 閏月
                if (leap > 0 && i == (leap + 1) && nongDate[6] == 0)
                {
                    --i;
                    nongDate[6] = 1;
                    temp = leapDays((int)nongDate[0]);
                }
                else
                {
                    temp = monthDays((int)nongDate[0], i);
                }

                // 解除閏月
                if (nongDate[6] == 1 && i == (leap + 1))
                    nongDate[6] = 0;
                offset -= temp;
                if (nongDate[6] == 0)
                    nongDate[4]++;
            }

            if (offset == 0 && leap > 0 && i == leap + 1)
            {
                if (nongDate[6] == 1)
                {
                    nongDate[6] = 0;
                }
                else
                {
                    nongDate[6] = 1;
                    --i;
                    --nongDate[4];
                }
            }
            if (offset < 0)
            {
                offset += temp;
                --i;
                --nongDate[4];
            }
            nongDate[1] = i;
            nongDate[2] = offset + 1;
            return nongDate;
        }

        private static String getChinaDate(int day)
        {
            String a = "";
            if (day == 10)
                return "初十";
            if (day == 20)
                return "二十";
            if (day == 30)
                return "三十";
            int two = (int)((day) / 10);
            if (two == 0)
                a = "初";
            if (two == 1)
                a = "十";
            if (two == 2)
                a = "廿";
            if (two == 3)
                a = "三";
            int one = (int)(day % 10);
            switch (one)
            {
                case 1:
                    a += "一";
                    break;
                case 2:
                    a += "二";
                    break;
                case 3:
                    a += "三";
                    break;
                case 4:
                    a += "四";
                    break;
                case 5:
                    a += "五";
                    break;
                case 6:
                    a += "六";
                    break;
                case 7:
                    a += "七";
                    break;
                case 8:
                    a += "八";
                    break;
                case 9:
                    a += "九";
                    break;
            }
            return a;
        }

        private static DateTime sTerm(int y, int n)
        {
            double ms = 31556925974.7 * (y - 1900);
            double ms1 = sTermInfo[n];
            DateTime offDate = new DateTime(1900, 1, 6, 2, 5, 0);
            offDate = offDate.AddMilliseconds(ms);
            offDate = offDate.AddMinutes(ms1);
            return offDate;
        }

        static string FormatDate(int m, int d)
        {
            return string.Format("{0:00}{1:00}", m, d);
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 傳回公歷y年m月的總天數
        /// </summary>
        public static int GetDaysByMonth(int y, int m)
        {
            int[] days = new int[] { 31, DateTime.IsLeapYear(y) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return days[m - 1];
        }

        /// <summary>
        /// 根據日期值獲得週一的日期
        /// </summary>
        /// <param name="dt">輸入日期</param>
        /// <returns>週一的日期</returns>
        public static DateTime GetMondayDateByDate(DateTime dt)
        {
            double d = 0;
            switch ((int)dt.DayOfWeek)
            {
                //case 1: d = 0; break;
                case 2: d = -1; break;
                case 3: d = -2; break;
                case 4: d = -3; break;
                case 5: d = -4; break;
                case 6: d = -5; break;
                case 0: d = -6; break;
            }
            return dt.AddDays(d);
        }

        /// <summary>
        /// 獲取農曆
        /// </summary>
        public static CNDate getChinaDate(DateTime dt)
        {
            CNDate cd = new CNDate();
            int year = dt.Year;
            int month = dt.Month;
            int date = dt.Day;
            long[] l = calElement(year, month, date);
            cd.cnIntYear = (int)l[0];
            cd.cnIntMonth = (int)l[1];
            cd.cnIntDay = (int)l[2];
            cd.cnStrYear = cyclical(year);
            cd.cnAnm = AnimalsYear(year);
            cd.cnStrMonth = nStr1[(int)l[1]];
            cd.cnStrDay = getChinaDate((int)(l[2]));
            string smd = dt.ToString("MMdd");

            string lmd = FormatDate(cd.cnIntMonth, cd.cnIntDay);
            for (int i = 0; i < solarTerm.Length; i++)
            {
                string s1 = sTerm(dt.Year, i).ToString("MMdd");
                if (s1.Equals(dt.ToString("MMdd")))
                {
                    cd.cnSolarTerm = solarTerm[i];
                    break;
                }
            }
            foreach (string s in sFtv)
            {
                string s1 = s.Substring(0, 4);
                if (s1.Equals(smd))
                {
                    cd.cnFtvs = s.Substring(4, s.Length - 4);
                    break;
                }
            }
            foreach (string s in lFtv)
            {
                string s1 = s.Substring(0, 4);
                if (s1.Equals(lmd))
                {
                    cd.cnFtvl = s.Substring(4, s.Length - 4);
                    break;
                }
            }
            dt = dt.AddDays(1);
            year = dt.Year;
            month = dt.Month;
            date = dt.Day;
            l = calElement(year, month, date);
            lmd = FormatDate((int)l[1], (int)l[2]);
            if (lmd.Equals("0101")) cd.cnFtvl = "除夕";
            return cd;
        }
        #endregion
    }

    /// <summary>
    /// 中國日曆
    /// </summary>
    //-------------------------------------------------------------------------------
    //調用:
    //ChineseCalendar c = new ChineseCalendar(new DateTime(1990, 01, 15));
    //StringBuilder dayInfo = new StringBuilder();
    //dayInfo.Append("陽曆：" + c.DateString + "\r\n");
    //dayInfo.Append("農曆：" + c.ChineseDateString + "\r\n");
    //dayInfo.Append("星期：" + c.WeekDayStr);
    //dayInfo.Append("時辰：" + c.ChineseHour + "\r\n");
    //dayInfo.Append("屬相：" + c.AnimalString + "\r\n");
    //dayInfo.Append("節氣：" + c.ChineseTwentyFourDay + "\r\n");
    //dayInfo.Append("前一個節氣：" + c.ChineseTwentyFourPrevDay + "\r\n");
    //dayInfo.Append("下一個節氣：" + c.ChineseTwentyFourNextDay + "\r\n");
    //dayInfo.Append("節日：" + c.DateHoliday + "\r\n");
    //dayInfo.Append("干支：" + c.GanZhiDateString + "\r\n");
    //dayInfo.Append("星宿：" + c.ChineseConstellation + "\r\n");
    //dayInfo.Append("星座：" + c.Constellation + "\r\n");
    //-------------------------------------------------------------------------------
    public class ChineseCalendar
    {
        #region 內部結構
        /// <summary>
        /// 陽曆
        /// </summary>
        private struct SolarHolidayStruct
        {
            public int Month;
            public int Day;
            public int Recess; //假期長度
            public string HolidayName;
            public SolarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }

        /// <summary>
        /// 農曆
        /// </summary>
        private struct LunarHolidayStruct
        {
            public int Month;
            public int Day;
            public int Recess;
            public string HolidayName;

            public LunarHolidayStruct(int month, int day, int recess, string name)
            {
                Month = month;
                Day = day;
                Recess = recess;
                HolidayName = name;
            }
        }

        private struct WeekHolidayStruct
        {
            public int Month;
            public int WeekAtMonth;
            public int WeekDay;
            public string HolidayName;

            public WeekHolidayStruct(int month, int weekAtMonth, int weekDay, string name)
            {
                Month = month;
                WeekAtMonth = weekAtMonth;
                WeekDay = weekDay;
                HolidayName = name;
            }
        }
        #endregion

        #region 內部變量
        private DateTime _date;
        private DateTime _datetime;
        private int _cYear;
        private int _cMonth;
        private int _cDay;
        private bool _cIsLeapMonth; //當月是否閏月
        private bool _cIsLeapYear;  //當年是否有閏月
        #endregion

        #region 基礎數據
        #region 基本常量
        private const int MinYear = 1900;
        private const int MaxYear = 2050;
        private static DateTime MinDay = new DateTime(1900, 1, 30);
        private static DateTime MaxDay = new DateTime(2049, 12, 31);
        private const int GanZhiStartYear = 1864; //干支計算起始年
        private static DateTime GanZhiStartDay = new DateTime(1899, 12, 22);//起始日
        private const string HZNum = "零一二三四五六七八九";
        private const int AnimalStartYear = 1900; //1900年為鼠年
        private static DateTime ChineseConstellationReferDay = new DateTime(2007, 9, 13);//28星宿參考值,本日為角
        #endregion

        #region 陰曆數據
        /// <summary>
        /// 來源於網上的農曆數據
        /// </summary>
        /// <remarks>
        /// 數據結構如下，共使用17位數據
        /// 第17位：表示閏月天數，0表示29天   1表示30天
        /// 第16位-第5位（共12位）表示12個月，其中第16位表示第一月，如果該月為30天則為1，29天為0
        /// 第4位-第1位（共4位）表示閏月是哪個月，如果當年沒有閏月，則置0
        ///</remarks>
        private static int[] LunarDateArray = new int[]{
                0x04BD8,0x04AE0,0x0A570,0x054D5,0x0D260,0x0D950,0x16554,0x056A0,0x09AD0,0x055D2,
                0x04AE0,0x0A5B6,0x0A4D0,0x0D250,0x1D255,0x0B540,0x0D6A0,0x0ADA2,0x095B0,0x14977,
                0x04970,0x0A4B0,0x0B4B5,0x06A50,0x06D40,0x1AB54,0x02B60,0x09570,0x052F2,0x04970,
                0x06566,0x0D4A0,0x0EA50,0x06E95,0x05AD0,0x02B60,0x186E3,0x092E0,0x1C8D7,0x0C950,
                0x0D4A0,0x1D8A6,0x0B550,0x056A0,0x1A5B4,0x025D0,0x092D0,0x0D2B2,0x0A950,0x0B557,
                0x06CA0,0x0B550,0x15355,0x04DA0,0x0A5B0,0x14573,0x052B0,0x0A9A8,0x0E950,0x06AA0,
                0x0AEA6,0x0AB50,0x04B60,0x0AAE4,0x0A570,0x05260,0x0F263,0x0D950,0x05B57,0x056A0,
                0x096D0,0x04DD5,0x04AD0,0x0A4D0,0x0D4D4,0x0D250,0x0D558,0x0B540,0x0B6A0,0x195A6,
                0x095B0,0x049B0,0x0A974,0x0A4B0,0x0B27A,0x06A50,0x06D40,0x0AF46,0x0AB60,0x09570,
                0x04AF5,0x04970,0x064B0,0x074A3,0x0EA50,0x06B58,0x055C0,0x0AB60,0x096D5,0x092E0,
                0x0C960,0x0D954,0x0D4A0,0x0DA50,0x07552,0x056A0,0x0ABB7,0x025D0,0x092D0,0x0CAB5,
                0x0A950,0x0B4A0,0x0BAA4,0x0AD50,0x055D9,0x04BA0,0x0A5B0,0x15176,0x052B0,0x0A930,
                0x07954,0x06AA0,0x0AD50,0x05B52,0x04B60,0x0A6E6,0x0A4E0,0x0D260,0x0EA65,0x0D530,
                0x05AA0,0x076A3,0x096D0,0x04BD7,0x04AD0,0x0A4D0,0x1D0B6,0x0D250,0x0D520,0x0DD45,
                0x0B5A0,0x056D0,0x055B2,0x049B0,0x0A577,0x0A4B0,0x0AA50,0x1B255,0x06D20,0x0ADA0,
                0x14B63        
                };

        #endregion

        #region 星座名稱
        private static string[] _constellationName = 
                { 
                    "白羊座", "金牛座", "雙子座", 
                    "巨蟹座", "獅子座", "處女座", 
                    "天秤座", "天蠍座", "射手座", 
                    "摩羯座", "水瓶座", "雙魚座"
                };
        #endregion

        #region 二十四節氣
        private static string[] _lunarHolidayName = 
                    { 
                    "小寒", "大寒", "立春", "雨水", 
                    "驚蟄", "春分", "清明", "谷雨", 
                    "立夏", "小滿", "芒種", "夏至", 
                    "小暑", "大暑", "立秋", "處暑", 
                    "白露", "秋分", "寒露", "霜降", 
                    "立冬", "小雪", "大雪", "冬至"
                    };
        #endregion

        #region 二十八星宿
        private static string[] _chineseConstellationName =
            {
                  //四        五      六         日        一      二      三  
                "角木蛟","亢金龍","女土蝠","房日兔","心月狐","尾火虎","箕水豹",
                "斗木獬","牛金牛","氐土貉","虛日鼠","危月燕","室火豬","壁水獝",
                "奎木狼","婁金狗","胃土彘","昴日雞","畢月烏","觜火猴","參水猿",
                "井木犴","鬼金羊","柳土獐","星日馬","張月鹿","翼火蛇","軫水蚓" 
            };
        #endregion

        #region 節氣數據
        private static string[] SolarTerm = new string[] { "小寒", "大寒", "立春", "雨水", "驚蟄", "春分", "清明", "谷雨", "立夏", "小滿", "芒種", "夏至", "小暑", "大暑", "立秋", "處暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };
        private static int[] sTermInfo = new int[] { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
        #endregion

        #region 農曆相關數據
        private static string ganStr = "甲乙丙丁戊己庚辛壬癸";
        private static string zhiStr = "子丑寅卯辰巳午未申酉戌亥";
        private static string animalStr = "鼠牛虎兔龍蛇馬羊猴雞狗豬";
        private static string nStr1 = "日一二三四五六七八九";
        private static string nStr2 = "初十廿卅";
        private static string[] _monthString =
                {
                    "出錯","正月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","臘月"
                };
        #endregion

        #region 按公歷計算的節日
        private static SolarHolidayStruct[] sHolidayInfo = new SolarHolidayStruct[]{
            new SolarHolidayStruct(1, 1, 1, "元旦"),
            new SolarHolidayStruct(2, 2, 0, "世界濕地日"),
            new SolarHolidayStruct(2, 10, 0, "國際氣象節"),
            new SolarHolidayStruct(2, 14, 0, "情人節"),
            new SolarHolidayStruct(3, 1, 0, "國際海豹日"),
            new SolarHolidayStruct(3, 5, 0, "學雷鋒紀念日"),
            new SolarHolidayStruct(3, 8, 0, "婦女節"), 
            new SolarHolidayStruct(3, 12, 0, "植樹節 孫中山逝世紀念日"), 
            new SolarHolidayStruct(3, 14, 0, "國際警察日"),
            new SolarHolidayStruct(3, 15, 0, "消費者權益日"),
            new SolarHolidayStruct(3, 17, 0, "中國國醫節 國際航海日"),
            new SolarHolidayStruct(3, 21, 0, "世界森林日 消除種族歧視國際日 世界兒歌日"),
            new SolarHolidayStruct(3, 22, 0, "世界水日"),
            new SolarHolidayStruct(3, 24, 0, "世界防治結核病日"),
            new SolarHolidayStruct(4, 1, 0, "愚人節"),
            new SolarHolidayStruct(4, 7, 0, "世界衛生日"),
            new SolarHolidayStruct(4, 22, 0, "世界地球日"),
            new SolarHolidayStruct(5, 1, 1, "勞動節"), 
            new SolarHolidayStruct(5, 2, 1, "勞動節假日"),
            new SolarHolidayStruct(5, 3, 1, "勞動節假日"),
            new SolarHolidayStruct(5, 4, 0, "青年節"), 
            new SolarHolidayStruct(5, 8, 0, "世界紅十字日"),
            new SolarHolidayStruct(5, 12, 0, "國際護士節"), 
            new SolarHolidayStruct(5, 31, 0, "世界無煙日"), 
            new SolarHolidayStruct(6, 1, 0, "國際兒童節"), 
            new SolarHolidayStruct(6, 5, 0, "世界環境保護日"),
            new SolarHolidayStruct(6, 26, 0, "國際禁毒日"),
            new SolarHolidayStruct(7, 1, 0, "建黨節 香港回歸紀念 世界建築日"),
            new SolarHolidayStruct(7, 11, 0, "世界人口日"),
            new SolarHolidayStruct(8, 1, 0, "建軍節"), 
            new SolarHolidayStruct(8, 8, 0, "中國男子節 父親節"),
            new SolarHolidayStruct(8, 15, 0, "抗日戰爭勝利紀念"),
            new SolarHolidayStruct(9, 9, 0, "毛主席逝世紀念"), 
            new SolarHolidayStruct(9, 10, 0, "教師節"), 
            new SolarHolidayStruct(9, 18, 0, "九·一八事變紀念日"),
            new SolarHolidayStruct(9, 20, 0, "國際愛牙日"),
            new SolarHolidayStruct(9, 27, 0, "世界旅遊日"),
            new SolarHolidayStruct(9, 28, 0, "孔子誕辰"),
            new SolarHolidayStruct(10, 1, 1, "國慶節 國際音樂日"),
            new SolarHolidayStruct(10, 2, 1, "國慶節假日"),
            new SolarHolidayStruct(10, 3, 1, "國慶節假日"),
            new SolarHolidayStruct(10, 6, 0, "老人節"), 
            new SolarHolidayStruct(10, 24, 0, "聯合國日"),
            new SolarHolidayStruct(11, 10, 0, "世界青年節"),
            new SolarHolidayStruct(11, 12, 0, "孫中山誕辰紀念"), 
            new SolarHolidayStruct(12, 1, 0, "世界艾滋病日"), 
            new SolarHolidayStruct(12, 3, 0, "世界殘疾人日"), 
            new SolarHolidayStruct(12, 20, 0, "澳門回歸紀念"), 
            new SolarHolidayStruct(12, 24, 0, "平安夜"), 
            new SolarHolidayStruct(12, 25, 0, "聖誕節"), 
            new SolarHolidayStruct(12, 26, 0, "毛主席誕辰紀念")
           };
        #endregion

        #region 按農曆計算的節日
        private static LunarHolidayStruct[] lHolidayInfo = new LunarHolidayStruct[]{
            new LunarHolidayStruct(1, 1, 1, "春節"), 
            new LunarHolidayStruct(1, 15, 0, "元宵節"), 
            new LunarHolidayStruct(5, 5, 0, "端午節"), 
            new LunarHolidayStruct(7, 7, 0, "七夕情人節"),
            new LunarHolidayStruct(7, 15, 0, "中元節 盂蘭盆節"), 
            new LunarHolidayStruct(8, 15, 0, "中秋節"), 
            new LunarHolidayStruct(9, 9, 0, "重陽節"), 
            new LunarHolidayStruct(12, 8, 0, "臘八節"),
            new LunarHolidayStruct(12, 23, 0, "北方小年(掃房)"),
            new LunarHolidayStruct(12, 24, 0, "南方小年(撣塵)"),
            //new LunarHolidayStruct(12, 30, 0, "除夕")  //注意除夕需要其它方法進行計算
        };
        #endregion

        #region 按某月第幾個星期幾
        private static WeekHolidayStruct[] wHolidayInfo = new WeekHolidayStruct[]{
            new WeekHolidayStruct(5, 2, 1, "母親節"), 
            new WeekHolidayStruct(5, 3, 1, "全國助殘日"), 
            new WeekHolidayStruct(6, 3, 1, "父親節"), 
            new WeekHolidayStruct(9, 3, 3, "國際和平日"), 
            new WeekHolidayStruct(9, 4, 1, "國際聾人節"), 
            new WeekHolidayStruct(10, 1, 2, "國際住房日"), 
            new WeekHolidayStruct(10, 1, 4, "國際減輕自然災害日"),
            new WeekHolidayStruct(11, 4, 5, "感恩節")
        };
        #endregion
        #endregion

        #region 構造函數
        #region 公歷日期初始化
        /// <summary>
        /// 用一個標準的公歷日期來初使化
        /// </summary>
        public ChineseCalendar(DateTime dt)
        {
            int i;
            int leap;
            int temp;
            int offset;

            CheckDateLimit(dt);

            _date = dt.Date;
            _datetime = dt;

            //農曆日期計算部分
            leap = 0;
            temp = 0;

            //計算兩天的基本差距
            TimeSpan ts = _date - ChineseCalendar.MinDay;
            offset = ts.Days;

            for (i = MinYear; i <= MaxYear; i++)
            {
                //求當年農曆年天數
                temp = GetChineseYearDays(i);
                if (offset - temp < 1)
                    break;
                else
                {
                    offset = offset - temp;
                }
            }
            _cYear = i;

            //計算該年閏哪個月
            leap = GetChineseLeapMonth(_cYear);

            //設定當年是否有閏月
            if (leap > 0)
            {
                _cIsLeapYear = true;
            }
            else
            {
                _cIsLeapYear = false;
            }

            _cIsLeapMonth = false;
            for (i = 1; i <= 12; i++)
            {
                //閏月
                if ((leap > 0) && (i == leap + 1) && (_cIsLeapMonth == false))
                {
                    _cIsLeapMonth = true;
                    i = i - 1;
                    temp = GetChineseLeapMonthDays(_cYear); //計算閏月天數
                }
                else
                {
                    _cIsLeapMonth = false;
                    temp = GetChineseMonthDays(_cYear, i);  //計算非閏月天數
                }

                offset = offset - temp;
                if (offset <= 0) break;
            }

            offset = offset + temp;
            _cMonth = i;
            _cDay = offset;
        }
        #endregion

        #region 農曆日期初始化
        /// <summary>
        /// 用農曆的日期來初使化
        /// </summary>
        /// <param name="cy">農曆年</param>
        /// <param name="cm">農曆月</param>
        /// <param name="cd">農曆日</param>
        /// <param name="LeapFlag">閏月標誌</param>
        public ChineseCalendar(int cy, int cm, int cd, bool leapMonthFlag)
        {
            int i, leap, Temp, offset;

            CheckChineseDateLimit(cy, cm, cd, leapMonthFlag);

            _cYear = cy;
            _cMonth = cm;
            _cDay = cd;

            offset = 0;

            for (i = MinYear; i < cy; i++)
            {
                //求當年農曆年天數
                Temp = GetChineseYearDays(i);
                offset = offset + Temp;
            }

            //計算該年應該閏哪個月
            leap = GetChineseLeapMonth(cy);
            if (leap != 0)
            {
                this._cIsLeapYear = true;
            }
            else
            {
                this._cIsLeapYear = false;
            }

            if (cm != leap)
            {
                //當前日期並非閏月
                _cIsLeapMonth = false;
            }
            else
            {
                //使用用戶輸入的是否閏月月份
                _cIsLeapMonth = leapMonthFlag;
            }

            //當年沒有閏月||計算月份小於閏月
            if ((_cIsLeapYear == false) || (cm < leap))
            {
                for (i = 1; i < cm; i++)
                {
                    Temp = GetChineseMonthDays(cy, i);//計算非閏月天數
                    offset = offset + Temp;
                }

                //檢查日期是否大於最大天
                if (cd > GetChineseMonthDays(cy, cm))
                {
                    throw new Exception("不合法的農曆日期");
                }
                //加上當月的天數
                offset = offset + cd;
            }

            //是閏年，且計算月份大於或等於閏月
            else
            {
                for (i = 1; i < cm; i++)
                {
                    //計算非閏月天數
                    Temp = GetChineseMonthDays(cy, i);
                    offset = offset + Temp;
                }

                //計算月大於閏月
                if (cm > leap)
                {
                    Temp = GetChineseLeapMonthDays(cy);   //計算閏月天數
                    offset = offset + Temp;               //加上閏月天數

                    if (cd > GetChineseMonthDays(cy, cm))
                    {
                        throw new Exception("不合法的農曆日期");
                    }
                    offset = offset + cd;
                }

                //計算月等於閏月
                else
                {
                    //如果需要計算的是閏月，則應首先加上與閏月對應的普通月的天數
                    if (this._cIsLeapMonth == true)         //計算月為閏月
                    {
                        Temp = GetChineseMonthDays(cy, cm); //計算非閏月天數
                        offset = offset + Temp;
                    }

                    if (cd > GetChineseLeapMonthDays(cy))
                    {
                        throw new Exception("不合法的農曆日期");
                    }
                    offset = offset + cd;
                }
            }
            _date = MinDay.AddDays(offset);
        }
        #endregion
        #endregion

        #region 私有函數
        #region GetChineseMonthDays
        /// <summary>
        /// //傳回農曆y年m月的總天數
        /// </summary>
        private int GetChineseMonthDays(int year, int month)
        {
            if (BitTest32((LunarDateArray[year - MinYear] & 0x0000FFFF), (16 - month)))
            {
                return 30;
            }
            else
            {
                return 29;
            }
        }
        #endregion

        #region GetChineseLeapMonth
        /// <summary>
        /// 傳回農曆 y年閏哪個月 1-12 , 沒閏傳回 0
        /// </summary>
        private int GetChineseLeapMonth(int year)
        {
            return LunarDateArray[year - MinYear] & 0xF;
        }
        #endregion

        #region GetChineseLeapMonthDays
        /// <summary>
        /// 傳回農曆y年閏月的天數
        /// </summary>
        private int GetChineseLeapMonthDays(int year)
        {
            if (GetChineseLeapMonth(year) != 0)
            {
                if ((LunarDateArray[year - MinYear] & 0x10000) != 0)
                {
                    return 30;
                }
                else
                {
                    return 29;
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region GetChineseYearDays
        /// <summary>
        /// 取農曆年一年的天數
        /// </summary>
        private int GetChineseYearDays(int year)
        {
            int i, f, sumDay, info;

            sumDay = 348; //29天*12個月
            i = 0x8000;
            info = LunarDateArray[year - MinYear] & 0x0FFFF;

            //計算12個月中有多少天為30天
            for (int m = 0; m < 12; m++)
            {
                f = info & i;
                if (f != 0)
                {
                    sumDay++;
                }
                i = i >> 1;
            }
            return sumDay + GetChineseLeapMonthDays(year);
        }
        #endregion

        #region GetChineseHour
        /// <summary>
        /// 獲得當前時間的時辰
        /// </summary> 
        private string GetChineseHour(DateTime dt)
        {
            int _hour, _minute, offset, i;
            int indexGan;
            string ganHour, zhiHour;
            string tmpGan;

            //計算時辰的地支
            _hour = dt.Hour;    //獲得當前時間小時
            _minute = dt.Minute;  //獲得當前時間分鐘

            if (_minute != 0) _hour += 1;
            offset = _hour / 2;
            if (offset >= 12) offset = 0;
            //zhiHour = zhiStr[offset].ToString();

            //計算天干
            TimeSpan ts = this._date - GanZhiStartDay;
            i = ts.Days % 60;

            //ganStr[i % 10] 為日的天干,(n*2-1) %10得出地支對應,n從1開始
            indexGan = ((i % 10 + 1) * 2 - 1) % 10 - 1;

            tmpGan = ganStr.Substring(indexGan) + ganStr.Substring(0, indexGan + 2);//湊齊12位
            //ganHour = ganStr[((i % 10 + 1) * 2 - 1) % 10 - 1].ToString();

            return tmpGan[offset].ToString() + zhiStr[offset].ToString();
        }
        #endregion

        #region CheckDateLimit
        /// <summary>
        /// 檢查公歷日期是否符合要求
        /// </summary>
        private void CheckDateLimit(DateTime dt)
        {
            if ((dt < MinDay) || (dt > MaxDay))
            {
                throw new Exception("超出可轉換的日期");
            }
        }
        #endregion

        #region CheckChineseDateLimit
        /// <summary>
        /// 檢查農曆日期是否合理
        /// </summary>
        private void CheckChineseDateLimit(int year, int month, int day, bool leapMonth)
        {
            if ((year < MinYear) || (year > MaxYear))
            {
                throw new Exception("非法農曆日期");
            }
            if ((month < 1) || (month > 12))
            {
                throw new Exception("非法農曆日期");
            }
            if ((day < 1) || (day > 30)) //中國的月最多30天
            {
                throw new Exception("非法農曆日期");
            }
            int leap = GetChineseLeapMonth(year);// 計算該年應該閏哪個月
            if ((leapMonth == true) && (month != leap))
            {
                throw new Exception("非法農曆日期");
            }
        }
        #endregion

        #region ConvertNumToChineseNum
        /// <summary>
        /// 將0-9轉成漢字形式
        /// </summary>
        private string ConvertNumToChineseNum(char n)
        {
            if ((n < '0') || (n > '9')) return "";
            switch (n)
            {
                case '0':
                    return HZNum[0].ToString();
                case '1':
                    return HZNum[1].ToString();
                case '2':
                    return HZNum[2].ToString();
                case '3':
                    return HZNum[3].ToString();
                case '4':
                    return HZNum[4].ToString();
                case '5':
                    return HZNum[5].ToString();
                case '6':
                    return HZNum[6].ToString();
                case '7':
                    return HZNum[7].ToString();
                case '8':
                    return HZNum[8].ToString();
                case '9':
                    return HZNum[9].ToString();
                default:
                    return "";
            }
        }
        #endregion

        #region BitTest32
        /// <summary>
        /// 測試某位是否為真
        /// </summary>
        private bool BitTest32(int num, int bitpostion)
        {
            if ((bitpostion > 31) || (bitpostion < 0))
                throw new Exception("Error Param: bitpostion[0-31]:" + bitpostion.ToString());

            int bit = 1 << bitpostion;

            if ((num & bit) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region ConvertDayOfWeek
        /// <summary>
        /// 將星期幾轉成數字表示
        /// </summary>
        private int ConvertDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                case DayOfWeek.Saturday:
                    return 7;
                default:
                    return 0;
            }
        }
        #endregion

        #region CompareWeekDayHoliday
        /// <summary>
        /// 比較當天是不是指定的第周幾
        /// </summary>
        private bool CompareWeekDayHoliday(DateTime date, int month, int week, int day)
        {
            bool ret = false;

            if (date.Month == month) //月份相同
            {
                if (ConvertDayOfWeek(date.DayOfWeek) == day) //星期幾相同
                {
                    DateTime firstDay = new DateTime(date.Year, date.Month, 1);//生成當月第一天
                    int i = ConvertDayOfWeek(firstDay.DayOfWeek);
                    int firWeekDays = 7 - ConvertDayOfWeek(firstDay.DayOfWeek) + 1; //計算第一周剩餘天數

                    if (i > day)
                    {
                        if ((week - 1) * 7 + day + firWeekDays == date.Day)
                        {
                            ret = true;
                        }
                    }
                    else
                    {
                        if (day + firWeekDays + (week - 2) * 7 == date.Day)
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }
        #endregion
        #endregion

        #region  屬性
        #region 節日
        #region newCalendarHoliday
        /// <summary>
        /// 計算中國農曆節日
        /// </summary>
        public string newCalendarHoliday
        {
            get
            {
                string tempStr = "";
                if (this._cIsLeapMonth == false) //閏月不計算節日
                {
                    foreach (LunarHolidayStruct lh in lHolidayInfo)
                    {
                        if ((lh.Month == this._cMonth) && (lh.Day == this._cDay))
                        {

                            tempStr = lh.HolidayName;
                            break;

                        }
                    }

                    //對除夕進行特別處理
                    if (this._cMonth == 12)
                    {
                        int i = GetChineseMonthDays(this._cYear, 12); //計算當年農曆12月的總天數
                        if (this._cDay == i) //如果為最後一天
                        {
                            tempStr = "除夕";
                        }
                    }
                }
                return tempStr;
            }
        }
        #endregion

        #region WeekDayHoliday
        /// <summary>
        /// 按某月第幾周第幾日計算的節日
        /// </summary>
        public string WeekDayHoliday
        {
            get
            {
                string tempStr = "";
                foreach (WeekHolidayStruct wh in wHolidayInfo)
                {
                    if (CompareWeekDayHoliday(_date, wh.Month, wh.WeekAtMonth, wh.WeekDay))
                    {
                        tempStr = wh.HolidayName;
                        break;
                    }
                }
                return tempStr;
            }
        }
        #endregion

        #region DateHoliday
        /// <summary>
        /// 按公歷日計算的節日
        /// </summary>
        public string DateHoliday
        {
            get
            {
                string tempStr = "";

                foreach (SolarHolidayStruct sh in sHolidayInfo)
                {
                    if ((sh.Month == _date.Month) && (sh.Day == _date.Day))
                    {
                        tempStr = sh.HolidayName;
                        break;
                    }
                }
                return tempStr;
            }
        }
        #endregion
        #endregion

        #region 公歷日期
        #region Date
        /// <summary>
        /// 取對應的公歷日期
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

        #region WeekDay
        /// <summary>
        /// 取星期幾
        /// </summary>
        public DayOfWeek WeekDay
        {
            get { return _date.DayOfWeek; }
        }
        #endregion

        #region WeekDayStr
        /// <summary>
        /// 周幾的字符
        /// </summary>
        public string WeekDayStr
        {
            get
            {
                switch (_date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "星期日";
                    case DayOfWeek.Monday:
                        return "星期一";
                    case DayOfWeek.Tuesday:
                        return "星期二";
                    case DayOfWeek.Wednesday:
                        return "星期三";
                    case DayOfWeek.Thursday:
                        return "星期四";
                    case DayOfWeek.Friday:
                        return "星期五";
                    default:
                        return "星期六";
                }
            }
        }
        #endregion

        #region DateString
        /// <summary>
        /// 公歷日期中文表示法 如一九九七年七月一日
        /// </summary>
        public string DateString
        {
            get
            {
                return "公元" + this._date.ToLongDateString();
            }
        }
        #endregion

        #region IsLeapYear
        /// <summary>
        /// 當前是否公歷閏年
        /// </summary>
        public bool IsLeapYear
        {
            get
            {
                return DateTime.IsLeapYear(this._date.Year);
            }
        }
        #endregion

        #region ChineseConstellation
        /// <summary>
        /// 28星宿計算
        /// </summary>
        public string ChineseConstellation
        {
            get
            {
                int offset = 0;
                int modStarDay = 0;

                TimeSpan ts = this._date - ChineseConstellationReferDay;
                offset = ts.Days;
                modStarDay = offset % 28;
                return (modStarDay >= 0 ? _chineseConstellationName[modStarDay] : _chineseConstellationName[27 + modStarDay]);
            }
        }
        #endregion

        #region ChineseHour
        /// <summary>
        /// 時辰
        /// </summary>
        public string ChineseHour
        {
            get
            {
                return GetChineseHour(_datetime);
            }
        }
        #endregion

        #endregion

        #region 農曆日期
        #region IsChineseLeapMonth
        /// <summary>
        /// 是否閏月
        /// </summary>
        public bool IsChineseLeapMonth
        {
            get { return this._cIsLeapMonth; }
        }
        #endregion

        #region IsChineseLeapYear
        /// <summary>
        /// 當年是否有閏月
        /// </summary>
        public bool IsChineseLeapYear
        {
            get
            {
                return this._cIsLeapYear;
            }
        }
        #endregion

        #region ChineseDay
        /// <summary>
        /// 農曆日
        /// </summary>
        public int ChineseDay
        {
            get { return this._cDay; }
        }
        #endregion

        #region ChineseDayString
        /// <summary>
        /// 農曆日中文表示
        /// </summary>
        public string ChineseDayString
        {
            get
            {
                switch (this._cDay)
                {
                    case 0:
                        return "";
                    case 10:
                        return "初十";
                    case 20:
                        return "二十";
                    case 30:
                        return "三十";
                    default:
                        return nStr2[(int)(_cDay / 10)].ToString() + nStr1[_cDay % 10].ToString();

                }
            }
        }
        #endregion

        #region ChineseMonth
        /// <summary>
        /// 農曆的月份
        /// </summary>
        public int ChineseMonth
        {
            get { return this._cMonth; }
        }
        #endregion

        #region ChineseMonthString
        /// <summary>
        /// 農曆月份字符串
        /// </summary>
        public string ChineseMonthString
        {
            get
            {
                return _monthString[this._cMonth];
            }
        }
        #endregion

        #region ChineseYear
        /// <summary>
        /// 取農曆年份
        /// </summary>
        public int ChineseYear
        {
            get { return this._cYear; }
        }
        #endregion

        #region ChineseYearString
        /// <summary>
        /// 取農曆年字符串如，一九九七年
        /// </summary>
        public string ChineseYearString
        {
            get
            {
                string tempStr = "";
                string num = this._cYear.ToString();
                for (int i = 0; i < 4; i++)
                {
                    tempStr += ConvertNumToChineseNum(num[i]);
                }
                return tempStr + "年";
            }
        }
        #endregion

        #region ChineseDateString
        /// <summary>
        /// 取農曆日期表示法：農曆一九九七年正月初五
        /// </summary>
        public string ChineseDateString
        {
            get
            {
                if (this._cIsLeapMonth == true)
                {
                    return "農曆" + ChineseYearString + "閏" + ChineseMonthString + ChineseDayString;
                }
                else
                {
                    return "農曆" + ChineseYearString + ChineseMonthString + ChineseDayString;
                }
            }
        }
        #endregion

        #region ChineseTwentyFourDay
        /// <summary>
        /// 定氣法計算二十四節氣,二十四節氣是按地球公轉來計算的，並非是陰曆計算的
        /// </summary>
        /// <remarks>
        /// 節氣的定法有兩種。古代曆法採用的稱為"恆氣"，即按時間把一年等分為24份，
        /// 每一節氣平均得15天有餘，所以又稱"平氣"。現代農曆採用的稱為"定氣"，即
        /// 按地球在軌道上的位置為標準，一周360°，兩節氣之間相隔15°。由於冬至時地
        /// 球位於近日點附近，運動速度較快，因而太陽在黃道上移動15°的時間不到15天。
        /// 夏至前後的情況正好相反，太陽在黃道上移動較慢，一個節氣達16天之多。採用
        /// 定氣時可以保證春、秋兩分必然在晝夜平分的那兩天。
        /// </remarks>
        public string ChineseTwentyFourDay
        {
            get
            {
                DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                string tempStr = "";

                y = this._date.Year;

                for (int i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + sTermInfo[i - 1];

                    newDate = baseDateAndTime.AddMinutes(num);//按分鐘計算
                    if (newDate.DayOfYear == _date.DayOfYear)
                    {
                        tempStr = SolarTerm[i - 1];
                        break;
                    }
                }
                return tempStr;
            }
        }

        //當前日期前一個最近節氣
        public string ChineseTwentyFourPrevDay
        {
            get
            {
                DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                string tempStr = "";

                y = this._date.Year;

                for (int i = 24; i >= 1; i--)
                {
                    num = 525948.76 * (y - 1900) + sTermInfo[i - 1];

                    newDate = baseDateAndTime.AddMinutes(num);//按分鐘計算

                    if (newDate.DayOfYear < _date.DayOfYear)
                    {
                        tempStr = string.Format("{0}[{1}]", SolarTerm[i - 1], newDate.ToString("yyyy-MM-dd"));
                        break;
                    }
                }

                return tempStr;
            }

        }

        //當前日期後一個最近節氣
        public string ChineseTwentyFourNextDay
        {
            get
            {
                DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
                DateTime newDate;
                double num;
                int y;
                string tempStr = "";

                y = this._date.Year;

                for (int i = 1; i <= 24; i++)
                {
                    num = 525948.76 * (y - 1900) + sTermInfo[i - 1];

                    newDate = baseDateAndTime.AddMinutes(num);//按分鐘計算

                    if (newDate.DayOfYear > _date.DayOfYear)
                    {
                        tempStr = string.Format("{0}[{1}]", SolarTerm[i - 1], newDate.ToString("yyyy-MM-dd"));
                        break;
                    }
                }
                return tempStr;
            }

        }
        #endregion
        #endregion

        #region 星座
        /// <summary>
        /// 計算指定日期的星座序號 
        /// </summary>
        public string Constellation
        {
            get
            {
                int index = 0;
                int y, m, d;
                y = _date.Year;
                m = _date.Month;
                d = _date.Day;
                y = m * 100 + d;

                if (((y >= 321) && (y <= 419))) { index = 0; }
                else if ((y >= 420) && (y <= 520)) { index = 1; }
                else if ((y >= 521) && (y <= 620)) { index = 2; }
                else if ((y >= 621) && (y <= 722)) { index = 3; }
                else if ((y >= 723) && (y <= 822)) { index = 4; }
                else if ((y >= 823) && (y <= 922)) { index = 5; }
                else if ((y >= 923) && (y <= 1022)) { index = 6; }
                else if ((y >= 1023) && (y <= 1121)) { index = 7; }
                else if ((y >= 1122) && (y <= 1221)) { index = 8; }
                else if ((y >= 1222) || (y <= 119)) { index = 9; }
                else if ((y >= 120) && (y <= 218)) { index = 10; }
                else if ((y >= 219) && (y <= 320)) { index = 11; }
                else { index = 0; }

                return _constellationName[index];
            }
        }
        #endregion

        #region 屬相
        #region Animal
        /// <summary>
        /// 計算屬相的索引，注意雖然屬相是以農曆年來區別的，但是目前在實際使用中是按公歷來計算的
        /// 鼠年為1,其它類推
        /// </summary>
        public int Animal
        {
            get
            {
                int offset = _date.Year - AnimalStartYear;
                return (offset % 12) + 1;
            }
        }
        #endregion

        #region AnimalString
        /// <summary>
        /// 取屬相字符串
        /// </summary>
        public string AnimalString
        {
            get
            {
                int offset = _date.Year - AnimalStartYear; //陽曆計算
                //int offset = this._cYear - AnimalStartYear;　農曆計算
                return animalStr[offset % 12].ToString();
            }
        }
        #endregion
        #endregion

        #region 天干地支
        #region GanZhiYearString
        /// <summary>
        /// 取農曆年的干支表示法如 乙丑年
        /// </summary>
        public string GanZhiYearString
        {
            get
            {
                string tempStr;
                int i = (this._cYear - GanZhiStartYear) % 60; //計算干支
                tempStr = ganStr[i % 10].ToString() + zhiStr[i % 12].ToString() + "年";
                return tempStr;
            }
        }
        #endregion

        #region GanZhiMonthString
        /// <summary>
        /// 取干支的月表示字符串，注意農曆的閏月不記干支
        /// </summary>
        public string GanZhiMonthString
        {
            get
            {
                //每個月的地支總是固定的,而且總是從寅月開始
                int zhiIndex;
                string zhi;
                if (this._cMonth > 10)
                {
                    zhiIndex = this._cMonth - 10;
                }
                else
                {
                    zhiIndex = this._cMonth + 2;
                }
                zhi = zhiStr[zhiIndex - 1].ToString();

                //根據當年的干支年的干來計算月干的第一個
                int ganIndex = 1;
                string gan;
                int i = (this._cYear - GanZhiStartYear) % 60; //計算干支
                switch (i % 10)
                {
                    #region ...
                    case 0: //甲
                        ganIndex = 3;
                        break;
                    case 1: //乙
                        ganIndex = 5;
                        break;
                    case 2: //丙
                        ganIndex = 7;
                        break;
                    case 3: //丁
                        ganIndex = 9;
                        break;
                    case 4: //戊
                        ganIndex = 1;
                        break;
                    case 5: //己
                        ganIndex = 3;
                        break;
                    case 6: //庚
                        ganIndex = 5;
                        break;
                    case 7: //辛
                        ganIndex = 7;
                        break;
                    case 8: //壬
                        ganIndex = 9;
                        break;
                    case 9: //癸
                        ganIndex = 1;
                        break;
                    #endregion
                }
                gan = ganStr[(ganIndex + this._cMonth - 2) % 10].ToString();

                return gan + zhi + "月";
            }
        }
        #endregion

        #region GanZhiDayString
        /// <summary>
        /// 取干支日表示法
        /// </summary>
        public string GanZhiDayString
        {
            get
            {
                int i, offset;
                TimeSpan ts = this._date - GanZhiStartDay;
                offset = ts.Days;
                i = offset % 60;
                return ganStr[i % 10].ToString() + zhiStr[i % 12].ToString() + "日";
            }
        }
        #endregion

        #region GanZhiDateString
        /// <summary>
        /// 取當前日期的干支表示法如 甲子年乙丑月丙庚日
        /// </summary>
        public string GanZhiDateString
        {
            get
            {
                return GanZhiYearString + GanZhiMonthString + GanZhiDayString;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}


