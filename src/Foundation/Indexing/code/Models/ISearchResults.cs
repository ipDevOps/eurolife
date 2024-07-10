using System.Collections.Generic;

namespace Wedia.Foundation.Indexing.Models
{
  public interface ISearchResults
  {
    IEnumerable<ISearchResultFacet> Facets { get; }
    IEnumerable<ISearchResult> Results { get; }
    int TotalNumberOfResults { get; }
  }
}