 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MAIN_LIST
        /// Primary Key: NODE
        /// </summary>

        public class MAIN_LISTStructs: DatabaseTable {
            
            public MAIN_LISTStructs(IDataProvider provider):base("MAIN_LIST",provider){
                ClassName = "MAIN_LIST";
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

                Columns.Add(new DatabaseColumn("PARENTNODE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PARENTNODE"
                });

                Columns.Add(new DatabaseColumn("NODE", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "NODE"
                });

                Columns.Add(new DatabaseColumn("DISPLAYTEXT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "DISPLAYTEXT"
                });

                Columns.Add(new DatabaseColumn("TABTEXT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TABTEXT"
                });

                Columns.Add(new DatabaseColumn("CLASSNAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "CLASSNAME"
                });

                Columns.Add(new DatabaseColumn("STATICCLASS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STATICCLASS"
                });

                Columns.Add(new DatabaseColumn("SORTORDER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SORTORDER"
                });

                Columns.Add(new DatabaseColumn("PICTUREINDEX", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "PICTUREINDEX"
                });

                Columns.Add(new DatabaseColumn("SELECTEDPICTUREINDEX", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "SELECTEDPICTUREINDEX"
                });

                Columns.Add(new DatabaseColumn("EXPANDED", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EXPANDED"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn PARENTNODE{
                get{
                    return this.GetColumn("PARENTNODE");
                }
            }
				
            
            public IColumn NODE{
                get{
                    return this.GetColumn("NODE");
                }
            }
				
            
            public IColumn DISPLAYTEXT{
                get{
                    return this.GetColumn("DISPLAYTEXT");
                }
            }
				
            
            public IColumn TABTEXT{
                get{
                    return this.GetColumn("TABTEXT");
                }
            }
				
            
            public IColumn CLASSNAME{
                get{
                    return this.GetColumn("CLASSNAME");
                }
            }
				
            
            public IColumn STATICCLASS{
                get{
                    return this.GetColumn("STATICCLASS");
                }
            }
				
            
            public IColumn SORTORDER{
                get{
                    return this.GetColumn("SORTORDER");
                }
            }
				
            
            public IColumn PICTUREINDEX{
                get{
                    return this.GetColumn("PICTUREINDEX");
                }
            }
				
            
            public IColumn SELECTEDPICTUREINDEX{
                get{
                    return this.GetColumn("SELECTEDPICTUREINDEX");
                }
            }
				
            
            public IColumn EXPANDED{
                get{
                    return this.GetColumn("EXPANDED");
                }
            }
				
            
                    
        }
        
}
