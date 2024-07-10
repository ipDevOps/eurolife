using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wedia.Feature.Identity
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute("register-newsletter", "api/feature/identity/register-newsletter", new { controller = "Identity", action = "AjaxNewsletterRegister", id = UrlParameter.Optional });
    }
  }
}