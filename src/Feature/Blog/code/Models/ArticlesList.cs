using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog.Models
{
  public class ArticlesList
  {
    public int Page { get; set; }
    public int TotalResults { get; set; }
    public int ResultsOnPage { get; set; }
    public bool ShowLoadMore { get; set; }
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

    public IEnumerable<BlogPostItem> Articles { get; set; }
  }
}