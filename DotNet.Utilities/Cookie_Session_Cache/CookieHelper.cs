/// <summary>
/// 類說明：CookieHelper
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web;

namespace DotNet.Utilities
{
    public class CookieHelper
    {
        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        public static void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        /// <summary>
        /// 獲取指定Cookie值
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        /// <returns></returns>
        public static string GetCookieValue(string cookiename)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookiename] != null)
            {
                return HttpContext.Current.Request.Cookies[cookiename].Value;
            }

            return "";
        }

        /// <summary>讀cookie值,Cookies[key]
        /// </summary>
        /// <param name="cookiename">名稱</param>
        /// <param name="key">key</param>
        /// <returns>cookie值</returns>
        public static string GetCookieValue(string cookiename, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[cookiename] != null && HttpContext.Current.Request.Cookies[cookiename][key] != null)
            {
                return HttpContext.Current.Request.Cookies[cookiename][key].ToString();
            }

            return "";
        }

        /// <summary>
        /// 添加一個Cookie（1年後過期）
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        public static void SetCookie(string cookiename, string cookievalue)
        {
            SetCookie(cookiename, cookievalue, DateTime.Now.AddYears(1));
        }
        /// <summary>
        /// 添加一個Cookie,帶過期時間
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">過期時間 DateTime</param>
        public static void SetCookie(string cookiename, string cookievalue, DateTime expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename);
            }
            cookie.Value = cookievalue;
            cookie.Expires = expires;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>寫cookie值,Cookies[key]（1年後過期）
        /// </summary>
        /// <param name="cookiename">名稱</param>
        /// <param name="key">key</param>
        /// <param name="cookievalue">值</param>
        public static void SetCookie(string cookiename, string key, string cookievalue)
        {
            SetCookie(cookiename, key, cookievalue, DateTime.Now.AddYears(1));
        }

        /// <summary>寫cookie值,Cookies[key],帶過期時間
        /// </summary>
        /// <param name="cookiename">名稱</param>
        /// <param name="key">key</param>
        /// <param name="cookievalue">值</param>
        /// <param name="expires">過期時間(分鐘)</param>
        public static void SetCookie(string cookiename, string key, string cookievalue, DateTime expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null)
            {
                cookie = new HttpCookie(cookiename);
            }

            cookie[key] = cookievalue;
            cookie.Expires = expires;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        
    }
}
