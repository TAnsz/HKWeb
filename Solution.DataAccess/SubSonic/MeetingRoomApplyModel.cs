 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// MeetingRoomApply表實例類
    /// </summary>
	[Serializable]
    public partial class MeetingRoomApply
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

		string _MeetingRoom_Code = "";
		/// <summary>
		/// 會議室編號
		/// </summary>
		public string MeetingRoom_Code
		{
			get { return _MeetingRoom_Code; }
			set { _MeetingRoom_Code = value; }
		}

		string _MeetingRoom_Name = "";
		/// <summary>
		/// 會議室名稱
		/// </summary>
		public string MeetingRoom_Name
		{
			get { return _MeetingRoom_Name; }
			set { _MeetingRoom_Name = value; }
		}

		DateTime _ApplyDate = new DateTime(1900,1,1);
		/// <summary>
		/// 申請日期
		/// </summary>
		public DateTime ApplyDate
		{
			get { return _ApplyDate; }
			set { _ApplyDate = value; }
		}

		DateTime _StartTime = new DateTime(1900,1,1);
		/// <summary>
		/// 開始時間
		/// </summary>
		public DateTime StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}

		DateTime _EndTime = new DateTime(1900,1,1);
		/// <summary>
		/// 結束時間
		/// </summary>
		public DateTime EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value; }
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

		string _Employee_Name = "";
		/// <summary>
		/// 申請人
		/// </summary>
		public string Employee_Name
		{
			get { return _Employee_Name; }
			set { _Employee_Name = value; }
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

		byte _IsVideo;
		/// <summary>例
		/// 是否視頻會議
		/// </summary>
		public byte IsVideo
		{
			get { return _IsVideo; }
			set { _IsVideo = value; }
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
			sb.Append("MeetingRoom_Code=" + MeetingRoom_Code + "; ");
			sb.Append("MeetingRoom_Name=" + MeetingRoom_Name + "; ");
			sb.Append("ApplyDate=" + ApplyDate + "; ");
			sb.Append("StartTime=" + StartTime + "; ");
			sb.Append("EndTime=" + EndTime + "; ");
			sb.Append("Employee_EmpId=" + Employee_EmpId + "; ");
			sb.Append("Employee_Name=" + Employee_Name + "; ");
			sb.Append("DepartId=" + DepartId + "; ");
			sb.Append("DepartName=" + DepartName + "; ");
			sb.Append("IsVideo=" + IsVideo + "; ");
			sb.Append("Remark=" + Remark + "; ");
			sb.Append("IsVaild=" + IsVaild + "; ");
			return sb.ToString();
        }

    } 

}


