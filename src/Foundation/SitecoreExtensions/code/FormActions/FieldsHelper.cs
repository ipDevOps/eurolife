using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Wedia.Foundation.SitecoreExtensions.FormActions
{
  public static class FieldsHelper
  {
    public static string GetFieldValue(IViewModel field)
    {
      string val = string.Empty;

      if (field is InputViewModel<List<string>> listStringInputViewModel)
      {
        if(listStringInputViewModel.Value.Any())
          val = listStringInputViewModel.Value.Aggregate("", (current, value) => current + ", " + value).Remove(0, 2);
      }
      else if (field is InputViewModel<bool> booleanInputViewModel)
      {
        val = booleanInputViewModel.Value ? "true" : "false";
      }
      else if (field is InputViewModel<DateTime?> dateTimeInputViewModel)
      {
        val = dateTimeInputViewModel.Value.HasValue ? dateTimeInputViewModel.Value.Value.ToString(CultureInfo.CurrentCulture) : string.Empty;
      }
      else if (field is InputViewModel<double?> doubleInputViewModel)
      {
        val = doubleInputViewModel.Value.HasValue
                    ? doubleInputViewModel.Value.Value.ToString(CultureInfo.InvariantCulture)
                    : string.Empty;
      }
      else if (field is InputViewModel<string> stringInputViewModel)
      {
        val = stringInputViewModel.Value ?? string.Empty;
      }

      return val;
    }
  }
}