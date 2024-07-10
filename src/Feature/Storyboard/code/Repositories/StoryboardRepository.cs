using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.Indexing.Repositories;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Feature.Storyboard.Repositories
{
    [Service(typeof(IStoryboardRepository))]
    public class StoryboardRepository : IStoryboardRepository
    {
        private readonly ISearchServiceRepository _searchServiceRepository;

        public StoryboardRepository(ISearchServiceRepository searchServiceRepository)
        {
            _searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<Item> Get(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }

            if (!contextItem.DescendsFrom(Templates.StoryboardItemsFolder.ID))
            {
                throw new ArgumentException("Item must derive from StoryboardItemFolder", nameof(contextItem));
            }

            //return contextItem.Children.Where(c => c.DescendsFrom(Templates.StoryboardItem.ID)).ToList();
            var searchService = _searchServiceRepository.Get(new SearchSettingsBase { Templates = new[] { Templates.StoryboardItem.ID } });
            searchService.Settings.Root = contextItem;
        
            var results = searchService.FindAll();
            return results.Results.Select(x => x.Item).Where(x => x != null).OrderBy(i => i[Templates.StoryboardItem.Fields.Year]);
        }
    }
}