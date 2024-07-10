using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.Glossary.Models
{
  public class GlossaryItem
  {
    public Item Item { get; set; }
    public string Title { get; set; }
    public string Gloss { get; set; }
  }
}