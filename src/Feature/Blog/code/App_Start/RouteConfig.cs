using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wedia.Feature.Blog
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute("loadmore-articles", "api/feature/blog/ajax-articles",
        new { controller = "Blog", action = "AjaxPagedList", id = UrlParameter.Optional });

      routes.MapRoute("latest-articles-feed", "api/feature/blog/latest-articles",
       new { controller = "Blog", action = "LatestArticlesFeed", numberOfArticles = UrlParameter.Optional });
    }
  }
}