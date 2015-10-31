
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Data;

namespace DotNet.Utilities.Json
{
    public class JsonHelper
    {
        /// <summary>
        /// json反序列化
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static object jsonDes<T>(string input)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(input);
        }
        public static string json(object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(obj);
        }

        #region 通用

        /// <summary>檢查字符串是否json格式</summary>
        /// <param name="jText"></param>
        /// <returns></returns>
        public static bool IsJson(string jText)
        {
            if (string.IsNullOrEmpty(jText) || jText.Length < 3)
            {
                return false;
            }

            if (jText.Substring(0, 2) == "{\"" || jText.Substring(0, 3) == "[{\"")
            {
                return true;
            }
            return false;
        }

        /// <summary>檢查字符串是否json格式數組</summary>
        /// <param name="jText"></param>
        /// <returns></returns>
        public static bool IsJsonRs(string jText)
        {
            if (string.IsNullOrEmpty(jText) || jText.Length < 3)
            {
                return false;
            }

            if (jText.Substring(0, 3) == "[{\"")
            {
                return true;
            }
            return false;
        }

        /// <summary>格式化 json</summary>
        /// <param name="jText"></param>
        /// <returns></returns>
        public static string Fmt_Null(string jText)
        {
            return StringHelper.ReplaceString(jText, ":null,", ":\"\",", true);
        }

        /// <summary>格式化 json ，刪除左右二邊的[]</summary>
        /// <param name="jText"></param>
        /// <returns></returns>
        public static string Fmt_Rs(string jText)
        {
            jText = jText.Trim();
            jText = jText.Trim('[');
            jText = jText.Trim(']');
            return jText;
        }

        #endregion

        #region Json序列化

        /// <summary>序列化</summary>
        /// <param name="obj">object </param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            var idtc = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" };

            return JsonConvert.SerializeObject(obj, idtc);
        }


        /// <summary>序列化--sql</summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>   
        public static string ToJson_FromSQL(DataTable dt)
        {
            string ss = ToJson(dt);
            dt.Dispose();
            return ss;
        }

        #endregion

        #region Json反序列化

        /// <summary>反序列化</summary>
        /// <param name="jText"></param>
        /// <returns></returns>      
        public static DataTable ToDataTable(string jText)
        {
            if (string.IsNullOrEmpty(jText))
            {
                return null;
            }
            else
            {
                try
                {
                    return JsonConvert.DeserializeObject<DataTable>(jText);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>反序列化</summary>
        /// <typeparam name="T">類型</typeparam>
        /// <param name="jText">json字符串</param>
        /// <returns>類型數據</returns>
        public static T ToObject<T>(string jText)
        {
            return (T)JsonConvert.DeserializeObject(jText, typeof(T));
        }

        #endregion
    }
}
