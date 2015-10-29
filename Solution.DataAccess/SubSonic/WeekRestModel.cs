 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// WeekRest表實例類
    /// </summary>
	[Serializable]
    public partial class WeekRest
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

		string _wr_code = "";
		/// <summary>
		/// 
		/// </summary>
		public string wr_code
		{
			get { return _wr_code; }
			set { _wr_code = value; }
		}

		string _wr_name = "";
		/// <summary>
		/// 
		/// </summary>
		public string wr_name
		{
			get { return _wr_name; }
			set { _wr_name = value; }
		}

		DateTime _wr_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime wr_date
		{
			get { return _wr_date; }
			set { _wr_date = value; }
		}

		DateTime? _wr_end = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? wr_end
		{
			get { return _wr_end; }
			set { _wr_end = value; }
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

		decimal? _wr_rate;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? wr_rate
		{
			get { return _wr_rate; }
			set { _wr_rate = value; }
		}

		int? _wr_kind;
		/// <summary>例
		/// 
		/// </summary>
		public int? wr_kind
		{
			get { return _wr_kind; }
			set { _wr_kind = value; }
		}

		short? _alway_use;
		/// <summary>例
		/// 
		/// </summary>
		public short? alway_use
		{
			get { return _alway_use; }
			set { _alway_use = value; }
		}

		short? _have_hrs;
		/// <summary>例
		/// 
		/// </summary>
		public short? have_hrs
		{
			get { return _have_hrs; }
			set { _have_hrs = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("wr_code=" + wr_code + "; ");
			sb.Append("wr_name=" + wr_name + "; ");
			sb.Append("wr_date=" + wr_date + "; ");
			sb.Append("wr_end=" + wr_end + "; ");
			sb.Append("begin_time=" + begin_time + "; ");
			sb.Append("end_time=" + end_time + "; ");
			sb.Append("wr_rate=" + wr_rate + "; ");
			sb.Append("wr_kind=" + wr_kind + "; ");
			sb.Append("alway_use=" + alway_use + "; ");
			sb.Append("have_hrs=" + have_hrs + "; ");
			return sb.ToString();
        }

    } 

}


