using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Core.DataAccess.Infrastructure
{
    public sealed class EntityKeyHelper
    {
        private static readonly Lazy<EntityKeyHelper> LazyInstance =
            new Lazy<EntityKeyHelper>(() => new EntityKeyHelper());

        private readonly Dictionary<Type, string[]> _dict = new Dictionary<Type, string[]>();

        private EntityKeyHelper()
        {
        }

        public static EntityKeyHelper Instance
        {
            get { return LazyInstance.Value; }
        }

        public string[] GetKeyNames<T>(DbContext context) where T : class
        {
            var t = typeof(T);

            //retreive the base type
            while (t != null && t.BaseType != typeof(object))
            {
                t = t.BaseType;
            }

            string[] keys;

            _dict.TryGetValue(t, out keys);

            if (keys != null)
            {
                return keys;
            }

            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            keys = objectContext.CreateObjectSet<T>()
                                .EntitySet.ElementType.KeyMembers
                                .Select(k => k.Name).ToArray();

            _dict.Add(t, keys);
            return keys;
        }

        public object[] GetKeys<T>(T entity, DbContext context) where T : class
        {
            var keyNames = GetKeyNames<T>(context);
            var type = typeof(T);

            var keys = new object[keyNames.Length];
            for (var i = 0; i < keyNames.Length; i++)
            {
                keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);
            }
            return keys;
        }
    }
}