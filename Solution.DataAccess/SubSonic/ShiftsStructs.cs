 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Shifts
        /// Primary Key: SHIFT_ID
        /// </summary>

        public class ShiftsStructs: DatabaseTable {
            
            public ShiftsStructs(IDataProvider provider):base("Shifts",provider){
                ClassName = "Shifts";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("SHIFT_ID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "SHIFT_ID"
                });

                Columns.Add(new DatabaseColumn("SHIFT_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "SHIFT_NAME"
                });

                Columns.Add(new DatabaseColumn("DEPART_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "DEPART_ID"
                });

                Columns.Add(new DatabaseColumn("SHIFT_KIND", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SHIFT_KIND"
                });

                Columns.Add(new DatabaseColumn("WORK_HRS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "WORK_HRS"
                });

                Columns.Add(new DatabaseColumn("NEED_HRS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEED_HRS"
                });

                Columns.Add(new DatabaseColumn("IS_DEFAULT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IS_DEFAULT"
                });

                Columns.Add(new DatabaseColumn("RULE_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "RULE_ID"
                });

                Columns.Add(new DatabaseColumn("CLASS_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CLASS_ID"
                });

                Columns.Add(new DatabaseColumn("NEED_SIGN_COUNT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEED_SIGN_COUNT"
                });

                Columns.Add(new DatabaseColumn("IS_COMMON", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IS_COMMON"
                });

                Columns.Add(new DatabaseColumn("AHEAD1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "AHEAD1"
                });

                Columns.Add(new DatabaseColumn("IN1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IN1"
                });

                Columns.Add(new DatabaseColumn("NEEDIN1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDIN1"
                });

                Columns.Add(new DatabaseColumn("BOVERTIME1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BOVERTIME1"
                });

                Columns.Add(new DatabaseColumn("OUT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OUT1"
                });

                Columns.Add(new DatabaseColumn("DELAY1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DELAY1"
                });

                Columns.Add(new DatabaseColumn("NEEDOUT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDOUT1"
                });

                Columns.Add(new DatabaseColumn("EOVERTIME1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EOVERTIME1"
                });

                Columns.Add(new DatabaseColumn("REST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST1"
                });

                Columns.Add(new DatabaseColumn("REST_BEGIN1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST_BEGIN1"
                });

                Columns.Add(new DatabaseColumn("BREAK1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BREAK1"
                });

                Columns.Add(new DatabaseColumn("OT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT1"
                });

                Columns.Add(new DatabaseColumn("EXT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EXT1"
                });

                Columns.Add(new DatabaseColumn("CANOT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CANOT1"
                });

                Columns.Add(new DatabaseColumn("OT_REST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST1"
                });

                Columns.Add(new DatabaseColumn("OT_REST_BEGIN1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST_BEGIN1"
                });

                Columns.Add(new DatabaseColumn("BASICHRS1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BASICHRS1"
                });

                Columns.Add(new DatabaseColumn("NEEDHRS1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDHRS1"
                });

                Columns.Add(new DatabaseColumn("DAY1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DAY1"
                });

                Columns.Add(new DatabaseColumn("AHEAD2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "AHEAD2"
                });

                Columns.Add(new DatabaseColumn("IN2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IN2"
                });

                Columns.Add(new DatabaseColumn("NEEDIN2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDIN2"
                });

                Columns.Add(new DatabaseColumn("BOVERTIME2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BOVERTIME2"
                });

                Columns.Add(new DatabaseColumn("OUT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OUT2"
                });

                Columns.Add(new DatabaseColumn("DELAY2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DELAY2"
                });

                Columns.Add(new DatabaseColumn("NEEDOUT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDOUT2"
                });

                Columns.Add(new DatabaseColumn("EOVERTIME2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EOVERTIME2"
                });

                Columns.Add(new DatabaseColumn("REST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST2"
                });

                Columns.Add(new DatabaseColumn("REST_BEGIN2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST_BEGIN2"
                });

                Columns.Add(new DatabaseColumn("BREAK2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BREAK2"
                });

                Columns.Add(new DatabaseColumn("OT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT2"
                });

                Columns.Add(new DatabaseColumn("EXT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EXT2"
                });

                Columns.Add(new DatabaseColumn("CANOT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CANOT2"
                });

                Columns.Add(new DatabaseColumn("OT_REST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST2"
                });

                Columns.Add(new DatabaseColumn("OT_REST_BEGIN2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST_BEGIN2"
                });

                Columns.Add(new DatabaseColumn("BASICHRS2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BASICHRS2"
                });

                Columns.Add(new DatabaseColumn("NEEDHRS2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDHRS2"
                });

                Columns.Add(new DatabaseColumn("DAY2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DAY2"
                });

                Columns.Add(new DatabaseColumn("AHEAD3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "AHEAD3"
                });

                Columns.Add(new DatabaseColumn("IN3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IN3"
                });

                Columns.Add(new DatabaseColumn("NEEDIN3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDIN3"
                });

                Columns.Add(new DatabaseColumn("BOVERTIME3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BOVERTIME3"
                });

                Columns.Add(new DatabaseColumn("OUT3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OUT3"
                });

                Columns.Add(new DatabaseColumn("DELAY3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DELAY3"
                });

                Columns.Add(new DatabaseColumn("NEEDOUT3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDOUT3"
                });

                Columns.Add(new DatabaseColumn("EOVERTIME3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EOVERTIME3"
                });

                Columns.Add(new DatabaseColumn("REST3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST3"
                });

                Columns.Add(new DatabaseColumn("REST_BEGIN3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST_BEGIN3"
                });

                Columns.Add(new DatabaseColumn("BREAK3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BREAK3"
                });

                Columns.Add(new DatabaseColumn("OT3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT3"
                });

                Columns.Add(new DatabaseColumn("EXT3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EXT3"
                });

                Columns.Add(new DatabaseColumn("CANOT3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CANOT3"
                });

                Columns.Add(new DatabaseColumn("OT_REST3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST3"
                });

                Columns.Add(new DatabaseColumn("OT_REST_BEGIN3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST_BEGIN3"
                });

                Columns.Add(new DatabaseColumn("BASICHRS3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BASICHRS3"
                });

                Columns.Add(new DatabaseColumn("NEEDHRS3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDHRS3"
                });

                Columns.Add(new DatabaseColumn("DAY3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DAY3"
                });

                Columns.Add(new DatabaseColumn("AHEAD4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "AHEAD4"
                });

                Columns.Add(new DatabaseColumn("IN4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IN4"
                });

                Columns.Add(new DatabaseColumn("NEEDIN4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDIN4"
                });

                Columns.Add(new DatabaseColumn("BOVERTIME4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BOVERTIME4"
                });

                Columns.Add(new DatabaseColumn("OUT4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OUT4"
                });

                Columns.Add(new DatabaseColumn("DELAY4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DELAY4"
                });

                Columns.Add(new DatabaseColumn("NEEDOUT4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDOUT4"
                });

                Columns.Add(new DatabaseColumn("EOVERTIME4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EOVERTIME4"
                });

                Columns.Add(new DatabaseColumn("REST4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST4"
                });

                Columns.Add(new DatabaseColumn("REST_BEGIN4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "REST_BEGIN4"
                });

                Columns.Add(new DatabaseColumn("BREAK4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BREAK4"
                });

                Columns.Add(new DatabaseColumn("OT4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT4"
                });

                Columns.Add(new DatabaseColumn("EXT4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EXT4"
                });

                Columns.Add(new DatabaseColumn("CANOT4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CANOT4"
                });

                Columns.Add(new DatabaseColumn("OT_REST4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST4"
                });

                Columns.Add(new DatabaseColumn("OT_REST_BEGIN4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OT_REST_BEGIN4"
                });

                Columns.Add(new DatabaseColumn("BASICHRS4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BASICHRS4"
                });

                Columns.Add(new DatabaseColumn("NEEDHRS4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NEEDHRS4"
                });

                Columns.Add(new DatabaseColumn("DAY4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DAY4"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn SHIFT_ID{
                get{
                    return this.GetColumn("SHIFT_ID");
                }
            }
				
            
            public IColumn SHIFT_NAME{
                get{
                    return this.GetColumn("SHIFT_NAME");
                }
            }
				
            
            public IColumn DEPART_ID{
                get{
                    return this.GetColumn("DEPART_ID");
                }
            }
				
            
            public IColumn SHIFT_KIND{
                get{
                    return this.GetColumn("SHIFT_KIND");
                }
            }
				
            
            public IColumn WORK_HRS{
                get{
                    return this.GetColumn("WORK_HRS");
                }
            }
				
            
            public IColumn NEED_HRS{
                get{
                    return this.GetColumn("NEED_HRS");
                }
            }
				
            
            public IColumn IS_DEFAULT{
                get{
                    return this.GetColumn("IS_DEFAULT");
                }
            }
				
            
            public IColumn RULE_ID{
                get{
                    return this.GetColumn("RULE_ID");
                }
            }
				
            
            public IColumn CLASS_ID{
                get{
                    return this.GetColumn("CLASS_ID");
                }
            }
				
            
            public IColumn NEED_SIGN_COUNT{
                get{
                    return this.GetColumn("NEED_SIGN_COUNT");
                }
            }
				
            
            public IColumn IS_COMMON{
                get{
                    return this.GetColumn("IS_COMMON");
                }
            }
				
            
            public IColumn AHEAD1{
                get{
                    return this.GetColumn("AHEAD1");
                }
            }
				
            
            public IColumn IN1{
                get{
                    return this.GetColumn("IN1");
                }
            }
				
            
            public IColumn NEEDIN1{
                get{
                    return this.GetColumn("NEEDIN1");
                }
            }
				
            
            public IColumn BOVERTIME1{
                get{
                    return this.GetColumn("BOVERTIME1");
                }
            }
				
            
            public IColumn OUT1{
                get{
                    return this.GetColumn("OUT1");
                }
            }
				
            
            public IColumn DELAY1{
                get{
                    return this.GetColumn("DELAY1");
                }
            }
				
            
            public IColumn NEEDOUT1{
                get{
                    return this.GetColumn("NEEDOUT1");
                }
            }
				
            
            public IColumn EOVERTIME1{
                get{
                    return this.GetColumn("EOVERTIME1");
                }
            }
				
            
            public IColumn REST1{
                get{
                    return this.GetColumn("REST1");
                }
            }
				
            
            public IColumn REST_BEGIN1{
                get{
                    return this.GetColumn("REST_BEGIN1");
                }
            }
				
            
            public IColumn BREAK1{
                get{
                    return this.GetColumn("BREAK1");
                }
            }
				
            
            public IColumn OT1{
                get{
                    return this.GetColumn("OT1");
                }
            }
				
            
            public IColumn EXT1{
                get{
                    return this.GetColumn("EXT1");
                }
            }
				
            
            public IColumn CANOT1{
                get{
                    return this.GetColumn("CANOT1");
                }
            }
				
            
            public IColumn OT_REST1{
                get{
                    return this.GetColumn("OT_REST1");
                }
            }
				
            
            public IColumn OT_REST_BEGIN1{
                get{
                    return this.GetColumn("OT_REST_BEGIN1");
                }
            }
				
            
            public IColumn BASICHRS1{
                get{
                    return this.GetColumn("BASICHRS1");
                }
            }
				
            
            public IColumn NEEDHRS1{
                get{
                    return this.GetColumn("NEEDHRS1");
                }
            }
				
            
            public IColumn DAY1{
                get{
                    return this.GetColumn("DAY1");
                }
            }
				
            
            public IColumn AHEAD2{
                get{
                    return this.GetColumn("AHEAD2");
                }
            }
				
            
            public IColumn IN2{
                get{
                    return this.GetColumn("IN2");
                }
            }
				
            
            public IColumn NEEDIN2{
                get{
                    return this.GetColumn("NEEDIN2");
                }
            }
				
            
            public IColumn BOVERTIME2{
                get{
                    return this.GetColumn("BOVERTIME2");
                }
            }
				
            
            public IColumn OUT2{
                get{
                    return this.GetColumn("OUT2");
                }
            }
				
            
            public IColumn DELAY2{
                get{
                    return this.GetColumn("DELAY2");
                }
            }
				
            
            public IColumn NEEDOUT2{
                get{
                    return this.GetColumn("NEEDOUT2");
                }
            }
				
            
            public IColumn EOVERTIME2{
                get{
                    return this.GetColumn("EOVERTIME2");
                }
            }
				
            
            public IColumn REST2{
                get{
                    return this.GetColumn("REST2");
                }
            }
				
            
            public IColumn REST_BEGIN2{
                get{
                    return this.GetColumn("REST_BEGIN2");
                }
            }
				
            
            public IColumn BREAK2{
                get{
                    return this.GetColumn("BREAK2");
                }
            }
				
            
            public IColumn OT2{
                get{
                    return this.GetColumn("OT2");
                }
            }
				
            
            public IColumn EXT2{
                get{
                    return this.GetColumn("EXT2");
                }
            }
				
            
            public IColumn CANOT2{
                get{
                    return this.GetColumn("CANOT2");
                }
            }
				
            
            public IColumn OT_REST2{
                get{
                    return this.GetColumn("OT_REST2");
                }
            }
				
            
            public IColumn OT_REST_BEGIN2{
                get{
                    return this.GetColumn("OT_REST_BEGIN2");
                }
            }
				
            
            public IColumn BASICHRS2{
                get{
                    return this.GetColumn("BASICHRS2");
                }
            }
				
            
            public IColumn NEEDHRS2{
                get{
                    return this.GetColumn("NEEDHRS2");
                }
            }
				
            
            public IColumn DAY2{
                get{
                    return this.GetColumn("DAY2");
                }
            }
				
            
            public IColumn AHEAD3{
                get{
                    return this.GetColumn("AHEAD3");
                }
            }
				
            
            public IColumn IN3{
                get{
                    return this.GetColumn("IN3");
                }
            }
				
            
            public IColumn NEEDIN3{
                get{
                    return this.GetColumn("NEEDIN3");
                }
            }
				
            
            public IColumn BOVERTIME3{
                get{
                    return this.GetColumn("BOVERTIME3");
                }
            }
				
            
            public IColumn OUT3{
                get{
                    return this.GetColumn("OUT3");
                }
            }
				
            
            public IColumn DELAY3{
                get{
                    return this.GetColumn("DELAY3");
                }
            }
				
            
            public IColumn NEEDOUT3{
                get{
                    return this.GetColumn("NEEDOUT3");
                }
            }
				
            
            public IColumn EOVERTIME3{
                get{
                    return this.GetColumn("EOVERTIME3");
                }
            }
				
            
            public IColumn REST3{
                get{
                    return this.GetColumn("REST3");
                }
            }
				
            
            public IColumn REST_BEGIN3{
                get{
                    return this.GetColumn("REST_BEGIN3");
                }
            }
				
            
            public IColumn BREAK3{
                get{
                    return this.GetColumn("BREAK3");
                }
            }
				
            
            public IColumn OT3{
                get{
                    return this.GetColumn("OT3");
                }
            }
				
            
            public IColumn EXT3{
                get{
                    return this.GetColumn("EXT3");
                }
            }
				
            
            public IColumn CANOT3{
                get{
                    return this.GetColumn("CANOT3");
                }
            }
				
            
            public IColumn OT_REST3{
                get{
                    return this.GetColumn("OT_REST3");
                }
            }
				
            
            public IColumn OT_REST_BEGIN3{
                get{
                    return this.GetColumn("OT_REST_BEGIN3");
                }
            }
				
            
            public IColumn BASICHRS3{
                get{
                    return this.GetColumn("BASICHRS3");
                }
            }
				
            
            public IColumn NEEDHRS3{
                get{
                    return this.GetColumn("NEEDHRS3");
                }
            }
				
            
            public IColumn DAY3{
                get{
                    return this.GetColumn("DAY3");
                }
            }
				
            
            public IColumn AHEAD4{
                get{
                    return this.GetColumn("AHEAD4");
                }
            }
				
            
            public IColumn IN4{
                get{
                    return this.GetColumn("IN4");
                }
            }
				
            
            public IColumn NEEDIN4{
                get{
                    return this.GetColumn("NEEDIN4");
                }
            }
				
            
            public IColumn BOVERTIME4{
                get{
                    return this.GetColumn("BOVERTIME4");
                }
            }
				
            
            public IColumn OUT4{
                get{
                    return this.GetColumn("OUT4");
                }
            }
				
            
            public IColumn DELAY4{
                get{
                    return this.GetColumn("DELAY4");
                }
            }
				
            
            public IColumn NEEDOUT4{
                get{
                    return this.GetColumn("NEEDOUT4");
                }
            }
				
            
            public IColumn EOVERTIME4{
                get{
                    return this.GetColumn("EOVERTIME4");
                }
            }
				
            
            public IColumn REST4{
                get{
                    return this.GetColumn("REST4");
                }
            }
				
            
            public IColumn REST_BEGIN4{
                get{
                    return this.GetColumn("REST_BEGIN4");
                }
            }
				
            
            public IColumn BREAK4{
                get{
                    return this.GetColumn("BREAK4");
                }
            }
				
            
            public IColumn OT4{
                get{
                    return this.GetColumn("OT4");
                }
            }
				
            
            public IColumn EXT4{
                get{
                    return this.GetColumn("EXT4");
                }
            }
				
            
            public IColumn CANOT4{
                get{
                    return this.GetColumn("CANOT4");
                }
            }
				
            
            public IColumn OT_REST4{
                get{
                    return this.GetColumn("OT_REST4");
                }
            }
				
            
            public IColumn OT_REST_BEGIN4{
                get{
                    return this.GetColumn("OT_REST_BEGIN4");
                }
            }
				
            
            public IColumn BASICHRS4{
                get{
                    return this.GetColumn("BASICHRS4");
                }
            }
				
            
            public IColumn NEEDHRS4{
                get{
                    return this.GetColumn("NEEDHRS4");
                }
            }
				
            
            public IColumn DAY4{
                get{
                    return this.GetColumn("DAY4");
                }
            }
				
            
                    
        }
        
}
