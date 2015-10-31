/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Text;

namespace DotNet.Utilities
{
    //頁面中彈出對話框
    public class MessageBox
    {
        private MessageBox()
        {
        }

        #region 顯示消息提示對話框
        /// <summary>
        /// 顯示消息提示對話框
        /// </summary>
        /// <param name="page">當前頁面指針，一般為this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
           // page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        #endregion

        #region 控件點擊 消息確認提示框

        /// <summary>
        /// 控件點擊 消息確認提示框
        /// </summary>
        /// <param name="page">當前頁面指針，一般為this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }
        #endregion

        #region 顯示消息提示對話框，並進行頁面跳轉
        /// <summary>
        /// 顯示消息提示對話框，並進行頁面跳轉
        /// </summary>
        /// <param name="page">當前頁面指針，一般為this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳轉的目標URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("location.href='{0}'", url);
            Builder.Append("</script>");
            //page.RegisterStartupScript("message", Builder.ToString());
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url, bool top)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            if (top == true)
            {
                Builder.AppendFormat("top.location.href='{0}'", url);
            }
            else
            {
                Builder.AppendFormat("location.href='{0}'", url);
            }
            Builder.Append("</script>");
           // page.RegisterStartupScript("message", Builder.ToString());
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        #endregion

        #region 輸出自定義腳本信息
        /// <summary>
        /// 輸出自定義腳本信息
        /// </summary>
        /// <param name="page">當前頁面指針，一般為this</param>
        /// <param name="script">輸出腳本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            //page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        #endregion

    }
}