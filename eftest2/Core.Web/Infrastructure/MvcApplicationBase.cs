using System;
using System.Web;
using Core.Web.Dependency;

namespace Core.Web.Infrastructure
{
    public abstract class MvcApplicationBase : HttpApplication
    {
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
