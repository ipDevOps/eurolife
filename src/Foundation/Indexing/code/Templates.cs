using Sitecore.Data;

namespace Wedia.Foundation.Indexing
{
  internal struct Templates
  {
    internal struct IndexedItem
    {
      public static ID ID = new ID("{3F38EA70-1F98-4A1C-BCB7-01E63046EEF6}");

      public struct Fields
      {
        public static readonly ID IncludeInSearchResults = new ID("{B026B2CE-8037-435E-8A0B-327B2D17E9D0}");
        public const string IncludeInSearchResults_FieldName = "IncludeInSearchResults";
      }
    }
  }
}