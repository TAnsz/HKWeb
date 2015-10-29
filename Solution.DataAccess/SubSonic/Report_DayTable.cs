 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Report_Day
        /// Primary Key: join_id
        /// </summary>
        public class Report_DayTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Report_Day";
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
   			public static string emp_id{
			      get{
        			return "emp_id";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string sign_date{
			      get{
        			return "sign_date";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string join_id{
			      get{
        			return "join_id";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string cur_kind{
			      get{
        			return "cur_kind";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string depart_id{
			      get{
        			return "depart_id";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string calc_date{
			      get{
        			return "calc_date";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string adjusted{
			      get{
        			return "adjusted";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string shift_id{
			      get{
        			return "shift_id";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string status{
			      get{
        			return "status";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string sign_count{
			      get{
        			return "sign_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string need_sign_count{
			      get{
        			return "need_sign_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string in1{
			      get{
        			return "in1";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string out1{
			      get{
        			return "out1";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string in2{
			      get{
        			return "in2";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string out2{
			      get{
        			return "out2";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string in3{
			      get{
        			return "in3";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string out3{
			      get{
        			return "out3";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string in4{
			      get{
        			return "in4";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string out4{
			      get{
        			return "out4";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string in5{
			      get{
        			return "in5";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string out5{
			      get{
        			return "out5";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string plan_days{
			      get{
        			return "plan_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string sun_days{
			      get{
        			return "sun_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string hd_days{
			      get{
        			return "hd_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string duty_days{
			      get{
        			return "duty_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string work_days{
			      get{
        			return "work_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string absent_days{
			      get{
        			return "absent_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave_days{
			      get{
        			return "leave_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string fact_hrs{
			      get{
        			return "fact_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string basic_hrs{
			      get{
        			return "basic_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string mid_hrs{
			      get{
        			return "mid_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ns_hrs{
			      get{
        			return "ns_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_hrs{
			      get{
        			return "ot_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string sun_hrs{
			      get{
        			return "sun_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string hd_hrs{
			      get{
        			return "hd_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string absent_hrs{
			      get{
        			return "absent_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string input_ot_hrs{
			      get{
        			return "input_ot_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late_mins{
			      get{
        			return "late_mins";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late_count{
			      get{
        			return "late_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave_mins{
			      get{
        			return "leave_mins";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave_count{
			      get{
        			return "leave_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_late_mins{
			      get{
        			return "ot_late_mins";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_leave_mins{
			      get{
        			return "ot_leave_mins";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_late_count{
			      get{
        			return "ot_late_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_leave_count{
			      get{
        			return "ot_leave_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ns_count{
			      get{
        			return "ns_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string mid_count{
			      get{
        			return "mid_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_count{
			      get{
        			return "ot_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string absent_count{
			      get{
        			return "absent_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l0hrs{
			      get{
        			return "l0hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l1hrs{
			      get{
        			return "l1hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l2hrs{
			      get{
        			return "l2hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l3hrs{
			      get{
        			return "l3hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l4hrs{
			      get{
        			return "l4hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l5hrs{
			      get{
        			return "l5hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l6hrs{
			      get{
        			return "l6hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l7hrs{
			      get{
        			return "l7hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l8hrs{
			      get{
        			return "l8hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string L9hrs{
			      get{
        			return "L9hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l10hrs{
			      get{
        			return "l10hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l11hrs{
			      get{
        			return "l11hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l12hrs{
			      get{
        			return "l12hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l13hrs{
			      get{
        			return "l13hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l14hrs{
			      get{
        			return "l14hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l15hrs{
			      get{
        			return "l15hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string outwork_hrs{
			      get{
        			return "outwork_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string shutdown_hrs{
			      get{
        			return "shutdown_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string outwork_days{
			      get{
        			return "outwork_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string shutdown_days{
			      get{
        			return "shutdown_days";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string notes{
			      get{
        			return "notes";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string shift_hrs{
			      get{
        			return "shift_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string onwatch_hrs{
			      get{
        			return "onwatch_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string audit{
			      get{
        			return "audit";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l0day{
			      get{
        			return "l0day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l1day{
			      get{
        			return "l1day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l2day{
			      get{
        			return "l2day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l3day{
			      get{
        			return "l3day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l4day{
			      get{
        			return "l4day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l5day{
			      get{
        			return "l5day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l6day{
			      get{
        			return "l6day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l7day{
			      get{
        			return "l7day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l8day{
			      get{
        			return "l8day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string L9day{
			      get{
        			return "L9day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l10day{
			      get{
        			return "l10day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l11day{
			      get{
        			return "l11day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l12day{
			      get{
        			return "l12day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l13day{
			      get{
        			return "l13day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l14day{
			      get{
        			return "l14day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l15day{
			      get{
        			return "l15day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string outwork_count{
			      get{
        			return "outwork_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string shutdown_count{
			      get{
        			return "shutdown_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l0count{
			      get{
        			return "l0count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l1count{
			      get{
        			return "l1count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l2count{
			      get{
        			return "l2count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l3count{
			      get{
        			return "l3count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l4count{
			      get{
        			return "l4count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l5count{
			      get{
        			return "l5count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l6count{
			      get{
        			return "l6count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l7count{
			      get{
        			return "l7count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l8count{
			      get{
        			return "l8count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string L9count{
			      get{
        			return "L9count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l10count{
			      get{
        			return "l10count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l11count{
			      get{
        			return "l11count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l12count{
			      get{
        			return "l12count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l13count{
			      get{
        			return "l13count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l14count{
			      get{
        			return "l14count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string l15count{
			      get{
        			return "l15count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_sun_day{
			      get{
        			return "ot_sun_day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string ot_nd_day{
			      get{
        			return "ot_nd_day";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string bait_hrs{
			      get{
        			return "bait_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string lesshrs_count{
			      get{
        			return "lesshrs_count";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string over_hrs{
			      get{
        			return "over_hrs";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late1_min{
			      get{
        			return "late1_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late2_min{
			      get{
        			return "late2_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late3_min{
			      get{
        			return "late3_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late4_min{
			      get{
        			return "late4_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string late5_min{
			      get{
        			return "late5_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave1_min{
			      get{
        			return "leave1_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave2_min{
			      get{
        			return "leave2_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave3_min{
			      get{
        			return "leave3_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave4_min{
			      get{
        			return "leave4_min";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string leave5_min{
			      get{
        			return "leave5_min";
      			}
		    }
                    
        }
}
