/// <summary>
/// 類說明：Assistant
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>


namespace DotNet.Utilities
{
    /// <summary>
    /// This class contains the Positive and Negative starting response strings
    /// that can be returned from a Pop3 server.
    /// </summary>
    internal static class Pop3Responses
    {
        /// <summary>
        /// The +OK starting of a positive response from the server.
        /// </summary>
        internal const string Ok = "+OK";

        /// <summary>
        /// The -ERR starting of a negative response from the server.
        /// </summary>
        internal const string Err = "-ERR";
    }
}
