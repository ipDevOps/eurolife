using Sitecore.Data.Items;

namespace Wedia.Feature.News.Models
{
  public class ArticleNavigation
  {
    public Item PreviousItem { get; set; }
    public Item NextItem { get; set; }
  }
}