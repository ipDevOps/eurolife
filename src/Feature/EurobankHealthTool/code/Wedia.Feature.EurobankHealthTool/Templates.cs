using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Wedia.Feature.EurobankHealthTool
{
  public class Templates
  {
    public struct EurobankArticle
    {
      public static readonly ID ID = new ID("{853088F4-1362-4961-996A-3EE7B1A1F594}");
    }

    public struct EurobankCategory
    {
      public static readonly ID ID = new ID("{1FB605BC-5576-4564-BFDD-D219EE87AAEF}");
    }

    public struct EurobankLanding
    {
      public static readonly ID ID = new ID("{1EE7CE8B-B22F-4658-9B86-99BEC81A7BE7}");
    }

    public struct EBArticleContent
    {
      public static readonly ID ID = new ID("{C6824E42-A120-446C-AC81-D39C1EC4B85F}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{C418852F-1DC2-4AFB-A4F5-2C70735C8065}");
        
        public static readonly ID Teaser = new ID("{93D8811C-00AE-43FB-9D2F-8CC5A3540EB2}");
        public const string Teaser_FieldName = "Teaser";
        public static readonly ID MainContent = new ID("{63D9AEBB-7D4C-43EB-A3EE-ADC96DF941D8}");             
        public static readonly ID Image = new ID("{F06F4366-95E6-40AC-BF47-09F13AA071E3}");
      }
    }


    public struct EurobankListGroup
    {
      public static readonly ID ID = new ID("{0C6604DE-FBCF-49A4-AA94-AD66531AAC3F}");

      public struct Fields
      {
        public static readonly ID EurobankList = new ID("{53B43279-8C4F-4FB2-919D-B529FB741E18}");
        public static readonly ID EurobankListTitle = new ID("{A91447B2-714F-4AF6-988F-CDF3C9F483E9}");
        public static readonly ID EurobankListSubtitle = new ID("{6A6C3A91-BD74-4438-9789-B9A22780DD54}");
      }
    }

    public struct EurobankListMain
    {
      public static readonly ID ID = new ID("{D9CD3235-4495-4233-A538-AFE4D8E90552}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{D22C0E38-20A0-473C-B815-2C702F14CE4F}");
        public static readonly ID Summary = new ID("{B177421C-4751-4B76-BD99-E3568B6E4E51}");
        public static readonly ID Link = new ID("{94DED248-7FDA-43F9-964A-2EDA95BDBC2E}");
        public static readonly ID Date = new ID("{6FAE2385-76B1-4209-9218-FA40357EB804}");
        public static readonly ID Category = new ID("{4D3186EA-2A6B-4673-8A57-494637F5B4D5}");
        public static readonly ID CategoryLink = new ID("{C3B8FF12-1ECB-4E20-BEA4-BBA9EDBCC899}");
        public static readonly ID Image = new ID("{5AD97C33-C017-47B4-9816-213126CFC29A}");
      }
    }

    public struct HasExcelTemplate
    {
      public static readonly ID ID = new ID("{4347EDEC-CAE9-4C1A-847B-FCB6DA3F92AE}");

      public struct Fields
      {
        public static readonly ID ExcelFile = new ID("{45E01379-E7EC-46FF-ACDD-0BE5462F3E5F}");
      }
    }

    public struct ProductsList
    {
      public static readonly ID ID = new ID("{AECD2696-8934-4C05-9ACB-A6F72644E86C}");
    }

    public struct Product
    {
      public static readonly ID ID = new ID("{47707496-BE60-48C4-9A9A-2BB9DE6B56D2}");
    }

    public struct HasProductContent
    {
      public static readonly ID ID = new ID("{9F20F8C2-702D-4AE1-B2C9-F3BA068615B9}");

      public struct Fields
      {
        public static readonly ID Code = new ID("{7CF02413-6700-4F33-8180-4D511BD8DA30}");
        public static readonly ID Title = new ID("{6643DE71-10B8-4AA6-86F3-B3D4A63288E4}");
        public static readonly ID Summary = new ID("{22DA33A1-E5AC-4E48-AA4E-C82D41D33A7D}");
        public static readonly ID FullDescription = new ID("{EEC5187D-E5C9-4E44-AD9D-9FEEA629858B}");
        public static readonly ID HospitalPosition = new ID("{759E6466-0C1B-4B96-B465-6E0C24A2C564}");
        public static readonly ID ExemptionAmount = new ID("{9BCDED88-3317-4058-95B4-83301DD83985}");
        public static readonly ID PromoCTATitle = new ID("{3C37000C-2807-4CF8-BAB3-5AD6A8841F8A}");
        public static readonly ID PromoCTALink = new ID("{5C09AE1D-5D01-4F12-AC56-4F5302581B9E}");
        public static readonly ID PromoCTAText = new ID("{189B06CF-CA5B-4587-8766-45B0B3EEB05B}");
        public static readonly ID PromoFirstTitle = new ID("{5DA991B0-0806-487C-AF18-33C3A4A46AEC}");
        public static readonly ID PromoSecondTitle = new ID("{415E0128-C0E5-4B50-999E-E5C47C395E9E}");
        public static readonly ID ToolCTATitle = new ID("{A43E4F81-BBEE-4F21-AB41-40F69371EBB1}");
        public static readonly ID ToolCTALink = new ID("{51C5B69A-80AE-48A4-BF1C-EB9074CD14B1}");
      }
    }

  }
}