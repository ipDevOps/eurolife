using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Sitecore;
using Sitecore.Data;
using Wedia.Foundation.SitecoreExtensions.Utilities;
using Sitecore.Diagnostics;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.Alerts;
using Wedia.Feature.PageContent.Repositories;

namespace Wedia.Feature.PageContent.Controllers
{
  public class PageContentController : Controller
  {
    private readonly IPageContentRepository _pageContentRepository;

    public PageContentController(IPageContentRepository pageContentRepository)
    {
      this._pageContentRepository = pageContentRepository;
    }

    public ActionResult InvestmentPlan()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (!item?.DescendsFrom(Templates.InvestmentPlan.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor ?
            this.InfoMessage(new InfoMessage(AlertTexts.InvalidDataSourceTemplateFriendlyMessage, InfoMessage.MessageType.Error)) :
            null;
      }

      var vm = _pageContentRepository.GetInvestmentPlanRendering(item);
      return View(vm);
    }
  }
}