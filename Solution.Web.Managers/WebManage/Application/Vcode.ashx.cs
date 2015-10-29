using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.SessionState;
using DotNet.Utilities;

namespace Solution.Web.Managers.WebManage.Application
{
    /// <summary>
    /// Vcode 的摘要说明
    /// </summary>
    public class Vcode : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            VerificationCode vcode = new VerificationCode();
            vcode.CountCode = 4;
            vcode.ImageHeight = 32;
            vcode.ImageWidth = 100;
            vcode.NoiseLine = 10;
            vcode.NoisePoint = 10;
            vcode.FontSize = 28;
            //生成验证码
            vcode.GetCaptcha();

            HttpContext.Current.Session["vcode"] = vcode.Code;
            
            //输出验证码图片
            Bitmap bitmap = vcode.CurrentBitmap;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/jpeg";
            bitmap.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Jpeg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}