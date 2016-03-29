 
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
    /// A class which represents the USERAUTHORITY table in the HKHR Database.
    /// </summary>
    public partial class USERAUTHORITY: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<USERAUTHORITY> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<USERAUTHORITY>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<USERAUTHORITY> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(USERAUTHORITY item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                USERAUTHORITY item=new USERAUTHORITY();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<USERAUTHORITY> _repo;
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
        public USERAUTHORITY(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                USERAUTHORITY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<USERAUTHORITY>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public USERAUTHORITY(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            GROUPS = readRecord.get_string("GROUPS",null);
               
            node = readRecord.get_string("node",null);
               
            ToolNo = readRecord.get_string("ToolNo",null);
               
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

        public USERAUTHORITY(Expression<Func<USERAUTHORITY, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<USERAUTHORITY> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<USERAUTHORITY> _repo;
            
            if(db.TestMode){
                USERAUTHORITY.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<USERAUTHORITY>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<USERAUTHORITY> GetRepo(){
            return GetRepo("","");
        }
        
        public static USERAUTHORITY SingleOrDefault(Expression<Func<USERAUTHORITY, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            USERAUTHORITY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static USERAUTHORITY SingleOrDefault(Expression<Func<USERAUTHORITY, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            USERAUTHORITY single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<USERAUTHORITY, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<USERAUTHORITY, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<USERAUTHORITY> Find(Expression<Func<USERAUTHORITY, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<USERAUTHORITY> Find(Expression<Func<USERAUTHORITY, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<USERAUTHORITY> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<USERAUTHORITY> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<USERAUTHORITY> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<USERAUTHORITY> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<USERAUTHORITY> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<USERAUTHORITY> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("GROUPS=" + GROUPS + "; ");
			sb.Append("node=" + node + "; ");
			sb.Append("ToolNo=" + ToolNo + "; ");
			sb.Append("TYPE=" + TYPE + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(USERAUTHORITY)){
                USERAUTHORITY compare=(USERAUTHORITY)obj;
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
                            return this.GROUPS.ToString();
                    }

        public string DescriptorColumn() {
            return "GROUPS";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "GROUPS";
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

        string _node;
		/// <summary>
		/// 
		/// </summary>
        public string node
        {
            get { return _node; }
            set
            {
                if(_node!=value || _isLoaded){
                    _node=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="node");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ToolNo;
		/// <summary>
		/// 
		/// </summary>
        public string ToolNo
        {
            get { return _ToolNo; }
            set
            {
                if(_ToolNo!=value || _isLoaded){
                    _ToolNo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ToolNo");
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


        public static void Delete(Expression<Func<USERAUTHORITY, bool>> expression) {
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

