using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Navigation
{
  public struct Templates
  {
    public struct DropMenuList
    {
      public static readonly ID ID = new ID("{F7DEA883-2547-44B0-BBE5-FFC4E901CE4A}");
    }

    public struct DropMenuCategory
    {
      public static readonly ID ID = new ID("{340A7CE1-04EA-4572-BC4A-6D8E9A448BE7}");
    }

    public struct DropMenuItem
    {
      public static readonly ID ID = new ID("{7D36D3D3-F756-40C0-9245-9A2104401189}");
    }

    public struct NavigationRoot
    {
      public static readonly ID ID = new ID("{4752B630-7956-4AB6-A3EF-4003178E6111}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{428F3A15-002B-4EBB-A9B5-CC021D99F648}");
      }
    }

    public struct Navigable
    {
      public static readonly ID ID = new ID("{672FFC13-EA1C-476F-8B06-2BFACE235A8F}");

      public struct Fields
      {
        public static readonly ID ShowInNavigation = new ID("{EC41FCD4-6086-4E51-A230-366FA15B648D}");
        public static readonly ID NavigationTitle = new ID("{F8086E11-481D-46AA-B2E5-B0A6F142EF10}");
        public static readonly ID ShowChildren = new ID("{3B4322C4-9D93-498D-85CF-C29921147099}");
      }
    }

    public struct Link
    {
      public static readonly ID ID = new ID("{F776B14E-53B1-4F26-ACED-45AE6D6C69D1}");

      public struct Fields
      {
        public static readonly ID Link = new ID("{6D1ACB3F-339C-4760-8419-DC7D47272005}");
      }
    }

    public struct LinkMenuItem
    {
      public static readonly ID ID = new ID("{9F104273-BC7A-4BD3-89C6-D1E85A67A169}");

      public struct Fields
      {
        public static readonly ID Icon = new ID("{48DD8F9D-3A6E-46DE-B185-4B1B53BFF3FD}");
        public static readonly ID DividerBefore = new ID("{B8C12C18-DCEF-4EDF-A030-50A4A55BEDAC}");
        public static readonly ID Class = new ID("{D7BD8D43-DE42-4BDE-8E7E-DDFCE607A9C6}");
      }
    }

    public struct LinkMenu
    {
      public static readonly ID ID = new ID("{00D32287-3ED5-4D97-9B00-0F8EF05F6DB8}");
    }

    public struct HasDropMenuCategory
    {
      public static readonly ID ID = new ID("{99132090-A113-472B-8BC6-27CD6571FCE4}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{BB0D84E8-DEA5-4BCD-9FB9-191C50D652E6}");
        public static readonly ID MenuTitle = new ID("{C87054EF-9E94-4E34-B8B9-5250B6D3F1EC}");
        public static readonly ID MenuDescription = new ID("{75AB4B88-E708-484F-80EB-8EF979966779}");
      }
    }

  }
}