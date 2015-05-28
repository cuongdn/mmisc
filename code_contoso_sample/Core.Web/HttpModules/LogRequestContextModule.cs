using System;
using System.Web;
using Core.Logging;

namespace Core.Web.HttpModules
{
    /// web.config
    /// <configuration>
    ///
    /// <system.webServer>
    ///   <modules runAllManagedModulesForAllRequests="true">
    ///    ...
    ///      <add name="LogRequest" type="Core.Web.HttpModules.LogRequestContextModule, Core.Web" />
    ///      ...
    ///    </modules>
    ///  </system.webServer>
    /// ...
    /// </configuration>
    public class LogRequestContextModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        void BeginRequest(object sender, EventArgs e)
        {
            var url = HttpContext.Current.Request.Path;
            // use %property{key} to get value in log conversation
            Logger.Default.ThreadVariablesContext.Set("url", url);
        }

        void EndRequest(object sender, EventArgs e)
        {
            Dispose();
        }

        public void Dispose()
        {
            Logger.Default.ThreadVariablesContext.Clear();
        }
    }
}
