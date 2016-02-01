using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

namespace DotNet.Utilities.Mail
{
    /// <summary>SendMailHelper Class</summary>
    public class SendMailHelper
    {
        private const string Enter = "\r\n";

        /// <summary> 
        /// 設定語言代碼，默認設定為GB2312，如不需要可設置為"" 
        /// </summary> 
        public string Charset = "UTF-8";
        /// <summary> 
        /// 發件人地址 
        /// </summary> 
        public string From = "";
        /// <summary> 
        /// 發件人姓名 
        /// </summary> 
        public string FromName = "";
        /// <summary> 
        /// 回復郵件地址 
        /// </summary> 
        public string ReplyTo = "";
        /// <summary> 
        /// 收件人姓名 
        /// </summary>    
        public string RecipientName = "";
        /// <summary> 
        /// 收件人列表 
        /// </summary> 
        private Hashtable Recipient = new Hashtable();
        /// <summary> 
        /// 郵件服務器域名 
        /// </summary>    
        private string _mailserver = "";
        /// <summary> 
        /// 郵件服務器端口號 
        /// </summary>    
        private int _mailserverport = 25;
        /// <summary> 
        /// SMTP認證時使用的用戶名 
        /// </summary> 
        private string _username = "";
        /// <summary> 
        /// SMTP認證時使用的密碼 
        /// </summary> 
        private string _password = "";
        /// <summary> 
        /// 是否需要SMTP驗證 
        /// </summary>       
        private bool _eSmtp = false;
        /// <summary> 
        /// 是否Html郵件 
        /// </summary>       
        public bool Html = false;
        /// <summary> 
        /// 郵件附件列表 
        /// </summary> 
        private System.Collections.ArrayList Attachments;
        /// <summary> 
        /// 郵件發送優先級，可設置為"High","Normal","Low"或"1","3","5" 
        /// </summary> 
        private string _priority = "Normal";
        /// <summary> 
        /// 郵件主題 
        /// </summary>       
        public string Subject = "";
        /// <summary> 
        /// 郵件正文 
        /// </summary>       
        public string Body = "";
        /// <summary> 
        /// 收件人數量 
        /// </summary> 
        private int _recipientNum = 0;

        /// <summary> 
        /// 最多收件人數量 
        /// </summary> 
        private const int recipientmaxnum = 5;

        /*
        /// <summary> 
        /// 密件收件人數量 
        /// </summary> 
        private int RecipientBCCNum=0; 
        */

        /// <summary> 
        /// 錯誤消息反饋 
        /// </summary> 
        private string _errmsg;

        /// <summary> 
        /// TcpClient對象，用於連接服務器 
        /// </summary>    
        private TcpClient _tc;

        /// <summary> 
        /// NetworkStream對像 
        /// </summary>    
        private NetworkStream _ns;

        /// <summary> 
        /// SMTP錯誤代碼哈希表 
        /// </summary> 
        private Hashtable ErrCodeHT = new Hashtable();

        /// <summary> 
        /// SMTP正確代碼哈希表 
        /// </summary> 
        private Hashtable RightCodeHT = new Hashtable();

        /// <summary> 
        /// 構造函數
        /// </summary> 
        public SendMailHelper()
        {
            Attachments = new System.Collections.ArrayList();
        }
        /// <summary> 
        /// 郵件服務器域名和驗證信息 
        /// 形如： "user:pass@www.server.com:25 "，也可省略次要信息。如 "user:pass@www.server.com "或 "www.server.com "
        /// </summary>    
        public string MailDomain
        {
            set
            {
                string maidomain = value.Trim();

                if (maidomain != "")
                {
                    int tempint = maidomain.LastIndexOf("@");
                    if (tempint != -1)
                    {
                        string str = maidomain.Substring(0, tempint);
                        MailServerUserName = str.Substring(0, str.IndexOf(":"));
                        MailServerPassWord = str.Substring(str.IndexOf(":") + 1, str.Length - str.IndexOf(":") - 1);
                        maidomain = maidomain.Substring(tempint + 1, maidomain.Length - tempint - 1);
                    }

                    tempint = maidomain.IndexOf(":");
                    if (tempint != -1)
                    {
                        _mailserver = maidomain.Substring(0, tempint);
                        _mailserverport = System.Convert.ToInt32(maidomain.Substring(tempint + 1, maidomain.Length - tempint - 1));
                    }
                    else
                    {
                        _mailserver = maidomain;

                    }


                }

            }
        }

        /// <summary> 
        /// 郵件服務器端口號 
        /// </summary>    
        public int MailDomainPort
        {
            set
            {
                _mailserverport = value;
            }
        }

        /// <summary> 
        /// SMTP認證時使用的用戶名 
        /// </summary> 
        public string MailServerUserName
        {
            set
            {
                if (value.Trim() != "")
                {
                    _username = value.Trim();
                    _eSmtp = true;
                }
                else
                {
                    _username = "";
                    _eSmtp = false;
                }
            }
        }

        /// <summary> 
        /// SMTP認證時使用的密碼 
        /// </summary> 
        public string MailServerPassWord
        {
            set
            {
                _password = value;
            }
        }

        /// <summary> 
        /// 郵件發送優先級，可設置為"High","Normal","Low"或"1","3","5" 
        /// </summary> 
        public string Priority
        {
            set
            {
                switch (value.ToLower())
                {
                    case "high":
                        _priority = "High";
                        break;

                    case "1":
                        _priority = "High";
                        break;

                    case "normal":
                        _priority = "Normal";
                        break;

                    case "3":
                        _priority = "Normal";
                        break;

                    case "low":
                        _priority = "Low";
                        break;

                    case "5":
                        _priority = "Low";
                        break;

                    default:
                        _priority = "Normal";
                        break;
                }
            }
        }


        /// <summary> 
        /// 錯誤消息反饋 
        /// </summary>       
        public string ErrorMessage
        {
            get
            {
                return _errmsg;
            }
        }

        /// <summary> 
        /// 服務器交互記錄 
        /// </summary> 
        private string _logs = "";

        /// <summary> 
        /// 服務器交互記錄，如發現本組件不能使用的SMTP服務器，請將出錯時的Logs發給我（lion-a@sohu.com），我將盡快查明原因。 
        /// </summary> 
        public string Logs
        {
            get
            {
                return _logs;
            }
        }


        /// <summary> 
        /// SMTP回應代碼哈希表 
        /// </summary> 
        private void SMTPCodeAdd()
        {
            ErrCodeHT.Add("500", "郵箱地址錯誤");
            ErrCodeHT.Add("501", "參數格式錯誤");
            ErrCodeHT.Add("502", "命令不可實現");
            ErrCodeHT.Add("503", "服務器需要SMTP驗證");
            ErrCodeHT.Add("504", "命令參數不可實現");
            ErrCodeHT.Add("421", "服務未就緒，關閉傳輸信道");
            ErrCodeHT.Add("450", "要求的郵件操作未完成，郵箱不可用（例如，郵箱忙）");
            ErrCodeHT.Add("550", "要求的郵件操作未完成，郵箱不可用（例如，郵箱未找到，或不可訪問）");
            ErrCodeHT.Add("451", "放棄要求的操作；處理過程中出錯");
            ErrCodeHT.Add("551", "用戶非本地，請嘗試<forward-path>");
            ErrCodeHT.Add("452", "系統存儲不足，要求的操作未執行");
            ErrCodeHT.Add("552", "過量的存儲分配，要求的操作未執行");
            ErrCodeHT.Add("553", "郵箱名不可用，要求的操作未執行（例如郵箱格式錯誤）");
            ErrCodeHT.Add("432", "需要一個密碼轉換");
            ErrCodeHT.Add("534", "認證機制過於簡單");
            ErrCodeHT.Add("538", "當前請求的認證機制需要加密");
            ErrCodeHT.Add("454", "臨時認證失敗");
            ErrCodeHT.Add("530", "需要認證");

            RightCodeHT.Add("220", "服務就緒");
            RightCodeHT.Add("250", "要求的郵件操作完成");
            RightCodeHT.Add("251", "用戶非本地，將轉發向<forward-path>");
            RightCodeHT.Add("354", "開始郵件輸入，以<enter>.<enter>結束");
            RightCodeHT.Add("221", "服務關閉傳輸信道");
            RightCodeHT.Add("334", "服務器響應驗證Base64字符串");
            RightCodeHT.Add("235", "驗證成功");
        }


        /// <summary> 
        /// 將字符串編碼為Base64字符串 
        /// </summary> 
        /// <param name="str">要編碼的字符串</param> 
        private string Base64Encode(string str)
        {
            byte[] barray = Encoding.UTF8.GetBytes(str);
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
        /// <param name="filePath">附件的絕對路徑</param> 
        private string GetStream(string filePath)
        {
            //建立文件流對像 
            var fileStr = new System.IO.FileStream(filePath, System.IO.FileMode.Open);
            byte[] by = new byte[System.Convert.ToInt32(fileStr.Length)];
            fileStr.Read(by, 0, by.Length);
            fileStr.Close();
            return (System.Convert.ToBase64String(by));
        }


        /// <summary> 
        /// 添加郵件附件 
        /// </summary> 
        /// <param name="path">附件絕對路徑</param> 
        public void AddAttachment(string path)
        {
            Attachments.Add(path);
        }

        /// <summary> 
        /// 添加一個收件人 
        /// </summary>    
        /// <param name="str">收件人地址</param> 
        public bool AddRecipient(string str)
        {
            str = str.Trim();
            if (str == null || str == "" || str.IndexOf("@") == -1)
                return true;
            if (_recipientNum < recipientmaxnum)
            {
                Recipient.Add(_recipientNum, str);
                _recipientNum++;
                return true;
            }
            else
            {
                _errmsg += "收件人過多";
                return false;
            }
        }


        /// <summary> 
        /// 最多收件人數量 
        /// </summary> 
        public int RecipientMaxNum
        {
            set
            {
                RecipientMaxNum = value;
            }
        }

        /// <summary>
        /// 添加一組收件人(不超過recipientmaxnum個),參數為字符串數組
        /// </summary>
        /// <param name="recipients">保存有收件人地址的字符串數組(不超過recipientmaxnum個)</param>	
        public bool AddRecipient(params string[] recipients)
        {
            if (Recipient == null)
            {
                _errmsg += "Recipients is Null";
            }
            for (int i = 0; i < recipients.Length; i++)
            {
                string recipient = recipients[i].Trim();
                if (recipient == String.Empty)
                {
                    _errmsg += "Recipients[" + i + "] isNull";
                }
                if (recipient.IndexOf("@") == -1)
                {
                    _errmsg += "Recipients.IndexOf(\"@\")==-1";
                }
                if (!AddRecipient(recipient))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary> 
        /// 發送SMTP命令 
        /// </summary>    
        private bool SendCommand(string str)
        {
            if (str == null || str.Trim() == "")
            {
                return true;
            }
            _logs += str;
            byte[] WriteBuffer = Encoding.Default.GetBytes(str);
            try
            {
                _ns.Write(WriteBuffer, 0, WriteBuffer.Length);
            }
            catch
            {
                _errmsg = "網絡連接錯誤";
                return false;
            }
            return true;
        }

        /// <summary> 
        /// 接收SMTP服務器回應 
        /// </summary> 
        private string RecvResponse()
        {
            int streamSize;
            string returnvalue = "";
            byte[] readBuffer = new byte[1024];
            try
            {
                streamSize = _ns.Read(readBuffer, 0, readBuffer.Length);
            }
            catch
            {
                _errmsg = "網絡連接錯誤";
                return "false";
            }

            if (streamSize == 0)
            {
                return returnvalue;
            }
            else
            {
                returnvalue = Encoding.Default.GetString(readBuffer).Substring(0, streamSize);
                _logs += returnvalue;
                return returnvalue;
            }
        }


        /// <summary> 
        /// 與服務器交互，發送一條命令並接收回應。 
        /// </summary> 
        /// <param name="str">一個要發送的命令</param> 
        /// <param name="errstr">如果錯誤，要反饋的信息</param> 
        private bool Dialog(string str, string errstr)
        {
            if (str == null || str.Trim() == "")
            {
                return true;
            }
            if (SendCommand(str))
            {
                string rr = RecvResponse();
                if (rr == "false")
                {
                    return false;
                }
                string rrCode = rr.Substring(0, 3);
                if (RightCodeHT[rrCode] != null)
                {
                    return true;
                }
                else
                {
                    if (ErrCodeHT[rrCode] != null)
                    {
                        _errmsg += (rrCode + ErrCodeHT[rrCode].ToString());
                        _errmsg += Enter;
                    }
                    else
                    {
                        _errmsg += rr;
                    }
                    _errmsg += errstr;
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
                    _errmsg += Enter;
                    _errmsg += errstr;
                    return false;
                }
            }

            return true;
        }

        private bool SendEmail()
        {
            //連接網絡 
            try
            {
                _tc = new TcpClient(_mailserver, _mailserverport);
            }
            catch (Exception e)
            {
                _errmsg = e.ToString();
                return false;
            }

            _ns = _tc.GetStream();
            SMTPCodeAdd();

            //驗證網絡連接是否正確 
            if (RightCodeHT[RecvResponse().Substring(0, 3)] == null)
            {
                _errmsg = "網絡連接失敗";
                return false;
            }


            string[] sendBuffer;
            string sendBufferstr;

            //進行SMTP驗證 
            if (_eSmtp)
            {
                sendBuffer = new String[4];
                sendBuffer[0] = "EHLO " + _mailserver + Enter;
                sendBuffer[1] = "AUTH LOGIN" + Enter;
                sendBuffer[2] = Base64Encode(_username) + Enter;
                sendBuffer[3] = Base64Encode(_password) + Enter;
                if (!Dialog(sendBuffer, "SMTP服務器驗證失敗，請核對用戶名和密碼。"))
                    return false;
            }
            else
            {
                sendBufferstr = "HELO " + _mailserver + Enter;
                if (!Dialog(sendBufferstr, ""))
                    return false;
            }

            // 
            sendBufferstr = "MAIL FROM:<" + From + ">" + Enter;
            if (!Dialog(sendBufferstr, "發件人地址錯誤，或不能為空"))
                return false;

            // 
            sendBuffer = new string[recipientmaxnum];
            for (int i = 0; i < Recipient.Count; i++)
            {
                sendBuffer[i] = "RCPT TO:<" + Recipient[i].ToString() + ">" + Enter;
            }

            if (!Dialog(sendBuffer, "收件人地址有誤"))
                return false;

            sendBufferstr = "DATA" + Enter;
            if (!Dialog(sendBufferstr, ""))
                return false;

            sendBufferstr = "From:=?" + Charset.ToUpper() + "?B?"+ Base64Encode(FromName) + "?=<" + From + ">" + Enter;
            sendBufferstr += "To:=?" + Charset.ToUpper() + "?B?" + Base64Encode(RecipientName) + "?=" + "<" + Recipient[0] + ">" + Enter;

            //抄送代碼
            /*
            SendBufferstr+="CC:"; 
            for(int i=0;i<Recipient.Count;i++) 
            { 
               SendBufferstr+=Recipient[i].ToString() + "<" + Recipient[i].ToString() +">,"; 
            } 
            SendBufferstr+=enter;
            */

            if (ReplyTo.Length > 0)
            {
                sendBufferstr += "Reply-To:" + ReplyTo + Enter;
            }

            sendBufferstr += (string.IsNullOrEmpty(Subject) ? "Subject:" : ((Charset == "") ? ("Subject:" + Subject) : ("Subject:" + "=?" + Charset.ToUpper() + "?B?" + Base64Encode(Subject) + "?="))) + Enter;
            sendBufferstr += "X-Priority:" + _priority + Enter;
            sendBufferstr += "X-MSMail-Priority:" + _priority + Enter;
            sendBufferstr += "Importance:" + _priority + Enter;
            sendBufferstr += "X-Mailer: Lion.Web.Mail.SmtpMail Pubclass" + Enter;
            sendBufferstr += "MIME-Version: 1.0" + Enter;

            if (Attachments.Count != 0)
            {
                sendBufferstr += "Content-Type: multipart/mixed;" + Enter;
                sendBufferstr += "	boundary=\"=====" + (Html ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====\"" + Enter + Enter;
            }

            if (Html)
            {
                if (Attachments.Count == 0)
                {
                    sendBufferstr += "Content-Type: multipart/alternative;" + Enter;//內容格式和分隔符
                    sendBufferstr += "	boundary=\"=====003_Dragon520636771063_=====\"" + Enter + Enter;

                    sendBufferstr += "This is a multi-part message in MIME format." + Enter + Enter;
                }
                else
                {
                    sendBufferstr += "This is a multi-part message in MIME format." + Enter + Enter;
                    sendBufferstr += "--=====001_Dragon520636771063_=====" + Enter;
                    sendBufferstr += "Content-Type: multipart/alternative;" + Enter;//內容格式和分隔符
                    sendBufferstr += "	boundary=\"=====003_Dragon520636771063_=====\"" + Enter + Enter;
                }
                sendBufferstr += "--=====003_Dragon520636771063_=====" + Enter;
                sendBufferstr += "Content-Type: text/plain;" + Enter;
                sendBufferstr += ((Charset == "") ? ("	charset=\"iso-8859-1\"") : ("	charset=\"" + Charset.ToLower() + "\"")) + Enter;
                sendBufferstr += "Content-Transfer-Encoding: base64" + Enter + Enter;
                sendBufferstr += Base64Encode("郵件內容為HTML格式,請選擇HTML方式查看") + Enter + Enter;

                sendBufferstr += "--=====003_Dragon520636771063_=====" + Enter;



                sendBufferstr += "Content-Type: text/html;" + Enter;
                sendBufferstr += ((Charset == "") ? ("	charset=\"iso-8859-1\"") : ("	charset=\"" + Charset.ToLower() + "\"")) + Enter;
                sendBufferstr += "Content-Transfer-Encoding: base64" + Enter + Enter;
                sendBufferstr += Base64Encode(Body) + Enter + Enter;
                sendBufferstr += "--=====003_Dragon520636771063_=====--" + Enter;
            }
            else
            {
                if (Attachments.Count != 0)
                {
                    sendBufferstr += "--=====001_Dragon303406132050_=====" + Enter;
                }
                sendBufferstr += "Content-Type: text/plain;" + Enter;
                sendBufferstr += ((Charset == "") ? ("	charset=\"iso-8859-1\"") : ("	charset=\"" + Charset.ToLower() + "\"")) + Enter;
                sendBufferstr += "Content-Transfer-Encoding: base64" + Enter + Enter;
                sendBufferstr += Base64Encode(Body) + Enter;
            }

            //SendBufferstr += "Content-Transfer-Encoding: base64"+enter;

            if (Attachments.Count != 0)
            {
                foreach (object t in Attachments)
                {
                    var filepath = (string)t;
                    sendBufferstr += "--=====" + (Html ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====" + Enter;
                    //SendBufferstr += "Content-Type: application/octet-stream"+enter;
                    sendBufferstr += "Content-Type: text/plain;" + Enter;
                    sendBufferstr += "	name=\"=?" + Charset.ToUpper() + "?B?" + Base64Encode(filepath.Substring(filepath.LastIndexOf("\\") + 1)) + "?=\"" + Enter;
                    sendBufferstr += "Content-Transfer-Encoding: base64" + Enter;
                    sendBufferstr += "Content-Disposition: attachment;" + Enter;
                    sendBufferstr += "	filename=\"=?" + Charset.ToUpper() + "?B?" + Base64Encode(filepath.Substring(filepath.LastIndexOf("\\") + 1)) + "?=\"" + Enter + Enter;
                    sendBufferstr += GetStream(filepath) + Enter + Enter;
                }
                sendBufferstr += "--=====" + (Html ? "001_Dragon520636771063_" : "001_Dragon303406132050_") + "=====--" + Enter + Enter;
            }

            sendBufferstr += Enter + "." + Enter;

            if (!Dialog(sendBufferstr, "錯誤信件信息"))
                return false;


            sendBufferstr = "QUIT" + Enter;
            if (!Dialog(sendBufferstr, "斷開連接時錯誤"))
                return false;


            _ns.Close();
            _tc.Close();
            return true;
        }


        /// <summary> 
        /// 發送郵件方法，所有參數均通過屬性設置。 
        /// </summary> 
        public bool Send()
        {
            if (Recipient.Count == 0)
            {
                _errmsg = "收件人列表不能為空";
                return false;
            }

            if (_mailserver.Trim() == "")
            {
                _errmsg = "必須指定SMTP服務器";
                return false;
            }

            if (Body.Trim() == "")
            {
                _errmsg = "必須指定Body";
                return false;
            }

            return SendEmail();

        }

        /// <summary> 
        /// 發送郵件方法 
        /// </summary> 
        /// <param name="smtpserver">smtp服務器信息，如"username:passwordwww.smtpserver.com:25"，也可去掉部分次要信息，如www.smtpserver.com"</param> 
        public bool Send(string smtpserver)
        {
            MailDomain = smtpserver;
            return Send();
        }


        /// <summary> 
        /// 發送郵件方法 
        /// </summary> 
        /// <param name="smtpserver">smtp服務器信息，如 "username:password@www.smtpserver.com:25 "，也可去掉部分次要信息，如 "www.smtpserver.com "</param> 
        /// <param name="from">發件人mail地址</param> 
        /// <param name="fromname">發件人姓名</param> 
        /// <param name="to">收件人地址</param> 
        /// <param name="toname">收件人姓名</param> 
        /// <param name="html">是否HTML郵件</param> 
        /// <param name="subject">郵件主題</param> 
        /// <param name="body">郵件正文</param> 
        public bool Send(string smtpserver, string from, string fromname, string to, string toname, bool html, string subject, string body)
        {
            MailDomain = smtpserver;
            From = from;
            FromName = fromname;
            AddRecipient(to);
            RecipientName = toname;
            Html = html;
            Subject = subject;
            Body = body;
            return Send();
        }

        /// <summary> 
        /// 釋放TcpClient同NetworkStream對像
        /// </summary> 
        public void Dispose()
        {
            if (_ns != null)
                _ns.Close();
            if (_tc != null)
                _tc.Close();
        }

    }
}
