/// <summary>
///  说梅愫乻sistant
/// ?犅??愫嬚飞?/// j系缃婍：361983679  
/// 杓惵嶈暰愫╰tp://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web;

namespace DotNet.Utilities
{
	/// <summary>
	/// 牒存???操楃�?
	/// </summary>
	public class DataCache
	{
		/// <summary>
		/// 氡堘当前应??愨柛妯僡cheKey?僡che值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// 扫?灞囉τ冦??告?acheKey?僡che值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

		/// <summary>
		/// 扫?灞囉τ冦??告?acheKey?僡che值
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
