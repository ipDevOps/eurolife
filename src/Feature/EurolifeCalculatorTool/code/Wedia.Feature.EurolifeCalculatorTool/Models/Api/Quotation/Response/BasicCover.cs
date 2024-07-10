using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Response
{
  public class BasicCover
  {
    public string CoverDescription { get; set; }
    public long? CovCode { get; set; }
    public long? CoverCapital { get; set; }
    public double? CoverPremium { get; set; }
    public double? CoverPremium2 { get; set; }
    public double? CoverPremium4 { get; set; }
    public double? CoverPremium12 { get; set; }
    public long? LoadAmount01 { get; set; }
    public long? LoadAmount02 { get; set; }
    public long? LoadAmount04 { get; set; }
    public long? LoadAmount12 { get; set; }
    public bool? NotInsurable { get; set; }
    public bool? SpecialTerm { get; set; }
    public long? LoadPerCentOnPremium { get; set; }
    public long? LoadPerThousandOnSumInsured { get; set; }
    public string CategoryDescription { get; set; }
    public long? ProductCode { get; set; }
    public bool? IsDiscount { get; set; }
    public long? RiskBsa { get; set; }
  }
}