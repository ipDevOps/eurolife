using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Response
{
  public class Quotation
  {
    public BasicCover BasicCover { get; set; }
    public List<Cover> Covers { get; set; }
    public List<BundleCover> BundleCovers { get; set; }
    public Customer Insured { get; set; }
    public Customer Customer { get; set; }
    public bool? InsuredSameWithCustomer { get; set; }
    public bool? IsPremType { get; set; }
    public bool? IsEndingBsa { get; set; }
    public long? InsuranceDuration { get; set; }
    public long? RateUpdate { get; set; }
    public long? Guarantee { get; set; }
    public long? GuaranteedSyntaxiYears { get; set; }
    public long? AdditionalPensions { get; set; }
    public bool? Moa { get; set; }
    public bool? DeathMoa { get; set; }
    public List<Dependent> Dependents { get; set; }
    public long? TotalPremium { get; set; }
    public double? TotalLoadPremium { get; set; }
    public double? Prem01 { get; set; }
    public double? Prem02 { get; set; }
    public double? Prem04 { get; set; }
    public double? Prem12 { get; set; }
    public List<object> Exagores { get; set; }
    public List<object> DecreasedBsa { get; set; }
    public long? FinalAmount { get; set; }
    public bool? IsTeleUw { get; set; }
    public long? SendCard { get; set; }
    public long? SendPol { get; set; }
    public bool? CalcPrem { get; set; }
    public bool? HasUploadedid { get; set; }
    public bool? HasQa { get; set; }
    public string FlowId { get; set; }
    public long? Channel { get; set; }
    public bool? EnableElectronicSignature { get; set; }
    public List<object> Warnings { get; set; }
    public long? PaymentFrequency { get; set; }
    public long? AppPaymentType { get; set; }
  }
}