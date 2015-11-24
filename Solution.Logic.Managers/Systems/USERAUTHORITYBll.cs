using System;
using System.Linq;
using System.Web;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-17
 *   文件名称：USERAUTHORITYBll.cs
 *   描    述：职位（角色）管理逻辑类
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// USERAUTHORITY表逻辑类
    /// </summary>
    public partial class USERAUTHORITYBll : LogicBase
    {
        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数

        #region 獲取有權限查看人員的權限

        public string[] GetUserWheres(string colname, string empid)
        {
            var drs = SPs.pro_USERAUTHORITY_REPORT(empid).ExecuteDataTable().Select("SType='0'");
            return drs.Length > 0 ? drs.Select(x => x["Id"].ToString()).ToArray() : null;
        }
        #endregion


        #endregion 自定义函数

    }
}
