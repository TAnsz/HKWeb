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
	/// Shifts表邏輯類
	/// </summary>
	public partial class ShiftsBll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函數                                                        *
		 ***********************************************************************/
		#region 模版生成函數
				
		private const string const_CacheKey = "Cache_Shifts";
        private const string const_CacheKey_Date = "Cache_Shifts_Date";

		#region 單例模式
		//定義單例實伐
		private static ShiftsBll _ShiftsBll = null;

		/// <summary>
		/// 獲取本邏輯類單例
		/// </summary>
		/// <returns></returns>
		public static ShiftsBll GetInstence() {
			if (_ShiftsBll == null) {
				_ShiftsBll = new ShiftsBll();
			}
			return _ShiftsBll;
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
		
		#region 從IIS緩存中獲取Shifts表記錄
		/// <summary>
        /// 從IIS緩存中獲取Shifts表記錄
        /// </summary>
	    /// <param name="isCache">是否從緩存中讀取</param>
        public IList<DataAccess.Model.Shifts> GetList(bool isCache = true)
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
						return (IList<DataAccess.Model.Shifts>)obj;
					}
				}
				else
				{
					//定義臨時實伐集
					IList<DataAccess.Model.Shifts> list = null;

					//獲??表緩存加載條件表達式
					var exp = GetExpression<Shifts>();
                    //?果條件為空，則查詢?表所有記錄
					if (exp == null)
					{
						//從數據庫中獲?所有記錄
						var all = Shifts.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //從數據庫中查詢出指定條件的記錄，並轉換為指定實伐集
						var all = Shifts.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取Shifts表記錄時出現異常", e);
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
		/// <returns>DataAccess.Model.Shifts</returns>
        public DataAccess.Model.Shifts GetModel(long id, bool isCache = true)
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
                var model = Shifts.SingleOrDefault(x => x.Id == id);
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
		/// <returns>DataAccess.Model.Shifts</returns>
        public DataAccess.Model.Shifts GetModelForCache(long id)
        {
			try
			{
				//從緩存中讀?指定Id記錄
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//從數據庫中讀?
					var tem = Shifts.SingleOrDefault(x => x.Id == id);
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
                CommonBll.WriteLog("從IIS緩存中獲取Shifts表記錄時出現異常", e);

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
        /// <returns>DataAccess.Model.Shifts</returns>
        public DataAccess.Model.Shifts GetModelForCache(string conditionColName, object value)
        {
			try
            {
                //從緩存中獲取List
                var list = GetList();
                DataAccess.Model.Shifts model = null;
                Expression<Func<Shifts, bool>> expression = null;

                //返回指定條件的實伐
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (int)value);
                        expression = x => x.Id == (int)value;
                        break;
					case "SHIFT_ID" :
						model = list.SingleOrDefault(x => x.SHIFT_ID == (string)value);
                        expression = x => x.SHIFT_ID == (string)value;
                        break;
					case "SHIFT_NAME" :
						model = list.SingleOrDefault(x => x.SHIFT_NAME == (string)value);
                        expression = x => x.SHIFT_NAME == (string)value;
                        break;
					case "DEPART_ID" :
						model = list.SingleOrDefault(x => x.DEPART_ID == (string)value);
                        expression = x => x.DEPART_ID == (string)value;
                        break;
					case "SHIFT_KIND" :
						model = list.SingleOrDefault(x => x.SHIFT_KIND == (int)value);
                        expression = x => x.SHIFT_KIND == (int)value;
                        break;
					case "WORK_HRS" :
						model = list.SingleOrDefault(x => x.WORK_HRS == (decimal)value);
                        expression = x => x.WORK_HRS == (decimal)value;
                        break;
					case "NEED_HRS" :
						model = list.SingleOrDefault(x => x.NEED_HRS == (decimal)value);
                        expression = x => x.NEED_HRS == (decimal)value;
                        break;
					case "IS_DEFAULT" :
						model = list.SingleOrDefault(x => x.IS_DEFAULT == (short)value);
                        expression = x => x.IS_DEFAULT == (short)value;
                        break;
					case "RULE_ID" :
						model = list.SingleOrDefault(x => x.RULE_ID == (string)value);
                        expression = x => x.RULE_ID == (string)value;
                        break;
					case "CLASS_ID" :
						model = list.SingleOrDefault(x => x.CLASS_ID == (int)value);
                        expression = x => x.CLASS_ID == (int)value;
                        break;
					case "NEED_SIGN_COUNT" :
						model = list.SingleOrDefault(x => x.NEED_SIGN_COUNT == (int)value);
                        expression = x => x.NEED_SIGN_COUNT == (int)value;
                        break;
					case "IS_COMMON" :
						model = list.SingleOrDefault(x => x.IS_COMMON == (short)value);
                        expression = x => x.IS_COMMON == (short)value;
                        break;
					case "AHEAD1" :
						model = list.SingleOrDefault(x => x.AHEAD1 == (int)value);
                        expression = x => x.AHEAD1 == (int)value;
                        break;
					case "IN1" :
						model = list.SingleOrDefault(x => x.IN1 == (DateTime)value);
                        expression = x => x.IN1 == (DateTime)value;
                        break;
					case "NEEDIN1" :
						model = list.SingleOrDefault(x => x.NEEDIN1 == (short)value);
                        expression = x => x.NEEDIN1 == (short)value;
                        break;
					case "BOVERTIME1" :
						model = list.SingleOrDefault(x => x.BOVERTIME1 == (short)value);
                        expression = x => x.BOVERTIME1 == (short)value;
                        break;
					case "OUT1" :
						model = list.SingleOrDefault(x => x.OUT1 == (DateTime)value);
                        expression = x => x.OUT1 == (DateTime)value;
                        break;
					case "DELAY1" :
						model = list.SingleOrDefault(x => x.DELAY1 == (short)value);
                        expression = x => x.DELAY1 == (short)value;
                        break;
					case "NEEDOUT1" :
						model = list.SingleOrDefault(x => x.NEEDOUT1 == (short)value);
                        expression = x => x.NEEDOUT1 == (short)value;
                        break;
					case "EOVERTIME1" :
						model = list.SingleOrDefault(x => x.EOVERTIME1 == (short)value);
                        expression = x => x.EOVERTIME1 == (short)value;
                        break;
					case "REST1" :
						model = list.SingleOrDefault(x => x.REST1 == (short)value);
                        expression = x => x.REST1 == (short)value;
                        break;
					case "REST_BEGIN1" :
						model = list.SingleOrDefault(x => x.REST_BEGIN1 == (DateTime)value);
                        expression = x => x.REST_BEGIN1 == (DateTime)value;
                        break;
					case "BREAK1" :
						model = list.SingleOrDefault(x => x.BREAK1 == (short)value);
                        expression = x => x.BREAK1 == (short)value;
                        break;
					case "OT1" :
						model = list.SingleOrDefault(x => x.OT1 == (short)value);
                        expression = x => x.OT1 == (short)value;
                        break;
					case "EXT1" :
						model = list.SingleOrDefault(x => x.EXT1 == (short)value);
                        expression = x => x.EXT1 == (short)value;
                        break;
					case "CANOT1" :
						model = list.SingleOrDefault(x => x.CANOT1 == (short)value);
                        expression = x => x.CANOT1 == (short)value;
                        break;
					case "OT_REST1" :
						model = list.SingleOrDefault(x => x.OT_REST1 == (int)value);
                        expression = x => x.OT_REST1 == (int)value;
                        break;
					case "OT_REST_BEGIN1" :
						model = list.SingleOrDefault(x => x.OT_REST_BEGIN1 == (DateTime)value);
                        expression = x => x.OT_REST_BEGIN1 == (DateTime)value;
                        break;
					case "BASICHRS1" :
						model = list.SingleOrDefault(x => x.BASICHRS1 == (decimal)value);
                        expression = x => x.BASICHRS1 == (decimal)value;
                        break;
					case "NEEDHRS1" :
						model = list.SingleOrDefault(x => x.NEEDHRS1 == (decimal)value);
                        expression = x => x.NEEDHRS1 == (decimal)value;
                        break;
					case "DAY1" :
						model = list.SingleOrDefault(x => x.DAY1 == (decimal)value);
                        expression = x => x.DAY1 == (decimal)value;
                        break;
					case "AHEAD2" :
						model = list.SingleOrDefault(x => x.AHEAD2 == (int)value);
                        expression = x => x.AHEAD2 == (int)value;
                        break;
					case "IN2" :
						model = list.SingleOrDefault(x => x.IN2 == (DateTime)value);
                        expression = x => x.IN2 == (DateTime)value;
                        break;
					case "NEEDIN2" :
						model = list.SingleOrDefault(x => x.NEEDIN2 == (short)value);
                        expression = x => x.NEEDIN2 == (short)value;
                        break;
					case "BOVERTIME2" :
						model = list.SingleOrDefault(x => x.BOVERTIME2 == (short)value);
                        expression = x => x.BOVERTIME2 == (short)value;
                        break;
					case "OUT2" :
						model = list.SingleOrDefault(x => x.OUT2 == (DateTime)value);
                        expression = x => x.OUT2 == (DateTime)value;
                        break;
					case "DELAY2" :
						model = list.SingleOrDefault(x => x.DELAY2 == (short)value);
                        expression = x => x.DELAY2 == (short)value;
                        break;
					case "NEEDOUT2" :
						model = list.SingleOrDefault(x => x.NEEDOUT2 == (short)value);
                        expression = x => x.NEEDOUT2 == (short)value;
                        break;
					case "EOVERTIME2" :
						model = list.SingleOrDefault(x => x.EOVERTIME2 == (short)value);
                        expression = x => x.EOVERTIME2 == (short)value;
                        break;
					case "REST2" :
						model = list.SingleOrDefault(x => x.REST2 == (short)value);
                        expression = x => x.REST2 == (short)value;
                        break;
					case "REST_BEGIN2" :
						model = list.SingleOrDefault(x => x.REST_BEGIN2 == (DateTime)value);
                        expression = x => x.REST_BEGIN2 == (DateTime)value;
                        break;
					case "BREAK2" :
						model = list.SingleOrDefault(x => x.BREAK2 == (short)value);
                        expression = x => x.BREAK2 == (short)value;
                        break;
					case "OT2" :
						model = list.SingleOrDefault(x => x.OT2 == (short)value);
                        expression = x => x.OT2 == (short)value;
                        break;
					case "EXT2" :
						model = list.SingleOrDefault(x => x.EXT2 == (short)value);
                        expression = x => x.EXT2 == (short)value;
                        break;
					case "CANOT2" :
						model = list.SingleOrDefault(x => x.CANOT2 == (short)value);
                        expression = x => x.CANOT2 == (short)value;
                        break;
					case "OT_REST2" :
						model = list.SingleOrDefault(x => x.OT_REST2 == (int)value);
                        expression = x => x.OT_REST2 == (int)value;
                        break;
					case "OT_REST_BEGIN2" :
						model = list.SingleOrDefault(x => x.OT_REST_BEGIN2 == (DateTime)value);
                        expression = x => x.OT_REST_BEGIN2 == (DateTime)value;
                        break;
					case "BASICHRS2" :
						model = list.SingleOrDefault(x => x.BASICHRS2 == (decimal)value);
                        expression = x => x.BASICHRS2 == (decimal)value;
                        break;
					case "NEEDHRS2" :
						model = list.SingleOrDefault(x => x.NEEDHRS2 == (decimal)value);
                        expression = x => x.NEEDHRS2 == (decimal)value;
                        break;
					case "DAY2" :
						model = list.SingleOrDefault(x => x.DAY2 == (decimal)value);
                        expression = x => x.DAY2 == (decimal)value;
                        break;
					case "AHEAD3" :
						model = list.SingleOrDefault(x => x.AHEAD3 == (int)value);
                        expression = x => x.AHEAD3 == (int)value;
                        break;
					case "IN3" :
						model = list.SingleOrDefault(x => x.IN3 == (DateTime)value);
                        expression = x => x.IN3 == (DateTime)value;
                        break;
					case "NEEDIN3" :
						model = list.SingleOrDefault(x => x.NEEDIN3 == (short)value);
                        expression = x => x.NEEDIN3 == (short)value;
                        break;
					case "BOVERTIME3" :
						model = list.SingleOrDefault(x => x.BOVERTIME3 == (short)value);
                        expression = x => x.BOVERTIME3 == (short)value;
                        break;
					case "OUT3" :
						model = list.SingleOrDefault(x => x.OUT3 == (DateTime)value);
                        expression = x => x.OUT3 == (DateTime)value;
                        break;
					case "DELAY3" :
						model = list.SingleOrDefault(x => x.DELAY3 == (short)value);
                        expression = x => x.DELAY3 == (short)value;
                        break;
					case "NEEDOUT3" :
						model = list.SingleOrDefault(x => x.NEEDOUT3 == (short)value);
                        expression = x => x.NEEDOUT3 == (short)value;
                        break;
					case "EOVERTIME3" :
						model = list.SingleOrDefault(x => x.EOVERTIME3 == (short)value);
                        expression = x => x.EOVERTIME3 == (short)value;
                        break;
					case "REST3" :
						model = list.SingleOrDefault(x => x.REST3 == (short)value);
                        expression = x => x.REST3 == (short)value;
                        break;
					case "REST_BEGIN3" :
						model = list.SingleOrDefault(x => x.REST_BEGIN3 == (DateTime)value);
                        expression = x => x.REST_BEGIN3 == (DateTime)value;
                        break;
					case "BREAK3" :
						model = list.SingleOrDefault(x => x.BREAK3 == (short)value);
                        expression = x => x.BREAK3 == (short)value;
                        break;
					case "OT3" :
						model = list.SingleOrDefault(x => x.OT3 == (short)value);
                        expression = x => x.OT3 == (short)value;
                        break;
					case "EXT3" :
						model = list.SingleOrDefault(x => x.EXT3 == (short)value);
                        expression = x => x.EXT3 == (short)value;
                        break;
					case "CANOT3" :
						model = list.SingleOrDefault(x => x.CANOT3 == (short)value);
                        expression = x => x.CANOT3 == (short)value;
                        break;
					case "OT_REST3" :
						model = list.SingleOrDefault(x => x.OT_REST3 == (int)value);
                        expression = x => x.OT_REST3 == (int)value;
                        break;
					case "OT_REST_BEGIN3" :
						model = list.SingleOrDefault(x => x.OT_REST_BEGIN3 == (DateTime)value);
                        expression = x => x.OT_REST_BEGIN3 == (DateTime)value;
                        break;
					case "BASICHRS3" :
						model = list.SingleOrDefault(x => x.BASICHRS3 == (decimal)value);
                        expression = x => x.BASICHRS3 == (decimal)value;
                        break;
					case "NEEDHRS3" :
						model = list.SingleOrDefault(x => x.NEEDHRS3 == (decimal)value);
                        expression = x => x.NEEDHRS3 == (decimal)value;
                        break;
					case "DAY3" :
						model = list.SingleOrDefault(x => x.DAY3 == (decimal)value);
                        expression = x => x.DAY3 == (decimal)value;
                        break;
					case "AHEAD4" :
						model = list.SingleOrDefault(x => x.AHEAD4 == (int)value);
                        expression = x => x.AHEAD4 == (int)value;
                        break;
					case "IN4" :
						model = list.SingleOrDefault(x => x.IN4 == (DateTime)value);
                        expression = x => x.IN4 == (DateTime)value;
                        break;
					case "NEEDIN4" :
						model = list.SingleOrDefault(x => x.NEEDIN4 == (short)value);
                        expression = x => x.NEEDIN4 == (short)value;
                        break;
					case "BOVERTIME4" :
						model = list.SingleOrDefault(x => x.BOVERTIME4 == (short)value);
                        expression = x => x.BOVERTIME4 == (short)value;
                        break;
					case "OUT4" :
						model = list.SingleOrDefault(x => x.OUT4 == (DateTime)value);
                        expression = x => x.OUT4 == (DateTime)value;
                        break;
					case "DELAY4" :
						model = list.SingleOrDefault(x => x.DELAY4 == (short)value);
                        expression = x => x.DELAY4 == (short)value;
                        break;
					case "NEEDOUT4" :
						model = list.SingleOrDefault(x => x.NEEDOUT4 == (short)value);
                        expression = x => x.NEEDOUT4 == (short)value;
                        break;
					case "EOVERTIME4" :
						model = list.SingleOrDefault(x => x.EOVERTIME4 == (short)value);
                        expression = x => x.EOVERTIME4 == (short)value;
                        break;
					case "REST4" :
						model = list.SingleOrDefault(x => x.REST4 == (short)value);
                        expression = x => x.REST4 == (short)value;
                        break;
					case "REST_BEGIN4" :
						model = list.SingleOrDefault(x => x.REST_BEGIN4 == (DateTime)value);
                        expression = x => x.REST_BEGIN4 == (DateTime)value;
                        break;
					case "BREAK4" :
						model = list.SingleOrDefault(x => x.BREAK4 == (short)value);
                        expression = x => x.BREAK4 == (short)value;
                        break;
					case "OT4" :
						model = list.SingleOrDefault(x => x.OT4 == (short)value);
                        expression = x => x.OT4 == (short)value;
                        break;
					case "EXT4" :
						model = list.SingleOrDefault(x => x.EXT4 == (short)value);
                        expression = x => x.EXT4 == (short)value;
                        break;
					case "CANOT4" :
						model = list.SingleOrDefault(x => x.CANOT4 == (short)value);
                        expression = x => x.CANOT4 == (short)value;
                        break;
					case "OT_REST4" :
						model = list.SingleOrDefault(x => x.OT_REST4 == (int)value);
                        expression = x => x.OT_REST4 == (int)value;
                        break;
					case "OT_REST_BEGIN4" :
						model = list.SingleOrDefault(x => x.OT_REST_BEGIN4 == (DateTime)value);
                        expression = x => x.OT_REST_BEGIN4 == (DateTime)value;
                        break;
					case "BASICHRS4" :
						model = list.SingleOrDefault(x => x.BASICHRS4 == (decimal)value);
                        expression = x => x.BASICHRS4 == (decimal)value;
                        break;
					case "NEEDHRS4" :
						model = list.SingleOrDefault(x => x.NEEDHRS4 == (decimal)value);
                        expression = x => x.NEEDHRS4 == (decimal)value;
                        break;
					case "DAY4" :
						model = list.SingleOrDefault(x => x.DAY4 == (decimal)value);
                        expression = x => x.DAY4 == (decimal)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //從數據庫中讀取
                    var tem = Shifts.SingleOrDefault(expression);
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
                CommonBll.WriteLog("從IIS緩存中獲取Shifts表記錄時出現異常", e);

                return null;
            }
        }
        #endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="expression">條件</param>
        /// <returns>DataAccess.Model.Shifts</returns>
        public DataAccess.Model.Shifts GetModelForCache(Expression<Func<DataAccess.Model.Shifts, bool>> expression)
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
        public void SetModelForCache(DataAccess.Model.Shifts model)
        {
			if (model == null) return;
			
            //從緩存中刪除記錄
            DelCache(model.Id);

            //從緩存中讀?記錄列表
            var list = GetList();
		    if (list == null)
		    {
                list = new List<DataAccess.Model.Shifts>();
		    }
            //添加記錄
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(Shifts model)
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
        /// 按條件刪除IIS緩存中Shifts表的指定記錄
        /// </summary>
        /// <param name="expression">條件，值為null時刪除?有記錄</param>
		public void DelCache(Expression<Func<DataAccess.Model.Shifts, bool>> expression)
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
		/// 將Shifts記錄實伐（SubSonic實伐）轉換為?通的實伐（DataAccess.Model.Shifts）
		/// </summary>
        /// <param name="model">SubSonic插件生成的實伐</param>
		/// <returns>DataAccess.Model.Shifts</returns>
		public DataAccess.Model.Shifts Transform(Shifts model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.Shifts
            {
                Id = model.Id,
                SHIFT_ID = model.SHIFT_ID,
                SHIFT_NAME = model.SHIFT_NAME,
                DEPART_ID = model.DEPART_ID,
                SHIFT_KIND = model.SHIFT_KIND,
                WORK_HRS = model.WORK_HRS,
                NEED_HRS = model.NEED_HRS,
                IS_DEFAULT = model.IS_DEFAULT,
                RULE_ID = model.RULE_ID,
                CLASS_ID = model.CLASS_ID,
                NEED_SIGN_COUNT = model.NEED_SIGN_COUNT,
                IS_COMMON = model.IS_COMMON,
                AHEAD1 = model.AHEAD1,
                IN1 = model.IN1,
                NEEDIN1 = model.NEEDIN1,
                BOVERTIME1 = model.BOVERTIME1,
                OUT1 = model.OUT1,
                DELAY1 = model.DELAY1,
                NEEDOUT1 = model.NEEDOUT1,
                EOVERTIME1 = model.EOVERTIME1,
                REST1 = model.REST1,
                REST_BEGIN1 = model.REST_BEGIN1,
                BREAK1 = model.BREAK1,
                OT1 = model.OT1,
                EXT1 = model.EXT1,
                CANOT1 = model.CANOT1,
                OT_REST1 = model.OT_REST1,
                OT_REST_BEGIN1 = model.OT_REST_BEGIN1,
                BASICHRS1 = model.BASICHRS1,
                NEEDHRS1 = model.NEEDHRS1,
                DAY1 = model.DAY1,
                AHEAD2 = model.AHEAD2,
                IN2 = model.IN2,
                NEEDIN2 = model.NEEDIN2,
                BOVERTIME2 = model.BOVERTIME2,
                OUT2 = model.OUT2,
                DELAY2 = model.DELAY2,
                NEEDOUT2 = model.NEEDOUT2,
                EOVERTIME2 = model.EOVERTIME2,
                REST2 = model.REST2,
                REST_BEGIN2 = model.REST_BEGIN2,
                BREAK2 = model.BREAK2,
                OT2 = model.OT2,
                EXT2 = model.EXT2,
                CANOT2 = model.CANOT2,
                OT_REST2 = model.OT_REST2,
                OT_REST_BEGIN2 = model.OT_REST_BEGIN2,
                BASICHRS2 = model.BASICHRS2,
                NEEDHRS2 = model.NEEDHRS2,
                DAY2 = model.DAY2,
                AHEAD3 = model.AHEAD3,
                IN3 = model.IN3,
                NEEDIN3 = model.NEEDIN3,
                BOVERTIME3 = model.BOVERTIME3,
                OUT3 = model.OUT3,
                DELAY3 = model.DELAY3,
                NEEDOUT3 = model.NEEDOUT3,
                EOVERTIME3 = model.EOVERTIME3,
                REST3 = model.REST3,
                REST_BEGIN3 = model.REST_BEGIN3,
                BREAK3 = model.BREAK3,
                OT3 = model.OT3,
                EXT3 = model.EXT3,
                CANOT3 = model.CANOT3,
                OT_REST3 = model.OT_REST3,
                OT_REST_BEGIN3 = model.OT_REST_BEGIN3,
                BASICHRS3 = model.BASICHRS3,
                NEEDHRS3 = model.NEEDHRS3,
                DAY3 = model.DAY3,
                AHEAD4 = model.AHEAD4,
                IN4 = model.IN4,
                NEEDIN4 = model.NEEDIN4,
                BOVERTIME4 = model.BOVERTIME4,
                OUT4 = model.OUT4,
                DELAY4 = model.DELAY4,
                NEEDOUT4 = model.NEEDOUT4,
                EOVERTIME4 = model.EOVERTIME4,
                REST4 = model.REST4,
                REST_BEGIN4 = model.REST_BEGIN4,
                BREAK4 = model.BREAK4,
                OT4 = model.OT4,
                EXT4 = model.EXT4,
                CANOT4 = model.CANOT4,
                OT_REST4 = model.OT_REST4,
                OT_REST_BEGIN4 = model.OT_REST_BEGIN4,
                BASICHRS4 = model.BASICHRS4,
                NEEDHRS4 = model.NEEDHRS4,
                DAY4 = model.DAY4,
            };
        }

		/// <summary>
		/// 將Shifts記錄實伐集（SubSonic實伐）轉換為?通的實伐集（DataAccess.Model.Shifts）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的實伐集</param>
        public IList<DataAccess.Model.Shifts> Transform(IList<Shifts> sourceList)
        {
			//創建List??
            var list = new List<DataAccess.Model.Shifts>();
			//將SubSonic插件生成的實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 將Shifts記錄實伐批?通的實伐（DataAccess.Model.Shifts）轉換為SubSonic插件生成的實伐
		/// </summary>
        /// <param name="model">?通的實伐（DataAccess.Model.Shifts）</param>
		/// <returns>Shifts</returns>
		public Shifts Transform(DataAccess.Model.Shifts model)
        {
			if (model == null) 
				return null;

            return new Shifts
            {
                Id = model.Id,
                SHIFT_ID = model.SHIFT_ID,
                SHIFT_NAME = model.SHIFT_NAME,
                DEPART_ID = model.DEPART_ID,
                SHIFT_KIND = model.SHIFT_KIND,
                WORK_HRS = model.WORK_HRS,
                NEED_HRS = model.NEED_HRS,
                IS_DEFAULT = model.IS_DEFAULT,
                RULE_ID = model.RULE_ID,
                CLASS_ID = model.CLASS_ID,
                NEED_SIGN_COUNT = model.NEED_SIGN_COUNT,
                IS_COMMON = model.IS_COMMON,
                AHEAD1 = model.AHEAD1,
                IN1 = model.IN1,
                NEEDIN1 = model.NEEDIN1,
                BOVERTIME1 = model.BOVERTIME1,
                OUT1 = model.OUT1,
                DELAY1 = model.DELAY1,
                NEEDOUT1 = model.NEEDOUT1,
                EOVERTIME1 = model.EOVERTIME1,
                REST1 = model.REST1,
                REST_BEGIN1 = model.REST_BEGIN1,
                BREAK1 = model.BREAK1,
                OT1 = model.OT1,
                EXT1 = model.EXT1,
                CANOT1 = model.CANOT1,
                OT_REST1 = model.OT_REST1,
                OT_REST_BEGIN1 = model.OT_REST_BEGIN1,
                BASICHRS1 = model.BASICHRS1,
                NEEDHRS1 = model.NEEDHRS1,
                DAY1 = model.DAY1,
                AHEAD2 = model.AHEAD2,
                IN2 = model.IN2,
                NEEDIN2 = model.NEEDIN2,
                BOVERTIME2 = model.BOVERTIME2,
                OUT2 = model.OUT2,
                DELAY2 = model.DELAY2,
                NEEDOUT2 = model.NEEDOUT2,
                EOVERTIME2 = model.EOVERTIME2,
                REST2 = model.REST2,
                REST_BEGIN2 = model.REST_BEGIN2,
                BREAK2 = model.BREAK2,
                OT2 = model.OT2,
                EXT2 = model.EXT2,
                CANOT2 = model.CANOT2,
                OT_REST2 = model.OT_REST2,
                OT_REST_BEGIN2 = model.OT_REST_BEGIN2,
                BASICHRS2 = model.BASICHRS2,
                NEEDHRS2 = model.NEEDHRS2,
                DAY2 = model.DAY2,
                AHEAD3 = model.AHEAD3,
                IN3 = model.IN3,
                NEEDIN3 = model.NEEDIN3,
                BOVERTIME3 = model.BOVERTIME3,
                OUT3 = model.OUT3,
                DELAY3 = model.DELAY3,
                NEEDOUT3 = model.NEEDOUT3,
                EOVERTIME3 = model.EOVERTIME3,
                REST3 = model.REST3,
                REST_BEGIN3 = model.REST_BEGIN3,
                BREAK3 = model.BREAK3,
                OT3 = model.OT3,
                EXT3 = model.EXT3,
                CANOT3 = model.CANOT3,
                OT_REST3 = model.OT_REST3,
                OT_REST_BEGIN3 = model.OT_REST_BEGIN3,
                BASICHRS3 = model.BASICHRS3,
                NEEDHRS3 = model.NEEDHRS3,
                DAY3 = model.DAY3,
                AHEAD4 = model.AHEAD4,
                IN4 = model.IN4,
                NEEDIN4 = model.NEEDIN4,
                BOVERTIME4 = model.BOVERTIME4,
                OUT4 = model.OUT4,
                DELAY4 = model.DELAY4,
                NEEDOUT4 = model.NEEDOUT4,
                EOVERTIME4 = model.EOVERTIME4,
                REST4 = model.REST4,
                REST_BEGIN4 = model.REST_BEGIN4,
                BREAK4 = model.BREAK4,
                OT4 = model.OT4,
                EXT4 = model.EXT4,
                CANOT4 = model.CANOT4,
                OT_REST4 = model.OT_REST4,
                OT_REST_BEGIN4 = model.OT_REST_BEGIN4,
                BASICHRS4 = model.BASICHRS4,
                NEEDHRS4 = model.NEEDHRS4,
                DAY4 = model.DAY4,
            };
        }

		/// <summary>
		/// 將Shifts記錄實伐批?通實伐集（DataAccess.Model.Shifts）轉換為SubSonic插件生成的實伐集
		/// </summary>
        /// <param name="sourceList">?通實伐集（DataAccess.Model.Shifts）</param>
        public IList<Shifts> Transform(IList<DataAccess.Model.Shifts> sourceList)
        {
			//創建List??
            var list = new List<Shifts>();
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
		public void SetModelValue(DataAccess.Model.Shifts model, Dictionary<string, object> dic)
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
		public void SetModelValue(DataAccess.Model.Shifts model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定條件的實伐
            switch (colName)
            {
				case "Id" :
					model.Id = (int)value;
                    break;
				case "SHIFT_ID" :
					model.SHIFT_ID = (string)value;
                    break;
				case "SHIFT_NAME" :
					model.SHIFT_NAME = (string)value;
                    break;
				case "DEPART_ID" :
					model.DEPART_ID = (string)value;
                    break;
				case "SHIFT_KIND" :
					model.SHIFT_KIND = (int)value;
                    break;
				case "WORK_HRS" :
					model.WORK_HRS = (decimal)value;
                    break;
				case "NEED_HRS" :
					model.NEED_HRS = (decimal)value;
                    break;
				case "IS_DEFAULT" :
					model.IS_DEFAULT = (short)value;
                    break;
				case "RULE_ID" :
					model.RULE_ID = (string)value;
                    break;
				case "CLASS_ID" :
					model.CLASS_ID = (int)value;
                    break;
				case "NEED_SIGN_COUNT" :
					model.NEED_SIGN_COUNT = (int)value;
                    break;
				case "IS_COMMON" :
					model.IS_COMMON = (short)value;
                    break;
				case "AHEAD1" :
					model.AHEAD1 = (int)value;
                    break;
				case "IN1" :
					model.IN1 = (DateTime)value;
                    break;
				case "NEEDIN1" :
					model.NEEDIN1 = (short)value;
                    break;
				case "BOVERTIME1" :
					model.BOVERTIME1 = (short)value;
                    break;
				case "OUT1" :
					model.OUT1 = (DateTime)value;
                    break;
				case "DELAY1" :
					model.DELAY1 = (short)value;
                    break;
				case "NEEDOUT1" :
					model.NEEDOUT1 = (short)value;
                    break;
				case "EOVERTIME1" :
					model.EOVERTIME1 = (short)value;
                    break;
				case "REST1" :
					model.REST1 = (short)value;
                    break;
				case "REST_BEGIN1" :
					model.REST_BEGIN1 = (DateTime)value;
                    break;
				case "BREAK1" :
					model.BREAK1 = (short)value;
                    break;
				case "OT1" :
					model.OT1 = (short)value;
                    break;
				case "EXT1" :
					model.EXT1 = (short)value;
                    break;
				case "CANOT1" :
					model.CANOT1 = (short)value;
                    break;
				case "OT_REST1" :
					model.OT_REST1 = (int)value;
                    break;
				case "OT_REST_BEGIN1" :
					model.OT_REST_BEGIN1 = (DateTime)value;
                    break;
				case "BASICHRS1" :
					model.BASICHRS1 = (decimal)value;
                    break;
				case "NEEDHRS1" :
					model.NEEDHRS1 = (decimal)value;
                    break;
				case "DAY1" :
					model.DAY1 = (decimal)value;
                    break;
				case "AHEAD2" :
					model.AHEAD2 = (int)value;
                    break;
				case "IN2" :
					model.IN2 = (DateTime)value;
                    break;
				case "NEEDIN2" :
					model.NEEDIN2 = (short)value;
                    break;
				case "BOVERTIME2" :
					model.BOVERTIME2 = (short)value;
                    break;
				case "OUT2" :
					model.OUT2 = (DateTime)value;
                    break;
				case "DELAY2" :
					model.DELAY2 = (short)value;
                    break;
				case "NEEDOUT2" :
					model.NEEDOUT2 = (short)value;
                    break;
				case "EOVERTIME2" :
					model.EOVERTIME2 = (short)value;
                    break;
				case "REST2" :
					model.REST2 = (short)value;
                    break;
				case "REST_BEGIN2" :
					model.REST_BEGIN2 = (DateTime)value;
                    break;
				case "BREAK2" :
					model.BREAK2 = (short)value;
                    break;
				case "OT2" :
					model.OT2 = (short)value;
                    break;
				case "EXT2" :
					model.EXT2 = (short)value;
                    break;
				case "CANOT2" :
					model.CANOT2 = (short)value;
                    break;
				case "OT_REST2" :
					model.OT_REST2 = (int)value;
                    break;
				case "OT_REST_BEGIN2" :
					model.OT_REST_BEGIN2 = (DateTime)value;
                    break;
				case "BASICHRS2" :
					model.BASICHRS2 = (decimal)value;
                    break;
				case "NEEDHRS2" :
					model.NEEDHRS2 = (decimal)value;
                    break;
				case "DAY2" :
					model.DAY2 = (decimal)value;
                    break;
				case "AHEAD3" :
					model.AHEAD3 = (int)value;
                    break;
				case "IN3" :
					model.IN3 = (DateTime)value;
                    break;
				case "NEEDIN3" :
					model.NEEDIN3 = (short)value;
                    break;
				case "BOVERTIME3" :
					model.BOVERTIME3 = (short)value;
                    break;
				case "OUT3" :
					model.OUT3 = (DateTime)value;
                    break;
				case "DELAY3" :
					model.DELAY3 = (short)value;
                    break;
				case "NEEDOUT3" :
					model.NEEDOUT3 = (short)value;
                    break;
				case "EOVERTIME3" :
					model.EOVERTIME3 = (short)value;
                    break;
				case "REST3" :
					model.REST3 = (short)value;
                    break;
				case "REST_BEGIN3" :
					model.REST_BEGIN3 = (DateTime)value;
                    break;
				case "BREAK3" :
					model.BREAK3 = (short)value;
                    break;
				case "OT3" :
					model.OT3 = (short)value;
                    break;
				case "EXT3" :
					model.EXT3 = (short)value;
                    break;
				case "CANOT3" :
					model.CANOT3 = (short)value;
                    break;
				case "OT_REST3" :
					model.OT_REST3 = (int)value;
                    break;
				case "OT_REST_BEGIN3" :
					model.OT_REST_BEGIN3 = (DateTime)value;
                    break;
				case "BASICHRS3" :
					model.BASICHRS3 = (decimal)value;
                    break;
				case "NEEDHRS3" :
					model.NEEDHRS3 = (decimal)value;
                    break;
				case "DAY3" :
					model.DAY3 = (decimal)value;
                    break;
				case "AHEAD4" :
					model.AHEAD4 = (int)value;
                    break;
				case "IN4" :
					model.IN4 = (DateTime)value;
                    break;
				case "NEEDIN4" :
					model.NEEDIN4 = (short)value;
                    break;
				case "BOVERTIME4" :
					model.BOVERTIME4 = (short)value;
                    break;
				case "OUT4" :
					model.OUT4 = (DateTime)value;
                    break;
				case "DELAY4" :
					model.DELAY4 = (short)value;
                    break;
				case "NEEDOUT4" :
					model.NEEDOUT4 = (short)value;
                    break;
				case "EOVERTIME4" :
					model.EOVERTIME4 = (short)value;
                    break;
				case "REST4" :
					model.REST4 = (short)value;
                    break;
				case "REST_BEGIN4" :
					model.REST_BEGIN4 = (DateTime)value;
                    break;
				case "BREAK4" :
					model.BREAK4 = (short)value;
                    break;
				case "OT4" :
					model.OT4 = (short)value;
                    break;
				case "EXT4" :
					model.EXT4 = (short)value;
                    break;
				case "CANOT4" :
					model.CANOT4 = (short)value;
                    break;
				case "OT_REST4" :
					model.OT_REST4 = (int)value;
                    break;
				case "OT_REST_BEGIN4" :
					model.OT_REST_BEGIN4 = (DateTime)value;
                    break;
				case "BASICHRS4" :
					model.BASICHRS4 = (decimal)value;
                    break;
				case "NEEDHRS4" :
					model.NEEDHRS4 = (decimal)value;
                    break;
				case "DAY4" :
					model.DAY4 = (decimal)value;
                    break;
            }
		}

        #endregion

		#endregion

		#region 獲?Shifts表記錄總數
        /// <summary>
        /// 獲?Shifts表記錄總數
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
				return select.GetRecordCount<Shifts>();
			}
        }

		/// <summary>
		/// 獲?Shifts表記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="wheres">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionHelper.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<Shifts>(wheres);

		}

		/// <summary>
		/// 獲?Shifts表指定條件的記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="expression">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<Shifts, bool>> expression) {
            return new Select().From<Shifts>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定條件的記錄集合
        /// <summary>
        /// 查找指定條件的記錄集合——從IIS緩存中查找
        /// </summary>
        /// <param name="expression">條件語句</param>
        public IList<DataAccess.Model.Shifts> Find(Expression<Func<DataAccess.Model.Shifts, bool>> expression)
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
            return Shifts.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判斷指定條件的記錄是否存在——默?在IIS緩存中查找，?果沒開?緩存時，則直接在數據庫中查詢出列表後，再從列表中查詢
        /// </summary>
        /// <param name="expression">條件語句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.Shifts, bool>> expression)
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

		#region 獲?Shifts表記錄
		/// <summary>
		/// 獲?Shifts表記錄
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
                return select.SelectDataTable<Shifts>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("獲?Shifts表記錄時出現異常", e);

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

		#region 添加與編輯Shifts表記錄
		/// <summary>
		/// 添加與編輯Shifts記錄
		/// </summary>
	    /// <param name="page">當?頁面指針</param>
		/// <param name="model">Shifts表實伐</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Save(Page page, Shifts model, string content = null, bool isCache = true, bool isAddUseLog = true)
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
						content = "{0}" + (model.Id == 0 ? "添加" : "編輯") + "Shifts記錄成功，ID為【" + model.Id + "】";
					}

					//添加用戶訪問記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "執行ShiftsBll.Save()函數出錯！";

				//出現異常，保存出錯?志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 刪除Shifts表記錄
		/// <summary>
		/// 刪除Shifts表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", ShiftsTable.TableName,  ShiftsTable.Id, id);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了Shifts表id為【" + id + "】的記錄！");
			}
		}

		/// <summary>
		/// 刪除Shifts表記錄
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
			var sql = string.Format("delete from {0} where {1} in ({2})", ShiftsTable.TableName,  ShiftsTable.Id, str);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了Shifts表id為【" + str + "】的記錄！");
			}
		}

		/// <summary>
        /// 刪除Shifts表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Delete(Page page, Expression<Func<Shifts, bool>> expression, bool isAddUseLog = true)
        {
			//執行刪除
			Shifts.Delete(expression);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了Shifts表記錄！");
			}
        }

		/// <summary>
        /// 刪除Shifts表所有記錄
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void DeleteAll(Page page, bool isAddUseLog = true)
        {
            //設瞞Sql語句
            var sql = string.Format("delete from {0}", ShiftsTable.TableName);

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
                UseLogBll.GetInstence().Save(page, "{0}刪除了Shifts表所有記錄！");
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
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "Shifts", sortName, "SHIFT_ID"))
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
				UseLogBll.GetInstence().Save(page, "{0}更新了Shifts表排序！");

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
			if (CommonBll.AutoSort("SHIFT_ID", "Shifts", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
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
				UseLogBll.GetInstence().Save(page, "{0}對Shifts表進行了自動排序操作！");

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
	                conditionColName = ShiftsTable.Id;
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
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.Shifts, bool>> expression)
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
            return select.GetColumnsValue<Shifts>(colName, wheres);
        }

		/// <summary>
        /// 返回實伐中指定字段名的值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">獲?的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.Shifts model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "SHIFT_ID" :
					return model.SHIFT_ID;
				case "SHIFT_NAME" :
					return model.SHIFT_NAME;
				case "DEPART_ID" :
					return model.DEPART_ID;
				case "SHIFT_KIND" :
					return model.SHIFT_KIND;
				case "WORK_HRS" :
					return model.WORK_HRS;
				case "NEED_HRS" :
					return model.NEED_HRS;
				case "IS_DEFAULT" :
					return model.IS_DEFAULT;
				case "RULE_ID" :
					return model.RULE_ID;
				case "CLASS_ID" :
					return model.CLASS_ID;
				case "NEED_SIGN_COUNT" :
					return model.NEED_SIGN_COUNT;
				case "IS_COMMON" :
					return model.IS_COMMON;
				case "AHEAD1" :
					return model.AHEAD1;
				case "IN1" :
					return model.IN1;
				case "NEEDIN1" :
					return model.NEEDIN1;
				case "BOVERTIME1" :
					return model.BOVERTIME1;
				case "OUT1" :
					return model.OUT1;
				case "DELAY1" :
					return model.DELAY1;
				case "NEEDOUT1" :
					return model.NEEDOUT1;
				case "EOVERTIME1" :
					return model.EOVERTIME1;
				case "REST1" :
					return model.REST1;
				case "REST_BEGIN1" :
					return model.REST_BEGIN1;
				case "BREAK1" :
					return model.BREAK1;
				case "OT1" :
					return model.OT1;
				case "EXT1" :
					return model.EXT1;
				case "CANOT1" :
					return model.CANOT1;
				case "OT_REST1" :
					return model.OT_REST1;
				case "OT_REST_BEGIN1" :
					return model.OT_REST_BEGIN1;
				case "BASICHRS1" :
					return model.BASICHRS1;
				case "NEEDHRS1" :
					return model.NEEDHRS1;
				case "DAY1" :
					return model.DAY1;
				case "AHEAD2" :
					return model.AHEAD2;
				case "IN2" :
					return model.IN2;
				case "NEEDIN2" :
					return model.NEEDIN2;
				case "BOVERTIME2" :
					return model.BOVERTIME2;
				case "OUT2" :
					return model.OUT2;
				case "DELAY2" :
					return model.DELAY2;
				case "NEEDOUT2" :
					return model.NEEDOUT2;
				case "EOVERTIME2" :
					return model.EOVERTIME2;
				case "REST2" :
					return model.REST2;
				case "REST_BEGIN2" :
					return model.REST_BEGIN2;
				case "BREAK2" :
					return model.BREAK2;
				case "OT2" :
					return model.OT2;
				case "EXT2" :
					return model.EXT2;
				case "CANOT2" :
					return model.CANOT2;
				case "OT_REST2" :
					return model.OT_REST2;
				case "OT_REST_BEGIN2" :
					return model.OT_REST_BEGIN2;
				case "BASICHRS2" :
					return model.BASICHRS2;
				case "NEEDHRS2" :
					return model.NEEDHRS2;
				case "DAY2" :
					return model.DAY2;
				case "AHEAD3" :
					return model.AHEAD3;
				case "IN3" :
					return model.IN3;
				case "NEEDIN3" :
					return model.NEEDIN3;
				case "BOVERTIME3" :
					return model.BOVERTIME3;
				case "OUT3" :
					return model.OUT3;
				case "DELAY3" :
					return model.DELAY3;
				case "NEEDOUT3" :
					return model.NEEDOUT3;
				case "EOVERTIME3" :
					return model.EOVERTIME3;
				case "REST3" :
					return model.REST3;
				case "REST_BEGIN3" :
					return model.REST_BEGIN3;
				case "BREAK3" :
					return model.BREAK3;
				case "OT3" :
					return model.OT3;
				case "EXT3" :
					return model.EXT3;
				case "CANOT3" :
					return model.CANOT3;
				case "OT_REST3" :
					return model.OT_REST3;
				case "OT_REST_BEGIN3" :
					return model.OT_REST_BEGIN3;
				case "BASICHRS3" :
					return model.BASICHRS3;
				case "NEEDHRS3" :
					return model.NEEDHRS3;
				case "DAY3" :
					return model.DAY3;
				case "AHEAD4" :
					return model.AHEAD4;
				case "IN4" :
					return model.IN4;
				case "NEEDIN4" :
					return model.NEEDIN4;
				case "BOVERTIME4" :
					return model.BOVERTIME4;
				case "OUT4" :
					return model.OUT4;
				case "DELAY4" :
					return model.DELAY4;
				case "NEEDOUT4" :
					return model.NEEDOUT4;
				case "EOVERTIME4" :
					return model.EOVERTIME4;
				case "REST4" :
					return model.REST4;
				case "REST_BEGIN4" :
					return model.REST_BEGIN4;
				case "BREAK4" :
					return model.BREAK4;
				case "OT4" :
					return model.OT4;
				case "EXT4" :
					return model.EXT4;
				case "CANOT4" :
					return model.CANOT4;
				case "OT_REST4" :
					return model.OT_REST4;
				case "OT_REST_BEGIN4" :
					return model.OT_REST_BEGIN4;
				case "BASICHRS4" :
					return model.BASICHRS4;
				case "NEEDHRS4" :
					return model.NEEDHRS4;
				case "DAY4" :
					return model.DAY4;
			}

			return null;
		}

		#endregion
		
		#region 更新Shifts表指定字段值
		/// <summary>更新Shifts表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="dic">需要更新的字段與值</param>
		/// <param name="wheres">條件</param>
		/// <param name="content">更新說明</param>
		/// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionHelper.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<Shifts>(dic, wheres);

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
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}囊改了Shifts表記錄。");				
				}
				else
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新Shifts表指定主鍵Id的字段值
		/// <summary>更新Shifts表記錄指定字段值</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue(Page page, int id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Shifts表主鍵Id值為" + id + "的記錄。";
			
            //條件
		    List<ConditionHelper.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, ShiftsTable.Id, Comparison.Equals, id));
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

        /// <summary>更新Shifts表記錄指定字段值（更新一個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, int id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了Shifts表主鍵Id值為" + id + "的記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新Shifts表記錄指定字段值（更新兩個字段值）</summary>
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
            content = content != "" ? content : "{0}囊改了Shifts表主鍵Id值為" + id + "的記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 獲取SHIFT_NAME字段值
        /// <summary>
        /// 獲?SHIFT_NAME字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetSHIFT_NAME(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.SHIFT_NAME;
            }
            else
            {
                //從數據庫中查詢
                var model = Shifts.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.SHIFT_NAME;
            }
        }
        #endregion

    
		#endregion 模版生成函數

    } 
}
