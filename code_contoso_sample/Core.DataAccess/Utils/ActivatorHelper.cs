using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.DataAccess.Utils
{
    internal delegate T ObjectActivator<T>(params object[] args);

    internal sealed class ActivatorHelper
    {
        private static readonly Lazy<ActivatorHelper> LazyInstance
            = new Lazy<ActivatorHelper>(() => new ActivatorHelper());

        private ActivatorHelper()
        {
        }

        public static ActivatorHelper Instance
        {
            get { return LazyInstance.Value; }
        }

        private readonly Dictionary<Type, dynamic> _dict = new Dictionary<Type, dynamic>();

        public ObjectActivator<T> GetActivator<T>()
        {
            var key = typeof(T);
            if (!_dict.ContainsKey(key))
            {
                _dict.Add(key, GetCompileConstructor<T>());
            }
            return (ObjectActivator<T>)_dict[key];
        }

        private static Delegate GetCompileConstructor<T>()
        {
            return GetCompileConstructor<T>(typeof(T).GetConstructors().First());
        }

        private static Delegate GetCompileConstructor<T>(ConstructorInfo ctor)
        {
            var paramsInfo = ctor.GetParameters();
            var param = Expression.Parameter(typeof(object[]), "args");
            var argsExp = new Expression[paramsInfo.Length];

            for (var i = 0; i < paramsInfo.Length; i++)
            {
                var index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                var paramAccessorExp = Expression.ArrayIndex(param, index);
                var paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                argsExp[i] = paramCastExp;
            }

            var newExp = Expression.New(ctor, argsExp);
            return Expression.Lambda(typeof(ObjectActivator<T>), newExp, param).Compile();
        }
    }
}
