using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wedia.Feature.Identity.Models;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.Dictionary.Repositories;
using Sitecore.Configuration;
using createsend_dotnet;
using System.Net;

namespace Wedia.Feature.Identity.Services
{
  [Service(typeof(INewsletterService))]
  public class NewsletterService : INewsletterService
  {
    private readonly string ApiKey = Settings.GetSetting("CreateSendApi");
    private readonly string ListID = Settings.GetSetting("CreateSendListId");

    public NewsletterFormViewModel GetFormViewModel()
    {
      return new NewsletterFormViewModel
      {
        FormUrl = "api/feature/identity/register-newsletter",
        ButtonLabel = DictionaryPhraseRepository.Current.Get("/Identity/Newsletter/Button Label"),
        TexboxLabel = DictionaryPhraseRepository.Current.Get("/Identity/Newsletter/Textbox Label"),
        CheckboxLabel = DictionaryPhraseRepository.Current.Get("Identity/Newsletter/Consent Label"),
        EmailError = DictionaryPhraseRepository.Current.Get("Identity/Newsletter/Invalid Email"),
        SuccessSubscribed = DictionaryPhraseRepository.Current.Get("Identity/Newsletter/Successful Subscribed")
      };
    }

    public NewsletterFormResponse Register(NewsletterDto newsletterDto)
    {
      AuthenticationDetails auth = new ApiKeyAuthenticationDetails(ApiKey);
      var url = $"https://api.createsend.com/api/v3.2/subscribers/{ListID}";

      var subscriber = new Subscriber(auth, ListID);

      var response = new NewsletterFormResponse();

      response.Message = subscriber.Add(newsletterDto.Email, newsletterDto.Email, new List<SubscriberCustomField>(), true, ConsentToTrack.Yes);
      response.StatusCode = (int)HttpStatusCode.Created;

    try
      {
        response.Message = subscriber.Add(newsletterDto.Email, newsletterDto.Email, new List<SubscriberCustomField>(), true, ConsentToTrack.Yes);
        response.StatusCode = (int)HttpStatusCode.Created;
      }
      catch (Exception e)
      {
        response.Message = DictionaryPhraseRepository.Current.Get("Identity/Newsletter/Error Response");
        response.StatusCode = (int)HttpStatusCode.BadRequest;
      }

      return response;
    }
  }
}