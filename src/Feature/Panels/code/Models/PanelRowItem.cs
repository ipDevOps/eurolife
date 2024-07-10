using Newtonsoft.Json;
using Sitecore.Data;

namespace Wedia.Feature.Panels.Models
{
  public class PanelRowItem
  {
    [JsonProperty("id")]
    public ID ID { get; set; }
    [JsonProperty("parentId")]
    public ID ParentID { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }
    [JsonProperty("isChecked")]
    public bool IsChecked { get; set; }
    [JsonProperty("tooltip")]
    public string Tooltip { get; set; }
  }
}