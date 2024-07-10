using System;
using Sitecore.Data.Items;
using Wedia.Feature.Metadata.Infrastructure.Pipelines.GetPageMetadata;
using Wedia.Feature.Metadata.Models;
using Wedia.Foundation.DependencyInjection;
using Sitecore.Pipelines;

namespace Wedia.Feature.Metadata.Repositories
{
    [Service]
    public class MetadataRepository
    {
        public IMetadata Get(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var args = new GetPageMetadataArgs(new MetadataViewModel(), item);
            CorePipeline.Run("metadata.getPageMetadata", args);

            return args.Metadata;
        }
    }
}