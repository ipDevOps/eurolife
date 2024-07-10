using System;
using System.Collections.Generic;
using System.Linq;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Dictionary.Repositories;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Foundation.Indexing.Services
{
  [Service]
  public class FormatBooleanFacetService
  {
    private readonly IDictionary<string, bool> booleanValues = new Dictionary<string, bool> { { "0", false }, { "1", true }, { "yes", true }, { "no", false }, { "true", true }, { "false", false } };

    private bool IsBoolean(ISearchResultFacet facet)
    {
      if (facet.Values.Count() > 3)
        return false;
      return facet.Values.All(v => v.Value is bool || string.IsNullOrWhiteSpace(v.Value?.ToString()) || this.booleanValues.ContainsKey(v.Value?.ToString().ToLowerInvariant()));
    }

    public bool Format(ISearchResultFacet facet)
    {
      if (!this.IsBoolean(facet))
        return false;
      this.FormatValues(facet);
      return true;
    }

    private void FormatValues(ISearchResultFacet facet)
    {
      foreach (var value in facet.Values)
      {
        if (string.IsNullOrWhiteSpace(value.Value?.ToString()))
          continue;
        var booleanValue = value.Value as bool? ?? this.booleanValues[value.Value.ToString()];

        value.Title = booleanValue ? DictionaryPhraseRepository.Current.Get("/Indexing/Facets/True", "Yes") : DictionaryPhraseRepository.Current.Get("/Indexing/Facets/False", "No");
      }
    }
  }
}