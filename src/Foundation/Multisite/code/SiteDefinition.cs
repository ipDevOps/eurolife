using Sitecore.Data.Items;
using Sitecore.Web;

namespace Wedia.Foundation.Multisite
{
  public class SiteDefinition
  {
    public Item Item { get; set; }
    public string HostName { get; set; }
    public string Name { get; set; }
    public bool IsCurrent { get; set; }
    public SiteInfo Site { get; set; }
  }
}