using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.News
{
  public struct Contants
  {
    public struct ImageDimensions
    {
      public const int LandingBannerWidth = 1740;
      public const int LandingBannerHeight = 604;
      public const int LandingBannerResponsiveWidth = 720;
      public const int LandingBannerResponsiveHeight = 604;
      public const int ArticleCardImageWidth = 328;
      public const int ArticleCardImageHeight = 200;
    }

    public struct LatestNews
    {
      public const int NumberOfArticles = 3;
    }
  }
}