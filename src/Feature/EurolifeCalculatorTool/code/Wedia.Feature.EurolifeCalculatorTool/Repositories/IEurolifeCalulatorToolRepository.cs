using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Wedia.Feature.EurolifeCalculatorTool.Models;

namespace Wedia.Feature.EurolifeCalculatorTool.Repositories
{
  public interface IEurolifeCalulatorToolRepository
  {
    IEnumerable<TargetGroup> GetAvailableTargetGroups(Item contextItem);
    IEnumerable<FamilyMember> GetAvailableFamilyMembers(Item contextItem, string targetGroupKey);
    IEnumerable<Amount> GetAvailableAmounts(Item contextItem);
    IEnumerable<Hospitalization> GetAvailableHospitalizations(Item contextItem);
    Task<OfferViewModel> GetProductAndBundles(Item contextItem, UserSelection userSelection);
  }
}
