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
 *   創建日期：2014-07-10
 *   文件名稱：ActiveFileEdit.aspx.cs
 *   描    述：廣告編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.ActiveFiles
{
    public partial class ActiveFileEdit : PageBase
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
                //廣告位置下拉框
                ActiveFileClassBll.GetInstence().BandDropDownListShowAll(this, ddlActiveFileClass);

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
                var model = ActiveFileBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtName.Text = model.Name;
                //Key是不能修改的，同一個位置的Key值一樣
                txtKeyword.Text = model.Keyword;
                txtKeyword.Readonly = true;
                filePhoto.EmptyText = model.Url;
                txtContent.Text = model.Content;

                ddlActiveFileClass.SelectedValue = model.ActiveFileClass_Id + "";
                rblIsDisplay.SelectedValue = model.IsDisplay + "";
                txtSort.Text = model.Sort + "";
            }
        }

        #endregion

        #region 頁面控件綁定功能

        #region 下拉列表改變事件
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlActiveFileClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint0(ddlActiveFileClass.SelectedValue);
            if (id == 0) return;

            var model = ActiveFileClassBll.GetInstence().GetModelForCache(id);
            if (model != null)
            {
                //修改Key
                txtKeyword.Text = model.Keyword;
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
                //ActiveFileBll.GetInstence().DelAdImg(this, id);

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
                //判斷是否重複
                var sName = StringHelper.Left(txtName.Text, 50);
                if (ActiveFileBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }
                if (ddlActiveFileClass.SelectedValue == "0")
                {
                    return ddlActiveFileClass.Label + "為必選項，請選擇！";
                }


                #endregion

                #region 賦值

                //獲取實體
                var model = new ActiveFile(x => x.Id == id);

                //------------------------------------------
                //設置名稱
                model.Name = sName;
                model.Keyword = StringHelper.Left(txtKeyword.Text, 50);
                //說明
                model.Content = StringHelper.Left(txtContent.Text, 100);
                //取得位置
                model.ActiveFileClass_Id = ConvertHelper.Cint0(ddlActiveFileClass.SelectedValue);
                model.ActiveFileClass_Name = StringHelper.Left(ddlActiveFileClass.SelectedText, 50);


                //設定當前項是否顯示
                model.IsDisplay = ConvertHelper.StringToByte(rblIsDisplay.SelectedValue);

                model.Sort = ConvertHelper.Cint0(txtSort.Text); ;

                //修改時間與用戶
                model.UpdateDate = DateTime.Now;
                model.Employee_EmpId = OnlineUsersBll.GetInstence().GetManagerEmpId();
                model.Employee_CName = OnlineUsersBll.GetInstence().GetManagerCName();

                #endregion
                #region 上傳文件
                //判斷前端的ASP.NET上傳控件是否選擇有上傳文件
                if (this.filePhoto.HasFile && this.filePhoto.FileName.Length > 3)
                {
                    //將當前頁面上傳文件綁定上傳配置表Id為7的記錄，給上傳組件的邏輯層函數調用
                    int vid = 5; //7	文件
                    //---------------------------------------------------
                    //創建上傳實體
                    var upload = new UploadFile();
                    //調用ASP.NET上傳控件上傳函數，並獲取上傳成功或失敗信息
                    result = new UploadFileBll().Upload_AspNet(this.filePhoto.PostedFile, vid, RndKey,
                        OnlineUsersBll.GetInstence().GetManagerId(), OnlineUsersBll.GetInstence().GetManagerCName(),
                        upload);
                    this.filePhoto.Dispose();
                    //---------------------------------------------------
                    //沒有返回信息時表示上傳成功
                    if (result.Length == 0)
                    {
                        //將上傳到服務器後的路徑賦給廣告實體對應字段
                        model.Url = upload.Path;
                    }
                    else
                    {
                        //將出錯寫入日誌中
                        CommonBll.WriteLog("上傳出錯：" + result); //收集異常信息
                        //彈出出錯提示
                        return "上傳出錯！" + result;
                    }
                }
                //如果是修改，檢查用戶是否重新上傳過廣告圖片，如果是刪除舊的圖片
                if (model.Id > 0)
                {
                    //刪除舊圖片
                    UploadFileBll.GetInstence()
                        .Upload_DiffFile(ActiveFileTable.Id, ActiveFileTable.Url, ActiveFileTable.TableName,
                            model.Id, model.Url);

                    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, ActiveFileTable.TableName, model.Id);
                }

                #endregion
                //------------------------------------------

                //----------------------------------------------------------
                //存儲到數據庫
                ActiveFileBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());

                #region 同步更新上傳圖片表綁定Id
                if (id == 0)
                {
                    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, ActiveFileTable.TableName, model.Id);
                }

                #endregion
                //這裡放置清空前端頁面緩存的代碼（如果前端使用了頁面緩存的話，必須進行清除操作）


            }
            catch (Exception e)
            {
                result = "保存失敗！";

                //出現異常，保存出錯日誌廣告
                CommonBll.WriteLog(result, e);
            }

            return result;
        }
        #endregion
    }
}