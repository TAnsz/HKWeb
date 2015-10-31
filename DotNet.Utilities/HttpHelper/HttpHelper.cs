/// <summary>
/// 類說明：HttpHelper類，用來實現Http訪問，Post或者Get方式的，直接訪問，帶Cookie的，帶證書的等方式，可以設置代理
/// 重要提示：請不要自行修改本類，如果因為你自己修改後將無法升級到新版本。如果確實有什麼問題請到官方網站提建議，
/// 我們一定會及時修改
/// 編碼日期：2011-09-20
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 官方網址：http://www.sufeinet.com/thread-3-1-1.html
/// 修改日期：2015-09-08
/// 版 本 號：1.5
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Linq;
using System.Net.Cache;

namespace DotNet4.Utilities
{
    /// <summary>
    /// Http連接操作幫助類
    /// </summary>
    public class HttpHelper
    {
        #region 預定義方變量
        //默認的編碼
        private Encoding encoding = Encoding.Default;
        //Post數據編碼
        private Encoding postencoding = Encoding.Default;
        //HttpWebRequest對像用來發起請求
        private HttpWebRequest request = null;
        //獲取影響流的數據對像
        private HttpWebResponse response = null;
        //設置本地的出口ip和端口
        private IPEndPoint _IPEndPoint = null;
        #endregion

        #region Public

        /// <summary>
        /// 根據相傳入的數據，得到相應頁面數據
        /// </summary>
        /// <param name="item">參數類對像</param>
        /// <returns>返回HttpResult類型</returns>
        public HttpResult GetHtml(HttpItem item)
        {
            //返回參數
            HttpResult result = new HttpResult();
            try
            {
                //準備參數
                SetRequest(item);
            }
            catch (Exception ex)
            {
                //配置參數時出錯
                return new HttpResult() { Cookie = string.Empty, Header = null, Html = ex.Message, StatusDescription = "配置參數時出錯：" + ex.Message };
            }
            try
            {
                //請求數據
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    GetData(item, result);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (response = (HttpWebResponse)ex.Response)
                    {
                        GetData(item, result);
                    }
                }
                else
                {
                    result.Html = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.Html = ex.Message;
            }
            if (item.IsToLower) result.Html = result.Html.ToLower();
            return result;
        }
        #endregion

        #region GetData

        /// <summary>
        /// 獲取數據的並解析的方法
        /// </summary>
        /// <param name="item"></param>
        /// <param name="result"></param>
        private void GetData(HttpItem item, HttpResult result)
        {
            if (response == null)
            {
                return;
            }
            #region base
            //獲取StatusCode
            result.StatusCode = response.StatusCode;
            //獲取StatusDescription
            result.StatusDescription = response.StatusDescription;
            //獲取Headers
            result.Header = response.Headers;
            //獲取最後訪問的URl
            result.ResponseUri = response.ResponseUri.ToString();
            //獲取CookieCollection
            if (response.Cookies != null) result.CookieCollection = response.Cookies;
            //獲取set-cookie
            if (response.Headers["set-cookie"] != null) result.Cookie = response.Headers["set-cookie"];
            #endregion

            #region byte
            //處理網頁Byte
            byte[] ResponseByte = GetByte();
            #endregion

            #region Html
            if (ResponseByte != null & ResponseByte.Length > 0)
            {
                //設置編碼
                SetEncoding(item, result, ResponseByte);
                //得到返回的HTML
                result.Html = encoding.GetString(ResponseByte);
            }
            else
            {
                //沒有返回任何Html代碼
                result.Html = string.Empty;
            }
            #endregion
        }
        /// <summary>
        /// 設置編碼
        /// </summary>
        /// <param name="item">HttpItem</param>
        /// <param name="result">HttpResult</param>
        /// <param name="ResponseByte">byte[]</param>
        private void SetEncoding(HttpItem item, HttpResult result, byte[] ResponseByte)
        {
            //是否返回Byte類型數據
            if (item.ResultType == ResultType.Byte) result.ResultByte = ResponseByte;
            //從這裡開始我們要無視編碼了
            if (encoding == null)
            {
                Match meta = Regex.Match(Encoding.Default.GetString(ResponseByte), "<meta[^<]*charset=([^<]*)[\"']", RegexOptions.IgnoreCase);
                string c = string.Empty;
                if (meta != null && meta.Groups.Count > 0)
                {
                    c = meta.Groups[1].Value.ToLower().Trim();
                }
                if (c.Length > 2)
                {
                    try
                    {
                        encoding = Encoding.GetEncoding(c.Replace("\"", string.Empty).Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
                    }
                    catch
                    {
                        if (string.IsNullOrEmpty(response.CharacterSet))
                        {
                            encoding = Encoding.UTF8;
                        }
                        else
                        {
                            encoding = Encoding.GetEncoding(response.CharacterSet);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(response.CharacterSet))
                    {
                        encoding = Encoding.UTF8;
                    }
                    else
                    {
                        encoding = Encoding.GetEncoding(response.CharacterSet);
                    }
                }
            }
        }
        /// <summary>
        /// 提取網頁Byte
        /// </summary>
        /// <returns></returns>
        private byte[] GetByte()
        {
            byte[] ResponseByte = null;
            using (MemoryStream _stream = new MemoryStream())
            {
                //GZIIP處理
                if (response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                {
                    //開始讀取流並設置編碼方式
                    new GZipStream(response.GetResponseStream(), CompressionMode.Decompress).CopyTo(_stream, 10240);
                }
                else
                {
                    //開始讀取流並設置編碼方式
                    response.GetResponseStream().CopyTo(_stream, 10240);
                }
                //獲取Byte
                ResponseByte = _stream.ToArray();
            }
            return ResponseByte;
        }


        #endregion

        #region SetRequest

        /// <summary>
        /// 為請求準備參數
        /// </summary>
        ///<param name="item">參數列表</param>
        private void SetRequest(HttpItem item)
        {

            // 驗證證書
            SetCer(item);
            if (item.IPEndPoint != null)
            {
                _IPEndPoint = item.IPEndPoint;
                //設置本地的出口ip和端口
                request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
            }
            //設置Header參數
            if (item.Header != null && item.Header.Count > 0) foreach (string key in item.Header.AllKeys)
                {
                    request.Headers.Add(key, item.Header[key]);
                }
            // 設置代理
            SetProxy(item);
            if (item.ProtocolVersion != null) request.ProtocolVersion = item.ProtocolVersion;
            request.ServicePoint.Expect100Continue = item.Expect100Continue;
            //請求方式Get或者Post
            request.Method = item.Method;
            request.Timeout = item.Timeout;
            request.KeepAlive = item.KeepAlive;
            request.ReadWriteTimeout = item.ReadWriteTimeout;
            if (!string.IsNullOrWhiteSpace(item.Host))
            {
                request.Host = item.Host;
            }
            if (item.IfModifiedSince != null) request.IfModifiedSince = Convert.ToDateTime(item.IfModifiedSince);
            //Accept
            request.Accept = item.Accept;
            //ContentType返回類型
            request.ContentType = item.ContentType;
            //UserAgent客戶端的訪問類型，包括瀏覽器版本和操作系統信息
            request.UserAgent = item.UserAgent;
            // 編碼
            encoding = item.Encoding;
            //設置安全憑證
            request.Credentials = item.ICredentials;
            //設置Cookie
            SetCookie(item);
            //來源地址
            request.Referer = item.Referer;
            //是否執行跳轉功能
            request.AllowAutoRedirect = item.Allowautoredirect;
            if (item.MaximumAutomaticRedirections > 0)
            {
                request.MaximumAutomaticRedirections = item.MaximumAutomaticRedirections;
            }
            //設置Post數據
            SetPostData(item);
            //設置最大連接
            if (item.Connectionlimit > 0) request.ServicePoint.ConnectionLimit = item.Connectionlimit;
        }
        /// <summary>
        /// 設置證書
        /// </summary>
        /// <param name="item"></param>
        private void SetCer(HttpItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.CerPath))
            {
                //這一句一定要寫在創建連接的前面。使用回調的方法進行證書驗證。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                //初始化對像，並設置請求的URL地址
                request = (HttpWebRequest)WebRequest.Create(item.URL);
                SetCerList(item);
                //將證書添加到請求裡
                request.ClientCertificates.Add(new X509Certificate(item.CerPath));
            }
            else
            {
                //初始化對像，並設置請求的URL地址
                request = (HttpWebRequest)WebRequest.Create(item.URL);
                SetCerList(item);
            }
        }
        /// <summary>
        /// 設置多個證書
        /// </summary>
        /// <param name="item"></param>
        private void SetCerList(HttpItem item)
        {
            if (item.ClentCertificates != null && item.ClentCertificates.Count > 0)
            {
                foreach (X509Certificate c in item.ClentCertificates)
                {
                    request.ClientCertificates.Add(c);
                }
            }
        }
        /// <summary>
        /// 設置Cookie
        /// </summary>
        /// <param name="item">Http參數</param>
        private void SetCookie(HttpItem item)
        {
            if (!string.IsNullOrEmpty(item.Cookie)) request.Headers[HttpRequestHeader.Cookie] = item.Cookie;
            //設置CookieCollection
            if (item.ResultCookieType == ResultCookieType.CookieCollection)
            {
                request.CookieContainer = new CookieContainer();
                if (item.CookieCollection != null && item.CookieCollection.Count > 0)
                    request.CookieContainer.Add(item.CookieCollection);
            }
        }
        /// <summary>
        /// 設置Post數據
        /// </summary>
        /// <param name="item">Http參數</param>
        private void SetPostData(HttpItem item)
        {
            //驗證在得到結果時是否有傳入數據
            if (!request.Method.Trim().ToLower().Contains("get"))
            {
                if (item.PostEncoding != null)
                {
                    postencoding = item.PostEncoding;
                }
                byte[] buffer = null;
                //寫入Byte類型
                if (item.PostDataType == PostDataType.Byte && item.PostdataByte != null && item.PostdataByte.Length > 0)
                {
                    //驗證在得到結果時是否有傳入數據
                    buffer = item.PostdataByte;
                }//寫入文件
                else if (item.PostDataType == PostDataType.FilePath && !string.IsNullOrWhiteSpace(item.Postdata))
                {
                    StreamReader r = new StreamReader(item.Postdata, postencoding);
                    buffer = postencoding.GetBytes(r.ReadToEnd());
                    r.Close();
                } //寫入字符串
                else if (!string.IsNullOrWhiteSpace(item.Postdata))
                {
                    buffer = postencoding.GetBytes(item.Postdata);
                }
                if (buffer != null)
                {
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }
            }
        }
        /// <summary>
        /// 設置代理
        /// </summary>
        /// <param name="item">參數對像</param>
        private void SetProxy(HttpItem item)
        {
            bool isIeProxy = false;
            if (!string.IsNullOrWhiteSpace(item.ProxyIp))
            {
                isIeProxy = item.ProxyIp.ToLower().Contains("ieproxy");
            }
            if (!string.IsNullOrWhiteSpace(item.ProxyIp) && !isIeProxy)
            {
                //設置代理服務器
                if (item.ProxyIp.Contains(":"))
                {
                    string[] plist = item.ProxyIp.Split(':');
                    WebProxy myProxy = new WebProxy(plist[0].Trim(), Convert.ToInt32(plist[1].Trim()));
                    //建議連接
                    myProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
                    //給當前請求對像
                    request.Proxy = myProxy;
                }
                else
                {
                    WebProxy myProxy = new WebProxy(item.ProxyIp, false);
                    //建議連接
                    myProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
                    //給當前請求對像
                    request.Proxy = myProxy;
                }
            }
            else if (isIeProxy)
            {
                //設置為IE代理
            }
            else
            {
                request.Proxy = item.WebProxy;
            }
        }


        #endregion

        #region private main
        /// <summary>
        /// 回調驗證證書問題
        /// </summary>
        /// <param name="sender">流對像</param>
        /// <param name="certificate">證書</param>
        /// <param name="chain">X509Chain</param>
        /// <param name="errors">SslPolicyErrors</param>
        /// <returns>bool</returns>
        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; }

        /// <summary>
        /// 通過設置這個屬性，可以在發出連接的時候綁定客戶端發出連接所使用的IP地址。 
        /// </summary>
        /// <param name="servicePoint"></param>
        /// <param name="remoteEndPoint"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        private IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            return _IPEndPoint;//端口號
        }
        #endregion
    }

    #region public calss
    /// <summary>
    /// Http請求參考類
    /// </summary>
    public class HttpItem
    {
        /// <summary>
        /// 請求URL必須填寫
        /// </summary>
        public string URL { get; set; }
        string _Method = "GET";
        /// <summary>
        /// 請求方式默認為GET方式,當為POST方式時必須設置Postdata的值
        /// </summary>
        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }
        int _Timeout = 100000;
        /// <summary>
        /// 默認請求超時時間
        /// </summary>
        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }
        int _ReadWriteTimeout = 30000;
        /// <summary>
        /// 默認寫入Post數據超時間
        /// </summary>
        public int ReadWriteTimeout
        {
            get { return _ReadWriteTimeout; }
            set { _ReadWriteTimeout = value; }
        }
        /// <summary>
        /// 設置Host的標頭信息
        /// </summary>
        public string Host { get; set; }
        Boolean _KeepAlive = true;
        /// <summary>
        ///  獲取或設置一個值，該值指示是否與 Internet 資源建立持久性連接默認為true。
        /// </summary>
        public Boolean KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }
        string _Accept = "text/html, application/xhtml+xml, */*";
        /// <summary>
        /// 請求標頭值 默認為text/html, application/xhtml+xml, */*
        /// </summary>
        public string Accept
        {
            get { return _Accept; }
            set { _Accept = value; }
        }
        string _ContentType = "text/html";
        /// <summary>
        /// 請求返回類型默認 text/html
        /// </summary>
        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }
        string _UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
        /// <summary>
        /// 客戶端訪問信息默認Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)
        /// </summary>
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }
        /// <summary>
        /// 返回數據編碼默認為NUll,可以自動識別,一般為utf-8,gbk,gb2312
        /// </summary>
        public Encoding Encoding { get; set; }
        private PostDataType _PostDataType = PostDataType.String;
        /// <summary>
        /// Post的數據類型
        /// </summary>
        public PostDataType PostDataType
        {
            get { return _PostDataType; }
            set { _PostDataType = value; }
        }
        /// <summary>
        /// Post請求時要發送的字符串Post數據
        /// </summary>
        public string Postdata { get; set; }
        /// <summary>
        /// Post請求時要發送的Byte類型的Post數據
        /// </summary>
        public byte[] PostdataByte { get; set; }
        /// <summary>
        /// Cookie對像集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
        /// <summary>
        /// 請求時的Cookie
        /// </summary>
        public string Cookie { get; set; }
        /// <summary>
        /// 來源地址，上次訪問地址
        /// </summary>
        public string Referer { get; set; }
        /// <summary>
        /// 證書絕對路徑
        /// </summary>
        public string CerPath { get; set; }
        /// <summary>
        /// 設置代理對象，不想使用IE默認配置就設置為Null，而且不要設置ProxyIp
        /// </summary>
        public WebProxy WebProxy { get; set; }
        private Boolean isToLower = false;
        /// <summary>
        /// 是否設置為全文小寫，默認為不轉化
        /// </summary>
        public Boolean IsToLower
        {
            get { return isToLower; }
            set { isToLower = value; }
        }
        private Boolean allowautoredirect = false;
        /// <summary>
        /// 支持跳轉頁面，查詢結果將是跳轉後的頁面，默認是不跳轉
        /// </summary>
        public Boolean Allowautoredirect
        {
            get { return allowautoredirect; }
            set { allowautoredirect = value; }
        }
        private int connectionlimit = 1024;
        /// <summary>
        /// 最大連接數
        /// </summary>
        public int Connectionlimit
        {
            get { return connectionlimit; }
            set { connectionlimit = value; }
        }
        /// <summary>
        /// 代理Proxy 服務器用戶名
        /// </summary>
        public string ProxyUserName { get; set; }
        /// <summary>
        /// 代理 服務器密碼
        /// </summary>
        public string ProxyPwd { get; set; }
        /// <summary>
        /// 代理 服務IP,如果要使用IE代理就設置為ieproxy
        /// </summary>
        public string ProxyIp { get; set; }
        private ResultType resulttype = ResultType.String;
        /// <summary>
        /// 設置返回類型String和Byte
        /// </summary>
        public ResultType ResultType
        {
            get { return resulttype; }
            set { resulttype = value; }
        }
        private WebHeaderCollection header = new WebHeaderCollection();
        /// <summary>
        /// header對像
        /// </summary>
        public WebHeaderCollection Header
        {
            get { return header; }
            set { header = value; }
        }
        /// <summary>
        //     獲取或設置用於請求的 HTTP 版本。返回結果:用於請求的 HTTP 版本。默認為 System.Net.HttpVersion.Version11。
        /// </summary>
        public Version ProtocolVersion { get; set; }
        private Boolean _expect100continue = true;
        /// <summary>
        ///  獲取或設置一個 System.Boolean 值，該值確定是否使用 100-Continue 行為。如果 POST 請求需要 100-Continue 響應，則為 true；否則為 false。默認值為 true。
        /// </summary>
        public Boolean Expect100Continue
        {
            get { return _expect100continue; }
            set { _expect100continue = value; }
        }
        /// <summary>
        /// 設置509證書集合
        /// </summary>
        public X509CertificateCollection ClentCertificates { get; set; }
        /// <summary>
        /// 設置或獲取Post參數編碼,默認的為Default編碼
        /// </summary>
        public Encoding PostEncoding { get; set; }
        private ResultCookieType _ResultCookieType = ResultCookieType.String;
        /// <summary>
        /// Cookie返回類型,默認的是只返回字符串類型
        /// </summary>
        public ResultCookieType ResultCookieType
        {
            get { return _ResultCookieType; }
            set { _ResultCookieType = value; }
        }
        private ICredentials _ICredentials = CredentialCache.DefaultCredentials;
        /// <summary>
        /// 獲取或設置請求的身份驗證信息。
        /// </summary>
        public ICredentials ICredentials
        {
            get { return _ICredentials; }
            set { _ICredentials = value; }
        }
        /// <summary>
        /// 設置請求將跟隨的重定向的最大數目
        /// </summary>
        public int MaximumAutomaticRedirections { get; set; }
        private DateTime? _IfModifiedSince = null;
        /// <summary>
        /// 獲取和設置IfModifiedSince，默認為當前日期和時間
        /// </summary>
        public DateTime? IfModifiedSince
        {
            get { return _IfModifiedSince; }
            set { _IfModifiedSince = value; }
        }
        #region ip-port
        private IPEndPoint _IPEndPoint = null;
        /// <summary>
        /// 設置本地的出口ip和端口
        /// </summary>]
        /// <example>
        ///item.IPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.1"),80);
        /// </example>
        public IPEndPoint IPEndPoint
        {
            get { return _IPEndPoint; }
            set { _IPEndPoint = value; }
        }
        #endregion
    }
    /// <summary>
    /// Http返回參數類
    /// </summary>
    public class HttpResult
    {
        /// <summary>
        /// Http請求返回的Cookie
        /// </summary>
        public string Cookie { get; set; }
        /// <summary>
        /// Cookie對像集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
        private string _html = string.Empty;
        /// <summary>
        /// 返回的String類型數據 只有ResultType.String時才返回數據，其它情況為空
        /// </summary>
        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }
        /// <summary>
        /// 返回的Byte數組 只有ResultType.Byte時才返回數據，其它情況為空
        /// </summary>
        public byte[] ResultByte { get; set; }
        /// <summary>
        /// header對像
        /// </summary>
        public WebHeaderCollection Header { get; set; }
        /// <summary>
        /// 返回狀態說明
        /// </summary>
        public string StatusDescription { get; set; }
        /// <summary>
        /// 返回狀態碼,默認為OK
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 最後訪問的URl
        /// </summary>
        public string ResponseUri { get; set; }
        /// <summary>
        /// 獲取重定向的URl
        /// </summary>
        public string RedirectUrl
        {
            get
            {
                try
                {
                    if (Header != null && Header.Count > 0)
                    {
                        if (Header.AllKeys.Any(k => k.ToLower().Contains("location")))
                        {
                            string locationurl = Header["location"].ToString().ToLower();

                            if (!string.IsNullOrWhiteSpace(locationurl))
                            {
                                bool b = locationurl.StartsWith("http://") || locationurl.StartsWith("https://");
                                if (!b)
                                {
                                    locationurl = new Uri(new Uri(ResponseUri), locationurl).AbsoluteUri;
                                }
                            }
                            return locationurl;
                        }
                    }
                }
                catch { }
                return string.Empty;
            }
        }
    }
    /// <summary>
    /// 返回類型
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 表示只返回字符串 只有Html有數據
        /// </summary>
        String,
        /// <summary>
        /// 表示返回字符串和字節流 ResultByte和Html都有數據返回
        /// </summary>
        Byte
    }
    /// <summary>
    /// Post的數據格式默認為string
    /// </summary>
    public enum PostDataType
    {
        /// <summary>
        /// 字符串類型，這時編碼Encoding可不設置
        /// </summary>
        String,
        /// <summary>
        /// Byte類型，需要設置PostdataByte參數的值編碼Encoding可設置為空
        /// </summary>
        Byte,
        /// <summary>
        /// 傳文件，Postdata必須設置為文件的絕對路徑，必須設置Encoding的值
        /// </summary>
        FilePath
    }
    /// <summary>
    /// Cookie返回類型
    /// </summary>
    public enum ResultCookieType
    {
        /// <summary>
        /// 只返回字符串類型的Cookie
        /// </summary>
        String,
        /// <summary>
        /// CookieCollection格式的Cookie集合同時也返回String類型的cookie
        /// </summary>
        CookieCollection
    }
    #endregion
}