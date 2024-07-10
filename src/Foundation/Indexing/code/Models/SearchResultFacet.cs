using System.Collections.Generic;

namespace Wedia.Foundation.Indexing.Models
{
  internal class SearchResultFacet : ISearchResultFacet
  {
    public IEnumerable<ISearchResultFacetValue> Values { get; set; }
    public IQueryFacet Definition { get; set; }
  }
}