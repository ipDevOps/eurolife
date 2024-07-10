using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Foundation.Indexing.Infrastructure.Fields
{
  public class SortOrderField : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      int DefaultSortOrderValue = 0;

      var item = (Item)(indexable as SitecoreIndexableItem);
      if (item == null) return null;

      if (string.IsNullOrEmpty(item[Sitecore.FieldIDs.Sortorder]))
      {
        return DefaultSortOrderValue;
      }

      return int.TryParse(item[Sitecore.FieldIDs.Sortorder], out int sortOrder)
          ? sortOrder
          : DefaultSortOrderValue;
    }      
  }
}