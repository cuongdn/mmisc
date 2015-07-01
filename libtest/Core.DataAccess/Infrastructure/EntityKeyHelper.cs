using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Core.DataAccess.Context;
using Core.DataAccess.Context.Fake;

namespace Core.DataAccess.Infrastructure
{
    internal sealed class EntityKeyHelper
    {
        private static readonly Lazy<EntityKeyHelper> LazyInstance =
            new Lazy<EntityKeyHelper>(() => new EntityKeyHelper());

        private readonly IDictionary<Type, string[]> _cachedKeys = new Dictionary<Type, string[]>();

        private EntityKeyHelper()
        {
        }

        public static EntityKeyHelper Instance
        {
            get { return LazyInstance.Value; }
        }

        public string[] GetKeyMembers<T>(IDataContext context) where T : class
        {
            var entityType = typeof(T);
            while (entityType != null && entityType.BaseType != typeof(object))
            {
                entityType = entityType.BaseType;
            }

            if (!_cachedKeys.ContainsKey(entityType))
            {
                _cachedKeys.Add(entityType, TryGetKeyMembers<T>(context));
            }
            return _cachedKeys[entityType];
        }

        private string[] TryGetKeyMembers<T>(IDataContext context) where T : class
        {
            var objectContextAdapter = context as IObjectContextAdapter;
            if (objectContextAdapter != null)
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                return objectContext.CreateObjectSet<T>()
                                     .EntitySet.ElementType.KeyMembers
                                     .Select(k => k.Name).ToArray();
            }

            var fakeContext = context as FakeContext;
            if (fakeContext != null)
            {
                return fakeContext.EntityKeyMembers[typeof(T)];
            }

            throw new ArgumentException(string.Format("No primary key field(s) in the type '{0}'.", typeof(T).FullName));
        }

    }
}