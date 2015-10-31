/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace DotNet.Utilities
{
    public class BasePage :System.Web.UI.Page
    {
        public BasePage()
        {
            //
            //TODO: 在此處添加構造函數邏輯
            //
        }

        public static string Title = "標題";
        public static string keywords = "關鍵字";
        public static string description = "網站描述";

        protected override void OnInit(EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString().Trim() == "")
            {
                Response.Redirect("login.aspx");
            }
            base.OnInit(e);
        }

        protected void ExportData(string strContent, string FileName)
        {

            FileName = FileName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

            Response.Clear();
            Response.Charset = "gb2312";
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            //this.Page.EnableViewState = false; 
            // 添加頭信息，為"文件下載/另存為"對話框指定默認文件名 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls");
            // 把文件流發送到客戶端 
            Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">");
            Response.Write(strContent);
            Response.Write("</body></html>");
            // 停止頁面的執行 
            //Response.End();
        }

        /// <summary>
        /// 導出Excel
        /// </summary>
        /// <param name="obj"></param>
        public void ExportData(GridView obj)
        {
            try
            {
                string style = "";
                if (obj.Rows.Count > 0)
                {
                    style = @"<style> .text { mso-number-format:\@; } </script> ";
                }
                else
                {
                    style = "no data.";
                }

                Response.ClearContent();
                DateTime dt = DateTime.Now;
                string filename = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString();
                Response.AddHeader("content-disposition", "attachment; filename=ExportData" + filename + ".xls");
                Response.ContentType = "application/ms-excel";
                Response.Charset = "GB2312";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                obj.RenderControl(htw);
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
            catch
            {
            }
        }
    }
}
