using System;
using System.Collections.Generic;
using Sitecore.Data.Items;
using Wedia.Feature.News.Models;

namespace Wedia.Feature.News.Repositories
{
  public interface INewsRepository
  {
    IEnumerable<Item> GetList(Item contextItem);
    IEnumerable<Item> GetLatest(Item contextItem, int count);
    ArticleNavigation GetArticleNavigation(Item contextItem);
    NewsPageResults GetPagedList(Item contextItem, PagingSettings pagingSettings, int? page);
  }
}
