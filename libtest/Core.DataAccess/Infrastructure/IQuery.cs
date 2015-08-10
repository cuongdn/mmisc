using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Common.Infrastructure.Paging;
using Core.DataAccess.Entities;

namespace Core.DataAccess.Infrastructure
{
    public interface IQuery<T> where T : EntityBase
    {
        IList<T> List();
        IList<TResult> List<TResult>(Expression<Func<T, TResult>> selector);
        IList<T> Top(int take, int skip);
        IList<T> Top(int take);
        IList<TResult> Top<TResult>(int take, int skip, Expression<Func<T, TResult>> selector);
        IList<TResult> Top<TResult>(int take, Expression<Func<T, TResult>> selector);
        IList<T> Paged(int page, int pageSize, out int totalRecords);
        IList<TResult> Paged<TResult>(int page, int pageSize, out int totalRecords, Expression<Func<T, TResult>> selector);
        IPagedList<T> Paged(int page, int pageSize);
        IPagedList<TResult> Paged<TResult>(int page, int pageSize, Expression<Func<T, TResult>> selector);
    }
}