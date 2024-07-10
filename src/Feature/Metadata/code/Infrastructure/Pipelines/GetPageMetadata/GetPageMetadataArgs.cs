using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Wedia.Feature.Metadata.Models;

namespace Wedia.Feature.Metadata.Infrastructure.Pipelines.GetPageMetadata
{
    public class GetPageMetadataArgs : Sitecore.Pipelines.PipelineArgs
    {
        public GetPageMetadataArgs(IMetadata metadata, Item item)
        {
            this.Metadata = metadata;
            this.Item = item;
        }

        public IMetadata Metadata { get; }
        public Item Item { get; }
    }
}