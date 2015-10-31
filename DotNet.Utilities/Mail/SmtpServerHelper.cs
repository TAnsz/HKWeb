using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Collections;

namespace DotNet.Utilities_Xofly
{
    public enum MailFormat { Text, HTML };
    public enum MailPriority { Low = 1, Normal = 3, High = 5 };

    /// <summary>
    /// 添加附件
    /// </summary>
    public class MailAttachments
    {
        #region 構造函數
        public MailAttachments()
        {
            _Attachments = new ArrayList();
        }
        #endregion

        #region 私有字段
        private IList _Attachments;
        private const int MaxAttachmentNum = 10;
        #endregion

        #region 索引器
        public string this[int index]
        {
            get { return (string)_Attachments[index]; }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 添加郵件附件
        /// </summary>
        /// <param name="FilePath">附件的絕對路徑</param>
        public void Add(params string[] filePath)
        {
            if (filePath == null)
            {
                throw (new ArgumentNullException("非法的附件"));
            }
            else
            {
                for (int i = 0; i < filePath.Length; i++)
                {
                    Add(filePath[i]);
                }
            }
        }

        /// <summary>
        /// 添加一個附件,當指定的附件不存在時，忽略該附件，不產生異常。
        /// </summary>
        /// <param name="filePath">附件的絕對路徑</param>
        public void Add(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                if (_Attachments.Count < MaxAttachmentNum)
                {
                    _Attachments.Add(filePath);
                }
            }
        }

        /// <summary>
        /// 清除所有附件
        /// </summary>
        public void Clear()
        {
            _Attachments.Clear();
        }

        /// <summary>
        /// 獲取附件個數
        /// </summary>
        public int Count
        {
            get { return _Attachments.Count; }
        }
        #endregion
    }

    /// <summary>
    /// 郵件信息
    /// </summary>
    public class MailMessage
    {
        #region 構造函數
        public MailMessage()
        {
            _Recipients = new ArrayList();        //收件人列表
            _Attachments = new MailAttachments(); //附件
            _BodyFormat = MailFormat.HTML;        //缺省的郵件格式為HTML
            _Priority = MailPriority.Normal;
            _Charset = "GB2312";
        }
        #endregion

        #region 私有字段
        private int _MaxRecipientNum = 30;
        private string _From;      //發件人地址
        private string _FromName;  //發件人姓名
        private IList _Recipients; //收件人
        private MailAttachments _Attachments;//附件
        private string _Body;      //內容
        private string _Subject;   //主題
        private MailFormat _BodyFormat;     //郵件格式
        private string _Charset = "GB2312"; //字符編碼格式
        private MailPriority _Priority;     //郵件優先級
        #endregion

        #region 公有屬性
        /// <summary>
        /// 設定語言代碼，默認設定為GB2312，如不需要可設置為""
        /// </summary>
        public string Charset
        {
            get { return _Charset; }
            set { _Charset = value; }
        }

        /// <summary>
        /// 最大收件人
        /// </summary>
        public int MaxRecipientNum
        {
            get { return _MaxRecipientNum; }
            set { _MaxRecipientNum = value; }
        }

        /// <summary>
        /// 發件人地址
        /// </summary>
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }

        /// <summary>
        /// 發件人姓名
        /// </summary>
        public string FromName
        {
            get { return _FromName; }
            set { _FromName = value; }
        }

        /// <summary>
        /// 內容
        /// </summary>
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }

        /// <summary>
        /// 主題
        /// </summary>
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        /// <summary>
        /// 附件
        /// </summary>
        public MailAttachments Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; }
        }

        /// <summary>
        /// 優先權
        /// </summary>
        public MailPriority Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        /// <summary>
        /// 收件人
        /// </summary>
        public IList Recipients
        {
            get { return _Recipients; }
        }

        /// <summary>
        /// 郵件格式
        /// </summary>
        public MailFormat BodyFormat
        {
            set { _BodyFormat = value; }
            get { return _BodyFormat; }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 增加一個收件人地址
        /// </summary>
        /// <param name="recipient">收件人的Email地址</param>
        public void AddRecipients(string recipient)
        {
            if (_Recipients.Count < MaxRecipientNum)
            {
                _Recipients.Add(recipient);
            }
        }

        /// <summary>
        /// 增加多個收件人地址
        /// </summary>
        /// <param name="recipient">收件人的Email地址集合</param>
        public void AddRecipients(params string[] recipient)
        {
            if (recipient == null)
            {
                throw (new ArgumentException("收件人不能為空."));
            }
            else
            {
                for (int i = 0; i < recipient.Length; i++)
                {
                    AddRecipients(recipient[i]);
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// 郵件操作
    /// </summary>
    public class SmtpServerHelper
    {
        #region 構造函數、析構函數
        public SmtpServerHelper()
        {
            SMTPCodeAdd();
        }

        ~SmtpServerHelper()
        {
            networkStream.Close();
            tcpClient.Close();
        }
        #endregion

        #region 私有字段
        /// <summary>
        /// 回車換行
        /// </summary>
        private string CRLF = "\r\n";

        /// <summary>
        /// 錯誤消息反饋
        /// </summary>
        private string errmsg;

        /// <summary>
        /// TcpClient對象，用於連接服務器
        /// </summary> 
        private TcpClient tcpClient;

        /// <summary>
        /// NetworkStream對像
        /// </summary> 
        private NetworkStream networkStream;

        /// <summary>
        /// 服務器交互記錄
        /// </summary>
        private string logs = "";

        /// <summary>
        /// SMTP錯誤代碼哈希表
        /// </summary>
        private Hashtable ErrCodeHT = new Hashtable();

        /// <summary>
        /// SMTP正確代碼哈希表
        /// </summary>
        private Hashtable RightCodeHT = new Hashtable();
        #endregion

        #region 公有屬性
        /// <summary>
        /// 錯誤消息反饋
        /// </summary>
        public string ErrMsg
        {
            set { errmsg = value; }
            get { return errmsg; }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 將字符串編碼為Base64字符串
        /// </summary>
        /// <param name="str">要編碼的字符串</param>
        private string Base64Encode(string str)
        {
            byte[] barray;
            barray = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(barray);
        }

        /// <summary>
        /// 將Base64字符串解碼為普通字符串
        /// </summary>
        /// <param name="str">要解碼的字符串</param>
        private string Base64Decode(string str)
        {
            byte[] barray;
            barray = Convert.FromBase64String(str);
            return Encoding.Default.GetString(barray);
        }

        /// <summary>
        /// 得到上傳附件的文件流
        /// </summary>
        /// <param name="FilePath">附件的絕對路徑</param>
        private string GetStream(string FilePath)
        {
            System.IO.FileStream FileStr = new System.IO.FileStream(FilePath, System.IO.FileMode.Open);
            byte[] by = new byte[System.Convert.ToInt32(FileStr.Length)];
            FileStr.Read(by, 0, by.Length);
            FileStr.Close();
            return (System.Convert.ToBase64String(by));
        }

        /// <summary>
        /// SMTP回應代碼哈希表
        /// </summary>
        private void SMTPCodeAdd()
        {
            ErrCodeHT.Add("421", "服務未就緒，關閉傳輸信道");
            ErrCodeHT.Add("432", "需要一個密碼轉換");
            ErrCodeHT.Add("450", "要求的郵件操作未完成，郵箱不可用（例如，郵箱忙）");
            ErrCodeHT.Add("451", "放棄要求的操作；處理過程中出錯");
            ErrCodeHT.Add("452", "系統存儲不足，要求的操作未執行");
            ErrCodeHT.Add("454", "臨時認證失敗");
            ErrCodeHT.Add("500", "郵箱地址錯誤");
            ErrCodeHT.Add("501", "參數格式錯誤");
            ErrCodeHT.Add("502", "命令不可實現");
            ErrCodeHT.Add("503", "服務器需要SMTP驗證");
            ErrCodeHT.Add("504", "命令參數不可實現");
            ErrCodeHT.Add("530", "需要認證");
            ErrCodeHT.Add("534", "認證機制過於簡單");
            ErrCodeHT.Add("538", "當前請求的認證機制需要加密");
            ErrCodeHT.Add("550", "要求的郵件操作未完成，郵箱不可用（例如，郵箱未找到，或不可訪問）");
            ErrCodeHT.Add("551", "用戶非本地，請嘗試<forward-path>");
            ErrCodeHT.Add("552", "過量的存儲分配，要求的操作未執行");
            ErrCodeHT.Add("553", "郵箱名不可用，要求的操作未執行（例如郵箱格式錯誤）");
            ErrCodeHT.Add("554", "傳輸失敗");

            RightCodeHT.Add("220", "服務就緒");
            RightCodeHT.Add("221", "服務關閉傳輸信道");
            RightCodeHT.Add("235", "驗證成功");
            RightCodeHT.Add("250", "要求的郵件操作完成");
            RightCodeHT.Add("251", "非本地用戶，將轉發向<forward-path>");
            RightCodeHT.Add("334", "服務器響應驗證Base64字符串");
            RightCodeHT.Add("354", "開始郵件輸入，以<CRLF>.<CRLF>結束");
        }

        /// <summary>
        /// 發送SMTP命令
        /// </summary> 
        private bool SendCommand(string str)
        {
            byte[] WriteBuffer;
            if (str == null || str.Trim() == String.Empty)
            {
                return true;
            }
            logs += str;
            WriteBuffer = Encoding.Default.GetBytes(str);
            try
            {
                networkStream.Write(WriteBuffer, 0, WriteBuffer.Length);
            }
            catch
            {
                errmsg = "網絡連接錯誤";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 接收SMTP服務器回應
        /// </summary>
        private string RecvResponse()
        {
            int StreamSize;
            string Returnvalue = String.Empty;
            byte[] ReadBuffer = new byte[1024];
            try
            {
                StreamSize = networkStream.Read(ReadBuffer, 0, ReadBuffer.Length);
            }
            catch
            {
                errmsg = "網絡連接錯誤";
                return "false";
            }

            if (StreamSize == 0)
            {
                return Returnvalue;
            }
            else
            {
                Returnvalue = Encoding.Default.GetString(ReadBuffer).Substring(0, StreamSize);
                logs += Returnvalue + this.CRLF;
                return Returnvalue;
            }
        }

        /// <summary>
        /// 與服務器交互，發送一條命令並接收回應。
        /// </summary>
        /// <param name="str">一個要發送的命令</param>
        /// <param name="errstr">如果錯誤，要反饋的信息</param>
        private bool Dialog(string str, string errstr)
        {
            if (str == null || str.Trim() == string.Empty)
            {
                return true;
            }
            if (SendCommand(str))
            {
                string RR = RecvResponse();
                if (RR == "false")
                {
                    return false;
                }

                //檢查返回的代碼，根據[RFC 821]返回代碼為3位數字代碼如220
                string RRCode = RR.Substring(0, 3);
                if (RightCodeHT[RRCode] != null)
                {
                    return true;
                }
                else
                {
                    if (ErrCodeHT[RRCode] != null)
                    {
                        errmsg += (RRCode + ErrCodeHT[RRCode].ToString());
                        errmsg += CRLF;
                    }
                    else
                    {
                        errmsg += RR;
                    }
                    errmsg += errstr;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 與服務器交互，發送一組命令並接收回應。
        /// </summary>
        private bool Dialog(string[] str, string errstr)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Dialog(str[i], ""))
                {
                    errmsg += CRLF;
                    errmsg += errstr;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 連接服務器
        /// </summary>
        private bool Connect(string smtpServer, int port)
        {
            try
            {
                tcpClient = new TcpClient(smtpServer, port);
            }
            catch (Exception e)
            {
                errmsg = e.ToString();
                return false;
            }
            networkStream = tcpClient.GetStream();

            if (RightCodeHT[RecvResponse().Substring(0, 3)] == null)
            {
                errmsg = "網絡連接失敗";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 獲取優先級
        /// </summary>
        /// <param name="mailPriority">優先級</param>
        private string GetPriorityString(MailPriority mailPriority)
        {
            string priority = "Normal";
            if (mailPriority == MailPriority.Low)
            {
                priority = "Low";
            }
            else if (mailPriority == MailPriority.High)
            {
                priority = "High";
            }
            return priority;
        }

        /// <summary>
        /// 發送電子郵件
        /// </summary>
        /// <param name="smtpServer">發信SMTP服務器</param>
        /// <param name="port">端口，默認為25</param>
        /// <param name="username">發信人郵箱地址</param>
        /// <param name="password">發信人郵箱密碼</param>
        /// <param name="mailMessage">郵件內容</param>
        private bool SendEmail(string smtpServer, int port, bool ESmtp, string username, string password, MailMessage mailMessage)
        {
            if (Connect(smtpServer, port) == false) return false;

            string priority = GetPriorityString(mailMessage.Priority);

            bool Html = (mailMessage.BodyFormat == MailFormat.HTML);

            string[] SendBuffer;
            string SendBufferstr;

            //進行SMTP驗證
            if (ESmtp)
            {
                SendBuffer = new String[4];
                SendBuffer[0] = "EHLO " + smtpServer + CRLF;
                SendBuffer[1] = "AUTH LOGIN" + CRLF;
                SendBuffer[2] = Base64Encode(username) + CRLF;
                SendBuffer[3] = Base64Encode(password) + CRLF;
                if (!Dialog(SendBuffer, "SMTP服務器驗證失敗，請核對用戶名和密碼。")) return false;
            }
            else
            {
                SendBufferstr = "HELO " + smtpServer + CRLF;
                if (!Dialog(SendBufferstr, "")) return false;
            }

            //發件人地址
            SendBufferstr = "MAIL FROM:<" + username + ">" + CRLF;
            if (!Dialog(SendBufferstr, "發件人地址錯誤，或不能為空")) return false;

            //收件人地址
            SendBuffer = new string[mailMessage.Recipients.Count];
            for (int i = 0; i < mailMessage.Recipients.Count; i++)
            {
                SendBuffer[i] = "RCPT TO:<" + (string)mailMessage.Recipients[i] + ">" + CRLF;
            }
            if (!Dialog(SendBuffer, "收件人地址有誤")) return false;

            SendBufferstr = "DATA" + CRLF;
            if (!Dialog(SendBufferstr, "")) return false;

            //發件人姓名
            SendBufferstr = "From:" + mailMessage.FromName + "<" + mailMessage.From + ">" + CRLF;

            if (mailMessage.Recipients.Count == 0)
            {
                return false;
            }
            else
            {
                SendBufferstr += "To:=?" + mailMessage.Charset.ToUpper() + "?B?" + Base64Encode((string)mailMessage.Recipients[0]) + "?=" + "<" + (string)mailMessage.Recipients[0] + ">" + CRLF;
            }
            SendBufferstr += ((mailMessage.Subject == String.Empty || mailMessage.Subject == null) ? "Subject:" : ((mailMessage.Charset == "") ? ("Subject:" + mailMessage.Subject) : ("Subject:" + "=?" + mailMessage.Charset.ToUpper() + "?B?" + Base64Encode(mailMessage.Subject) + "?="))) + CRLF;
            SendBufferstr += "X-Priority:" + priority + CRLF;
            SendBufferstr += "X-MSMail-Priority:" + priority + CRLF;
            SendBufferstr += "Importance:" + priority + CRLF;
            SendBufferstr += "X-Mailer: Lion.Web.Mail.SmtpMail Pubclass [cn]" + CRLF;
            SendBufferstr += "MIME-Version: 1.0" + CRLF;
            if (mailMessage.Attachments.Count != 0)
            {
                SendBufferstr += "Content-Type: multipart/mixed;" + CRLF;
                SendBufferstr += " boundary=\"=====" + (Html ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====\"" + CRLF + CRLF;
            }
            if (Html)
            {
                if (mailMessage.Attachments.Count == 0)
                {
                    SendBufferstr += "Content-Type: multipart/alternative;" + CRLF; //內容格式和分隔符
                    SendBufferstr += " boundary=\"=====003_Dragon520636771063_=====\"" + CRLF + CRLF;
                    SendBufferstr += "This is a multi-part message in MIME format." + CRLF + CRLF;
                }
                else
                {
                    SendBufferstr += "This is a multi-part message in MIME format." + CRLF + CRLF;
                    SendBufferstr += "--=====001_Dragon520636771063_=====" + CRLF;
                    SendBufferstr += "Content-Type: multipart/alternative;" + CRLF; //內容格式和分隔符
                    SendBufferstr += " boundary=\"=====003_Dragon520636771063_=====\"" + CRLF + CRLF;
                }
                SendBufferstr += "--=====003_Dragon520636771063_=====" + CRLF;
                SendBufferstr += "Content-Type: text/plain;" + CRLF;
                SendBufferstr += ((mailMessage.Charset == "") ? (" charset=\"iso-8859-1\"") : (" charset=\"" + mailMessage.Charset.ToLower() + "\"")) + CRLF;
                SendBufferstr += "Content-Transfer-Encoding: base64" + CRLF + CRLF;
                SendBufferstr += Base64Encode("郵件內容為HTML格式，請選擇HTML方式查看") + CRLF + CRLF;

                SendBufferstr += "--=====003_Dragon520636771063_=====" + CRLF;

                SendBufferstr += "Content-Type: text/html;" + CRLF;
                SendBufferstr += ((mailMessage.Charset == "") ? (" charset=\"iso-8859-1\"") : (" charset=\"" + mailMessage.Charset.ToLower() + "\"")) + CRLF;
                SendBufferstr += "Content-Transfer-Encoding: base64" + CRLF + CRLF;
                SendBufferstr += Base64Encode(mailMessage.Body) + CRLF + CRLF;
                SendBufferstr += "--=====003_Dragon520636771063_=====--" + CRLF;
            }
            else
            {
                if (mailMessage.Attachments.Count != 0)
                {
                    SendBufferstr += "--=====001_Dragon303406132050_=====" + CRLF;
                }
                SendBufferstr += "Content-Type: text/plain;" + CRLF;
                SendBufferstr += ((mailMessage.Charset == "") ? (" charset=\"iso-8859-1\"") : (" charset=\"" + mailMessage.Charset.ToLower() + "\"")) + CRLF;
                SendBufferstr += "Content-Transfer-Encoding: base64" + CRLF + CRLF;
                SendBufferstr += Base64Encode(mailMessage.Body) + CRLF;
            }
            if (mailMessage.Attachments.Count != 0)
            {
                for (int i = 0; i < mailMessage.Attachments.Count; i++)
                {
                    string filepath = (string)mailMessage.Attachments[i];
                    SendBufferstr += "--=====" + (Html ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====" + CRLF;
                    SendBufferstr += "Content-Type: text/plain;" + CRLF;
                    SendBufferstr += " name=\"=?" + mailMessage.Charset.ToUpper() + "?B?" + Base64Encode(filepath.Substring(filepath.LastIndexOf("\\") + 1)) + "?=\"" + CRLF;
                    SendBufferstr += "Content-Transfer-Encoding: base64" + CRLF;
                    SendBufferstr += "Content-Disposition: attachment;" + CRLF;
                    SendBufferstr += " filename=\"=?" + mailMessage.Charset.ToUpper() + "?B?" + Base64Encode(filepath.Substring(filepath.LastIndexOf("\\") + 1)) + "?=\"" + CRLF + CRLF;
                    SendBufferstr += GetStream(filepath) + CRLF + CRLF;
                }
                SendBufferstr += "--=====" + (Html ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====--" + CRLF + CRLF;
            }
            SendBufferstr += CRLF + "." + CRLF;
            if (!Dialog(SendBufferstr, "錯誤信件信息")) return false;

            SendBufferstr = "QUIT" + CRLF;
            if (!Dialog(SendBufferstr, "斷開連接時錯誤")) return false;

            networkStream.Close();
            tcpClient.Close();
            return true;
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 發送電子郵件,SMTP服務器不需要身份驗證
        /// </summary>
        /// <param name="smtpServer">發信SMTP服務器</param>
        /// <param name="port">端口，默認為25</param>
        /// <param name="mailMessage">郵件內容</param>
        public bool SendEmail(string smtpServer, int port, MailMessage mailMessage)
        {
            return SendEmail(smtpServer, port, false, "", "", mailMessage);
        }

        /// <summary>
        /// 發送電子郵件,SMTP服務器需要身份驗證
        /// </summary>
        /// <param name="smtpServer">發信SMTP服務器</param>
        /// <param name="port">端口，默認為25</param>
        /// <param name="username">發信人郵箱地址</param>
        /// <param name="password">發信人郵箱密碼</param>
        /// <param name="mailMessage">郵件內容</param>
        public bool SendEmail(string smtpServer, int port, string username, string password, MailMessage mailMessage)
        {
            return SendEmail(smtpServer, port, true, username, password, mailMessage);
        }
        #endregion
    }

    /// <summary>
    /// 發送郵件
    /// </summary>
    //--------------------調用-----------------------
    //MailAttachments ma=new MailAttachments();
    //ma.Add(@"附件地址");
    //MailMessage mail = new MailMessage();
    //mail.Attachments=ma;
    //mail.Body="你好";
    //mail.AddRecipients("zjy99684268@163.com");
    //mail.From="zjy99684268@163.com";
    //mail.FromName="zjy";
    //mail.Subject="Hello";
    //SmtpClient sp = new SmtpClient();
    //sp.SmtpServer = "smtp.163.com";
    //sp.Send(mail, "zjy99684268@163.com", "123456");
    //------------------------------------------------
    public class SmtpClient
    {
        #region 構造函數
        public SmtpClient()
        { }

        public SmtpClient(string _smtpServer)
        {
            _SmtpServer = _smtpServer;
        }
        #endregion

        #region 私有字段
        private string errmsg;
        private string _SmtpServer;
        #endregion

        #region 公有屬性
        /// <summary>
        /// 錯誤消息反饋
        /// </summary>
        public string ErrMsg
        {
            get { return errmsg; }
        }

        /// <summary>
        /// 郵件服務器
        /// </summary>
        public string SmtpServer
        {
            set { _SmtpServer = value; }
            get { return _SmtpServer; }
        }
        #endregion

        public bool Send(MailMessage mailMessage, string username, string password)
        {
            SmtpServerHelper helper = new SmtpServerHelper();
            if (helper.SendEmail(_SmtpServer, 25, username, password, mailMessage))
                return true;
            else
            {
                errmsg = helper.ErrMsg;
                return false;
            }
        }
    }

    /// <summary>
    /// 操作服務器上郵件
    /// </summary>
    public class SmtpMail
    {
        public SmtpMail()
        { }

        #region 字段
        private StreamReader sr;
        private StreamWriter sw;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        #endregion

        #region 私有方法
        /// <summary>
        /// 向服務器發送信息
        /// </summary>
        private bool SendDataToServer(string str)
        {
            try
            {
                sw.WriteLine(str);
                sw.Flush();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// 從網絡流中讀取服務器回送的信息
        /// </summary>
        private string ReadDataFromServer()
        {
            string str = null;
            try
            {
                str = sr.ReadLine();
                if (str[0] == '-')
                {
                    str = null;
                }
            }
            catch (Exception err)
            {
                str = err.Message;
            }
            return str;
        }
        #endregion

        #region 獲取郵件信息
        /// <summary>
        /// 獲取郵件信息
        /// </summary>
        /// <param name="uid">郵箱賬號</param>
        /// <param name="pwd">郵箱密碼</param>
        /// <returns>郵件信息</returns>
        public ArrayList ReceiveMail(string uid, string pwd)
        {
            ArrayList EmailMes = new ArrayList();
            string str;
            int index = uid.IndexOf('@');
            string pop3Server = "pop3." + uid.Substring(index + 1);
            tcpClient = new TcpClient(pop3Server, 110);
            networkStream = tcpClient.GetStream();
            sr = new StreamReader(networkStream);
            sw = new StreamWriter(networkStream);

            if (ReadDataFromServer() == null) return EmailMes;
            if (SendDataToServer("USER " + uid) == false) return EmailMes;
            if (ReadDataFromServer() == null) return EmailMes;
            if (SendDataToServer("PASS " + pwd) == false) return EmailMes;
            if (ReadDataFromServer() == null) return EmailMes;
            if (SendDataToServer("LIST") == false) return EmailMes;
            if ((str = ReadDataFromServer()) == null) return EmailMes;

            string[] splitString = str.Split(' ');
            int count = int.Parse(splitString[1]);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if ((str = ReadDataFromServer()) == null) return EmailMes;
                    splitString = str.Split(' ');
                    EmailMes.Add(string.Format("第{0}封郵件，{1}字節", splitString[0], splitString[1]));
                }
                return EmailMes;
            }
            else
            {
                return EmailMes;
            }
        }
        #endregion

        #region 讀取郵件內容
        /// <summary>
        /// 讀取郵件內容
        /// </summary>
        /// <param name="mailMessage">第幾封</param>
        /// <returns>內容</returns>
        public string ReadEmail(string str)
        {
            string state = "";
            if (SendDataToServer("RETR " + str) == false)
                state = "Error";
            else
            {
                state = sr.ReadToEnd();
            }
            return state;
        }
        #endregion

        #region 刪除郵件
        /// <summary>
        /// 刪除郵件
        /// </summary>
        /// <param name="str">第幾封</param>
        /// <returns>操作信息</returns>
        public string DeleteEmail(string str)
        {
            string state = "";
            if (SendDataToServer("DELE " + str) == true)
            {
                state = "成功刪除";
            }
            else
            {
                state = "Error";
            }
            return state;
        }
        #endregion

        #region 關閉服務器連接
        /// <summary>
        /// 關閉服務器連接
        /// </summary>
        public void CloseConnection()
        {
            SendDataToServer("QUIT");
            sr.Close();
            sw.Close();
            networkStream.Close();
            tcpClient.Close();
        }
        #endregion
    }

}

