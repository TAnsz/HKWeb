using DotNet.Utilities;
using Newtonsoft.Json;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Solution.Web.Managers.WebServices
{
    /// <summary>
    /// LoginWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class LoginWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 獲取SessionId
        /// </summary>
        /// <returns>string SessionId</returns>
        [WebMethod(Description = "獲取SessionId", EnableSession = true)]
        public string GetSessionId()
        {
            return Session.SessionID;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用戶名</param>
        /// <param name="pw">密碼</param>
        /// <returns></returns>
        [WebMethod(Description = "用戶登錄", EnableSession = true)]
        
        public string Login(string user, string pw)
        {
            if (string.IsNullOrEmpty(user))
            {
                return "用户名不能为空";
            }
            if (string.IsNullOrEmpty(pw))
            {
                return "密码不能为空";
            }
            //通过用户给的用户名获取相关实体类
            var userinfo = Employee.SingleOrDefault(x => (x.EMP_ID == user) || (x.EMP_FNAME == user));

            //判断用户是否存在
            if (userinfo == null)
            {
                LoginLogBll.GetInstence().Save(0, "账号【" + user + "】不存在，登录失败！");
                return "用户名不存在，请仔细检查您输入的用户名！";
            }

            //密码不匹配
            if (!EmployeeBll.GetInstence().CheckPassWord(user, pw))
            {
                LoginLogBll.GetInstence().Save(userinfo.Id, "账号【" + userinfo.EMP_ID + "】的用户【" + userinfo.EMP_FNAME + "】登录失败！登录密码错误。");
                return "您输入的用户密码错误！";
            }

            if (userinfo.KIND == 0)
            {
                //添加用户登陆日志
                LoginLogBll.GetInstence().Save(userinfo.Id, "离职用户登录失败！用户【" + userinfo.EMP_FNAME + "】试图登录系统");
                return "您已经没有权限登录本系统！";
            }
            #region 当前用户在线信息
            //当前时间
            var localTime = DateTime.Now.ToLocalTime();

            //创建在线用户实体
            var onlineUser = new OnlineUsers();
            //当前用户的Id编号
            onlineUser.Manager_Id = userinfo.Id;
            onlineUser.Manager_LoginName = userinfo.EMP_ID;
            //onlineUser.Manager_LoginPass = userinfo.PASSWORD.ToString();
            onlineUser.Manager_CName = userinfo.EMP_FNAME;
            onlineUser.LoginTime = localTime;
            onlineUser.LoginIp = "WebService";
            //生成密钥
            onlineUser.UserKey = RandomHelper.GetRndNum(32, true);
            //Md5(密钥+登陆帐号+密码+IP+密钥.Substring(6,8))
            onlineUser.Md5 = OnlineUsersBll.GetInstence().GenerateMd5(onlineUser);
            onlineUser.UpdateTime = localTime;
            onlineUser.Sex = userinfo.SEX;
            //onlineUser.Branch_Id = userinfo.DEPART_ID;
            onlineUser.Branch_Code = userinfo.DEPART_ID;
            onlineUser.Branch_Name = DepartsBll.GetInstence().GetFieldValue(DepartsTable.depart_name, DepartsTable.depart_id, userinfo.DEPART_ID, true).ToString();
            onlineUser.Position_Id = userinfo.GROUPS.Trim();
            var pname = T_TABLE_DBll.GetInstence().GetFieldValue(T_TABLE_DTable.DESCR, x => x.CODE == onlineUser.Position_Id && x.TABLES == "AUTH").ToString();
            onlineUser.Position_Name = pname.Trim();
            onlineUser.CurrentPage = "";
            onlineUser.CurrentPageTitle = "";
            //SessionId
            onlineUser.SessionId = Session.SessionID;
            onlineUser.OperatingSystem = "WebService";

            #endregion

            #region 记录当前用户UserId
            //定义HashTable表里Key的名称UserId
            string userHashKey = "";
            //判断当前用户帐户是否支持同一帐号在不同地方登陆功能，取得用户在HashTable表里Key的名称
            //不支持则
            if (userinfo.IS_SHEBAO == true)
            {
                userHashKey = userinfo.Id + "";
            }
            //支持则
            else
            {
                userHashKey = userinfo.Id + "_" + onlineUser.SessionId;
            }
            //记录用户的HashTable Key
            onlineUser.UserHashKey = userHashKey;
            Session[OnlineUsersTable.UserHashKey] = userHashKey;
            #endregion

            #region 将在线用户信息存入全局变量中
            //运行在线数据加载函数，如果缓存不存在，则尝试加载数据库中的在线表记录到缓存中
            //——主要用于IIS缓存被应用程序池或其他原因回收后，对在线数据进行重新加载，而不会使所有用户都被迫退出系统
            var onlineUsersList = OnlineUsersBll.GetInstence().GetList();

            //判断缓存中["OnlineUsers"]是否存在，不存在则直接将在线实体添加到缓存中
            if (onlineUsersList == null || onlineUsersList.Count == 0)
            {
                //清除在线表里与当前用户同名的记录
                OnlineUsersBll.GetInstence().Delete(null, x => x.Manager_LoginName == onlineUser.Manager_LoginName);

                //将在线实体保存到数据库的在线表中
                OnlineUsersBll.GetInstence().Save(null, onlineUser, null, true, false);
            }
            //存在则将它取出HashTable并进行处理
            else
            {
                //将HashTable里存储的前一登陆帐户移除
                //获取在线缓存实体
                var onlineModel = OnlineUsersBll.GetInstence().GetOnlineUsersModel(userHashKey);
                if (onlineModel != null)
                {
                    //添加用户下线记录
                    LoginLogBll.GetInstence().Save(userHashKey, "用户【{0}】的账号已经在另一处登录，本次登陆下线！在线时间【{1}】");

                    //清除在线表里与当前用户同名的记录
                    OnlineUsersBll.GetInstence().Delete(null, x => x.Manager_Id == onlineUser.Manager_Id);
                }

                //将在线实体保存到数据库的在线表中
                OnlineUsersBll.GetInstence().Save(null, onlineUser, null, true, false);
            }

            //检查在线列表数据，将不在线人员删除
            OnlineUsersBll.GetInstence().CheckOnline();

            #endregion


            #region 更新用户登陆信息

            userinfo.DEF0 = "WebService";
            userinfo.DOOR_ID = ++userinfo.DOOR_ID;
            userinfo.SHEBAO_DATE = localTime;

            EmployeeBll.GetInstence().Save(null, userinfo, string.Format("用户【{0}】登陆成功，更新登陆信息", userinfo.EMP_FNAME));

            #endregion

            #region 添加用户登录成功日志
            LoginLogBll.GetInstence().Save(userHashKey, string.Format("账号【{0}】的用户【{1}】登录成功", userinfo.EMP_ID, userinfo.EMP_FNAME));
            #endregion

            #region 写Cookies
            //写入用户的HashTable Key
            CookieHelper.SetCookie(OnlineUsersTable.UserHashKey, userHashKey);
            //写入加密值
            CookieHelper.SetCookie(OnlineUsersTable.Md5, onlineUser.Md5);
            #endregion
            //var json = ConvertJson.ToJson(OnlineUsersBll.GetInstence().Transform(onlineUser));

            var json = JsonConvert.SerializeObject(OnlineUsersBll.GetInstence().Transform(onlineUser));
            return json;
        }
    }
}
