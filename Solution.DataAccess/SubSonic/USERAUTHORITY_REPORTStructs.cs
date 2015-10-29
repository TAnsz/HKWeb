 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: USERAUTHORITY_REPORT
        /// Primary Key: Id
        /// </summary>

        public class USERAUTHORITY_REPORTStructs: DatabaseTable {
            
            public USERAUTHORITY_REPORTStructs(IDataProvider provider):base("USERAUTHORITY_REPORT",provider){
                ClassName = "USERAUTHORITY_REPORT";
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

                Columns.Add(new DatabaseColumn("emp_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
					PropertyName = "emp_id"
                });

                Columns.Add(new DatabaseColumn("node_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
					PropertyName = "node_id"
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
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn emp_id{
                get{
                    return this.GetColumn("emp_id");
                }
            }
				
            
            public IColumn node_id{
                get{
                    return this.GetColumn("node_id");
                }
            }
				
            
            public IColumn TYPE{
                get{
                    return this.GetColumn("TYPE");
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
				
            
                    
        }
        
}
