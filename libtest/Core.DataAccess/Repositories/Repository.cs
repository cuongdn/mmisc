using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Core.Common.Utils;
using Core.DataAccess.Context.Fake;
using Core.DataAccess.Entities;
using System.Data.Entity;
using System.Linq;
using Core.DataAccess.Infrastructure;
using Core.DataAccess.Uow;

namespace Core.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public readonly IUnitOfWork TheUnitOfWork;

        protected DbSet<T> DbSet { get; private set; }

        protected DbContext DbContext { get; private set; }

        public Repository(IUnitOfWork unitOfWork)
        {
            ArgumentChecker.NotNull(unitOfWork, "unitOfWork");
            TheUnitOfWork = unitOfWork;
            DbContext = TheUnitOfWork.DataContext as DbContext;
            if (DbContext != null)
            {
                DbSet = DbContext.Set<T>();
            }
            else
            {
                var fakeContext = TheUnitOfWork.DataContext as FakeContext;
                if (fakeContext != null)
                {
                    DbSet = fakeContext.Set<T>();
                }
            }
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

        public void AttachDelete(T entity)
        {
            entity.ObjectState = ObjectState.Deleted;
            DbSet.Attach(entity);
        }

        public T Get(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public IQueryFluent<T> Query()
        {
            var defaultOrderBy = string.Join(",", EntityKeyHelper.Instance.GetKeyNames<T>(DbContext));
            return new QueryFluent<T>(DbSet.AsQueryable(), defaultOrderBy);
        }

        public IQueryable<T> Queryable()
        {
            return DbSet;
        }

        public async Task<T> GetAsync(params object[] keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }
    }
}