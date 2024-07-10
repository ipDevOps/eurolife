using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using Wedia.Feature.Panels.Models;
using Wedia.Feature.Panels.Repositories;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Dictionary.Repositories;

namespace Wedia.Feature.Panels.Builders
{
  [Service(typeof(IPanelsBuilder))]
  public class PanelsBuilder : IPanelsBuilder
  {
    private readonly IPanelsRepository _repository;

    public PanelsBuilder(IPanelsRepository panelsRepository)
    {
      _repository = panelsRepository;
    }

    public Panel Build(Item panel)
    {
      var filters = new Filters
      {
        Title = DictionaryPhraseRepository.Current.Get("/Panel/Product Panel/Filters Title", "FILTER RESULTS"),
        ApplyButton = DictionaryPhraseRepository.Current.Get("/Panel/Product Panel/Apply Button", "Apply"),
        ClearButton = DictionaryPhraseRepository.Current.Get("/Panel/Product Panel/Clear Button", "Clear"),
        CancelButton = DictionaryPhraseRepository.Current.Get("/Panel/Product Panel/Cancel Button", "Cancel"),
        Items = _repository.GetFilters(panel)
      };

      return new Panel
      {
        ID = panel.ID,
        Title = panel.Fields[Templates.Panel.Fields.Title].Value,
        Summary = panel.Fields[Templates.Panel.Fields.Summary].Value,
        Items = _repository.GetItems(panel),
        Categories = _repository.GetCategories(panel),
        Filters = filters
      };
    }

    public PanelsGroup BuildGroup(Item item)
    {
      var panelItems = _repository.GetMultiListValueItems(item, Templates.PanelGroup.Fields.Panels, Templates.Panel.ID);

      if (panelItems == null || !panelItems.Any())
        throw new NullReferenceException("No panel items found");

      var panels = new List<Panel>();

      foreach (var panel in panelItems)
      {
        panels.Add(Build(panel));
      }

      return new PanelsGroup
      {
        ID = item.ID,
        Title = item.Fields[Templates.PanelGroup.Fields.Title].Value,
        Summary = item.Fields[Templates.PanelGroup.Fields.Summary].Value,
        Panels = panels
      };
    }
  }
}