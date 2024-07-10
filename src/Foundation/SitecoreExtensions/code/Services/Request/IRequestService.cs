using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Wedia.Foundation.SitecoreExtensions.Services.Request
{
  public interface IRequestService
  {
    Task<TResult> GetAsync<TResult>(string uri, string token = "");

    Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", Dictionary<string, string> headers = null);

    Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "", Dictionary<string, string> headers = null);
  }
}