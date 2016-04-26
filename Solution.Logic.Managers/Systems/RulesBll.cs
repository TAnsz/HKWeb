using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;

/***********************************************************************
 *   作    者：AllEmpty（陈焕）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 术 群：327360708
 *  
 *   创建日期：2014-06-26
 *   文件名称：UploadTypeBll.cs
 *   描    述：上传类型逻辑类
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// UploadTypeBll逻辑类
    /// </summary>
    public partial class RulesBll : LogicBase
    {
        /***********************************************************************
		 * 自定义函数                                                          *
		 ***********************************************************************/

        #region 自定义函数

        #region 绑定下拉列表
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        public void BandDropDownList(Page page, FineUI.DropDownList ddl)
        {
            //显示值
            ddl.DataTextField = RulesTable.rule_name;
            //显示key
            ddl.DataValueField = RulesTable.rule_id;

            //绑定数据源
            ddl.DataSource = GetDataTable();
            ddl.DataBind();
        }

        #endregion

        #endregion 自定义函数
    }
}
