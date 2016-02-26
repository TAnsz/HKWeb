


  
using System;
using System.Data;
using SubSonic.Schema;
using SubSonic.DataProviders;

namespace Solution.DataAccess.DataModel{
	public partial class SPs{

        public static StoredProcedure GetTime(){
            StoredProcedure sp=new StoredProcedure("GetTime");
			
            return sp;
        }
        public static StoredProcedure p_ToIDENTITY(string TableName,string FieldName,int increment){
            StoredProcedure sp=new StoredProcedure("p_ToIDENTITY");
			
            sp.Command.AddParameter("TableName",TableName,DbType.String);
            sp.Command.AddParameter("FieldName",FieldName,DbType.String);
            sp.Command.AddParameter("increment",increment,DbType.Int32);
            return sp;
        }
        public static StoredProcedure PRO_CHANGE_PASSWORD(string OLD,string NEW,string USER){
            StoredProcedure sp=new StoredProcedure("PRO_CHANGE_PASSWORD");
			
            sp.Command.AddParameter("OLD",OLD,DbType.AnsiString);
            sp.Command.AddParameter("NEW",NEW,DbType.AnsiString);
            sp.Command.AddParameter("USER",USER,DbType.AnsiStringFixedLength);
            return sp;
        }
        public static StoredProcedure PRO_DAY_REPORT(string Id){
            StoredProcedure sp=new StoredProcedure("PRO_DAY_REPORT");
			
            sp.Command.AddParameter("Id",Id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure PRO_INSERT_DAYSONYEAR(string YEAR){
            StoredProcedure sp=new StoredProcedure("PRO_INSERT_DAYSONYEAR");
			
            sp.Command.AddParameter("YEAR",YEAR,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure PRO_MAIN_ABNORMAL(){
            StoredProcedure sp=new StoredProcedure("PRO_MAIN_ABNORMAL");
			
            return sp;
        }
        public static StoredProcedure PRO_MAIN_STUFF(){
            StoredProcedure sp=new StoredProcedure("PRO_MAIN_STUFF");
			
            return sp;
        }
        public static StoredProcedure PRO_PROCESS_DAY_REPORT(int YEAR,int MONTH,string EMP_ID,string RETURN){
            StoredProcedure sp=new StoredProcedure("PRO_PROCESS_DAY_REPORT");
			
            sp.Command.AddParameter("YEAR",YEAR,DbType.Int32);
            sp.Command.AddParameter("MONTH",MONTH,DbType.Int32);
            sp.Command.AddParameter("EMP_ID",EMP_ID,DbType.AnsiString);
			sp.Command.AddOutputParameter("RETURN",-1,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure PRO_PROCESS_MONTH_REPORT(int YEAR,int MONTH,string EMP_ID,string RETURN){
            StoredProcedure sp=new StoredProcedure("PRO_PROCESS_MONTH_REPORT");
			
            sp.Command.AddParameter("YEAR",YEAR,DbType.Int32);
            sp.Command.AddParameter("MONTH",MONTH,DbType.Int32);
            sp.Command.AddParameter("EMP_ID",EMP_ID,DbType.AnsiString);
			sp.Command.AddOutputParameter("RETURN",-1,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure pro_USERAUTHORITY_REPORT(string empid){
            StoredProcedure sp=new StoredProcedure("pro_USERAUTHORITY_REPORT");
			
            sp.Command.AddParameter("empid",empid,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure PRO_VALID_PASSWORD(string PASS,string USER){
            StoredProcedure sp=new StoredProcedure("PRO_VALID_PASSWORD");
			
            sp.Command.AddParameter("PASS",PASS,DbType.AnsiString);
            sp.Command.AddParameter("USER",USER,DbType.AnsiStringFixedLength);
            return sp;
        }
	
	}
	
}
 