using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Web;


namespace Common.Cache
{
    public class Cache : ICache
    {
        private static IOptions<MemoryCacheOptions> cacheOptions = new OptionsWrapper<MemoryCacheOptions>(new MemoryCacheOptions());
        private static MemoryCache cache = new MemoryCache(cacheOptions);


        public T? GetCache<T>(string cacheKey) where T : class
        {
            if (!cache.TryGetValue<T>(cacheKey, out var value))
            {
                return default;

            }
            return value;
        }
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            WriteCache<T>(value, cacheKey, DateTime.Now.AddMinutes(10));
        }
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            cache.CreateEntry(cacheKey)
                .SetAbsoluteExpiration(expireTime)
                .SetSlidingExpiration(TimeSpan.Zero)
                .SetValue(value);
        }
        public void RemoveCache(string cacheKey)
        {
            cache.Remove(cacheKey);
        }
        public void RemoveCache()
        {
            cache.Dispose();
            cache = new MemoryCache(cacheOptions);
        }
    }
}
