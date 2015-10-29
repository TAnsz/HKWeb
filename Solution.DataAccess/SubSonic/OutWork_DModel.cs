 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// OutWork_D表實例類
    /// </summary>
	[Serializable]
    public partial class OutWork_D
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

		string _bill_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string bill_id
		{
			get { return _bill_id; }
			set { _bill_id = value; }
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

		int _join_id;
		/// <summary>例
		/// 
		/// </summary>
		public int join_id
		{
			get { return _join_id; }
			set { _join_id = value; }
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

		DateTime _bill_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime bill_date
		{
			get { return _bill_date; }
			set { _bill_date = value; }
		}

		DateTime? _begin_time = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? begin_time
		{
			get { return _begin_time; }
			set { _begin_time = value; }
		}

		DateTime? _end_time = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? end_time
		{
			get { return _end_time; }
			set { _end_time = value; }
		}

		string _work_type = "";
		/// <summary>
		/// 
		/// </summary>
		public string work_type
		{
			get { return _work_type; }
			set { _work_type = value; }
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

		int? _status_id;
		/// <summary>例
		/// 
		/// </summary>
		public int? status_id
		{
			get { return _status_id; }
			set { _status_id = value; }
		}

		string _leave_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string leave_id
		{
			get { return _leave_id; }
			set { _leave_id = value; }
		}

		decimal? _rate;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? rate
		{
			get { return _rate; }
			set { _rate = value; }
		}

		string _checker = "";
		/// <summary>
		/// 
		/// </summary>
		public string checker
		{
			get { return _checker; }
			set { _checker = value; }
		}

		DateTime? _check_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? check_date
		{
			get { return _check_date; }
			set { _check_date = value; }
		}

		string _op_user = "";
		/// <summary>
		/// 
		/// </summary>
		public string op_user
		{
			get { return _op_user; }
			set { _op_user = value; }
		}

		DateTime? _op_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? op_date
		{
			get { return _op_date; }
			set { _op_date = value; }
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

		string _memo = "";
		/// <summary>
		/// 
		/// </summary>
		public string memo
		{
			get { return _memo; }
			set { _memo = value; }
		}

		string _outwork_type = "";
		/// <summary>
		/// 
		/// </summary>
		public string outwork_type
		{
			get { return _outwork_type; }
			set { _outwork_type = value; }
		}

		string _outwork_addr = "";
		/// <summary>
		/// 
		/// </summary>
		public string outwork_addr
		{
			get { return _outwork_addr; }
			set { _outwork_addr = value; }
		}

		string _transportation = "";
		/// <summary>
		/// 
		/// </summary>
		public string transportation
		{
			get { return _transportation; }
			set { _transportation = value; }
		}

		DateTime? _Re_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Re_date
		{
			get { return _Re_date; }
			set { _Re_date = value; }
		}

		string _Start_ag = "";
		/// <summary>
		/// 
		/// </summary>
		public string Start_ag
		{
			get { return _Start_ag; }
			set { _Start_ag = value; }
		}

		string _re_ag = "";
		/// <summary>
		/// 
		/// </summary>
		public string re_ag
		{
			get { return _re_ag; }
			set { _re_ag = value; }
		}

		int? _peers;
		/// <summary>例
		/// 
		/// </summary>
		public int? peers
		{
			get { return _peers; }
			set { _peers = value; }
		}

		int? _Hostel;
		/// <summary>例
		/// 
		/// </summary>
		public int? Hostel
		{
			get { return _Hostel; }
			set { _Hostel = value; }
		}

		int? _hotel;
		/// <summary>例
		/// 
		/// </summary>
		public int? hotel
		{
			get { return _hotel; }
			set { _hotel = value; }
		}

		string _hotel_type = "";
		/// <summary>
		/// 
		/// </summary>
		public string hotel_type
		{
			get { return _hotel_type; }
			set { _hotel_type = value; }
		}

		string _reply = "";
		/// <summary>
		/// 
		/// </summary>
		public string reply
		{
			get { return _reply; }
			set { _reply = value; }
		}

		decimal? _work_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? work_hrs
		{
			get { return _work_hrs; }
			set { _work_hrs = value; }
		}

		short? _is_input;
		/// <summary>例
		/// 
		/// </summary>
		public short? is_input
		{
			get { return _is_input; }
			set { _is_input = value; }
		}

		string _refuse_reason = "";
		/// <summary>
		/// 
		/// </summary>
		public string refuse_reason
		{
			get { return _refuse_reason; }
			set { _refuse_reason = value; }
		}

		string _CHECKER2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string CHECKER2
		{
			get { return _CHECKER2; }
			set { _CHECKER2 = value; }
		}

		short? _audit2;
		/// <summary>例
		/// 
		/// </summary>
		public short? audit2
		{
			get { return _audit2; }
			set { _audit2 = value; }
		}

		short? _IsHotel;
		/// <summary>例
		/// 
		/// </summary>
		public short? IsHotel
		{
			get { return _IsHotel; }
			set { _IsHotel = value; }
		}

		short? _IsCar;
		/// <summary>例
		/// 
		/// </summary>
		public short? IsCar
		{
			get { return _IsCar; }
			set { _IsCar = value; }
		}

		string _Itinerary = "";
		/// <summary>
		/// 
		/// </summary>
		public string Itinerary
		{
			get { return _Itinerary; }
			set { _Itinerary = value; }
		}

		string _Destination = "";
		/// <summary>
		/// 
		/// </summary>
		public string Destination
		{
			get { return _Destination; }
			set { _Destination = value; }
		}

		string _IDate = "";
		/// <summary>
		/// 
		/// </summary>
		public string IDate
		{
			get { return _IDate; }
			set { _IDate = value; }
		}

		string _Nights = "";
		/// <summary>
		/// 
		/// </summary>
		public string Nights
		{
			get { return _Nights; }
			set { _Nights = value; }
		}

		string _reply2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string reply2
		{
			get { return _reply2; }
			set { _reply2 = value; }
		}

		string _itinerary2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string itinerary2
		{
			get { return _itinerary2; }
			set { _itinerary2 = value; }
		}

		string _itinerary3 = "";
		/// <summary>
		/// 
		/// </summary>
		public string itinerary3
		{
			get { return _itinerary3; }
			set { _itinerary3 = value; }
		}

		string _itinerary4 = "";
		/// <summary>
		/// 
		/// </summary>
		public string itinerary4
		{
			get { return _itinerary4; }
			set { _itinerary4 = value; }
		}

		string _IDate2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string IDate2
		{
			get { return _IDate2; }
			set { _IDate2 = value; }
		}

		string _IDate3 = "";
		/// <summary>
		/// 
		/// </summary>
		public string IDate3
		{
			get { return _IDate3; }
			set { _IDate3 = value; }
		}

		string _IDate4 = "";
		/// <summary>
		/// 
		/// </summary>
		public string IDate4
		{
			get { return _IDate4; }
			set { _IDate4 = value; }
		}

		string _Destination2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Destination2
		{
			get { return _Destination2; }
			set { _Destination2 = value; }
		}

		string _Destination3 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Destination3
		{
			get { return _Destination3; }
			set { _Destination3 = value; }
		}

		string _Destination4 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Destination4
		{
			get { return _Destination4; }
			set { _Destination4 = value; }
		}

		string _Nights2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Nights2
		{
			get { return _Nights2; }
			set { _Nights2 = value; }
		}

		string _Nights3 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Nights3
		{
			get { return _Nights3; }
			set { _Nights3 = value; }
		}

		string _Nights4 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Nights4
		{
			get { return _Nights4; }
			set { _Nights4 = value; }
		}

		DateTime? _check_date2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? check_date2
		{
			get { return _check_date2; }
			set { _check_date2 = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("bill_id=" + bill_id + "; ");
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("bill_date=" + bill_date + "; ");
			sb.Append("begin_time=" + begin_time + "; ");
			sb.Append("end_time=" + end_time + "; ");
			sb.Append("work_type=" + work_type + "; ");
			sb.Append("work_days=" + work_days + "; ");
			sb.Append("status_id=" + status_id + "; ");
			sb.Append("leave_id=" + leave_id + "; ");
			sb.Append("rate=" + rate + "; ");
			sb.Append("checker=" + checker + "; ");
			sb.Append("check_date=" + check_date + "; ");
			sb.Append("op_user=" + op_user + "; ");
			sb.Append("op_date=" + op_date + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("memo=" + memo + "; ");
			sb.Append("outwork_type=" + outwork_type + "; ");
			sb.Append("outwork_addr=" + outwork_addr + "; ");
			sb.Append("transportation=" + transportation + "; ");
			sb.Append("Re_date=" + Re_date + "; ");
			sb.Append("Start_ag=" + Start_ag + "; ");
			sb.Append("re_ag=" + re_ag + "; ");
			sb.Append("peers=" + peers + "; ");
			sb.Append("Hostel=" + Hostel + "; ");
			sb.Append("hotel=" + hotel + "; ");
			sb.Append("hotel_type=" + hotel_type + "; ");
			sb.Append("reply=" + reply + "; ");
			sb.Append("work_hrs=" + work_hrs + "; ");
			sb.Append("is_input=" + is_input + "; ");
			sb.Append("refuse_reason=" + refuse_reason + "; ");
			sb.Append("CHECKER2=" + CHECKER2 + "; ");
			sb.Append("audit2=" + audit2 + "; ");
			sb.Append("IsHotel=" + IsHotel + "; ");
			sb.Append("IsCar=" + IsCar + "; ");
			sb.Append("Itinerary=" + Itinerary + "; ");
			sb.Append("Destination=" + Destination + "; ");
			sb.Append("IDate=" + IDate + "; ");
			sb.Append("Nights=" + Nights + "; ");
			sb.Append("reply2=" + reply2 + "; ");
			sb.Append("itinerary2=" + itinerary2 + "; ");
			sb.Append("itinerary3=" + itinerary3 + "; ");
			sb.Append("itinerary4=" + itinerary4 + "; ");
			sb.Append("IDate2=" + IDate2 + "; ");
			sb.Append("IDate3=" + IDate3 + "; ");
			sb.Append("IDate4=" + IDate4 + "; ");
			sb.Append("Destination2=" + Destination2 + "; ");
			sb.Append("Destination3=" + Destination3 + "; ");
			sb.Append("Destination4=" + Destination4 + "; ");
			sb.Append("Nights2=" + Nights2 + "; ");
			sb.Append("Nights3=" + Nights3 + "; ");
			sb.Append("Nights4=" + Nights4 + "; ");
			sb.Append("check_date2=" + check_date2 + "; ");
			return sb.ToString();
        }

    } 

}


