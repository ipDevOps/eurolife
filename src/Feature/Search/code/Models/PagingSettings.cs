namespace Wedia.Feature.Search.Models
{
  public class PagingSettings
  {
    private int pagesToShow;
    private int resultsOnPage;
    public const int DefaultResultsOnPage = 10;
    public const int DefaultPagesToShow = 5;

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