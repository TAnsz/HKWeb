 
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
    /// A class which represents the CardDetail table in the HKHR Database.
    /// </summary>
    public partial class CardDetail: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<CardDetail> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<CardDetail>(new Solution.DataAccess.DataModel.HKHRDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<CardDetail> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(CardDetail item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                CardDetail item=new CardDetail();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<CardDetail> _repo;
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
        public CardDetail(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                CardDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CardDetail>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public CardDetail(){
			_db=new Solution.DataAccess.DataModel.HKHRDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_int("Id",null);
               
            emp_id = readRecord.get_string("emp_id",null);
               
            join_id = readRecord.get_int("join_id",null);
               
            depart_id = readRecord.get_string("depart_id",null);
               
            card_id = readRecord.get_string("card_id",null);
               
            kind = readRecord.get_int("kind",null);
               
            use_date = readRecord.get_datetime("use_date",null);
               
            Invalid_date = readRecord.get_datetime("Invalid_date",null);
               
            isbuban = readRecord.get_short("isbuban",null);
               
            isunloss = readRecord.get_short("isunloss",null);
               
            card_sn = readRecord.get_string("card_sn",null);
               
            old_card_id = readRecord.get_string("old_card_id",null);
               
            audit = readRecord.get_short("audit",null);
               
            remark = readRecord.get_string("remark",null);
               
            op_date = readRecord.get_datetime("op_date",null);
               
            op_user = readRecord.get_string("op_user",null);
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

        public CardDetail(Expression<Func<CardDetail, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<CardDetail> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HKHRDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HKHRDB();
            }else{
                db=new Solution.DataAccess.DataModel.HKHRDB(connectionString, providerName);
            }
            IRepository<CardDetail> _repo;
            
            if(db.TestMode){
                CardDetail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<CardDetail>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<CardDetail> GetRepo(){
            return GetRepo("","");
        }
        
        public static CardDetail SingleOrDefault(Expression<Func<CardDetail, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            CardDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static CardDetail SingleOrDefault(Expression<Func<CardDetail, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            CardDetail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<CardDetail, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<CardDetail, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<CardDetail> Find(Expression<Func<CardDetail, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<CardDetail> Find(Expression<Func<CardDetail, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<CardDetail> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<CardDetail> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<CardDetail> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<CardDetail> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<CardDetail> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<CardDetail> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("card_id=" + card_id + "; ");
			sb.Append("kind=" + kind + "; ");
			sb.Append("use_date=" + use_date + "; ");
			sb.Append("Invalid_date=" + Invalid_date + "; ");
			sb.Append("isbuban=" + isbuban + "; ");
			sb.Append("isunloss=" + isunloss + "; ");
			sb.Append("card_sn=" + card_sn + "; ");
			sb.Append("old_card_id=" + old_card_id + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("remark=" + remark + "; ");
			sb.Append("op_date=" + op_date + "; ");
			sb.Append("op_user=" + op_user + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(CardDetail)){
                CardDetail compare=(CardDetail)obj;
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

        string _card_id;
		/// <summary>
		/// 
		/// </summary>
        public string card_id
        {
            get { return _card_id; }
            set
            {
                if(_card_id!=value || _isLoaded){
                    _card_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="card_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _kind;
		/// <summary>
		/// 
		/// </summary>
        public int? kind
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

        DateTime? _use_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? use_date
        {
            get { return _use_date; }
            set
            {
                if(_use_date!=value || _isLoaded){
                    _use_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="use_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _Invalid_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? Invalid_date
        {
            get { return _Invalid_date; }
            set
            {
                if(_Invalid_date!=value || _isLoaded){
                    _Invalid_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Invalid_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _isbuban;
		/// <summary>
		/// 
		/// </summary>
        public short? isbuban
        {
            get { return _isbuban; }
            set
            {
                if(_isbuban!=value || _isLoaded){
                    _isbuban=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isbuban");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _isunloss;
		/// <summary>
		/// 
		/// </summary>
        public short? isunloss
        {
            get { return _isunloss; }
            set
            {
                if(_isunloss!=value || _isLoaded){
                    _isunloss=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="isunloss");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _card_sn;
		/// <summary>
		/// 
		/// </summary>
        public string card_sn
        {
            get { return _card_sn; }
            set
            {
                if(_card_sn!=value || _isLoaded){
                    _card_sn=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="card_sn");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _old_card_id;
		/// <summary>
		/// 
		/// </summary>
        public string old_card_id
        {
            get { return _old_card_id; }
            set
            {
                if(_old_card_id!=value || _isLoaded){
                    _old_card_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="old_card_id");
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


        public static void Delete(Expression<Func<CardDetail, bool>> expression) {
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

