using Newtonsoft.Json;
using Solution.DataAccess.DbHelper;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SubSonic.Query;

namespace Solution.Web.Managers.WebServices
{
    /// <summary>
    /// ApplyWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ApplyWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "读取用戶的UserHashKey值", EnableSession = true)]
        public string GetUserHashKey()
        {
            return OnlineUsersBll.GetInstence().GetUserHashKey();
        }

        [WebMethod(Description = "读取申请记录", EnableSession = true)]
        public string GetList(string type, bool norepeat = false, int top = 0, string columns = null, int pageIndex = 0, int pageSize = 0, string wheres = null, string sorts = null)
        {
            List<string> tsort = null;
            List<string> tcolumns = null;
            List<ConditionHelper.SqlqueryCondition> twhere = null;
            string ret = "";
            //检测用户是否超时退出
            OnlineUsersBll.GetInstence().IsTimeOut();
            //检测用户登录的有效性（是否被系统踢下线或管理员踢下线）
            if (OnlineUsersBll.GetInstence().IsOffline(null))
                return ret;
            if (string.IsNullOrEmpty(wheres))
            {
                twhere = JsonConvert.DeserializeObject<List<ConditionHelper.SqlqueryCondition>>(wheres);
            }
            if (string.IsNullOrEmpty(sorts))
            {
                tsort = JsonConvert.DeserializeObject<List<string>>(sorts);
            }
            if (string.IsNullOrEmpty(columns))
            {
                tcolumns = JsonConvert.DeserializeObject<List<string>>(columns);
            }
            switch (type)
            {
                case "leav":
                case "tral":
                    twhere.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.outwork_type, Comparison.Equals, type));
                    ret = JsonConvert.SerializeObject(OutWork_DBll.GetInstence().GetDataTable(norepeat, top, tcolumns, pageIndex, pageSize, twhere, tsort));
                    break;
                case "adju":
                    ret = JsonConvert.SerializeObject(adJustRest_DBll.GetInstence().GetDataTable(norepeat, top, tcolumns, pageIndex, pageSize, twhere, tsort));
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
