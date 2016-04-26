 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Report_Day
        /// Primary Key: Id
        /// </summary>

        public class Report_DayStructs: DatabaseTable {
            
            public Report_DayStructs(IDataProvider provider):base("Report_Day",provider){
                ClassName = "Report_Day";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("emp_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
					PropertyName = "emp_id"
                });

                Columns.Add(new DatabaseColumn("sign_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sign_date"
                });

                Columns.Add(new DatabaseColumn("join_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "join_id"
                });

                Columns.Add(new DatabaseColumn("cur_kind", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "cur_kind"
                });

                Columns.Add(new DatabaseColumn("depart_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "depart_id"
                });

                Columns.Add(new DatabaseColumn("calc_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "calc_date"
                });

                Columns.Add(new DatabaseColumn("adjusted", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "adjusted"
                });

                Columns.Add(new DatabaseColumn("shift_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "shift_id"
                });

                Columns.Add(new DatabaseColumn("status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "status"
                });

                Columns.Add(new DatabaseColumn("sign_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sign_count"
                });

                Columns.Add(new DatabaseColumn("need_sign_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "need_sign_count"
                });

                Columns.Add(new DatabaseColumn("in1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "in1"
                });

                Columns.Add(new DatabaseColumn("out1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "out1"
                });

                Columns.Add(new DatabaseColumn("in2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "in2"
                });

                Columns.Add(new DatabaseColumn("out2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "out2"
                });

                Columns.Add(new DatabaseColumn("in3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "in3"
                });

                Columns.Add(new DatabaseColumn("out3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "out3"
                });

                Columns.Add(new DatabaseColumn("in4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "in4"
                });

                Columns.Add(new DatabaseColumn("out4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "out4"
                });

                Columns.Add(new DatabaseColumn("in5", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "in5"
                });

                Columns.Add(new DatabaseColumn("out5", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "out5"
                });

                Columns.Add(new DatabaseColumn("plan_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "plan_days"
                });

                Columns.Add(new DatabaseColumn("sun_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sun_days"
                });

                Columns.Add(new DatabaseColumn("hd_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hd_days"
                });

                Columns.Add(new DatabaseColumn("duty_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "duty_days"
                });

                Columns.Add(new DatabaseColumn("work_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "work_days"
                });

                Columns.Add(new DatabaseColumn("absent_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "absent_days"
                });

                Columns.Add(new DatabaseColumn("leave_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave_days"
                });

                Columns.Add(new DatabaseColumn("fact_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "fact_hrs"
                });

                Columns.Add(new DatabaseColumn("basic_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "basic_hrs"
                });

                Columns.Add(new DatabaseColumn("mid_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "mid_hrs"
                });

                Columns.Add(new DatabaseColumn("ns_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ns_hrs"
                });

                Columns.Add(new DatabaseColumn("ot_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_hrs"
                });

                Columns.Add(new DatabaseColumn("sun_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sun_hrs"
                });

                Columns.Add(new DatabaseColumn("hd_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hd_hrs"
                });

                Columns.Add(new DatabaseColumn("absent_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "absent_hrs"
                });

                Columns.Add(new DatabaseColumn("input_ot_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "input_ot_hrs"
                });

                Columns.Add(new DatabaseColumn("late_mins", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late_mins"
                });

                Columns.Add(new DatabaseColumn("late_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late_count"
                });

                Columns.Add(new DatabaseColumn("leave_mins", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave_mins"
                });

                Columns.Add(new DatabaseColumn("leave_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave_count"
                });

                Columns.Add(new DatabaseColumn("ot_late_mins", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_late_mins"
                });

                Columns.Add(new DatabaseColumn("ot_leave_mins", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_leave_mins"
                });

                Columns.Add(new DatabaseColumn("ot_late_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_late_count"
                });

                Columns.Add(new DatabaseColumn("ot_leave_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_leave_count"
                });

                Columns.Add(new DatabaseColumn("ns_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ns_count"
                });

                Columns.Add(new DatabaseColumn("mid_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "mid_count"
                });

                Columns.Add(new DatabaseColumn("ot_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_count"
                });

                Columns.Add(new DatabaseColumn("absent_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "absent_count"
                });

                Columns.Add(new DatabaseColumn("l0hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l0hrs"
                });

                Columns.Add(new DatabaseColumn("l1hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l1hrs"
                });

                Columns.Add(new DatabaseColumn("l2hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l2hrs"
                });

                Columns.Add(new DatabaseColumn("l3hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l3hrs"
                });

                Columns.Add(new DatabaseColumn("l4hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l4hrs"
                });

                Columns.Add(new DatabaseColumn("l5hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l5hrs"
                });

                Columns.Add(new DatabaseColumn("l6hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l6hrs"
                });

                Columns.Add(new DatabaseColumn("l7hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l7hrs"
                });

                Columns.Add(new DatabaseColumn("l8hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l8hrs"
                });

                Columns.Add(new DatabaseColumn("L9hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "L9hrs"
                });

                Columns.Add(new DatabaseColumn("l10hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l10hrs"
                });

                Columns.Add(new DatabaseColumn("l11hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l11hrs"
                });

                Columns.Add(new DatabaseColumn("l12hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l12hrs"
                });

                Columns.Add(new DatabaseColumn("l13hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l13hrs"
                });

                Columns.Add(new DatabaseColumn("l14hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l14hrs"
                });

                Columns.Add(new DatabaseColumn("l15hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l15hrs"
                });

                Columns.Add(new DatabaseColumn("outwork_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "outwork_hrs"
                });

                Columns.Add(new DatabaseColumn("shutdown_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "shutdown_hrs"
                });

                Columns.Add(new DatabaseColumn("outwork_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "outwork_days"
                });

                Columns.Add(new DatabaseColumn("shutdown_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "shutdown_days"
                });

                Columns.Add(new DatabaseColumn("notes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2000,
					PropertyName = "notes"
                });

                Columns.Add(new DatabaseColumn("shift_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "shift_hrs"
                });

                Columns.Add(new DatabaseColumn("onwatch_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "onwatch_hrs"
                });

                Columns.Add(new DatabaseColumn("audit", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "audit"
                });

                Columns.Add(new DatabaseColumn("l0day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l0day"
                });

                Columns.Add(new DatabaseColumn("l1day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l1day"
                });

                Columns.Add(new DatabaseColumn("l2day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l2day"
                });

                Columns.Add(new DatabaseColumn("l3day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l3day"
                });

                Columns.Add(new DatabaseColumn("l4day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l4day"
                });

                Columns.Add(new DatabaseColumn("l5day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l5day"
                });

                Columns.Add(new DatabaseColumn("l6day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l6day"
                });

                Columns.Add(new DatabaseColumn("l7day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l7day"
                });

                Columns.Add(new DatabaseColumn("l8day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l8day"
                });

                Columns.Add(new DatabaseColumn("L9day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "L9day"
                });

                Columns.Add(new DatabaseColumn("l10day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l10day"
                });

                Columns.Add(new DatabaseColumn("l11day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l11day"
                });

                Columns.Add(new DatabaseColumn("l12day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l12day"
                });

                Columns.Add(new DatabaseColumn("l13day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l13day"
                });

                Columns.Add(new DatabaseColumn("l14day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l14day"
                });

                Columns.Add(new DatabaseColumn("l15day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l15day"
                });

                Columns.Add(new DatabaseColumn("outwork_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "outwork_count"
                });

                Columns.Add(new DatabaseColumn("shutdown_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "shutdown_count"
                });

                Columns.Add(new DatabaseColumn("l0count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l0count"
                });

                Columns.Add(new DatabaseColumn("l1count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l1count"
                });

                Columns.Add(new DatabaseColumn("l2count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l2count"
                });

                Columns.Add(new DatabaseColumn("l3count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l3count"
                });

                Columns.Add(new DatabaseColumn("l4count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l4count"
                });

                Columns.Add(new DatabaseColumn("l5count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l5count"
                });

                Columns.Add(new DatabaseColumn("l6count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l6count"
                });

                Columns.Add(new DatabaseColumn("l7count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l7count"
                });

                Columns.Add(new DatabaseColumn("l8count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l8count"
                });

                Columns.Add(new DatabaseColumn("L9count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "L9count"
                });

                Columns.Add(new DatabaseColumn("l10count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l10count"
                });

                Columns.Add(new DatabaseColumn("l11count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l11count"
                });

                Columns.Add(new DatabaseColumn("l12count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l12count"
                });

                Columns.Add(new DatabaseColumn("l13count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l13count"
                });

                Columns.Add(new DatabaseColumn("l14count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l14count"
                });

                Columns.Add(new DatabaseColumn("l15count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "l15count"
                });

                Columns.Add(new DatabaseColumn("ot_sun_day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_sun_day"
                });

                Columns.Add(new DatabaseColumn("ot_nd_day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_nd_day"
                });

                Columns.Add(new DatabaseColumn("bait_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "bait_hrs"
                });

                Columns.Add(new DatabaseColumn("lesshrs_count", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "lesshrs_count"
                });

                Columns.Add(new DatabaseColumn("over_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "over_hrs"
                });

                Columns.Add(new DatabaseColumn("late1_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late1_min"
                });

                Columns.Add(new DatabaseColumn("late2_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late2_min"
                });

                Columns.Add(new DatabaseColumn("late3_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late3_min"
                });

                Columns.Add(new DatabaseColumn("late4_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late4_min"
                });

                Columns.Add(new DatabaseColumn("late5_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "late5_min"
                });

                Columns.Add(new DatabaseColumn("leave1_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave1_min"
                });

                Columns.Add(new DatabaseColumn("leave2_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave2_min"
                });

                Columns.Add(new DatabaseColumn("leave3_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave3_min"
                });

                Columns.Add(new DatabaseColumn("leave4_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave4_min"
                });

                Columns.Add(new DatabaseColumn("leave5_min", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "leave5_min"
                });

                Columns.Add(new DatabaseColumn("In1Mac", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "In1Mac"
                });

                Columns.Add(new DatabaseColumn("Out1Mac", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Out1Mac"
                });

                Columns.Add(new DatabaseColumn("In2Mac", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "In2Mac"
                });

                Columns.Add(new DatabaseColumn("Out2Mac", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Out2Mac"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn emp_id{
                get{
                    return this.GetColumn("emp_id");
                }
            }
				
            
            public IColumn sign_date{
                get{
                    return this.GetColumn("sign_date");
                }
            }
				
            
            public IColumn join_id{
                get{
                    return this.GetColumn("join_id");
                }
            }
				
            
            public IColumn cur_kind{
                get{
                    return this.GetColumn("cur_kind");
                }
            }
				
            
            public IColumn depart_id{
                get{
                    return this.GetColumn("depart_id");
                }
            }
				
            
            public IColumn calc_date{
                get{
                    return this.GetColumn("calc_date");
                }
            }
				
            
            public IColumn adjusted{
                get{
                    return this.GetColumn("adjusted");
                }
            }
				
            
            public IColumn shift_id{
                get{
                    return this.GetColumn("shift_id");
                }
            }
				
            
            public IColumn status{
                get{
                    return this.GetColumn("status");
                }
            }
				
            
            public IColumn sign_count{
                get{
                    return this.GetColumn("sign_count");
                }
            }
				
            
            public IColumn need_sign_count{
                get{
                    return this.GetColumn("need_sign_count");
                }
            }
				
            
            public IColumn in1{
                get{
                    return this.GetColumn("in1");
                }
            }
				
            
            public IColumn out1{
                get{
                    return this.GetColumn("out1");
                }
            }
				
            
            public IColumn in2{
                get{
                    return this.GetColumn("in2");
                }
            }
				
            
            public IColumn out2{
                get{
                    return this.GetColumn("out2");
                }
            }
				
            
            public IColumn in3{
                get{
                    return this.GetColumn("in3");
                }
            }
				
            
            public IColumn out3{
                get{
                    return this.GetColumn("out3");
                }
            }
				
            
            public IColumn in4{
                get{
                    return this.GetColumn("in4");
                }
            }
				
            
            public IColumn out4{
                get{
                    return this.GetColumn("out4");
                }
            }
				
            
            public IColumn in5{
                get{
                    return this.GetColumn("in5");
                }
            }
				
            
            public IColumn out5{
                get{
                    return this.GetColumn("out5");
                }
            }
				
            
            public IColumn plan_days{
                get{
                    return this.GetColumn("plan_days");
                }
            }
				
            
            public IColumn sun_days{
                get{
                    return this.GetColumn("sun_days");
                }
            }
				
            
            public IColumn hd_days{
                get{
                    return this.GetColumn("hd_days");
                }
            }
				
            
            public IColumn duty_days{
                get{
                    return this.GetColumn("duty_days");
                }
            }
				
            
            public IColumn work_days{
                get{
                    return this.GetColumn("work_days");
                }
            }
				
            
            public IColumn absent_days{
                get{
                    return this.GetColumn("absent_days");
                }
            }
				
            
            public IColumn leave_days{
                get{
                    return this.GetColumn("leave_days");
                }
            }
				
            
            public IColumn fact_hrs{
                get{
                    return this.GetColumn("fact_hrs");
                }
            }
				
            
            public IColumn basic_hrs{
                get{
                    return this.GetColumn("basic_hrs");
                }
            }
				
            
            public IColumn mid_hrs{
                get{
                    return this.GetColumn("mid_hrs");
                }
            }
				
            
            public IColumn ns_hrs{
                get{
                    return this.GetColumn("ns_hrs");
                }
            }
				
            
            public IColumn ot_hrs{
                get{
                    return this.GetColumn("ot_hrs");
                }
            }
				
            
            public IColumn sun_hrs{
                get{
                    return this.GetColumn("sun_hrs");
                }
            }
				
            
            public IColumn hd_hrs{
                get{
                    return this.GetColumn("hd_hrs");
                }
            }
				
            
            public IColumn absent_hrs{
                get{
                    return this.GetColumn("absent_hrs");
                }
            }
				
            
            public IColumn input_ot_hrs{
                get{
                    return this.GetColumn("input_ot_hrs");
                }
            }
				
            
            public IColumn late_mins{
                get{
                    return this.GetColumn("late_mins");
                }
            }
				
            
            public IColumn late_count{
                get{
                    return this.GetColumn("late_count");
                }
            }
				
            
            public IColumn leave_mins{
                get{
                    return this.GetColumn("leave_mins");
                }
            }
				
            
            public IColumn leave_count{
                get{
                    return this.GetColumn("leave_count");
                }
            }
				
            
            public IColumn ot_late_mins{
                get{
                    return this.GetColumn("ot_late_mins");
                }
            }
				
            
            public IColumn ot_leave_mins{
                get{
                    return this.GetColumn("ot_leave_mins");
                }
            }
				
            
            public IColumn ot_late_count{
                get{
                    return this.GetColumn("ot_late_count");
                }
            }
				
            
            public IColumn ot_leave_count{
                get{
                    return this.GetColumn("ot_leave_count");
                }
            }
				
            
            public IColumn ns_count{
                get{
                    return this.GetColumn("ns_count");
                }
            }
				
            
            public IColumn mid_count{
                get{
                    return this.GetColumn("mid_count");
                }
            }
				
            
            public IColumn ot_count{
                get{
                    return this.GetColumn("ot_count");
                }
            }
				
            
            public IColumn absent_count{
                get{
                    return this.GetColumn("absent_count");
                }
            }
				
            
            public IColumn l0hrs{
                get{
                    return this.GetColumn("l0hrs");
                }
            }
				
            
            public IColumn l1hrs{
                get{
                    return this.GetColumn("l1hrs");
                }
            }
				
            
            public IColumn l2hrs{
                get{
                    return this.GetColumn("l2hrs");
                }
            }
				
            
            public IColumn l3hrs{
                get{
                    return this.GetColumn("l3hrs");
                }
            }
				
            
            public IColumn l4hrs{
                get{
                    return this.GetColumn("l4hrs");
                }
            }
				
            
            public IColumn l5hrs{
                get{
                    return this.GetColumn("l5hrs");
                }
            }
				
            
            public IColumn l6hrs{
                get{
                    return this.GetColumn("l6hrs");
                }
            }
				
            
            public IColumn l7hrs{
                get{
                    return this.GetColumn("l7hrs");
                }
            }
				
            
            public IColumn l8hrs{
                get{
                    return this.GetColumn("l8hrs");
                }
            }
				
            
            public IColumn L9hrs{
                get{
                    return this.GetColumn("L9hrs");
                }
            }
				
            
            public IColumn l10hrs{
                get{
                    return this.GetColumn("l10hrs");
                }
            }
				
            
            public IColumn l11hrs{
                get{
                    return this.GetColumn("l11hrs");
                }
            }
				
            
            public IColumn l12hrs{
                get{
                    return this.GetColumn("l12hrs");
                }
            }
				
            
            public IColumn l13hrs{
                get{
                    return this.GetColumn("l13hrs");
                }
            }
				
            
            public IColumn l14hrs{
                get{
                    return this.GetColumn("l14hrs");
                }
            }
				
            
            public IColumn l15hrs{
                get{
                    return this.GetColumn("l15hrs");
                }
            }
				
            
            public IColumn outwork_hrs{
                get{
                    return this.GetColumn("outwork_hrs");
                }
            }
				
            
            public IColumn shutdown_hrs{
                get{
                    return this.GetColumn("shutdown_hrs");
                }
            }
				
            
            public IColumn outwork_days{
                get{
                    return this.GetColumn("outwork_days");
                }
            }
				
            
            public IColumn shutdown_days{
                get{
                    return this.GetColumn("shutdown_days");
                }
            }
				
            
            public IColumn notes{
                get{
                    return this.GetColumn("notes");
                }
            }
				
            
            public IColumn shift_hrs{
                get{
                    return this.GetColumn("shift_hrs");
                }
            }
				
            
            public IColumn onwatch_hrs{
                get{
                    return this.GetColumn("onwatch_hrs");
                }
            }
				
            
            public IColumn audit{
                get{
                    return this.GetColumn("audit");
                }
            }
				
            
            public IColumn l0day{
                get{
                    return this.GetColumn("l0day");
                }
            }
				
            
            public IColumn l1day{
                get{
                    return this.GetColumn("l1day");
                }
            }
				
            
            public IColumn l2day{
                get{
                    return this.GetColumn("l2day");
                }
            }
				
            
            public IColumn l3day{
                get{
                    return this.GetColumn("l3day");
                }
            }
				
            
            public IColumn l4day{
                get{
                    return this.GetColumn("l4day");
                }
            }
				
            
            public IColumn l5day{
                get{
                    return this.GetColumn("l5day");
                }
            }
				
            
            public IColumn l6day{
                get{
                    return this.GetColumn("l6day");
                }
            }
				
            
            public IColumn l7day{
                get{
                    return this.GetColumn("l7day");
                }
            }
				
            
            public IColumn l8day{
                get{
                    return this.GetColumn("l8day");
                }
            }
				
            
            public IColumn L9day{
                get{
                    return this.GetColumn("L9day");
                }
            }
				
            
            public IColumn l10day{
                get{
                    return this.GetColumn("l10day");
                }
            }
				
            
            public IColumn l11day{
                get{
                    return this.GetColumn("l11day");
                }
            }
				
            
            public IColumn l12day{
                get{
                    return this.GetColumn("l12day");
                }
            }
				
            
            public IColumn l13day{
                get{
                    return this.GetColumn("l13day");
                }
            }
				
            
            public IColumn l14day{
                get{
                    return this.GetColumn("l14day");
                }
            }
				
            
            public IColumn l15day{
                get{
                    return this.GetColumn("l15day");
                }
            }
				
            
            public IColumn outwork_count{
                get{
                    return this.GetColumn("outwork_count");
                }
            }
				
            
            public IColumn shutdown_count{
                get{
                    return this.GetColumn("shutdown_count");
                }
            }
				
            
            public IColumn l0count{
                get{
                    return this.GetColumn("l0count");
                }
            }
				
            
            public IColumn l1count{
                get{
                    return this.GetColumn("l1count");
                }
            }
				
            
            public IColumn l2count{
                get{
                    return this.GetColumn("l2count");
                }
            }
				
            
            public IColumn l3count{
                get{
                    return this.GetColumn("l3count");
                }
            }
				
            
            public IColumn l4count{
                get{
                    return this.GetColumn("l4count");
                }
            }
				
            
            public IColumn l5count{
                get{
                    return this.GetColumn("l5count");
                }
            }
				
            
            public IColumn l6count{
                get{
                    return this.GetColumn("l6count");
                }
            }
				
            
            public IColumn l7count{
                get{
                    return this.GetColumn("l7count");
                }
            }
				
            
            public IColumn l8count{
                get{
                    return this.GetColumn("l8count");
                }
            }
				
            
            public IColumn L9count{
                get{
                    return this.GetColumn("L9count");
                }
            }
				
            
            public IColumn l10count{
                get{
                    return this.GetColumn("l10count");
                }
            }
				
            
            public IColumn l11count{
                get{
                    return this.GetColumn("l11count");
                }
            }
				
            
            public IColumn l12count{
                get{
                    return this.GetColumn("l12count");
                }
            }
				
            
            public IColumn l13count{
                get{
                    return this.GetColumn("l13count");
                }
            }
				
            
            public IColumn l14count{
                get{
                    return this.GetColumn("l14count");
                }
            }
				
            
            public IColumn l15count{
                get{
                    return this.GetColumn("l15count");
                }
            }
				
            
            public IColumn ot_sun_day{
                get{
                    return this.GetColumn("ot_sun_day");
                }
            }
				
            
            public IColumn ot_nd_day{
                get{
                    return this.GetColumn("ot_nd_day");
                }
            }
				
            
            public IColumn bait_hrs{
                get{
                    return this.GetColumn("bait_hrs");
                }
            }
				
            
            public IColumn lesshrs_count{
                get{
                    return this.GetColumn("lesshrs_count");
                }
            }
				
            
            public IColumn over_hrs{
                get{
                    return this.GetColumn("over_hrs");
                }
            }
				
            
            public IColumn late1_min{
                get{
                    return this.GetColumn("late1_min");
                }
            }
				
            
            public IColumn late2_min{
                get{
                    return this.GetColumn("late2_min");
                }
            }
				
            
            public IColumn late3_min{
                get{
                    return this.GetColumn("late3_min");
                }
            }
				
            
            public IColumn late4_min{
                get{
                    return this.GetColumn("late4_min");
                }
            }
				
            
            public IColumn late5_min{
                get{
                    return this.GetColumn("late5_min");
                }
            }
				
            
            public IColumn leave1_min{
                get{
                    return this.GetColumn("leave1_min");
                }
            }
				
            
            public IColumn leave2_min{
                get{
                    return this.GetColumn("leave2_min");
                }
            }
				
            
            public IColumn leave3_min{
                get{
                    return this.GetColumn("leave3_min");
                }
            }
				
            
            public IColumn leave4_min{
                get{
                    return this.GetColumn("leave4_min");
                }
            }
				
            
            public IColumn leave5_min{
                get{
                    return this.GetColumn("leave5_min");
                }
            }
				
            
            public IColumn In1Mac{
                get{
                    return this.GetColumn("In1Mac");
                }
            }
				
            
            public IColumn Out1Mac{
                get{
                    return this.GetColumn("Out1Mac");
                }
            }
				
            
            public IColumn In2Mac{
                get{
                    return this.GetColumn("In2Mac");
                }
            }
				
            
            public IColumn Out2Mac{
                get{
                    return this.GetColumn("Out2Mac");
                }
            }
				
            
                    
        }
        
}
