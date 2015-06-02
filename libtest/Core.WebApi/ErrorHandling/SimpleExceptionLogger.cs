using System.Web.Http.ExceptionHandling;
using Core.Logging;

namespace Core.WebApi.ErrorHandling
{
    public class SimpleExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Get<SimpleExceptionLogger>().Error("Unhandled exception", context.Exception);
        }
    }
}