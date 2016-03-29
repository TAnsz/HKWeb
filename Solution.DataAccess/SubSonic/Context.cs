


using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Schema;
using System.Data.Common;
using System.Collections.Generic;

namespace Solution.DataAccess.DataModel
{
    public partial class HKHRDB : IQuerySurface
    {

        public IDataProvider DataProvider;
        public DbQueryProvider provider;
        
        private static IDataProvider _idDataProvider;
        public static IDataProvider GetDataProvider()
        {
            if (_idDataProvider == null)
                _idDataProvider = ProviderFactory.GetProvider("conn");

            return _idDataProvider;
        }

        public bool TestMode
		{
            get
			{
                return DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public HKHRDB() 
        {
            if (DataProvider == null) {
                DataProvider = GetDataProvider();
            }
            //else {
            //    DataProvider = DefaultDataProvider;
            //}
            Init();
        }

        public HKHRDB(string connectionStringName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionStringName);
            Init();
        }

		public HKHRDB(string connectionString, string providerName)
        {
            DataProvider = ProviderFactory.GetProvider(connectionString,providerName);
            Init();
        }

		public ITable FindByPrimaryKey(string pkName)
        {
            return DataProvider.Schema.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>()
        {
            return new Query<T>(provider);
        }
        
        public ITable FindTable(string tableName)
        {
            return DataProvider.FindTable(tableName);
        }
               
        public IDataProvider Provider
        {
            get { return DataProvider; }
            set {DataProvider=value;}
        }
        
        public DbQueryProvider QueryProvider
        {
            get { return provider; }
        }
        
        BatchQuery _batch = null;
        public void Queue<T>(IQueryable<T> qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void Queue(ISqlQuery qry)
        {
            if (_batch == null)
                _batch = new BatchQuery(Provider, QueryProvider);
            _batch.Queue(qry);
        }

        public void ExecuteTransaction(IList<DbCommand> commands)
		{
            if(!TestMode)
			{
                using(var connection = commands[0].Connection)
				{
                   if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   
                   using (var trans = connection.BeginTransaction()) 
				   {
                        foreach (var cmd in commands) 
						{
                            cmd.Transaction = trans;
                            cmd.Connection = connection;
                            cmd.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    connection.Close();
                }
            }
        }

        public IDataReader ExecuteBatch()
        {
            if (_batch == null)
                throw new InvalidOperationException("There's nothing in the queue");
            if(!TestMode)
                return _batch.ExecuteReader();
            return null;
        }
			
        public Query<DataAccess.Model.ActiveFile> ActiveFile { get; set; }
        public Query<DataAccess.Model.ActiveFileClass> ActiveFileClass { get; set; }
        public Query<DataAccess.Model.adJustRest_D> adJustRest_D { get; set; }
        public Query<DataAccess.Model.ANNUALLEAVE> ANNUALLEAVE { get; set; }
        public Query<DataAccess.Model.CardDetail> CardDetail { get; set; }
        public Query<DataAccess.Model.Departs> Departs { get; set; }
        public Query<DataAccess.Model.Employee> Employee { get; set; }
        public Query<DataAccess.Model.employeedet> employeedet { get; set; }
        public Query<DataAccess.Model.ErrorLog> ErrorLog { get; set; }
        public Query<DataAccess.Model.Holidays> Holidays { get; set; }
        public Query<DataAccess.Model.Information> Information { get; set; }
        public Query<DataAccess.Model.InformationClass> InformationClass { get; set; }
        public Query<DataAccess.Model.LoginLog> LoginLog { get; set; }
        public Query<DataAccess.Model.Machine> Machine { get; set; }
        public Query<DataAccess.Model.MAIN_LIST> MAIN_LIST { get; set; }
        public Query<DataAccess.Model.MealOrdering> MealOrdering { get; set; }
        public Query<DataAccess.Model.MeetingRoom> MeetingRoom { get; set; }
        public Query<DataAccess.Model.MeetingRoomApply> MeetingRoomApply { get; set; }
        public Query<DataAccess.Model.MenuInfo> MenuInfo { get; set; }
        public Query<DataAccess.Model.OnlineUsers> OnlineUsers { get; set; }
        public Query<DataAccess.Model.OutWork_D> OutWork_D { get; set; }
        public Query<DataAccess.Model.PagePowerSign> PagePowerSign { get; set; }
        public Query<DataAccess.Model.PagePowerSignPublic> PagePowerSignPublic { get; set; }
        public Query<DataAccess.Model.Report_Day> Report_Day { get; set; }
        public Query<DataAccess.Model.Report_Month> Report_Month { get; set; }
        public Query<DataAccess.Model.RoomMoment> RoomMoment { get; set; }
        public Query<DataAccess.Model.Rules> Rules { get; set; }
        public Query<DataAccess.Model.Shifts> Shifts { get; set; }
        public Query<DataAccess.Model.T_TABLE_D> T_TABLE_D { get; set; }
        public Query<DataAccess.Model.T_TABLESET> T_TABLESET { get; set; }
        public Query<DataAccess.Model.TOOL_LIST> TOOL_LIST { get; set; }
        public Query<DataAccess.Model.UploadConfig> UploadConfig { get; set; }
        public Query<DataAccess.Model.UploadFile> UploadFile { get; set; }
        public Query<DataAccess.Model.UploadType> UploadType { get; set; }
        public Query<DataAccess.Model.UseLog> UseLog { get; set; }
        public Query<DataAccess.Model.USERAUTHORITY> USERAUTHORITY { get; set; }
        public Query<DataAccess.Model.USERAUTHORITY_REPORT> USERAUTHORITY_REPORT { get; set; }
        public Query<DataAccess.Model.WebConfig> WebConfig { get; set; }
        public Query<DataAccess.Model.WeekRest> WeekRest { get; set; }

			

        #region ' Aggregates and SubSonic Queries '
        public Select SelectColumns(params string[] columns)
        {
            return new Select(DataProvider, columns);
        }

        public Select Select
        {
            get { return new Select(this.Provider); }
        }

        public Insert Insert
		{
            get { return new Insert(this.Provider); }
        }

        public Update<T> Update<T>() where T:new()
		{
            return new Update<T>(this.Provider);
        }

        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new()
        {
            LambdaExpression lamda = column;
            SqlQuery result = new Delete<T>(this.Provider);
            result = result.From<T>();
            result.Constraints=lamda.ParseConstraints().ToList();
            return result;
        }

        public SqlQuery Max<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = DataProvider.FindTable(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }

        public SqlQuery Min<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }

        public SqlQuery Sum<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }

        public SqlQuery Avg<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }

        public SqlQuery Count<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }

        public SqlQuery Variance<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }

        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column)
        {
            LambdaExpression lamda = column;
            string colName = lamda.ParseObjectValue();
            string objectName = typeof(T).Name;
            string tableName = this.Provider.FindTable(objectName).Name;
            return new Select(this.Provider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }

        #endregion

        void Init()
        {
            provider = new DbQueryProvider(this.Provider);

            #region ' Query Defs '
            ActiveFile = new Query<DataAccess.Model.ActiveFile>(provider);
            ActiveFileClass = new Query<DataAccess.Model.ActiveFileClass>(provider);
            adJustRest_D = new Query<DataAccess.Model.adJustRest_D>(provider);
            ANNUALLEAVE = new Query<DataAccess.Model.ANNUALLEAVE>(provider);
            CardDetail = new Query<DataAccess.Model.CardDetail>(provider);
            Departs = new Query<DataAccess.Model.Departs>(provider);
            Employee = new Query<DataAccess.Model.Employee>(provider);
            employeedet = new Query<DataAccess.Model.employeedet>(provider);
            ErrorLog = new Query<DataAccess.Model.ErrorLog>(provider);
            Holidays = new Query<DataAccess.Model.Holidays>(provider);
            Information = new Query<DataAccess.Model.Information>(provider);
            InformationClass = new Query<DataAccess.Model.InformationClass>(provider);
            LoginLog = new Query<DataAccess.Model.LoginLog>(provider);
            Machine = new Query<DataAccess.Model.Machine>(provider);
            MAIN_LIST = new Query<DataAccess.Model.MAIN_LIST>(provider);
            MealOrdering = new Query<DataAccess.Model.MealOrdering>(provider);
            MeetingRoom = new Query<DataAccess.Model.MeetingRoom>(provider);
            MeetingRoomApply = new Query<DataAccess.Model.MeetingRoomApply>(provider);
            MenuInfo = new Query<DataAccess.Model.MenuInfo>(provider);
            OnlineUsers = new Query<DataAccess.Model.OnlineUsers>(provider);
            OutWork_D = new Query<DataAccess.Model.OutWork_D>(provider);
            PagePowerSign = new Query<DataAccess.Model.PagePowerSign>(provider);
            PagePowerSignPublic = new Query<DataAccess.Model.PagePowerSignPublic>(provider);
            Report_Day = new Query<DataAccess.Model.Report_Day>(provider);
            Report_Month = new Query<DataAccess.Model.Report_Month>(provider);
            RoomMoment = new Query<DataAccess.Model.RoomMoment>(provider);
            Rules = new Query<DataAccess.Model.Rules>(provider);
            Shifts = new Query<DataAccess.Model.Shifts>(provider);
            T_TABLE_D = new Query<DataAccess.Model.T_TABLE_D>(provider);
            T_TABLESET = new Query<DataAccess.Model.T_TABLESET>(provider);
            TOOL_LIST = new Query<DataAccess.Model.TOOL_LIST>(provider);
            UploadConfig = new Query<DataAccess.Model.UploadConfig>(provider);
            UploadFile = new Query<DataAccess.Model.UploadFile>(provider);
            UploadType = new Query<DataAccess.Model.UploadType>(provider);
            UseLog = new Query<DataAccess.Model.UseLog>(provider);
            USERAUTHORITY = new Query<DataAccess.Model.USERAUTHORITY>(provider);
            USERAUTHORITY_REPORT = new Query<DataAccess.Model.USERAUTHORITY_REPORT>(provider);
            WebConfig = new Query<DataAccess.Model.WebConfig>(provider);
            WeekRest = new Query<DataAccess.Model.WeekRest>(provider);
            #endregion


            #region ' Schemas '
        	if(DataProvider.Schema.Tables.Count == 0)
			{
            	DataProvider.Schema.Tables.Add(new ActiveFileStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ActiveFileClassStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new adJustRest_DStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ANNUALLEAVEStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new CardDetailStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new DepartsStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new EmployeeStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new employeedetStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ErrorLogStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new HolidaysStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new InformationStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new InformationClassStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new LoginLogStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MachineStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MAIN_LISTStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MealOrderingStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MeetingRoomStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MeetingRoomApplyStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new MenuInfoStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OnlineUsersStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new OutWork_DStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PagePowerSignStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new PagePowerSignPublicStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Report_DayStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new Report_MonthStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new RoomMomentStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new RulesStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new ShiftsStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new T_TABLE_DStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new T_TABLESETStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new TOOL_LISTStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UploadConfigStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UploadFileStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UploadTypeStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new UseLogStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new USERAUTHORITYStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new USERAUTHORITY_REPORTStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new WebConfigStructs(DataProvider));
            	DataProvider.Schema.Tables.Add(new WeekRestStructs(DataProvider));
            }
            #endregion
        }
        

        #region ' Helpers '
            
        internal static DateTime DateTimeNowTruncatedDownToSecond() {
            var now = DateTime.Now;
            return now.AddTicks(-now.Ticks % TimeSpan.TicksPerSecond);
        }

        #endregion

    }
}