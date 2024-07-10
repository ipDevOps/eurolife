using System.Collections.Generic;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Feature.Search.Models
{
  public class SearchQuery : IQuery
  {
    public string QueryText { get; set; }
    public int Page { get; set; }
    public int NoOfResults { get; set; }
    public Dictionary<string, string[]> Facets { get; set; }
  }
}