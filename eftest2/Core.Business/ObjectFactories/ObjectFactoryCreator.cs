using Core.Business.Common;
using Core.DataAccess.Entities;

namespace Core.Business.ObjectFactories
{
    public delegate EditObjectFactory<T, TE> EditObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : EntityBase, new();

    public delegate ObjectFactory<T, TE> ObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : class, new();

    public delegate GenericObjectFactory<T, TE> GenericObjectFactoryCreator<T, TE>()
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

        public static ObjectFactory<T, TE> Base<T, TE>(ObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : class , new()
        {
            return creator == null ? new ObjectFactory<T, TE>() : creator();
        }

        public static GenericObjectFactory<T, TE> Generic<T, TE>(GenericObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            return creator == null ? new GenericObjectFactory<T, TE>() : creator();
        }
    }
}