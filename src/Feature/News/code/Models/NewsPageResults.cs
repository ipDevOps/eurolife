using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Wedia.Foundation.Indexing.Models;

namespace Wedia.Feature.News.Models
{
  public class NewsPageResults
  {
    public ISearchResults Results { get; set; }
    public int Page { get; set; }
    public int TotalResults { get; set; }
    public int ResultsOnPage { get; set; }
    public virtual int TotalPagesCount
    {
      get
      {
        var pageCount = TotalResults / ResultsOnPage;
        if (TotalResults % ResultsOnPage > 0)
        {
          pageCount++;
        }

        return pageCount;
      }
    }
  }
}