using System;
using System.Collections.Generic;

namespace Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _context;
        private Dictionary<string, object> _repositories;
        private bool _disposed;

        public UnitOfWork(IDataContext context)
        {
            _context = context;
        }
        public IRepository<T> Repository<T>() where T : IObjectState
        {
            return GetRepository<T>();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Cache repositories. It is better if be used with IoC lib
        /// </summary>
        private IRepository<T> GetRepository<T>() where T : IObjectState
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
                return (IRepository<T>)_repositories[type];

            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context));
            return (IRepository<T>)_repositories[type];
        }
    }
}
