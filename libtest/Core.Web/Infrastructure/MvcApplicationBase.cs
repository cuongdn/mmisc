using System;
using System.Web;

namespace Core.Web.Infrastructure
{
    public abstract class MvcApplicationBase : HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Logger.Get(sender.GetType()).Error("Unhandled exception", Server.GetLastError());
            //Server.ClearError();
            //Response.Redirect("/Home/Error");
        }
    }
}
