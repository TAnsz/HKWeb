using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System.Globalization;
using System.Linq;
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
                tbxEmp.Text = model.emp_id;
                txtEmpName.Text = EmployeeBll.GetInstence().GetEmpName(model.emp_id);
                txtDeptId.Text = model.depart_id;
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

                ButtonAccept2.Enabled = !string.IsNullOrEmpty(model.CHECKER2);

                RB1.SelectedValue = model.transportation;
                RB2.SelectedValue = model.hotel_type;

                txtRemark.Text = model.outwork_addr;

                ddlSt.SelectedValue = model.Start_ag;
                ddlRe.SelectedValue = model.re_ag;

                nbPeers.Text = model.peers.ToString();
                cbxHostel.Checked = model.Hostel == 1;
                nbhotel.Text = model.hotel.ToString();

                txtA1.Text = model.Destination;
                txtA2.Text = model.Destination2;
                txtA3.Text = model.Destination3;
                txtA4.Text = model.Destination4;

                txtB1.Text = model.IDate;
                txtB2.Text = model.IDate2;
                txtB3.Text = model.IDate3;
                txtB4.Text = model.IDate4;

                txtC1.Text = model.Nights;
                txtC2.Text = model.Nights2;
                txtC3.Text = model.Nights3;
                txtC4.Text = model.Nights4;

                txtMemo.Text = model.memo;

                //判斷能否修改
                ResolveFormField(!(model.op_user == OnlineUsersBll.GetInstence().GetManagerEmpId() && model.audit == 0));

                //顯示對應的界面元素
                DisplayTral(model.work_type, model.work_type);
            }
        }

        /// <summary>
        /// 處理是否顯示出差相關字段
        /// </summary>
        /// <param name="s">請假出差類型</param>
        /// <param name="t">時段</param>
        private void DisplayTral(string s,string t)
        {
            switch (s)
            {
                case "1001":
                case "1002":
                    GP1.Hidden = false;
                    Paneltrl1.Hidden = false;
                    Form2.Hidden = true;
                    break;
                case "1003":
                    GP1.Hidden = true;
                    break;
                case "1004":
                    GP1.Hidden = false;
                    Paneltrl1.Hidden = true;
                    Form2.Hidden = false;
                    break;
                default:
                    GP1.Hidden = true;
                    break;
            }
            Paneltp.Hidden = t != "3";
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
            //int id = ConvertHelper.Cint0(ddlOutWorkRecord.SelectedValue);
            //if (id == 0) return;
            DisplayTral(ddlOutWorkRecord.SelectedValue,ddlType.SelectedValue);

            Paneltp.Hidden = ddlType.SelectedValue != "3";

            var lt = ddlType.Items.FindByValue("3");

            if (lt != null && !string.IsNullOrEmpty(ddlOutWorkRecord.SelectedValue))
            {
                lt.EnableSelect = ddlOutWorkRecord.SelectedValue[0] != '0';
            }
            //var model = OutWork_DBll.GetInstence().GetModelForCache(id);
            //if (model != null)
            //{
            //    //修改Key
            //    ddlOutWorkRecord.SelectedValue = model.leave_id;
            //}
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlOutWorkRecord.SelectedValue)) return;
            if (string.IsNullOrEmpty(ddlType.SelectedValue)) return;
            
            //計算天數
            GetDays();

            //int id = ConvertHelper.Cint0(ddlType.SelectedValue);
            //if (id == 0) return;

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
            string result;
            int id = ConvertHelper.Cint0(hidId.Text);

            try
            {
                #region 數據驗證

                if (string.IsNullOrEmpty(tbxEmp.Text.Trim()))
                {
                    return tbxEmp.Label + "不能為空！";
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
                model.emp_id = tbxEmp.Text;
                model.leave_id = ddlOutWorkRecord.SelectedValue;
                model.depart_id = txtDeptId.Text;
                //model.Url = StringHelper.Left(txtUrl.Text, 200, true, false);
                //說明
                model.memo = StringHelper.Left(txtMemo.Text, 100);


                //開始時間與結束時間
                model.bill_date = dpStartTime.SelectedDate ?? DateTime.Now.Date;
                model.Re_date = dpEndTime.SelectedDate ?? DateTime.Now.Date.AddDays(1);

                model.work_days = ConvertHelper.Cdecimal(txtDays.Text);
                model.work_type = ddlType.SelectedValue;

                model.audit = ConvertHelper.Ctinyint(cbIsCheck1.Checked);
                model.audit2 = ConvertHelper.Ctinyint(cbIsCheck2.Checked);

                //修改時間與用戶
                model.op_date = DateTime.Now;
                //model.op_user = OnlineUsersBll.GetInstence().GetManagerId();
                model.op_user = OnlineUsersBll.GetInstence().GetManagerCName();

                model.transportation = RB1.SelectedValue;
                model.hotel_type = RB2.SelectedValue;

                model.outwork_addr = txtRemark.Text;

                model.Start_ag = ddlSt.SelectedValue;
                model.re_ag = ddlRe.SelectedValue;

                model.peers = ConvertHelper.Cint0(nbPeers.Text);
                model.Hostel = ConvertHelper.Ctinyint(cbxHostel.Checked);
                model.hotel = ConvertHelper.Cint0(nbhotel.Text);

                model.Destination = txtA1.Text;
                model.Destination2 = txtA2.Text;
                model.Destination3 = txtA3.Text;
                model.Destination4 = txtA4.Text;

                model.IDate = txtB1.Text;
                model.IDate2 = txtB2.Text;
                model.IDate3 = txtB3.Text;
                model.IDate4 = txtB4.Text;

                model.Nights = txtC1.Text;
                model.Nights2 = txtC2.Text;
                model.Nights3 = txtC3.Text;
                model.Nights4 = txtC4.Text;

                #endregion

                //------------------------------------------
                //判斷當前申請是否重複
                result = OutWork_DBll.GetInstence().IsRepetition(model);
                if (result == null)
                {
                    //----------------------------------------------------------
                    //存儲到數據庫
                    OutWork_DBll.GetInstence().Save(this, model);
                    //清空字段修改標記
                    PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
                    //這裡放置清空前端頁面緩存的代碼（如果前端使用了頁面緩存的話，必須進行清除操作）
                }
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

        #region 員工選擇
        /// <summary>
        /// 彈出員工選擇界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbxEmp_TriggerClick(object sender, EventArgs e)
        {
            Window2.IFrameUrl = "/WebManage/Systems/Pop/EmpChoose.aspx?Selection=1&" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window2.Hidden = false;
        }
        #endregion

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
                FineUI.Alert.ShowInParent("請先保存記錄。", FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = OutWork_DBll.GetInstence().Accept(this, id, value, OutWork_DBll.check1);
            FineUI.Alert.ShowInParent(
                !string.IsNullOrEmpty(ret) ? ret : string.Format("二級{0}審批成功", value == 0 ? "反" : ""),
                FineUI.MessageBoxIcon.Information);
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
                FineUI.Alert.ShowInParent("請先保存記錄。", FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = OutWork_DBll.GetInstence().Accept(this, id, value, OutWork_DBll.check2);
            FineUI.Alert.ShowInParent(
                !string.IsNullOrEmpty(ret) ? ret : string.Format("二級{0}審批成功", value == 0 ? "反" : ""),
                FineUI.MessageBoxIcon.Information);
            LoadData();
        }

        /// <summary>
        /// 開始日期改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dpStartTime_TextChanged(object sender, EventArgs e)
        {
            if (dpEndTime.SelectedDate.HasValue)
            {
                dpEndTime.SelectedDate = dpStartTime.SelectedDate;
            }
            else
            {
                //計算天數
                GetDays();
            }
        }

        /// <summary>
        /// 結束日期改變事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dpEndTime_TextChanged(object sender, EventArgs e)
        {
            //計算天數
            GetDays();
        }

        /// <summary>
        /// 計算出天數 通過開始結束日期和 時段 上下午表示半天
        /// </summary>
        private void GetDays()
        {
            double d = 0;
            if (dpStartTime.SelectedDate.HasValue && dpEndTime.SelectedDate.HasValue)
            {
                switch (ddlType.SelectedValue)
                {
                    case "0":
                        d = (dpEndTime.SelectedDate.Value - dpStartTime.SelectedDate.Value).Days + 1;
                        break;
                    case "1":
                    case "2":
                        d = (dpEndTime.SelectedDate.Value - dpStartTime.SelectedDate.Value).Days + 0.5;
                        break;
                    default:
                        if (tpStart.SelectedDate.HasValue && tpEnd.SelectedDate.HasValue)
                        {
                            //默認一天八個工時
                            d = (dpEndTime.SelectedDate.Value - dpStartTime.SelectedDate.Value).Days + (tpEnd.SelectedDate.Value - tpStart.SelectedDate.Value).Minutes / 480;
                        }
                        break;
                }
                txtDays.Text = d.ToString(CultureInfo.InvariantCulture);
            }
        }
        #region 修改表單衹讀屬性

        /// <summary>
        /// 修改表單所有屬性
        /// </summary>
        private void ResolveFormField(bool b)
        {
            foreach (var field in extForm1.Rows.SelectMany(row => row.Items, (row, controlBase) => controlBase).Where(field => field is Field).Cast<Field>())
            {
                field.Readonly = b;
            }
        }

        #endregion

        #endregion

        #region 子窗口關閉事件
        /// <summary>
        /// 關閉子窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument.StartsWith("Emp="))
            {
                string provinceName = e.CloseArgument.Substring("Emp=".Length);
                tbxEmp.Text = provinceName.Trim();
                var model = EmployeeBll.GetInstence().GetModelForCache(x => x.EMP_ID == tbxEmp.Text);
                if (model != null)
                {
                    txtEmpName.Text = model.EMP_FNAME;
                    var depid = model.DEPART_ID;
                    txtDeptId.Text = depid;
                    txtDept.Text = DepartsBll.GetInstence().GetDeptName(depid);
                }
            }
        }
        #endregion

    }
}