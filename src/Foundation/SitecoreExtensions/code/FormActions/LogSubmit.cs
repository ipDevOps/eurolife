using System.Linq;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using static System.FormattableString;
using Sitecore.Mvc.Extensions;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using System;
using System.Globalization;

namespace Wedia.Foundation.SitecoreExtensions.FormActions
{
  public class LogSubmit : SubmitActionBase<string>
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="LogSubmit"/> class.
    /// </summary>
    /// <param name="submitActionData">The submit action data.</param>
    public LogSubmit(ISubmitActionData submitActionData) : base(submitActionData)
    {
    }

    /// <summary>
    /// Tries to convert the specified <paramref name="value" /> to an instance of the specified target type.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="target">The target object.</param>
    /// <returns>
    /// true if <paramref name="value" /> was converted successfully; otherwise, false.
    /// </returns>
    protected override bool TryParse(string value, out string target)
    {
      target = string.Empty;
      return true;
    }

    /// <summary>
    /// Executes the action with the specified <paramref name="data" />.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="formSubmitContext">The form submit context.</param>
    /// <returns>
    ///   <c>true</c> if the action is executed correctly; otherwise <c>false</c>
    /// </returns>
    protected override bool Execute(string data, FormSubmitContext formSubmitContext)
    {
      Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));


      Dictionary<string, string> fieldsDictionary = new Dictionary<string, string>();

      foreach (var field in formSubmitContext.Fields)
      {
       
        string fieldName = field.Name;
        string fieldValue = FieldsHelper.GetFieldValue(field);

        fieldsDictionary.Add(fieldName, fieldValue);
      }


        if (!formSubmitContext.HasErrors)
      {
        Logger.Info(Invariant($"Form {formSubmitContext.FormId} submitted successfully."), this);

        //we need to add to values to a string dictionary 

        
      }
      else
      {
        Logger.Warn(Invariant($"Form {formSubmitContext.FormId} submitted with errors: {string.Join(", ", formSubmitContext.Errors.Select(t => t.ErrorMessage))}."), this);
      }

      return true;
    }

    
  }
}