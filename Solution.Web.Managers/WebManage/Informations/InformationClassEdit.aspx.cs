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
 *   創建日期：2014-06-29
 *   文件名稱：InformationClassEdit.aspx.cs
 *   描    述：信息分類編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Informations
{
    public partial class InformationClassEdit : PageBase
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
                InformationClassBll.GetInstence().BandDropDownListShowAll(this, ddlParentId);

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
                //獲取指定ID的信息分類內容
                var model = InformationClassBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtName.Text = model.Name;
                //設置下拉列表選擇項
                ddlParentId.SelectedValue = model.ParentId + "";
                //編輯時不能修改父節點
                ddlParentId.Enabled = false;
                //設置父ID
                txtParent.Text = model.ParentId + "";
                //設置排序
                txtSort.Text = model.Sort + "";
                //設置是否顯示
                rblIsShow.SelectedValue = model.IsShow + "";
                //設置是否單頁
                rblIsPage.SelectedValue = model.IsPage + "";
                //SEO
                txtSeoTitle.Text = model.SeoTitle;
                txtSeoKey.Text = model.SeoKey;
                txtSeoDesc.Text = model.SeoDesc;
                //備註
                txtNotes.Text = model.Notes;

                //設置圖片
                if (model.ClassImg != null && model.ClassImg.Length > 5)
                {
                    imgClassImg.ImageUrl = model.ClassImg;
                    ButtonDeleteImage.Enabled = MenuInfoBll.GetInstence().CheckControlPower(this, "ButtonDeleteImage");
                }
                else
                {
                    ButtonDeleteImage.Visible = false;
                    imgClassImg.Visible = false;
                }
            }
            else
            {
                ButtonDeleteImage.Visible = false;
                imgClassImg.Visible = false;
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
        /// <summary>刪除圖片</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonDeleteImage_Click(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint0(hidId.Text);
            if (id > 0)
            {
                InformationClassBll.GetInstence().DelClassImg(this, id);

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

                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能為空！";
                }
                var sName = StringHelper.Left(txtName.Text, 20);
                if (InformationClassBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值
                //定義是否更新其他關聯表變量
                bool isUpdate = false;
                var oldParentId = ConvertHelper.Cint0(txtParent.Text);

                //獲取實體
                var model = new InformationClass(x => x.Id == id);
                //判斷是否有改變名稱
                if (id > 0 && sName != model.Name)
                {
                    isUpdate = true;
                }
                //修改時間與管理員
                model.UpdateDate = DateTime.Now;
                model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();

                //設置名稱
                model.Name = sName;
                //對應的父類id
                model.ParentId = oldParentId;
                //設置備註
                model.Notes = StringHelper.Left(txtNotes.Text, 100);

                //由於限制了編輯時不能修改父節點，所以這裡只對新建記錄時處理
                if (id == 0)
                {
                    //設定當前的深度與設定當前的層數級
                    if (model.ParentId == 0)
                    {
                        //設定當前的層數級
                        model.Depth = 0;
                        //父Id為0時，根Id也為0
                        model.RootId = 0;
                    }
                    else
                    {
                        //設定當前的層數
                        model.Depth = ConvertHelper.Cint0(InformationClassBll.GetInstence().GetFieldValue(ConvertHelper.Cint0(ddlParentId.SelectedValue),InformationClassTable.Depth)) + 1;
                        //獲取父類的父Id
                        model.RootId = ConvertHelper.Cint0(InformationClassBll.GetInstence().GetFieldValue(model.ParentId, InformationClassTable.ParentId));
                    }

                    //限制分類層數只能為3層
                    if (model.Depth > 3)
                    {
                        return "信息分類只能創建3層分類！";
                    }
                }

                //設置排序
                model.Sort = ConvertHelper.Cint0(txtSort.Text);
                if (model.Sort == 0)
                {
                    model.Sort = InformationClassBll.GetInstence().GetSortMax(model.ParentId) + 1;
                }

                //設定當前項是否顯示
                model.IsShow = ConvertHelper.StringToByte(rblIsShow.SelectedValue);
                //設定當前項是否單頁
                model.IsPage = ConvertHelper.StringToByte(rblIsPage.SelectedValue);

                //SEO
                model.SeoTitle = StringHelper.Left(txtSeoTitle.Text, 100);
                model.SeoKey = StringHelper.Left(txtSeoKey.Text, 100);
                model.SeoDesc = StringHelper.Left(txtSeoDesc.Text, 200);
                #endregion


                #region 上傳圖片
                //上傳分類大圖
                if (this.fuClassImg.HasFile && this.fuClassImg.FileName.Length > 3)
                {
                    int vid = 2; //2	信息(新聞)分類圖
                    //---------------------------------------------------
                    var upload = new UploadFile();
                    result = new UploadFileBll().Upload_AspNet(this.fuClassImg.PostedFile, vid, RndKey, OnlineUsersBll.GetInstence().GetManagerId(), OnlineUsersBll.GetInstence().GetManagerCName(), upload);
                    this.fuClassImg.Dispose();
                    //---------------------------------------------------
                    if (result.Length == 0)//上傳成功
                    {
                        model.ClassImg = upload.Path;
                    }
                    else
                    {
                        CommonBll.WriteLog("上傳出錯：" + result, null);//收集異常信息
                        return "上傳出錯！" + result;
                    }
                }
                //如果是修改，檢查用戶是否重新上傳過新圖片，如果是刪除舊的圖片
                if (model.Id > 0)
                {
                    UploadFileBll.GetInstence().Upload_DiffFile(InformationClassTable.Id, InformationClassTable.ClassImg, InformationClassTable.TableName, model.Id, model.ClassImg);

                    //同步UploadFile上傳表
                    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, InformationClassTable.TableName, model.Id);
                }

                #endregion


                //----------------------------------------------------------
                //存儲到數據庫
                InformationClassBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());

                #region 同步更新上傳圖片表綁定Id
                if (id == 0)
                {
                    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, InformationClassTable.TableName, model.Id);
                }

                #endregion
                
                //如果本次修改改變了相關名稱，則同步更新其他關聯表的對應名稱
                if (isUpdate)
                {
                    InformationBll.GetInstence().UpdateValue_For_InformationClass_Id(this, model.Id, InformationTable.InformationClass_Name, model.Name);
                    InformationBll.GetInstence().UpdateValue_For_InformationClass_Root_Id(this, model.Id, InformationTable.InformationClass_Root_Name, model.Name);
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