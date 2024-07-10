namespace Wedia.Feature.News.Models
{
  public class PagingSettings
  {
    private int resultsOnPage;
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
  }
}