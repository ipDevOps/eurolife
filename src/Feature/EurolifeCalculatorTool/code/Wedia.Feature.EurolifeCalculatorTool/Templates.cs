using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool
{
  public struct Templates
  {    
    public struct TargetGroupList
    {
      public static readonly ID ID = new ID("{96E2EAB8-0F60-4121-9975-663EA0D91937}");
    }

    public struct TargetGroup
    {
      public static readonly ID ID = new ID("{548C64C6-F5E0-495E-847E-9D6AA78962E6}");
    }

    public struct ProductsList
    {
      public static readonly ID ID = new ID("{FB4A71A9-8F1C-4560-B130-CFB7BB7CBC5F}");
    }

    public struct Product
    {
      public static readonly ID ID = new ID("{B18AD3FE-E9DC-4BC5-96E7-10E14EBB4D37}");
    }

    public struct HospitalizationList
    {
      public static readonly ID ID = new ID("{1B192805-9FFA-4A86-AB02-F2EA0FB2918B}");
    }

    public struct Hospitalization
    {
      public static readonly ID ID = new ID("{D6965262-7267-47F5-B0FE-1EAA023F5F3D}");
    }

    public struct AmountsList
    {
      public static readonly ID ID = new ID("{0F9FB495-269E-4368-A56A-5D359E83AFDF}");
    }

    public struct Amount
    {
      public static readonly ID ID = new ID("{A661F0BE-4895-447E-B1AA-0024D1D82C3D}");
    }

    public struct BundlesList
    {
      public static readonly ID ID = new ID("{96FE92AA-7E2D-4601-ADD7-4317621898F2}");
    }

    public struct BundleGroup
    {
      public static readonly ID ID = new ID("{E1EBFAF1-D607-4EE2-A8A6-FCFB2D6475E1}");
    }

    public struct Bundle
    {
      public static readonly ID ID = new ID("{E4518440-EB6E-4EF0-8889-FC9E92DAC933}");
    }

    public struct FamilyMembersList
    {
      public static readonly ID ID = new ID("{65CF9701-9958-40A0-91E5-5E31AFB872C8}");
    }

    public struct FamilyMember
    {
      public static readonly ID ID = new ID("{636714D5-1E6D-4CDC-9A1A-9DB4E41C199F}");
    }

    public struct InfoTabsList
    {
      public static readonly ID ID = new ID("{C11604CC-E0A8-4E3E-A667-FA6BC3CC7355}");
    }

    public struct InfoTabsItem
    {
      public static readonly ID ID = new ID("{BAA98B57-D925-4057-BD64-42580826722A}");
    }

    public struct HasInfoBox
    {
      public static readonly ID ID = new ID("{A4E88BF2-6719-4DAB-B33C-E9B077C58D5E}");
      public struct Fields
      {
        public static readonly ID Description = new ID("{6BB917EA-140D-401A-A482-65B49B3FEBA0}");
        public static readonly ID CTA = new ID("{DC2A0960-B571-4E51-B935-5B70CBA9DC0F}");
      }
    }

    public struct HasCode
    {
      public static readonly ID ID = new ID("{CA982E76-F0BC-42A7-B949-40664A29B559}");
      public struct Fields
      {       
        public static readonly ID Code = new ID("{A6423A57-8030-4E22-9C4C-5BEA2CEDE9F3}");
      }
    }

    public struct HasDescription
    {
      public static readonly ID ID = new ID("{6E8D8F21-AA3A-4E69-9FCC-394525069374}");
      public struct Fields
      {
        public static readonly ID Description = new ID("{FDCBDA9B-D895-40C7-B9BE-28B6F0881EBB}");
      }
    }

    public struct HasImage
    {
      public static readonly ID ID = new ID("{E484E799-150C-4CBC-834B-CF180242189D}");
      public struct Fields
      {
        public static readonly ID Image = new ID("{ABBB94BA-D620-428B-8187-839C5DF8D354}");
      }
    }

    public struct HasKey
    {
      public static readonly ID ID = new ID("{C896DC06-F65C-4B0D-AA81-1264072BF877}");
      public struct Fields
      {
        public static readonly ID Key = new ID("{914DAC4D-527A-4440-A014-55E7AC76499E}");
      }
    }

    public struct HasTitle
    {
      public static readonly ID ID = new ID("{C96CEB30-5C57-4CE0-84D2-B7DFE25C5E12}");
      public struct Fields
      {
        public static readonly ID Title = new ID("{B3B537A3-31D9-447F-89C4-413FB43C287E}");
      }
    }

    public struct HasValue
    {
      public static readonly ID ID = new ID("{3677BD8D-6144-4D4B-B8E2-8C0E96FE7DA5}");
      public struct Fields
      {
        public static readonly ID Value = new ID("{B8D86014-6E9F-4727-9156-328322DF73FE}");
      }
    }

    public struct HasProductContent
    {
      public static readonly ID ID = new ID("{F0F7662D-7CC6-4613-B4B7-8BEC9F3F6BA9}");
      public struct Fields
      {
        public static readonly ID Amount = new ID("{408DF9E1-54D8-49FA-ABE1-D5B248A58339}");
        public static readonly ID Hospitalization = new ID("{A3E59159-D02D-47B0-BCE6-864F5E4BA62C}");
        public static readonly ID RTE = new ID("{3EBCEC27-05BF-43CF-A278-F853827DC7DA}");       
        public static readonly ID DependentMembersProductKey = new ID("{FBD28DD6-53B1-4362-8EC5-5389128283F2}");
        public static readonly ID AdditonalProductKey = new ID("{F0F82592-9E76-4738-A37E-D511BB7514FB}");
      }
    }

    public struct HasCoverCapital
    {
       public static readonly ID ID = new ID("{84C60B51-39D9-450F-8F9D-7F7E0B248EF7}");

      public struct Fields
      {
        public static readonly ID CoverCapital = new ID("{809E605B-1A30-4ECF-8F2B-159463FD796D}");

      }
    }

    public struct HasCovCode
    {
      public static readonly ID ID = new ID("{71B7D363-17C3-4DC8-99DC-CD8622A622A0}");

      public struct Fields
      {
        public static readonly ID CovCode = new ID("{2133ACF1-8828-490A-B909-0168A152F452}");

      }
    }

    public struct HasCTA
    {
      public static readonly ID ID = new ID("{5E71F233-C446-4B67-982D-A7CC229B4E69}");
      public struct Fields
      {        
        public static readonly ID Link = new ID("{31AB8CDE-F32C-4A92-8A57-294A965B0E14}");
      }
    }

    public struct HasRTE
    {
      public static readonly ID ID = new ID("{EE227249-EDF4-4779-A79F-234338DFF294}");
      public struct Fields
      {
        public static readonly ID Link = new ID("{B207D76C-94EF-449A-B596-A91C0C8571FF}");
      }
    }

  }
}