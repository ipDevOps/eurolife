using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Wedia.Feature.Panels.Models;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.SitecoreExtensions.Extensions;

namespace Wedia.Feature.Panels.Repositories
{
  [Service(typeof(IPanelsRepository))]
  public class PanelsRepository : IPanelsRepository
  {
    public IEnumerable<PanelItem> GetItems(Item panel)
    {
      return GetMultiListValueItems(panel, Templates.Panel.Fields.Items, Templates.PanelItem.ID)
          .Select(i => new PanelItem
          {
            ID = i.ID,
            Title = i[Templates.PanelItem.Fields.Title],
            Rows = GetItemRowsFromMultilist(i)
          });
    }

    public IEnumerable<PanelCategory> GetCategories(Item panel)
    {
      return GetMultiListValueItems(panel, Templates.Panel.Fields.Categories, Templates.PanelCateogory.ID)
          .Select(i => new PanelCategory
          {
            ID = i.ID,
            Title = i.Fields[Templates.PanelCateogory.Fields.Title].Value,
            IsMain = MainUtil.GetBool(i[Templates.PanelCateogory.Fields.IsMain], false),
            Rows = GetCategoryRows(i)
          });
    }

    public IEnumerable<PanelRow> GetFilters(Item panel)
    {
      return GetMultiListValueItems(panel, Templates.Panel.Fields.Filters, Templates.PanelRow.ID)
          .Select(i => PanelRowFactory(i));
    }

    public IEnumerable<Item> GetMultiListValueItems(Item item, ID field, ID template)
    {
      return item.GetMultiListValueItems(field).Where(i => i.DescendsFrom(template));
    }

    private IEnumerable<PanelRowItem> GetItemRowsFromMultilist(Item item)
    {
      return GetMultiListValueItems(item, Templates.PanelItem.Fields.Value, Templates.PanelRowItemValue.ID)
          .Select(i => PanelRowItemFactory(i));
    }

    private IEnumerable<PanelRow> GetCategoryRows(Item item)
    {
      return GetMultiListValueItems(item, Templates.PanelCateogory.Fields.Rows, Templates.PanelRow.ID)
          .Select(i => PanelRowFactory(i));
    }

    private PanelRowItem PanelRowItemFactory(Item item)
    {
      return new PanelRowItem
      {
        ID = item.ID,
        ParentID = item.ParentID,
        Value = item.Fields[Templates.PanelRowItemValue.Fields.Value]?.Value,
        IsChecked = item.Fields[Templates.PanelRowItemValue.Fields.Check].IsChecked(),
        Tooltip = item.Fields[Templates.PanelRowItemValue.Fields.Tooltip]?.Value
      };
    }

    private PanelRow PanelRowFactory(Item item)
    {
      return new PanelRow
      {
        ID = item.ID,
        Title = item[Templates.PanelRow.Fields.Title],
        IsCheckbox = item[Templates.PanelRow.Fields.IsCheckbox],
        PanelRowTooltip = item[Templates.PanelRow.Fields.PanelRowTooltip],
        Props = GetItemRowsFromChildren(item)
      };
    }

    private IEnumerable<PanelRowItem> GetItemRowsFromChildren(Item item)
    {
      return item.Children.Where(i => i.DescendsFrom(Templates.PanelRowItemValue.ID))
          .Select(i => PanelRowItemFactory(i));
    }
  }
}