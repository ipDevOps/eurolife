using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.EurolifeCalculatorTool.Models
{
  public class OfferViewModel
  {
    public Item RenderingItem { get; set; }
    public Product Product { get; set; }
    public IEnumerable<GroupOfBundle> GroupOfBundles { get; set; }
    public UserSelection UserSelection { get; set; }
    public IEnumerable<InfoTab> InfoTabs { get; set; }
  }
}