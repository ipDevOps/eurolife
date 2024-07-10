using Sitecore;
using Sitecore.Pipelines;
using System.Web.Routing;
using Wedia.Foundation.DependencyInjection;

namespace Wedia.Feature.Media.Infrastructure.Pipelines
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