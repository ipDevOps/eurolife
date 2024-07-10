using Sitecore.Data;

namespace Wedia.Feature.Panels
{
  public struct Templates
  {
    public struct Folder
    {
      public static readonly ID ID = new ID("{FA06883A-FBAC-487E-9B8A-9A55109EAFE3}");
    }

    public struct Panel
    {
      public static readonly ID ID = new ID("{7F38453C-4222-4F5A-9055-66089C0C04E8}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{3C70DC86-2EAA-46EB-AC08-077BDDA5A247}");
        public static readonly ID Summary = new ID("{09AB4417-580D-412A-B022-1288B2F95534}");
        public static readonly ID Items = new ID("{3EEDCF8A-848C-4BEB-8513-B0577EE4ACFE}");
        public static readonly ID Categories = new ID("{6B0A5C41-7AD3-4548-96A9-B5086C2F0969}");
        public static readonly ID Filters = new ID("{EAEFDE6C-1755-4C47-BC40-237D17A8EBE8}");
      }
    }

    public struct PanelItem
    {
      public static readonly ID ID = new ID("{D0D7B515-5AE8-4049-A328-0D5C1C87FD3E}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{61303124-E3CF-431F-B6EB-25A1B3201834}");
        public static readonly ID Value = new ID("{BE970800-6D58-4663-AE9B-111A8FFCD2BD}");
      }
    }

    public struct PanelRow
    {
      public static readonly ID ID = new ID("{B5BF3A51-5D86-431A-ABDC-47F81C333C3F}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{1EF9B331-607C-48D3-BC12-C8B2D7CA1E40}");
        public static readonly ID Rows = new ID("{0FEDEF40-1ED0-422A-AEFB-B9ED2277043C}");
        public static readonly ID IsCheckbox = new ID("{1543892B-A690-4E90-A05F-C496FEE76C18}");
        public static readonly ID PanelRowTooltip = new ID("{F2D1C581-2352-4F2F-B79D-A339C237AC87}");
      }
    }

    public struct PanelCateogory
    {
      public static readonly ID ID = new ID("{944F51F1-0D2A-468B-905C-E88A1971066A}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{C7A77AB1-E14B-4AB5-AEA0-E3D6E3DB5941}");
        public static readonly ID Rows = new ID("{0FEDEF40-1ED0-422A-AEFB-B9ED2277043C}");
        public static readonly ID IsMain = new ID("{070BA0DE-12B3-4559-9B33-46C028777BD4}");
      }
    }

    public struct PanelRowItemValue
    {
      public static readonly ID ID = new ID("{C73AFB19-10EB-4E6F-8C70-8AF7F8C6D83B}");

      public struct Fields
      {
        public static readonly ID Row = new ID("{3C78FA0C-C0BD-42DA-BD52-6C3EC55A2C73}");
        public static readonly ID Value = new ID("{AE0C5505-9BCD-4218-9E66-E5BE620BCC7C}");
        public static readonly ID Check = new ID("{79F18C52-1570-4ECB-B32E-A55DF2FB321D}");
        public static readonly ID Tooltip = new ID("{46A86135-502B-4015-82FB-A4D54AB61719}");
      }
    }

    public struct PanelGroup
    {
      public static readonly ID ID = new ID("{FE6BD4BE-7E16-4959-8422-B0C12870ED74}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{F5D19984-678A-4FEF-919D-4CF92F68F464}");
        public static readonly ID Summary = new ID("{FB7552F8-587D-4B90-AE31-7E3EC84AE7F0}");
        public static readonly ID Panels = new ID("{409BB7C5-2388-4787-A80A-2CC72157FB5C}");
      }
    }
  }
}