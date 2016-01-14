using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;

namespace Solution.Web.Managers.WebServices
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://192.168.0.10/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Weather : WebService
    {
        /// <summary>
        /// 獲取天氣信息
        /// </summary>
        /// <param name="cityid">城市代碼</param>
        /// <returns>json字符串</returns>
        [WebMethod(Description = "獲取天氣信息",CacheDuration=1800)]
        public string GetWeather(string cityid)
        {
            const string url = "http://apis.baidu.com/apistore/weatherservice/recentweathers";
            string param = "cityid=" + cityid;
            string strUrl = url + '?' + param;
            var request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = "GET";
            // 添加header
            request.Headers.Add("apikey", "4e3dc30c80cae59cbd7105bc151dc4fd");
            var response = (HttpWebResponse)request.GetResponse();
            var s = response.GetResponseStream();
            string strDate;
            string strValue = "";
            StreamReader reader = new StreamReader(s, Encoding.UTF8);
            while ((strDate = reader.ReadLine()) != null)
            {
                strValue += strDate + "\r\n";
            }
            return strValue;
            //return HttpUtility.UrlDecode(str);
        }
    }
}
