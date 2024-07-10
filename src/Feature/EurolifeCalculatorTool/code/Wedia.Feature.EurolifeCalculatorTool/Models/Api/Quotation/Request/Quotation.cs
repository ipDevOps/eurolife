using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Request
{
  public class Quotation
  {
    public BasicCover BasicCover { get; set; }
    public object DependentCovCode { get; set; }
    public List<Cover> Covers { get; set; }
    public object ContractedCovers { get; set; }
    public List<BundleCover> BundleCovers { get; set; }
    public Customer Insured { get; set; }
    public Customer Customer { get; set; }
    public bool? InsuredSameWithCustomer { get; set; }
    public object Moa { get; set; }
    public object DeathMoa { get; set; }
    public List<Customer> Dependents { get; set; }
    public object MailInfo { get; set; }
    public object TotalPremium { get; set; }
    public object TotalLoadPremium { get; set; }
    public object Prem01 { get; set; }
    public object Prem02 { get; set; }
    public object Prem04 { get; set; }
    public object Prem12 { get; set; }
    public object Beneficiaries { get; set; }
    public object AgentNotes { get; set; }
    public object LegalRep { get; set; }
    public object SendCard { get; set; }
    public object SendPol { get; set; }
    public object CalcPrem { get; set; }
    public object InsRep1 { get; set; }
    public object InsRep2 { get; set; }
    public object PaymentFrequency { get; set; }
    public object HasUploadedid { get; set; }
    public object HasQa { get; set; }
    public string FlowId { get; set; }
    public object EnableElectronicSignature { get; set; }
    public long? Channel { get; set; }
    public object SignatureData { get; set; }
    public long? ProductCode { get; set; }
    public object ContextChanged { get; set; }
    public object PortalExtraDataInsRepCustomer { get; set; }
  }
}