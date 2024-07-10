using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog.Models
{
  public class PagingSettings
  {
    private int resultsOnPage; 

    public string CurrentItemID { get; set; }
    public const int DefaultResultsOnPage = 6;    
    public bool ShowTags { get; set; }    
    public int CurrentPage { get; set; }
    public string OrderBy { get; set; }
    public Dictionary<string, string> IncludedFields { get; set; }
    public Dictionary<string, string> ExcludedFields { get; set; }

    public int ResultsOnPage
    {
      get
      {
        return resultsOnPage < 1 ? DefaultResultsOnPage : resultsOnPage;
      }
      set
      {
        resultsOnPage = value;
      }
    }
  }
}