using System;
using System.Linq.Expressions;
using Core.Common.Infrastructure.Query;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Infrastructure
{
    public interface IQueryFluent<T> : IQuery<T>, IQueryAsync<T> where T : EntityBase
    {
        IQueryFluent<T> Include(Expression<Func<T, object>> expression);
        IQueryFluent<T> Where(QueryObject<T> queryObject);
        IQueryFluent<T> Where(Expression<Func<T, bool>> expression);
        IQueryFluent<T> Where(string expression, params object[] values);
        IQueryFluent<T> OrderBy(string orderBy);
    }
}