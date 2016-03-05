using System;
using System.Linq;
using System.Web;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-17
 *   文件名稱：Login.aspx.cs
 *   描    述：後端登陸頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers
{
    public partial class Login : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定用戶
                EmployeeBll.GetInstence().BandDropDownList(this, ddlUser, EmployeeTable.EMP_FNAME, "ASC");
                //生成驗證碼
                //imgCaptcha.ImageUrl = "WebManage/Application/Vcode.ashx?t=" + DateTime.Now.Ticks;

                //判斷是否登陸
                if (Session[OnlineUsersTable.UserHashKey] != null && !string.IsNullOrEmpty(Session[OnlineUsersTable.UserHashKey].ToString()))
                {
                    //跳轉進入主頁面    
                    Response.Redirect(CommonBll.IsPC(this) ? "Main.aspx" : "PhoneMain.aspx");
                }

            }
        }
        #endregion

        #region 登錄
        /// <summary>登錄</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            var ip = IpHelper.GetUserIp();

            #region 獲取用戶輸入的參數，並進行數據初步處理
            //獲取用戶名，並進行危險字符過濾
            var username = StringHelper.Left(ddlUser.SelectedItem == null ? ddlUser.Text : ddlUser.SelectedValue, 50);
            //獲取用戶密碼
            var userpass = txtPassword.Text;
            //獲取驗證碼
            //var strCode = StringHelper.Left(txtCaptcha.Text, 5);
            #endregion

            #region 初步驗證
            //開發測試使用，不用每次都輸入帳號與密碼
            //username = "0000000";
            //userpass = "0";
            //strCode = "12345";

            //用戶名驗證
            if (string.IsNullOrEmpty(username.Trim()))
            {
                ddlUser.Focus();
                FineUI.Alert.ShowInTop("用戶名不能為空,請仔細檢查您輸入的用戶名！", FineUI.MessageBoxIcon.Error);
                return;
            }
            //密碼驗證
            if (string.IsNullOrEmpty(userpass.Trim()))
            {
                txtPassword.Focus();
                FineUI.Alert.ShowInTop("密碼不能為空,請仔細檢查您輸入的密碼！", FineUI.MessageBoxIcon.Error);
                return;
            }

            //驗證碼驗證
            //if (string.IsNullOrEmpty(strCode))
            //{
            //    txtCaptcha.Focus();
            //    FineUI.Alert.ShowInParent("驗證碼不能為空！", FineUI.MessageBoxIcon.Error);
            //    return;
            //}
            //判斷驗證碼是否正確
            //if (Session["vcode"] == null || !Session["vcode"].ToString().Equals(strCode, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    SessionHelper.RemoveSession("vcode");
            //    txtpass.Focus();
            //    //JsHelper.Alert("驗證碼錯誤！");
            //    FineUI.Alert.ShowInParent("驗證碼錯誤！", FineUI.MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    //驗證碼正確，刪除驗證碼Session
            //    SessionHelper.RemoveSession("vcode");
            //}
            #endregion

            #region 數據庫驗證

            //通過用戶給的用戶名獲取相關實體類
            var userinfo = Employee.SingleOrDefault(x => (x.EMP_ID == username) || (x.EMP_FNAME == username));

            //判斷用戶是否存在
            if (userinfo == null)
            {
                LoginLogBll.GetInstence().Save(0, "賬號【" + username + "】不存在，登錄失敗！");
                ddlUser.Focus();
                FineUI.Alert.ShowInParent("用戶名不存在，請仔細檢查您輸入的用戶名！", FineUI.MessageBoxIcon.Error);
                return;
            }
            username = userinfo.EMP_ID;
            //密碼不匹配
            if (!EmployeeBll.GetInstence().CheckPassWord(username, userpass))
            {
                LoginLogBll.GetInstence().Save(userinfo.Id, "賬號【" + userinfo.EMP_ID + "】的用戶【" + userinfo.EMP_FNAME + "】登錄失敗！登錄密碼錯誤。");
                txtPassword.Focus();
                FineUI.Alert.ShowInParent("您輸入的用戶密碼錯誤！", FineUI.MessageBoxIcon.Error);
                return;
            }

            if (userinfo.KIND == 0)
            {
                //添加用戶登陸日誌
                LoginLogBll.GetInstence().Save(userinfo.Id, "離職用戶登錄失敗！用戶【" + userinfo.EMP_FNAME + "】試圖登錄系統");
                FineUI.Alert.ShowInParent("您已經沒有權限登錄本系統！", FineUI.MessageBoxIcon.Error);
                return;
            }

            //判斷當前賬號是否被啟用
            //if (userinfo.IsEnable == 0)
            //{
            //    //添加登錄日誌記錄
            //    LoginLogBll.GetInstence().Save(userinfo.Id, "賬號【" + userinfo.LoginName + "】的用戶【" + userinfo.CName + "】登錄失敗！用戶賬號被禁用。");

            //    FineUI.Alert.ShowInParent("當前賬號未被啟用，請聯繫管理人員激活！", FineUI.MessageBoxIcon.Error);
            //    return;
            //}

            #endregion

            #region 初始化用戶Session變量
            //初始化Session
            SessionHelper.RemoveSession(T_TABLE_DTable.PagePower);
            SessionHelper.RemoveSession(T_TABLE_DTable.ControlPower);
            SessionHelper.RemoveSession(OnlineUsersTable.UserHashKey);
            SessionHelper.RemoveSession(OnlineUsersTable.Md5);
            SessionHelper.RemoveSession(OnlineUsersTable.Manager_Id);
            SessionHelper.RemoveSession(OnlineUsersTable.Manager_LoginName);
            SessionHelper.RemoveSession(OnlineUsersTable.Manager_CName);
            //刪除Cookies
            CookieHelper.ClearCookie(OnlineUsersTable.UserHashKey);
            CookieHelper.ClearCookie(OnlineUsersTable.Md5);
            #endregion

            #region 存儲在線用戶資料

            #region 獲取用戶操作權限

            if (string.IsNullOrEmpty(userinfo.GROUPS))
            {
                Session["PagePower"] = "";
                Session["ControlPower"] = "";

                LoginLogBll.GetInstence().Save(0, "賬號【" + username + "】未綁定權限組，請管理員進行配置！");
                FineUI.Alert.ShowInParent("您的賬號未綁定職位，請與管理員聯繫！", FineUI.MessageBoxIcon.Error);
                return;
            }
            //獲取用戶權限並存儲到用戶Session裡
            T_TABLE_DBll.GetInstence().SetUserPower(userinfo.GROUPS);
            //HttpContext.Current.Session["PagePower"] = ",28,29,30,31,32,36,37,38,39,40,41,42,43,24,25,26,27,1,2,5,19,20,21,22,23,3,6,7,8,9,10,11,12,13,14,33,34,35,4,15,16,17,18,";
            //HttpContext.Current.Session["ControlPower"] = ",29|1,29|2,29|3,29|5,29|6,30|4,30|10,31|1,31|2,31|3,31|5,31|6,32|4,32|10,37|1,37|2,37|3,37|5,37|6,38|4,39|1,39|2,39|3,39|5,39|6,40|4,42|1,42|2,42|3,42|4,43|1,43|2,43|4,43|3,25|1,25|2,25|11,26|4,27|2,27|3,27|12,5|4,19|1,19|2,19|3,20|4,21|1,21|2,21|3,22|4,23|9,23|3,6|1,6|2,6|3,6|5,6|6,7|4,8|1,8|2,8|3,9|4,11|1,11|2,11|3,11|5,11|6,12|4,13|1,13|2,13|3,14|4,15|8,";

            #endregion

            #region 當前用戶在線信息


            //當前時間
            var localTime = DateTime.Now.ToLocalTime();
            //創建客戶端信息獲取實體
            var clientHelper = new ClientHelper(Request);

            //創建在線用戶實體
            var onlineUser = new OnlineUsers();
            //當前用戶的Id編號
            onlineUser.Manager_Id = userinfo.Id;
            onlineUser.Manager_LoginName = userinfo.EMP_ID;
            //onlineUser.Manager_LoginPass = userinfo.PASSWORD.ToString();
            onlineUser.Manager_CName = userinfo.EMP_FNAME;
            onlineUser.LoginTime = localTime;
            onlineUser.LoginIp = ip;
            //生成密鑰
            onlineUser.UserKey = RandomHelper.GetRndNum(32, true);
            //Md5(密鑰+登陸帳號+密碼+IP+密鑰.Substring(6,8))
            onlineUser.Md5 = OnlineUsersBll.GetInstence().GenerateMd5(onlineUser);
            HttpContext.Current.Session[OnlineUsersTable.Md5] = onlineUser.Md5;
            onlineUser.UpdateTime = localTime;
            onlineUser.Sex = userinfo.SEX;
            //onlineUser.Branch_Id = userinfo.DEPART_ID;
            onlineUser.Branch_Code = userinfo.DEPART_ID;
            onlineUser.Branch_Name = DepartsBll.GetInstence().GetFieldValue(DepartsTable.depart_name, DepartsTable.depart_id, userinfo.DEPART_ID).ToString();
            onlineUser.Position_Id = userinfo.GROUPS.Trim();
            var pname = T_TABLE_DBll.GetInstence().GetFieldValue(T_TABLE_DTable.DESCR, x => x.CODE == onlineUser.Position_Id && x.TABLES == "AUTH").ToString();
            onlineUser.Position_Name = pname.Trim();
            onlineUser.CurrentPage = "";
            onlineUser.CurrentPageTitle = "";
            //SessionId
            onlineUser.SessionId = Session.SessionID;
            onlineUser.UserAgent = StringHelper.FilterSql(HttpContext.Current.Request.Headers["User-Agent"] + "");
            onlineUser.OperatingSystem = clientHelper.GetSystem();
            onlineUser.TerminalType = clientHelper.IsMobileDevice(onlineUser.UserAgent) ? 1 : 0;
            onlineUser.BrowserName = clientHelper.GetBrowserName();
            onlineUser.BrowserVersion = clientHelper.GetBrowserVersion();

            #endregion

            #region 記錄當前用戶UserId
            //定義HashTable表裡Key的名稱UserId
            string userHashKey;
            //判斷當前用戶帳戶是否支持同一帳號在不同地方登陸功能，取得用戶在HashTable表裡Key的名稱
            //不支持則
            if (userinfo.IS_SHEBAO == null || userinfo.IS_SHEBAO == false)
            {
                userHashKey = userinfo.Id + "";
            }
            //支持則
            else
            {
                userHashKey = userinfo.Id + "_" + onlineUser.SessionId;
            }
            //記錄用戶的HashTable Key
            onlineUser.UserHashKey = userHashKey;
            Session[OnlineUsersTable.UserHashKey] = userHashKey;
            #endregion

            #region 將在線用戶信息存入全局變量中
            //運行在線數據加載函數，如果緩存不存在，則嘗試加載數據庫中的在線表記錄到緩存中
            //——主要用於IIS緩存被應用程序池或其他原因回收後，對在線數據進行重新加載，而不會使所有用戶都被迫退出系統
            var onlineUsersList = OnlineUsersBll.GetInstence().GetList();

            //判斷緩存中["OnlineUsers"]是否存在，不存在則直接將在線實體添加到緩存中
            if (onlineUsersList.SingleOrDefault(x => x.UserHashKey == userHashKey) != null)
            {
                //清除在線表裡與當前用戶同名的記錄
                OnlineUsersBll.GetInstence().Delete(this, x => x.UserHashKey == userHashKey);

                //將在線實體保存到數據庫的在線表中
                OnlineUsersBll.GetInstence().Save(this, onlineUser, null, true, false);
            }
            //存在則將它取出HashTable並進行處理
            else
            {
                //將HashTable裡存儲的前一登陸帳戶移除
                //獲取在線緩存實體
                var onlineModel = OnlineUsersBll.GetInstence().GetOnlineUsersModel(userHashKey);
                if (onlineModel != null)
                {
                    //添加用戶下線記錄
                    LoginLogBll.GetInstence().Save(userHashKey, "用戶【{0}】的賬號已經在另一處登錄，本次登陸下線！在線時間【{1}】");

                    //清除在線表裡與當前用戶同SessionId的記錄
                    OnlineUsersBll.GetInstence().Delete(this, x => x.SessionId == onlineUser.SessionId);
                }

                //將在線實體保存到數據庫的在線表中
                OnlineUsersBll.GetInstence().Save(this, onlineUser, null, true, false);
            }

            

            #endregion

            #endregion

            #region 更新用戶登陸信息

            userinfo.DEF0 = ip;
            userinfo.DOOR_ID = ++userinfo.DOOR_ID;
            userinfo.SHEBAO_DATE = localTime;

            EmployeeBll.GetInstence().Save(this, userinfo, string.Format("用戶【{0}】登陸成功，更新登陸信息", userinfo.EMP_FNAME));

            #endregion

            #region 添加用戶登錄成功日誌
            LoginLogBll.GetInstence().Save(userHashKey, string.Format("賬號【{0}】的用戶【{1}】登錄成功", userinfo.EMP_ID, userinfo.EMP_FNAME));
            #endregion

            #region 寫Cookies
            //寫入用戶的HashTable Key
            CookieHelper.SetCookie(OnlineUsersTable.UserHashKey, userHashKey);
            //寫入加密值
            CookieHelper.SetCookie(OnlineUsersTable.Md5, onlineUser.Md5);
            #endregion

            //跳轉進入主頁面    
            Response.Redirect(CommonBll.IsPC(this) ? "Main.aspx" : "PhoneMain.aspx");
        }
        #endregion

        #region 刷新驗證碼
        /// <summary>刷新驗證碼</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            //重新生成驗證碼
            //imgCaptcha.ImageUrl = "WebManage/Application/Vcode.ashx?t=" + DateTime.Now.Ticks;
        }
        #endregion

        protected void txtUser_TextChanged(object sender, EventArgs e)
        {
            var str = txtUser.Text;
            if (str == null) return;
            var model = EmployeeBll.GetInstence().GetModelForCache(x => x.EMP_ID.IndexOf(str, StringComparison.Ordinal) >= 0 || x.EMP_FNAME.IndexOf(str, StringComparison.Ordinal) >= 0);
            if (model == null) return;
            txtUser.Text = model.EMP_ID;
        }
    }
}