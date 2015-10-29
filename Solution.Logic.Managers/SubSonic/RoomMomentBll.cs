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
	/// RoomMoment表邏輯類
	/// </summary>
	public partial class RoomMomentBll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函數                                                        *
		 ***********************************************************************/
		#region 模版生成函數
				
		private const string const_CacheKey = "Cache_RoomMoment";
        private const string const_CacheKey_Date = "Cache_RoomMoment_Date";

		#region 單例模式
		//定義單例實伐
		private static RoomMomentBll _RoomMomentBll = null;

		/// <summary>
		/// 獲取本邏輯類單例
		/// </summary>
		/// <returns></returns>
		public static RoomMomentBll GetInstence() {
			if (_RoomMomentBll == null) {
				_RoomMomentBll = new RoomMomentBll();
			}
			return _RoomMomentBll;
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
		
		#region 從IIS緩存中獲取RoomMoment表記錄
		/// <summary>
        /// 從IIS緩存中獲取RoomMoment表記錄
        /// </summary>
	    /// <param name="isCache">是否從緩存中讀取</param>
        public IList<DataAccess.Model.RoomMoment> GetList(bool isCache = true)
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
						return (IList<DataAccess.Model.RoomMoment>)obj;
					}
				}
				else
				{
					//定義臨時實伐集
					IList<DataAccess.Model.RoomMoment> list = null;

					//獲??表緩存加載條件表達式
					var exp = GetExpression<RoomMoment>();
                    //?果條件為空，則查詢?表所有記錄
					if (exp == null)
					{
						//從數據庫中獲?所有記錄
						var all = RoomMoment.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //從數據庫中查詢出指定條件的記錄，並轉換為指定實伐集
						var all = RoomMoment.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取RoomMoment表記錄時出現異常", e);
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
		/// <returns>DataAccess.Model.RoomMoment</returns>
        public DataAccess.Model.RoomMoment GetModel(long id, bool isCache = true)
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
                var model = RoomMoment.SingleOrDefault(x => x.Id == id);
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
		/// <returns>DataAccess.Model.RoomMoment</returns>
        public DataAccess.Model.RoomMoment GetModelForCache(long id)
        {
			try
			{
				//從緩存中讀?指定Id記錄
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//從數據庫中讀?
					var tem = RoomMoment.SingleOrDefault(x => x.Id == id);
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
                CommonBll.WriteLog("從IIS緩存中獲取RoomMoment表記錄時出現異常", e);

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
        /// <returns>DataAccess.Model.RoomMoment</returns>
        public DataAccess.Model.RoomMoment GetModelForCache(string conditionColName, object value)
        {
			try
            {
                //從緩存中獲取List
                var list = GetList();
                DataAccess.Model.RoomMoment model = null;
                Expression<Func<RoomMoment, bool>> expression = null;

                //返回指定條件的實伐
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (long)value);
                        expression = x => x.Id == (long)value;
                        break;
					case "MeetingRoom_Code" :
						model = list.SingleOrDefault(x => x.MeetingRoom_Code == (string)value);
                        expression = x => x.MeetingRoom_Code == (string)value;
                        break;
					case "MeetingRoom_Name" :
						model = list.SingleOrDefault(x => x.MeetingRoom_Name == (string)value);
                        expression = x => x.MeetingRoom_Name == (string)value;
                        break;
					case "RoomDate" :
						model = list.SingleOrDefault(x => x.RoomDate == (DateTime)value);
                        expression = x => x.RoomDate == (DateTime)value;
                        break;
					case "T0830" :
						model = list.SingleOrDefault(x => x.T0830 == (byte)value);
                        expression = x => x.T0830 == (byte)value;
                        break;
					case "T0900" :
						model = list.SingleOrDefault(x => x.T0900 == (byte)value);
                        expression = x => x.T0900 == (byte)value;
                        break;
					case "T0930" :
						model = list.SingleOrDefault(x => x.T0930 == (byte)value);
                        expression = x => x.T0930 == (byte)value;
                        break;
					case "T1000" :
						model = list.SingleOrDefault(x => x.T1000 == (byte)value);
                        expression = x => x.T1000 == (byte)value;
                        break;
					case "T1030" :
						model = list.SingleOrDefault(x => x.T1030 == (byte)value);
                        expression = x => x.T1030 == (byte)value;
                        break;
					case "T1100" :
						model = list.SingleOrDefault(x => x.T1100 == (byte)value);
                        expression = x => x.T1100 == (byte)value;
                        break;
					case "T1130" :
						model = list.SingleOrDefault(x => x.T1130 == (byte)value);
                        expression = x => x.T1130 == (byte)value;
                        break;
					case "T1200" :
						model = list.SingleOrDefault(x => x.T1200 == (byte)value);
                        expression = x => x.T1200 == (byte)value;
                        break;
					case "T1230" :
						model = list.SingleOrDefault(x => x.T1230 == (byte)value);
                        expression = x => x.T1230 == (byte)value;
                        break;
					case "T1300" :
						model = list.SingleOrDefault(x => x.T1300 == (byte)value);
                        expression = x => x.T1300 == (byte)value;
                        break;
					case "T1330" :
						model = list.SingleOrDefault(x => x.T1330 == (byte)value);
                        expression = x => x.T1330 == (byte)value;
                        break;
					case "T1400" :
						model = list.SingleOrDefault(x => x.T1400 == (byte)value);
                        expression = x => x.T1400 == (byte)value;
                        break;
					case "T1430" :
						model = list.SingleOrDefault(x => x.T1430 == (byte)value);
                        expression = x => x.T1430 == (byte)value;
                        break;
					case "T1500" :
						model = list.SingleOrDefault(x => x.T1500 == (byte)value);
                        expression = x => x.T1500 == (byte)value;
                        break;
					case "T1530" :
						model = list.SingleOrDefault(x => x.T1530 == (byte)value);
                        expression = x => x.T1530 == (byte)value;
                        break;
					case "T1600" :
						model = list.SingleOrDefault(x => x.T1600 == (byte)value);
                        expression = x => x.T1600 == (byte)value;
                        break;
					case "T1630" :
						model = list.SingleOrDefault(x => x.T1630 == (byte)value);
                        expression = x => x.T1630 == (byte)value;
                        break;
					case "T1700" :
						model = list.SingleOrDefault(x => x.T1700 == (byte)value);
                        expression = x => x.T1700 == (byte)value;
                        break;
					case "T1730" :
						model = list.SingleOrDefault(x => x.T1730 == (byte)value);
                        expression = x => x.T1730 == (byte)value;
                        break;
					case "T1800" :
						model = list.SingleOrDefault(x => x.T1800 == (byte)value);
                        expression = x => x.T1800 == (byte)value;
                        break;
					case "T1830" :
						model = list.SingleOrDefault(x => x.T1830 == (byte)value);
                        expression = x => x.T1830 == (byte)value;
                        break;
					case "T1900" :
						model = list.SingleOrDefault(x => x.T1900 == (byte)value);
                        expression = x => x.T1900 == (byte)value;
                        break;
					case "T1930" :
						model = list.SingleOrDefault(x => x.T1930 == (byte)value);
                        expression = x => x.T1930 == (byte)value;
                        break;
					case "T2000" :
						model = list.SingleOrDefault(x => x.T2000 == (byte)value);
                        expression = x => x.T2000 == (byte)value;
                        break;
					case "T2030" :
						model = list.SingleOrDefault(x => x.T2030 == (byte)value);
                        expression = x => x.T2030 == (byte)value;
                        break;
					case "T2100" :
						model = list.SingleOrDefault(x => x.T2100 == (byte)value);
                        expression = x => x.T2100 == (byte)value;
                        break;
					case "T2130" :
						model = list.SingleOrDefault(x => x.T2130 == (byte)value);
                        expression = x => x.T2130 == (byte)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //從數據庫中讀取
                    var tem = RoomMoment.SingleOrDefault(expression);
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
                CommonBll.WriteLog("從IIS緩存中獲取RoomMoment表記錄時出現異常", e);

                return null;
            }
        }
        #endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="expression">條件</param>
        /// <returns>DataAccess.Model.RoomMoment</returns>
        public DataAccess.Model.RoomMoment GetModelForCache(Expression<Func<DataAccess.Model.RoomMoment, bool>> expression)
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
        public void SetModelForCache(DataAccess.Model.RoomMoment model)
        {
			if (model == null) return;
			
            //從緩存中刪除記錄
            DelCache(model.Id);

            //從緩存中讀?記錄列表
            var list = GetList();
		    if (list == null)
		    {
                list = new List<DataAccess.Model.RoomMoment>();
		    }
            //添加記錄
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(RoomMoment model)
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
        /// 按條件刪除IIS緩存中RoomMoment表的指定記錄
        /// </summary>
        /// <param name="expression">條件，值為null時刪除?有記錄</param>
		public void DelCache(Expression<Func<DataAccess.Model.RoomMoment, bool>> expression)
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
		/// 將RoomMoment記錄實伐（SubSonic實伐）轉換為?通的實伐（DataAccess.Model.RoomMoment）
		/// </summary>
        /// <param name="model">SubSonic插件生成的實伐</param>
		/// <returns>DataAccess.Model.RoomMoment</returns>
		public DataAccess.Model.RoomMoment Transform(RoomMoment model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.RoomMoment
            {
                Id = model.Id,
                MeetingRoom_Code = model.MeetingRoom_Code,
                MeetingRoom_Name = model.MeetingRoom_Name,
                RoomDate = model.RoomDate,
                T0830 = model.T0830,
                T0900 = model.T0900,
                T0930 = model.T0930,
                T1000 = model.T1000,
                T1030 = model.T1030,
                T1100 = model.T1100,
                T1130 = model.T1130,
                T1200 = model.T1200,
                T1230 = model.T1230,
                T1300 = model.T1300,
                T1330 = model.T1330,
                T1400 = model.T1400,
                T1430 = model.T1430,
                T1500 = model.T1500,
                T1530 = model.T1530,
                T1600 = model.T1600,
                T1630 = model.T1630,
                T1700 = model.T1700,
                T1730 = model.T1730,
                T1800 = model.T1800,
                T1830 = model.T1830,
                T1900 = model.T1900,
                T1930 = model.T1930,
                T2000 = model.T2000,
                T2030 = model.T2030,
                T2100 = model.T2100,
                T2130 = model.T2130,
            };
        }

		/// <summary>
		/// 將RoomMoment記錄實伐集（SubSonic實伐）轉換為?通的實伐集（DataAccess.Model.RoomMoment）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的實伐集</param>
        public IList<DataAccess.Model.RoomMoment> Transform(IList<RoomMoment> sourceList)
        {
			//創建List??
            var list = new List<DataAccess.Model.RoomMoment>();
			//將SubSonic插件生成的實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 將RoomMoment記錄實伐批?通的實伐（DataAccess.Model.RoomMoment）轉換為SubSonic插件生成的實伐
		/// </summary>
        /// <param name="model">?通的實伐（DataAccess.Model.RoomMoment）</param>
		/// <returns>RoomMoment</returns>
		public RoomMoment Transform(DataAccess.Model.RoomMoment model)
        {
			if (model == null) 
				return null;

            return new RoomMoment
            {
                Id = model.Id,
                MeetingRoom_Code = model.MeetingRoom_Code,
                MeetingRoom_Name = model.MeetingRoom_Name,
                RoomDate = model.RoomDate,
                T0830 = model.T0830,
                T0900 = model.T0900,
                T0930 = model.T0930,
                T1000 = model.T1000,
                T1030 = model.T1030,
                T1100 = model.T1100,
                T1130 = model.T1130,
                T1200 = model.T1200,
                T1230 = model.T1230,
                T1300 = model.T1300,
                T1330 = model.T1330,
                T1400 = model.T1400,
                T1430 = model.T1430,
                T1500 = model.T1500,
                T1530 = model.T1530,
                T1600 = model.T1600,
                T1630 = model.T1630,
                T1700 = model.T1700,
                T1730 = model.T1730,
                T1800 = model.T1800,
                T1830 = model.T1830,
                T1900 = model.T1900,
                T1930 = model.T1930,
                T2000 = model.T2000,
                T2030 = model.T2030,
                T2100 = model.T2100,
                T2130 = model.T2130,
            };
        }

		/// <summary>
		/// 將RoomMoment記錄實伐批?通實伐集（DataAccess.Model.RoomMoment）轉換為SubSonic插件生成的實伐集
		/// </summary>
        /// <param name="sourceList">?通實伐集（DataAccess.Model.RoomMoment）</param>
        public IList<RoomMoment> Transform(IList<DataAccess.Model.RoomMoment> sourceList)
        {
			//創建List??
            var list = new List<RoomMoment>();
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
		public void SetModelValue(DataAccess.Model.RoomMoment model, Dictionary<string, object> dic)
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
		public void SetModelValue(DataAccess.Model.RoomMoment model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定條件的實伐
            switch (colName)
            {
				case "Id" :
					model.Id = (long)value;
                    break;
				case "MeetingRoom_Code" :
					model.MeetingRoom_Code = (string)value;
                    break;
				case "MeetingRoom_Name" :
					model.MeetingRoom_Name = (string)value;
                    break;
				case "RoomDate" :
					model.RoomDate = (DateTime)value;
                    break;
				case "T0830" :
					model.T0830 = ConvertHelper.Ctinyint(value);
                    break;
				case "T0900" :
					model.T0900 = ConvertHelper.Ctinyint(value);
                    break;
				case "T0930" :
					model.T0930 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1000" :
					model.T1000 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1030" :
					model.T1030 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1100" :
					model.T1100 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1130" :
					model.T1130 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1200" :
					model.T1200 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1230" :
					model.T1230 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1300" :
					model.T1300 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1330" :
					model.T1330 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1400" :
					model.T1400 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1430" :
					model.T1430 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1500" :
					model.T1500 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1530" :
					model.T1530 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1600" :
					model.T1600 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1630" :
					model.T1630 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1700" :
					model.T1700 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1730" :
					model.T1730 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1800" :
					model.T1800 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1830" :
					model.T1830 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1900" :
					model.T1900 = ConvertHelper.Ctinyint(value);
                    break;
				case "T1930" :
					model.T1930 = ConvertHelper.Ctinyint(value);
                    break;
				case "T2000" :
					model.T2000 = ConvertHelper.Ctinyint(value);
                    break;
				case "T2030" :
					model.T2030 = ConvertHelper.Ctinyint(value);
                    break;
				case "T2100" :
					model.T2100 = ConvertHelper.Ctinyint(value);
                    break;
				case "T2130" :
					model.T2130 = ConvertHelper.Ctinyint(value);
                    break;
            }
		}

        #endregion

		#endregion

		#region 獲?RoomMoment表記錄總數
        /// <summary>
        /// 獲?RoomMoment表記錄總數
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
				return select.GetRecordCount<RoomMoment>();
			}
        }

		/// <summary>
		/// 獲?RoomMoment表記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="wheres">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionHelper.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<RoomMoment>(wheres);

		}

		/// <summary>
		/// 獲?RoomMoment表指定條件的記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="expression">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<RoomMoment, bool>> expression) {
            return new Select().From<RoomMoment>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定條件的記錄集合
        /// <summary>
        /// 查找指定條件的記錄集合——從IIS緩存中查找
        /// </summary>
        /// <param name="expression">條件語句</param>
        public IList<DataAccess.Model.RoomMoment> Find(Expression<Func<DataAccess.Model.RoomMoment, bool>> expression)
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
            return RoomMoment.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判斷指定條件的記錄是否存在——默?在IIS緩存中查找，?果沒開?緩存時，則直接在數據庫中查詢出列表後，再從列表中查詢
        /// </summary>
        /// <param name="expression">條件語句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.RoomMoment, bool>> expression)
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

		#region 獲?RoomMoment表記錄
		/// <summary>
		/// 獲?RoomMoment表記錄
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
                return select.SelectDataTable<RoomMoment>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("獲?RoomMoment表記錄時出現異常", e);

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

		#region 添加與編輯RoomMoment表記錄
		/// <summary>
		/// 添加與編輯RoomMoment記錄
		/// </summary>
	    /// <param name="page">當?頁面指針</param>
		/// <param name="model">RoomMoment表實伐</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Save(Page page, RoomMoment model, string content = null, bool isCache = true, bool isAddUseLog = true)
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
						content = "{0}" + (model.Id == 0 ? "添加" : "編輯") + "RoomMoment記錄成功，ID為【" + model.Id + "】";
					}

					//添加用戶訪問記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "執行RoomMomentBll.Save()函數出錯！";

				//出現異常，保存出錯?志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 刪除RoomMoment表記錄
		/// <summary>
		/// 刪除RoomMoment表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", RoomMomentTable.TableName,  RoomMomentTable.Id, id);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了RoomMoment表id為【" + id + "】的記錄！");
			}
		}

		/// <summary>
		/// 刪除RoomMoment表記錄
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
			var sql = string.Format("delete from {0} where {1} in ({2})", RoomMomentTable.TableName,  RoomMomentTable.Id, str);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了RoomMoment表id為【" + str + "】的記錄！");
			}
		}

		/// <summary>
        /// 刪除RoomMoment表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Delete(Page page, Expression<Func<RoomMoment, bool>> expression, bool isAddUseLog = true)
        {
			//執行刪除
			RoomMoment.Delete(expression);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了RoomMoment表記錄！");
			}
        }

		/// <summary>
        /// 刪除RoomMoment表所有記錄
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void DeleteAll(Page page, bool isAddUseLog = true)
        {
            //設瞞Sql語句
            var sql = string.Format("delete from {0}", RoomMomentTable.TableName);

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
                UseLogBll.GetInstence().Save(page, "{0}刪除了RoomMoment表所有記錄！");
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
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "RoomMoment", sortName, "Id"))
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
				UseLogBll.GetInstence().Save(page, "{0}更新了RoomMoment表排序！");

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
			if (CommonBll.AutoSort("Id", "RoomMoment", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
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
				UseLogBll.GetInstence().Save(page, "{0}對RoomMoment表進行了自動排序操作！");

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
	                conditionColName = RoomMomentTable.Id;
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
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.RoomMoment, bool>> expression)
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
            return select.GetColumnsValue<RoomMoment>(colName, wheres);
        }

		/// <summary>
        /// 返回實伐中指定字段名的值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">獲?的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.RoomMoment model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "MeetingRoom_Code" :
					return model.MeetingRoom_Code;
				case "MeetingRoom_Name" :
					return model.MeetingRoom_Name;
				case "RoomDate" :
					return model.RoomDate;
				case "T0830" :
					return model.T0830;
				case "T0900" :
					return model.T0900;
				case "T0930" :
					return model.T0930;
				case "T1000" :
					return model.T1000;
				case "T1030" :
					return model.T1030;
				case "T1100" :
					return model.T1100;
				case "T1130" :
					return model.T1130;
				case "T1200" :
					return model.T1200;
				case "T1230" :
					return model.T1230;
				case "T1300" :
					return model.T1300;
				case "T1330" :
					return model.T1330;
				case "T1400" :
					return model.T1400;
				case "T1430" :
					return model.T1430;
				case "T1500" :
					return model.T1500;
				case "T1530" :
					return model.T1530;
				case "T1600" :
					return model.T1600;
				case "T1630" :
					return model.T1630;
				case "T1700" :
					return model.T1700;
				case "T1730" :
					return model.T1730;
				case "T1800" :
					return model.T1800;
				case "T1830" :
					return model.T1830;
				case "T1900" :
					return model.T1900;
				case "T1930" :
					return model.T1930;
				case "T2000" :
					return model.T2000;
				case "T2030" :
					return model.T2030;
				case "T2100" :
					return model.T2100;
				case "T2130" :
					return model.T2130;
			}

			return null;
		}

		#endregion
		
		#region 更新RoomMoment表指定字段值
		/// <summary>更新RoomMoment表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="dic">需要更新的字段與值</param>
		/// <param name="wheres">條件</param>
		/// <param name="content">更新說明</param>
		/// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionHelper.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<RoomMoment>(dic, wheres);

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
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}囊改了RoomMoment表記錄。");				
				}
				else
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新RoomMoment表指定主鍵Id的字段值
		/// <summary>更新RoomMoment表記錄指定字段值</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue(Page page, long id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了RoomMoment表主鍵Id值為" + id + "的記錄。";
			
            //條件
		    List<ConditionHelper.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, RoomMomentTable.Id, Comparison.Equals, id));
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

        /// <summary>更新RoomMoment表記錄指定字段值（更新一個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, long id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了RoomMoment表主鍵Id值為" + id + "的記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新RoomMoment表記錄指定字段值（更新兩個字段值）</summary>
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
            content = content != "" ? content : "{0}囊改了RoomMoment表主鍵Id值為" + id + "的記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 獲取MeetingRoom_Name字段值
        /// <summary>
        /// 獲?MeetingRoom_Name字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetMeetingRoom_Name(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.MeetingRoom_Name;
            }
            else
            {
                //從數據庫中查詢
                var model = RoomMoment.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.MeetingRoom_Name;
            }
        }
        #endregion

		#region 更新T0830字段值
		/// <summary>
		/// 更新T0830字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT0830(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T0830] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T0830字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T0900字段值
		/// <summary>
		/// 更新T0900字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT0900(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T0900] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T0900字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T0930字段值
		/// <summary>
		/// 更新T0930字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT0930(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T0930] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T0930字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1000字段值
		/// <summary>
		/// 更新T1000字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1000(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1000] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1000字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1030字段值
		/// <summary>
		/// 更新T1030字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1030(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1030] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1030字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1100字段值
		/// <summary>
		/// 更新T1100字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1100(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1100] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1100字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1130字段值
		/// <summary>
		/// 更新T1130字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1130(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1130] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1130字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1200字段值
		/// <summary>
		/// 更新T1200字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1200(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1200] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1200字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1230字段值
		/// <summary>
		/// 更新T1230字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1230(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1230] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1230字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1300字段值
		/// <summary>
		/// 更新T1300字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1300(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1300] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1300字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1330字段值
		/// <summary>
		/// 更新T1330字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1330(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1330] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1330字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1400字段值
		/// <summary>
		/// 更新T1400字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1400(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1400] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1400字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1430字段值
		/// <summary>
		/// 更新T1430字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1430(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1430] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1430字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1500字段值
		/// <summary>
		/// 更新T1500字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1500(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1500] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1500字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1530字段值
		/// <summary>
		/// 更新T1530字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1530(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1530] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1530字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1600字段值
		/// <summary>
		/// 更新T1600字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1600(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1600] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1600字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1630字段值
		/// <summary>
		/// 更新T1630字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1630(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1630] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1630字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1700字段值
		/// <summary>
		/// 更新T1700字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1700(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1700] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1700字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1730字段值
		/// <summary>
		/// 更新T1730字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1730(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1730] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1730字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1800字段值
		/// <summary>
		/// 更新T1800字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1800(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1800] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1800字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1830字段值
		/// <summary>
		/// 更新T1830字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1830(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1830] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1830字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1900字段值
		/// <summary>
		/// 更新T1900字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1900(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1900] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1900字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T1930字段值
		/// <summary>
		/// 更新T1930字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT1930(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T1930] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T1930字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T2000字段值
		/// <summary>
		/// 更新T2000字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT2000(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T2000] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T2000字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T2030字段值
		/// <summary>
		/// 更新T2030字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT2030(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T2030] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T2030字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T2100字段值
		/// <summary>
		/// 更新T2100字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT2100(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T2100] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T2100字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新T2130字段值
		/// <summary>
		/// 更新T2130字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateT2130(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[RoomMomentTable.T2130] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了RoomMoment表id為【" + pkValue + "】的記錄，更新內容為將T2130字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
    
		#endregion 模版生成函數

    } 
}
