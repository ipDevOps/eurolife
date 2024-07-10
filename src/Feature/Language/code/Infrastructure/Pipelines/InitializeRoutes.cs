using System.Web.Routing;
using Sitecore;
using Sitecore.Pipelines;

namespace Wedia.Feature.Language.Infrastructure.Pipelines
{
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