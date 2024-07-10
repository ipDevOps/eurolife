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

namespace Wedia.Feature.PageContent.Indexing
{
    public class PageContentIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
    {
        public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
        {
            var fieldNames = new[] {
              Templates.HasPageContent.Fields.Title_FieldName,
              Templates.HasPageContent.Fields.Summary_FieldName,
              Templates.HasPageBodyContent.Fields.Body_FieldName};
            return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
        }

        public string ContentType => DictionaryPhraseRepository.Current.Get("/Page Content/Search/Content Type", "Page");

        public IEnumerable<ID> SupportedTemplates => new[]
        {
            Templates.HasPageContent.ID
        };

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var contentItem = item.GetItem();
            formattedResult.Title = FieldRenderer.Render(contentItem, Templates.HasPageContent.Fields.Title.ToString());
            formattedResult.Description = FieldRenderer.Render(contentItem, Templates.HasPageContent.Fields.Summary.ToString());
        }
    }
}