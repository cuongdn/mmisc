using System.Collections.Generic;
using TwitterBootstrapMVC.Infrastructure;
using Web.UI.AdminLTE.Enums;
using Web.UI.TypeExtensions;

namespace Web.UI.AdminLTE.Controls.Widget
{
    public class Box : HtmlElement
    {
        public Box()
            : base("div")
        {
            Class("box");
        }

        internal BootstrapStyle BootstrapStyle { get; private set; }

        public Box Id(string id)
        {
            MergeHtmlAttribute("id", id);
            return this;
        }

        public Box HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Box HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Box Class(string cssClass)
        {
            EnsureClass(cssClass);
            return this;
        }

        public Box Data(object htmlDataAttributes)
        {
            MergeHtmlDataAttributes(htmlDataAttributes);
            return this;
        }

        public Box Style(BootstrapStyle style)
        {
            BootstrapStyle = style;
            if (style != BootstrapStyle.None)
            {
                Class(string.Format("box-{0}", style.GetEnumDescription()));
            }
            return this;
        }

        public Box BgColor(BootstrapColor color)
        {
            Class(string.Format("bg-{0}", color.GetEnumDescription()));
            return this;
        }

        public Box Solid(bool value = true)
        {
            const string className = "box-solid";
            if (value)
            {
                Class(className);
            }
            else
            {
                EnsureClassRemoval(className);
            }
            return this;
        }
    }
}