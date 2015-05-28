using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Common.Infrastructure;
using Core.Common.Infrastructure.Paging;
using Core.Common.Infrastructure.Query;
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

        public async Task<IList<T>> ListAsync()
        {
            return await ExecuteQuery().ToListAsync();
        }

        public async Task<List<TResult>> ListAsync<TResult>(Expression<Func<T, TResult>> selector)
        {
            return await ExecuteQuery().Select(selector).ToListAsync();
        }

        public async Task<List<T>> TopAsync(int take, int skip)
        {
            return await ExecuteQueryTop(skip, take).ToListAsync();
        }

        public async Task<IList<T>> TopAsync(int take)
        {
            return await TopAsync(0, take);
        }

        public async Task<List<TResult>> TopAsync<TResult>(int take, int skip, Expression<Func<T, TResult>> selector)
        {
            return await ExecuteQueryTop(skip, take).Select(selector).ToListAsync();
        }

        public async Task<List<TResult>> TopAsync<TResult>(int take, Expression<Func<T, TResult>> selector)
        {
            return await TopAsync(0, take, selector);
        }

        public async Task<IPagedList<T>> PagedAsync(int page, int pageSize)
        {
            int totalRecords;
            var query = ExecuteQueryPage(page, pageSize, out totalRecords);
            return await new Task<IPagedList<T>>(() =>
            {
                var list = query == null ? new List<T>() : query.ToListAsync().Result;
                return new PagedList<T>(list, page, pageSize, totalRecords);
            });
        }

        public async Task<IPagedList<TResult>> PagedAsync<TResult>(int page, int pageSize, Expression<Func<T, TResult>> selector)
        {
            int totalRecords;
            var query = ExecuteQueryPage(page, pageSize, out totalRecords);
            return await new Task<IPagedList<TResult>>(() =>
            {
                var list = query == null ? new List<TResult>() : query.Select(selector).ToListAsync().Result;
                return new PagedList<TResult>(list, page, pageSize, totalRecords);
            });
        }

        public IList<T> List()
        {
            return ExecuteQuery().ToList();
        }

        public IList<TResult> List<TResult>(Expression<Func<T, TResult>> selector)
        {
            return ExecuteQuery().Select(selector).ToList();
        }

        public IList<T> Top(int take, int skip)
        {
            return ExecuteQueryTop(skip, take).ToList();
        }

        public IList<T> Top(int take)
        {
            return Top(0, take);
        }

        public IList<TResult> Top<TResult>(int take, int skip, Expression<Func<T, TResult>> selector)
        {
            return ExecuteQueryTop(skip, take).Select(selector).ToList();
        }

        public IList<TResult> Top<TResult>(int take, Expression<Func<T, TResult>> selector)
        {
            return Top(0, take, selector);
        }

        public IList<T> Paged(int page, int pageSize, out int totalRecords)
        {
            var query = ExecuteQueryPage(page, pageSize, out totalRecords);
            return query == null ? new List<T>() : query.ToList();
        }

        public IList<TResult> Paged<TResult>(int page, int pageSize, out int totalRecords,
            Expression<Func<T, TResult>> selector)
        {
            var query = ExecuteQueryPage(page, pageSize, out totalRecords);
            if (query == null)
                return new List<TResult>();
            return query.Select(selector).ToList();
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
            _orderBy = string.IsNullOrWhiteSpace(_orderBy) ? _defaultOrderBy : _orderBy;
            if (string.IsNullOrWhiteSpace(_orderBy))
            {
                throw new NullReferenceException("OrderBy");
            }
        }
    }
}