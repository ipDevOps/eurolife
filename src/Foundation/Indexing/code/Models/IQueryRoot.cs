using Sitecore.Data.Items;

namespace Wedia.Foundation.Indexing.Models
{
  public interface IQueryRoot
  {
    Item Root { get; set; }
  }
}