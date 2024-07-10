using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Wedia.Feature.Panels.Models;

namespace Wedia.Feature.Panels.Repositories
{
  public interface IPanelsRepository
  {
    IEnumerable<PanelItem> GetItems(Item panel);
    IEnumerable<PanelCategory> GetCategories(Item panel);
    IEnumerable<PanelRow> GetFilters(Item panel);
    IEnumerable<Item> GetMultiListValueItems(Item item, ID field, ID template);
  }
}
