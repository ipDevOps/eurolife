using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Foundation.SitecoreExtensions.Infrastructure.Pipelines
{
  public class CountryLanguageEnforcer : HttpRequestProcessor
  {
    public override void Process(HttpRequestArgs args)
    {
      if (Sitecore.Context.Site == null || Sitecore.Context.Language == null)
      {
        return;
      }

      if (!Sitecore.Context.PageMode.IsNormal)
      {
        return;
      }

      var enabledLanguages = Sitecore.Context.Site.GetEnabledLanguages();
      if (enabledLanguages.Length == 0)
      {
        return;
      }

      if (!enabledLanguages.Contains(Sitecore.Context.Language.Name))
      {
        //don’t process URL. could also directly force 404 here
        args.AbortPipeline();
      }
    }
  }
}