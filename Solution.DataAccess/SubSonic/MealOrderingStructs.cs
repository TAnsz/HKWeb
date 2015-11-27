 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: MealOrdering
        /// Primary Key: Id
        /// </summary>

        public class MealOrderingStructs: DatabaseTable {
            
            public MealOrderingStructs(IDataProvider provider):base("MealOrdering",provider){
                ClassName = "MealOrdering";
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

                Columns.Add(new DatabaseColumn("Employee_EmpId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "Employee_EmpId"
                });

                Columns.Add(new DatabaseColumn("Employee_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Employee_Name"
                });

                Columns.Add(new DatabaseColumn("DepartId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "DepartId"
                });

                Columns.Add(new DatabaseColumn("DepartName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "DepartName"
                });

                Columns.Add(new DatabaseColumn("FoodCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "FoodCode"
                });

                Columns.Add(new DatabaseColumn("DrinkCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "DrinkCode"
                });

                Columns.Add(new DatabaseColumn("ApplyDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ApplyDate"
                });

                Columns.Add(new DatabaseColumn("RecordId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "RecordId"
                });

                Columns.Add(new DatabaseColumn("RecordName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "RecordName"
                });

                Columns.Add(new DatabaseColumn("RecordDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "RecordDate"
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

                Columns.Add(new DatabaseColumn("ModifyDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ModifyDate"
                });

                Columns.Add(new DatabaseColumn("ModifyId", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "ModifyId"
                });

                Columns.Add(new DatabaseColumn("ModifyBy", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "ModifyBy"
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
				
            
            public IColumn Employee_EmpId{
                get{
                    return this.GetColumn("Employee_EmpId");
                }
            }
				
            
            public IColumn Employee_Name{
                get{
                    return this.GetColumn("Employee_Name");
                }
            }
				
            
            public IColumn DepartId{
                get{
                    return this.GetColumn("DepartId");
                }
            }
				
            
            public IColumn DepartName{
                get{
                    return this.GetColumn("DepartName");
                }
            }
				
            
            public IColumn FoodCode{
                get{
                    return this.GetColumn("FoodCode");
                }
            }
				
            
            public IColumn DrinkCode{
                get{
                    return this.GetColumn("DrinkCode");
                }
            }
				
            
            public IColumn ApplyDate{
                get{
                    return this.GetColumn("ApplyDate");
                }
            }
				
            
            public IColumn RecordId{
                get{
                    return this.GetColumn("RecordId");
                }
            }
				
            
            public IColumn RecordName{
                get{
                    return this.GetColumn("RecordName");
                }
            }
				
            
            public IColumn RecordDate{
                get{
                    return this.GetColumn("RecordDate");
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
				
            
            public IColumn ModifyDate{
                get{
                    return this.GetColumn("ModifyDate");
                }
            }
				
            
            public IColumn ModifyId{
                get{
                    return this.GetColumn("ModifyId");
                }
            }
				
            
            public IColumn ModifyBy{
                get{
                    return this.GetColumn("ModifyBy");
                }
            }
				
            
                    
        }
        
}
