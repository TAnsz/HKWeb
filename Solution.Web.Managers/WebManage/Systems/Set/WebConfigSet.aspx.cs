using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;


/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-24
 *   文件名稱：WebConfigEdit.aspx.cs
 *   描    述：系統配置編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Systems.Set
{
    public partial class WebConfigSet : PageBase
    {
        private int id = 1;

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            //獲取指定ID的系統配置內容
            var model = WebConfigBll.GetInstence().GetModelForCache(x => x.Id == id);
            if (model == null)
                return;

            txtWebName.Text = model.WebName;
            txtWebDomain.Text = model.WebDomain;
            txtWebEmail.Text = model.WebEmail;

            //--------------------------------------------
            txtLoginLogReserveTime.Text = model.LoginLogReserveTime + "";
            txtUseLogReserveTime.Text = model.UseLogReserveTime + "";

            //--------------------------------------------
            txtEmailSmtp.Text = model.EmailSmtp;
            txtEmailUserName.Text = model.EmailUserName;
            txtEmailPassWord.Text = model.EmailPassWord;
            
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

            try
            {
                #region 賦值

                //獲取實體
                var model = new WebConfig(x => x.Id == id);
                model.WebName = StringHelper.Left(txtWebName.Text, 50);
                model.WebDomain = StringHelper.Left(txtWebDomain.Text, 50, true, false);
                model.WebEmail = StringHelper.Left(txtWebEmail.Text, 50, true, false);

                model.LoginLogReserveTime = ConvertHelper.Cint0(txtLoginLogReserveTime.Text);
                model.UseLogReserveTime = ConvertHelper.Cint0(txtUseLogReserveTime.Text);

                model.EmailSmtp = StringHelper.Left(txtEmailSmtp.Text, 50, true, false);
                model.EmailUserName = StringHelper.Left(txtEmailUserName.Text, 50);
                model.EmailPassWord = StringHelper.Left(txtEmailPassWord.Text, 50, true, false);

                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                WebConfigBll.GetInstence().Save(this, model);

                //------------------------------------
                //測試郵件發送服務
                if (chkSendTest.Checked && model.EmailSmtp.Length > 0 && model.EmailUserName.Length > 0)
                {
                    var oMail = new MailBll();
                    string ss = oMail.TestMail("shaozhong.tan@py.kamhingintl.com");

                    if (ss.Length > 0)
                    {
                        return ("出錯！" + ss);
                    }
                    else
                    {
                        return ("發送成功！");
                    }
                }
                return "修改成功！";
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