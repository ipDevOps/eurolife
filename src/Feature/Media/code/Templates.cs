using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Media
{
  public struct Templates
  {
    public struct HasMedia
    {
      public static readonly ID ID = new ID("{C0C03229-5BD7-4D32-82F3-A1A71D97F727}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{8E77D56C-9AD2-4B70-BC1F-BEB99DE004E9}");
        public const string Title_FieldName = "MediaTitle";
        public static readonly ID Description = new ID("{20FAF759-601D-41E5-B2CE-CB23BE133C32}");
        public const string Description_FieldName = "MediaDescription";
        public static readonly ID Thumbnail = new ID("{DE984D10-9F28-4135-B53F-FE8B5DE19C55}");
        public const string Thumbnail_FieldName = "MediaThumbnail";
        public static readonly ID Label = new ID("{2B8D567C-52B2-4D1B-A645-2021D33C24EE}");
        public static readonly ID FirstPublisdDate = new ID("{1EAC664F-71C3-4F5B-8D1D-22C4363720B1}");
        public const string Media_FirstPublishDate = "MediaFirstPublishDate";
        public static readonly ID PublishSource = new ID("{502AB0B3-D1F6-4079-A6F4-C91EA0CCE9A1}");
        public const string Media_PublishSource = "MediaPublishSource";
      }
    }

    public struct HasMediaSelector
    {
      public static readonly ID ID = new ID("{84FFE891-AF2B-4050-B119-8E8722443C91}");

      public struct Fields
      {
        public static readonly ID MediaSelector = new ID("{F10D132F-19E6-4524-B1AB-AEC4F2A4931C}");
      }
    }

    public struct HasMediaImage
    {
      public static readonly ID ID = new ID("{97AFB237-A504-4CEA-87EB-02B9F8934717}");

      public struct Fields
      {
        public static readonly ID Image = new ID("{193F78B8-6160-4346-92C3-2954CE7026DE}");
      }
    }

    public struct HasMediaVideo
    {
      public static readonly ID ID = new ID("{9D7CD402-28C2-4E3B-BD70-19371AD5B493}");

      public struct Fields
      {
        public static readonly ID VideoLink = new ID("{66DB8F07-EEB8-4B8B-9AA1-75146826CE42}");
      }
    }

    public struct HasMediaGroupTitle
    {
      public static readonly ID ID = new ID("{789A56EF-6898-4593-BF34-2EAD332CBB78}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{FF6FC789-F1F2-495E-8A94-EFCBC528E1C6}");
      }
    }

    public struct MediaFile
    {
      public static readonly ID ID = new ID("{87151256-44A4-48E2-92B9-E40A529C4540}");

      public struct Fields
      {
        public static readonly ID File = new ID("{BF50C27A-312F-408D-A49B-2E34D6A1E715}");
      }
    }

    public struct  MediaFileGroup
    {
      public static readonly ID ID = new ID("{2598ADF9-8F12-4651-ABFB-435B1153A62A}");

      public struct Fields
      {
        public static readonly ID Files = new ID("{92184EE7-4EE4-466B-85BC-AD334BB2BEEE}");
      }
    }

    public struct MediaFileFolderGroup
    {
      public static readonly ID ID = new ID("{20C44FDF-B209-41B2-8A41-4AE8DF883C64}");

      public struct Fields
      {
        public static readonly ID Group = new ID("{F4543AEB-0454-4609-AFEC-D2AB0DD4FA11}");
      }
    }

    public struct HasMediaPublication
    {
      public static readonly ID ID = new ID("{3D83FC91-8358-4E1A-9CC1-FDF90C6E3AE2}");

      public struct Fields
      {
        public static readonly ID FirstPublishDate = new ID("{1EAC664F-71C3-4F5B-8D1D-22C4363720B1}");
        public static readonly ID PublishDate = new ID("{01D8867E-7244-41E9-9742-EE60972E6F12}");
        public const string Media_PublishDate = "MediaPublishDate";
        public static readonly ID PublishSource = new ID("{502AB0B3-D1F6-4079-A6F4-C91EA0CCE9A1}");
      }
    }

    public struct HasMediaUrl
    {
      public static readonly ID ID = new ID("{8DED5BE5-8CF5-4D9C-AC6F-B28C797CA805}");

      public struct Fields
      {
        public static readonly ID Url = new ID("{661C186C-F966-466B-8AAF-5FB32600711B}");
      }
    }

    public struct FinancialReports
    {
      public static readonly ID ID = new ID("{7FC965FC-B67A-40A0-8428-2CDF16C71B68}");
    }
     
    public struct PricingDocs
    {
      public static readonly ID ID = new ID("{FD330C65-B44A-4441-9988-5C6BFECEA0D8}");
    }

    public struct PricingDoc
    {
      public static readonly ID ID = new ID("{D222549D-036E-4BB3-A381-0F5E710F995C}");
    }   

    public struct HasPricingDoc
    {
      public static readonly ID ID = new ID("{AD6E4DE0-6A1B-4947-8029-DBC95A83C84F}");

      public struct Fields
      {          
        public static readonly ID File = new ID("{E9C6743E-53C9-428F-8536-F9F3C3DC64AF}");     
        public const string Name_Key = "_name";
        public static readonly ID PricingRoot = new ID("{2C711436-CDC3-4065-838F-AC0DFB71FC14}");
      }
    }
  }
}