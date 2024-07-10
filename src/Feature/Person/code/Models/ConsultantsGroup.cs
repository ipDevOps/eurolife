using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.Person.Models
{
  public class ConsultantsGroup
  {
    public Item Item { get; set; }
    public IEnumerable<Consultant> Consultants { get; set; }
  }
}