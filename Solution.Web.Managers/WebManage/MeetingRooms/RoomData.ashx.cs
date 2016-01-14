using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using DotNet.Utilities;
using DotNet.Utilities.Date;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using Solution.DataAccess.Model;
using Solution.Logic.Managers;
using SubSonic.Query;

namespace Solution.Web.Managers.WebManage.MeetingRooms
{
    /// <summary>
    /// RoomData 的摘要说明
    /// </summary>
    public class RoomData : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";

            try
            {
                //后续增加权限控制
                string cmd = HttpContext.Current.Request["Method"];
                if (string.IsNullOrEmpty(cmd)) return;
                var method = this.GetType().GetMethod(cmd);
                if (method != null)
                {
                    method.Invoke(this, new object[] { context });
                }
            }
            catch (Exception ex)
            {
                CommonBll.WriteLog("错误的参数调用", ex);
            }
        }

        #region 日程函數
        /// <summary>
        /// 顯示所有日程
        /// </summary>
        /// <param name="context"></param>
        public void List(HttpContext context)
        {
            var form = context.Request.Form;
            string data;//返回的json样式
            CalendarViewType viewType = (CalendarViewType)Enum.Parse(typeof(CalendarViewType), form["viewtype"]);
            string strshowday = form["showdate"];
            DateTime showdate;
            bool b = DateTime.TryParse(strshowday, out showdate);
            if (!b)
            {
                data =
                    JsonConvert.SerializeObject(
                        new JsonCalendarViewData(new JsonError("NotVolidDateTimeFormat", "lang,notvoliddatetimeformat")));
            }
            else
            {
                int clientzone = Convert.ToInt32(form["timezone"]);
                int serverzone = TimeHelper.GetTimeZone();
                var zonediff = serverzone - clientzone;
                var format = new CalendarViewFormat(viewType, showdate, DayOfWeek.Monday);
                var qstart = format.StartDate.AddHours(zonediff);
                var qend = format.EndDate.AddHours(zonediff);
                var dt = MeetingRoomApplyBll.GetInstence()
                    .GetDataTable(false, 0, null, 0, 0, new List<ConditionHelper.SqlqueryCondition> {
                new ConditionHelper.SqlqueryCondition(ConstraintType.And, MeetingRoomApplyTable.ApplyDate,
                    Comparison.GreaterOrEquals, qstart),
                    new ConditionHelper.SqlqueryCondition(ConstraintType.And, MeetingRoomApplyTable.ApplyDate,
                    Comparison.LessOrEquals, qend)
            }, new List<string> { MeetingRoomApplyTable.StartTime + " ASC" });
                List<CalendarM> list = new List<CalendarM>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    list.AddRange(from DataRow dr in dt.Rows
                                  select new CalendarM
                                  {
                                      Id = int.Parse(dr[MeetingRoomApplyTable.Id].ToString()),
                                      Subject = string.Format("{0}[{1}]{2}", dr[MeetingRoomApplyTable.MeetingRoom_Name], dr[MeetingRoomApplyTable.Employee_Name], dr[MeetingRoomApplyTable.IsVideo].ToString() == "1" ? "(視頻)" : " "),
                                      StartTime = Convert.ToDateTime(dr[MeetingRoomApplyTable.StartTime]),
                                      EndTime = Convert.ToDateTime(dr[MeetingRoomApplyTable.EndTime]),
                                      Location = dr[MeetingRoomApplyTable.DepartName] + "",
                                      Category = StringHelper.GetNumber(dr[MeetingRoomApplyTable.MeetingRoom_Code].ToString()) + ""
                                  });
                }
                //日程格式
                data =
                    JsonConvert.SerializeObject(
                        new JsonCalendarViewData(ConvertToStringArray(list), format.StartDate, format.EndDate),
                        new JavaScriptDateTimeConverter());
            }

            context.Response.Write(data);
            context.Response.End();

        }

        public void Add(HttpContext context)
        {
            var msg = new JsonReturnMessages
            {
                IsSuccess = true,
                Msg = "增加成功！"
            };
            var data = JsonConvert.SerializeObject(msg);
            context.Response.Write(data);
            context.Response.End();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="context"></param>
        public void Update(HttpContext context)
        {
            Page page = HttpContext.Current.Handler as Page;
            var form = context.Request.Form;
            var msg = new JsonReturnMessages();
            var id = ConvertHelper.Clng(form["calendarId"]);
            //取得人员部门相关信息
            var key = context.Session[OnlineUsersTable.UserHashKey] + "";

            //判斷是否有權限修改

            if (!MeetingRoomApplyBll.GetInstence().DeleteBefore((int)id))
            {
                msg.IsSuccess = false;
                msg.Msg = "非本人申請單據，無法修改！";
            }
            else
            {
                var model = new DataAccess.DataModel.MeetingRoomApply(x => x.Id == id)
                    {
                        ApplyDate = Convert.ToDateTime(form["CalendarStartTime"]).Date,
                        StartTime = Convert.ToDateTime(form["CalendarStartTime"]),
                        EndTime = Convert.ToDateTime(form["CalendarEndTime"]),
                        Employee_EmpId = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_LoginName).ToString(),
                        Employee_Name = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Manager_CName).ToString(),
                        DepartId = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Branch_Code).ToString(),
                        DepartName = OnlineUsersBll.GetInstence().GetUserOnlineInfo(key, OnlineUsersTable.Branch_Name).ToString(),
                    };
                model.MeetingRoom_Code = form["CalendarCode"] ?? model.MeetingRoom_Code;
                model.MeetingRoom_Name = form["CalendarTitle"] ?? model.MeetingRoom_Name;
                try
                {
                    //----------------------------------------------------------
                    //判断是否重复申请
                    //同時段不能重複申請
                    if (MeetingRoomApplyBll.GetInstence().Exist(x => x.MeetingRoom_Name == model.MeetingRoom_Name
                        && x.ApplyDate == model.ApplyDate
                        && ((x.StartTime > model.StartTime ? x.StartTime : model.StartTime) <
                                                       (x.EndTime < model.EndTime ? x.EndTime : model.EndTime))
                        && x.Id != model.Id))
                    {
                        msg.IsSuccess = false;
                        msg.Msg = "該時間段已申請！請更換時間段！";
                    }
                    else
                    {
                        //存儲到數據庫
                        MeetingRoomApplyBll.GetInstence().Save(page, model);
                        msg.IsSuccess = true;
                        msg.Msg = "操作成功！";
                        msg.Data = model.Id;
                    }
                }
                catch (Exception e)
                {
                    //出現異常，保存出錯?志信息
                    CommonBll.WriteLog("日程更新失败Id:" + id, e);
                    msg.IsSuccess = false;
                    msg.Msg = "操作失败！";
                }
            }
            var data = JsonConvert.SerializeObject(msg);
            context.Response.Write(data);
            context.Response.End();
        }

        /// <summary>
        /// 刪除申請
        /// </summary>
        /// <param name="context"></param>
        public void Del(HttpContext context)
        {
            //相关业务  
            Page page = HttpContext.Current.Handler as Page;

            var form = context.Request.Form;
            var id = Convert.ToInt32(form["calendarId"]);
            bool issuccess = true;
            string smsg = "刪除成功";
            if (id >= 0)
            {
                try
                {
                    //判斷是否有權限刪除
                    issuccess = MeetingRoomApplyBll.GetInstence().DeleteBefore(id);
                    if (issuccess)
                    {
                        MeetingRoomApplyBll.GetInstence().Delete(page, id);
                    }
                    else
                    {
                        smsg = "非本人申請或申請不存在，請檢查";
                    }
                }
                catch (Exception e)
                {
                    UseLogBll.GetInstence().Save(page, "{0}刪除MeetingRoomApply表id為【" + id + "】的記錄失败！");
                    issuccess = false;
                    smsg = "刪除出錯:" + e.Message;
                }
            }
            var msg = new JsonReturnMessages
            {
                IsSuccess = issuccess,
                Msg = smsg
            };
            var data = JsonConvert.SerializeObject(msg);
            context.Response.Write(data);
            context.Response.End();
        }
        #endregion

        #region 取數
        public void GetRoomList(HttpContext context)
        {
            var list = MeetingRoomBll.GetInstence().GetList();
            string ret = list.Aggregate("", (current, item) => current + string.Format("<option value='{0}'>{1}</option>", item.Code, item.Name));
            context.Response.Write(ret);
            context.Response.End();
        }
        #endregion

        #region 功能函數
        /// <summary>
        /// 轉成純數組
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<object[]> ConvertToStringArray(ICollection<CalendarM> list)
        {
            List<object[]> relist = new List<object[]>();

            if (list != null && list.Count > 0)
            {
                int serverzone = TimeHelper.GetTimeZone();
                relist.AddRange(from entity in list
                                let clientzone = entity.MasterId ?? 8
                                let zonediff = clientzone - serverzone
                                let s = entity.StartTime.AddHours(zonediff)
                                let e = entity.EndTime.AddHours(zonediff)
                                let attends = entity.AttendeeNames + (string.IsNullOrEmpty(entity.OtherAttendee) ? "" : "," + entity.OtherAttendee)
                                select new object[]
                    {
                        entity.Id, entity.Subject, entity.StartTime, entity.EndTime, entity.IsAllDayEvent ? 1 : 0, s.ToShortDateString() != e.ToShortDateString() ? 1 : 0, entity.InstanceType == 2 ? 1 : 0, string.IsNullOrEmpty(entity.Category) ? -1 : Convert.ToInt32(entity.Category), 1, entity.Location, attends
                    });
            }
            return relist;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}