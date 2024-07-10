using System;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Foundation.Theming.Extensions
{
    public static class SiteExtensions
    {
        public static string GetThemeColor(this SiteContext site)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var item = Sitecore.Context.Item;

            if (item == null || !item.DescendsFrom(Templates.ThemeClasses.ID))
                return Constants.ThemeClasses.Color;


            var targetItem = item.TargetItem(Templates.ThemeClasses.Fields.Color);

            if (targetItem == null)
                return Constants.ThemeClasses.Color;

            var themeClass = targetItem[Templates.Style.Fields.Class];

            if (themeClass == null || string.IsNullOrEmpty(themeClass))
                return Constants.ThemeClasses.Color;

            return themeClass;
        }
    }
}