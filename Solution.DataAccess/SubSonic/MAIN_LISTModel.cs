 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// MAIN_LIST表實例類
    /// </summary>
	[Serializable]
    public partial class MAIN_LIST
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

		int _PARENTNODE;
		/// <summary>例
		/// 
		/// </summary>
		public int PARENTNODE
		{
			get { return _PARENTNODE; }
			set { _PARENTNODE = value; }
		}

		int _NODE;
		/// <summary>例
		/// 
		/// </summary>
		public int NODE
		{
			get { return _NODE; }
			set { _NODE = value; }
		}

		string _DISPLAYTEXT = "";
		/// <summary>
		/// 
		/// </summary>
		public string DISPLAYTEXT
		{
			get { return _DISPLAYTEXT; }
			set { _DISPLAYTEXT = value; }
		}

		string _TABTEXT = "";
		/// <summary>
		/// 
		/// </summary>
		public string TABTEXT
		{
			get { return _TABTEXT; }
			set { _TABTEXT = value; }
		}

		string _CLASSNAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string CLASSNAME
		{
			get { return _CLASSNAME; }
			set { _CLASSNAME = value; }
		}

		int _STATICCLASS;
		/// <summary>例
		/// 
		/// </summary>
		public int STATICCLASS
		{
			get { return _STATICCLASS; }
			set { _STATICCLASS = value; }
		}

		int _SORTORDER;
		/// <summary>例
		/// 
		/// </summary>
		public int SORTORDER
		{
			get { return _SORTORDER; }
			set { _SORTORDER = value; }
		}

		string _PICTUREINDEX = "";
		/// <summary>
		/// 
		/// </summary>
		public string PICTUREINDEX
		{
			get { return _PICTUREINDEX; }
			set { _PICTUREINDEX = value; }
		}

		string _SELECTEDPICTUREINDEX = "";
		/// <summary>
		/// 
		/// </summary>
		public string SELECTEDPICTUREINDEX
		{
			get { return _SELECTEDPICTUREINDEX; }
			set { _SELECTEDPICTUREINDEX = value; }
		}

		int _EXPANDED;
		/// <summary>例
		/// 
		/// </summary>
		public int EXPANDED
		{
			get { return _EXPANDED; }
			set { _EXPANDED = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("PARENTNODE=" + PARENTNODE + "; ");
			sb.Append("NODE=" + NODE + "; ");
			sb.Append("DISPLAYTEXT=" + DISPLAYTEXT + "; ");
			sb.Append("TABTEXT=" + TABTEXT + "; ");
			sb.Append("CLASSNAME=" + CLASSNAME + "; ");
			sb.Append("STATICCLASS=" + STATICCLASS + "; ");
			sb.Append("SORTORDER=" + SORTORDER + "; ");
			sb.Append("PICTUREINDEX=" + PICTUREINDEX + "; ");
			sb.Append("SELECTEDPICTUREINDEX=" + SELECTEDPICTUREINDEX + "; ");
			sb.Append("EXPANDED=" + EXPANDED + "; ");
			return sb.ToString();
        }

    } 

}


