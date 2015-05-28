namespace Core.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value);
        void Add(string key, object value, EDataValidity dataValidity);
        bool Contains(string key);
        void Clear();
        object Get(string key);
        T Get<T>(string key);
        void Remove(string key);
    }
}