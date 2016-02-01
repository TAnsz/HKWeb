using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using DotNet.Utilities.Mail;
using Solution.DataAccess.DataModel;

namespace Solution.Logic.Managers
{
    /// <summary>E-Mail封装函数</summary>
    public class MailBll
    {
        //html模板字段
        public const string Headtem = @"<!DOCTYPE html><html><head><meta http-equiv='X-UA-Compatible' content='IE=8' /><meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><title>HR Auto Send</title><meta name='viewport' content='width=device-width, initial-scale=1.0'/>
        </head><body style='margin: 0; padding: 0;'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td style='padding: 10px 0 30px 0;'><table align='center' border='0' cellpadding='0'
        cellspacing='0' width='600' style='border: 1px solid #cccccc; border-collapse: collapse;'><tr><td align='center' bgcolor='#70bbd9' style='padding: 20px 0 30px 0; color: #153643; font-size: 28px; font-weight: bold; font-family: Arial, sans-serif;'>
		<h1>{0}</h1></td></tr><tr><td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'><table border='0' cellpadding='0' cellspacing='0' width='100%'><tr>
		<td style='color: #153643; font-family: Arial, sans-serif; font-size: 24px;'><b>{1}</b></td></tr>";

        public const string Bodytem = @"<tr><td>&nbsp;</td></tr><tr><td style='background-color: #e5e5e5; padding: 10px; font-size: 20px; border-left: 3px solid #1E95EC;'>
        <strong>{0}</strong> <span style='color: #d84a38; font-size: 20px'>{1}</span></td></tr>";

        public const string Foottem = @"</table></td></tr><tr><td bgcolor='#ee4c50' style='padding: 30px 30px 30px 30px;'><table border='0' cellpadding='0' cellspacing='0' width='100%'>
		<tr><td style='color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;' width='75%'><p>點擊進人事系統: &nbsp; <a href='http://attn.kamhingintl.com' style='color: #ffffff;font-size: 18px;'><font color='#ffffff'>http://attn.kamhingintl.com</font></a>
		<p>&reg; kamhing 2015 &nbsp;by集團電腦部	</td></tr></table></td></tr></table></td></tr></table></body></html>";

        //定义单例实体
        private static MailBll _mailBll = null;

        /// <summary>构造函数</summary>
        public static MailBll GetInstence()
        {
            return _mailBll ?? (_mailBll = new MailBll());
        }

        #region test
        /// <summary>发送测试邮件</summary>
        /// <returns></returns>
        public string TestMail(string sTo = "")
        {
            string tit = "test Mail == " + DateTime.Now.ToString("yyyy-M-d");
            string msg = "test Mail == " + DateTime.Now.ToString("yyyy-M-d");

            return SendMail(sTo, tit, msg);
        }
        #endregion

        #region SendMail

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sTo">收件人邮箱</param>
        /// <param name="tit">标题</param>
        /// <param name="msg">正文</param>
        /// <param name="ishtml">是否html文件</param>
        /// <returns></returns>
        public string SendMail(string sTo = "", string tit = "", string msg = "",bool ishtml=false)
        {

            //---------------------------------
            var model = WebConfigBll.GetInstence().GetModelForCache(x => x.Id > 0);

            if (sTo.Length < 2) { sTo = model.EmailUserName; }
            //---------------------------------

            return SendMail(model.EmailSmtp, model.EmailUserName, model.EmailPassWord, model.WebEmail, model.WebName, sTo, tit, msg, ishtml);
        }
        /// <summary>发送E-mail</summary>
        /// <param name="domain">smtp域名,例如:smtp.qq.com</param>
        /// <param name="user">smtp账号</param>
        /// <param name="pass">smtp密码</param>
        /// <param name="from">发件人地址</param>
        /// <param name="fromname">發件人名稱</param>
        /// <param name="sTo">发送对象,多个以；分隔</param>
        /// <param name="tit">邮件主題</param>
        /// <param name="msg">邮件内容</param>
        /// <param name="isHtml"></param>
        /// <returns></returns>
        private string SendMail(string domain, string user, string pass, string from,string fromname,string sTo, string tit, string msg, bool isHtml)
        {
            var oMail = new SendMailHelper();
            oMail.From = from;
            oMail.FromName = fromname;
            string[] arr = sTo.Split(new char[] { ';' });
            foreach (var item in arr)
            {
                oMail.AddRecipient(item.ToString());
            }
            oMail.RecipientName = sTo;
            oMail.MailDomain = domain;
            oMail.MailServerUserName = user;
            oMail.MailServerPassWord = pass;
            oMail.Html = isHtml;
            oMail.Priority = "High";
            oMail.Subject = tit;
            oMail.Body = msg;

            oMail.Dispose();
            return oMail.Send() ? "" : oMail.ErrorMessage;
        }

        #endregion
    }
}
