using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Feature.Media.Models
{
  public class FileQuery : IQuery
  {
    public string QueryText { get; set; }
    public int NoOfResults { get; set; }
    public Dictionary<string, string[]> Facets { get; set; }
    public int Page { get; set; }
  }
}