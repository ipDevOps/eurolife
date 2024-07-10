using System.Web.Mvc;
using Wedia.Feature.Teasers.Models;
using Wedia.Foundation.Alerts;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Sitecore.Mvc.Presentation;
using Sitecore;

namespace Wedia.Feature.Teasers.Controllers
{
  public class TeasersController : Controller
  {
    public ActionResult GetDynamicContent(string viewName)
    {
      var dataSourceItem = RenderingContext.Current.Rendering.Item;

      if (!dataSourceItem?.DescendsFrom(Templates.DynamicTeaser.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor ?
            this.InfoMessage(new InfoMessage(AlertTexts.InvalidDataSourceTemplateFriendlyMessage, InfoMessage.MessageType.Error)) :
            null;
      }

      var model = new DynamicTeaserModel(dataSourceItem);

      return View(viewName, model);
    }

    public ActionResult TeaserList() => GetDynamicContent("TeaserList");
    public ActionResult GreyCTAList() => GetDynamicContent("GreyCTAList");
    public ActionResult ThreeColumnsTeaser() => GetDynamicContent("ThreeColumnsTeaser");

    public ActionResult ColoredTeaserList() => GetDynamicContent("ColoredTeaserList");
    public ActionResult BoardList() => GetDynamicContent("BoardList");
  }
}