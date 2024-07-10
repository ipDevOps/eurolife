using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedia.Feature.PageContent.Models.ViewModels;
using Wedia.Foundation.DependencyInjection;

namespace Wedia.Feature.PageContent.Repositories
{
  [Service(typeof(IPageContentRepository))]
  public class PageContentRepository : IPageContentRepository
  {
    public InvestmentPlanViewModel GetInvestmentPlanRendering(Item contextItem)
    {
      var investmentPlanViewModel = new InvestmentPlanViewModel 
      {
        InvestmentPlan = contextItem
      };

      var cardsItems = contextItem
                            .Children.Where(x => x.TemplateID == Templates.Card.ID);

      if(cardsItems != null)
      {
        var cardViewModelsList = new List<CardViewModel>();
        foreach (var card in cardsItems)
        {
          var cardViewModel = new CardViewModel 
          {
            Card = card,
            PieCharts = card.Children.Where(x => x.TemplateID == Templates.PieChart.ID)?.ToList(),
            BarCharts = card.Children.Where(x => x.TemplateID == Templates.BarChart.ID)?.ToList()
          };

          cardViewModelsList.Add(cardViewModel);
        }

        investmentPlanViewModel.CardViewModels = cardViewModelsList;
      }

      return investmentPlanViewModel;
    }
  }
}