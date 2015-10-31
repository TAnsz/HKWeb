/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Utilities
{
    /// <summary>
    /// 頁面常用方法包裝
    /// </summary>
    public class ShowMessageBox
    {
        #region 信息顯示

        /// <summary>
        /// 顯示提示信息
        /// </summary>
        /// <param name="message"></param>
        public static void ShowMG(string message)
        {
            WriteScript("alert('" + message + "');");
        }


        /// <summary>
        /// 顯示提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        public static void ShowMessage(string message)
        {
            ShowMessage("系統提示", 180, 120, message);
        }


        /// <summary>
        /// 顯示提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        public static void ShowMessage_link(string message, string linkurl)
        {
            ShowMessage_link("系統提示", 180, 120, message, linkurl, 8000, -1);
        }

        /// <summary>
        /// 顯示提示信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="message">提示信息</param>
        private static void ShowMessage(string title, int width, int height, string message)
        {
            ShowMessage(title, width, height, message, 3000, -1);
        }

        /// <summary>
        /// 顯示提示信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="message"></param>
        /// <param name="delayms"></param>
        /// <param name="leftSpace"></param>
        private static void ShowMessage(string title, int width, int height, string message, int delayms, int leftSpace)
        {
            WriteScript(string.Format("popMessage({0},{1},'{2}','{3}',{4},{5});", width, height, title, message, delayms, leftSpace == -1 ? "null" : leftSpace.ToString()));
        }


        /// <summary>
        /// 顯示提示信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="message"></param>
        /// <param name="delayms"></param>
        /// <param name="leftSpace"></param>
        private static void ShowMessage_link(string title, int width, int height, string message, string linkurl, int delayms, int leftSpace)
        {
            WriteScript(string.Format("popMessage2({0},{1},'{2}','{3}','{4}',{5},{6});", width, height, title, message, linkurl, delayms, leftSpace == -1 ? "null" : leftSpace.ToString()));
        }


        #endregion

        #region 顯示異常信息

        /// <summary>
        /// 顯示異常信息
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowExceptionMessage(Exception ex)
        {
            ShowExceptionMessage(ex.Message);
        }

        /// <summary>
        /// 顯示異常信息
        /// </summary>
        /// <param name="message"></param>
        public static void ShowExceptionMessage(string message)
        {
            WriteScript("alert('" + message + "');");
            //PageHelper.ShowExceptionMessage("錯誤提示", 210, 125, message);
        }

        /// <summary>
        /// 顯示異常信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="message"></param>
        private static void ShowExceptionMessage(string title, int width, int height, string message)
        {
            WriteScript(string.Format("setTimeout(\"showAlert('{0}',{1},{2},'{3}')\",100);", title, width, height, message));
        }
        #endregion

        #region 顯示模態窗口

        /// <summary>
        /// 返回把指定鏈接地址顯示模態窗口的腳本
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="url"></param>
        public static string GetShowModalWindowScript(string wid, string title, int width, int height, string url)
        {
            return string.Format("setTimeout(\"showModalWindow('{0}','{1}',{2},{3},'{4}')\",100);", wid, title, width, height, url);
        }

        /// <summary>
        /// 把指定鏈接地址顯示模態窗口
        /// </summary>
        /// <param name="wid">窗口ID</param>
        /// <param name="title">標題</param>
        /// <param name="width">寬度</param>
        /// <param name="height">高度</param>
        /// <param name="url">鏈接地址</param>
        public static void ShowModalWindow(string wid, string title, int width, int height, string url)
        {
            WriteScript(GetShowModalWindowScript(wid, title, width, height, url));
        }

        /// <summary>
        /// 為指定控件綁定前台腳本：顯示模態窗口
        /// </summary>
        /// <param name="control"></param>
        /// <param name="eventName"></param>
        /// <param name="wid"></param>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="url"></param>
        /// <param name="isScriptEnd"></param>
        public static void ShowCilentModalWindow(string wid, WebControl control, string eventName, string title, int width, int height, string url, bool isScriptEnd)
        {
            string script = isScriptEnd ? "return false;" : "";
            control.Attributes[eventName] = string.Format("showModalWindow('{0}','{1}',{2},{3},'{4}');" + script, wid, title, width, height, url);
        }

        /// <summary>
        /// 為指定控件綁定前台腳本：顯示模態窗口
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="eventName"></param>
        /// <param name="wid"></param>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="url"></param>
        /// <param name="isScriptEnd"></param>
        public static void ShowCilentModalWindow(string wid, TableCell cell, string eventName, string title, int width, int height, string url, bool isScriptEnd)
        {
            string script = isScriptEnd ? "return false;" : "";
            cell.Attributes[eventName] = string.Format("showModalWindow('{0}','{1}',{2},{3},'{4}');" + script, wid, title, width, height, url);
        }
        #endregion

        #region 顯示客戶端確認窗口
        /// <summary>
        /// 顯示客戶端確認窗口
        /// </summary>
        /// <param name="control"></param>
        /// <param name="eventName"></param>
        /// <param name="message"></param>
        public static void ShowCilentConfirm(WebControl control, string eventName, string message)
        {
            ShowCilentConfirm(control, eventName, "系統提示", 210, 125, message);
        }

        /// <summary>
        /// 顯示客戶端確認窗口
        /// </summary>
        /// <param name="control"></param>
        /// <param name="eventName"></param>
        /// <param name="title"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="message"></param>
        public static void ShowCilentConfirm(WebControl control, string eventName, string title, int width, int height, string message)
        {
            control.Attributes[eventName] = string.Format("return showConfirm('{0}',{1},{2},'{3}','{4}');", title, width, height, message, control.ClientID);
        }


        #endregion

        /// <summary>
        /// 寫javascript腳本
        /// </summary>
        /// <param name="script">腳本內容</param>
        public static void WriteScript(string script)
        {
            Page page = GetCurrentPage();

            // NDGridViewScriptFirst(page.Form.Controls, page);

            page.ClientScript.RegisterStartupScript(page.GetType(), System.Guid.NewGuid().ToString(), script, true);

        }

        /// <summary>
        /// 得到當前頁對像實例
        /// </summary>
        /// <returns></returns>
        public static Page GetCurrentPage()
        {
            return (Page)HttpContext.Current.Handler;
        }


    }
}
