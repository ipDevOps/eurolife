using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data.Items;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Feature.Teasers.Models
{
    public class DynamicTeaserModel
    {
        private DynamicTeaserItem[] _items;

        public DynamicTeaserModel([NotNull] Item dynamicTeaser)
        {
            if (dynamicTeaser == null)
                throw new ArgumentNullException(nameof(dynamicTeaser));

            Item = dynamicTeaser;
            Id = $"accordion-{Guid.NewGuid().ToString("N")}";
        }

        public Item Item { get; set; }

        public string Id { get; set; }

        public IEnumerable<DynamicTeaserItem> Items
        {
            get
            {
                if(_items != null)
                {
                    return _items;
                }

                _items = CreateDynamicTeaserItems();
                SetActiveItem(_items);
                return _items;
            }
        }

        private DynamicTeaserItem[]  CreateDynamicTeaserItems()
        {
            var childItems = Item.Children.Where(i => i.DescendsFrom(Templates.HasTeaserHeadline.ID)).ToArray();
            DynamicTeaserItem[] returnItems = { };

            if (childItems.Any())
            {
                returnItems = childItems.Select(i => new DynamicTeaserItem(i)).ToArray();
            }
            else
            {
                var count = Item.GetInteger(Templates.DynamicTeaser.Fields.Count);

                if (count.HasValue)
                {
                    returnItems = new object[count.Value].Select(o => new DynamicTeaserItem()).ToArray();
                }
            }

            return returnItems;

        }

        private void SetActiveItem(IReadOnlyList<DynamicTeaserItem> items)
        {
            if (!items.Any())
                return;

            var active = Item.GetInteger(Templates.DynamicTeaser.Fields.Active);

            if(active.HasValue)
            {
                var activeItem = items.ElementAtOrDefault(active.Value);

                if (activeItem != null)
                {
                    activeItem.IsActive = true;
                    return;
                }
            }

            items[0].IsActive = true;

        }
    }
}