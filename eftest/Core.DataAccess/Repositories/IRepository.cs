using Core.DataAccess.Entities;
using Core.DataAccess.Infrastructure;

namespace Core.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(params object[] keyValues);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        QueryFluent<T> Query();
    }
}