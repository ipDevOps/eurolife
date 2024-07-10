using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Wedia.Foundation.Theming.Extensions.Controls
{
  public class FontColorRendering : IDisposable
  {
    /// <summary>
    ///   The html writer
    /// </summary>
    private readonly HtmlTextWriter htmlWriter;

    public FontColorRendering(TextWriter writer, string fontColorClass, string tag = "div")
    {
      if (!string.IsNullOrEmpty(fontColorClass))
      {
        this.htmlWriter = new HtmlTextWriter(writer);
        htmlWriter.AddAttribute("class", fontColorClass);
        htmlWriter.RenderBeginTag(tag);
      }
    }


    public void Dispose()
    {
      if (htmlWriter != null)
      {
        htmlWriter.RenderEndTag();
        this.htmlWriter.Dispose();
      }
    }
  }

}