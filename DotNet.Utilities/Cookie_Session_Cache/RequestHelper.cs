using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DotNet.Utilities
{
    public class RequestHelper
    {

        /// <summary>獲得Post提交的參數值</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="isFilterXss">是否過濾XSS</param>
        /// <returns>表單參數的值</returns>
        public static string GetFormString(string strName, bool isFilterXss = true)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }

            return StringHelper.FilterSql(HttpContext.Current.Request.Form[strName], true, isFilterXss);
        }

        /// <summary> 獲得Get提交的參數值 </summary>
        /// <param name="strName">Url參數</param>
        /// <param name="isFilterXss">是否過濾XSS</param>
        /// <returns>Url參數的值</returns>
        public static string GetQueryString(string strName, bool isFilterXss = true)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }

            return StringHelper.FilterSql(HttpContext.Current.Request.QueryString[strName], true, isFilterXss);
        }
        
        /// <summary>獲得Post提交的參數值,帶截取和sql注入過濾</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="minLen">截取的長度(字數)</param>
        /// <param name="isFilterXss">是否過濾XSS</param>
        /// <returns>表單參數的值(sql過濾,截取後)</returns>
        public static string PostText(string strName, int minLen, bool isFilterXss = true)
        {
            string str = GetFormString(strName, isFilterXss);

            if (str.Length > 0 && minLen > 0 && str.Length > minLen)
            {
                return str.Substring(0, minLen);
            }
            else
            {
                return str;
            }
        }

        /// <summary>獲得Get提交的參數值,帶截取和sql注入過濾</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="minLen">截取的長度(字數)</param>
        /// <param name="isFilterXss">是否過濾XSS</param>
        /// <returns>表單參數的值(sql過濾,截取後)</returns>
        public static string GetText(string strName, int minLen, bool isFilterXss = true)
        {
            string str = GetQueryString(strName, isFilterXss);

            if (str.Length > 0 && minLen > 0 && str.Length > minLen)
            {
                return str.Substring(0, minLen);
            }
            else
            {
                return str;
            }
        }

        /// <summary>獲得Get提交的參數值,判斷是否abcdefghijklmnopqrstuvwxyz0123456789組成的,是返回,否返回""</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="minLen">截取的長度(字數)</param>
        /// <returns>返回int型</returns>
        public static string GetKeyChar(string strName, int minLen = 32)
        {
            string str = GetText(strName, minLen);
            if (str.Length > 0 && StringHelper.IsRndKey(str))
            {
                return str;
            }
            else
            {
                return "";
            }
        }

        /// <summary>獲得Post提交的參數值,判斷是否int,是返回,否返回0</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回int型</returns>
        public static int PostInt(string strName)
        {
            string str = GetFormString(strName);
            if (str.Length > 0 && ConvertHelper.IsInt(str))
            {
                return ConvertHelper.Cint(str);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>獲得Post提交的參數值,判斷是否小於minValue,小於返回minValue</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="minValue">當Value少於該值時,返回該值</param>
        /// <returns>返回int型</returns>
        public static int PostIntMinValue(string strName, int minValue)
        {
            int str = PostInt(strName);
            if (str < minValue)
            {
                return minValue;
            }
            else
            {
                return str;
            }
        }

        /// <summary>獲得Post提交的參數值,小於0返回0,否則返回int值</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回 大於等於0的int型</returns>
        public static int PostInt0(string strName)
        {
            return PostIntMinValue(strName, 0);
        }

        /// <summary>獲得Post提交的參數值,小於1返回1,否則返回int值</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回 大於等於1的int型</returns>
        public static int PostInt1(string strName)
        {
            return PostIntMinValue(strName, 1);
        }

        /// <summary>獲得Post提交的參數值,判斷是否Long,是返回,否返回0</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回int型</returns>
        public static long PostLong(string strName)
        {
            string str = GetFormString(strName);
            if (str.Length > 0 && ConvertHelper.IsLong(str))
            {
                return ConvertHelper.Clng(str);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>獲得Post提交的參數值,判斷是否小於minValue,小於返回minValue</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="minValue">當Value少於該值時,返回該值</param>
        /// <returns>返回int型</returns>
        public static long PostLongMinValue(string strName, long minValue)
        {
            long str = PostLong(strName);
            if (str < minValue)
            {
                return minValue;
            }
            else
            {
                return str;
            }
        }

        /// <summary>獲得Post提交的參數值,小於0返回0,否則返回int值</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回 大於等於0的int型</returns>
        public static long PostLong0(string strName)
        {
            return PostLongMinValue(strName, 0);
        }

        /// <summary>獲得Post提交的參數值,小於1返回1,否則返回int值</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回 大於等於1的int型</returns>
        public static long PostLong1(string strName)
        {
            return PostLongMinValue(strName, 1);
        }


        /// <summary>獲得Get提交的參數值,判斷是否int,是返回,否返回"0"</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回int型</returns>
        public static int GetInt(string strName)
        {
            string str = GetQueryString(strName);
            if (str.Length > 0 && ConvertHelper.IsInt(str))
            {
                return ConvertHelper.Cint(str);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>獲得Get提交的參數值,判斷是否小於minValue,小於返回minValue</summary>
        /// <param name="strName">表單參數</param>
        /// <param name="minValue">當Value少於該值時,返回該值</param>
        /// <returns>返回int型</returns>
        public static int GetIntMinValue(string strName, int minValue)
        {
            int str = GetInt(strName);
            if (str < minValue)
            {
                return minValue;
            }
            else
            {
                return str;
            }
        }

        /// <summary>獲得Get提交的參數值,小於0返回0,否則返回int值</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回 大於等於0的int型</returns>
        public static int GetInt0(string strName)
        {
            return GetIntMinValue(strName, 0);
        }

        /// <summary>獲得Get提交的參數值,小於1返回1,否則返回int值</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回 大於等於1的int型</returns>
        public static int GetInt1(string strName)
        {
            return GetIntMinValue(strName, 1);
        }

        /// <summary>獲得Post提交的參數值,判斷是否double,是返回,否返回0</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回double型</returns>
        public static double PostDouble(string strName)
        {
            string str = GetFormString(strName);
            if (str.Length > 0 && ConvertHelper.IsNumeric(str))
            {
                return ConvertHelper.Cdbl(str);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>獲得Post提交的參數值,判斷是否double,是返回,否返回0</summary>
        /// <param name="strName">表單參數</param>
        /// <returns>返回double型</returns>
        public static double PostDouble0(string strName)
        {
            string str = GetFormString(strName);
            if (str.Length > 0 && ConvertHelper.IsNumeric(str))
            {
                double t = ConvertHelper.Cdbl(str);
                return (t < 0) ? 0 : t;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>獲得Url或表單參數的值(不區分Post或Get提交,同樣都取值,但Get優先處理)</summary>
        /// <param name="strName">參數</param>
        /// <param name="isFilterXss">是否過濾XSS</param>
        /// <returns>Url或表單參數的值</returns>
        public static string GetString(string strName, bool isFilterXss = true)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName, isFilterXss);
            }
            else
            {
                return GetQueryString(strName, isFilterXss);
            }
        }

        /// <summary>獲得Post提交的全部值</summary>
        /// <returns>獲得Post提交的全部值</returns>
        public static string GetFormAll(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            int ti = context.Request.Form.Count;
            if (ti > 0)
            {
                for (int i = 0; i < ti; i++)
                {
                    sb.Append(context.Request.Form.Keys[i].ToString());
                    sb.Append("=");
                    sb.AppendLine(context.Request.Form[i].ToString());
                }
            }
            return sb.ToString();
        }

        /// <summary>返回指定的服務器變量信息</summary>
        /// <param name="strName">服務器變量名</param>
        /// <returns>服務器變量信息</returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /// <summary>檢查輸入口,是否為本服務器</summary>
        /// <returns></returns>
        public static bool ChkSrcPost()
        {
            string strV1 = "", strV2 = "";
            strV1 = GetServerString("HTTP_REFERER");
            strV2 = GetServerString("SERVER_NAME");

            if (strV1.Length > 8)
                strV1 = strV1.Substring(7);

            if (strV1.Length > strV2.Length)
                strV1 = strV1.Substring(0, strV2.Length);

            return (strV1 == strV2);
        }

        /// <summary>取得當前頁面的域名</summary>
        /// <returns></returns>
        public static string GetRequestHost()
        {
            string url = "http://" + HttpContext.Current.Request.Url.Host;
            if (HttpContext.Current.Request.Url.Port != 80)
            {
                url += ":" + HttpContext.Current.Request.Url.Port;
            }
            return url;
        }

        /// <summary>取得當前頁面的域名</summary>
        /// <returns></returns>
        public static string GetRequestHost2()
        {
            string url = HttpContext.Current.Request.Url.Host;
            if (HttpContext.Current.Request.Url.Port != 80)
            {
                url += ":" + HttpContext.Current.Request.Url.Port;
            }
            return url;
        }

        /// <summary>取得當前頁面的路徑</summary>
        /// <returns></returns>
        public static string GetRequestFileName()
        {
            var fileName = System.IO.Path.GetFileName(HttpContext.Current.Request.Path);
            return fileName != null ? fileName.ToString() : "";
        }
    }
}
