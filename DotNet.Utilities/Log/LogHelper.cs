using System;

namespace DotNet.Utilities.Log
{
    /// <summary>  
    /// LogHelper的摘要說明。   
    /// </summary>   
    public class LogHelper
    {
        /// <summary>
        /// 靜態只讀實體對像info信息
        /// </summary>
        public static readonly log4net.ILog Loginfo = log4net.LogManager.GetLogger("loginfo");
        /// <summary>
        ///  靜態只讀實體對像error信息
        /// </summary>
        public static readonly log4net.ILog Logerror = log4net.LogManager.GetLogger("logerror");

        /// <summary>
        ///  添加info信息
        /// </summary>
        /// <param name="info">自定義日誌內容說明</param>
        public static void WriteLog(string info)
        {
            try
            {
                if (Loginfo.IsInfoEnabled)
                {
                    Loginfo.Info(info);
                }
            }
            catch { }
        }


        /// <summary>
        /// 添加異常信息
        /// </summary>
        /// <param name="info">自定義日誌內容說明</param>
        /// <param name="ex">異常信息</param>
        public static void WriteLog(string info, Exception ex)
        {
            try
            {
                if (Logerror.IsErrorEnabled)
                {
                    Logerror.Error(info, ex);
                }
            }
            catch { }
        }
    }
}