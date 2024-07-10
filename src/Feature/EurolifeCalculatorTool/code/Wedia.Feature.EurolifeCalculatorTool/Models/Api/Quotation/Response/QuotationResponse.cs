using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Response
{
  public class QuotationResponse
  {
    public Common.Header Header { get; set; }
    public Quotation Quotation { get; set; }
  }
}