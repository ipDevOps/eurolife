using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedia.Feature.Navigation.Models;
using Sitecore.Data.Items;

namespace Wedia.Feature.Navigation.Repositories
{
    public interface INavigationRepository
    {
        NavigationItems GetBreadcrumb();
        List<NavigationItems> GetPrimaryMenu(Item menuItem, bool descending = false, int limit = 20);
        NavigationItems GetLinkMenuItems(Item menuItem, bool descending = false, int limit = 20);        
        NavigationItems GetHeaderNavigationItems(Item menuItem, bool descending = false, int limit = 20);
        List<DropMenuCategory> GetDropMenuCategories(Item contextItem);
  }
}
