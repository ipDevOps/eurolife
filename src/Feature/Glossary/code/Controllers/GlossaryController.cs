using Sitecore;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedia.Feature.Glossary.Repositories;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.Dictionary.Repositories;

namespace Wedia.Feature.Glossary.Controllers
{
  public class GlossaryController : Controller
  {
    private readonly IGlossaryRepository _glossaryRepository;

    public GlossaryController(IGlossaryRepository glossaryRepository)
    {
      _glossaryRepository = glossaryRepository;
    }

    public ActionResult GlossaryList()
    {
      var contextItem = RenderingContext.Current.Rendering.Item;

      if (contextItem == null)
      {
        return Context.PageMode.IsExperienceEditor
            ? this.InfoMessage(
                new InfoMessage(
                    DictionaryPhraseRepository.Current.Get("/Glossary/Glossary List/No Context", "No Context"),
                    InfoMessage.MessageType.Warning))
                    : null;
      }

      var items = _glossaryRepository.GetGroups(contextItem);

      return View("GlossaryList", items);
    }
  }
}