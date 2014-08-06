using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// Query object supports AND, OR
    /// </summary>
    public interface IQueryObject<T>
    {
        Expression<Func<T, bool>> Query();
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> And(IQueryObject<T> queryObject);
        Expression<Func<T, bool>> Or(IQueryObject<T> queryObject);
        Expression<Func<T, bool>> And(string expression, params object[] values);
        Expression<Func<T, bool>> Or(string expression, params object[] values);
    }
}