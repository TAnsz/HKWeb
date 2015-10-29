 
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
    /// A class which represents the MealOrdering table in the HRtest Database.
    /// </summary>
    public partial class MealOrdering: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<MealOrdering> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<MealOrdering>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<MealOrdering> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(MealOrdering item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                MealOrdering item=new MealOrdering();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<MealOrdering> _repo;
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
        public MealOrdering(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                MealOrdering.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MealOrdering>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public MealOrdering(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            Code = readRecord.get_string("Code",null);
               
            Employee_Name = readRecord.get_string("Employee_Name",null);
               
            DepartId = readRecord.get_string("DepartId",null);
               
            DepartName = readRecord.get_string("DepartName",null);
               
            FoodCode = readRecord.get_string("FoodCode",null);
               
            DrinkCode = readRecord.get_string("DrinkCode",null);
               
            ApplyDate = readRecord.get_datetime("ApplyDate",null);
               
            Employee_EmpId = readRecord.get_string("Employee_EmpId",null);
               
            RecordId = readRecord.get_string("RecordId",null);
               
            RecordName = readRecord.get_string("RecordName",null);
               
            RecordDate = readRecord.get_datetime("RecordDate",null);
               
            Remark = readRecord.get_string("Remark",null);
               
            IsVaild = readRecord.get_byte("IsVaild",null);
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

        public MealOrdering(Expression<Func<MealOrdering, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<MealOrdering> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<MealOrdering> _repo;
            
            if(db.TestMode){
                MealOrdering.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MealOrdering>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<MealOrdering> GetRepo(){
            return GetRepo("","");
        }
        
        public static MealOrdering SingleOrDefault(Expression<Func<MealOrdering, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            MealOrdering single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static MealOrdering SingleOrDefault(Expression<Func<MealOrdering, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            MealOrdering single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<MealOrdering, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<MealOrdering, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<MealOrdering> Find(Expression<Func<MealOrdering, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<MealOrdering> Find(Expression<Func<MealOrdering, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<MealOrdering> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<MealOrdering> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<MealOrdering> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<MealOrdering> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<MealOrdering> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<MealOrdering> GetPaged(int pageIndex, int pageSize) {
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
                var settable = value.ChangeTypeTo<long>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
		
        public override string ToString(){
			var sb = new StringBuilder();
			sb.Append("Id=" + Id + "; ");
			sb.Append("Code=" + Code + "; ");
			sb.Append("Employee_Name=" + Employee_Name + "; ");
			sb.Append("DepartId=" + DepartId + "; ");
			sb.Append("DepartName=" + DepartName + "; ");
			sb.Append("FoodCode=" + FoodCode + "; ");
			sb.Append("DrinkCode=" + DrinkCode + "; ");
			sb.Append("ApplyDate=" + ApplyDate + "; ");
			sb.Append("Employee_EmpId=" + Employee_EmpId + "; ");
			sb.Append("RecordId=" + RecordId + "; ");
			sb.Append("RecordName=" + RecordName + "; ");
			sb.Append("RecordDate=" + RecordDate + "; ");
			sb.Append("Remark=" + Remark + "; ");
			sb.Append("IsVaild=" + IsVaild + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(MealOrdering)){
                MealOrdering compare=(MealOrdering)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.Code.ToString();
                    }

        public string DescriptorColumn() {
            return "Code";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "Code";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id;
		/// <summary>
		/// Id
		/// </summary>
		[SubSonicPrimaryKey]
        public long Id
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

        string _Code;
		/// <summary>
		/// 編號
		/// </summary>
        public string Code
        {
            get { return _Code; }
            set
            {
                if(_Code!=value || _isLoaded){
                    _Code=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Code");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Employee_Name;
		/// <summary>
		/// 申請人
		/// </summary>
        public string Employee_Name
        {
            get { return _Employee_Name; }
            set
            {
                if(_Employee_Name!=value || _isLoaded){
                    _Employee_Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Employee_Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DepartId;
		/// <summary>
		/// 申請人部門編號
		/// </summary>
        public string DepartId
        {
            get { return _DepartId; }
            set
            {
                if(_DepartId!=value || _isLoaded){
                    _DepartId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DepartId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DepartName;
		/// <summary>
		/// 申請人部門名稱
		/// </summary>
        public string DepartName
        {
            get { return _DepartName; }
            set
            {
                if(_DepartName!=value || _isLoaded){
                    _DepartName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DepartName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FoodCode;
		/// <summary>
		/// 飯類
		/// </summary>
        public string FoodCode
        {
            get { return _FoodCode; }
            set
            {
                if(_FoodCode!=value || _isLoaded){
                    _FoodCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FoodCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DrinkCode;
		/// <summary>
		/// 餐飲
		/// </summary>
        public string DrinkCode
        {
            get { return _DrinkCode; }
            set
            {
                if(_DrinkCode!=value || _isLoaded){
                    _DrinkCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DrinkCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ApplyDate;
		/// <summary>
		/// 申請日期
		/// </summary>
        public DateTime? ApplyDate
        {
            get { return _ApplyDate; }
            set
            {
                if(_ApplyDate!=value || _isLoaded){
                    _ApplyDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ApplyDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Employee_EmpId;
		/// <summary>
		/// 申請人編號
		/// </summary>
        public string Employee_EmpId
        {
            get { return _Employee_EmpId; }
            set
            {
                if(_Employee_EmpId!=value || _isLoaded){
                    _Employee_EmpId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Employee_EmpId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RecordId;
		/// <summary>
		/// 錄入人編號
		/// </summary>
        public string RecordId
        {
            get { return _RecordId; }
            set
            {
                if(_RecordId!=value || _isLoaded){
                    _RecordId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RecordId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RecordName;
		/// <summary>
		/// 錄入人
		/// </summary>
        public string RecordName
        {
            get { return _RecordName; }
            set
            {
                if(_RecordName!=value || _isLoaded){
                    _RecordName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RecordName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _RecordDate;
		/// <summary>
		/// 錄入日期
		/// </summary>
        public DateTime? RecordDate
        {
            get { return _RecordDate; }
            set
            {
                if(_RecordDate!=value || _isLoaded){
                    _RecordDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RecordDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Remark;
		/// <summary>
		/// 備注
		/// </summary>
        public string Remark
        {
            get { return _Remark; }
            set
            {
                if(_Remark!=value || _isLoaded){
                    _Remark=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Remark");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _IsVaild;
		/// <summary>
		/// 有效
		/// </summary>
        public byte? IsVaild
        {
            get { return _IsVaild; }
            set
            {
                if(_IsVaild!=value || _isLoaded){
                    _IsVaild=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsVaild");
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


        public static void Delete(Expression<Func<MealOrdering, bool>> expression) {
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

