/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Text.RegularExpressions;

namespace DotNet.Utilities
{
    /// <summary>
    /// 操作正則表達式的公共類
    /// </summary>    
    public class RegexHelper
    {
        #region 驗證輸入字符串是否與模式字符串匹配
        /// <summary>
        /// 驗證輸入字符串是否與模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">輸入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 驗證輸入字符串是否與模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">輸入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">篩選條件</param>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        #endregion
    }
}
