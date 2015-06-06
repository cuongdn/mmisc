using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Common.Infrastructure.Dependency;
using Core.DataAccess.Uow;
using Core.Web.Localization;
using Core.Web.Localization.Types;
using Core.WebApi.Common;
using Cs.DbModel;
using Cs.Localization.FriendlyNames;
using FluentValidation.WebApi;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Cs.WebApi
{
    [EnableCors("http://localhost:8080", "*", "*")]
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

            var factory = new UowHandlerFactory(container);
            factory.Register<SchoolContext>(lifestyle: new WebApiRequestLifestyle());
            container.RegisterWebApiRequest<IUowHandlerFactory>(() => factory);

            container.Verify();

            IoC.SetContainerProvider(() => container);
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            FluentValidationModelValidatorProvider.Configure(GlobalConfiguration.Configuration);

        }
    }
}
