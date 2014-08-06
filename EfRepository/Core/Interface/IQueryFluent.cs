using Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// Query fluent API used for repository query
    /// </summary>
    public interface IQueryFluent<T>
    {
        /// <summary>
        /// Include properties
        /// </summary>
        QueryFluent<T> Include(Expression<Func<T, object>> expression);
        /// <summary>
        /// Filter using Linq Expression
        /// </summary>
        QueryFluent<T> Filter(Expression<Func<T, bool>> expression);
        /// <summary>
        /// Filter using Dynamic Linq
        /// </summary>
        QueryFluent<T> Filter(string expression, params object[] values);
        /// <summary>
        /// Filter using Query Object
        /// </summary>
        QueryFluent<T> Filter(IQueryObject<T> queryObject);
        /// <summary>
        /// Sort order using Dynamic Linq. Must provide it if need to select page
        /// </summary>
        /// <param name="orderBy">Comma separated Order By. e.g: "FirstName, Id desc"</param>
        QueryFluent<T> OrderBy(string orderBy);
        /// <summary>
        /// Make query
        /// </summary>
        IEnumerable<T> Select();
        /// <summary>
        /// Custom selector
        /// </summary>
        IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector);
        /// <summary>
        /// Skip records and select top (no count result)
        /// </summary>
        IEnumerable<T> SelectTop(int take, int skip);
        /// <summary>
        /// Select top (no count result)
        /// </summary>
        IEnumerable<T> SelectTop(int take);
        /// <summary>
        /// Select top with custom selector
        /// </summary>
        IEnumerable<TResult> SelectTop<TResult>(int take, int skip, Expression<Func<T, TResult>> selector);
        /// <summary>
        /// Select top with custom selector
        /// </summary>
        IEnumerable<TResult> SelectTop<TResult>(int take, Expression<Func<T, TResult>> selector);
        /// <summary>
        /// Select page
        /// </summary>
        IEnumerable<T> SelectPage(int page, int pageSize, out int totalRecords);
        /// <summary>
        /// Select page with custom selector
        /// </summary>
        IEnumerable<TResult> SelectPage<TResult>(int page, int pageSize, out int totalRecords, Expression<Func<T, TResult>> selector);
        /// <summary>
        /// Select page and return IPagedList
        /// </summary>
        IPagedList<T> SelectPage(int page, int pageSize);
        /// <summary>
        /// Select page with custom selector and return IPagedList
        /// </summary>
        IPagedList<TResult> SelectPage<TResult>(int page, int pageSize, Expression<Func<T, TResult>> selector);
    }
}