using System;
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
                int id = RequestHelper.GetInt0("Id");
                if (id==0)
                {
                    id = RequestHelper.GetInt0("calId");
                }
                
                hidId.Text = id + "";
                //綁定下拉框
                MeetingRoomBll.GetInstence().BandDropDownListShowAll(this, dllRoomMoment);

                //添加最小時間選擇
                dpDate.MinDate = DateTime.Now.Date;

                if (id==0)
                {
                    var stime = RequestHelper.GetString("start");
                    var etime = RequestHelper.GetString("end");
                    var sroom = RequestHelper.GetString("title");
                    //初始化
                    if (!string.IsNullOrEmpty(stime))
                    {
                        dpDate.SelectedDate = Convert.ToDateTime(stime).Date;
                        dllStart.SelectedValue = Convert.ToDateTime(stime).ToString("HH:mm");
                    }
                    if (!string.IsNullOrEmpty(etime))
                    {
                        dllEnd.SelectedValue = Convert.ToDateTime(etime).ToString("HH:mm");
                    }
                    if (!string.IsNullOrEmpty(etime))
                    {
                        dllRoomMoment.SelectedValue = sroom;
                    }
                }
                else
                {
                    //加載數據
                    LoadData();
                }
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
                hidCode.Text = model.Code;
                //txtName.Text = model.Name;
                dllRoomMoment.SelectedValue = model.MeetingRoom_Code;
                dpDate.SelectedDate = model.ApplyDate;
                dllStart.SelectedValue = model.StartTime.ToString("HH:mm");
                dllEnd.SelectedValue = model.EndTime.ToString("HH:mm");
                txtEmpId.Text = model.Employee_EmpId;
                txtEmpName.Text = model.Employee_Name;
                txtDepartId.Text = model.DepartId;
                txtDepartName.Text = model.DepartName;

                //txtQty.Text = model.Qty.ToString();
                //txtAddress.Text = model.Address;
                txtRemark.Text = model.Remark;
                //視頻會議
                rblIsVideo.SelectedValue = model.IsVideo + "";

                //設置是否有效
                //rblIsVaild.SelectedValue = model.IsVaild + "";

                //判斷能否修改
                ResolveFormField(model.Employee_EmpId != OnlineUsersBll.GetInstence().GetManagerEmpId());
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
                if (string.IsNullOrEmpty(hidCode.Text.Trim()))
                {
                    hidCode.Text = CommonBll.GetTableSN(MeetingRoomApplyTable.TableName, MeetingRoomApplyTable.Code);
                }
                //var sName = StringHelper.Left(txtName.Text, 50);

                if (string.IsNullOrEmpty(dllRoomMoment.SelectedValue))
                {
                    return "請選擇會議室！";
                }

                if (dpDate.SelectedDate == null)
                {
                    return dpDate.Label + "不能為空！";
                }

                if (String.Compare(dllStart.SelectedText, dllStart.SelectedText, StringComparison.Ordinal) > 0)
                {
                    return "開始時間不能大於結束時間！";
                }
                var sRoomCode = dllRoomMoment.SelectedValue;
                DateTime appDate = Convert.ToDateTime(dpDate.SelectedDate);
                var sTime = Convert.ToDateTime(appDate.ToShortDateString() + " " + dllStart.SelectedText);
                var eTime = Convert.ToDateTime(appDate.ToShortDateString() + " " + dllEnd.SelectedText);
                //同時段不能重複申請
                if (MeetingRoomApplyBll.GetInstence().Exist(x => x.MeetingRoom_Code == sRoomCode &&
                    x.ApplyDate == appDate &&
                    x.IsVaild == 1 &&
                    ((x.StartTime <= sTime && x.EndTime > sTime) ||
                    (x.StartTime <= eTime && x.EndTime > eTime) ||
                    (x.StartTime >= sTime && x.EndTime < eTime)
                    ) && x.Id != id))
                {
                    return "該時間段已申請！請更換時間段！";
                }

                #endregion

                #region 賦值
                //獲取實體
                var model = new MeetingRoomApply(x => x.Id == id)
                {
                    Code = hidCode.Text,
                    MeetingRoom_Code = sRoomCode,
                    MeetingRoom_Name = dllRoomMoment.SelectedText,
                    ApplyDate = appDate,
                    StartTime = sTime,
                    EndTime = eTime,
                    Employee_EmpId = txtEmpId.Text,
                    Employee_Name = txtEmpName.Text,
                    DepartName = txtDepartName.Text,
                    DepartId = txtDepartId.Text,
                    Remark = txtRemark.Text,
                    IsVideo = ConvertHelper.StringToByte(rblIsVideo.SelectedValue)
                    // IsVaild = ConvertHelper.StringToByte(rblIsVaild.SelectedValue)
                };


                //設定當前項是否顯示

                #endregion

                //----------------------------------------------------------
                //存儲到數據庫
                MeetingRoomApplyBll.GetInstence().Save(this, model);
               // MeetingRoomApplyBll.GetInstence().UpdateRoomMoment(this, model.Id, 1);
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

        #region 刪除記錄
        /// <summary>
        /// 刪除記錄
        /// </summary>
        /// <returns></returns>
        public override string Delete()
        {
            //獲取要刪除的ID
            int id = RequestHelper.GetInt0("Id");

            //如果沒有選擇記錄，則直接退出
            if (id == 0)
            {
                return "單據未保存，無需刪除";
            }

            try
            {
               // MeetingRoomApplyBll.GetInstence().UpdateRoomMoment(this, id, 0);
                //刪除記錄
                bll.Delete(this, id);

                return "刪除編號ID為[" + id + "]的數據記錄成功。";
            }
            catch (Exception e)
            {
                string result = "嘗試刪除編號ID為[" + id + "]的數據記錄失敗！";

                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);

                return result;
            }
        }
        #endregion
        #region 修改表單衹讀屬性

        /// <summary>
        /// 修改表單所有屬性
        /// </summary>
        private void ResolveFormField(bool b)
        {
            lbtips.Hidden = !b;
            foreach (var field in SimpleForm1.Items.Cast<Field>().Where(field => field != null && !(field is Label)))
            {
                field.Readonly = b;
            }
        }

        #endregion
    }
}