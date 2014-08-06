using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private IDataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(IDataContext context)
        {
            _context = context;
            var dbContext = context as DbContext;
            if (dbContext != null)
                _dbSet = dbContext.Set<T>();
        }
        public T Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public void AddMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Add(entity);
        }

        public void Add(T entity)
        {
            entity.ObjectState = ObjectState.Added;
            _dbSet.Attach(entity);
        }
        public void Update(T entity)
        {
            entity.ObjectState = ObjectState.Modified;
            _dbSet.Attach(entity);
        }
        public void UpdateMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }
        public void Delete(T entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            _dbSet.Attach(entity);
        }
        public void DeleteMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Delete(entity);
        }
        public IQueryable<T> Queryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            return _dbSet.SqlQuery(query, parameters).AsQueryable();
        }

        public IQueryFluent<T> Query()
        {
            return new QueryFluent<T>(this);
        }
       
    }
}
