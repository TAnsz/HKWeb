 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: WeekRest
        /// Primary Key: Id
        /// </summary>

        public class WeekRestStructs: DatabaseTable {
            
            public WeekRestStructs(IDataProvider provider):base("WeekRest",provider){
                ClassName = "WeekRest";
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

                Columns.Add(new DatabaseColumn("wr_code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "wr_code"
                });

                Columns.Add(new DatabaseColumn("wr_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "wr_name"
                });

                Columns.Add(new DatabaseColumn("wr_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "wr_date"
                });

                Columns.Add(new DatabaseColumn("wr_end", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "wr_end"
                });

                Columns.Add(new DatabaseColumn("begin_time", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "begin_time"
                });

                Columns.Add(new DatabaseColumn("end_time", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "end_time"
                });

                Columns.Add(new DatabaseColumn("wr_rate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "wr_rate"
                });

                Columns.Add(new DatabaseColumn("wr_kind", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "wr_kind"
                });

                Columns.Add(new DatabaseColumn("alway_use", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "alway_use"
                });

                Columns.Add(new DatabaseColumn("have_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "have_hrs"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn wr_code{
                get{
                    return this.GetColumn("wr_code");
                }
            }
				
            
            public IColumn wr_name{
                get{
                    return this.GetColumn("wr_name");
                }
            }
				
            
            public IColumn wr_date{
                get{
                    return this.GetColumn("wr_date");
                }
            }
				
            
            public IColumn wr_end{
                get{
                    return this.GetColumn("wr_end");
                }
            }
				
            
            public IColumn begin_time{
                get{
                    return this.GetColumn("begin_time");
                }
            }
				
            
            public IColumn end_time{
                get{
                    return this.GetColumn("end_time");
                }
            }
				
            
            public IColumn wr_rate{
                get{
                    return this.GetColumn("wr_rate");
                }
            }
				
            
            public IColumn wr_kind{
                get{
                    return this.GetColumn("wr_kind");
                }
            }
				
            
            public IColumn alway_use{
                get{
                    return this.GetColumn("alway_use");
                }
            }
				
            
            public IColumn have_hrs{
                get{
                    return this.GetColumn("have_hrs");
                }
            }
				
            
                    
        }
        
}
