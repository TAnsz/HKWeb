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

namespace Solution.Web.Managers.WebManage.Reports
{
    /// <summary>
    /// RoomData 的摘要说明
    /// </summary>
    public class ReportData : IHttpHandler, IRequiresSessionState
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
                string cmd = context.Request["Method"];
                if (string.IsNullOrEmpty(cmd)) return;
                var method = this.GetType().GetMethod(cmd);
                if (method != null)
                {
                    method.Invoke(this, new object[] { context });
                }
            }
            catch (Exception)
            {
                //CommonBll.WriteLog("錯誤的參數調用", ex);
            }
        }

        #region 操作函數
        /// <summary>
        /// 顯示所有日程
        /// </summary>
        /// <param name="context"></param>
        public void GetReportById(HttpContext context)
        {
            var form = context.Request.Form;
            string data;//返回的json样式
            string strId = form["Id"];

            if (string.IsNullOrEmpty(strId))
            {
                data =
                    JsonConvert.SerializeObject(
                        new JsonCalendarViewData(new JsonError("NotVolidDateTimeFormat", "lang,notvoliddatetimeformat")));
            }
            else
            {
                //var dt = new DataTable();
                var dt = SPs.PRO_DAY_REPORT(strId).ExecuteDataTable();
                data =
                    JsonConvert.SerializeObject(
                        dt,
                        new JavaScriptDateTimeConverter());
            }

            context.Response.Write(data);
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