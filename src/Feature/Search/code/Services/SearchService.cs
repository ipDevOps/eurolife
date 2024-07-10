using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Wedia.Feature.Search.Factories;
using Wedia.Feature.Search.Models;
using Wedia.Feature.Search.Repositories;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.Indexing.Repositories;
using Wedia.Foundation.SitecoreExtensions.Services;
using Sitecore.Mvc.Presentation;

namespace Wedia.Feature.Search.Services
{
  [Service]
  public class SearchService
  {
    public SearchService(SearchResultsViewModelFactory searchResultsViewModelFactory, ISearchServiceRepository searchServiceRepository, ISearchContextRepository searchContextRepository, FacetQueryStringService facetQueryStringService, ITrackerService trackerService)
    {
      _searchResultsViewModelFactory = searchResultsViewModelFactory;
      _searchServiceRepository = searchServiceRepository;
      _searchContextRepository = searchContextRepository;
      _facetQueryStringService = facetQueryStringService;
      TrackerService = trackerService;
    }

    private readonly ISearchServiceRepository _searchServiceRepository;
    private readonly SearchResultsViewModelFactory _searchResultsViewModelFactory;
    private readonly ISearchContextRepository _searchContextRepository;
    private readonly FacetQueryStringService _facetQueryStringService;
    private ITrackerService TrackerService { get; set; }

    public SearchResultsViewModel Search(string query, int? page, string facets, PagingSettings pagingSettings)
    {
      var pageNumber = page == null ? 0 : page < 0 ? 0 : page.Value;
      query = query ?? string.Empty;

      var searchQuery = new SearchQuery
      {
        QueryText = query,
        Page = pageNumber,
        NoOfResults = pagingSettings.ResultsOnPage,
        Facets = _facetQueryStringService.ParseFacets(facets)
      };

      var searchContext = _searchContextRepository.Get();
      var results = _searchServiceRepository.Get(searchContext).Search(searchQuery);
      RegisterSearchPageEvent(query, results);
      return _searchResultsViewModelFactory.Create(searchQuery, results, pagingSettings.PagesToShow, pagingSettings.ResultsOnPage);
    }

    private void RegisterSearchPageEvent(string searchQuery, ISearchResults results)
    {
      TrackerService.TrackPageEvent(AnalyticsIds.SearchEvent.ToGuid(), searchQuery, searchQuery, searchQuery?.ToLowerInvariant(), results.TotalNumberOfResults);
      if (results.TotalNumberOfResults == 0)
        TrackerService.TrackPageEvent(AnalyticsIds.NoSearchHitsFound.ToGuid(), searchQuery, searchQuery, searchQuery?.ToLowerInvariant());
    }

    public SearchResultsViewModel SearchFromTopResults(string query, int count)
    {
      var searchQuery = new SearchQuery
      {
        QueryText = query,
        Page = 0,
        NoOfResults = count
      };

      var results = _searchServiceRepository.Get(_searchContextRepository.Get()).Search(searchQuery);
      return _searchResultsViewModelFactory.Create(searchQuery, results, 1, count);
    }
  }
}