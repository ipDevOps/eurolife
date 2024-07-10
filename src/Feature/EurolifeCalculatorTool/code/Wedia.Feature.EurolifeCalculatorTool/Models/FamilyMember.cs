using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class FamilyMember : BaseEntity
  {
    public bool IsPrimaryInsured { get; set; }
    public string BirthDate { get; set; }
    public string Image { get; set; }
  }
}