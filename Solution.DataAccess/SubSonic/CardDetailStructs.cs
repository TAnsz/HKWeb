 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: CardDetail
        /// Primary Key: Id
        /// </summary>

        public class CardDetailStructs: DatabaseTable {
            
            public CardDetailStructs(IDataProvider provider):base("CardDetail",provider){
                ClassName = "CardDetail";
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
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "emp_id"
                });

                Columns.Add(new DatabaseColumn("join_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "join_id"
                });

                Columns.Add(new DatabaseColumn("depart_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "depart_id"
                });

                Columns.Add(new DatabaseColumn("card_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "card_id"
                });

                Columns.Add(new DatabaseColumn("kind", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "kind"
                });

                Columns.Add(new DatabaseColumn("use_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "use_date"
                });

                Columns.Add(new DatabaseColumn("Invalid_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Invalid_date"
                });

                Columns.Add(new DatabaseColumn("isbuban", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "isbuban"
                });

                Columns.Add(new DatabaseColumn("isunloss", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "isunloss"
                });

                Columns.Add(new DatabaseColumn("card_sn", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "card_sn"
                });

                Columns.Add(new DatabaseColumn("old_card_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "old_card_id"
                });

                Columns.Add(new DatabaseColumn("audit", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "audit"
                });

                Columns.Add(new DatabaseColumn("remark", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "remark"
                });

                Columns.Add(new DatabaseColumn("op_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "op_date"
                });

                Columns.Add(new DatabaseColumn("op_user", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "op_user"
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
				
            
            public IColumn join_id{
                get{
                    return this.GetColumn("join_id");
                }
            }
				
            
            public IColumn depart_id{
                get{
                    return this.GetColumn("depart_id");
                }
            }
				
            
            public IColumn card_id{
                get{
                    return this.GetColumn("card_id");
                }
            }
				
            
            public IColumn kind{
                get{
                    return this.GetColumn("kind");
                }
            }
				
            
            public IColumn use_date{
                get{
                    return this.GetColumn("use_date");
                }
            }
				
            
            public IColumn Invalid_date{
                get{
                    return this.GetColumn("Invalid_date");
                }
            }
				
            
            public IColumn isbuban{
                get{
                    return this.GetColumn("isbuban");
                }
            }
				
            
            public IColumn isunloss{
                get{
                    return this.GetColumn("isunloss");
                }
            }
				
            
            public IColumn card_sn{
                get{
                    return this.GetColumn("card_sn");
                }
            }
				
            
            public IColumn old_card_id{
                get{
                    return this.GetColumn("old_card_id");
                }
            }
				
            
            public IColumn audit{
                get{
                    return this.GetColumn("audit");
                }
            }
				
            
            public IColumn remark{
                get{
                    return this.GetColumn("remark");
                }
            }
				
            
            public IColumn op_date{
                get{
                    return this.GetColumn("op_date");
                }
            }
				
            
            public IColumn op_user{
                get{
                    return this.GetColumn("op_user");
                }
            }
				
            
                    
        }
        
}
