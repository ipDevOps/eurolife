﻿using Wedia.Foundation.Assets.Repositories;
using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

namespace Wedia.Foundation.Assets.Pipelines.GetPageRendering
{
    public class ClearAssets : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            AssetRepository.Current.Clear();
        }
    }
}