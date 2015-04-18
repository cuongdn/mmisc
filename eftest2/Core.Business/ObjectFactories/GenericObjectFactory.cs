using Core.Business.Common;
using Core.DataAccess.Entities;
using Core.DataAccess.Repositories;
using Omu.ValueInjecter;

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

        public virtual void NewModelObject()
        {
            ModelObject = new T();
        }

        protected virtual void UpdateProperties()
        {
            DbEntity.InjectFrom(ModelObject);
        }

        public void InsertPreparation()
        {
            DbEntity = new TE();
            UpdateProperties();
            UpdateChildren();
        }

        public void UpdatePreparation()
        {
            UpdateProperties();
            UpdateChildren();
        }

        public virtual void Get(object id)
        {
            DbEntity = Repository.Get(id);
        }

        public virtual void UpdateChildren()
        {
        }

        public virtual void Insert()
        {
            Repository.Insert(DbEntity);
            TheUnitOfWork.SaveChanges();
        }

        public virtual void Update()
        {
            Repository.Update(DbEntity);
            TheUnitOfWork.SaveChanges();
        }

        public virtual void Delete()
        {
            TheUnitOfWork.Repository<TE>().Delete(DbEntity);
            TheUnitOfWork.SaveChanges();
        }
    }
}