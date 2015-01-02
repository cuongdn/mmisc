using System.IO;
using Web.UI.AdminLTE.Enums;
using Web.UI.TypeExtensions;

namespace Web.UI.AdminLTE.Controls.Widget
{
    public class BoxToolsPanel : BoxSectionPanel
    {
        private readonly BootstrapSize _buttonSize;
        private bool _closable;
        private bool _collapsible;

        internal BoxToolsPanel(Box box, TextWriter writer, BootstrapSize buttonSize = BootstrapSize.Small)
            : base(box, BoxSection.Tools, writer)
        {
            _buttonSize = buttonSize;
        }

        public BoxToolsPanel Closable(bool value = true)
        {
            _closable = value;
            return this;
        }

        public BoxToolsPanel Collapsible(bool value = true)
        {
            _collapsible = value;
            return this;
        }

        private void RenderButtonCollapse()
        {
            if (!_collapsible) return;
            RenderButton("collapse", "minus");
        }

        private void RenderButtonClose()
        {
            if (!_closable) return;
            RenderButton("remove", "times");
        }

        private void RenderButton(string widget, string icon)
        {
            TextWriter.Write(
                "<button class=\"btn btn-{0} btn-{1}\" data-widget=\"{2}\"><i class=\"fa fa-{3}\"></i></button>",
                Box.BootstrapStyle.GetEnumDescription(), _buttonSize.GetEnumDescription(), widget, icon);
        }

        public override void Dispose()
        {
            RenderButtonCollapse();
            if (_closable && _collapsible)
            {
                TextWriter.Write("&nbsp;");
            }
            RenderButtonClose();
            base.Dispose();
        }
    }
}