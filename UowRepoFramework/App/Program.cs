using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using App.Model;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using StructureMap;

namespace App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IDataContextAsync>().Use<DatabaseContext>();
                x.For<IRepositoryProvider>().Use<RepositoryProvider>()
                    .Ctor<RepositoryFactories>("repositoryFactories").Is(new RepositoryFactories());
                x.For<IUnitOfWork>().Use<UnitOfWork>();
                x.For(typeof(IRepositoryAsync<>)).Use(typeof(Repository<>));
            });

            using (var uow = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                var repo = uow.Repository<Product>();
                int total;

                var list = repo.Query()
                    .OrderBy(q => q.Include(x => x.Category).OrderBy("ModelNumber, ProductId desc"))
                    .SelectPage(1, 10, out total);

                foreach (var item in list)
                {
                    Console.WriteLine(item.ModelNumber + " " + item.Category.CategoryName + " " + item.ProductId);
                }

                list = repo.Query()
                    .OrderBy(q => q.Include(x => x.Category).OrderBy("ModelNumber desc, ProductId"))
                    .SelectPage(1, 10, out total);

                foreach (var item in list)
                {
                    Console.WriteLine(item.ModelNumber + " " + item.Category.CategoryName + " " + item.ProductId);
                }

                list = repo.Query()
                   .OrderBy(q => q.Include(x => x.Category).OrderBy("ModelNumber desc, ProductId"))
                   .SelectPage(1, 10, out total);

                foreach (var item in list)
                {
                    Console.WriteLine(item.ModelNumber + " " + item.Category.CategoryName + " " + item.ProductId);
                }
            }
        }
    }

    public static class LinqExtensions
    {
        private static readonly IDictionary<string, MethodInfo> CachedMethodDictionary = new Dictionary<string, MethodInfo>();
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy)
        {
            return (IOrderedQueryable<T>)ParseOrderBy(orderBy).Aggregate(source, ApplyOrderBy);
        }

        private static IOrderedQueryable<T> ApplyOrderBy<T>(IQueryable<T> source, OrderByInfo orderByInfo)
        {
            var props = orderByInfo.PropertyName.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);
            string methodName;

            if (!orderByInfo.Initial && source is IOrderedQueryable<T>)
            {
                if (orderByInfo.Direction == SortDirection.Ascending)
                {
                    methodName = "ThenBy";
                }
                else
                {
                    methodName = "ThenByDescending";
                }
            }
            else
            {
                if (orderByInfo.Direction == SortDirection.Ascending)
                {
                    methodName = "OrderBy";
                }
                else
                {
                    methodName = "OrderByDescending";
                }
            }

            if (!CachedMethodDictionary.ContainsKey(methodName))
            {
                var mi = typeof(Queryable).GetMethods().Single(
                     method => method.Name == methodName
                             && method.IsGenericMethodDefinition
                             && method.GetGenericArguments().Length == 2
                             && method.GetParameters().Length == 2).MakeGenericMethod(typeof(T), type);
                CachedMethodDictionary.Add(methodName, mi);
            }

            return (IOrderedQueryable<T>)CachedMethodDictionary[methodName].Invoke(null, new object[] { source, lambda });

        }

        private static IEnumerable<OrderByInfo> ParseOrderBy(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                yield break;

            var items = orderBy.Split(',');
            var initial = true;
            foreach (var item in items)
            {
                var pair = item.Trim().Split(' ');

                if (pair.Length > 2)
                {
                    throw new ArgumentException(String.Format("Invalid OrderBy string '{0}'. Order By Format: Property, Property2 ASC, Property2 DESC", item));
                }
                var prop = pair[0].Trim();

                if (String.IsNullOrEmpty(prop))
                    throw new ArgumentException("Invalid Property. Order By Format: Property, Property2 ASC, Property2 DESC");

                var direction = SortDirection.Ascending;

                if (pair.Length == 2)
                {
                    direction = ("desc".Equals(pair[1].Trim(), StringComparison.OrdinalIgnoreCase) ? SortDirection.Descending : SortDirection.Ascending);
                }
                yield return new OrderByInfo { PropertyName = prop, Direction = direction, Initial = initial };

                initial = false;
            }

        }
        private class OrderByInfo
        {
            public string PropertyName { get; set; }
            public SortDirection Direction { get; set; }
            public bool Initial { get; set; }
        }

        private enum SortDirection
        {
            Ascending = 0,
            Descending = 1
        }
    }
}