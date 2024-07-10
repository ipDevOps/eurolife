using Sitecore.Data;

namespace Wedia.Feature.Metadata
{
    public struct Templates
    {
        public struct PageMetadata
        {
            public static ID ID = new ID("{E5F4F03B-3264-4FB8-ACB9-1A24E024C9BA}");

            public struct Fields
            {
                public static readonly ID BrowserTitle = new ID("{2E232095-D195-4ACC-BBAE-0D26D4D5B27C}");
                public static readonly ID Description = new ID("{6E129621-73BC-403C-B4DB-BF403C685630}");
                public static readonly ID Keywords = new ID("{42567E83-DB1F-4651-8385-842ABD59ADED}");
                public static readonly ID CanIndex = new ID("{7C4AAADD-2CA5-488A-8FC1-5B5F01DF6A9B}");
                public static readonly ID CanFollow = new ID("{0CE01372-9068-4424-8EC1-81005FBCFE3B}");
                public static readonly ID CustomMetadata = new ID("{3BFE74BC-D673-4EBC-B7F1-46FF520FA8F3}");
            }
        }

        public struct SiteMetadata
        {
            public static readonly ID ID = new ID("{320FE7A9-7186-4AAC-9E01-8850E18506CC}");

            public struct Fields
            {
                public static readonly ID SiteBrowserTitle = new ID("{B4926567-FD0B-4BED-B86B-1D3B25C90D8B}");
            }
        }

        public struct Keyword
        {
            public static ID ID = new ID("{3A05869D-2DA8-4940-9066-EC2C95E8BF01}");

            public struct Fields
            {
                public static readonly ID Keyword = new ID("{CD69AA4A-E0E0-4439-88CC-092012C670BC}");
            }
        }
    }
}