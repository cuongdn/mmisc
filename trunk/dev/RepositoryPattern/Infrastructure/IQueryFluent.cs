using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utilities.PagedList;

namespace RepositoryPattern.Infrastructure
{
    public interface IQueryFluent<TEntity> where TEntity : IObjectState
    {
        IQueryFluent<TEntity> OrderBy(string orderBy);
        IQueryFluent<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IQueryFluent<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector, bool descending = false);
        IQueryFluent<TEntity> Include(Expression<Func<TEntity, object>> expression);
        IPagedList<TEntity> Select(int page, int pageSize);
        IList<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector = null);
        IList<TEntity> Select();
        Task<IList<TEntity>> SelectAsync();
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);
        IQueryFluent<TEntity> Filter(IFilterObject<TEntity> filterObject);
        IQueryFluent<TEntity> Filter(Expression<Func<TEntity, bool>> expression);
        IQueryFluent<TEntity> Filter(string expression, params object[] values);
        IPagedList<TResult> Select<TResult>(int page, int pageSize, Expression<Func<TEntity, TResult>> selector);
        Task<IList<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector);
        Task<IList<TEntity>> SelectAsync(int page, int pageSize);
        Task<IList<TResult>> SelectAsync<TResult>(int page, int pageSize, Expression<Func<TEntity, TResult>> selector);
    }
}