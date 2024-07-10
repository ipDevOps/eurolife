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

namespace Wedia.Feature.Media.Indexing
{
  public class MediaIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
  {
    public string ContentType => DictionaryPhraseRepository.Current.Get("/Media/Search/Content Type", "MediaFeature");
    public IEnumerable<ID> SupportedTemplates => new[] { Templates.HasMedia.ID };

    public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
    {
      var contentItem = item.GetItem();

      formattedResult.Title = FieldRenderer.Render(contentItem, Templates.HasMedia.Fields.Title.ToString());
      formattedResult.Description = FieldRenderer.Render(contentItem, Templates.HasMedia.Fields.Description.ToString());
      formattedResult.Media = ((ImageField)contentItem.Fields[Templates.HasMedia.Fields.Thumbnail])?.MediaItem;
      formattedResult.ViewName = "~/Views/MediaFeature/MediaSearchResult.cshtml";
    }

    public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
    {
      var fieldNames = new[]
      {
        Templates.HasMedia.Fields.Title_FieldName,
        Templates.HasMedia.Fields.Description_FieldName,
        Templates.HasMedia.Fields.Thumbnail_FieldName,
        //Templates.HasMedia.Fields.Media_FirstPublishDate
      };

      return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
    }
  }
}