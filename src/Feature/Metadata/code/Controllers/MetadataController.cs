using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Wedia.Feature.Metadata.Repositories;

namespace Wedia.Feature.Metadata.Controllers
{
    public class MetadataController : SitecoreController
    {
        private readonly MetadataRepository _metadataRepository;

        public MetadataController(MetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        // GET: Metadata
        public ActionResult PageMetadata()
        {
            var metadata = _metadataRepository.Get(RenderingContext.Current.Rendering.Item);
            return View(metadata);
        }
    }
}