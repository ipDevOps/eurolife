using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Wedia.Feature.Media.Models;
using Wedia.Feature.Media.Repositories;
using Sitecore.Sites;
using Wedia.Foundation.SitecoreExtensions.Utilities;
using Wedia.Foundation.SitecoreExtensions.Repositories;
using System.Net.Http;
using System.Net;
using System;
using System.Net.Http.Headers;
using System.IO;
using Sitecore.Diagnostics;

namespace Wedia.Feature.Media.Controllers
{
  public class MediaFeatureController : Controller
  {
    private readonly IMediaRepository _mediaRepository;

    private readonly IRenderingPropertiesRepository _renderingPropertiesRepository;

    public MediaFeatureController(IMediaRepository mediaRepository, IRenderingPropertiesRepository renderingPropertiesRepository)
    {
      _mediaRepository = mediaRepository;
      _renderingPropertiesRepository = renderingPropertiesRepository;
    }

    public ActionResult MediaFileFoldersGroupedListPricing(MediaFileGroupDto mediafileGroupDto)
    {
      var pagingSettings = _renderingPropertiesRepository.Get<PagingSettings>(RenderingContext.Current.Rendering);
      pagingSettings.CurrentGroupID = mediafileGroupDto.Group != null ? new ID(mediafileGroupDto.Group) : null;   

      var viewModel = _mediaRepository.GetFilesGroupedList(RenderingContext.Current.ContextItem, pagingSettings);
      return View(viewModel);
    }

    public ActionResult MediaFileFoldersGroupedList(MediaFileGroupDto mediafileGroupDto)
    {
      var pagingSettings = _renderingPropertiesRepository.Get<PagingSettings>(RenderingContext.Current.Rendering);
      pagingSettings.CurrentGroupID = mediafileGroupDto.Group != null ? new ID(mediafileGroupDto.Group) : null;

      var viewModel = _mediaRepository.GetFilesGroupedList(RenderingContext.Current.ContextItem, pagingSettings);
      return View(viewModel);
    }


    [HttpGet]
    public ActionResult AjaxMediaFileFolderGroupedList(MediaFileGroupDto mediafileGroupDto, int page = 1)
    {
      mediafileGroupDto.CurrentGroupID = new ID(mediafileGroupDto.Group);

      var viewModel = _mediaRepository.GetNextPage(mediafileGroupDto, page);

      if (viewModel.Files.Results == null)
        return Json(new { exhausted = true });
      
      var partial = Utilities.RenderRazorViewToString(ControllerContext, "MediaFileGroup", viewModel);
      return Json(new { exhausted = viewModel.TotalPagesCount == page + 1, data = partial }, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult AjaxMediaPricingDocs(string fileName)
    {     
      try
      {
        string path = $"~/pricedocs/{fileName}";
        string filePath = Server.MapPath(path);

        //first check for server files
        if (System.IO.File.Exists(filePath))
        {            
          byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
          return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        else //check for indexed items
        {
          string file = _mediaRepository.GetPricingDoc(fileName.Split('.')[0]);
          if(!string.IsNullOrEmpty(file))
          {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create($"{GetSiteRoot()}{file}");
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            MemoryStream ms = new MemoryStream();
            myResponse.GetResponseStream().CopyTo(ms);
            byte[] data = ms.ToArray();     

            return File(data, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
          }
        }
      }
      catch(Exception ex)
      {
        Log.Error($"AjaxMediaPricingDocs {fileName}", ex, this);
      }

      throw new Exception();
    }

    private string GetSiteRoot()
    {
      string port = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
      if (port == null || port == "80" || port == "443")
        port = "";
      else
        port = ":" + port;

      string protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
      if (protocol == null || protocol == "0")
        protocol = "http://";
      else
        protocol = "https://";

      string sOut = protocol + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + port + System.Web.HttpContext.Current.Request.ApplicationPath;

      if (sOut.EndsWith("/"))
      {
        sOut = sOut.Substring(0, sOut.Length - 1);
      }

      return sOut;
    }

  }
}