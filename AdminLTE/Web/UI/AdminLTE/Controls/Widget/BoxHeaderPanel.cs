using System.IO;
using Web.UI.AdminLTE.Enums;

namespace Web.UI.AdminLTE.Controls.Widget
{
    public class BoxHeaderPanel : BoxSectionPanel
    {
        internal BoxHeaderPanel(Box box, TextWriter writer, string title = null, string tooltip = null)
            : base(box, BoxSection.Header, writer, false)
        {
            if (tooltip != null)
            {
                TextWriter.Write("<div class=\"box-header\" data-toggle=\"tooltip\" data-original-title=\"{0}\">",
                    tooltip);
            }
            else
            {
                TextWriter.Write("<div class=\"box-header\">");
            }
            TextWriter.Write("<h3 class=\"box-title\">{0}</h3>", title);
        }

        public void BoxTools(BootstrapSize buttonSize = BootstrapSize.Small, bool closable = false,
            bool collapsible = false)
        {
            using (BeginBoxTools(buttonSize, closable, collapsible))
            {
                // NOP 
            }
        }

        public BoxToolsPanel BeginBoxTools(BootstrapSize buttonSize = BootstrapSize.Small, bool closable = false,
            bool collapsible = false)
        {
            return new BoxToolsPanel(Box, TextWriter, buttonSize).Closable(closable).Collapsible(collapsible);
        }
    }
}