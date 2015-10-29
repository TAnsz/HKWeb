 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Rules表實例類
    /// </summary>
	[Serializable]
    public partial class Rules
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

		string _rule_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string rule_id
		{
			get { return _rule_id; }
			set { _rule_id = value; }
		}

		string _rule_name = "";
		/// <summary>
		/// 
		/// </summary>
		public string rule_name
		{
			get { return _rule_name; }
			set { _rule_name = value; }
		}

		string _rules = "";
		/// <summary>
		/// 
		/// </summary>
		public string rules
		{
			get { return _rules; }
			set { _rules = value; }
		}

		decimal _daysinmonth;
		/// <summary>例
		/// 
		/// </summary>
		public decimal daysinmonth
		{
			get { return _daysinmonth; }
			set { _daysinmonth = value; }
		}

		decimal _hoursinday;
		/// <summary>例
		/// 
		/// </summary>
		public decimal hoursinday
		{
			get { return _hoursinday; }
			set { _hoursinday = value; }
		}

		decimal? _ot_rate;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? ot_rate
		{
			get { return _ot_rate; }
			set { _ot_rate = value; }
		}

		decimal? _sun_rate;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? sun_rate
		{
			get { return _sun_rate; }
			set { _sun_rate = value; }
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

		short _restdatemethod;
		/// <summary>例
		/// 
		/// </summary>
		public short restdatemethod
		{
			get { return _restdatemethod; }
			set { _restdatemethod = value; }
		}

		short? _sun;
		/// <summary>例
		/// 
		/// </summary>
		public short? sun
		{
			get { return _sun; }
			set { _sun = value; }
		}

		DateTime? _sunbegin = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? sunbegin
		{
			get { return _sunbegin; }
			set { _sunbegin = value; }
		}

		DateTime? _sunend = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? sunend
		{
			get { return _sunend; }
			set { _sunend = value; }
		}

		short? _sat;
		/// <summary>例
		/// 
		/// </summary>
		public short? sat
		{
			get { return _sat; }
			set { _sat = value; }
		}

		DateTime? _satbegin = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? satbegin
		{
			get { return _satbegin; }
			set { _satbegin = value; }
		}

		DateTime? _satend = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? satend
		{
			get { return _satend; }
			set { _satend = value; }
		}

		string _vrestdate = "";
		/// <summary>
		/// 
		/// </summary>
		public string vrestdate
		{
			get { return _vrestdate; }
			set { _vrestdate = value; }
		}

		DateTime? _vrestbegtime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? vrestbegtime
		{
			get { return _vrestbegtime; }
			set { _vrestbegtime = value; }
		}

		DateTime? _vrestendtime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? vrestendtime
		{
			get { return _vrestendtime; }
			set { _vrestendtime = value; }
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
			sb.Append("rule_id=" + rule_id + "; ");
			sb.Append("rule_name=" + rule_name + "; ");
			sb.Append("rules=" + rules + "; ");
			sb.Append("daysinmonth=" + daysinmonth + "; ");
			sb.Append("hoursinday=" + hoursinday + "; ");
			sb.Append("ot_rate=" + ot_rate + "; ");
			sb.Append("sun_rate=" + sun_rate + "; ");
			sb.Append("hd_rate=" + hd_rate + "; ");
			sb.Append("restdatemethod=" + restdatemethod + "; ");
			sb.Append("sun=" + sun + "; ");
			sb.Append("sunbegin=" + sunbegin + "; ");
			sb.Append("sunend=" + sunend + "; ");
			sb.Append("sat=" + sat + "; ");
			sb.Append("satbegin=" + satbegin + "; ");
			sb.Append("satend=" + satend + "; ");
			sb.Append("vrestdate=" + vrestdate + "; ");
			sb.Append("vrestbegtime=" + vrestbegtime + "; ");
			sb.Append("vrestendtime=" + vrestendtime + "; ");
			sb.Append("memo=" + memo + "; ");
			return sb.ToString();
        }

    } 

}


