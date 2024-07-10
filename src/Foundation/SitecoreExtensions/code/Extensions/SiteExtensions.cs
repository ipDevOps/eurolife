using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Wedia.Foundation.SitecoreExtensions.Extensions
{
  public static class SiteExtensions
  {

    private const string _enabledLanguagesAttributeName = "enabledLanguages";

    public static string[] GetEnabledLanguages(this SiteContext siteContext)
    {
      if (siteContext == null ||
      string.IsNullOrEmpty(siteContext.Properties[_enabledLanguagesAttributeName]))
      {
        return new string[0];
      }
      return siteContext.Properties[_enabledLanguagesAttributeName].Split('|');
    }

    public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      var startItem = site.GetStartItem();
      return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
    }

    public static Item GetRootItem(this SiteContext site)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      return site.Database.GetItem(site.RootPath);
    }

    public static Item GetStartItem(this SiteContext site)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      return site.Database.GetItem(site.StartPath);
    }
  }
}