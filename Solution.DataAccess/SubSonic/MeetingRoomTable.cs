 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MeetingRoom
        /// Primary Key: Id
        /// </summary>
        public class MeetingRoomTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "MeetingRoom";
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
			/// 名稱
			/// </summary>
   			public static string Name{
			      get{
        			return "Name";
      			}
		    }
			/// <summary>
			/// 可容納人數
			/// </summary>
   			public static string Qty{
			      get{
        			return "Qty";
      			}
		    }
			/// <summary>
			/// 地址
			/// </summary>
   			public static string Address{
			      get{
        			return "Address";
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
                    
        }
}
