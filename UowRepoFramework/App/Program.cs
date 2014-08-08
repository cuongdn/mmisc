using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
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
                IRepository<Product> repo = uow.Repository<Product>();
                int total;

                var list = repo.Query()
                    .OrderBy(q => q.Include(x => x.Category).OrderBy("ModelNumber, ProductId desc"))
                    .SelectPage(1, 10, out total)
                   ;

                foreach (var item in list)
                {
                    Console.WriteLine(item.ModelNumber + " " + item.Category.CategoryName + " " + item.ProductId);
                }
            }
        }
    }

    public class PropertyCriteria
    {
        public PropertyCriteria()
        {
            Ascending = true;
        }
        public string Name { get; set; }
        public bool Ascending { get; set; }
    }

    public static class LinqExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy)
        {
            var list = ParseOrderBy(orderBy);
            foreach (OrderByInfo orderByInfo in ParseOrderBy(orderBy))
                source = ApplyOrderBy(source, orderByInfo);
            return (IOrderedQueryable<T>)source;
        }
        private static IOrderedQueryable<T> ApplyOrderBy<T>(IQueryable<T> source, OrderByInfo orderByInfo)
        {
            string[] props = orderByInfo.PropertyName.Split('.');
            Type type = typeof(T);

            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
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

            //TODO: apply caching to the generic methodsinfos?
            return (IOrderedQueryable<T>)typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                        && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2
                        && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });

        }
        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                          && method.IsGenericMethodDefinition
                          && method.GetGenericArguments().Length == 2
                          && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }

        private static IEnumerable<OrderByInfo> ParseOrderBy(string orderBy)
        {
            if (String.IsNullOrEmpty(orderBy))
                yield break;

            string[] items = orderBy.Split(',');
            bool initial = true;
            foreach (string item in items)
            {
                string[] pair = item.Trim().Split(' ');

                if (pair.Length > 2)
                    throw new ArgumentException(String.Format("Invalid OrderBy string '{0}'. Order By Format: Property, Property2 ASC, Property2 DESC", item));

                string prop = pair[0].Trim();

                if (String.IsNullOrEmpty(prop))
                    throw new ArgumentException("Invalid Property. Order By Format: Property, Property2 ASC, Property2 DESC");

                var dir = SortDirection.Ascending;

                if (pair.Length == 2)
                    dir = ("desc".Equals(pair[1].Trim(), StringComparison.OrdinalIgnoreCase) ? SortDirection.Descending : SortDirection.Ascending);

                yield return new OrderByInfo() { PropertyName = prop, Direction = dir, Initial = initial };

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