using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedia.Feature.Navigation.Models;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Feature.Navigation.Repositories
{
  [Service(typeof(INavigationRepository), Lifetime = Lifetime.Transient)]
  public class NavigationRepository : INavigationRepository
  {
    public Item ContextItem => RenderingContext.Current?.ContextItem ?? Context.Item;

    public Item NavigationRoot { get; }

    public NavigationRepository()
    {
      NavigationRoot = GetNavigationRoot(ContextItem);

      if (NavigationRoot == null)
      {
        throw new InvalidOperationException($"Cannot determine navigation root from '{ContextItem.Paths.FullPath}'");
      }
    }

    public NavigationItems GetBreadcrumb()
    {
      var items = new NavigationItems
      {
        NavItems = GetNavigationHierarcy(true).Reverse().ToList()
      };

      for (var i = 0; i < items.NavItems.Count - 1; i++)
      {
        items.NavItems[i].Level = i;
        items.NavItems[i].IsActive = i == items.NavItems.Count - 1;
      }

      return items;
    }

    public List<NavigationItems> GetPrimaryMenu(Item menuRoot, bool descending = false, int limit = 20)
    {
      if (menuRoot == null)
      {
        throw new ArgumentNullException(nameof(menuRoot));
      }

      List<NavigationItems> primaryMenu = new List<NavigationItems>();

      foreach(var item in menuRoot.Children.Where(x=> x.TemplateID == Templates.LinkMenu.ID))
      {
        primaryMenu.Add(GetChildNavigationItems(item, 0, 2, descending, limit));
      }

      return primaryMenu; //GetChildNavigationItems(menuRoot, 0, 2, descending, limit);
    }

    public NavigationItems GetHeaderNavigationItems(Item menuRoot, bool descending = false, int limit = 20)
    {

      if (menuRoot == null)
      {
        throw new ArgumentNullException(nameof(menuRoot));
      }

      return GetChildNavigationItems(menuRoot, 0, 5, descending, limit);

    }

    public NavigationItems GetLinkMenuItems(Item menuRoot, bool descending = false, int limit = 20)
    {
      if (menuRoot == null)
      {
        throw new ArgumentNullException(nameof(menuRoot));
      }

      return GetChildNavigationItems(menuRoot, 0, 0, descending, limit);
    }

    public List<DropMenuCategory> GetDropMenuCategories(Item contextItem)
    {
      var list = new List<DropMenuCategory>();

      var categories = contextItem
                            .Children.Where(x => x.TemplateID == Templates.DropMenuCategory.ID);

      if(categories != null && categories.Any())
      {
        foreach (var category in categories)
        {
          var subItems = category.Children.Where(x => x.TemplateID == Templates.DropMenuItem.ID)?.ToList();

          list.Add(new DropMenuCategory 
          {
            Category = category,
            SubItems = subItems
          });
        }
      }

      return list;
    }

    private NavigationItems InfoMessage(InfoMessage infoMessage)
    {
      throw new NotImplementedException();
    }

    private Item GetNavigationRoot(Item contextItem)
    {
      return contextItem.GetAncestorOrSelfOfTemplate(Templates.NavigationRoot.ID) ?? Context.Site.GetContextItem(Templates.NavigationRoot.ID);
    }

    private IEnumerable<NavigationItem> GetNavigationHierarcy(bool forceShowInMenu = false)
    {
      var item = ContextItem;

      while (item != null)
      {
        if (IncludeInNavigation(item, forceShowInMenu))
        {
          yield return CreateNavigationItem(item, 0);
        }

        item = item.Parent;
      }
    }

    private bool IncludeInNavigation(Item item, bool forceShowInMenu = false)
    {
      return item.HasContextLanguage()
          && item.DescendsFrom(Templates.Navigable.ID)
          && (forceShowInMenu || MainUtil.GetBool(item[Templates.Navigable.Fields.ShowInNavigation], false));
    }

    private NavigationItem CreateNavigationItem(Item item, int level, int maxLevel = -1)
    {
      var targetItem = item.DescendsFrom(Templates.Link.ID) ? item.TargetItem(Templates.Link.Fields.Link) : item;

      return new NavigationItem
      {
        Item = item,
        Url = item.DescendsFrom(Templates.Link.ID) ? item.LinkFieldUrl(Templates.Link.Fields.Link) : item.Url(),
        Target = item.DescendsFrom(Templates.Link.ID) ? item.LinkFieldTarget(Templates.Link.Fields.Link) : "",
        IsActive = IsItemActive(targetItem ?? item),
        Children = GetChildNavigationItems(item, level + 1, maxLevel),
        ShowChildren = !item.DescendsFrom(Templates.Navigable.ID) || item.Fields[Templates.Navigable.Fields.ShowChildren].IsChecked()
      };
    }

    private bool IsItemActive(Item item)
    {
      return ContextItem.ID == item.ID || ContextItem.Axes.GetAncestors().Any(a => a.ID == item.ID);
    }

    private NavigationItems GetChildNavigationItems(Item parentItem, int level, int maxLevel, bool descending = false, int limit = 20)
    {
      if (level > maxLevel || !parentItem.HasChildren)
      {
        return null;
      }

      var childItems = parentItem
          .Children
          .Where(item => IncludeInNavigation(item));
          

      if (descending)
        childItems = childItems.OrderByDescending(item => item[FieldIDs.Sortorder]);
          

      var navItems = new NavigationItems {
        NavItems = childItems.Select(i => CreateNavigationItem(i, level, maxLevel)).ToList()
      };

      if (parentItem.DescendsFrom(Templates.NavigationRoot.ID))
      {
        navItems.Title = parentItem.Fields[Templates.NavigationRoot.Fields.Title]?.Value;
      }

      return navItems;

    }

  
  }
}