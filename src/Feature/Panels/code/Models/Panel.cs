using System.Collections.Generic;
using Newtonsoft.Json;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Wedia.Feature.Panels.Models
{
  public class Panel
  {
    [JsonProperty("id")]
    public ID ID { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("summary")]
    public string Summary { get; set; }
    [JsonProperty("items")]
    public IEnumerable<PanelItem> Items { get; set; }
    [JsonProperty("categories")]
    public IEnumerable<PanelCategory> Categories { get; set; }
    [JsonProperty("filters")]
    public Filters Filters { get; set; }
  }
}