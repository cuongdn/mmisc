using System;
using System.Linq.Expressions;

namespace RepositoryPattern.Infrastructure
{
    public interface IFilterObject<T>
    {
        Expression<Func<T, bool>> Expr();
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> expression);
        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> expression);
        Expression<Func<T, bool>> And(IFilterObject<T> filterObject);
        Expression<Func<T, bool>> Or(IFilterObject<T> filterObject);
        Expression<Func<T, bool>> And(string expression, params object[] values);
        Expression<Func<T, bool>> Or(string expression, params object[] values);
    }
}