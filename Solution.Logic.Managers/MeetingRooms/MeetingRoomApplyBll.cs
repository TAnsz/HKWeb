using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Solution.DataAccess.Model;
using SubSonic.Query;
using RoomMoment = Solution.DataAccess.DataModel.RoomMoment;

/***********************************************************************
 *   作    者：AllEmpty（陳煥）-- 1654937@qq.com
 *   博    客：http://www.cnblogs.com/EmptyFS/
 *   技 術 群：327360708
 *  
 *   創建日期：2014-06-29
 *   文件名稱：MeetingRoomApplyBll.cs
 *   描    述：會議室申請單管理邏輯類
 *             
 *   修 改 人：
 *   修改日期：
 *   修改原因：
 ***********************************************************************/
namespace Solution.Logic.Managers
{
    /// <summary>
    /// OutWork_DBll邏輯類
    /// </summary>
    public partial class MeetingRoomApplyBll : LogicBase
    {
        /***********************************************************************
		 * 自定義函數                                                          *
		 ***********************************************************************/

        #region 自定義函數

        #region 綁定類型下拉列表
        /// <summary>
        /// 綁定下拉列表
        /// </summary>
        public void BandDropDownList(Page page, System.Web.UI.WebControls.DropDownList ddl, string s)
        {
            //判斷需要綁定的下拉框

        }

        #endregion
        #region 同步更新已申請會議室列表

        /// <summary>
        /// 同步更新已申請會議室列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="id">修改的ID</param>
        /// <param name="isVaild">更新或取消</param>
        /// <param name="isAddUseLog"></param>
        public void UpdateRoomMoment(Page page, long id, byte? isVaild, bool isAddUseLog = true)
        {
            //判斷是否可以審核
            try
            {
                var model = GetModelForCache(x => x.Id == id);
                if (model == null)
                {
                    return;
                }

                //var dic = new Dictionary<string, object>();
                //dic.Add(RoomMomentTable.audit, updateValue);

                //var where = new List<ConditionHelper.SqlqueryCondition>();
                //where.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, RoomMomentTable.MeetingRoom_Code, Comparison.Equals, model.MeetingRoom_Code));
                //where.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, RoomMomentTable.RoomDate, Comparison.Equals, model.ApplyDate));

                var modelRoom = new RoomMoment(x => x.MeetingRoom_Code == model.MeetingRoom_Code && x.RoomDate == model.ApplyDate);

                if (modelRoom.IsNew())
                {
                    modelRoom.MeetingRoom_Code = model.MeetingRoom_Code;
                    modelRoom.MeetingRoom_Name = model.MeetingRoom_Name;
                    modelRoom.RoomDate = model.ApplyDate;
                }
                DateTime dt1 = Convert.ToDateTime(model.StartTime);
                DateTime dt2 = Convert.ToDateTime(model.EndTime);
                while (dt1 != dt2)
                {
                    string s = "T" + dt1.ToString("HHmm");
                    SetModelValue(modelRoom, s, isVaild);
                    dt1 = dt1.AddMinutes(30);
                    //防止死循環
                    if (dt1.Subtract(dt2).Days > 1)
                    {
                        break;
                    }
                }

                RoomMomentBll.GetInstence().Save(page, modelRoom);


            }
            catch (Exception e)
            {
                string result = "保存失敗！";
                //出現異常，保存出錯日誌信息
                CommonBll.WriteLog(result, e);
            }

        }

        #endregion

        #region 給實伐賦值
        /// <summary>
        /// 給實伐賦值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">列名</param>
        /// <param name="value">值</param>
        public void SetModelValue(RoomMoment model, string colName, object value)
        {
            if (model == null || string.IsNullOrEmpty(colName)) return;

            //返回指定條件的實伐
            switch (colName)
            {
                case "Id":
                    model.Id = (long)value;
                    break;
                case "MeetingRoom_Code":
                    model.MeetingRoom_Code = (string)value;
                    break;
                case "MeetingRoom_Name":
                    model.MeetingRoom_Name = (string)value;
                    break;
                case "RoomDate":
                    model.RoomDate = (DateTime)value;
                    break;
                case "T0830":
                    model.T0830 = ConvertHelper.Ctinyint(value);
                    break;
                case "T0900":
                    model.T0900 = ConvertHelper.Ctinyint(value);
                    break;
                case "T0930":
                    model.T0930 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1000":
                    model.T1000 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1030":
                    model.T1030 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1100":
                    model.T1100 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1130":
                    model.T1130 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1200":
                    model.T1200 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1230":
                    model.T1230 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1300":
                    model.T1300 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1330":
                    model.T1330 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1400":
                    model.T1400 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1430":
                    model.T1430 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1500":
                    model.T1500 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1530":
                    model.T1530 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1600":
                    model.T1600 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1630":
                    model.T1630 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1700":
                    model.T1700 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1730":
                    model.T1730 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1800":
                    model.T1800 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1830":
                    model.T1830 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1900":
                    model.T1900 = ConvertHelper.Ctinyint(value);
                    break;
                case "T1930":
                    model.T1930 = ConvertHelper.Ctinyint(value);
                    break;
                case "T2000":
                    model.T2000 = ConvertHelper.Ctinyint(value);
                    break;
                case "T2030":
                    model.T2030 = ConvertHelper.Ctinyint(value);
                    break;
                case "T2100":
                    model.T2100 = ConvertHelper.Ctinyint(value);
                    break;
                case "T2130":
                    model.T2130 = ConvertHelper.Ctinyint(value);
                    break;
            }
        }

        #endregion

        #region 獲取對應的申請單記錄的id
        public int GetMeetingRoomApplyId(Page page, int id, string time)
        {
            var model = RoomMomentBll.GetInstence().GetModelForCache(x => x.Id == id);
            if (model == null)
            {
                return 0;
            }
            return ConvertHelper.Cint0(GetFieldValue(MeetingRoomApplyTable.Id, x => x.ApplyDate == model.RoomDate
                && x.MeetingRoom_Code == model.MeetingRoom_Code && x.StartTime.CompareTo(time) <= 0
                && x.EndTime.CompareTo(time) > 0));

        }
        #endregion

        #region 轉換會議日程數組
        public List<object[]> ConvertToStringArray(ICollection<CalendarM> list)
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

        #endregion 自定義函數
    }
}
