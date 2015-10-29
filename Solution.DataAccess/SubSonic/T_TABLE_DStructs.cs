 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: T_TABLE_D
        /// Primary Key: Id
        /// </summary>

        public class T_TABLE_DStructs: DatabaseTable {
            
            public T_TABLE_DStructs(IDataProvider provider):base("T_TABLE_D",provider){
                ClassName = "T_TABLE_D";
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

                Columns.Add(new DatabaseColumn("TABLES", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4,
					PropertyName = "TABLES"
                });

                Columns.Add(new DatabaseColumn("CODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "CODE"
                });

                Columns.Add(new DatabaseColumn("DESCR", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "DESCR"
                });

                Columns.Add(new DatabaseColumn("DATA", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "DATA"
                });

                Columns.Add(new DatabaseColumn("TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "TYPE"
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

                Columns.Add(new DatabaseColumn("DATAC", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DATAC"
                });

                Columns.Add(new DatabaseColumn("NOTES", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "NOTES"
                });

                Columns.Add(new DatabaseColumn("RECORD_BY", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "RECORD_BY"
                });

                Columns.Add(new DatabaseColumn("RECORD_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "RECORD_DATE"
                });

                Columns.Add(new DatabaseColumn("SYSDIV", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2,
					PropertyName = "SYSDIV"
                });

                Columns.Add(new DatabaseColumn("DATAD1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DATAD1"
                });

                Columns.Add(new DatabaseColumn("DATAD2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DATAD2"
                });

                Columns.Add(new DatabaseColumn("DATAD3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DATAD3"
                });

                Columns.Add(new DatabaseColumn("DATAD4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DATAD4"
                });

                Columns.Add(new DatabaseColumn("DATAD5", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DATAD5"
                });

                Columns.Add(new DatabaseColumn("DATAD6", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DATAD6"
                });

                Columns.Add(new DatabaseColumn("DATAD7", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DATAD7"
                });

                Columns.Add(new DatabaseColumn("DATAD8", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DATAD8"
                });

                Columns.Add(new DatabaseColumn("EDIT_BY", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "EDIT_BY"
                });

                Columns.Add(new DatabaseColumn("EDIT_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EDIT_DATE"
                });

                Columns.Add(new DatabaseColumn("PagePower", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823,
					PropertyName = "PagePower"
                });

                Columns.Add(new DatabaseColumn("ControlPower", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823,
					PropertyName = "ControlPower"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn TABLES{
                get{
                    return this.GetColumn("TABLES");
                }
            }
				
            
            public IColumn CODE{
                get{
                    return this.GetColumn("CODE");
                }
            }
				
            
            public IColumn DESCR{
                get{
                    return this.GetColumn("DESCR");
                }
            }
				
            
            public IColumn DATA{
                get{
                    return this.GetColumn("DATA");
                }
            }
				
            
            public IColumn TYPE{
                get{
                    return this.GetColumn("TYPE");
                }
            }
				
            
            public IColumn GROUPS{
                get{
                    return this.GetColumn("GROUPS");
                }
            }
				
            
            public IColumn DATAC{
                get{
                    return this.GetColumn("DATAC");
                }
            }
				
            
            public IColumn NOTES{
                get{
                    return this.GetColumn("NOTES");
                }
            }
				
            
            public IColumn RECORD_BY{
                get{
                    return this.GetColumn("RECORD_BY");
                }
            }
				
            
            public IColumn RECORD_DATE{
                get{
                    return this.GetColumn("RECORD_DATE");
                }
            }
				
            
            public IColumn SYSDIV{
                get{
                    return this.GetColumn("SYSDIV");
                }
            }
				
            
            public IColumn DATAD1{
                get{
                    return this.GetColumn("DATAD1");
                }
            }
				
            
            public IColumn DATAD2{
                get{
                    return this.GetColumn("DATAD2");
                }
            }
				
            
            public IColumn DATAD3{
                get{
                    return this.GetColumn("DATAD3");
                }
            }
				
            
            public IColumn DATAD4{
                get{
                    return this.GetColumn("DATAD4");
                }
            }
				
            
            public IColumn DATAD5{
                get{
                    return this.GetColumn("DATAD5");
                }
            }
				
            
            public IColumn DATAD6{
                get{
                    return this.GetColumn("DATAD6");
                }
            }
				
            
            public IColumn DATAD7{
                get{
                    return this.GetColumn("DATAD7");
                }
            }
				
            
            public IColumn DATAD8{
                get{
                    return this.GetColumn("DATAD8");
                }
            }
				
            
            public IColumn EDIT_BY{
                get{
                    return this.GetColumn("EDIT_BY");
                }
            }
				
            
            public IColumn EDIT_DATE{
                get{
                    return this.GetColumn("EDIT_DATE");
                }
            }
				
            
            public IColumn PagePower{
                get{
                    return this.GetColumn("PagePower");
                }
            }
				
            
            public IColumn ControlPower{
                get{
                    return this.GetColumn("ControlPower");
                }
            }
				
            
                    
        }
        
}
