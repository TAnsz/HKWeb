 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: TOOL_LIST
        /// Primary Key: Id
        /// </summary>

        public class TOOL_LISTStructs: DatabaseTable {
            
            public TOOL_LISTStructs(IDataProvider provider):base("TOOL_LIST",provider){
                ClassName = "TOOL_LIST";
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

                Columns.Add(new DatabaseColumn("TOOL_NO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TOOL_NO"
                });

                Columns.Add(new DatabaseColumn("TEXT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TEXT"
                });

                Columns.Add(new DatabaseColumn("TOOLTIP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TOOLTIP"
                });

                Columns.Add(new DatabaseColumn("IMAGE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "IMAGE"
                });

                Columns.Add(new DatabaseColumn("DIVIDER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DIVIDER"
                });

                Columns.Add(new DatabaseColumn("DISABLED", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DISABLED"
                });

                Columns.Add(new DatabaseColumn("DROPDOWN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DROPDOWN"
                });

                Columns.Add(new DatabaseColumn("DROPWHOLE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "DROPWHOLE"
                });

                Columns.Add(new DatabaseColumn("TAGDATA", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TAGDATA"
                });

                Columns.Add(new DatabaseColumn("SORT_ORDER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SORT_ORDER"
                });

                Columns.Add(new DatabaseColumn("DWOBJECT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "DWOBJECT"
                });

                Columns.Add(new DatabaseColumn("GROUPNO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "GROUPNO"
                });

                Columns.Add(new DatabaseColumn("GROUPNAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "GROUPNAME"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn TOOL_NO{
                get{
                    return this.GetColumn("TOOL_NO");
                }
            }
				
            
            public IColumn TEXT{
                get{
                    return this.GetColumn("TEXT");
                }
            }
				
            
            public IColumn TOOLTIP{
                get{
                    return this.GetColumn("TOOLTIP");
                }
            }
				
            
            public IColumn IMAGE{
                get{
                    return this.GetColumn("IMAGE");
                }
            }
				
            
            public IColumn DIVIDER{
                get{
                    return this.GetColumn("DIVIDER");
                }
            }
				
            
            public IColumn DISABLED{
                get{
                    return this.GetColumn("DISABLED");
                }
            }
				
            
            public IColumn DROPDOWN{
                get{
                    return this.GetColumn("DROPDOWN");
                }
            }
				
            
            public IColumn DROPWHOLE{
                get{
                    return this.GetColumn("DROPWHOLE");
                }
            }
				
            
            public IColumn TAGDATA{
                get{
                    return this.GetColumn("TAGDATA");
                }
            }
				
            
            public IColumn SORT_ORDER{
                get{
                    return this.GetColumn("SORT_ORDER");
                }
            }
				
            
            public IColumn DWOBJECT{
                get{
                    return this.GetColumn("DWOBJECT");
                }
            }
				
            
            public IColumn GROUPNO{
                get{
                    return this.GetColumn("GROUPNO");
                }
            }
				
            
            public IColumn GROUPNAME{
                get{
                    return this.GetColumn("GROUPNAME");
                }
            }
				
            
                    
        }
        
}
