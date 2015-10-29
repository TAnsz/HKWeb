 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MeetingRoomApply
        /// Primary Key: Id
        /// </summary>

        public class MeetingRoomApplyStructs: DatabaseTable {
            
            public MeetingRoomApplyStructs(IDataProvider provider):base("MeetingRoomApply",provider){
                ClassName = "MeetingRoomApply";
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

                Columns.Add(new DatabaseColumn("Code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "Code"
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Name"
                });

                Columns.Add(new DatabaseColumn("MeetingRoom_Code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "MeetingRoom_Code"
                });

                Columns.Add(new DatabaseColumn("MeetingRoom_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "MeetingRoom_Name"
                });

                Columns.Add(new DatabaseColumn("ApplyDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ApplyDate"
                });

                Columns.Add(new DatabaseColumn("StartTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 5,
					PropertyName = "StartTime"
                });

                Columns.Add(new DatabaseColumn("EndTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 5,
					PropertyName = "EndTime"
                });

                Columns.Add(new DatabaseColumn("Employee_EmpId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "Employee_EmpId"
                });

                Columns.Add(new DatabaseColumn("Employee_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Employee_Name"
                });

                Columns.Add(new DatabaseColumn("DepartId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "DepartId"
                });

                Columns.Add(new DatabaseColumn("DepartName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DepartName"
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500,
					PropertyName = "Remark"
                });

                Columns.Add(new DatabaseColumn("IsVaild", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsVaild"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn Code{
                get{
                    return this.GetColumn("Code");
                }
            }
				
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
            
            public IColumn MeetingRoom_Code{
                get{
                    return this.GetColumn("MeetingRoom_Code");
                }
            }
				
            
            public IColumn MeetingRoom_Name{
                get{
                    return this.GetColumn("MeetingRoom_Name");
                }
            }
				
            
            public IColumn ApplyDate{
                get{
                    return this.GetColumn("ApplyDate");
                }
            }
				
            
            public IColumn StartTime{
                get{
                    return this.GetColumn("StartTime");
                }
            }
				
            
            public IColumn EndTime{
                get{
                    return this.GetColumn("EndTime");
                }
            }
				
            
            public IColumn Employee_EmpId{
                get{
                    return this.GetColumn("Employee_EmpId");
                }
            }
				
            
            public IColumn Employee_Name{
                get{
                    return this.GetColumn("Employee_Name");
                }
            }
				
            
            public IColumn DepartId{
                get{
                    return this.GetColumn("DepartId");
                }
            }
				
            
            public IColumn DepartName{
                get{
                    return this.GetColumn("DepartName");
                }
            }
				
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
            
            public IColumn IsVaild{
                get{
                    return this.GetColumn("IsVaild");
                }
            }
				
            
                    
        }
        
}
