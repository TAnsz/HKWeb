/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Web;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// QueryString 地址欄參數
    /// </summary>
    public class QueryString
    {
        #region 等於Request.QueryString;如果為null 返回 空「」 ，否則返回Request.QueryString[name]
        /// <summary>
        /// 等於Request.QueryString;如果為null 返回 空「」 ，否則返回Request.QueryString[name]
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Q(string name)
        {
            return Request.QueryString[name] == null ? "" : Request.QueryString[name];
        }
        #endregion
        /// <summary>
        /// 等於  Request.Form  如果為null 返回 空「」 ，否則返回 Request.Form[name]
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string F(string name)
        {
            return Request.Form[name] == null ? "" : Request.Form[name].ToString();
        }
        #region 獲取url中的id
        /// <summary>
        /// 獲取url中的id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int QId(string name)
        {
            return StrToId(Q(name));
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
        /// 檢查一個字符串是否是純數字構成的，一般用於查詢字符串參數的有效性驗證。
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

        #region 類內部調用
        /// <summary>
        /// HttpContext Current
        /// </summary>
        public static HttpContext Current
        {
            get { return HttpContext.Current; }
        }
        /// <summary>
        /// HttpContext Current  HttpRequest Request   get { return Current.Request;
        /// </summary>
        public static HttpRequest Request
        {
            get { return Current.Request; }
        }
        /// <summary>
        ///  HttpContext Current  HttpRequest Request   get { return Current.Request; HttpResponse Response  return Current.Response;
        /// </summary>
        public static HttpResponse Response
        {
            get { return Current.Response; }
        }
        #endregion
    }
}
