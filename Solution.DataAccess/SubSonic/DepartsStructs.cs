 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Departs
        /// Primary Key: depart_id
        /// </summary>

        public class DepartsStructs: DatabaseTable {
            
            public DepartsStructs(IDataProvider provider):base("Departs",provider){
                ClassName = "Departs";
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

                Columns.Add(new DatabaseColumn("depart_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "depart_id"
                });

                Columns.Add(new DatabaseColumn("inside_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "inside_id"
                });

                Columns.Add(new DatabaseColumn("depart_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "depart_name"
                });

                Columns.Add(new DatabaseColumn("manager1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "manager1"
                });

                Columns.Add(new DatabaseColumn("job_id1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
					PropertyName = "job_id1"
                });

                Columns.Add(new DatabaseColumn("manager2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "manager2"
                });

                Columns.Add(new DatabaseColumn("job_id2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
					PropertyName = "job_id2"
                });

                Columns.Add(new DatabaseColumn("emp_prefix", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 3,
					PropertyName = "emp_prefix"
                });

                Columns.Add(new DatabaseColumn("plan_num", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "plan_num"
                });

                Columns.Add(new DatabaseColumn("linktel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "linktel"
                });

                Columns.Add(new DatabaseColumn("remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "remark"
                });

                Columns.Add(new DatabaseColumn("butei_money", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Currency,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "butei_money"
                });

                Columns.Add(new DatabaseColumn("audit_access", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "audit_access"
                });

                Columns.Add(new DatabaseColumn("TreeLevel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "TreeLevel"
                });

                Columns.Add(new DatabaseColumn("Up_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 28,
					PropertyName = "Up_ID"
                });

                Columns.Add(new DatabaseColumn("LongName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "LongName"
                });

                Columns.Add(new DatabaseColumn("access_level", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "access_level"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn depart_id{
                get{
                    return this.GetColumn("depart_id");
                }
            }
				
            
            public IColumn inside_id{
                get{
                    return this.GetColumn("inside_id");
                }
            }
				
            
            public IColumn depart_name{
                get{
                    return this.GetColumn("depart_name");
                }
            }
				
            
            public IColumn manager1{
                get{
                    return this.GetColumn("manager1");
                }
            }
				
            
            public IColumn job_id1{
                get{
                    return this.GetColumn("job_id1");
                }
            }
				
            
            public IColumn manager2{
                get{
                    return this.GetColumn("manager2");
                }
            }
				
            
            public IColumn job_id2{
                get{
                    return this.GetColumn("job_id2");
                }
            }
				
            
            public IColumn emp_prefix{
                get{
                    return this.GetColumn("emp_prefix");
                }
            }
				
            
            public IColumn plan_num{
                get{
                    return this.GetColumn("plan_num");
                }
            }
				
            
            public IColumn linktel{
                get{
                    return this.GetColumn("linktel");
                }
            }
				
            
            public IColumn remark{
                get{
                    return this.GetColumn("remark");
                }
            }
				
            
            public IColumn butei_money{
                get{
                    return this.GetColumn("butei_money");
                }
            }
				
            
            public IColumn audit_access{
                get{
                    return this.GetColumn("audit_access");
                }
            }
				
            
            public IColumn TreeLevel{
                get{
                    return this.GetColumn("TreeLevel");
                }
            }
				
            
            public IColumn Up_ID{
                get{
                    return this.GetColumn("Up_ID");
                }
            }
				
            
            public IColumn LongName{
                get{
                    return this.GetColumn("LongName");
                }
            }
				
            
            public IColumn access_level{
                get{
                    return this.GetColumn("access_level");
                }
            }
				
            
                    
        }
        
}
