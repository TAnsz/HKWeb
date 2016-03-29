using System;
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
 *   創建日期：2014-07-08
 *   文件名稱：ActiveFileClassEdit.aspx.cs
 *   描    述：廣告位置編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.ActiveFiles
{
    public partial class ActiveFileClassEdit : PageBase
    {
        protected string RndKey = RandomHelper.GetRndKey();

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //綁定下拉列表
                ActiveFileClassBll.GetInstence().BandDropDownList(this, ddlParentId);

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
                //獲取指定ID的廣告位置內容
                var model = ActiveFileClassBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;
                
                //地址名稱
                txtName.Text = model.Name;
                //給下拉列表賦值
                ddlParentId.SelectedValue = model.ParentId + "";
                //編輯時不能修改父節點
                ddlParentId.Enabled = false;
                //設置父ID
                txtParent.Text = model.ParentId + "";
                //設置排序
                txtSort.Text = model.Sort + "";
                //KEY
                txtKey.Text = model.Keyword;
               
                //是否顯示（狀態）
                rblIsDisplay.SelectedValue = model.IsDisplay + "";

            }
            else
            {
                //新建廣告位置時，隱藏圖片控件和圖片刪除按鈕
                ButtonDelMapImg.Visible = false;
            }
        }

        #endregion

        #region 頁面控件綁定

        #region 下拉列表改變事件
        /// <summary>
        /// 下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlParentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //獲取當前節點的父節點Id
            txtParent.Text = ddlParentId.SelectedValue;
        }
        #endregion

        #region 刪除圖片
        /// <summary>
        /// 刪除位置圖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonDelMapImg_Click(object sender, EventArgs e)
        {
            //ActiveFileClassBll.GetInstence().DelMapImg(this, ConvertHelper.Cint0(hidId.Text));
            //刪除後刷新編輯窗口
            Response.Redirect(Request.Url.ToString());
        }
        #endregion

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
                if (ActiveFileClassBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }
                if (string.IsNullOrEmpty(txtKey.Text.Trim()))
                {
                    return txtKey.Label + "不能為空！";
                }
                var sKeyword = StringHelper.Left(txtKey.Text, 50);
                if (ActiveFileClassBll.GetInstence().Exist(x => x.Keyword == sKeyword && x.Id != id))
                {
                    return txtKey.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值
                //定義是否更新其他關聯表變量
                bool isUpdate = false;

                //讀取當前地址信息
                var model = new ActiveFileClass(x => x.Id == id);

                //判斷是否更新關聯表
                if (model.Id > 0 && sName != model.Name)
                    isUpdate = true;

                //設置名稱
                model.Name = StringHelper.Left(txtName.Text, 50);
                //KEY
                model.Keyword = StringHelper.Left(txtKey.Text, 50);
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
                        model.Depth = ConvertHelper.Cint0(ActiveFileClassBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue), ActiveFileClassTable.Depth)) + 1;
                    }

                    //限制分類層數只能為2層
                    if (model.Depth > 2)
                    {
                        return "廣告位置只能創建2層分類！";
                    }
                }
                //設置排序
                if (txtSort.Text == "0")
                {
                    model.Sort = ActiveFileClassBll.GetInstence().GetSortMax(model.ParentId) + 1;
                }
                else
                {
                    model.Sort = ConvertHelper.Cint0(txtSort.Text);
                }
                //設定當前項是否顯示
                model.IsDisplay = ConvertHelper.StringToByte(rblIsDisplay.SelectedValue);

                //廣告寬與高

                //添加最後修改人員
                model.Employee_EmpId = OnlineUsersBll.GetInstence().GetManagerEmpId();
                model.Employee_CName = OnlineUsersBll.GetInstence().GetManagerCName();
                model.AddDate = DateTime.Now;

                #endregion
                
                //----------------------------------------------------------
                //存儲到數據庫
                ActiveFileClassBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());

                //如果本次修改改變了相關名稱，則同步更新其他關聯表的對應名稱
                if (isUpdate)
                {
                    ActiveFileBll.GetInstence().UpdateValue_For_ActiveFileClass_Id(this, model.Id, ActiveFileTable.ActiveFileClass_Id, model.Name);
                }

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