
namespace Core.Caching
{
    public static class CacheFactory
    {
        private static ICacheManager _cacheManager;

        public static ICacheManager Current
        {
            get { return _cacheManager ?? (_cacheManager = new MemoryCacheManager()); }
        }

        public static void Set(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public static bool HasCacheManager
        {
            get { return _cacheManager != null; }
        }
    }
}
