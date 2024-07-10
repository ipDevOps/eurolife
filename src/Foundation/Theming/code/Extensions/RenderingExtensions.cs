using System.Web.Mvc;
using Sitecore.Data;
using Wedia.Foundation.SitecoreExtensions.Extensions;
using Wedia.Foundation.Theming.Extensions.Controls;
using Sitecore.Mvc.Presentation;
using Sitecore;

namespace Wedia.Foundation.Theming.Extensions
{
  public static class RenderingExtensions
  {
    public static CarouselOptions GetCarouselOptions([NotNull] this Rendering rendering)
    {
      return new CarouselOptions
             {
               ItemsShown = rendering.GetIntegerParameter(Constants.CarouselLayoutParameters.ItemsShown, 3),
               AutoPlay = rendering.GetIntegerParameter(Constants.CarouselLayoutParameters.Autoplay, 1) == 1,
               ShowNavigation = rendering.GetIntegerParameter(Constants.CarouselLayoutParameters.ShowNavigation) == 1
             };
    }

    public static string GetBackgroundClass([NotNull] this Rendering rendering)
    {
      var id = MainUtil.GetID(rendering.Parameters[Constants.BackgroundLayoutParameters.Background] ?? "", null);
      if (ID.IsNullOrEmpty(id))
        return "";
      var item = rendering.RenderingItem.Database.GetItem(id);
      return item?[Templates.Style.Fields.Class] ?? "";
    }

    public static string GetFontColorClass([NotNull] this Rendering rendering)
    {
      var id = MainUtil.GetID(rendering.Parameters[Constants.FontColorLayoutParameters.FontColor] ?? "", null);

      if (ID.IsNullOrEmpty(id))
        return "";

      var item = rendering.RenderingItem.Database.GetItem(id);
      return item?[Templates.Style.Fields.Class] ?? "";
    }

    public static string GetAlignmentClass([NotNull] this Rendering rendering)
    {
      var id = MainUtil.GetID(rendering.Parameters[Constants.AlignItemsParameters.Alignment] ?? "", null);

      if (ID.IsNullOrEmpty(id))
        return "";

      var item = rendering.RenderingItem.Database.GetItem(id);
      return item?[Templates.Style.Fields.Class] ?? "";
    }

    public static bool IsFixedHeight([NotNull] this Rendering rendering)
    {
      var isFixed = MainUtil.GetBool(rendering.Parameters[Constants.IsFixedHeightLayoutParameters.FixedHeight] ?? "", false);
      return isFixed;
    }

    public static int GetHeight([NotNull] this Rendering rendering)
    {
      return MainUtil.GetInt(rendering.Parameters[Constants.IsFixedHeightLayoutParameters.Height] ?? "", 0);
    }

    public static string GetContainerClass([NotNull] this Rendering rendering)
    {
      return rendering.IsContainerFluid() ? "center center--1100" : "";
    }

    public static bool IsContainerFluid([NotNull] this Rendering rendering)
    {
      return MainUtil.GetBool(rendering.Parameters[Constants.HasContainerLayoutParameters.IsFluid], false);
    }

    public static BackgroundRendering RenderBackground([NotNull] this Rendering rendering, HtmlHelper helper)
    {
      return new BackgroundRendering(helper.ViewContext.Writer, rendering.GetBackgroundClass());
    }

    public static FontColorRendering RenderFontColor([NotNull] this Rendering rendering, HtmlHelper helper)
    {
      return new FontColorRendering(helper.ViewContext.Writer, rendering.GetFontColorClass());
    }
  }
}