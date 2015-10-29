 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: RoomMoment
        /// Primary Key: Id
        /// </summary>

        public class RoomMomentStructs: DatabaseTable {
            
            public RoomMomentStructs(IDataProvider provider):base("RoomMoment",provider){
                ClassName = "RoomMoment";
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

                Columns.Add(new DatabaseColumn("MeetingRoom_Code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "MeetingRoom_Code"
                });

                Columns.Add(new DatabaseColumn("MeetingRoom_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "MeetingRoom_Name"
                });

                Columns.Add(new DatabaseColumn("RoomDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "RoomDate"
                });

                Columns.Add(new DatabaseColumn("T0830", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T0830"
                });

                Columns.Add(new DatabaseColumn("T0900", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T0900"
                });

                Columns.Add(new DatabaseColumn("T0930", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T0930"
                });

                Columns.Add(new DatabaseColumn("T1000", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1000"
                });

                Columns.Add(new DatabaseColumn("T1030", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1030"
                });

                Columns.Add(new DatabaseColumn("T1100", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1100"
                });

                Columns.Add(new DatabaseColumn("T1130", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1130"
                });

                Columns.Add(new DatabaseColumn("T1200", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1200"
                });

                Columns.Add(new DatabaseColumn("T1230", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1230"
                });

                Columns.Add(new DatabaseColumn("T1300", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1300"
                });

                Columns.Add(new DatabaseColumn("T1330", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1330"
                });

                Columns.Add(new DatabaseColumn("T1400", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1400"
                });

                Columns.Add(new DatabaseColumn("T1430", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1430"
                });

                Columns.Add(new DatabaseColumn("T1500", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1500"
                });

                Columns.Add(new DatabaseColumn("T1530", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1530"
                });

                Columns.Add(new DatabaseColumn("T1600", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1600"
                });

                Columns.Add(new DatabaseColumn("T1630", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1630"
                });

                Columns.Add(new DatabaseColumn("T1700", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1700"
                });

                Columns.Add(new DatabaseColumn("T1730", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1730"
                });

                Columns.Add(new DatabaseColumn("T1800", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1800"
                });

                Columns.Add(new DatabaseColumn("T1830", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1830"
                });

                Columns.Add(new DatabaseColumn("T1900", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1900"
                });

                Columns.Add(new DatabaseColumn("T1930", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T1930"
                });

                Columns.Add(new DatabaseColumn("T2000", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T2000"
                });

                Columns.Add(new DatabaseColumn("T2030", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T2030"
                });

                Columns.Add(new DatabaseColumn("T2100", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T2100"
                });

                Columns.Add(new DatabaseColumn("T2130", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T2130"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn MeetingRoom_Code{
                get{
                    return this.GetColumn("MeetingRoom_Code");
                }
            }
				
            
            public IColumn MeetingRoom_Name{
                get{
                    return this.GetColumn("MeetingRoom_Name");
                }
            }
				
            
            public IColumn RoomDate{
                get{
                    return this.GetColumn("RoomDate");
                }
            }
				
            
            public IColumn T0830{
                get{
                    return this.GetColumn("T0830");
                }
            }
				
            
            public IColumn T0900{
                get{
                    return this.GetColumn("T0900");
                }
            }
				
            
            public IColumn T0930{
                get{
                    return this.GetColumn("T0930");
                }
            }
				
            
            public IColumn T1000{
                get{
                    return this.GetColumn("T1000");
                }
            }
				
            
            public IColumn T1030{
                get{
                    return this.GetColumn("T1030");
                }
            }
				
            
            public IColumn T1100{
                get{
                    return this.GetColumn("T1100");
                }
            }
				
            
            public IColumn T1130{
                get{
                    return this.GetColumn("T1130");
                }
            }
				
            
            public IColumn T1200{
                get{
                    return this.GetColumn("T1200");
                }
            }
				
            
            public IColumn T1230{
                get{
                    return this.GetColumn("T1230");
                }
            }
				
            
            public IColumn T1300{
                get{
                    return this.GetColumn("T1300");
                }
            }
				
            
            public IColumn T1330{
                get{
                    return this.GetColumn("T1330");
                }
            }
				
            
            public IColumn T1400{
                get{
                    return this.GetColumn("T1400");
                }
            }
				
            
            public IColumn T1430{
                get{
                    return this.GetColumn("T1430");
                }
            }
				
            
            public IColumn T1500{
                get{
                    return this.GetColumn("T1500");
                }
            }
				
            
            public IColumn T1530{
                get{
                    return this.GetColumn("T1530");
                }
            }
				
            
            public IColumn T1600{
                get{
                    return this.GetColumn("T1600");
                }
            }
				
            
            public IColumn T1630{
                get{
                    return this.GetColumn("T1630");
                }
            }
				
            
            public IColumn T1700{
                get{
                    return this.GetColumn("T1700");
                }
            }
				
            
            public IColumn T1730{
                get{
                    return this.GetColumn("T1730");
                }
            }
				
            
            public IColumn T1800{
                get{
                    return this.GetColumn("T1800");
                }
            }
				
            
            public IColumn T1830{
                get{
                    return this.GetColumn("T1830");
                }
            }
				
            
            public IColumn T1900{
                get{
                    return this.GetColumn("T1900");
                }
            }
				
            
            public IColumn T1930{
                get{
                    return this.GetColumn("T1930");
                }
            }
				
            
            public IColumn T2000{
                get{
                    return this.GetColumn("T2000");
                }
            }
				
            
            public IColumn T2030{
                get{
                    return this.GetColumn("T2030");
                }
            }
				
            
            public IColumn T2100{
                get{
                    return this.GetColumn("T2100");
                }
            }
				
            
            public IColumn T2130{
                get{
                    return this.GetColumn("T2130");
                }
            }
				
            
                    
        }
        
}
