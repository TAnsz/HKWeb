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
	/// OnlineUsers表邏輯類
	/// </summary>
	public partial class OnlineUsersBll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函數                                                        *
		 ***********************************************************************/
		#region 模版生成函數
				
		private const string const_CacheKey = "Cache_OnlineUsers";
        private const string const_CacheKey_Date = "Cache_OnlineUsers_Date";

		#region 單例模式
		//定義單例實伐
		private static OnlineUsersBll _OnlineUsersBll = null;

		/// <summary>
		/// 獲取本邏輯類單例
		/// </summary>
		/// <returns></returns>
		public static OnlineUsersBll GetInstence() {
			if (_OnlineUsersBll == null) {
				_OnlineUsersBll = new OnlineUsersBll();
			}
			return _OnlineUsersBll;
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
		
		#region 從IIS緩存中獲取OnlineUsers表記錄
		/// <summary>
        /// 從IIS緩存中獲取OnlineUsers表記錄
        /// </summary>
	    /// <param name="isCache">是否從緩存中讀取</param>
        public IList<DataAccess.Model.OnlineUsers> GetList(bool isCache = true)
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
						return (IList<DataAccess.Model.OnlineUsers>)obj;
					}
				}
				else
				{
					//定義臨時實伐集
					IList<DataAccess.Model.OnlineUsers> list = null;

					//獲??表緩存加載條件表達式
					var exp = GetExpression<OnlineUsers>();
                    //?果條件為空，則查詢?表所有記錄
					if (exp == null)
					{
						//從數據庫中獲?所有記錄
						var all = OnlineUsers.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //從數據庫中查詢出指定條件的記錄，並轉換為指定實伐集
						var all = OnlineUsers.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取OnlineUsers表記錄時出現異常", e);
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
		/// <returns>DataAccess.Model.OnlineUsers</returns>
        public DataAccess.Model.OnlineUsers GetModel(long id, bool isCache = true)
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
                var model = OnlineUsers.SingleOrDefault(x => x.Id == id);
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
		/// <returns>DataAccess.Model.OnlineUsers</returns>
        public DataAccess.Model.OnlineUsers GetModelForCache(long id)
        {
			try
			{
				//從緩存中讀?指定Id記錄
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//從數據庫中讀?
					var tem = OnlineUsers.SingleOrDefault(x => x.Id == id);
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
                CommonBll.WriteLog("從IIS緩存中獲取OnlineUsers表記錄時出現異常", e);

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
        /// <returns>DataAccess.Model.OnlineUsers</returns>
        public DataAccess.Model.OnlineUsers GetModelForCache(string conditionColName, object value)
        {
			try
            {
                //從緩存中獲取List
                var list = GetList();
                DataAccess.Model.OnlineUsers model = null;
                Expression<Func<OnlineUsers, bool>> expression = null;

                //返回指定條件的實伐
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (int)value);
                        expression = x => x.Id == (int)value;
                        break;
					case "UserHashKey" :
						model = list.SingleOrDefault(x => x.UserHashKey == (string)value);
                        expression = x => x.UserHashKey == (string)value;
                        break;
					case "Manager_Id" :
						model = list.SingleOrDefault(x => x.Manager_Id == (int)value);
                        expression = x => x.Manager_Id == (int)value;
                        break;
					case "Manager_LoginName" :
						model = list.SingleOrDefault(x => x.Manager_LoginName == (string)value);
                        expression = x => x.Manager_LoginName == (string)value;
                        break;
					case "Manager_LoginPass" :
						model = list.SingleOrDefault(x => x.Manager_LoginPass == (string)value);
                        expression = x => x.Manager_LoginPass == (string)value;
                        break;
					case "Manager_CName" :
						model = list.SingleOrDefault(x => x.Manager_CName == (string)value);
                        expression = x => x.Manager_CName == (string)value;
                        break;
					case "LoginTime" :
						model = list.SingleOrDefault(x => x.LoginTime == (DateTime)value);
                        expression = x => x.LoginTime == (DateTime)value;
                        break;
					case "LoginIp" :
						model = list.SingleOrDefault(x => x.LoginIp == (string)value);
                        expression = x => x.LoginIp == (string)value;
                        break;
					case "UserKey" :
						model = list.SingleOrDefault(x => x.UserKey == (string)value);
                        expression = x => x.UserKey == (string)value;
                        break;
					case "Md5" :
						model = list.SingleOrDefault(x => x.Md5 == (string)value);
                        expression = x => x.Md5 == (string)value;
                        break;
					case "UpdateTime" :
						model = list.SingleOrDefault(x => x.UpdateTime == (DateTime)value);
                        expression = x => x.UpdateTime == (DateTime)value;
                        break;
					case "Sex" :
						model = list.SingleOrDefault(x => x.Sex == (string)value);
                        expression = x => x.Sex == (string)value;
                        break;
					case "Branch_Id" :
						model = list.SingleOrDefault(x => x.Branch_Id == (int)value);
                        expression = x => x.Branch_Id == (int)value;
                        break;
					case "Branch_Code" :
						model = list.SingleOrDefault(x => x.Branch_Code == (string)value);
                        expression = x => x.Branch_Code == (string)value;
                        break;
					case "Branch_Name" :
						model = list.SingleOrDefault(x => x.Branch_Name == (string)value);
                        expression = x => x.Branch_Name == (string)value;
                        break;
					case "Position_Id" :
						model = list.SingleOrDefault(x => x.Position_Id == (string)value);
                        expression = x => x.Position_Id == (string)value;
                        break;
					case "Position_Name" :
						model = list.SingleOrDefault(x => x.Position_Name == (string)value);
                        expression = x => x.Position_Name == (string)value;
                        break;
					case "CurrentPage" :
						model = list.SingleOrDefault(x => x.CurrentPage == (string)value);
                        expression = x => x.CurrentPage == (string)value;
                        break;
					case "CurrentPageTitle" :
						model = list.SingleOrDefault(x => x.CurrentPageTitle == (string)value);
                        expression = x => x.CurrentPageTitle == (string)value;
                        break;
					case "SessionId" :
						model = list.SingleOrDefault(x => x.SessionId == (string)value);
                        expression = x => x.SessionId == (string)value;
                        break;
					case "UserAgent" :
						model = list.SingleOrDefault(x => x.UserAgent == (string)value);
                        expression = x => x.UserAgent == (string)value;
                        break;
					case "OperatingSystem" :
						model = list.SingleOrDefault(x => x.OperatingSystem == (string)value);
                        expression = x => x.OperatingSystem == (string)value;
                        break;
					case "TerminalType" :
						model = list.SingleOrDefault(x => x.TerminalType == (int)value);
                        expression = x => x.TerminalType == (int)value;
                        break;
					case "BrowserName" :
						model = list.SingleOrDefault(x => x.BrowserName == (string)value);
                        expression = x => x.BrowserName == (string)value;
                        break;
					case "BrowserVersion" :
						model = list.SingleOrDefault(x => x.BrowserVersion == (string)value);
                        expression = x => x.BrowserVersion == (string)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //從數據庫中讀取
                    var tem = OnlineUsers.SingleOrDefault(expression);
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
                CommonBll.WriteLog("從IIS緩存中獲取OnlineUsers表記錄時出現異常", e);

                return null;
            }
        }
        #endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="expression">條件</param>
        /// <returns>DataAccess.Model.OnlineUsers</returns>
        public DataAccess.Model.OnlineUsers GetModelForCache(Expression<Func<DataAccess.Model.OnlineUsers, bool>> expression)
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
        public void SetModelForCache(DataAccess.Model.OnlineUsers model)
        {
			if (model == null) return;
			
            //從緩存中刪除記錄
            DelCache(model.Id);

            //從緩存中讀?記錄列表
            var list = GetList();
		    if (list == null)
		    {
                list = new List<DataAccess.Model.OnlineUsers>();
		    }
            //添加記錄
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(OnlineUsers model)
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
        /// 按條件刪除IIS緩存中OnlineUsers表的指定記錄
        /// </summary>
        /// <param name="expression">條件，值為null時刪除?有記錄</param>
		public void DelCache(Expression<Func<DataAccess.Model.OnlineUsers, bool>> expression)
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
		/// 將OnlineUsers記錄實伐（SubSonic實伐）轉換為?通的實伐（DataAccess.Model.OnlineUsers）
		/// </summary>
        /// <param name="model">SubSonic插件生成的實伐</param>
		/// <returns>DataAccess.Model.OnlineUsers</returns>
		public DataAccess.Model.OnlineUsers Transform(OnlineUsers model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.OnlineUsers
            {
                Id = model.Id,
                UserHashKey = model.UserHashKey,
                Manager_Id = model.Manager_Id,
                Manager_LoginName = model.Manager_LoginName,
                Manager_LoginPass = model.Manager_LoginPass,
                Manager_CName = model.Manager_CName,
                LoginTime = model.LoginTime,
                LoginIp = model.LoginIp,
                UserKey = model.UserKey,
                Md5 = model.Md5,
                UpdateTime = model.UpdateTime,
                Sex = model.Sex,
                Branch_Id = model.Branch_Id,
                Branch_Code = model.Branch_Code,
                Branch_Name = model.Branch_Name,
                Position_Id = model.Position_Id,
                Position_Name = model.Position_Name,
                CurrentPage = model.CurrentPage,
                CurrentPageTitle = model.CurrentPageTitle,
                SessionId = model.SessionId,
                UserAgent = model.UserAgent,
                OperatingSystem = model.OperatingSystem,
                TerminalType = model.TerminalType,
                BrowserName = model.BrowserName,
                BrowserVersion = model.BrowserVersion,
            };
        }

		/// <summary>
		/// 將OnlineUsers記錄實伐集（SubSonic實伐）轉換為?通的實伐集（DataAccess.Model.OnlineUsers）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的實伐集</param>
        public IList<DataAccess.Model.OnlineUsers> Transform(IList<OnlineUsers> sourceList)
        {
			//創建List??
            var list = new List<DataAccess.Model.OnlineUsers>();
			//將SubSonic插件生成的實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 將OnlineUsers記錄實伐批?通的實伐（DataAccess.Model.OnlineUsers）轉換為SubSonic插件生成的實伐
		/// </summary>
        /// <param name="model">?通的實伐（DataAccess.Model.OnlineUsers）</param>
		/// <returns>OnlineUsers</returns>
		public OnlineUsers Transform(DataAccess.Model.OnlineUsers model)
        {
			if (model == null) 
				return null;

            return new OnlineUsers
            {
                Id = model.Id,
                UserHashKey = model.UserHashKey,
                Manager_Id = model.Manager_Id,
                Manager_LoginName = model.Manager_LoginName,
                Manager_LoginPass = model.Manager_LoginPass,
                Manager_CName = model.Manager_CName,
                LoginTime = model.LoginTime,
                LoginIp = model.LoginIp,
                UserKey = model.UserKey,
                Md5 = model.Md5,
                UpdateTime = model.UpdateTime,
                Sex = model.Sex,
                Branch_Id = model.Branch_Id,
                Branch_Code = model.Branch_Code,
                Branch_Name = model.Branch_Name,
                Position_Id = model.Position_Id,
                Position_Name = model.Position_Name,
                CurrentPage = model.CurrentPage,
                CurrentPageTitle = model.CurrentPageTitle,
                SessionId = model.SessionId,
                UserAgent = model.UserAgent,
                OperatingSystem = model.OperatingSystem,
                TerminalType = model.TerminalType,
                BrowserName = model.BrowserName,
                BrowserVersion = model.BrowserVersion,
            };
        }

		/// <summary>
		/// 將OnlineUsers記錄實伐批?通實伐集（DataAccess.Model.OnlineUsers）轉換為SubSonic插件生成的實伐集
		/// </summary>
        /// <param name="sourceList">?通實伐集（DataAccess.Model.OnlineUsers）</param>
        public IList<OnlineUsers> Transform(IList<DataAccess.Model.OnlineUsers> sourceList)
        {
			//創建List??
            var list = new List<OnlineUsers>();
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
		public void SetModelValue(DataAccess.Model.OnlineUsers model, Dictionary<string, object> dic)
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
		public void SetModelValue(DataAccess.Model.OnlineUsers model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定條件的實伐
            switch (colName)
            {
				case "Id" :
					model.Id = (int)value;
                    break;
				case "UserHashKey" :
					model.UserHashKey = (string)value;
                    break;
				case "Manager_Id" :
					model.Manager_Id = (int)value;
                    break;
				case "Manager_LoginName" :
					model.Manager_LoginName = (string)value;
                    break;
				case "Manager_LoginPass" :
					model.Manager_LoginPass = (string)value;
                    break;
				case "Manager_CName" :
					model.Manager_CName = (string)value;
                    break;
				case "LoginTime" :
					model.LoginTime = (DateTime)value;
                    break;
				case "LoginIp" :
					model.LoginIp = (string)value;
                    break;
				case "UserKey" :
					model.UserKey = (string)value;
                    break;
				case "Md5" :
					model.Md5 = (string)value;
                    break;
				case "UpdateTime" :
					model.UpdateTime = (DateTime)value;
                    break;
				case "Sex" :
					model.Sex = (string)value;
                    break;
				case "Branch_Id" :
					model.Branch_Id = (int)value;
                    break;
				case "Branch_Code" :
					model.Branch_Code = (string)value;
                    break;
				case "Branch_Name" :
					model.Branch_Name = (string)value;
                    break;
				case "Position_Id" :
					model.Position_Id = (string)value;
                    break;
				case "Position_Name" :
					model.Position_Name = (string)value;
                    break;
				case "CurrentPage" :
					model.CurrentPage = (string)value;
                    break;
				case "CurrentPageTitle" :
					model.CurrentPageTitle = (string)value;
                    break;
				case "SessionId" :
					model.SessionId = (string)value;
                    break;
				case "UserAgent" :
					model.UserAgent = (string)value;
                    break;
				case "OperatingSystem" :
					model.OperatingSystem = (string)value;
                    break;
				case "TerminalType" :
					model.TerminalType = (int)value;
                    break;
				case "BrowserName" :
					model.BrowserName = (string)value;
                    break;
				case "BrowserVersion" :
					model.BrowserVersion = (string)value;
                    break;
            }
		}

        #endregion

		#endregion

		#region 獲?OnlineUsers表記錄總數
        /// <summary>
        /// 獲?OnlineUsers表記錄總數
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
				return select.GetRecordCount<OnlineUsers>();
			}
        }

		/// <summary>
		/// 獲?OnlineUsers表記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="wheres">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionHelper.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<OnlineUsers>(wheres);

		}

		/// <summary>
		/// 獲?OnlineUsers表指定條件的記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="expression">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<OnlineUsers, bool>> expression) {
            return new Select().From<OnlineUsers>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定條件的記錄集合
        /// <summary>
        /// 查找指定條件的記錄集合——從IIS緩存中查找
        /// </summary>
        /// <param name="expression">條件語句</param>
        public IList<DataAccess.Model.OnlineUsers> Find(Expression<Func<DataAccess.Model.OnlineUsers, bool>> expression)
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
            return OnlineUsers.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判斷指定條件的記錄是否存在——默?在IIS緩存中查找，?果沒開?緩存時，則直接在數據庫中查詢出列表後，再從列表中查詢
        /// </summary>
        /// <param name="expression">條件語句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.OnlineUsers, bool>> expression)
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

		#region 獲?OnlineUsers表記錄
		/// <summary>
		/// 獲?OnlineUsers表記錄
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
                return select.SelectDataTable<OnlineUsers>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("獲?OnlineUsers表記錄時出現異常", e);

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

		#region 添加與編輯OnlineUsers表記錄
		/// <summary>
		/// 添加與編輯OnlineUsers記錄
		/// </summary>
	    /// <param name="page">當?頁面指針</param>
		/// <param name="model">OnlineUsers表實伐</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Save(Page page, OnlineUsers model, string content = null, bool isCache = true, bool isAddUseLog = true)
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
						content = "{0}" + (model.Id == 0 ? "添加" : "編輯") + "OnlineUsers記錄成功，ID為【" + model.Id + "】";
					}

					//添加用戶訪問記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "執行OnlineUsersBll.Save()函數出錯！";

				//出現異常，保存出錯?志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 刪除OnlineUsers表記錄
		/// <summary>
		/// 刪除OnlineUsers表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", OnlineUsersTable.TableName,  OnlineUsersTable.Id, id);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表id為【" + id + "】的記錄！");
			}
		}

		/// <summary>
		/// 刪除OnlineUsers表記錄
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
			var sql = string.Format("delete from {0} where {1} in ({2})", OnlineUsersTable.TableName,  OnlineUsersTable.Id, str);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表id為【" + str + "】的記錄！");
			}
		}

		/// <summary>
        /// 刪除OnlineUsers表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Delete(Page page, Expression<Func<OnlineUsers, bool>> expression, bool isAddUseLog = true)
        {
			//執行刪除
			OnlineUsers.Delete(expression);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表記錄！");
			}
        }

		/// <summary>
        /// 刪除OnlineUsers表所有記錄
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void DeleteAll(Page page, bool isAddUseLog = true)
        {
            //設瞞Sql語句
            var sql = string.Format("delete from {0}", OnlineUsersTable.TableName);

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
                UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表所有記錄！");
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
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "OnlineUsers", sortName, "Id"))
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
				UseLogBll.GetInstence().Save(page, "{0}更新了OnlineUsers表排序！");

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
			if (CommonBll.AutoSort("Id", "OnlineUsers", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
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
				UseLogBll.GetInstence().Save(page, "{0}對OnlineUsers表進行了自動排序操作！");

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
	                conditionColName = OnlineUsersTable.Id;
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
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.OnlineUsers, bool>> expression)
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
            return select.GetColumnsValue<OnlineUsers>(colName, wheres);
        }

		/// <summary>
        /// 返回實伐中指定字段名的值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">獲?的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.OnlineUsers model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "UserHashKey" :
					return model.UserHashKey;
				case "Manager_Id" :
					return model.Manager_Id;
				case "Manager_LoginName" :
					return model.Manager_LoginName;
				case "Manager_LoginPass" :
					return model.Manager_LoginPass;
				case "Manager_CName" :
					return model.Manager_CName;
				case "LoginTime" :
					return model.LoginTime;
				case "LoginIp" :
					return model.LoginIp;
				case "UserKey" :
					return model.UserKey;
				case "Md5" :
					return model.Md5;
				case "UpdateTime" :
					return model.UpdateTime;
				case "Sex" :
					return model.Sex;
				case "Branch_Id" :
					return model.Branch_Id;
				case "Branch_Code" :
					return model.Branch_Code;
				case "Branch_Name" :
					return model.Branch_Name;
				case "Position_Id" :
					return model.Position_Id;
				case "Position_Name" :
					return model.Position_Name;
				case "CurrentPage" :
					return model.CurrentPage;
				case "CurrentPageTitle" :
					return model.CurrentPageTitle;
				case "SessionId" :
					return model.SessionId;
				case "UserAgent" :
					return model.UserAgent;
				case "OperatingSystem" :
					return model.OperatingSystem;
				case "TerminalType" :
					return model.TerminalType;
				case "BrowserName" :
					return model.BrowserName;
				case "BrowserVersion" :
					return model.BrowserVersion;
			}

			return null;
		}

		#endregion
		
		#region 更新OnlineUsers表指定字段值
		/// <summary>更新OnlineUsers表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="dic">需要更新的字段與值</param>
		/// <param name="wheres">條件</param>
		/// <param name="content">更新說明</param>
		/// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionHelper.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<OnlineUsers>(dic, wheres);

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
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}囊改了OnlineUsers表記錄。");				
				}
				else
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新OnlineUsers表指定主鍵Id的字段值
		/// <summary>更新OnlineUsers表記錄指定字段值</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue(Page page, int id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了OnlineUsers表主鍵Id值為" + id + "的記錄。";
			
            //條件
		    List<ConditionHelper.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, OnlineUsersTable.Id, Comparison.Equals, id));
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

        /// <summary>更新OnlineUsers表記錄指定字段值（更新一個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, int id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了OnlineUsers表主鍵Id值為" + id + "的記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新OnlineUsers表記錄指定字段值（更新兩個字段值）</summary>
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
            content = content != "" ? content : "{0}囊改了OnlineUsers表主鍵Id值為" + id + "的記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 使用UserHashKey來查詢，獲?一個OnlineUsers實伐對像
        /// <summary>使用Key來查詢，獲取一個OnlineUsers實伐對像</summary>
        /// <param name="page">當前頁面指針</param>
        /// <param name="key">Key值</param>
        /// <param name="isCache">是否從緩存中讀取</param>
        /// <returns>DataAccess.Model.OnlineUsers 實伐</returns>
        public DataAccess.Model.OnlineUsers GetModel_ByUserHashKey(Page page, string key, bool isCache = true)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            //判斷是否有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                return GetModelForCache(x => x.UserHashKey == key);
            }
			else
			{
				//從數據庫中查詢
				return Transform(OnlineUsers.SingleOrDefault(x => x.UserHashKey == key));
			}
        }
        #endregion

		#region 獲取Manager_LoginName字段值
        /// <summary>
        /// 獲?Manager_LoginName字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetManager_LoginName(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.Manager_LoginName;
            }
            else
            {
                //從數據庫中查詢
                var model = OnlineUsers.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.Manager_LoginName;
            }
        }
        #endregion

		#region 使用UserKey來查詢，獲?一個OnlineUsers實伐對像
        /// <summary>使用Key來查詢，獲取一個OnlineUsers實伐對像</summary>
        /// <param name="page">當前頁面指針</param>
        /// <param name="key">Key值</param>
        /// <param name="isCache">是否從緩存中讀取</param>
        /// <returns>DataAccess.Model.OnlineUsers 實伐</returns>
        public DataAccess.Model.OnlineUsers GetModel_ByUserKey(Page page, string key, bool isCache = true)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            //判斷是否有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                return GetModelForCache(x => x.UserKey == key);
            }
			else
			{
				//從數據庫中查詢
				return Transform(OnlineUsers.SingleOrDefault(x => x.UserKey == key));
			}
        }
        #endregion

		#region 刪除OnlineUsers表指定Branch_Id的字段值記錄
		/// <summary>
		/// 刪除OnlineUsers表指定Branch_Id的字段值記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		public void DeleteByBranch_Id(Page page, int id) {
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", OnlineUsersTable.TableName, OnlineUsersTable.Branch_Id, id);

			//刪除
			var delete = new DeleteHelper();
            delete.Delete(sql);
			
			//判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除緩存
                DelCache(x => x.Branch_Id == id);
            }
			
			//添加用戶操作記錄
			UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表Branch_Id值為【" + id + "】的記錄！");
		}

		/// <summary>
		/// 刪除OnlineUsers表指定Branch_Id的字段值記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		public void DeleteByBranch_Id(Page page, int[] id) {
			if (id == null) return;
			//將數組轉為逗號分隔的字串
			var str = string.Join(",", id);

			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} in ({2})", OnlineUsersTable.TableName, OnlineUsersTable.Branch_Id, id);

			//刪除
			var delete = new DeleteHelper();
            delete.Delete(sql);
			
			//判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                var ids = id.ToList();
                foreach (var i in ids)
                {
                    //刪除緩存
                    DelCache(x => x.Branch_Id == i);
                }
            }
			
			//添加用戶操作記錄
			UseLogBll.GetInstence().Save(page, "{0}刪除了OnlineUsers表Branch_Id值為【" + str + "】的記錄！");
		}
		#endregion

		#region 更新OnlineUsers表指定Branch_Id的字段值
        /// <summary>更新OnlineUsers表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="Branch_Id">字段Branch_Id的值</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_Branch_Id(Page page, int Branch_Id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了OnlineUsers表外鍵Branch_Id值為" + Branch_Id + "的所有記錄。";
			
            //條件
            var wheres = new List<ConditionHelper.SqlqueryCondition>
            {
                new ConditionHelper.SqlqueryCondition(ConstraintType.And, OnlineUsersTable.Branch_Id, Comparison.Equals, Branch_Id)
            };

            //執行更新
            UpdateValue(page, dic, wheres, content, isCache, isAddUseLog);
        }

		/// <summary>更新OnlineUsers表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="Branch_Id">字段Branch_Id的值</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_Branch_Id(Page page, int Branch_Id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了OnlineUsers表外鍵Branch_Id值為" + Branch_Id + "的所有記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue_For_Branch_Id(page, Branch_Id, dic, content, isCache, isAddUseLog);
        }

		/// <summary>更新OnlineUsers表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="Branch_Id">字段Branch_Id的值</param>
        /// <param name="columnName1">要更新的列名</param>
        /// <param name="columnValue1">要更新的列值</param>
        /// <param name="columnName2">要更新的列名</param>
        /// <param name="columnValue2">要更新的列值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_Branch_Id(Page page, int Branch_Id, string columnName1, object columnValue1, string columnName2, object columnValue2, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了OnlineUsers表外鍵Branch_Id值為" + Branch_Id + "的所有記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue_For_Branch_Id(page, Branch_Id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 獲取Branch_Name字段值
        /// <summary>
        /// 獲?Branch_Name字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetBranch_Name(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.Branch_Name;
            }
            else
            {
                //從數據庫中查詢
                var model = OnlineUsers.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.Branch_Name;
            }
        }
        #endregion

		#region 獲取Position_Name字段值
        /// <summary>
        /// 獲?Position_Name字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetPosition_Name(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.Position_Name;
            }
            else
            {
                //從數據庫中查詢
                var model = OnlineUsers.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.Position_Name;
            }
        }
        #endregion

		#region 獲取BrowserName字段值
        /// <summary>
        /// 獲?BrowserName字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetBrowserName(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.BrowserName;
            }
            else
            {
                //從數據庫中查詢
                var model = OnlineUsers.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.BrowserName;
            }
        }
        #endregion

    
		#endregion 模版生成函數

    } 
}
