using System.Collections.Generic;
using Sitecore.Data;

namespace Wedia.Foundation.Indexing.Models
{
  public interface ISearchSettings : IQueryRoot
  {
    IEnumerable<ID> Templates { get; }
    bool MustHaveFormatter { get; }
  }
}