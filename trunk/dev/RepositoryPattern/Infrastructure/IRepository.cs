using System.Collections.Generic;
using System.Linq;
using System.Web.Http.OData.Query;

namespace RepositoryPattern.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : IObjectState
    {
        TEntity Find(params object[] keyValues);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void InsertOrUpdateGraph(TEntity entity);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);
        IQueryFluent<TEntity> Query();
        IQueryable<TEntity> Queryable();
        IQueryable ODataQueryable(ODataQueryOptions<TEntity> oDataQueryOptions);
        IRepository<T> GetRepository<T>() where T : class, IObjectState;
    }
}