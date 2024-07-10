using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Wedia.Foundation.SitecoreExtensions.Utilities
{
  public static class Utilities
  {
    public static string RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
    {
      controllerContext.Controller.ViewData.Model = model;
      using (var sw = new StringWriter())
      {
        var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
        var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
        ViewResult.View.Render(ViewContext, sw);
        ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
        return sw.GetStringBuilder().ToString();
      }
    }

    public static string StripHTML(string input)
    {
      if (!string.IsNullOrEmpty(input))
        return Regex.Replace(input, "<.*?>", string.Empty);
      else return string.Empty;
    }
  }
}