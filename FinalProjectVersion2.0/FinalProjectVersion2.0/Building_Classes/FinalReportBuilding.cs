using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVersion2._0.Building_Classes
{
    /// <summary>
    /// This class represents a single building in the final excel report created by the program.
    /// </summary>
    public class FinalReportBuilding: Building
    {
        /// <summary>
        /// Represents the value in the "Old Rent Amount" column in the final report.
        /// </summary>
        public double OldRentAmount { get; set; }
        /// <summary>
        /// Represents the value in the "New Rent Amount" column in the final report.
        /// </summary>
        public double NewRentAmount { get; set; }
        /// <summary>
        /// Represents the value in the "Difference Amount" column in the final report.
        /// </summary>
        public double DifferenceAmount { get; set; }
    }
}
