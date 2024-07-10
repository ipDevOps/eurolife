using Newtonsoft.Json;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Panels.Models
{
  public class PanelRow
  {
    [JsonProperty("id")]
    public ID ID { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("panelrowtooltip")]
    public string PanelRowTooltip { get; set; }

    [JsonProperty("isCheckbox")]
    public string IsCheckbox { get; set; }
    [JsonProperty("props")]
    public IEnumerable<PanelRowItem> Props { get; set; }
  }
}