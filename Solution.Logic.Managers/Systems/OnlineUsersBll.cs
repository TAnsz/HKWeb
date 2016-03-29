using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-17
 *   文件名稱：OnlineUsersBll.cs
 *   描    述：用戶在線列表緩存管理邏輯類
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// OnlineUsersBll邏輯類
    /// </summary>
    public partial class OnlineUsersBll : LogicBase
    {
        /***********************************************************************
         * 自定義函數                                                          *
         ***********************************************************************/
        #region 自定義函數

        #region 獲取在線用戶表實體
        /// <summary>
        /// 根據字段名稱，獲取當前用戶在線表中的內容
        /// </summary>
        /// <returns></returns>
        public DataAccess.Model.OnlineUsers GetOnlineUsersModel(string userHashKey = null)
        {
            try
            {
                if (string.IsNullOrEmpty(userHashKey))
                {
                    userHashKey = GetUserHashKey();
                }

                //如果不存在在線表則退出
                if (string.IsNullOrEmpty(userHashKey))
                    return null;

                //返回指定字段的內容
                var model = GetModelForCache(x => x.UserHashKey == userHashKey);

                return model;
            }
            catch (Exception e)
            {
                //記錄出錯日誌
                CommonBll.WriteLog("獲取用戶表實體出錯", e);
            }

            return null;
        }
        #endregion

        #region 獲取在線用戶表內容
        /// <summary>
        /// 根據字段名稱，獲取指定用戶在線表中的內容
        /// </summary>
        /// <param name="userHashKey">用戶在線列表的Key</param>
        /// <param name="colName">字段名<para/>
        /// userId : 當前用戶的ID編號<para/>
        /// LoginDate : 登錄時間<para/>
        /// OnlineTime : 在線時長<para/>
        /// LoginIp : 當前用戶IP<para/>
        /// LoginName : 當前用戶登陸名<para/>
        /// CName : 當前用戶中文名<para/>
        /// Sex : 當前用戶的性別<para/>
        /// BranchId : 部門自動ID<para/>
        /// BranchCode : 部門編碼<para/>
        /// BranchName : 部門名稱<para/>
        /// PositionInfoId : 職位ID<para/>
        /// PositionInfoName : 職位名稱<para/>
        /// </param>
        /// <returns></returns>
        public object GetUserOnlineInfo(string userHashKey, string colName)
        {
            try
            {
                if (colName == "")
                {
                    return null;
                }

                //返回指定字段的內容
                var model = GetOnlineUsersModel(userHashKey);
                if (model == null)
                    return null;

                return GetFieldValue(model, colName);
            }
            catch (Exception e)
            {
                //記錄出錯日誌
                CommonBll.WriteLog("", e);
            }

            return null;
        }
        #endregion

        #region 更新在線用戶信息
        /// <summary>
        /// 更新在線用戶信息
        /// </summary>
        /// <param name="userHashKey">用戶在線Hashtable Key</param>
        /// <param name="colName">要更新的字段名稱</param>
        /// <param name="value">將要賦的值</param>
        public void UpdateUserOnlineInfo(string userHashKey, string colName, object value)
        {
            try
            {
                SetModelValue(GetOnlineUsersModel(userHashKey), colName, value);
            }
            catch (Exception e)
            { //記錄出錯日誌
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        #region 更新在線用戶緩存表中最後在線時間
        /// <summary>
        /// 更新在線用戶緩存表中最後在線時間
        /// </summary>
        public void UpdateTime()
        {
            try
            {
                var id = GetOnlineUsersId();
                if (id > 0)
                {
                    UpdateValue(null, id, OnlineUsersTable.UpdateTime, DateTime.Now, "", true, false);
                }
                //更新數據庫與緩存中的最後在線時間

                //修改在線緩存表中的用戶最後在線時間
                //UpdateUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.UpdateTime, DateTime.Now);
            }
            catch (Exception e)
            {
                //記錄出錯日誌
                CommonBll.WriteLog("", e);
            }
        }
        #endregion

        #region 獲取在線人數
        /// <summary>
        /// 獲取在線人數
        /// </summary>
        /// <returns></returns>
        public int GetUserOnlineCount()
        {
            var onlineUsers = GetList();
            return onlineUsers == null ? 0 : onlineUsers.Count;
        }
        #endregion

        #region 檢查在線列表
        /// <summary>
        /// 檢查在線列表，將不在線人員刪除
        /// </summary>
        public void CheckOnline()
        {
            //獲取在線列表
            var onlineUsers = GetList();

            //如果不存在在線表則退出
            if (onlineUsers == null || onlineUsers.Count == 0)
                return;

            //循環讀取在線信息
            List<int> list = new List<int>();
            foreach (var model in onlineUsers.Where(model => Math.Abs(TimeHelper.DateDiff("n", model.UpdateTime, DateTime.Now)) > 10))
            {
                //添加用戶下線記錄
                LoginLogBll.GetInstence().Save(model.UserHashKey, "用戶【{0}】超時被踢出系統！在線時間【{1}】");
                //移除在線數據
                list.Add(model.Id);
            }
            if (list.Count > 0)
            {
                Delete(null, list.ToArray());
            }
        }
        #endregion

        #region 判斷用戶是否被強迫離線
        /// <summary>
        /// 判斷用戶是否被強迫離線[true是；false否]
        /// </summary>
        public bool IsOffline(Page page)
        {
            try
            {
                //獲取當前用戶Id
                var userinfoId = GetManagerId();

                //判斷當前用戶是否已經被系統清除
                if (userinfoId == 0)
                {
                    //通知用戶
                    FineUI.Alert.Show("您太久沒有操作已退出系統，請重新登錄！", "檢測通知", MessageBoxIcon.Information, "top.location.href='/Login.aspx';");
                    return true;
                }
                else
                {
                    //判斷在線用戶的Md5與當前用戶存儲的Md5是否一致
                    if (GenerateMd5() != CookieHelper.GetCookieValue(OnlineUsersTable.Md5))
                    {
                        //添加用戶下線記錄
                        LoginLogBll.GetInstence().Save(userinfoId, "用戶【{0}】的賬號已經在另一處登錄，本次登陸下線！在線時間【{1}】");

                        //清除在線表裡與當前用戶同名的記錄
                        //Delete(null, x => x.Id == GetOnlineUsersId());

                        //清空Session
                        SessionHelper.RemoveSession(OnlineUsersTable.UserHashKey);
                        SessionHelper.RemoveSession(OnlineUsersTable.Md5);
                        SessionHelper.RemoveSession(T_TABLE_DTable.PagePower);
                        SessionHelper.RemoveSession(T_TABLE_DTable.ControlPower);
                        SessionHelper.RemoveSession(OnlineUsersTable.Manager_Id);
                        SessionHelper.RemoveSession(OnlineUsersTable.Manager_LoginName);
                        SessionHelper.RemoveSession(OnlineUsersTable.Manager_CName);
                        //刪除Cookies
                        CookieHelper.ClearCookie(OnlineUsersTable.UserHashKey);
                        CookieHelper.ClearCookie(OnlineUsersTable.Md5);

                        CommonBll.WriteLog("當前賬號已經下線，用戶Id【" + userinfoId + "】");

                        //通知用戶
                        FineUI.Alert.ShowInTop("您的賬號已經在另一處登錄或已退出，當前賬號已經下線！", "檢測通知", MessageBoxIcon.Information, "top.location.href='/Login.aspx';");
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                CommonBll.WriteLog("Logic.Systems.Manager.CheckIsOffline出現異常", ex);

                FineUI.Alert.ShowInTop("系統已經開始更新維護，請稍後重新登錄！", "檢測通知", MessageBoxIcon.Information, "top.location.href='/Login.aspx';");
                return true;
            }

        }
        #endregion

        #region 判斷用戶是否超時退出

        /// <summary>
        /// 判斷用戶是否超時退出（退出情況：1.系統更新，2.用戶自動退出）
        /// </summary>
        public void IsTimeOut()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[OnlineUsersTable.UserHashKey] != null)
                return;
            try
            {
                //不存在則表示Session失效了，重新從Cookies中加載
                var userHashKey = CookieHelper.GetCookieValue(OnlineUsersTable.UserHashKey);
                var md5 = CookieHelper.GetCookieValue(OnlineUsersTable.Md5);

                //判斷Cookies是否存在，存在則查詢在線列表，重新獲取用戶信息
                if (userHashKey.Length > 0 && md5.Length == 32)
                {
                    //讀取當前用戶在線實體
                    var model = GetOnlineUsersModel(userHashKey);
                    //當前用戶存在在線列表中
                    if (model != null)
                    {
                        //計算用戶md5值
                        var key = GenerateMd5(model);

                        //判斷用戶的md5值是否正確
                        if (md5 == key)
                        {
                            //將UserHashKey存儲到緩存中
                            HttpContext.Current.Session[OnlineUsersTable.UserHashKey] = userHashKey;
                            //獲取用戶權限並存儲到用戶Session裡
                            T_TABLE_DBll.GetInstence().SetUserPower(model.Position_Id);
                            //更新用戶當前SessionId到在線表中
                            UpdateUserOnlineInfo(model.Id + "", OnlineUsersTable.SessionId, HttpContext.Current.Session.SessionID);
                            return;
                        }
                        //添加用戶下線記錄
                        LoginLogBll.GetInstence().Save(model.Id, "用戶【{0}】的賬號已經在另一處登錄，本次登陸超時下線！在線時間【{1}】");

                        //清除在線表裡與當前用戶同名的記錄
                        Delete(null, x => x.Id == model.Id);

                        //清空Session
                        SessionHelper.RemoveSession(OnlineUsersTable.UserHashKey);
                        SessionHelper.RemoveSession(OnlineUsersTable.Md5);
                        SessionHelper.RemoveSession(T_TABLE_DTable.PagePower);
                        SessionHelper.RemoveSession(T_TABLE_DTable.ControlPower);
                        SessionHelper.RemoveSession(OnlineUsersTable.Manager_Id);
                        SessionHelper.RemoveSession(OnlineUsersTable.Manager_LoginName);
                        SessionHelper.RemoveSession(OnlineUsersTable.Manager_CName);
                        //刪除Cookies
                        CookieHelper.ClearCookie(OnlineUsersTable.UserHashKey);
                        CookieHelper.ClearCookie(OnlineUsersTable.Md5);
                    }
                    //刪除數據庫記錄與IIS緩存
                    Delete(null, x => x.UserHashKey == userHashKey);
                    //清空Session
                    SessionHelper.RemoveSession(OnlineUsersTable.UserHashKey);
                    SessionHelper.RemoveSession(OnlineUsersTable.Md5);
                    SessionHelper.RemoveSession(T_TABLE_DTable.PagePower);
                    SessionHelper.RemoveSession(T_TABLE_DTable.ControlPower);
                    SessionHelper.RemoveSession(OnlineUsersTable.Manager_Id);
                    SessionHelper.RemoveSession(OnlineUsersTable.Manager_LoginName);
                    SessionHelper.RemoveSession(OnlineUsersTable.Manager_CName);
                    //刪除Cookies
                    CookieHelper.ClearCookie(OnlineUsersTable.UserHashKey);
                    CookieHelper.ClearCookie(OnlineUsersTable.Md5);
                }
            }
            catch (Exception e)
            {
                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog("檢測用戶超時出錯", e);
            }
            //用戶不存在，直接退出
            FineUI.Alert.ShowInTop("當前用戶登錄已經過時或系統已更新,請重新登錄！", "檢測通知", MessageBoxIcon.Information, "top.location='/Login.aspx';");
            //DotNet.Utilities.JsHelper.AlertAndParentUrl("當前用戶登錄已經過時或系統已更新,請重新登錄！", "Login.aspx");
            //HttpContext.Current.Response.Redirect("/Login.aspx");
            //HttpContext.Current.Response.End();
        }
        #endregion

        #region 管理員退出系統
        /// <summary>
        /// 用戶點擊退出系統時，調用本函數，本函數將在在線用戶表中刪除當前用戶，並添加用戶退出日誌
        /// </summary>
        public void UserExit(Page page)
        {
            try
            {
                //獲取用戶Hashtable Key
                var userHashKey = GetUserHashKey();
                //判斷用戶的Session["UserHashKey"]是否存在，即用戶是否TimeOut退出了
                if (userHashKey != null)
                {
                    //添加用戶退出日誌
                    LoginLogBll.GetInstence().Save(userHashKey + "", "用戶【{0}】退出系統！在線時間【{1}】");

                    //刪除數據庫記錄與IIS緩存
                    Delete(page, x => x.UserHashKey == userHashKey);
                    //清空Session
                    SessionHelper.RemoveSession(OnlineUsersTable.UserHashKey);
                    SessionHelper.RemoveSession(OnlineUsersTable.Md5);
                    SessionHelper.RemoveSession(T_TABLE_DTable.PagePower);
                    SessionHelper.RemoveSession(T_TABLE_DTable.ControlPower);
                    //刪除Cookies
                    CookieHelper.ClearCookie(OnlineUsersTable.UserHashKey);
                    CookieHelper.ClearCookie(OnlineUsersTable.Md5);
                }
            }
            catch (Exception e)
            {
                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog("", e);
            }
        }

        /// <summary>
        /// 將指定用戶踢下線，並添加用戶退出日誌
        /// </summary>
        public void UserExit(Page page, string userHashKey)
        {
            var model = GetOnlineUsersModel(userHashKey);
            if (model != null)
            {
                //添加用戶退出日誌
                LoginLogBll.GetInstence().Save(userHashKey, "用戶【" + model.Manager_CName + "】給管理員【" + GetManagerCName() + "】踢出系統！在線時間【{1}】");

                //刪除數據庫記錄與IIS緩存
                Delete(page, model.Id);
            }
        }

        #endregion

        #region 生成加密串——用戶加密密鑰計算
        /// <summary>
        /// 生成加密串——用戶加密密鑰計算
        /// </summary>
        /// <param name="model">在線實體</param>
        /// <returns></returns>
        public string GenerateMd5(DataAccess.Model.OnlineUsers model)
        {
            if (model == null)
            {
                return RandomHelper.GetRndKey();
            }
            else
            {
                //Md5(密鑰+登陸帳號+密碼+IP+密鑰.Substring(6,8))
                //return Encrypt.Md5(model.UserKey + model.Manager_LoginName + model.Manager_LoginPass +
                //            IpHelper.GetUserIp() + model.UserKey.Substring(6, 8));
                return Encrypt.Md5(model.UserKey + model.Manager_LoginName + model.Manager_LoginPass + model.UserKey.Substring(6, 8));
            }
        }

        /// <summary>
        /// 生成加密串——用戶加密密鑰計算
        /// </summary>
        /// <param name="model">在線實體</param>
        /// <returns></returns>
        public string GenerateMd5(OnlineUsers model)
        {
            if (model == null)
            {
                return RandomHelper.GetRndKey();
            }
            else
            {
                return Encrypt.Md5(model.UserKey + model.Manager_LoginName + model.Manager_LoginPass + model.UserKey.Substring(6, 8));
            }
        }

        /// <summary>
        /// 生成加密串——用戶加密密鑰計算，直接讀取當前用戶實體
        /// </summary>
        /// <returns></returns>
        public string GenerateMd5()
        {
            //讀取當前用戶實體
            var model = GetOnlineUsersModel();
            return GenerateMd5(model);
        }
        #endregion

        #region 獲取當前在線用戶Id
        /// <summary>
        /// 獲取當前在線用戶Id
        /// </summary>
        /// <returns></returns>
        public int GetOnlineUsersId()
        {
            var id = SessionHelper.GetSession("OnlineUsersId");
            if (id == null)
            {
                id = GetUserOnlineInfo(GetUserHashKey(), "Id") + "";

                SessionHelper.SetSession("OnlineUsersId", id);
            }

            return ConvertHelper.Cint0(id);
        }
        #endregion

        #region 獲取當前在線用戶員工編號
        public string GetManagerEmpId()
        {
            var name = SessionHelper.GetSessionString(OnlineUsersTable.Manager_LoginName);
            if (string.IsNullOrEmpty(name))
            {
                name = GetUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.Manager_LoginName) + "";

                SessionHelper.SetSession(OnlineUsersTable.Manager_LoginName, name);
            }

            return name;
        }
        #endregion

        #region 獲取當前管理員Id
        /// <summary>
        /// 從緩存中讀取當前管理員Id
        /// </summary>
        /// <returns></returns>
        public int GetManagerId()
        {
            var id = SessionHelper.GetSession(OnlineUsersTable.Manager_Id);
            if (id == null)
            {
                id = GetUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.Manager_Id) + "";

                SessionHelper.SetSession(OnlineUsersTable.Manager_Id, id);
            }

            return ConvertHelper.Cint0(id);
        }
        #endregion

        #region 獲取用戶中文名稱
        /// <summary>
        /// 從Session中讀取用戶中文名稱,如果Session為Null時,返回""
        /// </summary>
        /// <returns></returns>
        public string GetManagerCName()
        {
            var name = SessionHelper.GetSessionString(OnlineUsersTable.Manager_CName);
            if (string.IsNullOrEmpty(name))
            {
                name = GetUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.Manager_CName) + "";

                SessionHelper.SetSession(OnlineUsersTable.Manager_CName, name);
            }

            return name;
        }

        /// <summary>
        /// 從Session中讀取用戶中文名稱,如果Session為Null時,返回""
        /// </summary>
        /// <returns></returns>
        public string GetManagerCName(int userId)
        {
            if (userId == 0)
            {
                return "";
            }

            var model = GetModelForCache(x => x.Manager_Id == userId);
            if (model == null)
            {
                return "";
            }
            else
            {
                return model.Manager_CName;
            }
        }
        #endregion

        #region 獲取用戶UserHashKey
        /// <summary>
        /// 獲取用戶UserHashKey
        /// </summary>
        /// <returns></returns>
        public string GetUserHashKey()
        {
            //讀取Session中存儲的UserHashKey值
            var userHashKey = SessionHelper.GetSession(OnlineUsersTable.UserHashKey);
            //如果為null
            if (userHashKey == null)
            {
                //為null則表示用戶Session過期了，所以要檢查用戶登陸，避免用戶權限問題
                IsTimeOut();
            }
            return SessionHelper.GetSessionString(OnlineUsersTable.UserHashKey);
        }
        #endregion

        #region 獲取用戶加密串——用戶加密密鑰Md5值
        /// <summary>
        /// 獲取用戶加密串——用戶加密密鑰Md5值
        /// </summary>
        /// <returns></returns>
        public string GetMd5()
        {
            //讀取Session中存儲的Md5值
            var md5 = SessionHelper.GetSessionString(OnlineUsersTable.Md5);
            //如果為null
            if (string.IsNullOrEmpty(md5))
            {
                //由於GenerateMd5()獲取在線實體時，會執行IsTimeOut()函數，所以這裡註釋掉
                //為null則表示用戶Session過期了，所以要檢查用戶登陸，避免用戶權限問題
                //IsTimeOut();
                md5 = GenerateMd5();

                SessionHelper.SetSession(OnlineUsersTable.Md5, md5);
            }

            return md5;
        }

        /// <summary>
        /// 獲取用戶加密串——用戶加密密鑰Md5值
        /// </summary>
        /// <returns></returns>
        public string GetMd5(int userId)
        {
            if (userId == 0)
            {
                return "";
            }

            var model = GetModelForCache(x => x.Manager_Id == userId);
            if (model == null)
            {
                return "";
            }
            else
            {
                return model.Md5;
            }
        }
        #endregion

        #region 獲取用戶頁面操作權限
        /// <summary>
        /// 獲取用戶頁面操作權限
        /// </summary>
        /// <returns></returns>
        public string GetPagePower()
        {
            //讀取Session中存儲的PagePower值
            var pagePower = SessionHelper.GetSession("PagePower");
            //如果為null
            if (pagePower == null)
            {
                //獲取用戶權限並存儲到用戶Session裡
                T_TABLE_DBll.GetInstence().SetUserPower(GetUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.Position_Id) + "");
            }
            pagePower = SessionHelper.GetSession("PagePower");
            return pagePower + "";
        }
        #endregion

        #region 獲取用戶頁面控件（按鍵）操作權限
        /// <summary>
        /// 獲取用戶頁面控件（按鍵）操作權限
        /// </summary>
        /// <returns></returns>
        public string GetControlPower()
        {
            //讀取Session中存儲的ControlPower值
            var controlPower = SessionHelper.GetSession(T_TABLE_DTable.ControlPower);
            //如果為null
            if (controlPower == null)
            {
                //獲取用戶權限並存儲到用戶Session裡
                T_TABLE_DBll.GetInstence().SetUserPower(GetUserOnlineInfo(GetUserHashKey(), OnlineUsersTable.Position_Id) + "");
            }
            controlPower = SessionHelper.GetSession(T_TABLE_DTable.ControlPower);
            return controlPower + "";
        }
        #endregion
        #region 重寫刪除函數

        /// <summary>
        /// 刪除OnlineUsers表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
        public void Delete(Page page, Expression<Func<OnlineUsers, bool>> expression)
        {
            if (OnlineUsers.Exists(expression))
            {
                //添加用戶操作記錄
                UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表記錄！");
            }
            //執行刪除
            OnlineUsers.Delete(expression);

            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //?空當?表所有緩存記錄
                DelAllCache();
                //重新載?緩存
                GetList();
            }

        }
        #endregion
        #endregion 自定義函數
    }
}
