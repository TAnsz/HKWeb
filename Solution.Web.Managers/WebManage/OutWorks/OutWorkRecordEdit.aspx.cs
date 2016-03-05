using System;
using System.Collections.Generic;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System.Globalization;
using System.Linq;
using FineUI;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

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
                T_TABLE_DBll.GetInstence().BandDropDownList(this, ddlOutWorkRecord, T_TABLE_DTable.TABLES, "'Tral'", "'LEAV'");
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
                //從緩存中獲取指定ID的內容，如果不存在，則從數據庫獲取
                var model = OutWork_DBll.GetInstence().GetModelForCache(x => x.Id == id) ??
                            OutWork_DBll.GetInstence().GetModel(id, false);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                tbxEmp.Text = model.emp_id;
                txtEmpName.Text = EmployeeBll.GetInstence().GetEmpName(model.emp_id);
                txtDeptId.Text = model.depart_id;
                txtDept.Text = DepartsBll.GetInstence().GetDeptName(model.depart_id);
                hjId.Text = model.join_id + "";

                txtDays.Text = model.work_days.ToString();

                //開始時間與結束時間
                dpStartTime.SelectedDate = model.bill_date;
                dpEndTime.SelectedDate = model.Re_date;

                ddlType.SelectedValue = model.work_type;
                ddlOutWorkRecord.SelectedValue = model.leave_id;
                //顯示年假
                if (model.leave_id == "0001")
                {
                    DisplayAl(model.emp_id);
                }

                hchecker1.Text = model.checker;
                txtchecker.Text = EmployeeBll.GetInstence().GetEmpName(model.checker);
                hchecker2.Text = model.CHECKER2;
                txtchecker2.Text = EmployeeBll.GetInstence().GetEmpName(model.CHECKER2);

                cbIsCheck1.Checked = ConvertHelper.Cint0(model.audit) == 1;
                cbIsCheck2.Checked = ConvertHelper.Cint0(model.audit2) == 1;

                ButtonAccept.Text = model.audit == 1 ? "一級反審批" : "一級審批";
                ButtonAccept2.Text = model.audit2 == 1 ? "二級反審批" : "二級審批";
                //增加出差廠區無法一級反審核
                ButtonAccept.Enabled = !(model.audit == 1 && (model.leave_id == "1001" || model.leave_id == "1002" || model.leave_id == "1003"));

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
                ResolveFormField(!(model.audit == 0 && (model.op_user == OnlineUsersBll.GetInstence().GetManagerCName() || model.emp_id == OnlineUsersBll.GetInstence().GetManagerEmpId())));

                //顯示對應的界面元素
                DisplayTral(model.work_type, model.work_type);
            }
            else
            {
                var key = OnlineUsersBll.GetInstence().GetUserHashKey();
                var empid = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_LoginName).ToString();
                var model = EmployeeBll.GetInstence().GetModelForCache(x => x.EMP_ID == empid);
                tbxEmp.Text = empid;
                txtEmpName.Text = model.EMP_FNAME;
                hjId.Text = model.Id.ToString();
                hchecker1.Text = model.LINK_MAN;
                txtchecker.Text = EmployeeBll.GetInstence().GetEmpName(model.LINK_MAN);
                hchecker2.Text = model.CHECKER2;
                txtchecker2.Text = EmployeeBll.GetInstence().GetEmpName(model.CHECKER2);
                var depid = model.DEPART_ID;
                txtDeptId.Text = depid;
                txtDept.Text = DepartsBll.GetInstence().GetDeptName(depid);
            }
        }

        private void DisplayAl(string empId)
        {
            lbal1.Text = GetAlall(empId).ToString("F");
            lbal2.Text = GetAlyet(empId).ToString("F");
            lbal3.Text = (ConvertHelper.Cdecimal(lbal1.Text) - ConvertHelper.Cdecimal(lbal2.Text)).ToString("F");
            GPanelal.Hidden = false;
        }

        private decimal GetAlyet(string empId)
        {
            return OutWork_DBll.GetInstence().GetSum(new List<ConditionHelper.SqlqueryCondition>
            {
                new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.emp_id, Comparison.Equals,
                    empId),
                new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.leave_id, Comparison.Equals,
                    "0001"),
                new ConditionHelper.SqlqueryCondition(ConstraintType.And,
                    string.Format("Year({0})", OutWork_DTable.bill_date), Comparison.Equals,
                    dpStartTime.SelectedDate.HasValue ? dpStartTime.SelectedDate.Value.Year : DateTime.Now.Year)
            });
        }

        private decimal GetAlall(string empId)
        {
            return ConvertHelper.Cdecimal(ANNUALLEAVEBll.GetInstence()
                .GetFieldValue(ANNUALLEAVETable.DATA, x => x.EMP_ID == empId && x.YEARS == DateTime.Now.Year));
        }

        /// <summary>
        /// 處理是否顯示出差相關字段
        /// </summary>
        /// <param name="s">請假出差類型</param>
        /// <param name="t">時段</param>
        private void DisplayTral(string s, string t)
        {
            switch (s)
            {
                case "0001"://年假
                    string empid = tbxEmp.Text;
                    DisplayAl(empid);

                    break;
                case "1001": //出差番禺
                case "1002"://出差恩平
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
            var s = ddlOutWorkRecord.SelectedValue;
            DisplayTral(s, ddlType.SelectedValue);

            cbIsCheck1.Checked = s == "1001" || s == "1002" || s == "1003";

            //Paneltp.Hidden = ddlType.SelectedValue != "3";

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

            Paneltp.Hidden = ddlType.SelectedValue != "3";

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

                var empid = tbxEmp.Text.Trim();
                if (string.IsNullOrEmpty(empid))
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

                var days = ConvertHelper.Cdecimal(txtDays.Text) - ConvertHelper.Cdecimal(lbal3.Text);
                if (days > 0 && ddlOutWorkRecord.SelectedValue == "0001")
                {
                    ddlOutWorkRecord.SelectedValue = "0008";
                    return "年假申請超出" + days.ToString("F") + "天，已自動修改爲無薪假，請確認無誤后再保存！";
                }
                #endregion

                #region 賦值

                //獲取實體
                var model = new OutWork_D(x => x.Id == id)
                {
                    emp_id = empid,
                    join_id = ConvertHelper.Cint0(hjId.Text),
                    leave_id = ddlOutWorkRecord.SelectedValue,
                    depart_id = txtDeptId.Text,
                    memo = StringHelper.Left(txtMemo.Text, 100),
                    bill_date = dpStartTime.SelectedDate.Value.Date,
                    begin_time = tpStart.SelectedDate,
                    end_time = tpEnd.SelectedDate,
                    Re_date = dpEndTime.SelectedDate.Value.Date,
                    work_days = ConvertHelper.Cdecimal(txtDays.Text),
                    work_type = ddlType.SelectedValue,
                    checker = hchecker1.Text,
                    CHECKER2 = hchecker2.Text,
                    audit = (short?)(cbIsCheck1.Checked ? 1 : 0),
                    audit2 = (short?)(cbIsCheck2.Checked ? 1 : 0),
                    op_date = DateTime.Now,
                    op_user = OnlineUsersBll.GetInstence().GetManagerCName(),
                    transportation = RB1.SelectedValue,
                    hotel_type = RB2.SelectedValue,
                    outwork_type = ddlOutWorkRecord.SelectedValue[0] == '1' ? "tral" : "leav",
                    outwork_addr = txtRemark.Text,
                    Start_ag = ddlSt.SelectedValue,
                    re_ag = ddlRe.SelectedValue,
                    peers = ConvertHelper.Cint0(nbPeers.Text),
                    Hostel = ConvertHelper.Ctinyint(cbxHostel.Checked),
                    hotel = ConvertHelper.Cint0(nbhotel.Text),
                    Destination = txtA1.Text,
                    Destination2 = txtA2.Text,
                    Destination3 = txtA3.Text,
                    Destination4 = txtA4.Text,
                    IDate = txtB1.Text,
                    IDate2 = txtB2.Text,
                    IDate3 = txtB3.Text,
                    IDate4 = txtB4.Text,
                    Nights = txtC1.Text,
                    Nights2 = txtC2.Text,
                    Nights3 = txtC3.Text,
                    Nights4 = txtC4.Text
                };

                //生成流水號
                if (string.IsNullOrEmpty(hbillId.Text))
                {
                    model.bill_id = GetSerialNumber();
                }

                #endregion

                //------------------------------------------
                //判斷當前申請是否重複
                result = OutWork_DBll.GetInstence().IsRepetition(model);
                if (result == null)
                {
                    //----------------------------------------------------------
                    //存儲到數據庫
                    OutWork_DBll.GetInstence().Save(this, model);
                    //發送郵件
                    if (id == 0) OutWork_DBll.GetInstence().SendMail(this, model);
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
            if (ddlOutWorkRecord.Readonly)
            {
                return;
            }
            Window2.IFrameUrl = "/WebManage/Systems/Pop/EmpSimpleChoose.aspx?" + MenuInfoBll.GetInstence().PageUrlEncryptString();
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
            //傳入需要修改后的值
            int value = cbIsCheck1.Checked ? 0 : 1;
            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                FineUI.Alert.ShowInParent("請先保存記錄。", FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = OutWork_DBll.GetInstence().Accept1(this, id, value);
            FineUI.Alert.ShowInParent(
                !string.IsNullOrEmpty(ret) ? ret : string.Format("一級{0}審批成功", value == 0 ? "反" : ""),
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
            int value = cbIsCheck1.Checked ? 0 : 1;
            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                FineUI.Alert.ShowInParent("請先保存記錄。", FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = OutWork_DBll.GetInstence().Accept2(this, id, value);
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
            if (!dpEndTime.SelectedDate.HasValue)
            {
                dpEndTime.SelectedDate = dpStartTime.SelectedDate;
            }
            //計算天數
            GetDays();
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
        public void ResolveFormField(bool b)
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
                    hchecker1.Text = model.LINK_MAN;
                    txtchecker.Text = EmployeeBll.GetInstence().GetEmpName(model.LINK_MAN);
                    hchecker2.Text = model.CHECKER2;
                    txtchecker2.Text = EmployeeBll.GetInstence().GetEmpName(model.CHECKER2);
                }
            }
        }
        #endregion

        #region 生成流水號

        protected string GetSerialNumber()
        {
            var str = new SelectHelper().GetMax<OutWork_D>(OutWork_DTable.bill_id).ToString();
            string headDate = str.Substring(0, 6);
            int lastNumber = int.Parse(str.Substring(6));
            //如果数据库最大值流水号中日期和生成日期在同一月，则顺序号加1
            if (headDate == DateTime.Now.ToString("yyyyMMdd"))
            {
                lastNumber++;
                return headDate + lastNumber.ToString("0000");
            }
            else
            {
                return DateTime.Now.Date.ToString("yyyymmdd") + "0001";
            }
        }
        #endregion




    }
}