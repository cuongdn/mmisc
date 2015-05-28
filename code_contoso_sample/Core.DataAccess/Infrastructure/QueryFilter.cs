using System;
using System.Linq.Expressions;

namespace Core.DataAccess.Infrastructure
{
    public class QueryFilter<T>
    {
        private readonly QueryObject<T> _queryObject;

        private QueryFilter(Expression<Func<T, bool>> query)
        {
            _queryObject = new QueryObject<T>(query);
        }

        public QueryObject<T> QueryObject()
        {
            return _queryObject;
        }

        public Expression<Func<T, bool>> Expression()
        {
            return _queryObject.Expression();
        }

        public QueryFilter<T> And(Expression<Func<T, bool>> query)
        {
            _queryObject.And(query);
            return this;
        }

        public QueryFilter<T> And(string expression, params object[] values)
        {
            _queryObject.And(expression, values);
            return this;
        }

        public QueryFilter<T> And(QueryObject<T> queryObject)
        {
            _queryObject.And(queryObject);
            return this;
        }

        public QueryFilter<T> Or(Expression<Func<T, bool>> query)
        {
            _queryObject.Or(query);
            return this;
        }

        public QueryFilter<T> Or(string expression, params object[] values)
        {
            _queryObject.Or(expression, values);
            return this;
        }

        public QueryFilter<T> Or(QueryObject<T> queryObject)
        {
            _queryObject.Or(queryObject);
            return this;
        }

        public static QueryFilter<T> Where(Expression<Func<T, bool>> query)
        {
            return new QueryFilter<T>(query);
        }
    }
}