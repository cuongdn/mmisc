using Core.Business.Common;
using Core.Business.ObjectFactories;
using Core.DataAccess.Entities;

namespace Core.Business.Utils
{
    public delegate EditObjectFactory<T, TE> EditObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : EntityBase, new();

    public delegate GenericObjectFactory<T, TE> GenericObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : class, new();

    public delegate PreviewObjectFactory<T, TE> PreviewObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : EntityBase, new();

    public static class ObjectFactoryCreator
    {
        public static EditObjectFactory<T, TE> Edit<T, TE>(EditObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            return creator == null ? new EditObjectFactory<T, TE>() : creator();
        }

        public static GenericObjectFactory<T, TE> Generic<T, TE>(GenericObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : class , new()
        {
            return creator == null ? new GenericObjectFactory<T, TE>() : creator();
        }

        public static PreviewObjectFactory<T, TE> Preview<T, TE>(PreviewObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            return creator == null ? new PreviewObjectFactory<T, TE>() : creator();
        }
    }
}