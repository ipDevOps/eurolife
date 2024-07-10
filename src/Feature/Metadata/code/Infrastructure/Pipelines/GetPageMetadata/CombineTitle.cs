using Wedia.Foundation.DependencyInjection;

namespace Wedia.Feature.Metadata.Infrastructure.Pipelines.GetPageMetadata
{
    [Service]
    public class CombineTitle
    {
        public void Process(GetPageMetadataArgs args)
        {
            args.Metadata.Title = $"{args.Metadata.PageTitle} - {args.Metadata.SiteTitle}";
        }
    }
}