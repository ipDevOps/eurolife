﻿using System.Collections.Generic;
using System.Configuration.Provider;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Foundation.Indexing.Infrastructure.Providers
{
    public class FallbackSearchResultFormatter : ProviderBase, ISearchResultFormatter
    {
        public string ContentType => "[Unknown]";

        public IEnumerable<ID> SupportedTemplates => new ID[0];

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            formattedResult.Title = $"[{item.Name}]";
            formattedResult.Description = $"[This item is indexed but has no content provider: {item.Path}]";
        }

    }
}