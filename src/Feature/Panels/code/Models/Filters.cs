using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Panels.Models
{
  public class Filters
  {
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("applyButton")]
    public string ApplyButton { get; set; }
    [JsonProperty("cancelButton")]
    public string CancelButton { get; set; }
    [JsonProperty("clearButton")]
    public string ClearButton { get; set; }
    [JsonProperty("items")]
    public IEnumerable<PanelRow> Items { get; set; }
  }
}