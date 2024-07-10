using System;
using Sitecore.Pipelines.HttpRequest;
using Sitecore;
using Sitecore.ContentSearch;
using System.Configuration;
using Sitecore.ContentSearch.SearchTypes;
using System.Linq; 
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;

namespace Wedia.Foundation.SitecoreExtensions.Buckets
{
  public class BucketItemResolver : HttpRequestProcessor
  {   
    public override void Process(HttpRequestArgs args)
    {
      try
      {
        Assert.ArgumentNotNull(args, "args");

        if (Context.Item != null || Context.Database == null || args.Url.ItemPath.Length == 0) return;

        string localUrl = args.LocalPath.ToLower();

        if (!localUrl.StartsWith(SitecoreExtensions.Constants.BucketResolver.Blog.BlogPath)) return;

        var itemPathParts = args.Url.ItemPath.Split('/');

        if (itemPathParts.Length == 0) return;

        var articleName = itemPathParts[itemPathParts.Length - 1].Replace("-", " ").ToLower();

        if (string.IsNullOrEmpty(articleName)) return;

        var index = ContentSearchManager.GetIndex($"sitecore_{Context.Database?.Name}_index");          

        using (var searchContext = index.CreateSearchContext())
        {
          var query = searchContext.GetQueryable<SearchResultItem>().Where(x => x.TemplateId == SitecoreExtensions.Constants.BucketResolver.BlogPost.TemplateID
                      && x.Name.Equals(articleName));
          var result = query.FirstOrDefault();

          if (result != null)
          {
            var item = result.GetItem();
            if (item.Language == Context.Language)
            {
              Context.Item = result.GetItem();
            }
            else
            {
              var langItem = Sitecore.Context.Database.GetItem(result.ItemId, Context.Language);
              if (langItem != null)
              {
                Context.Item = langItem;
              }
            }
          }


        }
      }
      catch (Exception ex)
      {
        return;
      }      
    }      
  }
}