using System;
using System.Collections.Generic;
using System.Data;
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
 *   創建日期：2014-07-03
 *   文件名稱：PositionSelect.aspx.cs
 *   描    述：頁面控件權限管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PositionSelect : System.Web.UI.Page
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            //檢測用戶是否超時退出
            OnlineUsersBll.GetInstence().IsTimeOut();
            //檢測用戶登錄的有效性（是否被系統踢下線或管理員踢下線）
            if (OnlineUsersBll.GetInstence().IsOffline(this))
                return;
            //檢查是否從正確路徑進入
            MenuInfoBll.GetInstence().CheckPageEncrypt(this);

            if (!IsPostBack)
            {
                //獲取ID值
                hidPositionId.Text = RequestHelper.GetQueryString("Id");
                //新增用戶時生成的Id是隨機碼，這裡處理一下
                if (hidPositionId.Text.IndexOf(",") == -1)
                {
                    hidPositionId.Text = "";
                }
                //綁定下接列表
                BranchBll.GetInstence().BandDropDownListShowAll(this, ddlBranch, true);

                LoadData();
            }
        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public void LoadData()
        {
            //設置排序
            var _order = new List<string>();
            _order.Add(PositionTable.Id);
            //設置查詢條件
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            //判斷是否選擇了部門，是的話只顯示指定部門的職位
            if (ddlBranch.SelectedValue != "0")
            {
                var branchCode = StringHelper.FilterSql(ddlBranch.SelectedValue, true, true);
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, PositionTable.Branch_Code, Comparison.StartsWith, branchCode));
            }

            //讀取職位Id
            var positionId = StringHelper.FilterSql(hidPositionId.Text, true, true);
            //如果不存在已選擇的職位，則直接運行綁定表格
            if (string.IsNullOrEmpty(positionId))
            {
                Grid2.DataSource = null;
                Grid2.DataBind();

                PositionBll.GetInstence().BindGrid(Grid1, 0, 0, wheres, _order);
            }
            else
            {
                //去掉兩邊的逗號
                positionId = StringHelper.DelStrSign(positionId);
                //轉換成數組
                var positionArr = StringHelper.GetArrayStr(positionId);

                //設置查詢條件
                var grid1Where = new List<ConditionHelper.SqlqueryCondition>();
                //添加條件
                grid1Where.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, PositionTable.Id, Comparison.In, positionArr));


                //獲取DataTable
                var dt = PositionBll.GetInstence().GetDataTable(false, 0, null, 0, 0, grid1Where, _order);

                if (dt == null || dt.Rows.Count == 0)
                {
                    Grid2.DataSource = null;
                    Grid2.DataBind();
                    PositionBll.GetInstence().BindGrid(Grid1, 0, 0, wheres, _order);
                }
                else
                {
                    //綁定到表格——已綁定控件列表
                    Grid2.DataSource = dt;
                    Grid2.DataBind();

                    wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, PositionTable.Id, Comparison.NotIn, positionArr));

                    PositionBll.GetInstence().BindGrid(Grid1, 0, 0, wheres, _order);

                }
            }
        }
        #endregion

        #region 頁面控件綁定
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region 按鍵事件

        #region 確認已選擇職位
        /// <summary>
        /// 確認已選擇職位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSelect_Click(object sender, EventArgs e)
        {
            //讀取職位Id
            var positionId = StringHelper.FilterSql(hidPositionId.Text, true, true);

            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(positionId) + ActiveWindow.GetHidePostBackReference());
        }
        #endregion

        #region 頁面綁定控件
        /// <summary>
        /// 頁面綁定控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonEmpower_Click(object sender, EventArgs e)
        {
            //讀取職位Id
            var positionId = StringHelper.FilterSql(hidPositionId.Text, true, true);
            //獲取當前用戶選擇的全部記錄Id
            var id = GridViewHelper.GetSelectedKeyArray(Grid1);
            //如果沒有選擇項，則直接退出
            if (id == null || id.Length == 0)
                return;

            //如果已選擇的職位Id不存在，則選添加個逗號
            if (string.IsNullOrEmpty(positionId))
            {
                positionId = ",";
            }

            //添加到綁定表中
            foreach (var i in id)
            {
                //檢查當前控件是否已添加
                //添加前判斷一下本職位是否已添加過了，沒有則進行添加
                if (positionId.IndexOf("," + i + ",") == -1)
                {
                    positionId += i + ",";
                }
            }
            //保存已選擇的職位
            hidPositionId.Text = positionId;

            LoadData();
        }
        #endregion

        #region 取消綁定控件
        /// <summary>
        /// 取消綁定控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            //讀取職位Id
            var positionId = StringHelper.FilterSql(hidPositionId.Text, true, true);
            //獲取當前用戶選擇的全部記錄Id
            var id = GridViewHelper.GetSelectedKeyArray(Grid2);
            //如果沒有選擇項，則直接退出
            if (id == null || id.Length == 0)
                return;

            //添加到綁定表中
            foreach (var i in id)
            {
                //檢查當前控件是否已存在
                if (positionId.IndexOf("," + i + ",") > -1)
                {
                    //將指定Id直接刪除
                    positionId = positionId.Replace("," + i + ",", ",");
                }
            }
            //如果刪除了所有選擇的職位，則去掉多餘的逗號
            if (positionId == ",")
            {
                positionId = "";
            }

            //保存已選擇的職位
            hidPositionId.Text = positionId;

            LoadData();
        }
        #endregion

        #region 清空綁定控件
        /// <summary>
        /// 清空綁定控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonEmpty_Click(object sender, EventArgs e)
        {
            //清空已選擇的職位
            hidPositionId.Text = "";

            LoadData();
        }
        #endregion

        #endregion
    }
}