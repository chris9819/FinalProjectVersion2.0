using FinalProjectVersion2._0.Building_Classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalProjectVersion2._0.Dictionary_Classes
{
    /// <summary>
    /// This method returns a dictionary object containing excel data in the "New Leases" report.
    /// </summary>
    public class NewLeaseReportDictionary
    {
        /// <summary>
        /// This method returns a dictionary object containing excel data in the "New Leases" report
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <param name="rowStart"></param>
        public Dictionary<int, NewLeaseReportBuilding> InitializeDictionary(FileInfo fileLocation, int rowStart)
        {
            // Create a dictionary object to be returned.
            Dictionary<int, NewLeaseReportBuilding> excelDictionary = new Dictionary<int, NewLeaseReportBuilding>();
            // Create a new excel package from a file location to be used.
            using (var pck = new ExcelPackage(fileLocation))
            {
                // Select the first worksheet in the excel file.
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
                    // Not sure why a null reference exception is thrown here.
                    try
                    {
                        foreach (var cell in queryParallel)
                        {
                            buildingRow[i] = cell.Value.ToString();
                            i++;
                        }
                    }
                    catch (NullReferenceException)
                    {
                    }
                    // Create a new building object to store the data within the string array.
                    NewLeaseReportBuilding building = new NewLeaseReportBuilding();
                    building.BuildingAbbreviation = buildingRow[0];
                    building.PortfolioName = buildingRow[1];
                    building.Status = buildingRow[2];
                    building.AdvertisingStartDate = buildingRow[3];
                    building.PropertyLeasedDate = buildingRow[4];
                    building.ManagementBeginDate = buildingRow[6];
                    // Special case for the "Rent Amount on Lease"  column, as values can be stored as currency, numbers, or even text (with dollar sign symbols)
                    // The following code always throws a NullReference Exception, and I am not sure why (possibly due to the last iteration of the do-while loop?).
                    try
                    {
                        if (buildingRow[5][0] == '$')
                        {
                            // Remove dollar sign before converting to double using a regex expression
                            string pattern = @"(\p{Sc}\s?)?(\d+\.?((?<=\.)\d+)?)(?(1)|\s?\p{Sc})?";
                            string replacement = "$2";
                            Regex rgx = new Regex(pattern);
                            string value = rgx.Replace(buildingRow[5], replacement);
                            building.RentAmountOnLease = Convert.ToDouble(value);
                        }
                        else
                        {
                            building.RentAmountOnLease = Convert.ToDouble(buildingRow[5]);
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
            return excelDictionary;
        }
    }
}
