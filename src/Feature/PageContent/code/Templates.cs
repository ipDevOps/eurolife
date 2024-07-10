using Sitecore.Data;

namespace Wedia.Feature.PageContent
{
  public struct Templates
  {
    public struct InvestmentPlan
    {
      public static readonly ID ID = new ID("{296D6535-40DA-4099-9C0F-C21724A22A2C}");
    }

    public struct Card
    {
      public static readonly ID ID = new ID("{7EE9A785-E169-474E-A73E-7833892BE2A9}");
    }

    public struct PieChart
    {
      public static readonly ID ID = new ID("{5515C419-66CB-4E45-B3C1-8501562A105A}");
    }

    public struct BarChart
    {
      public static readonly ID ID = new ID("{94962BE4-3EF6-41A7-834C-A4127DDEB95C}");     
    }

    public struct SocialWall
    {
      public static readonly ID ID = new ID("{B7EF6502-9906-4AAE-9E44-DCCCD740FB32}");
    }

    public struct NewsletterSubscription
    {
      public static readonly ID ID = new ID("{3590DA26-6390-442A-A776-657A9EAB38E5}");
    }

    public struct HasPageIconContent
    {
      public static readonly ID ID = new ID("{A5A87E16-7A80-47F8-AD2B-C27DCA24EB46}");

      public struct Fields
      {
        public static readonly ID Image = new ID("{23EF204D-DF36-447D-9E7D-8862C8B6455F}");
        public const string Image_FieldName = "Image";        
      }
    }

    public struct HasPageImageContent
    {
      public static readonly ID ID = new ID("{AE8B3FD1-CD52-49C5-9CFD-FDE8B7D58751}");

      public struct Fields
      {
        public static readonly ID DesktopImage = new ID("{B55592B1-8771-4BC3-A3A7-A30A2761430F}");
        public const string DesktopImage_FieldName = "DesktopImage";
        public static readonly ID MobileImage = new ID("{48C14F0A-157D-43E9-B294-261895506AE9}");
        public const string DesktopImage_MobileImage = "MobileImage";
      }
    }

    public struct HasPageContent
    {
      public static readonly ID ID = new ID("{68DC8ED7-3248-4897-B179-7516EA3ED3C3}");

      public struct Fields
      {
        public static readonly ID PreTitle = new ID("{1D7F5999-9735-4C52-9E08-47BD7DF3FB40}");
        public const string PreTitle_FieldName = "PreTitle";
        public static readonly ID Title = new ID("{48B984BE-446E-40C9-B86B-2B93F35F015E}");
        public const string Title_FieldName = "Title";
        public static readonly ID Summary = new ID("{9580E8D5-430E-4746-B4C1-6B71C56DF42E}");
        public const string Summary_FieldName = "Summary";
      }
    }

    public struct HasPageBodyContent
    {
      public static readonly ID ID = new ID("{A41837DB-BE80-49DD-9340-D1336CB1F17F}");

      public struct Fields
      {
        public static readonly ID Body = new ID("{5C95201B-69ED-40AE-ABDA-9EB83141D8E9}");
        public const string Body_FieldName = "Body";
      }
    }

    public struct HasPageInfoContent
    {
      public static readonly ID ID = new ID("{8511B505-DBBF-4FE1-9CD2-02B19AC125DC}");

      public struct Fields
      {
        public static readonly ID InfoContent = new ID("{BEC0DFB9-56A3-42B7-A619-E387F2C5B4B2}");
        public const string InfoContent_FieldName = "InfoContent";
      }
    }

    public struct HasPageCTA
    {
      public static readonly ID ID = new ID("{3E46454B-80FF-4B1C-AA72-B73CED6902BE}");

      public struct Fields
      {
        public static readonly ID CTA = new ID("{59B7D0BE-39F3-4F45-B645-BDE65FA07015}");
      }
    }

    public struct HasTitle
    {
      public static readonly ID ID = new ID("{1BA5F547-B119-44CB-BE3E-177AFA5517F0}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{D255187D-6894-46A2-B8B8-878B5E2B920B}");
      }
    }

    public struct HasSubTitle
    {
      public static readonly ID ID = new ID("{F33EF93B-3514-4011-AEE9-2357C7DCB3C4}");
      public struct Fields
      {
        public static readonly ID SubTitle = new ID("{AB009181-46A0-4FB0-8D89-218FE421D122}");
      }
    }

    public struct HasDescription
    {
      public static readonly ID ID = new ID("{F727CC0F-D809-41DF-9338-68C5D264075F}");
      public struct Fields
      {
        public static readonly ID Description = new ID("{49F97460-3F80-4654-A453-A9C2069C45D9}");
      }
    }

    public struct HasPieChartContent
    {
      public static readonly ID ID = new ID("{BEAF6171-25BD-4BB3-BE08-DB4F62A697C2}");
      public struct Fields
      {
        public static readonly ID Tooltip = new ID("{40ED1BA9-13AE-40DF-AE34-21C181B6AD38}");
        public static readonly ID Title_1 = new ID("{54EFD029-2983-4A72-B95D-1CDCEB991189}");
        public static readonly ID Value_1 = new ID("{1772D62B-16CF-4F15-8824-0FF83DDB723C}");
        public static readonly ID Title_2 = new ID("{B19F2B4D-C2CE-4684-9DF8-21BF0F4B0762}");
        public static readonly ID Value_2 = new ID("{4AC3A72C-37B8-46FC-AD6B-F3AB48378BBC}");
        public static readonly ID Title_3 = new ID("{A47B8FD6-EDB0-41D9-A324-2ED86DD7BAF3}");
        public static readonly ID Value_3 = new ID("{4DD8B5B6-98A8-4C1B-A59E-45B343C939EA}");
      }
    }

    public struct HasBarChartContent
    {
      public static readonly ID ID = new ID("{7678D65D-4EC6-4784-A8B1-234A58304BDF}");
      public struct Fields
      {
        public static readonly ID Value = new ID("{F42C66DE-4456-48DC-8C69-27C996ED7E74}");
        public static readonly ID HexColor = new ID("{7748887A-80CC-48FB-BCF8-B4951B76C86D}");
      }
    }

    public struct HasSocialLinks
    {
      public static readonly ID ID = new ID("{CE354BF8-6B6F-4921-93E1-CB1A280ABB8F}");
      public struct Fields
      {
        public static readonly ID Facebook = new ID("{05F53E1E-8C6D-466F-8E7B-C0148583D3D6}");
        public static readonly ID LinkedIn = new ID("{9AD55576-3C4F-42E7-B617-B9FFE003E969}");
        public static readonly ID YouTube = new ID("{DC058A43-5B55-42FC-939C-1DAC80020E1D}");
      }
    }

    public struct HasSocialImages
    {
      public static readonly ID ID = new ID("{448E4675-4B0E-4E74-8870-C03F548B1309}");
      public struct Fields
      {
        public static readonly ID Image_1 = new ID("{DDD6B4AD-0CFA-4784-BC19-934CCDA7048B}");
        public static readonly ID Image_2 = new ID("{EFD6A708-E194-4557-9670-C9498BBF065A}");
        public static readonly ID Image_3 = new ID("{9563181D-8778-4C64-A61F-B4803DEE187D}");
      }
    }
  }
}