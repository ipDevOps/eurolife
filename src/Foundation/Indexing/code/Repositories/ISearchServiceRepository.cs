using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.Indexing.Services;

namespace Wedia.Foundation.Indexing.Repositories
{
  public interface ISearchServiceRepository
  {
    SearchService Get(ISearchSettings searchSettings);
  }
}