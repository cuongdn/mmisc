using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Common.DI;
using Common.Extensions;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SimpleInjectorInitializer.Initialize(x => x.RegisterFromAssemblies(new[] { "Business", "Service" }));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
