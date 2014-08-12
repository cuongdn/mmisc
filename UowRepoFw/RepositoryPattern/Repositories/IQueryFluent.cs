﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RepositoryPattern.Infrastructure;

namespace RepositoryPattern.Repositories
{
    public interface IQueryFluent<TEntity> where TEntity : IObjectState
    {
        IQueryFluent<TEntity> OrderBy(string orderBy);
        IQueryFluent<TEntity> OrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IQueryFluent<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        IQueryFluent<TEntity> Include(Expression<Func<TEntity, object>> expression);
        IEnumerable<TEntity> SelectPage(int page, int pageSize, out int totalCount);
        IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector = null);
        IEnumerable<TEntity> Select();
        Task<IEnumerable<TEntity>> SelectAsync();
        IQueryable<TEntity> SqlQuery(string query, params object[] parameters);
    }
}