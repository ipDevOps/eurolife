using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Request
{
  public class Customer
  {
    public object Lastname { get; set; }
    public object FirstName { get; set; }
    public object FatherName { get; set; }
    public object Age { get; set; }
    public string BirthDate { get; set; }
    public long? Profession { get; set; }
    public long? ProfessionCategory { get; set; }
    public object ProfessionDescription { get; set; }
    public object MinBirthDate { get; set; }
    public object MaxBirthDate { get; set; }
    public long? Sex { get; set; }
    public object Email { get; set; }
    public object Relationship { get; set; }
    public object Addresses { get; set; }
    public object Afm { get; set; }
    public object Adt { get; set; }
    public object Doy { get; set; }
    public long? Id { get; set; }
    public object Amka { get; set; }
    public object Height { get; set; }
    public object Weight { get; set; }
    public object Mobile { get; set; }
    public object Nationality { get; set; }
    public object Adtcountry { get; set; }
    public object Brcountry { get; set; }
    public object ConsentSensitiveData { get; set; }
    public object ConsentsErb { get; set; }
    public object ConsentsThirdParty { get; set; }
    public object IsCustomer { get; set; }
    public object LegalPerson { get; set; }
    public object LegalType { get; set; }
    public object LegalRep { get; set; }
    public object DisplayedAge { get; set; }
    public object Trader { get; set; }
    public List<Cover> DependCovers { get; set; }
    public object MemberDescription { get; set; }
    public long? MemberRelationship { get; set; }
    public object MemberStudent { get; set; }
    public object HospitalCoverType { get; set; }
    public object OutHospitalCoverType { get; set; }
    public object SurgeryBenefit { get; set; }
    public object AgentNotes { get; set; }
    public object SendCard { get; set; }
    public object SendPol { get; set; }
    public object CalcPrem { get; set; }
  }
}