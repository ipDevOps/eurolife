using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class Product : BaseEntity
  {
    public string Amount { get; set; }
    public string Hospitalization { get; set; }
    public Price Price { get; set; }
    public HtmlString RTE { get; set; }
    public string DependentMembersProductKey { get; set; }
    public string AdditonalProductKey { get; set; }
    public IEnumerable<InsuredPerson> InsuredPeople { get; set; }
  }

  public class InsuredPerson
  {
    public string Title { get; set; }
    public string Image { get; set; }
  } 
}