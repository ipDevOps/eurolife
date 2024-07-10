using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.Glossary.Models
{
  public class GlossaryGroup
  {
    public Item Item { get; set; }
    public string Title { get; set; }
    public IEnumerable<GlossaryItem> Items { get; set; }
    public IEnumerable<GlossaryGroup> Groups { get; set; }
  }
}