using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Common.Utils;
using Core.DataAccess.Context;
using Core.DataAccess.Utils;

namespace Core.DataAccess.Uow
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

        public IDataContext DataContext { get; private set; }

        public UnitOfWork(IDataContext dataContext)
        {
            ArgumentChecker.NotNull(dataContext, "dataContext");
            DataContext = dataContext;
            _instanceId = Guid.NewGuid();
        }

        public T Repository<T>() where T : class
        {
            var type = typeof(T);
            if (!Repositories.ContainsKey(type))
            {
                Repositories.Add(type, DbUtil.Repository<T>(this));
            }
            return Repositories[type];
        }

        public int SaveChanges()
        {
            return DataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DataContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await DataContext.SaveChangesAsync(cancellationToken);
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
                    DataContext.Dispose();
                    DataContext = null;
                }
                _disposed = true;
            }
        }
        #endregion
    }
}