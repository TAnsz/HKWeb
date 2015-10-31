/// <summary>
///  ˵÷㺁ssistant
/// ᠠ« ȋ㺋շɍ
/// jϵ罊���361983679  
/// 輐蕾㺨ttp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web;

namespace DotNet.Utilities
{
	/// <summary>
	/// 뺴揠陣Ĳٗ瀠
	/// </summary>
	public class DataCache
	{
		/// <summary>
		/// 뱈ᵱǰӦӃ㌐▸樃acheKey儃acheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// ɨփ屇ӦӃ㌐▸樃acheKey儃acheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

		/// <summary>
		/// ɨփ屇ӦӃ㌐▸樃acheKey儃acheֵ
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration,TimeSpan slidingExpiration )
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject,null,absoluteExpiration,slidingExpiration);
		}
	}
}
