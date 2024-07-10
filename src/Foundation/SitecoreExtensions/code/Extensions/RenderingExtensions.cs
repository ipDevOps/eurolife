using System;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Xml;

namespace Wedia.Foundation.SitecoreExtensions.Extensions
{
  public static class RenderingExtensions
  {
    public static int GetIntegerParameter(this Rendering rendering, string parameterName, int defaultValue = 0)
    {
      if (rendering == null)
      {
        throw new ArgumentNullException(nameof(rendering));
      }

      var parameter = rendering.Parameters[parameterName];
      if (string.IsNullOrEmpty(parameter))
      {
        return defaultValue;
      }

      int returnValue;
      return !int.TryParse(parameter, out returnValue) ? defaultValue : returnValue;
    }

    public static bool GetBoolParameter(this Rendering rendering, string parameterName, bool defaultValue = false)
    {
      if (rendering == null)
      {
        throw new ArgumentNullException(nameof(rendering));
      }

      var parameter = rendering.Parameters[parameterName];
      if (string.IsNullOrEmpty(parameter))
      {
        return defaultValue;
      }

      return MainUtil.GetBool(parameter, defaultValue);
    }

    public static bool GetUseStaticPlaceholderNames([NotNull] this Rendering rendering)
    {
      return MainUtil.GetBool(rendering.Parameters[Constants.DynamicPlaceholdersLayoutParameters.UseStaticPlaceholderNames], false);
    }
  }
}