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
 *   創建日期：2014-07-01
 *   文件名稱：InformationList.aspx.cs
 *   描    述：信息列表管理
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.Informations
{
    public partial class InformationList : PageBase
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //綁定下拉框
                InformationClassBll.GetInstence().BandDropDownListShowAll(this, dllInformationClass);

                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {
            //邏輯對像賦值
            bll = InformationBll.GetInstence();
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

        //條件
        private List<ConditionHelper.SqlqueryCondition> InquiryCondition()
        {
            var list = new List<ConditionHelper.SqlqueryCondition>();

            //所屬欄目
            if (dllInformationClass.SelectedValue != "0")
            {
                list.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.InformationClass_Root_Id, Comparison.Equals, StringHelper.FilterSql(dllInformationClass.SelectedValue), true));
                list.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.Or, InformationTable.InformationClass_Id, Comparison.Equals, StringHelper.FilterSql(dllInformationClass.SelectedValue)));
                list.Add(new ConditionHelper.SqlqueryCondition());
            }
            //審批
            if (!string.IsNullOrEmpty(ddlIsDisplay.SelectedValue))
            {
                list.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.IsDisplay, Comparison.Equals, StringHelper.FilterSql(ddlIsDisplay.SelectedValue)));
            }
            //推薦狀態
            if (!string.IsNullOrEmpty(ddlIsHot.SelectedValue))
            {
                list.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.IsHot, Comparison.Equals, StringHelper.FilterSql(ddlIsHot.SelectedValue)));
            }
            //標題
            if (!string.IsNullOrEmpty(txtKey.Text.Trim()))
            {
                list.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.Title, Comparison.Like, "%" + StringHelper.FilterSql(txtKey.Text) + "%", true));
                list.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.Or, InformationTable.Keywords, Comparison.Like, "%" + StringHelper.FilterSql(txtKey.Text) + "%"));
                list.Add(new ConditionHelper.SqlqueryCondition());
            }

            return list;
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
            //綁定是否顯示
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                if (
                    row.Row.Table.Rows[e.RowIndex][InformationTable.IsDisplay]
                        .ToString() == "0")
                {
                    var lbf = Grid1.FindColumn("IsDisplay") as LinkButtonField;
                    lbf.Icon = Icon.BulletCross;
                    lbf.CommandArgument = "1";
                }
                else
                {
                    var lbf = Grid1.FindColumn("IsDisplay") as LinkButtonField;
                    lbf.Icon = Icon.BulletTick;
                    lbf.CommandArgument = "0";
                }

                //綁定是否置頂
                if (
                    row.Row.Table.Rows[e.RowIndex][InformationTable.IsTop]
                        .ToString() == "0")
                {
                    var lbf = Grid1.FindColumn("IsTop") as LinkButtonField;
                    lbf.Icon = Icon.BulletCross;
                    lbf.CommandArgument = "1";
                }
                else
                {
                    var lbf = Grid1.FindColumn("IsTop") as LinkButtonField;
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
                case "IsDisplay":
                    //更新狀態
                    InformationBll.GetInstence().UpdateIsDisplay(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加載
                    LoadData();

                    break;
                case "IsTop":
                    //更新狀態
                    InformationBll.GetInstence().UpdateIsTop(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加載
                    LoadData();

                    break;

                case "IsHot":
                    //更新狀態
                    InformationBll.GetInstence().UpdateIsHot(this, ConvertHelper.Cint0(id), ConvertHelper.Cint0(e.CommandArgument));
                    //重新加載
                    LoadData();

                    break;

                case "ButtonEdit":
                    //打開編輯窗口
                    Window1.IFrameUrl = "InformationEdit.aspx?Id=" + id + "&" + MenuInfoBll.GetInstence().PageUrlEncryptStringNoKey(id + "");
                    Window1.Hidden = false;

                    break;
            }
        }
        #endregion

        #region 保存自動排序
        /// <summary>
        /// 保存自動排序
        /// </summary>
        public override void SaveAutoSort()
        {
            if (bll.UpdateAutoSort(this))
            {
                Alert.ShowInParent("保存成功", "保存自動排序成功", "window.location.reload();");
            }
            else
            {
                Alert.ShowInParent("保存失敗", "保存自動排序失敗");
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
            Window1.IFrameUrl = "InformationEdit.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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
                //逐個刪除對應圖片
                foreach (var i in id)
                {
                    //刪除文章封面圖片
                    InformationBll.GetInstence().DelFrontCoverImg(this, i);
                    //刪除編輯器上傳圖片
                    UploadFileBll.Upload_BatDelPic(InformationTable.TableName, i);
                }

                //刪除記錄
                bll.Delete(this, id);

                return "刪除編號Id為[" + string.Join(",", id) + "]的數據記錄成功。";
            }
            catch (Exception e)
            {
                string result = "嘗試刪除編號ID為[" + string.Join(",", id) + "]的數據記錄失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion

    }
}