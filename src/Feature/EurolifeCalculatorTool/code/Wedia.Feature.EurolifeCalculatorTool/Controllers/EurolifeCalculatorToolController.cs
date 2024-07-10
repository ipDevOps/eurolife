using Sitecore;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wedia.Feature.EurolifeCalculatorTool.Models;
using Wedia.Feature.EurolifeCalculatorTool.Repositories;
using Wedia.Foundation.SitecoreExtensions.Services.Request;
using Wedia.Foundation.SitecoreExtensions.Utilities;

namespace Wedia.Feature.EurolifeCalculatorTool.Controllers
{
  public class EurolifeCalculatorToolController : Controller
  {
    protected readonly Dictionary<string, string> mappings;
    private readonly IEurolifeCalulatorToolRepository _eurolifeCalulatorToolRepository;
    

    public EurolifeCalculatorToolController(IEurolifeCalulatorToolRepository eurolifeCalulatorToolRepository)
    {
      this._eurolifeCalulatorToolRepository = eurolifeCalulatorToolRepository;     
      mappings = new Dictionary<string, string>();
      StepsViewMappings();
    }

    public ActionResult CalculatorToolPage()
    {
      try
      {
        var item = RenderingContext.Current.Rendering.Item;
        var availableTargetGroups = _eurolifeCalulatorToolRepository.GetAvailableTargetGroups(item);
        var viewModel = new CalculatorToolPageViewModel
        {
          RenderingItem = item,
          AvailableTargetGroups = availableTargetGroups
        };
        return View("CalculatorToolPage", viewModel);
      }
      catch (Exception ex)
      {
        Log.Error("CalculatorToolPage exception", ex, this);
        throw ex;
      }
    }

    [HttpPost]
    public ActionResult LoadNextStep(UserSelection userSelection)
    {
      try
      {
        var item = Context.Database.GetItem(new ID(userSelection.ItemId));
        var stepView = mappings[userSelection.Step];
        var availableTargetGroups = _eurolifeCalulatorToolRepository.GetAvailableTargetGroups(item);
        var availableFamilyMembers = _eurolifeCalulatorToolRepository.GetAvailableFamilyMembers(item, userSelection.TargetGroup.Key);
        var availableAmounts= _eurolifeCalulatorToolRepository.GetAvailableAmounts(item);
        var availableHospitalizations = _eurolifeCalulatorToolRepository.GetAvailableHospitalizations(item);

        var viewModel = new CalculatorToolPageViewModel
        {
          RenderingItem = item,
          AvailableTargetGroups = availableTargetGroups,
          AvailableFamilyMembers = availableFamilyMembers,
          AvailableAmounts = availableAmounts,
          AvailableHospitalizations = availableHospitalizations,
          UserSelection = userSelection
        };

        var partial = Utilities.RenderRazorViewToString(ControllerContext, 
          stepView,
          viewModel);
        return Json(partial, JsonRequestBehavior.AllowGet);
      }
      catch (Exception ex)
      {
        Log.Error("LoadNextStep exception", ex, this);
        throw ex;
      }
    }

    public async Task<ActionResult> GetOffer(UserSelection userSelection)
    {
      try
      {
        var item = Context.Database.GetItem(new ID(userSelection.ItemId));
        var stepView = mappings[userSelection.Step];

        OfferViewModel viewModel = await _eurolifeCalulatorToolRepository.GetProductAndBundles(item, userSelection);        

        var partial = Utilities.RenderRazorViewToString(ControllerContext,
          stepView,
          viewModel);

        return Json(partial, JsonRequestBehavior.AllowGet);
      }
      catch (Exception ex)
      {
        Log.Error("GetProducts exception", ex, this);
        throw ex;
      }
    }

    void StepsViewMappings()
    {
      mappings.Add("step-1", "~/Views/EurolifeCalculatorTool/Steps/Step1.cshtml");
      mappings.Add("step-2", "~/Views/EurolifeCalculatorTool/Steps/Step2.cshtml");
      mappings.Add("step-3", "~/Views/EurolifeCalculatorTool/Steps/Step3.cshtml");     
      mappings.Add("step-4", "~/Views/EurolifeCalculatorTool/Steps/Step4.cshtml");     
    }

  }
}