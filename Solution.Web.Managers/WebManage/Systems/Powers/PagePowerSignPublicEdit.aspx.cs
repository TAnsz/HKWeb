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
 *   創建日期：2014-06-21
 *   文件名稱：PagePowerSignPublicEdit.aspx.cs
 *   描    述：公用頁面權限標識編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Powers
{
    public partial class PagePowerSignPublicEdit : PageBase
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
                var model = PagePowerSignPublicBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //控件名稱
                txtCName.Text = model.CName;
                //英文名稱
                txtEName.Text = model.EName;
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

                if (string.IsNullOrEmpty(txtCName.Text.Trim()))
                {
                    return txtCName.Label + "不能為空！";
                }
                var sName = StringHelper.Left(txtCName.Text, 20);
                if (PagePowerSignPublicBll.GetInstence().Exist(x => x.CName == sName && x.Id != id))
                {
                    return txtCName.Label + "已存在！請重新輸入！";
                }
                if (string.IsNullOrEmpty(txtEName.Text.Trim()))
                {
                    return txtEName.Label + "不能為空！";
                }
                var sEname = StringHelper.Left(txtEName.Text, 50);
                if (PagePowerSignPublicBll.GetInstence().Exist(x => x.EName == sEname && x.Id != id))
                {
                    return txtEName.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值
                //定義是否更新標識——即當前記錄的名稱是否改變了
                bool isUpdate = false;

                //獲取實體
                var model = new PagePowerSignPublic(x => x.Id == id);

                //判斷是否有改變名稱
                if (id > 0 && (sName != model.CName || sEname != model.EName))
                {
                    isUpdate = true;
                }

                //設置名稱
                model.CName = sName;
                //設置英文名稱
                model.EName = sEname;
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                PagePowerSignPublicBll.GetInstence().Save(this, model);
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
                //判斷是否需要同步更新關聯表字段
                if (isUpdate)
                {
                    //調用更新函數，同步更新對應的所有記錄
                    PagePowerSignBll.GetInstence().UpdateValue_For_PagePowerSignPublic_Id(this, model.Id, PagePowerSignTable.CName, model.CName, PagePowerSignTable.EName, model.EName);
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