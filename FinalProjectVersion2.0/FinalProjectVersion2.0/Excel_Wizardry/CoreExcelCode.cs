using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectVersion2._0.Building_Classes;

namespace FinalProjectVersion2._0.Excel_Wizardry
{
    /// <summary>
    /// This class contains the core methods for interacting with data from the various excel reports.
    /// </summary>
    class CoreExcelCode
    {
        /// <summary>
        /// This method accepts a fileLocation, and row to start at, and extracts the data from the termintated excel report and returns it as a dictionary object.
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <returns></returns>
        public Dictionary<int, TerminatedLeaseReportBuilding> TerminatedLeaseInitializeDictionary(FileInfo fileLocation, int row)
        {
            // Create a dictionary object to be returned.
            Dictionary<int, TerminatedLeaseReportBuilding> excelDictionary = new Dictionary<int, TerminatedLeaseReportBuilding>();
            // Create a new excel package from a file location to be used.
            using (var pck = new ExcelPackage(fileLocation))
            {
                // Create a new worksheet.
                var worksheet = pck.Workbook.Worksheets[1];
                // Set the rowCount.
                int rowCount = row;
                do
                {
                    rowCount++;
                    // Select the current building row in the excel document in parallel and put it into a string array.
                    var queryParallel = (from cell in worksheet.Cells[string.Format("A{0}:G{0}", rowCount)] select cell).AsParallel();
                    string[] buildingRow = new string[7];
                    buildingRow = queryParallel.Select(c => c.Value.ToString()).ToArray();
                    // Create a new building object to store the data within the string array.
                    TerminatedLeaseReportBuilding building = new TerminatedLeaseReportBuilding();
                    building.BuildingAbbreviation = buildingRow[0];
                    building.PortfolioAbbreviation = buildingRow[1];
                    building.PayeePayer = buildingRow[2];
                    building.Date = buildingRow[3];
                    building.AccountNumber = buildingRow[5];
                    building.AccountDescription = buildingRow[6];
                    // Special case for the "Charge Amount" columnn, as it may contain a null value, which throws an error when converting to a double.
                    if (buildingRow[4] == null)
                    { building.ChargeAmount = 0; }
                    else
                        building.ChargeAmount = Convert.ToDouble(buildingRow[4]);
                    // Put the current building into the dictionary
                    excelDictionary[rowCount] = building;
                } while (excelDictionary.Last().Value.BuildingAbbreviation != null);
                // Remove the last row of the excel dictionary that is empty.
                excelDictionary.Remove(rowCount);
            }
            // Remove duplicates from the dictionary, then return a dictionary object.
            return new CoreExcelCode().TerminatedLeaseReportRemoveDuplicates(excelDictionary);
        }

        /// <summary>
        /// Rremoves duplicate pairs from a "Terminated Leases" dictionary object.
        /// </summary>
        /// <param name="dictionary"></param>
        private Dictionary<int, TerminatedLeaseReportBuilding> TerminatedLeaseReportRemoveDuplicates(Dictionary<int, TerminatedLeaseReportBuilding> dictionary)
        {
            var uniqueValues = dictionary.
                OrderByDescending(pair => pair.Value.ChargeAmount)
                .GroupBy(pair => pair.Value.BuildingAbbreviation)
                .Select(group => group.First())
                .OrderBy(group => group.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            return uniqueValues;
        }
    }
}
