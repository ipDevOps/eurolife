using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Feature.Search.Models
{
  public class SearchContext : ISearchSettings
  {
    public Item ConfigurationItem { get; set; }
    public string Query { get; set; }
    public string SearchBoxTitle { get; set; }
    public string SearchResultsUrl { get; set; }
    public IEnumerable<IQueryFacet> Facets { get; set; }
    public Item Root { get; set; }
    public IEnumerable<ID> Templates { get; set; }
    public bool MustHaveFormatter => true;
  }
}