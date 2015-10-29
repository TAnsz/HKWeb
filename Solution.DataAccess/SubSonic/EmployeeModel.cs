 
using System;
using System.Text;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Employee表實例類
    /// </summary>
	[Serializable]
    public partial class Employee
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

		string _EMP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_ID
		{
			get { return _EMP_ID; }
			set { _EMP_ID = value; }
		}

		string _CARD_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string CARD_ID
		{
			get { return _CARD_ID; }
			set { _CARD_ID = value; }
		}

		string _EMP_FNAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_FNAME
		{
			get { return _EMP_FNAME; }
			set { _EMP_FNAME = value; }
		}

		int? _KIND;
		/// <summary>例
		/// 
		/// </summary>
		public int? KIND
		{
			get { return _KIND; }
			set { _KIND = value; }
		}

		string _ID_CARD = "";
		/// <summary>
		/// 
		/// </summary>
		public string ID_CARD
		{
			get { return _ID_CARD; }
			set { _ID_CARD = value; }
		}

		bool _NO_SIGN = false;
		/// <summary>
		/// 
		/// </summary>
		public bool NO_SIGN
		{
			get { return _NO_SIGN; }
			set { _NO_SIGN = value; }
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

		string _RULE_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string RULE_ID
		{
			get { return _RULE_ID; }
			set { _RULE_ID = value; }
		}

		string _EDU_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string EDU_ID
		{
			get { return _EDU_ID; }
			set { _EDU_ID = value; }
		}

		DateTime? _BIRTH_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BIRTH_DATE
		{
			get { return _BIRTH_DATE; }
			set { _BIRTH_DATE = value; }
		}

		DateTime? _HIRE_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HIRE_DATE
		{
			get { return _HIRE_DATE; }
			set { _HIRE_DATE = value; }
		}

		DateTime? _CARDBEG_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CARDBEG_DATE
		{
			get { return _CARDBEG_DATE; }
			set { _CARDBEG_DATE = value; }
		}

		DateTime? _CARDEND_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CARDEND_DATE
		{
			get { return _CARDEND_DATE; }
			set { _CARDEND_DATE = value; }
		}

		DateTime? _LEAVE_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LEAVE_DATE
		{
			get { return _LEAVE_DATE; }
			set { _LEAVE_DATE = value; }
		}

		DateTime? _JOIN_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? JOIN_DATE
		{
			get { return _JOIN_DATE; }
			set { _JOIN_DATE = value; }
		}

		int? _TEMP_MONTH;
		/// <summary>例
		/// 
		/// </summary>
		public int? TEMP_MONTH
		{
			get { return _TEMP_MONTH; }
			set { _TEMP_MONTH = value; }
		}

		bool? _ISWAIT = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? ISWAIT
		{
			get { return _ISWAIT; }
			set { _ISWAIT = value; }
		}

		string _DIMISSION_TYPE_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string DIMISSION_TYPE_ID
		{
			get { return _DIMISSION_TYPE_ID; }
			set { _DIMISSION_TYPE_ID = value; }
		}

		string _SEX = "";
		/// <summary>
		/// 
		/// </summary>
		public string SEX
		{
			get { return _SEX; }
			set { _SEX = value; }
		}

		string _MARRIAGE = "";
		/// <summary>
		/// 
		/// </summary>
		public string MARRIAGE
		{
			get { return _MARRIAGE; }
			set { _MARRIAGE = value; }
		}

		string _EMAIL = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMAIL
		{
			get { return _EMAIL; }
			set { _EMAIL = value; }
		}

		string _PHONE_CODE = "";
		/// <summary>
		/// 
		/// </summary>
		public string PHONE_CODE
		{
			get { return _PHONE_CODE; }
			set { _PHONE_CODE = value; }
		}

		string _ADDRESS = "";
		/// <summary>
		/// 
		/// </summary>
		public string ADDRESS
		{
			get { return _ADDRESS; }
			set { _ADDRESS = value; }
		}

		string _POST_CODE = "";
		/// <summary>
		/// 
		/// </summary>
		public string POST_CODE
		{
			get { return _POST_CODE; }
			set { _POST_CODE = value; }
		}

		string _HANDER_CODE = "";
		/// <summary>
		/// 
		/// </summary>
		public string HANDER_CODE
		{
			get { return _HANDER_CODE; }
			set { _HANDER_CODE = value; }
		}

		string _HTTP_ADDRESS = "";
		/// <summary>
		/// 
		/// </summary>
		public string HTTP_ADDRESS
		{
			get { return _HTTP_ADDRESS; }
			set { _HTTP_ADDRESS = value; }
		}

		string _LINK_MAN = "";
		/// <summary>
		/// 
		/// </summary>
		public string LINK_MAN
		{
			get { return _LINK_MAN; }
			set { _LINK_MAN = value; }
		}

		string _LEAVE_CAUSE = "";
		/// <summary>
		/// 
		/// </summary>
		public string LEAVE_CAUSE
		{
			get { return _LEAVE_CAUSE; }
			set { _LEAVE_CAUSE = value; }
		}

		string _SHIFTS = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHIFTS
		{
			get { return _SHIFTS; }
			set { _SHIFTS = value; }
		}

		bool _ISSUED = false;
		/// <summary>
		/// 
		/// </summary>
		public bool ISSUED
		{
			get { return _ISSUED; }
			set { _ISSUED = value; }
		}

		DateTime? _ISSUE_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ISSUE_DATE
		{
			get { return _ISSUE_DATE; }
			set { _ISSUE_DATE = value; }
		}

		int? _ACCESS_LEVEL;
		/// <summary>例
		/// 
		/// </summary>
		public int? ACCESS_LEVEL
		{
			get { return _ACCESS_LEVEL; }
			set { _ACCESS_LEVEL = value; }
		}

		string _ACCESS_PWD = "";
		/// <summary>
		/// 
		/// </summary>
		public string ACCESS_PWD
		{
			get { return _ACCESS_PWD; }
			set { _ACCESS_PWD = value; }
		}

		string _MEAL_LEVEL = "";
		/// <summary>
		/// 
		/// </summary>
		public string MEAL_LEVEL
		{
			get { return _MEAL_LEVEL; }
			set { _MEAL_LEVEL = value; }
		}

		string _MEAL_PWD = "";
		/// <summary>
		/// 
		/// </summary>
		public string MEAL_PWD
		{
			get { return _MEAL_PWD; }
			set { _MEAL_PWD = value; }
		}

		string _FORCE_PWD = "";
		/// <summary>
		/// 
		/// </summary>
		public string FORCE_PWD
		{
			get { return _FORCE_PWD; }
			set { _FORCE_PWD = value; }
		}

		string _CARD_SN = "";
		/// <summary>
		/// 
		/// </summary>
		public string CARD_SN
		{
			get { return _CARD_SN; }
			set { _CARD_SN = value; }
		}

		byte[] _PHOTO;
		/// <summary>例
		/// 
		/// </summary>
		public byte[] PHOTO
		{
			get { return _PHOTO; }
			set { _PHOTO = value; }
		}

		bool? _ISPATROL = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? ISPATROL
		{
			get { return _ISPATROL; }
			set { _ISPATROL = value; }
		}

		string _DOOR_CARD = "";
		/// <summary>
		/// 
		/// </summary>
		public string DOOR_CARD
		{
			get { return _DOOR_CARD; }
			set { _DOOR_CARD = value; }
		}

		string _MEAL_CARD = "";
		/// <summary>
		/// 
		/// </summary>
		public string MEAL_CARD
		{
			get { return _MEAL_CARD; }
			set { _MEAL_CARD = value; }
		}

		DateTime? _OP_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OP_DATE
		{
			get { return _OP_DATE; }
			set { _OP_DATE = value; }
		}

		string _OP_USER = "";
		/// <summary>
		/// 
		/// </summary>
		public string OP_USER
		{
			get { return _OP_USER; }
			set { _OP_USER = value; }
		}

		string _RETURNCARD_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string RETURNCARD_ID
		{
			get { return _RETURNCARD_ID; }
			set { _RETURNCARD_ID = value; }
		}

		DateTime? _RETURNCARD_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RETURNCARD_DATE
		{
			get { return _RETURNCARD_DATE; }
			set { _RETURNCARD_DATE = value; }
		}

		string _LEAVE_TEXT = "";
		/// <summary>
		/// 
		/// </summary>
		public string LEAVE_TEXT
		{
			get { return _LEAVE_TEXT; }
			set { _LEAVE_TEXT = value; }
		}

		string _DEF0 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF0
		{
			get { return _DEF0; }
			set { _DEF0 = value; }
		}

		string _DEF1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF1
		{
			get { return _DEF1; }
			set { _DEF1 = value; }
		}

		string _DEF2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF2
		{
			get { return _DEF2; }
			set { _DEF2 = value; }
		}

		string _DEF3 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF3
		{
			get { return _DEF3; }
			set { _DEF3 = value; }
		}

		string _DEF4 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF4
		{
			get { return _DEF4; }
			set { _DEF4 = value; }
		}

		string _DEF5 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF5
		{
			get { return _DEF5; }
			set { _DEF5 = value; }
		}

		string _DEF6 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF6
		{
			get { return _DEF6; }
			set { _DEF6 = value; }
		}

		string _DEF7 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF7
		{
			get { return _DEF7; }
			set { _DEF7 = value; }
		}

		string _DEF8 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF8
		{
			get { return _DEF8; }
			set { _DEF8 = value; }
		}

		string _DEF9 = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEF9
		{
			get { return _DEF9; }
			set { _DEF9 = value; }
		}

		bool? _IS_SHEBAO = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? IS_SHEBAO
		{
			get { return _IS_SHEBAO; }
			set { _IS_SHEBAO = value; }
		}

		DateTime? _SHEBAO_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SHEBAO_DATE
		{
			get { return _SHEBAO_DATE; }
			set { _SHEBAO_DATE = value; }
		}

		string _BANK_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string BANK_NAME
		{
			get { return _BANK_NAME; }
			set { _BANK_NAME = value; }
		}

		string _BANK_CODE = "";
		/// <summary>
		/// 
		/// </summary>
		public string BANK_CODE
		{
			get { return _BANK_CODE; }
			set { _BANK_CODE = value; }
		}

		bool? _DOWN_FLAG = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? DOWN_FLAG
		{
			get { return _DOWN_FLAG; }
			set { _DOWN_FLAG = value; }
		}

		int? _DOOR_ID;
		/// <summary>例
		/// 
		/// </summary>
		public int? DOOR_ID
		{
			get { return _DOOR_ID; }
			set { _DOOR_ID = value; }
		}

		string _REMARK = "";
		/// <summary>
		/// 
		/// </summary>
		public string REMARK
		{
			get { return _REMARK; }
			set { _REMARK = value; }
		}

		string _LOGINPASS = "";
		/// <summary>
		/// 
		/// </summary>
		public string LOGINPASS
		{
			get { return _LOGINPASS; }
			set { _LOGINPASS = value; }
		}

		DateTime? _SFZ_BEGINDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SFZ_BEGINDATE
		{
			get { return _SFZ_BEGINDATE; }
			set { _SFZ_BEGINDATE = value; }
		}

		DateTime? _SFZ_ENDDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SFZ_ENDDATE
		{
			get { return _SFZ_ENDDATE; }
			set { _SFZ_ENDDATE = value; }
		}

		string _FINGERID = "";
		/// <summary>
		/// 
		/// </summary>
		public string FINGERID
		{
			get { return _FINGERID; }
			set { _FINGERID = value; }
		}

		bool? _ISDOWNFINGER = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? ISDOWNFINGER
		{
			get { return _ISDOWNFINGER; }
			set { _ISDOWNFINGER = value; }
		}

		string _INTROEMP = "";
		/// <summary>
		/// 
		/// </summary>
		public string INTROEMP
		{
			get { return _INTROEMP; }
			set { _INTROEMP = value; }
		}

		string _DEVID = "";
		/// <summary>
		/// 
		/// </summary>
		public string DEVID
		{
			get { return _DEVID; }
			set { _DEVID = value; }
		}

		string _CHECKTYPE = "";
		/// <summary>
		/// 
		/// </summary>
		public string CHECKTYPE
		{
			get { return _CHECKTYPE; }
			set { _CHECKTYPE = value; }
		}

		string _OPENDOORTYPE = "";
		/// <summary>
		/// 
		/// </summary>
		public string OPENDOORTYPE
		{
			get { return _OPENDOORTYPE; }
			set { _OPENDOORTYPE = value; }
		}

		short? _MODELNUM;
		/// <summary>例
		/// 
		/// </summary>
		public short? MODELNUM
		{
			get { return _MODELNUM; }
			set { _MODELNUM = value; }
		}

		string _FACE_DATA = "";
		/// <summary>
		/// 
		/// </summary>
		public string FACE_DATA
		{
			get { return _FACE_DATA; }
			set { _FACE_DATA = value; }
		}

		bool? _DEVTYPE = false;
		/// <summary>
		/// 
		/// </summary>
		public bool? DEVTYPE
		{
			get { return _DEVTYPE; }
			set { _DEVTYPE = value; }
		}

		int? _LEVELS;
		/// <summary>例
		/// 
		/// </summary>
		public int? LEVELS
		{
			get { return _LEVELS; }
			set { _LEVELS = value; }
		}

		byte[] _PASSWORD;
		/// <summary>例
		/// 
		/// </summary>
		public byte[] PASSWORD
		{
			get { return _PASSWORD; }
			set { _PASSWORD = value; }
		}

		string _GROUPS = "";
		/// <summary>
		/// 
		/// </summary>
		public string GROUPS
		{
			get { return _GROUPS; }
			set { _GROUPS = value; }
		}

		string _EN_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string EN_NAME
		{
			get { return _EN_NAME; }
			set { _EN_NAME = value; }
		}

		string _CHECKER2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string CHECKER2
		{
			get { return _CHECKER2; }
			set { _CHECKER2 = value; }
		}

		/// <summary>
        /// 導出實例所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("EMP_ID=" + EMP_ID + "; ");
			sb.Append("CARD_ID=" + CARD_ID + "; ");
			sb.Append("EMP_FNAME=" + EMP_FNAME + "; ");
			sb.Append("KIND=" + KIND + "; ");
			sb.Append("ID_CARD=" + ID_CARD + "; ");
			sb.Append("NO_SIGN=" + NO_SIGN + "; ");
			sb.Append("DEPART_ID=" + DEPART_ID + "; ");
			sb.Append("RULE_ID=" + RULE_ID + "; ");
			sb.Append("EDU_ID=" + EDU_ID + "; ");
			sb.Append("BIRTH_DATE=" + BIRTH_DATE + "; ");
			sb.Append("HIRE_DATE=" + HIRE_DATE + "; ");
			sb.Append("CARDBEG_DATE=" + CARDBEG_DATE + "; ");
			sb.Append("CARDEND_DATE=" + CARDEND_DATE + "; ");
			sb.Append("LEAVE_DATE=" + LEAVE_DATE + "; ");
			sb.Append("JOIN_DATE=" + JOIN_DATE + "; ");
			sb.Append("TEMP_MONTH=" + TEMP_MONTH + "; ");
			sb.Append("ISWAIT=" + ISWAIT + "; ");
			sb.Append("DIMISSION_TYPE_ID=" + DIMISSION_TYPE_ID + "; ");
			sb.Append("SEX=" + SEX + "; ");
			sb.Append("MARRIAGE=" + MARRIAGE + "; ");
			sb.Append("EMAIL=" + EMAIL + "; ");
			sb.Append("PHONE_CODE=" + PHONE_CODE + "; ");
			sb.Append("ADDRESS=" + ADDRESS + "; ");
			sb.Append("POST_CODE=" + POST_CODE + "; ");
			sb.Append("HANDER_CODE=" + HANDER_CODE + "; ");
			sb.Append("HTTP_ADDRESS=" + HTTP_ADDRESS + "; ");
			sb.Append("LINK_MAN=" + LINK_MAN + "; ");
			sb.Append("LEAVE_CAUSE=" + LEAVE_CAUSE + "; ");
			sb.Append("SHIFTS=" + SHIFTS + "; ");
			sb.Append("ISSUED=" + ISSUED + "; ");
			sb.Append("ISSUE_DATE=" + ISSUE_DATE + "; ");
			sb.Append("ACCESS_LEVEL=" + ACCESS_LEVEL + "; ");
			sb.Append("ACCESS_PWD=" + ACCESS_PWD + "; ");
			sb.Append("MEAL_LEVEL=" + MEAL_LEVEL + "; ");
			sb.Append("MEAL_PWD=" + MEAL_PWD + "; ");
			sb.Append("FORCE_PWD=" + FORCE_PWD + "; ");
			sb.Append("CARD_SN=" + CARD_SN + "; ");
			sb.Append("PHOTO=" + PHOTO + "; ");
			sb.Append("ISPATROL=" + ISPATROL + "; ");
			sb.Append("DOOR_CARD=" + DOOR_CARD + "; ");
			sb.Append("MEAL_CARD=" + MEAL_CARD + "; ");
			sb.Append("OP_DATE=" + OP_DATE + "; ");
			sb.Append("OP_USER=" + OP_USER + "; ");
			sb.Append("RETURNCARD_ID=" + RETURNCARD_ID + "; ");
			sb.Append("RETURNCARD_DATE=" + RETURNCARD_DATE + "; ");
			sb.Append("LEAVE_TEXT=" + LEAVE_TEXT + "; ");
			sb.Append("DEF0=" + DEF0 + "; ");
			sb.Append("DEF1=" + DEF1 + "; ");
			sb.Append("DEF2=" + DEF2 + "; ");
			sb.Append("DEF3=" + DEF3 + "; ");
			sb.Append("DEF4=" + DEF4 + "; ");
			sb.Append("DEF5=" + DEF5 + "; ");
			sb.Append("DEF6=" + DEF6 + "; ");
			sb.Append("DEF7=" + DEF7 + "; ");
			sb.Append("DEF8=" + DEF8 + "; ");
			sb.Append("DEF9=" + DEF9 + "; ");
			sb.Append("IS_SHEBAO=" + IS_SHEBAO + "; ");
			sb.Append("SHEBAO_DATE=" + SHEBAO_DATE + "; ");
			sb.Append("BANK_NAME=" + BANK_NAME + "; ");
			sb.Append("BANK_CODE=" + BANK_CODE + "; ");
			sb.Append("DOWN_FLAG=" + DOWN_FLAG + "; ");
			sb.Append("DOOR_ID=" + DOOR_ID + "; ");
			sb.Append("REMARK=" + REMARK + "; ");
			sb.Append("LOGINPASS=" + LOGINPASS + "; ");
			sb.Append("SFZ_BEGINDATE=" + SFZ_BEGINDATE + "; ");
			sb.Append("SFZ_ENDDATE=" + SFZ_ENDDATE + "; ");
			sb.Append("FINGERID=" + FINGERID + "; ");
			sb.Append("ISDOWNFINGER=" + ISDOWNFINGER + "; ");
			sb.Append("INTROEMP=" + INTROEMP + "; ");
			sb.Append("DEVID=" + DEVID + "; ");
			sb.Append("CHECKTYPE=" + CHECKTYPE + "; ");
			sb.Append("OPENDOORTYPE=" + OPENDOORTYPE + "; ");
			sb.Append("MODELNUM=" + MODELNUM + "; ");
			sb.Append("FACE_DATA=" + FACE_DATA + "; ");
			sb.Append("DEVTYPE=" + DEVTYPE + "; ");
			sb.Append("LEVELS=" + LEVELS + "; ");
			sb.Append("PASSWORD=" + PASSWORD + "; ");
			sb.Append("GROUPS=" + GROUPS + "; ");
			sb.Append("EN_NAME=" + EN_NAME + "; ");
			sb.Append("CHECKER2=" + CHECKER2 + "; ");
			return sb.ToString();
        }

    } 

}


