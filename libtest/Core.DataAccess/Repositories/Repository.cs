using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Core.Common.Utils;
using Core.DataAccess.Context;
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

        protected IDataContext DbContext { get; private set; }

        public Repository(IUnitOfWork unitOfWork)
        {
            ArgumentChecker.NotNull(unitOfWork, "unitOfWork");
            ArgumentChecker.NotNull(unitOfWork.DataContext, "unitOfWork.DataContext");

            TheUnitOfWork = unitOfWork;
            DbContext = TheUnitOfWork.DataContext;
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
            MarkAsModified(entity);
        }

        private void MarkAsModified(T entity)
        {
            var objectContextAdapter = DbContext as IObjectContextAdapter;
            if (objectContextAdapter != null)
            {
                objectContextAdapter.ObjectContext.ObjectStateManager
                    .ChangeObjectState(entity, EntityState.Modified);
            }
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

        public async Task<T> GetAsync(params object[] keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }

        public IQueryFluent<T> Query()
        {
            var defaultOrderBy = string.Join(",", EntityKeyHelper.Instance.GetKeyMembers<T>(DbContext));
            return new QueryFluent<T>(DbSet.AsQueryable(), defaultOrderBy);
        }

        public IQueryable<T> Queryable()
        {
            return DbSet;
        }

    }
}