using System.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Wedia.Foundation.Indexing.Repositories;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Foundation.Indexing.Models
{
  public class SearchResultFactory
  {
    public static ISearchResult Create(SearchResultItem result)
    {
      var item = result.GetItem();
      var formattedResult = new SearchResult(item);
      FormatResultUsingFirstSupportedProvider(result, item, formattedResult);
      return formattedResult;
    }

    private static void FormatResultUsingFirstSupportedProvider(SearchResultItem result, Item item, ISearchResult formattedResult)
    {
      var formatter = FindFirstSupportedFormatter(item) ?? IndexingProviderRepository.DefaultSearchResultFormatter;
      formattedResult.ContentType = formatter.ContentType;
      formatter.FormatResult(result, formattedResult);
    }

    private static ISearchResultFormatter FindFirstSupportedFormatter(Item item)
    {
      return IndexingProviderRepository.SearchResultFormatters.FirstOrDefault(provider => provider.SupportedTemplates.Any(item.DescendsFrom));
    }
  }
}