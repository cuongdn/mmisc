using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Business.Common;

namespace Core.Business.Utils
{
    public static class ModelHelper
    {
        private const string ModelFetch = "Model_Fetch";
        private const string ModelUpdate = "Model_Update";

        private static readonly Dictionary<Type, Dictionary<string, MethodInfo>> Storage
            = new Dictionary<Type, Dictionary<string, MethodInfo>>();
        private static readonly object Lock = new object();

        public static IList<T> FetchList<T>(IEnumerable list, params object[] parameters)
            where T : new()
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add(Fetch<T>(item, parameters));
            }
            return result;
        }

        /// <summary>
        /// Fetch list data using default object factory
        /// </summary>
        /// <typeparam name="T">Model object type</typeparam>
        /// <typeparam name="TE">Any type that has empty constructor</typeparam>
        /// <param name="list">Entity list to fetch data</param>
        /// <returns>Return a model list</returns>
        public static IList<T> FetchList<T, TE>(IEnumerable<TE> list)
            where T : ModelBase, new()
            where TE : class , new()
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add(ObjFacUtil.Fetch(new T(), item));
            }
            return result;
        }

        public static T NewModelObject<T>()
            where T : ModelEditBase, new()
        {
            var obj = new T();
            obj.CreateNew();
            return obj;
        }

        public static T Fetch<T>(object item, params object[] parameters)
            where T : new()
        {
            var paramValues = GetParamValues(item, parameters);
            var paramTypes = GetParamTypes(paramValues);
            var method = GetMethod<T>(ModelFetch, paramTypes);
            var obj = new T();
            method.Invoke(obj, paramValues);
            return obj;
        }

        public static void UpdateChildren<T>(IEnumerable childList, object parent, params object[] parameters)
        {
            if (childList == null) return;
            var paramValues = GetParamValues(parent, parameters);
            var paramTypes = GetParamTypes(paramValues);
            var method = GetMethod<T>(ModelUpdate, paramTypes);
            foreach (var item in childList)
            {
                method.Invoke(item, paramValues);
            }
        }

        private static object[] GetParamValues(object parent, params object[] parameters)
        {
            var paramValues = new List<object> { parent };
            paramValues.AddRange(parameters);
            return paramValues.ToArray();
        }

        private static Type[] GetParamTypes(IEnumerable<object> types)
        {
            return types.Select(type => type.GetType()).ToArray();
        }

        private static string GetKey(string name, IEnumerable<Type> types)
        {
            var typeString = types != null
                ? types.Aggregate(string.Empty, (current, type) => current + type)
                : string.Empty;
            return string.Format("{0}-{1}", name, typeString);
        }

        private static MethodInfo GetMethod<T>(string name, Type[] types)
        {
            var type = typeof(T);

            if (!Storage.ContainsKey(type))
            {
                lock (Lock)
                {
                    if (!Storage.ContainsKey(type))
                    {
                        Storage[type] = new Dictionary<string, MethodInfo>();
                    }
                }
            }

            var dic = Storage[type];
            var key = GetKey(name, types);
            if (!dic.ContainsKey(key))
            {
                lock (Lock)
                {
                    if (!dic.ContainsKey(key))
                    {
                        var method = type.GetMethod(name,
                                BindingFlags.NonPublic | BindingFlags.Instance, null, types, null);
                        if (method == null)
                        {
                            throw new NullReferenceException(string.Format("Method {0} is not defined.", name));
                        }
                        dic.Add(key, method);
                    }
                }
            }
            return dic[key];
        }
    }
}