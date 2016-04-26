 
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
    /// A class which represents the employeedet table in the HKHR Database.
    /// </summary>
    public partial class employeedet: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<employeedet> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<employeedet>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<employeedet> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(employeedet item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                employeedet item=new employeedet();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<employeedet> _repo;
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
        public employeedet(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                employeedet.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<employeedet>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public employeedet(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            employeeid = readRecord.get_string("employeeid",null);
               
            comingtime = readRecord.get_string("comingtime",null);
               
            overtime = readRecord.get_string("overtime",null);
               
            date1 = readRecord.get_string("date1",null);
               
            month1 = readRecord.get_string("month1",null);
               
            year1 = readRecord.get_string("year1",null);
               
            week1 = readRecord.get_string("week1",null);
               
            remark = readRecord.get_string("remark",null);
               
            no = readRecord.get_int("no",null);
               
            empid = readRecord.get_string("empid",null);
               
            comingtype = readRecord.get_byte("comingtype",null);
               
            overtype = readRecord.get_byte("overtype",null);
               
            ComingMac = readRecord.get_string("ComingMac",null);
               
            OverMac = readRecord.get_string("OverMac",null);
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

        public employeedet(Expression<Func<employeedet, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<employeedet> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<employeedet> _repo;
            
            if(db.TestMode){
                employeedet.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<employeedet>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<employeedet> GetRepo(){
            return GetRepo("","");
        }
        
        public static employeedet SingleOrDefault(Expression<Func<employeedet, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            employeedet single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static employeedet SingleOrDefault(Expression<Func<employeedet, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            employeedet single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<employeedet, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<employeedet, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<employeedet> Find(Expression<Func<employeedet, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<employeedet> Find(Expression<Func<employeedet, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<employeedet> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<employeedet> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<employeedet> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<employeedet> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<employeedet> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<employeedet> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "no";
        }

        public object KeyValue()
        {
            return this.no;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
		
        public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("employeeid=" + employeeid + "; ");
			sb.Append("comingtime=" + comingtime + "; ");
			sb.Append("overtime=" + overtime + "; ");
			sb.Append("date1=" + date1 + "; ");
			sb.Append("month1=" + month1 + "; ");
			sb.Append("year1=" + year1 + "; ");
			sb.Append("week1=" + week1 + "; ");
			sb.Append("remark=" + remark + "; ");
			sb.Append("no=" + no + "; ");
			sb.Append("empid=" + empid + "; ");
			sb.Append("comingtype=" + comingtype + "; ");
			sb.Append("overtype=" + overtype + "; ");
			sb.Append("ComingMac=" + ComingMac + "; ");
			sb.Append("OverMac=" + OverMac + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(employeedet)){
                employeedet compare=(employeedet)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.no;
        }
        
        public string DescriptorValue()
        {
                            return this.employeeid.ToString();
                    }

        public string DescriptorColumn() {
            return "employeeid";
        }
        public static string GetKeyColumn()
        {
            return "no";
        }        
        public static string GetDescriptorColumn()
        {
            return "employeeid";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _employeeid;
		/// <summary>
		/// 
		/// </summary>
        public string employeeid
        {
            get { return _employeeid; }
            set
            {
                if(_employeeid!=value || _isLoaded){
                    _employeeid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="employeeid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _comingtime;
		/// <summary>
		/// 
		/// </summary>
        public string comingtime
        {
            get { return _comingtime; }
            set
            {
                if(_comingtime!=value || _isLoaded){
                    _comingtime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comingtime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _overtime;
		/// <summary>
		/// 
		/// </summary>
        public string overtime
        {
            get { return _overtime; }
            set
            {
                if(_overtime!=value || _isLoaded){
                    _overtime=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="overtime");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _date1;
		/// <summary>
		/// 
		/// </summary>
        public string date1
        {
            get { return _date1; }
            set
            {
                if(_date1!=value || _isLoaded){
                    _date1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="date1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _month1;
		/// <summary>
		/// 
		/// </summary>
        public string month1
        {
            get { return _month1; }
            set
            {
                if(_month1!=value || _isLoaded){
                    _month1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="month1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _year1;
		/// <summary>
		/// 
		/// </summary>
        public string year1
        {
            get { return _year1; }
            set
            {
                if(_year1!=value || _isLoaded){
                    _year1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="year1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _week1;
		/// <summary>
		/// 
		/// </summary>
        public string week1
        {
            get { return _week1; }
            set
            {
                if(_week1!=value || _isLoaded){
                    _week1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="week1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _remark;
		/// <summary>
		/// 
		/// </summary>
        public string remark
        {
            get { return _remark; }
            set
            {
                if(_remark!=value || _isLoaded){
                    _remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _no;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
        public int no
        {
            get { return _no; }
            set
            {
                if(_no!=value || _isLoaded){
                    _no=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="no");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _empid;
		/// <summary>
		/// 
		/// </summary>
        public string empid
        {
            get { return _empid; }
            set
            {
                if(_empid!=value || _isLoaded){
                    _empid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="empid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _comingtype;
		/// <summary>
		/// 
		/// </summary>
        public byte? comingtype
        {
            get { return _comingtype; }
            set
            {
                if(_comingtype!=value || _isLoaded){
                    _comingtype=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="comingtype");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _overtype;
		/// <summary>
		/// 
		/// </summary>
        public byte? overtype
        {
            get { return _overtype; }
            set
            {
                if(_overtype!=value || _isLoaded){
                    _overtype=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="overtype");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ComingMac;
		/// <summary>
		/// 
		/// </summary>
        public string ComingMac
        {
            get { return _ComingMac; }
            set
            {
                if(_ComingMac!=value || _isLoaded){
                    _ComingMac=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ComingMac");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _OverMac;
		/// <summary>
		/// 
		/// </summary>
        public string OverMac
        {
            get { return _OverMac; }
            set
            {
                if(_OverMac!=value || _isLoaded){
                    _OverMac=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OverMac");
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


        public static void Delete(Expression<Func<employeedet, bool>> expression) {
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

