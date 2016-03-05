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
	/// Information表邏輯類
	/// </summary>
	public partial class InformationBll : LogicBase {
 
 		/***********************************************************************
		 * 模版生成函數                                                        *
		 ***********************************************************************/
		#region 模版生成函數
				
		private const string const_CacheKey = "Cache_Information";
        private const string const_CacheKey_Date = "Cache_Information_Date";

		#region 單例模式
		//定義單例實伐
		private static InformationBll _InformationBll = null;

		/// <summary>
		/// 獲取本邏輯類單例
		/// </summary>
		/// <returns></returns>
		public static InformationBll GetInstence() {
			if (_InformationBll == null) {
				_InformationBll = new InformationBll();
			}
			return _InformationBll;
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
		
		#region 從IIS緩存中獲取Information表記錄
		/// <summary>
        /// 從IIS緩存中獲取Information表記錄
        /// </summary>
	    /// <param name="isCache">是否從緩存中讀取</param>
        public IList<DataAccess.Model.Information> GetList(bool isCache = true)
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
						return (IList<DataAccess.Model.Information>)obj;
					}
				}
				else
				{
					//定義臨時實伐集
					IList<DataAccess.Model.Information> list = null;

					//獲??表緩存加載條件表達式
					var exp = GetExpression<Information>();
                    //?果條件為空，則查詢?表所有記錄
					if (exp == null)
					{
						//從數據庫中獲?所有記錄
						var all = Information.All();
                        list = all == null ? null : Transform(all.ToList());
					}
					else
					{
                        //從數據庫中查詢出指定條件的記錄，並轉換為指定實伐集
						var all = Information.Find(exp);
                        list = all == null ? null : Transform(all);
					}

					return list;
				}				
			}
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("從IIS緩存中獲取Information表記錄時出現異常", e);
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
		/// <returns>DataAccess.Model.Information</returns>
        public DataAccess.Model.Information GetModel(long id, bool isCache = true)
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
                var model = Information.SingleOrDefault(x => x.Id == id);
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
		/// <returns>DataAccess.Model.Information</returns>
        public DataAccess.Model.Information GetModelForCache(long id)
        {
			try
			{
				//從緩存中讀?指定Id記錄
                var model = GetModelForCache(x => x.Id == id);

				if (model == null){
					//從數據庫中讀?
					var tem = Information.SingleOrDefault(x => x.Id == id);
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
                CommonBll.WriteLog("從IIS緩存中獲取Information表記錄時出現異常", e);

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
        /// <returns>DataAccess.Model.Information</returns>
        public DataAccess.Model.Information GetModelForCache(string conditionColName, object value)
        {
			try
            {
                //從緩存中獲取List
                var list = GetList();
                DataAccess.Model.Information model = null;
                Expression<Func<Information, bool>> expression = null;

                //返回指定條件的實伐
                switch (conditionColName)
                {
					case "Id" :
						model = list.SingleOrDefault(x => x.Id == (int)value);
                        expression = x => x.Id == (int)value;
                        break;
					case "InformationClass_Root_Id" :
						model = list.SingleOrDefault(x => x.InformationClass_Root_Id == (int)value);
                        expression = x => x.InformationClass_Root_Id == (int)value;
                        break;
					case "InformationClass_Root_Name" :
						model = list.SingleOrDefault(x => x.InformationClass_Root_Name == (string)value);
                        expression = x => x.InformationClass_Root_Name == (string)value;
                        break;
					case "InformationClass_Id" :
						model = list.SingleOrDefault(x => x.InformationClass_Id == (int)value);
                        expression = x => x.InformationClass_Id == (int)value;
                        break;
					case "InformationClass_Name" :
						model = list.SingleOrDefault(x => x.InformationClass_Name == (string)value);
                        expression = x => x.InformationClass_Name == (string)value;
                        break;
					case "Title" :
						model = list.SingleOrDefault(x => x.Title == (string)value);
                        expression = x => x.Title == (string)value;
                        break;
					case "RedirectUrl" :
						model = list.SingleOrDefault(x => x.RedirectUrl == (string)value);
                        expression = x => x.RedirectUrl == (string)value;
                        break;
					case "Content" :
						model = list.SingleOrDefault(x => x.Content == (string)value);
                        expression = x => x.Content == (string)value;
                        break;
					case "Upload" :
						model = list.SingleOrDefault(x => x.Upload == (string)value);
                        expression = x => x.Upload == (string)value;
                        break;
					case "FrontCoverImg" :
						model = list.SingleOrDefault(x => x.FrontCoverImg == (string)value);
                        expression = x => x.FrontCoverImg == (string)value;
                        break;
					case "Notes" :
						model = list.SingleOrDefault(x => x.Notes == (string)value);
                        expression = x => x.Notes == (string)value;
                        break;
					case "NewsTime" :
						model = list.SingleOrDefault(x => x.NewsTime == (DateTime)value);
                        expression = x => x.NewsTime == (DateTime)value;
                        break;
					case "EndTime" :
						model = list.SingleOrDefault(x => x.EndTime == (DateTime)value);
                        expression = x => x.EndTime == (DateTime)value;
                        break;
					case "Keywords" :
						model = list.SingleOrDefault(x => x.Keywords == (string)value);
                        expression = x => x.Keywords == (string)value;
                        break;
					case "SeoTitle" :
						model = list.SingleOrDefault(x => x.SeoTitle == (string)value);
                        expression = x => x.SeoTitle == (string)value;
                        break;
					case "SeoKey" :
						model = list.SingleOrDefault(x => x.SeoKey == (string)value);
                        expression = x => x.SeoKey == (string)value;
                        break;
					case "SeoDesc" :
						model = list.SingleOrDefault(x => x.SeoDesc == (string)value);
                        expression = x => x.SeoDesc == (string)value;
                        break;
					case "Author" :
						model = list.SingleOrDefault(x => x.Author == (string)value);
                        expression = x => x.Author == (string)value;
                        break;
					case "FromName" :
						model = list.SingleOrDefault(x => x.FromName == (string)value);
                        expression = x => x.FromName == (string)value;
                        break;
					case "Sort" :
						model = list.SingleOrDefault(x => x.Sort == (int)value);
                        expression = x => x.Sort == (int)value;
                        break;
					case "IsDisplay" :
						model = list.SingleOrDefault(x => x.IsDisplay == (byte)value);
                        expression = x => x.IsDisplay == (byte)value;
                        break;
					case "IsHot" :
						model = list.SingleOrDefault(x => x.IsHot == (byte)value);
                        expression = x => x.IsHot == (byte)value;
                        break;
					case "IsTop" :
						model = list.SingleOrDefault(x => x.IsTop == (byte)value);
                        expression = x => x.IsTop == (byte)value;
                        break;
					case "IsPage" :
						model = list.SingleOrDefault(x => x.IsPage == (byte)value);
                        expression = x => x.IsPage == (byte)value;
                        break;
					case "IsDel" :
						model = list.SingleOrDefault(x => x.IsDel == (byte)value);
                        expression = x => x.IsDel == (byte)value;
                        break;
					case "CommentCount" :
						model = list.SingleOrDefault(x => x.CommentCount == (int)value);
                        expression = x => x.CommentCount == (int)value;
                        break;
					case "ViewCount" :
						model = list.SingleOrDefault(x => x.ViewCount == (int)value);
                        expression = x => x.ViewCount == (int)value;
                        break;
					case "AddYear" :
						model = list.SingleOrDefault(x => x.AddYear == (int)value);
                        expression = x => x.AddYear == (int)value;
                        break;
					case "AddMonth" :
						model = list.SingleOrDefault(x => x.AddMonth == (int)value);
                        expression = x => x.AddMonth == (int)value;
                        break;
					case "AddDay" :
						model = list.SingleOrDefault(x => x.AddDay == (int)value);
                        expression = x => x.AddDay == (int)value;
                        break;
					case "AddDate" :
						model = list.SingleOrDefault(x => x.AddDate == (DateTime)value);
                        expression = x => x.AddDate == (DateTime)value;
                        break;
					case "Manager_Id" :
						model = list.SingleOrDefault(x => x.Manager_Id == (int)value);
                        expression = x => x.Manager_Id == (int)value;
                        break;
					case "Manager_CName" :
						model = list.SingleOrDefault(x => x.Manager_CName == (string)value);
                        expression = x => x.Manager_CName == (string)value;
                        break;
					case "UpdateDate" :
						model = list.SingleOrDefault(x => x.UpdateDate == (DateTime)value);
                        expression = x => x.UpdateDate == (DateTime)value;
                        break;

                    default :
                        return null;
                }

                if (model == null)
                {
                    //從數據庫中讀取
                    var tem = Information.SingleOrDefault(expression);
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
                CommonBll.WriteLog("從IIS緩存中獲取Information表記錄時出現異常", e);

                return null;
            }
        }
        #endregion

		#region 從IIS緩存中獲?指定條件的記錄
        /// <summary>
        /// 從IIS緩存中獲?指定條件的記錄
        /// </summary>
        /// <param name="expression">條件</param>
        /// <returns>DataAccess.Model.Information</returns>
        public DataAccess.Model.Information GetModelForCache(Expression<Func<DataAccess.Model.Information, bool>> expression)
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
        public void SetModelForCache(DataAccess.Model.Information model)
        {
			if (model == null) return;
			
            //從緩存中刪除記錄
            DelCache(model.Id);

            //從緩存中讀?記錄列表
            var list = GetList();
		    if (list == null)
		    {
                list = new List<DataAccess.Model.Information>();
		    }
            //添加記錄
            list.Add(model);
        }

        /// <summary>
        /// 更新IIS緩存中指定Id記錄
        /// </summary>
        /// <param name="model">記錄實伐</param>
        public void SetModelForCache(Information model)
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
        /// 按條件刪除IIS緩存中Information表的指定記錄
        /// </summary>
        /// <param name="expression">條件，值為null時刪除?有記錄</param>
		public void DelCache(Expression<Func<DataAccess.Model.Information, bool>> expression)
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
		/// 將Information記錄實伐（SubSonic實伐）轉換為?通的實伐（DataAccess.Model.Information）
		/// </summary>
        /// <param name="model">SubSonic插件生成的實伐</param>
		/// <returns>DataAccess.Model.Information</returns>
		public DataAccess.Model.Information Transform(Information model)
        {			
			if (model == null) 
				return null;

            return new DataAccess.Model.Information
            {
                Id = model.Id,
                InformationClass_Root_Id = model.InformationClass_Root_Id,
                InformationClass_Root_Name = model.InformationClass_Root_Name,
                InformationClass_Id = model.InformationClass_Id,
                InformationClass_Name = model.InformationClass_Name,
                Title = model.Title,
                RedirectUrl = model.RedirectUrl,
                Content = model.Content,
                Upload = model.Upload,
                FrontCoverImg = model.FrontCoverImg,
                Notes = model.Notes,
                NewsTime = model.NewsTime,
                EndTime = model.EndTime,
                Keywords = model.Keywords,
                SeoTitle = model.SeoTitle,
                SeoKey = model.SeoKey,
                SeoDesc = model.SeoDesc,
                Author = model.Author,
                FromName = model.FromName,
                Sort = model.Sort,
                IsDisplay = model.IsDisplay,
                IsHot = model.IsHot,
                IsTop = model.IsTop,
                IsPage = model.IsPage,
                IsDel = model.IsDel,
                CommentCount = model.CommentCount,
                ViewCount = model.ViewCount,
                AddYear = model.AddYear,
                AddMonth = model.AddMonth,
                AddDay = model.AddDay,
                AddDate = model.AddDate,
                Manager_Id = model.Manager_Id,
                Manager_CName = model.Manager_CName,
                UpdateDate = model.UpdateDate,
            };
        }

		/// <summary>
		/// 將Information記錄實伐集（SubSonic實伐）轉換為?通的實伐集（DataAccess.Model.Information）
		/// </summary>
        /// <param name="sourceList">SubSonic插件生成的實伐集</param>
        public IList<DataAccess.Model.Information> Transform(IList<Information> sourceList)
        {
			//創建List??
            var list = new List<DataAccess.Model.Information>();
			//將SubSonic插件生成的實伐集轉換後存儲到剛創建的List??中
            sourceList.ToList().ForEach(r => list.Add(Transform(r)));
            return list;
        }

		/// <summary>
		/// 將Information記錄實伐批?通的實伐（DataAccess.Model.Information）轉換為SubSonic插件生成的實伐
		/// </summary>
        /// <param name="model">?通的實伐（DataAccess.Model.Information）</param>
		/// <returns>Information</returns>
		public Information Transform(DataAccess.Model.Information model)
        {
			if (model == null) 
				return null;

            return new Information
            {
                Id = model.Id,
                InformationClass_Root_Id = model.InformationClass_Root_Id,
                InformationClass_Root_Name = model.InformationClass_Root_Name,
                InformationClass_Id = model.InformationClass_Id,
                InformationClass_Name = model.InformationClass_Name,
                Title = model.Title,
                RedirectUrl = model.RedirectUrl,
                Content = model.Content,
                Upload = model.Upload,
                FrontCoverImg = model.FrontCoverImg,
                Notes = model.Notes,
                NewsTime = model.NewsTime,
                EndTime = model.EndTime,
                Keywords = model.Keywords,
                SeoTitle = model.SeoTitle,
                SeoKey = model.SeoKey,
                SeoDesc = model.SeoDesc,
                Author = model.Author,
                FromName = model.FromName,
                Sort = model.Sort,
                IsDisplay = model.IsDisplay,
                IsHot = model.IsHot,
                IsTop = model.IsTop,
                IsPage = model.IsPage,
                IsDel = model.IsDel,
                CommentCount = model.CommentCount,
                ViewCount = model.ViewCount,
                AddYear = model.AddYear,
                AddMonth = model.AddMonth,
                AddDay = model.AddDay,
                AddDate = model.AddDate,
                Manager_Id = model.Manager_Id,
                Manager_CName = model.Manager_CName,
                UpdateDate = model.UpdateDate,
            };
        }

		/// <summary>
		/// 將Information記錄實伐批?通實伐集（DataAccess.Model.Information）轉換為SubSonic插件生成的實伐集
		/// </summary>
        /// <param name="sourceList">?通實伐集（DataAccess.Model.Information）</param>
        public IList<Information> Transform(IList<DataAccess.Model.Information> sourceList)
        {
			//創建List??
            var list = new List<Information>();
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
		public void SetModelValue(DataAccess.Model.Information model, Dictionary<string, object> dic)
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
		public void SetModelValue(DataAccess.Model.Information model, string colName, object value)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return;

			//返回指定條件的實伐
            switch (colName)
            {
				case "Id" :
					model.Id = (int)value;
                    break;
				case "InformationClass_Root_Id" :
					model.InformationClass_Root_Id = (int)value;
                    break;
				case "InformationClass_Root_Name" :
					model.InformationClass_Root_Name = (string)value;
                    break;
				case "InformationClass_Id" :
					model.InformationClass_Id = (int)value;
                    break;
				case "InformationClass_Name" :
					model.InformationClass_Name = (string)value;
                    break;
				case "Title" :
					model.Title = (string)value;
                    break;
				case "RedirectUrl" :
					model.RedirectUrl = (string)value;
                    break;
				case "Content" :
					model.Content = (string)value;
                    break;
				case "Upload" :
					model.Upload = (string)value;
                    break;
				case "FrontCoverImg" :
					model.FrontCoverImg = (string)value;
                    break;
				case "Notes" :
					model.Notes = (string)value;
                    break;
				case "NewsTime" :
					model.NewsTime = (DateTime)value;
                    break;
				case "EndTime" :
					model.EndTime = (DateTime)value;
                    break;
				case "Keywords" :
					model.Keywords = (string)value;
                    break;
				case "SeoTitle" :
					model.SeoTitle = (string)value;
                    break;
				case "SeoKey" :
					model.SeoKey = (string)value;
                    break;
				case "SeoDesc" :
					model.SeoDesc = (string)value;
                    break;
				case "Author" :
					model.Author = (string)value;
                    break;
				case "FromName" :
					model.FromName = (string)value;
                    break;
				case "Sort" :
					model.Sort = (int)value;
                    break;
				case "IsDisplay" :
					model.IsDisplay = ConvertHelper.Ctinyint(value);
                    break;
				case "IsHot" :
					model.IsHot = ConvertHelper.Ctinyint(value);
                    break;
				case "IsTop" :
					model.IsTop = ConvertHelper.Ctinyint(value);
                    break;
				case "IsPage" :
					model.IsPage = ConvertHelper.Ctinyint(value);
                    break;
				case "IsDel" :
					model.IsDel = ConvertHelper.Ctinyint(value);
                    break;
				case "CommentCount" :
					model.CommentCount = (int)value;
                    break;
				case "ViewCount" :
					model.ViewCount = (int)value;
                    break;
				case "AddYear" :
					model.AddYear = (int)value;
                    break;
				case "AddMonth" :
					model.AddMonth = (int)value;
                    break;
				case "AddDay" :
					model.AddDay = (int)value;
                    break;
				case "AddDate" :
					model.AddDate = (DateTime)value;
                    break;
				case "Manager_Id" :
					model.Manager_Id = (int)value;
                    break;
				case "Manager_CName" :
					model.Manager_CName = (string)value;
                    break;
				case "UpdateDate" :
					model.UpdateDate = (DateTime)value;
                    break;
            }
		}

        #endregion

		#endregion

		#region 獲?Information表記錄總數
        /// <summary>
        /// 獲?Information表記錄總數
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
				return select.GetRecordCount<Information>();
			}
        }

		/// <summary>
		/// 獲?Information表記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="wheres">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(List<ConditionHelper.SqlqueryCondition> wheres) {
			var select = new SelectHelper();
			return select.GetRecordCount<Information>(wheres);

		}

		/// <summary>
		/// 獲?Information表指定條件的記錄總數——從數據庫中查詢
		/// </summary>
        /// <param name="expression">條件</param>
		/// <returns>int</returns>
		public int GetRecordCount(Expression<Func<Information, bool>> expression) {
            return new Select().From<Information>().Where(expression).GetRecordCount();
		}

        #endregion

		#region 查找指定條件的記錄集合
        /// <summary>
        /// 查找指定條件的記錄集合——從IIS緩存中查找
        /// </summary>
        /// <param name="expression">條件語句</param>
        public IList<DataAccess.Model.Information> Find(Expression<Func<DataAccess.Model.Information, bool>> expression)
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
            return Information.Exists(x => x.Id == id);
        }

        /// <summary>
        /// 判斷指定條件的記錄是否存在——默?在IIS緩存中查找，?果沒開?緩存時，則直接在數據庫中查詢出列表後，再從列表中查詢
        /// </summary>
        /// <param name="expression">條件語句</param>
        /// <returns></returns>
        public bool Exist(Expression<Func<DataAccess.Model.Information, bool>> expression)
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

		#region 獲?Information表記錄
		/// <summary>
		/// 獲?Information表記錄
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
                return select.SelectDataTable<Information>(norepeat, top, columns, pageIndex, pageSize, wheres, sorts);
            }
            catch (Exception e)
            {
                //記錄?志
                CommonBll.WriteLog("獲?Information表記錄時出現異常", e);

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

		#region 添加與編輯Information表記錄
		/// <summary>
		/// 添加與編輯Information記錄
		/// </summary>
	    /// <param name="page">當?頁面指針</param>
		/// <param name="model">Information表實伐</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Save(Page page, Information model, string content = null, bool isCache = true, bool isAddUseLog = true)
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
						content = "{0}" + (model.Id == 0 ? "添加" : "編輯") + "Information記錄成功，ID為【" + model.Id + "】";
					}

					//添加用戶訪問記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
			catch (Exception e) {
				var result = "執行InformationBll.Save()函數出錯！";

				//出現異常，保存出錯?志信息
				CommonBll.WriteLog(result, e);
			}
		}
		#endregion

		#region 刪除Information表記錄
		/// <summary>
		/// 刪除Information表記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public override void Delete(Page page, int id, bool isAddUseLog = true) 
		{
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", InformationTable.TableName,  InformationTable.Id, id);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了Information表id為【" + id + "】的記錄！");
			}
		}

		/// <summary>
		/// 刪除Information表記錄
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
			var sql = string.Format("delete from {0} where {1} in ({2})", InformationTable.TableName,  InformationTable.Id, str);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了Information表id為【" + str + "】的記錄！");
			}
		}

		/// <summary>
        /// 刪除Information表記錄——?果使用了緩存，刪除成功後會?空本表的所有緩存記錄，?後重新加載進緩存
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="expression">條件語句</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void Delete(Page page, Expression<Func<Information, bool>> expression, bool isAddUseLog = true)
        {
			//執行刪除
			Information.Delete(expression);

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
				UseLogBll.GetInstence().Save(page, "{0}刪除了Information表記錄！");
			}
        }

		/// <summary>
        /// 刪除Information表所有記錄
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void DeleteAll(Page page, bool isAddUseLog = true)
        {
            //設瞞Sql語句
            var sql = string.Format("delete from {0}", InformationTable.TableName);

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
                UseLogBll.GetInstence().Save(page, "{0}刪除了Information表所有記錄！");
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
			if (CommonBll.UpdateSort(page, grid1, tbxSort, "Information", sortName, "Id"))
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
				UseLogBll.GetInstence().Save(page, "{0}更新了Information表排序！");

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
			if (CommonBll.AutoSort("Id", "Information", strWhere, isExistsMoreLv, pid, fieldName, fieldParentId))
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
				UseLogBll.GetInstence().Save(page, "{0}對Information表進行了自動排序操作！");

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
	                conditionColName = InformationTable.Id;
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
        public object GetFieldValue(string colName, Expression<Func<DataAccess.Model.Information, bool>> expression)
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
            return select.GetColumnsValue<Information>(colName, wheres);
        }

		/// <summary>
        /// 返回實伐中指定字段名的值
        /// </summary>
        /// <param name="model">實伐</param>
        /// <param name="colName">獲?的字段名</param>
        /// <returns></returns>
		private object GetFieldValue(DataAccess.Model.Information model, string colName)
		{
			if (model == null || string.IsNullOrEmpty(colName)) return null;
			//返回指定的列值
			switch (colName)
			{
				case "Id" :
					return model.Id;
				case "InformationClass_Root_Id" :
					return model.InformationClass_Root_Id;
				case "InformationClass_Root_Name" :
					return model.InformationClass_Root_Name;
				case "InformationClass_Id" :
					return model.InformationClass_Id;
				case "InformationClass_Name" :
					return model.InformationClass_Name;
				case "Title" :
					return model.Title;
				case "RedirectUrl" :
					return model.RedirectUrl;
				case "Content" :
					return model.Content;
				case "Upload" :
					return model.Upload;
				case "FrontCoverImg" :
					return model.FrontCoverImg;
				case "Notes" :
					return model.Notes;
				case "NewsTime" :
					return model.NewsTime;
				case "EndTime" :
					return model.EndTime;
				case "Keywords" :
					return model.Keywords;
				case "SeoTitle" :
					return model.SeoTitle;
				case "SeoKey" :
					return model.SeoKey;
				case "SeoDesc" :
					return model.SeoDesc;
				case "Author" :
					return model.Author;
				case "FromName" :
					return model.FromName;
				case "Sort" :
					return model.Sort;
				case "IsDisplay" :
					return model.IsDisplay;
				case "IsHot" :
					return model.IsHot;
				case "IsTop" :
					return model.IsTop;
				case "IsPage" :
					return model.IsPage;
				case "IsDel" :
					return model.IsDel;
				case "CommentCount" :
					return model.CommentCount;
				case "ViewCount" :
					return model.ViewCount;
				case "AddYear" :
					return model.AddYear;
				case "AddMonth" :
					return model.AddMonth;
				case "AddDay" :
					return model.AddDay;
				case "AddDate" :
					return model.AddDate;
				case "Manager_Id" :
					return model.Manager_Id;
				case "Manager_CName" :
					return model.Manager_CName;
				case "UpdateDate" :
					return model.UpdateDate;
			}

			return null;
		}

		#endregion
		
		#region 更新Information表指定字段值
		/// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="dic">需要更新的字段與值</param>
		/// <param name="wheres">條件</param>
		/// <param name="content">更新說明</param>
		/// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateValue(Page page, Dictionary<string, object> dic, List<ConditionHelper.SqlqueryCondition> wheres = null, string content = "", bool isCache = true, bool isAddUseLog = true) {
			//更新
			var update = new UpdateHelper();
			update.Update<Information>(dic, wheres);

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
					UseLogBll.GetInstence().Save(page, content != "" ? content : "{0}囊改了Information表記錄。");				
				}
				else
				{
					//添加用戶操作記錄
					UseLogBll.GetInstence().Save(page, content);
				}
			}
		}
		#endregion
				
		#region 更新Information表指定主鍵Id的字段值
		/// <summary>更新Information表記錄指定字段值</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue(Page page, int id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表主鍵Id值為" + id + "的記錄。";
			
            //條件
		    List<ConditionHelper.SqlqueryCondition> wheres = null;
            if (id > 0)
            {
                wheres = new List<ConditionHelper.SqlqueryCondition>();
                wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.Id, Comparison.Equals, id));
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

        /// <summary>更新Information表記錄指定字段值（更新一個字段值）</summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="id">主鍵Id，當小於等於0時，則更新所有記錄</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
        /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
        public void UpdateValue(Page page, int id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
            content = content != "" ? content : "{0}囊改了Information表主鍵Id值為" + id + "的記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }

		 /// <summary>更新Information表記錄指定字段值（更新兩個字段值）</summary>
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
            content = content != "" ? content : "{0}囊改了Information表主鍵Id值為" + id + "的記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue(page, id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 刪除Information表指定InformationClass_Root_Id的字段值記錄
		/// <summary>
		/// 刪除Information表指定InformationClass_Root_Id的字段值記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		public void DeleteByInformationClass_Root_Id(Page page, int id) {
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", InformationTable.TableName, InformationTable.InformationClass_Root_Id, id);

			//刪除
			var delete = new DeleteHelper();
            delete.Delete(sql);
			
			//判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除緩存
                DelCache(x => x.InformationClass_Root_Id == id);
            }
			
			//添加用戶操作記錄
			UseLogBll.GetInstence().Save(page, "{0}刪除了Information表InformationClass_Root_Id值為【" + id + "】的記錄！");
		}

		/// <summary>
		/// 刪除Information表指定InformationClass_Root_Id的字段值記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		public void DeleteByInformationClass_Root_Id(Page page, int[] id) {
			if (id == null) return;
			//將數組轉為逗號分隔的字串
			var str = string.Join(",", id);

			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} in ({2})", InformationTable.TableName, InformationTable.InformationClass_Root_Id, id);

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
                    DelCache(x => x.InformationClass_Root_Id == i);
                }
            }
			
			//添加用戶操作記錄
			UseLogBll.GetInstence().Save(page, "{0}刪除了Information表InformationClass_Root_Id值為【" + str + "】的記錄！");
		}
		#endregion

		#region 更新Information表指定InformationClass_Root_Id的字段值
        /// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="InformationClass_Root_Id">字段InformationClass_Root_Id的值</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_InformationClass_Root_Id(Page page, int InformationClass_Root_Id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表外鍵InformationClass_Root_Id值為" + InformationClass_Root_Id + "的所有記錄。";
			
            //條件
            var wheres = new List<ConditionHelper.SqlqueryCondition>
            {
                new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.InformationClass_Root_Id, Comparison.Equals, InformationClass_Root_Id)
            };

            //執行更新
            UpdateValue(page, dic, wheres, content, isCache, isAddUseLog);
        }

		/// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="InformationClass_Root_Id">字段InformationClass_Root_Id的值</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_InformationClass_Root_Id(Page page, int InformationClass_Root_Id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表外鍵InformationClass_Root_Id值為" + InformationClass_Root_Id + "的所有記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue_For_InformationClass_Root_Id(page, InformationClass_Root_Id, dic, content, isCache, isAddUseLog);
        }

		/// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="InformationClass_Root_Id">字段InformationClass_Root_Id的值</param>
        /// <param name="columnName1">要更新的列名</param>
        /// <param name="columnValue1">要更新的列值</param>
        /// <param name="columnName2">要更新的列名</param>
        /// <param name="columnValue2">要更新的列值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_InformationClass_Root_Id(Page page, int InformationClass_Root_Id, string columnName1, object columnValue1, string columnName2, object columnValue2, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表外鍵InformationClass_Root_Id值為" + InformationClass_Root_Id + "的所有記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue_For_InformationClass_Root_Id(page, InformationClass_Root_Id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 獲取InformationClass_Root_Name字段值
        /// <summary>
        /// 獲?InformationClass_Root_Name字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetInformationClass_Root_Name(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.InformationClass_Root_Name;
            }
            else
            {
                //從數據庫中查詢
                var model = Information.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.InformationClass_Root_Name;
            }
        }
        #endregion

		#region 刪除Information表指定InformationClass_Id的字段值記錄
		/// <summary>
		/// 刪除Information表指定InformationClass_Id的字段值記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		public void DeleteByInformationClass_Id(Page page, int id) {
			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} = {2}", InformationTable.TableName, InformationTable.InformationClass_Id, id);

			//刪除
			var delete = new DeleteHelper();
            delete.Delete(sql);
			
			//判斷是否?用緩存
            if (CommonBll.IsUseCache())
            {
                //刪除緩存
                DelCache(x => x.InformationClass_Id == id);
            }
			
			//添加用戶操作記錄
			UseLogBll.GetInstence().Save(page, "{0}刪除了Information表InformationClass_Id值為【" + id + "】的記錄！");
		}

		/// <summary>
		/// 刪除Information表指定InformationClass_Id的字段值記錄
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="id">記錄的主鍵值</param>
		public void DeleteByInformationClass_Id(Page page, int[] id) {
			if (id == null) return;
			//將數組轉為逗號分隔的字串
			var str = string.Join(",", id);

			//設瞞Sql語句
			var sql = string.Format("delete from {0} where {1} in ({2})", InformationTable.TableName, InformationTable.InformationClass_Id, id);

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
                    DelCache(x => x.InformationClass_Id == i);
                }
            }
			
			//添加用戶操作記錄
			UseLogBll.GetInstence().Save(page, "{0}刪除了Information表InformationClass_Id值為【" + str + "】的記錄！");
		}
		#endregion

		#region 更新Information表指定InformationClass_Id的字段值
        /// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="InformationClass_Id">字段InformationClass_Id的值</param>
	    /// <param name="dic">需要更新的字段與值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_InformationClass_Id(Page page, int InformationClass_Id, Dictionary<string, object> dic, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表外鍵InformationClass_Id值為" + InformationClass_Id + "的所有記錄。";
			
            //條件
            var wheres = new List<ConditionHelper.SqlqueryCondition>
            {
                new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.InformationClass_Id, Comparison.Equals, InformationClass_Id)
            };

            //執行更新
            UpdateValue(page, dic, wheres, content, isCache, isAddUseLog);
        }

		/// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="InformationClass_Id">字段InformationClass_Id的值</param>
        /// <param name="columnName">要更新的列名</param>
        /// <param name="columnValue">要更新的列值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_InformationClass_Id(Page page, int InformationClass_Id, string columnName, object columnValue, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表外鍵InformationClass_Id值為" + InformationClass_Id + "的所有記錄，將" + columnName + "字段值囊改為" + columnValue;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName, columnValue);

			//執行更新
            UpdateValue_For_InformationClass_Id(page, InformationClass_Id, dic, content, isCache, isAddUseLog);
        }

		/// <summary>更新Information表記錄指定字段值，?果使用了緩存，保存成功後會?空本表的所有緩存記錄，?後重新加載進緩存</summary>
        /// <param name="page">當?頁面指針</param>
	    /// <param name="InformationClass_Id">字段InformationClass_Id的值</param>
        /// <param name="columnName1">要更新的列名</param>
        /// <param name="columnValue1">要更新的列值</param>
        /// <param name="columnName2">要更新的列名</param>
        /// <param name="columnValue2">要更新的列值</param>
	    /// <param name="content">更新說明</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
	    public void UpdateValue_For_InformationClass_Id(Page page, int InformationClass_Id, string columnName1, object columnValue1, string columnName2, object columnValue2, string content = "", bool isCache = true, bool isAddUseLog = true)
        {
			content = content != "" ? content : "{0}囊改了Information表外鍵InformationClass_Id值為" + InformationClass_Id + "的所有記錄，將" + columnName1 + "字段值囊改為" + columnValue1 + "，" + columnName2 + "字段值囊改為" + columnValue2;
            //設瞞更新字段
            var dic = new Dictionary<string, object>();
            dic.Add(columnName1, columnValue1);
            dic.Add(columnName2, columnValue2);

			//執行更新
            UpdateValue_For_InformationClass_Id(page, InformationClass_Id, dic, content, isCache, isAddUseLog);
        }
        #endregion
		
		#region 獲取InformationClass_Name字段值
        /// <summary>
        /// 獲?InformationClass_Name字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetInformationClass_Name(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.InformationClass_Name;
            }
            else
            {
                //從數據庫中查詢
                var model = Information.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.InformationClass_Name;
            }
        }
        #endregion

		#region 刪除FrontCoverImg字段存儲的對應圖?
		/// <summary>刪除FrontCoverImg字段存儲的對應圖?</summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		public void DelFrontCoverImg(Page page, int pkValue, bool isCache = true) 
		{
			try {
				string img = "";

				//設瞞條件
				var wheres = new List<ConditionHelper.SqlqueryCondition>();
				wheres.Add(new ConditionHelper.SqlqueryCondition(ConstraintType.And, InformationTable.Id, Comparison.Equals, pkValue));

				//獲取圖片地址
				var select = new SelectHelper();
				img = select.GetColumnsValue<Information>(InformationTable.FrontCoverImg, wheres) + "";

				//刪除圖片
				UploadFileBll.GetInstence().Upload_OneDelPic(img);

				//設瞞更新值
				var setValue = new Dictionary<string, object>();
				setValue[InformationTable.FrontCoverImg] = "";
				//更新
				UpdateValue(page, setValue, wheres, "{0}更新了Ad表id為【" + pkValue + "】的記錄，將圖片Img刪除", false);

                //判斷是否有用緩存
                if (isCache && CommonBll.IsUseCache())
                {
                    //從緩存中獲取實伐
                    var model = GetModelForCache(pkValue);
					if (model != null)
					{
						//給獲取的實伐賦值
						SetModelValue(model, InformationTable.FrontCoverImg, "");
						//更新緩存中的實伐
						SetModelForCache(model);
					}
                }
			}
			catch (Exception e) {
				//出現異常，保存出錯日志信息
				CommonBll.WriteLog("", e);
			}
		}
		#endregion

		#region 使用Keywords來查詢，獲?一個Information實伐對像
        /// <summary>使用Key來查詢，獲取一個Information實伐對像</summary>
        /// <param name="page">當前頁面指針</param>
        /// <param name="key">Key值</param>
        /// <param name="isCache">是否從緩存中讀取</param>
        /// <returns>DataAccess.Model.Information 實伐</returns>
        public DataAccess.Model.Information GetModel_ByKeywords(Page page, string key, bool isCache = true)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            //判斷是否有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                return GetModelForCache(x => x.Keywords == key);
            }
			else
			{
				//從數據庫中查詢
				return Transform(Information.SingleOrDefault(x => x.Keywords == key));
			}
        }
        #endregion

		#region 使用SeoKey來查詢，獲?一個Information實伐對像
        /// <summary>使用Key來查詢，獲取一個Information實伐對像</summary>
        /// <param name="page">當前頁面指針</param>
        /// <param name="key">Key值</param>
        /// <param name="isCache">是否從緩存中讀取</param>
        /// <returns>DataAccess.Model.Information 實伐</returns>
        public DataAccess.Model.Information GetModel_BySeoKey(Page page, string key, bool isCache = true)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            //判斷是否有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                return GetModelForCache(x => x.SeoKey == key);
            }
			else
			{
				//從數據庫中查詢
				return Transform(Information.SingleOrDefault(x => x.SeoKey == key));
			}
        }
        #endregion

		#region 獲取FromName字段值
        /// <summary>
        /// 獲?FromName字段值
        /// </summary>
        /// <param name="page">當?頁面指針</param>
        /// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否從緩存中讀?</param>
        /// <returns></returns>
        public string GetFromName(Page page, int pkValue, bool isCache = true)
        {
            //判斷是否?有用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //從緩存中獲取實伐
                var model = GetModelForCache(pkValue);
                return model == null ? "" : model.FromName;
            }
            else
            {
                //從數據庫中查詢
                var model = Information.SingleOrDefault(x => x.Id == pkValue);
                return model == null ? "" : model.FromName;
            }
        }
        #endregion

		#region 更新IsDisplay字段值
		/// <summary>
		/// 更新IsDisplay字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateIsDisplay(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[InformationTable.IsDisplay] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了Information表id為【" + pkValue + "】的記錄，更新內容為將IsDisplay字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新IsHot字段值
		/// <summary>
		/// 更新IsHot字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateIsHot(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[InformationTable.IsHot] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了Information表id為【" + pkValue + "】的記錄，更新內容為將IsHot字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新IsTop字段值
		/// <summary>
		/// 更新IsTop字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateIsTop(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[InformationTable.IsTop] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了Information表id為【" + pkValue + "】的記錄，更新內容為將IsTop字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新IsPage字段值
		/// <summary>
		/// 更新IsPage字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateIsPage(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[InformationTable.IsPage] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了Information表id為【" + pkValue + "】的記錄，更新內容為將IsPage字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新IsDel字段值
		/// <summary>
		/// 更新IsDel字段值
		/// </summary>
		/// <param name="page">當?頁面指針</param>
		/// <param name="pkValue">主鍵Id，當等於0時，則更新所有記錄</param>
		/// <param name="updateValue">更新值</param>
        /// <param name="isCache">是否魂步更新緩存</param>
		/// <param name="isAddUseLog">是否添加用戶操作?志</param>
		public void UpdateIsDel(Page page, int pkValue, int updateValue, bool isCache = true, bool isAddUseLog = true) {
			//設瞞更新值
			var setValue = new Dictionary<string, object>();
			setValue[InformationTable.IsDel] = updateValue;

			//更新
			UpdateValue(page, pkValue, setValue, "{0}更新了Information表id為【" + pkValue + "】的記錄，更新內容為將IsDel字段值囊改為" + updateValue, isCache, isAddUseLog);
		}
		#endregion
		
		#region 更新CommentCount字段值
		/// <summary>
		/// 更新CommentCount字段值
		/// </summary>
		/// <param name="page">當前頁面指針</param>
		/// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否同步更新緩存</param>
		public void UpdateCommentCount(Page page, int pkValue, bool isCache = true) 
		{
			if (pkValue <= 0) return;
			
			//判斷是否?用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //獲取實伐
                var model = GetModelForCache(pkValue);
				if (model != null)
				{
					model.CommentCount++;

					SetModelForCache(model);
				}
            }

			//設瞞更新Sql語句
			var sql = string.Format("update {0} set {1}={1} + 1 where {2} = {3}", InformationTable.TableName, InformationTable.CommentCount, "Id", pkValue);

			//更新
			var update = new UpdateHelper();
			update.Update(sql);
		}
		#endregion
		
		#region 更新ViewCount字段值
		/// <summary>
		/// 更新ViewCount字段值
		/// </summary>
		/// <param name="page">當前頁面指針</param>
		/// <param name="pkValue">主鍵Id</param>
        /// <param name="isCache">是否同步更新緩存</param>
		public void UpdateViewCount(Page page, int pkValue, bool isCache = true) 
		{
			if (pkValue <= 0) return;
			
			//判斷是否?用緩存
            if (isCache && CommonBll.IsUseCache())
            {
                //獲取實伐
                var model = GetModelForCache(pkValue);
				if (model != null)
				{
					model.ViewCount++;

					SetModelForCache(model);
				}
            }

			//設瞞更新Sql語句
			var sql = string.Format("update {0} set {1}={1} + 1 where {2} = {3}", InformationTable.TableName, InformationTable.ViewCount, "Id", pkValue);

			//更新
			var update = new UpdateHelper();
			update.Update(sql);
		}
		#endregion
		
		#region 獲?排序字段Sort的最大值
		/// <summary>
		/// 獲取排序字段Sort的最大值
		/// </summary>
		public int GetSortMax() 
		{
			//查詢
			var select = new SelectHelper();
		    return ConvertHelper.Cint0(select.GetMax<Information>(InformationTable.Sort));
		}
		#endregion
		
    
		#endregion 模版生成函數

    } 
}
