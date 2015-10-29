 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// CardDetail表實例類
    /// </summary>
	[Serializable]
    public partial class CardDetail
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

		int _join_id;
		/// <summary>例
		/// 
		/// </summary>
		public int join_id
		{
			get { return _join_id; }
			set { _join_id = value; }
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

		string _card_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string card_id
		{
			get { return _card_id; }
			set { _card_id = value; }
		}

		int? _kind;
		/// <summary>例
		/// 
		/// </summary>
		public int? kind
		{
			get { return _kind; }
			set { _kind = value; }
		}

		DateTime? _use_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? use_date
		{
			get { return _use_date; }
			set { _use_date = value; }
		}

		DateTime? _Invalid_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Invalid_date
		{
			get { return _Invalid_date; }
			set { _Invalid_date = value; }
		}

		short? _isbuban;
		/// <summary>例
		/// 
		/// </summary>
		public short? isbuban
		{
			get { return _isbuban; }
			set { _isbuban = value; }
		}

		short? _isunloss;
		/// <summary>例
		/// 
		/// </summary>
		public short? isunloss
		{
			get { return _isunloss; }
			set { _isunloss = value; }
		}

		string _card_sn = "";
		/// <summary>
		/// 
		/// </summary>
		public string card_sn
		{
			get { return _card_sn; }
			set { _card_sn = value; }
		}

		string _old_card_id = "";
		/// <summary>
		/// 
		/// </summary>
		public string old_card_id
		{
			get { return _old_card_id; }
			set { _old_card_id = value; }
		}

		short? _audit;
		/// <summary>例
		/// 
		/// </summary>
		public short? audit
		{
			get { return _audit; }
			set { _audit = value; }
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

		DateTime? _op_date = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? op_date
		{
			get { return _op_date; }
			set { _op_date = value; }
		}

		string _op_user = "";
		/// <summary>
		/// 
		/// </summary>
		public string op_user
		{
			get { return _op_user; }
			set { _op_user = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("card_id=" + card_id + "; ");
			sb.Append("kind=" + kind + "; ");
			sb.Append("use_date=" + use_date + "; ");
			sb.Append("Invalid_date=" + Invalid_date + "; ");
			sb.Append("isbuban=" + isbuban + "; ");
			sb.Append("isunloss=" + isunloss + "; ");
			sb.Append("card_sn=" + card_sn + "; ");
			sb.Append("old_card_id=" + old_card_id + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("remark=" + remark + "; ");
			sb.Append("op_date=" + op_date + "; ");
			sb.Append("op_user=" + op_user + "; ");
			return sb.ToString();
        }

    } 

}


