 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// MealOrdering表實例類
    /// </summary>
	[Serializable]
    public partial class MealOrdering
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

		string _Employee_EmpId = "";
		/// <summary>
		/// 申請人編號
		/// </summary>
		public string Employee_EmpId
		{
			get { return _Employee_EmpId; }
			set { _Employee_EmpId = value; }
		}

		string _Employee_Name = "";
		/// <summary>
		/// 申請人
		/// </summary>
		public string Employee_Name
		{
			get { return _Employee_Name; }
			set { _Employee_Name = value; }
		}

		string _Employee_EName = "";
		/// <summary>
		/// 申請人英文名
		/// </summary>
		public string Employee_EName
		{
			get { return _Employee_EName; }
			set { _Employee_EName = value; }
		}

		string _DepartId = "";
		/// <summary>
		/// 申請人部門編號
		/// </summary>
		public string DepartId
		{
			get { return _DepartId; }
			set { _DepartId = value; }
		}

		string _DepartName = "";
		/// <summary>
		/// 申請人部門名稱
		/// </summary>
		public string DepartName
		{
			get { return _DepartName; }
			set { _DepartName = value; }
		}

		string _FoodCode = "";
		/// <summary>
		/// 飯類
		/// </summary>
		public string FoodCode
		{
			get { return _FoodCode; }
			set { _FoodCode = value; }
		}

		string _DrinkCode = "";
		/// <summary>
		/// 餐飲
		/// </summary>
		public string DrinkCode
		{
			get { return _DrinkCode; }
			set { _DrinkCode = value; }
		}

		DateTime? _ApplyDate = new DateTime(1900,1,1);
		/// <summary>
		/// 申請日期
		/// </summary>
		public DateTime? ApplyDate
		{
			get { return _ApplyDate; }
			set { _ApplyDate = value; }
		}

		string _RecordId = "";
		/// <summary>
		/// 錄入人編號
		/// </summary>
		public string RecordId
		{
			get { return _RecordId; }
			set { _RecordId = value; }
		}

		string _RecordName = "";
		/// <summary>
		/// 錄入人
		/// </summary>
		public string RecordName
		{
			get { return _RecordName; }
			set { _RecordName = value; }
		}

		DateTime? _RecordDate = new DateTime(1900,1,1);
		/// <summary>
		/// 錄入日期
		/// </summary>
		public DateTime? RecordDate
		{
			get { return _RecordDate; }
			set { _RecordDate = value; }
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

		DateTime? _ModifyDate = new DateTime(1900,1,1);
		/// <summary>
		/// 修改日期
		/// </summary>
		public DateTime? ModifyDate
		{
			get { return _ModifyDate; }
			set { _ModifyDate = value; }
		}

		string _ModifyId = "";
		/// <summary>
		/// 修改人編號
		/// </summary>
		public string ModifyId
		{
			get { return _ModifyId; }
			set { _ModifyId = value; }
		}

		string _ModifyBy = "";
		/// <summary>
		/// 修改人
		/// </summary>
		public string ModifyBy
		{
			get { return _ModifyBy; }
			set { _ModifyBy = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("Code=" + Code + "; ");
			sb.Append("Employee_EmpId=" + Employee_EmpId + "; ");
			sb.Append("Employee_Name=" + Employee_Name + "; ");
			sb.Append("Employee_EName=" + Employee_EName + "; ");
			sb.Append("DepartId=" + DepartId + "; ");
			sb.Append("DepartName=" + DepartName + "; ");
			sb.Append("FoodCode=" + FoodCode + "; ");
			sb.Append("DrinkCode=" + DrinkCode + "; ");
			sb.Append("ApplyDate=" + ApplyDate + "; ");
			sb.Append("RecordId=" + RecordId + "; ");
			sb.Append("RecordName=" + RecordName + "; ");
			sb.Append("RecordDate=" + RecordDate + "; ");
			sb.Append("Remark=" + Remark + "; ");
			sb.Append("IsVaild=" + IsVaild + "; ");
			sb.Append("ModifyDate=" + ModifyDate + "; ");
			sb.Append("ModifyId=" + ModifyId + "; ");
			sb.Append("ModifyBy=" + ModifyBy + "; ");
			return sb.ToString();
        }

    } 

}


