 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// employeedet表實例類
    /// </summary>
	[Serializable]
    public partial class employeedet
    {

		string _employeeid = "";
		/// <summary>
		/// 
		/// </summary>
		public string employeeid
		{
			get { return _employeeid; }
			set { _employeeid = value; }
		}

		string _comingtime = "";
		/// <summary>
		/// 
		/// </summary>
		public string comingtime
		{
			get { return _comingtime; }
			set { _comingtime = value; }
		}

		string _overtime = "";
		/// <summary>
		/// 
		/// </summary>
		public string overtime
		{
			get { return _overtime; }
			set { _overtime = value; }
		}

		string _date1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string date1
		{
			get { return _date1; }
			set { _date1 = value; }
		}

		string _month1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string month1
		{
			get { return _month1; }
			set { _month1 = value; }
		}

		string _year1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string year1
		{
			get { return _year1; }
			set { _year1 = value; }
		}

		string _week1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string week1
		{
			get { return _week1; }
			set { _week1 = value; }
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

		int _no;
		/// <summary>例
		/// 
		/// </summary>
		public int no
		{
			get { return _no; }
			set { _no = value; }
		}

		string _empid = "";
		/// <summary>
		/// 
		/// </summary>
		public string empid
		{
			get { return _empid; }
			set { _empid = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("employeeid=" + employeeid + "; ");
			sb.Append("comingtime=" + comingtime + "; ");
			sb.Append("overtime=" + overtime + "; ");
			sb.Append("date1=" + date1 + "; ");
			sb.Append("month1=" + month1 + "; ");
			sb.Append("year1=" + year1 + "; ");
			sb.Append("week1=" + week1 + "; ");
			sb.Append("remark=" + remark + "; ");
			sb.Append("no=" + no + "; ");
			sb.Append("empid=" + empid + "; ");
			return sb.ToString();
        }

    } 

}


