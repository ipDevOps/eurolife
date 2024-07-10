using Sitecore.ContentSearch;
using Wedia.Foundation.DependencyInjection;

namespace Wedia.Foundation.Indexing.Services
{
    [Service]
    public class SearchIndexResolver
    {
        public virtual ISearchIndex GetIndex(SitecoreIndexableItem contextItem)
        {
            return ContentSearchManager.GetIndex(contextItem);
        }
    }
}