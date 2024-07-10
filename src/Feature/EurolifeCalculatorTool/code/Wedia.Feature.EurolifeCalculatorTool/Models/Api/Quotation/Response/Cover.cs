using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Response
{
  public class Cover
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
    public bool? IsSelected { get; set; }
    public bool? IsDepend { get; set; }
    public string CoverResult { get; set; }
    public bool? IsFixedBsa { get; set; }
    public long? CovType { get; set; }
    public string Header { get; set; }
    public string SubHeader { get; set; }
    public long? ProductCode { get; set; }
    public string ProductDescr { get; set; }
    public long? DeductibleAmount { get; set; }
    public string RoomType { get; set; }
    public bool? NotInsurable { get; set; }
    public bool? SpecialTerm { get; set; }
    public long? LoadPerCentOnPremium { get; set; }
    public long? LoadPerThousandOnSumInsured { get; set; }
    public long? CategoryCode { get; set; }
    public string ShortDescr { get; set; }
    public bool? IsDiscount { get; set; }
    public long? EndInsuranceAge { get; set; }
    public long? InsuranceDuration { get; set; }
    public long? PaymentDuration { get; set; }
    public long? RiskBsa { get; set; }
    public string CovDepend { get; set; }
  }
}