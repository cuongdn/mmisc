using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core;
using LinqKit;
using StructureMap;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory.Initialize(x =>
            {
                //TrackableDbContext.RecordEntityOrginalValues = false;

                // need to configure life time Hybrid when use in asp mvc app
                x.For<IDataContext>().Use<DataContext>()
                    .Ctor<string>("nameOrConnectionString").Is("Name=DataContext")
                    .Ctor<bool>("recordEntityOrginalValues").Is(false);
                x.For<IUnitOfWork>().Use<UnitOfWork>();

                // generic repository
                x.For(typeof(IRepository<>)).Use(typeof(Repository<>));
            });
            IEnumerable<Product> list;
            // with about configuration, each uow creates a new instance of datacontext 
            using (var uow = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                var rep = uow.Repository<Product>();
                var filter = new QueryObject<Product>();
                filter.And(x => x.ProductID >= 407);
                filter.And(x => x.ProductID <= 411);
                list = rep.Query()
                    .OrderBy("ProductID")
                    //.Filter(filter)
                    .Filter(x => x.ProductID >= 407)
                    .Filter(x => x.ProductID <= 411)
                   //.Filter(Filter<Product>
                   //        .Add(x => x.ProductID > 406)
                   //        .Or(x => x.ProductID < 400)
                   //        .Query())   // filter by Filer fluent API
                   .Include(x => x.Category)
                   .Select();
                //.SelectPage(1, 5);    // must provide orderby
                foreach (var item in list)
                    item.ModelName = "x2";

                rep.UpdateMany(list);
                uow.SaveChanges();  // nothing happen if no changes (use trackable)
            }
        }
    }
}
