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

        #region 獲取排序字段Sort的最大值
		/// <summary>
		/// 獲取排序字段Sort的最大值
		/// </summary>
		/// <param name="parentId">父Id值</param>
		public int GetSortMax(string parentId) 
		{
			//定義查詢條件
			var wheres = new List<ConditionHelper.SqlqueryCondition>();
			wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, DepartsTable.Up_ID, Comparison.Equals, parentId));
			//查詢
			var select = new SelectHelper();
            return ConvertHelper.Cint0(select.GetMax<Departs>(DepartsTable.inside_id, wheres));
		}
		#endregion

        /// <summary>
        /// 獲取部門列表
        /// </summary>
        public void BandDropDownList(Page page, FineUI.DropDownList ddl,bool isTree=false)
        {

            var dt = DataTableHelper.GetFilterData(GetDataTable(), DepartsTable.Up_ID, null, DepartsTable.inside_id, "ASC");


            //显示值
            ddl.DataTextField = DepartsTable.depart_name;
            ddl.DataValueField = DepartsTable.depart_id;
            if (isTree)
            {
                dt = DataTableHelper.DataTableTidyUp(dt, DepartsTable.depart_id, DepartsTable.Up_ID, 0);
                ddl.EnableSimulateTree = true;
                ddl.DataSimulateTreeLevelField = DepartsTable.TreeLevel;
            }

            //绑定数据源
            ddl.DataSource = dt;
            ddl.DataBind();
        }

        #endregion 自定义函数



        public void BandDropDownListShowAll(Page page, FineUI.DropDownList ddl, bool isTree = false)
        {
            //设置排序
            var sortList = new List<string> {DepartsTable.TreeLevel, DepartsTable.inside_id};

            var dt = GetDataTable(false, 0, null, 0, 0, null, sortList);

            //显示值
            ddl.DataTextField = DepartsTable.depart_name;
            ddl.DataValueField = DepartsTable.depart_id;
            if (isTree)
            {
                dt = DataTableHelper.DataTableTidyUp(dt, DepartsTable.depart_id, DepartsTable.Up_ID);
                ddl.EnableSimulateTree = true;
                ddl.DataSimulateTreeLevelField = DepartsTable.TreeLevel;
            }

            //绑定数据源
            ddl.DataSource = dt;
            ddl.DataBind();
        }
    }
}
