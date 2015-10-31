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
 *   創建日期：2014-07-01
 *   文件名稱：InformationEdit.aspx.cs
 *   描    述：信息編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Informations
{
    public partial class InformationEdit : PageBase
    {
        protected string RndKey = RandomHelper.GetRndKey();
        protected string p_Img = "";

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";
                //綁定下拉框
                InformationClassBll.GetInstence().BandDropDownListShowAll(this, ddlInformationClass_Id);
                //Key（上傳必須）
                txtRndKey.Text = RndKey;

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
                var model = InformationBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtTitle.Text = model.Title;
                ddlInformationClass_Id.SelectedValue = model.InformationClass_Id + "";

                txtKeywords.Text = model.Keywords;
                dpNewsTime.SelectedDate = model.NewsTime;

                txtNotes.Text = model.Notes;

                txtAuthor.Text = model.Author;
                txtFromName.Text = model.FromName;

                //置頂、審核、推薦
                rblIsTop.SelectedValue = model.IsTop + "";
                rblIsDisplay.SelectedValue = model.IsDisplay + "";
                rblIsHot.SelectedValue = model.IsHot + "";

                txtRedirectUrl.Text = model.RedirectUrl;

                //SEO
                txtSeoTitle.Text = model.SeoTitle;
                txtSeoKey.Text = model.SeoKey;
                txtSeoDesc.Text = model.SeoDesc;

                //Key（如果存在編輯器必須下面代碼）
                txtText.Text = model.Content;
                txtUpload.Text = model.Upload;

                if (!String.IsNullOrEmpty(model.FrontCoverImg))
                {
                    p_Img = model.FrontCoverImg;
                    ButtonDeleteImage.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonDeleteImage");
                }
                else
                {
                    ButtonDeleteImage.Visible = false;
                }
            }
            else
            {
                ButtonDeleteImage.Visible = false;
            }
        }

        #endregion

        #region 頁面控件綁定功能

        #region 下拉列表改變事件
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlInformationClassId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint0(hidId.Text);
            if (id > 0) return;

            //如果選擇根節點，則將SEO全部置空
            if (ddlInformationClass_Id.SelectedValue == "0")
            {
                txtSeoTitle.Text = "";
                txtSeoKey.Text = "";
                txtSeoDesc.Text = "";
            }
            //否則讀取分類節點的SEO值
            else
            {
                var icId = ConvertHelper.Cint0(ddlInformationClass_Id.SelectedValue);
                var model = InformationClassBll.GetInstence().GetModelForCache(x => x.Id == icId);
                if (model != null)
                {
                    txtSeoTitle.Text = model.SeoTitle;
                    txtSeoKey.Text = model.SeoKey;
                    txtSeoDesc.Text = model.SeoDesc;
                }
            }
        }
        #endregion

        #region 刪除圖片
        /// <summary>刪除圖片</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonDeleteImage_Click(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint0(hidId.Text);
            if (id > 0)
            {
                InformationBll.GetInstence().DelFrontCoverImg(this, id);

                FineUI.PageContext.RegisterStartupScript("window.location.reload()");
            }
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

                if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
                {
                    return txtTitle.Label + "不能為空！";
                }
                if (ddlInformationClass_Id.SelectedValue == "0")
                {
                    return ddlInformationClass_Id.Label + "為必選項，請選擇！";
                }
                //判斷是否重複
                var sTitle = StringHelper.FilterSql(txtTitle.Text, true);
                var icId = ConvertHelper.Cint0(ddlInformationClass_Id.SelectedValue);
                if (
                    DataAccess.DataModel.Information.Exists(
                        x => x.Title == sTitle && x.InformationClass_Id == icId && x.Id != id))
                {
                    return txtTitle.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值

                //獲取實體
                var model = new Information(x => x.Id == id);

                //------------------------------------------
                //設置名稱
                model.Title = StringHelper.Left(txtTitle.Text, 100);
                //取得分類
                model.InformationClass_Id = ConvertHelper.Cint0(ddlInformationClass_Id.SelectedValue);

                model.InformationClass_Root_Id =
                    ConvertHelper.Cint0(InformationClassBll.GetInstence()
                        .GetFieldValue(model.InformationClass_Id, InformationClassTable.ParentId));
                if (model.InformationClass_Root_Id > 0)
                {
                    model.InformationClass_Root_Name = InformationClassBll.GetInstence()
                        .GetName(this, model.InformationClass_Root_Id);
                }
                model.InformationClass_Name = StringHelper.Left(ddlInformationClass_Id.SelectedText, 20);

                //重定向
                model.RedirectUrl = StringHelper.Left(txtRedirectUrl.Text, 250);

                //------------------------------------------
                //編輯器
                model.Content = StringHelper.Left(txtText.Text, 0, true, false);
                model.Upload = StringHelper.Left(txtUpload.Text, 0, true, false);
                //這裡必須用回前端存放的Key，不然刪除時無法同步刪除編輯器上傳的圖片
                RndKey = StringHelper.Left(txtRndKey.Text, 0);

                //檢查用戶上傳的文件和最後保存的文件是否有出入，
                //如果上傳的文件大於保存的文件，把不保存，但本次操作已經上傳的文件刪除。
                model.Upload = UploadFileBll.GetInstence().FCK_BatchDelPic(model.Content, model.Upload);

                //------------------------------------------
                //其它值
                model.NewsTime = dpNewsTime.SelectedDate ?? DateTime.Now;
                model.AddYear = model.NewsTime.Year;
                model.AddMonth = model.NewsTime.Month;
                model.AddDay = model.NewsTime.Day;

                model.Notes = StringHelper.Left(txtNotes.Text, 200);

                model.Keywords = StringHelper.Left(txtKeywords.Text, 50);
                model.Author = StringHelper.Left(txtAuthor.Text, 50);
                model.FromName = StringHelper.Left(txtFromName.Text, 50);


                model.SeoTitle = StringHelper.Left(txtSeoTitle.Text, 100);
                model.SeoKey = StringHelper.Left(txtSeoKey.Text, 100);
                model.SeoDesc = StringHelper.Left(txtSeoDesc.Text, 200);
                model.Sort = 0;

                //設定當前項是否顯示
                model.IsDisplay = ConvertHelper.StringToByte(rblIsDisplay.SelectedValue);
                model.IsHot = ConvertHelper.StringToByte(rblIsHot.SelectedValue);
                model.IsTop = ConvertHelper.StringToByte(rblIsTop.SelectedValue);

                //------------------------------------------
                //判斷是否是新增
                if (model.Id == 0)
                {
                    //添加時間與用戶
                    model.AddDate = DateTime.Now;
                    //修改時間與用戶
                    model.UpdateDate = DateTime.Now;
                }
                else
                {
                    //修改時間與用戶
                    model.UpdateDate = DateTime.Now;
                }
                model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();

                #endregion

                //------------------------------------------

                #region 上傳圖片

                if (this.filePhoto.HasFile && this.filePhoto.FileName.Length > 3)
                {
                    int vid = 3; //3	文章封面
                    //---------------------------------------------------
                    var upload = new UploadFile();
                    result = new UploadFileBll().Upload_AspNet(this.filePhoto.PostedFile, vid, RndKey,
                        OnlineUsersBll.GetInstence().GetManagerId(), OnlineUsersBll.GetInstence().GetManagerCName(),
                        upload);
                    this.filePhoto.Dispose();
                    //---------------------------------------------------
                    if (result.Length == 0) //上傳成功
                    {
                        model.FrontCoverImg = upload.Path;
                    }
                    else
                    {
                        CommonBll.WriteLog("上傳出錯：" + result); //收集異常信息
                        return "上傳出錯！" + result;
                    }
                }
                //如果是修改，檢查用戶是否重新上傳過封面圖片，如果是刪除舊的圖片
                if (model.Id > 0)
                {
                    UploadFileBll.GetInstence()
                        .Upload_DiffFile(InformationTable.Id, InformationTable.FrontCoverImg, InformationTable.TableName,
                            model.Id, model.FrontCoverImg);

                    //同步UploadFile上傳表
                    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, InformationTable.TableName, model.Id);
                }

                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                InformationBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());

                #region 同步更新上傳圖片表綁定Id
                if (id == 0)
                {
                    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, InformationTable.TableName, model.Id);
                }
                #endregion
                
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