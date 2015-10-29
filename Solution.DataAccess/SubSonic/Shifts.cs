 
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
    /// A class which represents the Shifts table in the HRtest Database.
    /// </summary>
    public partial class Shifts: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Shifts> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Shifts>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Shifts> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Shifts item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Shifts item=new Shifts();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Shifts> _repo;
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
        public Shifts(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Shifts.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Shifts>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Shifts(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            SHIFT_ID = readRecord.get_string("SHIFT_ID",null);
               
            SHIFT_NAME = readRecord.get_string("SHIFT_NAME",null);
               
            DEPART_ID = readRecord.get_string("DEPART_ID",null);
               
            SHIFT_KIND = readRecord.get_int("SHIFT_KIND",null);
               
            WORK_HRS = readRecord.get_decimal("WORK_HRS",null);
               
            NEED_HRS = readRecord.get_decimal("NEED_HRS",null);
               
            IS_DEFAULT = readRecord.get_short("IS_DEFAULT",null);
               
            RULE_ID = readRecord.get_string("RULE_ID",null);
               
            CLASS_ID = readRecord.get_int("CLASS_ID",null);
               
            NEED_SIGN_COUNT = readRecord.get_int("NEED_SIGN_COUNT",null);
               
            IS_COMMON = readRecord.get_short("IS_COMMON",null);
               
            AHEAD1 = readRecord.get_int("AHEAD1",null);
               
            IN1 = readRecord.get_datetime("IN1",null);
               
            NEEDIN1 = readRecord.get_short("NEEDIN1",null);
               
            BOVERTIME1 = readRecord.get_short("BOVERTIME1",null);
               
            OUT1 = readRecord.get_datetime("OUT1",null);
               
            DELAY1 = readRecord.get_short("DELAY1",null);
               
            NEEDOUT1 = readRecord.get_short("NEEDOUT1",null);
               
            EOVERTIME1 = readRecord.get_short("EOVERTIME1",null);
               
            REST1 = readRecord.get_short("REST1",null);
               
            REST_BEGIN1 = readRecord.get_datetime("REST_BEGIN1",null);
               
            BREAK1 = readRecord.get_short("BREAK1",null);
               
            OT1 = readRecord.get_short("OT1",null);
               
            EXT1 = readRecord.get_short("EXT1",null);
               
            CANOT1 = readRecord.get_short("CANOT1",null);
               
            OT_REST1 = readRecord.get_int("OT_REST1",null);
               
            OT_REST_BEGIN1 = readRecord.get_datetime("OT_REST_BEGIN1",null);
               
            BASICHRS1 = readRecord.get_decimal("BASICHRS1",null);
               
            NEEDHRS1 = readRecord.get_decimal("NEEDHRS1",null);
               
            DAY1 = readRecord.get_decimal("DAY1",null);
               
            AHEAD2 = readRecord.get_int("AHEAD2",null);
               
            IN2 = readRecord.get_datetime("IN2",null);
               
            NEEDIN2 = readRecord.get_short("NEEDIN2",null);
               
            BOVERTIME2 = readRecord.get_short("BOVERTIME2",null);
               
            OUT2 = readRecord.get_datetime("OUT2",null);
               
            DELAY2 = readRecord.get_short("DELAY2",null);
               
            NEEDOUT2 = readRecord.get_short("NEEDOUT2",null);
               
            EOVERTIME2 = readRecord.get_short("EOVERTIME2",null);
               
            REST2 = readRecord.get_short("REST2",null);
               
            REST_BEGIN2 = readRecord.get_datetime("REST_BEGIN2",null);
               
            BREAK2 = readRecord.get_short("BREAK2",null);
               
            OT2 = readRecord.get_short("OT2",null);
               
            EXT2 = readRecord.get_short("EXT2",null);
               
            CANOT2 = readRecord.get_short("CANOT2",null);
               
            OT_REST2 = readRecord.get_int("OT_REST2",null);
               
            OT_REST_BEGIN2 = readRecord.get_datetime("OT_REST_BEGIN2",null);
               
            BASICHRS2 = readRecord.get_decimal("BASICHRS2",null);
               
            NEEDHRS2 = readRecord.get_decimal("NEEDHRS2",null);
               
            DAY2 = readRecord.get_decimal("DAY2",null);
               
            AHEAD3 = readRecord.get_int("AHEAD3",null);
               
            IN3 = readRecord.get_datetime("IN3",null);
               
            NEEDIN3 = readRecord.get_short("NEEDIN3",null);
               
            BOVERTIME3 = readRecord.get_short("BOVERTIME3",null);
               
            OUT3 = readRecord.get_datetime("OUT3",null);
               
            DELAY3 = readRecord.get_short("DELAY3",null);
               
            NEEDOUT3 = readRecord.get_short("NEEDOUT3",null);
               
            EOVERTIME3 = readRecord.get_short("EOVERTIME3",null);
               
            REST3 = readRecord.get_short("REST3",null);
               
            REST_BEGIN3 = readRecord.get_datetime("REST_BEGIN3",null);
               
            BREAK3 = readRecord.get_short("BREAK3",null);
               
            OT3 = readRecord.get_short("OT3",null);
               
            EXT3 = readRecord.get_short("EXT3",null);
               
            CANOT3 = readRecord.get_short("CANOT3",null);
               
            OT_REST3 = readRecord.get_int("OT_REST3",null);
               
            OT_REST_BEGIN3 = readRecord.get_datetime("OT_REST_BEGIN3",null);
               
            BASICHRS3 = readRecord.get_decimal("BASICHRS3",null);
               
            NEEDHRS3 = readRecord.get_decimal("NEEDHRS3",null);
               
            DAY3 = readRecord.get_decimal("DAY3",null);
               
            AHEAD4 = readRecord.get_int("AHEAD4",null);
               
            IN4 = readRecord.get_datetime("IN4",null);
               
            NEEDIN4 = readRecord.get_short("NEEDIN4",null);
               
            BOVERTIME4 = readRecord.get_short("BOVERTIME4",null);
               
            OUT4 = readRecord.get_datetime("OUT4",null);
               
            DELAY4 = readRecord.get_short("DELAY4",null);
               
            NEEDOUT4 = readRecord.get_short("NEEDOUT4",null);
               
            EOVERTIME4 = readRecord.get_short("EOVERTIME4",null);
               
            REST4 = readRecord.get_short("REST4",null);
               
            REST_BEGIN4 = readRecord.get_datetime("REST_BEGIN4",null);
               
            BREAK4 = readRecord.get_short("BREAK4",null);
               
            OT4 = readRecord.get_short("OT4",null);
               
            EXT4 = readRecord.get_short("EXT4",null);
               
            CANOT4 = readRecord.get_short("CANOT4",null);
               
            OT_REST4 = readRecord.get_int("OT_REST4",null);
               
            OT_REST_BEGIN4 = readRecord.get_datetime("OT_REST_BEGIN4",null);
               
            BASICHRS4 = readRecord.get_decimal("BASICHRS4",null);
               
            NEEDHRS4 = readRecord.get_decimal("NEEDHRS4",null);
               
            DAY4 = readRecord.get_decimal("DAY4",null);
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

        public Shifts(Expression<Func<Shifts, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Shifts> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<Shifts> _repo;
            
            if(db.TestMode){
                Shifts.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Shifts>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Shifts> GetRepo(){
            return GetRepo("","");
        }
        
        public static Shifts SingleOrDefault(Expression<Func<Shifts, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Shifts single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Shifts SingleOrDefault(Expression<Func<Shifts, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Shifts single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Shifts, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Shifts, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Shifts> Find(Expression<Func<Shifts, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Shifts> Find(Expression<Func<Shifts, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Shifts> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Shifts> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Shifts> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Shifts> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Shifts> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Shifts> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "SHIFT_ID";
        }

        public object KeyValue()
        {
            return this.SHIFT_ID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
		
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

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Shifts)){
                Shifts compare=(Shifts)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.SHIFT_ID.ToString();
                    }

        public string DescriptorColumn() {
            return "SHIFT_ID";
        }
        public static string GetKeyColumn()
        {
            return "SHIFT_ID";
        }        
        public static string GetDescriptorColumn()
        {
            return "SHIFT_ID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _Id;
		/// <summary>
		/// 
		/// </summary>
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

        string _SHIFT_ID;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public string SHIFT_ID
        {
            get { return _SHIFT_ID; }
            set
            {
                if(_SHIFT_ID!=value || _isLoaded){
                    _SHIFT_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SHIFT_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SHIFT_NAME;
		/// <summary>
		/// 
		/// </summary>
        public string SHIFT_NAME
        {
            get { return _SHIFT_NAME; }
            set
            {
                if(_SHIFT_NAME!=value || _isLoaded){
                    _SHIFT_NAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SHIFT_NAME");
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

        int? _SHIFT_KIND;
		/// <summary>
		/// 
		/// </summary>
        public int? SHIFT_KIND
        {
            get { return _SHIFT_KIND; }
            set
            {
                if(_SHIFT_KIND!=value || _isLoaded){
                    _SHIFT_KIND=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SHIFT_KIND");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _WORK_HRS;
		/// <summary>
		/// 
		/// </summary>
        public decimal? WORK_HRS
        {
            get { return _WORK_HRS; }
            set
            {
                if(_WORK_HRS!=value || _isLoaded){
                    _WORK_HRS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="WORK_HRS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _NEED_HRS;
		/// <summary>
		/// 
		/// </summary>
        public decimal? NEED_HRS
        {
            get { return _NEED_HRS; }
            set
            {
                if(_NEED_HRS!=value || _isLoaded){
                    _NEED_HRS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEED_HRS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short _IS_DEFAULT;
		/// <summary>
		/// 
		/// </summary>
        public short IS_DEFAULT
        {
            get { return _IS_DEFAULT; }
            set
            {
                if(_IS_DEFAULT!=value || _isLoaded){
                    _IS_DEFAULT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IS_DEFAULT");
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

        int? _CLASS_ID;
		/// <summary>
		/// 
		/// </summary>
        public int? CLASS_ID
        {
            get { return _CLASS_ID; }
            set
            {
                if(_CLASS_ID!=value || _isLoaded){
                    _CLASS_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CLASS_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _NEED_SIGN_COUNT;
		/// <summary>
		/// 
		/// </summary>
        public int? NEED_SIGN_COUNT
        {
            get { return _NEED_SIGN_COUNT; }
            set
            {
                if(_NEED_SIGN_COUNT!=value || _isLoaded){
                    _NEED_SIGN_COUNT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEED_SIGN_COUNT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _IS_COMMON;
		/// <summary>
		/// 
		/// </summary>
        public short? IS_COMMON
        {
            get { return _IS_COMMON; }
            set
            {
                if(_IS_COMMON!=value || _isLoaded){
                    _IS_COMMON=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IS_COMMON");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AHEAD1;
		/// <summary>
		/// 
		/// </summary>
        public int? AHEAD1
        {
            get { return _AHEAD1; }
            set
            {
                if(_AHEAD1!=value || _isLoaded){
                    _AHEAD1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AHEAD1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _IN1;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? IN1
        {
            get { return _IN1; }
            set
            {
                if(_IN1!=value || _isLoaded){
                    _IN1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IN1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDIN1;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDIN1
        {
            get { return _NEEDIN1; }
            set
            {
                if(_NEEDIN1!=value || _isLoaded){
                    _NEEDIN1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDIN1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BOVERTIME1;
		/// <summary>
		/// 
		/// </summary>
        public short? BOVERTIME1
        {
            get { return _BOVERTIME1; }
            set
            {
                if(_BOVERTIME1!=value || _isLoaded){
                    _BOVERTIME1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BOVERTIME1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OUT1;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OUT1
        {
            get { return _OUT1; }
            set
            {
                if(_OUT1!=value || _isLoaded){
                    _OUT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OUT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _DELAY1;
		/// <summary>
		/// 
		/// </summary>
        public short? DELAY1
        {
            get { return _DELAY1; }
            set
            {
                if(_DELAY1!=value || _isLoaded){
                    _DELAY1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DELAY1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDOUT1;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDOUT1
        {
            get { return _NEEDOUT1; }
            set
            {
                if(_NEEDOUT1!=value || _isLoaded){
                    _NEEDOUT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDOUT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EOVERTIME1;
		/// <summary>
		/// 
		/// </summary>
        public short? EOVERTIME1
        {
            get { return _EOVERTIME1; }
            set
            {
                if(_EOVERTIME1!=value || _isLoaded){
                    _EOVERTIME1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EOVERTIME1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _REST1;
		/// <summary>
		/// 
		/// </summary>
        public short? REST1
        {
            get { return _REST1; }
            set
            {
                if(_REST1!=value || _isLoaded){
                    _REST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _REST_BEGIN1;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? REST_BEGIN1
        {
            get { return _REST_BEGIN1; }
            set
            {
                if(_REST_BEGIN1!=value || _isLoaded){
                    _REST_BEGIN1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST_BEGIN1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BREAK1;
		/// <summary>
		/// 
		/// </summary>
        public short? BREAK1
        {
            get { return _BREAK1; }
            set
            {
                if(_BREAK1!=value || _isLoaded){
                    _BREAK1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BREAK1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _OT1;
		/// <summary>
		/// 
		/// </summary>
        public short? OT1
        {
            get { return _OT1; }
            set
            {
                if(_OT1!=value || _isLoaded){
                    _OT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EXT1;
		/// <summary>
		/// 
		/// </summary>
        public short? EXT1
        {
            get { return _EXT1; }
            set
            {
                if(_EXT1!=value || _isLoaded){
                    _EXT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _CANOT1;
		/// <summary>
		/// 
		/// </summary>
        public short? CANOT1
        {
            get { return _CANOT1; }
            set
            {
                if(_CANOT1!=value || _isLoaded){
                    _CANOT1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CANOT1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _OT_REST1;
		/// <summary>
		/// 
		/// </summary>
        public int? OT_REST1
        {
            get { return _OT_REST1; }
            set
            {
                if(_OT_REST1!=value || _isLoaded){
                    _OT_REST1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OT_REST_BEGIN1;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OT_REST_BEGIN1
        {
            get { return _OT_REST_BEGIN1; }
            set
            {
                if(_OT_REST_BEGIN1!=value || _isLoaded){
                    _OT_REST_BEGIN1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST_BEGIN1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _BASICHRS1;
		/// <summary>
		/// 
		/// </summary>
        public decimal? BASICHRS1
        {
            get { return _BASICHRS1; }
            set
            {
                if(_BASICHRS1!=value || _isLoaded){
                    _BASICHRS1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BASICHRS1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _NEEDHRS1;
		/// <summary>
		/// 
		/// </summary>
        public decimal? NEEDHRS1
        {
            get { return _NEEDHRS1; }
            set
            {
                if(_NEEDHRS1!=value || _isLoaded){
                    _NEEDHRS1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDHRS1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DAY1;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DAY1
        {
            get { return _DAY1; }
            set
            {
                if(_DAY1!=value || _isLoaded){
                    _DAY1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DAY1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AHEAD2;
		/// <summary>
		/// 
		/// </summary>
        public int? AHEAD2
        {
            get { return _AHEAD2; }
            set
            {
                if(_AHEAD2!=value || _isLoaded){
                    _AHEAD2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AHEAD2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _IN2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? IN2
        {
            get { return _IN2; }
            set
            {
                if(_IN2!=value || _isLoaded){
                    _IN2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IN2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDIN2;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDIN2
        {
            get { return _NEEDIN2; }
            set
            {
                if(_NEEDIN2!=value || _isLoaded){
                    _NEEDIN2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDIN2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BOVERTIME2;
		/// <summary>
		/// 
		/// </summary>
        public short? BOVERTIME2
        {
            get { return _BOVERTIME2; }
            set
            {
                if(_BOVERTIME2!=value || _isLoaded){
                    _BOVERTIME2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BOVERTIME2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OUT2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OUT2
        {
            get { return _OUT2; }
            set
            {
                if(_OUT2!=value || _isLoaded){
                    _OUT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OUT2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _DELAY2;
		/// <summary>
		/// 
		/// </summary>
        public short? DELAY2
        {
            get { return _DELAY2; }
            set
            {
                if(_DELAY2!=value || _isLoaded){
                    _DELAY2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DELAY2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDOUT2;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDOUT2
        {
            get { return _NEEDOUT2; }
            set
            {
                if(_NEEDOUT2!=value || _isLoaded){
                    _NEEDOUT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDOUT2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EOVERTIME2;
		/// <summary>
		/// 
		/// </summary>
        public short? EOVERTIME2
        {
            get { return _EOVERTIME2; }
            set
            {
                if(_EOVERTIME2!=value || _isLoaded){
                    _EOVERTIME2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EOVERTIME2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _REST2;
		/// <summary>
		/// 
		/// </summary>
        public short? REST2
        {
            get { return _REST2; }
            set
            {
                if(_REST2!=value || _isLoaded){
                    _REST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _REST_BEGIN2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? REST_BEGIN2
        {
            get { return _REST_BEGIN2; }
            set
            {
                if(_REST_BEGIN2!=value || _isLoaded){
                    _REST_BEGIN2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST_BEGIN2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BREAK2;
		/// <summary>
		/// 
		/// </summary>
        public short? BREAK2
        {
            get { return _BREAK2; }
            set
            {
                if(_BREAK2!=value || _isLoaded){
                    _BREAK2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BREAK2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _OT2;
		/// <summary>
		/// 
		/// </summary>
        public short? OT2
        {
            get { return _OT2; }
            set
            {
                if(_OT2!=value || _isLoaded){
                    _OT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EXT2;
		/// <summary>
		/// 
		/// </summary>
        public short? EXT2
        {
            get { return _EXT2; }
            set
            {
                if(_EXT2!=value || _isLoaded){
                    _EXT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXT2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _CANOT2;
		/// <summary>
		/// 
		/// </summary>
        public short? CANOT2
        {
            get { return _CANOT2; }
            set
            {
                if(_CANOT2!=value || _isLoaded){
                    _CANOT2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CANOT2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _OT_REST2;
		/// <summary>
		/// 
		/// </summary>
        public int? OT_REST2
        {
            get { return _OT_REST2; }
            set
            {
                if(_OT_REST2!=value || _isLoaded){
                    _OT_REST2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OT_REST_BEGIN2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OT_REST_BEGIN2
        {
            get { return _OT_REST_BEGIN2; }
            set
            {
                if(_OT_REST_BEGIN2!=value || _isLoaded){
                    _OT_REST_BEGIN2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST_BEGIN2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _BASICHRS2;
		/// <summary>
		/// 
		/// </summary>
        public decimal? BASICHRS2
        {
            get { return _BASICHRS2; }
            set
            {
                if(_BASICHRS2!=value || _isLoaded){
                    _BASICHRS2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BASICHRS2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _NEEDHRS2;
		/// <summary>
		/// 
		/// </summary>
        public decimal? NEEDHRS2
        {
            get { return _NEEDHRS2; }
            set
            {
                if(_NEEDHRS2!=value || _isLoaded){
                    _NEEDHRS2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDHRS2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DAY2;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DAY2
        {
            get { return _DAY2; }
            set
            {
                if(_DAY2!=value || _isLoaded){
                    _DAY2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DAY2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AHEAD3;
		/// <summary>
		/// 
		/// </summary>
        public int? AHEAD3
        {
            get { return _AHEAD3; }
            set
            {
                if(_AHEAD3!=value || _isLoaded){
                    _AHEAD3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AHEAD3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _IN3;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? IN3
        {
            get { return _IN3; }
            set
            {
                if(_IN3!=value || _isLoaded){
                    _IN3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IN3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDIN3;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDIN3
        {
            get { return _NEEDIN3; }
            set
            {
                if(_NEEDIN3!=value || _isLoaded){
                    _NEEDIN3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDIN3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BOVERTIME3;
		/// <summary>
		/// 
		/// </summary>
        public short? BOVERTIME3
        {
            get { return _BOVERTIME3; }
            set
            {
                if(_BOVERTIME3!=value || _isLoaded){
                    _BOVERTIME3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BOVERTIME3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OUT3;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OUT3
        {
            get { return _OUT3; }
            set
            {
                if(_OUT3!=value || _isLoaded){
                    _OUT3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OUT3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _DELAY3;
		/// <summary>
		/// 
		/// </summary>
        public short? DELAY3
        {
            get { return _DELAY3; }
            set
            {
                if(_DELAY3!=value || _isLoaded){
                    _DELAY3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DELAY3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDOUT3;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDOUT3
        {
            get { return _NEEDOUT3; }
            set
            {
                if(_NEEDOUT3!=value || _isLoaded){
                    _NEEDOUT3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDOUT3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EOVERTIME3;
		/// <summary>
		/// 
		/// </summary>
        public short? EOVERTIME3
        {
            get { return _EOVERTIME3; }
            set
            {
                if(_EOVERTIME3!=value || _isLoaded){
                    _EOVERTIME3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EOVERTIME3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _REST3;
		/// <summary>
		/// 
		/// </summary>
        public short? REST3
        {
            get { return _REST3; }
            set
            {
                if(_REST3!=value || _isLoaded){
                    _REST3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _REST_BEGIN3;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? REST_BEGIN3
        {
            get { return _REST_BEGIN3; }
            set
            {
                if(_REST_BEGIN3!=value || _isLoaded){
                    _REST_BEGIN3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST_BEGIN3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BREAK3;
		/// <summary>
		/// 
		/// </summary>
        public short? BREAK3
        {
            get { return _BREAK3; }
            set
            {
                if(_BREAK3!=value || _isLoaded){
                    _BREAK3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BREAK3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _OT3;
		/// <summary>
		/// 
		/// </summary>
        public short? OT3
        {
            get { return _OT3; }
            set
            {
                if(_OT3!=value || _isLoaded){
                    _OT3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EXT3;
		/// <summary>
		/// 
		/// </summary>
        public short? EXT3
        {
            get { return _EXT3; }
            set
            {
                if(_EXT3!=value || _isLoaded){
                    _EXT3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXT3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _CANOT3;
		/// <summary>
		/// 
		/// </summary>
        public short? CANOT3
        {
            get { return _CANOT3; }
            set
            {
                if(_CANOT3!=value || _isLoaded){
                    _CANOT3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CANOT3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _OT_REST3;
		/// <summary>
		/// 
		/// </summary>
        public int? OT_REST3
        {
            get { return _OT_REST3; }
            set
            {
                if(_OT_REST3!=value || _isLoaded){
                    _OT_REST3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OT_REST_BEGIN3;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OT_REST_BEGIN3
        {
            get { return _OT_REST_BEGIN3; }
            set
            {
                if(_OT_REST_BEGIN3!=value || _isLoaded){
                    _OT_REST_BEGIN3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST_BEGIN3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _BASICHRS3;
		/// <summary>
		/// 
		/// </summary>
        public decimal? BASICHRS3
        {
            get { return _BASICHRS3; }
            set
            {
                if(_BASICHRS3!=value || _isLoaded){
                    _BASICHRS3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BASICHRS3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _NEEDHRS3;
		/// <summary>
		/// 
		/// </summary>
        public decimal? NEEDHRS3
        {
            get { return _NEEDHRS3; }
            set
            {
                if(_NEEDHRS3!=value || _isLoaded){
                    _NEEDHRS3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDHRS3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DAY3;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DAY3
        {
            get { return _DAY3; }
            set
            {
                if(_DAY3!=value || _isLoaded){
                    _DAY3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DAY3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _AHEAD4;
		/// <summary>
		/// 
		/// </summary>
        public int? AHEAD4
        {
            get { return _AHEAD4; }
            set
            {
                if(_AHEAD4!=value || _isLoaded){
                    _AHEAD4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="AHEAD4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _IN4;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? IN4
        {
            get { return _IN4; }
            set
            {
                if(_IN4!=value || _isLoaded){
                    _IN4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IN4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDIN4;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDIN4
        {
            get { return _NEEDIN4; }
            set
            {
                if(_NEEDIN4!=value || _isLoaded){
                    _NEEDIN4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDIN4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BOVERTIME4;
		/// <summary>
		/// 
		/// </summary>
        public short? BOVERTIME4
        {
            get { return _BOVERTIME4; }
            set
            {
                if(_BOVERTIME4!=value || _isLoaded){
                    _BOVERTIME4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BOVERTIME4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OUT4;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OUT4
        {
            get { return _OUT4; }
            set
            {
                if(_OUT4!=value || _isLoaded){
                    _OUT4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OUT4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _DELAY4;
		/// <summary>
		/// 
		/// </summary>
        public short? DELAY4
        {
            get { return _DELAY4; }
            set
            {
                if(_DELAY4!=value || _isLoaded){
                    _DELAY4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DELAY4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _NEEDOUT4;
		/// <summary>
		/// 
		/// </summary>
        public short? NEEDOUT4
        {
            get { return _NEEDOUT4; }
            set
            {
                if(_NEEDOUT4!=value || _isLoaded){
                    _NEEDOUT4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDOUT4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EOVERTIME4;
		/// <summary>
		/// 
		/// </summary>
        public short? EOVERTIME4
        {
            get { return _EOVERTIME4; }
            set
            {
                if(_EOVERTIME4!=value || _isLoaded){
                    _EOVERTIME4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EOVERTIME4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _REST4;
		/// <summary>
		/// 
		/// </summary>
        public short? REST4
        {
            get { return _REST4; }
            set
            {
                if(_REST4!=value || _isLoaded){
                    _REST4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _REST_BEGIN4;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? REST_BEGIN4
        {
            get { return _REST_BEGIN4; }
            set
            {
                if(_REST_BEGIN4!=value || _isLoaded){
                    _REST_BEGIN4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="REST_BEGIN4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _BREAK4;
		/// <summary>
		/// 
		/// </summary>
        public short? BREAK4
        {
            get { return _BREAK4; }
            set
            {
                if(_BREAK4!=value || _isLoaded){
                    _BREAK4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BREAK4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _OT4;
		/// <summary>
		/// 
		/// </summary>
        public short? OT4
        {
            get { return _OT4; }
            set
            {
                if(_OT4!=value || _isLoaded){
                    _OT4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _EXT4;
		/// <summary>
		/// 
		/// </summary>
        public short? EXT4
        {
            get { return _EXT4; }
            set
            {
                if(_EXT4!=value || _isLoaded){
                    _EXT4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXT4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _CANOT4;
		/// <summary>
		/// 
		/// </summary>
        public short? CANOT4
        {
            get { return _CANOT4; }
            set
            {
                if(_CANOT4!=value || _isLoaded){
                    _CANOT4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CANOT4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _OT_REST4;
		/// <summary>
		/// 
		/// </summary>
        public int? OT_REST4
        {
            get { return _OT_REST4; }
            set
            {
                if(_OT_REST4!=value || _isLoaded){
                    _OT_REST4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OT_REST_BEGIN4;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? OT_REST_BEGIN4
        {
            get { return _OT_REST_BEGIN4; }
            set
            {
                if(_OT_REST_BEGIN4!=value || _isLoaded){
                    _OT_REST_BEGIN4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OT_REST_BEGIN4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _BASICHRS4;
		/// <summary>
		/// 
		/// </summary>
        public decimal? BASICHRS4
        {
            get { return _BASICHRS4; }
            set
            {
                if(_BASICHRS4!=value || _isLoaded){
                    _BASICHRS4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BASICHRS4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _NEEDHRS4;
		/// <summary>
		/// 
		/// </summary>
        public decimal? NEEDHRS4
        {
            get { return _NEEDHRS4; }
            set
            {
                if(_NEEDHRS4!=value || _isLoaded){
                    _NEEDHRS4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NEEDHRS4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DAY4;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DAY4
        {
            get { return _DAY4; }
            set
            {
                if(_DAY4!=value || _isLoaded){
                    _DAY4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DAY4");
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


        public static void Delete(Expression<Func<Shifts, bool>> expression) {
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

