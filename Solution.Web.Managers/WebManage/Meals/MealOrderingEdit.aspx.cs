using System;
using System.Globalization;
using System.Linq;
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
 *   文件名稱：MealOrderingEdit.aspx.cs
 *   描    述：會議室編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.Meals
{
    public partial class MealOrderingEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                hidId.Text = RequestHelper.GetInt0("Id") + "";

                //綁定下拉列表
                T_TABLE_DBll.GetInstence().BandRadioButtonList(this, rblFood, T_TABLE_DTable.TABLES, "'FOOD'");
                T_TABLE_DBll.GetInstence().BandRadioButtonList(this, rblDrink, T_TABLE_DTable.TABLES, "'DRIN'");
                rblDrink.SelectedValue = "";

                //添加最小日期選擇
                dpDate.MinDate = DateTime.Now.Date;

                //加載數據
                LoadData();
            }
            var model = WebConfigBll.GetInstence().GetModelForCache(1);
            if (model != null)
            {
                bool b = model.IsMealLock == 1 && model.MealLockDate == DateTime.Now.Date;
                ResolveFormField(b);
                redtips.Hidden = !b;
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
                var model = MealOrderingBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                hidCode.Text = model.Code;
                dpDate.SelectedDate = model.ApplyDate;
                tbxEmp.Text = model.Employee_EmpId;
                txtEmpName.Text = model.Employee_Name;
                txtDeptId.Text = model.DepartId;
                txtDeptName.Text = model.DepartName;

                rblFood.SelectedValue = model.FoodCode;
                rblDrink.SelectedValue = model.DrinkCode;

                lbuser.Text = model.RecordName;
                lbdate.Text = model.RecordDate.ToString();

                txtRemark.Text = model.Remark;

                //判斷能否修改 當天之前的數據不能修改
                ResolveFormField(DateTime.Compare(Convert.ToDateTime(model.ApplyDate), DateTime.Now.Date) < 0);
                ////設置是否有效
                //rblIsVaild.SelectedValue = model.IsVaild + "";
            }
            else
            {
                var key = OnlineUsersBll.GetInstence().GetUserHashKey();
                var empid = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_LoginName).ToString();
                var name = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_CName).ToString();
                tbxEmp.Text = empid;
                txtEmpName.Text = name;
                dpDate.SelectedDate = DateTime.Now.Date;
                txtDeptId.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Branch_Code).ToString();
                txtDeptName.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Branch_Name).ToString();
            }
        }



        #endregion
        #region 列表屬性綁定
        #region 員工選擇
        /// <summary>
        /// 彈出員工選擇界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbxEmp_TriggerClick(object sender, EventArgs e)
        {
            Window2.IFrameUrl = "/WebManage/Systems/Pop/EmpSimpleChoose.aspx?EmpId=0000000&" + MenuInfoBll.GetInstence().PageUrlEncryptString();
            Window2.Hidden = false;
        }
        #endregion
        #region 員工編號輸入
        //protected void txtEmpId_Blur(object sender, EventArgs e)
        //{
        //    var empid = tbxEmp.Text;
        //    var model = EmployeeBll.GetInstence().GetModelForCache(x => x.EMP_ID == empid);
        //    if (model == null)
        //    {
        //        tbxEmp.Text = "";
        //        FineUI.Alert.ShowInParent("員工編號不存在！", FineUI.MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        txtEmpName.Text = model.EMP_FNAME;
        //        var depid = model.DEPART_ID;
        //        txtDeptId.Text = depid;
        //        txtDeptName.Text = DepartsBll.GetInstence().GetDeptName(depid);
        //    }
        //}

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
                //判斷是否鎖定
                var mod = WebConfigBll.GetInstence().GetModelForCache(1);
                if (mod != null)
                {
                    bool b = mod.IsMealLock == 1 && mod.MealLockDate == DateTime.Now.Date;
                    if (b && dpDate.SelectedDate == DateTime.Now.Date)
                    {
                        PageContext.RegisterStartupScript(Panel1.GetClearDirtyReference());
                        return "當天訂餐系統已鎖定，無法修改和增加當天的訂餐信息！";
                    }
                }

                if (string.IsNullOrEmpty(hidCode.Text.Trim()))
                {
                    hidCode.Text = CommonBll.GetTableSN(MealOrderingTable.TableName, MealOrderingTable.Code);
                }
                if (string.IsNullOrEmpty(dpDate.ToString()))
                {
                    return dpDate.Label + "不能為空！";
                }
                if (string.IsNullOrEmpty(rblFood.SelectedValue))
                {
                    return rblFood.Label + "不能為空！";
                }

                if (MealOrderingBll.GetInstence().Exist(x => (x.Employee_EmpId == tbxEmp.Text && x.ApplyDate == dpDate.SelectedDate) && x.Id != id))
                {
                    return "該員工當天已訂餐，請勿重複申請！";
                }
                #endregion

                #region 賦值
                //獲取實體
                var model = new MealOrdering(x => x.Id == id)
                {
                    Code = hidCode.Text,
                    ApplyDate = dpDate.SelectedDate,
                    Employee_EmpId = tbxEmp.Text,
                    Employee_Name = txtEmpName.Text,
                    DepartId = txtDeptId.Text,
                    DepartName = txtDeptName.Text,
                    FoodCode = rblFood.SelectedValue,
                    DrinkCode = rblDrink.SelectedValue,
                    Remark = txtRemark.Text
                };

                //設置名稱


                //地址
                var empid = OnlineUsersBll.GetInstence().GetManagerEmpId();
                var name = OnlineUsersBll.GetInstence().GetManagerCName();
                if (id == 0)
                {
                    model.RecordId = empid;
                    model.RecordName = lbuser.Text = name;
                    model.RecordDate = DateTime.Now;
                    model.IsVaild = 1;
                    lbdate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    model.ModifyId = empid;
                    model.ModifyBy = name;
                    model.ModifyDate = DateTime.Now;
                }
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                MealOrderingBll.GetInstence().Save(this, model);
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
        #region 修改表單衹讀屬性

        /// <summary>
        /// 修改表單所有屬性
        /// </summary>
        private void ResolveFormField(bool b)
        {
            foreach (var field in extForm1.Items.Cast<Field>().Where(field => field != null && !(field is Label)))
            {
                field.Readonly = b;
            }
        }

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
                if (model == null) return;
                txtEmpName.Text = model.EMP_FNAME;
                var depid = model.DEPART_ID;
                txtDeptId.Text = depid;
                txtDeptName.Text = DepartsBll.GetInstence().GetDeptName(depid);
            }
        }
        #endregion
    }
}