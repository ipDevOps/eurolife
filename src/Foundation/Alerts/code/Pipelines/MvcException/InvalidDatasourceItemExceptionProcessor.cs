using System.Web.Mvc;
using Sitecore.Diagnostics;
using Wedia.Foundation.Alerts.Exceptions;
using Wedia.Foundation.Alerts.Models;
using Sitecore.Mvc.Pipelines.MvcEvents.Exception;
using Sitecore;

namespace Wedia.Foundation.Alerts.Pipelines.MvcException
{
  public class InvalidDatasourceItemExceptionProcessor
  {
    public void Process(ExceptionArgs exceptionArgs)
    {
      if (exceptionArgs.ExceptionContext.ExceptionHandled)
      {
        return;
      }

      this.HandleException(exceptionArgs.ExceptionContext);
    }

    protected virtual void HandleException(ExceptionContext exceptionContext)
    {
      var dataSourceException = exceptionContext.Exception as InvalidDataSourceItemException;
      if (dataSourceException == null)
        return;
      Log.Error(dataSourceException.Message, dataSourceException, this);

      if (Context.PageMode.IsNormal)
      {
        exceptionContext.Result = new EmptyResult();
      }
      else
      {
        var viewData = new ViewDataDictionary
                       {
                         Model = InfoMessage.Error(AlertTexts.InvalidDataSource)
                       };
        exceptionContext.Result = new ViewResult
                                  {
                                    ViewName = Constants.InfoMessageView,
                                    ViewData = viewData
                                  };
      }

      exceptionContext.ExceptionHandled = true;
    }
  }
}