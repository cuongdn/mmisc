using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Business;
using Common.Business;
using Common.DI;
using DataAccess;
using FluentValidation;
using FluentValidation.Mvc;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorInitializer.Initialize(container =>
            {
                var webLifestyle = new WebRequestLifestyle();
                container.RegisterSingle<IRepositoryProvider>(new RepositoryProvider(new RepositoryFactories()));
                container.Register<IDataContextAsync, DatabaseContext>(webLifestyle);
                container.Register<IUnitOfWorkAsync, UnitOfWork>(webLifestyle);
                container.RegisterOpenGeneric(typeof(IRepositoryAsync<>), typeof(Repository<>));
                container.Register<ICategoryService, CategoryService>();
                container.RegisterManyForOpenGeneric(typeof(IValidator<>), typeof(CategoryValidator).Assembly);
                FluentValidationModelValidatorProvider
                    .Configure(x => x.ValidatorFactory = new FluentValidatorFactory(container));
            });
        }
    }
}
