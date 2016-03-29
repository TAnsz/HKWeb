 
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
    /// A class which represents the adJustRest_D table in the HKHR Database.
    /// </summary>
    public partial class adJustRest_D: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<adJustRest_D> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<adJustRest_D>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<adJustRest_D> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(adJustRest_D item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                adJustRest_D item=new adJustRest_D();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<adJustRest_D> _repo;
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
        public adJustRest_D(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                adJustRest_D.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<adJustRest_D>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public adJustRest_D(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            bill_id = readRecord.get_string("bill_id",null);
               
            emp_id = readRecord.get_string("emp_id",null);
               
            join_id = readRecord.get_int("join_id",null);
               
            depart_id = readRecord.get_string("depart_id",null);
               
            ori_date = readRecord.get_datetime("ori_date",null);
               
            ori_btime = readRecord.get_datetime("ori_btime",null);
               
            ori_etime = readRecord.get_datetime("ori_etime",null);
               
            rest_date = readRecord.get_datetime("rest_date",null);
               
            rest_btime = readRecord.get_datetime("rest_btime",null);
               
            rest_etime = readRecord.get_datetime("rest_etime",null);
               
            checker = readRecord.get_string("checker",null);
               
            check_date = readRecord.get_datetime("check_date",null);
               
            op_user = readRecord.get_string("op_user",null);
               
            op_date = readRecord.get_datetime("op_date",null);
               
            audit = readRecord.get_short("audit",null);
               
            memo = readRecord.get_string("memo",null);
               
            all_day = readRecord.get_short("all_day",null);
               
            kind = readRecord.get_string("kind",null);
               
            refuse_reason = readRecord.get_string("refuse_reason",null);
               
            CHECKER2 = readRecord.get_string("CHECKER2",null);
               
            audit2 = readRecord.get_short("audit2",null);
               
            check_date2 = readRecord.get_datetime("check_date2",null);
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

        public adJustRest_D(Expression<Func<adJustRest_D, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<adJustRest_D> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<adJustRest_D> _repo;
            
            if(db.TestMode){
                adJustRest_D.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<adJustRest_D>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<adJustRest_D> GetRepo(){
            return GetRepo("","");
        }
        
        public static adJustRest_D SingleOrDefault(Expression<Func<adJustRest_D, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            adJustRest_D single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static adJustRest_D SingleOrDefault(Expression<Func<adJustRest_D, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            adJustRest_D single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<adJustRest_D, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<adJustRest_D, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<adJustRest_D> Find(Expression<Func<adJustRest_D, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<adJustRest_D> Find(Expression<Func<adJustRest_D, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<adJustRest_D> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<adJustRest_D> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<adJustRest_D> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<adJustRest_D> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<adJustRest_D> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<adJustRest_D> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("bill_id=" + bill_id + "; ");
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("ori_date=" + ori_date + "; ");
			sb.Append("ori_btime=" + ori_btime + "; ");
			sb.Append("ori_etime=" + ori_etime + "; ");
			sb.Append("rest_date=" + rest_date + "; ");
			sb.Append("rest_btime=" + rest_btime + "; ");
			sb.Append("rest_etime=" + rest_etime + "; ");
			sb.Append("checker=" + checker + "; ");
			sb.Append("check_date=" + check_date + "; ");
			sb.Append("op_user=" + op_user + "; ");
			sb.Append("op_date=" + op_date + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("memo=" + memo + "; ");
			sb.Append("all_day=" + all_day + "; ");
			sb.Append("kind=" + kind + "; ");
			sb.Append("refuse_reason=" + refuse_reason + "; ");
			sb.Append("CHECKER2=" + CHECKER2 + "; ");
			sb.Append("audit2=" + audit2 + "; ");
			sb.Append("check_date2=" + check_date2 + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(adJustRest_D)){
                adJustRest_D compare=(adJustRest_D)obj;
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
                            return this.bill_id.ToString();
                    }

        public string DescriptorColumn() {
            return "bill_id";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "bill_id";
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

        string _bill_id;
		/// <summary>
		/// 
		/// </summary>
        public string bill_id
        {
            get { return _bill_id; }
            set
            {
                if(_bill_id!=value || _isLoaded){
                    _bill_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="bill_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _emp_id;
		/// <summary>
		/// 
		/// </summary>
        public string emp_id
        {
            get { return _emp_id; }
            set
            {
                if(_emp_id!=value || _isLoaded){
                    _emp_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="emp_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _join_id;
		/// <summary>
		/// 
		/// </summary>
        public int join_id
        {
            get { return _join_id; }
            set
            {
                if(_join_id!=value || _isLoaded){
                    _join_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="join_id");
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

        DateTime? _ori_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? ori_date
        {
            get { return _ori_date; }
            set
            {
                if(_ori_date!=value || _isLoaded){
                    _ori_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ori_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ori_btime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? ori_btime
        {
            get { return _ori_btime; }
            set
            {
                if(_ori_btime!=value || _isLoaded){
                    _ori_btime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ori_btime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ori_etime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? ori_etime
        {
            get { return _ori_etime; }
            set
            {
                if(_ori_etime!=value || _isLoaded){
                    _ori_etime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ori_etime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime _rest_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime rest_date
        {
            get { return _rest_date; }
            set
            {
                if(_rest_date!=value || _isLoaded){
                    _rest_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rest_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _rest_btime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? rest_btime
        {
            get { return _rest_btime; }
            set
            {
                if(_rest_btime!=value || _isLoaded){
                    _rest_btime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rest_btime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _rest_etime;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? rest_etime
        {
            get { return _rest_etime; }
            set
            {
                if(_rest_etime!=value || _isLoaded){
                    _rest_etime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rest_etime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _checker;
		/// <summary>
		/// 
		/// </summary>
        public string checker
        {
            get { return _checker; }
            set
            {
                if(_checker!=value || _isLoaded){
                    _checker=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="checker");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _check_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? check_date
        {
            get { return _check_date; }
            set
            {
                if(_check_date!=value || _isLoaded){
                    _check_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="check_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _op_user;
		/// <summary>
		/// 
		/// </summary>
        public string op_user
        {
            get { return _op_user; }
            set
            {
                if(_op_user!=value || _isLoaded){
                    _op_user=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="op_user");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _op_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? op_date
        {
            get { return _op_date; }
            set
            {
                if(_op_date!=value || _isLoaded){
                    _op_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="op_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _audit;
		/// <summary>
		/// 
		/// </summary>
        public short? audit
        {
            get { return _audit; }
            set
            {
                if(_audit!=value || _isLoaded){
                    _audit=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="audit");
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

        short? _all_day;
		/// <summary>
		/// 
		/// </summary>
        public short? all_day
        {
            get { return _all_day; }
            set
            {
                if(_all_day!=value || _isLoaded){
                    _all_day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="all_day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _kind;
		/// <summary>
		/// 
		/// </summary>
        public string kind
        {
            get { return _kind; }
            set
            {
                if(_kind!=value || _isLoaded){
                    _kind=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="kind");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _refuse_reason;
		/// <summary>
		/// 
		/// </summary>
        public string refuse_reason
        {
            get { return _refuse_reason; }
            set
            {
                if(_refuse_reason!=value || _isLoaded){
                    _refuse_reason=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="refuse_reason");
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

        short? _audit2;
		/// <summary>
		/// 
		/// </summary>
        public short? audit2
        {
            get { return _audit2; }
            set
            {
                if(_audit2!=value || _isLoaded){
                    _audit2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="audit2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _check_date2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? check_date2
        {
            get { return _check_date2; }
            set
            {
                if(_check_date2!=value || _isLoaded){
                    _check_date2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="check_date2");
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


        public static void Delete(Expression<Func<adJustRest_D, bool>> expression) {
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

