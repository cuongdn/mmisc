using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData.Query;

namespace RepositoryPattern.Infrastructure
{
    public interface IService<TEntity> where TEntity : IObjectState
    {
        TEntity Find(params object[] keyValues);
        SingleResult<TEntity> GetSingleResult(params object[] keyValues);
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void InsertGraph(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IQueryFluent<TEntity> Query();
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        IQueryable<TEntity> Queryable();
        IQueryable ODataQueryable(ODataQueryOptions<TEntity> oDataQueryOptions);
    }
}