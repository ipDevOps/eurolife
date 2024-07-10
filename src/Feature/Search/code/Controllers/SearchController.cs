using System.Linq;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Wedia.Feature.Search.Models;
using Wedia.Feature.Search.Repositories;
using Wedia.Feature.Search.Services;
using Wedia.Foundation.SitecoreExtensions.Attributes;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Wedia.Foundation.SitecoreExtensions.Repositories;
using Sitecore.Mvc.Presentation;
using Sitecore;
using Constants = Wedia.Foundation.Indexing.Constants;
using Wedia.Foundation.SitecoreExtensions.Utilities;

namespace Wedia.Feature.Search.Controllers
{
  public class SearchController : Controller
  {
    private readonly ISearchContextRepository _searchContextRepository;
    private readonly FacetQueryStringService _facetQueryStringService;
    private readonly SearchService _searchService;
    private readonly IRenderingPropertiesRepository _renderingPropertiesRepository;

    public SearchController(ISearchContextRepository contextRepository, FacetQueryStringService facetQueryStringService, SearchService searchService, IRenderingPropertiesRepository renderingPropertiesRepository)
    {
      _searchContextRepository = contextRepository;
      _facetQueryStringService = facetQueryStringService;
      _searchService = searchService;
      _renderingPropertiesRepository = renderingPropertiesRepository;
    }

    public ActionResult SearchResults(string query)
    {
      var searchResults = GetSearchResults(query, null, null);
      return View(searchResults.Results);
    }

    public ActionResult PagedSearchResults(string query, int? page, string facets)
    {
      var results = GetSearchResults(query, page, facets);
      return View(results);
    }

    public ActionResult GlobalSearch()
    {
      var searchContext = _searchContextRepository.Get();
      if (searchContext == null)
      {
        Log.Warn("Attempting to show GlobalSearch without a search context", this);
        return new EmptyResult();
      }
      return View(_searchContextRepository.Get());
    }

    public ActionResult SearchResultsHeader(string query, int? page, string facets)
    {
      var searchContext = _searchContextRepository.Get();
      if (searchContext == null)
      {
        Log.Warn("Attempting to show SearchResultsHeader without a search context", this);
        return new EmptyResult();
      }

      var results = new SearchResultsHeader
      {
        Context = _searchContextRepository.Get(),
        Results = GetSearchResults(query, page, facets)
      };

      return View(results);
    }

    [HttpGet]
    [SkipAnalyticsTracking]
    public ActionResult AjaxSearchResults(string query, int resultsOnPage, int? page, string facets)
    {
      var paggingSettings = new PagingSettings { ResultsOnPage = resultsOnPage };

      var searchResults = GetSearchResults(query, page, facets, paggingSettings);

      if (!searchResults.Results.Results.Any())
        return Json(new { exhausted = true });

      var partial = Utilities.RenderRazorViewToString(ControllerContext, "SearchResults", searchResults.Results);
      return Json(new { exhausted = searchResults.TotalPagesCount == page + 1, data = partial }, JsonRequestBehavior.AllowGet);
    }

    private SearchResultsViewModel GetSearchResults(string query, int? page, string facets, PagingSettings paggingSettings = null)
    {
      if (HttpContext.Items.Contains("SearchResults"))
      {
        return HttpContext.Items["SearchResults"] as SearchResultsViewModel;
      }
      

      var pagingSettings = paggingSettings ?? _renderingPropertiesRepository.Get<PagingSettings>(RenderingContext.Current.Rendering);
      var viewModel = _searchService.Search(query, page, facets, pagingSettings);

      HttpContext?.Items.Add("SearchResults", viewModel);
      return viewModel;
    }
  }
}