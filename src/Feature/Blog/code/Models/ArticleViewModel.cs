using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog.Models
{
  public class ArticleViewModel
  {
    public Sitecore.Data.Items.Item RenderingItem { get; set; }
    public List<Tag> Tags { get; set; }
    public List<LifeStage> LifeStages { get; set; }
  }
}