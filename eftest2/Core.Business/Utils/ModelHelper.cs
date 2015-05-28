using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Business.Common;
using Core.Common.Infrastructure.Paging;

namespace Core.Business.Utils
{
    public static class ModelHelper
    {
        private const string ModelFetch = "Model_Fetch";
        private const string ModelUpdate = "Model_Update";

        private static readonly Dictionary<string, MethodInfo> Storage = new Dictionary<string, MethodInfo>();
        private static readonly object Lock = new object();

        /// <summary>
        /// Fetch list data using reflection to call the private method Model_Fetch
        /// </summary>
        /// <typeparam name="T">Model object type</typeparam>
        /// <param name="list">Entity list to fetch data</param>
        /// <param name="parameters">Extra parameters of the method if there is any</param>
        /// <returns>Return a model list</returns>
        public static IList<T> FetchList<T>(IEnumerable list, params object[] parameters)
            where T : new()
        {
            var result = new List<T>();
            Type[] paramTypes = null;
            foreach (var item in list)
            {
                var paramValues = GetParamValues(item, parameters);
                if (paramTypes == null)
                {
                    paramTypes = GetParamTypes(paramValues);
                }
                result.Add(Fetch<T>(paramTypes, paramValues));
            }
            return result;
        }

        public static IList<T> FetchList<T>(IEnumerable list, Type[] paramTypes, params object[] parameters)
            where T : new()
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                result.Add(Fetch<T>(paramTypes, GetParamValues(item, parameters)));
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
            return list.Select(item => ObjectUtil.Fetch(new T(), item)).ToList();
        }

        public static IPagedList<T> FetchList<T, TE>(IPagedList<TE> list)
            where T : ModelBase, new()
            where TE : class , new()
        {
            var result = list.Select(item => ObjectUtil.Fetch(new T(), item)).ToList();
            return new PagedList<T>(result, list.PageNumber, list.PageSize, list.TotalItemCount);
        }

        public static T NewModelObject<T>()
            where T : ModelEditBase, new()
        {
            var obj = new T();
            obj.CreateNew();
            return obj;
        }

        /// <summary>
        /// Using reflection to call private method Model_Fetch of model
        /// </summary>
        /// <typeparam name="T">Model object type</typeparam>
        /// <param name="item">First parameter of method</param>
        /// <param name="parameters">Extra parameters if there is any</param>
        /// <returns></returns>
        public static T Fetch<T>(object item, params object[] parameters)
            where T : new()
        {
            var paramValues = GetParamValues(item, parameters);
            var paramTypes = GetParamTypes(paramValues);
            return Fetch<T>(paramTypes, paramValues);
        }

        public static T Fetch<T>(Type[] paramTypes, params object[] paramValues)
            where T : new()
        {
            var method = GetMethod<T>(ModelFetch, paramTypes);
            var obj = new T();
            method.Invoke(obj, paramValues);
            return obj;
        }

        /// <summary>
        /// Using reflection to call private method Model_Update of model
        /// </summary>
        /// <typeparam name="T">Model object type</typeparam>
        /// <param name="childList">Model child list (used to update into entity)</param>
        /// <param name="parent">First parameter of the mtehod</param>
        /// <param name="parameters">Extra parameters if there is any</param>
        /// <returns></returns>
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

        private static string GetKey(Type classType, string methodName, IEnumerable<Type> argumentTypes)
        {
            var argString = argumentTypes != null
                ? argumentTypes.Aggregate(string.Empty, (current, type) => current + type)
                : string.Empty;
            return string.Format("{0}-{1}-{2}", classType.FullName, methodName, argString);
        }

        private static MethodInfo GetMethod<T>(string name, Type[] types)
        {
            var type = typeof(T);
            var key = GetKey(type, name, types);
            if (!Storage.ContainsKey(key))
            {
                lock (Lock)
                {
                    if (!Storage.ContainsKey(key))
                    {
                        var method = type.GetMethod(name,
                               BindingFlags.NonPublic | BindingFlags.Instance, null, types, null);
                        if (method == null)
                        {
                            throw new NullReferenceException(string.Format("Method {0} is not defined.", name));
                        }
                        Storage.Add(key, method);
                    }
                }
            }
            return Storage[key];
        }
    }
}