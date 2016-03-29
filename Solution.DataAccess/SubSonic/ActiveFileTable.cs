 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: ActiveFile
        /// Primary Key: Id
        /// </summary>
        public class ActiveFileTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "ActiveFile";
      			}
			}

			/// <summary>
			/// Id
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }
			/// <summary>
			/// 名稱
			/// </summary>
   			public static string Name{
			      get{
        			return "Name";
      			}
		    }
			/// <summary>
			/// 簡介
			/// </summary>
   			public static string Notes{
			      get{
        			return "Notes";
      			}
		    }
			/// <summary>
			/// 內容
			/// </summary>
   			public static string Content{
			      get{
        			return "Content";
      			}
		    }
			/// <summary>
			/// 關鍵字
			/// </summary>
   			public static string Keyword{
			      get{
        			return "Keyword";
      			}
		    }
			/// <summary>
			/// 文件鏈接
			/// </summary>
   			public static string Url{
			      get{
        			return "Url";
      			}
		    }
			/// <summary>
			/// 下載量
			/// </summary>
   			public static string DownloadCount{
			      get{
        			return "DownloadCount";
      			}
		    }
			/// <summary>
			/// 排序
			/// </summary>
   			public static string Sort{
			      get{
        			return "Sort";
      			}
		    }
			/// <summary>
			/// 是否顯示
			/// </summary>
   			public static string IsDisplay{
			      get{
        			return "IsDisplay";
      			}
		    }
			/// <summary>
			/// 修改時間
			/// </summary>
   			public static string UpdateDate{
			      get{
        			return "UpdateDate";
      			}
		    }
			/// <summary>
			/// 類別編號
			/// </summary>
   			public static string ActiveFileClass_Id{
			      get{
        			return "ActiveFileClass_Id";
      			}
		    }
			/// <summary>
			/// 類別名稱
			/// </summary>
   			public static string ActiveFileClass_Name{
			      get{
        			return "ActiveFileClass_Name";
      			}
		    }
			/// <summary>
			/// 申請人編號號
			/// </summary>
   			public static string Employee_EmpId{
			      get{
        			return "Employee_EmpId";
      			}
		    }
			/// <summary>
			/// 申請人
			/// </summary>
   			public static string Employee_CName{
			      get{
        			return "Employee_CName";
      			}
		    }
                    
        }
}
