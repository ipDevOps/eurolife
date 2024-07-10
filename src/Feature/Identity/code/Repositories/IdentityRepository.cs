using Sitecore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Wedia.Foundation.Dictionary.Repositories;

namespace Wedia.Feature.Identity.Repositories
{
  public class IdentityRepository
  {
    public static Item Get([NotNull] Item contextItem)
    {
      if (contextItem == null)
        throw new ArgumentNullException(nameof(contextItem));

      return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID)
        ?? Context.Site.GetContextItem(Templates.Identity.ID);
    }
  }
}