using LinqKit;
using RepositoryPattern.Infrastructure;
using System;
using System.Linq.Expressions;

namespace RepositoryPattern.Ef
{
    public class FilterObject<T> : IFilterObject<T>
    {
        private Expression<Func<T, bool>> _expression;
        public FilterObject()
        {
            _expression = PredicateBuilder.True<T>();
        }
        public FilterObject(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }
        public Expression<Func<T, bool>> Expr()
        {
            return _expression.Expand();
        }
        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> expression)
        {
            _expression = _expression.And(expression);
            return _expression;
        }
        public Expression<Func<T, bool>> And(string expression, params object[] values)
        {
            var e = System.Linq.Dynamic.DynamicExpression.ParseLambda<T, bool>(expression, values);
            return And(e);
        }
        public Expression<Func<T, bool>> And(IFilterObject<T> filterObject)
        {
            return And(filterObject.Expr());
        }
        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> expression)
        {
            _expression = _expression.Or(expression);
            return _expression;
        }
        public Expression<Func<T, bool>> Or(IFilterObject<T> filterObject)
        {
            return Or(filterObject.Expr());
        }
        public Expression<Func<T, bool>> Or(string expression, params object[] values)
        {
            return Or(System.Linq.Dynamic.DynamicExpression.ParseLambda<T, bool>(expression, values));
        }
    }
}