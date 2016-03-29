 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// ActiveFileClass表實例類
    /// </summary>
	[Serializable]
    public partial class ActiveFileClass
    {

		int _Id;
		/// <summary>例
		/// Id
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Name = "";
		/// <summary>
		/// 名稱
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		int _ParentId;
		/// <summary>例
		/// 父ID
		/// </summary>
		public int ParentId
		{
			get { return _ParentId; }
			set { _ParentId = value; }
		}

		int _Depth;
		/// <summary>例
		/// 層數
		/// </summary>
		public int Depth
		{
			get { return _Depth; }
			set { _Depth = value; }
		}

		int _Sort;
		/// <summary>例
		/// 排序
		/// </summary>
		public int Sort
		{
			get { return _Sort; }
			set { _Sort = value; }
		}

		string _Keyword = "";
		/// <summary>
		/// 關鍵字
		/// </summary>
		public string Keyword
		{
			get { return _Keyword; }
			set { _Keyword = value; }
		}

		byte _IsDisplay;
		/// <summary>例
		/// 是否顯示
		/// </summary>
		public byte IsDisplay
		{
			get { return _IsDisplay; }
			set { _IsDisplay = value; }
		}

		string _Employee_EmpId = "";
		/// <summary>
		/// 申請人編號號
		/// </summary>
		public string Employee_EmpId
		{
			get { return _Employee_EmpId; }
			set { _Employee_EmpId = value; }
		}

		string _Employee_CName = "";
		/// <summary>
		/// 申請人
		/// </summary>
		public string Employee_CName
		{
			get { return _Employee_CName; }
			set { _Employee_CName = value; }
		}

		DateTime _AddDate = new DateTime(1900,1,1);
		/// <summary>
		/// 添加時間
		/// </summary>
		public DateTime AddDate
		{
			get { return _AddDate; }
			set { _AddDate = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("Name=" + Name + "; ");
			sb.Append("ParentId=" + ParentId + "; ");
			sb.Append("Depth=" + Depth + "; ");
			sb.Append("Sort=" + Sort + "; ");
			sb.Append("Keyword=" + Keyword + "; ");
			sb.Append("IsDisplay=" + IsDisplay + "; ");
			sb.Append("Employee_EmpId=" + Employee_EmpId + "; ");
			sb.Append("Employee_CName=" + Employee_CName + "; ");
			sb.Append("AddDate=" + AddDate + "; ");
			return sb.ToString();
        }

    } 

}


