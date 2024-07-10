using System.Collections.Generic;
using System.Configuration.Provider;
using Wedia.Feature.Search.Repositories;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Feature.Search.Infrastructure.Providers
{
  [Service]
  public class DefaultFacetProvider : ProviderBase, IQueryFacetProvider
  {
    public DefaultFacetProvider(ISearchContextRepository searchContextRepository)
    {
      this.SearchContextRepository = searchContextRepository;
    }

    public IEnumerable<IQueryFacet> GetFacets()
    {
      var context = this.SearchContextRepository.Get();
      return context.Facets;
    }

    public ISearchContextRepository SearchContextRepository { get; }
  }
}