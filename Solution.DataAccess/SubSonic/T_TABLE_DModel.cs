 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// T_TABLE_D表實例類
    /// </summary>
	[Serializable]
    public partial class T_TABLE_D
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

		string _TABLES = "";
		/// <summary>
		/// 
		/// </summary>
		public string TABLES
		{
			get { return _TABLES; }
			set { _TABLES = value; }
		}

		string _CODE = "";
		/// <summary>
		/// 
		/// </summary>
		public string CODE
		{
			get { return _CODE; }
			set { _CODE = value; }
		}

		string _DESCR = "";
		/// <summary>
		/// 
		/// </summary>
		public string DESCR
		{
			get { return _DESCR; }
			set { _DESCR = value; }
		}

		string _DATA = "";
		/// <summary>
		/// 
		/// </summary>
		public string DATA
		{
			get { return _DATA; }
			set { _DATA = value; }
		}

		string _TYPE = "";
		/// <summary>
		/// 
		/// </summary>
		public string TYPE
		{
			get { return _TYPE; }
			set { _TYPE = value; }
		}

		string _GROUPS = "";
		/// <summary>
		/// 
		/// </summary>
		public string GROUPS
		{
			get { return _GROUPS; }
			set { _GROUPS = value; }
		}

		int? _DATAC;
		/// <summary>例
		/// 
		/// </summary>
		public int? DATAC
		{
			get { return _DATAC; }
			set { _DATAC = value; }
		}

		string _NOTES = "";
		/// <summary>
		/// 
		/// </summary>
		public string NOTES
		{
			get { return _NOTES; }
			set { _NOTES = value; }
		}

		string _RECORD_BY = "";
		/// <summary>
		/// 
		/// </summary>
		public string RECORD_BY
		{
			get { return _RECORD_BY; }
			set { _RECORD_BY = value; }
		}

		DateTime? _RECORD_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RECORD_DATE
		{
			get { return _RECORD_DATE; }
			set { _RECORD_DATE = value; }
		}

		string _SYSDIV = "";
		/// <summary>
		/// 
		/// </summary>
		public string SYSDIV
		{
			get { return _SYSDIV; }
			set { _SYSDIV = value; }
		}

		decimal? _DATAD1;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DATAD1
		{
			get { return _DATAD1; }
			set { _DATAD1 = value; }
		}

		decimal? _DATAD2;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DATAD2
		{
			get { return _DATAD2; }
			set { _DATAD2 = value; }
		}

		decimal? _DATAD3;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DATAD3
		{
			get { return _DATAD3; }
			set { _DATAD3 = value; }
		}

		decimal? _DATAD4;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DATAD4
		{
			get { return _DATAD4; }
			set { _DATAD4 = value; }
		}

		string _DATAD5 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DATAD5
		{
			get { return _DATAD5; }
			set { _DATAD5 = value; }
		}

		string _DATAD6 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DATAD6
		{
			get { return _DATAD6; }
			set { _DATAD6 = value; }
		}

		string _DATAD7 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DATAD7
		{
			get { return _DATAD7; }
			set { _DATAD7 = value; }
		}

		string _DATAD8 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DATAD8
		{
			get { return _DATAD8; }
			set { _DATAD8 = value; }
		}

		string _EDIT_BY = "";
		/// <summary>
		/// 
		/// </summary>
		public string EDIT_BY
		{
			get { return _EDIT_BY; }
			set { _EDIT_BY = value; }
		}

		DateTime? _EDIT_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EDIT_DATE
		{
			get { return _EDIT_DATE; }
			set { _EDIT_DATE = value; }
		}

		string _PagePower = "";
		/// <summary>
		/// 
		/// </summary>
		public string PagePower
		{
			get { return _PagePower; }
			set { _PagePower = value; }
		}

		string _ControlPower = "";
		/// <summary>
		/// 
		/// </summary>
		public string ControlPower
		{
			get { return _ControlPower; }
			set { _ControlPower = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("TABLES=" + TABLES + "; ");
			sb.Append("CODE=" + CODE + "; ");
			sb.Append("DESCR=" + DESCR + "; ");
			sb.Append("DATA=" + DATA + "; ");
			sb.Append("TYPE=" + TYPE + "; ");
			sb.Append("GROUPS=" + GROUPS + "; ");
			sb.Append("DATAC=" + DATAC + "; ");
			sb.Append("NOTES=" + NOTES + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("SYSDIV=" + SYSDIV + "; ");
			sb.Append("DATAD1=" + DATAD1 + "; ");
			sb.Append("DATAD2=" + DATAD2 + "; ");
			sb.Append("DATAD3=" + DATAD3 + "; ");
			sb.Append("DATAD4=" + DATAD4 + "; ");
			sb.Append("DATAD5=" + DATAD5 + "; ");
			sb.Append("DATAD6=" + DATAD6 + "; ");
			sb.Append("DATAD7=" + DATAD7 + "; ");
			sb.Append("DATAD8=" + DATAD8 + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			sb.Append("PagePower=" + PagePower + "; ");
			sb.Append("ControlPower=" + ControlPower + "; ");
			return sb.ToString();
        }

    } 

}


