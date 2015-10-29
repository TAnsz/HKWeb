 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Rules
        /// Primary Key: rule_id
        /// </summary>

        public class RulesStructs: DatabaseTable {
            
            public RulesStructs(IDataProvider provider):base("Rules",provider){
                ClassName = "Rules";
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

                Columns.Add(new DatabaseColumn("rule_id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 8,
					PropertyName = "rule_id"
                });

                Columns.Add(new DatabaseColumn("rule_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "rule_name"
                });

                Columns.Add(new DatabaseColumn("rules", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2000,
					PropertyName = "rules"
                });

                Columns.Add(new DatabaseColumn("daysinmonth", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "daysinmonth"
                });

                Columns.Add(new DatabaseColumn("hoursinday", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hoursinday"
                });

                Columns.Add(new DatabaseColumn("ot_rate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ot_rate"
                });

                Columns.Add(new DatabaseColumn("sun_rate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sun_rate"
                });

                Columns.Add(new DatabaseColumn("hd_rate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hd_rate"
                });

                Columns.Add(new DatabaseColumn("restdatemethod", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "restdatemethod"
                });

                Columns.Add(new DatabaseColumn("sun", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sun"
                });

                Columns.Add(new DatabaseColumn("sunbegin", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sunbegin"
                });

                Columns.Add(new DatabaseColumn("sunend", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sunend"
                });

                Columns.Add(new DatabaseColumn("sat", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sat"
                });

                Columns.Add(new DatabaseColumn("satbegin", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "satbegin"
                });

                Columns.Add(new DatabaseColumn("satend", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "satend"
                });

                Columns.Add(new DatabaseColumn("vrestdate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "vrestdate"
                });

                Columns.Add(new DatabaseColumn("vrestbegtime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "vrestbegtime"
                });

                Columns.Add(new DatabaseColumn("vrestendtime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "vrestendtime"
                });

                Columns.Add(new DatabaseColumn("memo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "memo"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn rule_id{
                get{
                    return this.GetColumn("rule_id");
                }
            }
				
            
            public IColumn rule_name{
                get{
                    return this.GetColumn("rule_name");
                }
            }
				
            
            public IColumn rules{
                get{
                    return this.GetColumn("rules");
                }
            }
				
            
            public IColumn daysinmonth{
                get{
                    return this.GetColumn("daysinmonth");
                }
            }
				
            
            public IColumn hoursinday{
                get{
                    return this.GetColumn("hoursinday");
                }
            }
				
            
            public IColumn ot_rate{
                get{
                    return this.GetColumn("ot_rate");
                }
            }
				
            
            public IColumn sun_rate{
                get{
                    return this.GetColumn("sun_rate");
                }
            }
				
            
            public IColumn hd_rate{
                get{
                    return this.GetColumn("hd_rate");
                }
            }
				
            
            public IColumn restdatemethod{
                get{
                    return this.GetColumn("restdatemethod");
                }
            }
				
            
            public IColumn sun{
                get{
                    return this.GetColumn("sun");
                }
            }
				
            
            public IColumn sunbegin{
                get{
                    return this.GetColumn("sunbegin");
                }
            }
				
            
            public IColumn sunend{
                get{
                    return this.GetColumn("sunend");
                }
            }
				
            
            public IColumn sat{
                get{
                    return this.GetColumn("sat");
                }
            }
				
            
            public IColumn satbegin{
                get{
                    return this.GetColumn("satbegin");
                }
            }
				
            
            public IColumn satend{
                get{
                    return this.GetColumn("satend");
                }
            }
				
            
            public IColumn vrestdate{
                get{
                    return this.GetColumn("vrestdate");
                }
            }
				
            
            public IColumn vrestbegtime{
                get{
                    return this.GetColumn("vrestbegtime");
                }
            }
				
            
            public IColumn vrestendtime{
                get{
                    return this.GetColumn("vrestendtime");
                }
            }
				
            
            public IColumn memo{
                get{
                    return this.GetColumn("memo");
                }
            }
				
            
                    
        }
        
}
