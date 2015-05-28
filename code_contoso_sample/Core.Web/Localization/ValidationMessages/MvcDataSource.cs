using System.Web.Mvc;

namespace Core.Web.Localization.ValidationMessages
{
    /// <summary>
    /// Provides messages for all attributes in ASP.NET MVC
    /// </summary>
    public class MvcDataSource : IValidationMessageDataSource
    {
        /// <summary>
        /// Get a validation message
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>
        /// String if found; otherwise <c>null</c>.
        /// </returns>
        public string GetMessage(IGetMessageContext context)
        {
            // ReSharper disable once CSharpWarnings::CS0618
            if (context.Attribute is CompareAttribute)
                return "The {0} and {1} fields to not match.";

            return null;
        }
    }
}
