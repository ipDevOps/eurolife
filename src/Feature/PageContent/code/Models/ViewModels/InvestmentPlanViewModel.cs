using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Wedia.Feature.PageContent.Models.ViewModels
{
  public class InvestmentPlanViewModel
  {
    public Item InvestmentPlan { get; set; }
    public IList<CardViewModel> CardViewModels { get; set; }
  }
}