using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectVersion2._0.Building_Classes;
using OfficeOpenXml;
using System.IO;
using System.Text.RegularExpressions;

namespace FinalProjectVersion2._0.Dictionary_Classes
{
    /// <summary>
    /// This class represents a dictionary of <see cref="TerminatedLeaseReportBuilding"/> objects.
    /// </summary>
    public class TerminatedLeaseReportDictionary
    {
        /// <summary>
        /// This method returns a dictionary object containing all excel data less duplicates in the "Terminated Leases"
        /// report.
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <param name="rowStart"></param>
        public Dictionary<int,TerminatedLeaseReportBuilding> InitializeDictionary(FileInfo fileLocation, int rowStart)
        {
            // Create a dictionary object to be returned.
            Dictionary<int, TerminatedLeaseReportBuilding> excelDictionary = new Dictionary<int, TerminatedLeaseReportBuilding>();
            // Create a new excel package from a file location to be used.
            using (var pck = new ExcelPackage(fileLocation))
            {
                // Create a new worksheet.
                var worksheet = pck.Workbook.Worksheets[1];
                // Set the row to start at.
                int rowCount = rowStart;
                do
                {
                    rowCount++;
                    // Select the current building row in the excel document in parallel and put it into a string array.
                    var queryParallel = (from cell in worksheet.Cells[string.Format("A{0}:G{0}", rowCount)] select cell).AsParallel();
                    string[] buildingRow = new string[7];
                    int i = 0;
                    foreach (var cell in queryParallel)
                    {
                        buildingRow[i] = cell.Value.ToString();
                        i++;
                    }
                    // Create a new building object to store the data within the string array.
                    TerminatedLeaseReportBuilding building = new TerminatedLeaseReportBuilding();
                    building.BuildingAbbreviation = buildingRow[0];
                    building.PortfolioAbbreviation = buildingRow[1];
                    building.PayeePayer = buildingRow[2];
                    building.Date = buildingRow[3];
                    building.AccountNumber = buildingRow[5];
                    building.AccountDescription = buildingRow[6];
                    // Special case for the charge amount column, as values can be stored as currency, numbers, or even text (with dollar sign symbols)
                    // The following code always throws a NullReference Exception, and I am not sure why (possible due to the last iteration of the do-while loop?).
                    try
                    {
                        if (buildingRow[4][0] == '$')
                        {
                            // Remove dollar sign before converting to double using a regex expression
                            string pattern = @"(\p{Sc}\s?)?(\d+\.?((?<=\.)\d+)?)(?(1)|\s?\p{Sc})?";
                            string replacement = "$2";
                            Regex rgx = new Regex(pattern);
                            string value = rgx.Replace(buildingRow[4], replacement);
                            building.ChargeAmount = Convert.ToDouble(value);
                        }
                        else
                        {
                            building.ChargeAmount = Convert.ToDouble(buildingRow[4]);
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                    }
                    // Put the current building into the dictionary
                    excelDictionary[rowCount] = building;
                } while (excelDictionary.Last().Value.BuildingAbbreviation != null);
                // Remove the last row of the excel dictionary that is empty.
                excelDictionary.Remove(rowCount);
            }
            return new TerminatedLeaseReportDictionary().TerminatedLeaseReportRemoveDuplicates(excelDictionary);
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
