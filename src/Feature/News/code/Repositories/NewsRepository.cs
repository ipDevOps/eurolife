using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Wedia.Feature.News.Models;
using Wedia.Feature.Search.Models;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.Indexing.Repositories;
using NewsPagingSettings = Wedia.Feature.News.Models.PagingSettings;

namespace Wedia.Feature.News.Repositories
{
  [Service(typeof(INewsRepository))]
  public class NewsRepository : INewsRepository
  {
    private readonly ISearchServiceRepository _searchServiceRepository;
    private readonly SearchSettingsBase _searchBaseSettings;

    public NewsRepository(ISearchServiceRepository searchServiceRepository)
    {
      _searchServiceRepository = searchServiceRepository;
      _searchBaseSettings = new SearchSettingsBase { Templates = new[] { Templates.NewsArticle.ID } };
    }

    public IEnumerable<Item> GetList(Item contextItem)
    {
      return Get(contextItem).OrderByDescending(i => i[Templates.NewsArticle.Fields.Date]);
    }

    public IEnumerable<Item> GetLatest(Item contextItem, int count)
    {
      return Get(contextItem).OrderByDescending(i => i[Templates.NewsArticle.Fields.Date]).Take(count);
    }

    public NewsPageResults GetPagedList(Item contextItem, NewsPagingSettings pagingSettings, int? page)
    {
      var pageNumber = page == null ? 0 : page < 0 ? 0 : page.Value;

      var searchService = _searchServiceRepository.Get(new SearchSettingsBase { Templates = new[] { Templates.NewsArticle.ID } });
      searchService.Settings.Root = contextItem;

      var results = searchService.FindAll(pageNumber * pagingSettings.ResultsOnPage, 
        pagingSettings.ResultsOnPage,
        Templates.NewsArticle.Fields.Date_FieldName,
        true);       

      return new NewsPageResults
      {
        ResultsOnPage = pagingSettings.ResultsOnPage,
        Results = results,
        TotalResults = results.TotalNumberOfResults,
        Page = pageNumber
      };
    }

    public ArticleNavigation GetArticleNavigation(Item contextItem)
    {
      var articleDate = GetArticleDate(contextItem);
      var parent = contextItem.GetParentBucketItemOrParent();

      var previous = Get(parent)
        .Where(i => GetArticleDate(i) < articleDate)
        .OrderByDescending(i => i[Templates.NewsArticle.Fields.Date])
        .Take(1).SingleOrDefault();

      var next = Get(parent)
        .Where(i => GetArticleDate(i) > articleDate)
        .OrderBy(i => i[Templates.NewsArticle.Fields.Date])
        .Take(1).SingleOrDefault();

      return new ArticleNavigation
      {
        PreviousItem = previous,
        NextItem = next
      };
    }

    private IEnumerable<Item> Get(Item contextItem)
    {
      var searchService = _searchServiceRepository
        .Get(_searchBaseSettings);

      searchService.Settings.Root = contextItem;

      var results = searchService.FindAll();

      return results.Results.Select(x => x.Item).Where(x => x != null);
    }

    private DateTime GetArticleDate(Item item)
    {
      var inputDate = (DateField)item.Fields[Templates.NewsArticle.Fields.Date];
      var createdDate = item.Created;
      
      if (string.IsNullOrEmpty(inputDate.Value))
        return createdDate;

      var sitecoreDate = Sitecore.DateUtil.IsoDateToServerTimeIsoDate(inputDate.Value);

      var convertedDate = DateTime.ParseExact(sitecoreDate, "yyyyMMddTHHmmss", Sitecore.Context.ContentLanguage.CultureInfo);
      return convertedDate;
    }

  }
}