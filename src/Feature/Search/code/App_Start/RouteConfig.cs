using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wedia.Feature.Search
{
  public static class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute("search-ajaxsearch", "api/feature/search/ajaxsearch", new { controller = "Search", action = "AjaxSearchResults", id = UrlParameter.Optional });
    }
  }
}