using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using FineUI;


/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-19
 *   文件名稱：MenuInfoEdit.aspx.cs
 *   描    述：菜單編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class MenuInfoEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //綁定下拉列表
                MenuInfoBll.GetInstence().BandDropDownListShowMenu(this, ddlParentId);

                //加載數據
                LoadData();
            }
        }
        #endregion

        #region 接口函數，用於UI頁面初始化，給邏輯層對像、列表等對像賦值
        public override void Init()
        {

        }
        #endregion

        #region 加載數據
        /// <summary>讀取數據</summary>
        public override void LoadData()
        {
            int id = ConvertHelper.Cint0(hidId.Text);

            if (id != 0)
            {
                //獲取指定ID的菜單內容
                var model = MenuInfoBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtName.Text = model.Name;
                //設置下拉列表選擇項
                ddlParentId.SelectedValue = model.ParentId + "";
                //編輯時不給修改節點
                ddlParentId.Enabled = false;
                //設置頁面URL
                txtUrl.Text = model.Url;
                //設置父ID
                txtParent.Text = model.ParentId + "";
                //設置排序
                txtSort.Text = model.Sort + "";
                //設置頁面類型——菜單還是頁面
                rblIsMenu.SelectedValue = model.IsMenu + "";
                //設置是否顯示
                rblIsDisplay.SelectedValue = model.IsDisplay + "";
            }
        }

        #endregion

        #region 頁面控件綁定
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化路徑值
            txtUrl.Text = string.Empty;
            //獲取當前節點的父節點Id
            txtParent.Text = ddlParentId.SelectedValue;
            if (!ddlParentId.SelectedValue.Equals("0"))
            {
                try
                {
                    //獲取當前節點的父節點url
                    txtUrl.Text = MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Url) + "";
                }
                catch
                {
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 數據保存
        /// </summary>
        /// <returns></returns>
        public override string Save()
        {
            string result = string.Empty;
            int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 數據驗證

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能為空！";
                }
                var sName = StringHelper.Left(txtName.Text, 50);
                if (MenuInfoBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }
                if (string.IsNullOrEmpty(txtUrl.Text.Trim()))
                {
                    return txtUrl.Label + "不能為空！";
                }
                var sUrl = StringHelper.Left(txtUrl.Text, 250, true, false);
                if (MenuInfoBll.GetInstence().Exist(x => x.Url == sUrl && x.Id != id))
                {
                    return txtUrl.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值
                //獲取實體
                var model = new MenuInfo(x => x.Id == id);

                //設置名稱
                model.Name = sName;
                //連接地址
                model.Url = sUrl;
                //對應的父類id
                model.ParentId = ConvertHelper.Cint0(txtParent.Text);

                //由於限制了編輯時不能修改父節點，所以這裡只對新建記錄時處理
                if (id == 0)
                {
                    //設定當前的深度與設定當前的層數級
                    if (model.ParentId == 0)
                    {
                        //設定當前的層數級
                        model.Depth = 0;
                    }
                    else
                    {
                        //設定當前的層數
                        model.Depth = ConvertHelper.Cint0(MenuInfoBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), MenuInfoTable.Depth)) + 1;
                    }
                }

                //設置排序
                if (txtSort.Text == "0")
                {
                    model.Sort = MenuInfoBll.GetInstence().GetSortMax(model.ParentId) + 1;
                }
                else
                {
                    model.Sort = ConvertHelper.Cint0(txtSort.Text);
                }
                //設定當前項屬於菜單還是頁面
                model.IsMenu = ConvertHelper.StringToByte(rblIsMenu.SelectedValue);
                //設定當前項是否顯示
                model.IsDisplay = ConvertHelper.StringToByte(rblIsDisplay.SelectedValue);
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                MenuInfoBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
            }
            catch (Exception e)
            {
                result = "保存失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);
            }

            return result;
        }
        #endregion
    }
}