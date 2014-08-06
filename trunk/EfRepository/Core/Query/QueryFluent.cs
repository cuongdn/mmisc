using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Core
{
    public class QueryFluent<T> : IQueryFluent<T>
    {
        private string _orderBy;
        private readonly QueryObject<T> _filter;
        private readonly List<Expression<Func<T, object>>> _includes;
        private readonly IRepository<T> _repository;

        public QueryFluent(IRepository<T> repository)
        {
            _repository = repository;
            _includes = new List<Expression<Func<T, object>>>();
            _filter = new QueryObject<T>();
        }

        public QueryFluent<T> Include(Expression<Func<T, object>> expression)
        {
            _includes.Add(expression);
            return this;
        }
        public QueryFluent<T> Filter(IQueryObject<T> queryObject)
        {
            _filter.And(queryObject);
            return this;
        }

        public QueryFluent<T> Filter(Expression<Func<T, bool>> expression)
        {
            _filter.And(expression);
            return this;
        }

        public QueryFluent<T> Filter(string expression, params object[] values)
        {
            _filter.And(expression, values);
            return this;
        }

        public QueryFluent<T> OrderBy(string orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public IEnumerable<T> Select()
        {
            return QuerySelect().ToList();
        }
        public IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            return QuerySelect().Select(selector);
        }
        public IEnumerable<T> SelectTop(int take, int skip)
        {
            return QueryTop(skip, take).ToList();
        }
        public IEnumerable<T> SelectTop(int take)
        {
            return SelectTop(0, take);
        }
        public IEnumerable<TResult> SelectTop<TResult>(int take, int skip, Expression<Func<T, TResult>> selector)
        {
            return QueryTop(skip, take).Select(selector);
        }
        public IEnumerable<TResult> SelectTop<TResult>(int take, Expression<Func<T, TResult>> selector)
        {
            return QueryTop(0, take).Select(selector);
        }
        public IEnumerable<T> SelectPage(int page, int pageSize, out int totalRecords)
        {
            var query = QueryPage(page, pageSize, out totalRecords);
            if (query == null)
                return new List<T>();
            return query.ToList();
        }
        public IEnumerable<TResult> SelectPage<TResult>(int page, int pageSize, out int totalRecords, Expression<Func<T, TResult>> selector)
        {
            var query = QueryPage(page, pageSize, out totalRecords);
            if (query == null)
                return new List<TResult>();
            return query.Select(selector);
        }

        public IPagedList<T> SelectPage(int page, int pageSize)
        {
            var totalRecords = 0;
            var list = SelectPage(page, pageSize, out totalRecords);
            return new PagedList<T>(list, page, pageSize, totalRecords);
        }

        public IPagedList<TResult> SelectPage<TResult>(int page, int pageSize, Expression<Func<T, TResult>> selector)
        {
            var totalRecords = 0;
            var list = SelectPage(page, pageSize, out totalRecords, selector);
            return new PagedList<TResult>(list, page, pageSize, totalRecords);
        }
        private IQueryable<T> QueryPage(int page, int pageSize, out int totalRecords)
        {
            CheckOrderBy();
            var query = _repository.Queryable();
            AppendFilter(ref query);
            totalRecords = query.Count();
            if (totalRecords == 0)
                return null;

            AppendInclude(ref query);
            query = query.OrderBy(_orderBy)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);

            return query;
        }

        private IQueryable<T> QueryTop(int skip, int take)
        {
            CheckOrderBy();
            var query = _repository.Queryable();
            AppendFilter(ref query);
            AppendInclude(ref query);
            query = query.OrderBy(_orderBy)
                        .Skip(skip)
                        .Take(take);
            return query;
        }
        private IQueryable<T> QuerySelect()
        {
            var query = _repository.Queryable();
            AppendFilter(ref query);
            AppendInclude(ref query);
            if (!String.IsNullOrWhiteSpace(_orderBy))
                query = query.OrderBy(_orderBy);
            return query;
        }
        private void AppendInclude(ref IQueryable<T> query)
        {
            if (_includes.Count > 0)
                query = _includes.Aggregate(query, (current, include) => current.Include(include));
        }
        private void AppendFilter(ref IQueryable<T> query)
        {
            query = query.Where(_filter.Query());
        }
        private void CheckOrderBy()
        {
            if (String.IsNullOrWhiteSpace(_orderBy))
                throw new ArgumentNullException("OrderBy");
        }


    }
}
