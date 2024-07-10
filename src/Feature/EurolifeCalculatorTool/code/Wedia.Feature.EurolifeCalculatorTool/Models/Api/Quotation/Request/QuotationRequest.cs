using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool.Models.Api.Quotation.Request
{
  public class QuotationRequest
  {
    public Common.Header Header { get; set; }
    public Quotation Quotation { get; set; }
  }
}