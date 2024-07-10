using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Wedia.Foundation.Indexing.Repositories;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Foundation.Indexing.Infrastructure.Fields
{
  public class HasSearchResultFormatterComputedField : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      var indexItem = indexable as SitecoreIndexableItem;
      if (indexItem == null)
      {
        return null;
      }
      var item = indexItem.Item;

      return IndexingProviderRepository.SearchResultFormatters.Any(p => p.SupportedTemplates.Any(id => item.DescendsFrom(id)));
    }
  }
}