using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System.Collections.Generic;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;
using FineUI;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-07-10
 *   文件名稱：OutWorkRecordEdit.aspx.cs
 *   描    述：編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.OutWorks
{
    public partial class OutWorkRecordEdit : PageBase
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
                T_TABLE_DBll.GetInstence().BandDropDownList(this, ddlOutWorkRecord, T_TABLE_DTable.TABLES, "'LEAV'", "'TRAL'");
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
                var model = OutWork_DBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtEmpId.Text = model.emp_id;
                txtEmpName.Text = EmployeeBll.GetInstence().GetEmpName(model.emp_id);
                txtDept.Text = DepartsBll.GetInstence().GetDeptName(model.depart_id);

                txtDays.Text = model.work_days.ToString();

                //開始時間與結束時間
                dpStartTime.SelectedDate = model.bill_date;
                dpEndTime.SelectedDate = model.Re_date;

                ddlType.SelectedValue = model.work_type;
                ddlOutWorkRecord.SelectedValue = model.leave_id;

                txtchecker.Text = EmployeeBll.GetInstence().GetEmpName(model.checker);
                txtchecker2.Text = EmployeeBll.GetInstence().GetEmpName(model.CHECKER2);

                cbIsCheck1.Checked = model.audit == 1;
                cbIsCheck2.Checked = model.audit2 == 1;

                ButtonAccept.Text = model.audit == 1 ? "一級反審批" : "一級審批";
                ButtonAccept2.Text = model.audit2 == 1 ? "二級反審批" : "二級審批";

                txtMemo.Text = model.memo;

                //判斷能否修改
                ResolveFormField(!(model.op_user == OnlineUsersBll.GetInstence().GetManagerEmpId() && model.audit == 0));

            }
        }



        #endregion

        #region 頁面控件綁定功能

        #region 下拉列表改變事件
        /// <summary>下拉列表改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlOutWorkRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint0(ddlOutWorkRecord.SelectedValue);
            if (id == 0) return;

            //var model = OutWork_DBll.GetInstence().GetModelForCache(id);
            //if (model != null)
            //{
            //    //修改Key
            //    ddlOutWorkRecord.SelectedValue = model.leave_id;
            //}
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ConvertHelper.Cint0(ddlType.SelectedValue);
            if (id == 0) return;

            //var model = OutWork_DBll.GetInstence().GetModelForCache(id);
            //if (model != null)
            //{

            //    txtKeyword.Text = model.bill_id;
            //}
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

                if (string.IsNullOrEmpty(txtEmpId.Text.Trim()))
                {
                    return txtEmpId.Label + "不能為空！";
                }
                //判斷是否重複
                //var sName = StringHelper.Left(txtName.Text, 50);
                //if (OutWork_DBll.GetInstence().Exist(x => x.bill_id == sName && x.Id != id))
                //{
                //    return txtName.Label + "已存在！請重新輸入！";
                //}
                if (ddlOutWorkRecord.SelectedValue == "0")
                {
                    return ddlOutWorkRecord.Label + "為必選項，請選擇！";
                }

                if (dpStartTime.SelectedDate == null || TimeHelper.IsDateTime(dpStartTime.SelectedDate) == false)
                {
                    return "請選擇" + dpStartTime.Label;
                }
                if (dpEndTime.SelectedDate == null || TimeHelper.IsDateTime(dpEndTime.SelectedDate) == false)
                {
                    return "請選擇" + dpEndTime.Label;
                }
                if (dpStartTime.SelectedDate > dpEndTime.SelectedDate)
                {
                    return dpStartTime.Label + "不能大於" + dpEndTime.Label;
                }

                #endregion

                #region 賦值

                //獲取實體
                var model = new OutWork_D(x => x.Id == id);

                //------------------------------------------
                //設置名稱
                model.emp_id = txtEmpId.Text;
                model.leave_id = ddlOutWorkRecord.SelectedValue;
                //model.Url = StringHelper.Left(txtUrl.Text, 200, true, false);
                //說明
                model.memo = StringHelper.Left(txtMemo.Text, 100);


                //開始時間與結束時間
                model.bill_date = dpStartTime.SelectedDate ?? DateTime.Now.Date;
                model.Re_date = dpEndTime.SelectedDate ?? DateTime.Now.Date.AddDays(1);

                model.work_days = ConvertHelper.Cdecimal(txtDays.Text, 0);
                model.work_type = ddlType.SelectedValue;

                model.audit = ConvertHelper.Ctinyint(cbIsCheck1.Checked);
                model.audit2 = ConvertHelper.Ctinyint(cbIsCheck2.Checked);

                //修改時間與用戶
                model.op_date = DateTime.Now;
                //model.op_user = OnlineUsersBll.GetInstence().GetManagerId();
                model.op_user = OnlineUsersBll.GetInstence().GetManagerCName();

                #endregion

                //------------------------------------------
                //清空字段修改標記
                PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());

                #endregion


                //----------------------------------------------------------
                //存儲到數據庫
                OutWork_DBll.GetInstence().Save(this, model);

                #region 同步更新上傳圖片表綁定Id
                //if (id == 0)
                //{
                //    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                //    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, OutWorkRecordTable.TableName, model.Id);
                //}

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

        #region 按鍵事件
        /// <summary>
        /// 一級審批
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAccept_Click(object sender, EventArgs e)
        {
            //獲取ID，調用審批函數
            int id = ConvertHelper.Cint0(hidId.Text);
            int value = ConvertHelper.Cint0(cbIsCheck1.Checked);
            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                string result = "請先保存記錄。";
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = OutWork_DBll.GetInstence().Accept(this, id, value, OutWork_DBll.check1);
            if (!String.IsNullOrEmpty(ret))
            {
                FineUI.Alert.ShowInParent(ret, FineUI.MessageBoxIcon.Information);
            }
            else
            {
                FineUI.Alert.ShowInParent(string.Format("二級{0}審批成功", value == 0 ? "反" : ""), FineUI.MessageBoxIcon.Information);
            }
            LoadData();
        }
        /// <summary>
        /// 二級審批
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAccept2_Click(object sender, EventArgs e)
        {
            //獲取ID，調用審批函數
            int id = ConvertHelper.Cint0(hidId.Text);
            int value = ConvertHelper.Cint0(cbIsCheck2.Checked);
            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                string result = "請先保存記錄。";
                FineUI.Alert.ShowInParent(result, FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = OutWork_DBll.GetInstence().Accept(this, id, value, OutWork_DBll.check2);
            if (!String.IsNullOrEmpty(ret))
            {
                FineUI.Alert.ShowInParent(ret, FineUI.MessageBoxIcon.Information);
            }
            else
            {
                FineUI.Alert.ShowInParent(string.Format("二級{0}審批成功", value == 0 ? "反" : ""), FineUI.MessageBoxIcon.Information);
            }
            LoadData();
        }


        #region 修改表單衹讀屬性
        /// <summary>
        /// 修改表單所有屬性
        /// </summary>
        /// <param name="process"></param>
        private void ResolveFormField(bool b)
        {
            foreach (FormRow row in extForm1.Rows)
            {
                foreach (Field field in row.Items)
                {
                    if (field != null && !(field is Label))
                    {
                        field.Readonly=b;
                    }
                }
            }
        }
        #endregion

        #endregion

    }
}