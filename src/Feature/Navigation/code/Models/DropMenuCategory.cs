using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.Navigation.Models
{
  public class DropMenuCategory
  {
    public Item Category { get; set; }
    public IList<Item> SubItems { get; set; }
  }
}