using System.Collections.Generic;
using System.Linq;

namespace Wedia.Feature.Multisite.Models
{
  public class SiteConfigurations
  {
    public IEnumerable<SiteConfiguration> Items { get; set; }

    public SiteConfiguration Current
    {
      get
      {
        return this.Items.FirstOrDefault(site => site.IsCurrent);
      }
    }
  }
}