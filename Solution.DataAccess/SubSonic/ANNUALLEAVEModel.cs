 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// ANNUALLEAVE表實例類
    /// </summary>
	[Serializable]
    public partial class ANNUALLEAVE
    {

		string _EMP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_ID
		{
			get { return _EMP_ID; }
			set { _EMP_ID = value; }
		}

		int _YEARS;
		/// <summary>例
		/// 
		/// </summary>
		public int YEARS
		{
			get { return _YEARS; }
			set { _YEARS = value; }
		}

		decimal? _DATA;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DATA
		{
			get { return _DATA; }
			set { _DATA = value; }
		}

		string _MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string MEMO
		{
			get { return _MEMO; }
			set { _MEMO = value; }
		}

		DateTime? _S_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? S_DATE
		{
			get { return _S_DATE; }
			set { _S_DATE = value; }
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

		bool _IsValid = false;
		/// <summary>
		/// 
		/// </summary>
		public bool IsValid
		{
			get { return _IsValid; }
			set { _IsValid = value; }
		}

		long _Id;
		/// <summary>例
		/// 
		/// </summary>
		public long Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("EMP_ID=" + EMP_ID + "; ");
			sb.Append("YEARS=" + YEARS + "; ");
			sb.Append("DATA=" + DATA + "; ");
			sb.Append("MEMO=" + MEMO + "; ");
			sb.Append("S_DATE=" + S_DATE + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			sb.Append("IsValid=" + IsValid + "; ");
			sb.Append("Id=" + Id + "; ");
			return sb.ToString();
        }

    } 

}


