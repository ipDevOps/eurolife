namespace Wedia.Foundation.Indexing.Models
{
  public interface IQueryFacet
  {
    string Title { get; set; }
    string FieldName { get; set; }
    string ViewName { get; set; }
  }
}