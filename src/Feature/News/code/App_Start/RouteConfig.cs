using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wedia.Feature.News
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute("loadmore-news", "api/feature/news/ajax-news", new { controller = "News", action = "AjaxPagedList", id = UrlParameter.Optional });
    }
  }
}