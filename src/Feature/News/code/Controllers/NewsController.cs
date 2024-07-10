using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Wedia.Feature.News.Models;
using Wedia.Feature.News.Repositories;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.Dictionary.Repositories;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Wedia.Foundation.SitecoreExtensions.Repositories;
using Wedia.Foundation.SitecoreExtensions.Utilities;
using Sitecore.Data.Items;
using System.Linq;

namespace Wedia.Feature.News.Controllers
{
  public class NewsController : Controller
  {
    private readonly INewsRepository _newsRepository;
    private readonly IRenderingPropertiesRepository _renderingPropertiesRepository;

    public NewsController(INewsRepository newsRepository, IRenderingPropertiesRepository renderingPropertiesRepository)
    {
      _newsRepository = newsRepository;
      _renderingPropertiesRepository = renderingPropertiesRepository;
    }

    public ActionResult LatestNewsGrid() => GetLatestArticles("LatestNewsGrid", DictionaryPhraseRepository
         .Current
         .Get("/News/Latest News/Missing Rendering Item", "Invalid or Missing Datasource"));

    public ActionResult CSRNewsList()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (item == null)
        return ErrorMessage(DictionaryPhraseRepository
          .Current
          .Get("/News/News List/Missing Rendering Item", "Invalid or Missing Datasource"));

      var items = _newsRepository.GetList(item);

      return View("CSRArticlesList", items);
    }

    public ActionResult LatestNews() => GetLatestArticles("LatestNews", DictionaryPhraseRepository
          .Current
          .Get("/News/Latest News/Missing Rendering Item", "Invalid or Missing Datasource"));

    public ActionResult LatestNewsImageless() => GetLatestArticles("LatestNewsListImageless", DictionaryPhraseRepository
          .Current
          .Get("/News/Latest News List Imageless/Missing Rendering Item", "Invalid or Missing Datasource"));

    public ActionResult ArticleNavigation()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (item == null || !item.DescendsFrom(Templates.NewsArticle.ID))
        return ErrorMessage(DictionaryPhraseRepository
          .Current
          .Get("/News/Article Navigation/Missing Rendering Item", "Invalid or Missing Datasource"));

      var navigation = _newsRepository.GetArticleNavigation(item);
      return View("ArticleNavigation", navigation);
    }

    public ActionResult PagedNewsList()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (item == null || !item.DescendsFrom(Templates.NewsFolder.ID))
        return ErrorMessage(DictionaryPhraseRepository
          .Current
          .Get("/News/News List/Missing Rendering Item", "Invalid or Missing Datasource"));

      var pagingSettings = _renderingPropertiesRepository.Get<PagingSettings>(RenderingContext.Current.Rendering);

      return GetPagedResults(item, pagingSettings);
    }

    [HttpGet]
    public ActionResult AjaxPagedList(NewsPagingDto pagingDto, int page = 0)
    {
      var item = Context.Database.GetItem(new ID(pagingDto.CurrentItemID));

      if (item == null || !item.DescendsFrom(Templates.NewsFolder.ID))
        return ErrorMessage(DictionaryPhraseRepository
          .Current
          .Get("/News/News List/Missing Rendering Item", "Invalid or Missing Datasource"));

      return GetPagedResults(item, pagingDto, page, true);
    }

    private ActionResult GetLatestArticles(string viewName, string errorMessage)
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (item == null)
        return ErrorMessage(errorMessage);


      var count = RenderingContext.Current.Rendering.GetIntegerParameter("count", Contants.LatestNews.NumberOfArticles);
      var items = _newsRepository.GetLatest(RenderingContext.Current.Rendering.Item, count);

      return View(viewName, items);
    }

    private ActionResult GetPagedResults(Item item, PagingSettings pagingSettings, int page = 0, bool isPartial = false)
    {
      var results = _newsRepository.GetPagedList(item, pagingSettings, page);

      if (!isPartial)
        return View("PagedNewsList", results);


      if (!results.Results.Results.Any())
        return Json(new { exhausted = true });

      var partial = Utilities.RenderRazorViewToString(ControllerContext, "PagedListItems", results);
      return Json(new { exhausted = results.TotalPagesCount == page + 1, data = partial }, JsonRequestBehavior.AllowGet);
    }

    private ViewResult ErrorMessage(string message)
    {
      return Context.PageMode.IsExperienceEditor
            ? this.InfoMessage(new InfoMessage(message, InfoMessage.MessageType.Warning))
                    : null;
    }
  }
}