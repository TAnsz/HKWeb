 
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
    /// A class which represents the RoomMoment table in the HRtest Database.
    /// </summary>
    public partial class RoomMoment: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<RoomMoment> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<RoomMoment>(new Solution.DataAccess.DataModel.HRtestDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<RoomMoment> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(RoomMoment item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                RoomMoment item=new RoomMoment();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<RoomMoment> _repo;
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
        public RoomMoment(string connectionString, string providerName) {

            _db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                RoomMoment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RoomMoment>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public RoomMoment(){
			_db=new Solution.DataAccess.DataModel.HRtestDB();
            Init();            
        }

		public void ORMapping(IDataRecord dataRecord)
        {
            IReadRecord readRecord = SqlReadRecord.GetIReadRecord();
            readRecord.DataRecord = dataRecord;   
               
            Id = readRecord.get_long("Id",null);
               
            MeetingRoom_Code = readRecord.get_string("MeetingRoom_Code",null);
               
            MeetingRoom_Name = readRecord.get_string("MeetingRoom_Name",null);
               
            RoomDate = readRecord.get_datetime("RoomDate",null);
               
            T0800 = readRecord.get_byte("T0800",null);
               
            T0830 = readRecord.get_byte("T0830",null);
               
            T0900 = readRecord.get_byte("T0900",null);
               
            T0930 = readRecord.get_byte("T0930",null);
               
            T1000 = readRecord.get_byte("T1000",null);
               
            T1030 = readRecord.get_byte("T1030",null);
               
            T1100 = readRecord.get_byte("T1100",null);
               
            T1130 = readRecord.get_byte("T1130",null);
               
            T1200 = readRecord.get_byte("T1200",null);
               
            T1230 = readRecord.get_byte("T1230",null);
               
            T1300 = readRecord.get_byte("T1300",null);
               
            T1330 = readRecord.get_byte("T1330",null);
               
            T1400 = readRecord.get_byte("T1400",null);
               
            T1430 = readRecord.get_byte("T1430",null);
               
            T1500 = readRecord.get_byte("T1500",null);
               
            T1530 = readRecord.get_byte("T1530",null);
               
            T1600 = readRecord.get_byte("T1600",null);
               
            T1630 = readRecord.get_byte("T1630",null);
               
            T1700 = readRecord.get_byte("T1700",null);
               
            T1730 = readRecord.get_byte("T1730",null);
               
            T1800 = readRecord.get_byte("T1800",null);
               
            T1830 = readRecord.get_byte("T1830",null);
               
            T1900 = readRecord.get_byte("T1900",null);
               
            T1930 = readRecord.get_byte("T1930",null);
               
            T2000 = readRecord.get_byte("T2000",null);
               
            T2030 = readRecord.get_byte("T2030",null);
               
            T2100 = readRecord.get_byte("T2100",null);
               
            T2130 = readRecord.get_byte("T2130",null);
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

        public RoomMoment(Expression<Func<RoomMoment, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<RoomMoment> GetRepo(string connectionString, string providerName){
            Solution.DataAccess.DataModel.HRtestDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Solution.DataAccess.DataModel.HRtestDB();
            }else{
                db=new Solution.DataAccess.DataModel.HRtestDB(connectionString, providerName);
            }
            IRepository<RoomMoment> _repo;
            
            if(db.TestMode){
                RoomMoment.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<RoomMoment>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<RoomMoment> GetRepo(){
            return GetRepo("","");
        }
        
        public static RoomMoment SingleOrDefault(Expression<Func<RoomMoment, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            RoomMoment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static RoomMoment SingleOrDefault(Expression<Func<RoomMoment, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            RoomMoment single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<RoomMoment, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<RoomMoment, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<RoomMoment> Find(Expression<Func<RoomMoment, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<RoomMoment> Find(Expression<Func<RoomMoment, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<RoomMoment> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<RoomMoment> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<RoomMoment> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<RoomMoment> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<RoomMoment> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<RoomMoment> GetPaged(int pageIndex, int pageSize) {
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
			sb.Append("MeetingRoom_Code=" + MeetingRoom_Code + "; ");
			sb.Append("MeetingRoom_Name=" + MeetingRoom_Name + "; ");
			sb.Append("RoomDate=" + RoomDate + "; ");
			sb.Append("T0800=" + T0800 + "; ");
			sb.Append("T0830=" + T0830 + "; ");
			sb.Append("T0900=" + T0900 + "; ");
			sb.Append("T0930=" + T0930 + "; ");
			sb.Append("T1000=" + T1000 + "; ");
			sb.Append("T1030=" + T1030 + "; ");
			sb.Append("T1100=" + T1100 + "; ");
			sb.Append("T1130=" + T1130 + "; ");
			sb.Append("T1200=" + T1200 + "; ");
			sb.Append("T1230=" + T1230 + "; ");
			sb.Append("T1300=" + T1300 + "; ");
			sb.Append("T1330=" + T1330 + "; ");
			sb.Append("T1400=" + T1400 + "; ");
			sb.Append("T1430=" + T1430 + "; ");
			sb.Append("T1500=" + T1500 + "; ");
			sb.Append("T1530=" + T1530 + "; ");
			sb.Append("T1600=" + T1600 + "; ");
			sb.Append("T1630=" + T1630 + "; ");
			sb.Append("T1700=" + T1700 + "; ");
			sb.Append("T1730=" + T1730 + "; ");
			sb.Append("T1800=" + T1800 + "; ");
			sb.Append("T1830=" + T1830 + "; ");
			sb.Append("T1900=" + T1900 + "; ");
			sb.Append("T1930=" + T1930 + "; ");
			sb.Append("T2000=" + T2000 + "; ");
			sb.Append("T2030=" + T2030 + "; ");
			sb.Append("T2100=" + T2100 + "; ");
			sb.Append("T2130=" + T2130 + "; ");
			return sb.ToString();
        }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(RoomMoment)){
                RoomMoment compare=(RoomMoment)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.MeetingRoom_Code.ToString();
                    }

        public string DescriptorColumn() {
            return "MeetingRoom_Code";
        }
        public static string GetKeyColumn()
        {
            return "Id";
        }        
        public static string GetDescriptorColumn()
        {
            return "MeetingRoom_Code";
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

        string _MeetingRoom_Code;
		/// <summary>
		/// 會議室編號
		/// </summary>
        public string MeetingRoom_Code
        {
            get { return _MeetingRoom_Code; }
            set
            {
                if(_MeetingRoom_Code!=value || _isLoaded){
                    _MeetingRoom_Code=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MeetingRoom_Code");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MeetingRoom_Name;
		/// <summary>
		/// 會議室名稱
		/// </summary>
        public string MeetingRoom_Name
        {
            get { return _MeetingRoom_Name; }
            set
            {
                if(_MeetingRoom_Name!=value || _isLoaded){
                    _MeetingRoom_Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MeetingRoom_Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _RoomDate;
		/// <summary>
		/// 日期
		/// </summary>
        public DateTime? RoomDate
        {
            get { return _RoomDate; }
            set
            {
                if(_RoomDate!=value || _isLoaded){
                    _RoomDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RoomDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T0800;
		/// <summary>
		/// 08:00--
		/// </summary>
        public byte? T0800
        {
            get { return _T0800; }
            set
            {
                if(_T0800!=value || _isLoaded){
                    _T0800=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T0800");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T0830;
		/// <summary>
		/// 08:30--
		/// </summary>
        public byte? T0830
        {
            get { return _T0830; }
            set
            {
                if(_T0830!=value || _isLoaded){
                    _T0830=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T0830");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T0900;
		/// <summary>
		/// 09:00-
		/// </summary>
        public byte? T0900
        {
            get { return _T0900; }
            set
            {
                if(_T0900!=value || _isLoaded){
                    _T0900=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T0900");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T0930;
		/// <summary>
		/// 09:30--
		/// </summary>
        public byte? T0930
        {
            get { return _T0930; }
            set
            {
                if(_T0930!=value || _isLoaded){
                    _T0930=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T0930");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1000;
		/// <summary>
		/// 10:00--
		/// </summary>
        public byte? T1000
        {
            get { return _T1000; }
            set
            {
                if(_T1000!=value || _isLoaded){
                    _T1000=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1000");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1030;
		/// <summary>
		/// 10:30-
		/// </summary>
        public byte? T1030
        {
            get { return _T1030; }
            set
            {
                if(_T1030!=value || _isLoaded){
                    _T1030=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1030");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1100;
		/// <summary>
		/// 11:00-
		/// </summary>
        public byte? T1100
        {
            get { return _T1100; }
            set
            {
                if(_T1100!=value || _isLoaded){
                    _T1100=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1100");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1130;
		/// <summary>
		/// 11:30-
		/// </summary>
        public byte? T1130
        {
            get { return _T1130; }
            set
            {
                if(_T1130!=value || _isLoaded){
                    _T1130=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1130");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1200;
		/// <summary>
		/// 12:00-
		/// </summary>
        public byte? T1200
        {
            get { return _T1200; }
            set
            {
                if(_T1200!=value || _isLoaded){
                    _T1200=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1200");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1230;
		/// <summary>
		/// 12:30-
		/// </summary>
        public byte? T1230
        {
            get { return _T1230; }
            set
            {
                if(_T1230!=value || _isLoaded){
                    _T1230=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1230");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1300;
		/// <summary>
		/// 13:00-
		/// </summary>
        public byte? T1300
        {
            get { return _T1300; }
            set
            {
                if(_T1300!=value || _isLoaded){
                    _T1300=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1300");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1330;
		/// <summary>
		/// 13:30-
		/// </summary>
        public byte? T1330
        {
            get { return _T1330; }
            set
            {
                if(_T1330!=value || _isLoaded){
                    _T1330=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1330");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1400;
		/// <summary>
		/// 14:00-
		/// </summary>
        public byte? T1400
        {
            get { return _T1400; }
            set
            {
                if(_T1400!=value || _isLoaded){
                    _T1400=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1400");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1430;
		/// <summary>
		/// 14:30-
		/// </summary>
        public byte? T1430
        {
            get { return _T1430; }
            set
            {
                if(_T1430!=value || _isLoaded){
                    _T1430=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1430");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1500;
		/// <summary>
		/// 15:00-
		/// </summary>
        public byte? T1500
        {
            get { return _T1500; }
            set
            {
                if(_T1500!=value || _isLoaded){
                    _T1500=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1500");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1530;
		/// <summary>
		/// 15:30-
		/// </summary>
        public byte? T1530
        {
            get { return _T1530; }
            set
            {
                if(_T1530!=value || _isLoaded){
                    _T1530=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1530");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1600;
		/// <summary>
		/// 16:00-
		/// </summary>
        public byte? T1600
        {
            get { return _T1600; }
            set
            {
                if(_T1600!=value || _isLoaded){
                    _T1600=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1600");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1630;
		/// <summary>
		/// 16:30-
		/// </summary>
        public byte? T1630
        {
            get { return _T1630; }
            set
            {
                if(_T1630!=value || _isLoaded){
                    _T1630=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1630");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1700;
		/// <summary>
		/// 17:00-
		/// </summary>
        public byte? T1700
        {
            get { return _T1700; }
            set
            {
                if(_T1700!=value || _isLoaded){
                    _T1700=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1700");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1730;
		/// <summary>
		/// 17:30-
		/// </summary>
        public byte? T1730
        {
            get { return _T1730; }
            set
            {
                if(_T1730!=value || _isLoaded){
                    _T1730=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1730");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1800;
		/// <summary>
		/// 18:00-
		/// </summary>
        public byte? T1800
        {
            get { return _T1800; }
            set
            {
                if(_T1800!=value || _isLoaded){
                    _T1800=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1800");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1830;
		/// <summary>
		/// 18:30-
		/// </summary>
        public byte? T1830
        {
            get { return _T1830; }
            set
            {
                if(_T1830!=value || _isLoaded){
                    _T1830=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1830");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1900;
		/// <summary>
		/// 19:00-
		/// </summary>
        public byte? T1900
        {
            get { return _T1900; }
            set
            {
                if(_T1900!=value || _isLoaded){
                    _T1900=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1900");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T1930;
		/// <summary>
		/// 19:30-
		/// </summary>
        public byte? T1930
        {
            get { return _T1930; }
            set
            {
                if(_T1930!=value || _isLoaded){
                    _T1930=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T1930");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T2000;
		/// <summary>
		/// 20:00-
		/// </summary>
        public byte? T2000
        {
            get { return _T2000; }
            set
            {
                if(_T2000!=value || _isLoaded){
                    _T2000=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T2000");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T2030;
		/// <summary>
		/// 20:30-
		/// </summary>
        public byte? T2030
        {
            get { return _T2030; }
            set
            {
                if(_T2030!=value || _isLoaded){
                    _T2030=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T2030");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T2100;
		/// <summary>
		/// 21:00-
		/// </summary>
        public byte? T2100
        {
            get { return _T2100; }
            set
            {
                if(_T2100!=value || _isLoaded){
                    _T2100=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T2100");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte? _T2130;
		/// <summary>
		/// 21:30-
		/// </summary>
        public byte? T2130
        {
            get { return _T2130; }
            set
            {
                if(_T2130!=value || _isLoaded){
                    _T2130=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="T2130");
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


        public static void Delete(Expression<Func<RoomMoment, bool>> expression) {
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

