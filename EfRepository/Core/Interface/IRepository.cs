using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Repository, need Unit of Work to commit changes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        T Find(params object[] keyValues);
        void Add(T entity);
        void AddMany(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateMany(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteMany(IEnumerable<T> entities);

        IQueryable<T> Queryable();

        IQueryFluent<T> Query();
    }
}
