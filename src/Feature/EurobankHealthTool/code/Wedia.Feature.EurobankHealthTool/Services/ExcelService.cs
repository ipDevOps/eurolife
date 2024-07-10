using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Wedia.Feature.EurobankHealthTool.Models;
using Wedia.Foundation.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore;
using OfficeOpenXml;
using System.Reflection.Emit;
using Sitecore.Mvc.Extensions;

namespace Wedia.Feature.EurobankHealthTool.Services
{
  [Service(typeof(IExcelService))]
  public class ExcelService : IExcelService
  {


    #region Utilities      
    protected virtual int GetColumnIndex(string[] properties, string columnName)
    {
      if (properties == null)
        throw new ArgumentNullException("properties");

      if (columnName == null)
        throw new ArgumentNullException("columnName");

      for (int i = 0; i < properties.Length; i++)
        if (properties[i].Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
          return i + 1; //excel indexes start from 1
      return 0;
    }   
    #endregion


    #region Methods
    public List<ProgramsData> GetProgramsData(Item item)
    {
      try
      {
        Sitecore.Data.Fields.FileField fileField = item.Fields[Templates.HasExcelTemplate.Fields.ExcelFile];
        var list = new List<ProgramsData>();

        if (fileField != null)
        {
          Item mediaItem = Context.Database.GetItem(fileField.MediaID);
          var stream = Sitecore.Resources.Media.MediaManager.GetMedia(mediaItem).GetStream().Stream;

          using (var xlPackage = new ExcelPackage(stream))
          {
            foreach (var worksheet in xlPackage.Workbook.Worksheets)
            {
              var properties = new[]
              {
                    "AGE",
                    "CODE",
                    "PREMIUM",
                    "PREMIUMPERMILE",
                    "FINALPRICE"
              };

              int iRow = 2;

              while (true)
              {
                bool allColumnsAreEmpty = true;
                for (var i = 1; i <= properties.Length; i++)
                  if (worksheet.Cells[iRow, i].Value != null && !String.IsNullOrEmpty(worksheet.Cells[iRow, i].Value.ToString()))
                  {
                    allColumnsAreEmpty = false;
                    break;
                  }
                if (allColumnsAreEmpty)
                  break;


                var programsData = new ProgramsData
                {
                  Age = worksheet.Cells[iRow, GetColumnIndex(properties, "AGE")].Value != null
                  ? int.Parse(worksheet.Cells[iRow, GetColumnIndex(properties, "AGE")].Value.ToString())
                  : 0,
                  Programs = new List<Program>
                  {
                    new Program
                    {
                      PremiumCode =  worksheet.Cells[iRow, GetColumnIndex(properties, "CODE")].Value != null
                      ? worksheet.Cells[iRow, GetColumnIndex(properties, "CODE")].Value.ToString()
                      : string.Empty,

                      PremiumPrice = worksheet.Cells[iRow, GetColumnIndex(properties, "PREMIUM")].Value != null
                      ? double.Parse(worksheet.Cells[iRow, GetColumnIndex(properties, "PREMIUM")].Value.ToString())
                      : 0,

                      PremiumPerMille = worksheet.Cells[iRow, GetColumnIndex(properties, "PREMIUMPERMILE")].Value != null
                      ? double.Parse(worksheet.Cells[iRow, GetColumnIndex(properties, "PREMIUMPERMILE")].Value.ToString())
                      : 0,

                      PremiumFinalPrice = worksheet.Cells[iRow, GetColumnIndex(properties, "FINALPRICE")].Value != null
                      ? double.Parse(worksheet.Cells[iRow, GetColumnIndex(properties, "FINALPRICE")].Value.ToString())
                      : 0
                    }
                  }
                };

                list.Add(programsData);
                iRow++;
              }
            }
          }
        }

        var groupedList = list
        .GroupBy(d => new { d.Age })
        .Select(g => new ProgramsData
        {
          Age = g.Key.Age,
          Programs = g.SelectMany(i => i.Programs).ToList()
        }).ToList();


        return groupedList;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    #endregion
  }
}