 
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
    /// A class which represents the USERAUTHORITY_REPORT table in the HKHR Database.
    /// </summary>
    public partial class USERAUTHORITY_REPORT: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<USERAUTHORITY_REPORT> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<USERAUTHORITY_REPORT>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<USERAUTHORITY_REPORT> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(USERAUTHORITY_REPORT item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                USERAUTHORITY_REPORT item=new USERAUTHORITY_REPORT();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<USERAUTHORITY_REPORT> _repo;
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
        public USERAUTHORITY_REPORT(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                USERAUTHORITY_REPORT.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<USERAUTHORITY_REPORT>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public USERAUTHORITY_REPORT(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            emp_id = readRecord.get_string("emp_id",null);
               
            node_id = readRecord.get_string("node_id",null);
               
            TYPE = readRecord.get_string("TYPE",null);
               
            RECORD_BY = readRecord.get_string("RECORD_BY",null);
               
            RECORD_DATE = readRecord.get_datetime("RECORD_DATE",null);
               
            EDIT_BY = readRecord.get_string("EDIT_BY",null);
               
            EDIT_DATE = readRecord.get_datetime("EDIT_DATE",null);
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

        public USERAUTHORITY_REPORT(Expression<Func<USERAUTHORITY_REPORT, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<USERAUTHORITY_REPORT> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<USERAUTHORITY_REPORT> _repo;
            
            if(db.TestMode){
                USERAUTHORITY_REPORT.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<USERAUTHORITY_REPORT>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<USERAUTHORITY_REPORT> GetRepo(){
            return GetRepo("","");
        }
        
        public static USERAUTHORITY_REPORT SingleOrDefault(Expression<Func<USERAUTHORITY_REPORT, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            USERAUTHORITY_REPORT single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static USERAUTHORITY_REPORT SingleOrDefault(Expression<Func<USERAUTHORITY_REPORT, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            USERAUTHORITY_REPORT single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<USERAUTHORITY_REPORT, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<USERAUTHORITY_REPORT, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<USERAUTHORITY_REPORT> Find(Expression<Func<USERAUTHORITY_REPORT, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<USERAUTHORITY_REPORT> Find(Expression<Func<USERAUTHORITY_REPORT, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<USERAUTHORITY_REPORT> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<USERAUTHORITY_REPORT> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<USERAUTHORITY_REPORT> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<USERAUTHORITY_REPORT> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<USERAUTHORITY_REPORT> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<USERAUTHORITY_REPORT> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("node_id=" + node_id + "; ");
			sb.Append("TYPE=" + TYPE + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(USERAUTHORITY_REPORT)){
                USERAUTHORITY_REPORT compare=(USERAUTHORITY_REPORT)obj;
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
                            return this.emp_id.ToString();
                    }

        public string DescriptorColumn() {
            return "emp_id";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "emp_id";
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

        string _node_id;
		/// <summary>
		/// 
		/// </summary>
        public string node_id
        {
            get { return _node_id; }
            set
            {
                if(_node_id!=value || _isLoaded){
                    _node_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="node_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TYPE;
		/// <summary>
		/// 
		/// </summary>
        public string TYPE
        {
            get { return _TYPE; }
            set
            {
                if(_TYPE!=value || _isLoaded){
                    _TYPE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TYPE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RECORD_BY;
		/// <summary>
		/// 
		/// </summary>
        public string RECORD_BY
        {
            get { return _RECORD_BY; }
            set
            {
                if(_RECORD_BY!=value || _isLoaded){
                    _RECORD_BY=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RECORD_BY");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _RECORD_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? RECORD_DATE
        {
            get { return _RECORD_DATE; }
            set
            {
                if(_RECORD_DATE!=value || _isLoaded){
                    _RECORD_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RECORD_DATE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _EDIT_BY;
		/// <summary>
		/// 
		/// </summary>
        public string EDIT_BY
        {
            get { return _EDIT_BY; }
            set
            {
                if(_EDIT_BY!=value || _isLoaded){
                    _EDIT_BY=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EDIT_BY");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _EDIT_DATE;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? EDIT_DATE
        {
            get { return _EDIT_DATE; }
            set
            {
                if(_EDIT_DATE!=value || _isLoaded){
                    _EDIT_DATE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EDIT_DATE");
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


        public static void Delete(Expression<Func<USERAUTHORITY_REPORT, bool>> expression) {
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

