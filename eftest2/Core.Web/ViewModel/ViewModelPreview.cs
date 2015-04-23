using System;
using System.Collections.Generic;

namespace Core.Web.ViewModel
{
    public class ViewModelPreview<T> : IViewModel<T> where T : class
    {
        private IDictionary<Type, object> _cachedObjects;
        protected IDictionary<Type, object> CachedObjects
        {
            get { return _cachedObjects ?? (_cachedObjects = new Dictionary<Type, object>()); }
        }

        public T ModelObject { get; set; }

        public bool Found
        {
            get { return ModelObject != null; }
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
    }
}