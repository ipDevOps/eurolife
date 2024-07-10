using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Wedia.Foundation.Dictionary.Models
{
  public class Dictionary
  {
    public Item Root { get; set; }
    public bool AutoCreate { get; set; }
    public SiteContext Site { get; set; }
  }
}