 
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
    /// A class which represents the TOOL_LIST table in the HRtest Database.
    /// </summary>
    public partial class TOOL_LIST: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<TOOL_LIST> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<TOOL_LIST>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<TOOL_LIST> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(TOOL_LIST item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                TOOL_LIST item=new TOOL_LIST();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<TOOL_LIST> _repo;
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
        public TOOL_LIST(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                TOOL_LIST.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TOOL_LIST>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public TOOL_LIST(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            TOOL_NO = readRecord.get_string("TOOL_NO",null);
               
            TEXT = readRecord.get_string("TEXT",null);
               
            TOOLTIP = readRecord.get_string("TOOLTIP",null);
               
            IMAGE = readRecord.get_string("IMAGE",null);
               
            DIVIDER = readRecord.get_int("DIVIDER",null);
               
            DISABLED = readRecord.get_int("DISABLED",null);
               
            DROPDOWN = readRecord.get_int("DROPDOWN",null);
               
            DROPWHOLE = readRecord.get_int("DROPWHOLE",null);
               
            TAGDATA = readRecord.get_string("TAGDATA",null);
               
            SORT_ORDER = readRecord.get_int("SORT_ORDER",null);
               
            DWOBJECT = readRecord.get_string("DWOBJECT",null);
               
            GROUPNO = readRecord.get_int("GROUPNO",null);
               
            GROUPNAME = readRecord.get_string("GROUPNAME",null);
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

        public TOOL_LIST(Expression<Func<TOOL_LIST, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<TOOL_LIST> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<TOOL_LIST> _repo;
            
            if(db.TestMode){
                TOOL_LIST.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TOOL_LIST>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<TOOL_LIST> GetRepo(){
            return GetRepo("","");
        }
        
        public static TOOL_LIST SingleOrDefault(Expression<Func<TOOL_LIST, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            TOOL_LIST single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static TOOL_LIST SingleOrDefault(Expression<Func<TOOL_LIST, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            TOOL_LIST single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<TOOL_LIST, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<TOOL_LIST, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<TOOL_LIST> Find(Expression<Func<TOOL_LIST, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<TOOL_LIST> Find(Expression<Func<TOOL_LIST, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<TOOL_LIST> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<TOOL_LIST> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<TOOL_LIST> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<TOOL_LIST> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<TOOL_LIST> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<TOOL_LIST> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("TOOL_NO=" + TOOL_NO + "; ");
			sb.Append("TEXT=" + TEXT + "; ");
			sb.Append("TOOLTIP=" + TOOLTIP + "; ");
			sb.Append("IMAGE=" + IMAGE + "; ");
			sb.Append("DIVIDER=" + DIVIDER + "; ");
			sb.Append("DISABLED=" + DISABLED + "; ");
			sb.Append("DROPDOWN=" + DROPDOWN + "; ");
			sb.Append("DROPWHOLE=" + DROPWHOLE + "; ");
			sb.Append("TAGDATA=" + TAGDATA + "; ");
			sb.Append("SORT_ORDER=" + SORT_ORDER + "; ");
			sb.Append("DWOBJECT=" + DWOBJECT + "; ");
			sb.Append("GROUPNO=" + GROUPNO + "; ");
			sb.Append("GROUPNAME=" + GROUPNAME + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(TOOL_LIST)){
                TOOL_LIST compare=(TOOL_LIST)obj;
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
                            return this.TOOL_NO.ToString();
                    }

        public string DescriptorColumn() {
            return "TOOL_NO";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "TOOL_NO";
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

        string _TOOL_NO;
		/// <summary>
		/// 
		/// </summary>
        public string TOOL_NO
        {
            get { return _TOOL_NO; }
            set
            {
                if(_TOOL_NO!=value || _isLoaded){
                    _TOOL_NO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TOOL_NO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TEXT;
		/// <summary>
		/// 
		/// </summary>
        public string TEXT
        {
            get { return _TEXT; }
            set
            {
                if(_TEXT!=value || _isLoaded){
                    _TEXT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TEXT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TOOLTIP;
		/// <summary>
		/// 
		/// </summary>
        public string TOOLTIP
        {
            get { return _TOOLTIP; }
            set
            {
                if(_TOOLTIP!=value || _isLoaded){
                    _TOOLTIP=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TOOLTIP");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IMAGE;
		/// <summary>
		/// 
		/// </summary>
        public string IMAGE
        {
            get { return _IMAGE; }
            set
            {
                if(_IMAGE!=value || _isLoaded){
                    _IMAGE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IMAGE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DIVIDER;
		/// <summary>
		/// 
		/// </summary>
        public int? DIVIDER
        {
            get { return _DIVIDER; }
            set
            {
                if(_DIVIDER!=value || _isLoaded){
                    _DIVIDER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DIVIDER");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DISABLED;
		/// <summary>
		/// 
		/// </summary>
        public int? DISABLED
        {
            get { return _DISABLED; }
            set
            {
                if(_DISABLED!=value || _isLoaded){
                    _DISABLED=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DISABLED");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DROPDOWN;
		/// <summary>
		/// 
		/// </summary>
        public int? DROPDOWN
        {
            get { return _DROPDOWN; }
            set
            {
                if(_DROPDOWN!=value || _isLoaded){
                    _DROPDOWN=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DROPDOWN");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _DROPWHOLE;
		/// <summary>
		/// 
		/// </summary>
        public int? DROPWHOLE
        {
            get { return _DROPWHOLE; }
            set
            {
                if(_DROPWHOLE!=value || _isLoaded){
                    _DROPWHOLE=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DROPWHOLE");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TAGDATA;
		/// <summary>
		/// 
		/// </summary>
        public string TAGDATA
        {
            get { return _TAGDATA; }
            set
            {
                if(_TAGDATA!=value || _isLoaded){
                    _TAGDATA=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TAGDATA");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _SORT_ORDER;
		/// <summary>
		/// 
		/// </summary>
        public int SORT_ORDER
        {
            get { return _SORT_ORDER; }
            set
            {
                if(_SORT_ORDER!=value || _isLoaded){
                    _SORT_ORDER=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SORT_ORDER");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DWOBJECT;
		/// <summary>
		/// 
		/// </summary>
        public string DWOBJECT
        {
            get { return _DWOBJECT; }
            set
            {
                if(_DWOBJECT!=value || _isLoaded){
                    _DWOBJECT=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DWOBJECT");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _GROUPNO;
		/// <summary>
		/// 
		/// </summary>
        public int? GROUPNO
        {
            get { return _GROUPNO; }
            set
            {
                if(_GROUPNO!=value || _isLoaded){
                    _GROUPNO=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GROUPNO");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _GROUPNAME;
		/// <summary>
		/// 
		/// </summary>
        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set
            {
                if(_GROUPNAME!=value || _isLoaded){
                    _GROUPNAME=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="GROUPNAME");
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


        public static void Delete(Expression<Func<TOOL_LIST, bool>> expression) {
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

