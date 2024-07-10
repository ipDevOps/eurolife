using Sitecore;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedia.Feature.Navigation.Repositories;
using Wedia.Foundation.Alerts;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.Dictionary.Repositories;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Feature.Navigation.Controllers
{
  public class NavigationController : Controller
  {
    private readonly INavigationRepository _navigationRepository;

    public NavigationController(INavigationRepository navigationRepository)
    {
      _navigationRepository = navigationRepository;
    }

    //Get drop menu
    public ActionResult DropMenu()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (!item?.DescendsFrom(Templates.DropMenuList.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor ?
            this.InfoMessage(new InfoMessage(AlertTexts.InvalidDataSourceTemplateFriendlyMessage, InfoMessage.MessageType.Error)) :
            null;
      }

      var vm = _navigationRepository.GetDropMenuCategories(item);
      return View(vm);
     }

    // GET: Breadcrumb
      public ActionResult Breadcrumb()
    {
      var items = _navigationRepository.GetBreadcrumb();
      return View(items);
    }

    public ActionResult LoginRegisterLinks() => GetMenu("LoginRegisterLinks");
    public ActionResult NavigationLinksList() => GetMenu("NavigationLinksList");
    public ActionResult FooterNavigationLinksList() => GetMenu("FooterNavigationLinksList");

    public ActionResult RoundedLinkMenu() => GetMenu("RoundedLinkMenu");

    public ActionResult UnderlinedLinkMenu() => GetMenu("UnderlinedLinkMenu",
        RenderingContext.Current.Rendering.GetBoolParameter(Constants.NavigationParameters.Descending),
        RenderingContext.Current.Rendering.GetIntegerParameter(Constants.NavigationParameters.Limit) + 1);

    public ActionResult BlogSocialLinks() => GetMenu("BlogSocialMenu");
    public ActionResult SocialLinks() => GetMenu("SocialMenu");

    public ActionResult LinksList() => GetMenu("UnderlinedLinkMenu");

    public ActionResult HorizontalNavigationLinks() => GetMenu("HorizontalNavigationLinks");

    public ActionResult HeaderTopNavigation() => GetHeaderNavigationMenu("HeaderTopNavigation");

    public ActionResult MainMenu()
    {     
      var item = RenderingContext.Current.Rendering.Item;
      var items = _navigationRepository.GetPrimaryMenu(item);

      return View("MainMenu", items);
    }

    public ActionResult GetHeaderNavigationMenu(string view, bool descending = false, int limit = 20)
    {
      if (HasError())
      {
        return ErrorResponse();
      }

      var item = RenderingContext.Current.Rendering.Item;
      var items = _navigationRepository.GetHeaderNavigationItems(item, descending, limit);

      return View(view, items);
    }

    public ActionResult GetMenu(string view, bool descending = false, int limit = 20)
    {
      if (HasError())
      {
        return ErrorResponse();
      }

      var item = RenderingContext.Current.Rendering.Item;
      var items = _navigationRepository.GetLinkMenuItems(item, descending, limit);

      return View(view, items);
    }

    private bool HasError()
    {
      return string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource);
    }

    private ViewResult ErrorResponse()
    {
      return Context.PageMode.IsExperienceEditor
            ? this.InfoMessage(
                new InfoMessage(
                    DictionaryPhraseRepository.Current.Get("/Navigation/Link Menu/Missing Datasource", "Missing Datasource"),
                    InfoMessage.MessageType.Warning))
                    : null;
    }
  }
}