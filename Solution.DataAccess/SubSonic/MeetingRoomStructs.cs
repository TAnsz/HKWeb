 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MeetingRoom
        /// Primary Key: Id
        /// </summary>

        public class MeetingRoomStructs: DatabaseTable {
            
            public MeetingRoomStructs(IDataProvider provider):base("MeetingRoom",provider){
                ClassName = "MeetingRoom";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("Code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "Code"
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Name"
                });

                Columns.Add(new DatabaseColumn("Qty", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Qty"
                });

                Columns.Add(new DatabaseColumn("Address", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Address"
                });

                Columns.Add(new DatabaseColumn("Remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500,
					PropertyName = "Remark"
                });

                Columns.Add(new DatabaseColumn("IsVaild", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsVaild"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn Code{
                get{
                    return this.GetColumn("Code");
                }
            }
				
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
            
            public IColumn Qty{
                get{
                    return this.GetColumn("Qty");
                }
            }
				
            
            public IColumn Address{
                get{
                    return this.GetColumn("Address");
                }
            }
				
            
            public IColumn Remark{
                get{
                    return this.GetColumn("Remark");
                }
            }
				
            
            public IColumn IsVaild{
                get{
                    return this.GetColumn("IsVaild");
                }
            }
				
            
                    
        }
        
}
