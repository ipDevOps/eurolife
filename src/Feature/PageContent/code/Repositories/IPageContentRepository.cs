using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Wedia.Feature.PageContent.Repositories
{
  public interface IPageContentRepository
  {
    Models.ViewModels.InvestmentPlanViewModel GetInvestmentPlanRendering(Item contextItem);
  }
}
