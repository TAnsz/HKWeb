using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using DotNet.Utilities;
using DotNet.Utilities.Json;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;


/***********************************************************************
 *   作    者：July
 *   博    客：
 *   技 術 群：327360708
 *  
 *   創建日期：很多很多年前
 *   文件名稱：FileUpload.ashx.cs
 *   描    述：上傳類（本頁只用於後台，前台不調用）
 *             
 *   修 改 人：AllEmpty（陳煥）-- 1654937@qq.com
 *   修改日期：2014-07-02
 *   修改原因：將程序進行修改，以適應本框架結構調用
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Application
{
    /// <summary>
    /// RemoteUpload 上傳類（本頁只用於後台編輯器，前台不調用）
    /// </summary>
    public class RemoteUpload : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //---------------------------------------------------
            int vid = RequestHelper.GetInt0("vid");
            string key = RequestHelper.GetKeyChar("key", 20);
            if (vid < 1 || key.Length < 10)
            {
                ShowMsg_Editor("缺少參數:key或sid");
                return;
            }

            string pic = RequestHelper.PostText("pic", 200, false);
            if (!isRemotePic(pic))
            {
                ShowMsg_Editor("圖片地址格式不正確!");
                return;
            }

            //---------------------------------------------------
            #region 判斷權限
            int userId = 0;
            string userName = "";
            if (SessionHelper.GetSession("UserHashKey") != null)
            {
                var uinfo = OnlineUsersBll.GetInstence().GetOnlineUsersModel();
                userId = uinfo.Manager_Id;
                userName = uinfo.Manager_CName;
            }
            else
            {
                ShowMsg_Editor("還未登陸，權限不足！");
                return;
            }
            #endregion

            /* 測試使用
                int vid = 52;
                string key = RandomHelp.GetRndKey();
                string pic = "http://bidhtml.july.com/Images/ad/indexHotAd.jpg";
                int userId = 4;
                string userName = "admin";
                */
            //---------------------------------------------------
            var m_r = new UploadFile();
            string msg = new UploadFileBll().Upload_RemotePic(vid, key, userId, userName, pic, m_r);
            if (msg.Length > 0)
            {
                ShowMsg_Editor(msg);
            }
            else
            {
                ShowMsg_Editor("上傳成功", m_r.Path);
            }

            Write("系統暫時禁止上傳文件！");
            //RequestHelper.AlertUtf8("系統暫時禁止上傳文件！", 8, "");
            return;
        }

        /// <summary>判斷url是否為遠程圖片 </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool isRemotePic(string url)
        {
            if (string.IsNullOrEmpty(url) || url.Length < 10)
            {
                return false;
            }
            if (url.Substring(0, 7).ToLower() == "http://")
            {
                string local = RequestHelper.GetRequestHost().ToLower();
                int ti = local.Length;
                if (url.Length > ti)
                {
                    if (url.Substring(0, ti).ToLower() != local)
                    {
                        /*
                        string sAllowed = ",jpg,gif,png,bmp,";
                        string sExt = "," + FileHelper.GetFileExt(url).ToLower() + ",";
                        return (sAllowed.IndexOf(sExt) > -1);
                        */
                        return Regex.IsMatch(url, "\\.(jpg|gif|png)?", RegexOptions.IgnoreCase);
                    }
                }
            }
            return false;
        }

        /// <summary>提示信息輸出（編輯器ke4專用）</summary>
        /// <param name="msg">提示內容</param>
        /// <param name="filePath">上傳後新的url地址</param>
        private void ShowMsg_Editor(string msg, string filePath = "")
        {
            var hash = new Hashtable();

            if (filePath == "")
            {
                hash["error"] = 1;
                hash["message"] = StringHelper.XssTextClear(msg);
            }
            else
            {
                hash["error"] = 0;
                hash["url"] = filePath;
            }

            string str = JsonHelper.ToJson(hash);

            Write(str);
            //RequestHelper.AlertUtf8(str, 8, "");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void Write(string str)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ContentType = "text/html";
            response.Charset = "utf-8";
            response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            response.Expires = -1;
            response.AddHeader("pragma", "no-cache");
            response.AddHeader("cache-control", "private");
            response.CacheControl = "no-cache";

            response.Write(str);
            response.End();
        }
    }
}