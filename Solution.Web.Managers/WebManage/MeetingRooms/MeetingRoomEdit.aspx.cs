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
 *   文件名稱：MeetingRoomEdit.aspx.cs
 *   描    述：會議室編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.MeetingRooms
{
    public partial class MeetingRoomEdit : PageBase
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
                //獲取指定ID的菜單內容
                var model = MeetingRoomBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtCode.Text = model.Code;
                txtName.Text = model.Name;

                txtQty.Text = model.Qty.ToString();
                txtAddress.Text = model.Address;
                txtRemark.Text = model.Remark;
               
                //設置是否有效
                rblIsVaild.SelectedValue = model.IsVaild + "";
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
                if (string.IsNullOrEmpty(txtCode.Text.Trim()))
                {
                    return txtCode.Label + "不能為空！";
                }
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    return txtName.Label + "不能為空！";
                }
                var sName = StringHelper.Left(txtName.Text, 50);
                var sCode = StringHelper.Left(txtCode.Text, 100);
                if (MeetingRoomBll.GetInstence().Exist(x => (x.Code == sCode ||x.Name==sName) && x.Id != id))
                {
                    return txtCode.Label + "或" + txtName.Label + "已存在！請重新輸入！";
                }

                #endregion

                #region 賦值
                //獲取實體
                var model = new MeetingRoom(x => x.Id == id);

                //設置名稱
                model.Code = sCode;
                model.Name = sName;
                //地址
                model.Qty = ConvertHelper.Cint0(txtQty.Text);
                model.Address = txtAddress.Text;
                model.Remark = txtRemark.Text;

                //設定當前項是否顯示
                model.IsVaild = ConvertHelper.StringToByte(rblIsVaild.SelectedValue);
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                MeetingRoomBll.GetInstence().Save(this, model);

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