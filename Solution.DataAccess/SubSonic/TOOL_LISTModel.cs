 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// TOOL_LIST表實例類
    /// </summary>
	[Serializable]
    public partial class TOOL_LIST
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

		string _TOOL_NO = "";
		/// <summary>
		/// 
		/// </summary>
		public string TOOL_NO
		{
			get { return _TOOL_NO; }
			set { _TOOL_NO = value; }
		}

		string _TEXT = "";
		/// <summary>
		/// 
		/// </summary>
		public string TEXT
		{
			get { return _TEXT; }
			set { _TEXT = value; }
		}

		string _TOOLTIP = "";
		/// <summary>
		/// 
		/// </summary>
		public string TOOLTIP
		{
			get { return _TOOLTIP; }
			set { _TOOLTIP = value; }
		}

		string _IMAGE = "";
		/// <summary>
		/// 
		/// </summary>
		public string IMAGE
		{
			get { return _IMAGE; }
			set { _IMAGE = value; }
		}

		int? _DIVIDER;
		/// <summary>例
		/// 
		/// </summary>
		public int? DIVIDER
		{
			get { return _DIVIDER; }
			set { _DIVIDER = value; }
		}

		int? _DISABLED;
		/// <summary>例
		/// 
		/// </summary>
		public int? DISABLED
		{
			get { return _DISABLED; }
			set { _DISABLED = value; }
		}

		int? _DROPDOWN;
		/// <summary>例
		/// 
		/// </summary>
		public int? DROPDOWN
		{
			get { return _DROPDOWN; }
			set { _DROPDOWN = value; }
		}

		int? _DROPWHOLE;
		/// <summary>例
		/// 
		/// </summary>
		public int? DROPWHOLE
		{
			get { return _DROPWHOLE; }
			set { _DROPWHOLE = value; }
		}

		string _TAGDATA = "";
		/// <summary>
		/// 
		/// </summary>
		public string TAGDATA
		{
			get { return _TAGDATA; }
			set { _TAGDATA = value; }
		}

		int _SORT_ORDER;
		/// <summary>例
		/// 
		/// </summary>
		public int SORT_ORDER
		{
			get { return _SORT_ORDER; }
			set { _SORT_ORDER = value; }
		}

		string _DWOBJECT = "";
		/// <summary>
		/// 
		/// </summary>
		public string DWOBJECT
		{
			get { return _DWOBJECT; }
			set { _DWOBJECT = value; }
		}

		int? _GROUPNO;
		/// <summary>例
		/// 
		/// </summary>
		public int? GROUPNO
		{
			get { return _GROUPNO; }
			set { _GROUPNO = value; }
		}

		string _GROUPNAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string GROUPNAME
		{
			get { return _GROUPNAME; }
			set { _GROUPNAME = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("TOOL_NO=" + TOOL_NO + "; ");
			sb.Append("TEXT=" + TEXT + "; ");
			sb.Append("TOOLTIP=" + TOOLTIP + "; ");
			sb.Append("IMAGE=" + IMAGE + "; ");
			sb.Append("DIVIDER=" + DIVIDER + "; ");
			sb.Append("DISABLED=" + DISABLED + "; ");
			sb.Append("DROPDOWN=" + DROPDOWN + "; ");
			sb.Append("DROPWHOLE=" + DROPWHOLE + "; ");
			sb.Append("TAGDATA=" + TAGDATA + "; ");
			sb.Append("SORT_ORDER=" + SORT_ORDER + "; ");
			sb.Append("DWOBJECT=" + DWOBJECT + "; ");
			sb.Append("GROUPNO=" + GROUPNO + "; ");
			sb.Append("GROUPNAME=" + GROUPNAME + "; ");
			return sb.ToString();
        }

    } 

}


