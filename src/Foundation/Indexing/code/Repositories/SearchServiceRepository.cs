using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.Indexing.Services;

namespace Wedia.Foundation.Indexing.Repositories
{
  [Service(typeof(ISearchServiceRepository))]
  public class SearchServiceRepository : ISearchServiceRepository
  {
    public virtual SearchService Get(ISearchSettings settings)
    {
      return new SearchService(settings);
    }
  }
}