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
 *   創建日期：2014-06-25
 *   文件名稱：UploadConfigEdit.aspx.cs
 *   描    述：上傳類型編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Set
{
    public partial class UploadConfigEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";
                //綁定下拉列表
                UploadTypeBll.GetInstence().BandDropDownList(this, ddlUploadTypeId);

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
                //獲取指定ID的菜單內容，如果不存在，則創建一個菜單實體
                var model = UploadConfigBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                txtName.Text = model.Name;
                txtJoinName.Text = model.JoinName;
                rblUserType.SelectedValue = model.UserType + "";
                ddlUploadTypeId.SelectedValue = model.UploadType_Id + "";
                txtPicSize.Text = model.PicSize + "";
                txtFileSize.Text = model.FileSize + "";
                txtSaveDir.Text = model.SaveDir;
                rblIsPost.SelectedValue = model.IsPost + "";
                rblIsEditor.SelectedValue = model.IsEditor + "";
                rblIsSwf.SelectedValue = model.IsSwf + "";
                brlIsChkSrcPost.SelectedValue = model.IsChkSrcPost + "";
                rblIsFixPic.SelectedValue = model.IsFixPic + "";
                ddlCutType.SelectedValue = model.CutType + "";
                txtPicWidth.Text = model.PicWidth + "";
                txtPicHeight.Text = model.PicHeight + "";
                txtPicQuality.Text = model.PicQuality + "";
                rblIsBigPic.SelectedValue = model.IsBigPic + "";
                txtBigWidth.Text = model.BigWidth + "";
                txtBigHeight.Text = model.BigHeight + "";
                txtBigQuality.Text = model.BigQuality + "";
                rblIsMidPic.SelectedValue = model.IsMidPic + "";
                txtMidWidth.Text = model.MidWidth + "";
                txtMidHeight.Text = model.MidHeight + "";
                txtMidQuality.Text = model.MidQuality + "";
                rblIsMinPic.SelectedValue = model.IsMinPic + "";
                txtMinWidth.Text = model.MinWidth + "";
                txtMinHeight.Text = model.MinHeight + "";
                txtMinQuality.Text = model.MinQuality + "";
                rblIsHotPic.SelectedValue = model.IsHotPic + "";
                txtHotWidth.Text = model.HotWidth + "";
                txtHotHeight.Text = model.HotHeight + "";
                txtHotQuality.Text = model.HotQuality + "";
                rblIsWaterPic.SelectedValue = model.IsWaterPic + "";
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
                var sName = StringHelper.Left(txtName.Text, 20);
                if (UploadConfigBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }
                if (string.IsNullOrEmpty(txtJoinName.Text.Trim()))
                {
                    return txtJoinName.Label + "不能為空！";
                }
                if (ddlUploadTypeId.SelectedValue == "0")
                {
                    return ddlUploadTypeId.Label + "為必選項，請選擇後再保存！";
                }
                if (string.IsNullOrEmpty(txtPicSize.Text.Trim()))
                {
                    return txtPicSize.Label + "不能為空！";
                }
                if (string.IsNullOrEmpty(txtFileSize.Text.Trim()))
                {
                    return txtFileSize.Label + "不能為空！";
                }
                if (string.IsNullOrEmpty(txtSaveDir.Text.Trim()))
                {
                    return txtSaveDir.Label + "不能為空！";
                }
                #endregion

                #region 賦值
                //獲取實體
                var model = new UploadConfig(x => x.Id == id);

                model.Name = sName;
                model.JoinName = StringHelper.Left(txtJoinName.Text, 30);
                model.UserType = (byte)ConvertHelper.Cint1(rblUserType.SelectedValue);
                //讀取上傳類型
                model.UploadType_Id = ConvertHelper.Cint0(ddlUploadTypeId.SelectedValue);
                var uploadTypeModel = UploadTypeBll.GetInstence().GetModelForCache(model.UploadType_Id);
                if (uploadTypeModel != null)
                {
                    model.UploadType_Name = uploadTypeModel.Name;
                    model.UploadType_TypeKey = uploadTypeModel.TypeKey;
                }

                //上傳限制
                model.PicSize = ConvertHelper.Cint0(txtPicSize.Text);
                model.FileSize = ConvertHelper.Cint0(txtFileSize.Text);

                model.SaveDir = StringHelper.Left(txtSaveDir.Text, 50);
                model.IsPost = ConvertHelper.Ctinyint(rblIsPost.SelectedValue);
                model.IsEditor = ConvertHelper.Ctinyint(rblIsEditor.SelectedValue);
                model.IsSwf = ConvertHelper.Ctinyint(rblIsSwf.SelectedValue);
                model.IsChkSrcPost = ConvertHelper.Ctinyint(brlIsChkSrcPost.SelectedValue);

                //按比例生成
                model.IsFixPic = ConvertHelper.Ctinyint(rblIsFixPic.SelectedValue);
                model.CutType = ConvertHelper.Cint0(ddlCutType.SelectedValue);
                model.PicWidth = ConvertHelper.Cint0(txtPicWidth.Text);
                model.PicHeight = ConvertHelper.Cint0(txtPicHeight.Text);
                model.PicQuality = ConvertHelper.Cint0(txtPicQuality.Text);

                //大圖
                model.IsBigPic = ConvertHelper.Ctinyint(rblIsBigPic.SelectedValue);
                model.BigWidth = ConvertHelper.Cint0(txtBigWidth.Text);
                model.BigHeight = ConvertHelper.Cint0(txtBigHeight.Text);
                model.BigQuality = ConvertHelper.Cint0(txtBigQuality.Text);

                //中圖
                model.IsMidPic = ConvertHelper.Ctinyint(rblIsMidPic.SelectedValue);
                model.MidWidth = ConvertHelper.Cint0(txtMidWidth.Text);
                model.MidWidth = ConvertHelper.Cint0(txtMidWidth.Text);
                model.MidHeight = ConvertHelper.Cint0(txtMidHeight.Text);

                //小圖
                model.IsMinPic = ConvertHelper.Ctinyint(rblIsMinPic.SelectedValue);
                model.MinWidth = ConvertHelper.Cint0(txtMinWidth.Text);
                model.MinWidth = ConvertHelper.Cint0(txtMinWidth.Text);
                model.MinHeight = ConvertHelper.Cint0(txtMinHeight.Text);

                //推薦圖
                model.IsHotPic = ConvertHelper.Ctinyint(rblIsHotPic.SelectedValue);
                model.HotWidth = ConvertHelper.Cint0(txtHotWidth.Text);
                model.HotWidth = ConvertHelper.Cint0(txtHotWidth.Text);
                model.HotHeight = ConvertHelper.Cint0(txtHotHeight.Text);

                //加水印
                model.IsWaterPic = ConvertHelper.Ctinyint(rblIsWaterPic.SelectedValue);

                //修改時間與管理員
                model.UpdateDate = DateTime.Now;
                model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();
                
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                UploadConfigBll.GetInstence().Save(this, model);
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