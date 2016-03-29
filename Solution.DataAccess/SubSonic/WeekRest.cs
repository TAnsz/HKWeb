 
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
    /// A class which represents the WeekRest table in the HKHR Database.
    /// </summary>
    public partial class WeekRest: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<WeekRest> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<WeekRest>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<WeekRest> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(WeekRest item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                WeekRest item=new WeekRest();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<WeekRest> _repo;
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

        Solution.DataAccess.DataModel.HKHRDB _db;
        public WeekRest(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                WeekRest.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WeekRest>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public WeekRest(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            wr_code = readRecord.get_string("wr_code",null);
               
            wr_name = readRecord.get_string("wr_name",null);
               
            wr_date = readRecord.get_datetime("wr_date",null);
               
            wr_end = readRecord.get_datetime("wr_end",null);
               
            begin_time = readRecord.get_datetime("begin_time",null);
               
            end_time = readRecord.get_datetime("end_time",null);
               
            wr_rate = readRecord.get_decimal("wr_rate",null);
               
            wr_kind = readRecord.get_int("wr_kind",null);
               
            alway_use = readRecord.get_short("alway_use",null);
               
            have_hrs = readRecord.get_short("have_hrs",null);
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

        public WeekRest(Expression<Func<WeekRest, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<WeekRest> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<WeekRest> _repo;
            
            if(db.TestMode){
                WeekRest.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<WeekRest>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<WeekRest> GetRepo(){
            return GetRepo("","");
        }
        
        public static WeekRest SingleOrDefault(Expression<Func<WeekRest, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            WeekRest single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static WeekRest SingleOrDefault(Expression<Func<WeekRest, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            WeekRest single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<WeekRest, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<WeekRest, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<WeekRest> Find(Expression<Func<WeekRest, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<WeekRest> Find(Expression<Func<WeekRest, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<WeekRest> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<WeekRest> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<WeekRest> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<WeekRest> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<WeekRest> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<WeekRest> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("wr_code=" + wr_code + "; ");
			sb.Append("wr_name=" + wr_name + "; ");
			sb.Append("wr_date=" + wr_date + "; ");
			sb.Append("wr_end=" + wr_end + "; ");
			sb.Append("begin_time=" + begin_time + "; ");
			sb.Append("end_time=" + end_time + "; ");
			sb.Append("wr_rate=" + wr_rate + "; ");
			sb.Append("wr_kind=" + wr_kind + "; ");
			sb.Append("alway_use=" + alway_use + "; ");
			sb.Append("have_hrs=" + have_hrs + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(WeekRest)){
                WeekRest compare=(WeekRest)obj;
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
                            return this.wr_code.ToString();
                    }

        public string DescriptorColumn() {
            return "wr_code";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "wr_code";
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

        string _wr_code;
		/// <summary>
		/// 
		/// </summary>
        public string wr_code
        {
            get { return _wr_code; }
            set
            {
                if(_wr_code!=value || _isLoaded){
                    _wr_code=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="wr_code");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _wr_name;
		/// <summary>
		/// 
		/// </summary>
        public string wr_name
        {
            get { return _wr_name; }
            set
            {
                if(_wr_name!=value || _isLoaded){
                    _wr_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="wr_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _wr_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime wr_date
        {
            get { return _wr_date; }
            set
            {
                if(_wr_date!=value || _isLoaded){
                    _wr_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="wr_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _wr_end;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? wr_end
        {
            get { return _wr_end; }
            set
            {
                if(_wr_end!=value || _isLoaded){
                    _wr_end=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="wr_end");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _begin_time;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? begin_time
        {
            get { return _begin_time; }
            set
            {
                if(_begin_time!=value || _isLoaded){
                    _begin_time=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="begin_time");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _end_time;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? end_time
        {
            get { return _end_time; }
            set
            {
                if(_end_time!=value || _isLoaded){
                    _end_time=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="end_time");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _wr_rate;
		/// <summary>
		/// 
		/// </summary>
        public decimal? wr_rate
        {
            get { return _wr_rate; }
            set
            {
                if(_wr_rate!=value || _isLoaded){
                    _wr_rate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="wr_rate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _wr_kind;
		/// <summary>
		/// 
		/// </summary>
        public int? wr_kind
        {
            get { return _wr_kind; }
            set
            {
                if(_wr_kind!=value || _isLoaded){
                    _wr_kind=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="wr_kind");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _alway_use;
		/// <summary>
		/// 
		/// </summary>
        public short? alway_use
        {
            get { return _alway_use; }
            set
            {
                if(_alway_use!=value || _isLoaded){
                    _alway_use=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="alway_use");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _have_hrs;
		/// <summary>
		/// 
		/// </summary>
        public short? have_hrs
        {
            get { return _have_hrs; }
            set
            {
                if(_have_hrs!=value || _isLoaded){
                    _have_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="have_hrs");
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


        public static void Delete(Expression<Func<WeekRest, bool>> expression) {
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

