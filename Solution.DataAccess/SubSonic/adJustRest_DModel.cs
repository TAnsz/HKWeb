 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// adJustRest_D表實例類
    /// </summary>
	[Serializable]
    public partial class adJustRest_D
    {

		int _Id;
		/// <summary>例
		/// 
		/// </summary>
		public int Id
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

		DateTime? _ori_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ori_date
		{
			get { return _ori_date; }
			set { _ori_date = value; }
		}

		DateTime? _ori_btime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ori_btime
		{
			get { return _ori_btime; }
			set { _ori_btime = value; }
		}

		DateTime? _ori_etime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ori_etime
		{
			get { return _ori_etime; }
			set { _ori_etime = value; }
		}

		DateTime _rest_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime rest_date
		{
			get { return _rest_date; }
			set { _rest_date = value; }
		}

		DateTime? _rest_btime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? rest_btime
		{
			get { return _rest_btime; }
			set { _rest_btime = value; }
		}

		DateTime? _rest_etime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? rest_etime
		{
			get { return _rest_etime; }
			set { _rest_etime = value; }
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

		short? _all_day;
		/// <summary>例
		/// 
		/// </summary>
		public short? all_day
		{
			get { return _all_day; }
			set { _all_day = value; }
		}

		string _kind = "";
		/// <summary>
		/// 
		/// </summary>
		public string kind
		{
			get { return _kind; }
			set { _kind = value; }
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
			sb.Append("ori_date=" + ori_date + "; ");
			sb.Append("ori_btime=" + ori_btime + "; ");
			sb.Append("ori_etime=" + ori_etime + "; ");
			sb.Append("rest_date=" + rest_date + "; ");
			sb.Append("rest_btime=" + rest_btime + "; ");
			sb.Append("rest_etime=" + rest_etime + "; ");
			sb.Append("checker=" + checker + "; ");
			sb.Append("check_date=" + check_date + "; ");
			sb.Append("op_user=" + op_user + "; ");
			sb.Append("op_date=" + op_date + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("memo=" + memo + "; ");
			sb.Append("all_day=" + all_day + "; ");
			sb.Append("kind=" + kind + "; ");
			sb.Append("refuse_reason=" + refuse_reason + "; ");
			sb.Append("CHECKER2=" + CHECKER2 + "; ");
			sb.Append("audit2=" + audit2 + "; ");
			sb.Append("check_date2=" + check_date2 + "; ");
			return sb.ToString();
        }

    } 

}


