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
	/// OutWork_D表邏輯類
	/// </summary>
	public partial class OutWork_DBll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函數                                                        *
		 ***********************************************************************/
		#region 模版生成函數
				
		private const string const_CacheKey = "Cache_OutWork_D";
        private const string const_CacheKey_Date = "Cache_OutWork_D_Date";

		#region 單例模式
		//定義單例實伐
		private static OutWork_DBll _OutWork_DBll = null;

		/// <summary>
		/// 獲取本邏輯類單例
		/// </summary>
		/// <returns></returns>
		public static OutWork_DBll GetInstence() {
			if (_OutWork_DBll == null) {
				_OutWork_DBll = new OutWork_DBll();
			}
			return _OutWork_DBll;
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
		
		#region 從IIS緩存中獲取OutWork_D表記錄
		/// <summary>
        /// 從IIS緩存中獲取OutWork_D表記錄
        /// </summary>
	    /// <param name="isCache">是否從緩存中讀取</param>
        public IList<DataAccess.Model.OutWork_D> GetList(bool isCache = true)
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
						return (IList<DataAccess.Model.OutWork_D>)obj;
					}
				}
				else
				{
					//定義臨時實伐集
					IList<DataAccess.Model.OutWork_D> list = null;

					//獲??表緩存加載條件表達式
					var exp = GetExpression<OutWork_D>();
                    //?果條件為空，則查詢?表所有記錄
					if (exp == null)
					{
						//從數據庫中獲?所有記錄
						var all = OutWork_D.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //從數據庫中查詢出指定條件的記錄，並轉換為指定實伐集
						var all = OutWork_D.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取OutWork_D表記錄時出現異常", e);
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
		/// <returns>DataAccess.Model.OutWork_D</returns>
        public DataAccess.Model.OutWork_D GetModel(long id, bool isCache = true)
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
                var model = OutWork_D.SingleOrDefault(x => x.Id == id);
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
		/// <returns>DataAccess.Model.OutWork_D</returns>
        public DataAccess.Model.OutWork_D GetModelForCache(long id)
        {
			try
			{
				//從緩存中讀?指定Id記錄
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//從數據庫中讀?
					var tem = OutWork_D.SingleOrDefault(x => x.Id == id);
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
                CommonBll.WriteLog("從IIS緩存中獲取OutWork_D表記錄時出現異常", e);

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
        /// <returns>DataAccess.Model.OutWork_D</returns>
        public DataAccess.Model.OutWork_D GetModelForCache(string conditionColName, object value)
        {
			try
            {
                //從緩存中獲取List
                var list = GetList();
                DataAccess.Model.OutWork_D model = null;
                Expression<Func<OutWork_D, bool>> expression = null;

                //返回指定條件的實伐
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (long)value);
                        expression = x => x.Id == (long)value;
                        break;
					case "bill_id" :
						model = list.SingleOrDefault(x => x.bill_id == (string)value);
                        expression = x => x.bill_id == (string)value;
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
					case "bill_date" :
						model = list.SingleOrDefault(x => x.bill_date == (DateTime)value);
                        expression = x => x.bill_date == (DateTime)value;
                        break;
					case "begin_time" :
						model = list.SingleOrDefault(x => x.begin_time == (DateTime)value);
                        expression = x => x.begin_time == (DateTime)value;
                        break;
					case "end_time" :
						model = list.SingleOrDefault(x => x.end_time == (DateTime)value);
                        expression = x => x.end_time == (DateTime)value;
                        break;
					case "work_type" :
						model = list.SingleOrDefault(x => x.work_type == (string)value);
                        expression = x => x.work_type == (string)value;
                        break;
					case "work_days" :
						model = list.SingleOrDefault(x => x.work_days == (decimal)value);
                        expression = x => x.work_days == (decimal)value;
                        break;
					case "status_id" :
						model = list.SingleOrDefault(x => x.status_id == (int)value);
                        expression = x => x.status_id == (int)value;
                        break;
					case "leave_id" :
						model = list.SingleOrDefault(x => x.leave_id == (string)value);
                        expression = x => x.leave_id == (string)value;
                        break;
					case "rate" :
						model = list.SingleOrDefault(x => x.rate == (decimal)value);
                        expression = x => x.rate == (decimal)value;
                        break;
					case "checker" :
						model = list.SingleOrDefault(x => x.checker == (string)value);
                        expression = x => x.checker == (string)value;
                        break;
					case "check_date" :
						model = list.SingleOrDefault(x => x.check_date == (DateTime)value);
                        expression = x => x.check_date == (DateTime)value;
                        break;
					case "op_user" :
						model = list.SingleOrDefault(x => x.op_user == (string)value);
                        expression = x => x.op_user == (string)value;
                        break;
					case "op_date" :
						model = list.SingleOrDefault(x => x.op_date == (DateTime)value);
                        expression = x => x.op_date == (DateTime)value;
                        break;
					case "audit" :
						model = list.SingleOrDefault(x => x.audit == (short)value);
                        expression = x => x.audit == (short)value;
                        break;
					case "memo" :
						model = list.SingleOrDefault(x => x.memo == (string)value);
                        expression = x => x.memo == (string)value;
                        break;
					case "outwork_type" :
						model = list.SingleOrDefault(x => x.outwork_type == (string)value);
                        expression = x => x.outwork_type == (string)value;
                        break;
					case "outwork_addr" :
						model = list.SingleOrDefault(x => x.outwork_addr == (string)value);
                        expression = x => x.outwork_addr == (string)value;
                        break;
					case "transportation" :
						model = list.SingleOrDefault(x => x.transportation == (string)value);
                        expression = x => x.transportation == (string)value;
                        break;
					case "Re_date" :
						model = list.SingleOrDefault(x => x.Re_date == (DateTime)value);
                        expression = x => x.Re_date == (DateTime)value;
                        break;
					case "Start_ag" :
						model = list.SingleOrDefault(x => x.Start_ag == (string)value);
                        expression = x => x.Start_ag == (string)value;
                        break;
					case "re_ag" :
						model = list.SingleOrDefault(x => x.re_ag == (string)value);
                        expression = x => x.re_ag == (string)value;
                        break;
					case "peers" :
						model = list.SingleOrDefault(x => x.peers == (int)value);
                        expression = x => x.peers == (int)value;
                        break;
					case "Hostel" :
						model = list.SingleOrDefault(x => x.Hostel == (int)value);
                        expression = x => x.Hostel == (int)value;
                        break;
					case "hotel" :
						model = list.SingleOrDefault(x => x.hotel == (int)value);
                        expression = x => x.hotel == (int)value;
                        break;
					case "hotel_type" :
						model = list.SingleOrDefault(x => x.hotel_type == (string)value);
                        expression = x => x.hotel_type == (string)value;
                        break;
					case "reply" :
						model = list.SingleOrDefault(x => x.reply == (string)value);
                        expression = x => x.reply == (string)value;
                        break;
					case "work_hrs" :
						model = list.SingleOrDefault(x => x.work_hrs == (decimal)value);
                        expression = x => x.work_hrs == (decimal)value;
                        break;
					case "is_input" :
						model = list.SingleOrDefault(x => x.is_input == (short)value);
                        expression = x => x.is_input == (short)value;
                        break;
					case "refuse_reason" :
						model = list.SingleOrDefault(x => x.refuse_reason == (string)value);
                        expression = x => x.refuse_reason == (string)value;
                        break;
					case "CHECKER2" :
						model = list.SingleOrDefault(x => x.CHECKER2 == (string)value);
                        expression = x => x.CHECKER2 == (string)value;
                        break;
					case "audit2" :
						model = list.SingleOrDefault(x => x.audit2 == (short)value);
                        expression = x => x.audit2 == (short)value;
                        break;
					case "IsHotel" :
						model = list.SingleOrDefault(x => x.IsHotel == (short)value);
                        expression = x => x.IsHotel == (short)value;
                        break;
					case "IsCar" :
						model = list.SingleOrDefault(x => x.IsCar == (short)value);
                        expression = x => x.IsCar == (short)value;
                        break;
					case "Itinerary" :
						model = list.SingleOrDefault(x => x.Itinerary == (string)value);
                        expression = x => x.Itinerary == (string)value;
                        break;
					case "Destination" :
						model = list.SingleOrDefault(x => x.Destination == (string)value);
                        expression = x => x.Destination == (string)value;
                        break;
					case "IDate" :
						model = list.SingleOrDefault(x => x.IDate == (string)value);
                        expression = x => x.IDate == (string)value;
                        break;
					case "Nights" :
						model = list.SingleOrDefault(x => x.Nights == (string)value);
                        expression = x => x.Nights == (string)value;
                        break;
					case "reply2" :
						model = list.SingleOrDefault(x => x.reply2 == (string)value);
                        expression = x => x.reply2 == (string)value;
                        break;
					case "itinerary2" :
						model = list.SingleOrDefault(x => x.itinerary2 == (string)value);
                        expression = x => x.itinerary2 == (string)value;
                        break;
					case "itinerary3" :
						model = list.SingleOrDefault(x => x.itinerary3 == (string)value);
                        expression = x => x.itinerary3 == (string)value;
                        break;
					case "itinerary4" :
						model = list.SingleOrDefault(x => x.itinerary4 == (string)value);
                        expression = x => x.itinerary4 == (string)value;
                        break;
					case "IDate2" :
						model = list.SingleOrDefault(x => x.IDate2 == (string)value);
                        expression = x => x.IDate2 == (string)value;
                        break;
					case "IDate3" :
						model = list.SingleOrDefault(x => x.IDate3 == (string)value);
                        expression = x => x.IDate3 == (string)value;
                        break;
					case "IDate4" :
						model = list.SingleOrDefault(x => x.IDate4 == (string)value);
                        expression = x => x.IDate4 == (string)value;
                        break;
					case "Destination2" :
						model = list.SingleOrDefault(x => x.Destination2 == (string)value);
                        expression = x => x.Destination2 == (string)value;
                        break;
					case "Destination3" :
						model = list.SingleOrDefault(x => x.Destination3 == (string)value);
                        expression = x => x.Destination3 == (string)value;
                        break;
					case "Destination4" :
						model = list.SingleOrDefault(x => x.Destination4 == (string)value);
                        expression = x => x.Destination4 == (string)value;
                        break;
					case "Nights2" :
						model = list.SingleOrDefault(x => x.Nights2 == (string)value);
                        expression = x => x.Nights2 == (string)value;
                        break;
					case "Nights3" :
						model = list.SingleOrDefault(x => x.Nights3 == (string)value);
                        expression = x => x.Nights3 == (string)value;
                        break;
					case "Nights4" :
						model = list.SingleOrDefault(x => x.Nights4 == (string)value);
                        expression = x => x.Nights4 == (string)value;
                        break;
					case "check_date2" :
						model = list.SingleOrDefault(x => x.check_date2 == (DateTime)value);
                        expression = x => x.check_date2 == (DateTime)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //從數據庫中讀取
                    var tem = OutWork_D.SingleOrDefault(expression);
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
                CommonBll.WriteLog("從IIS緩存中獲取OutWork_D表記錄時出現異常", e);

                return null;
            }
        }
        #endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="expression">條件</param>
        /// <returns>DataAccess.Model.OutWork_D</returns>
        public DataAccess.Model.OutWork_D GetModelForCache(Expression<Func<DataAccess.Model.OutWork_D, bool>> expression)
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
        public void SetModelForCache(DataAccess.Model.OutWork_D model)
        {
			if (model == null) return;
			
            //從緩存中刪除記錄
            DelCache(model.Id);

            //從緩存中讀?記錄列表
            var list = GetList();
		    if (list == null)
		    {
                list = new List<DataAccess.Model.OutWork_D>();
		    }
            //添加記錄
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(OutWork_D model)
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
        /// 按條件刪除IIS緩存中OutWork_D表的指定記錄
        /// </summary>
        /// <param name="expression">條件，值為null時刪除?有記錄</param>
		public void DelCache(Expression<Func<DataAccess.Model.OutWork_D, bool>> expression)
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
		/// 將OutWork_D記錄實伐（SubSonic實伐）轉換為?通的實伐（DataAccess.Model.OutWork_D）
		/// </summary>
        /// <param name="model">SubSonic插件生成的實伐</param>
		/// <returns>DataAccess.Model.OutWork_D</returns>
		public DataAccess.Model.OutWork_D Transform(OutWork_D model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.OutWork_D
            {
                Id = model.Id,
                bill_id = model.bill_id,
                emp_id = model.emp_id,
                join_id = model.join_id,
                depart_id = model.depart_id,
                bill_date = model.bill_date,
                begin_time = model.begin_time,
                end_time = model.end_time,
                work_type = model.work_type,
                work_days = model.work_days,
                status_id = model.status_id,
                leave_id = model.leave_id,
                rate = model.rate,
                checker = model.checker,
                check_date = model.check_date,
                op_user = model.op_user,
                op_date = model.op_date,
                audit = model.audit,
                memo = model.memo,
                outwork_type = model.outwork_type,
                outwork_addr = model.outwork_addr,
                transportation = model.transportation,
                Re_date = model.Re_date,
                Start_ag = model.Start_ag,
                re_ag = model.re_ag,
                peers = model.peers,
                Hostel = model.Hostel,
                hotel = model.hotel,
                hotel_type = model.hotel_type,
                reply = model.reply,
                work_hrs = model.work_hrs,
                is_input = model.is_input,
                refuse_reason = model.refuse_reason,
                CHECKER2 = model.CHECKER2,
                audit2 = model.audit2,
                IsHotel = model.IsHotel,
                IsCar = model.IsCar,
                Itinerary = model.Itinerary,
                Destination = model.Destination,
                IDate = model.IDate,
                Nights = model.Nights,
                reply2 = model.reply2,
                itinerary2 = model.itinerary2,
                itinerary3 = model.itinerary3,
                itinerary4 = model.itinerary4,
                IDate2 = model.IDate2,
                IDate3 = model.IDate3,
                IDate4 = model.IDate4,
                Destination2 = model.Destination2,
                Destination3 = model.Destination3,
                Destination4 = model.Destination4,
                Nights2 = model.Nights2,
                Nights3 = model.Nights3,
                Nights4 = model.Nights4,
                check_date2 = model.check_date2,
            };
        }

		/// <summary>
		/// 將OutWork_D記錄實伐集（SubSonic實伐）轉換為?通的實伐集（DataAccess.Model.OutWork_D）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的實伐集</param>
        public IList<DataAccess.Model.OutWork_D> Transform(IList<OutWork_D> sourceList)
        {
			//創建List??
            var list = new List<DataAccess.Model.OutWork_D>();
			//將SubSonic插件生成的實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 將OutWork_D記錄實伐批?通的實伐（DataAccess.Model.OutWork_D）轉換為SubSonic插件生成的實伐
		/// </summary>
        /// <param name="model">?通的實伐（DataAccess.Model.OutWork_D）</param>
		/// <returns>OutWork_D</returns>
		public OutWork_D Transform(DataAccess.Model.OutWork_D model)
        {
			if (model == null) 
				return null;

            return new OutWork_D
            {
                Id = model.Id,
                bill_id = model.bill_id,
                emp_id = model.emp_id,
                join_id = model.join_id,
                depart_id = model.depart_id,
                bill_date = model.bill_date,
                begin_time = model.begin_time,
                end_time = model.end_time,
                work_type = model.work_type,
                work_days = model.work_days,
                status_id = model.status_id,
                leave_id = model.leave_id,
                rate = model.rate,
                checker = model.checker,
                check_date = model.check_date,
                op_user = model.op_user,
                op_date = model.op_date,
                audit = model.audit,
                memo = model.memo,
                outwork_type = model.outwork_type,
                outwork_addr = model.outwork_addr,
                transportation = model.transportation,
                Re_date = model.Re_date,
                Start_ag = model.Start_ag,
                re_ag = model.re_ag,
                peers = model.peers,
                Hostel = model.Hostel,
                hotel = model.hotel,
                hotel_type = model.hotel_type,
                reply = model.reply,
                work_hrs = model.work_hrs,
                is_input = model.is_input,
                refuse_reason = model.refuse_reason,
                CHECKER2 = model.CHECKER2,
                audit2 = model.audit2,
                IsHotel = model.IsHotel,
                IsCar = model.IsCar,
                Itinerary = model.Itinerary,
                Destination = model.Destination,
                IDate = model.IDate,
                Nights = model.Nights,
                reply2 = model.reply2,
                itinerary2 = model.itinerary2,
                itinerary3 = model.itinerary3,
                itinerary4 = model.itinerary4,
                IDate2 = model.IDate2,
                IDate3 = model.IDate3,
                IDate4 = model.IDate4,
                Destination2 = model.Destination2,
                Destination3 = model.Destination3,
                Destination4 = model.Destination4,
                Nights2 = model.Nights2,
                Nights3 = model.Nights3,
                Nights4 = model.Nights4,
                check_date2 = model.check_date2,
            };
        }

		/// <summary>
		/// 將OutWork_D記錄實伐批?通實伐集（DataAccess.Model.OutWork_D）轉換為SubSonic插件生成的實伐集
		/// </summary>
        /// <param name="sourceList">?通實伐集（DataAccess.Model.OutWork_D）</param>
        public IList<OutWork_D> Transform(IList<DataAccess.Model.OutWork_D> sourceList)
        {
			//創建List??
            var list = new List<OutWork_D>();
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
		public void SetModelValue(DataAccess.Model.OutWork_D model, Dictionary<string, object> dic)
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
		public void SetModelValue(DataAccess.Model.OutWork_D model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定條件的實伐
            switch (colName)
            {
				case "Id" :
					model.Id = (long)value;
                    break;
				case "bill_id" :
					model.bill_id = (string)value;
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
				case "bill_date" :
					model.bill_date = (DateTime)value;
                    break;
				case "begin_time" :
					model.begin_time = (DateTime)value;
                    break;
				case "end_time" :
					model.end_time = (DateTime)value;
                    break;
				case "work_type" :
					model.work_type = (string)value;
                    break;
				case "work_days" :
					model.work_days = (decimal)value;
                    break;
				case "status_id" :
					model.status_id = (int)value;
                    break;
				case "leave_id" :
					model.leave_id = (string)value;
                    break;
				case "rate" :
					model.rate = (decimal)value;
                    break;
				case "checker" :
					model.checker = (string)value;
                    break;
				case "check_date" :
					model.check_date = (DateTime)value;
                    break;
				case "op_user" :
					model.op_user = (string)value;
                    break;
				case "op_date" :
					model.op_date = (DateTime)value;
                    break;
				case "audit" :
					model.audit = (short)value;
                    break;
				case "memo" :
					model.memo = (string)value;
                    break;
				case "outwork_type" :
					model.outwork_type = (string)value;
                    break;
				case "outwork_addr" :
					model.outwork_addr = (string)value;
                    break;
				case "transportation" :
					model.transportation = (string)value;
                    break;
				case "Re_date" :
					model.Re_date = (DateTime)value;
                    break;
				case "Start_ag" :
					model.Start_ag = (string)value;
                    break;
				case "re_ag" :
					model.re_ag = (string)value;
                    break;
				case "peers" :
					model.peers = (int)value;
                    break;
				case "Hostel" :
					model.Hostel = (int)value;
                    break;
				case "hotel" :
					model.hotel = (int)value;
                    break;
				case "hotel_type" :
					model.hotel_type = (string)value;
                    break;
				case "reply" :
					model.reply = (string)value;
                    break;
				case "work_hrs" :
					model.work_hrs = (decimal)value;
                    break;
				case "is_input" :
					model.is_input = (short)value;
                    break;
				case "refuse_reason" :
					model.refuse_reason = (string)value;
                    break;
				case "CHECKER2" :
					model.CHECKER2 = (string)value;
                    break;
				case "audit2" :
					model.audit2 = (short)value;
                    break;
				case "IsHotel" :
					model.IsHotel = (short)value;
                    break;
				case "IsCar" :
					model.IsCar = (short)value;
                    break;
				case "Itinerary" :
					model.Itinerary = (string)value;
                    break;
				case "Destination" :
					model.Destination = (string)value;
                    break;
				case "IDate" :
					model.IDate = (string)value;
                    break;
				case "Nights" :
					model.Nights = (string)value;
                    break;
				case "reply2" :
					model.reply2 = (string)value;
                    break;
				case "itinerary2" :
					model.itinerary2 = (string)value;
                    break;
				case "itinerary3" :
					model.itinerary3 = (string)value;
                    break;
				case "itinerary4" :
					model.itinerary4 = (string)value;
                    break;
				case "IDate2" :
					model.IDate2 = (string)value;
                    break;
				case "IDate3" :
					model.IDate3 = (string)value;
                    break;
				case "IDate4" :
					model.IDate4 = (string)value;
                    break;
				case "Destination2" :
					model.Destination2 = (string)value;
                    break;
				case "Destination3" :
					model.Destination3 = (string)value;
                    break;
				case "Destination4" :
					model.Destination4 = (string)value;
                    break;
				case "Nights2" :
					model.Nights2 = (string)value;
                    break;
				case "Nights3" :
					model.Nights3 = (string)value;
                    break;
				case "Nights4" :
					model.Nights4 = (string)value;
                    break;
				case "check_date2" :
					model.check_date2 = (DateTime)value;
                    break;
            }
		}

        #endregion

		#endregion

		#region 獲?OutWork_D表記錄總數
        /// <summary>
        /// 獲?OutWork_D表記錄總數
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
				return select.GetRecordCount<OutWork_D>();
			}
        }

		/// <summary>
		/// 獲?OutWork_D表記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="wheres">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionHelper.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<OutWork_D>(wheres);

		}

		/// <summary>
		/// 獲?OutWork_D表指定條件的記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="expression">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<OutWork_D, bool>> expression) {
            return new Select().From<OutWork_D>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定條件的記錄集合
        /// <summary>
        /// 查找指定條件的記錄集合——從IIS緩存中查找
        /// </summary>
        /// <param name="expression">條件語句</param>
        public IList<DataAccess.Model.OutWork_D> Find(Expression<Func<DataAccess.Model.OutWork_D, bool>> expression)
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
            return OutWork_D.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判斷指定條件的記錄是否存在——默?在IIS緩存中查找，?果沒開?緩存時，則直接在數據庫中查詢出列表後，再從列表中查詢
        /// </summary>
        /// <param name="expression">條件語句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.OutWork_D, bool>> expression)
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

		#region 獲?OutWork_D表記錄
		/// <summary>
		/// 獲?OutWork_D表記錄
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
                return select.SelectDataTable<OutWork_D>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("獲?OutWork_D表記錄時出現異常", e);

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

		#region 添加與編輯OutWork_D表記錄
		/// <summary>
		/// 添加與編輯OutWork_D記錄
		/// </summary>
	    /// <param name="page">當?頁面指針</param>
		/// <param name="model">OutWork_D表實伐</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Save(Page page, OutWork_D model, string content = null, bool isCache = true, bool isAddUseLog = true)
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
						content = "{0}" + (model.Id == 0 ? "添加" : "編輯") + "OutWork_D記錄成功，ID為【" + model.Id + "】";
					}

					//添加用戶訪問記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "執行OutWork_DBll.Save()函數出錯！";

				//出現異常，保存出錯?志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 刪除OutWork_D表記錄
		/// <summary>
		/// 刪除OutWork_D表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", OutWork_DTable.TableName,  OutWork_DTable.Id, id);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了OutWork_D表id為【" + id + "】的記錄！");
			}
		}

		/// <summary>
		/// 刪除OutWork_D表記錄
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
			var sql = string.Format("delete from {0} where {1} in ({2})", OutWork_DTable.TableName,  OutWork_DTable.Id, str);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了OutWork_D表id為【" + str + "】的記錄！");
			}
		}

		/// <summary>
        /// 刪除OutWork_D表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Delete(Page page, Expression<Func<OutWork_D, bool>> expression, bool isAddUseLog = true)
        {
			//執行刪除
			OutWork_D.Delete(expression);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了OutWork_D表記錄！");
			}
        }

		/// <summary>
        /// 刪除OutWork_D表所有記錄
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void DeleteAll(Page page, bool isAddUseLog = true)
        {
            //設瞞Sql語句
            var sql = string.Format("delete from {0}", OutWork_DTable.TableName);

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
                UseLogBll.GetInstence().Save(page, "{0}刪除了OutWork_D表所有記錄！");
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
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "OutWork_D", sortName, "Id"))
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
				UseLogBll.GetInstence().Save(page, "{0}更新了OutWork_D表排序！");

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
			if (CommonBll.AutoSort("Id", "OutWork_D", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
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
				UseLogBll.GetInstence().Save(page, "{0}對OutWork_D表進行了自動排序操作！");

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
	                conditionColName = OutWork_DTable.Id;
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
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.OutWork_D, bool>> expression)
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
            return select.GetColumnsValue<OutWork_D>(colName, wheres);
        }

		/// <summary>
        /// 返回實伐中指定字段名的值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">獲?的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.OutWork_D model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "bill_id" :
					return model.bill_id;
				case "emp_id" :
					return model.emp_id;
				case "join_id" :
					return model.join_id;
				case "depart_id" :
					return model.depart_id;
				case "bill_date" :
					return model.bill_date;
				case "begin_time" :
					return model.begin_time;
				case "end_time" :
					return model.end_time;
				case "work_type" :
					return model.work_type;
				case "work_days" :
					return model.work_days;
				case "status_id" :
					return model.status_id;
				case "leave_id" :
					return model.leave_id;
				case "rate" :
					return model.rate;
				case "checker" :
					return model.checker;
				case "check_date" :
					return model.check_date;
				case "op_user" :
					return model.op_user;
				case "op_date" :
					return model.op_date;
				case "audit" :
					return model.audit;
				case "memo" :
					return model.memo;
				case "outwork_type" :
					return model.outwork_type;
				case "outwork_addr" :
					return model.outwork_addr;
				case "transportation" :
					return model.transportation;
				case "Re_date" :
					return model.Re_date;
				case "Start_ag" :
					return model.Start_ag;
				case "re_ag" :
					return model.re_ag;
				case "peers" :
					return model.peers;
				case "Hostel" :
					return model.Hostel;
				case "hotel" :
					return model.hotel;
				case "hotel_type" :
					return model.hotel_type;
				case "reply" :
					return model.reply;
				case "work_hrs" :
					return model.work_hrs;
				case "is_input" :
					return model.is_input;
				case "refuse_reason" :
					return model.refuse_reason;
				case "CHECKER2" :
					return model.CHECKER2;
				case "audit2" :
					return model.audit2;
				case "IsHotel" :
					return model.IsHotel;
				case "IsCar" :
					return model.IsCar;
				case "Itinerary" :
					return model.Itinerary;
				case "Destination" :
					return model.Destination;
				case "IDate" :
					return model.IDate;
				case "Nights" :
					return model.Nights;
				case "reply2" :
					return model.reply2;
				case "itinerary2" :
					return model.itinerary2;
				case "itinerary3" :
					return model.itinerary3;
				case "itinerary4" :
					return model.itinerary4;
				case "IDate2" :
					return model.IDate2;
				case "IDate3" :
					return model.IDate3;
				case "IDate4" :
					return model.IDate4;
				case "Destination2" :
					return model.Destination2;
				case "Destination3" :
					return model.Destination3;
				case "Destination4" :
					return model.Destination4;
				case "Nights2" :
					return model.Nights2;
				case "Nights3" :
					return model.Nights3;
				case "Nights4" :
					return model.Nights4;
				case "check_date2" :
					return model.check_date2;
			}

			return null;
		}

		#endregion
		
		#region 更新OutWork_D表指定字段值
		/// <summary>更新OutWork_D表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="dic">需要更新的字段與值</param>
		/// <param name="wheres">條件</param>
		/// <param name="content">更新說明</param>
		/// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionHelper.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<OutWork_D>(dic, wheres);

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
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}囊改了OutWork_D表記錄。");				
				}
				else
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新OutWork_D表指定主鍵Id的字段值
		/// <summary>更新OutWork_D表記錄指定字段值</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue(Page page, long id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了OutWork_D表主鍵Id值為" + id + "的記錄。";
			
            //條件
		    List<ConditionHelper.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OutWork_DTable.Id, Comparison.Equals, id));
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

        /// <summary>更新OutWork_D表記錄指定字段值（更新一個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, long id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了OutWork_D表主鍵Id值為" + id + "的記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新OutWork_D表記錄指定字段值（更新兩個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName1">要更新的列名</param>
        /// <param name="columnValue1">要更新的列值</param>
        /// <param name="columnName2">要更新的列名</param>
        /// <param name="columnValue2">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, long id, string columnName1, object columnValue1, string columnName2, object columnValue2, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了OutWork_D表主鍵Id值為" + id + "的記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
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
