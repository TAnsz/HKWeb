/// <summary>
/// 類說明：CacheHelper
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Web;
using System.Collections;

namespace DotNet.Utilities
{
    public class CacheHelper
    {
        /// <summary>
        /// 獲取數據緩存
        /// </summary>
        /// <param name="CacheKey">鍵</param>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 設置數據緩存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 設置數據緩存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject, TimeSpan Timeout)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, DateTime.MaxValue, Timeout, System.Web.Caching.CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// 設置數據緩存
        /// </summary>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>清除單一鍵緩存</summary>
        /// <param name="cacheKey">緩存名稱</param>
        public static void RemoveOneCache(string cacheKey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            _cache.Remove(cacheKey);
        }

        /// <summary>
        /// 移除指定數據緩存
        /// </summary>
        public static void RemoveAllCache(string CacheKey)
        {
            RemoveOneCache(CacheKey);
        }

        /// <summary>
        /// 移除全部緩存
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }

        /// <summary>清除所有緩存</summary>
        public static void RemoveManagersAllCache()
        {
            try
            {
                System.Web.Caching.Cache objCache = HttpRuntime.Cache;
                IDictionaryEnumerator cacheEnum = objCache.GetEnumerator();
                if (objCache.Count > 0)
                {
                    var al = new ArrayList();
                    //設置後台在線列表緩存標識
                    const string ss = "OnlineUsers";
                    int keyLen = ss.Length;

                    while (cacheEnum.MoveNext())
                    {
                        //如果是後台在線列表相關緩存，則不進行刪除操作
                        if (StringHelper.Left(cacheEnum.Key.ToString(), keyLen) == ss)
                            continue;

                        al.Add(cacheEnum.Key);
                    }

                    foreach (string key in al)
                    {
                        objCache.Remove(key);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>以列表形式返回已存在的所有緩存</summary>
        /// <returns></returns> 
        public static ArrayList ShowAllCache()
        {
            var al = new ArrayList();
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            if (objCache.Count > 0)
            {
                IDictionaryEnumerator cacheEnum = objCache.GetEnumerator();
                while (cacheEnum.MoveNext())
                {
                    al.Add(cacheEnum.Key);
                }
            }
            return al;
        }
    }
}