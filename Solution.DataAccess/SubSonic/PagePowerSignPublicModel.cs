 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// PagePowerSignPublic表實例類
    /// </summary>
	[Serializable]
    public partial class PagePowerSignPublic
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

		string _CName = "";
		/// <summary>
		/// 权限中文名称
		/// </summary>
		public string CName
		{
			get { return _CName; }
			set { _CName = value; }
		}

		string _EName = "";
		/// <summary>
		/// 权限英文名称
		/// </summary>
		public string EName
		{
			get { return _EName; }
			set { _EName = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("CName=" + CName + "; ");
			sb.Append("EName=" + EName + "; ");
			return sb.ToString();
        }

    } 

}


