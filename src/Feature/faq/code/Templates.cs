using Sitecore.Data;

namespace Wedia.Feature.FAQ
{
    public struct Templates
    {
        public struct Faq
        {
            public static readonly ID ID = new ID("{063D0D49-9AAD-4EBA-A01E-FC3BAD65FD9B}");

            public struct Fields
            {
                public static readonly ID Question = new ID("{218376E4-DE85-44B1-A731-93A0A1F0EF06}");
                public static readonly ID Answer = new ID("{C4A11B04-61F4-45AC-AC39-7ECA98AAC0D3}");
            }
        }

        public struct FaqGroup
        {
            public static readonly ID ID = new ID("{D31E08E4-E1C4-4F46-A6AC-FA160D92A860}");

            public struct Fields
            {
                public static readonly ID GroupMember = new ID("{4CEECCB7-2E78-4869-BFBE-26EDB115A6A8}");
            }
        }

    }
}