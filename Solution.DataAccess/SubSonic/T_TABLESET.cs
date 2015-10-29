 
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
    /// A class which represents the T_TABLESET table in the HRtest Database.
    /// </summary>
    public partial class T_TABLESET: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<T_TABLESET> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<T_TABLESET>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<T_TABLESET> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(T_TABLESET item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                T_TABLESET item=new T_TABLESET();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<T_TABLESET> _repo;
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
        public T_TABLESET(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                T_TABLESET.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<T_TABLESET>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public T_TABLESET(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            CODE = readRecord.get_string("CODE",null);
               
            NAMEE = readRecord.get_string("NAMEE",null);
               
            NAMEC = readRecord.get_string("NAMEC",null);
               
            DATAEA = readRecord.get_string("DATAEA",null);
               
            NOTES = readRecord.get_string("NOTES",null);
               
            RECORD_BY = readRecord.get_string("RECORD_BY",null);
               
            RECORD_DATE = readRecord.get_datetime("RECORD_DATE",null);
               
            EDIT_BY = readRecord.get_string("EDIT_BY",null);
               
            EDIT_DATE = readRecord.get_datetime("EDIT_DATE",null);
               
            SYSDIV = readRecord.get_string("SYSDIV",null);
               
            STATURS = readRecord.get_string("STATURS",null);
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

        public T_TABLESET(Expression<Func<T_TABLESET, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<T_TABLESET> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<T_TABLESET> _repo;
            
            if(db.TestMode){
                T_TABLESET.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<T_TABLESET>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<T_TABLESET> GetRepo(){
            return GetRepo("","");
        }
        
        public static T_TABLESET SingleOrDefault(Expression<Func<T_TABLESET, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            T_TABLESET single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static T_TABLESET SingleOrDefault(Expression<Func<T_TABLESET, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            T_TABLESET single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<T_TABLESET, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<T_TABLESET, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<T_TABLESET> Find(Expression<Func<T_TABLESET, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<T_TABLESET> Find(Expression<Func<T_TABLESET, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<T_TABLESET> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<T_TABLESET> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<T_TABLESET> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<T_TABLESET> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<T_TABLESET> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<T_TABLESET> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CODE";
        }

        public object KeyValue()
        {
            return this.CODE;
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
			sb.Append("CODE=" + CODE + "; ");
			sb.Append("NAMEE=" + NAMEE + "; ");
			sb.Append("NAMEC=" + NAMEC + "; ");
			sb.Append("DATAEA=" + DATAEA + "; ");
			sb.Append("NOTES=" + NOTES + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			sb.Append("SYSDIV=" + SYSDIV + "; ");
			sb.Append("STATURS=" + STATURS + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(T_TABLESET)){
                T_TABLESET compare=(T_TABLESET)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.CODE.ToString();
                    }

        public string DescriptorColumn() {
            return "CODE";
        }
        public static string GetKeyColumn()
        {
            return "CODE";
        }        
        public static string GetDescriptorColumn()
        {
            return "CODE";
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

        string _CODE;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public string CODE
        {
            get { return _CODE; }
            set
            {
                if(_CODE!=value || _isLoaded){
                    _CODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _NAMEE;
		/// <summary>
		/// 
		/// </summary>
        public string NAMEE
        {
            get { return _NAMEE; }
            set
            {
                if(_NAMEE!=value || _isLoaded){
                    _NAMEE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NAMEE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _NAMEC;
		/// <summary>
		/// 
		/// </summary>
        public string NAMEC
        {
            get { return _NAMEC; }
            set
            {
                if(_NAMEC!=value || _isLoaded){
                    _NAMEC=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NAMEC");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DATAEA;
		/// <summary>
		/// 
		/// </summary>
        public string DATAEA
        {
            get { return _DATAEA; }
            set
            {
                if(_DATAEA!=value || _isLoaded){
                    _DATAEA=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAEA");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _NOTES;
		/// <summary>
		/// 
		/// </summary>
        public string NOTES
        {
            get { return _NOTES; }
            set
            {
                if(_NOTES!=value || _isLoaded){
                    _NOTES=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NOTES");
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

        string _SYSDIV;
		/// <summary>
		/// 
		/// </summary>
        public string SYSDIV
        {
            get { return _SYSDIV; }
            set
            {
                if(_SYSDIV!=value || _isLoaded){
                    _SYSDIV=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SYSDIV");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _STATURS;
		/// <summary>
		/// 
		/// </summary>
        public string STATURS
        {
            get { return _STATURS; }
            set
            {
                if(_STATURS!=value || _isLoaded){
                    _STATURS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STATURS");
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


        public static void Delete(Expression<Func<T_TABLESET, bool>> expression) {
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

