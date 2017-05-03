using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectVersion2._0.Building_Classes;

namespace FinalProjectVersion2._0.Dictionary_Classes
{
    /// <summary>
    /// This class represents a dictionary of <see cref="FinalReportBuilding"/> objects.
    /// </summary>
    public class FinalReportDictionary
    {
        /// <summary>
        /// This method combines a <see cref="TerminatedLeaseReportDictionary"/> and a <see cref="NewLeaseReportDictionary"/> into a single, summary dictionary.
        /// </summary>
        /// <param name="terminatedLeaseDictionary"></param>
        /// <param name="newLeaseDictionary"></param>
        /// <returns></returns>
        public Dictionary<int, FinalReportBuilding> CombineDictionaries(Dictionary<int, TerminatedLeaseReportBuilding> terminatedLeaseDictionary, Dictionary<int, NewLeaseReportBuilding> newLeaseDictionary)
        {
            // Perform a join operation on two dictionaries to get the data needed for the final report
            var query1 =
                 from item1 in terminatedLeaseDictionary
                 join item2 in newLeaseDictionary on item1.Value.BuildingAbbreviation equals item2.Value.BuildingAbbreviation
                 select new { item1.Value.BuildingAbbreviation, item1.Value.ChargeAmount, item2.Value.RentAmountOnLease };
            Dictionary<int, FinalReportBuilding> excelDictionary = new Dictionary<int, FinalReportBuilding>();
            int key = 0;
            foreach (var item in query1)
            {
                key++;
                char[] myChar = { '$' };
                double rentalRateChange = item.RentAmountOnLease - item.ChargeAmount;
                double percentRentChange = Math.Round(rentalRateChange / item.ChargeAmount, 3, MidpointRounding.AwayFromZero);
                FinalReportBuilding building = new FinalReportBuilding();
                building.BuildingAbbreviation = item.BuildingAbbreviation;
                building.OldRentAmount = item.ChargeAmount;
                building.NewRentAmount = item.RentAmountOnLease;
                building.DifferenceAmount = percentRentChange;
                excelDictionary[key] = building;
            }
            return excelDictionary;
        }
    }
}
