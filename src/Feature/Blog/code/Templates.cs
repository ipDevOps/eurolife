using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Blog
{
  public struct Templates
  {

    public struct Blog
    {
      public static readonly ID ID = new ID("{417DA68A-F3A5-4F0E-B96D-8FBFF6FF72E1}");
    }

    public struct BlogList
    {
      public static readonly ID ID = new ID("{559AD9DB-9BFE-40A2-9034-9E965E06A6FF}");
    }

    public struct BlogPost
    {
        public static readonly ID ID = new ID("{67F40FEF-B3C7-4366-B026-183E80DCF4E6}");
    }    
    
    public struct LifeStage
    {
      public static readonly ID ID = new ID("{3D204D86-3DB9-4721-B8AD-D4AA7F0E6F6E}");
      public struct Fields
      {
      }
    }

    public struct Product
    {
      public static readonly ID ID = new ID("{70DBEA9E-F842-4F79-A111-DD9D803526EE}");

      public struct Fields
      {
      }
    }

    public struct ArticlesSlider
    {
      public static readonly ID ID = new ID("{2A9F943D-6A09-43DC-9917-FC5552AAC173}");     
    }

    public struct HasBlogContent
    {
      public static readonly ID ID = new ID("{6976D16D-9044-4615-8C3C-4ED3BF7E60A4}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{ABB06B40-3BDA-4795-9E3F-C3203DA27637}");
        public const string Title_FieldName = "Title";
        public static readonly ID Teaser = new ID("{9FB7209F-E455-4463-91BA-1216D326DBFC}");
        public const string Teaser_FieldName = "Teaser";
        public static readonly ID MainContent = new ID("{751CC2E2-F3D2-4896-94B5-ED8174395942}");
        public static readonly ID ContentPart2 = new ID("{4BC3D402-8171-461A-B87D-BBB56E3431D8}");
        public static readonly ID Publicationdate = new ID("{DC21DBB1-629E-4C7C-8260-2048C1DE036F}");
        public const string Publicationdate_FieldName = "Publicationdate";
        public static readonly ID Image = new ID("{A766D447-508E-4FEC-9033-F00E30361EDC}");  
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

    public struct HasLifeStages
    {
      public static readonly ID ID = new ID("{B155D7C4-8330-4919-975E-674BA528B46D}");

      public struct Fields
      {
        public static readonly ID SelectedLifeStages = new ID("{DC55B7E8-4AEA-4E4F-82F3-4BEFD91D4375}");
        public const string SelectedLifeStages_FieldName = "Selected Life Stages";
      }
    }

    public struct HasProducts
    {
      public static readonly ID ID = new ID("{4B97E4C2-4C80-4C33-9357-5A5521C62296}");

      public struct Fields
      {
        public static readonly ID SelectedProducts = new ID("{710D9BE7-B5B4-4786-AF74-43FD2D763A3B}");
        public const string SelectedProducts_FieldName = "Selected Products";
      }
    }

    public struct HasColor
    {
      public static readonly ID ID = new ID("{ED2D2057-7FF2-437F-8010-B506D226B964}");

      public struct Fields
      {
        public static readonly ID SelectedColor = new ID("{7370C8EF-7E8E-4ACB-9700-70114F1BA73D}");
      }
    }
    
    public struct Style
    {
      public static readonly ID ID = new ID("{CC84A3AC-CBE7-454E-8E28-929FCD7D8753}");

      public struct Fields
      {
        public static readonly ID Style = new ID("{41D1E1AA-4552-4852-B717-ACD5D3E632C2}");
      }
    }

    //public struct HasCTA
    //{
    //  public static readonly ID ID = new ID("{74FFB94C-1BD7-4BFC-8292-DB9379745E3B}");

    //  public struct Fields
    //  {
    //    public static readonly ID Title = new ID("{8B54C24C-E106-4715-9B85-954473010D46}");

    //    public static readonly ID Link = new ID("{2814FC30-0147-4CCF-9F85-52AB3925D8F7}");
    //  }
    //}

    public struct HasTag
    {
      public static readonly ID ID = new ID("{6EA52919-2D4A-4347-B7C8-81C644BDF385}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{E22449AE-462C-4573-9018-6FE278161AAB}"); 
      }
    }

    public struct HasArticleIntro
    {
      public static readonly ID ID = new ID("{963F5D1D-DD7B-4BD4-8D67-B16730BE4EE5}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{038889D7-D183-49DB-9087-92C16F9A22C9}");
        public static readonly ID Subtitle = new ID("{4A13A0C8-178B-49F7-9540-F4F677E737C4}");
      }
    }

    public struct HasPromo
    {
      public static readonly ID ID = new ID("{20F5520E-D561-4DED-8926-8A973145909C}");

      public struct Fields
      {
        public static readonly ID Icon = new ID("{846EA033-54E2-48AB-BD8E-5CA53D177000}");
        public static readonly ID Title = new ID("{DDFE8A5B-F9FD-45C9-B096-9CFA4B68BFC2}");
        public static readonly ID CTA = new ID("{7D7BC053-7804-4B84-A8EF-415610C803FF}");
        public static readonly ID Color = new ID("{F6530655-A2E7-4874-9DA1-AB4852E9A0DB}");
      }
    }

    public struct HasTitle
    {
      public static readonly ID ID = new ID("{CC95603C-E0CF-48B9-A352-3C5A8BB1E6A2}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{BEA35F1D-57FB-4B62-8771-0FCA5E26DE39}");
      }
    }

    public struct HasSubTitle
    {
      public static readonly ID ID = new ID("{6936692B-6199-47E6-B4E8-C5E17662F7C3}");
      public struct Fields
      {
        public static readonly ID SubTitle = new ID("{EF564F63-AC66-4AC2-985F-CF03483E18FE}");
      }      
    }

    public struct HasArticles
    {
      public static readonly ID ID = new ID("{6936692B-6199-47E6-B4E8-C5E17662F7C3}");
      public struct Fields
      {
        public static readonly ID Articles = new ID("{0DCE0B72-AE72-4430-939B-61236DF4A2B1}");
      }
    }
  }
}