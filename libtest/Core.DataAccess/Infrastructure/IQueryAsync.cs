using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Common.Infrastructure.Paging;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Infrastructure
{
    public interface IQueryAsync<T> where T : EntityBase
    {
        Task<IList<T>> ListAsync();
        Task<List<TResult>> ListAsync<TResult>(Expression<Func<T, TResult>> selector);
        Task<List<T>> TopAsync(int take, int skip);
        Task<IList<T>> TopAsync(int take);
        Task<List<TResult>> TopAsync<TResult>(int take, int skip, Expression<Func<T, TResult>> selector);
        Task<List<TResult>> TopAsync<TResult>(int take, Expression<Func<T, TResult>> selector);
        Task<IPagedList<T>> PagedAsync(int page, int pageSize);
        Task<IPagedList<TResult>> PagedAsync<TResult>(int page, int pageSize, Expression<Func<T, TResult>> selector);
    }
}