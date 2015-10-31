/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web;
using System.Threading;
using System.Diagnostics;

namespace DotNet.Utilities
{
    /// <summary>
    /// 系統操作相關的公共類
    /// </summary>    
    public static class SysHelper
    {
        #region 獲取文件相對路徑映射的物理路徑
        /// <summary>
        /// 獲取文件相對路徑映射的物理路徑
        /// </summary>
        /// <param name="virtualPath">文件的相對路徑</param>        
        public static string GetPath(string virtualPath)
        {

            return HttpContext.Current.Server.MapPath(virtualPath);

        }
        #endregion

        #region 獲取指定調用層級的方法名
        /// <summary>
        /// 獲取指定調用層級的方法名
        /// </summary>
        /// <param name="level">調用的層數</param>        
        public static string GetMethodName(int level)
        {
            //創建一個堆棧跟蹤
            StackTrace trace = new StackTrace();

            //獲取指定調用層級的方法名
            return trace.GetFrame(level).GetMethod().Name;
        }
        #endregion

        #region 獲取GUID值
        /// <summary>
        /// 獲取GUID值
        /// </summary>
        public static string NewGUID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        #endregion

        #region 獲取換行字符
        /// <summary>
        /// 獲取換行字符
        /// </summary>
        public static string NewLine
        {
            get
            {
                return Environment.NewLine;
            }
        }
        #endregion

        #region 獲取當前應用程序域
        /// <summary>
        /// 獲取當前應用程序域
        /// </summary>
        public static AppDomain CurrentAppDomain
        {
            get
            {
                return Thread.GetDomain();
            }
        }
        #endregion
    }
}
