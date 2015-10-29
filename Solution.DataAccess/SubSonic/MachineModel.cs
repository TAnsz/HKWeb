 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Machine表實例類
    /// </summary>
	[Serializable]
    public partial class Machine
    {

		string _Id = "";
		/// <summary>
		/// 
		/// </summary>
		public string Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _name = "";
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		string _spec = "";
		/// <summary>
		/// 
		/// </summary>
		public string spec
		{
			get { return _spec; }
			set { _spec = value; }
		}

		string _ip = "";
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			get { return _ip; }
			set { _ip = value; }
		}

		string _port = "";
		/// <summary>
		/// 
		/// </summary>
		public string port
		{
			get { return _port; }
			set { _port = value; }
		}

		bool? _isvaild = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? isvaild
		{
			get { return _isvaild; }
			set { _isvaild = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("name=" + name + "; ");
			sb.Append("spec=" + spec + "; ");
			sb.Append("ip=" + ip + "; ");
			sb.Append("port=" + port + "; ");
			sb.Append("isvaild=" + isvaild + "; ");
			return sb.ToString();
        }

    } 

}


