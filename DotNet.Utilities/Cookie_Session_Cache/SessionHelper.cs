/// <summary>
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Web;

namespace DotNet.Utilities
{
    /// <summary>
    /// Session 操作類
    /// 1、GetSession(string name)根據session名獲取session對像
    /// 2、SetSession(string name, object val)設置session
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// 根據session名獲取session對像
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetSession(string name)
        {
            return HttpContext.Current.Session[name];
        }

        /// <summary>獲取指定Session的值值</summary>
        /// <param name="strName">Session的ID</param>
        /// <returns>返回Session值</returns>
        public static string GetSessionString(string strName)
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[strName] != null)
            {
                return HttpContext.Current.Session[strName] + "";
            }
            return "";
        }

        /// <summary>
        /// 設置session
        /// </summary>
        /// <param name="name">session 名</param>
        /// <param name="val">session 值</param>
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }

        /// <summary>
        /// 清空所有的Session
        /// </summary>
        /// <returns></returns>
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        /// 刪除一個指定的ession
        /// </summary>
        /// <param name="name">Session名稱</param>
        /// <returns></returns>
        public static void RemoveSession(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }

        /// <summary>
        /// 刪除所有的ession
        /// </summary>
        /// <returns></returns>
        public static void RemoveAllSession()
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}
