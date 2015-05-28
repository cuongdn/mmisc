
namespace Core.Caching
{
    public class NoneCacheManager : ICacheManager
    {
        public void Add(string key, object value)
        {

        }

        public void Add(string key, object value, EDataValidity dataValidity)
        {

        }

        public bool Contains(string key)
        {
            return false;
        }

        public void Clear()
        {

        }

        public object Get(string key)
        {
            return null;
        }

        public T Get<T>(string key)
        {
            return default(T);
        }

        public void Remove(string key)
        {

        }
    }
}
