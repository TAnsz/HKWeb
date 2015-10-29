 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Holidays表實例類
    /// </summary>
	[Serializable]
    public partial class Holidays
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

		string _hd_code = "";
		/// <summary>
		/// 
		/// </summary>
		public string hd_code
		{
			get { return _hd_code; }
			set { _hd_code = value; }
		}

		string _hd_name = "";
		/// <summary>
		/// 
		/// </summary>
		public string hd_name
		{
			get { return _hd_name; }
			set { _hd_name = value; }
		}

		DateTime _hd_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime hd_date
		{
			get { return _hd_date; }
			set { _hd_date = value; }
		}

		DateTime? _hd_end = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? hd_end
		{
			get { return _hd_end; }
			set { _hd_end = value; }
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

		decimal? _hd_rate;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? hd_rate
		{
			get { return _hd_rate; }
			set { _hd_rate = value; }
		}

		string _hd_type = "";
		/// <summary>
		/// 
		/// </summary>
		public string hd_type
		{
			get { return _hd_type; }
			set { _hd_type = value; }
		}

		int? _hd_kind;
		/// <summary>例
		/// 
		/// </summary>
		public int? hd_kind
		{
			get { return _hd_kind; }
			set { _hd_kind = value; }
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

		short _alway_use;
		/// <summary>例
		/// 
		/// </summary>
		public short alway_use
		{
			get { return _alway_use; }
			set { _alway_use = value; }
		}

		short _sub_depart;
		/// <summary>例
		/// 
		/// </summary>
		public short sub_depart
		{
			get { return _sub_depart; }
			set { _sub_depart = value; }
		}

		short? _need_write;
		/// <summary>例
		/// 
		/// </summary>
		public short? need_write
		{
			get { return _need_write; }
			set { _need_write = value; }
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

		string _memo = "";
		/// <summary>
		/// 
		/// </summary>
		public string memo
		{
			get { return _memo; }
			set { _memo = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("hd_code=" + hd_code + "; ");
			sb.Append("hd_name=" + hd_name + "; ");
			sb.Append("hd_date=" + hd_date + "; ");
			sb.Append("hd_end=" + hd_end + "; ");
			sb.Append("begin_time=" + begin_time + "; ");
			sb.Append("end_time=" + end_time + "; ");
			sb.Append("hd_rate=" + hd_rate + "; ");
			sb.Append("hd_type=" + hd_type + "; ");
			sb.Append("hd_kind=" + hd_kind + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("alway_use=" + alway_use + "; ");
			sb.Append("sub_depart=" + sub_depart + "; ");
			sb.Append("need_write=" + need_write + "; ");
			sb.Append("have_hrs=" + have_hrs + "; ");
			sb.Append("memo=" + memo + "; ");
			return sb.ToString();
        }

    } 

}


