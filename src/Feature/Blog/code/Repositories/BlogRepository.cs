using System;
using System.Collections.Generic;
using System.Linq;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Indexing.Repositories;
using Sitecore.Data.Items;
using Wedia.Foundation.Indexing.Models;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data;
using Wedia.Foundation.SitecoreExtensions.Utilities;
using Wedia.Foundation.Theming.Extensions;

namespace Wedia.Feature.Blog.Repositories
{
  [Service(typeof(IBlogRepository))]
  public class BlogRepository : IBlogRepository
  {
    private readonly SearchSettingsBase _searchBaseSettings;

    public ISearchServiceRepository _searchServiceRepository;

    public BlogRepository(ISearchServiceRepository searchServiceRepository)
    {
      _searchServiceRepository = searchServiceRepository;
      _searchBaseSettings = new SearchSettingsBase { Templates = new[] { Templates.BlogPost.ID } };
    }

    public Models.ArticleSliderViewModel GetSliderData(Item contextItem)
    {     
      var vm = new Models.ArticleSliderViewModel 
      {        
        RenderingItem = contextItem,
        LifeStages = GetProductLifeStages(contextItem),
        Articles = GetSelectedArticles(contextItem)
      };

      return vm;
    } 

    /// <summary>
    /// this is used for migration
    /// </summary>
    /// <param name="contextItem"></param>
    /// <param name="year"></param>
    /// <returns></returns>

    public IEnumerable<Item> GetArticlesForSpecificYear(Item contextItem, string year)
    {
        var data = Get(contextItem, Templates.BlogPost.ID, "sortorder", year);

        return data.Where(x => x.Fields[Templates.HasBlogContent.Fields.Publicationdate].ToString().Contains(year));
    }  

    public IEnumerable<Models.BlogPostItem> GetLatest(Item contextItem, int count, bool showTags = true,  bool includeHostName = false)
    {
      var items = Get(contextItem).OrderByDescending(i => i[Templates.HasBlogContent.Fields.Publicationdate]).Take(count);

      List<Models.BlogPostItem> data = new List<Models.BlogPostItem>();

      if(items != null && items.Any())
      {
        foreach(var item in items)
        {
          data.Add(MappingBlogPostItem(item, showTags, includeHostName));
        }
      }                                       

      return data;
    }

    public Models.ArticlesList GetPagedList(Item contextItem, Models.PagingSettings pagingSettings)
    {
      return Get(contextItem, pagingSettings);
    }


    public Models.PromoSectionViewModel GetPromoSectionViewModel(Item contextItem)
    {
      var vm = new Models.PromoSectionViewModel
      {
        RenderingItem = contextItem,
        PromoColor = GetPromoColor(contextItem)
      };

      return vm;
    }

    /// <summary>
    /// view model for article page
    /// </summary>
    /// <param name="contextItem"></param>
    /// <returns></returns>
    public Models.ArticleViewModel GetArticleViewModel(Item contextItem)
    {
      var vm = new Models.ArticleViewModel
      {
        RenderingItem = contextItem,
        Tags = GetProductTags(contextItem),
        LifeStages = GetProductLifeStages(contextItem)
      };

      return vm;
    }

    private Models.BlogPostItem MappingBlogPostItem(Item item, bool showTags = false, bool includeHostName = false)
    {
      Models.BlogPostItem blogPostItem = new Models.BlogPostItem();

      if (!item.DescendsFrom(Templates.BlogPost.ID))
        return blogPostItem;

      var mediaUrlOptions = new Sitecore.Resources.Media.MediaUrlOptions
      {
        Width = 600,
        Height = 0    ,
        AlwaysIncludeServerUrl = includeHostName
      };

      if (item != null)
      {
        blogPostItem.Title = item.Fields[Templates.HasBlogContent.Fields.Title].ToString();
        blogPostItem.URL = item.Url(new Sitecore.Links.UrlOptions { AlwaysIncludeServerUrl = includeHostName});
        blogPostItem.Summary = Utilities.StripHTML(item.Fields[Templates.HasBlogContent.Fields.Teaser].ToString());
        blogPostItem.Image = item.FieldHasValue(Templates.HasBlogContent.Fields.Image) 
          ? item.ImageUrl(Templates.HasBlogContent.Fields.Image, mediaUrlOptions) 
          : string.Empty;

        if (showTags)
        {
          blogPostItem.Tags = GetProductTags(item, includeHostName);
        } 
      }

      return blogPostItem;
    }

    private List<Models.BlogPostItem> GetSelectedArticles(Item item)
    {
      var list = new List<Models.BlogPostItem>();

      if (item.FieldHasValue(Templates.HasArticles.Fields.Articles))
      {
        var selectedArticles = item.GetMultiListValueItems(Templates.HasArticles.Fields.Articles);

        if (selectedArticles != null && selectedArticles.Any())
        {
          foreach (var article in selectedArticles)
          {
            list.Add(MappingBlogPostItem(article, true));
          }
        }
      }
      
      return list;
    }

    private List<Models.LifeStage> GetProductLifeStages(Item item)
    {
      var lifeStages = new List<Models.LifeStage>();

      if (item.FieldHasValue(Templates.HasLifeStages.Fields.SelectedLifeStages))
      {
        var selectedLifeStages = item.GetMultiListValueItems(Templates.HasLifeStages.Fields.SelectedLifeStages);
        if (selectedLifeStages != null && selectedLifeStages.Any())
        {
          foreach (var lifeStage in selectedLifeStages)
          {
            lifeStages.Add(new Models.LifeStage
            {
              Title = lifeStage.Fields[Templates.HasPageContent.Fields.Title]?.ToString(),
              Hashtag = lifeStage.Fields[Templates.HasTag.Fields.Title]?.ToString(),
              URL = lifeStage.Url()
            });
          }
        }
      }

      return lifeStages;
    }

    private List<Models.Tag> GetProductTags(Item item, bool includeHostName = false)
    {
      var tags = new List<Models.Tag>();

      if (item.FieldHasValue(Templates.HasProducts.Fields.SelectedProducts))
      {
        var selectedProducts = item.GetMultiListValueItems(Templates.HasProducts.Fields.SelectedProducts);
        if (selectedProducts != null && selectedProducts.Any())
        {
          foreach (var product in selectedProducts)
          {
            var color = string.Empty;
            if (product.FieldHasValue(Templates.HasColor.Fields.SelectedColor))
            {
              var colorField = product.Fields[Templates.HasColor.Fields.SelectedColor];
              var data = Sitecore.Context.Database.GetItem(colorField.Value);
              color = data.Fields[Templates.Style.Fields.Style].ToString();
            }

            tags.Add(new Models.Tag
            {
              Title = product.Fields[Templates.HasPageContent.Fields.Title]?.ToString(),
              Color = color,
              URL = product.Url(new Sitecore.Links.UrlOptions { AlwaysIncludeServerUrl = includeHostName})
            });
          }
        }
      }

      return tags;
    }


    private string GetPromoColor(Item item)
    {
      var color = string.Empty;
      if (item.FieldHasValue(Templates.HasPromo.Fields.Color))
      {
        var colorField = item.Fields[Templates.HasPromo.Fields.Color];
        var data = Sitecore.Context.Database.GetItem(colorField.Value);
        color = data.Fields[Templates.Style.Fields.Style].ToString();
      }

      return color;
    }



    private IEnumerable<Item> Get(Item contextItem)
    {
      var searchService = _searchServiceRepository
        .Get(_searchBaseSettings);

      searchService.Settings.Root = contextItem;

      var results = searchService.FindAll();

      return results.Results.Select(x => x.Item).Where(x => x != null);
    }


    private IEnumerable<Item> Get(Item contextItem, ID TemplateID, string orderby = "sortorder", string year = "")
    {
      if (contextItem == null)
      {
        throw new ArgumentNullException(nameof(contextItem));
      }

      var searchService = _searchServiceRepository
        .Get(new SearchSettingsBase { Templates = new[] { TemplateID } });

      searchService.Settings.Root = contextItem;

      var results = searchService.FindAll(0, 0, orderby);

      //if(!string.IsNullOrEmpty(year))
      //{
      //  return results.Results.Select(d => d.Item).Where(i => i != null
      //  && i.Field(Templates.HasBlogContent.Fields.Publicationdate).ToString().Contains(year)); // == int.Parse(year));
      //}

      return results.Results.Select(d => d.Item).Where(i => i != null);    
    }

    /// <summary>
    /// Get Paginated items for listing, filter by specific field
    /// </summary>
    /// <param name="contextItem"></param>
    /// <param name="pagingSettings"></param>
    /// <returns></returns>
    private Models.ArticlesList Get(Item contextItem, Models.PagingSettings pagingSettings)
    {
      var searchService = _searchServiceRepository.Get(new SearchSettingsBase { Templates = new[] { Templates.BlogPost.ID } });
      searchService.Settings.Root = contextItem
                                    .GetAncestorOrSelfOfTemplate(Templates.Blog.ID)
                                    .Children.Where(x=> x.TemplateID == Templates.BlogList.ID)
                                    .FirstOrDefault()?? throw new ArgumentNullException(nameof(contextItem));                  

      var results = searchService.FindAll(pagingSettings.CurrentPage * pagingSettings.ResultsOnPage,
        pagingSettings.ResultsOnPage,
        pagingSettings.OrderBy,
        true, pagingSettings.IncludedFields, pagingSettings.ExcludedFields);

      var items = results.Results.Select(d => d.Item).Where(i => i != null);
      List<Models.BlogPostItem> data = new List<Models.BlogPostItem>();

      if (items != null && items.Any())
      {
        foreach (var item in items)
        {
          data.Add(MappingBlogPostItem(item, pagingSettings.ShowTags));
        }
      }

      Models.ArticlesList articlesList = new Models.ArticlesList
      {
        ResultsOnPage = pagingSettings.ResultsOnPage,
        TotalResults = results.TotalNumberOfResults,
        Page = pagingSettings.CurrentPage,
        Articles = data,
        ShowLoadMore = ((pagingSettings.CurrentPage + 1) * pagingSettings.ResultsOnPage < results.TotalNumberOfResults ? true : false)
      };
                          
      return articlesList; 
    }



  }
}