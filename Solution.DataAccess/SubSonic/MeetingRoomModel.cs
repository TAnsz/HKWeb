 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// MeetingRoom表實例類
    /// </summary>
	[Serializable]
    public partial class MeetingRoom
    {

		long _Id;
		/// <summary>例
		/// Id
		/// </summary>
		public long Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Code = "";
		/// <summary>
		/// 編號
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
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

		int? _Qty;
		/// <summary>例
		/// 可容納人數
		/// </summary>
		public int? Qty
		{
			get { return _Qty; }
			set { _Qty = value; }
		}

		string _Address = "";
		/// <summary>
		/// 地址
		/// </summary>
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}

		string _Remark = "";
		/// <summary>
		/// 備注
		/// </summary>
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}

		byte? _IsVaild;
		/// <summary>例
		/// 有效
		/// </summary>
		public byte? IsVaild
		{
			get { return _IsVaild; }
			set { _IsVaild = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("Code=" + Code + "; ");
			sb.Append("Name=" + Name + "; ");
			sb.Append("Qty=" + Qty + "; ");
			sb.Append("Address=" + Address + "; ");
			sb.Append("Remark=" + Remark + "; ");
			sb.Append("IsVaild=" + IsVaild + "; ");
			return sb.ToString();
        }

    } 

}


