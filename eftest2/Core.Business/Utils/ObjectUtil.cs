using System;
using System.Collections.Generic;
using System.Linq;
using Core.Business.Common;
using Core.Business.ObjectFactories;
using Core.DataAccess.Entities;
using Core.DataAccess.Infrastructure;

namespace Core.Business.Utils
{
    public static class ObjectUtil
    {
        public static T NewModelObject<T, TE>(T modelObject, EditObjectFactoryCreator<T, TE> creator = null)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = ObjectFactoryCreator.Edit(creator);
            objectFactory.ModelObject = modelObject;
            objectFactory.NewModelObject();
            return objectFactory.ModelObject;
        }

        /// <summary>
        /// Get object by primary key and fetch data by using default/custom object factory
        /// </summary>
        /// <typeparam name="T">Model object type</typeparam>
        /// <typeparam name="TE">Any type that has empty constructor</typeparam>
        /// <param name="id">Primary key value</param>
        /// <param name="creator">Custom object factory</param>
        /// <returns></returns>
        public static T Get<T, TE>(object id, GenericObjectFactoryCreator<T, TE> creator = null)
            where T : ModelBase, new()
            where TE : class,new()
        {
            return GetAndFetch(id, ObjectFactoryCreator.Generic(creator));
        }

        public static T GetEdit<T, TE>(object id, EditObjectFactoryCreator<T, TE> creator = null)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            return GetAndFetch(id, ObjectFactoryCreator.Edit(creator));
        }

        public static T GetPreview<T, TE>(object id, PreviewObjectFactoryCreator<T, TE> creator = null)
            where T : ModelBase, new()
            where TE : EntityBase, new()
        {
            return GetAndFetch(id, ObjectFactoryCreator.Preview(creator));
        }

        private static T GetAndFetch<T, TE>(object id, ObjectFactoryBase<T, TE> objectFactory)
        {
            objectFactory.Get(id);
            objectFactory.Fetch();
            return objectFactory.ModelObject;
        }

        public static T Fetch<T, TE>(T modelObject, TE dbEntity,
            GenericObjectFactoryCreator<T, TE> creator = null, Action<ObjectFactoryBase<T, TE>> actionFetch = null)
            where T : ModelBase, new()
            where TE : class , new()
        {
            if (dbEntity == null)
            {
                throw new ArgumentNullException("dbEntity");
            }

            var objectFactory = ObjectFactoryCreator.Generic(creator);
            return Fetch(objectFactory, modelObject, dbEntity, actionFetch);
        }

        public static T Fetch<T, TE>(ObjectFactoryBase<T, TE> objectFactory, T modelObject, TE dbEntity,
           Action<ObjectFactoryBase<T, TE>> actionFetch = null)
        {
            objectFactory.ModelObject = modelObject;
            objectFactory.DbEntity = dbEntity;
            if (actionFetch != null)
            {
                actionFetch(objectFactory);
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

        public static TE UpdateChild<T, TE, TKey>(T modelObject, ICollection<TE> collection, EditObjectFactoryCreator<T, TE> creator = null)
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

            var objectFactory = ObjectFactoryCreator.Edit(creator);
            objectFactory.ModelObject = modelObject;
            objectFactory.DbEntity = dbEntity;
            objectFactory.UpdatePreparation();
            if (modelObject.IsNew)
            {
                collection.Add(dbEntity);
            }
            return dbEntity;
        }

        public static bool Delete<T, TE>(object id, EditObjectFactoryCreator<T, TE> creator = null)
            where T : ModelEditBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = ObjectFactoryCreator.Edit(creator);
            objectFactory.Get(id);
            if (objectFactory.DbEntity == null)
            {
                return false;
            }

            objectFactory.Delete();
            return true;
        }

        public static bool Upsert<T, TE>(T modelObject, bool forceUpdate = false,
                EditObjectFactoryCreator<T, TE> creator = null, bool refetch = true)
            where T : ModelEditBase, new()
            where TE : EntityBase, new()
        {
            var objectFactory = ObjectFactoryCreator.Edit(creator);
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
    }
}