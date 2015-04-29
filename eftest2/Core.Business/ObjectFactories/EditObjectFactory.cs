using Core.Business.Common;
using Core.Business.Helpers;
using Core.Business.Mapper;
using Core.DataAccess.Entities;
using Omu.ValueInjecter;

namespace Core.Business.ObjectFactories
{
    public class EditObjectFactory<T, TE> : GenericObjectFactory<T, TE>
        where T : ModelBase, new()
        where TE : EntityBase, new()
    {
        /// <summary>
        /// Using ModelHelper to call this in Model class
        /// </summary>
        public virtual void NewModelObject()
        {
            ModelObject = new T();
        }

        protected virtual void UpdateProperties()
        {
            DbEntity.InjectFrom<ExcludeVersionInjection>(ModelObject);
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

        /// <summary>
        /// Using ModelHelper to call this in Model class
        /// </summary>
        public virtual void UpdateChildren()
        {
        }

        public virtual void Insert()
        {
            CheckConcurrency();
            Repository.Insert(DbEntity);
            TheUnitOfWork.SaveChanges();
        }

        public virtual void Update()
        {
            CheckConcurrency();
            Repository.Update(DbEntity);
            TheUnitOfWork.SaveChanges();
        }

        public virtual void Delete()
        {
            CheckConcurrency();
            Repository.Delete(DbEntity);
            TheUnitOfWork.SaveChanges();
        }

        protected virtual void CheckConcurrency()
        {
            VersionChecker.Check(ModelObject, DbEntity);
        }
    }
}