using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Blogging.Web.Dependency;
using Core.Web.Dependency;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var container = new Container(new ScanningRegistry());
            StructureMapDependencyResolver.Initialize(container);
            ServiceLocator.SetLocatorProvider(() => StructureMapDependencyResolver.Current);
            DependencyResolver.SetResolver(ServiceLocator.Current);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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
