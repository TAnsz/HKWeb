 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Report_Day表實例類
    /// </summary>
	[Serializable]
    public partial class Report_Day
    {

		long _Id;
		/// <summary>例
		/// 
		/// </summary>
		public long Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _emp_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string emp_id
		{
			get { return _emp_id; }
			set { _emp_id = value; }
		}

		DateTime _sign_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime sign_date
		{
			get { return _sign_date; }
			set { _sign_date = value; }
		}

		int _join_id;
		/// <summary>例
		/// 
		/// </summary>
		public int join_id
		{
			get { return _join_id; }
			set { _join_id = value; }
		}

		int? _cur_kind;
		/// <summary>例
		/// 
		/// </summary>
		public int? cur_kind
		{
			get { return _cur_kind; }
			set { _cur_kind = value; }
		}

		string _depart_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string depart_id
		{
			get { return _depart_id; }
			set { _depart_id = value; }
		}

		DateTime _calc_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime calc_date
		{
			get { return _calc_date; }
			set { _calc_date = value; }
		}

		short? _adjusted;
		/// <summary>例
		/// 
		/// </summary>
		public short? adjusted
		{
			get { return _adjusted; }
			set { _adjusted = value; }
		}

		string _shift_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string shift_id
		{
			get { return _shift_id; }
			set { _shift_id = value; }
		}

		byte? _status;
		/// <summary>例
		/// 
		/// </summary>
		public byte? status
		{
			get { return _status; }
			set { _status = value; }
		}

		byte? _sign_count;
		/// <summary>例
		/// 
		/// </summary>
		public byte? sign_count
		{
			get { return _sign_count; }
			set { _sign_count = value; }
		}

		int? _need_sign_count;
		/// <summary>例
		/// 
		/// </summary>
		public int? need_sign_count
		{
			get { return _need_sign_count; }
			set { _need_sign_count = value; }
		}

		DateTime? _in1 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? in1
		{
			get { return _in1; }
			set { _in1 = value; }
		}

		DateTime? _out1 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? out1
		{
			get { return _out1; }
			set { _out1 = value; }
		}

		DateTime? _in2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? in2
		{
			get { return _in2; }
			set { _in2 = value; }
		}

		DateTime? _out2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? out2
		{
			get { return _out2; }
			set { _out2 = value; }
		}

		DateTime? _in3 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? in3
		{
			get { return _in3; }
			set { _in3 = value; }
		}

		DateTime? _out3 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? out3
		{
			get { return _out3; }
			set { _out3 = value; }
		}

		DateTime? _in4 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? in4
		{
			get { return _in4; }
			set { _in4 = value; }
		}

		DateTime? _out4 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? out4
		{
			get { return _out4; }
			set { _out4 = value; }
		}

		DateTime? _in5 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? in5
		{
			get { return _in5; }
			set { _in5 = value; }
		}

		DateTime? _out5 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? out5
		{
			get { return _out5; }
			set { _out5 = value; }
		}

		decimal? _plan_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? plan_days
		{
			get { return _plan_days; }
			set { _plan_days = value; }
		}

		decimal? _sun_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? sun_days
		{
			get { return _sun_days; }
			set { _sun_days = value; }
		}

		decimal? _hd_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? hd_days
		{
			get { return _hd_days; }
			set { _hd_days = value; }
		}

		decimal? _duty_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? duty_days
		{
			get { return _duty_days; }
			set { _duty_days = value; }
		}

		decimal? _work_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? work_days
		{
			get { return _work_days; }
			set { _work_days = value; }
		}

		decimal? _absent_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? absent_days
		{
			get { return _absent_days; }
			set { _absent_days = value; }
		}

		decimal? _leave_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave_days
		{
			get { return _leave_days; }
			set { _leave_days = value; }
		}

		decimal? _fact_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? fact_hrs
		{
			get { return _fact_hrs; }
			set { _fact_hrs = value; }
		}

		decimal? _basic_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? basic_hrs
		{
			get { return _basic_hrs; }
			set { _basic_hrs = value; }
		}

		decimal? _mid_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? mid_hrs
		{
			get { return _mid_hrs; }
			set { _mid_hrs = value; }
		}

		decimal? _ns_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ns_hrs
		{
			get { return _ns_hrs; }
			set { _ns_hrs = value; }
		}

		decimal? _ot_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_hrs
		{
			get { return _ot_hrs; }
			set { _ot_hrs = value; }
		}

		decimal? _sun_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? sun_hrs
		{
			get { return _sun_hrs; }
			set { _sun_hrs = value; }
		}

		decimal? _hd_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? hd_hrs
		{
			get { return _hd_hrs; }
			set { _hd_hrs = value; }
		}

		decimal? _absent_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? absent_hrs
		{
			get { return _absent_hrs; }
			set { _absent_hrs = value; }
		}

		decimal? _input_ot_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? input_ot_hrs
		{
			get { return _input_ot_hrs; }
			set { _input_ot_hrs = value; }
		}

		decimal? _late_mins;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late_mins
		{
			get { return _late_mins; }
			set { _late_mins = value; }
		}

		decimal? _late_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late_count
		{
			get { return _late_count; }
			set { _late_count = value; }
		}

		decimal? _leave_mins;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave_mins
		{
			get { return _leave_mins; }
			set { _leave_mins = value; }
		}

		decimal? _leave_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave_count
		{
			get { return _leave_count; }
			set { _leave_count = value; }
		}

		decimal? _ot_late_mins;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_late_mins
		{
			get { return _ot_late_mins; }
			set { _ot_late_mins = value; }
		}

		decimal? _ot_leave_mins;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_leave_mins
		{
			get { return _ot_leave_mins; }
			set { _ot_leave_mins = value; }
		}

		decimal? _ot_late_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_late_count
		{
			get { return _ot_late_count; }
			set { _ot_late_count = value; }
		}

		decimal? _ot_leave_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_leave_count
		{
			get { return _ot_leave_count; }
			set { _ot_leave_count = value; }
		}

		decimal? _ns_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ns_count
		{
			get { return _ns_count; }
			set { _ns_count = value; }
		}

		decimal? _mid_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? mid_count
		{
			get { return _mid_count; }
			set { _mid_count = value; }
		}

		decimal? _ot_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_count
		{
			get { return _ot_count; }
			set { _ot_count = value; }
		}

		decimal? _absent_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? absent_count
		{
			get { return _absent_count; }
			set { _absent_count = value; }
		}

		decimal? _l0hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l0hrs
		{
			get { return _l0hrs; }
			set { _l0hrs = value; }
		}

		decimal? _l1hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l1hrs
		{
			get { return _l1hrs; }
			set { _l1hrs = value; }
		}

		decimal? _l2hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l2hrs
		{
			get { return _l2hrs; }
			set { _l2hrs = value; }
		}

		decimal? _l3hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l3hrs
		{
			get { return _l3hrs; }
			set { _l3hrs = value; }
		}

		decimal? _l4hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l4hrs
		{
			get { return _l4hrs; }
			set { _l4hrs = value; }
		}

		decimal? _l5hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l5hrs
		{
			get { return _l5hrs; }
			set { _l5hrs = value; }
		}

		decimal? _l6hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l6hrs
		{
			get { return _l6hrs; }
			set { _l6hrs = value; }
		}

		decimal? _l7hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l7hrs
		{
			get { return _l7hrs; }
			set { _l7hrs = value; }
		}

		decimal? _l8hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l8hrs
		{
			get { return _l8hrs; }
			set { _l8hrs = value; }
		}

		decimal? _L9hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? L9hrs
		{
			get { return _L9hrs; }
			set { _L9hrs = value; }
		}

		decimal? _l10hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l10hrs
		{
			get { return _l10hrs; }
			set { _l10hrs = value; }
		}

		decimal? _l11hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l11hrs
		{
			get { return _l11hrs; }
			set { _l11hrs = value; }
		}

		decimal? _l12hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l12hrs
		{
			get { return _l12hrs; }
			set { _l12hrs = value; }
		}

		decimal? _l13hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l13hrs
		{
			get { return _l13hrs; }
			set { _l13hrs = value; }
		}

		decimal? _l14hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l14hrs
		{
			get { return _l14hrs; }
			set { _l14hrs = value; }
		}

		decimal? _l15hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l15hrs
		{
			get { return _l15hrs; }
			set { _l15hrs = value; }
		}

		decimal? _outwork_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? outwork_hrs
		{
			get { return _outwork_hrs; }
			set { _outwork_hrs = value; }
		}

		decimal? _shutdown_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? shutdown_hrs
		{
			get { return _shutdown_hrs; }
			set { _shutdown_hrs = value; }
		}

		decimal? _outwork_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? outwork_days
		{
			get { return _outwork_days; }
			set { _outwork_days = value; }
		}

		decimal? _shutdown_days;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? shutdown_days
		{
			get { return _shutdown_days; }
			set { _shutdown_days = value; }
		}

		string _notes = "";
		/// <summary>
		/// 
		/// </summary>
		public string notes
		{
			get { return _notes; }
			set { _notes = value; }
		}

		decimal? _shift_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? shift_hrs
		{
			get { return _shift_hrs; }
			set { _shift_hrs = value; }
		}

		decimal? _onwatch_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? onwatch_hrs
		{
			get { return _onwatch_hrs; }
			set { _onwatch_hrs = value; }
		}

		short? _audit;
		/// <summary>例
		/// 
		/// </summary>
		public short? audit
		{
			get { return _audit; }
			set { _audit = value; }
		}

		decimal? _l0day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l0day
		{
			get { return _l0day; }
			set { _l0day = value; }
		}

		decimal? _l1day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l1day
		{
			get { return _l1day; }
			set { _l1day = value; }
		}

		decimal? _l2day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l2day
		{
			get { return _l2day; }
			set { _l2day = value; }
		}

		decimal? _l3day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l3day
		{
			get { return _l3day; }
			set { _l3day = value; }
		}

		decimal? _l4day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l4day
		{
			get { return _l4day; }
			set { _l4day = value; }
		}

		decimal? _l5day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l5day
		{
			get { return _l5day; }
			set { _l5day = value; }
		}

		decimal? _l6day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l6day
		{
			get { return _l6day; }
			set { _l6day = value; }
		}

		decimal? _l7day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l7day
		{
			get { return _l7day; }
			set { _l7day = value; }
		}

		decimal? _l8day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l8day
		{
			get { return _l8day; }
			set { _l8day = value; }
		}

		decimal? _L9day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? L9day
		{
			get { return _L9day; }
			set { _L9day = value; }
		}

		decimal? _l10day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l10day
		{
			get { return _l10day; }
			set { _l10day = value; }
		}

		decimal? _l11day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l11day
		{
			get { return _l11day; }
			set { _l11day = value; }
		}

		decimal? _l12day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l12day
		{
			get { return _l12day; }
			set { _l12day = value; }
		}

		decimal? _l13day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l13day
		{
			get { return _l13day; }
			set { _l13day = value; }
		}

		decimal? _l14day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l14day
		{
			get { return _l14day; }
			set { _l14day = value; }
		}

		decimal? _l15day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l15day
		{
			get { return _l15day; }
			set { _l15day = value; }
		}

		decimal? _outwork_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? outwork_count
		{
			get { return _outwork_count; }
			set { _outwork_count = value; }
		}

		decimal? _shutdown_count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? shutdown_count
		{
			get { return _shutdown_count; }
			set { _shutdown_count = value; }
		}

		decimal? _l0count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l0count
		{
			get { return _l0count; }
			set { _l0count = value; }
		}

		decimal? _l1count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l1count
		{
			get { return _l1count; }
			set { _l1count = value; }
		}

		decimal? _l2count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l2count
		{
			get { return _l2count; }
			set { _l2count = value; }
		}

		decimal? _l3count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l3count
		{
			get { return _l3count; }
			set { _l3count = value; }
		}

		decimal? _l4count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l4count
		{
			get { return _l4count; }
			set { _l4count = value; }
		}

		decimal? _l5count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l5count
		{
			get { return _l5count; }
			set { _l5count = value; }
		}

		decimal? _l6count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l6count
		{
			get { return _l6count; }
			set { _l6count = value; }
		}

		decimal? _l7count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l7count
		{
			get { return _l7count; }
			set { _l7count = value; }
		}

		decimal? _l8count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l8count
		{
			get { return _l8count; }
			set { _l8count = value; }
		}

		decimal? _L9count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? L9count
		{
			get { return _L9count; }
			set { _L9count = value; }
		}

		decimal? _l10count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l10count
		{
			get { return _l10count; }
			set { _l10count = value; }
		}

		decimal? _l11count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l11count
		{
			get { return _l11count; }
			set { _l11count = value; }
		}

		decimal? _l12count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l12count
		{
			get { return _l12count; }
			set { _l12count = value; }
		}

		decimal? _l13count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l13count
		{
			get { return _l13count; }
			set { _l13count = value; }
		}

		decimal? _l14count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l14count
		{
			get { return _l14count; }
			set { _l14count = value; }
		}

		decimal? _l15count;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? l15count
		{
			get { return _l15count; }
			set { _l15count = value; }
		}

		decimal? _ot_sun_day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_sun_day
		{
			get { return _ot_sun_day; }
			set { _ot_sun_day = value; }
		}

		decimal? _ot_nd_day;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_nd_day
		{
			get { return _ot_nd_day; }
			set { _ot_nd_day = value; }
		}

		decimal? _bait_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? bait_hrs
		{
			get { return _bait_hrs; }
			set { _bait_hrs = value; }
		}

		int? _lesshrs_count;
		/// <summary>例
		/// 
		/// </summary>
		public int? lesshrs_count
		{
			get { return _lesshrs_count; }
			set { _lesshrs_count = value; }
		}

		decimal? _over_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? over_hrs
		{
			get { return _over_hrs; }
			set { _over_hrs = value; }
		}

		decimal? _late1_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late1_min
		{
			get { return _late1_min; }
			set { _late1_min = value; }
		}

		decimal? _late2_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late2_min
		{
			get { return _late2_min; }
			set { _late2_min = value; }
		}

		decimal? _late3_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late3_min
		{
			get { return _late3_min; }
			set { _late3_min = value; }
		}

		decimal? _late4_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late4_min
		{
			get { return _late4_min; }
			set { _late4_min = value; }
		}

		decimal? _late5_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? late5_min
		{
			get { return _late5_min; }
			set { _late5_min = value; }
		}

		decimal? _leave1_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave1_min
		{
			get { return _leave1_min; }
			set { _leave1_min = value; }
		}

		decimal? _leave2_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave2_min
		{
			get { return _leave2_min; }
			set { _leave2_min = value; }
		}

		decimal? _leave3_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave3_min
		{
			get { return _leave3_min; }
			set { _leave3_min = value; }
		}

		decimal? _leave4_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave4_min
		{
			get { return _leave4_min; }
			set { _leave4_min = value; }
		}

		decimal? _leave5_min;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? leave5_min
		{
			get { return _leave5_min; }
			set { _leave5_min = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("sign_date=" + sign_date + "; ");
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("cur_kind=" + cur_kind + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("calc_date=" + calc_date + "; ");
			sb.Append("adjusted=" + adjusted + "; ");
			sb.Append("shift_id=" + shift_id + "; ");
			sb.Append("status=" + status + "; ");
			sb.Append("sign_count=" + sign_count + "; ");
			sb.Append("need_sign_count=" + need_sign_count + "; ");
			sb.Append("in1=" + in1 + "; ");
			sb.Append("out1=" + out1 + "; ");
			sb.Append("in2=" + in2 + "; ");
			sb.Append("out2=" + out2 + "; ");
			sb.Append("in3=" + in3 + "; ");
			sb.Append("out3=" + out3 + "; ");
			sb.Append("in4=" + in4 + "; ");
			sb.Append("out4=" + out4 + "; ");
			sb.Append("in5=" + in5 + "; ");
			sb.Append("out5=" + out5 + "; ");
			sb.Append("plan_days=" + plan_days + "; ");
			sb.Append("sun_days=" + sun_days + "; ");
			sb.Append("hd_days=" + hd_days + "; ");
			sb.Append("duty_days=" + duty_days + "; ");
			sb.Append("work_days=" + work_days + "; ");
			sb.Append("absent_days=" + absent_days + "; ");
			sb.Append("leave_days=" + leave_days + "; ");
			sb.Append("fact_hrs=" + fact_hrs + "; ");
			sb.Append("basic_hrs=" + basic_hrs + "; ");
			sb.Append("mid_hrs=" + mid_hrs + "; ");
			sb.Append("ns_hrs=" + ns_hrs + "; ");
			sb.Append("ot_hrs=" + ot_hrs + "; ");
			sb.Append("sun_hrs=" + sun_hrs + "; ");
			sb.Append("hd_hrs=" + hd_hrs + "; ");
			sb.Append("absent_hrs=" + absent_hrs + "; ");
			sb.Append("input_ot_hrs=" + input_ot_hrs + "; ");
			sb.Append("late_mins=" + late_mins + "; ");
			sb.Append("late_count=" + late_count + "; ");
			sb.Append("leave_mins=" + leave_mins + "; ");
			sb.Append("leave_count=" + leave_count + "; ");
			sb.Append("ot_late_mins=" + ot_late_mins + "; ");
			sb.Append("ot_leave_mins=" + ot_leave_mins + "; ");
			sb.Append("ot_late_count=" + ot_late_count + "; ");
			sb.Append("ot_leave_count=" + ot_leave_count + "; ");
			sb.Append("ns_count=" + ns_count + "; ");
			sb.Append("mid_count=" + mid_count + "; ");
			sb.Append("ot_count=" + ot_count + "; ");
			sb.Append("absent_count=" + absent_count + "; ");
			sb.Append("l0hrs=" + l0hrs + "; ");
			sb.Append("l1hrs=" + l1hrs + "; ");
			sb.Append("l2hrs=" + l2hrs + "; ");
			sb.Append("l3hrs=" + l3hrs + "; ");
			sb.Append("l4hrs=" + l4hrs + "; ");
			sb.Append("l5hrs=" + l5hrs + "; ");
			sb.Append("l6hrs=" + l6hrs + "; ");
			sb.Append("l7hrs=" + l7hrs + "; ");
			sb.Append("l8hrs=" + l8hrs + "; ");
			sb.Append("L9hrs=" + L9hrs + "; ");
			sb.Append("l10hrs=" + l10hrs + "; ");
			sb.Append("l11hrs=" + l11hrs + "; ");
			sb.Append("l12hrs=" + l12hrs + "; ");
			sb.Append("l13hrs=" + l13hrs + "; ");
			sb.Append("l14hrs=" + l14hrs + "; ");
			sb.Append("l15hrs=" + l15hrs + "; ");
			sb.Append("outwork_hrs=" + outwork_hrs + "; ");
			sb.Append("shutdown_hrs=" + shutdown_hrs + "; ");
			sb.Append("outwork_days=" + outwork_days + "; ");
			sb.Append("shutdown_days=" + shutdown_days + "; ");
			sb.Append("notes=" + notes + "; ");
			sb.Append("shift_hrs=" + shift_hrs + "; ");
			sb.Append("onwatch_hrs=" + onwatch_hrs + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("l0day=" + l0day + "; ");
			sb.Append("l1day=" + l1day + "; ");
			sb.Append("l2day=" + l2day + "; ");
			sb.Append("l3day=" + l3day + "; ");
			sb.Append("l4day=" + l4day + "; ");
			sb.Append("l5day=" + l5day + "; ");
			sb.Append("l6day=" + l6day + "; ");
			sb.Append("l7day=" + l7day + "; ");
			sb.Append("l8day=" + l8day + "; ");
			sb.Append("L9day=" + L9day + "; ");
			sb.Append("l10day=" + l10day + "; ");
			sb.Append("l11day=" + l11day + "; ");
			sb.Append("l12day=" + l12day + "; ");
			sb.Append("l13day=" + l13day + "; ");
			sb.Append("l14day=" + l14day + "; ");
			sb.Append("l15day=" + l15day + "; ");
			sb.Append("outwork_count=" + outwork_count + "; ");
			sb.Append("shutdown_count=" + shutdown_count + "; ");
			sb.Append("l0count=" + l0count + "; ");
			sb.Append("l1count=" + l1count + "; ");
			sb.Append("l2count=" + l2count + "; ");
			sb.Append("l3count=" + l3count + "; ");
			sb.Append("l4count=" + l4count + "; ");
			sb.Append("l5count=" + l5count + "; ");
			sb.Append("l6count=" + l6count + "; ");
			sb.Append("l7count=" + l7count + "; ");
			sb.Append("l8count=" + l8count + "; ");
			sb.Append("L9count=" + L9count + "; ");
			sb.Append("l10count=" + l10count + "; ");
			sb.Append("l11count=" + l11count + "; ");
			sb.Append("l12count=" + l12count + "; ");
			sb.Append("l13count=" + l13count + "; ");
			sb.Append("l14count=" + l14count + "; ");
			sb.Append("l15count=" + l15count + "; ");
			sb.Append("ot_sun_day=" + ot_sun_day + "; ");
			sb.Append("ot_nd_day=" + ot_nd_day + "; ");
			sb.Append("bait_hrs=" + bait_hrs + "; ");
			sb.Append("lesshrs_count=" + lesshrs_count + "; ");
			sb.Append("over_hrs=" + over_hrs + "; ");
			sb.Append("late1_min=" + late1_min + "; ");
			sb.Append("late2_min=" + late2_min + "; ");
			sb.Append("late3_min=" + late3_min + "; ");
			sb.Append("late4_min=" + late4_min + "; ");
			sb.Append("late5_min=" + late5_min + "; ");
			sb.Append("leave1_min=" + leave1_min + "; ");
			sb.Append("leave2_min=" + leave2_min + "; ");
			sb.Append("leave3_min=" + leave3_min + "; ");
			sb.Append("leave4_min=" + leave4_min + "; ");
			sb.Append("leave5_min=" + leave5_min + "; ");
			return sb.ToString();
        }

    } 

}


