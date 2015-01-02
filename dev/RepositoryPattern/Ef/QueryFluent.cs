using RepositoryPattern.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Utilities.PagedList;

namespace RepositoryPattern.Ef
{
    public sealed class QueryFluent<TEntity> : IQueryFluent<TEntity> where TEntity : class, IObjectState
    {
        private readonly List<Expression<Func<TEntity, object>>> _includes;
        private readonly Repository<TEntity> _repository;
        private readonly Filter<TEntity> _filter;
        private Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> _orderBy;
        public QueryFluent(Repository<TEntity> repository)
        {
            _repository = repository;
            _includes = new List<Expression<Func<TEntity, object>>>();
            _filter = Filter<TEntity>.New();
        }
        public IQueryFluent<TEntity> Filter(IFilterObject<TEntity> filterObject)
        {
            _filter.And(filterObject);
            return this;
        }
        public IQueryFluent<TEntity> Filter(Expression<Func<TEntity, bool>> expression)
        {
            _filter.And(expression);
            return this;
        }
        public IQueryFluent<TEntity> Filter(string expression, params object[] values)
        {
            _filter.And(expression, values);
            return this;
        }
        public IQueryFluent<TEntity> OrderBy(string orderBy)
        {
            _orderBy = query => query.OrderBy(orderBy) as IOrderedQueryable<TEntity>;
            return this;
        }
        public IQueryFluent<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            _orderBy = orderBy;
            return this;
        }
        public IQueryFluent<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector, bool descending = false)
        {
            if (descending)
            {
                _orderBy = query => query.OrderByDescending(keySelector);
            }
            else
            {
                _orderBy = query => query.OrderBy(keySelector);
            }
            return this;
        }
        public IQueryFluent<TEntity> Include(Expression<Func<TEntity, object>> expression)
        {
            _includes.Add(expression);
            return this;
        }
        public IPagedList<TEntity> Select(int page, int pageSize)
        {
            var expression = _filter.Expr();
            var totalCount = Count(expression);
            if (totalCount == 0)
            {
                return new PagedList<TEntity>();
            }
            var list = _repository.Select(expression, _orderBy, _includes, page, pageSize).ToList();
            return new PagedList<TEntity>(list, page, pageSize, totalCount);
        }
        public IPagedList<TResult> Select<TResult>(int page, int pageSize, Expression<Func<TEntity, TResult>> selector)
        {
            var expression = _filter.Expr();
            var totalCount = Count(expression);
            if (totalCount == 0)
            {
                return new PagedList<TResult>();
            }
            var list = _repository.Select(expression, _orderBy, _includes, page, pageSize).Select(selector).ToList();
            return new PagedList<TResult>(list, page, pageSize, totalCount);
        }
        private int Count(Expression<Func<TEntity, bool>> expression)
        {
            return expression == null ? _repository.Queryable().Count() : _repository.Select(expression).Count();
        }
        public IList<TEntity> Select()
        {
            return _repository.Select(_filter.Expr(), _orderBy, _includes).ToList();
        }
        public IList<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _repository.Select(_filter.Expr(), _orderBy, _includes).Select(selector).ToList();
        }
        public async Task<IList<TEntity>> SelectAsync()
        {
            return await _repository.SelectAsync(_filter.Expr(), _orderBy, _includes);
        }
        public async Task<IList<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return await _repository.SelectAsync(selector, _filter.Expr(), _orderBy, _includes);
        }
        public async Task<IList<TEntity>> SelectAsync(int page, int pageSize)
        {
            return await _repository.SelectAsync(_filter.Expr(), _orderBy, _includes, page, pageSize);
        }
        public async Task<IList<TResult>> SelectAsync<TResult>(int page, int pageSize, Expression<Func<TEntity, TResult>> selector)
        {
            return await _repository.SelectAsync(selector, _filter.Expr(), _orderBy, _includes, page, pageSize);
        }
        public IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            return _repository.SqlQuery(query, parameters).AsQueryable();
        }
    }
}