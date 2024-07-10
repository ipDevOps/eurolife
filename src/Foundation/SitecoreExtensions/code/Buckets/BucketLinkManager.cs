using Sitecore.Buckets.Managers;
using Sitecore.Buckets.Extensions;
using Sitecore.IO;
using Sitecore.Links;
using System;

namespace Wedia.Foundation.SitecoreExtensions.Buckets
{
  public class BucketLinkManager : LinkProvider
  {
    public override string GetItemUrl(Sitecore.Data.Items.Item item, UrlOptions options)
    {        

      if (item.TemplateID == SitecoreExtensions.Constants.BucketResolver.BlogPost.TemplateID)
      {
        if (BucketManager.IsItemContainedWithinBucket(item))
        {
          var bucketItem = item.GetParentBucketItemOrParent();
          if (bucketItem != null && bucketItem.IsABucket())
          {
            var bucketUrl = base.GetItemUrl(bucketItem, options);
            if (options.AddAspxExtension)
            {
              bucketUrl = bucketUrl.Replace(".aspx", string.Empty);
            }

            return FileUtil.MakePath(bucketUrl, item.Name).Replace(" ", "-") +
                    (options.AddAspxExtension ? ".aspx" : string.Empty);
          }
        }
      }       

      return Sitecore.StringUtil.EnsurePostfix('/', base.GetItemUrl(item, options));
    }
  }
}