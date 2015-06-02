using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.DataAccess.Context;
using Core.DataAccess.Uow;
using Core.Web.Dependency;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using Core.WebApi.Common;
using Cs.DbModel;
using Cs.Localization.FriendlyNames;
using FluentValidation.WebApi;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Cs.WebApi
{
    public class WebApiApplication : WebApiApplicationBase
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var container = new Container();
            var provider = LocalizationConfig.RegisterResources(Assembly.GetAssembly(typeof(StudentFriendlyNames)));
            container.RegisterSingle<ILocalizedStringProvider>(provider);
            container.RegisterWebApiRequest<IUnitOfWork, UnitOfWork>();
            container.RegisterWebApiRequest<IDataContext, SchoolContext>();
            container.Verify();

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);

        }
    }
}
