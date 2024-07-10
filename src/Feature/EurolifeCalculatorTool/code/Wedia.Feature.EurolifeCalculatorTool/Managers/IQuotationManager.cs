using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedia.Feature.EurolifeCalculatorTool.Managers
{
  public interface IQuotationManager
  {
    Task<Models.Api.Quotation.Response.QuotationResponse> GetQuotation(Models.UserSelection userSelection, 
      Models.Product product, 
      List<Models.Bundle> bundles,
      List<Models.GroupOfBundle> groupOfBundles);
  }
}
