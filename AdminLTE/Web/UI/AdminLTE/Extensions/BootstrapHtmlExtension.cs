using TwitterBootstrapMVC.BootstrapMethods;
using Web.UI.AdminLTE.Controls.Widget;

namespace Web.UI.AdminLTE.Extensions
{
    public static class BootstrapHtmlExtension
    {
        public static BoxBuilder<TModel> Begin<TModel>(this BootstrapBase<TModel> bootstrap, Box box)
        {
            return new BoxBuilder<TModel>(bootstrap.Html, box);
        }
    }
}