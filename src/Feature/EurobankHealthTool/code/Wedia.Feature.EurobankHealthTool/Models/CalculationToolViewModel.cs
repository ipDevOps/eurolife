using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.EurobankHealthTool.Models
{
  public class CalculationToolViewModel
  {   
    public Item RenderingItem { get; set; }
    public List<Item> Products { get; set; }
    public string JsonExcelData { get; set; }
  }
}