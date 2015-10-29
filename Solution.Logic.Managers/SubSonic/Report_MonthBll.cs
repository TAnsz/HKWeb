using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;
using SubSonic.Query;

namespace Solution.Logic.Managers {
	/// <summary>
	/// Report_Month表邏輯類
	/// </summary>
	public partial class Report_MonthBll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函數                                                        *
		 ***********************************************************************/
		#region 模版生成函數
				
		private const string const_CacheKey = "Cache_Report_Month";
        private const string const_CacheKey_Date = "Cache_Report_Month_Date";

		#region 單例模式
		//定義單例實伐
		private static Report_MonthBll _Report_MonthBll = null;

		/// <summary>
		/// 獲取本邏輯類單例
		/// </summary>
		/// <returns></returns>
		public static Report_MonthBll GetInstence() {
			if (_Report_MonthBll == null) {
				_Report_MonthBll = new Report_MonthBll();
			}
			return _Report_MonthBll;
		}
		#endregion
		
		#region 清空緩存
        /// <summary>清空緩存</summary>
        private void DelAllCache()
        {
            //去除模板緩存
            CacheHelper.RemoveOneCache(const_CacheKey);
			CacheHelper.RemoveOneCache(const_CacheKey_Date);

			//去除控制台緩存
			CommonBll.RemoveCache(const_CacheKey);
			//運行自定義緩存處理程序
            DelCache();
        }
		#endregion

		#region IIS緩存函數
		
		#region 從IIS緩存中獲取Report_Month表記錄
		/// <summary>
        /// 從IIS緩存中獲取Report_Month表記錄
        /// </summary>
	    /// <param name="isCache">是否從緩存中讀取</param>
        public IList<DataAccess.Model.Report_Month> GetList(bool isCache = true)
        {
			try
			{
				//判斷是否使用緩存
				if (CommonBll.IsUseCache() && isCache){
					//檢查指定緩存是否過期——緩存當天有效，第二天自動清空
					if (CommonBll.CheckCacheIsExpired(const_CacheKey_Date)){		        
						//刪除緩存
						DelAllCache();
					}

					//從緩存中獲取DataTable
					var obj = CacheHelper.GetCache(const_CacheKey);
					//如果緩存為null，則查詢數據庫
					if (obj == null)
					{
						var list = GetList(false);

						//將查詢出來的數據存儲到緩存中
                        CacheHelper.SetCache(const_CacheKey, list);
						//存儲當前時間
						CacheHelper.SetCache(const_CacheKey_Date, DateTime.Now);

                        return list;
					}
					//緩存中存在數據，則直接返回
					else
					{
						return (IList<DataAccess.Model.Report_Month>)obj;
					}
				}
				else
				{
					//定義臨時實伐集
					IList<DataAccess.Model.Report_Month> list = null;

					//獲??表緩存加載條件表達式
					var exp = GetExpression<Report_Month>();
                    //?果條件為空，則查詢?表所有記錄
					if (exp == null)
					{
						//從數據庫中獲?所有記錄
						var all = Report_Month.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //從數據庫中查詢出指定條件的記錄，並轉換為指定實伐集
						var all = Report_Month.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取Report_Month表記錄時出現異常", e);
			}
            
            return null;
        }
		#endregion

		#region 獲?指定Id記錄
		/// <summary>
        /// 獲?指定Id記錄
        /// </summary>
        /// <param name="id">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
		/// <returns>DataAccess.Model.Report_Month</returns>
        public DataAccess.Model.Report_Month GetModel(long id, bool isCache = true)
        {
            //判斷是否使用緩存
		    if (CommonBll.IsUseCache() && isCache)
		    {
                //從緩存中獲?List
		        var list = GetList();
		        if (list == null || list.Count == 0)
		        {
		            return null;
		        }
		        else
		        {
                    //在List查詢指定主鍵Id的記錄
		            return list.SingleOrDefault(x => x.Id == id);
		        }
		    }
		    else
		    {
                //從數據庫中直接讀?
                var model = Report_Month.SingleOrDefault(x => x.Id == id);
                if (model == null)
                {
                    return null;
                }
                else
                {
                    //對查詢出來的實伐進行轉換
                    return Transform(model);
                }
		    }
        }
		#endregion

		#region 從IIS緩存中獲?指定Id記錄
		/// <summary>
        /// 從IIS緩存中獲?指定Id記錄
        /// </summary>
        /// <param name="id">主鍵Id</param>
		/// <returns>DataAccess.Model.Report_Month</returns>
        public DataAccess.Model.Report_Month GetModelForCache(long id)
        {
			try
			{
				//從緩存中讀?指定Id記錄
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//從數據庫中讀?
					var tem = Report_Month.SingleOrDefault(x => x.Id == id);
					if (tem == null)
					{
						return null;
					}
					else
					{
						//對查詢出來的實伐進行轉換
						model = Transform(tem);
						SetModelForCache(model);
						return model;
					}
				}
				else
				{
					return model;
				}
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取Report_Month表記錄時出現異常", e);

                return null;
            }
        }
		#endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="conditionColName">條件列名</param>
        /// <param name="value">條件值</param>
        /// <returns>DataAccess.Model.Report_Month</returns>
        public DataAccess.Model.Report_Month GetModelForCache(string conditionColName, object value)
        {
			try
            {
                //從緩存中獲取List
                var list = GetList();
                DataAccess.Model.Report_Month model = null;
                Expression<Func<Report_Month, bool>> expression = null;

                //返回指定條件的實伐
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (int)value);
                        expression = x => x.Id == (int)value;
                        break;
					case "YM" :
						model = list.SingleOrDefault(x => x.YM == (string)value);
                        expression = x => x.YM == (string)value;
                        break;
					case "emp_id" :
						model = list.SingleOrDefault(x => x.emp_id == (string)value);
                        expression = x => x.emp_id == (string)value;
                        break;
					case "join_id" :
						model = list.SingleOrDefault(x => x.join_id == (int)value);
                        expression = x => x.join_id == (int)value;
                        break;
					case "depart_id" :
						model = list.SingleOrDefault(x => x.depart_id == (string)value);
                        expression = x => x.depart_id == (string)value;
                        break;
					case "audit" :
						model = list.SingleOrDefault(x => x.audit == (short)value);
                        expression = x => x.audit == (short)value;
                        break;
					case "auditor" :
						model = list.SingleOrDefault(x => x.auditor == (string)value);
                        expression = x => x.auditor == (string)value;
                        break;
					case "audit_date" :
						model = list.SingleOrDefault(x => x.audit_date == (DateTime)value);
                        expression = x => x.audit_date == (DateTime)value;
                        break;
					case "update_date" :
						model = list.SingleOrDefault(x => x.update_date == (DateTime)value);
                        expression = x => x.update_date == (DateTime)value;
                        break;
					case "month_days" :
						model = list.SingleOrDefault(x => x.month_days == (short)value);
                        expression = x => x.month_days == (short)value;
                        break;
					case "plan_days" :
						model = list.SingleOrDefault(x => x.plan_days == (decimal)value);
                        expression = x => x.plan_days == (decimal)value;
                        break;
					case "sun_days" :
						model = list.SingleOrDefault(x => x.sun_days == (decimal)value);
                        expression = x => x.sun_days == (decimal)value;
                        break;
					case "hd_days" :
						model = list.SingleOrDefault(x => x.hd_days == (decimal)value);
                        expression = x => x.hd_days == (decimal)value;
                        break;
					case "cal_days" :
						model = list.SingleOrDefault(x => x.cal_days == (decimal)value);
                        expression = x => x.cal_days == (decimal)value;
                        break;
					case "duty_days" :
						model = list.SingleOrDefault(x => x.duty_days == (decimal)value);
                        expression = x => x.duty_days == (decimal)value;
                        break;
					case "work_days" :
						model = list.SingleOrDefault(x => x.work_days == (decimal)value);
                        expression = x => x.work_days == (decimal)value;
                        break;
					case "absent_days" :
						model = list.SingleOrDefault(x => x.absent_days == (decimal)value);
                        expression = x => x.absent_days == (decimal)value;
                        break;
					case "leave_days" :
						model = list.SingleOrDefault(x => x.leave_days == (decimal)value);
                        expression = x => x.leave_days == (decimal)value;
                        break;
					case "fact_hrs" :
						model = list.SingleOrDefault(x => x.fact_hrs == (decimal)value);
                        expression = x => x.fact_hrs == (decimal)value;
                        break;
					case "basic_hrs" :
						model = list.SingleOrDefault(x => x.basic_hrs == (decimal)value);
                        expression = x => x.basic_hrs == (decimal)value;
                        break;
					case "mid_hrs" :
						model = list.SingleOrDefault(x => x.mid_hrs == (decimal)value);
                        expression = x => x.mid_hrs == (decimal)value;
                        break;
					case "ns_hrs" :
						model = list.SingleOrDefault(x => x.ns_hrs == (decimal)value);
                        expression = x => x.ns_hrs == (decimal)value;
                        break;
					case "ot_hrs" :
						model = list.SingleOrDefault(x => x.ot_hrs == (decimal)value);
                        expression = x => x.ot_hrs == (decimal)value;
                        break;
					case "sun_hrs" :
						model = list.SingleOrDefault(x => x.sun_hrs == (decimal)value);
                        expression = x => x.sun_hrs == (decimal)value;
                        break;
					case "hd_hrs" :
						model = list.SingleOrDefault(x => x.hd_hrs == (decimal)value);
                        expression = x => x.hd_hrs == (decimal)value;
                        break;
					case "absent_hrs" :
						model = list.SingleOrDefault(x => x.absent_hrs == (decimal)value);
                        expression = x => x.absent_hrs == (decimal)value;
                        break;
					case "late_mins" :
						model = list.SingleOrDefault(x => x.late_mins == (decimal)value);
                        expression = x => x.late_mins == (decimal)value;
                        break;
					case "late_count" :
						model = list.SingleOrDefault(x => x.late_count == (decimal)value);
                        expression = x => x.late_count == (decimal)value;
                        break;
					case "leave_mins" :
						model = list.SingleOrDefault(x => x.leave_mins == (decimal)value);
                        expression = x => x.leave_mins == (decimal)value;
                        break;
					case "leave_count" :
						model = list.SingleOrDefault(x => x.leave_count == (decimal)value);
                        expression = x => x.leave_count == (decimal)value;
                        break;
					case "ot_late_mins" :
						model = list.SingleOrDefault(x => x.ot_late_mins == (decimal)value);
                        expression = x => x.ot_late_mins == (decimal)value;
                        break;
					case "ot_leave_mins" :
						model = list.SingleOrDefault(x => x.ot_leave_mins == (decimal)value);
                        expression = x => x.ot_leave_mins == (decimal)value;
                        break;
					case "ot_late_count" :
						model = list.SingleOrDefault(x => x.ot_late_count == (decimal)value);
                        expression = x => x.ot_late_count == (decimal)value;
                        break;
					case "ot_leave_count" :
						model = list.SingleOrDefault(x => x.ot_leave_count == (decimal)value);
                        expression = x => x.ot_leave_count == (decimal)value;
                        break;
					case "ns_count" :
						model = list.SingleOrDefault(x => x.ns_count == (decimal)value);
                        expression = x => x.ns_count == (decimal)value;
                        break;
					case "mid_count" :
						model = list.SingleOrDefault(x => x.mid_count == (decimal)value);
                        expression = x => x.mid_count == (decimal)value;
                        break;
					case "ot_count" :
						model = list.SingleOrDefault(x => x.ot_count == (decimal)value);
                        expression = x => x.ot_count == (decimal)value;
                        break;
					case "absent_count" :
						model = list.SingleOrDefault(x => x.absent_count == (decimal)value);
                        expression = x => x.absent_count == (decimal)value;
                        break;
					case "l0hrs" :
						model = list.SingleOrDefault(x => x.l0hrs == (decimal)value);
                        expression = x => x.l0hrs == (decimal)value;
                        break;
					case "l1hrs" :
						model = list.SingleOrDefault(x => x.l1hrs == (decimal)value);
                        expression = x => x.l1hrs == (decimal)value;
                        break;
					case "l2hrs" :
						model = list.SingleOrDefault(x => x.l2hrs == (decimal)value);
                        expression = x => x.l2hrs == (decimal)value;
                        break;
					case "l3hrs" :
						model = list.SingleOrDefault(x => x.l3hrs == (decimal)value);
                        expression = x => x.l3hrs == (decimal)value;
                        break;
					case "l4hrs" :
						model = list.SingleOrDefault(x => x.l4hrs == (decimal)value);
                        expression = x => x.l4hrs == (decimal)value;
                        break;
					case "l5hrs" :
						model = list.SingleOrDefault(x => x.l5hrs == (decimal)value);
                        expression = x => x.l5hrs == (decimal)value;
                        break;
					case "l6hrs" :
						model = list.SingleOrDefault(x => x.l6hrs == (decimal)value);
                        expression = x => x.l6hrs == (decimal)value;
                        break;
					case "l7hrs" :
						model = list.SingleOrDefault(x => x.l7hrs == (decimal)value);
                        expression = x => x.l7hrs == (decimal)value;
                        break;
					case "l8hrs" :
						model = list.SingleOrDefault(x => x.l8hrs == (decimal)value);
                        expression = x => x.l8hrs == (decimal)value;
                        break;
					case "l9hrs" :
						model = list.SingleOrDefault(x => x.l9hrs == (decimal)value);
                        expression = x => x.l9hrs == (decimal)value;
                        break;
					case "l10hrs" :
						model = list.SingleOrDefault(x => x.l10hrs == (decimal)value);
                        expression = x => x.l10hrs == (decimal)value;
                        break;
					case "l11hrs" :
						model = list.SingleOrDefault(x => x.l11hrs == (decimal)value);
                        expression = x => x.l11hrs == (decimal)value;
                        break;
					case "l12hrs" :
						model = list.SingleOrDefault(x => x.l12hrs == (decimal)value);
                        expression = x => x.l12hrs == (decimal)value;
                        break;
					case "l13hrs" :
						model = list.SingleOrDefault(x => x.l13hrs == (decimal)value);
                        expression = x => x.l13hrs == (decimal)value;
                        break;
					case "l14hrs" :
						model = list.SingleOrDefault(x => x.l14hrs == (decimal)value);
                        expression = x => x.l14hrs == (decimal)value;
                        break;
					case "l15hrs" :
						model = list.SingleOrDefault(x => x.l15hrs == (decimal)value);
                        expression = x => x.l15hrs == (decimal)value;
                        break;
					case "outwork_hrs" :
						model = list.SingleOrDefault(x => x.outwork_hrs == (decimal)value);
                        expression = x => x.outwork_hrs == (decimal)value;
                        break;
					case "shutdown_hrs" :
						model = list.SingleOrDefault(x => x.shutdown_hrs == (decimal)value);
                        expression = x => x.shutdown_hrs == (decimal)value;
                        break;
					case "outwork_days" :
						model = list.SingleOrDefault(x => x.outwork_days == (decimal)value);
                        expression = x => x.outwork_days == (decimal)value;
                        break;
					case "shutdown_days" :
						model = list.SingleOrDefault(x => x.shutdown_days == (decimal)value);
                        expression = x => x.shutdown_days == (decimal)value;
                        break;
					case "shift_hrs" :
						model = list.SingleOrDefault(x => x.shift_hrs == (decimal)value);
                        expression = x => x.shift_hrs == (decimal)value;
                        break;
					case "onwatch_hrs" :
						model = list.SingleOrDefault(x => x.onwatch_hrs == (decimal)value);
                        expression = x => x.onwatch_hrs == (decimal)value;
                        break;
					case "sign_count" :
						model = list.SingleOrDefault(x => x.sign_count == (int)value);
                        expression = x => x.sign_count == (int)value;
                        break;
					case "need_sign_count" :
						model = list.SingleOrDefault(x => x.need_sign_count == (int)value);
                        expression = x => x.need_sign_count == (int)value;
                        break;
					case "l0day" :
						model = list.SingleOrDefault(x => x.l0day == (decimal)value);
                        expression = x => x.l0day == (decimal)value;
                        break;
					case "l1day" :
						model = list.SingleOrDefault(x => x.l1day == (decimal)value);
                        expression = x => x.l1day == (decimal)value;
                        break;
					case "l2day" :
						model = list.SingleOrDefault(x => x.l2day == (decimal)value);
                        expression = x => x.l2day == (decimal)value;
                        break;
					case "l3day" :
						model = list.SingleOrDefault(x => x.l3day == (decimal)value);
                        expression = x => x.l3day == (decimal)value;
                        break;
					case "l4day" :
						model = list.SingleOrDefault(x => x.l4day == (decimal)value);
                        expression = x => x.l4day == (decimal)value;
                        break;
					case "l5day" :
						model = list.SingleOrDefault(x => x.l5day == (decimal)value);
                        expression = x => x.l5day == (decimal)value;
                        break;
					case "l6day" :
						model = list.SingleOrDefault(x => x.l6day == (decimal)value);
                        expression = x => x.l6day == (decimal)value;
                        break;
					case "l7day" :
						model = list.SingleOrDefault(x => x.l7day == (decimal)value);
                        expression = x => x.l7day == (decimal)value;
                        break;
					case "l8day" :
						model = list.SingleOrDefault(x => x.l8day == (decimal)value);
                        expression = x => x.l8day == (decimal)value;
                        break;
					case "L9day" :
						model = list.SingleOrDefault(x => x.L9day == (decimal)value);
                        expression = x => x.L9day == (decimal)value;
                        break;
					case "l10day" :
						model = list.SingleOrDefault(x => x.l10day == (decimal)value);
                        expression = x => x.l10day == (decimal)value;
                        break;
					case "l11day" :
						model = list.SingleOrDefault(x => x.l11day == (decimal)value);
                        expression = x => x.l11day == (decimal)value;
                        break;
					case "l12day" :
						model = list.SingleOrDefault(x => x.l12day == (decimal)value);
                        expression = x => x.l12day == (decimal)value;
                        break;
					case "l13day" :
						model = list.SingleOrDefault(x => x.l13day == (decimal)value);
                        expression = x => x.l13day == (decimal)value;
                        break;
					case "l14day" :
						model = list.SingleOrDefault(x => x.l14day == (decimal)value);
                        expression = x => x.l14day == (decimal)value;
                        break;
					case "l15day" :
						model = list.SingleOrDefault(x => x.l15day == (decimal)value);
                        expression = x => x.l15day == (decimal)value;
                        break;
					case "outwork_count" :
						model = list.SingleOrDefault(x => x.outwork_count == (decimal)value);
                        expression = x => x.outwork_count == (decimal)value;
                        break;
					case "shutdown_count" :
						model = list.SingleOrDefault(x => x.shutdown_count == (decimal)value);
                        expression = x => x.shutdown_count == (decimal)value;
                        break;
					case "l0count" :
						model = list.SingleOrDefault(x => x.l0count == (decimal)value);
                        expression = x => x.l0count == (decimal)value;
                        break;
					case "l1count" :
						model = list.SingleOrDefault(x => x.l1count == (decimal)value);
                        expression = x => x.l1count == (decimal)value;
                        break;
					case "l2count" :
						model = list.SingleOrDefault(x => x.l2count == (decimal)value);
                        expression = x => x.l2count == (decimal)value;
                        break;
					case "l3count" :
						model = list.SingleOrDefault(x => x.l3count == (decimal)value);
                        expression = x => x.l3count == (decimal)value;
                        break;
					case "l4count" :
						model = list.SingleOrDefault(x => x.l4count == (decimal)value);
                        expression = x => x.l4count == (decimal)value;
                        break;
					case "l5count" :
						model = list.SingleOrDefault(x => x.l5count == (decimal)value);
                        expression = x => x.l5count == (decimal)value;
                        break;
					case "l6count" :
						model = list.SingleOrDefault(x => x.l6count == (decimal)value);
                        expression = x => x.l6count == (decimal)value;
                        break;
					case "l7count" :
						model = list.SingleOrDefault(x => x.l7count == (decimal)value);
                        expression = x => x.l7count == (decimal)value;
                        break;
					case "l8count" :
						model = list.SingleOrDefault(x => x.l8count == (decimal)value);
                        expression = x => x.l8count == (decimal)value;
                        break;
					case "L9count" :
						model = list.SingleOrDefault(x => x.L9count == (decimal)value);
                        expression = x => x.L9count == (decimal)value;
                        break;
					case "l10count" :
						model = list.SingleOrDefault(x => x.l10count == (decimal)value);
                        expression = x => x.l10count == (decimal)value;
                        break;
					case "l11count" :
						model = list.SingleOrDefault(x => x.l11count == (decimal)value);
                        expression = x => x.l11count == (decimal)value;
                        break;
					case "l12count" :
						model = list.SingleOrDefault(x => x.l12count == (decimal)value);
                        expression = x => x.l12count == (decimal)value;
                        break;
					case "l13count" :
						model = list.SingleOrDefault(x => x.l13count == (decimal)value);
                        expression = x => x.l13count == (decimal)value;
                        break;
					case "l14count" :
						model = list.SingleOrDefault(x => x.l14count == (decimal)value);
                        expression = x => x.l14count == (decimal)value;
                        break;
					case "l15count" :
						model = list.SingleOrDefault(x => x.l15count == (decimal)value);
                        expression = x => x.l15count == (decimal)value;
                        break;
					case "ot_sun_day" :
						model = list.SingleOrDefault(x => x.ot_sun_day == (decimal)value);
                        expression = x => x.ot_sun_day == (decimal)value;
                        break;
					case "ot_nd_day" :
						model = list.SingleOrDefault(x => x.ot_nd_day == (decimal)value);
                        expression = x => x.ot_nd_day == (decimal)value;
                        break;
					case "bait_hrs" :
						model = list.SingleOrDefault(x => x.bait_hrs == (decimal)value);
                        expression = x => x.bait_hrs == (decimal)value;
                        break;
					case "lesshrs_count" :
						model = list.SingleOrDefault(x => x.lesshrs_count == (int)value);
                        expression = x => x.lesshrs_count == (int)value;
                        break;
					case "over_hrs" :
						model = list.SingleOrDefault(x => x.over_hrs == (decimal)value);
                        expression = x => x.over_hrs == (decimal)value;
                        break;
					case "late1_min" :
						model = list.SingleOrDefault(x => x.late1_min == (decimal)value);
                        expression = x => x.late1_min == (decimal)value;
                        break;
					case "late2_min" :
						model = list.SingleOrDefault(x => x.late2_min == (decimal)value);
                        expression = x => x.late2_min == (decimal)value;
                        break;
					case "late3_min" :
						model = list.SingleOrDefault(x => x.late3_min == (decimal)value);
                        expression = x => x.late3_min == (decimal)value;
                        break;
					case "late4_min" :
						model = list.SingleOrDefault(x => x.late4_min == (decimal)value);
                        expression = x => x.late4_min == (decimal)value;
                        break;
					case "late5_min" :
						model = list.SingleOrDefault(x => x.late5_min == (decimal)value);
                        expression = x => x.late5_min == (decimal)value;
                        break;
					case "leave1_min" :
						model = list.SingleOrDefault(x => x.leave1_min == (decimal)value);
                        expression = x => x.leave1_min == (decimal)value;
                        break;
					case "leave2_min" :
						model = list.SingleOrDefault(x => x.leave2_min == (decimal)value);
                        expression = x => x.leave2_min == (decimal)value;
                        break;
					case "leave3_min" :
						model = list.SingleOrDefault(x => x.leave3_min == (decimal)value);
                        expression = x => x.leave3_min == (decimal)value;
                        break;
					case "leave4_min" :
						model = list.SingleOrDefault(x => x.leave4_min == (decimal)value);
                        expression = x => x.leave4_min == (decimal)value;
                        break;
					case "leave5_min" :
						model = list.SingleOrDefault(x => x.leave5_min == (decimal)value);
                        expression = x => x.leave5_min == (decimal)value;
                        break;
					case "input_ot_hrs" :
						model = list.SingleOrDefault(x => x.input_ot_hrs == (decimal)value);
                        expression = x => x.input_ot_hrs == (decimal)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //從數據庫中讀取
                    var tem = Report_Month.SingleOrDefault(expression);
                    if (tem == null)
                    {
                        return null;
                    }
                    else
                    {
                        //對查詢出來的實伐進行轉換
                        model = Transform(tem);
						SetModelForCache(model);
                        return model;
                    }
                }
                else
                {
                    return model;
                }
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取Report_Month表記錄時出現異常", e);

                return null;
            }
        }
        #endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="expression">條件</param>
        /// <returns>DataAccess.Model.Report_Month</returns>
        public DataAccess.Model.Report_Month GetModelForCache(Expression<Func<DataAccess.Model.Report_Month, bool>> expression)
        {
			//從緩存中讀?記錄列表
			var list = GetList();
            //?果條件為空，則查詢?表所有記錄
            if (expression == null)
            {
                //查找並返回記錄實伐
                if (list == null || list.Count == 0)
                {
                    return null;
                }
                else
                {
                    return list.First();
                }
            }
            else
            {
                //查找並返回記錄實伐
                if (list == null || list.Count == 0)
                {
                    return null;
                }
                else
                {
					//先進行條件篩選，得出的數據，再?第一個
                    var tmp = list.AsQueryable().Where(expression);
                    if (tmp.Any())
                    {
                        return tmp.First();
                    }

                    return null;
                }
            }
        }
        #endregion

		#region 更新IIS緩存中指定Id記錄
		/// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(DataAccess.Model.Report_Month model)
        {
			if (model == null) return;
			
            //從緩存中刪除記錄
            DelCache(model.Id);

            //從緩存中讀?記錄列表
            var list = GetList();
		    if (list == null)
		    {
                list = new List<DataAccess.Model.Report_Month>();
		    }
            //添加記錄
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(Report_Month model)
        {
            SetModelForCache(Transform(model));
        }
		#endregion

		#region 刪除IIS緩存中指定Id記錄
        /// <summary>
        /// 刪除IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="id">主鍵Id</param>
        public bool DelCache(long id)
        {
            //從緩存中獲?List
            var list = GetList(true);
            if (list == null || list.Count == 0)
            {
                return false;
            }
            else
            {
                //找到指定主鍵Id的實伐
                var model = list.SingleOrDefault(x => x.Id == id);
                //刪除指定Id的記錄
                return model != null && list.Remove(model);
            }
        }

		/// <summary>
        /// 批量刪除IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="ids">主鍵Id</param>
        public void DelCache(IEnumerable ids)
        {
            //循環刪除指定Id隊列
		    foreach (var id in ids)
		    {
		        DelCache((int)id);
		    }
        }

		/// <summary>
        /// 按條件刪除IIS緩存中Report_Month表的指定記錄
        /// </summary>
        /// <param name="expression">條件，值為null時刪除?有記錄</param>
		public void DelCache(Expression<Func<DataAccess.Model.Report_Month, bool>> expression)
        {
            //從緩存中獲?List
		    var list = GetList();
            //?果緩存為null，則不做?何處理
            if (list == null || list.Count == 0)
            {
                return;
            }

            //?果條件為空，則刪除?部記錄
            if (expression == null)
            {
                //刪除所有記錄
                DelAllCache();
            }
            else
            {
                var tem = list.AsQueryable().Where(expression);
                foreach (var model in tem)
                {
                    list.Remove(model);
                }
            }
        }
		#endregion

		#region 實伐轉換
		/// <summary>
		/// 將Report_Month記錄實伐（SubSonic實伐）轉換為?通的實伐（DataAccess.Model.Report_Month）
		/// </summary>
        /// <param name="model">SubSonic插件生成的實伐</param>
		/// <returns>DataAccess.Model.Report_Month</returns>
		public DataAccess.Model.Report_Month Transform(Report_Month model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.Report_Month
            {
                Id = model.Id,
                YM = model.YM,
                emp_id = model.emp_id,
                join_id = model.join_id,
                depart_id = model.depart_id,
                audit = model.audit,
                auditor = model.auditor,
                audit_date = model.audit_date,
                update_date = model.update_date,
                month_days = model.month_days,
                plan_days = model.plan_days,
                sun_days = model.sun_days,
                hd_days = model.hd_days,
                cal_days = model.cal_days,
                duty_days = model.duty_days,
                work_days = model.work_days,
                absent_days = model.absent_days,
                leave_days = model.leave_days,
                fact_hrs = model.fact_hrs,
                basic_hrs = model.basic_hrs,
                mid_hrs = model.mid_hrs,
                ns_hrs = model.ns_hrs,
                ot_hrs = model.ot_hrs,
                sun_hrs = model.sun_hrs,
                hd_hrs = model.hd_hrs,
                absent_hrs = model.absent_hrs,
                late_mins = model.late_mins,
                late_count = model.late_count,
                leave_mins = model.leave_mins,
                leave_count = model.leave_count,
                ot_late_mins = model.ot_late_mins,
                ot_leave_mins = model.ot_leave_mins,
                ot_late_count = model.ot_late_count,
                ot_leave_count = model.ot_leave_count,
                ns_count = model.ns_count,
                mid_count = model.mid_count,
                ot_count = model.ot_count,
                absent_count = model.absent_count,
                l0hrs = model.l0hrs,
                l1hrs = model.l1hrs,
                l2hrs = model.l2hrs,
                l3hrs = model.l3hrs,
                l4hrs = model.l4hrs,
                l5hrs = model.l5hrs,
                l6hrs = model.l6hrs,
                l7hrs = model.l7hrs,
                l8hrs = model.l8hrs,
                l9hrs = model.l9hrs,
                l10hrs = model.l10hrs,
                l11hrs = model.l11hrs,
                l12hrs = model.l12hrs,
                l13hrs = model.l13hrs,
                l14hrs = model.l14hrs,
                l15hrs = model.l15hrs,
                outwork_hrs = model.outwork_hrs,
                shutdown_hrs = model.shutdown_hrs,
                outwork_days = model.outwork_days,
                shutdown_days = model.shutdown_days,
                shift_hrs = model.shift_hrs,
                onwatch_hrs = model.onwatch_hrs,
                sign_count = model.sign_count,
                need_sign_count = model.need_sign_count,
                l0day = model.l0day,
                l1day = model.l1day,
                l2day = model.l2day,
                l3day = model.l3day,
                l4day = model.l4day,
                l5day = model.l5day,
                l6day = model.l6day,
                l7day = model.l7day,
                l8day = model.l8day,
                L9day = model.L9day,
                l10day = model.l10day,
                l11day = model.l11day,
                l12day = model.l12day,
                l13day = model.l13day,
                l14day = model.l14day,
                l15day = model.l15day,
                outwork_count = model.outwork_count,
                shutdown_count = model.shutdown_count,
                l0count = model.l0count,
                l1count = model.l1count,
                l2count = model.l2count,
                l3count = model.l3count,
                l4count = model.l4count,
                l5count = model.l5count,
                l6count = model.l6count,
                l7count = model.l7count,
                l8count = model.l8count,
                L9count = model.L9count,
                l10count = model.l10count,
                l11count = model.l11count,
                l12count = model.l12count,
                l13count = model.l13count,
                l14count = model.l14count,
                l15count = model.l15count,
                ot_sun_day = model.ot_sun_day,
                ot_nd_day = model.ot_nd_day,
                bait_hrs = model.bait_hrs,
                lesshrs_count = model.lesshrs_count,
                over_hrs = model.over_hrs,
                late1_min = model.late1_min,
                late2_min = model.late2_min,
                late3_min = model.late3_min,
                late4_min = model.late4_min,
                late5_min = model.late5_min,
                leave1_min = model.leave1_min,
                leave2_min = model.leave2_min,
                leave3_min = model.leave3_min,
                leave4_min = model.leave4_min,
                leave5_min = model.leave5_min,
                input_ot_hrs = model.input_ot_hrs,
            };
        }

		/// <summary>
		/// 將Report_Month記錄實伐集（SubSonic實伐）轉換為?通的實伐集（DataAccess.Model.Report_Month）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的實伐集</param>
        public IList<DataAccess.Model.Report_Month> Transform(IList<Report_Month> sourceList)
        {
			//創建List??
            var list = new List<DataAccess.Model.Report_Month>();
			//將SubSonic插件生成的實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 將Report_Month記錄實伐批?通的實伐（DataAccess.Model.Report_Month）轉換為SubSonic插件生成的實伐
		/// </summary>
        /// <param name="model">?通的實伐（DataAccess.Model.Report_Month）</param>
		/// <returns>Report_Month</returns>
		public Report_Month Transform(DataAccess.Model.Report_Month model)
        {
			if (model == null) 
				return null;

            return new Report_Month
            {
                Id = model.Id,
                YM = model.YM,
                emp_id = model.emp_id,
                join_id = model.join_id,
                depart_id = model.depart_id,
                audit = model.audit,
                auditor = model.auditor,
                audit_date = model.audit_date,
                update_date = model.update_date,
                month_days = model.month_days,
                plan_days = model.plan_days,
                sun_days = model.sun_days,
                hd_days = model.hd_days,
                cal_days = model.cal_days,
                duty_days = model.duty_days,
                work_days = model.work_days,
                absent_days = model.absent_days,
                leave_days = model.leave_days,
                fact_hrs = model.fact_hrs,
                basic_hrs = model.basic_hrs,
                mid_hrs = model.mid_hrs,
                ns_hrs = model.ns_hrs,
                ot_hrs = model.ot_hrs,
                sun_hrs = model.sun_hrs,
                hd_hrs = model.hd_hrs,
                absent_hrs = model.absent_hrs,
                late_mins = model.late_mins,
                late_count = model.late_count,
                leave_mins = model.leave_mins,
                leave_count = model.leave_count,
                ot_late_mins = model.ot_late_mins,
                ot_leave_mins = model.ot_leave_mins,
                ot_late_count = model.ot_late_count,
                ot_leave_count = model.ot_leave_count,
                ns_count = model.ns_count,
                mid_count = model.mid_count,
                ot_count = model.ot_count,
                absent_count = model.absent_count,
                l0hrs = model.l0hrs,
                l1hrs = model.l1hrs,
                l2hrs = model.l2hrs,
                l3hrs = model.l3hrs,
                l4hrs = model.l4hrs,
                l5hrs = model.l5hrs,
                l6hrs = model.l6hrs,
                l7hrs = model.l7hrs,
                l8hrs = model.l8hrs,
                l9hrs = model.l9hrs,
                l10hrs = model.l10hrs,
                l11hrs = model.l11hrs,
                l12hrs = model.l12hrs,
                l13hrs = model.l13hrs,
                l14hrs = model.l14hrs,
                l15hrs = model.l15hrs,
                outwork_hrs = model.outwork_hrs,
                shutdown_hrs = model.shutdown_hrs,
                outwork_days = model.outwork_days,
                shutdown_days = model.shutdown_days,
                shift_hrs = model.shift_hrs,
                onwatch_hrs = model.onwatch_hrs,
                sign_count = model.sign_count,
                need_sign_count = model.need_sign_count,
                l0day = model.l0day,
                l1day = model.l1day,
                l2day = model.l2day,
                l3day = model.l3day,
                l4day = model.l4day,
                l5day = model.l5day,
                l6day = model.l6day,
                l7day = model.l7day,
                l8day = model.l8day,
                L9day = model.L9day,
                l10day = model.l10day,
                l11day = model.l11day,
                l12day = model.l12day,
                l13day = model.l13day,
                l14day = model.l14day,
                l15day = model.l15day,
                outwork_count = model.outwork_count,
                shutdown_count = model.shutdown_count,
                l0count = model.l0count,
                l1count = model.l1count,
                l2count = model.l2count,
                l3count = model.l3count,
                l4count = model.l4count,
                l5count = model.l5count,
                l6count = model.l6count,
                l7count = model.l7count,
                l8count = model.l8count,
                L9count = model.L9count,
                l10count = model.l10count,
                l11count = model.l11count,
                l12count = model.l12count,
                l13count = model.l13count,
                l14count = model.l14count,
                l15count = model.l15count,
                ot_sun_day = model.ot_sun_day,
                ot_nd_day = model.ot_nd_day,
                bait_hrs = model.bait_hrs,
                lesshrs_count = model.lesshrs_count,
                over_hrs = model.over_hrs,
                late1_min = model.late1_min,
                late2_min = model.late2_min,
                late3_min = model.late3_min,
                late4_min = model.late4_min,
                late5_min = model.late5_min,
                leave1_min = model.leave1_min,
                leave2_min = model.leave2_min,
                leave3_min = model.leave3_min,
                leave4_min = model.leave4_min,
                leave5_min = model.leave5_min,
                input_ot_hrs = model.input_ot_hrs,
            };
        }

		/// <summary>
		/// 將Report_Month記錄實伐批?通實伐集（DataAccess.Model.Report_Month）轉換為SubSonic插件生成的實伐集
		/// </summary>
        /// <param name="sourceList">?通實伐集（DataAccess.Model.Report_Month）</param>
        public IList<Report_Month> Transform(IList<DataAccess.Model.Report_Month> sourceList)
        {
			//創建List??
            var list = new List<Report_Month>();
			//將?通實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }
		#endregion

		#region 給實伐賦值
		/// <summary>
        /// 給實伐賦值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="dic">列名與值</param>
		public void SetModelValue(DataAccess.Model.Report_Month model, Dictionary<string, object> dic)
		{
			if (model == null || dic == null) return;

            //遍歷字典，逐個給字段賦值
            foreach (var d in dic)
            {
                SetModelValue(model, d.Key, d.Value);
            }
		}

        /// <summary>
        /// 給實伐賦值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">列名</param>
        /// <param name="value">值</param>
		public void SetModelValue(DataAccess.Model.Report_Month model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定條件的實伐
            switch (colName)
            {
				case "Id" :
					model.Id = (int)value;
                    break;
				case "YM" :
					model.YM = (string)value;
                    break;
				case "emp_id" :
					model.emp_id = (string)value;
                    break;
				case "join_id" :
					model.join_id = (int)value;
                    break;
				case "depart_id" :
					model.depart_id = (string)value;
                    break;
				case "audit" :
					model.audit = (short)value;
                    break;
				case "auditor" :
					model.auditor = (string)value;
                    break;
				case "audit_date" :
					model.audit_date = (DateTime)value;
                    break;
				case "update_date" :
					model.update_date = (DateTime)value;
                    break;
				case "month_days" :
					model.month_days = (short)value;
                    break;
				case "plan_days" :
					model.plan_days = (decimal)value;
                    break;
				case "sun_days" :
					model.sun_days = (decimal)value;
                    break;
				case "hd_days" :
					model.hd_days = (decimal)value;
                    break;
				case "cal_days" :
					model.cal_days = (decimal)value;
                    break;
				case "duty_days" :
					model.duty_days = (decimal)value;
                    break;
				case "work_days" :
					model.work_days = (decimal)value;
                    break;
				case "absent_days" :
					model.absent_days = (decimal)value;
                    break;
				case "leave_days" :
					model.leave_days = (decimal)value;
                    break;
				case "fact_hrs" :
					model.fact_hrs = (decimal)value;
                    break;
				case "basic_hrs" :
					model.basic_hrs = (decimal)value;
                    break;
				case "mid_hrs" :
					model.mid_hrs = (decimal)value;
                    break;
				case "ns_hrs" :
					model.ns_hrs = (decimal)value;
                    break;
				case "ot_hrs" :
					model.ot_hrs = (decimal)value;
                    break;
				case "sun_hrs" :
					model.sun_hrs = (decimal)value;
                    break;
				case "hd_hrs" :
					model.hd_hrs = (decimal)value;
                    break;
				case "absent_hrs" :
					model.absent_hrs = (decimal)value;
                    break;
				case "late_mins" :
					model.late_mins = (decimal)value;
                    break;
				case "late_count" :
					model.late_count = (decimal)value;
                    break;
				case "leave_mins" :
					model.leave_mins = (decimal)value;
                    break;
				case "leave_count" :
					model.leave_count = (decimal)value;
                    break;
				case "ot_late_mins" :
					model.ot_late_mins = (decimal)value;
                    break;
				case "ot_leave_mins" :
					model.ot_leave_mins = (decimal)value;
                    break;
				case "ot_late_count" :
					model.ot_late_count = (decimal)value;
                    break;
				case "ot_leave_count" :
					model.ot_leave_count = (decimal)value;
                    break;
				case "ns_count" :
					model.ns_count = (decimal)value;
                    break;
				case "mid_count" :
					model.mid_count = (decimal)value;
                    break;
				case "ot_count" :
					model.ot_count = (decimal)value;
                    break;
				case "absent_count" :
					model.absent_count = (decimal)value;
                    break;
				case "l0hrs" :
					model.l0hrs = (decimal)value;
                    break;
				case "l1hrs" :
					model.l1hrs = (decimal)value;
                    break;
				case "l2hrs" :
					model.l2hrs = (decimal)value;
                    break;
				case "l3hrs" :
					model.l3hrs = (decimal)value;
                    break;
				case "l4hrs" :
					model.l4hrs = (decimal)value;
                    break;
				case "l5hrs" :
					model.l5hrs = (decimal)value;
                    break;
				case "l6hrs" :
					model.l6hrs = (decimal)value;
                    break;
				case "l7hrs" :
					model.l7hrs = (decimal)value;
                    break;
				case "l8hrs" :
					model.l8hrs = (decimal)value;
                    break;
				case "l9hrs" :
					model.l9hrs = (decimal)value;
                    break;
				case "l10hrs" :
					model.l10hrs = (decimal)value;
                    break;
				case "l11hrs" :
					model.l11hrs = (decimal)value;
                    break;
				case "l12hrs" :
					model.l12hrs = (decimal)value;
                    break;
				case "l13hrs" :
					model.l13hrs = (decimal)value;
                    break;
				case "l14hrs" :
					model.l14hrs = (decimal)value;
                    break;
				case "l15hrs" :
					model.l15hrs = (decimal)value;
                    break;
				case "outwork_hrs" :
					model.outwork_hrs = (decimal)value;
                    break;
				case "shutdown_hrs" :
					model.shutdown_hrs = (decimal)value;
                    break;
				case "outwork_days" :
					model.outwork_days = (decimal)value;
                    break;
				case "shutdown_days" :
					model.shutdown_days = (decimal)value;
                    break;
				case "shift_hrs" :
					model.shift_hrs = (decimal)value;
                    break;
				case "onwatch_hrs" :
					model.onwatch_hrs = (decimal)value;
                    break;
				case "sign_count" :
					model.sign_count = (int)value;
                    break;
				case "need_sign_count" :
					model.need_sign_count = (int)value;
                    break;
				case "l0day" :
					model.l0day = (decimal)value;
                    break;
				case "l1day" :
					model.l1day = (decimal)value;
                    break;
				case "l2day" :
					model.l2day = (decimal)value;
                    break;
				case "l3day" :
					model.l3day = (decimal)value;
                    break;
				case "l4day" :
					model.l4day = (decimal)value;
                    break;
				case "l5day" :
					model.l5day = (decimal)value;
                    break;
				case "l6day" :
					model.l6day = (decimal)value;
                    break;
				case "l7day" :
					model.l7day = (decimal)value;
                    break;
				case "l8day" :
					model.l8day = (decimal)value;
                    break;
				case "L9day" :
					model.L9day = (decimal)value;
                    break;
				case "l10day" :
					model.l10day = (decimal)value;
                    break;
				case "l11day" :
					model.l11day = (decimal)value;
                    break;
				case "l12day" :
					model.l12day = (decimal)value;
                    break;
				case "l13day" :
					model.l13day = (decimal)value;
                    break;
				case "l14day" :
					model.l14day = (decimal)value;
                    break;
				case "l15day" :
					model.l15day = (decimal)value;
                    break;
				case "outwork_count" :
					model.outwork_count = (decimal)value;
                    break;
				case "shutdown_count" :
					model.shutdown_count = (decimal)value;
                    break;
				case "l0count" :
					model.l0count = (decimal)value;
                    break;
				case "l1count" :
					model.l1count = (decimal)value;
                    break;
				case "l2count" :
					model.l2count = (decimal)value;
                    break;
				case "l3count" :
					model.l3count = (decimal)value;
                    break;
				case "l4count" :
					model.l4count = (decimal)value;
                    break;
				case "l5count" :
					model.l5count = (decimal)value;
                    break;
				case "l6count" :
					model.l6count = (decimal)value;
                    break;
				case "l7count" :
					model.l7count = (decimal)value;
                    break;
				case "l8count" :
					model.l8count = (decimal)value;
                    break;
				case "L9count" :
					model.L9count = (decimal)value;
                    break;
				case "l10count" :
					model.l10count = (decimal)value;
                    break;
				case "l11count" :
					model.l11count = (decimal)value;
                    break;
				case "l12count" :
					model.l12count = (decimal)value;
                    break;
				case "l13count" :
					model.l13count = (decimal)value;
                    break;
				case "l14count" :
					model.l14count = (decimal)value;
                    break;
				case "l15count" :
					model.l15count = (decimal)value;
                    break;
				case "ot_sun_day" :
					model.ot_sun_day = (decimal)value;
                    break;
				case "ot_nd_day" :
					model.ot_nd_day = (decimal)value;
                    break;
				case "bait_hrs" :
					model.bait_hrs = (decimal)value;
                    break;
				case "lesshrs_count" :
					model.lesshrs_count = (int)value;
                    break;
				case "over_hrs" :
					model.over_hrs = (decimal)value;
                    break;
				case "late1_min" :
					model.late1_min = (decimal)value;
                    break;
				case "late2_min" :
					model.late2_min = (decimal)value;
                    break;
				case "late3_min" :
					model.late3_min = (decimal)value;
                    break;
				case "late4_min" :
					model.late4_min = (decimal)value;
                    break;
				case "late5_min" :
					model.late5_min = (decimal)value;
                    break;
				case "leave1_min" :
					model.leave1_min = (decimal)value;
                    break;
				case "leave2_min" :
					model.leave2_min = (decimal)value;
                    break;
				case "leave3_min" :
					model.leave3_min = (decimal)value;
                    break;
				case "leave4_min" :
					model.leave4_min = (decimal)value;
                    break;
				case "leave5_min" :
					model.leave5_min = (decimal)value;
                    break;
				case "input_ot_hrs" :
					model.input_ot_hrs = (decimal)value;
                    break;
            }
		}

        #endregion

		#endregion

		#region 獲?Report_Month表記錄總數
        /// <summary>
        /// 獲?Report_Month表記錄總數
        /// </summary>
        /// <returns>記錄總數</returns>
        public int GetRecordCount()
        {
            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
				//從緩存中獲?記錄集
                var list = GetList();
                return list == null ? 0 : list.Count;
            }
			else
			{
				//從數據庫中查詢記錄集數量
				var select = new SelectHelper();
				return select.GetRecordCount<Report_Month>();
			}
        }

		/// <summary>
		/// 獲?Report_Month表記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="wheres">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionHelper.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<Report_Month>(wheres);

		}

		/// <summary>
		/// 獲?Report_Month表指定條件的記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="expression">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<Report_Month, bool>> expression) {
            return new Select().From<Report_Month>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定條件的記錄集合
        /// <summary>
        /// 查找指定條件的記錄集合——從IIS緩存中查找
        /// </summary>
        /// <param name="expression">條件語句</param>
        public IList<DataAccess.Model.Report_Month> Find(Expression<Func<DataAccess.Model.Report_Month, bool>> expression)
        {
			//從緩存中獲?記錄集
			var list = GetList();
            //判斷獲?記錄集是否為null
            if (list == null)
            {
                return null;
            }
            else
            {
                //在返回的記錄集中查詢
                var result = list.AsQueryable().Where(expression);
                //不存在指定記錄集
                if (!result.Any())
                    return null;
                else
                    return result.ToList();
            }
        }
		#endregion

		#region 判斷指定條件的記錄是否存在
        /// <summary>
        /// 判斷指定主鍵Id的記錄是否存在——在IIS緩存或數據庫中查找
        /// </summary>
        /// <param name="id">主鍵Id</param>
        /// <returns></returns>
        public bool Exist(int id)
        {
            if (id <= 0)
                return false;

            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                return Exist(x => x.Id == id);
            }
            
            //從數據庫中查找
            return Report_Month.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判斷指定條件的記錄是否存在——默?在IIS緩存中查找，?果沒開?緩存時，則直接在數據庫中查詢出列表後，再從列表中查詢
        /// </summary>
        /// <param name="expression">條件語句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.Report_Month, bool>> expression)
        {
            var list = GetList();
            if (list == null) 
                return false;
            else
            {
                return list.AsQueryable().Any(expression);
            }
        }
        #endregion

		#region 獲?Report_Month表記錄
		/// <summary>
		/// 獲?Report_Month表記錄
		/// </summary>
		/// <param name="norepeat">是否使用?重複</param>
		/// <param name="top">獲?指定數量記錄</param>
		/// <param name="columns">獲?指定的列記錄</param>
		/// <param name="pageIndex">當?分頁頁面索引</param>
		/// <param name="pageSize">每個頁面記錄數量</param>
		/// <param name="wheres">查詢條件</param>
		/// <param name="sorts">排序方式</param>
        /// <returns>返回DataTable</returns>
		public DataTable GetDataTable(bool norepeat = false, int top = 0, List<string> columns = null, int pageIndex = 0, int pageSize = 0, List<ConditionHelper.SqlqueryCondition> wheres = null, List<string> sorts = null) {
			try
            {
                //分頁查詢
                var select = new SelectHelper();
                return select.SelectDataTable<Report_Month>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("獲?Report_Month表記錄時出現異常", e);

                return null;
            }
		}
		#endregion

		#region 綁定Grid表格
		/// <summary>
		/// 綁定Grid表格，並實現分頁
		/// </summary>
		/// <param name="grid">表格控件</param>
		/// <param name="pageIndex">第幾頁</param>
		/// <param name="pageSize">每頁顯示記錄數量</param>
		/// <param name="wheres">查詢條件</param>
		/// <param name="sorts">排序</param>
		public override void BindGrid(FineUI.Grid grid, int pageIndex = 0, int pageSize = 0, List<ConditionHelper.SqlqueryCondition> wheres = null, List<string> sorts = null) {
			//用於統計執行時長(耗時)
			var swatch = new Stopwatch();
			swatch.Start();

			try {
				// 1.設瞞總項數
				grid.RecordCount = GetRecordCount(wheres);
				// 2.?果不存在記錄，則?空Grid表格
				if (grid.RecordCount == 0) {
					grid.Rows.Clear();
					// 查詢並綁定到Grid
                    grid.DataBind();
                    grid.AllowPaging = false;
				}
				else
				{
					//3.查詢並綁定到Grid
					grid.DataSource = GetDataTable(false, 0, null, pageIndex, pageSize, wheres, sorts);
					grid.DataBind();
				}
			}
			catch (Exception e) {
				// 記錄?志
				CommonBll.WriteLog("獲?用戶操作?志表記錄時出現異常", e);

			}

			// 統計結束
			swatch.Stop();
			// 計算查詢數據庫使用時間，並存儲到Session裡，以便UI顯示
			HttpContext.Current.Session["SpendingTime"] = (swatch.ElapsedMilliseconds / 1000.00).ToString();
		}
		#endregion

		#region 綁定Grid表格
		/// <summary>
		/// 綁定Grid表格，使用內存分頁，顯示有層次感
		/// </summary>
		/// <param name="grid">表格控件</param>
		/// <param name="parentValue">父Id值</param>
		/// <param name="wheres">查詢條件</param>
		/// <param name="sorts">排序</param>
		/// <param name="parentId">父Id</param>
		public override void BindGrid(FineUI.Grid grid, int parentValue, List<ConditionHelper.SqlqueryCondition> wheres = null, List<string> sorts = null, string parentId = "ParentId") {
			//用於統計執行時長(耗時)
			var swatch = new Stopwatch();
			swatch.Start();

			try
			{
				// 查詢數據庫
				var dt = GetDataTable(false, 0, null, 0, 0, wheres, sorts);
                
                // 1.設瞞總項數
                grid.RecordCount = dt == null ? 0 : dt.Rows.Count;
                // 2.?果不存在記錄，則?空Grid表格
                if (grid.RecordCount == 0)
                {
                    grid.Rows.Clear();
                    // 查詢並綁定到Grid
                    grid.DataBind();
                    grid.AllowPaging = false;
                }
                else
                {
                    // 對查詢出來的記錄進行層次處理
                    grid.DataSource = DataTableHelper.DataTableTidyUp(dt, "id", parentId, parentValue);
                    // 查詢並綁定到Grid
                    grid.DataBind();
                    grid.AllowPaging = true;
                }
			}
			catch (Exception e) {
				// 記錄?志
				CommonBll.WriteLog("綁定表格時出現異常", e);

			}

			//統計結束
			swatch.Stop();
			//計算查詢數據庫使用時間，並存儲到Session裡，以便UI顯示
			HttpContext.Current.Session["SpendingTime"] = (swatch.ElapsedMilliseconds / 1000.00).ToString();
		}

		/// <summary>
		/// 綁定Grid表格，使用內存分頁，顯示有層次感
		/// </summary>
		/// <param name="grid">表格控件</param>
		/// <param name="parentValue">父Id值</param>
		/// <param name="sorts">排序</param>
		/// <param name="parentId">父Id</param>
		public override void BindGrid(FineUI.Grid grid, int parentValue, List<string> sorts = null, string parentId = "ParentId") {
			BindGrid(grid, parentValue, null, sorts, parentId);
		}
		#endregion

		#region 添加與編輯Report_Month表記錄
		/// <summary>
		/// 添加與編輯Report_Month記錄
		/// </summary>
	    /// <param name="page">當?頁面指針</param>
		/// <param name="model">Report_Month表實伐</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Save(Page page, Report_Month model, string content = null, bool isCache = true, bool isAddUseLog = true)
        {
			try {
				//保存
				model.Save();
				
				//判斷是否?用緩存
			    if (CommonBll.IsUseCache() && isCache)
			    {
                    SetModelForCache(model);
			    }
				
				if (isAddUseLog)
				{
					if (string.IsNullOrEmpty(content))
					{
						content = "{0}" + (model.Id == 0 ? "添加" : "編輯") + "Report_Month記錄成功，ID為【" + model.Id + "】";
					}

					//添加用戶訪問記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "執行Report_MonthBll.Save()函數出錯！";

				//出現異常，保存出錯?志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 刪除Report_Month表記錄
		/// <summary>
		/// 刪除Report_Month表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", Report_MonthTable.TableName,  Report_MonthTable.Id, id);

			//刪除
			var delete = new DeleteHelper();
		    delete.Delete(sql);
			
			//判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除緩存
                DelCache(id);
            }
			
			if (isAddUseLog)
		    {
				//添加用戶操作記錄
				UseLogBll.GetInstence().Save(page, "{0}刪除了Report_Month表id為【" + id + "】的記錄！");
			}
		}

		/// <summary>
		/// 刪除Report_Month表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int[] id, bool isAddUseLog = true) 
		{
			if (id == null) return;
			//將數組轉為逗號分隔的字串
			var str = string.Join(",", id);

			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} in ({2})", Report_MonthTable.TableName,  Report_MonthTable.Id, str);

			//刪除
			var delete = new DeleteHelper();
		    delete.Delete(sql);
			
			//判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除緩存
                DelCache(id.ToList());
            }
			
			if (isAddUseLog)
		    {
				//添加用戶操作記錄
				UseLogBll.GetInstence().Save(page, "{0}刪除了Report_Month表id為【" + str + "】的記錄！");
			}
		}

		/// <summary>
        /// 刪除Report_Month表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Delete(Page page, Expression<Func<Report_Month, bool>> expression, bool isAddUseLog = true)
        {
			//執行刪除
			Report_Month.Delete(expression);

            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
				//?空當?表所有緩存記錄
				DelAllCache();
                //重新載?緩存
                GetList();
            }
			
			if (isAddUseLog)
		    {
				//添加用戶操作記錄
				UseLogBll.GetInstence().Save(page, "{0}刪除了Report_Month表記錄！");
			}
        }

		/// <summary>
        /// 刪除Report_Month表所有記錄
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void DeleteAll(Page page, bool isAddUseLog = true)
        {
            //設瞞Sql語句
            var sql = string.Format("delete from {0}", Report_MonthTable.TableName);

            //刪除
            var delete = new DeleteHelper();
            delete.Delete(sql);

            //判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //?空當?表所有緩存記錄
                DelAllCache();
            }

            if (isAddUseLog)
            {
                //添加用戶操作記錄
                UseLogBll.GetInstence().Save(page, "{0}刪除了Report_Month表所有記錄！");
            }
        }
		#endregion
		
		#region 保存列表排序
		/// <summary>
		/// 保存列表排序，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="grid1">頁面表格</param>
		/// <param name="tbxSort">表格中綁定排序的表單名</param>
		/// <param name="sortName">排序字段名</param>
		/// <returns>更新成功返回true，失敗返回false</returns>
		public override bool UpdateSort(Page page, FineUI.Grid grid1, string tbxSort, string sortName = "Sort")
	    {
		     //更新排序
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "Report_Month", sortName, "Id"))
		    {
				//判斷是否?用緩存
                if (CommonBll.IsUseCache())
                {
                    //刪除所有緩存
                    DelAllCache();
                    //重新載?緩存
                    GetList();
                }
				
			    //添加用戶操作記錄
				UseLogBll.GetInstence().Save(page, "{0}更新了Report_Month表排序！");

			    return true;
		    }

			return false;
	    }
		#endregion

		#region 自動排序
		/// <summary>自動排序，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="strWhere">附加Where : " sid=1 "</param>
		/// <param name="isExistsMoreLv">是否存在多級分類,一級時,?使用false,多級使用true，(一級不包括ParentID字段)</param>
		/// <param name="pid">父級分類的ParentID</param>
		/// <param name="fieldName">字段名:"SortId"</param>
		/// <param name="fieldParentId">字段名:"ParentId"</param>
		/// <returns>更新成功返回true，失敗返回false</returns>
		public override bool UpdateAutoSort(Page page, string strWhere = "", bool isExistsMoreLv = false, int pid = 0, string fieldName = "Sort", string fieldParentId = "ParentId")
	    {
		    //更新排序
			if (CommonBll.AutoSort("Id", "Report_Month", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
		    {
				//判斷是否?用緩存
                if (CommonBll.IsUseCache())
                {
                    //刪除所有緩存
                    DelAllCache();
                    //重新載?緩存
                    GetList();
                }

			    //添加用戶操作記錄
				UseLogBll.GetInstence().Save(page, "{0}對Report_Month表進行了自動排序操作！");

			    return true;
		    }

			return false;
	    }
		#endregion
		
		#region 獲?數據表中的某個值
		/// <summary>
        /// 獲?數據表中的某個值——主要用於內存查詢，數據量大的表?將isCache設為false
        /// </summary>
        /// <param name="id">主鍵Id</param>
        /// <param name="colName">獲?的列名</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns>指定列的值</returns>
        public object GetFieldValue(int id, string colName, bool isCache = true)
	    {
			return GetFieldValue(colName, null, id, isCache);            
	    }

	    /// <summary>
        /// 獲?數據表中的某個值——主要用於內存查詢，數據量大的表?將isCache設為false
	    /// </summary>
	    /// <param name="colName">獲?的列名</param>
	    /// <param name="conditionColName">條件列名，為null時默?為主鍵Id</param>
	    /// <param name="value">條件值</param>
	    /// <param name="isCache">是否從緩存中讀?</param>
	    /// <returns></returns>
	    public object GetFieldValue(string colName, string conditionColName, object value, bool isCache = true)
	    {
            //在內存中查詢
	        if (isCache)
	        {
                //判斷是否?用緩存
                if (CommonBll.IsUseCache())
                {
                    //?果條件列為空，則默?為主鍵列
                    if (string.IsNullOrEmpty(conditionColName))
                    {
                        //獲?實伐
                        var model = GetModelForCache(ConvertHelper.Cint0(value));
                        //返回指定字段名的值
                        return GetFieldValue(model, colName);
                    }
                    else
                    {
                        //獲?實伐
                        var model = GetModelForCache(conditionColName, value);
                        //返回指定字段名的值
                        return GetFieldValue(model, colName);
                    }
                }

				//遞歸調用，從數據庫中查詢
	            return GetFieldValue(colName, conditionColName, value, false);
	        }
            //從數據庫中查詢
	        else
	        {
				if (string.IsNullOrEmpty(conditionColName))
	            {
	                conditionColName = Report_MonthTable.Id;
	            }

                //設瞞條件
                var wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, conditionColName, Comparison.Equals, value));

                return GetFieldValue(colName, wheres);
	        }
	    }
		
	    /// <summary>
        /// 獲?數據表中的某個值——使用IIS緩存查詢
        /// </summary>
        /// <param name="colName">獲?的列名</param>
        /// <param name="expression">條件</param>
        /// <returns></returns>
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.Report_Month, bool>> expression)
	    {
	        return GetFieldValue(GetModelForCache(expression), colName);
	    }

	    /// <summary>
        /// 獲?數據表中的某個值——從數據庫中查詢
        /// </summary>
        /// <param name="colName">獲?的列名</param>
        /// <param name="wheres">條件，例：Id=100 and xx=20</param>
        /// <returns></returns>
        public object GetFieldValue(string colName, string wheres)
        {
            try
            {
                return DataTableHelper.DataTable_Find_Value(GetDataTable(), wheres, colName);
			}
			catch (Exception e)
			{
                //記錄?志
                CommonBll.WriteLog("查詢數據出現異常", e);
			}

            return null;
        }

        /// <summary>
        /// 獲?數據表中的某個值——從數據庫中查詢
        /// </summary>
        /// <param name="colName">獲?的列名</param>
        /// <param name="wheres">條件</param>
        /// <returns></returns>
        public object GetFieldValue(string colName, List<ConditionHelper.SqlqueryCondition> wheres)
        {
            var select = new SelectHelper();
            return select.GetColumnsValue<Report_Month>(colName, wheres);
        }

		/// <summary>
        /// 返回實伐中指定字段名的值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">獲?的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.Report_Month model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "YM" :
					return model.YM;
				case "emp_id" :
					return model.emp_id;
				case "join_id" :
					return model.join_id;
				case "depart_id" :
					return model.depart_id;
				case "audit" :
					return model.audit;
				case "auditor" :
					return model.auditor;
				case "audit_date" :
					return model.audit_date;
				case "update_date" :
					return model.update_date;
				case "month_days" :
					return model.month_days;
				case "plan_days" :
					return model.plan_days;
				case "sun_days" :
					return model.sun_days;
				case "hd_days" :
					return model.hd_days;
				case "cal_days" :
					return model.cal_days;
				case "duty_days" :
					return model.duty_days;
				case "work_days" :
					return model.work_days;
				case "absent_days" :
					return model.absent_days;
				case "leave_days" :
					return model.leave_days;
				case "fact_hrs" :
					return model.fact_hrs;
				case "basic_hrs" :
					return model.basic_hrs;
				case "mid_hrs" :
					return model.mid_hrs;
				case "ns_hrs" :
					return model.ns_hrs;
				case "ot_hrs" :
					return model.ot_hrs;
				case "sun_hrs" :
					return model.sun_hrs;
				case "hd_hrs" :
					return model.hd_hrs;
				case "absent_hrs" :
					return model.absent_hrs;
				case "late_mins" :
					return model.late_mins;
				case "late_count" :
					return model.late_count;
				case "leave_mins" :
					return model.leave_mins;
				case "leave_count" :
					return model.leave_count;
				case "ot_late_mins" :
					return model.ot_late_mins;
				case "ot_leave_mins" :
					return model.ot_leave_mins;
				case "ot_late_count" :
					return model.ot_late_count;
				case "ot_leave_count" :
					return model.ot_leave_count;
				case "ns_count" :
					return model.ns_count;
				case "mid_count" :
					return model.mid_count;
				case "ot_count" :
					return model.ot_count;
				case "absent_count" :
					return model.absent_count;
				case "l0hrs" :
					return model.l0hrs;
				case "l1hrs" :
					return model.l1hrs;
				case "l2hrs" :
					return model.l2hrs;
				case "l3hrs" :
					return model.l3hrs;
				case "l4hrs" :
					return model.l4hrs;
				case "l5hrs" :
					return model.l5hrs;
				case "l6hrs" :
					return model.l6hrs;
				case "l7hrs" :
					return model.l7hrs;
				case "l8hrs" :
					return model.l8hrs;
				case "l9hrs" :
					return model.l9hrs;
				case "l10hrs" :
					return model.l10hrs;
				case "l11hrs" :
					return model.l11hrs;
				case "l12hrs" :
					return model.l12hrs;
				case "l13hrs" :
					return model.l13hrs;
				case "l14hrs" :
					return model.l14hrs;
				case "l15hrs" :
					return model.l15hrs;
				case "outwork_hrs" :
					return model.outwork_hrs;
				case "shutdown_hrs" :
					return model.shutdown_hrs;
				case "outwork_days" :
					return model.outwork_days;
				case "shutdown_days" :
					return model.shutdown_days;
				case "shift_hrs" :
					return model.shift_hrs;
				case "onwatch_hrs" :
					return model.onwatch_hrs;
				case "sign_count" :
					return model.sign_count;
				case "need_sign_count" :
					return model.need_sign_count;
				case "l0day" :
					return model.l0day;
				case "l1day" :
					return model.l1day;
				case "l2day" :
					return model.l2day;
				case "l3day" :
					return model.l3day;
				case "l4day" :
					return model.l4day;
				case "l5day" :
					return model.l5day;
				case "l6day" :
					return model.l6day;
				case "l7day" :
					return model.l7day;
				case "l8day" :
					return model.l8day;
				case "L9day" :
					return model.L9day;
				case "l10day" :
					return model.l10day;
				case "l11day" :
					return model.l11day;
				case "l12day" :
					return model.l12day;
				case "l13day" :
					return model.l13day;
				case "l14day" :
					return model.l14day;
				case "l15day" :
					return model.l15day;
				case "outwork_count" :
					return model.outwork_count;
				case "shutdown_count" :
					return model.shutdown_count;
				case "l0count" :
					return model.l0count;
				case "l1count" :
					return model.l1count;
				case "l2count" :
					return model.l2count;
				case "l3count" :
					return model.l3count;
				case "l4count" :
					return model.l4count;
				case "l5count" :
					return model.l5count;
				case "l6count" :
					return model.l6count;
				case "l7count" :
					return model.l7count;
				case "l8count" :
					return model.l8count;
				case "L9count" :
					return model.L9count;
				case "l10count" :
					return model.l10count;
				case "l11count" :
					return model.l11count;
				case "l12count" :
					return model.l12count;
				case "l13count" :
					return model.l13count;
				case "l14count" :
					return model.l14count;
				case "l15count" :
					return model.l15count;
				case "ot_sun_day" :
					return model.ot_sun_day;
				case "ot_nd_day" :
					return model.ot_nd_day;
				case "bait_hrs" :
					return model.bait_hrs;
				case "lesshrs_count" :
					return model.lesshrs_count;
				case "over_hrs" :
					return model.over_hrs;
				case "late1_min" :
					return model.late1_min;
				case "late2_min" :
					return model.late2_min;
				case "late3_min" :
					return model.late3_min;
				case "late4_min" :
					return model.late4_min;
				case "late5_min" :
					return model.late5_min;
				case "leave1_min" :
					return model.leave1_min;
				case "leave2_min" :
					return model.leave2_min;
				case "leave3_min" :
					return model.leave3_min;
				case "leave4_min" :
					return model.leave4_min;
				case "leave5_min" :
					return model.leave5_min;
				case "input_ot_hrs" :
					return model.input_ot_hrs;
			}

			return null;
		}

		#endregion
		
		#region 更新Report_Month表指定字段值
		/// <summary>更新Report_Month表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="dic">需要更新的字段與值</param>
		/// <param name="wheres">條件</param>
		/// <param name="content">更新說明</param>
		/// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionHelper.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<Report_Month>(dic, wheres);

			//判斷是否?用緩存
			if (isCache && CommonBll.IsUseCache())
			{
				//刪除?部緩存	
				DelAllCache();
				//重新載?緩存
				GetList();
			}
			
			if (isAddUseLog){
				if (string.IsNullOrEmpty(content))
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}囊改了Report_Month表記錄。");				
				}
				else
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新Report_Month表指定主鍵Id的字段值
		/// <summary>更新Report_Month表記錄指定字段值</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue(Page page, int id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Report_Month表主鍵Id值為" + id + "的記錄。";
			
            //條件
		    List<ConditionHelper.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, Report_MonthTable.Id, Comparison.Equals, id));
            };

			//判斷是否?用緩存——為了防止並發問題，所以先更新緩存再更新數據庫
			if (isCache && CommonBll.IsUseCache())
			{
				//從緩存中獲?實伐
				var model = GetModelForCache(id);
				if (model != null)
				{
					//給獲?的實伐賦值
					SetModelValue(model, dic);
					//更新緩存中的實伐
					SetModelForCache(model);
				}
			}

            //執行更新
            UpdateValue(page, dic, wheres, content, false, isAddUseLog);
        }

        /// <summary>更新Report_Month表記錄指定字段值（更新一個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, int id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了Report_Month表主鍵Id值為" + id + "的記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新Report_Month表記錄指定字段值（更新兩個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName1">要更新的列名</param>
        /// <param name="columnValue1">要更新的列值</param>
        /// <param name="columnName2">要更新的列名</param>
        /// <param name="columnValue2">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, int id, string columnName1, object columnValue1, string columnName2, object columnValue2, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了Report_Month表主鍵Id值為" + id + "的記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
    
		#endregion 模版生成函數

    } 
}
