 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: OutWork_D
        /// Primary Key: Id
        /// </summary>

        public class OutWork_DStructs: DatabaseTable {
            
            public OutWork_DStructs(IDataProvider provider):base("OutWork_D",provider){
                ClassName = "OutWork_D";
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

                Columns.Add(new DatabaseColumn("bill_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "bill_id"
                });

                Columns.Add(new DatabaseColumn("emp_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 12,
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

                Columns.Add(new DatabaseColumn("bill_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "bill_date"
                });

                Columns.Add(new DatabaseColumn("begin_time", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "begin_time"
                });

                Columns.Add(new DatabaseColumn("end_time", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "end_time"
                });

                Columns.Add(new DatabaseColumn("work_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "work_type"
                });

                Columns.Add(new DatabaseColumn("work_days", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "work_days"
                });

                Columns.Add(new DatabaseColumn("status_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "status_id"
                });

                Columns.Add(new DatabaseColumn("leave_id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "leave_id"
                });

                Columns.Add(new DatabaseColumn("rate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "rate"
                });

                Columns.Add(new DatabaseColumn("checker", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 16,
					PropertyName = "checker"
                });

                Columns.Add(new DatabaseColumn("check_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "check_date"
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

                Columns.Add(new DatabaseColumn("memo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "memo"
                });

                Columns.Add(new DatabaseColumn("outwork_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "outwork_type"
                });

                Columns.Add(new DatabaseColumn("outwork_addr", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "outwork_addr"
                });

                Columns.Add(new DatabaseColumn("transportation", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "transportation"
                });

                Columns.Add(new DatabaseColumn("Re_date", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Re_date"
                });

                Columns.Add(new DatabaseColumn("Start_ag", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Start_ag"
                });

                Columns.Add(new DatabaseColumn("re_ag", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "re_ag"
                });

                Columns.Add(new DatabaseColumn("peers", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "peers"
                });

                Columns.Add(new DatabaseColumn("Hostel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Hostel"
                });

                Columns.Add(new DatabaseColumn("hotel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "hotel"
                });

                Columns.Add(new DatabaseColumn("hotel_type", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "hotel_type"
                });

                Columns.Add(new DatabaseColumn("reply", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "reply"
                });

                Columns.Add(new DatabaseColumn("work_hrs", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "work_hrs"
                });

                Columns.Add(new DatabaseColumn("is_input", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "is_input"
                });

                Columns.Add(new DatabaseColumn("refuse_reason", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "refuse_reason"
                });

                Columns.Add(new DatabaseColumn("CHECKER2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "CHECKER2"
                });

                Columns.Add(new DatabaseColumn("audit2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "audit2"
                });

                Columns.Add(new DatabaseColumn("IsHotel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsHotel"
                });

                Columns.Add(new DatabaseColumn("IsCar", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "IsCar"
                });

                Columns.Add(new DatabaseColumn("Itinerary", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Itinerary"
                });

                Columns.Add(new DatabaseColumn("Destination", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Destination"
                });

                Columns.Add(new DatabaseColumn("IDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "IDate"
                });

                Columns.Add(new DatabaseColumn("Nights", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Nights"
                });

                Columns.Add(new DatabaseColumn("reply2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "reply2"
                });

                Columns.Add(new DatabaseColumn("itinerary2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "itinerary2"
                });

                Columns.Add(new DatabaseColumn("itinerary3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "itinerary3"
                });

                Columns.Add(new DatabaseColumn("itinerary4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "itinerary4"
                });

                Columns.Add(new DatabaseColumn("IDate2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "IDate2"
                });

                Columns.Add(new DatabaseColumn("IDate3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "IDate3"
                });

                Columns.Add(new DatabaseColumn("IDate4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "IDate4"
                });

                Columns.Add(new DatabaseColumn("Destination2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Destination2"
                });

                Columns.Add(new DatabaseColumn("Destination3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Destination3"
                });

                Columns.Add(new DatabaseColumn("Destination4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Destination4"
                });

                Columns.Add(new DatabaseColumn("Nights2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Nights2"
                });

                Columns.Add(new DatabaseColumn("Nights3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Nights3"
                });

                Columns.Add(new DatabaseColumn("Nights4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "Nights4"
                });

                Columns.Add(new DatabaseColumn("check_date2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "check_date2"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn bill_id{
                get{
                    return this.GetColumn("bill_id");
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
				
            
            public IColumn bill_date{
                get{
                    return this.GetColumn("bill_date");
                }
            }
				
            
            public IColumn begin_time{
                get{
                    return this.GetColumn("begin_time");
                }
            }
				
            
            public IColumn end_time{
                get{
                    return this.GetColumn("end_time");
                }
            }
				
            
            public IColumn work_type{
                get{
                    return this.GetColumn("work_type");
                }
            }
				
            
            public IColumn work_days{
                get{
                    return this.GetColumn("work_days");
                }
            }
				
            
            public IColumn status_id{
                get{
                    return this.GetColumn("status_id");
                }
            }
				
            
            public IColumn leave_id{
                get{
                    return this.GetColumn("leave_id");
                }
            }
				
            
            public IColumn rate{
                get{
                    return this.GetColumn("rate");
                }
            }
				
            
            public IColumn checker{
                get{
                    return this.GetColumn("checker");
                }
            }
				
            
            public IColumn check_date{
                get{
                    return this.GetColumn("check_date");
                }
            }
				
            
            public IColumn op_user{
                get{
                    return this.GetColumn("op_user");
                }
            }
				
            
            public IColumn op_date{
                get{
                    return this.GetColumn("op_date");
                }
            }
				
            
            public IColumn audit{
                get{
                    return this.GetColumn("audit");
                }
            }
				
            
            public IColumn memo{
                get{
                    return this.GetColumn("memo");
                }
            }
				
            
            public IColumn outwork_type{
                get{
                    return this.GetColumn("outwork_type");
                }
            }
				
            
            public IColumn outwork_addr{
                get{
                    return this.GetColumn("outwork_addr");
                }
            }
				
            
            public IColumn transportation{
                get{
                    return this.GetColumn("transportation");
                }
            }
				
            
            public IColumn Re_date{
                get{
                    return this.GetColumn("Re_date");
                }
            }
				
            
            public IColumn Start_ag{
                get{
                    return this.GetColumn("Start_ag");
                }
            }
				
            
            public IColumn re_ag{
                get{
                    return this.GetColumn("re_ag");
                }
            }
				
            
            public IColumn peers{
                get{
                    return this.GetColumn("peers");
                }
            }
				
            
            public IColumn Hostel{
                get{
                    return this.GetColumn("Hostel");
                }
            }
				
            
            public IColumn hotel{
                get{
                    return this.GetColumn("hotel");
                }
            }
				
            
            public IColumn hotel_type{
                get{
                    return this.GetColumn("hotel_type");
                }
            }
				
            
            public IColumn reply{
                get{
                    return this.GetColumn("reply");
                }
            }
				
            
            public IColumn work_hrs{
                get{
                    return this.GetColumn("work_hrs");
                }
            }
				
            
            public IColumn is_input{
                get{
                    return this.GetColumn("is_input");
                }
            }
				
            
            public IColumn refuse_reason{
                get{
                    return this.GetColumn("refuse_reason");
                }
            }
				
            
            public IColumn CHECKER2{
                get{
                    return this.GetColumn("CHECKER2");
                }
            }
				
            
            public IColumn audit2{
                get{
                    return this.GetColumn("audit2");
                }
            }
				
            
            public IColumn IsHotel{
                get{
                    return this.GetColumn("IsHotel");
                }
            }
				
            
            public IColumn IsCar{
                get{
                    return this.GetColumn("IsCar");
                }
            }
				
            
            public IColumn Itinerary{
                get{
                    return this.GetColumn("Itinerary");
                }
            }
				
            
            public IColumn Destination{
                get{
                    return this.GetColumn("Destination");
                }
            }
				
            
            public IColumn IDate{
                get{
                    return this.GetColumn("IDate");
                }
            }
				
            
            public IColumn Nights{
                get{
                    return this.GetColumn("Nights");
                }
            }
				
            
            public IColumn reply2{
                get{
                    return this.GetColumn("reply2");
                }
            }
				
            
            public IColumn itinerary2{
                get{
                    return this.GetColumn("itinerary2");
                }
            }
				
            
            public IColumn itinerary3{
                get{
                    return this.GetColumn("itinerary3");
                }
            }
				
            
            public IColumn itinerary4{
                get{
                    return this.GetColumn("itinerary4");
                }
            }
				
            
            public IColumn IDate2{
                get{
                    return this.GetColumn("IDate2");
                }
            }
				
            
            public IColumn IDate3{
                get{
                    return this.GetColumn("IDate3");
                }
            }
				
            
            public IColumn IDate4{
                get{
                    return this.GetColumn("IDate4");
                }
            }
				
            
            public IColumn Destination2{
                get{
                    return this.GetColumn("Destination2");
                }
            }
				
            
            public IColumn Destination3{
                get{
                    return this.GetColumn("Destination3");
                }
            }
				
            
            public IColumn Destination4{
                get{
                    return this.GetColumn("Destination4");
                }
            }
				
            
            public IColumn Nights2{
                get{
                    return this.GetColumn("Nights2");
                }
            }
				
            
            public IColumn Nights3{
                get{
                    return this.GetColumn("Nights3");
                }
            }
				
            
            public IColumn Nights4{
                get{
                    return this.GetColumn("Nights4");
                }
            }
				
            
            public IColumn check_date2{
                get{
                    return this.GetColumn("check_date2");
                }
            }
				
            
                    
        }
        
}
