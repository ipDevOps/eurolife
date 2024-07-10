using Newtonsoft.Json;
using Sitecore.Data;
using System.Collections.Generic;

namespace Wedia.Feature.Panels.Models
{
  public class PanelItem
  {
    [JsonProperty("id")]
    public ID ID { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("rows")]
    public IEnumerable<PanelRowItem> Rows { get; set; }
  }
}