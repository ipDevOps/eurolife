﻿using System;
using System.IO;
using System.Web.UI;

namespace Wedia.Foundation.Theming.Extensions.Controls
{
  public class BackgroundRendering : IDisposable
  {
    /// <summary>
    ///   The html writer
    /// </summary>
    private readonly HtmlTextWriter htmlWriter;

    public BackgroundRendering(TextWriter writer, string backgroundClass, string tag = "div")
    {
      if (!string.IsNullOrEmpty(backgroundClass))
      {
        this.htmlWriter = new HtmlTextWriter(writer);
        htmlWriter.AddAttribute("class", backgroundClass);
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