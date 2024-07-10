using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class UserSelection
  {
    public string ItemId { get; set; }
    public string Step { get; set; }
    public TargetGroup TargetGroup { get; set; }
    public IEnumerable<FamilyMember> FamilyMembers { get; set; }
    public Amount Amount { get; set; }
    public Hospitalization Hospitalization { get; set; }   
  }   
}