using System;
using System.Collections.Generic;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using SubSonic.Query;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-21
 *   文件名稱：DepartsList.aspx.cs
 *   描    述：部門列表文件
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class DepartsList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定下拉列表
                //DepartsBll.GetInstence().BandDropDownList(this, ddlParentId,true);

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = DepartsBll.GetInstence();
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
                Sort();
            }

            //綁定Grid表格
            if (bll != null) bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, null, sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var wheres = new List<ConditionHelper.SqlqueryCondition>();

            //選擇菜單
            //if (ddlParentId.SelectedValue != "0")
            //{
            //    wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, DepartsTable.Up_ID, Comparison.In,
            //        ddlParentId.SelectedValue));
            //}
            return wheres;
        }

        #region 排序
        /// <summary>
        /// 頁面表格綁定排序
        /// </summary>
        public void Sort()
        {
            //設置排序
            sortList = new List<string>();
            //sortList.Add(DepartsTable.Depth + " asc");
            sortList.Add(DepartsTable.inside_id + " asc");
        }
        #endregion

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
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "DepartsEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
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
            Window1.IFrameUrl = "DepartsEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window1.Hidden = false;
        }
        #endregion

        #region 刪除記錄
        /// <summary>
        /// 刪除記錄
        /// </summary>
        /// <returns></returns>
        public override string Delete()
        {
            //獲取要刪除的ID
            int id = ConvertHelper.Cint0(GridViewHelper.GetSelectedKey(Grid1, true));
            
            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                return "請選擇要刪除的記錄。";
            }

            var modle = DepartsBll.GetInstence().GetModelForCache(id);

            if (modle==null)
            {
                return "刪除失敗，部門信息不存在，請刷新！";
            }
            try
            {
                //刪除前判斷一下
                if (DepartsBll.GetInstence().Exist(x => x.Up_ID == modle.depart_id))
                {
                    return "刪除失敗，本部門下面存在子部門，不能直接刪除！";
                }
                //刪除前判斷一下
                //if (PositionBll.GetInstence().Exist(x => x.Departs_Id == id))
                //{
                //    return "刪除失敗，相關職位已綁定本部門，不能直接刪除！";
                //}
                if (EmployeeBll.GetInstence().Exist(x => x.DEPART_ID == modle.depart_id))
                {
                    return "刪除失敗，已有員工綁定本部門，不能直接刪除！";
                }

                //刪除記錄
                bll.Delete(this, id);

                return "刪除編號ID為[" + id + "]的數據記錄成功。";
            }
            catch (Exception e)
            {
                string result = "嘗試刪除編號ID為[" + id + "]的數據記錄失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion

    }
}