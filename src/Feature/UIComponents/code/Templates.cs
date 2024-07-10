using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.UIComponents
{
  public struct Templates
  {
    public struct HasUIComponentsHeading
    {
      public static readonly ID ID = new ID("{F29FDE6B-5263-48AB-84CA-1CA84B788D44}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{5160EADE-B54A-4C64-B1DD-6F4EB7339F76}");
        public static readonly ID Summary = new ID("{6D532B85-DADF-4513-8E22-ADEC9A80BDDA}");
      }
    }

    public struct IFrame
    {
      public static readonly ID ID = new ID("{683AC653-2DE3-4147-9EA4-AF85DC61E740}");

      public struct Fields
      {
        public static readonly ID IFrame = new ID("{D9CC1068-49D0-4E46-8859-95D8D0E95B76}");
      }
    }
  }
}