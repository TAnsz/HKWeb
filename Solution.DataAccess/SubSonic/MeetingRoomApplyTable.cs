 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MeetingRoomApply
        /// Primary Key: Id
        /// </summary>
        public class MeetingRoomApplyTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "MeetingRoomApply";
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
			/// 會議室編號
			/// </summary>
   			public static string MeetingRoom_Code{
			      get{
        			return "MeetingRoom_Code";
      			}
		    }
			/// <summary>
			/// 會議室名稱
			/// </summary>
   			public static string MeetingRoom_Name{
			      get{
        			return "MeetingRoom_Name";
      			}
		    }
			/// <summary>
			/// 申?日期
			/// </summary>
   			public static string ApplyDate{
			      get{
        			return "ApplyDate";
      			}
		    }
			/// <summary>
			/// ?始??
			/// </summary>
   			public static string StartTime{
			      get{
        			return "StartTime";
      			}
		    }
			/// <summary>
			/// ?束?据
			/// </summary>
   			public static string EndTime{
			      get{
        			return "EndTime";
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
