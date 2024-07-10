using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Wedia.Feature.EurobankHealthTool.Models;
using Sitecore.Data.Items;

namespace Wedia.Feature.EurobankHealthTool.Services
{
  public interface IExcelService
  {
    List<ProgramsData> GetProgramsData(Item item);
  }
}