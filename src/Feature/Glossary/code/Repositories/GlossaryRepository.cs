using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Wedia.Feature.Glossary.Models;
using Wedia.Foundation.DependencyInjection;

namespace Wedia.Feature.Glossary.Repositories
{
  [Service(typeof(IGlossaryRepository))]
  public class GlossaryRepository : IGlossaryRepository
  {
    public IEnumerable<GlossaryGroup> GetGroups(Item contextItem)
    {
      return GetGlossaryGroups(contextItem, true);
    }

    private IEnumerable<GlossaryGroup> GetGlossaryGroups(Item contextItem, bool root = false)
    {
      return contextItem.GetChildren()
        .Where(i => i.DescendsFrom(Templates.GlossaryGroup.ID))
        .Select(i => new GlossaryGroup
        {
          Item = i,
          Title = i.Fields[Templates.HasGlossaryTitle.Fields.Title]?.Value,
          Items = !root ? GetGlossaryItems(i) : null,
          Groups = root ? GetGlossaryGroups(i) : null
        });
    }

    private IEnumerable<GlossaryItem> GetGlossaryItems(Item item)
    {
      return item.GetChildren()
        .Where(i => i.DescendsFrom(Templates.Glossary.ID))
        .Select(i => new GlossaryItem
        {
          Item = i,
          Title = i.Fields[Templates.HasGlossaryTitle.Fields.Title]?.Value,
          Gloss = i.Fields[Templates.Glossary.Fields.Gloss]?.Value
        })
        .OrderBy(i => i.Title);
    }
  }
}