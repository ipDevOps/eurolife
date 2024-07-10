using System;
using System.Collections.Generic;
using System.Linq;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Repositories;
using Sitecore.Data.Items;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Wedia.Feature.Person.Models;
using Sitecore.Data;

namespace Wedia.Feature.Person.Repositories
{
  [Service(typeof(IPersonRepository))]
  public class PersonRepository : IPersonRepository
  {
    public ISearchServiceRepository _searchServiceRepository;

    public PersonRepository(ISearchServiceRepository searchServiceRepository)
    {
      _searchServiceRepository = searchServiceRepository;
    }

    public IEnumerable<Item> GetEmployees(Item contextItem)
    {
      return Get(contextItem, Templates.Person.ID);
    }

    public IEnumerable<Item> GetEmployeesOrdered(Item contextItem)
    {
      return contextItem.GetChildren().Where(x => x.TemplateID == Templates.Employee.ID);
    }

    public IEnumerable<Item> GetCarousel(Item context, Item pageItem)
    {
      return context.GetMultiListValueItems(Templates.PersonGroup.Fields.Persons)
        .Where(i => i.DescendsFrom(Templates.Person.ID) && i.ID != pageItem.ID);
    }

    public IEnumerable<ConsultantsGroup> GetConsultantsGroups(Item contextItem)
    {
      return Get(contextItem, Templates.HasPersonGroupName.ID, Templates.HasPersonGroupName.Fields.PersonGroupName_FieldName)
        .Select(d => new ConsultantsGroup
        {
          Item = d,
          Consultants = GetConsultants(d)
        })
        .Where(i => i != null);
    }

    private IEnumerable<Consultant> GetConsultants(Item contextItem)
    {
      var data =  Get(contextItem, Templates.Person.ID, Templates.Person.Fields.Name_FieldName)
        .Select(d => new Consultant
        {
          Item = d ,
          SortName = d.Fields[Templates.Person.Fields.Name_FieldName].ToString()
        });

      data = data.OrderBy(x => x.SortName);
      return data;
    }

    private IEnumerable<Item> Get(Item contextItem, ID TemplateID, string orderby = "sortorder")
    {
      if (contextItem == null)
      {
        throw new ArgumentNullException(nameof(contextItem));
      }

      var searchService = _searchServiceRepository
        .Get(new SearchSettingsBase { Templates = new[] { TemplateID } });

      searchService.Settings.Root = contextItem;

      var results = searchService.FindAll(0, 0, orderby);   

      return results.Results.Select(d => d.Item).Where(i => i != null); 

    }
  }
}