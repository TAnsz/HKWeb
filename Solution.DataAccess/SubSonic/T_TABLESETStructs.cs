 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: T_TABLESET
        /// Primary Key: CODE
        /// </summary>

        public class T_TABLESETStructs: DatabaseTable {
            
            public T_TABLESETStructs(IDataProvider provider):base("T_TABLESET",provider){
                ClassName = "T_TABLESET";
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

                Columns.Add(new DatabaseColumn("CODE", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4,
					PropertyName = "CODE"
                });

                Columns.Add(new DatabaseColumn("NAMEE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "NAMEE"
                });

                Columns.Add(new DatabaseColumn("NAMEC", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "NAMEC"
                });

                Columns.Add(new DatabaseColumn("DATAEA", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DATAEA"
                });

                Columns.Add(new DatabaseColumn("NOTES", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
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

                Columns.Add(new DatabaseColumn("STATURS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1,
					PropertyName = "STATURS"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn CODE{
                get{
                    return this.GetColumn("CODE");
                }
            }
				
            
            public IColumn NAMEE{
                get{
                    return this.GetColumn("NAMEE");
                }
            }
				
            
            public IColumn NAMEC{
                get{
                    return this.GetColumn("NAMEC");
                }
            }
				
            
            public IColumn DATAEA{
                get{
                    return this.GetColumn("DATAEA");
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
				
            
            public IColumn SYSDIV{
                get{
                    return this.GetColumn("SYSDIV");
                }
            }
				
            
            public IColumn STATURS{
                get{
                    return this.GetColumn("STATURS");
                }
            }
				
            
                    
        }
        
}
