 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// InformationClass表實例類
    /// </summary>
	[Serializable]
    public partial class InformationClass
    {

		int _Id;
		/// <summary>例
		/// 主键Id
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Name = "";
		/// <summary>
		/// 信息名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		string _Notes = "";
		/// <summary>
		/// 描述
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
		}

		byte _IsSys;
		/// <summary>例
		/// 1=系统分类（不能删除，不能添加文章，但可以添加子分类）
		/// </summary>
		public byte IsSys
		{
			get { return _IsSys; }
			set { _IsSys = value; }
		}

		string _ClassImg = "";
		/// <summary>
		/// 分类图
		/// </summary>
		public string ClassImg
		{
			get { return _ClassImg; }
			set { _ClassImg = value; }
		}

		byte _IsShow;
		/// <summary>例
		/// 是否显示, 0=False,1=True,
		/// </summary>
		public byte IsShow
		{
			get { return _IsShow; }
			set { _IsShow = value; }
		}

		byte _IsPage;
		/// <summary>例
		/// 是否为单页,单页，没有文章封面，没有发表者，也不能评论
		/// </summary>
		public byte IsPage
		{
			get { return _IsPage; }
			set { _IsPage = value; }
		}

		int _RootId;
		/// <summary>例
		/// 分类顶层id
		/// </summary>
		public int RootId
		{
			get { return _RootId; }
			set { _RootId = value; }
		}

		int _ParentId;
		/// <summary>例
		/// 父id
		/// </summary>
		public int ParentId
		{
			get { return _ParentId; }
			set { _ParentId = value; }
		}

		int _Depth;
		/// <summary>例
		/// 层数
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

		string _SeoTitle = "";
		/// <summary>
		/// Seo标题
		/// </summary>
		public string SeoTitle
		{
			get { return _SeoTitle; }
			set { _SeoTitle = value; }
		}

		string _SeoKey = "";
		/// <summary>
		/// Seo关键字(搜索文章)
		/// </summary>
		public string SeoKey
		{
			get { return _SeoKey; }
			set { _SeoKey = value; }
		}

		string _SeoDesc = "";
		/// <summary>
		/// Seo描述
		/// </summary>
		public string SeoDesc
		{
			get { return _SeoDesc; }
			set { _SeoDesc = value; }
		}

		int _Manager_Id;
		/// <summary>例
		/// 修改人员id
		/// </summary>
		public int Manager_Id
		{
			get { return _Manager_Id; }
			set { _Manager_Id = value; }
		}

		string _Manager_CName = "";
		/// <summary>
		/// 修改人员姓名
		/// </summary>
		public string Manager_CName
		{
			get { return _Manager_CName; }
			set { _Manager_CName = value; }
		}

		DateTime _UpdateDate = new DateTime(1900,1,1);
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime UpdateDate
		{
			get { return _UpdateDate; }
			set { _UpdateDate = value; }
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
			sb.Append("IsSys=" + IsSys + "; ");
			sb.Append("ClassImg=" + ClassImg + "; ");
			sb.Append("IsShow=" + IsShow + "; ");
			sb.Append("IsPage=" + IsPage + "; ");
			sb.Append("RootId=" + RootId + "; ");
			sb.Append("ParentId=" + ParentId + "; ");
			sb.Append("Depth=" + Depth + "; ");
			sb.Append("Sort=" + Sort + "; ");
			sb.Append("SeoTitle=" + SeoTitle + "; ");
			sb.Append("SeoKey=" + SeoKey + "; ");
			sb.Append("SeoDesc=" + SeoDesc + "; ");
			sb.Append("Manager_Id=" + Manager_Id + "; ");
			sb.Append("Manager_CName=" + Manager_CName + "; ");
			sb.Append("UpdateDate=" + UpdateDate + "; ");
			return sb.ToString();
        }

    } 

}


