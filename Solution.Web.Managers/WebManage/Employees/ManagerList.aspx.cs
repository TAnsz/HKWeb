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
 *   創建日期：2014-06-27
 *   文件名稱：ManagerList.aspx.cs
 *   描    述：在職員工列表管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Employees
{
    public partial class ManagerList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定部門
                BranchBll.GetInstence().BandDropDownListShowAll(this, ddlBranch_Id, true);

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = ManagerBll.GetInstence();
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
            bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, InquiryCondition(), sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            //添加條件：只顯示在職人員
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ManagerTable.IsWork, Comparison.Equals,
                1));

            //登陸賬號
            if (!string.IsNullOrEmpty(txtLoginName.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ManagerTable.LoginName,
                    Comparison.Like, "%" + StringHelper.FilterSql(txtLoginName.Text) + "%"));
            }
            //中文名稱
            if (!string.IsNullOrEmpty(txtCName.Text.Trim()))
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ManagerTable.CName, Comparison.Like,
                    "%" + StringHelper.FilterSql(txtCName.Text) + "%"));
            }
            //綁定部門編碼
            if (ddlBranch_Id.SelectedValue != "0")
            {
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ManagerTable.Branch_Code, Comparison.StartsWith,
                    StringHelper.FilterSql(ddlBranch_Id.SelectedValue)));
            }

            return wheres;
        }

        #endregion

        #region 列表屬性綁定

        #region 列表按鍵綁定——修改列表控件屬性
        /// <summary>
        /// 列表按鍵綁定——修改列表控件屬性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            //綁定是否編輯列
            var lbfEdit = Grid1.FindColumn("ButtonEdit") as LinkButtonField;
            lbfEdit.Text = "編輯";
            lbfEdit.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonEdit");
        }
        #endregion

        #region Grid點擊事件
        /// <summary> 
        /// Grid點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            GridRow gr = Grid1.Rows[e.RowIndex];
            //獲取當前點擊列的主鍵ID
            object id = gr.DataKeys[0];

            switch (e.CommandName)
            {
                case "LoginLog":
                    Window2.IFrameUrl = "../Systems/Security/LoginLogList.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window2.Hidden = false;
                    break;
                case "UserLog":
                    Window2.IFrameUrl = "../Systems/Security/UseLogList.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window2.Hidden = false;
                    break;
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "ManagerEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window1.Hidden = false;

                    break;
            }
        }
        #endregion

        #endregion

        #region 添加新記錄
        /// <summary>
        /// 添加新記錄
        /// </summary>
        public override void Add()
        {
            Window1.IFrameUrl = "ManagerEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window1.Hidden = false;
        }
        #endregion

        #region 設置員工離職
        /// <summary>
        /// 設置員工離職
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonStaffTurnover_Click(object sender, EventArgs e)
        {
            //獲取要操作的ID
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);

            //如果沒有選擇記錄，則直接退出
            if (id == null)
            {
                FineUI.Alert.ShowInParent("請選擇你要處理的記錄", FineUI.MessageBoxIcon.Information);
            }

            try
            {
                //逐個設置離職
                foreach (var i in id)
                {
                    var name = ManagerBll.GetInstence().GetCName(this, i);
                    ManagerBll.GetInstence().UpdateValue(this, i, ManagerTable.IsWork, 0, ManagerTable.IsEnable, 0, "{0}將員工" + name + "[" + i + "]設置為離職狀態");
                }

                LoadData();

                FineUI.Alert.ShowInParent("編號Id為[" + string.Join(",", id) + "]的員工已設置為離職", FineUI.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string result = "嘗試設置編號ID為[" + string.Join(",", id) + "]的員工離職失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, ex);

                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
            }
        }
        #endregion

    }
}