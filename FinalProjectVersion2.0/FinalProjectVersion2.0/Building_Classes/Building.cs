using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectVersion2._0
{
    /// <summary>
    /// This class represents a single building within the Terminated Leases Excel Report from Propertyware,
    /// the New Leases Excel Report from Propertyware, or the Final Report which is created by the program.
    /// </summary>
    public class Building
    {
        /// <summary>
        /// Represents the value in the "Building Abreviation" column on an excel report.
        /// </summary>
        public string BuildingAbbreviation { get; set; }
    }
}
