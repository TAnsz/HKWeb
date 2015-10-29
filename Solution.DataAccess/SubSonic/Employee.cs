 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using SubSonic.Repository;
using System.Data.Common;
using SubSonic.SqlGeneration.Schema;

namespace Solution.DataAccess.DataModel
{    
    /// <summary>
    /// A class which represents the Employee table in the HRtest Database.
    /// </summary>
    public partial class Employee: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Employee> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Employee>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Employee> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Employee item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Employee item=new Employee();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Employee> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Solution.DataAccess.DataModel.HRtestDB _db;
        public Employee(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Employee.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Employee>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Employee(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            EMP_ID = readRecord.get_string("EMP_ID",null);
               
            CARD_ID = readRecord.get_string("CARD_ID",null);
               
            EMP_FNAME = readRecord.get_string("EMP_FNAME",null);
               
            KIND = readRecord.get_int("KIND",null);
               
            ID_CARD = readRecord.get_string("ID_CARD",null);
               
            NO_SIGN = readRecord.get_bool("NO_SIGN",null);
               
            DEPART_ID = readRecord.get_string("DEPART_ID",null);
               
            RULE_ID = readRecord.get_string("RULE_ID",null);
               
            EDU_ID = readRecord.get_string("EDU_ID",null);
               
            BIRTH_DATE = readRecord.get_datetime("BIRTH_DATE",null);
               
            HIRE_DATE = readRecord.get_datetime("HIRE_DATE",null);
               
            CARDBEG_DATE = readRecord.get_datetime("CARDBEG_DATE",null);
               
            CARDEND_DATE = readRecord.get_datetime("CARDEND_DATE",null);
               
            LEAVE_DATE = readRecord.get_datetime("LEAVE_DATE",null);
               
            JOIN_DATE = readRecord.get_datetime("JOIN_DATE",null);
               
            TEMP_MONTH = readRecord.get_int("TEMP_MONTH",null);
               
            ISWAIT = readRecord.get_bool("ISWAIT",null);
               
            DIMISSION_TYPE_ID = readRecord.get_string("DIMISSION_TYPE_ID",null);
               
            SEX = readRecord.get_string("SEX",null);
               
            MARRIAGE = readRecord.get_string("MARRIAGE",null);
               
            EMAIL = readRecord.get_string("EMAIL",null);
               
            PHONE_CODE = readRecord.get_string("PHONE_CODE",null);
               
            ADDRESS = readRecord.get_string("ADDRESS",null);
               
            POST_CODE = readRecord.get_string("POST_CODE",null);
               
            HANDER_CODE = readRecord.get_string("HANDER_CODE",null);
               
            HTTP_ADDRESS = readRecord.get_string("HTTP_ADDRESS",null);
               
            LINK_MAN = readRecord.get_string("LINK_MAN",null);
               
            LEAVE_CAUSE = readRecord.get_string("LEAVE_CAUSE",null);
               
            SHIFTS = readRecord.get_string("SHIFTS",null);
               
            ISSUED = readRecord.get_bool("ISSUED",null);
               
            ISSUE_DATE = readRecord.get_datetime("ISSUE_DATE",null);
               
            ACCESS_LEVEL = readRecord.get_int("ACCESS_LEVEL",null);
               
            ACCESS_PWD = readRecord.get_string("ACCESS_PWD",null);
               
            MEAL_LEVEL = readRecord.get_string("MEAL_LEVEL",null);
               
            MEAL_PWD = readRecord.get_string("MEAL_PWD",null);
               
            FORCE_PWD = readRecord.get_string("FORCE_PWD",null);
               
            CARD_SN = readRecord.get_string("CARD_SN",null);
               
            PHOTO = readRecord.get_bytes("PHOTO",null);
               
            ISPATROL = readRecord.get_bool("ISPATROL",null);
               
            DOOR_CARD = readRecord.get_string("DOOR_CARD",null);
               
            MEAL_CARD = readRecord.get_string("MEAL_CARD",null);
               
            OP_DATE = readRecord.get_datetime("OP_DATE",null);
               
            OP_USER = readRecord.get_string("OP_USER",null);
               
            RETURNCARD_ID = readRecord.get_string("RETURNCARD_ID",null);
               
            RETURNCARD_DATE = readRecord.get_datetime("RETURNCARD_DATE",null);
               
            LEAVE_TEXT = readRecord.get_string("LEAVE_TEXT",null);
               
            DEF0 = readRecord.get_string("DEF0",null);
               
            DEF1 = readRecord.get_string("DEF1",null);
               
            DEF2 = readRecord.get_string("DEF2",null);
               
            DEF3 = readRecord.get_string("DEF3",null);
               
            DEF4 = readRecord.get_string("DEF4",null);
               
            DEF5 = readRecord.get_string("DEF5",null);
               
            DEF6 = readRecord.get_string("DEF6",null);
               
            DEF7 = readRecord.get_string("DEF7",null);
               
            DEF8 = readRecord.get_string("DEF8",null);
               
            DEF9 = readRecord.get_string("DEF9",null);
               
            IS_SHEBAO = readRecord.get_bool("IS_SHEBAO",null);
               
            SHEBAO_DATE = readRecord.get_datetime("SHEBAO_DATE",null);
               
            BANK_NAME = readRecord.get_string("BANK_NAME",null);
               
            BANK_CODE = readRecord.get_string("BANK_CODE",null);
               
            DOWN_FLAG = readRecord.get_bool("DOWN_FLAG",null);
               
            DOOR_ID = readRecord.get_int("DOOR_ID",null);
               
            REMARK = readRecord.get_string("REMARK",null);
               
            LOGINPASS = readRecord.get_string("LOGINPASS",null);
               
            SFZ_BEGINDATE = readRecord.get_datetime("SFZ_BEGINDATE",null);
               
            SFZ_ENDDATE = readRecord.get_datetime("SFZ_ENDDATE",null);
               
            FINGERID = readRecord.get_string("FINGERID",null);
               
            ISDOWNFINGER = readRecord.get_bool("ISDOWNFINGER",null);
               
            INTROEMP = readRecord.get_string("INTROEMP",null);
               
            DEVID = readRecord.get_string("DEVID",null);
               
            CHECKTYPE = readRecord.get_string("CHECKTYPE",null);
               
            OPENDOORTYPE = readRecord.get_string("OPENDOORTYPE",null);
               
            MODELNUM = readRecord.get_short("MODELNUM",null);
               
            FACE_DATA = readRecord.get_string("FACE_DATA",null);
               
            DEVTYPE = readRecord.get_bool("DEVTYPE",null);
               
            LEVELS = readRecord.get_int("LEVELS",null);
               
            PASSWORD = readRecord.get_bytes("PASSWORD",null);
               
            GROUPS = readRecord.get_string("GROUPS",null);
               
            EN_NAME = readRecord.get_string("EN_NAME",null);
               
            CHECKER2 = readRecord.get_string("CHECKER2",null);
                }   

        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public Employee(Expression<Func<Employee, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Employee> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<Employee> _repo;
            
            if(db.TestMode){
                Employee.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Employee>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Employee> GetRepo(){
            return GetRepo("","");
        }
        
        public static Employee SingleOrDefault(Expression<Func<Employee, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Employee single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Employee SingleOrDefault(Expression<Func<Employee, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Employee single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Employee, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Employee, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Employee> Find(Expression<Func<Employee, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Employee> Find(Expression<Func<Employee, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Employee> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Employee> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Employee> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Employee> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Employee> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Employee> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "Id";
        }

        public object KeyValue()
        {
            return this.Id;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
		
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

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Employee)){
                Employee compare=(Employee)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.Id;
        }
        
        public string DescriptorValue()
        {
                            return this.EMP_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "EMP_ID";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "EMP_ID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public int Id
        {
            get { return _Id; }
            set
            {
                if(_Id!=value || _isLoaded){
                    _Id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EMP_ID;
		/// <summary>
		/// 
		/// </summary>
        public string EMP_ID
        {
            get { return _EMP_ID; }
            set
            {
                if(_EMP_ID!=value || _isLoaded){
                    _EMP_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EMP_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CARD_ID;
		/// <summary>
		/// 
		/// </summary>
        public string CARD_ID
        {
            get { return _CARD_ID; }
            set
            {
                if(_CARD_ID!=value || _isLoaded){
                    _CARD_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CARD_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EMP_FNAME;
		/// <summary>
		/// 
		/// </summary>
        public string EMP_FNAME
        {
            get { return _EMP_FNAME; }
            set
            {
                if(_EMP_FNAME!=value || _isLoaded){
                    _EMP_FNAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EMP_FNAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _KIND;
		/// <summary>
		/// 
		/// </summary>
        public int? KIND
        {
            get { return _KIND; }
            set
            {
                if(_KIND!=value || _isLoaded){
                    _KIND=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="KIND");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ID_CARD;
		/// <summary>
		/// 
		/// </summary>
        public string ID_CARD
        {
            get { return _ID_CARD; }
            set
            {
                if(_ID_CARD!=value || _isLoaded){
                    _ID_CARD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ID_CARD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _NO_SIGN;
		/// <summary>
		/// 
		/// </summary>
        public bool NO_SIGN
        {
            get { return _NO_SIGN; }
            set
            {
                if(_NO_SIGN!=value || _isLoaded){
                    _NO_SIGN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NO_SIGN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEPART_ID;
		/// <summary>
		/// 
		/// </summary>
        public string DEPART_ID
        {
            get { return _DEPART_ID; }
            set
            {
                if(_DEPART_ID!=value || _isLoaded){
                    _DEPART_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEPART_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RULE_ID;
		/// <summary>
		/// 
		/// </summary>
        public string RULE_ID
        {
            get { return _RULE_ID; }
            set
            {
                if(_RULE_ID!=value || _isLoaded){
                    _RULE_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RULE_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EDU_ID;
		/// <summary>
		/// 
		/// </summary>
        public string EDU_ID
        {
            get { return _EDU_ID; }
            set
            {
                if(_EDU_ID!=value || _isLoaded){
                    _EDU_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EDU_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _BIRTH_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? BIRTH_DATE
        {
            get { return _BIRTH_DATE; }
            set
            {
                if(_BIRTH_DATE!=value || _isLoaded){
                    _BIRTH_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BIRTH_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _HIRE_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? HIRE_DATE
        {
            get { return _HIRE_DATE; }
            set
            {
                if(_HIRE_DATE!=value || _isLoaded){
                    _HIRE_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HIRE_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CARDBEG_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? CARDBEG_DATE
        {
            get { return _CARDBEG_DATE; }
            set
            {
                if(_CARDBEG_DATE!=value || _isLoaded){
                    _CARDBEG_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CARDBEG_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CARDEND_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? CARDEND_DATE
        {
            get { return _CARDEND_DATE; }
            set
            {
                if(_CARDEND_DATE!=value || _isLoaded){
                    _CARDEND_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CARDEND_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _LEAVE_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? LEAVE_DATE
        {
            get { return _LEAVE_DATE; }
            set
            {
                if(_LEAVE_DATE!=value || _isLoaded){
                    _LEAVE_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LEAVE_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _JOIN_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? JOIN_DATE
        {
            get { return _JOIN_DATE; }
            set
            {
                if(_JOIN_DATE!=value || _isLoaded){
                    _JOIN_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="JOIN_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _TEMP_MONTH;
		/// <summary>
		/// 
		/// </summary>
        public int? TEMP_MONTH
        {
            get { return _TEMP_MONTH; }
            set
            {
                if(_TEMP_MONTH!=value || _isLoaded){
                    _TEMP_MONTH=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TEMP_MONTH");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _ISWAIT;
		/// <summary>
		/// 
		/// </summary>
        public bool? ISWAIT
        {
            get { return _ISWAIT; }
            set
            {
                if(_ISWAIT!=value || _isLoaded){
                    _ISWAIT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ISWAIT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DIMISSION_TYPE_ID;
		/// <summary>
		/// 
		/// </summary>
        public string DIMISSION_TYPE_ID
        {
            get { return _DIMISSION_TYPE_ID; }
            set
            {
                if(_DIMISSION_TYPE_ID!=value || _isLoaded){
                    _DIMISSION_TYPE_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DIMISSION_TYPE_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SEX;
		/// <summary>
		/// 
		/// </summary>
        public string SEX
        {
            get { return _SEX; }
            set
            {
                if(_SEX!=value || _isLoaded){
                    _SEX=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SEX");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MARRIAGE;
		/// <summary>
		/// 
		/// </summary>
        public string MARRIAGE
        {
            get { return _MARRIAGE; }
            set
            {
                if(_MARRIAGE!=value || _isLoaded){
                    _MARRIAGE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MARRIAGE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EMAIL;
		/// <summary>
		/// 
		/// </summary>
        public string EMAIL
        {
            get { return _EMAIL; }
            set
            {
                if(_EMAIL!=value || _isLoaded){
                    _EMAIL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EMAIL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PHONE_CODE;
		/// <summary>
		/// 
		/// </summary>
        public string PHONE_CODE
        {
            get { return _PHONE_CODE; }
            set
            {
                if(_PHONE_CODE!=value || _isLoaded){
                    _PHONE_CODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PHONE_CODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ADDRESS;
		/// <summary>
		/// 
		/// </summary>
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set
            {
                if(_ADDRESS!=value || _isLoaded){
                    _ADDRESS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ADDRESS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _POST_CODE;
		/// <summary>
		/// 
		/// </summary>
        public string POST_CODE
        {
            get { return _POST_CODE; }
            set
            {
                if(_POST_CODE!=value || _isLoaded){
                    _POST_CODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="POST_CODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _HANDER_CODE;
		/// <summary>
		/// 
		/// </summary>
        public string HANDER_CODE
        {
            get { return _HANDER_CODE; }
            set
            {
                if(_HANDER_CODE!=value || _isLoaded){
                    _HANDER_CODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HANDER_CODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _HTTP_ADDRESS;
		/// <summary>
		/// 
		/// </summary>
        public string HTTP_ADDRESS
        {
            get { return _HTTP_ADDRESS; }
            set
            {
                if(_HTTP_ADDRESS!=value || _isLoaded){
                    _HTTP_ADDRESS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HTTP_ADDRESS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LINK_MAN;
		/// <summary>
		/// 
		/// </summary>
        public string LINK_MAN
        {
            get { return _LINK_MAN; }
            set
            {
                if(_LINK_MAN!=value || _isLoaded){
                    _LINK_MAN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LINK_MAN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LEAVE_CAUSE;
		/// <summary>
		/// 
		/// </summary>
        public string LEAVE_CAUSE
        {
            get { return _LEAVE_CAUSE; }
            set
            {
                if(_LEAVE_CAUSE!=value || _isLoaded){
                    _LEAVE_CAUSE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LEAVE_CAUSE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SHIFTS;
		/// <summary>
		/// 
		/// </summary>
        public string SHIFTS
        {
            get { return _SHIFTS; }
            set
            {
                if(_SHIFTS!=value || _isLoaded){
                    _SHIFTS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SHIFTS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool _ISSUED;
		/// <summary>
		/// 
		/// </summary>
        public bool ISSUED
        {
            get { return _ISSUED; }
            set
            {
                if(_ISSUED!=value || _isLoaded){
                    _ISSUED=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ISSUED");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ISSUE_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? ISSUE_DATE
        {
            get { return _ISSUE_DATE; }
            set
            {
                if(_ISSUE_DATE!=value || _isLoaded){
                    _ISSUE_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ISSUE_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ACCESS_LEVEL;
		/// <summary>
		/// 
		/// </summary>
        public int? ACCESS_LEVEL
        {
            get { return _ACCESS_LEVEL; }
            set
            {
                if(_ACCESS_LEVEL!=value || _isLoaded){
                    _ACCESS_LEVEL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ACCESS_LEVEL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ACCESS_PWD;
		/// <summary>
		/// 
		/// </summary>
        public string ACCESS_PWD
        {
            get { return _ACCESS_PWD; }
            set
            {
                if(_ACCESS_PWD!=value || _isLoaded){
                    _ACCESS_PWD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ACCESS_PWD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MEAL_LEVEL;
		/// <summary>
		/// 
		/// </summary>
        public string MEAL_LEVEL
        {
            get { return _MEAL_LEVEL; }
            set
            {
                if(_MEAL_LEVEL!=value || _isLoaded){
                    _MEAL_LEVEL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MEAL_LEVEL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MEAL_PWD;
		/// <summary>
		/// 
		/// </summary>
        public string MEAL_PWD
        {
            get { return _MEAL_PWD; }
            set
            {
                if(_MEAL_PWD!=value || _isLoaded){
                    _MEAL_PWD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MEAL_PWD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FORCE_PWD;
		/// <summary>
		/// 
		/// </summary>
        public string FORCE_PWD
        {
            get { return _FORCE_PWD; }
            set
            {
                if(_FORCE_PWD!=value || _isLoaded){
                    _FORCE_PWD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FORCE_PWD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CARD_SN;
		/// <summary>
		/// 
		/// </summary>
        public string CARD_SN
        {
            get { return _CARD_SN; }
            set
            {
                if(_CARD_SN!=value || _isLoaded){
                    _CARD_SN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CARD_SN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte[] _PHOTO;
		/// <summary>
		/// 
		/// </summary>
        public byte[] PHOTO
        {
            get { return _PHOTO; }
            set
            {
                if(_PHOTO!=value || _isLoaded){
                    _PHOTO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PHOTO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _ISPATROL;
		/// <summary>
		/// 
		/// </summary>
        public bool? ISPATROL
        {
            get { return _ISPATROL; }
            set
            {
                if(_ISPATROL!=value || _isLoaded){
                    _ISPATROL=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ISPATROL");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DOOR_CARD;
		/// <summary>
		/// 
		/// </summary>
        public string DOOR_CARD
        {
            get { return _DOOR_CARD; }
            set
            {
                if(_DOOR_CARD!=value || _isLoaded){
                    _DOOR_CARD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DOOR_CARD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MEAL_CARD;
		/// <summary>
		/// 
		/// </summary>
        public string MEAL_CARD
        {
            get { return _MEAL_CARD; }
            set
            {
                if(_MEAL_CARD!=value || _isLoaded){
                    _MEAL_CARD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MEAL_CARD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OP_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OP_DATE
        {
            get { return _OP_DATE; }
            set
            {
                if(_OP_DATE!=value || _isLoaded){
                    _OP_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OP_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OP_USER;
		/// <summary>
		/// 
		/// </summary>
        public string OP_USER
        {
            get { return _OP_USER; }
            set
            {
                if(_OP_USER!=value || _isLoaded){
                    _OP_USER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OP_USER");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RETURNCARD_ID;
		/// <summary>
		/// 
		/// </summary>
        public string RETURNCARD_ID
        {
            get { return _RETURNCARD_ID; }
            set
            {
                if(_RETURNCARD_ID!=value || _isLoaded){
                    _RETURNCARD_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RETURNCARD_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _RETURNCARD_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? RETURNCARD_DATE
        {
            get { return _RETURNCARD_DATE; }
            set
            {
                if(_RETURNCARD_DATE!=value || _isLoaded){
                    _RETURNCARD_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RETURNCARD_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LEAVE_TEXT;
		/// <summary>
		/// 
		/// </summary>
        public string LEAVE_TEXT
        {
            get { return _LEAVE_TEXT; }
            set
            {
                if(_LEAVE_TEXT!=value || _isLoaded){
                    _LEAVE_TEXT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LEAVE_TEXT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF0;
		/// <summary>
		/// 
		/// </summary>
        public string DEF0
        {
            get { return _DEF0; }
            set
            {
                if(_DEF0!=value || _isLoaded){
                    _DEF0=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF0");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF1;
		/// <summary>
		/// 
		/// </summary>
        public string DEF1
        {
            get { return _DEF1; }
            set
            {
                if(_DEF1!=value || _isLoaded){
                    _DEF1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF2;
		/// <summary>
		/// 
		/// </summary>
        public string DEF2
        {
            get { return _DEF2; }
            set
            {
                if(_DEF2!=value || _isLoaded){
                    _DEF2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF3;
		/// <summary>
		/// 
		/// </summary>
        public string DEF3
        {
            get { return _DEF3; }
            set
            {
                if(_DEF3!=value || _isLoaded){
                    _DEF3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF4;
		/// <summary>
		/// 
		/// </summary>
        public string DEF4
        {
            get { return _DEF4; }
            set
            {
                if(_DEF4!=value || _isLoaded){
                    _DEF4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF5;
		/// <summary>
		/// 
		/// </summary>
        public string DEF5
        {
            get { return _DEF5; }
            set
            {
                if(_DEF5!=value || _isLoaded){
                    _DEF5=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF5");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF6;
		/// <summary>
		/// 
		/// </summary>
        public string DEF6
        {
            get { return _DEF6; }
            set
            {
                if(_DEF6!=value || _isLoaded){
                    _DEF6=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF6");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF7;
		/// <summary>
		/// 
		/// </summary>
        public string DEF7
        {
            get { return _DEF7; }
            set
            {
                if(_DEF7!=value || _isLoaded){
                    _DEF7=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF7");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF8;
		/// <summary>
		/// 
		/// </summary>
        public string DEF8
        {
            get { return _DEF8; }
            set
            {
                if(_DEF8!=value || _isLoaded){
                    _DEF8=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF8");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEF9;
		/// <summary>
		/// 
		/// </summary>
        public string DEF9
        {
            get { return _DEF9; }
            set
            {
                if(_DEF9!=value || _isLoaded){
                    _DEF9=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEF9");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _IS_SHEBAO;
		/// <summary>
		/// 
		/// </summary>
        public bool? IS_SHEBAO
        {
            get { return _IS_SHEBAO; }
            set
            {
                if(_IS_SHEBAO!=value || _isLoaded){
                    _IS_SHEBAO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IS_SHEBAO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _SHEBAO_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? SHEBAO_DATE
        {
            get { return _SHEBAO_DATE; }
            set
            {
                if(_SHEBAO_DATE!=value || _isLoaded){
                    _SHEBAO_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SHEBAO_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _BANK_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string BANK_NAME
        {
            get { return _BANK_NAME; }
            set
            {
                if(_BANK_NAME!=value || _isLoaded){
                    _BANK_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BANK_NAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _BANK_CODE;
		/// <summary>
		/// 
		/// </summary>
        public string BANK_CODE
        {
            get { return _BANK_CODE; }
            set
            {
                if(_BANK_CODE!=value || _isLoaded){
                    _BANK_CODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BANK_CODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _DOWN_FLAG;
		/// <summary>
		/// 
		/// </summary>
        public bool? DOWN_FLAG
        {
            get { return _DOWN_FLAG; }
            set
            {
                if(_DOWN_FLAG!=value || _isLoaded){
                    _DOWN_FLAG=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DOWN_FLAG");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DOOR_ID;
		/// <summary>
		/// 
		/// </summary>
        public int? DOOR_ID
        {
            get { return _DOOR_ID; }
            set
            {
                if(_DOOR_ID!=value || _isLoaded){
                    _DOOR_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DOOR_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _REMARK;
		/// <summary>
		/// 
		/// </summary>
        public string REMARK
        {
            get { return _REMARK; }
            set
            {
                if(_REMARK!=value || _isLoaded){
                    _REMARK=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REMARK");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LOGINPASS;
		/// <summary>
		/// 
		/// </summary>
        public string LOGINPASS
        {
            get { return _LOGINPASS; }
            set
            {
                if(_LOGINPASS!=value || _isLoaded){
                    _LOGINPASS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LOGINPASS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _SFZ_BEGINDATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? SFZ_BEGINDATE
        {
            get { return _SFZ_BEGINDATE; }
            set
            {
                if(_SFZ_BEGINDATE!=value || _isLoaded){
                    _SFZ_BEGINDATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SFZ_BEGINDATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _SFZ_ENDDATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? SFZ_ENDDATE
        {
            get { return _SFZ_ENDDATE; }
            set
            {
                if(_SFZ_ENDDATE!=value || _isLoaded){
                    _SFZ_ENDDATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SFZ_ENDDATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FINGERID;
		/// <summary>
		/// 
		/// </summary>
        public string FINGERID
        {
            get { return _FINGERID; }
            set
            {
                if(_FINGERID!=value || _isLoaded){
                    _FINGERID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FINGERID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _ISDOWNFINGER;
		/// <summary>
		/// 
		/// </summary>
        public bool? ISDOWNFINGER
        {
            get { return _ISDOWNFINGER; }
            set
            {
                if(_ISDOWNFINGER!=value || _isLoaded){
                    _ISDOWNFINGER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ISDOWNFINGER");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _INTROEMP;
		/// <summary>
		/// 
		/// </summary>
        public string INTROEMP
        {
            get { return _INTROEMP; }
            set
            {
                if(_INTROEMP!=value || _isLoaded){
                    _INTROEMP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="INTROEMP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DEVID;
		/// <summary>
		/// 
		/// </summary>
        public string DEVID
        {
            get { return _DEVID; }
            set
            {
                if(_DEVID!=value || _isLoaded){
                    _DEVID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEVID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CHECKTYPE;
		/// <summary>
		/// 
		/// </summary>
        public string CHECKTYPE
        {
            get { return _CHECKTYPE; }
            set
            {
                if(_CHECKTYPE!=value || _isLoaded){
                    _CHECKTYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CHECKTYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OPENDOORTYPE;
		/// <summary>
		/// 
		/// </summary>
        public string OPENDOORTYPE
        {
            get { return _OPENDOORTYPE; }
            set
            {
                if(_OPENDOORTYPE!=value || _isLoaded){
                    _OPENDOORTYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OPENDOORTYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _MODELNUM;
		/// <summary>
		/// 
		/// </summary>
        public short? MODELNUM
        {
            get { return _MODELNUM; }
            set
            {
                if(_MODELNUM!=value || _isLoaded){
                    _MODELNUM=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MODELNUM");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FACE_DATA;
		/// <summary>
		/// 
		/// </summary>
        public string FACE_DATA
        {
            get { return _FACE_DATA; }
            set
            {
                if(_FACE_DATA!=value || _isLoaded){
                    _FACE_DATA=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FACE_DATA");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _DEVTYPE;
		/// <summary>
		/// 
		/// </summary>
        public bool? DEVTYPE
        {
            get { return _DEVTYPE; }
            set
            {
                if(_DEVTYPE!=value || _isLoaded){
                    _DEVTYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DEVTYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _LEVELS;
		/// <summary>
		/// 
		/// </summary>
        public int? LEVELS
        {
            get { return _LEVELS; }
            set
            {
                if(_LEVELS!=value || _isLoaded){
                    _LEVELS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LEVELS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte[] _PASSWORD;
		/// <summary>
		/// 
		/// </summary>
        public byte[] PASSWORD
        {
            get { return _PASSWORD; }
            set
            {
                if(_PASSWORD!=value || _isLoaded){
                    _PASSWORD=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PASSWORD");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GROUPS;
		/// <summary>
		/// 
		/// </summary>
        public string GROUPS
        {
            get { return _GROUPS; }
            set
            {
                if(_GROUPS!=value || _isLoaded){
                    _GROUPS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GROUPS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EN_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string EN_NAME
        {
            get { return _EN_NAME; }
            set
            {
                if(_EN_NAME!=value || _isLoaded){
                    _EN_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EN_NAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CHECKER2;
		/// <summary>
		/// 
		/// </summary>
        public string CHECKER2
        {
            get { return _CHECKER2; }
            set
            {
                if(_CHECKER2!=value || _isLoaded){
                    _CHECKER2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CHECKER2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
				_repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }

        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<Employee, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}

