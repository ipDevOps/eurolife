using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Wedia.Foundation.DependencyInjection;
using Wedia.Foundation.SitecoreExtensions.Services.Request;

namespace Wedia.Feature.EurolifeCalculatorTool.Managers
{
  [Service(typeof(IQuotationManager))]
  public class QuotationManager : IQuotationManager
  {
    private readonly IRequestService _requestService;
    private readonly static string GetQuotationPathName = "QuotationApi/GetQuotation";
    public QuotationManager(IRequestService requestService)
    {
      this._requestService = requestService;
    }

    public async Task<Models.Api.Quotation.Response.QuotationResponse> GetQuotation(Models.UserSelection userSelection, Models.Product product, List<Models.Bundle> bundles, List<Models.GroupOfBundle> groupOfBundles )
    {
      var quotationRequest = new Models.Api.Quotation.Request.QuotationRequest
      {
        Header = GetHeader(),
        Quotation = new Models.Api.Quotation.Request.Quotation
        {
          BasicCover = GetBasicCover(product),
          Covers = GetCovers(userSelection.TargetGroup, product, bundles),
          BundleCovers = userSelection.TargetGroup.Key == Constants.Family_Target_Child? null : GetBundlesCovers(groupOfBundles), 
          Insured = GetInsured(userSelection.FamilyMembers),
          Customer = GetCustomer(userSelection.TargetGroup, userSelection.FamilyMembers),
          InsuredSameWithCustomer = userSelection.TargetGroup.Key == Constants.Family_Target_Child ? false : true,
          Dependents = GetDependents(userSelection.FamilyMembers, product, bundles),
          FlowId = "0203-01-12e9e77f-8756-4a45-a53c-852538afe25d",
          Channel = 1
        }
      };

      var uri = $"{Constants.LifeWebApiURL}{GetQuotationPathName}";

      var response = await _requestService.PostAsync<Models.Api.Quotation.Request.QuotationRequest, Models.Api.Quotation.Response.QuotationResponse>(uri, quotationRequest);

      //var req = Newtonsoft.Json.JsonConvert.SerializeObject(quotationRequest);
      //var res = Newtonsoft.Json.JsonConvert.SerializeObject(response);

      return response;
    }

    private Models.Api.Common.Header GetHeader()
    {
      return new Models.Api.Common.Header
      {
        ServicesVersion = "1",
        CultureName = "GR"
      };
    }

    private Models.Api.Quotation.Request.BasicCover GetBasicCover(Models.Product product)
    {
      var basicCover = new Models.Api.Quotation.Request.BasicCover();

      if(!string.IsNullOrEmpty(product.AdditonalProductKey))
      {
        basicCover.CovCode = product.AdditonalProductKey;
        basicCover.CoverCapital = "3000";
      }

      return basicCover;
    }

    private List<Models.Api.Quotation.Request.Cover> GetCovers(Models.TargetGroup targetGroup, Models.Product product, List<Models.Bundle> bundles)
    {
      var covers = new List<Models.Api.Quotation.Request.Cover>();

      if(!string.IsNullOrEmpty(product.Key))
      {
        covers.Add(new Models.Api.Quotation.Request.Cover 
        {
          CovCode = product.Key,
          CoverCapital = "700000",
          IsSelected = true,
          IsDepend = true
        });
      }

      if(bundles!= null && bundles.Any() && targetGroup.Key != Constants.Family_Target_Child)
      {
        foreach(var bundle in bundles)
        {
          covers.Add(new Models.Api.Quotation.Request.Cover
          {
            CovCode = bundle.Key,
            CoverCapital = bundle.CoverCapital,
            IsSelected = true,
            IsDepend = true
          });
        }
      }

      return covers;
    }

    private List<Models.Api.Quotation.Request.BundleCover> GetBundlesCovers(List<Models.GroupOfBundle> groupOfBundles)
    {
      var bundleCovers = new List<Models.Api.Quotation.Request.BundleCover>();

      if(groupOfBundles != null && groupOfBundles.Any())
      {
        foreach (var group in groupOfBundles)
        {
          var bundleCover = new Models.Api.Quotation.Request.BundleCover
          {
            Code = long.Parse(group.Key),
            Descr = group.Title,
            IsSelected = true,
            Covers = new List<Models.Api.Quotation.Request.Cover>()
          };

          if (group.Bundles != null && groupOfBundles.Any())
          {
            foreach (var bundle in group.Bundles)
            {
              bundleCover.Covers.Add(new Models.Api.Quotation.Request.Cover 
              {
                CoverDescription = bundle.Title,
                CovCode = bundle.Key,
                CoverCapital = bundle.CoverCapital,
                CoverPremium = 0,
                CoverPremium2 = 0,
                CoverPremium4 = 0,
                CoverPremium12 = 0,
                IsSelected = false,
                IsDepend = false,
                IsFixedBsa = false,
                CovType = 0,
                ProductCode = 0,
                NotInsurable = false,
                SpecialTerm = false,
                LoadPerCentOnPremium = 0,
                LoadPerThousandOnSumInsured = 0,
                CategoryCode = 0
              });
            }
          }

          bundleCovers.Add(bundleCover);
        }
      }

      return bundleCovers;
    }

    private Models.Api.Quotation.Request.Customer GetInsured(IEnumerable<Models.FamilyMember> familyMembers)
    {
      var mainInsured = familyMembers.Count() > 1 ? familyMembers.Where(x => x.IsPrimaryInsured).FirstOrDefault() : familyMembers.FirstOrDefault();

      return new Models.Api.Quotation.Request.Customer
      {
        BirthDate = $"{mainInsured.BirthDate}-01-01",
        Profession = 1000,
        ProfessionCategory = 1,
        Sex = 0
      };
    }

    private Models.Api.Quotation.Request.Customer GetCustomer(Models.TargetGroup targetGroup, IEnumerable<Models.FamilyMember> familyMembers)
    {
      var mainInsured = familyMembers.Count() > 1 ? familyMembers.Where(x => x.IsPrimaryInsured).FirstOrDefault() : familyMembers.FirstOrDefault();
      string birthDate = string.Empty;

      if (targetGroup.Key == Constants.Family_Target_Child)      
        birthDate = $"{DateTime.Now.AddYears(-30).Year}-01-01";
     
      else
        birthDate = $"{mainInsured.BirthDate}-01-01";

      return new Models.Api.Quotation.Request.Customer
      {
        BirthDate = birthDate,
        Profession = 1000,
        ProfessionCategory = 1       
      };
    }

    //we do not send bundles for dependents
    private List<Models.Api.Quotation.Request.Customer> GetDependents(IEnumerable<Models.FamilyMember> familyMembers, Models.Product product, List<Models.Bundle> bundles)
    {
      var dependents = new List<Models.Api.Quotation.Request.Customer>();

      if(familyMembers.Count() > 1)
      {
        foreach(var familyMember in familyMembers.Where(x => !x.IsPrimaryInsured).Select((value, index) => new { value, index}))
        {
          dependents.Add(new Models.Api.Quotation.Request.Customer 
          {
            BirthDate = $"{familyMember.value.BirthDate}-01-01",
            Profession = 1000,
            ProfessionCategory = 1,
            Sex = 0,
            DependCovers = new List<Models.Api.Quotation.Request.Cover>
            {
              new Models.Api.Quotation.Request.Cover
              {
                CovCode = product.DependentMembersProductKey,
                IsSelected = true,
                IsDepend = true
              }
            },
            MemberRelationship = 0,
            Id = familyMember.index + 1 //start from 1 - service issue
          });
        }
      }

      return dependents;
    }
  }
}