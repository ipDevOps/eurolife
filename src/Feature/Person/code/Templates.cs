using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Person
{
  public struct Templates
  {
    public struct Employee
    {
      public static readonly ID ID = new ID("{CE1D7E61-0867-4D85-8661-EBEA1D8B48EA}");
    }   

    public struct Person
    {
      public static readonly ID ID = new ID("{E876D234-83DB-4B57-BE87-365D9576377A}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{902AD41A-7A0A-43FC-9080-0A858D455597}");
        public const string Title_FieldName = "PersonTitle";
        public static readonly ID Name = new ID("{66DAF897-2490-46A2-9CEC-3523434273BB}");
        public const string Name_FieldName = "PersonName";
      }
    }

    public struct HasPersonImage
    {
      public static readonly ID ID = new ID("{CCBE09A4-4E2B-43F2-BE19-5EC382143924}");

      public struct Fields
      {
        public static readonly ID Image = new ID("{A212C93A-7C83-4FED-BC5A-5B035BAEFF50}");
        public const string Image_FieldName = "PersonImage";
      }
    }

    public struct HasPersonContent
    {
      public static readonly ID ID = new ID("{050CC5CC-3AB1-4A3D-87D2-A25F798BDA55}");

      public struct Fields
      {
        public static readonly ID Body = new ID("{3A28C78D-3C5E-4D7B-837B-9F511FB70D80}");
        public const string Body_FieldName = "PersonBody";
      }
    }

    public struct HasPersonQuote
    {
      public static readonly ID ID = new ID("{72624AAD-C2B9-4568-A921-5DF5386FB7BA}");

      public struct Fields
      {
        public static readonly ID Quote = new ID("{47E95858-EFCC-4862-8A26-3905105ECE5B}");
      }
    }

    public struct HasPersonPosition
    {
      public static readonly ID ID = new ID("{3BA924FD-68DE-4A03-9F1A-812218AD6823}");
    
      public struct Fields
      {
        public static readonly ID Position = new ID("{E57A5FEE-E68D-4D37-AC1F-EDC51E551121}");
        public const string Position_FieldName = "PersonPosition";
      }
    }

    public struct PersonGroup
    {
      public static readonly ID ID = new ID("{5816C3B2-E272-4933-8BC4-D025F3C288B2}");

      public struct Fields
      {
        public static readonly ID Persons = new ID("{C5270F95-33AA-4DA7-B3B7-0EEA5DD1B4B1}");          
      }
    }

    public struct HasPersonGroupName
    {
      public static readonly ID ID = new ID("{4DF778D4-794C-49F4-B7CC-256AD573280F}");

      public struct Fields
      {
        public static readonly ID Name = new ID("{DAC83A8F-9622-442F-B594-964D5F01B1E3}");
        public const string PersonGroupName_FieldName = "PersonGroupName";
      }
    }

    public struct HasPersonContact
    {
      public static readonly ID ID = new ID("{6A75B781-ECC7-43F7-B50C-690A32EF9B24}");

      public struct Fields
      {
        public static readonly ID Telephone = new ID("{6C65BD46-BBCD-4AF7-9419-04A1E6F8315C}");
        public static readonly ID Mobile = new ID("{674E1EF9-C125-4BD4-98CC-ED2936E09845}");
        public static readonly ID Fax = new ID("{65FC9B13-4667-4C78-B222-428FAF91B1A7}");
        public static readonly ID Email = new ID("{75ACC29F-3A37-4042-8E27-D2E8A92CF7EB}");
        public static readonly ID Address = new ID("{DBDD034D-8648-4144-AB97-71FF82FE9C58}");
      }
    }
  }
}