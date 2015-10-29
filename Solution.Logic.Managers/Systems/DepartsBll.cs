using System;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using System.Collections.Generic;
using SubSonic.Query;

namespace Solution.Logic.Managers
{
    /// <summary>
    /// Employee（用户表逻辑类）逻辑类
    /// </summary>
    public partial class DepartsBll : LogicBase
    {
        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数
        #region 获取部门名称
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="p">部门ID</param>
        /// <returns></returns>
        public string GetDeptName(object id)
        {
            if (id == null)
            {
                return "";
            }
            var name = GetFieldValue(DepartsTable.depart_name, DepartsTable.depart_id, id, true);
            return name == null ? id.ToString() : name.ToString();
        }
        #endregion

        #endregion 自定义函数

    }
}
