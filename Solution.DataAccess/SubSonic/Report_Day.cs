 
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
    /// A class which represents the Report_Day table in the HRtest Database.
    /// </summary>
    public partial class Report_Day: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<Report_Day> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<Report_Day>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<Report_Day> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(Report_Day item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                Report_Day item=new Report_Day();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<Report_Day> _repo;
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
        public Report_Day(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                Report_Day.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Report_Day>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public Report_Day(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            emp_id = readRecord.get_string("emp_id",null);
               
            sign_date = readRecord.get_datetime("sign_date",null);
               
            join_id = readRecord.get_int("join_id",null);
               
            cur_kind = readRecord.get_int("cur_kind",null);
               
            depart_id = readRecord.get_string("depart_id",null);
               
            calc_date = readRecord.get_datetime("calc_date",null);
               
            adjusted = readRecord.get_short("adjusted",null);
               
            shift_id = readRecord.get_string("shift_id",null);
               
            status = readRecord.get_byte("status",null);
               
            sign_count = readRecord.get_byte("sign_count",null);
               
            need_sign_count = readRecord.get_int("need_sign_count",null);
               
            in1 = readRecord.get_datetime("in1",null);
               
            out1 = readRecord.get_datetime("out1",null);
               
            in2 = readRecord.get_datetime("in2",null);
               
            out2 = readRecord.get_datetime("out2",null);
               
            in3 = readRecord.get_datetime("in3",null);
               
            out3 = readRecord.get_datetime("out3",null);
               
            in4 = readRecord.get_datetime("in4",null);
               
            out4 = readRecord.get_datetime("out4",null);
               
            in5 = readRecord.get_datetime("in5",null);
               
            out5 = readRecord.get_datetime("out5",null);
               
            plan_days = readRecord.get_decimal("plan_days",null);
               
            sun_days = readRecord.get_decimal("sun_days",null);
               
            hd_days = readRecord.get_decimal("hd_days",null);
               
            duty_days = readRecord.get_decimal("duty_days",null);
               
            work_days = readRecord.get_decimal("work_days",null);
               
            absent_days = readRecord.get_decimal("absent_days",null);
               
            leave_days = readRecord.get_decimal("leave_days",null);
               
            fact_hrs = readRecord.get_decimal("fact_hrs",null);
               
            basic_hrs = readRecord.get_decimal("basic_hrs",null);
               
            mid_hrs = readRecord.get_decimal("mid_hrs",null);
               
            ns_hrs = readRecord.get_decimal("ns_hrs",null);
               
            ot_hrs = readRecord.get_decimal("ot_hrs",null);
               
            sun_hrs = readRecord.get_decimal("sun_hrs",null);
               
            hd_hrs = readRecord.get_decimal("hd_hrs",null);
               
            absent_hrs = readRecord.get_decimal("absent_hrs",null);
               
            input_ot_hrs = readRecord.get_decimal("input_ot_hrs",null);
               
            late_mins = readRecord.get_decimal("late_mins",null);
               
            late_count = readRecord.get_decimal("late_count",null);
               
            leave_mins = readRecord.get_decimal("leave_mins",null);
               
            leave_count = readRecord.get_decimal("leave_count",null);
               
            ot_late_mins = readRecord.get_decimal("ot_late_mins",null);
               
            ot_leave_mins = readRecord.get_decimal("ot_leave_mins",null);
               
            ot_late_count = readRecord.get_decimal("ot_late_count",null);
               
            ot_leave_count = readRecord.get_decimal("ot_leave_count",null);
               
            ns_count = readRecord.get_decimal("ns_count",null);
               
            mid_count = readRecord.get_decimal("mid_count",null);
               
            ot_count = readRecord.get_decimal("ot_count",null);
               
            absent_count = readRecord.get_decimal("absent_count",null);
               
            l0hrs = readRecord.get_decimal("l0hrs",null);
               
            l1hrs = readRecord.get_decimal("l1hrs",null);
               
            l2hrs = readRecord.get_decimal("l2hrs",null);
               
            l3hrs = readRecord.get_decimal("l3hrs",null);
               
            l4hrs = readRecord.get_decimal("l4hrs",null);
               
            l5hrs = readRecord.get_decimal("l5hrs",null);
               
            l6hrs = readRecord.get_decimal("l6hrs",null);
               
            l7hrs = readRecord.get_decimal("l7hrs",null);
               
            l8hrs = readRecord.get_decimal("l8hrs",null);
               
            L9hrs = readRecord.get_decimal("L9hrs",null);
               
            l10hrs = readRecord.get_decimal("l10hrs",null);
               
            l11hrs = readRecord.get_decimal("l11hrs",null);
               
            l12hrs = readRecord.get_decimal("l12hrs",null);
               
            l13hrs = readRecord.get_decimal("l13hrs",null);
               
            l14hrs = readRecord.get_decimal("l14hrs",null);
               
            l15hrs = readRecord.get_decimal("l15hrs",null);
               
            outwork_hrs = readRecord.get_decimal("outwork_hrs",null);
               
            shutdown_hrs = readRecord.get_decimal("shutdown_hrs",null);
               
            outwork_days = readRecord.get_decimal("outwork_days",null);
               
            shutdown_days = readRecord.get_decimal("shutdown_days",null);
               
            notes = readRecord.get_string("notes",null);
               
            shift_hrs = readRecord.get_decimal("shift_hrs",null);
               
            onwatch_hrs = readRecord.get_decimal("onwatch_hrs",null);
               
            audit = readRecord.get_short("audit",null);
               
            l0day = readRecord.get_decimal("l0day",null);
               
            l1day = readRecord.get_decimal("l1day",null);
               
            l2day = readRecord.get_decimal("l2day",null);
               
            l3day = readRecord.get_decimal("l3day",null);
               
            l4day = readRecord.get_decimal("l4day",null);
               
            l5day = readRecord.get_decimal("l5day",null);
               
            l6day = readRecord.get_decimal("l6day",null);
               
            l7day = readRecord.get_decimal("l7day",null);
               
            l8day = readRecord.get_decimal("l8day",null);
               
            L9day = readRecord.get_decimal("L9day",null);
               
            l10day = readRecord.get_decimal("l10day",null);
               
            l11day = readRecord.get_decimal("l11day",null);
               
            l12day = readRecord.get_decimal("l12day",null);
               
            l13day = readRecord.get_decimal("l13day",null);
               
            l14day = readRecord.get_decimal("l14day",null);
               
            l15day = readRecord.get_decimal("l15day",null);
               
            outwork_count = readRecord.get_decimal("outwork_count",null);
               
            shutdown_count = readRecord.get_decimal("shutdown_count",null);
               
            l0count = readRecord.get_decimal("l0count",null);
               
            l1count = readRecord.get_decimal("l1count",null);
               
            l2count = readRecord.get_decimal("l2count",null);
               
            l3count = readRecord.get_decimal("l3count",null);
               
            l4count = readRecord.get_decimal("l4count",null);
               
            l5count = readRecord.get_decimal("l5count",null);
               
            l6count = readRecord.get_decimal("l6count",null);
               
            l7count = readRecord.get_decimal("l7count",null);
               
            l8count = readRecord.get_decimal("l8count",null);
               
            L9count = readRecord.get_decimal("L9count",null);
               
            l10count = readRecord.get_decimal("l10count",null);
               
            l11count = readRecord.get_decimal("l11count",null);
               
            l12count = readRecord.get_decimal("l12count",null);
               
            l13count = readRecord.get_decimal("l13count",null);
               
            l14count = readRecord.get_decimal("l14count",null);
               
            l15count = readRecord.get_decimal("l15count",null);
               
            ot_sun_day = readRecord.get_decimal("ot_sun_day",null);
               
            ot_nd_day = readRecord.get_decimal("ot_nd_day",null);
               
            bait_hrs = readRecord.get_decimal("bait_hrs",null);
               
            lesshrs_count = readRecord.get_int("lesshrs_count",null);
               
            over_hrs = readRecord.get_decimal("over_hrs",null);
               
            late1_min = readRecord.get_decimal("late1_min",null);
               
            late2_min = readRecord.get_decimal("late2_min",null);
               
            late3_min = readRecord.get_decimal("late3_min",null);
               
            late4_min = readRecord.get_decimal("late4_min",null);
               
            late5_min = readRecord.get_decimal("late5_min",null);
               
            leave1_min = readRecord.get_decimal("leave1_min",null);
               
            leave2_min = readRecord.get_decimal("leave2_min",null);
               
            leave3_min = readRecord.get_decimal("leave3_min",null);
               
            leave4_min = readRecord.get_decimal("leave4_min",null);
               
            leave5_min = readRecord.get_decimal("leave5_min",null);
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

        public Report_Day(Expression<Func<Report_Day, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<Report_Day> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<Report_Day> _repo;
            
            if(db.TestMode){
                Report_Day.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<Report_Day>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<Report_Day> GetRepo(){
            return GetRepo("","");
        }
        
        public static Report_Day SingleOrDefault(Expression<Func<Report_Day, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            Report_Day single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static Report_Day SingleOrDefault(Expression<Func<Report_Day, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            Report_Day single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<Report_Day, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<Report_Day, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<Report_Day> Find(Expression<Func<Report_Day, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<Report_Day> Find(Expression<Func<Report_Day, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<Report_Day> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<Report_Day> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<Report_Day> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<Report_Day> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<Report_Day> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<Report_Day> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "join_id";
        }

        public object KeyValue()
        {
            return this.join_id;
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
			sb.Append("sign_date=" + sign_date + "; ");
			sb.Append("join_id=" + join_id + "; ");
			sb.Append("cur_kind=" + cur_kind + "; ");
			sb.Append("depart_id=" + depart_id + "; ");
			sb.Append("calc_date=" + calc_date + "; ");
			sb.Append("adjusted=" + adjusted + "; ");
			sb.Append("shift_id=" + shift_id + "; ");
			sb.Append("status=" + status + "; ");
			sb.Append("sign_count=" + sign_count + "; ");
			sb.Append("need_sign_count=" + need_sign_count + "; ");
			sb.Append("in1=" + in1 + "; ");
			sb.Append("out1=" + out1 + "; ");
			sb.Append("in2=" + in2 + "; ");
			sb.Append("out2=" + out2 + "; ");
			sb.Append("in3=" + in3 + "; ");
			sb.Append("out3=" + out3 + "; ");
			sb.Append("in4=" + in4 + "; ");
			sb.Append("out4=" + out4 + "; ");
			sb.Append("in5=" + in5 + "; ");
			sb.Append("out5=" + out5 + "; ");
			sb.Append("plan_days=" + plan_days + "; ");
			sb.Append("sun_days=" + sun_days + "; ");
			sb.Append("hd_days=" + hd_days + "; ");
			sb.Append("duty_days=" + duty_days + "; ");
			sb.Append("work_days=" + work_days + "; ");
			sb.Append("absent_days=" + absent_days + "; ");
			sb.Append("leave_days=" + leave_days + "; ");
			sb.Append("fact_hrs=" + fact_hrs + "; ");
			sb.Append("basic_hrs=" + basic_hrs + "; ");
			sb.Append("mid_hrs=" + mid_hrs + "; ");
			sb.Append("ns_hrs=" + ns_hrs + "; ");
			sb.Append("ot_hrs=" + ot_hrs + "; ");
			sb.Append("sun_hrs=" + sun_hrs + "; ");
			sb.Append("hd_hrs=" + hd_hrs + "; ");
			sb.Append("absent_hrs=" + absent_hrs + "; ");
			sb.Append("input_ot_hrs=" + input_ot_hrs + "; ");
			sb.Append("late_mins=" + late_mins + "; ");
			sb.Append("late_count=" + late_count + "; ");
			sb.Append("leave_mins=" + leave_mins + "; ");
			sb.Append("leave_count=" + leave_count + "; ");
			sb.Append("ot_late_mins=" + ot_late_mins + "; ");
			sb.Append("ot_leave_mins=" + ot_leave_mins + "; ");
			sb.Append("ot_late_count=" + ot_late_count + "; ");
			sb.Append("ot_leave_count=" + ot_leave_count + "; ");
			sb.Append("ns_count=" + ns_count + "; ");
			sb.Append("mid_count=" + mid_count + "; ");
			sb.Append("ot_count=" + ot_count + "; ");
			sb.Append("absent_count=" + absent_count + "; ");
			sb.Append("l0hrs=" + l0hrs + "; ");
			sb.Append("l1hrs=" + l1hrs + "; ");
			sb.Append("l2hrs=" + l2hrs + "; ");
			sb.Append("l3hrs=" + l3hrs + "; ");
			sb.Append("l4hrs=" + l4hrs + "; ");
			sb.Append("l5hrs=" + l5hrs + "; ");
			sb.Append("l6hrs=" + l6hrs + "; ");
			sb.Append("l7hrs=" + l7hrs + "; ");
			sb.Append("l8hrs=" + l8hrs + "; ");
			sb.Append("L9hrs=" + L9hrs + "; ");
			sb.Append("l10hrs=" + l10hrs + "; ");
			sb.Append("l11hrs=" + l11hrs + "; ");
			sb.Append("l12hrs=" + l12hrs + "; ");
			sb.Append("l13hrs=" + l13hrs + "; ");
			sb.Append("l14hrs=" + l14hrs + "; ");
			sb.Append("l15hrs=" + l15hrs + "; ");
			sb.Append("outwork_hrs=" + outwork_hrs + "; ");
			sb.Append("shutdown_hrs=" + shutdown_hrs + "; ");
			sb.Append("outwork_days=" + outwork_days + "; ");
			sb.Append("shutdown_days=" + shutdown_days + "; ");
			sb.Append("notes=" + notes + "; ");
			sb.Append("shift_hrs=" + shift_hrs + "; ");
			sb.Append("onwatch_hrs=" + onwatch_hrs + "; ");
			sb.Append("audit=" + audit + "; ");
			sb.Append("l0day=" + l0day + "; ");
			sb.Append("l1day=" + l1day + "; ");
			sb.Append("l2day=" + l2day + "; ");
			sb.Append("l3day=" + l3day + "; ");
			sb.Append("l4day=" + l4day + "; ");
			sb.Append("l5day=" + l5day + "; ");
			sb.Append("l6day=" + l6day + "; ");
			sb.Append("l7day=" + l7day + "; ");
			sb.Append("l8day=" + l8day + "; ");
			sb.Append("L9day=" + L9day + "; ");
			sb.Append("l10day=" + l10day + "; ");
			sb.Append("l11day=" + l11day + "; ");
			sb.Append("l12day=" + l12day + "; ");
			sb.Append("l13day=" + l13day + "; ");
			sb.Append("l14day=" + l14day + "; ");
			sb.Append("l15day=" + l15day + "; ");
			sb.Append("outwork_count=" + outwork_count + "; ");
			sb.Append("shutdown_count=" + shutdown_count + "; ");
			sb.Append("l0count=" + l0count + "; ");
			sb.Append("l1count=" + l1count + "; ");
			sb.Append("l2count=" + l2count + "; ");
			sb.Append("l3count=" + l3count + "; ");
			sb.Append("l4count=" + l4count + "; ");
			sb.Append("l5count=" + l5count + "; ");
			sb.Append("l6count=" + l6count + "; ");
			sb.Append("l7count=" + l7count + "; ");
			sb.Append("l8count=" + l8count + "; ");
			sb.Append("L9count=" + L9count + "; ");
			sb.Append("l10count=" + l10count + "; ");
			sb.Append("l11count=" + l11count + "; ");
			sb.Append("l12count=" + l12count + "; ");
			sb.Append("l13count=" + l13count + "; ");
			sb.Append("l14count=" + l14count + "; ");
			sb.Append("l15count=" + l15count + "; ");
			sb.Append("ot_sun_day=" + ot_sun_day + "; ");
			sb.Append("ot_nd_day=" + ot_nd_day + "; ");
			sb.Append("bait_hrs=" + bait_hrs + "; ");
			sb.Append("lesshrs_count=" + lesshrs_count + "; ");
			sb.Append("over_hrs=" + over_hrs + "; ");
			sb.Append("late1_min=" + late1_min + "; ");
			sb.Append("late2_min=" + late2_min + "; ");
			sb.Append("late3_min=" + late3_min + "; ");
			sb.Append("late4_min=" + late4_min + "; ");
			sb.Append("late5_min=" + late5_min + "; ");
			sb.Append("leave1_min=" + leave1_min + "; ");
			sb.Append("leave2_min=" + leave2_min + "; ");
			sb.Append("leave3_min=" + leave3_min + "; ");
			sb.Append("leave4_min=" + leave4_min + "; ");
			sb.Append("leave5_min=" + leave5_min + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(Report_Day)){
                Report_Day compare=(Report_Day)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.join_id;
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
            return "join_id";
        }        
        public static string GetDescriptorColumn()
        {
            return "emp_id";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        long _Id;
		/// <summary>
		/// 
		/// </summary>
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

        DateTime _sign_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime sign_date
        {
            get { return _sign_date; }
            set
            {
                if(_sign_date!=value || _isLoaded){
                    _sign_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sign_date");
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
		[SubSonicPrimaryKey]
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

        int? _cur_kind;
		/// <summary>
		/// 
		/// </summary>
        public int? cur_kind
        {
            get { return _cur_kind; }
            set
            {
                if(_cur_kind!=value || _isLoaded){
                    _cur_kind=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="cur_kind");
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

        DateTime _calc_date;
		/// <summary>
		/// 
		/// </summary>
        public DateTime calc_date
        {
            get { return _calc_date; }
            set
            {
                if(_calc_date!=value || _isLoaded){
                    _calc_date=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="calc_date");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _adjusted;
		/// <summary>
		/// 
		/// </summary>
        public short? adjusted
        {
            get { return _adjusted; }
            set
            {
                if(_adjusted!=value || _isLoaded){
                    _adjusted=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="adjusted");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _shift_id;
		/// <summary>
		/// 
		/// </summary>
        public string shift_id
        {
            get { return _shift_id; }
            set
            {
                if(_shift_id!=value || _isLoaded){
                    _shift_id=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="shift_id");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _status;
		/// <summary>
		/// 
		/// </summary>
        public byte? status
        {
            get { return _status; }
            set
            {
                if(_status!=value || _isLoaded){
                    _status=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="status");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _sign_count;
		/// <summary>
		/// 
		/// </summary>
        public byte? sign_count
        {
            get { return _sign_count; }
            set
            {
                if(_sign_count!=value || _isLoaded){
                    _sign_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sign_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _need_sign_count;
		/// <summary>
		/// 
		/// </summary>
        public int? need_sign_count
        {
            get { return _need_sign_count; }
            set
            {
                if(_need_sign_count!=value || _isLoaded){
                    _need_sign_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="need_sign_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _in1;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? in1
        {
            get { return _in1; }
            set
            {
                if(_in1!=value || _isLoaded){
                    _in1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="in1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _out1;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? out1
        {
            get { return _out1; }
            set
            {
                if(_out1!=value || _isLoaded){
                    _out1=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="out1");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _in2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? in2
        {
            get { return _in2; }
            set
            {
                if(_in2!=value || _isLoaded){
                    _in2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="in2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _out2;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? out2
        {
            get { return _out2; }
            set
            {
                if(_out2!=value || _isLoaded){
                    _out2=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="out2");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _in3;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? in3
        {
            get { return _in3; }
            set
            {
                if(_in3!=value || _isLoaded){
                    _in3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="in3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _out3;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? out3
        {
            get { return _out3; }
            set
            {
                if(_out3!=value || _isLoaded){
                    _out3=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="out3");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _in4;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? in4
        {
            get { return _in4; }
            set
            {
                if(_in4!=value || _isLoaded){
                    _in4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="in4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _out4;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? out4
        {
            get { return _out4; }
            set
            {
                if(_out4!=value || _isLoaded){
                    _out4=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="out4");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _in5;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? in5
        {
            get { return _in5; }
            set
            {
                if(_in5!=value || _isLoaded){
                    _in5=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="in5");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _out5;
		/// <summary>
		/// 
		/// </summary>
        public DateTime? out5
        {
            get { return _out5; }
            set
            {
                if(_out5!=value || _isLoaded){
                    _out5=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="out5");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _plan_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? plan_days
        {
            get { return _plan_days; }
            set
            {
                if(_plan_days!=value || _isLoaded){
                    _plan_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="plan_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _sun_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? sun_days
        {
            get { return _sun_days; }
            set
            {
                if(_sun_days!=value || _isLoaded){
                    _sun_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sun_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _hd_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? hd_days
        {
            get { return _hd_days; }
            set
            {
                if(_hd_days!=value || _isLoaded){
                    _hd_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _duty_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? duty_days
        {
            get { return _duty_days; }
            set
            {
                if(_duty_days!=value || _isLoaded){
                    _duty_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="duty_days");
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

        decimal? _absent_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? absent_days
        {
            get { return _absent_days; }
            set
            {
                if(_absent_days!=value || _isLoaded){
                    _absent_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="absent_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave_days
        {
            get { return _leave_days; }
            set
            {
                if(_leave_days!=value || _isLoaded){
                    _leave_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _fact_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? fact_hrs
        {
            get { return _fact_hrs; }
            set
            {
                if(_fact_hrs!=value || _isLoaded){
                    _fact_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="fact_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _basic_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? basic_hrs
        {
            get { return _basic_hrs; }
            set
            {
                if(_basic_hrs!=value || _isLoaded){
                    _basic_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="basic_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _mid_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? mid_hrs
        {
            get { return _mid_hrs; }
            set
            {
                if(_mid_hrs!=value || _isLoaded){
                    _mid_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="mid_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ns_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ns_hrs
        {
            get { return _ns_hrs; }
            set
            {
                if(_ns_hrs!=value || _isLoaded){
                    _ns_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ns_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_hrs
        {
            get { return _ot_hrs; }
            set
            {
                if(_ot_hrs!=value || _isLoaded){
                    _ot_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _sun_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? sun_hrs
        {
            get { return _sun_hrs; }
            set
            {
                if(_sun_hrs!=value || _isLoaded){
                    _sun_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="sun_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _hd_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? hd_hrs
        {
            get { return _hd_hrs; }
            set
            {
                if(_hd_hrs!=value || _isLoaded){
                    _hd_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="hd_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _absent_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? absent_hrs
        {
            get { return _absent_hrs; }
            set
            {
                if(_absent_hrs!=value || _isLoaded){
                    _absent_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="absent_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _input_ot_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? input_ot_hrs
        {
            get { return _input_ot_hrs; }
            set
            {
                if(_input_ot_hrs!=value || _isLoaded){
                    _input_ot_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="input_ot_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late_mins;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late_mins
        {
            get { return _late_mins; }
            set
            {
                if(_late_mins!=value || _isLoaded){
                    _late_mins=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late_mins");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late_count
        {
            get { return _late_count; }
            set
            {
                if(_late_count!=value || _isLoaded){
                    _late_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave_mins;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave_mins
        {
            get { return _leave_mins; }
            set
            {
                if(_leave_mins!=value || _isLoaded){
                    _leave_mins=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave_mins");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave_count
        {
            get { return _leave_count; }
            set
            {
                if(_leave_count!=value || _isLoaded){
                    _leave_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_late_mins;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_late_mins
        {
            get { return _ot_late_mins; }
            set
            {
                if(_ot_late_mins!=value || _isLoaded){
                    _ot_late_mins=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_late_mins");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_leave_mins;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_leave_mins
        {
            get { return _ot_leave_mins; }
            set
            {
                if(_ot_leave_mins!=value || _isLoaded){
                    _ot_leave_mins=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_leave_mins");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_late_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_late_count
        {
            get { return _ot_late_count; }
            set
            {
                if(_ot_late_count!=value || _isLoaded){
                    _ot_late_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_late_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_leave_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_leave_count
        {
            get { return _ot_leave_count; }
            set
            {
                if(_ot_leave_count!=value || _isLoaded){
                    _ot_leave_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_leave_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ns_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ns_count
        {
            get { return _ns_count; }
            set
            {
                if(_ns_count!=value || _isLoaded){
                    _ns_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ns_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _mid_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? mid_count
        {
            get { return _mid_count; }
            set
            {
                if(_mid_count!=value || _isLoaded){
                    _mid_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="mid_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_count
        {
            get { return _ot_count; }
            set
            {
                if(_ot_count!=value || _isLoaded){
                    _ot_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _absent_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? absent_count
        {
            get { return _absent_count; }
            set
            {
                if(_absent_count!=value || _isLoaded){
                    _absent_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="absent_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l0hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l0hrs
        {
            get { return _l0hrs; }
            set
            {
                if(_l0hrs!=value || _isLoaded){
                    _l0hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l0hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l1hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l1hrs
        {
            get { return _l1hrs; }
            set
            {
                if(_l1hrs!=value || _isLoaded){
                    _l1hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l1hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l2hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l2hrs
        {
            get { return _l2hrs; }
            set
            {
                if(_l2hrs!=value || _isLoaded){
                    _l2hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l2hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l3hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l3hrs
        {
            get { return _l3hrs; }
            set
            {
                if(_l3hrs!=value || _isLoaded){
                    _l3hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l3hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l4hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l4hrs
        {
            get { return _l4hrs; }
            set
            {
                if(_l4hrs!=value || _isLoaded){
                    _l4hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l4hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l5hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l5hrs
        {
            get { return _l5hrs; }
            set
            {
                if(_l5hrs!=value || _isLoaded){
                    _l5hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l5hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l6hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l6hrs
        {
            get { return _l6hrs; }
            set
            {
                if(_l6hrs!=value || _isLoaded){
                    _l6hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l6hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l7hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l7hrs
        {
            get { return _l7hrs; }
            set
            {
                if(_l7hrs!=value || _isLoaded){
                    _l7hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l7hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l8hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l8hrs
        {
            get { return _l8hrs; }
            set
            {
                if(_l8hrs!=value || _isLoaded){
                    _l8hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l8hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _L9hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? L9hrs
        {
            get { return _L9hrs; }
            set
            {
                if(_L9hrs!=value || _isLoaded){
                    _L9hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="L9hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l10hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l10hrs
        {
            get { return _l10hrs; }
            set
            {
                if(_l10hrs!=value || _isLoaded){
                    _l10hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l10hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l11hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l11hrs
        {
            get { return _l11hrs; }
            set
            {
                if(_l11hrs!=value || _isLoaded){
                    _l11hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l11hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l12hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l12hrs
        {
            get { return _l12hrs; }
            set
            {
                if(_l12hrs!=value || _isLoaded){
                    _l12hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l12hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l13hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l13hrs
        {
            get { return _l13hrs; }
            set
            {
                if(_l13hrs!=value || _isLoaded){
                    _l13hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l13hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l14hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l14hrs
        {
            get { return _l14hrs; }
            set
            {
                if(_l14hrs!=value || _isLoaded){
                    _l14hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l14hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l15hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l15hrs
        {
            get { return _l15hrs; }
            set
            {
                if(_l15hrs!=value || _isLoaded){
                    _l15hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l15hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _outwork_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? outwork_hrs
        {
            get { return _outwork_hrs; }
            set
            {
                if(_outwork_hrs!=value || _isLoaded){
                    _outwork_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="outwork_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _shutdown_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? shutdown_hrs
        {
            get { return _shutdown_hrs; }
            set
            {
                if(_shutdown_hrs!=value || _isLoaded){
                    _shutdown_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="shutdown_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _outwork_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? outwork_days
        {
            get { return _outwork_days; }
            set
            {
                if(_outwork_days!=value || _isLoaded){
                    _outwork_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="outwork_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _shutdown_days;
		/// <summary>
		/// 
		/// </summary>
        public decimal? shutdown_days
        {
            get { return _shutdown_days; }
            set
            {
                if(_shutdown_days!=value || _isLoaded){
                    _shutdown_days=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="shutdown_days");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _notes;
		/// <summary>
		/// 
		/// </summary>
        public string notes
        {
            get { return _notes; }
            set
            {
                if(_notes!=value || _isLoaded){
                    _notes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="notes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _shift_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? shift_hrs
        {
            get { return _shift_hrs; }
            set
            {
                if(_shift_hrs!=value || _isLoaded){
                    _shift_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="shift_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _onwatch_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? onwatch_hrs
        {
            get { return _onwatch_hrs; }
            set
            {
                if(_onwatch_hrs!=value || _isLoaded){
                    _onwatch_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="onwatch_hrs");
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

        decimal? _l0day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l0day
        {
            get { return _l0day; }
            set
            {
                if(_l0day!=value || _isLoaded){
                    _l0day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l0day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l1day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l1day
        {
            get { return _l1day; }
            set
            {
                if(_l1day!=value || _isLoaded){
                    _l1day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l1day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l2day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l2day
        {
            get { return _l2day; }
            set
            {
                if(_l2day!=value || _isLoaded){
                    _l2day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l2day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l3day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l3day
        {
            get { return _l3day; }
            set
            {
                if(_l3day!=value || _isLoaded){
                    _l3day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l3day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l4day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l4day
        {
            get { return _l4day; }
            set
            {
                if(_l4day!=value || _isLoaded){
                    _l4day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l4day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l5day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l5day
        {
            get { return _l5day; }
            set
            {
                if(_l5day!=value || _isLoaded){
                    _l5day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l5day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l6day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l6day
        {
            get { return _l6day; }
            set
            {
                if(_l6day!=value || _isLoaded){
                    _l6day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l6day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l7day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l7day
        {
            get { return _l7day; }
            set
            {
                if(_l7day!=value || _isLoaded){
                    _l7day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l7day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l8day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l8day
        {
            get { return _l8day; }
            set
            {
                if(_l8day!=value || _isLoaded){
                    _l8day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l8day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _L9day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? L9day
        {
            get { return _L9day; }
            set
            {
                if(_L9day!=value || _isLoaded){
                    _L9day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="L9day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l10day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l10day
        {
            get { return _l10day; }
            set
            {
                if(_l10day!=value || _isLoaded){
                    _l10day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l10day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l11day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l11day
        {
            get { return _l11day; }
            set
            {
                if(_l11day!=value || _isLoaded){
                    _l11day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l11day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l12day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l12day
        {
            get { return _l12day; }
            set
            {
                if(_l12day!=value || _isLoaded){
                    _l12day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l12day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l13day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l13day
        {
            get { return _l13day; }
            set
            {
                if(_l13day!=value || _isLoaded){
                    _l13day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l13day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l14day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l14day
        {
            get { return _l14day; }
            set
            {
                if(_l14day!=value || _isLoaded){
                    _l14day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l14day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l15day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l15day
        {
            get { return _l15day; }
            set
            {
                if(_l15day!=value || _isLoaded){
                    _l15day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l15day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _outwork_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? outwork_count
        {
            get { return _outwork_count; }
            set
            {
                if(_outwork_count!=value || _isLoaded){
                    _outwork_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="outwork_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _shutdown_count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? shutdown_count
        {
            get { return _shutdown_count; }
            set
            {
                if(_shutdown_count!=value || _isLoaded){
                    _shutdown_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="shutdown_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l0count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l0count
        {
            get { return _l0count; }
            set
            {
                if(_l0count!=value || _isLoaded){
                    _l0count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l0count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l1count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l1count
        {
            get { return _l1count; }
            set
            {
                if(_l1count!=value || _isLoaded){
                    _l1count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l1count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l2count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l2count
        {
            get { return _l2count; }
            set
            {
                if(_l2count!=value || _isLoaded){
                    _l2count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l2count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l3count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l3count
        {
            get { return _l3count; }
            set
            {
                if(_l3count!=value || _isLoaded){
                    _l3count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l3count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l4count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l4count
        {
            get { return _l4count; }
            set
            {
                if(_l4count!=value || _isLoaded){
                    _l4count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l4count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l5count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l5count
        {
            get { return _l5count; }
            set
            {
                if(_l5count!=value || _isLoaded){
                    _l5count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l5count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l6count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l6count
        {
            get { return _l6count; }
            set
            {
                if(_l6count!=value || _isLoaded){
                    _l6count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l6count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l7count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l7count
        {
            get { return _l7count; }
            set
            {
                if(_l7count!=value || _isLoaded){
                    _l7count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l7count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l8count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l8count
        {
            get { return _l8count; }
            set
            {
                if(_l8count!=value || _isLoaded){
                    _l8count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l8count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _L9count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? L9count
        {
            get { return _L9count; }
            set
            {
                if(_L9count!=value || _isLoaded){
                    _L9count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="L9count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l10count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l10count
        {
            get { return _l10count; }
            set
            {
                if(_l10count!=value || _isLoaded){
                    _l10count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l10count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l11count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l11count
        {
            get { return _l11count; }
            set
            {
                if(_l11count!=value || _isLoaded){
                    _l11count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l11count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l12count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l12count
        {
            get { return _l12count; }
            set
            {
                if(_l12count!=value || _isLoaded){
                    _l12count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l12count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l13count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l13count
        {
            get { return _l13count; }
            set
            {
                if(_l13count!=value || _isLoaded){
                    _l13count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l13count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l14count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l14count
        {
            get { return _l14count; }
            set
            {
                if(_l14count!=value || _isLoaded){
                    _l14count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l14count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _l15count;
		/// <summary>
		/// 
		/// </summary>
        public decimal? l15count
        {
            get { return _l15count; }
            set
            {
                if(_l15count!=value || _isLoaded){
                    _l15count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="l15count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_sun_day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_sun_day
        {
            get { return _ot_sun_day; }
            set
            {
                if(_ot_sun_day!=value || _isLoaded){
                    _ot_sun_day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_sun_day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _ot_nd_day;
		/// <summary>
		/// 
		/// </summary>
        public decimal? ot_nd_day
        {
            get { return _ot_nd_day; }
            set
            {
                if(_ot_nd_day!=value || _isLoaded){
                    _ot_nd_day=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ot_nd_day");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _bait_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? bait_hrs
        {
            get { return _bait_hrs; }
            set
            {
                if(_bait_hrs!=value || _isLoaded){
                    _bait_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="bait_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _lesshrs_count;
		/// <summary>
		/// 
		/// </summary>
        public int? lesshrs_count
        {
            get { return _lesshrs_count; }
            set
            {
                if(_lesshrs_count!=value || _isLoaded){
                    _lesshrs_count=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="lesshrs_count");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _over_hrs;
		/// <summary>
		/// 
		/// </summary>
        public decimal? over_hrs
        {
            get { return _over_hrs; }
            set
            {
                if(_over_hrs!=value || _isLoaded){
                    _over_hrs=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="over_hrs");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late1_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late1_min
        {
            get { return _late1_min; }
            set
            {
                if(_late1_min!=value || _isLoaded){
                    _late1_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late1_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late2_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late2_min
        {
            get { return _late2_min; }
            set
            {
                if(_late2_min!=value || _isLoaded){
                    _late2_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late2_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late3_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late3_min
        {
            get { return _late3_min; }
            set
            {
                if(_late3_min!=value || _isLoaded){
                    _late3_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late3_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late4_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late4_min
        {
            get { return _late4_min; }
            set
            {
                if(_late4_min!=value || _isLoaded){
                    _late4_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late4_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _late5_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? late5_min
        {
            get { return _late5_min; }
            set
            {
                if(_late5_min!=value || _isLoaded){
                    _late5_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="late5_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave1_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave1_min
        {
            get { return _leave1_min; }
            set
            {
                if(_leave1_min!=value || _isLoaded){
                    _leave1_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave1_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave2_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave2_min
        {
            get { return _leave2_min; }
            set
            {
                if(_leave2_min!=value || _isLoaded){
                    _leave2_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave2_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave3_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave3_min
        {
            get { return _leave3_min; }
            set
            {
                if(_leave3_min!=value || _isLoaded){
                    _leave3_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave3_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave4_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave4_min
        {
            get { return _leave4_min; }
            set
            {
                if(_leave4_min!=value || _isLoaded){
                    _leave4_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave4_min");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _leave5_min;
		/// <summary>
		/// 
		/// </summary>
        public decimal? leave5_min
        {
            get { return _leave5_min; }
            set
            {
                if(_leave5_min!=value || _isLoaded){
                    _leave5_min=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="leave5_min");
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


        public static void Delete(Expression<Func<Report_Day, bool>> expression) {
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

