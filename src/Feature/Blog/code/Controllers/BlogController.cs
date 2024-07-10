using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedia.Feature.Blog.Repositories;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Wedia.Feature.Blog.Models;
using Sitecore;
using Sitecore.Data;
using Wedia.Foundation.SitecoreExtensions.Utilities;
using Sitecore.Diagnostics;
using Wedia.Foundation.Alerts.Extensions;
using Wedia.Foundation.Alerts.Models;
using Wedia.Foundation.Alerts;

namespace Wedia.Feature.Blog.Controllers
{
  public class BlogController : Controller
  {
    private readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
      this._blogRepository = blogRepository;
    }

    /// <summary>
    /// Articles Slider   
    /// Insert Title
    /// Insert Subtitle
    /// Select desired life stages
    /// Select desired articles
    /// </summary>
    /// <returns></returns>
    public ActionResult ArticlesSlider()
    {
      var item = RenderingContext.Current.Rendering.Item;

      if (!item?.DescendsFrom(Templates.ArticlesSlider.ID) ?? true)
      {
        return Context.PageMode.IsExperienceEditor ?
            this.InfoMessage(new InfoMessage(AlertTexts.InvalidDataSourceTemplateFriendlyMessage, InfoMessage.MessageType.Error)) :
            null;
      }

      var vm = _blogRepository.GetSliderData(item);

      return View(vm);
    }

    /// <summary>
    /// promo section for products and article page
    /// </summary>
    /// <returns></returns>
    public ActionResult PromoSection()
    {
      var item = RenderingContext.Current.Rendering.Item;
      var vm = _blogRepository.GetPromoSectionViewModel(item);
      return View("PromoSection", vm);
    }
    
    /// <summary>
    /// main article page
    /// </summary>
    /// <returns></returns>
    public ActionResult Article()
    {
      var item = RenderingContext.Current.Rendering.Item;  
      var vm = _blogRepository.GetArticleViewModel(item);    
      return View("ArticleContent", vm);
    }      

    /// <summary>
    /// Loaf life stages rendering
    /// </summary>
    /// <returns></returns>
    public ActionResult LifeStages()
    {
      var item = RenderingContext.Current.Rendering.Item; 
      return View("LifeStages", item.Children);
    }

    /// <summary>
    /// Latest articles for blog landing page
    /// </summary>
    /// <returns></returns>
    public ActionResult LatestArticles()
    {  
      var item = RenderingContext.Current.Rendering.Item;
      var count = RenderingContext.Current.Rendering.GetIntegerParameter("count", Contants.LatestNews.NumberOfArticles);

      IEnumerable<BlogPostItem> data = new List<BlogPostItem>();

      try
      {
        data = _blogRepository.GetLatest(item, count);
      }
      catch (Exception ex)
      {
        Log.Error("LatestArticles exception", ex, this);
      }

      return View("LatestArticles", data);
    }

    public ActionResult RelatedArticles()
    {
      var item = RenderingContext.Current.Rendering.Item;
      var pagingSettings = FillSettings(item);

      var data = GetPagedResults(item, pagingSettings);

      return View("RelatedArticles", data);
    }

    /// <summary>
    /// Load articles list for specific category (product or life stage)
    /// </summary>
    /// <returns></returns>
    public ActionResult ArticlesList()
    {
      var item = RenderingContext.Current.Rendering.Item;
      var pagingSettings = FillSettings(item);

      var data = GetPagedResults(item, pagingSettings);

      return View("ArticlesList", data);
    }

    /// <summary>
    /// Ajax load more articles
    /// </summary>
    /// <param name="pagingSettings"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult AjaxPagedList(PagingSettings pagingSettings, int page = 0)
    {
      var item = Context.Database.GetItem(new ID(pagingSettings.CurrentItemID));
      pagingSettings = FillSettings(item, page);
      var data = GetPagedResults(item, pagingSettings);

      var partial = Utilities.RenderRazorViewToString(ControllerContext, "_PagedListArticles", data);
      return Json(new { exhausted = !data.ShowLoadMore, data = partial }, JsonRequestBehavior.AllowGet);      
    }


    [HttpGet]
    public ActionResult LatestArticlesFeed(int numberOfArticles = 3)
    {
      IEnumerable<BlogPostItem> data = new List<BlogPostItem>();

      try
      {
        if (numberOfArticles > 100)
          numberOfArticles = 100;

        var rootItem = Context.Database.GetRootItem();

        var blogList = rootItem.Axes.GetDescendants()
                                    .Where(x => x.TemplateID == Templates.BlogList.ID)
                                    .FirstOrDefault() ?? throw new ArgumentNullException("blogList not found");

        data = _blogRepository.GetLatest(rootItem, numberOfArticles, true, true);
      }
      catch (Exception ex)
      {
        Log.Error("LatestArticlesFeed exception", ex, this);
      }

      return Json(data, JsonRequestBehavior.AllowGet);
    }


    private PagingSettings FillSettings(Item item, int currentPage = 0)
    {
      var includedFields = new Dictionary<string, string>();
      var excludedFields = new Dictionary<string, string>();
      bool showTags = false;
      var itemsOnPage = 6;

      if (item.TemplateID == Templates.Product.ID)
      {
        showTags = false;
        includedFields.Add(Templates.HasProducts.Fields.SelectedProducts_FieldName,
          item.ID.ToString().ToLower().Replace("-", "").TrimStart('{').TrimEnd('}'));
      }
      else if (item.TemplateID == Templates.LifeStage.ID)
      {
        showTags = true;
        includedFields.Add(Templates.HasLifeStages.Fields.SelectedLifeStages_FieldName,
          item.ID.ToString().ToLower().Replace("-", "").TrimStart('{').TrimEnd('}'));
      }
      else if (item.TemplateID == Templates.BlogPost.ID)
      {
        showTags = true;

        if(item.FieldHasValue(Templates.HasProducts.Fields.SelectedProducts))
        {
          var selectedProducts = item.GetMultiListValueItems(Templates.HasProducts.Fields.SelectedProducts);
          if (selectedProducts != null && selectedProducts.Any())
          {           
            includedFields.Add(Templates.HasProducts.Fields.SelectedProducts_FieldName,
               selectedProducts.FirstOrDefault().ID.ToString().ToLower().Replace("-", "").TrimStart('{').TrimEnd('}'));
          }
        }

        if (item.FieldHasValue(Templates.HasLifeStages.Fields.SelectedLifeStages))
        {
          var selectedLifeStages = item.GetMultiListValueItems(Templates.HasLifeStages.Fields.SelectedLifeStages);
         
          if (selectedLifeStages != null && selectedLifeStages.Any())
          {           
            includedFields.Add(Templates.HasLifeStages.Fields.SelectedLifeStages_FieldName,
               selectedLifeStages.FirstOrDefault().ID.ToString().ToLower().Replace("-", "").TrimStart('{').TrimEnd('}'));
          }
        }

        //custom property for item id
        excludedFields.Add("_itemid_s", item.ID.ToString().ToLower().Replace("-", "").TrimStart('{').TrimEnd('}'));

        itemsOnPage = 3;
      }

      var pagingSettings = new PagingSettings
      {
        ShowTags = showTags,
        CurrentPage = currentPage,
        OrderBy = Templates.HasBlogContent.Fields.Publicationdate_FieldName,
        IncludedFields = includedFields,
        ExcludedFields = excludedFields,
        ResultsOnPage = itemsOnPage
      };

      return pagingSettings;
    }

    private ArticlesList GetPagedResults(Item item, PagingSettings pagingSettings)
    {
      var results = _blogRepository.GetPagedList(item, pagingSettings);
      return results;
    }

    public ActionResult MigrationData(string year = "")
    {
#if DEBUG
      List<string> errors = new List<string>();    

      if (!string.IsNullOrEmpty(year))
      {
        var page = RenderingContext.Current.Rendering.Item;         

        var data = _blogRepository.GetArticlesForSpecificYear(page, year);
        Sitecore.Data.Database master = Sitecore.Configuration.Factory.GetDatabase("master");
        string mediaPath = $"/sitecore/media library/Project/Eurolife/Blog/{year}"; 

        if (data != null && data.Any())
        {
          foreach(var item in data)
          {
            if(item.Fields["OldImage"].HasValue)
            {                
              string tmpImage = item.Fields["OldImage"].ToString().Split('/').Last();
              string imgRaw = item.Fields["Image Raw HTML"].ToString();
              if (imgRaw.Contains($"{tmpImage}.png"))
                tmpImage = $"{tmpImage}.png";
              else if (imgRaw.Contains($"{tmpImage}.jpg"))
                tmpImage = $"{tmpImage}.jpg";
              else if (imgRaw.Contains($"{tmpImage}.jpeg"))
                tmpImage = $"{tmpImage}.jpeg";
              else if (imgRaw.Contains($"{tmpImage}.gif"))
                tmpImage = $"{tmpImage}.gif";

              string sourcePath = Url.Content(string.Format("{0}/{1}", System.Web.HttpContext.Current.Server.MapPath("~/asm"), System.IO.Path.GetFileName(tmpImage)));

              try
              {

                string proposedName = ItemUtil.ProposeValidItemName(item.Fields["OldImage"].ToString().Split('/').Last());
                Item myItem = master.GetItem(mediaPath + "/" + proposedName);

                if (myItem == null)
                {                     

                  if (!System.IO.File.Exists(sourcePath))
                  {
                    continue;
                  }

                  if (!string.IsNullOrEmpty(sourcePath))
                  {
                    Sitecore.Resources.Media.MediaCreatorOptions options = new Sitecore.Resources.Media.MediaCreatorOptions
                    {
                      // Store the file in the database, not as a file
                      FileBased = false,
                      // Remove file extension from item name
                      IncludeExtensionInItemName = false,
                      // Do not make a versioned template
                      Versioned = false,
                      // set the path
                      Destination = mediaPath
                    };
                    options.Destination = options.Destination + "/" + proposedName;
                    // Set the database
                    options.Database = Sitecore.Configuration.Factory.GetDatabase("master");
                    options.Language = Sitecore.Data.Managers.LanguageManager.GetLanguage("el-GR");

                    // Now create the file
                    Sitecore.Resources.Media.MediaCreator creator = new Sitecore.Resources.Media.MediaCreator();
                    MediaItem mediaItem = creator.CreateFromFile(sourcePath, options);

                    using (new Sitecore.SecurityModel.SecurityDisabler())
                    {
                      item.Editing.BeginEdit();

                      var imageField = (ImageField)item.Fields["Image"];
                      imageField.MediaID = mediaItem.ID;

                      item.Editing.EndEdit();
                    }   
                  }
                }
                else
                {
                  using (new Sitecore.SecurityModel.SecurityDisabler())
                  {
                    item.Editing.BeginEdit();

                    var imageField = (ImageField)item.Fields["Image"];
                    imageField.MediaID = myItem.ID;

                    item.Editing.EndEdit();
                  }
                }
              }
              catch (Exception ex)
              {
                errors.Add(item.Name);
              }

            }
          }
        }         

      }

      return Content(String.Join(", ", errors.ToArray()));
#endif

      return Content("OK");
    }
      
  }
}