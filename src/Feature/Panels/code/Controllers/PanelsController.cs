using Sitecore;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedia.Feature.Panels.Builders;
using Wedia.Foundation.Alerts;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;

namespace Wedia.Feature.Panels.Controllers
{
  public class PanelsController : Controller
  {
    private readonly IPanelsBuilder _panelsBuilder;

    public PanelsController(IPanelsBuilder panelsBuilder)
    {
      _panelsBuilder = panelsBuilder;
    }

    public ActionResult CreateProductPanel()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (!item?.DescendsFrom(Templates.Panel.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor
            ? this.InfoMessage(
                new InfoMessage(
                    AlertTexts.InvalidDataSourceTemplateFriendlyMessage,
                    InfoMessage.MessageType.Warning))
                    : null;
      }

      var panel = _panelsBuilder.Build(item);

      return View("ProductPanel", panel);
    }

    public ActionResult CreateProductPanelsGroup()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (!item?.DescendsFrom(Templates.PanelGroup.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor
          ? this.InfoMessage(
              new InfoMessage(
                  AlertTexts.InvalidDataSourceTemplateFriendlyMessage,
                  InfoMessage.MessageType.Warning
                ))
                : null;
      }

      var group = _panelsBuilder.BuildGroup(item);

      return View("ProductPanelsGroup", group);
    }


  }
}