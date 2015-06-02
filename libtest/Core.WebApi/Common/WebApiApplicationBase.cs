using System.Web;
using Core.Logging;

namespace Core.WebApi.Common
{
    public class WebApiApplicationBase : HttpApplication
    {
        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                Logger.Get(GetType()).Error("Unhandled exception.", exception);
            }
        }
    }
}
