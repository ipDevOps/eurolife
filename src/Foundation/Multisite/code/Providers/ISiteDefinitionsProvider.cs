using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Wedia.Foundation.Multisite.Providers
{
  public interface ISiteDefinitionsProvider
  {
    IEnumerable<SiteDefinition> SiteDefinitions { get; }
    SiteDefinition GetContextSiteDefinition(Item item);
  }
}
