using RepositoryPattern.Infrastructure;
using System;
using System.Linq.Expressions;

namespace RepositoryPattern.Ef
{
    public class Filter<T>
    {
        internal static Filter<T> New()
        {
            return new Filter<T>();
        }
        public static Filter<T> Add(Expression<Func<T, bool>> expression)
        {
            return new Filter<T>(expression);
        }
        public IFilterObject<T> FilterObject { get; private set; }
        private Filter()
        {
            FilterObject = new FilterObject<T>();
        }
        private Filter(Expression<Func<T, bool>> expression)
        {
            FilterObject = new FilterObject<T>(expression);
        }
        public Expression<Func<T, bool>> Expr()
        {
            return FilterObject.Expr();
        }
        public Filter<T> And(Expression<Func<T, bool>> expression)
        {
            FilterObject.And(expression);
            return this;
        }
        public Filter<T> And(string expression, params object[] values)
        {
            FilterObject.And(expression, values);
            return this;
        }
        public Filter<T> And(IFilterObject<T> filterObject)
        {
            FilterObject.And(filterObject);
            return this;
        }
        public Filter<T> Or(Expression<Func<T, bool>> expression)
        {
            FilterObject.Or(expression);
            return this;
        }
        public Filter<T> Or(string expression, params object[] values)
        {
            FilterObject.Or(expression, values);
            return this;
        }
        public Filter<T> Or(IFilterObject<T> filterObject)
        {
            FilterObject.Or(filterObject);
            return this;
        }
    }
}