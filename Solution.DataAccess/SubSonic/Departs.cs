 
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
    /// A class which represents the Departs table in the HKHR Database.
    /// </summary>
    public partial class Departs: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Departs> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Departs>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Departs> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Departs item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Departs item=new Departs();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Departs> _repo;
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
        public Departs(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Departs.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Departs>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Departs(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            depart_id = readRecord.get_string("depart_id",null);
               
            inside_id = readRecord.get_int("inside_id",null);
               
            depart_name = readRecord.get_string("depart_name",null);
               
            manager1 = readRecord.get_string("manager1",null);
               
            job_id1 = readRecord.get_string("job_id1",null);
               
            manager2 = readRecord.get_string("manager2",null);
               
            job_id2 = readRecord.get_string("job_id2",null);
               
            emp_prefix = readRecord.get_string("emp_prefix",null);
               
            plan_num = readRecord.get_int("plan_num",null);
               
            linktel = readRecord.get_string("linktel",null);
               
            remark = readRecord.get_string("remark",null);
               
            butei_money = readRecord.get_decimal("butei_money",null);
               
            audit_access = readRecord.get_int("audit_access",null);
               
            TreeLevel = readRecord.get_int("TreeLevel",null);
               
            Up_ID = readRecord.get_string("Up_ID",null);
               
            LongName = readRecord.get_string("LongName",null);
               
            access_level = readRecord.get_int("access_level",null);
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

        public Departs(Expression<Func<Departs, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Departs> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<Departs> _repo;
            
            if(db.TestMode){
                Departs.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Departs>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Departs> GetRepo(){
            return GetRepo("","");
        }
        
        public static Departs SingleOrDefault(Expression<Func<Departs, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Departs single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Departs SingleOrDefault(Expression<Func<Departs, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Departs single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Departs, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Departs, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Departs> Find(Expression<Func<Departs, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Departs> Find(Expression<Func<Departs, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Departs> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Departs> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Departs> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Departs> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Departs> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Departs> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "depart_id";
        }

        public object KeyValue()
        {
            return this.depart_id;
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
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("inside_id=" + inside_id + "; ");
			sb.Append("depart_name=" + depart_name + "; ");
			sb.Append("manager1=" + manager1 + "; ");
			sb.Append("job_id1=" + job_id1 + "; ");
			sb.Append("manager2=" + manager2 + "; ");
			sb.Append("job_id2=" + job_id2 + "; ");
			sb.Append("emp_prefix=" + emp_prefix + "; ");
			sb.Append("plan_num=" + plan_num + "; ");
			sb.Append("linktel=" + linktel + "; ");
			sb.Append("remark=" + remark + "; ");
			sb.Append("butei_money=" + butei_money + "; ");
			sb.Append("audit_access=" + audit_access + "; ");
			sb.Append("TreeLevel=" + TreeLevel + "; ");
			sb.Append("Up_ID=" + Up_ID + "; ");
			sb.Append("LongName=" + LongName + "; ");
			sb.Append("access_level=" + access_level + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Departs)){
                Departs compare=(Departs)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.depart_id.ToString();
                    }

        public string DescriptorColumn() {
            return "depart_id";
        }
        public static string GetKeyColumn()
        {
            return "depart_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "depart_id";
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

        string _depart_id;
		/// <summary>
		/// 
		/// </summary>
		[SubSonicPrimaryKey]
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

        int? _inside_id;
		/// <summary>
		/// 
		/// </summary>
        public int? inside_id
        {
            get { return _inside_id; }
            set
            {
                if(_inside_id!=value || _isLoaded){
                    _inside_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="inside_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _depart_name;
		/// <summary>
		/// 
		/// </summary>
        public string depart_name
        {
            get { return _depart_name; }
            set
            {
                if(_depart_name!=value || _isLoaded){
                    _depart_name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="depart_name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _manager1;
		/// <summary>
		/// 
		/// </summary>
        public string manager1
        {
            get { return _manager1; }
            set
            {
                if(_manager1!=value || _isLoaded){
                    _manager1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="manager1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _job_id1;
		/// <summary>
		/// 
		/// </summary>
        public string job_id1
        {
            get { return _job_id1; }
            set
            {
                if(_job_id1!=value || _isLoaded){
                    _job_id1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="job_id1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _manager2;
		/// <summary>
		/// 
		/// </summary>
        public string manager2
        {
            get { return _manager2; }
            set
            {
                if(_manager2!=value || _isLoaded){
                    _manager2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="manager2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _job_id2;
		/// <summary>
		/// 
		/// </summary>
        public string job_id2
        {
            get { return _job_id2; }
            set
            {
                if(_job_id2!=value || _isLoaded){
                    _job_id2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="job_id2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _emp_prefix;
		/// <summary>
		/// 
		/// </summary>
        public string emp_prefix
        {
            get { return _emp_prefix; }
            set
            {
                if(_emp_prefix!=value || _isLoaded){
                    _emp_prefix=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="emp_prefix");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _plan_num;
		/// <summary>
		/// 
		/// </summary>
        public int? plan_num
        {
            get { return _plan_num; }
            set
            {
                if(_plan_num!=value || _isLoaded){
                    _plan_num=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="plan_num");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _linktel;
		/// <summary>
		/// 
		/// </summary>
        public string linktel
        {
            get { return _linktel; }
            set
            {
                if(_linktel!=value || _isLoaded){
                    _linktel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="linktel");
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

        decimal? _butei_money;
		/// <summary>
		/// 
		/// </summary>
        public decimal? butei_money
        {
            get { return _butei_money; }
            set
            {
                if(_butei_money!=value || _isLoaded){
                    _butei_money=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="butei_money");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _audit_access;
		/// <summary>
		/// 
		/// </summary>
        public int? audit_access
        {
            get { return _audit_access; }
            set
            {
                if(_audit_access!=value || _isLoaded){
                    _audit_access=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="audit_access");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _TreeLevel;
		/// <summary>
		/// 
		/// </summary>
        public int? TreeLevel
        {
            get { return _TreeLevel; }
            set
            {
                if(_TreeLevel!=value || _isLoaded){
                    _TreeLevel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TreeLevel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Up_ID;
		/// <summary>
		/// 
		/// </summary>
        public string Up_ID
        {
            get { return _Up_ID; }
            set
            {
                if(_Up_ID!=value || _isLoaded){
                    _Up_ID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Up_ID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LongName;
		/// <summary>
		/// 
		/// </summary>
        public string LongName
        {
            get { return _LongName; }
            set
            {
                if(_LongName!=value || _isLoaded){
                    _LongName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LongName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _access_level;
		/// <summary>
		/// 
		/// </summary>
        public int? access_level
        {
            get { return _access_level; }
            set
            {
                if(_access_level!=value || _isLoaded){
                    _access_level=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="access_level");
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


        public static void Delete(Expression<Func<Departs, bool>> expression) {
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

