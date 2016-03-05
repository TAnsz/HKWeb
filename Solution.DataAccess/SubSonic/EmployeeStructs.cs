 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Employee
        /// Primary Key: Id
        /// </summary>

        public class EmployeeStructs: DatabaseTable {
            
            public EmployeeStructs(IDataProvider provider):base("Employee",provider){
                ClassName = "Employee";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("EMP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "EMP_ID"
                });

                Columns.Add(new DatabaseColumn("CARD_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "CARD_ID"
                });

                Columns.Add(new DatabaseColumn("EMP_FNAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "EMP_FNAME"
                });

                Columns.Add(new DatabaseColumn("KIND", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "KIND"
                });

                Columns.Add(new DatabaseColumn("ID_CARD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "ID_CARD"
                });

                Columns.Add(new DatabaseColumn("NO_SIGN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NO_SIGN"
                });

                Columns.Add(new DatabaseColumn("DEPART_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "DEPART_ID"
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

                Columns.Add(new DatabaseColumn("EDU_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "EDU_ID"
                });

                Columns.Add(new DatabaseColumn("BIRTH_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BIRTH_DATE"
                });

                Columns.Add(new DatabaseColumn("HIRE_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "HIRE_DATE"
                });

                Columns.Add(new DatabaseColumn("CARDBEG_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CARDBEG_DATE"
                });

                Columns.Add(new DatabaseColumn("CARDEND_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CARDEND_DATE"
                });

                Columns.Add(new DatabaseColumn("LEAVE_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LEAVE_DATE"
                });

                Columns.Add(new DatabaseColumn("JOIN_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "JOIN_DATE"
                });

                Columns.Add(new DatabaseColumn("TEMP_MONTH", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "TEMP_MONTH"
                });

                Columns.Add(new DatabaseColumn("ISWAIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ISWAIT"
                });

                Columns.Add(new DatabaseColumn("DIMISSION_TYPE_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "DIMISSION_TYPE_ID"
                });

                Columns.Add(new DatabaseColumn("SEX", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "SEX"
                });

                Columns.Add(new DatabaseColumn("MARRIAGE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4,
					PropertyName = "MARRIAGE"
                });

                Columns.Add(new DatabaseColumn("EMAIL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "EMAIL"
                });

                Columns.Add(new DatabaseColumn("PHONE_CODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PHONE_CODE"
                });

                Columns.Add(new DatabaseColumn("ADDRESS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "ADDRESS"
                });

                Columns.Add(new DatabaseColumn("POST_CODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "POST_CODE"
                });

                Columns.Add(new DatabaseColumn("HANDER_CODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "HANDER_CODE"
                });

                Columns.Add(new DatabaseColumn("HTTP_ADDRESS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "HTTP_ADDRESS"
                });

                Columns.Add(new DatabaseColumn("LINK_MAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "LINK_MAN"
                });

                Columns.Add(new DatabaseColumn("LEAVE_CAUSE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "LEAVE_CAUSE"
                });

                Columns.Add(new DatabaseColumn("SHIFTS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500,
					PropertyName = "SHIFTS"
                });

                Columns.Add(new DatabaseColumn("ISSUED", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ISSUED"
                });

                Columns.Add(new DatabaseColumn("ISSUE_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ISSUE_DATE"
                });

                Columns.Add(new DatabaseColumn("ACCESS_LEVEL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ACCESS_LEVEL"
                });

                Columns.Add(new DatabaseColumn("ACCESS_PWD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "ACCESS_PWD"
                });

                Columns.Add(new DatabaseColumn("MEAL_LEVEL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "MEAL_LEVEL"
                });

                Columns.Add(new DatabaseColumn("MEAL_PWD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "MEAL_PWD"
                });

                Columns.Add(new DatabaseColumn("FORCE_PWD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "FORCE_PWD"
                });

                Columns.Add(new DatabaseColumn("CARD_SN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "CARD_SN"
                });

                Columns.Add(new DatabaseColumn("PHOTO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Binary,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647,
					PropertyName = "PHOTO"
                });

                Columns.Add(new DatabaseColumn("ISPATROL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ISPATROL"
                });

                Columns.Add(new DatabaseColumn("DOOR_CARD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "DOOR_CARD"
                });

                Columns.Add(new DatabaseColumn("MEAL_CARD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "MEAL_CARD"
                });

                Columns.Add(new DatabaseColumn("OP_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "OP_DATE"
                });

                Columns.Add(new DatabaseColumn("OP_USER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "OP_USER"
                });

                Columns.Add(new DatabaseColumn("RETURNCARD_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "RETURNCARD_ID"
                });

                Columns.Add(new DatabaseColumn("RETURNCARD_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "RETURNCARD_DATE"
                });

                Columns.Add(new DatabaseColumn("LEAVE_TEXT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823,
					PropertyName = "LEAVE_TEXT"
                });

                Columns.Add(new DatabaseColumn("DEF0", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF0"
                });

                Columns.Add(new DatabaseColumn("DEF1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF1"
                });

                Columns.Add(new DatabaseColumn("DEF2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF2"
                });

                Columns.Add(new DatabaseColumn("DEF3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF3"
                });

                Columns.Add(new DatabaseColumn("DEF4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF4"
                });

                Columns.Add(new DatabaseColumn("DEF5", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF5"
                });

                Columns.Add(new DatabaseColumn("DEF6", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF6"
                });

                Columns.Add(new DatabaseColumn("DEF7", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF7"
                });

                Columns.Add(new DatabaseColumn("DEF8", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF8"
                });

                Columns.Add(new DatabaseColumn("DEF9", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DEF9"
                });

                Columns.Add(new DatabaseColumn("IS_SHEBAO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IS_SHEBAO"
                });

                Columns.Add(new DatabaseColumn("SHEBAO_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SHEBAO_DATE"
                });

                Columns.Add(new DatabaseColumn("BANK_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "BANK_NAME"
                });

                Columns.Add(new DatabaseColumn("BANK_CODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "BANK_CODE"
                });

                Columns.Add(new DatabaseColumn("DOWN_FLAG", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DOWN_FLAG"
                });

                Columns.Add(new DatabaseColumn("DOOR_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DOOR_ID"
                });

                Columns.Add(new DatabaseColumn("REMARK", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "REMARK"
                });

                Columns.Add(new DatabaseColumn("LOGINPASS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "LOGINPASS"
                });

                Columns.Add(new DatabaseColumn("SFZ_BEGINDATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SFZ_BEGINDATE"
                });

                Columns.Add(new DatabaseColumn("SFZ_ENDDATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SFZ_ENDDATE"
                });

                Columns.Add(new DatabaseColumn("FINGERID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
					PropertyName = "FINGERID"
                });

                Columns.Add(new DatabaseColumn("ISDOWNFINGER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ISDOWNFINGER"
                });

                Columns.Add(new DatabaseColumn("INTROEMP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "INTROEMP"
                });

                Columns.Add(new DatabaseColumn("DEVID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200,
					PropertyName = "DEVID"
                });

                Columns.Add(new DatabaseColumn("CHECKTYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "CHECKTYPE"
                });

                Columns.Add(new DatabaseColumn("OPENDOORTYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "OPENDOORTYPE"
                });

                Columns.Add(new DatabaseColumn("MODELNUM", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "MODELNUM"
                });

                Columns.Add(new DatabaseColumn("FACE_DATA", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2147483647,
					PropertyName = "FACE_DATA"
                });

                Columns.Add(new DatabaseColumn("DEVTYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DEVTYPE"
                });

                Columns.Add(new DatabaseColumn("LEVELS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LEVELS"
                });

                Columns.Add(new DatabaseColumn("PASSWORD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Binary,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 256,
					PropertyName = "PASSWORD"
                });

                Columns.Add(new DatabaseColumn("GROUPS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "GROUPS"
                });

                Columns.Add(new DatabaseColumn("EN_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "EN_NAME"
                });

                Columns.Add(new DatabaseColumn("CHECKER2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "CHECKER2"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn EMP_ID{
                get{
                    return this.GetColumn("EMP_ID");
                }
            }
				
            
            public IColumn CARD_ID{
                get{
                    return this.GetColumn("CARD_ID");
                }
            }
				
            
            public IColumn EMP_FNAME{
                get{
                    return this.GetColumn("EMP_FNAME");
                }
            }
				
            
            public IColumn KIND{
                get{
                    return this.GetColumn("KIND");
                }
            }
				
            
            public IColumn ID_CARD{
                get{
                    return this.GetColumn("ID_CARD");
                }
            }
				
            
            public IColumn NO_SIGN{
                get{
                    return this.GetColumn("NO_SIGN");
                }
            }
				
            
            public IColumn DEPART_ID{
                get{
                    return this.GetColumn("DEPART_ID");
                }
            }
				
            
            public IColumn RULE_ID{
                get{
                    return this.GetColumn("RULE_ID");
                }
            }
				
            
            public IColumn EDU_ID{
                get{
                    return this.GetColumn("EDU_ID");
                }
            }
				
            
            public IColumn BIRTH_DATE{
                get{
                    return this.GetColumn("BIRTH_DATE");
                }
            }
				
            
            public IColumn HIRE_DATE{
                get{
                    return this.GetColumn("HIRE_DATE");
                }
            }
				
            
            public IColumn CARDBEG_DATE{
                get{
                    return this.GetColumn("CARDBEG_DATE");
                }
            }
				
            
            public IColumn CARDEND_DATE{
                get{
                    return this.GetColumn("CARDEND_DATE");
                }
            }
				
            
            public IColumn LEAVE_DATE{
                get{
                    return this.GetColumn("LEAVE_DATE");
                }
            }
				
            
            public IColumn JOIN_DATE{
                get{
                    return this.GetColumn("JOIN_DATE");
                }
            }
				
            
            public IColumn TEMP_MONTH{
                get{
                    return this.GetColumn("TEMP_MONTH");
                }
            }
				
            
            public IColumn ISWAIT{
                get{
                    return this.GetColumn("ISWAIT");
                }
            }
				
            
            public IColumn DIMISSION_TYPE_ID{
                get{
                    return this.GetColumn("DIMISSION_TYPE_ID");
                }
            }
				
            
            public IColumn SEX{
                get{
                    return this.GetColumn("SEX");
                }
            }
				
            
            public IColumn MARRIAGE{
                get{
                    return this.GetColumn("MARRIAGE");
                }
            }
				
            
            public IColumn EMAIL{
                get{
                    return this.GetColumn("EMAIL");
                }
            }
				
            
            public IColumn PHONE_CODE{
                get{
                    return this.GetColumn("PHONE_CODE");
                }
            }
				
            
            public IColumn ADDRESS{
                get{
                    return this.GetColumn("ADDRESS");
                }
            }
				
            
            public IColumn POST_CODE{
                get{
                    return this.GetColumn("POST_CODE");
                }
            }
				
            
            public IColumn HANDER_CODE{
                get{
                    return this.GetColumn("HANDER_CODE");
                }
            }
				
            
            public IColumn HTTP_ADDRESS{
                get{
                    return this.GetColumn("HTTP_ADDRESS");
                }
            }
				
            
            public IColumn LINK_MAN{
                get{
                    return this.GetColumn("LINK_MAN");
                }
            }
				
            
            public IColumn LEAVE_CAUSE{
                get{
                    return this.GetColumn("LEAVE_CAUSE");
                }
            }
				
            
            public IColumn SHIFTS{
                get{
                    return this.GetColumn("SHIFTS");
                }
            }
				
            
            public IColumn ISSUED{
                get{
                    return this.GetColumn("ISSUED");
                }
            }
				
            
            public IColumn ISSUE_DATE{
                get{
                    return this.GetColumn("ISSUE_DATE");
                }
            }
				
            
            public IColumn ACCESS_LEVEL{
                get{
                    return this.GetColumn("ACCESS_LEVEL");
                }
            }
				
            
            public IColumn ACCESS_PWD{
                get{
                    return this.GetColumn("ACCESS_PWD");
                }
            }
				
            
            public IColumn MEAL_LEVEL{
                get{
                    return this.GetColumn("MEAL_LEVEL");
                }
            }
				
            
            public IColumn MEAL_PWD{
                get{
                    return this.GetColumn("MEAL_PWD");
                }
            }
				
            
            public IColumn FORCE_PWD{
                get{
                    return this.GetColumn("FORCE_PWD");
                }
            }
				
            
            public IColumn CARD_SN{
                get{
                    return this.GetColumn("CARD_SN");
                }
            }
				
            
            public IColumn PHOTO{
                get{
                    return this.GetColumn("PHOTO");
                }
            }
				
            
            public IColumn ISPATROL{
                get{
                    return this.GetColumn("ISPATROL");
                }
            }
				
            
            public IColumn DOOR_CARD{
                get{
                    return this.GetColumn("DOOR_CARD");
                }
            }
				
            
            public IColumn MEAL_CARD{
                get{
                    return this.GetColumn("MEAL_CARD");
                }
            }
				
            
            public IColumn OP_DATE{
                get{
                    return this.GetColumn("OP_DATE");
                }
            }
				
            
            public IColumn OP_USER{
                get{
                    return this.GetColumn("OP_USER");
                }
            }
				
            
            public IColumn RETURNCARD_ID{
                get{
                    return this.GetColumn("RETURNCARD_ID");
                }
            }
				
            
            public IColumn RETURNCARD_DATE{
                get{
                    return this.GetColumn("RETURNCARD_DATE");
                }
            }
				
            
            public IColumn LEAVE_TEXT{
                get{
                    return this.GetColumn("LEAVE_TEXT");
                }
            }
				
            
            public IColumn DEF0{
                get{
                    return this.GetColumn("DEF0");
                }
            }
				
            
            public IColumn DEF1{
                get{
                    return this.GetColumn("DEF1");
                }
            }
				
            
            public IColumn DEF2{
                get{
                    return this.GetColumn("DEF2");
                }
            }
				
            
            public IColumn DEF3{
                get{
                    return this.GetColumn("DEF3");
                }
            }
				
            
            public IColumn DEF4{
                get{
                    return this.GetColumn("DEF4");
                }
            }
				
            
            public IColumn DEF5{
                get{
                    return this.GetColumn("DEF5");
                }
            }
				
            
            public IColumn DEF6{
                get{
                    return this.GetColumn("DEF6");
                }
            }
				
            
            public IColumn DEF7{
                get{
                    return this.GetColumn("DEF7");
                }
            }
				
            
            public IColumn DEF8{
                get{
                    return this.GetColumn("DEF8");
                }
            }
				
            
            public IColumn DEF9{
                get{
                    return this.GetColumn("DEF9");
                }
            }
				
            
            public IColumn IS_SHEBAO{
                get{
                    return this.GetColumn("IS_SHEBAO");
                }
            }
				
            
            public IColumn SHEBAO_DATE{
                get{
                    return this.GetColumn("SHEBAO_DATE");
                }
            }
				
            
            public IColumn BANK_NAME{
                get{
                    return this.GetColumn("BANK_NAME");
                }
            }
				
            
            public IColumn BANK_CODE{
                get{
                    return this.GetColumn("BANK_CODE");
                }
            }
				
            
            public IColumn DOWN_FLAG{
                get{
                    return this.GetColumn("DOWN_FLAG");
                }
            }
				
            
            public IColumn DOOR_ID{
                get{
                    return this.GetColumn("DOOR_ID");
                }
            }
				
            
            public IColumn REMARK{
                get{
                    return this.GetColumn("REMARK");
                }
            }
				
            
            public IColumn LOGINPASS{
                get{
                    return this.GetColumn("LOGINPASS");
                }
            }
				
            
            public IColumn SFZ_BEGINDATE{
                get{
                    return this.GetColumn("SFZ_BEGINDATE");
                }
            }
				
            
            public IColumn SFZ_ENDDATE{
                get{
                    return this.GetColumn("SFZ_ENDDATE");
                }
            }
				
            
            public IColumn FINGERID{
                get{
                    return this.GetColumn("FINGERID");
                }
            }
				
            
            public IColumn ISDOWNFINGER{
                get{
                    return this.GetColumn("ISDOWNFINGER");
                }
            }
				
            
            public IColumn INTROEMP{
                get{
                    return this.GetColumn("INTROEMP");
                }
            }
				
            
            public IColumn DEVID{
                get{
                    return this.GetColumn("DEVID");
                }
            }
				
            
            public IColumn CHECKTYPE{
                get{
                    return this.GetColumn("CHECKTYPE");
                }
            }
				
            
            public IColumn OPENDOORTYPE{
                get{
                    return this.GetColumn("OPENDOORTYPE");
                }
            }
				
            
            public IColumn MODELNUM{
                get{
                    return this.GetColumn("MODELNUM");
                }
            }
				
            
            public IColumn FACE_DATA{
                get{
                    return this.GetColumn("FACE_DATA");
                }
            }
				
            
            public IColumn DEVTYPE{
                get{
                    return this.GetColumn("DEVTYPE");
                }
            }
				
            
            public IColumn LEVELS{
                get{
                    return this.GetColumn("LEVELS");
                }
            }
				
            
            public IColumn PASSWORD{
                get{
                    return this.GetColumn("PASSWORD");
                }
            }
				
            
            public IColumn GROUPS{
                get{
                    return this.GetColumn("GROUPS");
                }
            }
				
            
            public IColumn EN_NAME{
                get{
                    return this.GetColumn("EN_NAME");
                }
            }
				
            
            public IColumn CHECKER2{
                get{
                    return this.GetColumn("CHECKER2");
                }
            }
				
            
                    
        }
        
}
