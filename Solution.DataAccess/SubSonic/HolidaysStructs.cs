 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Holidays
        /// Primary Key: Id
        /// </summary>

        public class HolidaysStructs: DatabaseTable {
            
            public HolidaysStructs(IDataProvider provider):base("Holidays",provider){
                ClassName = "Holidays";
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

                Columns.Add(new DatabaseColumn("hd_code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "hd_code"
                });

                Columns.Add(new DatabaseColumn("hd_name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "hd_name"
                });

                Columns.Add(new DatabaseColumn("hd_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hd_date"
                });

                Columns.Add(new DatabaseColumn("hd_end", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hd_end"
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

                Columns.Add(new DatabaseColumn("hd_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "hd_type"
                });

                Columns.Add(new DatabaseColumn("hd_kind", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hd_kind"
                });

                Columns.Add(new DatabaseColumn("depart_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "depart_id"
                });

                Columns.Add(new DatabaseColumn("alway_use", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "alway_use"
                });

                Columns.Add(new DatabaseColumn("sub_depart", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "sub_depart"
                });

                Columns.Add(new DatabaseColumn("need_write", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "need_write"
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

                Columns.Add(new DatabaseColumn("memo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "memo"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn hd_code{
                get{
                    return this.GetColumn("hd_code");
                }
            }
				
            
            public IColumn hd_name{
                get{
                    return this.GetColumn("hd_name");
                }
            }
				
            
            public IColumn hd_date{
                get{
                    return this.GetColumn("hd_date");
                }
            }
				
            
            public IColumn hd_end{
                get{
                    return this.GetColumn("hd_end");
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
				
            
            public IColumn hd_rate{
                get{
                    return this.GetColumn("hd_rate");
                }
            }
				
            
            public IColumn hd_type{
                get{
                    return this.GetColumn("hd_type");
                }
            }
				
            
            public IColumn hd_kind{
                get{
                    return this.GetColumn("hd_kind");
                }
            }
				
            
            public IColumn depart_id{
                get{
                    return this.GetColumn("depart_id");
                }
            }
				
            
            public IColumn alway_use{
                get{
                    return this.GetColumn("alway_use");
                }
            }
				
            
            public IColumn sub_depart{
                get{
                    return this.GetColumn("sub_depart");
                }
            }
				
            
            public IColumn need_write{
                get{
                    return this.GetColumn("need_write");
                }
            }
				
            
            public IColumn have_hrs{
                get{
                    return this.GetColumn("have_hrs");
                }
            }
				
            
            public IColumn memo{
                get{
                    return this.GetColumn("memo");
                }
            }
				
            
                    
        }
        
}
