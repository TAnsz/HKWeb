/// <summary>
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>

using System;

namespace DotNet.Utilities
{
	/// <summary>
    /// BaseRandom
	/// 產生隨機數
	/// 
	/// 隨機數管理，最大值、最小值可以自己進行設定。
	/// </summary>
	public class BaseRandom
	{
		public static int Minimum = 100000;
        public static int Maximal = 999999;
        public static int RandomLength = 6;

        private static string RandomString = "0123456789ABCDEFGHIJKMLNOPQRSTUVWXYZ";
        private static Random Random = new Random(DateTime.Now.Second);

        #region public static string GetRandomString() 產生隨機字符
        /// <summary>
        /// 產生隨機字符
        /// </summary>
        /// <returns>字符串</returns>
        public static string GetRandomString()
        {
            string returnValue = string.Empty;
            for (int i = 0; i < RandomLength; i++)
            {
                int r = Random.Next(0, RandomString.Length - 1);
                returnValue += RandomString[r];
            }
            return returnValue;
        }
        #endregion

        #region public static int GetRandom()
        /// <summary>
        /// 產生隨機數
        /// </summary>
        /// <returns>隨機數</returns>
        public static int GetRandom()
		{
			return Random.Next(Minimum, Maximal);
		}
		#endregion

        #region public static int GetRandom(int minimum, int maximal)
        /// <summary>
		/// 產生隨機數
		/// </summary>
		/// <param name="minimum">最小值</param>
		/// <param name="maximal">最大值</param>
		/// <returns>隨機數</returns>
        public static int GetRandom(int minimum, int maximal)
		{
            return Random.Next(minimum, maximal);
		}
		#endregion
	}
}