using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog.Models
{
  public class BlogPostItem
  {
    public string Image { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string URL { get; set; }

    public List<Tag> Tags { get; set; }  
  }

  public class Tag
  {
    public string Title { get; set; }
    public string URL { get; set; }
    public string Color { get; set; }
  }

  public class LifeStage
  {
    public string Title { get; set; }
    public string Hashtag { get; set; }
    public string URL { get; set; }
  }
}