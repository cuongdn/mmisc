using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Blogging.Startup;
using Core.Web.Dependency;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Initialize();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            StructureMapDependencyResolver.Current.CreateNestedContainer();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            StructureMapDependencyResolver.Current.DisposeNestedContainer();
        }
    }
}
