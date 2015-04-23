using Core.Business.Common;
using Core.DataAccess.Entities;
using Core.DataAccess.Repositories;

namespace Core.Business.ObjectFactories
{
    public class GenericObjectFactory<T, TE> : ObjectFactory<T, TE>
        where T : ModelBase, new()
        where TE : EntityBase, new()
    {
        protected IRepository<TE> Repository
        {
            get { return TheUnitOfWork.Repository<TE>(); }
        }

        protected virtual IUnitOfWork TheUnitOfWork
        {
            get { return UnitOfWorkFactory.Get(); }
        }

        public override void Get(object id)
        {
            DbEntity = Repository.Get(id);
        }
    }
}