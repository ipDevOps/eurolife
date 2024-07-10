using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Response
{
  public class BundleCover
  {
    public long Code { get; set; }
    public string Descr { get; set; }
    public string ShortDescr { get; set; }
    public bool IsSelected { get; set; }
    public List<Cover> Covers { get; set; }
    public long CategoryCode { get; set; }
    public double CoverPremium { get; set; }
    public double CoverPremium2 { get; set; }
    public double CoverPremium4 { get; set; }
    public double CoverPremium12 { get; set; }
    public long CoverPremiumPlus30312 { get; set; }
  }
}