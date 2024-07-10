using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Wedia.Feature.Blog.Repositories
{
  public interface IBlogRepository
  {
    IEnumerable<Item> GetArticlesForSpecificYear(Item contextItem, string year);
    IEnumerable<Models.BlogPostItem> GetLatest(Item contextItem, int count, bool showTags = true, bool includeHostName = false);
    Models.ArticlesList GetPagedList(Item contextItem, Models.PagingSettings pagingSettings);
    Models.ArticleViewModel GetArticleViewModel(Item contextItem);
    Models.PromoSectionViewModel GetPromoSectionViewModel(Item contextItem);
    Models.ArticleSliderViewModel GetSliderData(Item contextItem);
  }
}
