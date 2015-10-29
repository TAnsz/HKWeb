 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// RoomMoment表實例類
    /// </summary>
	[Serializable]
    public partial class RoomMoment
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

		DateTime? _RoomDate = new DateTime(1900,1,1);
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime? RoomDate
		{
			get { return _RoomDate; }
			set { _RoomDate = value; }
		}

		byte? _T0830;
		/// <summary>例
		/// 08:30--
		/// </summary>
		public byte? T0830
		{
			get { return _T0830; }
			set { _T0830 = value; }
		}

		byte? _T0900;
		/// <summary>例
		/// 09:00-
		/// </summary>
		public byte? T0900
		{
			get { return _T0900; }
			set { _T0900 = value; }
		}

		byte? _T0930;
		/// <summary>例
		/// 09:30--
		/// </summary>
		public byte? T0930
		{
			get { return _T0930; }
			set { _T0930 = value; }
		}

		byte? _T1000;
		/// <summary>例
		/// 10:00--
		/// </summary>
		public byte? T1000
		{
			get { return _T1000; }
			set { _T1000 = value; }
		}

		byte? _T1030;
		/// <summary>例
		/// 10:30-
		/// </summary>
		public byte? T1030
		{
			get { return _T1030; }
			set { _T1030 = value; }
		}

		byte? _T1100;
		/// <summary>例
		/// 11:00-
		/// </summary>
		public byte? T1100
		{
			get { return _T1100; }
			set { _T1100 = value; }
		}

		byte? _T1130;
		/// <summary>例
		/// 11:30-
		/// </summary>
		public byte? T1130
		{
			get { return _T1130; }
			set { _T1130 = value; }
		}

		byte? _T1200;
		/// <summary>例
		/// 12:00-
		/// </summary>
		public byte? T1200
		{
			get { return _T1200; }
			set { _T1200 = value; }
		}

		byte? _T1230;
		/// <summary>例
		/// 12:30-
		/// </summary>
		public byte? T1230
		{
			get { return _T1230; }
			set { _T1230 = value; }
		}

		byte? _T1300;
		/// <summary>例
		/// 13:00-
		/// </summary>
		public byte? T1300
		{
			get { return _T1300; }
			set { _T1300 = value; }
		}

		byte? _T1330;
		/// <summary>例
		/// 13:30-
		/// </summary>
		public byte? T1330
		{
			get { return _T1330; }
			set { _T1330 = value; }
		}

		byte? _T1400;
		/// <summary>例
		/// 14:00-
		/// </summary>
		public byte? T1400
		{
			get { return _T1400; }
			set { _T1400 = value; }
		}

		byte? _T1430;
		/// <summary>例
		/// 14:30-
		/// </summary>
		public byte? T1430
		{
			get { return _T1430; }
			set { _T1430 = value; }
		}

		byte? _T1500;
		/// <summary>例
		/// 15:00-
		/// </summary>
		public byte? T1500
		{
			get { return _T1500; }
			set { _T1500 = value; }
		}

		byte? _T1530;
		/// <summary>例
		/// 15:30-
		/// </summary>
		public byte? T1530
		{
			get { return _T1530; }
			set { _T1530 = value; }
		}

		byte? _T1600;
		/// <summary>例
		/// 16:00-
		/// </summary>
		public byte? T1600
		{
			get { return _T1600; }
			set { _T1600 = value; }
		}

		byte? _T1630;
		/// <summary>例
		/// 16:30-
		/// </summary>
		public byte? T1630
		{
			get { return _T1630; }
			set { _T1630 = value; }
		}

		byte? _T1700;
		/// <summary>例
		/// 17:00-
		/// </summary>
		public byte? T1700
		{
			get { return _T1700; }
			set { _T1700 = value; }
		}

		byte? _T1730;
		/// <summary>例
		/// 17:30-
		/// </summary>
		public byte? T1730
		{
			get { return _T1730; }
			set { _T1730 = value; }
		}

		byte? _T1800;
		/// <summary>例
		/// 18:00-
		/// </summary>
		public byte? T1800
		{
			get { return _T1800; }
			set { _T1800 = value; }
		}

		byte? _T1830;
		/// <summary>例
		/// 18:30-
		/// </summary>
		public byte? T1830
		{
			get { return _T1830; }
			set { _T1830 = value; }
		}

		byte? _T1900;
		/// <summary>例
		/// 19:00-
		/// </summary>
		public byte? T1900
		{
			get { return _T1900; }
			set { _T1900 = value; }
		}

		byte? _T1930;
		/// <summary>例
		/// 19:30-
		/// </summary>
		public byte? T1930
		{
			get { return _T1930; }
			set { _T1930 = value; }
		}

		byte? _T2000;
		/// <summary>例
		/// 20:00-
		/// </summary>
		public byte? T2000
		{
			get { return _T2000; }
			set { _T2000 = value; }
		}

		byte? _T2030;
		/// <summary>例
		/// 20:30-
		/// </summary>
		public byte? T2030
		{
			get { return _T2030; }
			set { _T2030 = value; }
		}

		byte? _T2100;
		/// <summary>例
		/// 21:00-
		/// </summary>
		public byte? T2100
		{
			get { return _T2100; }
			set { _T2100 = value; }
		}

		byte? _T2130;
		/// <summary>例
		/// 21:30-
		/// </summary>
		public byte? T2130
		{
			get { return _T2130; }
			set { _T2130 = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("MeetingRoom_Code=" + MeetingRoom_Code + "; ");
			sb.Append("MeetingRoom_Name=" + MeetingRoom_Name + "; ");
			sb.Append("RoomDate=" + RoomDate + "; ");
			sb.Append("T0830=" + T0830 + "; ");
			sb.Append("T0900=" + T0900 + "; ");
			sb.Append("T0930=" + T0930 + "; ");
			sb.Append("T1000=" + T1000 + "; ");
			sb.Append("T1030=" + T1030 + "; ");
			sb.Append("T1100=" + T1100 + "; ");
			sb.Append("T1130=" + T1130 + "; ");
			sb.Append("T1200=" + T1200 + "; ");
			sb.Append("T1230=" + T1230 + "; ");
			sb.Append("T1300=" + T1300 + "; ");
			sb.Append("T1330=" + T1330 + "; ");
			sb.Append("T1400=" + T1400 + "; ");
			sb.Append("T1430=" + T1430 + "; ");
			sb.Append("T1500=" + T1500 + "; ");
			sb.Append("T1530=" + T1530 + "; ");
			sb.Append("T1600=" + T1600 + "; ");
			sb.Append("T1630=" + T1630 + "; ");
			sb.Append("T1700=" + T1700 + "; ");
			sb.Append("T1730=" + T1730 + "; ");
			sb.Append("T1800=" + T1800 + "; ");
			sb.Append("T1830=" + T1830 + "; ");
			sb.Append("T1900=" + T1900 + "; ");
			sb.Append("T1930=" + T1930 + "; ");
			sb.Append("T2000=" + T2000 + "; ");
			sb.Append("T2030=" + T2030 + "; ");
			sb.Append("T2100=" + T2100 + "; ");
			sb.Append("T2130=" + T2130 + "; ");
			return sb.ToString();
        }

    } 

}


