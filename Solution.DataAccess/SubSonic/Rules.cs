 
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
    /// A class which represents the Rules table in the HRtest Database.
    /// </summary>
    public partial class Rules: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Rules> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Rules>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Rules> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Rules item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Rules item=new Rules();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Rules> _repo;
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
        public Rules(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Rules.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Rules>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Rules(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            rule_id = readRecord.get_string("rule_id",null);
               
            rule_name = readRecord.get_string("rule_name",null);
               
            rules = readRecord.get_string("rules",null);
               
            daysinmonth = readRecord.get_decimal("daysinmonth",null);
               
            hoursinday = readRecord.get_decimal("hoursinday",null);
               
            ot_rate = readRecord.get_decimal("ot_rate",null);
               
            sun_rate = readRecord.get_decimal("sun_rate",null);
               
            hd_rate = readRecord.get_decimal("hd_rate",null);
               
            restdatemethod = readRecord.get_short("restdatemethod",null);
               
            sun = readRecord.get_short("sun",null);
               
            sunbegin = readRecord.get_datetime("sunbegin",null);
               
            sunend = readRecord.get_datetime("sunend",null);
               
            sat = readRecord.get_short("sat",null);
               
            satbegin = readRecord.get_datetime("satbegin",null);
               
            satend = readRecord.get_datetime("satend",null);
               
            vrestdate = readRecord.get_string("vrestdate",null);
               
            vrestbegtime = readRecord.get_datetime("vrestbegtime",null);
               
            vrestendtime = readRecord.get_datetime("vrestendtime",null);
               
            memo = readRecord.get_string("memo",null);
               
            IsAllowances = readRecord.get_byte("IsAllowances",null);
               
            SatOutTime = readRecord.get_datetime("SatOutTime",null);
               
            MonInTime = readRecord.get_datetime("MonInTime",null);
               
            FriOutTime = readRecord.get_datetime("FriOutTime",null);
               
            HolInTime = readRecord.get_datetime("HolInTime",null);
               
            HolOutTime = readRecord.get_datetime("HolOutTime",null);
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

        public Rules(Expression<Func<Rules, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Rules> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<Rules> _repo;
            
            if(db.TestMode){
                Rules.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Rules>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Rules> GetRepo(){
            return GetRepo("","");
        }
        
        public static Rules SingleOrDefault(Expression<Func<Rules, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Rules single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Rules SingleOrDefault(Expression<Func<Rules, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Rules single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Rules, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Rules, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Rules> Find(Expression<Func<Rules, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Rules> Find(Expression<Func<Rules, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Rules> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Rules> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Rules> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Rules> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Rules> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Rules> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "rule_id";
        }

        public object KeyValue()
        {
            return this.rule_id;
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
			sb.Append("rule_id=" + rule_id + "; ");
			sb.Append("rule_name=" + rule_name + "; ");
			sb.Append("rules=" + rules + "; ");
			sb.Append("daysinmonth=" + daysinmonth + "; ");
			sb.Append("hoursinday=" + hoursinday + "; ");
			sb.Append("ot_rate=" + ot_rate + "; ");
			sb.Append("sun_rate=" + sun_rate + "; ");
			sb.Append("hd_rate=" + hd_rate + "; ");
			sb.Append("restdatemethod=" + restdatemethod + "; ");
			sb.Append("sun=" + sun + "; ");
			sb.Append("sunbegin=" + sunbegin + "; ");
			sb.Append("sunend=" + sunend + "; ");
			sb.Append("sat=" + sat + "; ");
			sb.Append("satbegin=" + satbegin + "; ");
			sb.Append("satend=" + satend + "; ");
			sb.Append("vrestdate=" + vrestdate + "; ");
			sb.Append("vrestbegtime=" + vrestbegtime + "; ");
			sb.Append("vrestendtime=" + vrestendtime + "; ");
			sb.Append("memo=" + memo + "; ");
			sb.Append("IsAllowances=" + IsAllowances + "; ");
			sb.Append("SatOutTime=" + SatOutTime + "; ");
			sb.Append("MonInTime=" + MonInTime + "; ");
			sb.Append("FriOutTime=" + FriOutTime + "; ");
			sb.Append("HolInTime=" + HolInTime + "; ");
			sb.Append("HolOutTime=" + HolOutTime + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Rules)){
                Rules compare=(Rules)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.rule_id.ToString();
                    }

        public string DescriptorColumn() {
            return "rule_id";
        }
        public static string GetKeyColumn()
        {
            return "rule_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "rule_id";
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

        string _rule_id;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public string rule_id
        {
            get { return _rule_id; }
            set
            {
                if(_rule_id!=value || _isLoaded){
                    _rule_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rule_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _rule_name;
		/// <summary>
		/// 
		/// </summary>
        public string rule_name
        {
            get { return _rule_name; }
            set
            {
                if(_rule_name!=value || _isLoaded){
                    _rule_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rule_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _rules;
		/// <summary>
		/// 
		/// </summary>
        public string rules
        {
            get { return _rules; }
            set
            {
                if(_rules!=value || _isLoaded){
                    _rules=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rules");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _daysinmonth;
		/// <summary>
		/// 
		/// </summary>
        public decimal daysinmonth
        {
            get { return _daysinmonth; }
            set
            {
                if(_daysinmonth!=value || _isLoaded){
                    _daysinmonth=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="daysinmonth");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _hoursinday;
		/// <summary>
		/// 
		/// </summary>
        public decimal hoursinday
        {
            get { return _hoursinday; }
            set
            {
                if(_hoursinday!=value || _isLoaded){
                    _hoursinday=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hoursinday");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_rate;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_rate
        {
            get { return _ot_rate; }
            set
            {
                if(_ot_rate!=value || _isLoaded){
                    _ot_rate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_rate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _sun_rate;
		/// <summary>
		/// 
		/// </summary>
        public decimal? sun_rate
        {
            get { return _sun_rate; }
            set
            {
                if(_sun_rate!=value || _isLoaded){
                    _sun_rate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sun_rate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _hd_rate;
		/// <summary>
		/// 
		/// </summary>
        public decimal? hd_rate
        {
            get { return _hd_rate; }
            set
            {
                if(_hd_rate!=value || _isLoaded){
                    _hd_rate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_rate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short _restdatemethod;
		/// <summary>
		/// 
		/// </summary>
        public short restdatemethod
        {
            get { return _restdatemethod; }
            set
            {
                if(_restdatemethod!=value || _isLoaded){
                    _restdatemethod=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="restdatemethod");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _sun;
		/// <summary>
		/// 
		/// </summary>
        public short? sun
        {
            get { return _sun; }
            set
            {
                if(_sun!=value || _isLoaded){
                    _sun=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sun");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _sunbegin;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? sunbegin
        {
            get { return _sunbegin; }
            set
            {
                if(_sunbegin!=value || _isLoaded){
                    _sunbegin=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sunbegin");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _sunend;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? sunend
        {
            get { return _sunend; }
            set
            {
                if(_sunend!=value || _isLoaded){
                    _sunend=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sunend");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _sat;
		/// <summary>
		/// 
		/// </summary>
        public short? sat
        {
            get { return _sat; }
            set
            {
                if(_sat!=value || _isLoaded){
                    _sat=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sat");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _satbegin;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? satbegin
        {
            get { return _satbegin; }
            set
            {
                if(_satbegin!=value || _isLoaded){
                    _satbegin=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="satbegin");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _satend;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? satend
        {
            get { return _satend; }
            set
            {
                if(_satend!=value || _isLoaded){
                    _satend=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="satend");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _vrestdate;
		/// <summary>
		/// 
		/// </summary>
        public string vrestdate
        {
            get { return _vrestdate; }
            set
            {
                if(_vrestdate!=value || _isLoaded){
                    _vrestdate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="vrestdate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _vrestbegtime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? vrestbegtime
        {
            get { return _vrestbegtime; }
            set
            {
                if(_vrestbegtime!=value || _isLoaded){
                    _vrestbegtime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="vrestbegtime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _vrestendtime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? vrestendtime
        {
            get { return _vrestendtime; }
            set
            {
                if(_vrestendtime!=value || _isLoaded){
                    _vrestendtime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="vrestendtime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _memo;
		/// <summary>
		/// 
		/// </summary>
        public string memo
        {
            get { return _memo; }
            set
            {
                if(_memo!=value || _isLoaded){
                    _memo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="memo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte _IsAllowances;
		/// <summary>
		/// 
		/// </summary>
        public byte IsAllowances
        {
            get { return _IsAllowances; }
            set
            {
                if(_IsAllowances!=value || _isLoaded){
                    _IsAllowances=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsAllowances");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _SatOutTime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? SatOutTime
        {
            get { return _SatOutTime; }
            set
            {
                if(_SatOutTime!=value || _isLoaded){
                    _SatOutTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SatOutTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _MonInTime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? MonInTime
        {
            get { return _MonInTime; }
            set
            {
                if(_MonInTime!=value || _isLoaded){
                    _MonInTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MonInTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _FriOutTime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? FriOutTime
        {
            get { return _FriOutTime; }
            set
            {
                if(_FriOutTime!=value || _isLoaded){
                    _FriOutTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FriOutTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _HolInTime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? HolInTime
        {
            get { return _HolInTime; }
            set
            {
                if(_HolInTime!=value || _isLoaded){
                    _HolInTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HolInTime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _HolOutTime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? HolOutTime
        {
            get { return _HolOutTime; }
            set
            {
                if(_HolOutTime!=value || _isLoaded){
                    _HolOutTime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HolOutTime");
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


        public static void Delete(Expression<Func<Rules, bool>> expression) {
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

