using System.Collections.Generic;

namespace Wedia.Foundation.Indexing.Models
{
  public interface ISearchResultFacet
  {
    IQueryFacet Definition { get; set; }
    IEnumerable<ISearchResultFacetValue> Values { get; set; }
  }
}