using LinqKit;
using System;
using System.Linq.Expressions;
using DynamicExpression = System.Linq.Dynamic.DynamicExpression;

namespace Core.DataAccess.Infrastructure
{
    public class QueryObject<T>
    {
        protected Expression<Func<T, bool>> PredicateExpr;

        public QueryObject()
        {
            PredicateExpr = PredicateBuilder.True<T>();
        }

        public QueryObject(Expression<Func<T, bool>> expr)
        {
            PredicateExpr = expr;
        }

        public Expression<Func<T, bool>> Expression()
        {
            return PredicateExpr.Expand();
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> expr)
        {
            PredicateExpr = PredicateExpr.And(expr);
            return PredicateExpr;
        }

        public Expression<Func<T, bool>> And(string expression, params object[] values)
        {
            var e = DynamicExpression.ParseLambda<T, bool>(expression, values);
            return And(e);
        }

        public Expression<Func<T, bool>> And(QueryObject<T> queryObject)
        {
            return And(queryObject.Expression());
        }

        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> expr)
        {
            PredicateExpr = PredicateExpr.Or(expr);
            return PredicateExpr;
        }

        public Expression<Func<T, bool>> Or(QueryObject<T> queryObject)
        {
            return Or(queryObject.Expression());
        }

        public Expression<Func<T, bool>> Or(string expression, params object[] values)
        {
            var e = DynamicExpression.ParseLambda<T, bool>(expression, values);
            return Or(e);
        }
    }
}