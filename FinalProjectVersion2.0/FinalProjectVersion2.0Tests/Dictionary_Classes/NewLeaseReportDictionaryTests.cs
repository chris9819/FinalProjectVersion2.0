using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProjectVersion2._0.Dictionary_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProjectVersion2._0.Dictionary_Classes.Tests
{
    [TestClass()]
    public class NewLeaseReportDictionaryTests
    {
        [TestMethod()]
        public void NewLeaseReportDictionaryTest()
        {
            // Create a new TerminatedLeasesReportDictionary and fill it with data from the SampleNewLeasesReport.
            var excelDictionary = new NewLeaseReportDictionary().InitializeDictionary(new FileInfo("SampleNewLeasesReport.xlsx"), 8);
            // Print the data to the console.
            foreach (var entry in excelDictionary)
            {
                Console.WriteLine(string.Format("BuildingAbbriviation: {0} | PortfolioName: {1} | Status: {2} | AdStartDate: {3} | PropLeasedDate {4} | RentAmountOnLease {5}| ManagmentBeginDate {6}",
                    entry.Value.BuildingAbbreviation, entry.Value.PortfolioName, entry.Value.Status, entry.Value.AdvertisingStartDate, entry.Value.PropertyLeasedDate, entry.Value.RentAmountOnLease, entry.Value.ManagementBeginDate));
            }
        }
    }
}