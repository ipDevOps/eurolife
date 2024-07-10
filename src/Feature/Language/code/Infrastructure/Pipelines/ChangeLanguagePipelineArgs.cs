using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Pipelines;

namespace Wedia.Feature.Language.Infrastructure.Pipelines
{
  public class ChangeLanguagePipelineArgs : PipelineArgs
  {
    public ChangeLanguagePipelineArgs(string currentLanguage, string newLanguage)
    {
      this.CurrentLanguage = currentLanguage;
      this.NewLanguage = newLanguage;
    }

    public string CurrentLanguage
    {
      get
      {
        return this.CustomData["CurrentLanguage"]?.ToString();
      }
      set
      {
        this.CustomData["CurrentLanguage"] = value;
      }
    }

    public string NewLanguage
    {
      get
      {
        return this.CustomData["NewLanguage"]?.ToString();
      }
      set
      {
        this.CustomData["NewLanguage"] = value;
      }
    }
  }
}