using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Common
{
  public class Header
  {
    public string ServicesVersion { get; set; }
    public string CultureName { get; set; }
    public object TimeDiff { get; set; }
  }
}