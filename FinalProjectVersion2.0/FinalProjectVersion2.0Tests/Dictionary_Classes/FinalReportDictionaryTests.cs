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
    public class FinalReportDictionaryTests
    {
        [TestMethod()]
        public void CombineDictionariesTest()
        {
            // Create a new TerminatedLeasesReportDictionary and fill it with data from the SampleTerminatedLeasesReport.
            var excelDictionaryTerminatedLeases = new TerminatedLeaseReportDictionary().InitializeDictionary(new FileInfo("SampleTerminatedLeasesReport.xlsx"), 8);
            // Create a new TerminatedLeasesReportDictionary and fill it with data from the SampleNewLeasesReport.
            var excelDictionaryNewLeases = new NewLeaseReportDictionary().InitializeDictionary(new FileInfo("SampleNewLeasesReport.xlsx"), 8);
            // Create a new FinalReportDictionary from the previous two.
            var excelDictionaryFinalReport = new FinalReportDictionary().CombineDictionaries(excelDictionaryTerminatedLeases, excelDictionaryNewLeases);
            // Print to the console.
            foreach (var entry in excelDictionaryFinalReport)
            {
                Console.WriteLine(string.Format("BuildingAbbriviation: {0} | OldRentAmount: {1} | NewRentAmount: {2} | ChangeInRent: {3}",
                    entry.Value.BuildingAbbreviation, entry.Value.OldRentAmount, entry.Value.NewRentAmount, entry.Value.DifferenceAmount));
            }
        }
    }
}