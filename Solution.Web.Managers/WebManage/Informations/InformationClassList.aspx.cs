using System;
using System.Collections.Generic;
using System.Data;
using DotNet.Utilities;
using FineUI;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-29
 *   文件名稱：InformationClassList.aspx.cs
 *   描    述：信息分類列表文件
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Informations
{
    public partial class InformationClassList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定下拉列表
                InformationClassBll.GetInstence().BandDropDownList(this, ddlParentId);

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = InformationClassBll.GetInstence();
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
            if (bll != null) bll.BindGrid(Grid1, InquiryCondition(), sortList);
        }

        /// <summary>
        /// 查詢條件
        /// </summary>
        /// <returns></returns>
        private int InquiryCondition()
        {
            int value = 0;

            //選擇信息分類
            if (ddlParentId.SelectedValue != "0")
            {
                value = ConvertHelper.Cint0(ddlParentId.SelectedValue);
            }
            return value;
        }

        #region 排序
        /// <summary>
        /// 頁面表格綁定排序
        /// </summary>
        public void Sort()
        {
            //設置排序
            sortList = new List<string>();
            sortList.Add(InformationClassTable.Depth + " asc");
            sortList.Add(InformationClassTable.Sort + " asc");
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
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                //綁定是否顯示狀態列
                if (row.Row.Table.Rows[e.RowIndex][InformationClassTable.IsShow].ToString() == "0")
                {
                    var lbf = Grid1.FindColumn("IsShow") as LinkButtonField;
                    lbf.Icon = Icon.BulletCross;
                    lbf.CommandArgument = "1";
                }
                else
                {
                    var lbf = Grid1.FindColumn("IsShow") as LinkButtonField;
                    lbf.Icon = Icon.BulletTick;
                    lbf.CommandArgument = "0";
                }

                //綁定是否單頁列
                if (row.Row.Table.Rows[e.RowIndex][InformationClassTable.IsPage].ToString() == "0")
                {
                    var lbf = Grid1.FindColumn("IsPage") as LinkButtonField;
                    lbf.Icon = Icon.BulletCross;
                    lbf.CommandArgument = "1";
                }
                else
                {
                    var lbf = Grid1.FindColumn("IsPage") as LinkButtonField;
                    lbf.Icon = Icon.BulletTick;
                    lbf.CommandArgument = "0";
                }
            }

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
                case "IsShow":
                    //更新狀態
                    InformationClassBll.GetInstence().UpdateIsShow(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加載
                    LoadData();

                    break;
                case "IsPage":
                    //更新狀態
                    InformationClassBll.GetInstence().UpdateIsPage(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加載
                    LoadData();

                    break;
                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "InformationClassEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
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
            Window1.IFrameUrl = "InformationClassEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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

            try
            {
                //刪除前判斷一下
                if (InformationClassBll.GetInstence().Exist(x => x.ParentId == id))
                {
                    return "刪除失敗，本信息分類下面存在子信息分類，不能直接刪除！";
                }
                //刪除前判斷一下
                if (InformationBll.GetInstence().Exist(x => x.InformationClass_Id == id))
                {
                    return "刪除失敗，本信息分類已被信息表的記錄引用，不能直接刪除！";
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