using LinqKit;
using System;
using System.Linq.Expressions;

namespace Core
{
    public class QueryObject<T> : IQueryObject<T>
    {
        private Expression<Func<T, bool>> _query;

        public QueryObject()
        {
            _query = PredicateBuilder.True<T>();
        }

        public QueryObject(Expression<Func<T, bool>> query)
        {
            _query = query;
        }
        public virtual Expression<Func<T, bool>> Query()
        {
            return _query.Expand();
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> query)
        {
            _query = _query.And(query);
            return _query;
        }
        public Expression<Func<T, bool>> And(string expression, params object[] values)
        {
            var e = System.Linq.Dynamic.DynamicExpression.ParseLambda<T, bool>(expression, values);
            return And(e);
        }
        public Expression<Func<T, bool>> And(IQueryObject<T> queryObject)
        {
            return And(queryObject.Query());
        }

        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query)
        {
            _query = _query.Or(query);
            return _query;
        }
        public Expression<Func<T, bool>> Or(IQueryObject<T> queryObject)
        {
            return Or(queryObject.Query());
        }
        public Expression<Func<T, bool>> Or(string expression, params object[] values)
        {
            var e = System.Linq.Dynamic.DynamicExpression.ParseLambda<T, bool>(expression, values);
            return Or(e);
        }

    }
}