using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.PageContent.Models.ViewModels
{
  public class CardViewModel
  {
    public Item Card { get; set; }
    public IList<Item> PieCharts { get; set; }
    public IList<Item> BarCharts { get; set; }
  }
}