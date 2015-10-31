/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// 共用工具類
    /// </summary>
    public static class Tools
    {
        #region 獲得用戶IP
        /// <summary>
        /// 獲得用戶IP
        /// </summary>
        public static string GetUserIp()
        {
            string ip;
            string[] temp;
            bool isErr = false;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"] == null)
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            else
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"].ToString();
            if (ip.Length > 15)
                isErr = true;
            else
            {
                temp = ip.Split('.');
                if (temp.Length == 4)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Length > 3) isErr = true;
                    }
                }
                else
                    isErr = true;
            }

            if (isErr)
                return "1.1.1.1";
            else
                return ip;
        }
        #endregion

        #region 根據配置對指定字符串進行 MD5 加密
        /// <summary>
        /// 根據配置對指定字符串進行 MD5 加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetMD5(string s)
        {
            //md5加密
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "md5").ToString();

            return s.ToLower().Substring(8, 16);
        }
        #endregion

        #region 得到字符串長度，一個漢字長度為2
        /// <summary>
        /// 得到字符串長度，一個漢字長度為2
        /// </summary>
        /// <param name="inputString">參數字符串</param>
        /// <returns></returns>
        public static int StrLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }
        #endregion

        #region 截取指定長度字符串
        /// <summary>
        /// 截取指定長度字符串
        /// </summary>
        /// <param name="inputString">要處理的字符串</param>
        /// <param name="len">指定長度</param>
        /// <returns>返回處理後的字符串</returns>
        public static string ClipString(string inputString, int len)
        {
            bool isShowFix = false;
            if (len % 2 == 1)
            {
                isShowFix = true;
                len--;
            }
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }

            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (isShowFix && mybyte.Length > len)
                tempString += "…";
            return tempString;
        }
        #endregion

        #region 獲得兩個日期的間隔
        /// <summary>
        /// 獲得兩個日期的間隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期間隔TimeSpan。</returns>
        public static TimeSpan DateDiff(DateTime DateTime1, DateTime DateTime2)
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

        #region HTML轉行成TEXT
        /// <summary>
        /// HTML轉行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToTxt(string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>.*?</script>",
            @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);", 
            @"&(nbsp|#160);", 
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }
        #endregion

        #region 判斷對象是否為空
        /// <summary>
        /// 判斷對象是否為空，為空返回true
        /// </summary>
        /// <typeparam name="T">要驗證的對象的類型</typeparam>
        /// <param name="data">要驗證的對象</param>        
        public static bool IsNullOrEmpty<T>(T data)
        {
            //如果為null
            if (data == null)
            {
                return true;
            }

            //如果為""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果為DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不為空
            return false;
        }

        /// <summary>
        /// 判斷對象是否為空，為空返回true
        /// </summary>
        /// <param name="data">要驗證的對象</param>
        public static bool IsNullOrEmpty(object data)
        {
            //如果為null
            if (data == null)
            {
                return true;
            }

            //如果為""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果為DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不為空
            return false;
        }
        #endregion

        #region 驗證IP地址是否合法
        /// <summary>
        /// 驗證IP地址是否合法
        /// </summary>
        /// <param name="ip">要驗證的IP地址</param>        
        public static bool IsIP(string ip)
        {
            //如果為空，認為驗證合格
            if (IsNullOrEmpty(ip))
            {
                return true;
            }

            //清除要驗證字符串中的空格
            ip = ip.Trim();

            //模式字符串
            string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";

            //驗證
            return RegexHelper.IsMatch(ip, pattern);
        }
        #endregion

        #region  驗證EMail是否合法
        /// <summary>
        /// 驗證EMail是否合法
        /// </summary>
        /// <param name="email">要驗證的Email</param>
        public static bool IsEmail(string email)
        {
            //如果為空，認為驗證不合格
            if (IsNullOrEmpty(email))
            {
                return false;
            }

            //清除要驗證字符串中的空格
            email = email.Trim();

            //模式字符串
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

            //驗證
            return RegexHelper.IsMatch(email, pattern);
        }
        #endregion

        #region 驗證是否為整數
        /// <summary>
        /// 驗證是否為整數 如果為空，認為驗證不合格 返回false
        /// </summary>
        /// <param name="number">要驗證的整數</param>        
        public static bool IsInt(string number)
        {
            //如果為空，認為驗證不合格
            if (IsNullOrEmpty(number))
            {
                return false;
            }

            //清除要驗證字符串中的空格
            number = number.Trim();

            //模式字符串
            string pattern = @"^[0-9]+[0-9]*$";

            //驗證
            return RegexHelper.IsMatch(number, pattern);
        }
        #endregion

        #region 驗證是否為數字
        /// <summary>
        /// 驗證是否為數字
        /// </summary>
        /// <param name="number">要驗證的數字</param>        
        public static bool IsNumber(string number)
        {
            //如果為空，認為驗證不合格
            if (IsNullOrEmpty(number))
            {
                return false;
            }

            //清除要驗證字符串中的空格
            number = number.Trim();

            //模式字符串
            string pattern = @"^[0-9]+[0-9]*[.]?[0-9]*$";

            //驗證
            return RegexHelper.IsMatch(number, pattern);
        }
        #endregion

        #region 驗證日期是否合法
        /// <summary>
        /// 驗證日期是否合法,對不規則的作了簡單處理
        /// </summary>
        /// <param name="date">日期</param>
        public static bool IsDate(ref string date)
        {
            //如果為空，認為驗證合格
            if (IsNullOrEmpty(date))
            {
                return true;
            }

            //清除要驗證字符串中的空格
            date = date.Trim();

            //替換\
            date = date.Replace(@"\", "-");
            //替換/
            date = date.Replace(@"/", "-");

            //如果查找到漢字"今",則認為是當前日期
            if (date.IndexOf("今") != -1)
            {
                date = DateTime.Now.ToString();
            }

            try
            {
                //用轉換測試是否為規則的日期字符
                date = Convert.ToDateTime(date).ToString("d");
                return true;
            }
            catch
            {
                //如果日期字符串中存在非數字，則返回false
                if (!IsInt(date))
                {
                    return false;
                }

                #region 對純數字進行解析
                //對8位純數字進行解析
                if (date.Length == 8)
                {
                    //獲取年月日
                    string year = date.Substring(0, 4);
                    string month = date.Substring(4, 2);
                    string day = date.Substring(6, 2);

                    //驗證合法性
                    if (Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > 2100)
                    {
                        return false;
                    }
                    if (Convert.ToInt32(month) > 12 || Convert.ToInt32(day) > 31)
                    {
                        return false;
                    }

                    //拼接日期
                    date = Convert.ToDateTime(year + "-" + month + "-" + day).ToString("d");
                    return true;
                }

                //對6位純數字進行解析
                if (date.Length == 6)
                {
                    //獲取年月
                    string year = date.Substring(0, 4);
                    string month = date.Substring(4, 2);

                    //驗證合法性
                    if (Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > 2100)
                    {
                        return false;
                    }
                    if (Convert.ToInt32(month) > 12)
                    {
                        return false;
                    }

                    //拼接日期
                    date = Convert.ToDateTime(year + "-" + month).ToString("d");
                    return true;
                }

                //對5位純數字進行解析
                if (date.Length == 5)
                {
                    //獲取年月
                    string year = date.Substring(0, 4);
                    string month = date.Substring(4, 1);

                    //驗證合法性
                    if (Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > 2100)
                    {
                        return false;
                    }

                    //拼接日期
                    date = year + "-" + month;
                    return true;
                }

                //對4位純數字進行解析
                if (date.Length == 4)
                {
                    //獲取年
                    string year = date.Substring(0, 4);

                    //驗證合法性
                    if (Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > 2100)
                    {
                        return false;
                    }

                    //拼接日期
                    date = Convert.ToDateTime(year).ToString("d");
                    return true;
                }
                #endregion

                return false;
            }
        }
        #endregion

        #region 驗證身份證是否合法
        /// <summary>
        /// 驗證身份證是否合法
        /// </summary>
        /// <param name="idCard">要驗證的身份證</param>        
        public static bool IsIdCard(string idCard)
        {
            //如果為空，認為驗證合格
            if (IsNullOrEmpty(idCard))
            {
                return true;
            }

            //清除要驗證字符串中的空格
            idCard = idCard.Trim();

            //模式字符串
            StringBuilder pattern = new StringBuilder();
            pattern.Append(@"^(11|12|13|14|15|21|22|23|31|32|33|34|35|36|37|41|42|43|44|45|46|");
            pattern.Append(@"50|51|52|53|54|61|62|63|64|65|71|81|82|91)");
            pattern.Append(@"(\d{13}|\d{15}[\dx])$");

            //驗證
            return RegexHelper.IsMatch(idCard, pattern.ToString());
        }
        #endregion

        #region 檢測客戶的輸入中是否有危險字符串
        /// <summary>
        /// 檢測客戶輸入的字符串是否有效,並將原始字符串修改為有效字符串或空字符串。
        /// 當檢測到客戶的輸入中有攻擊性危險字符串,則返回false,有效返回true。
        /// </summary>
        /// <param name="input">要檢測的字符串</param>
        public static bool IsValidInput(ref string input)
        {
            try
            {
                if (IsNullOrEmpty(input))
                {
                    //如果是空值,則跳出
                    return true;
                }
                else
                {
                    //替換單引號
                    input = input.Replace("'", "''").Trim();

                    //檢測攻擊性危險字符串
                    string testString = "and |or |exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
                    string[] testArray = testString.Split('|');
                    foreach (string testStr in testArray)
                    {
                        if (input.ToLower().IndexOf(testStr) != -1)
                        {
                            //檢測到攻擊字符串,清空傳入的值
                            input = "";
                            return false;
                        }
                    }

                    //未檢測到攻擊字符串
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
