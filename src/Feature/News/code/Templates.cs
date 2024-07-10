using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.News
{
  public struct Templates
  {
    public struct NewsArticle
    {
      public static readonly ID ID = new ID("{37C0600D-B62F-40D3-BB5E-51F9777ED47A}");
      
      public struct Fields
      {
        public static readonly ID Title = new ID("{CD562337-58D1-4AC7-AE9C-CAC9839368D3}");
        public const string Title_FieldName = "NewsTitle";

        public static readonly ID DesktopImage = new ID("{06DA1C6E-A118-40BC-9C2A-C951364F98F7}");
        public const string DesktopImage_FieldName = "NewsDesktopImage";
        public static readonly ID MobileImage = new ID("{CC55C7F7-8274-465B-8A77-D65B2153BB00}");
        public const string DesktopImage_MobileImage = "NewsMobileImage";

        public static readonly ID Date = new ID("{F426DCD4-A506-4A26-A7C1-E77AE6E22A1A}");
        public const string Date_FieldName = "NewsDate";

        public static readonly ID Summary = new ID("{554286B4-E1F0-49D5-A706-9739F30830BF}");
        public const string Summary_FieldName = "NewsSummary";

        public static readonly ID Body = new ID("{4F14C1C9-29A8-4039-BE45-351A340C4D54}");
        public const string Body_FieldName = "NewsBody";
      }
    }

    public struct NewsFolder
    {
      public static readonly ID ID = new ID("{2821DDC7-AE57-487E-B2A3-33AAA36BF07F}");
    }
    
  }
}