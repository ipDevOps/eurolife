using Sitecore.Data;
using Sitecore.Shell.Framework.Commands.Masters;

namespace Wedia.Foundation.Multisite
{
  public class Templates
  {
    public struct Site
    {
      public static ID ID = new ID("{74970261-7463-4C79-B6AC-3E9993AEF8EE}");
    }

    public struct DatasourceConfiguration
    {
      public static ID ID = new ID("{15D489C4-EBF5-4F3B-BD82-D2E846AB73E4}");

      public struct Fields
      {
        public static readonly ID DatasourceLocation = new ID("{ED070A1E-0115-4DBB-8685-DF0C5BF846FA}");
        public static readonly ID DatasourceTemplate = new ID("{DA14E9AD-1CE9-4F02-9F5E-23519C650C91}");
      }
    }

    public struct SiteSettings
    {
      public static ID ID = new ID("{F6C12E63-CA81-45FF-A557-A6C0DA4DE66F}");
    }

    public struct RenderingOptions
    {
      public static ID ID = new ID("{D1592226-3898-4CE2-B190-090FD5F84A4C}");

      public struct Fields
      {
        public static readonly ID DatasourceLocation = new ID("{B5B27AF1-25EF-405C-87CE-369B3A004016}");
        public static readonly ID DatasourceTemplate = new ID("{1A7C85E5-DC0B-490D-9187-BB1DBCB4C72F}");
      }
    }
  }
}