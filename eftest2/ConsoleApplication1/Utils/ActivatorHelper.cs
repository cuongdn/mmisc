using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleApplication1.Utils
{
    public delegate T ObjectActivator<T>(params object[] args);

    public static class ActivatorHelper
    {
        private static readonly Dictionary<Type, dynamic> _dict = new Dictionary<Type, dynamic>();

        public static ObjectActivator<T> GetActivator<T>()
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

            //create a single param of type object[]
            var param = Expression.Parameter(typeof(object[]), "args");

            var argsExp = new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                var index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                var paramAccessorExp = Expression.ArrayIndex(param, index);
                var paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            var newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            var lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            //compile it
            return lambda.Compile();
        }
    }
}
