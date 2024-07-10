using System.Web.Routing;
using Wedia.Foundation.DependencyInjection;
using Sitecore.Pipelines;
using Sitecore;

namespace Wedia.Feature.Search.Infrastructure.Pipelines
{
  [Service]
  public class InitializeRoutes
  {
    public void Process(PipelineArgs args)
    {
      if (!Context.IsUnitTesting)
      {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
      }
    }
  }
}