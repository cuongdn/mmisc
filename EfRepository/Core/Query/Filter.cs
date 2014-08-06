using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// Filter fluent API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Filter<T>
    {
        public static Filter<T> Add(Expression<Func<T, bool>> query)
        {
            return new Filter<T>(query);
        }

        private readonly IQueryObject<T> _queryObject;

        private Filter(Expression<Func<T, bool>> query)
        {
            _queryObject = new QueryObject<T>(query);
        }
        public IQueryObject<T> QueryObject()
        {
            return _queryObject;
        }
        public Expression<Func<T, bool>> Query()
        {
            return _queryObject.Query();
        }
        public Filter<T> And(Expression<Func<T, bool>> query)
        {
            _queryObject.And(query);
            return this;
        }
        public Filter<T> And(string expression, params object[] values)
        {
            _queryObject.And(expression, values);
            return this;
        }
        public Filter<T> And(IQueryObject<T> queryObject)
        {
            _queryObject.And(queryObject);
            return this;
        }

        public Filter<T> Or(Expression<Func<T, bool>> query)
        {
            _queryObject.Or(query);
            return this;
        }
        public Filter<T> Or(string expression, params object[] values)
        {
            _queryObject.Or(expression, values);
            return this;
        }
        public Filter<T> Or(IQueryObject<T> queryObject)
        {
            _queryObject.Or(queryObject);
            return this;
        }
    }
}