using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wedia.Feature.Identity.Models;
using Wedia.Feature.Identity.Services;
using Wedia.Foundation.Dictionary.Repositories;

namespace Wedia.Feature.Identity.Controllers
{
  public class IdentityController : Controller
  {
    private readonly INewsletterService _newsletterService;

    public IdentityController(INewsletterService newsletterService)
    {
      _newsletterService = newsletterService;
    }

    public ActionResult NewsletterForm()
    {
      return View(_newsletterService.GetFormViewModel());
    }

    [HttpPost]
    public ActionResult AjaxNewsletterRegister(NewsletterDto newsletterDto)
    {
      if (!ModelState.IsValid)
      {
        ControllerContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return Json(new { message = DictionaryPhraseRepository.Current.Get("Identity/Newsletter/Invalid Email") });
      }

      var response = _newsletterService.Register(newsletterDto);

      ControllerContext.HttpContext.Response.StatusCode = response.StatusCode;

      return Json(response);
    }
  }
}