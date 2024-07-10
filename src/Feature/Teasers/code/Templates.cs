using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Teasers
{
  public struct Templates
  {
    public struct TeaserBoardItem
    {
      public static readonly ID ID = new ID("{802F372F-AF21-4045-9BA4-B5655427C966}");
    }

    public struct DynamicTeaser
    {
      public static readonly ID ID = new ID("{6D4C5623-46BE-4226-95E1-AAF56A304537}");

      public struct Fields
      {
        public static readonly ID Active = new ID("{2B28DCCA-4258-4F5D-A795-B475333909CB}");
        public static readonly ID Count = new ID("{C1B4B643-02C7-4362-B316-465478198FF6}");
      }
    }

    public struct HasTeaserHeadline
    {
      public static readonly ID ID = new ID("{248FD29E-E583-4A75-8CEB-0A8508D82EBC}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{1C2F6EBB-7EB9-47F8-AF61-57F1174108FE}");
      }
    }

    public struct HasTeaserImage
    {
      public static readonly ID ID = new ID("{94FCF2F1-3CCA-4D44-87FC-4400397C7AAE}");

      public struct Fields
      {
        public static readonly ID Image = new ID("{CFC640DB-B9E4-41D6-ABCD-5050D6B6D6FE}");
      }
    }

    public struct HasTeaserImageMobile
    {
      public static readonly ID ID = new ID("{80336FBB-35B4-437C-BD89-68DE697C8348}");

      public struct Fields
      {
        public static readonly ID Image = new ID("{87F8CB69-AC48-4D6A-88EE-B19665F166F3}");
      }
    }

    public struct HasTeaserSummary
    {
      public static readonly ID ID = new ID("{85BB73D4-978F-4B24-AFC4-243058868D0C}");
      public struct Fields
      {
        public static readonly ID Summary = new ID("{015650F6-49A4-401C-B484-B9410A78C8CA}");
      }
    }

    public struct HasTeaserCTA
    {
      public static readonly ID ID = new ID("{6E50FBEA-AF05-4901-8B4D-3308E1FF92C4}");

      public struct Fields
      {
        public static readonly ID CTA = new ID("{AF8B8E9D-3FE1-4BFF-9062-4A139D8F4975}");
      }
    }

    public struct HasTeaserLabel
    {
      public static readonly ID ID = new ID("{0A7BE377-3CD0-44CC-A191-224D9DBE25A0}");

      public struct Fields
      {
        public static readonly ID Label = new ID("{12F214C9-16EE-4CF1-9220-7D1C8FEFC9A1}");
      }
    }

    public struct HasTeaserDownloadButton
    {
      public static readonly ID ID = new ID("{289626EC-F1F0-4EB1-AF6F-01A29E5936B1}");

      public struct Fields
      {
        public static readonly ID CTA = new ID("{F51DD24C-64BE-4832-9F98-E03F9E84FA63}");
      }
    }

    public struct HasTeaserIcon
    {
      public static readonly ID ID = new ID("{40829EAB-1B5E-40D5-9FB5-8A1D934847AC}");

      public struct Fields
      {
        public static readonly ID Icon = new ID("{B09E98C3-49F2-49CD-8257-C50B267B29F5}");
      }
    }

    public struct HasTeaserTitle
    {
      public static readonly ID ID = new ID("{505F405E-1E8C-4C03-85C8-385669B913B5}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{BBDB1173-7923-40D0-8F16-9E0DA04F4D6B}");
      }
    }

    public struct HasTeaserTitle_2
    {
      public static readonly ID ID = new ID("{86C98A1C-5D99-414A-9A34-8D2E507F5FC2}");

      public struct Fields
      {
        public static readonly ID Title_2 = new ID("{B1433A0A-488B-4EDB-8B7F-A137CA826F37}");
      }
    }

    public struct HasTeaserSubTitle
    {
      public static readonly ID ID = new ID("{B3BF4D03-E66B-41E3-9E8C-F18D34974C4A}");

      public struct Fields
      {
        public static readonly ID SubTitle = new ID("{4EE94DA5-989E-4F54-8A56-6F6F8EDDE228}");
      }
    }

    public struct HasTeaserDescription
    {
      public static readonly ID ID = new ID("{8E870768-9388-4428-91BE-0043044B7BEF}");

      public struct Fields
      {
        public static readonly ID Description = new ID("{8AB028AE-1CE7-4A68-AAE2-B0D9F6622F03}");
      }
    }

    public struct HasTeaserDescription_2
    {
      public static readonly ID ID = new ID("{18147DA2-5242-4FA0-9424-7F3D9C3C1CE5}");

      public struct Fields
      {
        public static readonly ID Description_2 = new ID("{9996BECE-A607-4754-B142-D410921D2A7E}");
      }
    }

    public struct HasTeaserCTA_2
    {
      public static readonly ID ID = new ID("{5CF62D67-6B1C-45FC-8E42-90EF0E818CFB}");

      public struct Fields
      {
        public static readonly ID CTA_2 = new ID("{06BE0EAB-7633-4AB5-841E-197A532E8012}");
      }
    }

  }
}