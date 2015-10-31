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
 *   文件名稱：UploadTypeEdit.aspx.cs
 *   描    述：上傳類型編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Set
{
    public partial class UploadTypeEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

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
                var model = UploadTypeBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //名稱
                txtName.Text = model.Name;
                //關鍵字
                txtTypeKey.Text = model.TypeKey;
                //編輯時，關鍵字不能修改
                txtTypeKey.Enabled = false;
                //綁定擴展名
                txtExt.Text = model.Ext;
                //是否系統默認
                //rblIsSys.SelectedValue = model.IsSys + "";
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
                if (UploadTypeBll.GetInstence().Exist(x => x.Name == sName && x.Id != id))
                {
                    return txtName.Label + "已存在！請重新輸入！";
                }
                if (string.IsNullOrEmpty(txtTypeKey.Text.Trim()))
                {
                    return txtTypeKey.Label + "不能為空！";
                }
                if (string.IsNullOrEmpty(txtExt.Text.Trim()))
                {
                    return txtExt.Label + "不能為空！";
                }

                #endregion

                #region 賦值
                //獲取實體
                var model = new UploadType(x => x.Id == id);

                //系統默認
                //model.IsSys = ConvertHelper.StringToByte(rblIsSys.SelectedValue);

                //判斷是否有改變關鍵字
                var sTypeKey = StringHelper.Left(txtTypeKey.Text, 20);
                if (id > 0 && model.IsSys == 1 && sTypeKey != model.TypeKey)
                {
                    return "當前記錄為系統默認，不能修改關鍵字！";
                }

                //設置名稱
                model.Name = sName;
                //設置關鍵字
                model.TypeKey = sTypeKey;
                //擴展名
                model.Ext = StringHelper.Left(txtExt.Text, 0);
                
                //修改時間與管理員
                model.UpdateDate = DateTime.Now;
                model.Manager_Id = OnlineUsersBll.GetInstence().GetManagerId();
                model.Manager_CName = OnlineUsersBll.GetInstence().GetManagerCName();
                
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                UploadTypeBll.GetInstence().Save(this, model);
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