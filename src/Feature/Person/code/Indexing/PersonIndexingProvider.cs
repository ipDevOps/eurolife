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

namespace Wedia.Feature.Person.Indexing
{
    public class PersonIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
    {
        public string ContentType => DictionaryPhraseRepository.Current.Get("/Person/Search/Content Type", "Person");
        public IEnumerable<ID> SupportedTemplates => new[] { Templates.Person.ID };

        public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
        {
            var fieldNames = new[]
            {
                Templates.Person.Fields.Title_FieldName,
                Templates.Person.Fields.Name_FieldName,
                Templates.HasPersonPosition.Fields.Position_FieldName
            };

            return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
        }

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var contentItem = item.GetItem();
            formattedResult.Title = FieldRenderer.Render(contentItem, Templates.Person.Fields.Name.ToString());
            formattedResult.Description = FieldRenderer.Render(contentItem, Templates.HasPersonPosition.Fields.Position.ToString());
            formattedResult.Media = ((ImageField)contentItem.Fields[Templates.HasPersonImage.Fields.Image])?.MediaItem;
            formattedResult.ViewName = "~/Views/Persons/PersonSearchResult.cshtml";
        }
    }
}