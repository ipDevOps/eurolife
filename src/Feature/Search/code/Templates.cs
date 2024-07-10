using Sitecore.Data;

namespace Wedia.Feature.Search
{
  public struct Templates
  {
    public struct SearchResults
    {
      public static readonly ID ID = new ID("{A25242D4-7C30-4962-951E-95921976D4C0}");

      public struct Fields
      {
        public static readonly ID SearchBoxTitle = new ID("{5AE7B7D1-EEAA-48FD-885B-7956A463D2C5}");
        public static readonly ID Root = new ID("{5F1EDB58-25D4-4508-9C61-E13553302908}");
        public static readonly ID Facets = new ID("{06104EFF-818D-4A95-8BF6-FDCE039DBD81}");
      }
    }

    public struct SearchContext
    {
      public static readonly ID ID = new ID("{2DBF252E-E4E9-4B48-B8A5-DA740CC4888F}");

      public struct Fields
      {
        public static readonly ID SearchResultsPage = new ID("{98B34509-E828-4A84-9943-4EFE786E401F}");
      }
    }
  }
}