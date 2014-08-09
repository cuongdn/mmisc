using System;
using System.Collections.Generic;
using DataAccess.Model;
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
                IEnumerable<Product> list = repo.Query()
                    .Include(x => x.Category)
                    //.OrderBy(q => q.OrderBy(x => x.Category.CategoryName))
                    .OrderBy(x => x.Category.CategoryName)
                    //.OrderBy("Category.CategoryName")
                    .SelectPage(2, 3, out total);

                foreach (Product item in list)
                {
                    Console.WriteLine(item.ModelNumber + " " + item.Category.CategoryName + " " + item.ProductId);
                }
            }
        }
    }
}