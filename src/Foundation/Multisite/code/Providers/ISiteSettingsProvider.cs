using Sitecore.Data.Items;
using Sitecore.Web;

namespace Wedia.Foundation.Multisite.Providers
{
  public interface ISiteSettingsProvider
  {
    Item GetSetting(Item contextItem, string settingsType, string setting);
  }
}