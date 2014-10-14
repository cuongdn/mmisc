using Common.Extensions;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Common.Web;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyInitializer.Initialize(
                x => x.RegisterFromAssemblies(new[] { "Business", "Service" }));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
