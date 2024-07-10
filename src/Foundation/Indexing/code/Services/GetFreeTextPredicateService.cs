using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Foundation.Indexing.Infrastructure
{
    public static class GetFreeTextPredicateService
    {
        public static Expression<Func<SearchResultItem, bool>> GetFreeTextPredicate(string[] fieldNames, IQuery query)
        {
            var predicate = PredicateBuilder.False<SearchResultItem>();
            if (string.IsNullOrWhiteSpace(query.QueryText))
            {
                return predicate;
            }
            foreach (var name in fieldNames)
            {
              predicate = predicate                                   
                                   .Or(i => i[name].Contains(query.QueryText))                          
                                   .Or(i => i[name].Contains(RemoveDiacritics(query.QueryText))); 
            }
            return predicate;
        }

      static string RemoveDiacritics(string text)
      {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
          var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
          if (unicodeCategory != UnicodeCategory.NonSpacingMark)
          {
            stringBuilder.Append(c);
          }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
      }
  }
}