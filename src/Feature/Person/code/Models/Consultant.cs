using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.Person.Models
{
  public class Consultant
  {
    public Item Item { get; set; }
    public string SortName { get; set; }
  }
}