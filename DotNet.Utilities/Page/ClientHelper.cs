using System;
using System.Web;

namespace DotNet.Utilities
{
    /// <summary>
    /// 客戶端信息獲取類
    /// </summary>
    public class ClientHelper
    {

        private HttpBrowserCapabilities bc = new HttpBrowserCapabilities();
        //定義搜索引擎關鍵字，用於判斷是否是搜索引警進入本站
        string[] SearchEngine = { "google", "360.cn", "baidu", "sogou", "soso", "so.com", "youdao", "bing.com", "yahoo", "lycos", "googlesyndication.com", "sm.cn" };
        //定義搜索引擎關鍵字，用於判斷訪問網站的是否是搜索引擎的網絡蜘蛛在抓起頁面
        public static readonly string[] _searchEngineList = { "spider", "Googlebot", "bingbot", "Yahoo", "YoudaoBot", "MJ12bot", "alexa", "Wget", "msnbot", "DotBot", "yandex", "google", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };

        /// <summary>構造函數
        /// </summary>
		public ClientHelper(HttpRequest Request)
        {
            bc = Request.Browser;
        }

        /// <summary>返回瀏覽器操作系統名稱
        /// </summary>
        /// <returns></returns>
        public string GetBrowserOS()
        {
            return System.Web.HttpContext.Current.Request.Browser.Platform.ToString();
        }

        /// <summary>返回瀏覽器IP
        /// </summary>
        /// <returns></returns>
        public string GetBrowserIP()
        {
            return System.Web.HttpContext.Current.Request.UserHostAddress;
            //return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];//此方法也可以
        }

        ///<summary> 返回瀏覽器是否支持Java
        /// </summary>
        /// <returns></returns>
        public string GetBrowserSupportJava()
        {
            return System.Web.HttpContext.Current.Request.Browser.JavaScript.ToString();
        }

        /// <summary>返回瀏覽器IE版本
        /// </summary>
        /// <returns></returns>
        public string GetBrowserName()
        {
            return System.Web.HttpContext.Current.Request.Browser.Browser.ToString() + System.Web.HttpContext.Current.Request.Browser.Version.ToString();
        }

        /// <summary>返回瀏覽器.NET版本
        /// </summary>
        /// <returns></returns>
        public string GetBrowserNETCLR()
        {
            return System.Web.HttpContext.Current.Request.Browser.ClrVersion.ToString();
        }

        /// <summary>返回瀏覽器是否支持Cookies
        /// </summary>
        /// <returns></returns>
        public string GetBrowserSupportCookies()
        {
            return System.Web.HttpContext.Current.Request.Browser.Cookies.ToString();
        }

        /// <summary>獲取客戶端使用的系統</summary>
        /// <returns></returns>
        public string GetSystem()
        {
            try
            {
                return HttpContext.Current.Request.Browser.Platform;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>判斷系統屬於win16還是win32,還是其他
        /// </summary>
        /// <returns></returns>
        public string GetSysClass()
        {
            try
            {
                if (bc.Win16)
                {
                    return "16位";
                        //bc.Win16.ToString();
                }
                else
                    if (bc.Win32)
                    {
                        //return bc.Win32.ToString();

                        return "32位";
                    }
                    else
                    {
                        return "Other";
                    }

            }
            catch (Exception)
            {
                return "";
            }


        }

        /// <summary>獲取客戶端瀏覽器信息
        /// </summary>
        /// <returns></returns>
        public string GetBrowserInfo()
        {
            try
            {
                return bc.Browser;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>獲取瀏覽器的標識
        /// </summary>
        /// <returns></returns>
        public string GetBrowserIdentifying()
        {
            try
            {

                return bc.Id;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>獲取瀏覽器的版本信息
        /// </summary>
        /// <returns></returns>
        public string GetBrowserVersion()
        {
            try
            {
                return bc.Version;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>獲取瀏覽器的主版本信息
        /// </summary>
        /// <returns></returns>
        public string GetBrowerMajorVersion()
        {
            try
            {
                return bc.MajorVersion.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>獲取瀏覽器的次版本信息
        /// </summary>
        /// <returns></returns>
        public string GetBrowserMinorVersion()
        {
            try
            {
                return bc.MinorVersion.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>判斷瀏覽器是否為測試版本
        /// </summary>
        /// <returns></returns>
        public bool? IsBrowserBeta()
        {
            try
            {
                return bc.Beta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>是否是 America Online(美國在線服務)瀏覽器</summary>
        /// <returns></returns>
        public bool? IsBrowserAOL()
        {
            try
            {
                return bc.AOL;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>客戶端安裝的 .NET Framework 版本</summary>
        /// <returns></returns>
        public string GetNetClrVersion()
        {
            try
            {
                return bc.ClrVersion.ToString();

            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>是否為是搜索引擎的網絡爬蟲
        /// </summary>
        /// <returns></returns>
        public bool IsCrawler()
        {
            try
            {
                return bc.Crawler;
            }
            catch (Exception)
            {

            }

            string UA = HttpContext.Current.Request.Headers["User-Agent"];
            if (UA == null || UA == "")
            {
                return false;
            }
            foreach (string ua in _searchEngineList)
            {
                if (UA.IndexOf(ua) > -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否為移動設備
        /// </summary>
        /// <returns></returns>
        public bool IsMobileDevice()
        {
            try
            {
                return bc.IsMobileDevice;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 是否為移動設備
        /// </summary>
        /// <returns></returns>
        public bool IsMobileDevice(string ua)
        {
            try
            {
                if (ua.IndexOf("Android") > -1 || ua.IndexOf("iPhone") > -1 || ua.IndexOf("Mobile") > -1)
                    return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>顯示的顏色深度
        /// 
        /// </summary>
        /// <returns></returns>
        public int? GetScreenBitDepth()
        {
            try
            {
                return bc.ScreenBitDepth;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>顯示的近似寬度（以字符行為單位)
        /// </summary>
        /// <returns></returns>
        public int? GetScreenCharactersWidth()
        {
            try
            {
                return bc.ScreenCharactersWidth;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>顯示的近似高度（以字符行為單位）
        /// </summary>
        /// <returns></returns>
        public int? GetScreenCharactersHeight()
        {
            try
            {
                return bc.ScreenCharactersHeight;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>顯示的近似寬度（以像素行為單位）
        /// </summary>
        /// <returns></returns>
        public int? GetScreenPixelsWidth()
        {
            try
            {
                return bc.ScreenPixelsWidth;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>顯示的近似高度（以像素行為單位）
        /// </summary>
        /// <returns></returns>
        public int? GetScreenPixelsHeight()
        {
            try
            {
                return bc.ScreenPixelsHeight;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>是否支持 CSS
        /// </summary>
        /// <returns></returns>
        public bool? IsSupportsCss()
        {
            try
            {
                return bc.SupportsCss;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>是否支持 ActiveX 控件
        /// </summary>
        /// <returns></returns>
        public bool? IsActiveXControls()
        {
            try
            {
                return bc.ActiveXControls;
            }
            catch (Exception)
            {
                return null;

            }
        }

        /// <summary>是否支持 JavaApplets
        /// </summary>
        /// <returns></returns>
        public bool? IsJavaApplets()
        {
            try
            {
                return bc.JavaApplets;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>是否支持javascript
        /// </summary>
        /// <returns></returns>
        public bool? IsJavaScript()
        {
            try
            {
                return bc.JavaScript;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>獲取javascript版本
        /// </summary>
        /// <returns></returns>
        public String GetJScriptVersion()
        {
            try
            {
                return bc.JScriptVersion.ToString();
            }
            catch (Exception)
            {

                return "";
            }
        }

        /// <summary>是否支持VBScript腳本
        /// </summary>
        public bool? IsVBScript()
        {
            try
            {
                return bc.VBScript;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>是否支持Cookie
        /// </summary>
        /// <returns></returns>
        public bool? IsCookies()
        {
            try
            {
                return bc.Cookies;
            }
            catch (Exception)
            {

                return null;

            }
        }

        /// <summary>支持的 MSHTML 的 DOM 版本
        /// </summary>
        /// <returns></returns>
        public string GetMSDomVersion()
        {
            try
            {
                return bc.MSDomVersion.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>支持的 W3C 的 DOM 版本
        /// </summary>
        /// <returns></returns>
        public string GetW3CDomVersion()
        {
            try
            {
                return bc.W3CDomVersion.ToString();
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>是否支持通過 HTTP 接收 XML
        /// </summary>
        /// <returns></returns>
        public bool? IsSupportsXmlHttp()
        {
            try
            {
                return bc.SupportsXmlHttp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>是否支持框架
        /// </summary>
        /// <returns></returns>
        public bool? IsFrames()
        {
            try
            {
                return bc.Frames;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>超鏈接 a 屬性 href 值的最大長度
        /// </summary>
        /// <returns></returns>
        public int? GetMaximumHrefLength()
        {
            try
            {
                return bc.MaximumHrefLength;
            }
            catch (Exception)
            {

                return null;
            }

        }

        /// <summary>是否支持表格
        /// </summary>
        /// <returns></returns>
        public bool? IsTables()
        {
            try
            {
                return bc.Tables;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>返回移動設備製造商的名稱
        /// </summary>
        /// <returns></returns>
        public String GetMobileDeviceManufacturer()
        {
            try
            {
                return bc.MobileDeviceManufacturer;

            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>該瀏覽器設備是否能夠啟動語音呼叫
        /// </summary>
        /// <returns></returns>
        public bool? IsCanInitiateVoiceCall()
        {
            try
            {
                return bc.CanInitiateVoiceCall;

            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>判斷瀏覽器是否支持Html中mailto發送電子郵件
        /// </summary>
        /// <returns></returns>
        public bool? IsCanSendMail()
        {
            try
            {
                return bc.CanSendMail;

            }
            catch (Exception)
            {

                throw null;
            }
        }

        /// <summary>判斷瀏覽器是否支持Web廣播的頻道定義格式
        /// </summary>
        /// <returns></returns>
        public bool? IsCDF()
        {
            try
            {
                return bc.CDF;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>獲取瀏覽器EcmaScriptVersion支持的版本
        /// </summary>
        /// <returns></returns>
        public string GetEcmaScriptVersion()
        {
            try
            {
                return bc.EcmaScriptVersion.ToString();

            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>返回瀏覽器支持可輸入的類型
        /// </summary>
        /// <returns></returns>
        public string GetInputType()
        {
            try
            {
                return bc.InputType;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>判斷當前瀏覽器是否與指定的瀏覽器相同
        /// </summary>
        /// <param name="BrowserName">指定進行對比的瀏覽器</param>
        /// <returns></returns>
        public bool? IsAlikeBrowser(string BrowserName)
        {
            try
            {
                return bc.IsBrowser(BrowserName);

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>返回移動設備上軟鍵的數目
        /// </summary>
        /// <returns></returns>
        public int? GetNumberOfSoftkeys()
        {
            try
            {
                return bc.NumberOfSoftkeys;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary> 獲取瀏覽器請求的首選編碼
        /// </summary>
        /// <returns></returns>
        public string GetPreferredRequestEncoding()
        {
            try
            {
                return bc.PreferredRequestEncoding;

            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>獲取瀏覽器響應的首選編碼
        /// </summary>
        /// <returns></returns>
        public string GetPreferredResponseEncoding()
        {
            try
            {
                return bc.PreferredResponseEncoding;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>瀏覽器是否支持回調腳本
        /// </summary>
        /// <returns></returns>
        public bool? IsSupportsCallback()
        {
            try
            {
                return bc.SupportsCallback;

            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>獲取瀏覽器的名稱+主（整數）版本號
        /// </summary>
        /// <returns></returns>
        public string GetBrowserType()
        {
            try
            {
                return bc.Type;
            }
            catch (Exception)
            {

                return null; ;
            }
        }

        /// <summary>
        /// 判斷是否為搜索引擎
        /// </summary>
        /// <returns></returns>
        public bool IsSearchEnginesGet(string refererUrl)
        {
            if (string.IsNullOrEmpty(refererUrl))
                return false;

            string tmpReferrer = refererUrl.ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判斷是否為搜索引擎
        /// </summary>
        /// <returns></returns>
        public bool IsSearchEnginesGet()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
            {
                return false;
            }

            return IsSearchEnginesGet(HttpContext.Current.Request.UrlReferrer.ToString());
        }

        /// <summary> 獲得當前頁面客戶端的IP </summary>
        /// <returns>當前頁面客戶端的IP</returns>
        public string GetIP()
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_VIA"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "127.0.0.1";
            }
            return result;
        }

        /// <summary>
        /// 將所以客戶端收集的信息輸出來
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string temp = "";
            temp += "返回瀏覽器操作系統名稱:   " + GetBrowserOS() + "\r\n";
            temp += "返回瀏覽器IP:   " + GetBrowserIP() + "\r\n";
            temp += "瀏覽器是否支持JavaScript:   " + GetBrowserSupportJava() + "\r\n";
            temp += "瀏覽器IE版本:   " + GetBrowserName() + "\r\n";
            temp += "瀏覽器.NET版本:   " + GetBrowserNETCLR() + "\r\n";
            temp += "瀏覽器是否支持Cookies:   " + GetBrowserSupportCookies() + "\r\n";
            temp += "客戶端使用的系統:   " + GetSystem() + "\r\n";
            temp += "判斷系統屬於win16還是win32,還是其他:   " + GetSysClass() + "\r\n";
            temp += "客戶端瀏覽器信息:   " + GetBrowserInfo() + "\r\n";
            temp += "瀏覽器的標識:   " + GetBrowserIdentifying() + "\r\n";
            temp += "瀏覽器的版本信息:   " + GetBrowserVersion() + "\r\n";
            temp += "瀏覽器的主版本信息:   " + GetBrowerMajorVersion() + "\r\n";
            temp += "瀏覽器的次版本信息:   " + GetBrowserMinorVersion() + "\r\n";
            temp += "瀏覽器是否為測試版本:   " + IsBrowserBeta() + "\r\n";
            temp += "是否是 America Online(美國在線服務)瀏覽器:   " + IsBrowserAOL() + "\r\n";
            temp += "客戶端安裝的 .NET Framework 版本:   " + GetNetClrVersion() + "\r\n";
            temp += "是否為是搜索引擎的網絡爬蟲:   " + IsCrawler() + "\r\n";
            temp += "是否為移動設備:   " + IsMobileDevice() + "\r\n";
            temp += "顯示的顏色深度:   " + GetScreenBitDepth() + "\r\n";
            temp += "顯示的近似寬度（以字符行為單位):   " + GetScreenCharactersWidth() + "\r\n";
            temp += "顯示的近似高度（以字符行為單位）:   " + GetScreenCharactersHeight() + "\r\n";
            temp += "顯示的近似寬度（以像素行為單位）:   " + GetScreenPixelsWidth() + "\r\n";
            temp += "顯示的近似高度（以像素行為單位）:   " + GetScreenPixelsHeight() + "\r\n";
            temp += "是否支持 CSS:   " + IsSupportsCss() + "\r\n";
            temp += "是否支持 ActiveX 控件:   " + IsActiveXControls() + "\r\n";
            temp += "是否支持 JavaApplets:   " + IsJavaApplets() + "\r\n";
            temp += "是否支持javascript:   " + IsJavaScript() + "\r\n";
            temp += "獲取javascript版本:   " + GetJScriptVersion() + "\r\n";
            temp += "是否支持VBScript腳本:   " + IsVBScript() + "\r\n";
            temp += "是否支持Cookie:   " + IsCookies() + "\r\n";
            temp += "支持的 MSHTML 的 DOM 版本:   " + GetMSDomVersion() + "\r\n";
            temp += "支持的 W3C 的 DOM 版本:   " + GetW3CDomVersion() + "\r\n";
            temp += "是否支持通過 HTTP 接收 XML:   " + IsSupportsXmlHttp() + "\r\n";
            temp += "是否支持框架:   " + IsFrames() + "\r\n";
            temp += "超鏈接 a 屬性 href 值的最大長度:   " + GetMaximumHrefLength() + "\r\n";
            temp += "是否支持表格:   " + IsTables() + "\r\n";
            temp += "返回移動設備製造商的名稱:   " + GetMobileDeviceManufacturer() + "\r\n";
            temp += "該瀏覽器設備是否能夠啟動語音呼叫:   " + IsCanInitiateVoiceCall() + "\r\n";
            temp += "判斷瀏覽器是否支持Html中mailto發送電子郵件:   " + IsCanSendMail() + "\r\n";
            temp += "判斷瀏覽器是否支持Web廣播的頻道定義格式:   " + IsCDF() + "\r\n";
            temp += "獲取瀏覽器EcmaScriptVersion支持的版本:   " + GetEcmaScriptVersion() + "\r\n";
            temp += "返回瀏覽器支持可輸入的類型:   " + GetInputType() + "\r\n";
            temp += "返回移動設備上軟鍵的數目:   " + GetNumberOfSoftkeys() + "\r\n";
            temp += "獲取瀏覽器請求的首選編碼:   " + GetPreferredRequestEncoding() + "\r\n";
            temp += "瀏覽器是否支持回調腳本:   " + IsSupportsCallback() + "\r\n";
            temp += "獲取瀏覽器的名稱+主（整數）版本號:   " + GetBrowserType() + "\r\n";
            temp += "判斷是否為搜索引擎:   " + IsSearchEnginesGet() + "\r\n";
            temp += "獲得當前頁面客戶端的IP :   " + GetIP() + "\r\n";

            return temp;
        }

    }
}
