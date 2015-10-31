/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// 字符串操作類
    /// 1、GetStrArray(string str, char speater, bool toLower)  把字符串按照分隔符轉換成 List
    /// 2、GetStrArray(string str) 把字符串轉 按照, 分割 換為數據
    /// 3、GetArrayStr(List list, string speater) 把 List 按照分隔符組裝成 string
    /// 4、GetArrayStr(List list)  得到數組列表以逗號分隔的字符串
    /// 5、GetArrayValueStr(Dictionary<int, int> list)得到數組列表以逗號分隔的字符串
    /// 6、DelLastComma(string str)刪除最後結尾的一個逗號
    /// 7、DelLastChar(string str, string strchar)刪除最後結尾的指定字符後的字符
    /// 8、ToSBC(string input)轉全角的函數(SBC case)
    /// 9、ToDBC(string input)轉半角的函數(SBC case)
    /// 10、GetSubStringList(string o_str, char sepeater)把字符串按照指定分隔符裝成 List 去除重複
    /// 11、GetCleanStyle(string StrList, string SplitString)將字符串樣式轉換為純字符串
    /// 12、GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)將字符串轉換為新樣式
    /// 13、SplitMulti(string str, string splitstr)分割字符串
    /// 14、SqlSafeString(string String, bool IsDel)
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 把字符串按照分隔符轉換成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否轉換為小寫</param>
        /// <returns></returns>
        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        /// <summary>
        /// 把字符串轉 按照, 分割 換為數據
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] GetArrayStr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else
            {
                return str.Split(new Char[] { ',' });
            }
        }
        /// <summary>
        /// 把 List<string> 按照分隔符組裝成 string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="speater"></param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 得到數組列表以逗號分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetArrayStr(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i].ToString());
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 得到數組列表以逗號分隔的字符串
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetArrayValueStr(Dictionary<int, int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<int, int> kvp in list)
            {
                sb.Append(kvp.Value + ",");
            }
            if (list.Count > 0)
            {
                return DelLastComma(sb.ToString());
            }
            else
            {
                return "";
            }
        }

        /// <summary>自定義的替換字符串函數</summary>
        /// <param name="SourceString">原字符串</param>
        /// <param name="SearchString">查找的字符串</param>
        /// <param name="ReplaceString">替換的字符串</param>
        /// <param name="IsCaseInse">是否區分大小寫,true=不區分,false=區分大小寫</param>
        /// <returns></returns>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInse)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInse ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        #region 刪除最後一個字符之後的字符

        /// <summary>
        /// 刪除最後結尾的一個逗號
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        /// <summary>
        /// 刪除最後結尾的指定字符後的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        #endregion

        #region 刪除字符串左右兩邊的分隔符號
        /// <summary>刪除字符串左右兩邊的分隔符號</summary>
        /// <param name="str">字符串</param>
        /// <param name="key">分隔符,默認為,</param>
        /// <returns></returns>
        public static string DelStrSign(string str, string key = ",")
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(key))
            {
                return "";
            }

            int iSpace = 0;
            //查找字符串頭部多個連續的分隔符數量，比如,,,1,2,3,,,
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == key)
                {
                    iSpace++;
                }
                else
                {
                    break;
                }
            }
            //刪除分隔符
            if (iSpace > 0)
            {
                str = str.Remove(0, iSpace);
            }

            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            iSpace = 0;
            //查找字符串尾部多個連續的分隔符數量，比如,,,1,2,3,,,
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i].ToString() == key)
                {
                    iSpace++;
                }
                else
                {
                    break;
                }
            }
            //刪除分隔符
            if (iSpace > 0)
            {
                str = str.Remove((str.Length - iSpace), iSpace);
            }
            return str;
        }
        #endregion

        #region 全角與半角轉換
        /// <summary>
        /// 轉全角的函數(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角轉全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  轉半角的函數(SBC case)
        /// </summary>
        /// <param name="input">輸入</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        /// <summary>
        /// 把字符串按照指定分隔符裝成 List 去除重複
        /// </summary>
        /// <param name="o_str"></param>
        /// <param name="sepeater"></param>
        /// <returns></returns>
        public static List<string> GetSubStringList(string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            string[] ss = o_str.Split(sepeater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != sepeater.ToString())
                {
                    list.Add(s);
                }
            }
            return list;
        }


        #region 將字符串樣式轉換為純字符串
        /// <summary>
        ///  將字符串樣式轉換為純字符串
        /// </summary>
        /// <param name="StrList"></param>
        /// <param name="SplitString"></param>
        /// <returns></returns>
        public static string GetCleanStyle(string StrList, string SplitString)
        {
            string RetrunValue = "";
            //如果為空，返回空值
            if (StrList == null)
            {
                RetrunValue = "";
            }
            else
            {
                //返回去掉分隔符
                string NewString = "";
                NewString = StrList.Replace(SplitString, "");
                RetrunValue = NewString;
            }
            return RetrunValue;
        }
        #endregion

        #region 將字符串轉換為新樣式
        /// <summary>
        /// 將字符串轉換為新樣式
        /// </summary>
        /// <param name="StrList"></param>
        /// <param name="NewStyle"></param>
        /// <param name="SplitString"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public static string GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)
        {
            string ReturnValue = "";
            //如果輸入空值，返回空，並給出錯誤提示
            if (StrList == null)
            {
                ReturnValue = "";
                Error = "請輸入需要劃分格式的字符串";
            }
            else
            {
                //檢查傳入的字符串長度和樣式是否匹配,如果不匹配，則說明使用錯誤。給出錯誤信息並返回空值
                int strListLength = StrList.Length;
                int NewStyleLength = GetCleanStyle(NewStyle, SplitString).Length;
                if (strListLength != NewStyleLength)
                {
                    ReturnValue = "";
                    Error = "樣式格式的長度與輸入的字符長度不符，請重新輸入";
                }
                else
                {
                    //檢查新樣式中分隔符的位置
                    string Lengstr = "";
                    for (int i = 0; i < NewStyle.Length; i++)
                    {
                        if (NewStyle.Substring(i, 1) == SplitString)
                        {
                            Lengstr = Lengstr + "," + i;
                        }
                    }
                    if (Lengstr != "")
                    {
                        Lengstr = Lengstr.Substring(1);
                    }
                    //將分隔符放在新樣式中的位置
                    string[] str = Lengstr.Split(',');
                    foreach (string bb in str)
                    {
                        StrList = StrList.Insert(int.Parse(bb), SplitString);
                    }
                    //給出最後的結果
                    ReturnValue = StrList;
                    //因為是正常的輸出，沒有錯誤
                    Error = "";
                }
            }
            return ReturnValue;
        }
        #endregion

        #region 分割字符串
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitstr"></param>
        /// <returns></returns>
        public static string[] SplitMulti(string str, string splitstr)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(splitstr))
            {
                return new string[0] { };
            }

            string[] strArray = new Regex(splitstr).Split(str);

            return strArray;
        }
        #endregion
        
        #region 獲取正確的Id，如果不是正整數，返回0
        /// <summary>
        /// 獲取正確的Id，如果不是正整數，返回0
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>返回正確的整數ID，失敗返回0</returns>
        public static int StrToId(string _value)
        {
            if (IsNumberId(_value))
                return int.Parse(_value);
            else
                return 0;
        }
        #endregion

        #region 檢查一個字符串是否是純數字構成的，一般用於查詢字符串參數的有效性驗證。
        /// <summary>
        /// 檢查一個字符串是否是純數字構成的，一般用於查詢字符串參數的有效性驗證。(0除外)
        /// </summary>
        /// <param name="_value">需驗證的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumberId(string _value)
        {
            return QuickValidate("^[1-9]*[0-9]*$", _value);
        }
        #endregion

        #region 快速驗證一個字符串是否符合指定的正則表達式。
        /// <summary>
        /// 快速驗證一個字符串是否符合指定的正則表達式。
        /// </summary>
        /// <param name="_express">正則表達式的內容。</param>
        /// <param name="_value">需驗證的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(string _express, string _value)
        {
            if (_value == null) return false;
            Regex myRegex = new Regex(_express);
            if (_value.Length == 0)
            {
                return false;
            }
            return myRegex.IsMatch(_value);
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
        /// 截取指定長度字符串——區分中英文字符長度
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

        /// <summary>截取字符串,從左邊算起 n 個字,並經過 SQL注入過濾 處理(不區分中英文長度)，默認去左右兩邊空格與過濾XSS攻擊字符</summary>
        /// <param name="str">字符串</param>
        /// <param name="length">截取的長度(字數)</param>
        /// <param name="isTrim">true=使用Trim(),falae=原文</param>
        /// <param name="isFilterXss">是否去除特殊符號</param>
        /// <returns></returns>
        public static string Left(string str, int length, bool isTrim = true, bool isFilterXss = true)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = FilterSql(str, isTrim, isFilterXss);

            if (length > 0)
            {
                if (str.Length > length)
                {
                    str = str.Substring(0, length);
                }
                return str;
            }
            return str;
        }

        /// <summary>從字符串右邊返回指定數目的字符——簡單截取</summary>
        /// <param name="str">字符串</param>
        /// <param name="length">截取的長度(字數)</param>
        /// <returns></returns>
        public static string Right(string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            if (length > 0)
            {
                if (str.Length > length)
                {
                    int pos = str.Length - length;
                    return str.Substring(pos);
                }
                return str;
            }
            return str;
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

        #region 安全操作函數


        public static string SqlSafeString(string String, bool IsDel)
        {
            if (IsDel)
            {
                String = String.Replace("'", "");
                String = String.Replace("\"", "");
                return String;
            }
            String = String.Replace("'", "&#39;");
            String = String.Replace("\"", "&#34;");
            return String;
        }

        /// <summary>過濾 Sql 語句字符串中的注入腳本
        /// </summary>
        /// <param name="source">傳入的字符串</param>
        /// <param name="isTrim">是否去除字符串兩邊的空格</param>
        /// <param name="isFilterXss">是否去除特殊符號</param>
        /// <returns></returns>
        public static string FilterSql(string source, bool isTrim = true, bool isFilterXss = false)
        {
            if (string.IsNullOrEmpty(source))
            {
                return "";
            }
            //去空格
            if (isTrim) source = source.Trim();

            //去除'
            source = source.Replace("'", "");

            //去除執行存儲過程的命令關鍵字
            source = source.Replace("Exec", "");

            //去除系統存儲過程或擴展存儲過程關鍵字
            source = source.Replace("xp_", "x p_");
            source = source.Replace("sp_", "s p_");
            //防止16進制注入
            source = source.Replace(new string((char)0, 1), "");

            if (isFilterXss)
            {
                source = XssTextClear(source);
            }
            return source;

        }

        /// <summary>清除輸入字符串中的特殊字符
        /// </summary>
        /// <param name="xssText">輸入字符串</param>
        /// <returns>處理後的字符串</returns>
        public static string XssTextClear(string xssText)
        {
            if (string.IsNullOrEmpty(xssText))
            {
                return "";
            }
            xssText = xssText.Trim();
            xssText = xssText.Replace("<", "").Replace("%3C", "");//去除<
            xssText = xssText.Replace(">", "").Replace("%3E", "");//去除>
            xssText = xssText.Replace("'", "").Replace("%27", "");//去除'
            xssText = xssText.Replace("\"", "");
            xssText = xssText.Replace("\\", "");
            xssText = xssText.Replace("/", "");
            xssText = xssText.Replace("=", "");
            xssText = xssText.Replace("%", "");
            xssText = xssText.Replace("#", "");
            xssText = xssText.Replace("&", "");
            xssText = xssText.Replace("(", "（");
            xssText = xssText.Replace(")", "）");
            xssText = xssText.Replace("^", "");
            xssText = xssText.Replace("{", "");
            xssText = xssText.Replace("}", "");
            xssText = xssText.Replace("*", "");
            return xssText;
        }
        #endregion

        #region 驗證操作函數
        /// <summary> 檢查字符串裡每個字是否都在指定字符集內的字.
        /// 比如:整數(0123456789)
        /// 字母(abcdefghijklmnopqrstuvwxyz)
        /// </summary>
        /// <param name="sValue">字符串</param>
        /// <param name="sCompate">字符集</param>
        /// <returns>true=在字符集內,false=存在非字符集的字</returns>
        public static bool IsExistValue(string sValue, string sCompate)
        {
            if (string.IsNullOrEmpty(sValue) || string.IsNullOrEmpty(sCompate))
            {
                return false;
            }

            string sComp = sCompate.ToLower();
            string str = sValue.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (sComp.IndexOf(str[i]) == -1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>檢查輸入是否為指字內容,檢查id列(用於數據庫查詢),"34,5,1,8"</summary>
        /// <param name="str">字符串,分隔符默認為,</param>
        /// <returns>true=是id列,false=非id列</returns>
        public static bool IsIdList(string str)
        {
            string key = ",";
            return IsIdList(str, key);
        }

        /// <summary>檢查輸入是否為指字內容,檢查id列(用於數據庫查詢),"34,5,1,8"</summary>
        /// <param name="str">字符串</param>
        /// <param name="key">字符串,分隔符默認為,</param>
        /// <returns>true=是id列,false=非id列</returns>
        public static bool IsIdList(string str, string key)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return IsExistValue(str, "0123456789" + key);
        }

        /// <summary>是否為純數字字符</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumberChar(string str)
        {
            return IsExistValue(str, "0123456789");
        }

        /// <summary>檢測是否符合email格式</summary>
        /// <param name="str">要判斷的email字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            if (string.IsNullOrEmpty(str)) { return false; }
            return Regex.IsMatch(str, @"^([a-zA-Z0-9_.-]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>檢查輸入,是否由字母組成</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsEnglish(string str)
        {
            return IsExistValue(str, "abcdefghijklmnopqrstuvwxyz");
        }

        /// <summary>檢查輸入,檢查用戶註冊賬號是否合法字符(由字母,數字或"_"組成)</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsRegName(string str)
        {
            return IsExistValue(str, "abcdefghijklmnopqrstuvwxyz0123456789_");
        }

        /// <summary>檢查輸入,是否為隨機生成的文件名稱</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsRndFileName(string str)
        {
            return IsExistValue(str, "abcdefghijklmnopqrstuvwxyz0123456789_-./");
        }

        /// <summary>檢查輸入,是否為隨機生成的文件名稱(即全由字母和數字組成)</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsRndKey(string str)
        {
            return IsExistValue(str, "abcdefghijklmnopqrstuvwxyz0123456789");
        }

        /// <summary>檢查輸入,是否為隨機生成的文件名稱(即全由字母和數字組成)</summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string GetIsRndKey(string str)
        {
            if (str.Length > 0 && IsRndKey(str))
            {
                return str;
            }
            else
            {
                return "";
            }
        }

        /// <summary>檢查輸入,檢查是否為正常的手機號碼.</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobile(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            string s = @"^(13[0-9]|15[012356789]|18[012356789]|14[57])\d{8}$";

            return Regex.IsMatch(str, s);
        }

        /// <summary>判斷輸入是否為Base64編碼.</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBase64(string str)
        {
            if ((str.Length % 4) != 0)
            {
                return false;
            }
            /*
            if (!Regex.IsMatch(str, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase))
            {
                return false;
            }

            try { Convert.FromBase64String(str); }
            catch { return false; }
            */
            return true;
        }
        #endregion
    }
}
