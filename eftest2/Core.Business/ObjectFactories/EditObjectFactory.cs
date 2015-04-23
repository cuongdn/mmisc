using Core.Business.Common;
using Core.DataAccess.Entities;
using Omu.ValueInjecter;

namespace Core.Business.ObjectFactories
{
    public class EditObjectFactory<T, TE> : PreviewObjectFactory<T, TE>
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
            DbEntity.InjectFrom<FlatLoopValueInjection>(ModelObject);
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
            Repository.Insert(DbEntity);
            TheUnitOfWork.SaveChangesAsync();
        }

        public virtual void Update()
        {
            Repository.Update(DbEntity);
            TheUnitOfWork.SaveChangesAsync();
        }

        public virtual void Delete()
        {
            TheUnitOfWork.Repository<TE>().Delete(DbEntity);
            TheUnitOfWork.SaveChangesAsync();
        }
    }
}