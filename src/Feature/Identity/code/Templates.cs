using Sitecore.Data;

namespace Wedia.Feature.Identity
{
  public struct Templates
  {
    public struct Identity
    {
      public static readonly ID ID = new ID("{D7A6241C-2C98-4F02-BB03-B4D024C7A278}");

      public struct Fields
      {
        public static readonly ID Logo = new ID("{C29843BA-7353-454E-9842-3DB3B7174668}");
        public static readonly ID LogoTagLine = new ID("{0626D59C-FBEF-41CE-BFA3-226304B9E846}");
        public static readonly ID Copyright = new ID("{C9937D39-6C03-44BE-A0BB-965903C6EF43}");
        public static readonly ID OrganizationName = new ID("{C8175F95-150A-47C9-A485-BF76E6436304}");
        public static readonly ID OrganizationPhone = new ID("{CEA1AAFE-BC37-4321-A135-EDEDCAC59783}");
        public static readonly ID OrganizationEmail = new ID("{4EC67362-43BA-4021-89FA-4AA5A1FFB9E0}");
        public static readonly ID OrganizationFax = new ID("{C43A2010-E0DC-41BF-BCFB-F6433A60845D}");
        public static readonly ID OrganizationAddresses = new ID("{8B9F427A-D6BD-4AAD-9E70-8965E09C4AF2}");
        public static readonly ID ClickToCall = new ID("{A3B0F0F0-CAC4-496A-ACA7-8F80FC52BB6A}");
        public static readonly ID ClickToChat = new ID("{F3394D78-1E2B-4854-BEA1-6180D271A426}");
        public static readonly ID ContactForm = new ID("{34375FC7-4DF0-4C85-9D04-64C79D1FFEF8}");
        public static readonly ID Login = new ID("{48DC1E12-F410-4DA4-B560-AF1809E0262C}");
        public static readonly ID OnlinePayment = new ID("{CD55543C-7ECA-405F-89A1-6BC0A9D10292}");
        public static readonly ID Register = new ID("{2C137E1A-ADE1-4D1A-AF60-0E0F9A386C5B}");
      }
    }

    public struct IdentityFolder
    {
      public static readonly ID ID = new ID("{95A93D2C-CCCF-4537-9023-10A8AA1657C9}");
    }

    public struct IdentityAddress
    {
      public static readonly ID ID = new ID("{A41604D9-DDBF-43A2-8296-EA07AEA6886E}");

      public struct Fields
      {
        public static readonly ID City = new ID("{75DA3499-D2AE-4C77-911E-0CBEBE3C1891}");
        public static readonly ID Street = new ID("{4105155B-C61A-4DB2-8D92-640D956D5700}");
      }
    }
  }
}