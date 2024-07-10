using Sitecore.Data;

namespace Wedia.Foundation.SitecoreExtensions
{
  public struct Constants
  {
    public struct DynamicPlaceholdersLayoutParameters
    {
      public static string UseStaticPlaceholderNames => "UseStaticPlaceholderNames";
    }

    public struct BucketResolver
    {
      public struct Blog
      {
        public const string BlogPath = "/blog/articles";
      }
      public struct BlogPost
      {         
        public static readonly ID TemplateID = new ID("{67F40FEF-B3C7-4366-B026-183E80DCF4E6}");
      }
    
    }

    public struct LifeWebApi
    {
      public static readonly string User = Sitecore.Configuration.Settings.GetSetting("LifeWebApi.User").ToString();
      public static readonly string Password = Sitecore.Configuration.Settings.GetSetting("LifeWebApi.Password").ToString();
      public static readonly string Domain = Sitecore.Configuration.Settings.GetSetting("LifeWebApi.Domain").ToString();
    }
  }
}