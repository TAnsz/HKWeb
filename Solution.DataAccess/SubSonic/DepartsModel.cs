 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Departs表實例類
    /// </summary>
	[Serializable]
    public partial class Departs
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

		string _depart_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string depart_id
		{
			get { return _depart_id; }
			set { _depart_id = value; }
		}

		int? _inside_id;
		/// <summary>例
		/// 
		/// </summary>
		public int? inside_id
		{
			get { return _inside_id; }
			set { _inside_id = value; }
		}

		string _depart_name = "";
		/// <summary>
		/// 
		/// </summary>
		public string depart_name
		{
			get { return _depart_name; }
			set { _depart_name = value; }
		}

		string _manager1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string manager1
		{
			get { return _manager1; }
			set { _manager1 = value; }
		}

		string _job_id1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string job_id1
		{
			get { return _job_id1; }
			set { _job_id1 = value; }
		}

		string _manager2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string manager2
		{
			get { return _manager2; }
			set { _manager2 = value; }
		}

		string _job_id2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string job_id2
		{
			get { return _job_id2; }
			set { _job_id2 = value; }
		}

		string _emp_prefix = "";
		/// <summary>
		/// 
		/// </summary>
		public string emp_prefix
		{
			get { return _emp_prefix; }
			set { _emp_prefix = value; }
		}

		int? _plan_num;
		/// <summary>例
		/// 
		/// </summary>
		public int? plan_num
		{
			get { return _plan_num; }
			set { _plan_num = value; }
		}

		string _linktel = "";
		/// <summary>
		/// 
		/// </summary>
		public string linktel
		{
			get { return _linktel; }
			set { _linktel = value; }
		}

		string _remark = "";
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			get { return _remark; }
			set { _remark = value; }
		}

		decimal? _butei_money;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? butei_money
		{
			get { return _butei_money; }
			set { _butei_money = value; }
		}

		int? _audit_access;
		/// <summary>例
		/// 
		/// </summary>
		public int? audit_access
		{
			get { return _audit_access; }
			set { _audit_access = value; }
		}

		int? _TreeLevel;
		/// <summary>例
		/// 
		/// </summary>
		public int? TreeLevel
		{
			get { return _TreeLevel; }
			set { _TreeLevel = value; }
		}

		string _Up_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string Up_ID
		{
			get { return _Up_ID; }
			set { _Up_ID = value; }
		}

		string _LongName = "";
		/// <summary>
		/// 
		/// </summary>
		public string LongName
		{
			get { return _LongName; }
			set { _LongName = value; }
		}

		int? _access_level;
		/// <summary>例
		/// 
		/// </summary>
		public int? access_level
		{
			get { return _access_level; }
			set { _access_level = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("inside_id=" + inside_id + "; ");
			sb.Append("depart_name=" + depart_name + "; ");
			sb.Append("manager1=" + manager1 + "; ");
			sb.Append("job_id1=" + job_id1 + "; ");
			sb.Append("manager2=" + manager2 + "; ");
			sb.Append("job_id2=" + job_id2 + "; ");
			sb.Append("emp_prefix=" + emp_prefix + "; ");
			sb.Append("plan_num=" + plan_num + "; ");
			sb.Append("linktel=" + linktel + "; ");
			sb.Append("remark=" + remark + "; ");
			sb.Append("butei_money=" + butei_money + "; ");
			sb.Append("audit_access=" + audit_access + "; ");
			sb.Append("TreeLevel=" + TreeLevel + "; ");
			sb.Append("Up_ID=" + Up_ID + "; ");
			sb.Append("LongName=" + LongName + "; ");
			sb.Append("access_level=" + access_level + "; ");
			return sb.ToString();
        }

    } 

}


