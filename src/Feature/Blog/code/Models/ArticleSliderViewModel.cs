using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog.Models
{
  public class ArticleSliderViewModel
  {   
    public Sitecore.Data.Items.Item RenderingItem { get; set; }
    public List<LifeStage> LifeStages { get; set; }
    public IList<BlogPostItem> Articles { get; set; }
  }
}