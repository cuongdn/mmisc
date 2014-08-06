using System;

namespace Core
{
    /// <summary>
    /// Commit changes and manage transactions
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IRepository<T> Repository<T>() where T : IObjectState;
        void Dispose(bool disposing);
    }
}