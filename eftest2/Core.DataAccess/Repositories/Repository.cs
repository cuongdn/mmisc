using System;
using System.Data.Entity.Infrastructure;
using Core.DataAccess.Entities;
using System.Data.Entity;
using System.Linq;
using Core.DataAccess.Infrastructure;

namespace Core.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public readonly IUnitOfWork TheUnitOfWork;

        protected DbSet<T> DbSet { get; private set; }

        protected DbContext DbContext
        {
            get { return TheUnitOfWork.DbContext; }
        }

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            TheUnitOfWork = unitOfWork;
            DbSet = DbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            entity.ObjectState = ObjectState.Added;
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            entity.ObjectState = ObjectState.Modified;
            DbSet.Attach(entity);
            ((IObjectContextAdapter)DbContext).ObjectContext.ObjectStateManager.
                ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            DbSet.Remove(entity);
        }

        public T Get(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public QueryFluent<T> Query()
        {
            var defaultOrderBy = string.Join(",", EntityKeyHelper.Instance.GetKeyNames<T>(DbContext));
            return new QueryFluent<T>(DbSet.AsQueryable(), defaultOrderBy);
        }
    }
}