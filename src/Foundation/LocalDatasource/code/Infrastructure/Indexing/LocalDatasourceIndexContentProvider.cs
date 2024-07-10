using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq.Expressions;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Wedia.Foundation.Indexing.Infrastructure;
using Wedia.Foundation.Indexing.Models;
using Sitecore.Web.UI.WebControls;
using Sitecore;

namespace Wedia.Foundation.LocalDatasource.Infrastructure.Indexing
{
  public class LocalDatasourceQueryPredicateProvider : ProviderBase, IQueryPredicateProvider
  {
    public IEnumerable<ID> SupportedTemplates => new[]
    {
      TemplateIDs.StandardTemplate
    };

    public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
    {
      var fieldNames = new[]
      {
        Templates.Index.Fields.LocalDatasourceContent_IndexFieldName
      };
      return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
    }
  }
}