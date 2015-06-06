using System.Linq;
using System.Threading.Tasks;
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
        void AttachDelete(T entity);
        IQueryFluent<T> Query();
        IQueryable<T> Queryable();
        Task<T> GetAsync(params object[] keyValues);
    }
}