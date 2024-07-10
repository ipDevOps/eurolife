using Newtonsoft.Json;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Panels.Models
{
  public class PanelsGroup
  {
    [JsonProperty("id")]
    public ID ID { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("summary")]
    public string Summary { get; set; }
    [JsonProperty("panels")]
    public IEnumerable<Panel> Panels { get; set; }
  }
}