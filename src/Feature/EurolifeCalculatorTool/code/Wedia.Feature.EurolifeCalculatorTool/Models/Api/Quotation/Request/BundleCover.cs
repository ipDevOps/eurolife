using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Request
{
  public class BundleCover
  {
    public long Code { get; set; }
    public string Descr { get; set; }
    public bool IsSelected { get; set; }
    public List<Cover> Covers { get; set; }
  }
}