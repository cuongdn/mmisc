using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Core.Common.Infra.PagedList;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Infrastructure
{
    public class QueryFluent<T> where T : EntityBase
    {
        private readonly QueryObject<T> _filter;
        private readonly List<Expression<Func<T, object>>> _includes;
        private string _orderBy;
        private IQueryable<T> _query;
        private readonly string _defaultOrderBy;

        public QueryFluent(IQueryable<T> query, string defaultOrderBy = null)
        {
            _query = query;
            _defaultOrderBy = defaultOrderBy;
            _includes = new List<Expression<Func<T, object>>>();
            _filter = new QueryObject<T>();
        }

        public QueryFluent<T> Include(Expression<Func<T, object>> expression)
        {
            _includes.Add(expression);
            return this;
        }

        public QueryFluent<T> Where(QueryObject<T> queryObject)
        {
            _filter.And(queryObject);
            return this;
        }

        public QueryFluent<T> Where(Expression<Func<T, bool>> expression)
        {
            _filter.And(expression);
            return this;
        }

        public QueryFluent<T> Where(string expression, params object[] values)
        {
            _filter.And(expression, values);
            return this;
        }

        public QueryFluent<T> OrderBy(string orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public IEnumerable<T> List()
        {
            return ExecuteQuery().ToList();
        }

        public IEnumerable<TResult> List<TResult>(Expression<Func<T, TResult>> selector)
        {
            return ExecuteQuery().Select(selector);
        }

        public IEnumerable<T> Top(int take, int skip)
        {
            return ExecuteQueryTop(skip, take).ToList();
        }

        public IEnumerable<T> Top(int take)
        {
            return Top(0, take);
        }

        public IEnumerable<TResult> Top<TResult>(int take, int skip, Expression<Func<T, TResult>> selector)
        {
            return ExecuteQueryTop(skip, take).Select(selector);
        }

        public IEnumerable<TResult> Top<TResult>(int take, Expression<Func<T, TResult>> selector)
        {
            return ExecuteQueryTop(0, take).Select(selector);
        }

        public IEnumerable<T> Paged(int page, int pageSize, out int totalRecords)
        {
            var query = ExecuteQueryPage(page, pageSize, out totalRecords);
            return query == null ? new List<T>() : query.ToList();
        }

        public IEnumerable<TResult> Paged<TResult>(int page, int pageSize, out int totalRecords,
            Expression<Func<T, TResult>> selector)
        {
            var query = ExecuteQueryPage(page, pageSize, out totalRecords);
            if (query == null)
                return new List<TResult>();
            return query.Select(selector);
        }

        public IPagedList<T> Paged(int page, int pageSize)
        {
            int totalRecords;
            var list = Paged(page, pageSize, out totalRecords);
            return new PagedList<T>(list, page, pageSize, totalRecords);
        }

        public IPagedList<TResult> Paged<TResult>(int page, int pageSize, Expression<Func<T, TResult>> selector)
        {
            int totalRecords;
            var list = Paged(page, pageSize, out totalRecords, selector);
            return new PagedList<TResult>(list, page, pageSize, totalRecords);
        }

        private IQueryable<T> ExecuteQueryPage(int page, int pageSize, out int totalRecords)
        {
            EnsureOrderBy();
            AppendFilter();
            totalRecords = _query.Count();
            if (totalRecords == 0)
                return null;

            AppendInclude();
            return _query.OrderBy(_orderBy).Skip((page - 1) * pageSize).Take(pageSize);
        }

        private IQueryable<T> ExecuteQueryTop(int skip, int take)
        {
            EnsureOrderBy();
            AppendFilter();
            AppendInclude();
            return _query.OrderBy(_orderBy).Skip(skip).Take(take);
        }

        private IQueryable<T> ExecuteQuery()
        {
            AppendFilter();
            AppendInclude();
            if (!string.IsNullOrWhiteSpace(_orderBy))
                _query = _query.OrderBy(_orderBy);
            return _query;
        }

        private void AppendInclude()
        {
            if (_includes.Count > 0)
                _query = _includes.Aggregate(_query, (current, include) => current.Include(include));
        }

        private void AppendFilter()
        {
            _query = _query.Where(_filter.Expression());
        }

        private void EnsureOrderBy()
        {
            _orderBy = _orderBy ?? _defaultOrderBy;
            if (string.IsNullOrWhiteSpace(_orderBy))
            {
                throw new NullReferenceException("OrderBy");
            }
        }
    }
}