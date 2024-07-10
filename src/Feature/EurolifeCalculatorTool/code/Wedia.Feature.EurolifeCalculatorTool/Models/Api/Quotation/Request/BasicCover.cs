using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Request
{
  public class BasicCover
  {
    public string CovCode { get; set; }
    public string CoverCapital { get; set; }
    public object CoverPremium { get; set; }
    public object CoverPremium2 { get; set; }
    public object CoverPremium4 { get; set; }
    public object CoverPremium12 { get; set; }
    public object LoadAmount01 { get; set; }
    public object LoadAmount02 { get; set; }
    public object LoadAmount04 { get; set; }
    public object LoadAmount12 { get; set; }
    public object NotInsurable { get; set; }
    public object SpecialTerm { get; set; }
    public object MinBsa { get; set; }
    public object MaxBsa { get; set; }
    public object LoadPerCentOnPremium { get; set; }
    public object LoadPerThousandOnSumInsured { get; set; }
  }
}