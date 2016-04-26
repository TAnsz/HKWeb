 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Machine
        /// Primary Key: Id
        /// </summary>

        public class MachineStructs: DatabaseTable {
            
            public MachineStructs(IDataProvider provider):base("Machine",provider){
                ClassName = "Machine";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "name"
                });

                Columns.Add(new DatabaseColumn("content", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "content"
                });

                Columns.Add(new DatabaseColumn("spec", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "spec"
                });

                Columns.Add(new DatabaseColumn("ip", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "ip"
                });

                Columns.Add(new DatabaseColumn("port", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "port"
                });

                Columns.Add(new DatabaseColumn("isvaild", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "isvaild"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn name{
                get{
                    return this.GetColumn("name");
                }
            }
				
            
            public IColumn content{
                get{
                    return this.GetColumn("content");
                }
            }
				
            
            public IColumn spec{
                get{
                    return this.GetColumn("spec");
                }
            }
				
            
            public IColumn ip{
                get{
                    return this.GetColumn("ip");
                }
            }
				
            
            public IColumn port{
                get{
                    return this.GetColumn("port");
                }
            }
				
            
            public IColumn isvaild{
                get{
                    return this.GetColumn("isvaild");
                }
            }
				
            
                    
        }
        
}
