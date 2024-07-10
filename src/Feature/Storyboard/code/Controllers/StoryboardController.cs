using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Wedia.Feature.Storyboard.Repositories;

namespace Wedia.Feature.Storyboard.Controllers
{
  public class StoryboardController : Controller
  {
    private readonly IStoryboardRepository _storyboardRepository;

    public StoryboardController(IStoryboardRepository storyboardRepository)
    {
      _storyboardRepository = storyboardRepository;
    }

    public ActionResult Index()
    {
      var items = _storyboardRepository.Get(RenderingContext.Current.Rendering.Item);
      return View(items);
    }
  }
}