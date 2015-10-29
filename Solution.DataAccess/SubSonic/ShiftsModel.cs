 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Shifts表實例類
    /// </summary>
	[Serializable]
    public partial class Shifts
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

		string _SHIFT_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHIFT_ID
		{
			get { return _SHIFT_ID; }
			set { _SHIFT_ID = value; }
		}

		string _SHIFT_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHIFT_NAME
		{
			get { return _SHIFT_NAME; }
			set { _SHIFT_NAME = value; }
		}

		string _DEPART_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEPART_ID
		{
			get { return _DEPART_ID; }
			set { _DEPART_ID = value; }
		}

		int? _SHIFT_KIND;
		/// <summary>例
		/// 
		/// </summary>
		public int? SHIFT_KIND
		{
			get { return _SHIFT_KIND; }
			set { _SHIFT_KIND = value; }
		}

		decimal? _WORK_HRS;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? WORK_HRS
		{
			get { return _WORK_HRS; }
			set { _WORK_HRS = value; }
		}

		decimal? _NEED_HRS;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? NEED_HRS
		{
			get { return _NEED_HRS; }
			set { _NEED_HRS = value; }
		}

		short _IS_DEFAULT;
		/// <summary>例
		/// 
		/// </summary>
		public short IS_DEFAULT
		{
			get { return _IS_DEFAULT; }
			set { _IS_DEFAULT = value; }
		}

		string _RULE_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string RULE_ID
		{
			get { return _RULE_ID; }
			set { _RULE_ID = value; }
		}

		int? _CLASS_ID;
		/// <summary>例
		/// 
		/// </summary>
		public int? CLASS_ID
		{
			get { return _CLASS_ID; }
			set { _CLASS_ID = value; }
		}

		int? _NEED_SIGN_COUNT;
		/// <summary>例
		/// 
		/// </summary>
		public int? NEED_SIGN_COUNT
		{
			get { return _NEED_SIGN_COUNT; }
			set { _NEED_SIGN_COUNT = value; }
		}

		short? _IS_COMMON;
		/// <summary>例
		/// 
		/// </summary>
		public short? IS_COMMON
		{
			get { return _IS_COMMON; }
			set { _IS_COMMON = value; }
		}

		int? _AHEAD1;
		/// <summary>例
		/// 
		/// </summary>
		public int? AHEAD1
		{
			get { return _AHEAD1; }
			set { _AHEAD1 = value; }
		}

		DateTime? _IN1 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? IN1
		{
			get { return _IN1; }
			set { _IN1 = value; }
		}

		short? _NEEDIN1;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDIN1
		{
			get { return _NEEDIN1; }
			set { _NEEDIN1 = value; }
		}

		short? _BOVERTIME1;
		/// <summary>例
		/// 
		/// </summary>
		public short? BOVERTIME1
		{
			get { return _BOVERTIME1; }
			set { _BOVERTIME1 = value; }
		}

		DateTime? _OUT1 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OUT1
		{
			get { return _OUT1; }
			set { _OUT1 = value; }
		}

		short? _DELAY1;
		/// <summary>例
		/// 
		/// </summary>
		public short? DELAY1
		{
			get { return _DELAY1; }
			set { _DELAY1 = value; }
		}

		short? _NEEDOUT1;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDOUT1
		{
			get { return _NEEDOUT1; }
			set { _NEEDOUT1 = value; }
		}

		short? _EOVERTIME1;
		/// <summary>例
		/// 
		/// </summary>
		public short? EOVERTIME1
		{
			get { return _EOVERTIME1; }
			set { _EOVERTIME1 = value; }
		}

		short? _REST1;
		/// <summary>例
		/// 
		/// </summary>
		public short? REST1
		{
			get { return _REST1; }
			set { _REST1 = value; }
		}

		DateTime? _REST_BEGIN1 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REST_BEGIN1
		{
			get { return _REST_BEGIN1; }
			set { _REST_BEGIN1 = value; }
		}

		short? _BREAK1;
		/// <summary>例
		/// 
		/// </summary>
		public short? BREAK1
		{
			get { return _BREAK1; }
			set { _BREAK1 = value; }
		}

		short? _OT1;
		/// <summary>例
		/// 
		/// </summary>
		public short? OT1
		{
			get { return _OT1; }
			set { _OT1 = value; }
		}

		short? _EXT1;
		/// <summary>例
		/// 
		/// </summary>
		public short? EXT1
		{
			get { return _EXT1; }
			set { _EXT1 = value; }
		}

		short? _CANOT1;
		/// <summary>例
		/// 
		/// </summary>
		public short? CANOT1
		{
			get { return _CANOT1; }
			set { _CANOT1 = value; }
		}

		int? _OT_REST1;
		/// <summary>例
		/// 
		/// </summary>
		public int? OT_REST1
		{
			get { return _OT_REST1; }
			set { _OT_REST1 = value; }
		}

		DateTime? _OT_REST_BEGIN1 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OT_REST_BEGIN1
		{
			get { return _OT_REST_BEGIN1; }
			set { _OT_REST_BEGIN1 = value; }
		}

		decimal? _BASICHRS1;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? BASICHRS1
		{
			get { return _BASICHRS1; }
			set { _BASICHRS1 = value; }
		}

		decimal? _NEEDHRS1;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? NEEDHRS1
		{
			get { return _NEEDHRS1; }
			set { _NEEDHRS1 = value; }
		}

		decimal? _DAY1;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DAY1
		{
			get { return _DAY1; }
			set { _DAY1 = value; }
		}

		int? _AHEAD2;
		/// <summary>例
		/// 
		/// </summary>
		public int? AHEAD2
		{
			get { return _AHEAD2; }
			set { _AHEAD2 = value; }
		}

		DateTime? _IN2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? IN2
		{
			get { return _IN2; }
			set { _IN2 = value; }
		}

		short? _NEEDIN2;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDIN2
		{
			get { return _NEEDIN2; }
			set { _NEEDIN2 = value; }
		}

		short? _BOVERTIME2;
		/// <summary>例
		/// 
		/// </summary>
		public short? BOVERTIME2
		{
			get { return _BOVERTIME2; }
			set { _BOVERTIME2 = value; }
		}

		DateTime? _OUT2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OUT2
		{
			get { return _OUT2; }
			set { _OUT2 = value; }
		}

		short? _DELAY2;
		/// <summary>例
		/// 
		/// </summary>
		public short? DELAY2
		{
			get { return _DELAY2; }
			set { _DELAY2 = value; }
		}

		short? _NEEDOUT2;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDOUT2
		{
			get { return _NEEDOUT2; }
			set { _NEEDOUT2 = value; }
		}

		short? _EOVERTIME2;
		/// <summary>例
		/// 
		/// </summary>
		public short? EOVERTIME2
		{
			get { return _EOVERTIME2; }
			set { _EOVERTIME2 = value; }
		}

		short? _REST2;
		/// <summary>例
		/// 
		/// </summary>
		public short? REST2
		{
			get { return _REST2; }
			set { _REST2 = value; }
		}

		DateTime? _REST_BEGIN2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REST_BEGIN2
		{
			get { return _REST_BEGIN2; }
			set { _REST_BEGIN2 = value; }
		}

		short? _BREAK2;
		/// <summary>例
		/// 
		/// </summary>
		public short? BREAK2
		{
			get { return _BREAK2; }
			set { _BREAK2 = value; }
		}

		short? _OT2;
		/// <summary>例
		/// 
		/// </summary>
		public short? OT2
		{
			get { return _OT2; }
			set { _OT2 = value; }
		}

		short? _EXT2;
		/// <summary>例
		/// 
		/// </summary>
		public short? EXT2
		{
			get { return _EXT2; }
			set { _EXT2 = value; }
		}

		short? _CANOT2;
		/// <summary>例
		/// 
		/// </summary>
		public short? CANOT2
		{
			get { return _CANOT2; }
			set { _CANOT2 = value; }
		}

		int? _OT_REST2;
		/// <summary>例
		/// 
		/// </summary>
		public int? OT_REST2
		{
			get { return _OT_REST2; }
			set { _OT_REST2 = value; }
		}

		DateTime? _OT_REST_BEGIN2 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OT_REST_BEGIN2
		{
			get { return _OT_REST_BEGIN2; }
			set { _OT_REST_BEGIN2 = value; }
		}

		decimal? _BASICHRS2;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? BASICHRS2
		{
			get { return _BASICHRS2; }
			set { _BASICHRS2 = value; }
		}

		decimal? _NEEDHRS2;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? NEEDHRS2
		{
			get { return _NEEDHRS2; }
			set { _NEEDHRS2 = value; }
		}

		decimal? _DAY2;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DAY2
		{
			get { return _DAY2; }
			set { _DAY2 = value; }
		}

		int? _AHEAD3;
		/// <summary>例
		/// 
		/// </summary>
		public int? AHEAD3
		{
			get { return _AHEAD3; }
			set { _AHEAD3 = value; }
		}

		DateTime? _IN3 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? IN3
		{
			get { return _IN3; }
			set { _IN3 = value; }
		}

		short? _NEEDIN3;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDIN3
		{
			get { return _NEEDIN3; }
			set { _NEEDIN3 = value; }
		}

		short? _BOVERTIME3;
		/// <summary>例
		/// 
		/// </summary>
		public short? BOVERTIME3
		{
			get { return _BOVERTIME3; }
			set { _BOVERTIME3 = value; }
		}

		DateTime? _OUT3 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OUT3
		{
			get { return _OUT3; }
			set { _OUT3 = value; }
		}

		short? _DELAY3;
		/// <summary>例
		/// 
		/// </summary>
		public short? DELAY3
		{
			get { return _DELAY3; }
			set { _DELAY3 = value; }
		}

		short? _NEEDOUT3;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDOUT3
		{
			get { return _NEEDOUT3; }
			set { _NEEDOUT3 = value; }
		}

		short? _EOVERTIME3;
		/// <summary>例
		/// 
		/// </summary>
		public short? EOVERTIME3
		{
			get { return _EOVERTIME3; }
			set { _EOVERTIME3 = value; }
		}

		short? _REST3;
		/// <summary>例
		/// 
		/// </summary>
		public short? REST3
		{
			get { return _REST3; }
			set { _REST3 = value; }
		}

		DateTime? _REST_BEGIN3 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REST_BEGIN3
		{
			get { return _REST_BEGIN3; }
			set { _REST_BEGIN3 = value; }
		}

		short? _BREAK3;
		/// <summary>例
		/// 
		/// </summary>
		public short? BREAK3
		{
			get { return _BREAK3; }
			set { _BREAK3 = value; }
		}

		short? _OT3;
		/// <summary>例
		/// 
		/// </summary>
		public short? OT3
		{
			get { return _OT3; }
			set { _OT3 = value; }
		}

		short? _EXT3;
		/// <summary>例
		/// 
		/// </summary>
		public short? EXT3
		{
			get { return _EXT3; }
			set { _EXT3 = value; }
		}

		short? _CANOT3;
		/// <summary>例
		/// 
		/// </summary>
		public short? CANOT3
		{
			get { return _CANOT3; }
			set { _CANOT3 = value; }
		}

		int? _OT_REST3;
		/// <summary>例
		/// 
		/// </summary>
		public int? OT_REST3
		{
			get { return _OT_REST3; }
			set { _OT_REST3 = value; }
		}

		DateTime? _OT_REST_BEGIN3 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OT_REST_BEGIN3
		{
			get { return _OT_REST_BEGIN3; }
			set { _OT_REST_BEGIN3 = value; }
		}

		decimal? _BASICHRS3;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? BASICHRS3
		{
			get { return _BASICHRS3; }
			set { _BASICHRS3 = value; }
		}

		decimal? _NEEDHRS3;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? NEEDHRS3
		{
			get { return _NEEDHRS3; }
			set { _NEEDHRS3 = value; }
		}

		decimal? _DAY3;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DAY3
		{
			get { return _DAY3; }
			set { _DAY3 = value; }
		}

		int? _AHEAD4;
		/// <summary>例
		/// 
		/// </summary>
		public int? AHEAD4
		{
			get { return _AHEAD4; }
			set { _AHEAD4 = value; }
		}

		DateTime? _IN4 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? IN4
		{
			get { return _IN4; }
			set { _IN4 = value; }
		}

		short? _NEEDIN4;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDIN4
		{
			get { return _NEEDIN4; }
			set { _NEEDIN4 = value; }
		}

		short? _BOVERTIME4;
		/// <summary>例
		/// 
		/// </summary>
		public short? BOVERTIME4
		{
			get { return _BOVERTIME4; }
			set { _BOVERTIME4 = value; }
		}

		DateTime? _OUT4 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OUT4
		{
			get { return _OUT4; }
			set { _OUT4 = value; }
		}

		short? _DELAY4;
		/// <summary>例
		/// 
		/// </summary>
		public short? DELAY4
		{
			get { return _DELAY4; }
			set { _DELAY4 = value; }
		}

		short? _NEEDOUT4;
		/// <summary>例
		/// 
		/// </summary>
		public short? NEEDOUT4
		{
			get { return _NEEDOUT4; }
			set { _NEEDOUT4 = value; }
		}

		short? _EOVERTIME4;
		/// <summary>例
		/// 
		/// </summary>
		public short? EOVERTIME4
		{
			get { return _EOVERTIME4; }
			set { _EOVERTIME4 = value; }
		}

		short? _REST4;
		/// <summary>例
		/// 
		/// </summary>
		public short? REST4
		{
			get { return _REST4; }
			set { _REST4 = value; }
		}

		DateTime? _REST_BEGIN4 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REST_BEGIN4
		{
			get { return _REST_BEGIN4; }
			set { _REST_BEGIN4 = value; }
		}

		short? _BREAK4;
		/// <summary>例
		/// 
		/// </summary>
		public short? BREAK4
		{
			get { return _BREAK4; }
			set { _BREAK4 = value; }
		}

		short? _OT4;
		/// <summary>例
		/// 
		/// </summary>
		public short? OT4
		{
			get { return _OT4; }
			set { _OT4 = value; }
		}

		short? _EXT4;
		/// <summary>例
		/// 
		/// </summary>
		public short? EXT4
		{
			get { return _EXT4; }
			set { _EXT4 = value; }
		}

		short? _CANOT4;
		/// <summary>例
		/// 
		/// </summary>
		public short? CANOT4
		{
			get { return _CANOT4; }
			set { _CANOT4 = value; }
		}

		int? _OT_REST4;
		/// <summary>例
		/// 
		/// </summary>
		public int? OT_REST4
		{
			get { return _OT_REST4; }
			set { _OT_REST4 = value; }
		}

		DateTime? _OT_REST_BEGIN4 = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OT_REST_BEGIN4
		{
			get { return _OT_REST_BEGIN4; }
			set { _OT_REST_BEGIN4 = value; }
		}

		decimal? _BASICHRS4;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? BASICHRS4
		{
			get { return _BASICHRS4; }
			set { _BASICHRS4 = value; }
		}

		decimal? _NEEDHRS4;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? NEEDHRS4
		{
			get { return _NEEDHRS4; }
			set { _NEEDHRS4 = value; }
		}

		decimal? _DAY4;
		/// <summary>例
		/// 
		/// </summary>
		public decimal? DAY4
		{
			get { return _DAY4; }
			set { _DAY4 = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("SHIFT_ID=" + SHIFT_ID + "; ");
			sb.Append("SHIFT_NAME=" + SHIFT_NAME + "; ");
			sb.Append("DEPART_ID=" + DEPART_ID + "; ");
			sb.Append("SHIFT_KIND=" + SHIFT_KIND + "; ");
			sb.Append("WORK_HRS=" + WORK_HRS + "; ");
			sb.Append("NEED_HRS=" + NEED_HRS + "; ");
			sb.Append("IS_DEFAULT=" + IS_DEFAULT + "; ");
			sb.Append("RULE_ID=" + RULE_ID + "; ");
			sb.Append("CLASS_ID=" + CLASS_ID + "; ");
			sb.Append("NEED_SIGN_COUNT=" + NEED_SIGN_COUNT + "; ");
			sb.Append("IS_COMMON=" + IS_COMMON + "; ");
			sb.Append("AHEAD1=" + AHEAD1 + "; ");
			sb.Append("IN1=" + IN1 + "; ");
			sb.Append("NEEDIN1=" + NEEDIN1 + "; ");
			sb.Append("BOVERTIME1=" + BOVERTIME1 + "; ");
			sb.Append("OUT1=" + OUT1 + "; ");
			sb.Append("DELAY1=" + DELAY1 + "; ");
			sb.Append("NEEDOUT1=" + NEEDOUT1 + "; ");
			sb.Append("EOVERTIME1=" + EOVERTIME1 + "; ");
			sb.Append("REST1=" + REST1 + "; ");
			sb.Append("REST_BEGIN1=" + REST_BEGIN1 + "; ");
			sb.Append("BREAK1=" + BREAK1 + "; ");
			sb.Append("OT1=" + OT1 + "; ");
			sb.Append("EXT1=" + EXT1 + "; ");
			sb.Append("CANOT1=" + CANOT1 + "; ");
			sb.Append("OT_REST1=" + OT_REST1 + "; ");
			sb.Append("OT_REST_BEGIN1=" + OT_REST_BEGIN1 + "; ");
			sb.Append("BASICHRS1=" + BASICHRS1 + "; ");
			sb.Append("NEEDHRS1=" + NEEDHRS1 + "; ");
			sb.Append("DAY1=" + DAY1 + "; ");
			sb.Append("AHEAD2=" + AHEAD2 + "; ");
			sb.Append("IN2=" + IN2 + "; ");
			sb.Append("NEEDIN2=" + NEEDIN2 + "; ");
			sb.Append("BOVERTIME2=" + BOVERTIME2 + "; ");
			sb.Append("OUT2=" + OUT2 + "; ");
			sb.Append("DELAY2=" + DELAY2 + "; ");
			sb.Append("NEEDOUT2=" + NEEDOUT2 + "; ");
			sb.Append("EOVERTIME2=" + EOVERTIME2 + "; ");
			sb.Append("REST2=" + REST2 + "; ");
			sb.Append("REST_BEGIN2=" + REST_BEGIN2 + "; ");
			sb.Append("BREAK2=" + BREAK2 + "; ");
			sb.Append("OT2=" + OT2 + "; ");
			sb.Append("EXT2=" + EXT2 + "; ");
			sb.Append("CANOT2=" + CANOT2 + "; ");
			sb.Append("OT_REST2=" + OT_REST2 + "; ");
			sb.Append("OT_REST_BEGIN2=" + OT_REST_BEGIN2 + "; ");
			sb.Append("BASICHRS2=" + BASICHRS2 + "; ");
			sb.Append("NEEDHRS2=" + NEEDHRS2 + "; ");
			sb.Append("DAY2=" + DAY2 + "; ");
			sb.Append("AHEAD3=" + AHEAD3 + "; ");
			sb.Append("IN3=" + IN3 + "; ");
			sb.Append("NEEDIN3=" + NEEDIN3 + "; ");
			sb.Append("BOVERTIME3=" + BOVERTIME3 + "; ");
			sb.Append("OUT3=" + OUT3 + "; ");
			sb.Append("DELAY3=" + DELAY3 + "; ");
			sb.Append("NEEDOUT3=" + NEEDOUT3 + "; ");
			sb.Append("EOVERTIME3=" + EOVERTIME3 + "; ");
			sb.Append("REST3=" + REST3 + "; ");
			sb.Append("REST_BEGIN3=" + REST_BEGIN3 + "; ");
			sb.Append("BREAK3=" + BREAK3 + "; ");
			sb.Append("OT3=" + OT3 + "; ");
			sb.Append("EXT3=" + EXT3 + "; ");
			sb.Append("CANOT3=" + CANOT3 + "; ");
			sb.Append("OT_REST3=" + OT_REST3 + "; ");
			sb.Append("OT_REST_BEGIN3=" + OT_REST_BEGIN3 + "; ");
			sb.Append("BASICHRS3=" + BASICHRS3 + "; ");
			sb.Append("NEEDHRS3=" + NEEDHRS3 + "; ");
			sb.Append("DAY3=" + DAY3 + "; ");
			sb.Append("AHEAD4=" + AHEAD4 + "; ");
			sb.Append("IN4=" + IN4 + "; ");
			sb.Append("NEEDIN4=" + NEEDIN4 + "; ");
			sb.Append("BOVERTIME4=" + BOVERTIME4 + "; ");
			sb.Append("OUT4=" + OUT4 + "; ");
			sb.Append("DELAY4=" + DELAY4 + "; ");
			sb.Append("NEEDOUT4=" + NEEDOUT4 + "; ");
			sb.Append("EOVERTIME4=" + EOVERTIME4 + "; ");
			sb.Append("REST4=" + REST4 + "; ");
			sb.Append("REST_BEGIN4=" + REST_BEGIN4 + "; ");
			sb.Append("BREAK4=" + BREAK4 + "; ");
			sb.Append("OT4=" + OT4 + "; ");
			sb.Append("EXT4=" + EXT4 + "; ");
			sb.Append("CANOT4=" + CANOT4 + "; ");
			sb.Append("OT_REST4=" + OT_REST4 + "; ");
			sb.Append("OT_REST_BEGIN4=" + OT_REST_BEGIN4 + "; ");
			sb.Append("BASICHRS4=" + BASICHRS4 + "; ");
			sb.Append("NEEDHRS4=" + NEEDHRS4 + "; ");
			sb.Append("DAY4=" + DAY4 + "; ");
			return sb.ToString();
        }

    } 

}


