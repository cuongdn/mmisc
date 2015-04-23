using System;
using System.Collections.Generic;
using Core.Business.Common;

namespace Core.Web.ViewModel
{
    public abstract class ViewModelBase<T> where T : ModelEditBase
    {
        private IDictionary<Type, object> _cachedObjects;
        protected IDictionary<Type, object> CachedObjects
        {
            get { return _cachedObjects ?? (_cachedObjects = new Dictionary<Type, object>()); }
        }

        public T ModelObject { get; set; }

        public bool NotFound
        {
            get { return ModelObject == null; }
        }

        protected TResult GetObject<TResult>(Func<TResult> createObject) where TResult : class
        {
            var key = typeof(TResult);
            if (!CachedObjects.ContainsKey(key))
            {
                CachedObjects.Add(key, createObject());
            }
            return CachedObjects[key] as TResult;
        }

        public virtual bool Upsert(bool forceUpdate = false)
        {
            return ModelObject.Upsert(forceUpdate);
        }

        public virtual bool Delete()
        {
            return ModelObject.Delete();
        }
    }
}
