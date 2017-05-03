using FinalProjectVersion2._0.Building_Classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVersion2._0.Main
{
    public class CreateFile
    {
        /// <summary>
        /// This method accepts a dictionary then creates an excel report based on the information 
        /// </summary>
        public void createFinalReportFile(Dictionary<int, FinalReportBuilding> combinedExcelReport)
        {
            // Set the file name and get the output directory.
            var fileName = "FinalReport" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Create the file using the FileInfo object.
            var file = new FileInfo(path + "\\" + fileName).Create();
            using (var package = new ExcelPackage(file))
            {
                // Add headers.
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells[1, 1].Value = "Building Abbreviation";
                worksheet.Cells[1, 2].Value = "Old Rent Amount";
                worksheet.Cells[1, 3].Value = "New Rent Amount";
                worksheet.Cells[1, 4].Value = "% Change in Rent";
                int rowCount = 1;
                // Add data from dictionary
                foreach (var entry in combinedExcelReport)
                {
                    rowCount++;
                    worksheet.Cells[rowCount, 1].Value = entry.Value.BuildingAbbreviation;
                    worksheet.Cells[rowCount, 2].Value = entry.Value.OldRentAmount;
                    worksheet.Cells[rowCount, 3].Value = entry.Value.NewRentAmount;
                    worksheet.Cells[rowCount, 4].Value = entry.Value.DifferenceAmount;
                }
                worksheet.Cells[rowCount + 2, 4].Formula = "= AVERAGE(D2, D" + rowCount + ")";
                worksheet.Cells[rowCount + 2, 3].Value = "Avg change in rent";
                worksheet.Cells.AutoFitColumns();
                package.Save();
            }
        }
    }
}
