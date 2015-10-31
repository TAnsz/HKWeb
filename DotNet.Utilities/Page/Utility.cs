/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>

using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace DotNet.Utilities
{
	/// <summary>
	/// Utility 的摘要說明。
	/// </summary>
	public class Utility:Page
	{

		#region 數據轉換
		/// <summary>
		/// 返回對像obj的String值,obj為null時返回空值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>字符串。</returns>
		public static string ToObjectString(object obj)  
		{
			return null == obj ? String.Empty : obj.ToString();
		}

		/// <summary>
		/// 將對像轉換為數值(Int32)類型,轉換失敗返回-1。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Int32數值。</returns>
		public static int ToInt(object obj)
		{
			try
			{
				return int.Parse(ToObjectString(obj));
			}
			catch
			{ return -1; }
		}

		/// <summary>
		/// 將對像轉換為數值(Int32)類型。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Int32數值。</returns>
		public static int ToInt(object obj,int returnValue)
		{
			try
			{
				return int.Parse(ToObjectString(obj));
			}
			catch
			{ return returnValue; }
		}
		/// <summary>
		/// 將對像轉換為數值(Long)類型,轉換失敗返回-1。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Long數值。</returns>
		public static long ToLong(object obj)
		{
			try
			{
				return long.Parse(ToObjectString(obj));
			}
			catch
			{ return -1L; }
		}
		/// <summary>
		/// 將對像轉換為數值(Long)類型。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Long數值。</returns>
		public static long ToLong(object obj,long returnValue)
		{
			try
			{
				return long.Parse(ToObjectString(obj));
			}
			catch
			{ return returnValue; }
		}
		/// <summary>
		/// 將對像轉換為數值(Decimal)類型,轉換失敗返回-1。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Decimal數值。</returns>
		public static decimal ToDecimal(object obj)
		{
			try
			{
				return decimal.Parse(ToObjectString(obj));
			}
			catch
			{ return -1M; }
		}

		/// <summary>
		/// 將對像轉換為數值(Decimal)類型。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Decimal數值。</returns>
		public static decimal ToDecimal(object obj,decimal returnValue)
		{
			try
			{
				return decimal.Parse(ToObjectString(obj));
			}
			catch
			{ return returnValue; }
		}
		/// <summary>
		/// 將對像轉換為數值(Double)類型,轉換失敗返回-1。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Double數值。</returns>
		public static double ToDouble(object obj)
		{
			try
			{
				return double.Parse(ToObjectString(obj));
			}
			catch
			{ return -1; }
		}

		/// <summary>
		/// 將對像轉換為數值(Double)類型。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Double數值。</returns>
		public static double ToDouble(object obj,double returnValue)
		{
			try
			{
				return double.Parse(ToObjectString(obj));
			}
			catch
			{ return returnValue; }
		}
		/// <summary>
		/// 將對像轉換為數值(Float)類型,轉換失敗返回-1。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Float數值。</returns>
		public static float ToFloat(object obj)
		{
			try
			{
				return float.Parse(ToObjectString(obj));
			}
			catch
			{ return -1; }
		}

		/// <summary>
		/// 將對像轉換為數值(Float)類型。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Float數值。</returns>
		public static float ToFloat(object obj,float returnValue)
		{
			try
			{
				return float.Parse(ToObjectString(obj));
			}
			catch
			{ return returnValue; }
		}
		/// <summary>
		/// 將對像轉換為數值(DateTime)類型,轉換失敗返回Now。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>DateTime值。</returns>
		public static DateTime ToDateTime(object obj)
		{
			try
			{
				DateTime dt = DateTime.Parse(ToObjectString(obj));
				if( dt > DateTime.MinValue && DateTime.MaxValue > dt)
					return dt;
				return DateTime.Now;
			}
			catch
			{ return DateTime.Now; }
		}

		/// <summary>
		/// 將對像轉換為數值(DateTime)類型。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>DateTime值。</returns>
		public static DateTime ToDateTime(object obj,DateTime returnValue)
		{
			try
			{
				DateTime dt = DateTime.Parse(ToObjectString(obj));
				if( dt > DateTime.MinValue && DateTime.MaxValue > dt)
					return dt;
				return returnValue;
			}
			catch
			{ return returnValue; }
		}
		/// <summary>
		/// 從Boolean轉換成byte,轉換失敗返回0。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Byte值。</returns>
		public static byte ToByteByBool( object obj )
		{
			string text = ToObjectString(obj).Trim();
			if( text == string.Empty)
				return 0;
			else
			{
				try
				{
					return (byte)(text.ToLower()=="true"?1:0);
				}
				catch
				{
					return 0;
				}
			}
		}
		
		/// <summary>
		/// 從Boolean轉換成byte。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Byte值。</returns>
		public static byte ToByteByBool( object obj, byte returnValue )
		{
			string text = ToObjectString(obj).Trim();
			if( text == string.Empty)
				return returnValue;
			else
			{
				try
				{
					return (byte)(text.ToLower()=="true"?1:0);
				}
				catch
				{
					return returnValue;
				}
			}
		}
		/// <summary>
		/// 從byte轉換成Boolean,轉換失敗返回false。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Boolean值。</returns>
		public static bool ToBoolByByte( object obj )
		{
			try
			{
				string s = ToObjectString(obj).ToLower();
				return s == "1" || s== "true"?true:false;
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// 從byte轉換成Boolean。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <param name="returnValue">轉換失敗返回該值。</param>
		/// <returns>Boolean值。</returns>
		public static bool ToBoolByByte( object obj, bool returnValue )
		{
			try
			{
				string s = ToObjectString(obj).ToLower();
				return s == "1" || s== "true"?true:false;
			}
			catch
			{
				return returnValue;
			}
		}
		#endregion

		#region 數據判斷
		/// <summary>
		/// 判斷文本obj是否為空值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Boolean值。</returns>
		public static bool IsEmpty(string obj)
		{
			return ToObjectString(obj).Trim() == String.Empty ? true : false;
		}

		/// <summary>
		/// 判斷對象是否為正確的日期值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Boolean。</returns>
		public static bool IsDateTime(object obj)
		{
			try
			{
				DateTime dt = DateTime.Parse(ToObjectString(obj));
				if( dt > DateTime.MinValue && DateTime.MaxValue > dt)
					return true;
				return false;
			}
			catch
			{ return false; }
		}

		/// <summary>
		/// 判斷對象是否為正確的Int32值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Int32值。</returns>
		public static bool IsInt(object obj)
		{
			try
			{
				int.Parse(ToObjectString(obj));
				return true;
			}
			catch
			{ return false; }
		}

		/// <summary>
		/// 判斷對象是否為正確的Long值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Long值。</returns>
		public static bool IsLong(object obj)
		{
			try
			{
				long.Parse(ToObjectString(obj));
				return true;
			}
			catch
			{ return false; }
		}

		/// <summary>
		/// 判斷對象是否為正確的Float值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Float值。</returns>
		public static bool IsFloat(object obj)
		{
			try
			{
				float.Parse(ToObjectString(obj));
				return true;
			}
			catch
			{ return false; }
		}

		/// <summary>
		/// 判斷對象是否為正確的Double值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Double值。</returns>
		public static bool IsDouble(object obj)
		{
			try
			{
				double.Parse(ToObjectString(obj));
				return true;
			}
			catch
			{ return false; }
		}
		
		/// <summary>
		/// 判斷對象是否為正確的Decimal值。
		/// </summary>
		/// <param name="obj">對象。</param>
		/// <returns>Decimal值。</returns>
		public static bool IsDecimal(object obj)
		{
			try
			{
				decimal.Parse(ToObjectString(obj));
				return true;
			}
			catch
			{ return false; }
		}
		#endregion

		#region 數據操作
		/// <summary>
		/// 去除字符串的所有空格。
		/// </summary>
		/// <param name="text">字符串</param>
		/// <returns>字符串</returns>
		public static string StringTrimAll( string text )
		{
			string _text = ToObjectString(text);
			string returnText = String.Empty;
			char[] chars = _text.ToCharArray();
			for( int i=0;i<chars.Length;i++)
			{
				if( chars[i].ToString() != string.Empty)
					returnText += chars[i].ToString();
			}
			return returnText;
		}

		/// <summary>
		/// 去除數值字符串的所有空格。
		/// </summary>
		/// <param name="numricString">數值字符串</param>
		/// <returns>String</returns>
		public static string NumricTrimAll( string numricString )
		{
			string text = ToObjectString(numricString).Trim();
			string returnText = String.Empty;
			char[] chars = text.ToCharArray();
			for( int i=0;i<chars.Length;i++)
			{
				if( chars[i].ToString() == "+" || chars[i].ToString() == "-" || IsDouble( chars[i].ToString()) )
					returnText += chars[i].ToString();
			}
			return returnText;
		}

		/// <summary>
		/// 在數組中查找匹配對像類型
		/// </summary>
		/// <param name="array">數組</param>
		/// <param name="obj">對像</param>
		/// <returns>Boolean</returns>
		public static bool ArrayFind(Array array,object obj)
		{
			bool b = false;
			foreach(object obj1 in array)
			{
				if(obj.Equals(obj1))
				{
					b = true;
					break;
				}
			}
			return b;
		}

		/// <summary>
		/// 在數組中查找匹配字符串
		/// </summary>
		/// <param name="array">數組</param>
		/// <param name="obj">對像</param>
		/// <param name="unUpLower">是否忽略大小寫</param>
		/// <returns>Boolean</returns>
		public static bool ArrayFind(Array array,string obj,bool unUpLower)
		{
			bool b = false;
			foreach(string obj1 in array)
			{
				if(!unUpLower)
				{
					if(obj.Trim().Equals(obj1.ToString().Trim()))
					{
						b = true;
						break;
					}
				}
				else
				{
					if(obj.Trim().ToUpper().Equals(obj1.ToString().Trim().ToUpper()))
					{
						b = true;
						break;
					}
				}
			}
			return b;
		}
		/// <summary>
		/// 替換字符串中的單引號。
		/// </summary>
		/// <param name="inputString">字符串</param>
		/// <returns>String</returns>
		public static string ReplaceInvertedComma( string inputString )
		{
			return inputString.Replace("'","''");
		}

		
		/// <summary>
		/// 判斷兩個字節數組是否具有相同值.
		/// </summary>
		/// <param name="bytea">字節1</param>
		/// <param name="byteb">字節2</param>
		/// <returns>Boolean</returns>
		public static bool CompareByteArray(byte[] bytea,byte[] byteb)
		{
			if(null == bytea || null == byteb)
			{
				return false;
			}
			else
			{
				int aLength = bytea.Length;
				int bLength = byteb.Length;
				if(aLength != bLength)
					return false;
				else
				{
					bool compare = true;
					for(int index = 0; index < aLength; index++)
					{
						if(bytea[index].CompareTo(byteb[index]) != 0)
						{
							compare = false;
							break;
						}
					}
					return compare;
				}
			}
		}

		
		/// <summary>
		/// 日期智能生成。
		/// </summary>
		/// <param name="inputText">字符串</param>
		/// <returns>DateTime</returns>
		public static string BuildDate( string inputText )
		{
			try
			{
				return DateTime.Parse( inputText ).ToShortDateString();
			}
			catch
			{
				string text = NumricTrimAll( inputText );
				string year = DateTime.Now.Year.ToString();
				string month = DateTime.Now.Month.ToString();
				string day = DateTime.Now.Day.ToString();
				int length = text.Length;
				if( length == 0 )
					return String.Empty;
				else
				{
					if( length<=2 )
						day = text;
					else if( length<=4 )
					{
						month = text.Substring(0,2);
						day = text.Substring(2,length-2);
					}
					else if( length<=6 )
					{
						year = text.Substring(0,4);
						month = text.Substring(4,length-4);
					}
					else if( length>6)
					{
						year = text.Substring(0,4);
						month = text.Substring(4,2);
						day = text.Substring(6,length-6);
					}
					try
					{
						return DateTime.Parse( year+"-"+month+"-"+day ).ToShortDateString();
					}
					catch
					{
						return String.Empty;
					}
				}
			}
		}

		

		/// <summary>
		/// 檢查文件是否真實存在。
		/// </summary>
		/// <param name="path">文件全名（包括路徑）。</param>
		/// <returns>Boolean</returns>
		public static bool IsFileExists(string path)
		{
			try
			{
				return File.Exists(path);
			}
			catch
			{	return false; }
		}

		/// <summary>
		/// 檢查目錄是否真實存在。
		/// </summary>
		/// <param name="path">目錄路徑.</param>
		/// <returns>Boolean</returns>
		public static bool IsDirectoryExists(string path)
		{
			try
			{
				return Directory.Exists(Path.GetDirectoryName(path));
			}
			catch
			{	return false; }
		}
		
		/// <summary>
		/// 查找文件中是否存在匹配行。
		/// </summary>
		/// <param name="fi">目標文件.</param>
		/// <param name="lineText">要查找的行文本.</param>
		/// <param name="lowerUpper">是否區分大小寫.</param>
		/// <returns>Boolean</returns>
		public static bool FindLineTextFromFile(FileInfo fi,string lineText,bool lowerUpper)
		{
			bool b = false;
			try
			{
				if(fi.Exists)
				{
					StreamReader sr=new StreamReader(fi.FullName);
					string g = "";
					do
					{
						g=sr.ReadLine();
						if(lowerUpper)
						{
							if(ToObjectString(g).Trim() == ToObjectString(lineText).Trim())
							{
								b = true;
								break;
							}
						}
						else
						{
							if(ToObjectString(g).Trim().ToLower() == ToObjectString(lineText).Trim().ToLower())
							{
								b = true;
								break;
							}
						}
					}
					while(sr.Peek()!=-1);
					sr.Close();
				}
			}
			catch
			{	b =false;	}
			return b;
		}


		/// <summary>
		/// 判斷父子級關係是否正確。
		/// </summary>
		/// <param name="table">數據表。</param>
		/// <param name="columnName">子鍵列名。</param>
		/// <param name="parentColumnName">父鍵列名。</param>
		/// <param name="inputString">子鍵值。</param>
		/// <param name="compareString">父鍵值。</param>
		/// <returns></returns>
		public static bool IsRightParent(DataTable table,string columnName,string parentColumnName,string inputString,string compareString)
		{
			ArrayList array = new ArrayList();
			SearchChild(array,table,columnName,parentColumnName,inputString,compareString);
			return array.Count == 0;
		}

		// 內部方法
		private static void SearchChild(ArrayList array,DataTable table,string columnName,string parentColumnName,string inputString,string compareString)
		{
			DataView view = new DataView(table);
			view.RowFilter = parentColumnName+"='"+ReplaceInvertedComma(inputString.Trim())+"'";//找出所有的子類。
			//查找表中的數據的ID是否與compareString相等，相等返回 false;不相等繼續迭代。
			for(int index = 0 ;index < view.Count;index ++)
			{
				if(Utility.ToObjectString(view[index][columnName]).ToLower() == compareString.Trim().ToLower())
				{
					array.Add("1");
					break;
				}
				else
				{
					SearchChild(array,table,columnName,parentColumnName,Utility.ToObjectString(view[index][columnName]),compareString);
				}
			}
		}

		#endregion

		#region 日期

        /// <summary>
        /// 格式化日期類型，返回字符串
        /// </summary>
        /// <param name="dtime">日期</param>
        /// <param name="s">日期年月日間隔符號</param>
        /// <returns></returns>
		public static String Fomatdate(DateTime dtime,String s)
		{
			String datestr="";
			datestr=dtime.Year.ToString() + s + dtime.Month.ToString().PadLeft(2,'0')+ s +dtime.Day.ToString().PadLeft(2,'0');
			return datestr;
		}

        /// <summary>
        /// 返回日期差
        /// </summary>
        /// <param name="sdmin">開始日期</param>
        /// <param name="sdmax">結束日期</param>
        /// <returns>日期差：負數為失敗</returns>
		public static int Datediff(DateTime sdmin,DateTime sdmax)
		{
			try
			{
				double i=0;
				while(sdmin.AddDays(i)<sdmax)
				{
					i++;
				}
				return Utility.ToInt(i);
			}
			catch
			{
			    return -1;
			}
		}

        /// <summary>
        /// 返回日期差
        /// </summary>
        /// <param name="sdmin">開始日期</param>
        /// <param name="sdmax">結束日期</param>
        /// <returns>日期差：負數為失敗</returns>
		public static int Datediff(String sdmin,String sdmax)
		{
			try
			{
				DateTime dmin;
				DateTime dmax;
				dmin=DateTime.Parse(sdmin);
				dmax=DateTime.Parse(sdmax);
				double i=0;
				while(dmin.AddDays(i)<dmax)
				{
					i++;
				}
				return Utility.ToInt(i);
			}
			catch
			{
			    return -1;
			}
		}

		#endregion

		#region 轉換用戶輸入

		/// <summary>
		/// 將用戶輸入的字符串轉換為可換行、替換Html編碼、無危害數據庫特殊字符、去掉首尾空白、的安全方便代碼。
		/// </summary>
		/// <param name="inputString">用戶輸入字符串</param>
		public static string ConvertStr(string inputString)
		{
			string retVal=inputString;
			//retVal=retVal.Replace("&","&amp;"); 
			retVal=retVal.Replace("\"","&quot;"); 
			retVal=retVal.Replace("<","&lt;"); 
			retVal=retVal.Replace(">","&gt;"); 
			retVal=retVal.Replace(" ","&nbsp;"); 
			retVal=retVal.Replace("  ","&nbsp;&nbsp;"); 
			retVal=retVal.Replace("\t","&nbsp;&nbsp;");
			retVal=retVal.Replace("\r", "<br>");
			return retVal;
		}

		public static string InputText(string inputString)
		{
			string retVal=inputString;
			retVal= ConvertStr(retVal);
			retVal=retVal.Replace("[url]", "");
			retVal=retVal.Replace("[/url]", "");
			return retVal;
		}


        /// <summary>
        /// 將html代碼顯示在網頁上
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
		public static string OutputText(string inputString)
		{
			string retVal=System.Web.HttpUtility.HtmlDecode(inputString);
			retVal=retVal.Replace("<br>","");
			retVal=retVal.Replace("&amp","&;"); 
			retVal=retVal.Replace("&quot;","\""); 
			retVal=retVal.Replace("&lt;","<"); 
			retVal=retVal.Replace("&gt;",">"); 
			retVal=retVal.Replace("&nbsp;"," "); 
			retVal=retVal.Replace("&nbsp;&nbsp;","  "); 
			return retVal;
		}

		public static string ToUrl(string inputString)
		{
			string retVal=inputString;
			retVal= ConvertStr(retVal);
			return Regex.Replace(retVal,@"\[url](?<x>[^\]]*)\[/url]",@"<a href=""$1"" target=""_blank"">$1</a>",RegexOptions.IgnoreCase);
		}

		public static string GetSafeCode(string str)
		{
			  str=str.Replace("'","");
			  str=str.Replace(char.Parse("34"),' ');
			  str=str.Replace(";","");
			return str;
		}

		#endregion

   
        //#region 彈出框

        ///// <summary>
        ///// 服務器端彈出alert對話框
        ///// </summary>
        ///// <param name="str_Message">提示信息,例子："請輸入您姓名!"</param>
        ///// <param name="page">Page類</param>
        //public static void Alert(string str_Message,Page page)
        //{
        //    page.RegisterStartupScript("","<script>alert('"+str_Message+"');</script>");
        //}
        ///// <summary>
        ///// 服務器端彈出alert對話框
        ///// </summary>
        ///// <param name="str_Ctl_Name">獲得焦點控件Id值,比如：txt_Name</param>
        ///// <param name="str_Message">提示信息,例子："請輸入您姓名!"</param>
        ///// <param name="page">Page類</param>
        //public static void Alert(string str_Ctl_Name,string str_Message,Page page)
        //{
        //    page.RegisterStartupScript("","<script>alert('"+str_Message+"');document.forms(0)."+str_Ctl_Name+".focus(); document.forms(0)."+str_Ctl_Name+".select();</script>");
        //}
        ///// <summary>
        ///// 服務器端彈出confirm對話框,該函數有個弊端,必須放到響應事件的最後,目前沒有妥善解決方案
        ///// </summary>
        ///// <param name="str_Message">提示信息,例子："您是否確認刪除!"</param>
        ///// <param name="btn">隱藏Botton按鈕Id值,比如：btn_Flow</param>
        ///// <param name="page">Page類</param>
        //public static void Confirm(string str_Message,string btn,Page page)
        //{
        //    page.RegisterStartupScript("","<script> if (confirm('"+str_Message+"')==true){document.forms(0)."+btn+".click();}</script>");
        //}
        ///// <summary>
        /////  服務器端彈出confirm對話框,詢問用戶準備轉向相應操作，包括「確定」和「取消」時的操作
        ///// </summary>
        ///// <param name="str_Message">提示信息，比如："成功增加數據,單擊\"確定\"按鈕填寫流程,單擊\"取消\"修改數據"</param>
        ///// <param name="btn_Redirect_Flow">"確定"按鈕id值</param>
        ///// <param name="btn_Redirect_Self">"取消"按鈕id值</param>
        ///// <param name="page">Page類</param>
        //public static void Confirm(string str_Message,string btn_Redirect_Flow,string btn_Redirect_Self,Page page)
        //{
        //    page.RegisterStartupScript("","<script> if (confirm('"+str_Message+"')==true){document.forms(0)."+btn_Redirect_Flow+".click();}else{document.forms(0)."+btn_Redirect_Self+".click();}</script>");
        //}

        //#endregion


		/// <summary>
		/// 設置綁定到DataGrid的DataTable的記錄行數，如不夠則添加空行
		/// </summary>
		/// <param name="myDataTable">數據表</param>
		/// <param name="intPageCount">DataGrid分頁時每頁行數</param>
		public static void SetTableRows(DataTable myDataTable,int intPageCount)
		{
			try
			{
				int intTemp=myDataTable.Rows.Count%intPageCount;
				if ((myDataTable.Rows.Count==0) || (intTemp!=0))
				{
					for(int i=0;i<(intPageCount-intTemp);i++)
					{
						DataRow myDataRow=myDataTable.NewRow();
						myDataTable.Rows.Add(myDataRow);
					}
				}
			}
			catch
			{
				throw;
			}
		}


        public static string GetGuid(string guid)
        {
            return guid.Replace("-", "");
        }

        public static string ReadConfig(string filePath)
        {
            return System.Configuration.ConfigurationManager.AppSettings[filePath];
        }

        #region   字符串長度區分中英文截取
        /// <summary>   
        /// 截取文本，區分中英文字符，中文算兩個長度，英文算一個長度
        /// </summary>
        /// <param name="str">待截取的字符串</param>
        /// <param name="length">需計算長度的字符串</param>
        /// <returns>string</returns>
        public static string GetSubString(string str, int length)
        {
            string temp = str;
            int j = 0;
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Regex.IsMatch(temp.Substring(i, 1), @"[\u4e00-\u9fa5]+"))
                {
                    j += 2;
                }
                else
                {
                    j += 1;
                }
                if (j <= length)
                {
                    k += 1;
                }
                if (j > length)
                {
                    return temp.Substring(0, k) + "...";
                }
            }
            return temp;
        }
        #endregion
	}
}
