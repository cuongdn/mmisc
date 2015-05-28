using System;
using System.Collections.Specialized;
using System.Runtime.Caching;

namespace Core.Caching
{
    public class MemoryCacheManager : ICacheManager
    {
        private MemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            CreateNewCache();
        }

        public void Add(string key, object value)
        {
            Add(key, value, EDataValidity.ShortLiving);
        }

        public bool Contains(string key)
        {
            return _memoryCache.Contains(key);
        }

        public void Clear()
        {
            var cache = _memoryCache;
            CreateNewCache();
            cache.Dispose();
            GC.Collect();
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public T Get<T>(string key)
        {
            return (T)_memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Add(string key, object value, EDataValidity dataValidity)
        {
            if (string.IsNullOrEmpty(key) || value == null) return;

            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.Default
            };
            switch (dataValidity)
            {
                case EDataValidity.ShortLiving:
                    policy.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(5.0));
                    break;

                case EDataValidity.NormalBusiness:
                    policy.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddHours(1.0));
                    break;

                case EDataValidity.StaticReference:
                    policy.AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddHours(4.0));
                    break;
            }
            _memoryCache.Add(key, value, policy);
        }

        private void CreateNewCache()
        {
            var config = new NameValueCollection
            {
                {"cacheMemoryLimitMegabytes", "15"},
                {"physicalMemoryLimitPercentage", "0"},
                {"pollingInterval", "00:02:00"}
            };
            _memoryCache = new MemoryCache(Guid.NewGuid().ToString(), config);
        }
    }
}