using System;
using System.Collections.Generic;
using System.Linq;
using Core.Business.Common;
using Core.Business.ObjectFactories;
using Core.DataAccess.Entities;
using Core.DataAccess.Infrastructure;

namespace Core.Business.Utils
{
    public delegate GenericObjectFactory<T, TE> GenericObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : EntityBase, new();

    public delegate ObjectFactory<T, TE> ObjectFactoryCreator<T, TE>()
        where T : ModelBase, new()
        where TE : class, new();

    public static class ObjFacUtil
    {
        public static T NewModelObject<T, TE>(T modelObject, GenericObjectFactoryCreator<T, TE> creator = null)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = CreateGenericObjectFactory(creator);
            objectFactory.ModelObject = modelObject;
            objectFactory.NewModelObject();
            return objectFactory.ModelObject;
        }

        public static T Get<T, TE>(object id, GenericObjectFactoryCreator<T, TE> creator = null)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = CreateGenericObjectFactory(creator);
            objectFactory.Get(id);

            if (objectFactory.DbEntity == null)
            {
                return null;
            }

            objectFactory.Fetch();
            return objectFactory.ModelObject;
        }

        public static T Fetch<T, TE>(T modelObject, TE dbEntity,
            ObjectFactoryCreator<T, TE> creator = null, Action actionFetch = null)
            where T : ModelBase, new()
            where TE : class , new()
        {
            if (dbEntity == null)
            {
                throw new ArgumentNullException("dbEntity");
            }

            var objectFactory = CreateObjectFactory(creator);
            objectFactory.ModelObject = modelObject;
            objectFactory.DbEntity = dbEntity;
            if (actionFetch != null)
            {
                actionFetch();
            }
            else
            {
                objectFactory.Fetch();
            }
            return objectFactory.ModelObject;
        }

        private static TE GetDbEntity<T, TE, TKey>(T modelObject, IEnumerable<TE> collection)
            where T : ModelEditBase, new()
            where TE : Entity<TKey>, new()
        {
            return modelObject.IsNew ? new TE() : collection.FirstOrDefault(x => x.Id.Equals(modelObject.IdValue));
        }

        public static TE UpdateChild<T, TE, TKey>(T modelObject, ICollection<TE> collection, GenericObjectFactoryCreator<T, TE> creator = null)
            where T : ModelEditBase, new()
            where TE : Entity<TKey>, new()
        {
            var dbEntity = GetDbEntity<T, TE, TKey>(modelObject, collection);
            if (dbEntity == null)
            {
                return null;
            }
            if (!modelObject.IsNew && modelObject.IsDelete)
            {

                dbEntity.ObjectState = ObjectState.Deleted;
                collection.Remove(dbEntity);
                return dbEntity;
            }

            var objectFactory = CreateGenericObjectFactory(creator);
            objectFactory.ModelObject = modelObject;
            objectFactory.DbEntity = dbEntity;
            objectFactory.UpdatePreparation();
            if (modelObject.IsNew)
            {
                collection.Add(dbEntity);
            }
            return dbEntity;
        }

        public static bool Delete<T, TE>(object id, GenericObjectFactoryCreator<T, TE> creator = null)
            where T : ModelEditBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = CreateGenericObjectFactory(creator);
            objectFactory.Get(id);
            if (objectFactory.DbEntity == null)
            {
                return false;
            }

            objectFactory.Delete();
            return true;
        }

        public static bool Upsert<T, TE>(T modelObject, bool forceUpdate = false,
                GenericObjectFactoryCreator<T, TE> creator = null, bool refetch = true)
            where T : ModelEditBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = CreateGenericObjectFactory(creator);
            objectFactory.ModelObject = modelObject;

            if (forceUpdate)
            {
                objectFactory.Get(modelObject.IdValue);
                if (objectFactory.DbEntity == null)
                {
                    return false;
                }
                objectFactory.UpdatePreparation();
                objectFactory.Update();
            }
            else
            {
                objectFactory.InsertPreparation();
                objectFactory.Insert();
            }
            if (refetch)
            {
                objectFactory.Fetch();
            }
            return true;
        }

        private static GenericObjectFactory<T, TE> CreateGenericObjectFactory<T, TE>(GenericObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            return creator == null ? new GenericObjectFactory<T, TE>() : creator();
        }

        private static ObjectFactory<T, TE> CreateObjectFactory<T, TE>(ObjectFactoryCreator<T, TE> creator)
            where T : ModelBase, new()
            where TE : class , new()
        {
            return creator == null ? new ObjectFactory<T, TE>() : creator();
        }
    }
}