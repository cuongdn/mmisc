using System;
using System.Data.Entity;
using App.Model;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using StructureMap;
using Utilities.Extensions;

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
}