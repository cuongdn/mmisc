using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Web.Infrastructure;
using Mms.Startup;

namespace MvcMusicStore
{
    public class MvcApplication : MvcApplicationBase
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Initialize();
        }
    }
}
