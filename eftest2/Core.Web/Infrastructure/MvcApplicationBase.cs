using System;
using System.Web;
using Core.Logging;
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

        protected void Application_Error(object sender, EventArgs e)
        {
            //Logger.Get(sender.GetType()).Error("Unhandled exception", Server.GetLastError());
            //Server.ClearError();
            //Response.Redirect("/Home/Error");
        }
    }
}
