 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// ActiveFile表實例類
    /// </summary>
	[Serializable]
    public partial class ActiveFile
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

		string _Notes = "";
		/// <summary>
		/// 簡介
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
		}

		string _Content = "";
		/// <summary>
		/// 內容
		/// </summary>
		public string Content
		{
			get { return _Content; }
			set { _Content = value; }
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

		string _Url = "";
		/// <summary>
		/// 文件鏈接
		/// </summary>
		public string Url
		{
			get { return _Url; }
			set { _Url = value; }
		}

		int _DownloadCount;
		/// <summary>例
		/// 下載量
		/// </summary>
		public int DownloadCount
		{
			get { return _DownloadCount; }
			set { _DownloadCount = value; }
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

		byte _IsDisplay;
		/// <summary>例
		/// 是否顯示
		/// </summary>
		public byte IsDisplay
		{
			get { return _IsDisplay; }
			set { _IsDisplay = value; }
		}

		DateTime _UpdateDate = new DateTime(1900,1,1);
		/// <summary>
		/// 修改時間
		/// </summary>
		public DateTime UpdateDate
		{
			get { return _UpdateDate; }
			set { _UpdateDate = value; }
		}

		int _ActiveFileClass_Id;
		/// <summary>例
		/// 類別編號
		/// </summary>
		public int ActiveFileClass_Id
		{
			get { return _ActiveFileClass_Id; }
			set { _ActiveFileClass_Id = value; }
		}

		string _ActiveFileClass_Name = "";
		/// <summary>
		/// 類別名稱
		/// </summary>
		public string ActiveFileClass_Name
		{
			get { return _ActiveFileClass_Name; }
			set { _ActiveFileClass_Name = value; }
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

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("Name=" + Name + "; ");
			sb.Append("Notes=" + Notes + "; ");
			sb.Append("Content=" + Content + "; ");
			sb.Append("Keyword=" + Keyword + "; ");
			sb.Append("Url=" + Url + "; ");
			sb.Append("DownloadCount=" + DownloadCount + "; ");
			sb.Append("Sort=" + Sort + "; ");
			sb.Append("IsDisplay=" + IsDisplay + "; ");
			sb.Append("UpdateDate=" + UpdateDate + "; ");
			sb.Append("ActiveFileClass_Id=" + ActiveFileClass_Id + "; ");
			sb.Append("ActiveFileClass_Name=" + ActiveFileClass_Name + "; ");
			sb.Append("Employee_EmpId=" + Employee_EmpId + "; ");
			sb.Append("Employee_CName=" + Employee_CName + "; ");
			return sb.ToString();
        }

    } 

}


