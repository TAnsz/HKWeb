using System;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.Logic.Managers;
using Solution.Web.Managers.WebManage.Application;
using System.Linq;
using FineUI;
using Solution.DataAccess.DbHelper;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-07-10
 *   文件名稱：adJustRest_DEdit.aspx.cs
 *   描    述：編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.adJustRests
{
    public partial class adJustRest_DEdit : PageBase
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
                T_TABLE_DBll.GetInstence().BandDropDownList(this, ddladJustRest_D, T_TABLE_DTable.TABLES, "'ADJU'");
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
                var model = adJustRest_DBll.GetInstence().GetModelForCache(x => x.Id == id)??adJustRest_DBll.GetInstence().GetModel(id,false);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                tbxEmp.Text = model.emp_id;
                txtEmpName.Text = EmployeeBll.GetInstence().GetEmpName(model.emp_id);
                txtDeptId.Text = model.depart_id;
                txtDept.Text = DepartsBll.GetInstence().GetDeptName(model.depart_id);

                hbillId.Text = model.bill_id;
                //txtDays.Text = model.all_day.ToString();

                //開始時間與結束時間
                dpStartTime.SelectedDate = model.ori_date;
                dpEndTime.SelectedDate = model.rest_date;

                ddlType.SelectedValue = model.all_day.ToString();
                ddladJustRest_D.SelectedValue = model.kind;

                hchecker1.Text = model.checker;
                txtchecker.Text = EmployeeBll.GetInstence().GetEmpName(model.checker);
                hchecker2.Text = model.CHECKER2;
                txtchecker2.Text = EmployeeBll.GetInstence().GetEmpName(model.CHECKER2);

                cbIsCheck1.Checked = ConvertHelper.Cint0(model.audit) == 1;
                cbIsCheck2.Checked = ConvertHelper.Cint0(model.audit2) == 1;

                ButtonAccept.Text = model.audit == 1 ? "一級反審批" : "一級審批";
                ButtonAccept2.Text = model.audit2 == 1 ? "二級反審批" : "二級審批";

                txtMemo.Text = model.memo;

                //判斷能否修改
                ResolveFormField(!(model.audit == 0 && (model.op_user == OnlineUsersBll.GetInstence().GetManagerCName() || model.emp_id == OnlineUsersBll.GetInstence().GetManagerEmpId())));

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



        #endregion

        #region 頁面控件綁定功能

        #region 下拉列表改變事件
 

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
                //if (adJustRest_DBll.GetInstence().Exist(x => x.bill_id == sName && x.Id != id))
                //{
                //    return txtName.Label + "已存在！請重新輸入！";
                //}
                if (ddladJustRest_D.SelectedValue == "0")
                {
                    return ddladJustRest_D.Label + "為必選項，請選擇！";
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
                var model = new adJustRest_D(x => x.Id == id)
                {
                    emp_id = tbxEmp.Text,
                    join_id = ConvertHelper.Cint0(hjId.Text),
                    depart_id = txtDeptId.Text,
                    kind = ddladJustRest_D.SelectedValue,
                    memo = StringHelper.Left(txtMemo.Text, 100),
                    ori_date = dpStartTime.SelectedDate.Value.Date,
                    rest_date = dpEndTime.SelectedDate.Value.Date,
                    all_day = ConvertHelper.Ctinyint(ddlType.SelectedValue),
                    checker = hchecker1.Text,
                    CHECKER2 = hchecker2.Text,
                    audit = (short?)(cbIsCheck1.Checked ? 1 : 0),
                    audit2 = (short?)(cbIsCheck2.Checked ? 1 : 0),
                    op_date = DateTime.Now,
                    op_user = OnlineUsersBll.GetInstence().GetManagerCName()
                };
                if (string.IsNullOrEmpty(hbillId.Text))
                {
                    var str = new SelectHelper().GetMax<adJustRest_D>(adJustRest_DTable.bill_id).ToString();
                    string headDate = str.Substring(0,6);
                    int lastNumber = int.Parse(str.Substring(6));
                    //如果数据库最大值流水号中日期和生成日期在同一天，则顺序号加1
                    if (headDate == DateTime.Now.ToString("yyyyMM"))
                    {
                        lastNumber++;
                        model.bill_id = headDate + lastNumber.ToString("0000");
                    }
                    else
                    {
                        model.bill_id = DateTime.Now.Date.ToString("yyyyMM") + "0001";
                    }
                }

                //------------------------------------------
                //設置名稱
                //model.Url = StringHelper.Left(txtUrl.Text, 200, true, false);
                //說明


                //開始時間與結束時間



                //修改時間與用戶
                //model.op_user = OnlineUsersBll.GetInstence().GetManagerId();

                #endregion

                //------------------------------------------

                #region 上傳圖片
                ////判斷前端的ASP.NET上傳控件是否選擇有上傳文件
                //if (this.filePhoto.HasFile && this.filePhoto.FileName.Length > 3)
                //{
                //    //將當前頁面上傳文件綁定上傳配置表Id為7的記錄，給上傳組件的邏輯層函數調用
                //    int vid = 7; //7	廣告
                //    //---------------------------------------------------
                //    //創建上傳實體
                //    var upload = new UploadFile();
                //    //調用ASP.NET上傳控件上傳函數，並獲取上傳成功或失敗信息
                //    result = new UploadFileBll().Upload_AspNet(this.filePhoto.PostedFile, vid, RndKey,
                //        OnlineUsersBll.GetInstence().GetManagerId(), OnlineUsersBll.GetInstence().GetManagerCName(),
                //        upload);
                //    this.filePhoto.Dispose();
                //    //---------------------------------------------------
                //    //沒有返回信息時表示上傳成功
                //    if (result.Length == 0) 
                //    {
                //        //將上傳到服務器後的路徑賦給廣告實體對應字段
                //        model.AdImg = upload.Path;
                //    }
                //    else
                //    {
                //        //將出錯寫入日誌中
                //        CommonBll.WriteLog("上傳出錯：" + result); //收集異常信息
                //        //彈出出錯提示
                //        return "上傳出錯！" + result;
                //    }
                //}
                ////如果是修改，檢查用戶是否重新上傳過廣告圖片，如果是刪除舊的圖片
                //if (model.Id > 0)
                //{
                //    //刪除舊圖片
                //    UploadFileBll.GetInstence()
                //        .Upload_DiffFile(adJustRest_DTable.Id, adJustRest_DTable.AdImg, adJustRest_DTable.TableName,
                //            model.Id, model.AdImg);

                //    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                //    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, adJustRest_DTable.TableName, model.Id);
                //}

                #endregion

                //判斷當前申請是否重複
                result = adJustRest_DBll.GetInstence().IsRepetition(model);
                if (result == null)
                {
                    //----------------------------------------------------------
                    //存儲到數據庫
                    adJustRest_DBll.GetInstence().Save(this, model);
                    if (id == 0) adJustRest_DBll.GetInstence().SendMail(this, model);

                    //清空字段修改標記
                    PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());

                    #region 同步更新上傳圖片表綁定Id
                    //if (id == 0)
                    //{
                    //    //同步UploadFile上傳表記錄，綁定剛剛上傳成功的文件Id為當前記錄Id
                    //    UploadFileBll.GetInstence().Upload_UpdateRs(RndKey, adJustRest_DTable.TableName, model.Id);
                    //}

                    #endregion

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
            if (ddladJustRest_D.Readonly)
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
            int value = ConvertHelper.Cint0(cbIsCheck1.Checked);
            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                FineUI.Alert.ShowInParent("請先保存記錄。", FineUI.MessageBoxIcon.Information);
                return;
            }
            string ret = adJustRest_DBll.GetInstence().Accept(this, id, value, adJustRest_DBll.Check1);
            FineUI.Alert.ShowInParent(
                !string.IsNullOrEmpty(ret) ? ret : string.Format("一級{0}審批成功", value == 0 ? "反" : ""),
                FineUI.MessageBoxIcon.Information);
            LoadData();
        }
        /// <summary>
        /// 一級審批
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAccept2_Click(object sender, EventArgs e)
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
            string ret = adJustRest_DBll.GetInstence().Accept(this, id, value, adJustRest_DBll.Check2);
            FineUI.Alert.ShowInParent(
                !string.IsNullOrEmpty(ret) ? ret : string.Format("二級{0}審批成功", value == 0 ? "反" : ""),
                FineUI.MessageBoxIcon.Information);
            LoadData();
        }


        #region 修改表單衹讀屬性

        /// <summary>
        /// 修改表單所有屬性
        /// </summary>
        private void ResolveFormField(bool b)
        {
            foreach (var field in extForm1.Rows.SelectMany(row => row.Items, (row, controlBase) => (Field)controlBase).Where(field => field != null && !(field is Label)))
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
            if (!e.CloseArgument.StartsWith("Emp=")) return;
            string provinceName = e.CloseArgument.Substring("Emp=".Length);
            tbxEmp.Text = provinceName.Trim();
            var model = EmployeeBll.GetInstence().GetModelForCache(x => x.EMP_ID == tbxEmp.Text);
            if (model == null) return;
            txtEmpName.Text = model.EMP_FNAME;
            hjId.Text = model.Id.ToString();
            var depid = model.DEPART_ID;
            txtDeptId.Text = depid;
            txtDept.Text = DepartsBll.GetInstence().GetDeptName(depid);
            hchecker1.Text = model.LINK_MAN;
            txtchecker.Text = EmployeeBll.GetInstence().GetEmpName(model.LINK_MAN);
            hchecker2.Text = model.CHECKER2;
            txtchecker2.Text = EmployeeBll.GetInstence().GetEmpName(model.CHECKER2);

        }
        #endregion
    }
}