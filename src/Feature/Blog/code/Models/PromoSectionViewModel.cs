using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog.Models
{
  public class PromoSectionViewModel
  {
    public Sitecore.Data.Items.Item RenderingItem { get; set; }
    public string PromoColor { get; set; }
  }
}