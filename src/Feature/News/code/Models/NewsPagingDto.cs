using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.News.Models
{
  public class NewsPagingDto : PagingSettings
  {
    public string CurrentItemID { get; set; }
  }
}