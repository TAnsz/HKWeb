 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Machine
        /// Primary Key: Id
        /// </summary>
        public class MachineTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Machine";
      			}
			}

			/// <summary>
			/// 
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string name{
			      get{
        			return "name";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string spec{
			      get{
        			return "spec";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ip{
			      get{
        			return "ip";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string port{
			      get{
        			return "port";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string isvaild{
			      get{
        			return "isvaild";
      			}
		    }
                    
        }
}
