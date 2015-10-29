 
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
    /// A class which represents the OutWork_D table in the HRtest Database.
    /// </summary>
    public partial class OutWork_D: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<OutWork_D> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<OutWork_D>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<OutWork_D> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(OutWork_D item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                OutWork_D item=new OutWork_D();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<OutWork_D> _repo;
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
        public OutWork_D(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                OutWork_D.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<OutWork_D>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public OutWork_D(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            bill_id = readRecord.get_string("bill_id",null);
               
            emp_id = readRecord.get_string("emp_id",null);
               
            join_id = readRecord.get_int("join_id",null);
               
            depart_id = readRecord.get_string("depart_id",null);
               
            bill_date = readRecord.get_datetime("bill_date",null);
               
            begin_time = readRecord.get_datetime("begin_time",null);
               
            end_time = readRecord.get_datetime("end_time",null);
               
            work_type = readRecord.get_string("work_type",null);
               
            work_days = readRecord.get_decimal("work_days",null);
               
            status_id = readRecord.get_int("status_id",null);
               
            leave_id = readRecord.get_string("leave_id",null);
               
            rate = readRecord.get_decimal("rate",null);
               
            checker = readRecord.get_string("checker",null);
               
            check_date = readRecord.get_datetime("check_date",null);
               
            op_user = readRecord.get_string("op_user",null);
               
            op_date = readRecord.get_datetime("op_date",null);
               
            audit = readRecord.get_short("audit",null);
               
            memo = readRecord.get_string("memo",null);
               
            outwork_type = readRecord.get_string("outwork_type",null);
               
            outwork_addr = readRecord.get_string("outwork_addr",null);
               
            transportation = readRecord.get_string("transportation",null);
               
            Re_date = readRecord.get_datetime("Re_date",null);
               
            Start_ag = readRecord.get_string("Start_ag",null);
               
            re_ag = readRecord.get_string("re_ag",null);
               
            peers = readRecord.get_int("peers",null);
               
            Hostel = readRecord.get_int("Hostel",null);
               
            hotel = readRecord.get_int("hotel",null);
               
            hotel_type = readRecord.get_string("hotel_type",null);
               
            reply = readRecord.get_string("reply",null);
               
            work_hrs = readRecord.get_decimal("work_hrs",null);
               
            is_input = readRecord.get_short("is_input",null);
               
            refuse_reason = readRecord.get_string("refuse_reason",null);
               
            CHECKER2 = readRecord.get_string("CHECKER2",null);
               
            audit2 = readRecord.get_short("audit2",null);
               
            IsHotel = readRecord.get_short("IsHotel",null);
               
            IsCar = readRecord.get_short("IsCar",null);
               
            Itinerary = readRecord.get_string("Itinerary",null);
               
            Destination = readRecord.get_string("Destination",null);
               
            IDate = readRecord.get_string("IDate",null);
               
            Nights = readRecord.get_string("Nights",null);
               
            reply2 = readRecord.get_string("reply2",null);
               
            itinerary2 = readRecord.get_string("itinerary2",null);
               
            itinerary3 = readRecord.get_string("itinerary3",null);
               
            itinerary4 = readRecord.get_string("itinerary4",null);
               
            IDate2 = readRecord.get_string("IDate2",null);
               
            IDate3 = readRecord.get_string("IDate3",null);
               
            IDate4 = readRecord.get_string("IDate4",null);
               
            Destination2 = readRecord.get_string("Destination2",null);
               
            Destination3 = readRecord.get_string("Destination3",null);
               
            Destination4 = readRecord.get_string("Destination4",null);
               
            Nights2 = readRecord.get_string("Nights2",null);
               
            Nights3 = readRecord.get_string("Nights3",null);
               
            Nights4 = readRecord.get_string("Nights4",null);
               
            check_date2 = readRecord.get_datetime("check_date2",null);
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

        public OutWork_D(Expression<Func<OutWork_D, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<OutWork_D> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<OutWork_D> _repo;
            
            if(db.TestMode){
                OutWork_D.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<OutWork_D>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<OutWork_D> GetRepo(){
            return GetRepo("","");
        }
        
        public static OutWork_D SingleOrDefault(Expression<Func<OutWork_D, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            OutWork_D single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static OutWork_D SingleOrDefault(Expression<Func<OutWork_D, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            OutWork_D single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<OutWork_D, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<OutWork_D, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<OutWork_D> Find(Expression<Func<OutWork_D, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<OutWork_D> Find(Expression<Func<OutWork_D, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<OutWork_D> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<OutWork_D> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<OutWork_D> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<OutWork_D> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<OutWork_D> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<OutWork_D> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("bill_id=" + bill_id + "; ");
			sb.Append("emp_id=" + emp_id + "; ");
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("bill_date=" + bill_date + "; ");
			sb.Append("begin_time=" + begin_time + "; ");
			sb.Append("end_time=" + end_time + "; ");
			sb.Append("work_type=" + work_type + "; ");
			sb.Append("work_days=" + work_days + "; ");
			sb.Append("status_id=" + status_id + "; ");
			sb.Append("leave_id=" + leave_id + "; ");
			sb.Append("rate=" + rate + "; ");
			sb.Append("checker=" + checker + "; ");
			sb.Append("check_date=" + check_date + "; ");
			sb.Append("op_user=" + op_user + "; ");
			sb.Append("op_date=" + op_date + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("memo=" + memo + "; ");
			sb.Append("outwork_type=" + outwork_type + "; ");
			sb.Append("outwork_addr=" + outwork_addr + "; ");
			sb.Append("transportation=" + transportation + "; ");
			sb.Append("Re_date=" + Re_date + "; ");
			sb.Append("Start_ag=" + Start_ag + "; ");
			sb.Append("re_ag=" + re_ag + "; ");
			sb.Append("peers=" + peers + "; ");
			sb.Append("Hostel=" + Hostel + "; ");
			sb.Append("hotel=" + hotel + "; ");
			sb.Append("hotel_type=" + hotel_type + "; ");
			sb.Append("reply=" + reply + "; ");
			sb.Append("work_hrs=" + work_hrs + "; ");
			sb.Append("is_input=" + is_input + "; ");
			sb.Append("refuse_reason=" + refuse_reason + "; ");
			sb.Append("CHECKER2=" + CHECKER2 + "; ");
			sb.Append("audit2=" + audit2 + "; ");
			sb.Append("IsHotel=" + IsHotel + "; ");
			sb.Append("IsCar=" + IsCar + "; ");
			sb.Append("Itinerary=" + Itinerary + "; ");
			sb.Append("Destination=" + Destination + "; ");
			sb.Append("IDate=" + IDate + "; ");
			sb.Append("Nights=" + Nights + "; ");
			sb.Append("reply2=" + reply2 + "; ");
			sb.Append("itinerary2=" + itinerary2 + "; ");
			sb.Append("itinerary3=" + itinerary3 + "; ");
			sb.Append("itinerary4=" + itinerary4 + "; ");
			sb.Append("IDate2=" + IDate2 + "; ");
			sb.Append("IDate3=" + IDate3 + "; ");
			sb.Append("IDate4=" + IDate4 + "; ");
			sb.Append("Destination2=" + Destination2 + "; ");
			sb.Append("Destination3=" + Destination3 + "; ");
			sb.Append("Destination4=" + Destination4 + "; ");
			sb.Append("Nights2=" + Nights2 + "; ");
			sb.Append("Nights3=" + Nights3 + "; ");
			sb.Append("Nights4=" + Nights4 + "; ");
			sb.Append("check_date2=" + check_date2 + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(OutWork_D)){
                OutWork_D compare=(OutWork_D)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.bill_id.ToString();
                    }

        public string DescriptorColumn() {
            return "bill_id";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "bill_id";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id;
		/// <summary>
		/// 
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

        string _bill_id;
		/// <summary>
		/// 
		/// </summary>
        public string bill_id
        {
            get { return _bill_id; }
            set
            {
                if(_bill_id!=value || _isLoaded){
                    _bill_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="bill_id");
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

        DateTime _bill_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime bill_date
        {
            get { return _bill_date; }
            set
            {
                if(_bill_date!=value || _isLoaded){
                    _bill_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="bill_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _begin_time;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? begin_time
        {
            get { return _begin_time; }
            set
            {
                if(_begin_time!=value || _isLoaded){
                    _begin_time=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="begin_time");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _end_time;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? end_time
        {
            get { return _end_time; }
            set
            {
                if(_end_time!=value || _isLoaded){
                    _end_time=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="end_time");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _work_type;
		/// <summary>
		/// 
		/// </summary>
        public string work_type
        {
            get { return _work_type; }
            set
            {
                if(_work_type!=value || _isLoaded){
                    _work_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="work_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _work_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? work_days
        {
            get { return _work_days; }
            set
            {
                if(_work_days!=value || _isLoaded){
                    _work_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="work_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _status_id;
		/// <summary>
		/// 
		/// </summary>
        public int? status_id
        {
            get { return _status_id; }
            set
            {
                if(_status_id!=value || _isLoaded){
                    _status_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="status_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _leave_id;
		/// <summary>
		/// 
		/// </summary>
        public string leave_id
        {
            get { return _leave_id; }
            set
            {
                if(_leave_id!=value || _isLoaded){
                    _leave_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _rate;
		/// <summary>
		/// 
		/// </summary>
        public decimal? rate
        {
            get { return _rate; }
            set
            {
                if(_rate!=value || _isLoaded){
                    _rate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="rate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _checker;
		/// <summary>
		/// 
		/// </summary>
        public string checker
        {
            get { return _checker; }
            set
            {
                if(_checker!=value || _isLoaded){
                    _checker=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="checker");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _check_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? check_date
        {
            get { return _check_date; }
            set
            {
                if(_check_date!=value || _isLoaded){
                    _check_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="check_date");
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

        string _memo;
		/// <summary>
		/// 
		/// </summary>
        public string memo
        {
            get { return _memo; }
            set
            {
                if(_memo!=value || _isLoaded){
                    _memo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="memo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _outwork_type;
		/// <summary>
		/// 
		/// </summary>
        public string outwork_type
        {
            get { return _outwork_type; }
            set
            {
                if(_outwork_type!=value || _isLoaded){
                    _outwork_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="outwork_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _outwork_addr;
		/// <summary>
		/// 
		/// </summary>
        public string outwork_addr
        {
            get { return _outwork_addr; }
            set
            {
                if(_outwork_addr!=value || _isLoaded){
                    _outwork_addr=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="outwork_addr");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _transportation;
		/// <summary>
		/// 
		/// </summary>
        public string transportation
        {
            get { return _transportation; }
            set
            {
                if(_transportation!=value || _isLoaded){
                    _transportation=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="transportation");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _Re_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? Re_date
        {
            get { return _Re_date; }
            set
            {
                if(_Re_date!=value || _isLoaded){
                    _Re_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Re_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Start_ag;
		/// <summary>
		/// 
		/// </summary>
        public string Start_ag
        {
            get { return _Start_ag; }
            set
            {
                if(_Start_ag!=value || _isLoaded){
                    _Start_ag=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Start_ag");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _re_ag;
		/// <summary>
		/// 
		/// </summary>
        public string re_ag
        {
            get { return _re_ag; }
            set
            {
                if(_re_ag!=value || _isLoaded){
                    _re_ag=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="re_ag");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _peers;
		/// <summary>
		/// 
		/// </summary>
        public int? peers
        {
            get { return _peers; }
            set
            {
                if(_peers!=value || _isLoaded){
                    _peers=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="peers");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Hostel;
		/// <summary>
		/// 
		/// </summary>
        public int? Hostel
        {
            get { return _Hostel; }
            set
            {
                if(_Hostel!=value || _isLoaded){
                    _Hostel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Hostel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _hotel;
		/// <summary>
		/// 
		/// </summary>
        public int? hotel
        {
            get { return _hotel; }
            set
            {
                if(_hotel!=value || _isLoaded){
                    _hotel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hotel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _hotel_type;
		/// <summary>
		/// 
		/// </summary>
        public string hotel_type
        {
            get { return _hotel_type; }
            set
            {
                if(_hotel_type!=value || _isLoaded){
                    _hotel_type=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hotel_type");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _reply;
		/// <summary>
		/// 
		/// </summary>
        public string reply
        {
            get { return _reply; }
            set
            {
                if(_reply!=value || _isLoaded){
                    _reply=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="reply");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _work_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? work_hrs
        {
            get { return _work_hrs; }
            set
            {
                if(_work_hrs!=value || _isLoaded){
                    _work_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="work_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _is_input;
		/// <summary>
		/// 
		/// </summary>
        public short? is_input
        {
            get { return _is_input; }
            set
            {
                if(_is_input!=value || _isLoaded){
                    _is_input=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="is_input");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _refuse_reason;
		/// <summary>
		/// 
		/// </summary>
        public string refuse_reason
        {
            get { return _refuse_reason; }
            set
            {
                if(_refuse_reason!=value || _isLoaded){
                    _refuse_reason=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="refuse_reason");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CHECKER2;
		/// <summary>
		/// 
		/// </summary>
        public string CHECKER2
        {
            get { return _CHECKER2; }
            set
            {
                if(_CHECKER2!=value || _isLoaded){
                    _CHECKER2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CHECKER2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _audit2;
		/// <summary>
		/// 
		/// </summary>
        public short? audit2
        {
            get { return _audit2; }
            set
            {
                if(_audit2!=value || _isLoaded){
                    _audit2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="audit2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _IsHotel;
		/// <summary>
		/// 
		/// </summary>
        public short? IsHotel
        {
            get { return _IsHotel; }
            set
            {
                if(_IsHotel!=value || _isLoaded){
                    _IsHotel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsHotel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _IsCar;
		/// <summary>
		/// 
		/// </summary>
        public short? IsCar
        {
            get { return _IsCar; }
            set
            {
                if(_IsCar!=value || _isLoaded){
                    _IsCar=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IsCar");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Itinerary;
		/// <summary>
		/// 
		/// </summary>
        public string Itinerary
        {
            get { return _Itinerary; }
            set
            {
                if(_Itinerary!=value || _isLoaded){
                    _Itinerary=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Itinerary");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Destination;
		/// <summary>
		/// 
		/// </summary>
        public string Destination
        {
            get { return _Destination; }
            set
            {
                if(_Destination!=value || _isLoaded){
                    _Destination=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Destination");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IDate;
		/// <summary>
		/// 
		/// </summary>
        public string IDate
        {
            get { return _IDate; }
            set
            {
                if(_IDate!=value || _isLoaded){
                    _IDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Nights;
		/// <summary>
		/// 
		/// </summary>
        public string Nights
        {
            get { return _Nights; }
            set
            {
                if(_Nights!=value || _isLoaded){
                    _Nights=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Nights");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _reply2;
		/// <summary>
		/// 
		/// </summary>
        public string reply2
        {
            get { return _reply2; }
            set
            {
                if(_reply2!=value || _isLoaded){
                    _reply2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="reply2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _itinerary2;
		/// <summary>
		/// 
		/// </summary>
        public string itinerary2
        {
            get { return _itinerary2; }
            set
            {
                if(_itinerary2!=value || _isLoaded){
                    _itinerary2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="itinerary2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _itinerary3;
		/// <summary>
		/// 
		/// </summary>
        public string itinerary3
        {
            get { return _itinerary3; }
            set
            {
                if(_itinerary3!=value || _isLoaded){
                    _itinerary3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="itinerary3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _itinerary4;
		/// <summary>
		/// 
		/// </summary>
        public string itinerary4
        {
            get { return _itinerary4; }
            set
            {
                if(_itinerary4!=value || _isLoaded){
                    _itinerary4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="itinerary4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IDate2;
		/// <summary>
		/// 
		/// </summary>
        public string IDate2
        {
            get { return _IDate2; }
            set
            {
                if(_IDate2!=value || _isLoaded){
                    _IDate2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IDate2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IDate3;
		/// <summary>
		/// 
		/// </summary>
        public string IDate3
        {
            get { return _IDate3; }
            set
            {
                if(_IDate3!=value || _isLoaded){
                    _IDate3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IDate3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _IDate4;
		/// <summary>
		/// 
		/// </summary>
        public string IDate4
        {
            get { return _IDate4; }
            set
            {
                if(_IDate4!=value || _isLoaded){
                    _IDate4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="IDate4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Destination2;
		/// <summary>
		/// 
		/// </summary>
        public string Destination2
        {
            get { return _Destination2; }
            set
            {
                if(_Destination2!=value || _isLoaded){
                    _Destination2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Destination2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Destination3;
		/// <summary>
		/// 
		/// </summary>
        public string Destination3
        {
            get { return _Destination3; }
            set
            {
                if(_Destination3!=value || _isLoaded){
                    _Destination3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Destination3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Destination4;
		/// <summary>
		/// 
		/// </summary>
        public string Destination4
        {
            get { return _Destination4; }
            set
            {
                if(_Destination4!=value || _isLoaded){
                    _Destination4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Destination4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Nights2;
		/// <summary>
		/// 
		/// </summary>
        public string Nights2
        {
            get { return _Nights2; }
            set
            {
                if(_Nights2!=value || _isLoaded){
                    _Nights2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Nights2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Nights3;
		/// <summary>
		/// 
		/// </summary>
        public string Nights3
        {
            get { return _Nights3; }
            set
            {
                if(_Nights3!=value || _isLoaded){
                    _Nights3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Nights3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Nights4;
		/// <summary>
		/// 
		/// </summary>
        public string Nights4
        {
            get { return _Nights4; }
            set
            {
                if(_Nights4!=value || _isLoaded){
                    _Nights4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Nights4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _check_date2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? check_date2
        {
            get { return _check_date2; }
            set
            {
                if(_check_date2!=value || _isLoaded){
                    _check_date2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="check_date2");
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


        public static void Delete(Expression<Func<OutWork_D, bool>> expression) {
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

