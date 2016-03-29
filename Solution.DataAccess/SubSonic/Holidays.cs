 
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
    /// A class which represents the Holidays table in the HKHR Database.
    /// </summary>
    public partial class Holidays: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Holidays> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Holidays>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Holidays> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Holidays item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Holidays item=new Holidays();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Holidays> _repo;
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
        public Holidays(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Holidays.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Holidays>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Holidays(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            hd_code = readRecord.get_string("hd_code",null);
               
            hd_name = readRecord.get_string("hd_name",null);
               
            hd_date = readRecord.get_datetime("hd_date",null);
               
            hd_end = readRecord.get_datetime("hd_end",null);
               
            begin_time = readRecord.get_datetime("begin_time",null);
               
            end_time = readRecord.get_datetime("end_time",null);
               
            hd_rate = readRecord.get_decimal("hd_rate",null);
               
            hd_type = readRecord.get_string("hd_type",null);
               
            hd_kind = readRecord.get_int("hd_kind",null);
               
            depart_id = readRecord.get_string("depart_id",null);
               
            alway_use = readRecord.get_short("alway_use",null);
               
            sub_depart = readRecord.get_short("sub_depart",null);
               
            need_write = readRecord.get_short("need_write",null);
               
            have_hrs = readRecord.get_short("have_hrs",null);
               
            memo = readRecord.get_string("memo",null);
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

        public Holidays(Expression<Func<Holidays, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Holidays> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<Holidays> _repo;
            
            if(db.TestMode){
                Holidays.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Holidays>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Holidays> GetRepo(){
            return GetRepo("","");
        }
        
        public static Holidays SingleOrDefault(Expression<Func<Holidays, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Holidays single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Holidays SingleOrDefault(Expression<Func<Holidays, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Holidays single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Holidays, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Holidays, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Holidays> Find(Expression<Func<Holidays, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Holidays> Find(Expression<Func<Holidays, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Holidays> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Holidays> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Holidays> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Holidays> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Holidays> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Holidays> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("hd_code=" + hd_code + "; ");
			sb.Append("hd_name=" + hd_name + "; ");
			sb.Append("hd_date=" + hd_date + "; ");
			sb.Append("hd_end=" + hd_end + "; ");
			sb.Append("begin_time=" + begin_time + "; ");
			sb.Append("end_time=" + end_time + "; ");
			sb.Append("hd_rate=" + hd_rate + "; ");
			sb.Append("hd_type=" + hd_type + "; ");
			sb.Append("hd_kind=" + hd_kind + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("alway_use=" + alway_use + "; ");
			sb.Append("sub_depart=" + sub_depart + "; ");
			sb.Append("need_write=" + need_write + "; ");
			sb.Append("have_hrs=" + have_hrs + "; ");
			sb.Append("memo=" + memo + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Holidays)){
                Holidays compare=(Holidays)obj;
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
                            return this.hd_code.ToString();
                    }

        public string DescriptorColumn() {
            return "hd_code";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "hd_code";
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

        string _hd_code;
		/// <summary>
		/// 
		/// </summary>
        public string hd_code
        {
            get { return _hd_code; }
            set
            {
                if(_hd_code!=value || _isLoaded){
                    _hd_code=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_code");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _hd_name;
		/// <summary>
		/// 
		/// </summary>
        public string hd_name
        {
            get { return _hd_name; }
            set
            {
                if(_hd_name!=value || _isLoaded){
                    _hd_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _hd_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime hd_date
        {
            get { return _hd_date; }
            set
            {
                if(_hd_date!=value || _isLoaded){
                    _hd_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _hd_end;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? hd_end
        {
            get { return _hd_end; }
            set
            {
                if(_hd_end!=value || _isLoaded){
                    _hd_end=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_end");
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

        string _hd_type;
		/// <summary>
		/// 
		/// </summary>
        public string hd_type
        {
            get { return _hd_type; }
            set
            {
                if(_hd_type!=value || _isLoaded){
                    _hd_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _hd_kind;
		/// <summary>
		/// 
		/// </summary>
        public int? hd_kind
        {
            get { return _hd_kind; }
            set
            {
                if(_hd_kind!=value || _isLoaded){
                    _hd_kind=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_kind");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _depart_id;
		/// <summary>
		/// 
		/// </summary>
        public string depart_id
        {
            get { return _depart_id; }
            set
            {
                if(_depart_id!=value || _isLoaded){
                    _depart_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="depart_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short _alway_use;
		/// <summary>
		/// 
		/// </summary>
        public short alway_use
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

        short _sub_depart;
		/// <summary>
		/// 
		/// </summary>
        public short sub_depart
        {
            get { return _sub_depart; }
            set
            {
                if(_sub_depart!=value || _isLoaded){
                    _sub_depart=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sub_depart");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _need_write;
		/// <summary>
		/// 
		/// </summary>
        public short? need_write
        {
            get { return _need_write; }
            set
            {
                if(_need_write!=value || _isLoaded){
                    _need_write=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="need_write");
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


        public static void Delete(Expression<Func<Holidays, bool>> expression) {
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

