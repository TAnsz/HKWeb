/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
/** 1. 功能：處理數據類型轉換，數制轉換、編碼轉換相關的類
 *  2. 作者：周兆坤 
 *  3. 創建日期：2010-3-19
 *  4. 最後修改日期：2010-3-19
**/
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// 處理數據類型轉換，數制轉換、編碼轉換相關的類
    /// </summary>    
    public sealed class ConvertHelper
    {
        #region 補足位數
        /// <summary>
        /// 指定字符串的固定長度，如果字符串小於固定長度，
        /// 則在字符串的前面補足零，可設置的固定長度最大為9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定長度</param>
        public static string RepairZero(string text, int limitedLength)
        {
            //補足0的字符串
            string temp = "";

            //補足0
            for (int i = 0; i < limitedLength - text.Length; i++)
            {
                temp += "0";
            }

            //連接text
            temp += text;

            //返回補足0的字符串
            return temp;
        }
        #endregion

        #region 各進制數間轉換
        /// <summary>
        /// 實現各進制數間的轉換。ConvertBase("15",10,16)表示將十進制數15轉換為16進制的數。
        /// </summary>
        /// <param name="value">要轉換的值,即原值</param>
        /// <param name="from">原值的進制,只能是2,8,10,16四個值。</param>
        /// <param name="to">要轉換到的目標進制，只能是2,8,10,16四個值。</param>
        public static string ConvertBase(string value, int from, int to)
        {
            try
            {
                int intValue = Convert.ToInt32(value, from);  //先轉成10進制
                string result = Convert.ToString(intValue, to);  //再轉成目標進制
                if (to == 2)
                {
                    int resultLength = result.Length;  //獲取二進制的長度
                    switch (resultLength)
                    {
                        case 7:
                            result = "0" + result;
                            break;
                        case 6:
                            result = "00" + result;
                            break;
                        case 5:
                            result = "000" + result;
                            break;
                        case 4:
                            result = "0000" + result;
                            break;
                        case 3:
                            result = "00000" + result;
                            break;
                    }
                }
                return result;
            }
            catch
            {

                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                return "0";
            }
        }
        #endregion

        #region 使用指定字符集將string轉換成byte[]
        /// <summary>
        /// 使用指定字符集將string轉換成byte[]
        /// </summary>
        /// <param name="text">要轉換的字符串</param>
        /// <param name="encoding">字符編碼</param>
        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }
        #endregion

        #region 使用指定字符集將byte[]轉換成string
        /// <summary>
        /// 使用指定字符集將byte[]轉換成string
        /// </summary>
        /// <param name="bytes">要轉換的字節數組</param>
        /// <param name="encoding">字符編碼</param>
        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }
        #endregion

        #region 將byte[]轉換成int
        /// <summary>
        /// 將byte[]轉換成int
        /// </summary>
        /// <param name="data">需要轉換成整數的byte數組</param>
        public static int BytesToInt32(byte[] data)
        {
            //如果傳入的字節數組長度小於4,則返回0
            if (data.Length < 4)
            {
                return 0;
            }

            //定義要返回的整數
            int num = 0;

            //如果傳入的字節數組長度大於4,需要進行處理
            if (data.Length >= 4)
            {
                //創建一個臨時緩衝區
                byte[] tempBuffer = new byte[4];

                //將傳入的字節數組的前4個字節複製到臨時緩衝區
                Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);

                //將臨時緩衝區的值轉換成整數，並賦給num
                num = BitConverter.ToInt32(tempBuffer, 0);
            }

            //返回整數
            return num;
        }
        #endregion

        #region 數字轉換

        /// <summary>判斷是否為數字類型,包括[+-]號,小數字
        /// 包括（boolean/byte/int16/int32/int64/single/double/decimal）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length > 18)
            {
                return false;
            }
            else
            {
                return (new Regex("^[\\+\\-]?[0-9]*\\.?[0-9]+$")).IsMatch(str);
            }
        }

        /// <summary>判斷是否為數字類型,包括[+-]號,小數字
        /// 包括（boolean/byte/int16/int32/int64/single/double/decimal）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(object str)
        {
            if (str != null)
            {
                return IsNumeric(str.ToString());
            }
            return false;
        }

        /// <summary>判斷是否為整型數字(int32),不包括-</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if ((str.Length > 10) || (str.Length == 10 && str[0] != '1'))
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] < '0') || (str[i] > '9'))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>判斷是否為整型數字,包括（int32）</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(object str)
        {
            if (str != null)
            {
                return IsInt(str.ToString());
            }
            return false;
        }

        /// <summary>判斷是否為整型數字,包括（int64）</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLong(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length > 18)
            {
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] < '0') || (str[i] > '9'))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>判斷是否為整型數字,包括（int64）</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLong(object str)
        {
            if (str != null)
            {
                return IsInt(str.ToString());
            }
            return false;
        }

        /// <summary>判斷是否為浮點數字,用於貨幣,數量,包括小數字,但不包[+-]號,最多18位
        /// 包括（single/double/decimal）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsFloat(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length > 18)
            {
                return false;
            }
            else
            {
                return (new Regex("^[0-9]*\\.?[0-9]+$")).IsMatch(str);
            }
        }

        /// <summary>判斷是否為浮點數字,用於貨幣,數量,包括小數字,但不包[+-]號
        /// 包括（single/double/decimal）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsFloat(object str)
        {
            if (str != null)
            {
                return IsFloat(str.ToString());
            }
            return false;
        }

        /// <summary>把string 轉 int32 ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static int Cint(string str, int defValue = 0)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defValue;
            }

            int iLen = str.Length;
            if (iLen > 10)
            {
                return defValue;
            }

            string ss = "";
            bool isFlag = (str[0] == '-');
            int iStart = isFlag ? 1 : 0;

            for (int i = iStart; i < iLen; i++)
            {
                if ((str[i] < '0') || (str[i] > '9'))
                {
                    break;
                }
                else
                {
                    ss += str[i].ToString();
                    if (ss.Length > 9)
                    {
                        break;
                    }
                }
            }

            if (isFlag)
            {
                ss = "-" + ss;
            }
            return ss == "" ? defValue : int.Parse(ss);
        }

        /// <summary>把string 轉 int32 ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int Cint(object str)
        {
            if (str != null)
            {
                return Cint(str.ToString());
            }
            return 0;
        }

        /// <summary>把string 轉 int32,判斷是否小於minValue,小於返回minValue</summary>
        /// <param name="str"></param>
        /// <param name="minValue">當Value少於該值時,返回該值</param>
        /// <returns></returns>
        public static int CintMinValue(string str, int minValue)
        {
            int tmp = Cint(str);
            return tmp < minValue ? minValue : tmp;
        }

        /// <summary>把string 轉 int32,判斷是否小於minValue,小於返回minValue</summary>
        /// <param name="str"></param>
        /// <param name="minValue">當Value少於該值時,返回該值</param>
        /// <returns></returns>
        public static int CintMinValue(object str, int minValue)
        {
            if (str != null)
            {
                return CintMinValue(str.ToString(), minValue);
            }
            return minValue;
        }

        /// <summary>把string 轉 int32,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=0的int型</returns>
        public static int Cint0(string str)
        {
            return CintMinValue(str, 0);
        }

        /// <summary>把string 轉 int32,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=0的int型</returns>
        public static int Cint0(object str)
        {
            return CintMinValue(str, 0);
        }

        /// <summary>把string 轉 int32,小於1返回1,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=1的int型</returns>
        public static int Cint1(string str)
        {
            return CintMinValue(str, 1);
        }

        /// <summary>把string 轉 int32,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=1的int型</returns>
        public static int Cint1(object str)
        {
            return CintMinValue(str, 1);
        }

        /// <summary>不等於"1",就為"0",用於審核之類的</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte Ctinyint(string str)
        {
            return StringToByte(str, 0);
        }

        /// <summary>不等於"1",就為"0",用於審核之類的</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte Ctinyint(object str)
        {
            if (str != null)
            {
                return Ctinyint(str.ToString());
            }
            return 0;
        }

        #region Decimal 相關 2013-9-11 周光華

        /// <summary>把string 轉 decimal ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static decimal Cdecimal(string str, int defValue = 0)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defValue;
            }

            if (str.Length > 18)
            {
                return defValue;
            }

            if (IsNumeric(str))
            {
                return decimal.Parse(str);
            }
            return defValue;
        }

        /// <summary>把string 轉 decimal ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static decimal Cdecimal(object str, int defValue = 0)
        {
            if (str != null)
            {
                return Cdecimal(str.ToString());
            }
            return defValue;
        }

        /// <summary>把string 轉 decimal ,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=0的int型</returns>
        public static decimal Cdecimal0(string str)
        {
            decimal tmp = Cdecimal(str);
            return tmp < 0 ? 0 : tmp;
        }

        /// <summary>把string 轉 decimal ,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=0的int型</returns>
        public static decimal Cdecimal0(object str)
        {
            return Cdecimal0(str + "");
        }
        #endregion

        /// <summary>把string 轉 long/int64 ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long Clng(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            int iLen = str.Length;
            if (iLen > 18)
            {
                return 0;
            }
            string ss = "";

            for (int i = 0; i < iLen; i++)
            {
                if ((str[i] < '0') || (str[i] > '9'))
                {
                    break;
                }
                else
                {
                    ss += str[i].ToString();
                }
            }

            if (ss == "")
            {
                return 0;
            }
            else
            {
                return long.Parse(ss.ToString());
            }
        }

        /// <summary>把string 轉 long/int64 ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long Clng(object str)
        {
            if (str != null)
            {
                return Clng(str.ToString());
            }
            return 0;
        }

        /// <summary>把string 轉 Double ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double Cdbl(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            if (str.Length > 18)
            {
                return 0;
            }

            if (IsNumeric(str.ToString()))
            {
                return double.Parse(str);
            }
            return 0;
        }

        /// <summary>把string 轉 Double ,從左邊繼位檢查轉換(不管輸入的是小數,還是字母)</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double Cdbl(object str)
        {
            if (str != null)
            {
                return Cdbl(str.ToString());
            }
            return 0;
        }

        /// <summary>把string 轉 Double ,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=0的int型</returns>
        public static double Cdbl0(string str)
        {
            double tmp = Cdbl(str);
            if (tmp < 0)
            {
                return 0;
            }
            else
            {
                return tmp;
            }
        }

        /// <summary>把string 轉 Double ,小於0返回0,否則返回int值</summary>
        /// <param name="str"></param>
        /// <returns>返回>=0的int型</returns>
        public static double Cdbl0(object str)
        {
            return Cdbl0(str.ToString());
        }

        /// <summary>限制數值,不得少於 iMin ,比如分頁數,不能少於 1</summary>
        /// <param name="str"></param>
        /// <param name="iMin"></param>
        /// <returns></returns>
        /// 
        public static int MinInt(int str, int iMin)
        {
            if (str < iMin)
            {
                return iMin;
            }
            else
            {
                return str;
            }
        }
        /// <summary>限制數值,不得少於 iMin ,比如分頁數,不能少於 1</summary>
        /// <param name="str"></param>
        /// <param name="iMin"></param>
        /// <returns></returns>
        public static double MinDbl(double str, double iMin)
        {
            if (str < iMin)
            {
                return iMin;
            }
            else
            {
                return str;
            }
        }

        /// <summary>限制數值,不得少於 iMin ,比如分頁數,不能少於 1</summary>
        /// <param name="str"></param>
        /// <param name="iMin"></param>
        /// <returns></returns>
        public static double MinDbl(object str, double iMin)
        {
            if (str != null)
            {
                return MinDbl(Cdbl(str.ToString()), iMin);
            }
            return iMin;
        }

        #endregion

        #region byts轉換
        /// <summary>字符串轉為Btye類型
        /// </summary>
        /// <param name="str">字符串值</param>
        /// <param name="value">值，請輸入0或1</param>
        /// <returns>byte值</returns>
        public static byte StringToByte(String str, int value = 0)
        {
            try
            {
                return byte.Parse(str);
            }
            catch (Exception)
            {
                return (byte)value;
            }
        }

        /// <summary>將String 轉為 byte[] </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string str)
        {
            //return Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>將byte[] 轉為  String</summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteArrayToString(byte[] bytes)
        {
            //return .Encoding.Default.GetString(bytes);
            return Encoding.UTF8.GetString(bytes);
        }


        /// <summary>將Hex String 轉為 byte[] </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>將byte[] 轉為 Hex String</summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            int b;
            for (int i = 0; i < bytes.Length; i++)
            {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c);
        }

        /*
        /// <summary>將byte[] 轉為 Hex String（和上面的函數相比這個性能會慢一些，但是它是官方函數）</summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString2(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes); 
            return hex.Replace("-", "");
        }
        */
        #endregion
    }
}
