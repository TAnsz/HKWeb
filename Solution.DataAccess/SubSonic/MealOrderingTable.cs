 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MealOrdering
        /// Primary Key: Id
        /// </summary>
        public class MealOrderingTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "MealOrdering";
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
			/// 編號
			/// </summary>
   			public static string Code{
			      get{
        			return "Code";
      			}
		    }
			/// <summary>
			/// 申請人編號
			/// </summary>
   			public static string Employee_EmpId{
			      get{
        			return "Employee_EmpId";
      			}
		    }
			/// <summary>
			/// 申請人
			/// </summary>
   			public static string Employee_Name{
			      get{
        			return "Employee_Name";
      			}
		    }
			/// <summary>
			/// 申請人部門編號
			/// </summary>
   			public static string DepartId{
			      get{
        			return "DepartId";
      			}
		    }
			/// <summary>
			/// 申請人部門名稱
			/// </summary>
   			public static string DepartName{
			      get{
        			return "DepartName";
      			}
		    }
			/// <summary>
			/// 飯類
			/// </summary>
   			public static string FoodCode{
			      get{
        			return "FoodCode";
      			}
		    }
			/// <summary>
			/// 餐飲
			/// </summary>
   			public static string DrinkCode{
			      get{
        			return "DrinkCode";
      			}
		    }
			/// <summary>
			/// 申請日期
			/// </summary>
   			public static string ApplyDate{
			      get{
        			return "ApplyDate";
      			}
		    }
			/// <summary>
			/// 錄入人編號
			/// </summary>
   			public static string RecordId{
			      get{
        			return "RecordId";
      			}
		    }
			/// <summary>
			/// 錄入人
			/// </summary>
   			public static string RecordName{
			      get{
        			return "RecordName";
      			}
		    }
			/// <summary>
			/// 錄入日期
			/// </summary>
   			public static string RecordDate{
			      get{
        			return "RecordDate";
      			}
		    }
			/// <summary>
			/// 備注
			/// </summary>
   			public static string Remark{
			      get{
        			return "Remark";
      			}
		    }
			/// <summary>
			/// 有效
			/// </summary>
   			public static string IsVaild{
			      get{
        			return "IsVaild";
      			}
		    }
			/// <summary>
			/// 修改日期
			/// </summary>
   			public static string ModifyDate{
			      get{
        			return "ModifyDate";
      			}
		    }
			/// <summary>
			/// 修改人編號
			/// </summary>
   			public static string ModifyId{
			      get{
        			return "ModifyId";
      			}
		    }
			/// <summary>
			/// 修改人
			/// </summary>
   			public static string ModifyBy{
			      get{
        			return "ModifyBy";
      			}
		    }
                    
        }
}
