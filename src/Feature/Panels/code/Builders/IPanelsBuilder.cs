using Wedia.Feature.Panels.Models;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace Wedia.Feature.Panels.Builders
{
  public interface IPanelsBuilder
  {
    Panel Build(Item panel);
    PanelsGroup BuildGroup(Item item);
  }
}
