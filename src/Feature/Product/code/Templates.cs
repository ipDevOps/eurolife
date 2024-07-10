using Sitecore.Data;

namespace Wedia.Feature.Product
{
    public struct Templates
    {
        public struct ProgramCoverages
        {
            public static readonly ID ID = new ID("{6DD3A03C-17FB-4B41-B192-7BCE6142E474}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{14CAE3CD-F0B5-4ED4-99D4-D46CF790D2C6}");
                public static readonly ID ItCovers = new ID("{EBC5143C-F5A2-40FC-8B58-F1C0F60671EE}");
                public static readonly ID ItNotCovers = new ID("{208A8C4C-9CA3-4D74-841E-E62CB92A9879}");
            }
        }

        public struct HasProductToolkit
        {
            public static readonly ID ID = new ID("{7E40D90A-F52C-4F0D-8F4B-C1021AA76110}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{83B0E4E3-AB03-43E3-8083-3E7FD2946AD4}");
                public static readonly ID Subhead = new ID("{4791FADD-9BB5-4EFD-B542-4D2F8BB634E4}");
                public static readonly ID HowItWorks = new ID("{328F77A3-08CC-4496-B8C9-184E3C194993}");
                public static readonly ID ContactTransfer = new ID("{6271F1C8-D91E-47ED-8F4A-99FE75D004A5}");
            }
        }
    }
}