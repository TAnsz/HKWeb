 
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
    /// A class which represents the MAIN_LIST table in the HRtest Database.
    /// </summary>
    public partial class MAIN_LIST: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<MAIN_LIST> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<MAIN_LIST>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<MAIN_LIST> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(MAIN_LIST item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                MAIN_LIST item=new MAIN_LIST();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<MAIN_LIST> _repo;
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
        public MAIN_LIST(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                MAIN_LIST.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MAIN_LIST>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public MAIN_LIST(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            PARENTNODE = readRecord.get_int("PARENTNODE",null);
               
            NODE = readRecord.get_int("NODE",null);
               
            DISPLAYTEXT = readRecord.get_string("DISPLAYTEXT",null);
               
            TABTEXT = readRecord.get_string("TABTEXT",null);
               
            CLASSNAME = readRecord.get_string("CLASSNAME",null);
               
            STATICCLASS = readRecord.get_int("STATICCLASS",null);
               
            SORTORDER = readRecord.get_int("SORTORDER",null);
               
            PICTUREINDEX = readRecord.get_string("PICTUREINDEX",null);
               
            SELECTEDPICTUREINDEX = readRecord.get_string("SELECTEDPICTUREINDEX",null);
               
            EXPANDED = readRecord.get_int("EXPANDED",null);
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

        public MAIN_LIST(Expression<Func<MAIN_LIST, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<MAIN_LIST> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<MAIN_LIST> _repo;
            
            if(db.TestMode){
                MAIN_LIST.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MAIN_LIST>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<MAIN_LIST> GetRepo(){
            return GetRepo("","");
        }
        
        public static MAIN_LIST SingleOrDefault(Expression<Func<MAIN_LIST, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            MAIN_LIST single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static MAIN_LIST SingleOrDefault(Expression<Func<MAIN_LIST, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            MAIN_LIST single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<MAIN_LIST, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<MAIN_LIST, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<MAIN_LIST> Find(Expression<Func<MAIN_LIST, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<MAIN_LIST> Find(Expression<Func<MAIN_LIST, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<MAIN_LIST> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<MAIN_LIST> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<MAIN_LIST> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<MAIN_LIST> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<MAIN_LIST> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<MAIN_LIST> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "NODE";
        }

        public object KeyValue()
        {
            return this.NODE;
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
			sb.Append("PARENTNODE=" + PARENTNODE + "; ");
			sb.Append("NODE=" + NODE + "; ");
			sb.Append("DISPLAYTEXT=" + DISPLAYTEXT + "; ");
			sb.Append("TABTEXT=" + TABTEXT + "; ");
			sb.Append("CLASSNAME=" + CLASSNAME + "; ");
			sb.Append("STATICCLASS=" + STATICCLASS + "; ");
			sb.Append("SORTORDER=" + SORTORDER + "; ");
			sb.Append("PICTUREINDEX=" + PICTUREINDEX + "; ");
			sb.Append("SELECTEDPICTUREINDEX=" + SELECTEDPICTUREINDEX + "; ");
			sb.Append("EXPANDED=" + EXPANDED + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(MAIN_LIST)){
                MAIN_LIST compare=(MAIN_LIST)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.NODE;
        }
        
        public string DescriptorValue()
        {
                            return this.DISPLAYTEXT.ToString();
                    }

        public string DescriptorColumn() {
            return "DISPLAYTEXT";
        }
        public static string GetKeyColumn()
        {
            return "NODE";
        }        
        public static string GetDescriptorColumn()
        {
            return "DISPLAYTEXT";
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

        int _PARENTNODE;
		/// <summary>
		/// 
		/// </summary>
        public int PARENTNODE
        {
            get { return _PARENTNODE; }
            set
            {
                if(_PARENTNODE!=value || _isLoaded){
                    _PARENTNODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PARENTNODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _NODE;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public int NODE
        {
            get { return _NODE; }
            set
            {
                if(_NODE!=value || _isLoaded){
                    _NODE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="NODE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DISPLAYTEXT;
		/// <summary>
		/// 
		/// </summary>
        public string DISPLAYTEXT
        {
            get { return _DISPLAYTEXT; }
            set
            {
                if(_DISPLAYTEXT!=value || _isLoaded){
                    _DISPLAYTEXT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DISPLAYTEXT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TABTEXT;
		/// <summary>
		/// 
		/// </summary>
        public string TABTEXT
        {
            get { return _TABTEXT; }
            set
            {
                if(_TABTEXT!=value || _isLoaded){
                    _TABTEXT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TABTEXT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CLASSNAME;
		/// <summary>
		/// 
		/// </summary>
        public string CLASSNAME
        {
            get { return _CLASSNAME; }
            set
            {
                if(_CLASSNAME!=value || _isLoaded){
                    _CLASSNAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CLASSNAME");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _STATICCLASS;
		/// <summary>
		/// 
		/// </summary>
        public int STATICCLASS
        {
            get { return _STATICCLASS; }
            set
            {
                if(_STATICCLASS!=value || _isLoaded){
                    _STATICCLASS=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="STATICCLASS");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SORTORDER;
		/// <summary>
		/// 
		/// </summary>
        public int SORTORDER
        {
            get { return _SORTORDER; }
            set
            {
                if(_SORTORDER!=value || _isLoaded){
                    _SORTORDER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SORTORDER");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PICTUREINDEX;
		/// <summary>
		/// 
		/// </summary>
        public string PICTUREINDEX
        {
            get { return _PICTUREINDEX; }
            set
            {
                if(_PICTUREINDEX!=value || _isLoaded){
                    _PICTUREINDEX=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PICTUREINDEX");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SELECTEDPICTUREINDEX;
		/// <summary>
		/// 
		/// </summary>
        public string SELECTEDPICTUREINDEX
        {
            get { return _SELECTEDPICTUREINDEX; }
            set
            {
                if(_SELECTEDPICTUREINDEX!=value || _isLoaded){
                    _SELECTEDPICTUREINDEX=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SELECTEDPICTUREINDEX");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _EXPANDED;
		/// <summary>
		/// 
		/// </summary>
        public int EXPANDED
        {
            get { return _EXPANDED; }
            set
            {
                if(_EXPANDED!=value || _isLoaded){
                    _EXPANDED=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EXPANDED");
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


        public static void Delete(Expression<Func<MAIN_LIST, bool>> expression) {
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

