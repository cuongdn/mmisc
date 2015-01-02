using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;
using Web.UI.AdminLTE.Enums;

namespace Web.UI.AdminLTE.Controls.Widget
{
    public class BoxBuilder<TModel> : BuilderBase<TModel, Box>
    {
        public BoxBuilder(HtmlHelper<TModel> htmlHelper, Box element)
            : base(htmlHelper, element, false)
        {
        }

        public void Header(string title, string tooltip = null)
        {
            using (BeginHeader(title, tooltip))
            {
                //NOP
            }
        }

        public BoxHeaderPanel BeginHeader(string title, string tooltip = null)
        {
            return new BoxHeaderPanel(element, textWriter, title, tooltip);
        }

        public BoxSectionPanel BeginBody()
        {
            return new BoxSectionPanel(element, BoxSection.Body, textWriter);
        }

        public BoxSectionPanel BeginFooter()
        {
            return new BoxSectionPanel(element, BoxSection.Footer, textWriter);
        }
    }
}