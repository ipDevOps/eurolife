using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Wedia.Foundation.SitecoreExtensions.Extensions;


namespace Wedia.Foundation.Indexing.Infrastructure.Fields
{
  public class ItemIDField : IComputedIndexField
  {
    public string FieldName { get; set; }

    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      Item i = indexable as SitecoreIndexableItem;
      return i.ID.ToString().ToLower().Replace("-", "").TrimStart('{').TrimEnd('}');
    }
  }
}