using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Feature.EurolifeCalculatorTool
{
  public static class Constants
  {
    public const string Family_Target_Me = "me";
    public const string Family_Target_Family = "family";
    public const string Family_Target_Us = "us";
    public const string Family_Target_Child = "child";
    public const string Family_Member_Mother = "mother";
    public const string Family_Member_Father = "father";
    public const string Family_Member_Son = "son";
    public const string Family_Member_Daughter = "daughter";
    public const string Family_Member_Me = "me";
    public const string Family_Member_Child = "child";

    public static readonly string LifeWebApiURL = Sitecore.Configuration.Settings.GetSetting("EurolifeCalculatorTool.LifeWebApi.URL").ToString();

    public const long ExtraHospitalCareCode = 30292;
    public const long AccidentCare1Code = 17;
    public const long SeriusInjuriesCode = 30003;
    public const long PremiumSurgerysCode = 30113;
    public const long PremiumDiagnosticsCode = 30415;
  }
}