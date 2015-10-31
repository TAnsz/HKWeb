/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    public class PageValidate
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等價於^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或數字的字符串，和 [a-zA-Z0-9] 語法一樣 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");

        public PageValidate()
        {
        }


        #region 數字字符串檢查
        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="inputData">源字符串</param>
        /// <param name="formatlevel">0:不做驗證| 1:sql語句參數| 2:存儲過程參數| 3:EncodeHtml| 4:Encode+sql| 5:Encode+存儲過程</param>
        /// <returns>返回格式化後的字符串</returns>
        public static string FormatString(string inputData, int formatlevel)
        {
            return inputData;
        }
        /// <summary>
        /// 檢查Request查詢字符串的鍵值，是否是數字，最大長度限制
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request的鍵值</param>
        /// <param name="maxLen">最大長度</param>
        /// <returns>返回Request查詢字符串</returns>
        public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
        {
            string retVal = string.Empty;
            if (inputKey != null && inputKey != string.Empty)
            {
                retVal = req.QueryString[inputKey];
                if (null == retVal)
                    retVal = req.Form[inputKey];
                if (null != retVal)
                {
                    retVal = SqlText(retVal, maxLen);
                    if (!IsNumber(retVal))
                        retVal = string.Empty;
                }
            }
            if (retVal == null)
                retVal = string.Empty;
            return retVal;
        }

        public enum CheckType
        { None, Int, SignInt, Float, SignFloat, Chinese, Mail }
        /// <summary>
        /// 檢測字符串類型
        /// </summary>
        /// <param name="inputData">輸入字符串</param>
        /// <param name="checktype">0:不檢測| 1:數字| 2:符號數字| 3: 浮點數| 4:符號浮點| 5: 中文?| 6:郵件?</param>
        /// <returns></returns>
        public static bool checkString(string inputData, int checktype)
        {

            bool _return = false;
            switch (checktype)
            {
                case 0:
                    _return = true;
                    break;
                case 1:
                    _return = IsNumber(inputData);
                    break;
                case 2:
                    _return = IsNumberSign(inputData);
                    break;
                case 3:
                    _return = IsDecimal(inputData);
                    break;
                case 4:
                    _return = IsDecimalSign(inputData);
                    break;
                case 5:
                    _return = IsHasCHZN(inputData);
                    break;
                case 6:
                    _return = IsEmail(inputData);
                    break;
                default:
                    _return = false;
                    break;
            }
            return _return;
        }
        /// <summary>
        /// 是否數字字符串
        /// </summary>
        /// <param name="inputData">輸入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否數字字符串 可帶正負號
        /// </summary>
        /// <param name="inputData">輸入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮點數
        /// </summary>
        /// <param name="inputData">輸入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮點數 可帶正負號
        /// </summary>
        /// <param name="inputData">輸入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 中文檢測

        /// <summary>
        /// 檢測是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        public static string GetShortDate(string dt)
        {
            return Convert.ToDateTime(dt).ToShortDateString();
        }

        #region 郵件地址
        /// <summary>
        /// 是否是浮點數 可帶正負號
        /// </summary>
        /// <param name="inputData">輸入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 其他

        /// <summary>
        /// 檢查字符串最大長度，返回指定長度的串
        /// </summary>
        /// <param name="sqlInput">輸入字符串</param>
        /// <param name="maxLength">最大長度</param>
        /// <returns></returns>			
        public static string SqlText(string sqlInput, int maxLength)
        {
            if (sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)//按最大長度截取字符串
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }


        /// <summary>
        /// 字符串編碼
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }
        /// <summary>
        /// 設置Label顯示Encode的字符串
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="txtInput"></param>
        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = HtmlEncode(txtInput);
        }
        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }

        #endregion

        #region 對於用戶權限從數據庫中讀出的解密過程
        public static string switch_riddle(string s_ch)//解密
        {
            string s_out, s_temp, temp;
            int i_len = s_ch.Length;
            if (i_len == 0 || s_ch == "")
            {
                s_out = "0";
            }
            temp = "";
            s_temp = "";
            s_out = "";
            for (int i = 0; i <= i_len - 1; i++)
            {
                temp = s_ch.Substring(i, 1);
                switch (temp)
                {
                    case "a": s_temp = "1010";
                        break;
                    case "b": s_temp = "1011";
                        break;
                    case "c": s_temp = "1100";
                        break;
                    case "d": s_temp = "1101";
                        break;
                    case "e": s_temp = "1110";
                        break;
                    case "f": s_temp = "1111";
                        break;
                    case "0": s_temp = "0000";
                        break;
                    case "1": s_temp = "0001";
                        break;
                    case "2": s_temp = "0010";
                        break;
                    case "3": s_temp = "0011";
                        break;
                    case "4": s_temp = "0100";
                        break;
                    case "5": s_temp = "0101";
                        break;
                    case "6": s_temp = "0110";
                        break;
                    case "7": s_temp = "0111";
                        break;
                    case "8": s_temp = "1000";
                        break;
                    case "9": s_temp = "1001";
                        break;
                    default: s_temp = "0000";
                        break;
                }
                s_out = s_out + s_temp;
                s_temp = "";
            }
            return s_out;
        }
        #endregion

        #region 用戶權限的加密過程
        public static string switch_encrypt(string s_ch)
        {
            string s_out, s_temp, temp;
            int i_len = 64;
            if (i_len == 0 || s_ch == "")
            {
                s_out = "0000";
            }
            temp = "";
            s_temp = "";
            s_out = "";
            for (int i = 0; i <= i_len - 1; i = i + 4)
            {
                temp = s_ch.Substring(i, 4);
                switch (temp)
                {
                    case "1010": s_temp = "a";
                        break;
                    case "1011": s_temp = "b";
                        break;
                    case "1100": s_temp = "c";
                        break;
                    case "1101": s_temp = "d";
                        break;
                    case "1110": s_temp = "e";
                        break;
                    case "1111": s_temp = "f";
                        break;
                    case "0000": s_temp = "0";
                        break;
                    case "0001": s_temp = "1";
                        break;
                    case "0010": s_temp = "2";
                        break;
                    case "0011": s_temp = "3";
                        break;
                    case "0100": s_temp = "4";
                        break;
                    case "0101": s_temp = "5";
                        break;
                    case "0110": s_temp = "6";
                        break;
                    case "0111": s_temp = "7";
                        break;
                    case "1000": s_temp = "8";
                        break;
                    case "1001": s_temp = "9";
                        break;
                    default: s_temp = "0";
                        break;
                }
                s_out = s_out + s_temp;
                s_temp = "";
            }
            return s_out;
        }//加密
        #endregion

        #region   訪問權限
        public static bool CheckTrue(string s_admin, int a)
        {
            string s_temp = "";
            s_temp = s_admin.Substring(a - 1, 1);   //s_admin為全局變量
            if (s_temp == "" || s_temp == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region   檢測字符串長度
        /// <summary>   
        /// 計算文本長度，區分中英文字符，中文算兩個長度，英文算一個長度
        /// </summary>
        /// <param name="Text">需計算長度的字符串</param>
        /// <returns>int</returns>
        public static int Text_Length(string Text)
        {
            int len = 0;

            for (int i = 0; i < Text.Length; i++)
            {
                byte[] byte_len = Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //如果長度大於1，是中文，佔兩個字節，+2
                else
                    len += 1;  //如果長度等於1，是英文，佔一個字節，+1
            }

            return len;
        }
        #endregion

        #region   字符串長度區分中英文截取
        /// <summary>   
        /// 截取文本，區分中英文字符，中文算兩個長度，英文算一個長度
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <param name="length">需計算長度的字符串</param>
        /// <returns>string</returns>
        public static string GetSubString(string str, int length)
        {
            string temp = str;
            int j = 0;
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Regex.IsMatch(temp.Substring(i, 1), @"[\u4e00-\u9fa5]+"))
                {
                    j += 2;
                }
                else
                {
                    j += 1;
                }
                if (j <= length)
                {
                    k += 1;
                }
                if (j > length)
                {
                    return temp.Substring(0, k) + "..";
                }
            }
            return temp;
        }
        #endregion

        #region 頁面HTML格式化
        public static string GetHtml(string sDetail)
        {
            Regex r;
            Match m;
            #region 處理空格
            sDetail = sDetail.Replace(" ", "&nbsp;");
            #endregion
            #region 處理單引號
            sDetail = sDetail.Replace("'", "』");
            #endregion
            #region 處理雙引號
            sDetail = sDetail.Replace("\"", "&quot;");
            #endregion
            #region html標記符
            sDetail = sDetail.Replace("<", "&lt;");
            sDetail = sDetail.Replace(">", "&gt;");

            #endregion
            #region 處理換行
            //處理換行，在每個新行的前面添加兩個全角空格
            r = new Regex(@"(\r\n((&nbsp;)|　)+)(?<正文>\S+)", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<BR>　　" + m.Groups["正文"].ToString());
            }
            //處理換行，在每個新行的前面添加兩個全角空格
            sDetail = sDetail.Replace("\r\n", "<BR>");
            #endregion

            return sDetail;
        }
        #endregion

        #region 分頁
        //public static string paging(string url, string para, int sumpage, int page)
        //{
        //    string result = string.Empty;
        //    if (sumpage == 1)
        //    {
        //        return result;
        //    }
        //    if (page > sumpage)
        //    {
        //        page = 1;
        //    }
        //    if (sumpage > 0)
        //    {
        //        for (int i = 1; i <= sumpage; i++)
        //        {
        //            if (i == page)
        //            {
        //                result += string.Format("<a class=\"a_page\" href=\"{0}?page={1}{2}\">{3}</a> ", new object[] { url, i.ToString(), para, i.ToString() });
        //            }
        //            else
        //            {
        //                result += string.Format("<a href=\"{0}?page={1}{2}\">{3}</a> ", new object[] { url, i.ToString(), para, i.ToString() });
        //            }
        //        }
        //    }
        //    return result;
        //}

        public static string paging(string url, string para, int sumpage, int page)
        {
            string result = string.Empty;
            if (sumpage == 1)
            {
                return result;
            }
            if (sumpage > 500)
            {
                sumpage = 500;
            }
            if (page > sumpage)
            {
                page = 1;
            }
            StringBuilder sb = new StringBuilder();
            if (sumpage > 0)
            {
                switch (page)
                {
                    case 1:
                        sb.Append(string.Format("<p class=\"next\"><a href=\"{0}?page={1}{2}\">{3}</a> ", new object[] { url, page + 1, para, "下一頁" }));
                        break;
                    default:
                        if (sumpage == page)
                        {
                            sb.Append(string.Format("<p class=\"next\"><a href=\"{0}?page={1}{2}\">{3}</a> ", new object[] { url, page - 1, para, "上一頁" }));
                        }
                        else
                        {
                            sb.Append(string.Format("<p class=\"next\"><a href=\"{0}?page={1}{2}\">{3}</a> <a href=\"{4}?page={5}{6}\">{7}</a> ",
                                new object[] { url, page + 1, para, "下一頁", url, page - 1, para, "上一頁" }));
                        }
                        break;
                }
                sb.Append(string.Format("第{0}/{1}頁</p>", new object[] { page, sumpage }));
            }
            return sb.ToString();
        }

        public static string paging(string url, string para, int sumpage, int page, System.Web.UI.UserControl myPaging)
        {
            myPaging.Visible = false;
            string result = string.Empty;
            if (sumpage == 1)
            {
                return result;
            }
            if (sumpage > 500)
            {
                sumpage = 500;
            }
            if (page > sumpage)
            {
                page = 1;
            }
            StringBuilder sb = new StringBuilder();
            if (sumpage > 0)
            {
                myPaging.Visible = true;
                switch (page)
                {
                    case 1:
                        sb.Append(string.Format("<a href=\"{0}?page={1}{2}\">{3}</a> ", new object[] { url, page + 1, para, "下一頁" }));
                        break;
                    default:
                        if (sumpage == page)
                        {
                            sb.Append(string.Format("<a href=\"{0}?page={1}{2}\">{3}</a> ", new object[] { url, page - 1, para, "上一頁" }));
                        }
                        else
                        {
                            sb.Append(string.Format("<a href=\"{0}?page={1}{2}\">{3}</a> <a href=\"{4}?page={5}{6}\">{7}</a> ",
                                new object[] { url, page + 1, para, "下一頁", url, page - 1, para, "上一頁" }));
                        }
                        break;
                }
                sb.Append(string.Format("第{0}/{1}頁", new object[] { page, sumpage }));
            }
            return sb.ToString();
        }

        public static string paging(string para, int sumpage, int page, int count)
        {
            string result = string.Empty;
            if (page > sumpage)
            {
                page = 1;
            }
            StringBuilder sb = new StringBuilder();
            if (sumpage > 0)
            {
                if (sumpage != 1)
                {
                    switch (page)
                    {
                        case 1:
                            sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a> ", new object[] { page + 1, para, "下一頁" }));
                            break;
                        default:
                            if (sumpage == page)
                            {
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a> ", new object[] { page - 1, para, "上一頁" }));
                            }
                            else
                            {
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a> <a href=\"?page={3}{4}\">{5}</a> ",
                                    new object[] { page - 1, para, "上一頁", page + 1, para, "下一頁" }));
                            }
                            break;
                    }
                }
                sb.Append(string.Format("第{0}/{1}頁 共{2}條", new object[] { page, sumpage, count }));
            }
            return sb.ToString();
        }

        public static void paging(string clinktail, int sumpage, int page, System.Web.UI.WebControls.Label page_view)
        {
            if (sumpage > 0)
            {
                int n = sumpage;    //總頁數
                int x = page;   //得到當前頁
                int i;
                int endpage;
                string pageview = "", pageviewtop = "";
                if (x > 1)
                {
                    pageview += "&nbsp;&nbsp;<a class='pl' href='?page=1" + clinktail + "'>第1頁</a> | ";
                    pageviewtop += "&nbsp;&nbsp;<a class='pl' href='?page=1" + clinktail + "'>第1頁</a> | ";
                }
                else
                {
                    pageview += "&nbsp;&nbsp;<font color='#666666'> 第1頁 </font> | ";
                    pageviewtop += "&nbsp;&nbsp;<font color='#666666'> 第1頁 </font> | ";
                }

                if (x > 1)
                {
                    pageviewtop += " <a class='pl' href='?page=" + (x - 1) + "" + clinktail + "'>上1頁</a> ";
                }
                else
                {
                    pageviewtop += " <font color='#666666'>上1頁</font> ";
                }

                if (x > ((x - 1) / 10) * 10 && x > 10)
                {
                    pageview += "<a class='pl' href='?page=" + ((x - 1) / 10) * 10 + "" + clinktail + "' onclink='return false;'>上10頁</a>";
                }

                //if (((x-1) / 10) * 10 + 10) >= n )
                if (((x - 1) / 10) * 10 + 10 >= n)
                {
                    endpage = n;
                }
                else
                {
                    endpage = ((x - 1) / 10) * 10 + 10;
                }

                for (i = ((x - 1) / 10) * 10 + 1; i <= endpage; ++i)
                {
                    if (i == x)
                    {
                        pageview += " <font color='#FF0000'><b>" + i + "</b></font>";
                    }
                    else
                    {
                        pageview += " <a class='pl' href='?page=" + i + "" + clinktail + "'>" + i + "</a>";
                    }
                }

                if (x < n)
                {
                    pageviewtop += " <a class='pl' href='?page=" + (x + 1) + "" + clinktail + "'>下1頁</a> ";
                }
                else
                {
                    pageviewtop += " <font color='#666666'>下1頁</font> ";
                }

                if (endpage != n)
                {
                    pageview += " <a class='pl' href='?page=" + (endpage + 1) + "" + clinktail + "' class='pl' onclink='return false;'>下10頁</a> | ";
                }
                else
                {
                    pageview += " | ";
                }
                if (x < n)
                {
                    pageview += " <a class='pl' href='?page=" + n + "" + clinktail + "' class='pl'>第" + n + "頁</a> ";
                    pageviewtop += " |  <a class='pl' href='?page=" + n + "" + clinktail + "' class='pl'>第" + n + "頁</a> ";
                }
                else
                {
                    pageview += "<font color='#666666'> 第" + n + "頁 </font>";
                    pageviewtop += " | <font color='#666666'> 第" + n + "頁 </font>";
                }
                page_view.Text = pageview.ToString();
            }
            else
            {
                page_view.Text = "";
            }
        }

        //帶第一頁和最後一頁
        public static string paging2(string para, int sumpage, int page, int count)
        {
            string result = string.Empty;
            if (page > sumpage)
            {
                page = 1;
            }
            StringBuilder sb = new StringBuilder();
            if (sumpage > 0)
            {
                if (sumpage != 1)
                {
                    //第一頁
                    sb.Append(string.Format("<a href=\"?page={0}{1}\"><img src=\"images/first-icon.gif\" border=\"0\"/></a>&nbsp;&nbsp;", new object[] { 1, para }));
                    switch (page)
                    {
                        case 1:
                            //前一頁圖片
                            sb.Append(string.Format("<a>{0}</a>", new object[] { "<img src=\"images/left-icon.gif\" border=\"0\"/>" }));
                            sb.Append(string.Format("<a>上一頁</a><a href=\"?page={0}{1}\">{2}</a> ", new object[] { page + 1, para, "下一頁" }));
                            //後一頁圖片
                            sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page + 1, para, "<img src=\"images/right-icon.gif\" border=\"0\"/>" }));
                            break;
                        default:
                            if (sumpage == page)
                            {
                                //前一頁圖片
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page - 1, para, "<img src=\"images/left-icon.gif\" border=\"0\"/>" }));
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a><a>下一頁</a> ", new object[] { page - 1, para, "上一頁" }));
                                //後一頁圖片
                                sb.Append(string.Format("<a>{0}</a>", new object[] { "<img src=\"images/right-icon.gif\" />" }));
                            }
                            else
                            {
                                //前一頁圖片
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page - 1, para, "<img src=\"images/left-icon.gif\" border=\"0\"/>" }));
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a> <a href=\"?page={3}{4}\">{5}</a> ",
                                    new object[] { page - 1, para, "上一頁", page + 1, para, "下一頁" }));
                                //後一頁圖片
                                sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page + 1, para, "<img src=\"images/right-icon.gif\" border=\"0\"/>" }));
                            }
                            break;
                    }
                    //最後一頁圖片
                    sb.Append(string.Format("&nbsp;&nbsp;<a href=\"?page={0}{1}\"><img src=\"images/last-icon.gif\" border=\"0\"/></a>&nbsp;&nbsp;", new object[] { sumpage, para }));
                }
                sb.Append(string.Format("第{0}頁/共{1}頁 共{2}條", new object[] { page, sumpage, count }));
            }
            return sb.ToString();
        }

        public static string paging3(string url, string para, int sumpage, int page, int count)
        {
            string result = string.Empty;
            if (page > sumpage)
            {
                page = 1;
            }
            StringBuilder sb = new StringBuilder();
            if (sumpage > 0)
            {
                if (sumpage != 1)
                {
                    //第一頁
                    sb.Append(string.Format("<a href=\"{2}?page={0}{1}\">首頁</a>", new object[] { 1, para, url }));
                    switch (page)
                    {
                        case 1:
                            //前一頁圖片
                            // sb.Append(string.Format("<a>{0}</a>", new object[] { "<img src=\"images/left-icon.gif\" border=\"0\"/>" }));
                            sb.Append(string.Format("<a>上一頁</a><a href=\"{3}?page={0}{1}\">{2}</a> ", new object[] { page + 1, para, "下一頁", url }));
                            //後一頁圖片
                            // sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page + 1, para, "<img src=\"images/right-icon.gif\" border=\"0\"/>" }));
                            break;
                        default:
                            if (sumpage == page)
                            {
                                //前一頁圖片
                                //sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page - 1, para, "<img src=\"images/left-icon.gif\" border=\"0\"/>" }));
                                sb.Append(string.Format("<a href=\"{3}?page={0}{1}\">{2}</a><a>下一頁</a> ", new object[] { page - 1, para, "上一頁", url }));
                                //後一頁圖片
                                //sb.Append(string.Format("<a>{0}</a>", new object[] { "<img src=\"images/right-icon.gif\" />" }));
                            }
                            else
                            {
                                //前一頁圖片
                                //sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page - 1, para, "<img src=\"images/left-icon.gif\" border=\"0\"/>" }));
                                sb.Append(string.Format("<a href=\"{6}?page={0}{1}\">{2}</a> <a href=\"{6}?page={3}{4}\">{5}</a> ",
                                    new object[] { page - 1, para, "上一頁", page + 1, para, "下一頁", url }));
                                //後一頁圖片
                                //sb.Append(string.Format("<a href=\"?page={0}{1}\">{2}</a>", new object[] { page + 1, para, "<img src=\"images/right-icon.gif\" border=\"0\"/>" }));
                            }
                            break;
                    }
                    //最後一頁圖片
                    sb.Append(string.Format("<a href=\"{2}?page={0}{1}\">末頁</a>&nbsp;&nbsp;", new object[] { sumpage, para, url }));
                }
                sb.Append(string.Format("第{0}頁/共{1}頁 共{2}條", new object[] { page, sumpage, count }));
            }
            return sb.ToString();
        }
        #endregion

        #region 日期格式判斷
        /// <summary>
        /// 日期格式字符串判斷
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    DateTime.Parse(str);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 是否由特定字符組成
        public static bool isContainSameChar(string strInput)
        {
            string charInput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                charInput = strInput.Substring(0, 1);
            }
            return isContainSameChar(strInput, charInput, strInput.Length);
        }

        public static bool isContainSameChar(string strInput, string charInput, int lenInput)
        {
            if (string.IsNullOrEmpty(charInput))
            {
                return false;
            }
            else
            {
                Regex RegNumber = new Regex(string.Format("^([{0}])+$", charInput));
                //Regex RegNumber = new Regex(string.Format("^([{0}]{{1}})+$", charInput,lenInput));
                Match m = RegNumber.Match(strInput);
                return m.Success;
            }
        }
        #endregion

        #region 檢查輸入的參數是不是某些定義好的特殊字符：這個方法目前用於密碼輸入的安全檢查
        /// <summary>
        /// 檢查輸入的參數是不是某些定義好的特殊字符：這個方法目前用於密碼輸入的安全檢查
        /// </summary>
        public static bool isContainSpecChar(string strInput)
        {
            string[] list = new string[] { "123456", "654321" };
            bool result = new bool();
            for (int i = 0; i < list.Length; i++)
            {
                if (strInput == list[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        #endregion
    }
}