using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedia.Feature.Search.Models;
using Wedia.Feature.Search.Services;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.DependencyInjection;

namespace Wedia.Feature.Search.Factories
{
  [Service]
  public class SearchResultsViewModelFactory
  {
    public SearchResultsViewModelFactory(FacetQueryStringService facetQueryStringService)
    {
      this.FacetQueryStringService = facetQueryStringService;
    }

    public SearchResultsViewModel Create(IQuery searchQuery, ISearchResults results, int pagesToShow, int resultsOnPage)
    {
      var facets = searchQuery.Facets == null ? null : this.FacetQueryStringService.GetFacetQueryString(searchQuery.Facets);
      return new SearchResultsViewModel
      {
        VisiblePagesCount = pagesToShow,
        TotalResults = results.TotalNumberOfResults,
        ResultsOnPage = resultsOnPage,
        Query = searchQuery.QueryText,
        Facets = facets,
        Results = results,
        Page = searchQuery.Page
      };
    }

    private FacetQueryStringService FacetQueryStringService { get; }
  }
}