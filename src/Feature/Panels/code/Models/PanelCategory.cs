using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Wedia.Feature.Panels.Models
{
  public class PanelCategory
  {
    [JsonProperty("id")]
    public ID ID { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("isMain")]
    public bool IsMain { get; set; }
    [JsonProperty("rows")]
    public IEnumerable<PanelRow> Rows { get; set; }
  }
}