using Sitecore;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Web.Mvc;
using Wedia.Feature.Person.Repositories;
using Wedia.Foundation.Alerts;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.Dictionary.Repositories;
using Sitecore.Data.Items;

namespace Wedia.Feature.Person.Controllers
{
  public class PersonsController : Controller
  {
    private readonly IPersonRepository _personRepository;

    public PersonsController(IPersonRepository personRepository)
    {
      _personRepository = personRepository;
    }

    public ActionResult Index(int? page)
    {
      var items = _personRepository.GetEmployeesOrdered(RenderingContext.Current.Rendering.Item);
      return View(items);
    }

    public ActionResult ExecutiveEmployeesCarousel() => GetCarousel("ExecutiveEmployeesCarousel");
    public ActionResult EmployeesCarousel() => GetCarousel("EmployeesCarousel");

    public ActionResult ConsultantsList()
    {
      var contextItem = RenderingContext.Current.Rendering.Item;

      if (contextItem == null)
      {
        return Context.PageMode.IsExperienceEditor
            ? this.InfoMessage(
                new InfoMessage(
                    DictionaryPhraseRepository.Current.Get("/Person/Consultants List/No Context", "No Context"),
                    InfoMessage.MessageType.Warning))
                    : null;
      }

      var items = _personRepository.GetConsultantsGroups(contextItem);

      return View(items);
    }

    public ActionResult GetCarousel(string viewName)
    {
      var contextItem = RenderingContext.Current.Rendering.Item;
      var pageItem = PageContext.Current.Item;

      if (!contextItem?.DescendsFrom(Templates.PersonGroup.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor
            ? this.InfoMessage(
                new InfoMessage(
                    AlertTexts.InvalidDataSourceTemplateFriendlyMessage,
                    InfoMessage.MessageType.Warning))
                    : null;
      }

      return View(viewName, _personRepository.GetCarousel(contextItem, pageItem));
    }

  }
}