using System;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Foundation.Theming.Extensions
{
  public static class ItemExtensions
  {
    public static string GetBackgroundClass(this Item item, ID field)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }

      var targetItem = item.TargetItem(field);

      return targetItem?.Fields[Templates.Style.Fields.Class]?.Value ?? "";
    }
  }
}