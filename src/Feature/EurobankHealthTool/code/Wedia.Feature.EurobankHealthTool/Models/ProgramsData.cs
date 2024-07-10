using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurobankHealthTool.Models
{
  public class ProgramsData
  {
    public int Age { get; set; }
    public List<Program> Programs { get; set; }
  }

  public class Program
  {
    public string PremiumCode { get; set; }
    public double PremiumPrice { get; set; }
    public double? PremiumPerMille { get; set; }
    public double PremiumFinalPrice { get; set; }
  }
}