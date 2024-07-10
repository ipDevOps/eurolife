using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq.Expressions;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Wedia.Foundation.Dictionary.Repositories;
using Wedia.Foundation.Indexing.Infrastructure;
using Wedia.Foundation.Indexing.Models;
using Sitecore.Web.UI.WebControls;

namespace Wedia.Feature.News.Indexing
{
  public class NewsIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
  {
    public string ContentType => DictionaryPhraseRepository.Current.Get("/News/Search/Content Type", "News");

    public IEnumerable<ID> SupportedTemplates => new[] { Templates.NewsArticle.ID };

    public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
    {
      var fieldNames = new[] {
        Templates.NewsArticle.Fields.Title_FieldName,
        Templates.NewsArticle.Fields.Summary_FieldName,
        Templates.NewsArticle.Fields.Body_FieldName,
        //Templates.NewsArticle.Fields.Date_FieldName
      };

      return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
    }

    public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
    {
      var contentItem = item.GetItem();

      if (contentItem == null)
      {
        return;
      }

      formattedResult.Title = FieldRenderer.Render(contentItem, Templates.NewsArticle.Fields.Title.ToString());
      formattedResult.Description = FieldRenderer.Render(contentItem, Templates.NewsArticle.Fields.Summary.ToString());
      formattedResult.Media = ((ImageField)contentItem.Fields[Templates.NewsArticle.Fields.DesktopImage])?.MediaItem;
      formattedResult.ViewName = "~/Views/News/NewsSearchResult.cshtml";
    }

    
  }
}