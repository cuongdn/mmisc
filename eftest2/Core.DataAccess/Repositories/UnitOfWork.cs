using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.DataAccess.Entities;
using Microsoft.Practices.ServiceLocation;

namespace Core.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Guid _instanceId;
        private bool _disposed;
        private Dictionary<Type, dynamic> _repositories;

        protected Dictionary<Type, dynamic> Repositories
        {
            get { return _repositories ?? (_repositories = new Dictionary<Type, dynamic>()); }
        }

        protected DbContextTransaction CurrentTransaction
        {
            get { return DbContext.Database.CurrentTransaction; }
        }

        public DbContext DbContext { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
            _instanceId = Guid.NewGuid();
        }

        public IRepository<T> Repository<T>() where T : EntityBase
        {
            var type = typeof(T);
            if (!Repositories.ContainsKey(type))
            {
                Repositories.Add(type, ServiceLocator.Current.GetInstance<IRepository<T>>());
            }
            return Repositories[type];
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public override string ToString()
        {
            // Used for debug
            return _instanceId.ToString();
        }

        #region Destructors

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                    DbContext = null;
                }
                _disposed = true;
            }
        }
        #endregion
    }
}