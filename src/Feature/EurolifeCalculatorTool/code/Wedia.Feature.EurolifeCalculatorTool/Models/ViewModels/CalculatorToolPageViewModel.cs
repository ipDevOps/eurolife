using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class CalculatorToolPageViewModel
  {
    public Item RenderingItem { get; set; }
    public IEnumerable<TargetGroup> AvailableTargetGroups { get; set; }
    public IEnumerable<FamilyMember> AvailableFamilyMembers { get; set; }
    public IEnumerable<Amount> AvailableAmounts { get; set; }
    public IEnumerable<Hospitalization> AvailableHospitalizations { get; set; }
    public UserSelection UserSelection { get; set; }
  }
}