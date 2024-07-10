using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Response
{
  public class Customer
  {
    public long? Age { get; set; }
    public string BirthDate { get; set; }
    public long? Profession { get; set; }
    public long? ProfessionCategory { get; set; }
    public bool? LegalPerson { get; set; }
    public long? Doy { get; set; }
    public long? Sex { get; set; }
    public long? LegalType { get; set; }
    public bool? ConsentPersonalData { get; set; }
    public long? ConsentsErb { get; set; }
    public long? ConsentsThirdParty { get; set; }
    public long? CustomerRelationship { get; set; }
    public bool? PublicService { get; set; }
  }
}