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
    public partial class EmployeeBll : LogicBase
    {
        /***********************************************************************
         * 自定义函数                                                          *
         ***********************************************************************/
        #region 自定义函数

        #region 判斷密碼是否正確

        public bool CheckPassWord(string empid, string pw)
        {
            string sql = string.Format("SELECT EMP_ID FROM Employee WHERE EMP_ID = '{0}' AND PWDCOMPARE('{1}', PASSWORD) = 1", empid, pw);
            var ret = new SelectHelper().ExecuteScalar(sql);
            return (ret!=null);
        }
        #endregion


        /// <summary>
        /// 获取人员姓名
        /// </summary>
        /// <param name="id">员工编号</param>
        /// <returns></returns>
        public string GetEmpName(object id)
        {
            if (id==null)
            {
                return "";
            }
            var name = GetFieldValue(EmployeeTable.EMP_FNAME, EmployeeTable.EMP_ID, id, true);
            return name == null ? id.ToString() : name.ToString();
        }
        #endregion 自定义函数

    }
}
