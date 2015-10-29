 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: adJustRest_D
        /// Primary Key: bill_id
        /// </summary>

        public class adJustRest_DStructs: DatabaseTable {
            
            public adJustRest_DStructs(IDataProvider provider):base("adJustRest_D",provider){
                ClassName = "adJustRest_D";
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

                Columns.Add(new DatabaseColumn("bill_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "bill_id"
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

                Columns.Add(new DatabaseColumn("ori_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ori_date"
                });

                Columns.Add(new DatabaseColumn("ori_btime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ori_btime"
                });

                Columns.Add(new DatabaseColumn("ori_etime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ori_etime"
                });

                Columns.Add(new DatabaseColumn("rest_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "rest_date"
                });

                Columns.Add(new DatabaseColumn("rest_btime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "rest_btime"
                });

                Columns.Add(new DatabaseColumn("rest_etime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "rest_etime"
                });

                Columns.Add(new DatabaseColumn("checker", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "checker"
                });

                Columns.Add(new DatabaseColumn("check_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "check_date"
                });

                Columns.Add(new DatabaseColumn("op_user", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "op_user"
                });

                Columns.Add(new DatabaseColumn("op_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "op_date"
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

                Columns.Add(new DatabaseColumn("memo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200,
					PropertyName = "memo"
                });

                Columns.Add(new DatabaseColumn("all_day", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "all_day"
                });

                Columns.Add(new DatabaseColumn("kind", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "kind"
                });

                Columns.Add(new DatabaseColumn("refuse_reason", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "refuse_reason"
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

                Columns.Add(new DatabaseColumn("audit2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "audit2"
                });

                Columns.Add(new DatabaseColumn("check_date2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "check_date2"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn bill_id{
                get{
                    return this.GetColumn("bill_id");
                }
            }
				
            
            public IColumn emp_id{
                get{
                    return this.GetColumn("emp_id");
                }
            }
				
            
            public IColumn join_id{
                get{
                    return this.GetColumn("join_id");
                }
            }
				
            
            public IColumn depart_id{
                get{
                    return this.GetColumn("depart_id");
                }
            }
				
            
            public IColumn ori_date{
                get{
                    return this.GetColumn("ori_date");
                }
            }
				
            
            public IColumn ori_btime{
                get{
                    return this.GetColumn("ori_btime");
                }
            }
				
            
            public IColumn ori_etime{
                get{
                    return this.GetColumn("ori_etime");
                }
            }
				
            
            public IColumn rest_date{
                get{
                    return this.GetColumn("rest_date");
                }
            }
				
            
            public IColumn rest_btime{
                get{
                    return this.GetColumn("rest_btime");
                }
            }
				
            
            public IColumn rest_etime{
                get{
                    return this.GetColumn("rest_etime");
                }
            }
				
            
            public IColumn checker{
                get{
                    return this.GetColumn("checker");
                }
            }
				
            
            public IColumn check_date{
                get{
                    return this.GetColumn("check_date");
                }
            }
				
            
            public IColumn op_user{
                get{
                    return this.GetColumn("op_user");
                }
            }
				
            
            public IColumn op_date{
                get{
                    return this.GetColumn("op_date");
                }
            }
				
            
            public IColumn audit{
                get{
                    return this.GetColumn("audit");
                }
            }
				
            
            public IColumn memo{
                get{
                    return this.GetColumn("memo");
                }
            }
				
            
            public IColumn all_day{
                get{
                    return this.GetColumn("all_day");
                }
            }
				
            
            public IColumn kind{
                get{
                    return this.GetColumn("kind");
                }
            }
				
            
            public IColumn refuse_reason{
                get{
                    return this.GetColumn("refuse_reason");
                }
            }
				
            
            public IColumn CHECKER2{
                get{
                    return this.GetColumn("CHECKER2");
                }
            }
				
            
            public IColumn audit2{
                get{
                    return this.GetColumn("audit2");
                }
            }
				
            
            public IColumn check_date2{
                get{
                    return this.GetColumn("check_date2");
                }
            }
				
            
                    
        }
        
}
