using System.Web.Mvc;
using Core.Web.Common;

namespace Core.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ErrorMessage(this HtmlHelper html)
        {
            var tempData = html.ViewContext.TempData;
            if (tempData.ContainsKey(WebConstants.ErrorMessage))
            {
                return MvcHtmlString.Create(string.Format("<p class='error'>{0}</p>", tempData[WebConstants.ErrorMessage]));
            }
            return MvcHtmlString.Empty;
        }
    }
}
