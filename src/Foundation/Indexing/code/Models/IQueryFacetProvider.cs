using System.Collections.Generic;

namespace Wedia.Foundation.Indexing.Models
{
  public interface IQueryFacetProvider
  {
    IEnumerable<IQueryFacet> GetFacets();
  }
}