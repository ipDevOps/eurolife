using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Wedia.Feature.Glossary
{
  public struct Templates
  {
    public struct GlossaryGroup
    {
      public static readonly ID ID = new ID("{75AA1C60-7A7D-4EA4-BB69-362551088370}");
    }

    public struct Glossary
    {
      public static readonly ID ID = new ID("{6EB504BC-02AE-4A5F-BEDD-07FB43970029}");

      public struct Fields
      {
        public static readonly ID Gloss = new ID("{4D753C7B-D0A0-42D1-9843-E2D23987FE81}");
      }
    }

    public struct GlossaryChoiceGroup
    {
      public static readonly ID ID = new ID("{2871F608-0053-4E92-BFBA-42D75D8EB99E}");

      public struct Fields
      {
        public static readonly ID Items = new ID("{58AE458F-3AD1-41D4-962D-D5B11002576D}");
      }
    }

    public struct HasGlossaryTitle
    {
      public static readonly ID ID = new ID("{D9351E70-89C0-4FB5-A6A5-2503E0FC20AE}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{1F40AE97-E31D-4388-B2EC-E23FFE4304EB}");
      }
    }
  }
}