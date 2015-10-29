 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// T_TABLESET表實例類
    /// </summary>
	[Serializable]
    public partial class T_TABLESET
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

		string _CODE = "";
		/// <summary>
		/// 
		/// </summary>
		public string CODE
		{
			get { return _CODE; }
			set { _CODE = value; }
		}

		string _NAMEE = "";
		/// <summary>
		/// 
		/// </summary>
		public string NAMEE
		{
			get { return _NAMEE; }
			set { _NAMEE = value; }
		}

		string _NAMEC = "";
		/// <summary>
		/// 
		/// </summary>
		public string NAMEC
		{
			get { return _NAMEC; }
			set { _NAMEC = value; }
		}

		string _DATAEA = "";
		/// <summary>
		/// 
		/// </summary>
		public string DATAEA
		{
			get { return _DATAEA; }
			set { _DATAEA = value; }
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

		string _SYSDIV = "";
		/// <summary>
		/// 
		/// </summary>
		public string SYSDIV
		{
			get { return _SYSDIV; }
			set { _SYSDIV = value; }
		}

		string _STATURS = "";
		/// <summary>
		/// 
		/// </summary>
		public string STATURS
		{
			get { return _STATURS; }
			set { _STATURS = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("CODE=" + CODE + "; ");
			sb.Append("NAMEE=" + NAMEE + "; ");
			sb.Append("NAMEC=" + NAMEC + "; ");
			sb.Append("DATAEA=" + DATAEA + "; ");
			sb.Append("NOTES=" + NOTES + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			sb.Append("SYSDIV=" + SYSDIV + "; ");
			sb.Append("STATURS=" + STATURS + "; ");
			return sb.ToString();
        }

    } 

}


