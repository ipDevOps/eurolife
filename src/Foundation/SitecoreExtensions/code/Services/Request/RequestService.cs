using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.SitecoreExtensions.Exceptions;

namespace Wedia.Foundation.SitecoreExtensions.Services.Request
{
  [Service(typeof(IRequestService))]
  public class RequestService : IRequestService
  {
    readonly JsonSerializerSettings serializerSettings;

    public RequestService()
    {
      serializerSettings = new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };

      serializerSettings.Converters.Add(new StringEnumConverter());
    }

    public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
    {
      var httpClient = CreateHttpClient(token);      
      var response = await httpClient.GetAsync(uri);

      await HandleResponse(response);

      var serialized = await response.Content.ReadAsStringAsync();

      var result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, serializerSettings));

      return result;
    }

    public Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", Dictionary<string, string> headers = null) => PostAsync<TResult, TResult>(uri, data, token, headers);

    public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string token = "", Dictionary<string, string> headers = null)
    {
      var httpClient = CreateHttpClient(token, headers);
      var serialized = await Task.Run(() => JsonConvert.SerializeObject(data, serializerSettings));
      var response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

      await HandleResponse(response);

      var responseData = await response.Content.ReadAsStringAsync();

      return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, serializerSettings));
    }

    HttpClient CreateHttpClient(string token = "", Dictionary<string, string> headers = null)
    {
      //ntlm auth
      HttpClientHandler handler = new HttpClientHandler()
      {
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(Constants.LifeWebApi.User,
                                            Constants.LifeWebApi.Password, Constants.LifeWebApi.Domain),
        PreAuthenticate = true
      };
                  

      var httpClient = new HttpClient(handler);     

      httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      if(headers != null)
      {
        foreach (var header in headers)
          httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
      }   

      if (!string.IsNullOrEmpty(token))
      {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }     

      return httpClient;
    }

    async Task HandleResponse(HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode)
      {
        var content = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
        {
          throw new AuthorizationException();
        }       

        throw new HttpRequestException(content);
      }
    }
  }
}