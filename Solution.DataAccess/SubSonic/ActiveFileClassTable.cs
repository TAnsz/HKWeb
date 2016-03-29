 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: ActiveFileClass
        /// Primary Key: Id
        /// </summary>
        public class ActiveFileClassTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "ActiveFileClass";
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
			/// 父ID
			/// </summary>
   			public static string ParentId{
			      get{
        			return "ParentId";
      			}
		    }
			/// <summary>
			/// 層數
			/// </summary>
   			public static string Depth{
			      get{
        			return "Depth";
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
			/// 關鍵字
			/// </summary>
   			public static string Keyword{
			      get{
        			return "Keyword";
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
			/// <summary>
			/// 添加時間
			/// </summary>
   			public static string AddDate{
			      get{
        			return "AddDate";
      			}
		    }
                    
        }
}
