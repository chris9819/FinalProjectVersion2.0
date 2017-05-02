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
    /// <summary>
    /// This class contains methods for testing the <see cref="TerminatedLeaseReportDictionary"/> class.
    /// </summary>
    [TestClass()]
    public class TerminatedLeaseReportDictionaryTests
    {
        /// <summary>
        /// This test method checks to see if an instance of the <see cref="TerminatedLeaseReportDictionary"/> can be created, and that data is added successfully.
        /// </summary>
        [TestMethod()]
        public void TerminatedLeaseReportDictionaryTest()
        {
            // Create a new TerminatedLeasesReportDictionary and fill it with data from the SampleTerminatedLeasesReport.
            var excelDictionary = new TerminatedLeaseReportDictionary().InitializeDictionary(new FileInfo("SampleTerminatedLeasesReport.xlsx"), 8);
            // Print the data to the console.
            foreach (var entry in excelDictionary)
            {
                Console.WriteLine(string.Format("BuildingAbbriviation: {0} | PortfolioAbbreviation: {1} | Payee/Payer: {2} | Date: {3} | Charge Amount {4} | Account Number {5}| Account Description {6}", 
                    entry.Value.BuildingAbbreviation, entry.Value.PortfolioAbbreviation, entry.Value.PayeePayer,entry.Value.Date, entry.Value.ChargeAmount,entry.Value.AccountNumber,entry.Value.AccountDescription));
            }
        }
    }
}