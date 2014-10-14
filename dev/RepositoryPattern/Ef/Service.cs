﻿using RepositoryPattern.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData.Query;

namespace RepositoryPattern.Ef
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : IObjectState
    {
        #region Private Fields

        private readonly IRepositoryAsync<TEntity> _repository;

        #endregion Private Fields

        #region Constructor

        protected Service(IRepositoryAsync<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion Constructor

        public virtual TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }
        public SingleResult<TEntity> GetSingleResult(params object[] keyValues)
        {
            return SingleResult.Create((new List<TEntity> {Find(keyValues)}).AsQueryable());
        }

        public virtual IQueryable<TEntity> SqlQuery(string query, params object[] parameters)
        {
            return _repository.SqlQuery(query, parameters).AsQueryable();
        }

        public virtual void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _repository.InsertRange(entities);
        }

        public virtual void InsertGraph(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            _repository.InsertGraphRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(object id)
        {
            _repository.Delete(id);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public IQueryFluent<TEntity> Query()
        {
            return _repository.Query();
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _repository.FindAsync(keyValues);
        }

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _repository.FindAsync(cancellationToken, keyValues);
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }

        //IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _repository.DeleteAsync(cancellationToken, keyValues);
        }

        public IQueryable ODataQueryable(ODataQueryOptions<TEntity> oDataQueryOptions)
        {
            return _repository.ODataQueryable(oDataQueryOptions);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }
    }
}