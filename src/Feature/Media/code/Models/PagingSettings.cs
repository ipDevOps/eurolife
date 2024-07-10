using Sitecore.Data;

namespace Wedia.Feature.Media.Models
{
  public class PagingSettings
  {
    private int resultsOnPage;
    private int pagesToShow;
    public const int DefaultResultsOnPage = 10;
    public const int DefaultPagesToShow = 5;

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

    public int PagesToShow
    {
      get
      {
        return pagesToShow < 1 ? DefaultPagesToShow : pagesToShow;
      }
      set
      {
        pagesToShow = value;
      }
    }

    public ID CurrentGroupID { get; set; }
  }
}