/// <summary>
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Web;

namespace DotNet.Utilities
{
    public static class SessionHelper2
    {
        /// <summary>
        /// 添加Session，調動有效期為20分鐘
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        /// <param name="strValue">Session值</param>
        public static void Add(string strSessionName, string strValue)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>
        /// 添加Session，調動有效期為20分鐘
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        /// <param name="strValues">Session值數組</param>
        public static void Adds(string strSessionName, string[] strValues)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        /// <param name="strValue">Session值</param>
        /// <param name="iExpires">調動有效期（分鐘）</param>
        public static void Add(string strSessionName, string strValue, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        /// <param name="strValues">Session值數組</param>
        /// <param name="iExpires">調動有效期（分鐘）</param>
        public static void Adds(string strSessionName, string[] strValues, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// 讀取某個Session對像值
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        /// <returns>Session對像值</returns>
        public static string Get(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName].ToString();
            }
        }

        /// <summary>
        /// 讀取某個Session對像值數組
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        /// <returns>Session對像值數組</returns>
        public static string[] Gets(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return (string[])HttpContext.Current.Session[strSessionName];
            }
        }

        /// <summary>
        /// 刪除某個Session對像
        /// </summary>
        /// <param name="strSessionName">Session對像名稱</param>
        public static void Del(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }
    }
}