using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Sitecore;
using Sitecore.Data;
using Wedia.Foundation.SitecoreExtensions.Utilities;
using Sitecore.Diagnostics;
using Wedia.Feature.EurobankHealthTool.Services;
using Wedia.Feature.EurobankHealthTool.Models;
using Newtonsoft.Json;

namespace Wedia.Feature.EurobankHealthTool.Controllers
{
  public class EurobankHealthToolController : Controller
  {
    private readonly IExcelService _excelService;

    public EurobankHealthToolController(IExcelService excelService)
    {
      this._excelService = excelService;
    }

    /// <summary>
    /// CalculationTool page
    /// Read Data from Excel
    /// </summary>
    /// <returns>
    /// CalculationToolViewModel
    /// </returns>
    public ActionResult CalculationTool()
    {
      var item = RenderingContext.Current.Rendering.Item;
      var vm = new CalculationToolViewModel();

      try
      {
        var productsList = item.Children.Where(x => x.TemplateID == Templates.ProductsList.ID).FirstOrDefault();
        vm.Products = productsList.Children.Where(x => x.TemplateID == Templates.Product.ID)?.ToList();
        vm.RenderingItem = item;
        var data = _excelService.GetProgramsData(item);     
        vm.JsonExcelData = JsonConvert.SerializeObject(data);        
      }
      catch (Exception ex)
      {
        Log.Error($"CalculationTool error", ex, this);
      }

      return View("CalculationTool/CalculationToolPage", vm);      
    }

  }
}