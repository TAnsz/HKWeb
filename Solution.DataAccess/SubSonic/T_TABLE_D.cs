 
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
    /// A class which represents the T_TABLE_D table in the HRtest Database.
    /// </summary>
    public partial class T_TABLE_D: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<T_TABLE_D> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<T_TABLE_D>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<T_TABLE_D> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(T_TABLE_D item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                T_TABLE_D item=new T_TABLE_D();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<T_TABLE_D> _repo;
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
        public T_TABLE_D(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                T_TABLE_D.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<T_TABLE_D>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public T_TABLE_D(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            TABLES = readRecord.get_string("TABLES",null);
               
            CODE = readRecord.get_string("CODE",null);
               
            DESCR = readRecord.get_string("DESCR",null);
               
            DATA = readRecord.get_string("DATA",null);
               
            TYPE = readRecord.get_string("TYPE",null);
               
            GROUPS = readRecord.get_string("GROUPS",null);
               
            DATAC = readRecord.get_int("DATAC",null);
               
            NOTES = readRecord.get_string("NOTES",null);
               
            RECORD_BY = readRecord.get_string("RECORD_BY",null);
               
            RECORD_DATE = readRecord.get_datetime("RECORD_DATE",null);
               
            SYSDIV = readRecord.get_string("SYSDIV",null);
               
            DATAD1 = readRecord.get_decimal("DATAD1",null);
               
            DATAD2 = readRecord.get_decimal("DATAD2",null);
               
            DATAD3 = readRecord.get_decimal("DATAD3",null);
               
            DATAD4 = readRecord.get_decimal("DATAD4",null);
               
            DATAD5 = readRecord.get_string("DATAD5",null);
               
            DATAD6 = readRecord.get_string("DATAD6",null);
               
            DATAD7 = readRecord.get_string("DATAD7",null);
               
            DATAD8 = readRecord.get_string("DATAD8",null);
               
            EDIT_BY = readRecord.get_string("EDIT_BY",null);
               
            EDIT_DATE = readRecord.get_datetime("EDIT_DATE",null);
               
            PagePower = readRecord.get_string("PagePower",null);
               
            ControlPower = readRecord.get_string("ControlPower",null);
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

        public T_TABLE_D(Expression<Func<T_TABLE_D, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<T_TABLE_D> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<T_TABLE_D> _repo;
            
            if(db.TestMode){
                T_TABLE_D.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<T_TABLE_D>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<T_TABLE_D> GetRepo(){
            return GetRepo("","");
        }
        
        public static T_TABLE_D SingleOrDefault(Expression<Func<T_TABLE_D, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            T_TABLE_D single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static T_TABLE_D SingleOrDefault(Expression<Func<T_TABLE_D, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            T_TABLE_D single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<T_TABLE_D, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<T_TABLE_D, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<T_TABLE_D> Find(Expression<Func<T_TABLE_D, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<T_TABLE_D> Find(Expression<Func<T_TABLE_D, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<T_TABLE_D> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<T_TABLE_D> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<T_TABLE_D> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<T_TABLE_D> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<T_TABLE_D> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<T_TABLE_D> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("TABLES=" + TABLES + "; ");
			sb.Append("CODE=" + CODE + "; ");
			sb.Append("DESCR=" + DESCR + "; ");
			sb.Append("DATA=" + DATA + "; ");
			sb.Append("TYPE=" + TYPE + "; ");
			sb.Append("GROUPS=" + GROUPS + "; ");
			sb.Append("DATAC=" + DATAC + "; ");
			sb.Append("NOTES=" + NOTES + "; ");
			sb.Append("RECORD_BY=" + RECORD_BY + "; ");
			sb.Append("RECORD_DATE=" + RECORD_DATE + "; ");
			sb.Append("SYSDIV=" + SYSDIV + "; ");
			sb.Append("DATAD1=" + DATAD1 + "; ");
			sb.Append("DATAD2=" + DATAD2 + "; ");
			sb.Append("DATAD3=" + DATAD3 + "; ");
			sb.Append("DATAD4=" + DATAD4 + "; ");
			sb.Append("DATAD5=" + DATAD5 + "; ");
			sb.Append("DATAD6=" + DATAD6 + "; ");
			sb.Append("DATAD7=" + DATAD7 + "; ");
			sb.Append("DATAD8=" + DATAD8 + "; ");
			sb.Append("EDIT_BY=" + EDIT_BY + "; ");
			sb.Append("EDIT_DATE=" + EDIT_DATE + "; ");
			sb.Append("PagePower=" + PagePower + "; ");
			sb.Append("ControlPower=" + ControlPower + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(T_TABLE_D)){
                T_TABLE_D compare=(T_TABLE_D)obj;
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
                            return this.TABLES.ToString();
                    }

        public string DescriptorColumn() {
            return "TABLES";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "TABLES";
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

        string _TABLES;
		/// <summary>
		/// 
		/// </summary>
        public string TABLES
        {
            get { return _TABLES; }
            set
            {
                if(_TABLES!=value || _isLoaded){
                    _TABLES=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TABLES");
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

        string _DESCR;
		/// <summary>
		/// 
		/// </summary>
        public string DESCR
        {
            get { return _DESCR; }
            set
            {
                if(_DESCR!=value || _isLoaded){
                    _DESCR=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DESCR");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DATA;
		/// <summary>
		/// 
		/// </summary>
        public string DATA
        {
            get { return _DATA; }
            set
            {
                if(_DATA!=value || _isLoaded){
                    _DATA=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATA");
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

        int? _DATAC;
		/// <summary>
		/// 
		/// </summary>
        public int? DATAC
        {
            get { return _DATAC; }
            set
            {
                if(_DATAC!=value || _isLoaded){
                    _DATAC=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAC");
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

        decimal? _DATAD1;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DATAD1
        {
            get { return _DATAD1; }
            set
            {
                if(_DATAD1!=value || _isLoaded){
                    _DATAD1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DATAD2;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DATAD2
        {
            get { return _DATAD2; }
            set
            {
                if(_DATAD2!=value || _isLoaded){
                    _DATAD2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DATAD3;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DATAD3
        {
            get { return _DATAD3; }
            set
            {
                if(_DATAD3!=value || _isLoaded){
                    _DATAD3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _DATAD4;
		/// <summary>
		/// 
		/// </summary>
        public decimal? DATAD4
        {
            get { return _DATAD4; }
            set
            {
                if(_DATAD4!=value || _isLoaded){
                    _DATAD4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DATAD5;
		/// <summary>
		/// 
		/// </summary>
        public string DATAD5
        {
            get { return _DATAD5; }
            set
            {
                if(_DATAD5!=value || _isLoaded){
                    _DATAD5=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD5");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DATAD6;
		/// <summary>
		/// 
		/// </summary>
        public string DATAD6
        {
            get { return _DATAD6; }
            set
            {
                if(_DATAD6!=value || _isLoaded){
                    _DATAD6=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD6");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DATAD7;
		/// <summary>
		/// 
		/// </summary>
        public string DATAD7
        {
            get { return _DATAD7; }
            set
            {
                if(_DATAD7!=value || _isLoaded){
                    _DATAD7=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD7");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DATAD8;
		/// <summary>
		/// 
		/// </summary>
        public string DATAD8
        {
            get { return _DATAD8; }
            set
            {
                if(_DATAD8!=value || _isLoaded){
                    _DATAD8=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DATAD8");
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

        string _PagePower;
		/// <summary>
		/// 
		/// </summary>
        public string PagePower
        {
            get { return _PagePower; }
            set
            {
                if(_PagePower!=value || _isLoaded){
                    _PagePower=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PagePower");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ControlPower;
		/// <summary>
		/// 
		/// </summary>
        public string ControlPower
        {
            get { return _ControlPower; }
            set
            {
                if(_ControlPower!=value || _isLoaded){
                    _ControlPower=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ControlPower");
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


        public static void Delete(Expression<Func<T_TABLE_D, bool>> expression) {
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

