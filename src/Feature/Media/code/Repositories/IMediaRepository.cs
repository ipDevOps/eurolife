using System;
using System.Collections.Generic;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Wedia.Feature.Media.Models;

namespace Wedia.Feature.Media.Repositories
{
  public interface IMediaRepository
  {
    FileGroups GetFilesGroupedList([NotNull] Item item, PagingSettings pagingSettings);
    FileGroup GetNextPage(PagingSettings pagingSettings, int page);
    string GetPricingDoc(string itemName);
  }
}
