/// <summary>
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;

namespace Maticsoft.DBUtility
{
	/// <summary>
	/// 數據訪問基礎類(基於Oracle)
	/// 可以用戶可以修改滿足自己項目的需要。
	/// </summary>
	public abstract class DbHelperOra
	{
        //數據庫連接字符串(web.config來配置)，可以動態更改connectionString支持多數據庫.		
        public static string connectionString = "連接字符串"; 
		public DbHelperOra()
		{			
		}

        #region 公用方法
        
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params OracleParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        #endregion

		#region  執行簡單SQL語句

		/// <summary>
		/// 執行SQL語句，返回影響的記錄數
		/// </summary>
		/// <param name="SQLString">SQL語句</param>
		/// <returns>影響的記錄數</returns>
		public static int ExecuteSql(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{				
				using (OracleCommand cmd = new OracleCommand(SQLString,connection))
				{
					try
					{		
						connection.Open();
						int rows=cmd.ExecuteNonQuery();
						return rows;
					}
					catch(System.Data.OracleClient.OracleException E)
					{					
						connection.Close();
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
		/// <summary>
		/// 執行多條SQL語句，實現數據庫事務。
		/// </summary>
		/// <param name="SQLStringList">多條SQL語句</param>		
		public static void ExecuteSqlTran(ArrayList SQLStringList)
		{
			using (OracleConnection conn = new OracleConnection(connectionString))
			{
				conn.Open();
				OracleCommand cmd = new OracleCommand();
				cmd.Connection=conn;				
				OracleTransaction tx=conn.BeginTransaction();			
				cmd.Transaction=tx;				
				try
				{   		
					for(int n=0;n<SQLStringList.Count;n++)
					{
						string strsql=SQLStringList[n].ToString();
						if (strsql.Trim().Length>1)
						{
							cmd.CommandText=strsql;
							cmd.ExecuteNonQuery();
						}
					}										
					tx.Commit();					
				}
				catch(System.Data.OracleClient.OracleException E)
				{		
					tx.Rollback();
					throw new Exception(E.Message);
				}
			}
		}
		/// <summary>
		/// 執行帶一個存儲過程參數的的SQL語句。
		/// </summary>
		/// <param name="SQLString">SQL語句</param>
		/// <param name="content">參數內容,比如一個字段是格式複雜的文章，有特殊符號，可以通過這個方式添加</param>
		/// <returns>影響的記錄數</returns>
		public static int ExecuteSql(string SQLString,string content)
		{				
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand(SQLString,connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter("@content", OracleType.NVarChar);
				myParameter.Value = content ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.OracleClient.OracleException E)
				{				
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}	
			}
		}		
		/// <summary>
		/// 向數據庫裡插入圖像格式的字段(和上面情況類似的另一種實例)
		/// </summary>
		/// <param name="strSQL">SQL語句</param>
		/// <param name="fs">圖像字節,數據庫的字段類型為image的情況</param>
		/// <returns>影響的記錄數</returns>
		public static int ExecuteSqlInsertImg(string strSQL,byte[] fs)
		{		
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand(strSQL,connection);
                System.Data.OracleClient.OracleParameter myParameter = new System.Data.OracleClient.OracleParameter("@fs", OracleType.LongRaw);
				myParameter.Value = fs ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.OracleClient.OracleException E)
				{				
					throw new Exception(E.Message);
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}				
			}
		}
		
		/// <summary>
		/// 執行一條計算查詢結果語句，返回查詢結果（object）。
		/// </summary>
		/// <param name="SQLString">計算查詢結果語句</param>
		/// <returns>查詢結果（object）</returns>
		public static object GetSingle(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				using(OracleCommand cmd = new OracleCommand(SQLString,connection))
				{
					try
					{
						connection.Open();
						object obj = cmd.ExecuteScalar();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.OracleClient.OracleException e)
					{						
						connection.Close();
						throw new Exception(e.Message);
					}	
				}
			}
		}
		/// <summary>
        /// 執行查詢語句，返回OracleDataReader ( 注意：調用該方法後，一定要對SqlDataReader進行Close )
		/// </summary>
		/// <param name="strSQL">查詢語句</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader ExecuteReader(string strSQL)
		{
			OracleConnection connection = new OracleConnection(connectionString);			
			OracleCommand cmd = new OracleCommand(strSQL,connection);				
			try
			{
				connection.Open();
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException e)
			{								
				throw new Exception(e.Message);
			}			
			
		}		
		/// <summary>
		/// 執行查詢語句，返回DataSet
		/// </summary>
		/// <param name="SQLString">查詢語句</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				DataSet ds = new DataSet();
				try
				{
					connection.Open();
					OracleDataAdapter command = new OracleDataAdapter(SQLString,connection);				
					command.Fill(ds,"ds");
				}
				catch(System.Data.OracleClient.OracleException ex)
				{				
					throw new Exception(ex.Message);
				}			
				return ds;
			}			
		}


		#endregion

		#region 執行帶參數的SQL語句

		/// <summary>
		/// 執行SQL語句，返回影響的記錄數
		/// </summary>
		/// <param name="SQLString">SQL語句</param>
		/// <returns>影響的記錄數</returns>
		public static int ExecuteSql(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{				
				using (OracleCommand cmd = new OracleCommand())
				{
					try
					{		
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						int rows=cmd.ExecuteNonQuery();
						cmd.Parameters.Clear();
						return rows;
					}
					catch(System.Data.OracleClient.OracleException E)
					{				
						throw new Exception(E.Message);
					}
				}				
			}
		}
		
			
		/// <summary>
		/// 執行多條SQL語句，實現數據庫事務。
		/// </summary>
		/// <param name="SQLStringList">SQL語句的哈希表（key為sql語句，value是該語句的OracleParameter[]）</param>
		public static void ExecuteSqlTran(Hashtable SQLStringList)
		{			
			using (OracleConnection conn = new OracleConnection(connectionString))
			{
				conn.Open();
				using (OracleTransaction trans = conn.BeginTransaction()) 
				{
					OracleCommand cmd = new OracleCommand();
					try 
					{
						//循環
						foreach (DictionaryEntry myDE in SQLStringList)
						{	
							string 	cmdText=myDE.Key.ToString();
							OracleParameter[] cmdParms=(OracleParameter[])myDE.Value;
							PrepareCommand(cmd,conn,trans,cmdText, cmdParms);
							int val = cmd.ExecuteNonQuery();
							cmd.Parameters.Clear();

							trans.Commit();
						}					
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}				
			}
		}
	
				
		/// <summary>
		/// 執行一條計算查詢結果語句，返回查詢結果（object）。
		/// </summary>
		/// <param name="SQLString">計算查詢結果語句</param>
		/// <returns>查詢結果（object）</returns>
		public static object GetSingle(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				using (OracleCommand cmd = new OracleCommand())
				{
					try
					{
						PrepareCommand(cmd, connection, null,SQLString, cmdParms);
						object obj = cmd.ExecuteScalar();
						cmd.Parameters.Clear();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.OracleClient.OracleException e)
					{				
						throw new Exception(e.Message);
					}					
				}
			}
		}
		
		/// <summary>
        /// 執行查詢語句，返回OracleDataReader ( 注意：調用該方法後，一定要對SqlDataReader進行Close )
		/// </summary>
		/// <param name="strSQL">查詢語句</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader ExecuteReader(string SQLString,params OracleParameter[] cmdParms)
		{		
			OracleConnection connection = new OracleConnection(connectionString);
			OracleCommand cmd = new OracleCommand();				
			try
			{
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
                OracleDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				cmd.Parameters.Clear();
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException e)
			{								
				throw new Exception(e.Message);
			}					
			
		}		
		
		/// <summary>
		/// 執行查詢語句，返回DataSet
		/// </summary>
		/// <param name="SQLString">查詢語句</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString,params OracleParameter[] cmdParms)
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				OracleCommand cmd = new OracleCommand();
				PrepareCommand(cmd, connection, null,SQLString, cmdParms);
				using( OracleDataAdapter da = new OracleDataAdapter(cmd) )
				{
					DataSet ds = new DataSet();	
					try
					{												
						da.Fill(ds,"ds");
						cmd.Parameters.Clear();
					}
					catch(System.Data.OracleClient.OracleException ex)
					{				
						throw new Exception(ex.Message);
					}			
					return ds;
				}				
			}			
		}


		private static void PrepareCommand(OracleCommand cmd,OracleConnection conn,OracleTransaction trans, string cmdText, OracleParameter[] cmdParms) 
		{
			if (conn.State != ConnectionState.Open)
				conn.Open();
			cmd.Connection = conn;
			cmd.CommandText = cmdText;
			if (trans != null)
				cmd.Transaction = trans;
			cmd.CommandType = CommandType.Text;//cmdType;
			if (cmdParms != null) 
			{
				foreach (OracleParameter parm in cmdParms)
					cmd.Parameters.Add(parm);
			}
		}

		#endregion

		#region 存儲過程操作

		/// <summary>
        /// 執行存儲過程 返回SqlDataReader ( 注意：調用該方法後，一定要對SqlDataReader進行Close )
		/// </summary>
		/// <param name="storedProcName">存儲過程名</param>
		/// <param name="parameters">存儲過程參數</param>
		/// <returns>OracleDataReader</returns>
		public static OracleDataReader RunProcedure(string storedProcName, IDataParameter[] parameters )
		{
			OracleConnection connection = new OracleConnection(connectionString);
			OracleDataReader returnReader;
			connection.Open();
			OracleCommand command = BuildQueryCommand( connection,storedProcName, parameters );
			command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);				
			return returnReader;			
		}
		
		
		/// <summary>
		/// 執行存儲過程
		/// </summary>
		/// <param name="storedProcName">存儲過程名</param>
		/// <param name="parameters">存儲過程參數</param>
		/// <param name="tableName">DataSet結果中的表名</param>
		/// <returns>DataSet</returns>
		public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName )
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				DataSet dataSet = new DataSet();
				connection.Open();
				OracleDataAdapter sqlDA = new OracleDataAdapter();
				sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters );
				sqlDA.Fill( dataSet, tableName );
				connection.Close();
				return dataSet;
			}
		}

		
		/// <summary>
		/// 構建 OracleCommand 對像(用來返回一個結果集，而不是一個整數值)
		/// </summary>
		/// <param name="connection">數據庫連接</param>
		/// <param name="storedProcName">存儲過程名</param>
		/// <param name="parameters">存儲過程參數</param>
		/// <returns>OracleCommand</returns>
		private static OracleCommand BuildQueryCommand(OracleConnection connection,string storedProcName, IDataParameter[] parameters)
		{			
			OracleCommand command = new OracleCommand( storedProcName, connection );
			command.CommandType = CommandType.StoredProcedure;
			foreach (OracleParameter parameter in parameters)
			{
				command.Parameters.Add( parameter );
			}
			return command;			
		}
		
		/// <summary>
		/// 執行存儲過程，返回影響的行數		
		/// </summary>
		/// <param name="storedProcName">存儲過程名</param>
		/// <param name="parameters">存儲過程參數</param>
		/// <param name="rowsAffected">影響的行數</param>
		/// <returns></returns>
		public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected )
		{
			using (OracleConnection connection = new OracleConnection(connectionString))
			{
				int result;
				connection.Open();
				OracleCommand command = BuildIntCommand(connection,storedProcName, parameters );
				rowsAffected = command.ExecuteNonQuery();
				result = (int)command.Parameters["ReturnValue"].Value;
				//Connection.Close();
				return result;
			}
		}
		
		/// <summary>
		/// 創建 OracleCommand 對像實例(用來返回一個整數值)	
		/// </summary>
		/// <param name="storedProcName">存儲過程名</param>
		/// <param name="parameters">存儲過程參數</param>
		/// <returns>OracleCommand 對像實例</returns>
		private static OracleCommand BuildIntCommand(OracleConnection connection,string storedProcName, IDataParameter[] parameters)
		{
			OracleCommand command = BuildQueryCommand(connection,storedProcName, parameters );
			command.Parameters.Add( new OracleParameter ( "ReturnValue",
                OracleType.Int32, 4, ParameterDirection.ReturnValue,
				false,0,0,string.Empty,DataRowVersion.Default,null ));
			return command;
		}
		#endregion	

	}
}
