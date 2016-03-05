using System;
using System.Collections.Generic;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-22
 *   文件名稱：ErrorLogList.aspx.cs
 *   描    述：錯誤日誌列表文件
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;
using System.Data;

namespace Solution.Web.Managers.WebManage.Systems.Security
{
    public partial class ErrorLogList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //設定初始化時間
                dpStart.Text = DateTime.Now.ToString("yyyy-M-d");
                dpEnd.Text = DateTime.Now.AddDays(1).ToString("yyyy-M-d");

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = ErrorLogBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            //設置排序
            if (sortList == null)
            {
                Sort(null);
            }

            //綁定Grid表格
            if (bll != null) bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, InquiryCondition(), sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();

            //起始時間
            if (!string.IsNullOrEmpty(dpStart.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ErrorLogTable.ErrTime, Comparison.GreaterOrEquals, StringHelper.FilterSql(dpStart.Text)));
                //終止時間
                if (!string.IsNullOrEmpty(dpEnd.Text.Trim()))
                {
                    wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ErrorLogTable.ErrTime, Comparison.LessOrEquals, StringHelper.FilterSql(dpEnd.Text)));
                }
            }

            //ip地址
            if (!string.IsNullOrEmpty(txtIp.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ErrorLogTable.Ip, Comparison.Equals, StringHelper.FilterSql(txtIp.Text)));
            }
            //位置
            if (!string.IsNullOrEmpty(ddlType.SelectedValue.Trim()) && StringHelper.FilterSql(ddlType.SelectedValue.Trim()) != "-1")
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ErrorLogTable.Type, Comparison.Equals,
                                                            ConvertHelper.Cint0(ddlType.SelectedValue)));
            }
            return wheres;
        }

        #endregion

        #region 列表屬性綁定
        /// <summary>
        /// 列表按鍵綁定——修改列表控件屬性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            //位置
            DataRowView row = e.DataItem as DataRowView;
            var lbf = Grid1.FindColumn("Type") as LinkButtonField;
            if (lbf != null)
            {
                if (row.Row.Table.Rows[e.RowIndex][ErrorLogTable.Type].ToString() == "0")
                {
                    lbf.Text = "後端";
                }
                else
                {
                    lbf.Text = "前端";
                }
            }
        }
        #endregion

    }
}