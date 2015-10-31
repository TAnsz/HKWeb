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
 *   文件名稱：PositionList.aspx.cs
 *   描    述：職位管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PositionList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = T_TABLE_DBll.GetInstence();
            //表格對像賦值
            grid = Grid1;
        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            //設置排序
            var order = new List<string>();
            order.Add(PagePowerSignTable.Id);
            var wheres = new List<ConditionHelper.SqlqueryCondition>();
            wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And,T_TABLE_DTable.TABLES,Comparison.Equals,"AUTH"));
            //綁定Grid表格
            bll.BindGrid(Grid1, Grid1.PageIndex + 1, Grid1.PageSize, wheres, order);
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
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "PositionEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id+"");
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
            Window1.IFrameUrl = "PositionEdit.aspx?&" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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
        //獲取要刪除的Id組
            var id = GridViewHelper.GetSelectedKeyIntArray(Grid1);

        //如果沒有選擇記錄，則直接退出
        if (id == null)
        {
            return "請選擇要刪除的記錄。";
        }

        try
        {
            //逐個判斷是否可以刪除
            foreach (var i in id)
            {
                //刪除前檢查
                if (EmployeeBll.GetInstence().Exist(x => x.GROUPS.Contains("," + i + ",")))
                {
                    return "刪除失敗，Id為【" + i + "】的角色已有員工使用，不能直接刪除！";
                }
            }

            //刪除記錄
            bll.Delete(this, id);

            return "刪除編號Id為[" + string.Join(",", id) + "]的數據記錄成功。";
        }
        catch (Exception e)
        {
            string result = "嘗試刪除編號ID為[" + string.Join(",", id) +"]的數據記錄失敗！";

            //出現異常，保存出錯日誌信息
            CommonBll.WriteLog(result, e);

            return result;
        }
        }
        #endregion
        
    }
}