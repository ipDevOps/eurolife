using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Sitecore.Abstractions;
using Wedia.Feature.Language.Infrastructure.Pipelines;
using Wedia.Feature.Language.Models;
using Wedia.Feature.Language.Repositories;
using Wedia.Foundation.SitecoreExtensions.Attributes;
using Sitecore.Pipelines;

namespace Wedia.Feature.Language.Controllers
{
  public class LanguageController : Controller
  {
    public const string ChangeLanguagePipeline = "language.changeLanguage";

    private ILanguageRepository LanguageRepository { get; }
    private BaseCorePipelineManager PipelineManager { get; }

    public LanguageController(ILanguageRepository languageRepository, BaseCorePipelineManager pipelineManager)
    {
      this.LanguageRepository = languageRepository;
      this.PipelineManager = pipelineManager;
    }

    [HttpPost]
    [SkipAnalyticsTracking]
    public JsonResult ChangeLanguage(string newLanguage, string currentLanguage)
    {
      var args = new ChangeLanguagePipelineArgs(currentLanguage, newLanguage);
      this.PipelineManager.Run(ChangeLanguagePipeline, args, false);

      return new JsonResult { Data = args.CustomData };
    }

    public ActionResult LanguageSelector()
    {
      var model = new LanguageSelector
      {
        ActiveLanguage = this.LanguageRepository.GetActive(),
        SupportedLanguages = this.LanguageRepository.GetSupportedLanguages().ToList()
      };
      return this.View(model);
    }
  }
}