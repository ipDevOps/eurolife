using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Navigation.Models
{
  public class NavigationItems
  {
    public string Title { get; set; }
    public IList<NavigationItem> NavItems { get; set; }
  }
}