using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class GroupOfBundle : BaseEntity
  {
    public Price Price { get; set; }
    public List<Bundle> Bundles { get; set; }
  }
}