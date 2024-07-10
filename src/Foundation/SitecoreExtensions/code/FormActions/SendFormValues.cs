using System;
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
using System.Net.Http;

namespace Wedia.Foundation.SitecoreExtensions.FormActions
{
  public class SendFormValues : SubmitActionBase<string>
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="LogSubmit"/> class.
    /// </summary>
    /// <param name="submitActionData">The submit action data.</param>
    public SendFormValues(ISubmitActionData submitActionData) : base(submitActionData)
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

      if (!formSubmitContext.HasErrors)
      {          
        try
        {   
          //we need to add to values to a string dictionary 
          Dictionary<string, string> fieldsDictionary = new Dictionary<string, string>();

          
          string postUrl = "";

          foreach (var field in formSubmitContext.Fields)
          {

            string fieldName = field.Name;
            string fieldValue = FieldsHelper.GetFieldValue(field);

            //checking if post Url field is present and filled. if not we will grab the post url from sitecore coniguration. no need to send this
            if (fieldName == "postUrl")
            {
              postUrl = FieldsHelper.GetFieldValue(field);
              continue;
            }

            fieldsDictionary.Add(fieldName, fieldValue);
          }

          string apiPostUrl = "";
          if (!string.IsNullOrEmpty(postUrl))
            apiPostUrl = postUrl;
          else
            apiPostUrl = Sitecore.Configuration.Settings.GetSetting("FormActions.SalesforceApiUrl");

          var client = new HttpClient();
          FormUrlEncodedContent content = new FormUrlEncodedContent(fieldsDictionary);
          var response = client.PostAsync(apiPostUrl, content).Result;

         if(!response.IsSuccessStatusCode)
          {
            Log.Error($"SendValues form with id: {formSubmitContext.FormId},response error: {response.StatusCode}", this);
          }              
        }
        catch (Exception ex)
        {
          Log.Error("SendValues form with id " + formSubmitContext.FormId + " error exception", ex, this);
        }       

      }
      else
      {
        Logger.Warn(Invariant($"Form {formSubmitContext.FormId} submitted with errors: {string.Join(", ", formSubmitContext.Errors.Select(t => t.ErrorMessage))}."), this);
      }

      return true;
    }
  }
}