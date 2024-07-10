using Sitecore;
using System;
using Sitecore.Data.Items;

namespace Wedia.Feature.Teasers.Models
{
    public class DynamicTeaserItem
    {
        [CanBeNull]
        public Item Item { get; set; }

        [CanBeNull]
        public string Title { get; set; }

        public bool IsActive { get; set; }

        public string HeaderId { get; set; }

        public string PanelId { get; set; }

        public DynamicTeaserItem()
        {
            HeaderId = $"header{Guid.NewGuid().ToString("N")}";
            PanelId = $"panel{Guid.NewGuid().ToString("N")}";
        }

        public DynamicTeaserItem(Item headline) : this()
        {
            Item = headline;
            Title = headline[Templates.HasTeaserHeadline.Fields.Title];
        }
    }
}