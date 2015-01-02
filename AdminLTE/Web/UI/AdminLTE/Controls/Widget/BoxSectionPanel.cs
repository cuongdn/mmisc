using System;
using System.IO;

namespace Web.UI.AdminLTE.Controls.Widget
{
    public class BoxSectionPanel : IDisposable
    {
        protected readonly Box Box;
        protected readonly TextWriter TextWriter;

        internal BoxSectionPanel(Box box, BoxSection section, TextWriter writer, bool renderAfterInit = true)
        {
            Box = box;
            TextWriter = writer;
            if (!renderAfterInit) return;
            Render(section);
        }

        public virtual void Dispose()
        {
            TextWriter.Write("</div>");
        }

        protected BoxSectionPanel Render(BoxSection section)
        {
            switch (section)
            {
                case BoxSection.Tools:
                    TextWriter.Write("<div class=\"box-tools pull-right\">");
                    break;
                case BoxSection.Body:
                    TextWriter.Write("<div class=\"box-body\">");
                    break;
                case BoxSection.Footer:
                    TextWriter.Write("<div class=\"box-footer\">");
                    break;
            }
            return this;
        }
    }
}