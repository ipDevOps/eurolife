using System;
using System.Text.RegularExpressions;

namespace Wedia.Foundation.SitecoreExtensions.Extensions
{
  public static class StringExtensions
  {
    public static string Humanize(this string input)
    {
      return Regex.Replace(input, "(\\B[A-Z])", " $1");
    }

    public static string ToCssUrlValue(this string url)
    {
      return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
    }

    public static string ToGreekFormat(this double? @this)
    {
      return @this?.ToString("#,##0.00", System.Globalization.CultureInfo.CreateSpecificCulture("el"));
    }
  }
}