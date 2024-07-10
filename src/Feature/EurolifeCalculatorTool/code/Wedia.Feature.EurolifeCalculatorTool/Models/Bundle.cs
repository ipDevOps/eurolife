using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class Bundle : BaseEntity
  {
    public Price Price { get; set; }
    public string CoverCapital { get; set; }       
  }
}