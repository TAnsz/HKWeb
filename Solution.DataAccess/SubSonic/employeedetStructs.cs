 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: employeedet
        /// Primary Key: no
        /// </summary>

        public class employeedetStructs: DatabaseTable {
            
            public employeedetStructs(IDataProvider provider):base("employeedet",provider){
                ClassName = "employeedet";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("employeeid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "employeeid"
                });

                Columns.Add(new DatabaseColumn("comingtime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "comingtime"
                });

                Columns.Add(new DatabaseColumn("overtime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "overtime"
                });

                Columns.Add(new DatabaseColumn("date1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "date1"
                });

                Columns.Add(new DatabaseColumn("month1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2,
					PropertyName = "month1"
                });

                Columns.Add(new DatabaseColumn("year1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4,
					PropertyName = "year1"
                });

                Columns.Add(new DatabaseColumn("week1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 3,
					PropertyName = "week1"
                });

                Columns.Add(new DatabaseColumn("remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "remark"
                });

                Columns.Add(new DatabaseColumn("no", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "no"
                });

                Columns.Add(new DatabaseColumn("empid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "empid"
                });
                    
                
                
            }

            public IColumn employeeid{
                get{
                    return this.GetColumn("employeeid");
                }
            }
				
            
            public IColumn comingtime{
                get{
                    return this.GetColumn("comingtime");
                }
            }
				
            
            public IColumn overtime{
                get{
                    return this.GetColumn("overtime");
                }
            }
				
            
            public IColumn date1{
                get{
                    return this.GetColumn("date1");
                }
            }
				
            
            public IColumn month1{
                get{
                    return this.GetColumn("month1");
                }
            }
				
            
            public IColumn year1{
                get{
                    return this.GetColumn("year1");
                }
            }
				
            
            public IColumn week1{
                get{
                    return this.GetColumn("week1");
                }
            }
				
            
            public IColumn remark{
                get{
                    return this.GetColumn("remark");
                }
            }
				
            
            public IColumn no{
                get{
                    return this.GetColumn("no");
                }
            }
				
            
            public IColumn empid{
                get{
                    return this.GetColumn("empid");
                }
            }
				
            
                    
        }
        
}
