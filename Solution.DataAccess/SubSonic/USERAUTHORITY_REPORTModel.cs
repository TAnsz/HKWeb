 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// USERAUTHORITY_REPORT表實例類
    /// </summary>
	[Serializable]
    public partial class USERAUTHORITY_REPORT
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

		string _emp_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string emp_id
		{
			get { return _emp_id; }
			set { _emp_id = value; }
		}

		string _node_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string node_id
		{
			get { return _node_id; }
			set { _node_id = value; }
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

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("node_id=" + node_id + "; ");
			sb.Append("TYPE=" + TYPE + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			return sb.ToString();
        }

    } 

}


