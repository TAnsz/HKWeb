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
 *   文件名稱：MeetingRoomApplyEdit.aspx.cs
 *   描    述：會議室申請編輯頁面
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Web.Managers.WebManage.MeetingRooms
{
    public partial class MeetingRoomApplyEdit : PageBase
    {

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //獲取ID值
                string sTime = RequestHelper.GetString("Time");
                int id = RequestHelper.GetInt0("Id");
                if (!string.IsNullOrEmpty(sTime))
                {
                    id = MeetingRoomApplyBll.GetInstence().GetMeetingRoomApplyId(this, id, sTime);
                }
                hidId.Text = id + "";
                //綁定下拉框
                MeetingRoomBll.GetInstence().BandDropDownListShowAll(this, dllRoomMoment);

                //添加最小时间选择
                dpDate.MinDate = DateTime.Now.Date;

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
                var model = MeetingRoomApplyBll.GetInstence().GetModelForCache(x => x.Id == id);
                if (model == null)
                    return;

                //對頁面窗體進行賦值
                txtCode.Text = model.Code;
                txtName.Text = model.Name;
                dllRoomMoment.SelectedValue = model.MeetingRoom_Code;
                dpDate.SelectedDate = model.ApplyDate;
                dllStart.SelectedValue = model.StartTime;
                dllEnd.SelectedValue = model.EndTime;
                txtEmpId.Text = model.Employee_EmpId;
                txtEmpName.Text = model.Employee_Name;
                txtDepartId.Text = model.DepartId;
                txtDepartName.Text = model.DepartName;

                //txtQty.Text = model.Qty.ToString();
                //txtAddress.Text = model.Address;
                txtRemark.Text = model.Remark;

                //設置是否有效
                rblIsVaild.SelectedValue = model.IsVaild + "";

                //判斷能否修改
                ResolveFormField(!(model.Employee_EmpId == OnlineUsersBll.GetInstence().GetManagerEmpId()));
            }
            else
            {
                var key = OnlineUsersBll.GetInstence().GetUserHashKey();
                dpDate.SelectedDate = DateTime.Now.Date;
                txtEmpId.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_LoginName).ToString();
                txtEmpName.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_CName).ToString();
                txtDepartId.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Branch_Code).ToString();
                txtDepartName.Text = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Branch_Name).ToString();
            }
        }

        #endregion

        #region 下拉列表改變事件

        ///// <summary>下拉列表改變事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void dllStart_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    //LoadData();
        //}

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
                //if (string.IsNullOrEmpty(txtCode.Text.Trim()))
                //{
                //    return txtCode.Label + "不能為空！";
                //}
                var sCode = CommonBll.GetTableSN(MeetingRoomApplyTable.TableName, MeetingRoomApplyTable.Code);
                txtCode.Text = sCode;
                var sName = StringHelper.Left(txtName.Text, 50);
                var sRoomCode = dllRoomMoment.SelectedValue;
                var AppDate = dpDate.SelectedDate;
                var sTime = dllStart.SelectedValue;
                var eTime = dllEnd.SelectedValue;
                if (string.IsNullOrEmpty(sName))
                {
                    return txtName.Label + "不能為空！";
                }
                if (MeetingRoomApplyBll.GetInstence().Exist(x => (x.Code == sCode) && x.Id != id))
                {
                    return txtCode.Label + "已存在！請重新輸入！";
                }

                if (sRoomCode == "0" || string.IsNullOrEmpty(sRoomCode))
                {
                    return "請選擇會議室！";
                }

                if (string.IsNullOrEmpty(dpDate.ToString()))
                {
                    return dpDate.Label + "不能為空！";
                }

                if (sTime.CompareTo(eTime) > 0)
                {
                    return "開始時間不能大於結束時間！";
                }
                //同時段不能重複申請
                if (MeetingRoomApplyBll.GetInstence().Exist(x => x.MeetingRoom_Code == sRoomCode &&
                    x.ApplyDate == AppDate &&
                    x.IsVaild == 1 &&
                    ((x.StartTime.CompareTo(sTime) <= 0 && x.EndTime.CompareTo(sTime) > 0) ||
                    (x.StartTime.CompareTo(eTime) <= 0 && x.EndTime.CompareTo(eTime) > 0) ||
                    (x.StartTime.CompareTo(sTime) >= 0 && x.EndTime.CompareTo(eTime) < 0)
                    ) && x.Id != id))
                {
                    return "該時間段已申請！請更換時間段！";
                }

                #endregion

                #region 賦值
                //獲取實體
                var model = new MeetingRoomApply(x => x.Id == id);

                //設置名稱
                model.Code = sCode;
                model.Name = sName;

                model.MeetingRoom_Code = sRoomCode;
                model.MeetingRoom_Name = dllRoomMoment.SelectedText;
                model.ApplyDate = AppDate;
                model.StartTime = sTime;
                model.EndTime = eTime;
                model.Employee_EmpId = txtEmpId.Text;
                model.Employee_Name = txtEmpName.Text;
                model.DepartName = txtDepartName.Text;
                model.DepartId = txtDepartId.Text;
                model.Remark = txtRemark.Text;

                //設定當前項是否顯示
                model.IsVaild = ConvertHelper.StringToByte(rblIsVaild.SelectedValue);
                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                MeetingRoomApplyBll.GetInstence().Save(this, model);
                MeetingRoomApplyBll.GetInstence().UpdateRoomMoment(this, model.Id, model.IsVaild);
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

        #region 修改表單衹讀屬性
        /// <summary>
        /// 修改表單所有屬性
        /// </summary>
        /// <param name="process"></param>
        private void ResolveFormField(bool b)
        {
            lbtips.Hidden = !b;
            foreach (Field field in SimpleForm1.Items)
            {
                if (field != null && !(field is Label))
                {
                    field.Readonly = b;
                }
            }
        }
        #endregion
    }
}